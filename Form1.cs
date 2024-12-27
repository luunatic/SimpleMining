using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Mines
{
	public partial class Form1 : Form
	{
		private RadioButton[] levels;
		private List<Button> Field = new List<Button>();
		private enum BlockState
		{
			Init,
			Flag,
			Mined
		};
		private List<BlockState> FieldState = new List<BlockState>();
		private List<int> BombMap = new List<int>();
		private Dictionary<RadioButton, int> gridSize;
		private DataGridViewTextBoxColumn[] cols;
		private bool GameOn = false;
		private bool FirstClick = true;
		private int countMine = 0;
		private Stopwatch stopwatch = new Stopwatch();
		Task taskTimer;
		CancellationToken tokenTimer;
		CancellationTokenSource tsTimer;
		int size = 10;
		public Form1()
		{
			System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;

			InitializeComponent();
			InitializeSizeDic();
			InitializeLevels();
			this.Board.Size = new Size(0, 0);
			this.Size = new Size(this.panel1.Width + 30, this.panel1.Height);
			button_result.Paint +=button1_Paint;
		}

		private void button1_Paint(object sender, PaintEventArgs e)
		{
			Button btn = sender as Button;
			Image img = btn.ImageList.Images[btn.ImageIndex]; // 获取图片
			
			// 调整图片大小以适应按钮
			Image resizedImg = new Bitmap(img, new Size(btn.Width, btn.Height));

			// 绘制图片
			e.Graphics.DrawImage(resizedImg, 0, 0, btn.Width, btn.Height);
		}
		private void InitializeSizeDic()
		{
			gridSize = new Dictionary<RadioButton, int>() { [radio_level1] = 10, [radio_level2] = 15, [radio_level3] = 20 };
		}
		private void InitializeLevels()
		{
			levels = new RadioButton[] { radio_level1, radio_level2, radio_level3 };
		}
		private void PaintBlankCanvas()
		{
			int a = 50;
			//获取扫雷棋盘的尺寸，也是埋雷个数
			foreach (RadioButton rb in levels)
			{
				if (rb.Checked)
				{
					size = gridSize[rb];
				}
			}
			this.panel1.Dock = DockStyle.Right;
			Board.Size = new Size(a * (size) + 50, a * (size) + 10);
			Board.Controls.Clear();
			Field.Clear();
			FieldState.Clear();

			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < size; j++)
				{
					Button button = new Button()
					{
						Location = new Point(i * a, j * a),
						Size = new Size(a, a),
						BackColor = Color.White,

					};
					button.MouseDown += BlockClick;

					Board.Controls.Add(button);
					Field.Add(button);
					FieldState.Add(BlockState.Init);
				}
			}
			int boardsize = a*size;
			int panel1width = panel1.Width;
			this.Size = new Size(panel1width + boardsize, boardsize);
		}
		//po表示第一次单机画布时候的位置
		private void InitializeCanvas(Point p0)
		{
			int size = 0;
			//获取扫雷棋盘的尺寸，也是埋雷个数
			foreach (RadioButton rb in levels)
			{
				if (rb.Checked)
				{
					size = gridSize[rb];
				}
			}
			//Canvas保存棋盘布局
			//bombs保存炸弹位置
			List<Point> bombs = new List<Point>(size);
			for (int i = 0; i < size * size; i++)
			{
				BombMap.Add(0);
			}
			int x;
			int y;
			//随机选择size个不同的点放置炸弹
			for (int i = 0; i < size; i++)
			{
				Random random = new Random();
				x = random.Next(size);
				y = random.Next(size);
				//注意炸弹不能放在初始点下的位置
				while (bombs.Contains(p0))
				{
					x = random.Next(size);
					y = random.Next(size);
				}
				while (bombs.Contains(new Point(x, y)))
				{
					x = random.Next(size);
					y = random.Next(size);
				}
				bombs.Add(new Point(x, y));
			}

			//数一数空格旁边有几个炸弹
			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < size; j++)
				{
					if (bombs.Contains(new Point(i, j)))
					{
						BombMap[i * size + j] = int.MaxValue;
						continue;
					}

					//初始化为0
					int count = 0;
					for (int dx = -1; dx <= 1; dx++)
					{
						//count存放炸弹数量

						for (int dy = -1; dy <= 1; dy++)
						{
							if (dx == 0 && dy == 0) continue;
							int nx = i + dx;
							int ny = j + dy;
							if (nx < 0 || nx >= size || ny < 0 || ny >= size) continue;
							if (bombs.Contains(new Point(nx, ny)))
							{
								count++;
							}
						}

					}
					BombMap[i * size + j] = count;
				}
			}
		}
		#region radioButton互斥属性实现
		private void radio_level1_CheckedChanged(object sender, EventArgs e)
		{
			radio_level1.Checked = true;
			radio_level2.Checked = false;
			radio_level3.Checked = false;
		}

		private void radio_level2_CheckedChanged(object sender, EventArgs e)
		{
			radio_level2.Checked = true;
			radio_level1.Checked = false;
			radio_level3.Checked = false;
		}

		private void radio_level3_CheckedChanged(object sender, EventArgs e)
		{
			radio_level3.Checked = true;
			radio_level2.Checked = false;
			radio_level1.Checked = false;
		}
		#endregion
		private string TimerLabel(int second)
		{
			//若时长超过1小时
			if (second >= 60 * 60)
			{
				return "超过1小时";
			}
			string min = Convert.ToString(second / 60).PadLeft(2, '0');
			string sec = Convert.ToString(second % 60).PadLeft(2, '0');
			return min + ":" + sec;
		}
		public async Task RunAsyncTimer(CancellationToken ct)
		{
			if (ct.IsCancellationRequested) return;
			await Task.Run(() => UpdateTImer(ct), ct);
		}
		private void UpdateTImer(CancellationToken token)
		{
			while (!token.IsCancellationRequested)
			{
				label_timer.Invoke((EventHandler)delegate
				{
					label_timer.Text = "计时  " + TimerLabel((int)(stopwatch.ElapsedMilliseconds / 1000));
				});
				Thread.Sleep(200);
			}

		}
		private void button_restart_Click(object sender, EventArgs e)
		{
			Thread.Sleep(500);
			if (!GameOn)
			{
				GameOn = true;
				FirstClick = true;
				button_result.ImageIndex = 2;
				stopwatch.Reset();
				stopwatch.Start();
				tsTimer = new CancellationTokenSource();
				tokenTimer = tsTimer.Token;
				taskTimer = RunAsyncTimer(tokenTimer);
				PaintBlankCanvas();
				button_restart.Text = "放弃";

			}
			else
			{
				GameOn = false;
				stopwatch.Stop();
				tsTimer.Cancel();
				button_result.ImageIndex = 0;
				button_restart.Text = "重新开始";
			}
		}    
		private void BlockClick(object sender, MouseEventArgs e)
		{
			//若未开始游戏，点击无效
			if (!GameOn) return;
			Button b = sender as Button;
			//若点击的不是button控件，无效
			if (b == null) return;
			int id = Field.IndexOf(b);
			//若点击的button不属于Field列表，无效
			if (id == -1) return;
			//若当前块被置标志，不动作
			if (e.Button == MouseButtons.Right)
			{
				//若当前块已经点开，返回
				if (FieldState[id] == BlockState.Mined) return;
				if (FieldState[id] != BlockState.Flag)
				{
					FieldState[id] = BlockState.Flag;
					b.Text = "F";
					b.BackColor = Color.Yellow;
				}
				else
				{
					FieldState[id] = BlockState.Init;
					b.Text = "";
					b.BackColor = Color.White;
				}
			}
			else
			{
				if (FieldState[id] == BlockState.Flag) return;
				FieldState[id] = BlockState.Mined;
				int row = id / size;
				int col = id % size;
				if (FirstClick)
				{
					InitializeCanvas(new Point(row, col));
					FirstClick = false;
					countMine = 1;
				}

				int curr = BombMap[row * size + col];
				if (curr == int.MaxValue)
				{
					b.Text = "*";
					b.BackColor = Color.Red;
					GameOn = false;
					button_restart.Text = "重新开始";
					tsTimer?.Cancel();
					button_result.ImageIndex = 0;
					MessageBox.Show("You died", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

					return;

				}
				else
				{
					if (curr == 0)
					{
						b.Text = "";
					}
					else
					{
						b.Text = curr.ToString();
					}
					b.BackColor = Color.Green;
					countMine++;
				}

				if (countMine == size * size - size)
				{
					button_result.ImageIndex = 1;
					MessageBox.Show("You WON");
					GameOn = false;
					return;
				}
			}

		}

	}
}