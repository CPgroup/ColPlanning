namespace CoScheduling.Main.Coverage
{
    partial class SatelliteResaultList
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SatelliteResaultList));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonShowResaultByTime = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonRefreshByOrder = new System.Windows.Forms.Button();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.tvSatelliteResault = new System.Windows.Forms.TreeView();
            this.cmsTvSat = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmiSatLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiSatShow = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiSatInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiSatRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiSatTask = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.cmsTvSat.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(0, 378);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(294, 203);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "列表选项";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.buttonShowResaultByTime);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.dateTimePicker2);
            this.groupBox3.Controls.Add(this.dateTimePicker1);
            this.groupBox3.Location = new System.Drawing.Point(6, 20);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(276, 103);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "时间";
            // 
            // buttonShowResaultByTime
            // 
            this.buttonShowResaultByTime.Location = new System.Drawing.Point(194, 75);
            this.buttonShowResaultByTime.Name = "buttonShowResaultByTime";
            this.buttonShowResaultByTime.Size = new System.Drawing.Size(75, 23);
            this.buttonShowResaultByTime.TabIndex = 4;
            this.buttonShowResaultByTime.Text = "显示";
            this.buttonShowResaultByTime.UseVisualStyleBackColor = true;
            this.buttonShowResaultByTime.Click += new System.EventHandler(this.buttonShowResaultByTime_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "结束：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "开始：";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(69, 48);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 21);
            this.dateTimePicker2.TabIndex = 1;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(69, 21);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 21);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.buttonRefreshByOrder);
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Location = new System.Drawing.Point(6, 126);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(276, 74);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "排序方式";
            // 
            // buttonRefreshByOrder
            // 
            this.buttonRefreshByOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRefreshByOrder.Location = new System.Drawing.Point(194, 43);
            this.buttonRefreshByOrder.Name = "buttonRefreshByOrder";
            this.buttonRefreshByOrder.Size = new System.Drawing.Size(76, 23);
            this.buttonRefreshByOrder.TabIndex = 2;
            this.buttonRefreshByOrder.Text = "刷新";
            this.buttonRefreshByOrder.UseVisualStyleBackColor = true;
            this.buttonRefreshByOrder.Click += new System.EventHandler(this.buttonRefreshByOrder_Click);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 46);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(71, 16);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "卫星名称";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 20);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(47, 16);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "时间";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // tvSatelliteResault
            // 
            this.tvSatelliteResault.Dock = System.Windows.Forms.DockStyle.Top;
            this.tvSatelliteResault.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tvSatelliteResault.Location = new System.Drawing.Point(0, 0);
            this.tvSatelliteResault.Name = "tvSatelliteResault";
            this.tvSatelliteResault.Size = new System.Drawing.Size(294, 369);
            this.tvSatelliteResault.TabIndex = 3;
            this.tvSatelliteResault.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvSatelliteResault_AfterSelect_1);
            // 
            // cmsTvSat
            // 
            this.cmsTvSat.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmiSatLoad,
            this.cmiSatShow,
            this.cmiSatInfo,
            this.cmiSatRefresh,
            this.cmiSatTask});
            this.cmsTvSat.Name = "cmsTvSat";
            this.cmsTvSat.Size = new System.Drawing.Size(137, 114);
            // 
            // cmiSatLoad
            // 
            this.cmiSatLoad.Image = ((System.Drawing.Image)(resources.GetObject("cmiSatLoad.Image")));
            this.cmiSatLoad.Name = "cmiSatLoad";
            this.cmiSatLoad.Size = new System.Drawing.Size(136, 22);
            this.cmiSatLoad.Text = "加载";
            this.cmiSatLoad.Click += new System.EventHandler(this.cmiSatLoad_Click);
            // 
            // cmiSatShow
            // 
            this.cmiSatShow.Image = ((System.Drawing.Image)(resources.GetObject("cmiSatShow.Image")));
            this.cmiSatShow.Name = "cmiSatShow";
            this.cmiSatShow.Size = new System.Drawing.Size(152, 22);
            this.cmiSatShow.Text = "显示";
            this.cmiSatShow.Click += new System.EventHandler(this.cmiSatShow_Click);
            // 
            // cmiSatInfo
            // 
            this.cmiSatInfo.Image = ((System.Drawing.Image)(resources.GetObject("cmiSatInfo.Image")));
            this.cmiSatInfo.Name = "cmiSatInfo";
            this.cmiSatInfo.Size = new System.Drawing.Size(152, 22);
            this.cmiSatInfo.Text = "信息";
            this.cmiSatInfo.Click += new System.EventHandler(this.cmiSatInfo_Click);
            // 
            // cmiSatRefresh
            // 
            this.cmiSatRefresh.Image = ((System.Drawing.Image)(resources.GetObject("cmiSatRefresh.Image")));
            this.cmiSatRefresh.Name = "cmiSatRefresh";
            this.cmiSatRefresh.Size = new System.Drawing.Size(152, 22);
            this.cmiSatRefresh.Text = "刷新";
            this.cmiSatRefresh.Click += new System.EventHandler(this.cmiSatRefresh_Click);
            // 
            // cmiSatTask
            // 
            this.cmiSatTask.Image = ((System.Drawing.Image)(resources.GetObject("cmiSatTask.Image")));
            this.cmiSatTask.Name = "cmiSatTask";
            this.cmiSatTask.Size = new System.Drawing.Size(152, 22);
            this.cmiSatTask.Text = "显示任务区";
            this.cmiSatTask.Click += new System.EventHandler(this.cmiSatTask_Click);
            // 
            // SatelliteResaultList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 581);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tvSatelliteResault);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "SatelliteResaultList";
            this.Text = "卫星观测任务规划结果列表";
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.cmsTvSat.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonShowResaultByTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonRefreshByOrder;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TreeView tvSatelliteResault;
        private System.Windows.Forms.ContextMenuStrip cmsTvSat;
        private System.Windows.Forms.ToolStripMenuItem cmiSatLoad;
        private System.Windows.Forms.ToolStripMenuItem cmiSatShow;
        private System.Windows.Forms.ToolStripMenuItem cmiSatInfo;
        private System.Windows.Forms.ToolStripMenuItem cmiSatRefresh;
        private System.Windows.Forms.ToolStripMenuItem cmiSatTask;
    }
}