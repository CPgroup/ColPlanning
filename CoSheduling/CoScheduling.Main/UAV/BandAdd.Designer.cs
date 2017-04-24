namespace CoScheduling.Main.UAV
{
    partial class BandAdd
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
            this.ButtonReset = new System.Windows.Forms.Button();
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.txtSNR = new System.Windows.Forms.TextBox();
            this.txtGeometryResolution = new System.Windows.Forms.TextBox();
            this.txtDistanceResolution = new System.Windows.Forms.TextBox();
            this.txtAzimuResolution = new System.Windows.Forms.TextBox();
            this.comboBoxPolar = new System.Windows.Forms.ComboBox();
            this.txtBandWidth = new System.Windows.Forms.TextBox();
            this.txtBandCenter = new System.Windows.Forms.TextBox();
            this.txtSpeMax = new System.Windows.Forms.TextBox();
            this.txtSpeMin = new System.Windows.Forms.TextBox();
            this.comboBoxBandType = new System.Windows.Forms.ComboBox();
            this.txtBandSwathWidth = new System.Windows.Forms.TextBox();
            this.txtBandID = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSensorID = new System.Windows.Forms.Label();
            this.txtUAVID = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ButtonReset
            // 
            this.ButtonReset.Location = new System.Drawing.Point(306, 243);
            this.ButtonReset.Name = "ButtonReset";
            this.ButtonReset.Size = new System.Drawing.Size(75, 23);
            this.ButtonReset.TabIndex = 61;
            this.ButtonReset.Text = "重置";
            this.ButtonReset.UseVisualStyleBackColor = true;
            this.ButtonReset.Click += new System.EventHandler(this.ButtonReset_Click);
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.Location = new System.Drawing.Point(198, 243);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(75, 23);
            this.ButtonAdd.TabIndex = 60;
            this.ButtonAdd.Text = "添加";
            this.ButtonAdd.UseVisualStyleBackColor = true;
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // txtSNR
            // 
            this.txtSNR.Location = new System.Drawing.Point(410, 207);
            this.txtSNR.Name = "txtSNR";
            this.txtSNR.Size = new System.Drawing.Size(123, 21);
            this.txtSNR.TabIndex = 59;
            // 
            // txtGeometryResolution
            // 
            this.txtGeometryResolution.Location = new System.Drawing.Point(412, 174);
            this.txtGeometryResolution.Name = "txtGeometryResolution";
            this.txtGeometryResolution.Size = new System.Drawing.Size(121, 21);
            this.txtGeometryResolution.TabIndex = 58;
            // 
            // txtDistanceResolution
            // 
            this.txtDistanceResolution.Location = new System.Drawing.Point(412, 133);
            this.txtDistanceResolution.Name = "txtDistanceResolution";
            this.txtDistanceResolution.Size = new System.Drawing.Size(121, 21);
            this.txtDistanceResolution.TabIndex = 57;
            // 
            // txtAzimuResolution
            // 
            this.txtAzimuResolution.Location = new System.Drawing.Point(412, 91);
            this.txtAzimuResolution.Name = "txtAzimuResolution";
            this.txtAzimuResolution.Size = new System.Drawing.Size(121, 21);
            this.txtAzimuResolution.TabIndex = 56;
            // 
            // comboBoxPolar
            // 
            this.comboBoxPolar.FormattingEnabled = true;
            this.comboBoxPolar.Items.AddRange(new object[] {
            "V",
            "H",
            "VV",
            "HH",
            "HV",
            "VH",
            "V,H",
            "HH,VV",
            "HH,HV,VH,VV",
            "V,H,HH+HV+VH+VV",
            "HH,HV,VH,VV,HH+HV,VV+VH,V,H",
            "TBD"});
            this.comboBoxPolar.Location = new System.Drawing.Point(412, 54);
            this.comboBoxPolar.Name = "comboBoxPolar";
            this.comboBoxPolar.Size = new System.Drawing.Size(121, 20);
            this.comboBoxPolar.TabIndex = 54;
            // 
            // txtBandWidth
            // 
            this.txtBandWidth.Location = new System.Drawing.Point(130, 204);
            this.txtBandWidth.Name = "txtBandWidth";
            this.txtBandWidth.Size = new System.Drawing.Size(143, 21);
            this.txtBandWidth.TabIndex = 53;
            // 
            // txtBandCenter
            // 
            this.txtBandCenter.Location = new System.Drawing.Point(130, 170);
            this.txtBandCenter.Name = "txtBandCenter";
            this.txtBandCenter.Size = new System.Drawing.Size(143, 21);
            this.txtBandCenter.TabIndex = 52;
            // 
            // txtSpeMax
            // 
            this.txtSpeMax.Location = new System.Drawing.Point(213, 130);
            this.txtSpeMax.Name = "txtSpeMax";
            this.txtSpeMax.Size = new System.Drawing.Size(60, 21);
            this.txtSpeMax.TabIndex = 51;
            // 
            // txtSpeMin
            // 
            this.txtSpeMin.Location = new System.Drawing.Point(130, 130);
            this.txtSpeMin.Name = "txtSpeMin";
            this.txtSpeMin.Size = new System.Drawing.Size(60, 21);
            this.txtSpeMin.TabIndex = 50;
            // 
            // comboBoxBandType
            // 
            this.comboBoxBandType.FormattingEnabled = true;
            this.comboBoxBandType.Location = new System.Drawing.Point(130, 91);
            this.comboBoxBandType.Name = "comboBoxBandType";
            this.comboBoxBandType.Size = new System.Drawing.Size(143, 20);
            this.comboBoxBandType.TabIndex = 49;
            // 
            // txtBandSwathWidth
            // 
            this.txtBandSwathWidth.Location = new System.Drawing.Point(130, 54);
            this.txtBandSwathWidth.Name = "txtBandSwathWidth";
            this.txtBandSwathWidth.Size = new System.Drawing.Size(143, 21);
            this.txtBandSwathWidth.TabIndex = 47;
            // 
            // txtBandID
            // 
            this.txtBandID.Location = new System.Drawing.Point(347, 17);
            this.txtBandID.Name = "txtBandID";
            this.txtBandID.Size = new System.Drawing.Size(150, 21);
            this.txtBandID.TabIndex = 46;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(252, 20);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 12);
            this.label13.TabIndex = 45;
            this.label13.Text = "波段模式ID：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(304, 211);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 44;
            this.label12.Text = "信噪比：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(304, 174);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 12);
            this.label11.TabIndex = 43;
            this.label11.Text = "空间分辨率：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(304, 133);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 12);
            this.label10.TabIndex = 42;
            this.label10.Text = "距离分辨率：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(304, 94);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 41;
            this.label9.Text = "方位分辨率：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(304, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 39;
            this.label7.Text = "极化方式：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 207);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 38;
            this.label6.Text = "频谱宽度：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 37;
            this.label5.Text = "频谱中心：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 36;
            this.label4.Text = "频谱范围：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 35;
            this.label3.Text = "波段类型：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 33;
            this.label1.Text = "幅宽：";
            // 
            // txtSensorID
            // 
            this.txtSensorID.AutoSize = true;
            this.txtSensorID.Location = new System.Drawing.Point(137, 20);
            this.txtSensorID.Name = "txtSensorID";
            this.txtSensorID.Size = new System.Drawing.Size(53, 12);
            this.txtSensorID.TabIndex = 32;
            this.txtSensorID.Text = "载荷ID：";
            // 
            // txtUAVID
            // 
            this.txtUAVID.AutoSize = true;
            this.txtUAVID.Location = new System.Drawing.Point(21, 20);
            this.txtUAVID.Name = "txtUAVID";
            this.txtUAVID.Size = new System.Drawing.Size(71, 12);
            this.txtUAVID.TabIndex = 31;
            this.txtUAVID.Text = "无人机ID ：";
            // 
            // BandAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 297);
            this.Controls.Add(this.ButtonReset);
            this.Controls.Add(this.ButtonAdd);
            this.Controls.Add(this.txtSNR);
            this.Controls.Add(this.txtGeometryResolution);
            this.Controls.Add(this.txtDistanceResolution);
            this.Controls.Add(this.txtAzimuResolution);
            this.Controls.Add(this.comboBoxPolar);
            this.Controls.Add(this.txtBandWidth);
            this.Controls.Add(this.txtBandCenter);
            this.Controls.Add(this.txtSpeMax);
            this.Controls.Add(this.txtSpeMin);
            this.Controls.Add(this.comboBoxBandType);
            this.Controls.Add(this.txtBandSwathWidth);
            this.Controls.Add(this.txtBandID);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSensorID);
            this.Controls.Add(this.txtUAVID);
            this.Name = "BandAdd";
            this.Text = "添加一个波段";
            this.Load += new System.EventHandler(this.BandAdd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonReset;
        private System.Windows.Forms.Button ButtonAdd;
        private System.Windows.Forms.TextBox txtSNR;
        private System.Windows.Forms.TextBox txtGeometryResolution;
        private System.Windows.Forms.TextBox txtDistanceResolution;
        private System.Windows.Forms.TextBox txtAzimuResolution;
        private System.Windows.Forms.ComboBox comboBoxPolar;
        private System.Windows.Forms.TextBox txtBandWidth;
        private System.Windows.Forms.TextBox txtBandCenter;
        private System.Windows.Forms.TextBox txtSpeMax;
        private System.Windows.Forms.TextBox txtSpeMin;
        private System.Windows.Forms.ComboBox comboBoxBandType;
        private System.Windows.Forms.TextBox txtBandSwathWidth;
        private System.Windows.Forms.TextBox txtBandID;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtSensorID;
        private System.Windows.Forms.Label txtUAVID;
    }
}