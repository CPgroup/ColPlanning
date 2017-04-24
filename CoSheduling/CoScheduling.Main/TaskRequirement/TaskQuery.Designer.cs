namespace CoScheduling.Main.TaskRequirement
{
    partial class TaskQuery
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtTaskCount = new System.Windows.Forms.TextBox();
            this.ButtonReturn = new System.Windows.Forms.Button();
            this.ButtonReset = new System.Windows.Forms.Button();
            this.ButtonQuery = new System.Windows.Forms.Button();
            this.groupBox_ObsRegion = new System.Windows.Forms.GroupBox();
            this.txtMinLon = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaxLat = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtMaxLon = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtMinLat = new System.Windows.Forms.TextBox();
            this.comboBox_DisaType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dateEndTime = new System.Windows.Forms.DateTimePicker();
            this.dateStartTime = new System.Windows.Forms.DateTimePicker();
            this.txtTaskID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewTask = new System.Windows.Forms.DataGridView();
            this.TaskID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SpaceResolution = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DisasterType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RespondingTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ObservationFrequency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox_ObsRegion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTask)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(604, 296);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 111;
            this.label2.Text = "查询结果数量";
            // 
            // txtTaskCount
            // 
            this.txtTaskCount.Location = new System.Drawing.Point(596, 318);
            this.txtTaskCount.Name = "txtTaskCount";
            this.txtTaskCount.ReadOnly = true;
            this.txtTaskCount.Size = new System.Drawing.Size(96, 21);
            this.txtTaskCount.TabIndex = 110;
            // 
            // ButtonReturn
            // 
            this.ButtonReturn.Location = new System.Drawing.Point(606, 396);
            this.ButtonReturn.Name = "ButtonReturn";
            this.ButtonReturn.Size = new System.Drawing.Size(75, 23);
            this.ButtonReturn.TabIndex = 109;
            this.ButtonReturn.Text = "返回";
            this.ButtonReturn.UseVisualStyleBackColor = true;
            // 
            // ButtonReset
            // 
            this.ButtonReset.Location = new System.Drawing.Point(606, 357);
            this.ButtonReset.Name = "ButtonReset";
            this.ButtonReset.Size = new System.Drawing.Size(75, 23);
            this.ButtonReset.TabIndex = 108;
            this.ButtonReset.Text = "重置";
            this.ButtonReset.UseVisualStyleBackColor = true;
            // 
            // ButtonQuery
            // 
            this.ButtonQuery.Location = new System.Drawing.Point(606, 258);
            this.ButtonQuery.Name = "ButtonQuery";
            this.ButtonQuery.Size = new System.Drawing.Size(75, 23);
            this.ButtonQuery.TabIndex = 107;
            this.ButtonQuery.Text = "查询";
            this.ButtonQuery.UseVisualStyleBackColor = true;
            this.ButtonQuery.Click += new System.EventHandler(this.ButtonQuery_Click);
            // 
            // groupBox_ObsRegion
            // 
            this.groupBox_ObsRegion.Controls.Add(this.txtMinLon);
            this.groupBox_ObsRegion.Controls.Add(this.label14);
            this.groupBox_ObsRegion.Controls.Add(this.label3);
            this.groupBox_ObsRegion.Controls.Add(this.txtMaxLat);
            this.groupBox_ObsRegion.Controls.Add(this.label13);
            this.groupBox_ObsRegion.Controls.Add(this.txtMaxLon);
            this.groupBox_ObsRegion.Controls.Add(this.label12);
            this.groupBox_ObsRegion.Controls.Add(this.txtMinLat);
            this.groupBox_ObsRegion.Location = new System.Drawing.Point(279, 253);
            this.groupBox_ObsRegion.Name = "groupBox_ObsRegion";
            this.groupBox_ObsRegion.Size = new System.Drawing.Size(270, 170);
            this.groupBox_ObsRegion.TabIndex = 106;
            this.groupBox_ObsRegion.TabStop = false;
            this.groupBox_ObsRegion.Text = "观测区域范围";
            // 
            // txtMinLon
            // 
            this.txtMinLon.Location = new System.Drawing.Point(89, 20);
            this.txtMinLon.Name = "txtMinLon";
            this.txtMinLon.Size = new System.Drawing.Size(154, 21);
            this.txtMinLon.TabIndex = 21;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(13, 143);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 12);
            this.label14.TabIndex = 28;
            this.label14.Text = "最大纬度：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 25;
            this.label3.Text = "最小经度：";
            // 
            // txtMaxLat
            // 
            this.txtMaxLat.Location = new System.Drawing.Point(89, 140);
            this.txtMaxLat.Name = "txtMaxLat";
            this.txtMaxLat.Size = new System.Drawing.Size(154, 21);
            this.txtMaxLat.TabIndex = 24;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 104);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 12);
            this.label13.TabIndex = 27;
            this.label13.Text = "最小纬度：";
            // 
            // txtMaxLon
            // 
            this.txtMaxLon.Location = new System.Drawing.Point(89, 60);
            this.txtMaxLon.Name = "txtMaxLon";
            this.txtMaxLon.Size = new System.Drawing.Size(154, 21);
            this.txtMaxLon.TabIndex = 22;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 65);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 26;
            this.label12.Text = "最大经度：";
            // 
            // txtMinLat
            // 
            this.txtMinLat.Location = new System.Drawing.Point(89, 100);
            this.txtMinLat.Name = "txtMinLat";
            this.txtMinLat.Size = new System.Drawing.Size(154, 21);
            this.txtMinLat.TabIndex = 23;
            // 
            // comboBox_DisaType
            // 
            this.comboBox_DisaType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_DisaType.FormattingEnabled = true;
            this.comboBox_DisaType.Location = new System.Drawing.Point(101, 307);
            this.comboBox_DisaType.Name = "comboBox_DisaType";
            this.comboBox_DisaType.Size = new System.Drawing.Size(154, 20);
            this.comboBox_DisaType.TabIndex = 105;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 311);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 104;
            this.label5.Text = "灾害类型：";
            // 
            // dateEndTime
            // 
            this.dateEndTime.Checked = false;
            this.dateEndTime.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.dateEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateEndTime.Location = new System.Drawing.Point(101, 400);
            this.dateEndTime.Name = "dateEndTime";
            this.dateEndTime.ShowCheckBox = true;
            this.dateEndTime.Size = new System.Drawing.Size(154, 21);
            this.dateEndTime.TabIndex = 103;
            // 
            // dateStartTime
            // 
            this.dateStartTime.Checked = false;
            this.dateStartTime.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.dateStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateStartTime.Location = new System.Drawing.Point(101, 353);
            this.dateStartTime.Name = "dateStartTime";
            this.dateStartTime.ShowCheckBox = true;
            this.dateStartTime.Size = new System.Drawing.Size(154, 21);
            this.dateStartTime.TabIndex = 102;
            // 
            // txtTaskID
            // 
            this.txtTaskID.Location = new System.Drawing.Point(101, 260);
            this.txtTaskID.Name = "txtTaskID";
            this.txtTaskID.Size = new System.Drawing.Size(154, 21);
            this.txtTaskID.TabIndex = 101;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 402);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 100;
            this.label7.Text = "结束时间：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 356);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 99;
            this.label6.Text = "开始时间：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 265);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 98;
            this.label1.Text = "任务编号：";
            // 
            // dataGridViewTask
            // 
            this.dataGridViewTask.AllowUserToAddRows = false;
            this.dataGridViewTask.AllowUserToDeleteRows = false;
            this.dataGridViewTask.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTask.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TaskID,
            this.SpaceResolution,
            this.DisasterType,
            this.RespondingTime,
            this.ObservationFrequency,
            this.StartTime,
            this.EndTime});
            this.dataGridViewTask.Location = new System.Drawing.Point(21, 15);
            this.dataGridViewTask.Name = "dataGridViewTask";
            this.dataGridViewTask.RowHeadersWidth = 10;
            this.dataGridViewTask.RowTemplate.Height = 23;
            this.dataGridViewTask.Size = new System.Drawing.Size(714, 222);
            this.dataGridViewTask.TabIndex = 97;
            // 
            // TaskID
            // 
            this.TaskID.DataPropertyName = "TaskID";
            this.TaskID.HeaderText = "任务ID";
            this.TaskID.Name = "TaskID";
            // 
            // SpaceResolution
            // 
            this.SpaceResolution.DataPropertyName = "SpaceResolution";
            this.SpaceResolution.HeaderText = "分辨率要求";
            this.SpaceResolution.Name = "SpaceResolution";
            // 
            // DisasterType
            // 
            this.DisasterType.DataPropertyName = "DisasterType";
            this.DisasterType.HeaderText = "灾害类型";
            this.DisasterType.Name = "DisasterType";
            // 
            // RespondingTime
            // 
            this.RespondingTime.DataPropertyName = "RespondingTime";
            this.RespondingTime.HeaderText = "响应时间";
            this.RespondingTime.Name = "RespondingTime";
            // 
            // ObservationFrequency
            // 
            this.ObservationFrequency.DataPropertyName = "ObservationFrequency";
            this.ObservationFrequency.HeaderText = "观测频率";
            this.ObservationFrequency.Name = "ObservationFrequency";
            // 
            // StartTime
            // 
            this.StartTime.DataPropertyName = "StartTime";
            this.StartTime.HeaderText = "观测开始时间";
            this.StartTime.Name = "StartTime";
            this.StartTime.ToolTipText = "该时间为UTC时间";
            // 
            // EndTime
            // 
            this.EndTime.DataPropertyName = "EndTime";
            this.EndTime.HeaderText = "观测结束时间";
            this.EndTime.Name = "EndTime";
            // 
            // TaskQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 439);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTaskCount);
            this.Controls.Add(this.ButtonReturn);
            this.Controls.Add(this.ButtonReset);
            this.Controls.Add(this.ButtonQuery);
            this.Controls.Add(this.groupBox_ObsRegion);
            this.Controls.Add(this.comboBox_DisaType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateEndTime);
            this.Controls.Add(this.dateStartTime);
            this.Controls.Add(this.txtTaskID);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewTask);
            this.Name = "TaskQuery";
            this.Text = "TaskQuery";
            this.Load += new System.EventHandler(this.TaskQuery_Load);
            this.groupBox_ObsRegion.ResumeLayout(false);
            this.groupBox_ObsRegion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTask)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTaskCount;
        private System.Windows.Forms.Button ButtonReturn;
        private System.Windows.Forms.Button ButtonReset;
        private System.Windows.Forms.Button ButtonQuery;
        private System.Windows.Forms.GroupBox groupBox_ObsRegion;
        private System.Windows.Forms.TextBox txtMinLon;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMaxLat;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtMaxLon;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtMinLat;
        private System.Windows.Forms.ComboBox comboBox_DisaType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateEndTime;
        private System.Windows.Forms.DateTimePicker dateStartTime;
        private System.Windows.Forms.TextBox txtTaskID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewTask;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaskID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SpaceResolution;
        private System.Windows.Forms.DataGridViewTextBoxColumn DisasterType;
        private System.Windows.Forms.DataGridViewTextBoxColumn RespondingTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ObservationFrequency;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndTime;
    }
}