namespace CoScheduling.Main.Coverage
{
    partial class TaskSchemeDetail
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboTaskType = new System.Windows.Forms.ComboBox();
            this.dateTaskEndTime = new System.Windows.Forms.DateTimePicker();
            this.dateTaskStartTime = new System.Windows.Forms.DateTimePicker();
            this.txtResolution = new System.Windows.Forms.TextBox();
            this.txtTaskPriority = new System.Windows.Forms.TextBox();
            this.txtTaskName = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtLat2 = new System.Windows.Forms.TextBox();
            this.txtLat1 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtLon2 = new System.Windows.Forms.TextBox();
            this.txtLon1 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.GridViewTaskLayout = new System.Windows.Forms.DataGridView();
            this.TASKID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TASKNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRIORITY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MAXGSD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STARTTIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ENDTIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTaskEnd = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTaskStart = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSchemeName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewTaskLayout)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboTaskType);
            this.groupBox3.Controls.Add(this.dateTaskEndTime);
            this.groupBox3.Controls.Add(this.dateTaskStartTime);
            this.groupBox3.Controls.Add(this.txtResolution);
            this.groupBox3.Controls.Add(this.txtTaskPriority);
            this.groupBox3.Controls.Add(this.txtTaskName);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(12, 307);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(600, 201);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "观测任务参数设置";
            // 
            // comboTaskType
            // 
            this.comboTaskType.FormattingEnabled = true;
            this.comboTaskType.Items.AddRange(new object[] {
            "点目标",
            "区域目标"});
            this.comboTaskType.Location = new System.Drawing.Point(395, 17);
            this.comboTaskType.Name = "comboTaskType";
            this.comboTaskType.Size = new System.Drawing.Size(121, 20);
            this.comboTaskType.TabIndex = 12;
            // 
            // dateTaskEndTime
            // 
            this.dateTaskEndTime.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.dateTaskEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTaskEndTime.Location = new System.Drawing.Point(395, 74);
            this.dateTaskEndTime.Name = "dateTaskEndTime";
            this.dateTaskEndTime.Size = new System.Drawing.Size(180, 21);
            this.dateTaskEndTime.TabIndex = 11;
            // 
            // dateTaskStartTime
            // 
            this.dateTaskStartTime.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.dateTaskStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTaskStartTime.Location = new System.Drawing.Point(108, 74);
            this.dateTaskStartTime.Name = "dateTaskStartTime";
            this.dateTaskStartTime.Size = new System.Drawing.Size(180, 21);
            this.dateTaskStartTime.TabIndex = 10;
            // 
            // txtResolution
            // 
            this.txtResolution.Location = new System.Drawing.Point(395, 45);
            this.txtResolution.Name = "txtResolution";
            this.txtResolution.Size = new System.Drawing.Size(100, 21);
            this.txtResolution.TabIndex = 9;
            // 
            // txtTaskPriority
            // 
            this.txtTaskPriority.Location = new System.Drawing.Point(108, 45);
            this.txtTaskPriority.Name = "txtTaskPriority";
            this.txtTaskPriority.Size = new System.Drawing.Size(100, 21);
            this.txtTaskPriority.TabIndex = 8;
            // 
            // txtTaskName
            // 
            this.txtTaskName.Location = new System.Drawing.Point(108, 17);
            this.txtTaskName.Name = "txtTaskName";
            this.txtTaskName.Size = new System.Drawing.Size(100, 21);
            this.txtTaskName.TabIndex = 7;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtLat2);
            this.groupBox4.Controls.Add(this.txtLat1);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.txtLon2);
            this.groupBox4.Controls.Add(this.txtLon1);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Location = new System.Drawing.Point(11, 114);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(579, 68);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "观测位置属性";
            // 
            // txtLat2
            // 
            this.txtLat2.Location = new System.Drawing.Point(475, 27);
            this.txtLat2.Name = "txtLat2";
            this.txtLat2.Size = new System.Drawing.Size(80, 21);
            this.txtLat2.TabIndex = 5;
            // 
            // txtLat1
            // 
            this.txtLat1.Location = new System.Drawing.Point(385, 27);
            this.txtLat1.Name = "txtLat1";
            this.txtLat1.Size = new System.Drawing.Size(80, 21);
            this.txtLat1.TabIndex = 4;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(300, 30);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 3;
            this.label11.Text = "纬度范围";
            // 
            // txtLon2
            // 
            this.txtLon2.Location = new System.Drawing.Point(187, 27);
            this.txtLon2.Name = "txtLon2";
            this.txtLon2.Size = new System.Drawing.Size(80, 21);
            this.txtLon2.TabIndex = 2;
            // 
            // txtLon1
            // 
            this.txtLon1.Location = new System.Drawing.Point(97, 27);
            this.txtLon1.Name = "txtLon1";
            this.txtLon1.Size = new System.Drawing.Size(80, 21);
            this.txtLon1.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "经度范围";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(311, 78);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 5;
            this.label9.Text = "观测结束时间";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 4;
            this.label8.Text = "观测开始时间";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(311, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 3;
            this.label7.Text = "分辨率";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "任务优先级";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(311, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "任务类型";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "任务STK名称";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.GridViewTaskLayout);
            this.groupBox2.Location = new System.Drawing.Point(12, 137);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(600, 163);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "观测任务列表";
            // 
            // GridViewTaskLayout
            // 
            this.GridViewTaskLayout.AllowUserToAddRows = false;
            this.GridViewTaskLayout.AllowUserToDeleteRows = false;
            this.GridViewTaskLayout.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridViewTaskLayout.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridViewTaskLayout.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TASKID,
            this.TASKNAME,
            this.PRIORITY,
            this.MAXGSD,
            this.STARTTIME,
            this.ENDTIME});
            this.GridViewTaskLayout.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.GridViewTaskLayout.Location = new System.Drawing.Point(7, 21);
            this.GridViewTaskLayout.Name = "GridViewTaskLayout";
            this.GridViewTaskLayout.RowTemplate.Height = 23;
            this.GridViewTaskLayout.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridViewTaskLayout.Size = new System.Drawing.Size(583, 136);
            this.GridViewTaskLayout.TabIndex = 0;
            // 
            // TASKID
            // 
            this.TASKID.DataPropertyName = "TASKID";
            this.TASKID.HeaderText = "任务ID";
            this.TASKID.Name = "TASKID";
            this.TASKID.Visible = false;
            // 
            // TASKNAME
            // 
            this.TASKNAME.DataPropertyName = "TASKNAME";
            this.TASKNAME.HeaderText = "任务名称";
            this.TASKNAME.Name = "TASKNAME";
            // 
            // PRIORITY
            // 
            this.PRIORITY.DataPropertyName = "PRIORITY";
            this.PRIORITY.HeaderText = "观测优先级";
            this.PRIORITY.Name = "PRIORITY";
            // 
            // MAXGSD
            // 
            this.MAXGSD.DataPropertyName = "MAXGSD";
            this.MAXGSD.HeaderText = "分辨率要求";
            this.MAXGSD.Name = "MAXGSD";
            // 
            // STARTTIME
            // 
            this.STARTTIME.DataPropertyName = "STARTTIME";
            this.STARTTIME.HeaderText = "观测开始时间";
            this.STARTTIME.Name = "STARTTIME";
            this.STARTTIME.ToolTipText = "该时间为UTC时间";
            // 
            // ENDTIME
            // 
            this.ENDTIME.DataPropertyName = "ENDTIME";
            this.ENDTIME.HeaderText = "观测结束时间";
            this.ENDTIME.Name = "ENDTIME";
            this.ENDTIME.ToolTipText = "该时间为UTC时间";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateTaskEnd);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dateTaskStart);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtSchemeName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(600, 119);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "最新任务方案";
            // 
            // dateTaskEnd
            // 
            this.dateTaskEnd.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.dateTaskEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTaskEnd.Location = new System.Drawing.Point(390, 60);
            this.dateTaskEnd.Name = "dateTaskEnd";
            this.dateTaskEnd.Size = new System.Drawing.Size(200, 21);
            this.dateTaskEnd.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(322, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "结束时间";
            // 
            // dateTaskStart
            // 
            this.dateTaskStart.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.dateTaskStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTaskStart.Location = new System.Drawing.Point(91, 60);
            this.dateTaskStart.Name = "dateTaskStart";
            this.dateTaskStart.Size = new System.Drawing.Size(200, 21);
            this.dateTaskStart.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "开始时间";
            // 
            // txtSchemeName
            // 
            this.txtSchemeName.Location = new System.Drawing.Point(91, 19);
            this.txtSchemeName.Name = "txtSchemeName";
            this.txtSchemeName.Size = new System.Drawing.Size(499, 21);
            this.txtSchemeName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "任务方案名称";
            // 
            // TaskSchemeDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 520);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "TaskSchemeDetail";
            this.Text = "观测任务详情";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridViewTaskLayout)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox comboTaskType;
        private System.Windows.Forms.DateTimePicker dateTaskEndTime;
        private System.Windows.Forms.DateTimePicker dateTaskStartTime;
        private System.Windows.Forms.TextBox txtResolution;
        private System.Windows.Forms.TextBox txtTaskPriority;
        private System.Windows.Forms.TextBox txtTaskName;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtLat2;
        private System.Windows.Forms.TextBox txtLat1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtLon2;
        private System.Windows.Forms.TextBox txtLon1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView GridViewTaskLayout;
        private System.Windows.Forms.DataGridViewTextBoxColumn TASKID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TASKNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRIORITY;
        private System.Windows.Forms.DataGridViewTextBoxColumn MAXGSD;
        private System.Windows.Forms.DataGridViewTextBoxColumn STARTTIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn ENDTIME;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTaskEnd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTaskStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSchemeName;
        private System.Windows.Forms.Label label1;
    }
}