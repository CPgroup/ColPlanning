namespace CoScheduling.Main.Coverage
{
    partial class PlanningResults
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridViewTimewindow = new System.Windows.Forms.DataGridView();
            this.LSTR_SEQID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SCHEME_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TASKID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SATID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SAT_STKNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SENSOR_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SENSOR_STKNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STARTTIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ENDTIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIMELONG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GSD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SANGLE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CIRCLE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridViewResault = new System.Windows.Forms.DataGridView();
            this.RESAULT_LSTR_SEQID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RESAULT_SCHEMEID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RESAULT_TASKID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RESAULT_SUBTASKID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RESAULT_COMPOSEDNUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RESAULT_SATID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RESAULT_SATSTKNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RESAULT_SENSORID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RESAULT_SENSORSTKNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RESAULT_ZCSTARTTIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RESAULT_ZCENDTIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RESAULT_SLEWANGLE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RESAULT_RESOLUTION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTimewindow)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResault)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(796, 392);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.DoubleClick += new System.EventHandler(this.tabControl1_DoubleClick);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridViewTimewindow);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(788, 366);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "卫星资源时间窗口";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridViewTimewindow
            // 
            this.dataGridViewTimewindow.AllowDrop = true;
            this.dataGridViewTimewindow.AllowUserToAddRows = false;
            this.dataGridViewTimewindow.AllowUserToDeleteRows = false;
            this.dataGridViewTimewindow.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTimewindow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTimewindow.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LSTR_SEQID,
            this.SCHEME_ID,
            this.TASKID,
            this.SATID,
            this.SAT_STKNAME,
            this.SENSOR_ID,
            this.SENSOR_STKNAME,
            this.STARTTIME,
            this.ENDTIME,
            this.TIMELONG,
            this.GSD,
            this.SANGLE,
            this.CIRCLE});
            this.dataGridViewTimewindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTimewindow.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewTimewindow.Name = "dataGridViewTimewindow";
            this.dataGridViewTimewindow.ReadOnly = true;
            this.dataGridViewTimewindow.RowTemplate.Height = 23;
            this.dataGridViewTimewindow.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewTimewindow.Size = new System.Drawing.Size(782, 360);
            this.dataGridViewTimewindow.TabIndex = 1;
            // 
            // LSTR_SEQID
            // 
            this.LSTR_SEQID.DataPropertyName = "LSTR_SEQID";
            this.LSTR_SEQID.HeaderText = "窗口编号";
            this.LSTR_SEQID.Name = "LSTR_SEQID";
            this.LSTR_SEQID.ReadOnly = true;
            this.LSTR_SEQID.Visible = false;
            // 
            // SCHEME_ID
            // 
            this.SCHEME_ID.DataPropertyName = "SCHEMEID";
            this.SCHEME_ID.HeaderText = "方案ID";
            this.SCHEME_ID.Name = "SCHEME_ID";
            this.SCHEME_ID.ReadOnly = true;
            this.SCHEME_ID.Visible = false;
            // 
            // TASKID
            // 
            this.TASKID.DataPropertyName = "TASKID";
            this.TASKID.HeaderText = "任务ID";
            this.TASKID.Name = "TASKID";
            this.TASKID.ReadOnly = true;
            this.TASKID.Visible = false;
            // 
            // SATID
            // 
            this.SATID.DataPropertyName = "SATID";
            this.SATID.HeaderText = "卫星ID";
            this.SATID.Name = "SATID";
            this.SATID.ReadOnly = true;
            this.SATID.Visible = false;
            // 
            // SAT_STKNAME
            // 
            this.SAT_STKNAME.DataPropertyName = "SAT_STKNAME";
            this.SAT_STKNAME.HeaderText = "卫星名称";
            this.SAT_STKNAME.Name = "SAT_STKNAME";
            this.SAT_STKNAME.ReadOnly = true;
            // 
            // SENSOR_ID
            // 
            this.SENSOR_ID.DataPropertyName = "SENSOR_ID";
            this.SENSOR_ID.HeaderText = "载荷ID";
            this.SENSOR_ID.Name = "SENSOR_ID";
            this.SENSOR_ID.ReadOnly = true;
            this.SENSOR_ID.Visible = false;
            // 
            // SENSOR_STKNAME
            // 
            this.SENSOR_STKNAME.DataPropertyName = "SENSOR_STKNAME";
            this.SENSOR_STKNAME.HeaderText = "载荷名称";
            this.SENSOR_STKNAME.Name = "SENSOR_STKNAME";
            this.SENSOR_STKNAME.ReadOnly = true;
            // 
            // STARTTIME
            // 
            this.STARTTIME.DataPropertyName = "STARTTIME";
            dataGridViewCellStyle1.Format = "G";
            dataGridViewCellStyle1.NullValue = null;
            this.STARTTIME.DefaultCellStyle = dataGridViewCellStyle1;
            this.STARTTIME.HeaderText = "开始时间";
            this.STARTTIME.Name = "STARTTIME";
            this.STARTTIME.ReadOnly = true;
            // 
            // ENDTIME
            // 
            this.ENDTIME.DataPropertyName = "ENDTIME";
            dataGridViewCellStyle2.Format = "G";
            dataGridViewCellStyle2.NullValue = null;
            this.ENDTIME.DefaultCellStyle = dataGridViewCellStyle2;
            this.ENDTIME.HeaderText = "结束时间";
            this.ENDTIME.Name = "ENDTIME";
            this.ENDTIME.ReadOnly = true;
            // 
            // TIMELONG
            // 
            this.TIMELONG.DataPropertyName = "TIMELONG";
            this.TIMELONG.HeaderText = "时长";
            this.TIMELONG.Name = "TIMELONG";
            this.TIMELONG.ReadOnly = true;
            // 
            // GSD
            // 
            this.GSD.DataPropertyName = "GSD";
            this.GSD.HeaderText = "分辨率";
            this.GSD.Name = "GSD";
            this.GSD.ReadOnly = true;
            // 
            // SANGLE
            // 
            this.SANGLE.DataPropertyName = "SANGLE";
            this.SANGLE.HeaderText = "侧摆角";
            this.SANGLE.Name = "SANGLE";
            this.SANGLE.ReadOnly = true;
            // 
            // CIRCLE
            // 
            this.CIRCLE.DataPropertyName = "CIRCLE";
            this.CIRCLE.HeaderText = "圈数";
            this.CIRCLE.Name = "CIRCLE";
            this.CIRCLE.ReadOnly = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridViewResault);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(788, 366);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "卫星资源规划结果";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridViewResault
            // 
            this.dataGridViewResault.AllowDrop = true;
            this.dataGridViewResault.AllowUserToAddRows = false;
            this.dataGridViewResault.AllowUserToDeleteRows = false;
            this.dataGridViewResault.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewResault.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResault.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RESAULT_LSTR_SEQID,
            this.RESAULT_SCHEMEID,
            this.RESAULT_TASKID,
            this.RESAULT_SUBTASKID,
            this.RESAULT_COMPOSEDNUMBER,
            this.RESAULT_SATID,
            this.RESAULT_SATSTKNAME,
            this.RESAULT_SENSORID,
            this.RESAULT_SENSORSTKNAME,
            this.RESAULT_ZCSTARTTIME,
            this.RESAULT_ZCENDTIME,
            this.RESAULT_SLEWANGLE,
            this.RESAULT_RESOLUTION});
            this.dataGridViewResault.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewResault.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewResault.Name = "dataGridViewResault";
            this.dataGridViewResault.ReadOnly = true;
            this.dataGridViewResault.RowTemplate.Height = 23;
            this.dataGridViewResault.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewResault.Size = new System.Drawing.Size(782, 360);
            this.dataGridViewResault.TabIndex = 1;
            // 
            // RESAULT_LSTR_SEQID
            // 
            this.RESAULT_LSTR_SEQID.DataPropertyName = "LSTR_SEQID";
            this.RESAULT_LSTR_SEQID.HeaderText = "时间窗口ID";
            this.RESAULT_LSTR_SEQID.Name = "RESAULT_LSTR_SEQID";
            this.RESAULT_LSTR_SEQID.ReadOnly = true;
            this.RESAULT_LSTR_SEQID.Visible = false;
            // 
            // RESAULT_SCHEMEID
            // 
            this.RESAULT_SCHEMEID.DataPropertyName = "SCHEMEID";
            this.RESAULT_SCHEMEID.HeaderText = "方案ID";
            this.RESAULT_SCHEMEID.Name = "RESAULT_SCHEMEID";
            this.RESAULT_SCHEMEID.ReadOnly = true;
            this.RESAULT_SCHEMEID.Visible = false;
            // 
            // RESAULT_TASKID
            // 
            this.RESAULT_TASKID.DataPropertyName = "TASKID";
            this.RESAULT_TASKID.HeaderText = "任务ID";
            this.RESAULT_TASKID.Name = "RESAULT_TASKID";
            this.RESAULT_TASKID.ReadOnly = true;
            this.RESAULT_TASKID.Visible = false;
            // 
            // RESAULT_SUBTASKID
            // 
            this.RESAULT_SUBTASKID.DataPropertyName = "SUBTASKID";
            this.RESAULT_SUBTASKID.HeaderText = "子任务ID";
            this.RESAULT_SUBTASKID.Name = "RESAULT_SUBTASKID";
            this.RESAULT_SUBTASKID.ReadOnly = true;
            this.RESAULT_SUBTASKID.Visible = false;
            // 
            // RESAULT_COMPOSEDNUMBER
            // 
            this.RESAULT_COMPOSEDNUMBER.DataPropertyName = "COMPOSEDNUMBER";
            this.RESAULT_COMPOSEDNUMBER.HeaderText = "规划编号";
            this.RESAULT_COMPOSEDNUMBER.Name = "RESAULT_COMPOSEDNUMBER";
            this.RESAULT_COMPOSEDNUMBER.ReadOnly = true;
            // 
            // RESAULT_SATID
            // 
            this.RESAULT_SATID.DataPropertyName = "SATID";
            this.RESAULT_SATID.HeaderText = "卫星ID";
            this.RESAULT_SATID.Name = "RESAULT_SATID";
            this.RESAULT_SATID.ReadOnly = true;
            this.RESAULT_SATID.Visible = false;
            // 
            // RESAULT_SATSTKNAME
            // 
            this.RESAULT_SATSTKNAME.DataPropertyName = "SATSTKNAME";
            this.RESAULT_SATSTKNAME.HeaderText = "卫星名称";
            this.RESAULT_SATSTKNAME.Name = "RESAULT_SATSTKNAME";
            this.RESAULT_SATSTKNAME.ReadOnly = true;
            // 
            // RESAULT_SENSORID
            // 
            this.RESAULT_SENSORID.DataPropertyName = "SENSORID";
            this.RESAULT_SENSORID.HeaderText = "载荷ID";
            this.RESAULT_SENSORID.Name = "RESAULT_SENSORID";
            this.RESAULT_SENSORID.ReadOnly = true;
            this.RESAULT_SENSORID.Visible = false;
            // 
            // RESAULT_SENSORSTKNAME
            // 
            this.RESAULT_SENSORSTKNAME.DataPropertyName = "SENSORSTKNAME";
            this.RESAULT_SENSORSTKNAME.HeaderText = "载荷名称";
            this.RESAULT_SENSORSTKNAME.Name = "RESAULT_SENSORSTKNAME";
            this.RESAULT_SENSORSTKNAME.ReadOnly = true;
            // 
            // RESAULT_ZCSTARTTIME
            // 
            this.RESAULT_ZCSTARTTIME.DataPropertyName = "ZCSTARTTIME";
            dataGridViewCellStyle3.Format = "G";
            dataGridViewCellStyle3.NullValue = null;
            this.RESAULT_ZCSTARTTIME.DefaultCellStyle = dataGridViewCellStyle3;
            this.RESAULT_ZCSTARTTIME.HeaderText = "开始时间";
            this.RESAULT_ZCSTARTTIME.Name = "RESAULT_ZCSTARTTIME";
            this.RESAULT_ZCSTARTTIME.ReadOnly = true;
            // 
            // RESAULT_ZCENDTIME
            // 
            this.RESAULT_ZCENDTIME.DataPropertyName = "ZCENDTIME";
            dataGridViewCellStyle4.Format = "G";
            dataGridViewCellStyle4.NullValue = null;
            this.RESAULT_ZCENDTIME.DefaultCellStyle = dataGridViewCellStyle4;
            this.RESAULT_ZCENDTIME.HeaderText = "结束时间";
            this.RESAULT_ZCENDTIME.Name = "RESAULT_ZCENDTIME";
            this.RESAULT_ZCENDTIME.ReadOnly = true;
            // 
            // RESAULT_SLEWANGLE
            // 
            this.RESAULT_SLEWANGLE.DataPropertyName = "SLEWANGLE";
            this.RESAULT_SLEWANGLE.HeaderText = "侧摆角度";
            this.RESAULT_SLEWANGLE.Name = "RESAULT_SLEWANGLE";
            this.RESAULT_SLEWANGLE.ReadOnly = true;
            // 
            // RESAULT_RESOLUTION
            // 
            this.RESAULT_RESOLUTION.DataPropertyName = "RESOLUTION";
            this.RESAULT_RESOLUTION.HeaderText = "分辨率";
            this.RESAULT_RESOLUTION.Name = "RESAULT_RESOLUTION";
            this.RESAULT_RESOLUTION.ReadOnly = true;
            // 
            // PlanningResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 392);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "PlanningResults";
            this.Text = "卫星规划结果";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTimewindow)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResault)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridViewTextBoxColumn LSTR_SEQID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SCHEME_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TASKID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SATID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SAT_STKNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn SENSOR_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SENSOR_STKNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn STARTTIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn ENDTIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIMELONG;
        private System.Windows.Forms.DataGridViewTextBoxColumn GSD;
        private System.Windows.Forms.DataGridViewTextBoxColumn SANGLE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CIRCLE;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridViewTextBoxColumn RESAULT_LSTR_SEQID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RESAULT_SCHEMEID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RESAULT_TASKID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RESAULT_SUBTASKID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RESAULT_COMPOSEDNUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn RESAULT_SATID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RESAULT_SATSTKNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn RESAULT_SENSORID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RESAULT_SENSORSTKNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn RESAULT_ZCSTARTTIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn RESAULT_ZCENDTIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn RESAULT_SLEWANGLE;
        private System.Windows.Forms.DataGridViewTextBoxColumn RESAULT_RESOLUTION;
        public System.Windows.Forms.DataGridView dataGridViewTimewindow;
        public System.Windows.Forms.DataGridView dataGridViewResault;
    }
}