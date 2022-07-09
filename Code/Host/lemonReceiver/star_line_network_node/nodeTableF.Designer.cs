namespace lemonReceiver.star_line_network_node
{
	partial class nodeTableF
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
			this.mainT = new System.Windows.Forms.TreeView();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.nodeNumL = new System.Windows.Forms.ToolStripStatusLabel();
			this.onNodNumL = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.searchTB = new System.Windows.Forms.ToolStripTextBox();
			this.sortCB = new System.Windows.Forms.ToolStripComboBox();
			this.statusStrip1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainT
			// 
			this.mainT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.mainT.BackColor = System.Drawing.Color.White;
			this.mainT.Location = new System.Drawing.Point(12, 28);
			this.mainT.Name = "mainT";
			this.mainT.Size = new System.Drawing.Size(260, 381);
			this.mainT.TabIndex = 0;
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nodeNumL,
            this.onNodNumL});
			this.statusStrip1.Location = new System.Drawing.Point(0, 462);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(284, 22);
			this.statusStrip1.TabIndex = 3;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// nodeNumL
			// 
			this.nodeNumL.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.nodeNumL.ForeColor = System.Drawing.Color.MediumBlue;
			this.nodeNumL.Name = "nodeNumL";
			this.nodeNumL.Size = new System.Drawing.Size(94, 17);
			this.nodeNumL.Text = "注册节点数目: 0";
			// 
			// onNodNumL
			// 
			this.onNodNumL.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.onNodNumL.ForeColor = System.Drawing.Color.DarkGreen;
			this.onNodNumL.Name = "onNodNumL";
			this.onNodNumL.Size = new System.Drawing.Size(114, 17);
			this.onNodNumL.Text = "已开启的节点数目:0";
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchTB,
            this.sortCB});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(284, 25);
			this.toolStrip1.TabIndex = 4;
			this.toolStrip1.Text = "地址值";
			// 
			// searchTB
			// 
			this.searchTB.Name = "searchTB";
			this.searchTB.Size = new System.Drawing.Size(100, 25);
			this.searchTB.Text = "find";
			// 
			// sortCB
			// 
			this.sortCB.BackColor = System.Drawing.SystemColors.Window;
			this.sortCB.Items.AddRange(new object[] {
            "原始顺序",
            "地址值",
            "节点状态"});
			this.sortCB.Name = "sortCB";
			this.sortCB.Size = new System.Drawing.Size(100, 25);
			// 
			// nodeTableF
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 484);
			this.ControlBox = false;
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.mainT);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(300, 500);
			this.Name = "nodeTableF";
			this.Text = "节点列表";
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TreeView mainT;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel nodeNumL;
		private System.Windows.Forms.ToolStripStatusLabel onNodNumL;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripTextBox searchTB;
		private System.Windows.Forms.ToolStripComboBox sortCB;
	}
}