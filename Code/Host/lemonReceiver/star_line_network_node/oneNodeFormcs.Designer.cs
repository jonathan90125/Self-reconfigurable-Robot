namespace lemonReceiver.star_line_network_node
{
	partial class oneNodeFormcs
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tL = new System.Windows.Forms.Label();
			this.close = new System.Windows.Forms.Button();
			this.aL = new System.Windows.Forms.Label();
			this.hL = new System.Windows.Forms.Label();
			this.lL = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// tL
			// 
			this.tL.AutoSize = true;
			this.tL.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.tL.Location = new System.Drawing.Point(12, 30);
			this.tL.Name = "tL";
			this.tL.Size = new System.Drawing.Size(67, 21);
			this.tL.TabIndex = 0;
			this.tL.Text = "温度: 无";
			// 
			// close
			// 
			this.close.BackColor = System.Drawing.Color.Transparent;
			this.close.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.close.Location = new System.Drawing.Point(70, 102);
			this.close.Name = "close";
			this.close.Size = new System.Drawing.Size(57, 32);
			this.close.TabIndex = 1;
			this.close.Text = "关闭";
			this.close.UseVisualStyleBackColor = false;
			this.close.Click += new System.EventHandler(this.button1_Click);
			// 
			// aL
			// 
			this.aL.AutoSize = true;
			this.aL.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.aL.Location = new System.Drawing.Point(12, 9);
			this.aL.Name = "aL";
			this.aL.Size = new System.Drawing.Size(67, 21);
			this.aL.TabIndex = 0;
			this.aL.Text = "地址: 无";
			// 
			// hL
			// 
			this.hL.AutoSize = true;
			this.hL.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.hL.Location = new System.Drawing.Point(12, 51);
			this.hL.Name = "hL";
			this.hL.Size = new System.Drawing.Size(67, 21);
			this.hL.TabIndex = 0;
			this.hL.Text = "湿度: 无";
			// 
			// lL
			// 
			this.lL.AutoSize = true;
			this.lL.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lL.Location = new System.Drawing.Point(12, 72);
			this.lL.Name = "lL";
			this.lL.Size = new System.Drawing.Size(67, 21);
			this.lL.TabIndex = 0;
			this.lL.Text = "光照: 无";
			// 
			// oneNodeFormcs
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(193, 146);
			this.Controls.Add(this.close);
			this.Controls.Add(this.aL);
			this.Controls.Add(this.lL);
			this.Controls.Add(this.hL);
			this.Controls.Add(this.tL);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "oneNodeFormcs";
			this.Text = "oneNodeFormcs";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label tL;
		private System.Windows.Forms.Button close;
		private System.Windows.Forms.Label aL;
		private System.Windows.Forms.Label hL;
		private System.Windows.Forms.Label lL;
	}
}