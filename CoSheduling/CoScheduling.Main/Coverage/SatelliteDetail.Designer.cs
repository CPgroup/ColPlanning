namespace CoScheduling.Main.Coverage
{
    partial class SatelliteDetail
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
            this.sensorDescription = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dataGridViewBand = new System.Windows.Forms.DataGridView();
            this.BAND_MODE_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SWATHWIDTH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BAND_TYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SPECTRALRANGEMIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SPECTRALRANGEMAX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SPECTRALCENTER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POLARIZATION_MODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ACROSSRESOLUTION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewSensor = new System.Windows.Forms.DataGridView();
            this.SENSOR_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SENSOR_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SENSOR_TYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.APPLICATION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NUMOFBANDS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BANDCATEGORIES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REVISITTIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.satPicture = new System.Windows.Forms.PictureBox();
            this.satDescription = new System.Windows.Forms.TextBox();
            this.label1LaunchTime = new System.Windows.Forms.Label();
            this.labelApplication = new System.Windows.Forms.Label();
            this.labelAgency = new System.Windows.Forms.Label();
            this.labelCountry = new System.Windows.Forms.Label();
            this.labelRepeatCycle = new System.Windows.Forms.Label();
            this.labelOrbitType = new System.Windows.Forms.Label();
            this.labelFullName = new System.Windows.Forms.Label();
            this.labelShortName = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSensor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.satPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // sensorDescription
            // 
            this.sensorDescription.Location = new System.Drawing.Point(88, 449);
            this.sensorDescription.Multiline = true;
            this.sensorDescription.Name = "sensorDescription";
            this.sensorDescription.ReadOnly = true;
            this.sensorDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.sensorDescription.Size = new System.Drawing.Size(679, 57);
            this.sensorDescription.TabIndex = 75;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 452);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 74;
            this.label12.Text = "载荷描述：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 524);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 73;
            this.label11.Text = "波段模式：";
            // 
            // dataGridViewBand
            // 
            this.dataGridViewBand.AllowUserToAddRows = false;
            this.dataGridViewBand.AllowUserToDeleteRows = false;
            this.dataGridViewBand.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewBand.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBand.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BAND_MODE_NAME,
            this.SWATHWIDTH,
            this.BAND_TYPE,
            this.SPECTRALRANGEMIN,
            this.SPECTRALRANGEMAX,
            this.SPECTRALCENTER,
            this.POLARIZATION_MODE,
            this.ACROSSRESOLUTION});
            this.dataGridViewBand.Location = new System.Drawing.Point(88, 524);
            this.dataGridViewBand.Name = "dataGridViewBand";
            this.dataGridViewBand.ReadOnly = true;
            this.dataGridViewBand.RowTemplate.Height = 23;
            this.dataGridViewBand.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewBand.Size = new System.Drawing.Size(679, 189);
            this.dataGridViewBand.TabIndex = 72;
            // 
            // BAND_MODE_NAME
            // 
            this.BAND_MODE_NAME.DataPropertyName = "BAND_MODE_NAME";
            this.BAND_MODE_NAME.HeaderText = "波段模式";
            this.BAND_MODE_NAME.Name = "BAND_MODE_NAME";
            this.BAND_MODE_NAME.ReadOnly = true;
            // 
            // SWATHWIDTH
            // 
            this.SWATHWIDTH.DataPropertyName = "SWATHWIDTH";
            this.SWATHWIDTH.HeaderText = "幅宽(Km)";
            this.SWATHWIDTH.Name = "SWATHWIDTH";
            this.SWATHWIDTH.ReadOnly = true;
            // 
            // BAND_TYPE
            // 
            this.BAND_TYPE.DataPropertyName = "BAND_TYPE";
            this.BAND_TYPE.HeaderText = "波段类型";
            this.BAND_TYPE.Name = "BAND_TYPE";
            this.BAND_TYPE.ReadOnly = true;
            // 
            // SPECTRALRANGEMIN
            // 
            this.SPECTRALRANGEMIN.DataPropertyName = "SPECTRALRANGEMIN";
            this.SPECTRALRANGEMIN.HeaderText = "频谱小(um/GHz)";
            this.SPECTRALRANGEMIN.Name = "SPECTRALRANGEMIN";
            this.SPECTRALRANGEMIN.ReadOnly = true;
            // 
            // SPECTRALRANGEMAX
            // 
            this.SPECTRALRANGEMAX.DataPropertyName = "SPECTRALRANGEMAX";
            this.SPECTRALRANGEMAX.HeaderText = "频谱大(um/GHz)";
            this.SPECTRALRANGEMAX.Name = "SPECTRALRANGEMAX";
            this.SPECTRALRANGEMAX.ReadOnly = true;
            // 
            // SPECTRALCENTER
            // 
            this.SPECTRALCENTER.DataPropertyName = "SPECTRALCENTER";
            this.SPECTRALCENTER.HeaderText = "频谱中心(um/GHz)";
            this.SPECTRALCENTER.Name = "SPECTRALCENTER";
            this.SPECTRALCENTER.ReadOnly = true;
            // 
            // POLARIZATION_MODE
            // 
            this.POLARIZATION_MODE.DataPropertyName = "POLARIZATION_MODE";
            this.POLARIZATION_MODE.HeaderText = "极化方式";
            this.POLARIZATION_MODE.Name = "POLARIZATION_MODE";
            this.POLARIZATION_MODE.ReadOnly = true;
            // 
            // ACROSSRESOLUTION
            // 
            this.ACROSSRESOLUTION.DataPropertyName = "ACROSSRESOLUTION";
            this.ACROSSRESOLUTION.HeaderText = "分辨率(m)";
            this.ACROSSRESOLUTION.Name = "ACROSSRESOLUTION";
            this.ACROSSRESOLUTION.ReadOnly = true;
            // 
            // dataGridViewSensor
            // 
            this.dataGridViewSensor.AllowUserToAddRows = false;
            this.dataGridViewSensor.AllowUserToDeleteRows = false;
            this.dataGridViewSensor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSensor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSensor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SENSOR_ID,
            this.SENSOR_NAME,
            this.SENSOR_TYPE,
            this.APPLICATION,
            this.NUMOFBANDS,
            this.BANDCATEGORIES,
            this.REVISITTIME});
            this.dataGridViewSensor.Location = new System.Drawing.Point(88, 290);
            this.dataGridViewSensor.Name = "dataGridViewSensor";
            this.dataGridViewSensor.ReadOnly = true;
            this.dataGridViewSensor.RowTemplate.Height = 23;
            this.dataGridViewSensor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSensor.Size = new System.Drawing.Size(679, 149);
            this.dataGridViewSensor.TabIndex = 71;
            // 
            // SENSOR_ID
            // 
            this.SENSOR_ID.DataPropertyName = "SENSOR_ID";
            this.SENSOR_ID.HeaderText = "载荷ID";
            this.SENSOR_ID.Name = "SENSOR_ID";
            this.SENSOR_ID.ReadOnly = true;
            this.SENSOR_ID.Visible = false;
            // 
            // SENSOR_NAME
            // 
            this.SENSOR_NAME.DataPropertyName = "SENSOR_NAME";
            this.SENSOR_NAME.HeaderText = "载荷名称";
            this.SENSOR_NAME.Name = "SENSOR_NAME";
            this.SENSOR_NAME.ReadOnly = true;
            // 
            // SENSOR_TYPE
            // 
            this.SENSOR_TYPE.DataPropertyName = "SENSOR_TYPE";
            this.SENSOR_TYPE.HeaderText = "载荷类型";
            this.SENSOR_TYPE.Name = "SENSOR_TYPE";
            this.SENSOR_TYPE.ReadOnly = true;
            // 
            // APPLICATION
            // 
            this.APPLICATION.DataPropertyName = "APPLICATION";
            this.APPLICATION.HeaderText = "载荷应用";
            this.APPLICATION.Name = "APPLICATION";
            this.APPLICATION.ReadOnly = true;
            // 
            // NUMOFBANDS
            // 
            this.NUMOFBANDS.DataPropertyName = "NUMOFBANDS";
            this.NUMOFBANDS.HeaderText = "波段数";
            this.NUMOFBANDS.Name = "NUMOFBANDS";
            this.NUMOFBANDS.ReadOnly = true;
            // 
            // BANDCATEGORIES
            // 
            this.BANDCATEGORIES.DataPropertyName = "BANDCATEGORIES";
            this.BANDCATEGORIES.HeaderText = "波段种类";
            this.BANDCATEGORIES.Name = "BANDCATEGORIES";
            this.BANDCATEGORIES.ReadOnly = true;
            // 
            // REVISITTIME
            // 
            this.REVISITTIME.DataPropertyName = "REVISITTIME";
            this.REVISITTIME.HeaderText = "重访周期(Day)";
            this.REVISITTIME.Name = "REVISITTIME";
            this.REVISITTIME.ReadOnly = true;
            // 
            // satPicture
            // 
            this.satPicture.Location = new System.Drawing.Point(442, 8);
            this.satPicture.Name = "satPicture";
            this.satPicture.Size = new System.Drawing.Size(260, 190);
            this.satPicture.TabIndex = 70;
            this.satPicture.TabStop = false;
            // 
            // satDescription
            // 
            this.satDescription.Location = new System.Drawing.Point(88, 208);
            this.satDescription.Multiline = true;
            this.satDescription.Name = "satDescription";
            this.satDescription.ReadOnly = true;
            this.satDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.satDescription.Size = new System.Drawing.Size(679, 57);
            this.satDescription.TabIndex = 69;
            // 
            // label1LaunchTime
            // 
            this.label1LaunchTime.AutoSize = true;
            this.label1LaunchTime.Location = new System.Drawing.Point(88, 183);
            this.label1LaunchTime.Name = "label1LaunchTime";
            this.label1LaunchTime.Size = new System.Drawing.Size(23, 12);
            this.label1LaunchTime.TabIndex = 68;
            this.label1LaunchTime.Text = "N/A";
            // 
            // labelApplication
            // 
            this.labelApplication.AutoSize = true;
            this.labelApplication.Location = new System.Drawing.Point(88, 158);
            this.labelApplication.Name = "labelApplication";
            this.labelApplication.Size = new System.Drawing.Size(23, 12);
            this.labelApplication.TabIndex = 67;
            this.labelApplication.Text = "N/A";
            // 
            // labelAgency
            // 
            this.labelAgency.AutoSize = true;
            this.labelAgency.Location = new System.Drawing.Point(88, 133);
            this.labelAgency.Name = "labelAgency";
            this.labelAgency.Size = new System.Drawing.Size(23, 12);
            this.labelAgency.TabIndex = 66;
            this.labelAgency.Text = "N/A";
            // 
            // labelCountry
            // 
            this.labelCountry.AutoSize = true;
            this.labelCountry.Location = new System.Drawing.Point(88, 108);
            this.labelCountry.Name = "labelCountry";
            this.labelCountry.Size = new System.Drawing.Size(23, 12);
            this.labelCountry.TabIndex = 65;
            this.labelCountry.Text = "N/A";
            // 
            // labelRepeatCycle
            // 
            this.labelRepeatCycle.AutoSize = true;
            this.labelRepeatCycle.Location = new System.Drawing.Point(88, 83);
            this.labelRepeatCycle.Name = "labelRepeatCycle";
            this.labelRepeatCycle.Size = new System.Drawing.Size(23, 12);
            this.labelRepeatCycle.TabIndex = 64;
            this.labelRepeatCycle.Text = "N/A";
            // 
            // labelOrbitType
            // 
            this.labelOrbitType.AutoSize = true;
            this.labelOrbitType.Location = new System.Drawing.Point(88, 58);
            this.labelOrbitType.Name = "labelOrbitType";
            this.labelOrbitType.Size = new System.Drawing.Size(23, 12);
            this.labelOrbitType.TabIndex = 63;
            this.labelOrbitType.Text = "N/A";
            // 
            // labelFullName
            // 
            this.labelFullName.AutoSize = true;
            this.labelFullName.Location = new System.Drawing.Point(88, 33);
            this.labelFullName.Name = "labelFullName";
            this.labelFullName.Size = new System.Drawing.Size(23, 12);
            this.labelFullName.TabIndex = 62;
            this.labelFullName.Text = "N/A";
            // 
            // labelShortName
            // 
            this.labelShortName.AutoSize = true;
            this.labelShortName.Location = new System.Drawing.Point(88, 8);
            this.labelShortName.Name = "labelShortName";
            this.labelShortName.Size = new System.Drawing.Size(23, 12);
            this.labelShortName.TabIndex = 61;
            this.labelShortName.Text = "N/A";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 289);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 60;
            this.label10.Text = "载荷：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 83);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 59;
            this.label9.Text = "重返周期：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 208);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 58;
            this.label8.Text = "描述信息：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 183);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 57;
            this.label7.Text = "发射时间：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 56;
            this.label6.Text = "应用类型：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 55;
            this.label5.Text = "所属机构：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 54;
            this.label4.Text = "所属国家：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 53;
            this.label3.Text = "轨道类型：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 52;
            this.label2.Text = "卫星全名：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 51;
            this.label1.Text = "卫星简称：";
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(692, 719);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 76;
            this.buttonClose.Text = "关闭";
            this.buttonClose.UseVisualStyleBackColor = true;
            // 
            // SatelliteDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 750);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.sensorDescription);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dataGridViewBand);
            this.Controls.Add(this.dataGridViewSensor);
            this.Controls.Add(this.satPicture);
            this.Controls.Add(this.satDescription);
            this.Controls.Add(this.label1LaunchTime);
            this.Controls.Add(this.labelApplication);
            this.Controls.Add(this.labelAgency);
            this.Controls.Add(this.labelCountry);
            this.Controls.Add(this.labelRepeatCycle);
            this.Controls.Add(this.labelOrbitType);
            this.Controls.Add(this.labelFullName);
            this.Controls.Add(this.labelShortName);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SatelliteDetail";
            this.Text = "详情";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSensor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.satPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox sensorDescription;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dataGridViewBand;
        private System.Windows.Forms.DataGridViewTextBoxColumn BAND_MODE_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn SWATHWIDTH;
        private System.Windows.Forms.DataGridViewTextBoxColumn BAND_TYPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn SPECTRALRANGEMIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn SPECTRALRANGEMAX;
        private System.Windows.Forms.DataGridViewTextBoxColumn SPECTRALCENTER;
        private System.Windows.Forms.DataGridViewTextBoxColumn POLARIZATION_MODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn ACROSSRESOLUTION;
        private System.Windows.Forms.DataGridView dataGridViewSensor;
        private System.Windows.Forms.DataGridViewTextBoxColumn SENSOR_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SENSOR_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn SENSOR_TYPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn APPLICATION;
        private System.Windows.Forms.DataGridViewTextBoxColumn NUMOFBANDS;
        private System.Windows.Forms.DataGridViewTextBoxColumn BANDCATEGORIES;
        private System.Windows.Forms.DataGridViewTextBoxColumn REVISITTIME;
        private System.Windows.Forms.PictureBox satPicture;
        private System.Windows.Forms.TextBox satDescription;
        private System.Windows.Forms.Label label1LaunchTime;
        private System.Windows.Forms.Label labelApplication;
        private System.Windows.Forms.Label labelAgency;
        private System.Windows.Forms.Label labelCountry;
        private System.Windows.Forms.Label labelRepeatCycle;
        private System.Windows.Forms.Label labelOrbitType;
        private System.Windows.Forms.Label labelFullName;
        private System.Windows.Forms.Label labelShortName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
    }
}