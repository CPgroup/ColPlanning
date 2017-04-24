namespace CoScheduling.Main.Coverage
{
    partial class PointCoverage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewPointCoverage = new System.Windows.Forms.DataGridView();
            this.TIMEWINDOWID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIMEWINDOWSTART = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIMEWINDOWSTOP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIMEWINDOWINTERVAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SATID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SATNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SENSORID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SENSORNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.导出ExeclToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPointCoverage)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewPointCoverage
            // 
            this.dataGridViewPointCoverage.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewPointCoverage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPointCoverage.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TIMEWINDOWID,
            this.TIMEWINDOWSTART,
            this.TIMEWINDOWSTOP,
            this.TIMEWINDOWINTERVAL,
            this.SATID,
            this.SATNAME,
            this.SENSORID,
            this.SENSORNAME});
            this.dataGridViewPointCoverage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewPointCoverage.Location = new System.Drawing.Point(0, 25);
            this.dataGridViewPointCoverage.Name = "dataGridViewPointCoverage";
            this.dataGridViewPointCoverage.ReadOnly = true;
            this.dataGridViewPointCoverage.RowTemplate.Height = 23;
            this.dataGridViewPointCoverage.Size = new System.Drawing.Size(488, 248);
            this.dataGridViewPointCoverage.TabIndex = 2;
            // 
            // TIMEWINDOWID
            // 
            this.TIMEWINDOWID.DataPropertyName = "TIMEWINDOWID";
            this.TIMEWINDOWID.HeaderText = "时间窗口ID";
            this.TIMEWINDOWID.Name = "TIMEWINDOWID";
            this.TIMEWINDOWID.ReadOnly = true;
            this.TIMEWINDOWID.Visible = false;
            // 
            // TIMEWINDOWSTART
            // 
            this.TIMEWINDOWSTART.DataPropertyName = "TIMEWINDOWSTART";
            dataGridViewCellStyle1.Format = "yyyy-MM-dd HH:mm:ss";
            this.TIMEWINDOWSTART.DefaultCellStyle = dataGridViewCellStyle1;
            this.TIMEWINDOWSTART.HeaderText = "开始时间";
            this.TIMEWINDOWSTART.Name = "TIMEWINDOWSTART";
            this.TIMEWINDOWSTART.ReadOnly = true;
            // 
            // TIMEWINDOWSTOP
            // 
            this.TIMEWINDOWSTOP.DataPropertyName = "TIMEWINDOWSTOP";
            dataGridViewCellStyle2.Format = "yyyy-MM-dd HH:mm:ss";
            this.TIMEWINDOWSTOP.DefaultCellStyle = dataGridViewCellStyle2;
            this.TIMEWINDOWSTOP.HeaderText = "结束时间";
            this.TIMEWINDOWSTOP.Name = "TIMEWINDOWSTOP";
            this.TIMEWINDOWSTOP.ReadOnly = true;
            // 
            // TIMEWINDOWINTERVAL
            // 
            this.TIMEWINDOWINTERVAL.DataPropertyName = "TIMEWINDOWINTERVAL";
            dataGridViewCellStyle3.Format = "N3";
            dataGridViewCellStyle3.NullValue = null;
            this.TIMEWINDOWINTERVAL.DefaultCellStyle = dataGridViewCellStyle3;
            this.TIMEWINDOWINTERVAL.HeaderText = "时长";
            this.TIMEWINDOWINTERVAL.Name = "TIMEWINDOWINTERVAL";
            this.TIMEWINDOWINTERVAL.ReadOnly = true;
            // 
            // SATID
            // 
            this.SATID.DataPropertyName = "SATID";
            this.SATID.HeaderText = "卫星ID";
            this.SATID.Name = "SATID";
            this.SATID.ReadOnly = true;
            this.SATID.Visible = false;
            // 
            // SATNAME
            // 
            this.SATNAME.DataPropertyName = "SAT_NAME";
            this.SATNAME.HeaderText = "卫星名称";
            this.SATNAME.Name = "SATNAME";
            this.SATNAME.ReadOnly = true;
            // 
            // SENSORID
            // 
            this.SENSORID.DataPropertyName = "SENSORID";
            this.SENSORID.HeaderText = "载荷ID";
            this.SENSORID.Name = "SENSORID";
            this.SENSORID.ReadOnly = true;
            this.SENSORID.Visible = false;
            // 
            // SENSORNAME
            // 
            this.SENSORNAME.DataPropertyName = "SENSOR_NAME";
            this.SENSORNAME.HeaderText = "载荷名称";
            this.SENSORNAME.Name = "SENSORNAME";
            this.SENSORNAME.ReadOnly = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.导出ExeclToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(488, 25);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 导出ExeclToolStripMenuItem
            // 
            this.导出ExeclToolStripMenuItem.Name = "导出ExeclToolStripMenuItem";
            this.导出ExeclToolStripMenuItem.Size = new System.Drawing.Size(73, 21);
            this.导出ExeclToolStripMenuItem.Text = "导出Execl";
            // 
            // PointCoverage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 273);
            this.Controls.Add(this.dataGridViewPointCoverage);
            this.Controls.Add(this.menuStrip1);
            this.Name = "PointCoverage";
            this.Text = "PointCoverage";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPointCoverage)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewPointCoverage;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIMEWINDOWID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIMEWINDOWSTART;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIMEWINDOWSTOP;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIMEWINDOWINTERVAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn SATID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SATNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn SENSORID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SENSORNAME;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 导出ExeclToolStripMenuItem;
    }
}