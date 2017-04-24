namespace CoScheduling.Main.TaskRequirement
{
    partial class TaskResMatch
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
            this.dataGridViewTask = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewSensor = new System.Windows.Forms.DataGridView();
            this.ButtonMatch = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtSensorCount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BandNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LookAngle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaskID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SpaceResolution = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DisasterType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RespondingTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ObservationFrequency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SensorNeeded = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTask)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSensor)).BeginInit();
            this.SuspendLayout();
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
            this.SensorNeeded});
            this.dataGridViewTask.Location = new System.Drawing.Point(12, 28);
            this.dataGridViewTask.Name = "dataGridViewTask";
            this.dataGridViewTask.RowHeadersWidth = 10;
            this.dataGridViewTask.RowTemplate.Height = 23;
            this.dataGridViewTask.Size = new System.Drawing.Size(639, 163);
            this.dataGridViewTask.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 144;
            this.label1.Text = "任务信息";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 207);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 12);
            this.label2.TabIndex = 146;
            this.label2.Text = "观测资源传感器信息";
            // 
            // dataGridViewSensor
            // 
            this.dataGridViewSensor.AllowUserToAddRows = false;
            this.dataGridViewSensor.AllowUserToDeleteRows = false;
            this.dataGridViewSensor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSensor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn5,
            this.BandNumber,
            this.LookAngle,
            this.dataGridViewTextBoxColumn7});
            this.dataGridViewSensor.Location = new System.Drawing.Point(12, 232);
            this.dataGridViewSensor.Name = "dataGridViewSensor";
            this.dataGridViewSensor.RowHeadersWidth = 10;
            this.dataGridViewSensor.RowTemplate.Height = 23;
            this.dataGridViewSensor.Size = new System.Drawing.Size(639, 193);
            this.dataGridViewSensor.TabIndex = 145;
            // 
            // ButtonMatch
            // 
            this.ButtonMatch.Location = new System.Drawing.Point(436, 446);
            this.ButtonMatch.Name = "ButtonMatch";
            this.ButtonMatch.Size = new System.Drawing.Size(88, 23);
            this.ButtonMatch.TabIndex = 149;
            this.ButtonMatch.Text = "匹配";
            this.ButtonMatch.UseVisualStyleBackColor = true;
            this.ButtonMatch.Click += new System.EventHandler(this.ButtonMatch_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(563, 446);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 23);
            this.button1.TabIndex = 150;
            this.button1.Text = "返回";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // txtSensorCount
            // 
            this.txtSensorCount.Location = new System.Drawing.Point(131, 443);
            this.txtSensorCount.Name = "txtSensorCount";
            this.txtSensorCount.ReadOnly = true;
            this.txtSensorCount.Size = new System.Drawing.Size(96, 21);
            this.txtSensorCount.TabIndex = 151;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 446);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 152;
            this.label3.Text = "查询结果数量";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "SensorID";
            this.dataGridViewTextBoxColumn1.HeaderText = "传感器ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "SensorName";
            this.dataGridViewTextBoxColumn2.HeaderText = "传感器名称";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 90;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "SensorType";
            this.dataGridViewTextBoxColumn3.HeaderText = "传感器类型";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 90;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "GeometryResolution";
            this.dataGridViewTextBoxColumn5.HeaderText = "空间分辨率";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 90;
            // 
            // BandNumber
            // 
            this.BandNumber.DataPropertyName = "BandNumber";
            this.BandNumber.HeaderText = "波段数量";
            this.BandNumber.Name = "BandNumber";
            this.BandNumber.Width = 80;
            // 
            // LookAngle
            // 
            this.LookAngle.DataPropertyName = "LookAngle";
            this.LookAngle.HeaderText = "视场角";
            this.LookAngle.Name = "LookAngle";
            this.LookAngle.Width = 70;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "PLATFORM_ID";
            this.dataGridViewTextBoxColumn7.HeaderText = "平台ID";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ToolTipText = "该时间为UTC时间";
            this.dataGridViewTextBoxColumn7.Width = 80;
            // 
            // TaskID
            // 
            this.TaskID.DataPropertyName = "TaskID";
            this.TaskID.HeaderText = "任务ID";
            this.TaskID.Name = "TaskID";
            this.TaskID.Width = 75;
            // 
            // SpaceResolution
            // 
            this.SpaceResolution.DataPropertyName = "SpaceResolution";
            this.SpaceResolution.HeaderText = "分辨率要求";
            this.SpaceResolution.Name = "SpaceResolution";
            this.SpaceResolution.Width = 90;
            // 
            // DisasterType
            // 
            this.DisasterType.DataPropertyName = "DisasterType";
            this.DisasterType.HeaderText = "灾害类型";
            this.DisasterType.Name = "DisasterType";
            this.DisasterType.Width = 80;
            // 
            // RespondingTime
            // 
            this.RespondingTime.DataPropertyName = "RespondingTime";
            this.RespondingTime.HeaderText = "响应时间";
            this.RespondingTime.Name = "RespondingTime";
            this.RespondingTime.Width = 80;
            // 
            // ObservationFrequency
            // 
            this.ObservationFrequency.DataPropertyName = "ObservationFrequency";
            this.ObservationFrequency.HeaderText = "观测频率";
            this.ObservationFrequency.Name = "ObservationFrequency";
            this.ObservationFrequency.Width = 80;
            // 
            // SensorNeeded
            // 
            this.SensorNeeded.DataPropertyName = "SensorNeeded";
            this.SensorNeeded.HeaderText = "波段类型";
            this.SensorNeeded.Name = "SensorNeeded";
            // 
            // TaskResMatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 481);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSensorCount);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ButtonMatch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridViewSensor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewTask);
            this.Name = "TaskResMatch";
            this.Text = "任务资源匹配";
            this.Load += new System.EventHandler(this.TaskResMatch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTask)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSensor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewTask;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewSensor;
        private System.Windows.Forms.Button ButtonMatch;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtSensorCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaskID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SpaceResolution;
        private System.Windows.Forms.DataGridViewTextBoxColumn DisasterType;
        private System.Windows.Forms.DataGridViewTextBoxColumn RespondingTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ObservationFrequency;
        private System.Windows.Forms.DataGridViewTextBoxColumn SensorNeeded;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn BandNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn LookAngle;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
    }
}