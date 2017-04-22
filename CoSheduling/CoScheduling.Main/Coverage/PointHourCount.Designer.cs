namespace CoScheduling.Main.Coverage
{
    partial class PointHourCount
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.TARGET_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PERIOD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PERIOD2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIMES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.COUNTTIMES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COUNTNUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.导出ExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView2);
            this.splitContainer1.Size = new System.Drawing.Size(614, 391);
            this.splitContainer1.SplitterDistance = 355;
            this.splitContainer1.TabIndex = 4;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TARGET_ID,
            this.PERIOD,
            this.PERIOD2,
            this.TIMES});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(355, 391);
            this.dataGridView1.TabIndex = 1;
            // 
            // TARGET_ID
            // 
            this.TARGET_ID.DataPropertyName = "TARGETID";
            this.TARGET_ID.HeaderText = "目标ID";
            this.TARGET_ID.Name = "TARGET_ID";
            this.TARGET_ID.ReadOnly = true;
            // 
            // PERIOD
            // 
            this.PERIOD.DataPropertyName = "STARTHOUR";
            this.PERIOD.HeaderText = "开始时间";
            this.PERIOD.Name = "PERIOD";
            this.PERIOD.ReadOnly = true;
            // 
            // PERIOD2
            // 
            this.PERIOD2.DataPropertyName = "STOPHOUR";
            this.PERIOD2.HeaderText = "结束时间";
            this.PERIOD2.Name = "PERIOD2";
            this.PERIOD2.ReadOnly = true;
            // 
            // TIMES
            // 
            this.TIMES.DataPropertyName = "TIMES";
            this.TIMES.HeaderText = "次数";
            this.TIMES.Name = "TIMES";
            this.TIMES.ReadOnly = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.COUNTTIMES,
            this.COUNTNUM});
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(255, 391);
            this.dataGridView2.TabIndex = 0;
            // 
            // COUNTTIMES
            // 
            this.COUNTTIMES.DataPropertyName = "TIMES";
            this.COUNTTIMES.HeaderText = "次数统计";
            this.COUNTTIMES.Name = "COUNTTIMES";
            this.COUNTTIMES.ReadOnly = true;
            // 
            // COUNTNUM
            // 
            this.COUNTNUM.DataPropertyName = "POINTNUM";
            this.COUNTNUM.HeaderText = "目标个数";
            this.COUNTNUM.Name = "COUNTNUM";
            this.COUNTNUM.ReadOnly = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.导出ExcelToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(614, 25);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 导出ExcelToolStripMenuItem
            // 
            this.导出ExcelToolStripMenuItem.Name = "导出ExcelToolStripMenuItem";
            this.导出ExcelToolStripMenuItem.Size = new System.Drawing.Size(73, 21);
            this.导出ExcelToolStripMenuItem.Text = "导出Excel";
            // 
            // PointHourCount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 416);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "PointHourCount";
            this.Text = "PointHourCount";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TARGET_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PERIOD;
        private System.Windows.Forms.DataGridViewTextBoxColumn PERIOD2;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIMES;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn COUNTTIMES;
        private System.Windows.Forms.DataGridViewTextBoxColumn COUNTNUM;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 导出ExcelToolStripMenuItem;
    }
}