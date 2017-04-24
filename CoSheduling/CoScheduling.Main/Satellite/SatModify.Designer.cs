namespace CoScheduling.Main.Satellite
{
    partial class SatModify
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
            this.comboBoxSatCharter = new System.Windows.Forms.ComboBox();
            this.txtSatCountry = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtPeriod = new System.Windows.Forms.TextBox();
            this.txtApogee = new System.Windows.Forms.TextBox();
            this.txtPerigee = new System.Windows.Forms.TextBox();
            this.txtLonGEO = new System.Windows.Forms.TextBox();
            this.comboBoxOrbitClass = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.dateTimePickerEndTime = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerLaunchTime = new System.Windows.Forms.DateTimePicker();
            this.txtMinSlewAngle = new System.Windows.Forms.TextBox();
            this.txtAngleAcceleration = new System.Windows.Forms.TextBox();
            this.txtAngleVelocity = new System.Windows.Forms.TextBox();
            this.txtMaxSlewAngle = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.ButtonReturn = new System.Windows.Forms.Button();
            this.txtPlatformName = new System.Windows.Forms.TextBox();
            this.ButtonModify = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtNumberOfSensor = new System.Windows.Forms.TextBox();
            this.txtPlatformID = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxOrbitType = new System.Windows.Forms.ComboBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxSatCharter
            // 
            this.comboBoxSatCharter.FormattingEnabled = true;
            this.comboBoxSatCharter.Items.AddRange(new object[] {
            "是",
            "否"});
            this.comboBoxSatCharter.Location = new System.Drawing.Point(356, 312);
            this.comboBoxSatCharter.Name = "comboBoxSatCharter";
            this.comboBoxSatCharter.Size = new System.Drawing.Size(154, 20);
            this.comboBoxSatCharter.TabIndex = 254;
            // 
            // txtSatCountry
            // 
            this.txtSatCountry.Location = new System.Drawing.Point(356, 273);
            this.txtSatCountry.Name = "txtSatCountry";
            this.txtSatCountry.Size = new System.Drawing.Size(154, 21);
            this.txtSatCountry.TabIndex = 253;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(275, 317);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 12);
            this.label15.TabIndex = 252;
            this.label15.Text = "宪章成员：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(275, 278);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 251;
            this.label3.Text = "所属国家：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBoxOrbitType);
            this.groupBox2.Controls.Add(this.txtPeriod);
            this.groupBox2.Controls.Add(this.txtApogee);
            this.groupBox2.Controls.Add(this.txtPerigee);
            this.groupBox2.Controls.Add(this.txtLonGEO);
            this.groupBox2.Controls.Add(this.comboBoxOrbitClass);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Location = new System.Drawing.Point(269, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(269, 227);
            this.groupBox2.TabIndex = 250;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "轨道信息";
            // 
            // txtPeriod
            // 
            this.txtPeriod.Location = new System.Drawing.Point(132, 195);
            this.txtPeriod.Name = "txtPeriod";
            this.txtPeriod.Size = new System.Drawing.Size(113, 21);
            this.txtPeriod.TabIndex = 11;
            this.txtPeriod.Text = "-1";
            // 
            // txtApogee
            // 
            this.txtApogee.Location = new System.Drawing.Point(132, 160);
            this.txtApogee.Name = "txtApogee";
            this.txtApogee.Size = new System.Drawing.Size(113, 21);
            this.txtApogee.TabIndex = 10;
            // 
            // txtPerigee
            // 
            this.txtPerigee.Location = new System.Drawing.Point(132, 125);
            this.txtPerigee.Name = "txtPerigee";
            this.txtPerigee.Size = new System.Drawing.Size(113, 21);
            this.txtPerigee.TabIndex = 9;
            // 
            // txtLonGEO
            // 
            this.txtLonGEO.Location = new System.Drawing.Point(132, 90);
            this.txtLonGEO.Name = "txtLonGEO";
            this.txtLonGEO.Size = new System.Drawing.Size(113, 21);
            this.txtLonGEO.TabIndex = 8;
            this.txtLonGEO.Text = "-1";
            // 
            // comboBoxOrbitClass
            // 
            this.comboBoxOrbitClass.FormattingEnabled = true;
            this.comboBoxOrbitClass.Items.AddRange(new object[] {
            "LEO",
            "MEO",
            "GEO"});
            this.comboBoxOrbitClass.Location = new System.Drawing.Point(132, 20);
            this.comboBoxOrbitClass.Name = "comboBoxOrbitClass";
            this.comboBoxOrbitClass.Size = new System.Drawing.Size(113, 20);
            this.comboBoxOrbitClass.TabIndex = 6;
            this.comboBoxOrbitClass.SelectedIndexChanged += new System.EventHandler(this.comboBoxOrbitClass_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 200);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 5;
            this.label10.Text = "回归周期：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 165);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 4;
            this.label9.Text = "远地点高度：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "近地点高度：";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 95);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 12);
            this.label13.TabIndex = 2;
            this.label13.Text = "轨道经度：";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(10, 60);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(113, 12);
            this.label14.TabIndex = 1;
            this.label14.Text = "轨道类型（综合）：";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(10, 25);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(113, 12);
            this.label16.TabIndex = 0;
            this.label16.Text = "轨道类型（高度）：";
            // 
            // dateTimePickerEndTime
            // 
            this.dateTimePickerEndTime.Location = new System.Drawing.Point(97, 150);
            this.dateTimePickerEndTime.Name = "dateTimePickerEndTime";
            this.dateTimePickerEndTime.Size = new System.Drawing.Size(154, 21);
            this.dateTimePickerEndTime.TabIndex = 249;
            // 
            // dateTimePickerLaunchTime
            // 
            this.dateTimePickerLaunchTime.Location = new System.Drawing.Point(97, 115);
            this.dateTimePickerLaunchTime.Name = "dateTimePickerLaunchTime";
            this.dateTimePickerLaunchTime.Size = new System.Drawing.Size(154, 21);
            this.dateTimePickerLaunchTime.TabIndex = 248;
            // 
            // txtMinSlewAngle
            // 
            this.txtMinSlewAngle.Location = new System.Drawing.Point(97, 190);
            this.txtMinSlewAngle.Name = "txtMinSlewAngle";
            this.txtMinSlewAngle.Size = new System.Drawing.Size(154, 21);
            this.txtMinSlewAngle.TabIndex = 247;
            // 
            // txtAngleAcceleration
            // 
            this.txtAngleAcceleration.Location = new System.Drawing.Point(97, 312);
            this.txtAngleAcceleration.Name = "txtAngleAcceleration";
            this.txtAngleAcceleration.Size = new System.Drawing.Size(154, 21);
            this.txtAngleAcceleration.TabIndex = 246;
            // 
            // txtAngleVelocity
            // 
            this.txtAngleVelocity.Location = new System.Drawing.Point(97, 270);
            this.txtAngleVelocity.Name = "txtAngleVelocity";
            this.txtAngleVelocity.Size = new System.Drawing.Size(154, 21);
            this.txtAngleVelocity.TabIndex = 245;
            // 
            // txtMaxSlewAngle
            // 
            this.txtMaxSlewAngle.Location = new System.Drawing.Point(97, 229);
            this.txtMaxSlewAngle.Name = "txtMaxSlewAngle";
            this.txtMaxSlewAngle.Size = new System.Drawing.Size(154, 21);
            this.txtMaxSlewAngle.TabIndex = 244;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(15, 315);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(65, 12);
            this.label17.TabIndex = 243;
            this.label17.Text = "角加速度：";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(15, 279);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(53, 12);
            this.label18.TabIndex = 242;
            this.label18.Text = "角速度：";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(15, 198);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(65, 12);
            this.label19.TabIndex = 241;
            this.label19.Text = "最小摆角：";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(15, 232);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(65, 12);
            this.label20.TabIndex = 240;
            this.label20.Text = "最大摆角：";
            // 
            // ButtonReturn
            // 
            this.ButtonReturn.Location = new System.Drawing.Point(435, 347);
            this.ButtonReturn.Name = "ButtonReturn";
            this.ButtonReturn.Size = new System.Drawing.Size(75, 23);
            this.ButtonReturn.TabIndex = 239;
            this.ButtonReturn.Text = "返回";
            this.ButtonReturn.UseVisualStyleBackColor = true;
            this.ButtonReturn.Click += new System.EventHandler(this.ButtonReturn_Click);
            // 
            // txtPlatformName
            // 
            this.txtPlatformName.Location = new System.Drawing.Point(97, 45);
            this.txtPlatformName.Name = "txtPlatformName";
            this.txtPlatformName.Size = new System.Drawing.Size(154, 21);
            this.txtPlatformName.TabIndex = 237;
            // 
            // ButtonModify
            // 
            this.ButtonModify.Location = new System.Drawing.Point(272, 347);
            this.ButtonModify.Name = "ButtonModify";
            this.ButtonModify.Size = new System.Drawing.Size(75, 23);
            this.ButtonModify.TabIndex = 236;
            this.ButtonModify.Text = "修改";
            this.ButtonModify.UseVisualStyleBackColor = true;
            this.ButtonModify.Click += new System.EventHandler(this.ButtonModify_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 153);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 229;
            this.label12.Text = "预计结束：";
            // 
            // txtNumberOfSensor
            // 
            this.txtNumberOfSensor.Location = new System.Drawing.Point(97, 80);
            this.txtNumberOfSensor.Name = "txtNumberOfSensor";
            this.txtNumberOfSensor.Size = new System.Drawing.Size(154, 21);
            this.txtNumberOfSensor.TabIndex = 235;
            // 
            // txtPlatformID
            // 
            this.txtPlatformID.Location = new System.Drawing.Point(97, 12);
            this.txtPlatformID.Name = "txtPlatformID";
            this.txtPlatformID.Size = new System.Drawing.Size(154, 21);
            this.txtPlatformID.TabIndex = 234;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 118);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 233;
            this.label11.Text = "发射日期：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 232;
            this.label4.Text = "传感器数量：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 231;
            this.label2.Text = "平台名称：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 230;
            this.label1.Text = "平台编号：";
            // 
            // comboBoxOrbitType
            // 
            this.comboBoxOrbitType.FormattingEnabled = true;
            this.comboBoxOrbitType.Items.AddRange(new object[] {
            "Intermediate",
            "Polar",
            "Sun-Synchronous",
            "MEO",
            "GEO"});
            this.comboBoxOrbitType.Location = new System.Drawing.Point(132, 57);
            this.comboBoxOrbitType.Name = "comboBoxOrbitType";
            this.comboBoxOrbitType.Size = new System.Drawing.Size(113, 20);
            this.comboBoxOrbitType.TabIndex = 12;
            // 
            // SatModify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 384);
            this.Controls.Add(this.comboBoxSatCharter);
            this.Controls.Add(this.txtSatCountry);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dateTimePickerEndTime);
            this.Controls.Add(this.dateTimePickerLaunchTime);
            this.Controls.Add(this.txtMinSlewAngle);
            this.Controls.Add(this.txtAngleAcceleration);
            this.Controls.Add(this.txtAngleVelocity);
            this.Controls.Add(this.txtMaxSlewAngle);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.ButtonReturn);
            this.Controls.Add(this.txtPlatformName);
            this.Controls.Add(this.ButtonModify);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtNumberOfSensor);
            this.Controls.Add(this.txtPlatformID);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SatModify";
            this.Text = "卫星信息修改";
            this.Load += new System.EventHandler(this.SatModify_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxSatCharter;
        private System.Windows.Forms.TextBox txtSatCountry;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtPeriod;
        private System.Windows.Forms.TextBox txtApogee;
        private System.Windows.Forms.TextBox txtPerigee;
        private System.Windows.Forms.TextBox txtLonGEO;
        private System.Windows.Forms.ComboBox comboBoxOrbitClass;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker dateTimePickerEndTime;
        private System.Windows.Forms.DateTimePicker dateTimePickerLaunchTime;
        private System.Windows.Forms.TextBox txtMinSlewAngle;
        private System.Windows.Forms.TextBox txtAngleAcceleration;
        private System.Windows.Forms.TextBox txtAngleVelocity;
        private System.Windows.Forms.TextBox txtMaxSlewAngle;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button ButtonReturn;
        private System.Windows.Forms.TextBox txtPlatformName;
        private System.Windows.Forms.Button ButtonModify;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtNumberOfSensor;
        private System.Windows.Forms.TextBox txtPlatformID;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxOrbitType;
    }
}