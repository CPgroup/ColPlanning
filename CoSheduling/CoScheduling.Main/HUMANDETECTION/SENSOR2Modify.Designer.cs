namespace CoScheduling.Main.HUMANDETECTION
{
    partial class SENSOR2Modify
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
            this.comboBoxPLATFORM = new System.Windows.Forms.ComboBox();
            this.ButtonReturn = new System.Windows.Forms.Button();
            this.ButtonModify = new System.Windows.Forms.Button();
            this.txtFocalLength = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHorizontalResolution = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxSensorApplication = new System.Windows.Forms.ComboBox();
            this.comboBoxSensorType = new System.Windows.Forms.ComboBox();
            this.txtSquintAngle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPixel = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAperture = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.扫射速度 = new System.Windows.Forms.Label();
            this.txtMaxDistance = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtResolution = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtMinIllumination = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtLookAngle = new System.Windows.Forms.TextBox();
            this.txtSensorName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxPLATFORM
            // 
            this.comboBoxPLATFORM.FormattingEnabled = true;
            this.comboBoxPLATFORM.Location = new System.Drawing.Point(108, 23);
            this.comboBoxPLATFORM.Name = "comboBoxPLATFORM";
            this.comboBoxPLATFORM.Size = new System.Drawing.Size(153, 20);
            this.comboBoxPLATFORM.TabIndex = 427;
            // 
            // ButtonReturn
            // 
            this.ButtonReturn.Location = new System.Drawing.Point(426, 283);
            this.ButtonReturn.Name = "ButtonReturn";
            this.ButtonReturn.Size = new System.Drawing.Size(75, 23);
            this.ButtonReturn.TabIndex = 426;
            this.ButtonReturn.Text = "返回";
            this.ButtonReturn.UseVisualStyleBackColor = true;
            // 
            // ButtonModify
            // 
            this.ButtonModify.Location = new System.Drawing.Point(311, 283);
            this.ButtonModify.Name = "ButtonModify";
            this.ButtonModify.Size = new System.Drawing.Size(75, 23);
            this.ButtonModify.TabIndex = 425;
            this.ButtonModify.Text = "修改";
            this.ButtonModify.UseVisualStyleBackColor = true;
            this.ButtonModify.Click += new System.EventHandler(this.ButtonModify_Click);
            // 
            // txtFocalLength
            // 
            this.txtFocalLength.Location = new System.Drawing.Point(373, 244);
            this.txtFocalLength.Name = "txtFocalLength";
            this.txtFocalLength.Size = new System.Drawing.Size(154, 21);
            this.txtFocalLength.TabIndex = 424;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(291, 249);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 423;
            this.label1.Text = "焦距：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 288);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 422;
            this.label2.Text = "水平分辨率：";
            // 
            // txtHorizontalResolution
            // 
            this.txtHorizontalResolution.Location = new System.Drawing.Point(109, 285);
            this.txtHorizontalResolution.Name = "txtHorizontalResolution";
            this.txtHorizontalResolution.Size = new System.Drawing.Size(154, 21);
            this.txtHorizontalResolution.TabIndex = 421;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 420;
            this.label7.Text = "所属平台：";
            // 
            // comboBoxSensorApplication
            // 
            this.comboBoxSensorApplication.FormattingEnabled = true;
            this.comboBoxSensorApplication.Items.AddRange(new object[] {
            "Atmospheric chemistry instruments",
            "Atmospheric temperature and humidity sounders",
            "Cloud profile and rain radars",
            "Earth radiation budget radiometers",
            "High-resolution optical imagers",
            "Imaging multi-spectral radiometers (visible/infrared)",
            "Imaging multi-spectral radiometers (passive microwave)",
            "Imaging microwave radars",
            "Lidars",
            "Lightning instruments",
            "Multiple direction/polarisation instruments",
            "Ocean colour instruments",
            "Radar altimeters",
            "Scatterometers",
            "Gravity, magnetic field and geodynamic "});
            this.comboBoxSensorApplication.Location = new System.Drawing.Point(109, 153);
            this.comboBoxSensorApplication.Name = "comboBoxSensorApplication";
            this.comboBoxSensorApplication.Size = new System.Drawing.Size(155, 20);
            this.comboBoxSensorApplication.TabIndex = 419;
            // 
            // comboBoxSensorType
            // 
            this.comboBoxSensorType.FormattingEnabled = true;
            this.comboBoxSensorType.Location = new System.Drawing.Point(109, 108);
            this.comboBoxSensorType.Name = "comboBoxSensorType";
            this.comboBoxSensorType.Size = new System.Drawing.Size(154, 20);
            this.comboBoxSensorType.TabIndex = 418;
            // 
            // txtSquintAngle
            // 
            this.txtSquintAngle.Location = new System.Drawing.Point(373, 114);
            this.txtSquintAngle.Name = "txtSquintAngle";
            this.txtSquintAngle.Size = new System.Drawing.Size(154, 21);
            this.txtSquintAngle.TabIndex = 413;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(291, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 414;
            this.label3.Text = "斜视角：";
            // 
            // txtPixel
            // 
            this.txtPixel.Location = new System.Drawing.Point(110, 201);
            this.txtPixel.Name = "txtPixel";
            this.txtPixel.Size = new System.Drawing.Size(154, 21);
            this.txtPixel.TabIndex = 417;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 416;
            this.label5.Text = "像素：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 415;
            this.label6.Text = "应用方面：";
            // 
            // txtAperture
            // 
            this.txtAperture.Location = new System.Drawing.Point(373, 199);
            this.txtAperture.Name = "txtAperture";
            this.txtAperture.Size = new System.Drawing.Size(154, 21);
            this.txtAperture.TabIndex = 412;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(291, 204);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(41, 12);
            this.label16.TabIndex = 411;
            this.label16.Text = "光圈：";
            // 
            // 扫射速度
            // 
            this.扫射速度.AutoSize = true;
            this.扫射速度.Location = new System.Drawing.Point(291, 162);
            this.扫射速度.Name = "扫射速度";
            this.扫射速度.Size = new System.Drawing.Size(59, 12);
            this.扫射速度.TabIndex = 410;
            this.扫射速度.Text = "最大距离:";
            // 
            // txtMaxDistance
            // 
            this.txtMaxDistance.Location = new System.Drawing.Point(373, 159);
            this.txtMaxDistance.Name = "txtMaxDistance";
            this.txtMaxDistance.Size = new System.Drawing.Size(154, 21);
            this.txtMaxDistance.TabIndex = 409;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(26, 249);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 12);
            this.label14.TabIndex = 405;
            this.label14.Text = "空间分辨率：";
            // 
            // txtResolution
            // 
            this.txtResolution.Location = new System.Drawing.Point(109, 246);
            this.txtResolution.Name = "txtResolution";
            this.txtResolution.Size = new System.Drawing.Size(154, 21);
            this.txtResolution.TabIndex = 402;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(291, 74);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 404;
            this.label13.Text = "视场角：";
            // 
            // txtMinIllumination
            // 
            this.txtMinIllumination.Location = new System.Drawing.Point(373, 22);
            this.txtMinIllumination.Name = "txtMinIllumination";
            this.txtMinIllumination.Size = new System.Drawing.Size(154, 21);
            this.txtMinIllumination.TabIndex = 400;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(291, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 403;
            this.label12.Text = "最小光照：";
            // 
            // txtLookAngle
            // 
            this.txtLookAngle.Location = new System.Drawing.Point(373, 71);
            this.txtLookAngle.Name = "txtLookAngle";
            this.txtLookAngle.Size = new System.Drawing.Size(154, 21);
            this.txtLookAngle.TabIndex = 401;
            // 
            // txtSensorName
            // 
            this.txtSensorName.Location = new System.Drawing.Point(108, 62);
            this.txtSensorName.Name = "txtSensorName";
            this.txtSensorName.Size = new System.Drawing.Size(154, 21);
            this.txtSensorName.TabIndex = 408;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(25, 111);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 12);
            this.label11.TabIndex = 407;
            this.label11.Text = "传感器类型：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 406;
            this.label4.Text = "传感器名称：";
            // 
            // SENSOR2Modify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 338);
            this.Controls.Add(this.comboBoxPLATFORM);
            this.Controls.Add(this.ButtonReturn);
            this.Controls.Add(this.ButtonModify);
            this.Controls.Add(this.txtFocalLength);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtHorizontalResolution);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBoxSensorApplication);
            this.Controls.Add(this.comboBoxSensorType);
            this.Controls.Add(this.txtSquintAngle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPixel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtAperture);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.扫射速度);
            this.Controls.Add(this.txtMaxDistance);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtResolution);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtMinIllumination);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtLookAngle);
            this.Controls.Add(this.txtSensorName);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label4);
            this.Name = "SENSOR2Modify";
            this.Text = "SENSOR2Modify";
            this.Load += new System.EventHandler(this.SENSOR2Modify_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxPLATFORM;
        private System.Windows.Forms.Button ButtonReturn;
        private System.Windows.Forms.Button ButtonModify;
        private System.Windows.Forms.TextBox txtFocalLength;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHorizontalResolution;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxSensorApplication;
        private System.Windows.Forms.ComboBox comboBoxSensorType;
        private System.Windows.Forms.TextBox txtSquintAngle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPixel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAperture;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label 扫射速度;
        private System.Windows.Forms.TextBox txtMaxDistance;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtResolution;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtMinIllumination;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtLookAngle;
        private System.Windows.Forms.TextBox txtSensorName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label4;
    }
}