namespace thSensor
{
    partial class mainF
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.mainDGV = new System.Windows.Forms.DataGridView();
            this.temperature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.humidity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.redOn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.partt = new System.Windows.Forms.DataGridViewButtonColumn();
            this.part2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.part3 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.mainCP = new thSensor.ToNode.ComPortControl();
            ((System.ComponentModel.ISupportInitialize)(this.mainDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(0, 306);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(512, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.StatusStrip1_ItemClicked);
            // 
            // mainDGV
            // 
            this.mainDGV.AllowUserToAddRows = false;
            this.mainDGV.AllowUserToDeleteRows = false;
            this.mainDGV.AllowUserToOrderColumns = true;
            this.mainDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mainDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.temperature,
            this.humidity,
            this.redOn,
            this.partt,
            this.part2,
            this.part3});
            this.mainDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainDGV.Location = new System.Drawing.Point(0, 0);
            this.mainDGV.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mainDGV.Name = "mainDGV";
            this.mainDGV.ReadOnly = true;
            this.mainDGV.RowHeadersWidth = 80;
            this.mainDGV.RowTemplate.Height = 23;
            this.mainDGV.Size = new System.Drawing.Size(512, 306);
            this.mainDGV.TabIndex = 2;
            this.mainDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.mainDGV_CellContentClick);
            // 
            // temperature
            // 
            this.temperature.HeaderText = " ";
            this.temperature.MinimumWidth = 6;
            this.temperature.Name = "temperature";
            this.temperature.ReadOnly = true;
            this.temperature.Width = 56;
            // 
            // humidity
            // 
            this.humidity.HeaderText = "time";
            this.humidity.MinimumWidth = 6;
            this.humidity.Name = "humidity";
            this.humidity.ReadOnly = true;
            this.humidity.Width = 56;
            // 
            // redOn
            // 
            this.redOn.HeaderText = "activate coil 1";
            this.redOn.MinimumWidth = 6;
            this.redOn.Name = "redOn";
            this.redOn.ReadOnly = true;
            this.redOn.Width = 80;
            // 
            // partt
            // 
            this.partt.HeaderText = "activate coil 2";
            this.partt.MinimumWidth = 6;
            this.partt.Name = "partt";
            this.partt.ReadOnly = true;
            this.partt.Width = 80;
            // 
            // part2
            // 
            this.part2.HeaderText = "activate coil 3";
            this.part2.MinimumWidth = 6;
            this.part2.Name = "part2";
            this.part2.ReadOnly = true;
            this.part2.Width = 80;
            // 
            // part3
            // 
            this.part3.HeaderText = "rotate";
            this.part3.MinimumWidth = 6;
            this.part3.Name = "part3";
            this.part3.ReadOnly = true;
            this.part3.Width = 60;
            // 
            // mainCP
            // 
            this.mainCP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainCP.Location = new System.Drawing.Point(0, 302);
            this.mainCP.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.mainCP.MinimumSize = new System.Drawing.Size(53, 25);
            this.mainCP.Name = "mainCP";
            this.mainCP.Size = new System.Drawing.Size(512, 25);
            this.mainCP.TabIndex = 0;
            this.mainCP.Load += new System.EventHandler(this.MainCP_Load);
            // 
            // mainF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 328);
            this.Controls.Add(this.mainDGV);
            this.Controls.Add(this.mainCP);
            this.Controls.Add(this.statusStrip1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(527, 363);
            this.Name = "mainF";
            this.Text = "Testing Program ";
            ((System.ComponentModel.ISupportInitialize)(this.mainDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToNode.ComPortControl mainCP;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.DataGridView mainDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn temperature;
        private System.Windows.Forms.DataGridViewTextBoxColumn humidity;
        private System.Windows.Forms.DataGridViewButtonColumn redOn;
        private System.Windows.Forms.DataGridViewButtonColumn partt;
        private System.Windows.Forms.DataGridViewButtonColumn part2;
        private System.Windows.Forms.DataGridViewButtonColumn part3;
    }
}