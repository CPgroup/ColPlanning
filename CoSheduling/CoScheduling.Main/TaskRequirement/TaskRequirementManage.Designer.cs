namespace CoScheduling.Main.TaskRequirement
{
    partial class TaskRequirementManage
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
            this.ButtonTaskAdd = new System.Windows.Forms.Button();
            this.ButtonTaskDelete = new System.Windows.Forms.Button();
            this.ButtonTaskModify = new System.Windows.Forms.Button();
            this.dataGridViewTask = new System.Windows.Forms.DataGridView();
            this.TaskID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SpaceResolution = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DisasterType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RespondingTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ObservationFrequency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTask)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonTaskAdd
            // 
            this.ButtonTaskAdd.Location = new System.Drawing.Point(269, 396);
            this.ButtonTaskAdd.Name = "ButtonTaskAdd";
            this.ButtonTaskAdd.Size = new System.Drawing.Size(88, 23);
            this.ButtonTaskAdd.TabIndex = 15;
            this.ButtonTaskAdd.Text = "添加任务记录";
            this.ButtonTaskAdd.UseVisualStyleBackColor = true;
            this.ButtonTaskAdd.Click += new System.EventHandler(this.ButtonTaskAdd_Click);
            // 
            // ButtonTaskDelete
            // 
            this.ButtonTaskDelete.Location = new System.Drawing.Point(555, 396);
            this.ButtonTaskDelete.Name = "ButtonTaskDelete";
            this.ButtonTaskDelete.Size = new System.Drawing.Size(85, 23);
            this.ButtonTaskDelete.TabIndex = 14;
            this.ButtonTaskDelete.Text = "删除任务记录";
            this.ButtonTaskDelete.UseVisualStyleBackColor = true;
            this.ButtonTaskDelete.Click += new System.EventHandler(this.ButtonTaskDelete_Click);
            // 
            // ButtonTaskModify
            // 
            this.ButtonTaskModify.Location = new System.Drawing.Point(415, 396);
            this.ButtonTaskModify.Name = "ButtonTaskModify";
            this.ButtonTaskModify.Size = new System.Drawing.Size(88, 23);
            this.ButtonTaskModify.TabIndex = 13;
            this.ButtonTaskModify.Text = "修改任务记录";
            this.ButtonTaskModify.UseVisualStyleBackColor = true;
            this.ButtonTaskModify.Click += new System.EventHandler(this.ButtonTaskModify_Click);
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
            this.dataGridViewTask.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewTask.Name = "dataGridViewTask";
            this.dataGridViewTask.RowHeadersWidth = 10;
            this.dataGridViewTask.RowTemplate.Height = 23;
            this.dataGridViewTask.Size = new System.Drawing.Size(641, 368);
            this.dataGridViewTask.TabIndex = 12;
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
            // StartTime
            // 
            this.StartTime.DataPropertyName = "StartTime";
            this.StartTime.HeaderText = "观测开始时间";
            this.StartTime.Name = "StartTime";
            this.StartTime.ToolTipText = "该时间为UTC时间";
            this.StartTime.Width = 108;
            // 
            // EndTime
            // 
            this.EndTime.DataPropertyName = "EndTime";
            this.EndTime.HeaderText = "观测结束时间";
            this.EndTime.Name = "EndTime";
            this.EndTime.ToolTipText = "该时间为UTC时间";
            this.EndTime.Width = 108;
            // 
            // TaskRequirementManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 431);
            this.Controls.Add(this.ButtonTaskAdd);
            this.Controls.Add(this.ButtonTaskDelete);
            this.Controls.Add(this.ButtonTaskModify);
            this.Controls.Add(this.dataGridViewTask);
            this.Name = "TaskRequirementManage";
            this.Text = "TaskRequirementManage";
            this.Load += new System.EventHandler(this.TaskRequirementManage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTask)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButtonTaskAdd;
        private System.Windows.Forms.Button ButtonTaskDelete;
        private System.Windows.Forms.Button ButtonTaskModify;
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