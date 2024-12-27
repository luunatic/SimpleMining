using System.Drawing;
using System.Windows.Forms;

namespace Mines
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.button_result = new System.Windows.Forms.Button();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.label_timer = new System.Windows.Forms.Label();
			this.radio_level1 = new System.Windows.Forms.RadioButton();
			this.radio_level2 = new System.Windows.Forms.RadioButton();
			this.radio_level3 = new System.Windows.Forms.RadioButton();
			this.Board = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.button_restart = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// button_result
			// 
			this.button_result.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.button_result.Dock = System.Windows.Forms.DockStyle.Top;
			this.button_result.Enabled = false;
			this.button_result.FlatAppearance.BorderColor = System.Drawing.Color.White;
			this.button_result.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button_result.ImageIndex = 2;
			this.button_result.ImageList = this.imageList1;
			this.button_result.Location = new System.Drawing.Point(0, 0);
			this.button_result.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.button_result.Name = "button_result";
			this.button_result.Size = new System.Drawing.Size(162, 94);
			this.button_result.TabIndex = 2;
			this.button_result.UseVisualStyleBackColor = false;
			this.button_result.UseWaitCursor = true;
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "lose.jpg");
			this.imageList1.Images.SetKeyName(1, "win.jpg");
			this.imageList1.Images.SetKeyName(2, "default.jpg");
			// 
			// label_timer
			// 
			this.label_timer.AutoSize = true;
			this.label_timer.Dock = System.Windows.Forms.DockStyle.Top;
			this.label_timer.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Bold);
			this.label_timer.Location = new System.Drawing.Point(0, 136);
			this.label_timer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label_timer.Name = "label_timer";
			this.label_timer.Size = new System.Drawing.Size(146, 31);
			this.label_timer.TabIndex = 4;
			this.label_timer.Text = "计时 00：00";
			// 
			// radio_level1
			// 
			this.radio_level1.AutoSize = true;
			this.radio_level1.Checked = true;
			this.radio_level1.Dock = System.Windows.Forms.DockStyle.Top;
			this.radio_level1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
			this.radio_level1.Location = new System.Drawing.Point(0, 229);
			this.radio_level1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.radio_level1.Name = "radio_level1";
			this.radio_level1.Size = new System.Drawing.Size(162, 31);
			this.radio_level1.TabIndex = 5;
			this.radio_level1.TabStop = true;
			this.radio_level1.Text = "初级（10阶）";
			this.radio_level1.UseVisualStyleBackColor = true;
			this.radio_level1.Click += new System.EventHandler(this.radio_level1_CheckedChanged);
			// 
			// radio_level2
			// 
			this.radio_level2.AutoSize = true;
			this.radio_level2.Dock = System.Windows.Forms.DockStyle.Top;
			this.radio_level2.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
			this.radio_level2.Location = new System.Drawing.Point(0, 198);
			this.radio_level2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.radio_level2.Name = "radio_level2";
			this.radio_level2.Size = new System.Drawing.Size(162, 31);
			this.radio_level2.TabIndex = 6;
			this.radio_level2.Text = "中级（15阶）";
			this.radio_level2.UseVisualStyleBackColor = true;
			this.radio_level2.Click += new System.EventHandler(this.radio_level2_CheckedChanged);
			// 
			// radio_level3
			// 
			this.radio_level3.AutoSize = true;
			this.radio_level3.Dock = System.Windows.Forms.DockStyle.Top;
			this.radio_level3.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
			this.radio_level3.Location = new System.Drawing.Point(0, 167);
			this.radio_level3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.radio_level3.Name = "radio_level3";
			this.radio_level3.Size = new System.Drawing.Size(162, 31);
			this.radio_level3.TabIndex = 7;
			this.radio_level3.Text = "高级（20阶）";
			this.radio_level3.UseVisualStyleBackColor = true;
			this.radio_level3.Click += new System.EventHandler(this.radio_level3_CheckedChanged);
			// 
			// Board
			// 
			this.Board.AutoSize = true;
			this.Board.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Board.Location = new System.Drawing.Point(0, 0);
			this.Board.Margin = new System.Windows.Forms.Padding(2);
			this.Board.Name = "Board";
			this.Board.Size = new System.Drawing.Size(924, 395);
			this.Board.TabIndex = 8;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.radio_level1);
			this.panel1.Controls.Add(this.radio_level2);
			this.panel1.Controls.Add(this.radio_level3);
			this.panel1.Controls.Add(this.label_timer);
			this.panel1.Controls.Add(this.button_restart);
			this.panel1.Controls.Add(this.button_result);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel1.Location = new System.Drawing.Point(924, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(162, 395);
			this.panel1.TabIndex = 9;
			// 
			// button_restart
			// 
			this.button_restart.Dock = System.Windows.Forms.DockStyle.Top;
			this.button_restart.Location = new System.Drawing.Point(0, 94);
			this.button_restart.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.button_restart.Name = "button_restart";
			this.button_restart.Size = new System.Drawing.Size(162, 42);
			this.button_restart.TabIndex = 3;
			this.button_restart.Text = "重新开始";
			this.button_restart.UseVisualStyleBackColor = true;
			this.button_restart.Click += new System.EventHandler(this.button_restart_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1086, 395);
			this.Controls.Add(this.Board);
			this.Controls.Add(this.panel1);
			this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.Name = "Form1";
			this.Text = "扫雷";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private Button button_result;
		private Label label_timer;
		private RadioButton radio_level1;
		private RadioButton radio_level2;
		private RadioButton radio_level3;
		private ImageList imageList1;
		private Panel Canvas;
		private Panel Board;
		private Panel panel1;
		private Button button_restart;
	}
}