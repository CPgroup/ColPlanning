namespace CoScheduling.Main.SPYCAM_RANGE
{
    partial class SPYCAMManage
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
            this.dataGridViewSensor = new System.Windows.Forms.DataGridView();
            this.dataGridViewSPYCAM = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ButtonBandModify = new System.Windows.Forms.Button();
            this.ButtonBandAdd = new System.Windows.Forms.Button();
            this.ButtonSensorDelete = new System.Windows.Forms.Button();
            this.ButtonSensorModify = new System.Windows.Forms.Button();
            this.ButtonSensorAdd = new System.Windows.Forms.Button();
            this.ButtonSPYCAMDelete = new System.Windows.Forms.Button();
            this.ButtonSPYCAMModify = new System.Windows.Forms.Button();
            this.ButtonSPYCAMAdd = new System.Windows.Forms.Button();
            this.dataGridViewBand = new System.Windows.Forms.DataGridView();
            this.ButtonBandDelete = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LookAngle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSensor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSPYCAM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBand)).BeginInit();
            this.SuspendLayout();
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
            this.LookAngle,
            this.dataGridViewTextBoxColumn7});
            this.dataGridViewSensor.Location = new System.Drawing.Point(9, 161);
            this.dataGridViewSensor.Name = "dataGridViewSensor";
            this.dataGridViewSensor.RowHeadersWidth = 10;
            this.dataGridViewSensor.RowTemplate.Height = 23;
            this.dataGridViewSensor.Size = new System.Drawing.Size(549, 117);
            this.dataGridViewSensor.TabIndex = 173;
            this.dataGridViewSensor.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSensor_CellClick);
            // 
            // dataGridViewSPYCAM
            // 
            this.dataGridViewSPYCAM.AllowUserToAddRows = false;
            this.dataGridViewSPYCAM.AllowUserToDeleteRows = false;
            this.dataGridViewSPYCAM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSPYCAM.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10});
            this.dataGridViewSPYCAM.Location = new System.Drawing.Point(9, 12);
            this.dataGridViewSPYCAM.Name = "dataGridViewSPYCAM";
            this.dataGridViewSPYCAM.RowHeadersWidth = 10;
            this.dataGridViewSPYCAM.RowTemplate.Height = 23;
            this.dataGridViewSPYCAM.Size = new System.Drawing.Size(549, 119);
            this.dataGridViewSPYCAM.TabIndex = 174;
            this.dataGridViewSPYCAM.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSPYCAM_CellClick);
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "PLATFORM_ID";
            this.dataGridViewTextBoxColumn4.HeaderText = "平台ID";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "PLATFORM_Name";
            this.dataGridViewTextBoxColumn6.HeaderText = "平台名称";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "NumberOfSensor";
            this.dataGridViewTextBoxColumn8.HeaderText = "传感器数量";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "HorizontalRotationAngle";
            this.dataGridViewTextBoxColumn9.HeaderText = "水平旋转角";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "VerticalRotationAngle";
            this.dataGridViewTextBoxColumn10.HeaderText = "垂直旋转角";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.DataPropertyName = "PLATFORM_ID";
            this.dataGridViewTextBoxColumn19.HeaderText = "平台ID";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.ToolTipText = "该时间为UTC时间";
            this.dataGridViewTextBoxColumn19.Width = 80;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "SensorID";
            this.dataGridViewTextBoxColumn16.HeaderText = "传感器ID";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.Width = 90;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "BandType";
            this.dataGridViewTextBoxColumn15.HeaderText = "波段类型";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.Width = 90;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "BAND_MODE_NAME";
            this.dataGridViewTextBoxColumn14.HeaderText = "波段名称";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.Width = 90;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "BandID";
            this.dataGridViewTextBoxColumn13.HeaderText = "波段ID";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.Width = 80;
            // 
            // ButtonBandModify
            // 
            this.ButtonBandModify.Location = new System.Drawing.Point(366, 459);
            this.ButtonBandModify.Name = "ButtonBandModify";
            this.ButtonBandModify.Size = new System.Drawing.Size(88, 23);
            this.ButtonBandModify.TabIndex = 183;
            this.ButtonBandModify.Text = "波段修改";
            this.ButtonBandModify.UseVisualStyleBackColor = true;
            this.ButtonBandModify.Click += new System.EventHandler(this.ButtonBandModify_Click);
            // 
            // ButtonBandAdd
            // 
            this.ButtonBandAdd.Location = new System.Drawing.Point(261, 459);
            this.ButtonBandAdd.Name = "ButtonBandAdd";
            this.ButtonBandAdd.Size = new System.Drawing.Size(88, 23);
            this.ButtonBandAdd.TabIndex = 182;
            this.ButtonBandAdd.Text = "波段添加";
            this.ButtonBandAdd.UseVisualStyleBackColor = true;
            this.ButtonBandAdd.Click += new System.EventHandler(this.ButtonBandAdd_Click);
            // 
            // ButtonSensorDelete
            // 
            this.ButtonSensorDelete.Location = new System.Drawing.Point(470, 284);
            this.ButtonSensorDelete.Name = "ButtonSensorDelete";
            this.ButtonSensorDelete.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ButtonSensorDelete.Size = new System.Drawing.Size(88, 23);
            this.ButtonSensorDelete.TabIndex = 181;
            this.ButtonSensorDelete.Text = "传感器删除";
            this.ButtonSensorDelete.UseVisualStyleBackColor = true;
            this.ButtonSensorDelete.Click += new System.EventHandler(this.ButtonSensorDelete_Click);
            // 
            // ButtonSensorModify
            // 
            this.ButtonSensorModify.Location = new System.Drawing.Point(367, 284);
            this.ButtonSensorModify.Name = "ButtonSensorModify";
            this.ButtonSensorModify.Size = new System.Drawing.Size(88, 23);
            this.ButtonSensorModify.TabIndex = 180;
            this.ButtonSensorModify.Text = "传感器修改";
            this.ButtonSensorModify.UseVisualStyleBackColor = true;
            this.ButtonSensorModify.Click += new System.EventHandler(this.ButtonSensorModify_Click);
            // 
            // ButtonSensorAdd
            // 
            this.ButtonSensorAdd.Location = new System.Drawing.Point(262, 284);
            this.ButtonSensorAdd.Name = "ButtonSensorAdd";
            this.ButtonSensorAdd.Size = new System.Drawing.Size(88, 23);
            this.ButtonSensorAdd.TabIndex = 179;
            this.ButtonSensorAdd.Text = "传感器添加";
            this.ButtonSensorAdd.UseVisualStyleBackColor = true;
            this.ButtonSensorAdd.Click += new System.EventHandler(this.ButtonSensorAdd_Click);
            // 
            // ButtonSPYCAMDelete
            // 
            this.ButtonSPYCAMDelete.Location = new System.Drawing.Point(469, 134);
            this.ButtonSPYCAMDelete.Name = "ButtonSPYCAMDelete";
            this.ButtonSPYCAMDelete.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ButtonSPYCAMDelete.Size = new System.Drawing.Size(88, 23);
            this.ButtonSPYCAMDelete.TabIndex = 178;
            this.ButtonSPYCAMDelete.Text = "摄像头删除";
            this.ButtonSPYCAMDelete.UseVisualStyleBackColor = true;
            this.ButtonSPYCAMDelete.Click += new System.EventHandler(this.ButtonSPYCAMDelete_Click);
            // 
            // ButtonSPYCAMModify
            // 
            this.ButtonSPYCAMModify.Location = new System.Drawing.Point(366, 134);
            this.ButtonSPYCAMModify.Name = "ButtonSPYCAMModify";
            this.ButtonSPYCAMModify.Size = new System.Drawing.Size(88, 23);
            this.ButtonSPYCAMModify.TabIndex = 177;
            this.ButtonSPYCAMModify.Text = "摄像头修改";
            this.ButtonSPYCAMModify.UseVisualStyleBackColor = true;
            this.ButtonSPYCAMModify.Click += new System.EventHandler(this.ButtonSPYCAMModify_Click);
            // 
            // ButtonSPYCAMAdd
            // 
            this.ButtonSPYCAMAdd.Location = new System.Drawing.Point(262, 134);
            this.ButtonSPYCAMAdd.Name = "ButtonSPYCAMAdd";
            this.ButtonSPYCAMAdd.Size = new System.Drawing.Size(88, 23);
            this.ButtonSPYCAMAdd.TabIndex = 176;
            this.ButtonSPYCAMAdd.Text = "摄像头添加";
            this.ButtonSPYCAMAdd.UseVisualStyleBackColor = true;
            this.ButtonSPYCAMAdd.Click += new System.EventHandler(this.ButtonSPYCAMAdd_Click);
            // 
            // dataGridViewBand
            // 
            this.dataGridViewBand.AllowUserToAddRows = false;
            this.dataGridViewBand.AllowUserToDeleteRows = false;
            this.dataGridViewBand.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBand.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn15,
            this.dataGridViewTextBoxColumn16,
            this.dataGridViewTextBoxColumn19});
            this.dataGridViewBand.Location = new System.Drawing.Point(8, 313);
            this.dataGridViewBand.Name = "dataGridViewBand";
            this.dataGridViewBand.RowHeadersWidth = 10;
            this.dataGridViewBand.RowTemplate.Height = 23;
            this.dataGridViewBand.Size = new System.Drawing.Size(549, 140);
            this.dataGridViewBand.TabIndex = 175;
            // 
            // ButtonBandDelete
            // 
            this.ButtonBandDelete.Location = new System.Drawing.Point(469, 459);
            this.ButtonBandDelete.Name = "ButtonBandDelete";
            this.ButtonBandDelete.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ButtonBandDelete.Size = new System.Drawing.Size(88, 23);
            this.ButtonBandDelete.TabIndex = 184;
            this.ButtonBandDelete.Text = "波段删除";
            this.ButtonBandDelete.UseVisualStyleBackColor = true;
            this.ButtonBandDelete.Click += new System.EventHandler(this.ButtonBandDelete_Click);
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
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Resolution";
            this.dataGridViewTextBoxColumn5.HeaderText = "空间分辨率";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 90;
            // 
            // LookAngle
            // 
            this.LookAngle.DataPropertyName = "LookAngle";
            this.LookAngle.HeaderText = "视场角";
            this.LookAngle.Name = "LookAngle";
            this.LookAngle.Width = 80;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "PLATFORM_ID";
            this.dataGridViewTextBoxColumn7.HeaderText = "平台ID";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ToolTipText = "该时间为UTC时间";
            this.dataGridViewTextBoxColumn7.Width = 80;
            // 
            // SPYCAMManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 489);
            this.Controls.Add(this.dataGridViewSensor);
            this.Controls.Add(this.dataGridViewSPYCAM);
            this.Controls.Add(this.ButtonBandModify);
            this.Controls.Add(this.ButtonBandAdd);
            this.Controls.Add(this.ButtonSensorDelete);
            this.Controls.Add(this.ButtonSensorModify);
            this.Controls.Add(this.ButtonSensorAdd);
            this.Controls.Add(this.ButtonSPYCAMDelete);
            this.Controls.Add(this.ButtonSPYCAMModify);
            this.Controls.Add(this.ButtonSPYCAMAdd);
            this.Controls.Add(this.dataGridViewBand);
            this.Controls.Add(this.ButtonBandDelete);
            this.Name = "SPYCAMManage";
            this.Text = "监控摄像头管理";
            this.Load += new System.EventHandler(this.SPYCAMManage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSensor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSPYCAM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBand)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewSensor;
        private System.Windows.Forms.DataGridView dataGridViewSPYCAM;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.Button ButtonBandModify;
        private System.Windows.Forms.Button ButtonBandAdd;
        private System.Windows.Forms.Button ButtonSensorDelete;
        private System.Windows.Forms.Button ButtonSensorModify;
        private System.Windows.Forms.Button ButtonSensorAdd;
        private System.Windows.Forms.Button ButtonSPYCAMDelete;
        private System.Windows.Forms.Button ButtonSPYCAMModify;
        private System.Windows.Forms.Button ButtonSPYCAMAdd;
        private System.Windows.Forms.DataGridView dataGridViewBand;
        private System.Windows.Forms.Button ButtonBandDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn LookAngle;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
    }
}