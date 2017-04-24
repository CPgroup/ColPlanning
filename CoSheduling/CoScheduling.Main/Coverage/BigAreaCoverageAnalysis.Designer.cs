namespace CoScheduling.Main.Coverage
{
    partial class BigAreaCoverageAnalysis
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
            this.dataGridViewCoverageAnalysis = new System.Windows.Forms.DataGridView();
            this.TARGETID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TOTALNUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DAYS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AVGDAY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.导出ExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCoverageAnalysis)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewCoverageAnalysis
            // 
            this.dataGridViewCoverageAnalysis.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewCoverageAnalysis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCoverageAnalysis.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TARGETID,
            this.TOTALNUM,
            this.DAYS,
            this.PROB,
            this.AVGDAY});
            this.dataGridViewCoverageAnalysis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewCoverageAnalysis.Location = new System.Drawing.Point(0, 25);
            this.dataGridViewCoverageAnalysis.Name = "dataGridViewCoverageAnalysis";
            this.dataGridViewCoverageAnalysis.ReadOnly = true;
            this.dataGridViewCoverageAnalysis.RowTemplate.Height = 23;
            this.dataGridViewCoverageAnalysis.Size = new System.Drawing.Size(657, 390);
            this.dataGridViewCoverageAnalysis.TabIndex = 5;
            // 
            // TARGETID
            // 
            this.TARGETID.DataPropertyName = "TARGETID";
            this.TARGETID.HeaderText = "目标ID";
            this.TARGETID.Name = "TARGETID";
            this.TARGETID.ReadOnly = true;
            // 
            // TOTALNUM
            // 
            this.TOTALNUM.DataPropertyName = "TOTALNUM";
            this.TOTALNUM.HeaderText = "总覆盖次数";
            this.TOTALNUM.Name = "TOTALNUM";
            this.TOTALNUM.ReadOnly = true;
            // 
            // DAYS
            // 
            this.DAYS.DataPropertyName = "DAYS";
            this.DAYS.HeaderText = "覆盖天数";
            this.DAYS.Name = "DAYS";
            this.DAYS.ReadOnly = true;
            // 
            // PROB
            // 
            this.PROB.DataPropertyName = "PROB";
            this.PROB.HeaderText = "1日覆盖率";
            this.PROB.Name = "PROB";
            this.PROB.ReadOnly = true;
            // 
            // AVGDAY
            // 
            this.AVGDAY.DataPropertyName = "AVGDAY";
            this.AVGDAY.HeaderText = "日均覆盖次数";
            this.AVGDAY.Name = "AVGDAY";
            this.AVGDAY.ReadOnly = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.导出ExcelToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(657, 25);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 导出ExcelToolStripMenuItem
            // 
            this.导出ExcelToolStripMenuItem.Name = "导出ExcelToolStripMenuItem";
            this.导出ExcelToolStripMenuItem.Size = new System.Drawing.Size(73, 21);
            this.导出ExcelToolStripMenuItem.Text = "导出Excel";
            // 
            // BigAreaCoverageAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 415);
            this.Controls.Add(this.dataGridViewCoverageAnalysis);
            this.Controls.Add(this.menuStrip1);
            this.Name = "BigAreaCoverageAnalysis";
            this.Text = "BigAreaCoverageAnalysis";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCoverageAnalysis)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewCoverageAnalysis;
        private System.Windows.Forms.DataGridViewTextBoxColumn TARGETID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOTALNUM;
        private System.Windows.Forms.DataGridViewTextBoxColumn DAYS;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROB;
        private System.Windows.Forms.DataGridViewTextBoxColumn AVGDAY;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 导出ExcelToolStripMenuItem;
    }
}