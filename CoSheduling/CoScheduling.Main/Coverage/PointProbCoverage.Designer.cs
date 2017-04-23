namespace CoScheduling.Main.Coverage
{
    partial class PointProbCoverage
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
            this.dataGridViewPointProbCoverage = new System.Windows.Forms.DataGridView();
            this.PROBILITYID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TARGET_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INTERVAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROBABILITY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SCHEMEID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.导出ExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.生成图片ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPointProbCoverage)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewPointProbCoverage
            // 
            this.dataGridViewPointProbCoverage.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewPointProbCoverage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPointProbCoverage.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PROBILITYID,
            this.TARGET_ID,
            this.INTERVAL,
            this.PROBABILITY,
            this.SCHEMEID});
            this.dataGridViewPointProbCoverage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewPointProbCoverage.Location = new System.Drawing.Point(0, 25);
            this.dataGridViewPointProbCoverage.Name = "dataGridViewPointProbCoverage";
            this.dataGridViewPointProbCoverage.ReadOnly = true;
            this.dataGridViewPointProbCoverage.RowTemplate.Height = 23;
            this.dataGridViewPointProbCoverage.Size = new System.Drawing.Size(535, 372);
            this.dataGridViewPointProbCoverage.TabIndex = 1;
            // 
            // PROBILITYID
            // 
            this.PROBILITYID.DataPropertyName = "PROBILITYID";
            this.PROBILITYID.HeaderText = "ID";
            this.PROBILITYID.Name = "PROBILITYID";
            this.PROBILITYID.ReadOnly = true;
            this.PROBILITYID.Visible = false;
            // 
            // TARGET_ID
            // 
            this.TARGET_ID.DataPropertyName = "TARGETID";
            this.TARGET_ID.HeaderText = "目标ID";
            this.TARGET_ID.Name = "TARGET_ID";
            this.TARGET_ID.ReadOnly = true;
            // 
            // INTERVAL
            // 
            this.INTERVAL.DataPropertyName = "INTERVAL";
            this.INTERVAL.HeaderText = "时间";
            this.INTERVAL.Name = "INTERVAL";
            this.INTERVAL.ReadOnly = true;
            // 
            // PROBABILITY
            // 
            this.PROBABILITY.DataPropertyName = "PROBABILITY";
            this.PROBABILITY.HeaderText = "覆盖几率";
            this.PROBABILITY.Name = "PROBABILITY";
            this.PROBABILITY.ReadOnly = true;
            // 
            // SCHEMEID
            // 
            this.SCHEMEID.DataPropertyName = "SCHEMEID";
            this.SCHEMEID.HeaderText = "方案ID";
            this.SCHEMEID.Name = "SCHEMEID";
            this.SCHEMEID.ReadOnly = true;
            this.SCHEMEID.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.导出ExcelToolStripMenuItem,
            this.生成图片ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(535, 25);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 导出ExcelToolStripMenuItem
            // 
            this.导出ExcelToolStripMenuItem.Name = "导出ExcelToolStripMenuItem";
            this.导出ExcelToolStripMenuItem.Size = new System.Drawing.Size(73, 21);
            this.导出ExcelToolStripMenuItem.Text = "导出Excel";
            // 
            // 生成图片ToolStripMenuItem
            // 
            this.生成图片ToolStripMenuItem.Name = "生成图片ToolStripMenuItem";
            this.生成图片ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.生成图片ToolStripMenuItem.Text = "生成图片";
            // 
            // PointProbCoverage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 397);
            this.Controls.Add(this.dataGridViewPointProbCoverage);
            this.Controls.Add(this.menuStrip1);
            this.Name = "PointProbCoverage";
            this.Text = "PointProbCoverage";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPointProbCoverage)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewPointProbCoverage;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROBILITYID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TARGET_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn INTERVAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROBABILITY;
        private System.Windows.Forms.DataGridViewTextBoxColumn SCHEMEID;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 导出ExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 生成图片ToolStripMenuItem;
    }
}