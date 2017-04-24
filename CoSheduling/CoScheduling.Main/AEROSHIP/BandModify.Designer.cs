namespace CoScheduling.Main.AEROSHIP
{
    partial class BandModify
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
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.ButtonModify = new System.Windows.Forms.Button();
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
            this.txtAEROSHIPID = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Location = new System.Drawing.Point(306, 245);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 115;
            this.ButtonCancel.Text = "取消";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // ButtonModify
            // 
            this.ButtonModify.Location = new System.Drawing.Point(198, 245);
            this.ButtonModify.Name = "ButtonModify";
            this.ButtonModify.Size = new System.Drawing.Size(75, 23);
            this.ButtonModify.TabIndex = 114;
            this.ButtonModify.Text = "修改";
            this.ButtonModify.UseVisualStyleBackColor = true;
            this.ButtonModify.Click += new System.EventHandler(this.ButtonModify_Click);
            // 
            // txtSNR
            // 
            this.txtSNR.Location = new System.Drawing.Point(410, 209);
            this.txtSNR.Name = "txtSNR";
            this.txtSNR.Size = new System.Drawing.Size(123, 21);
            this.txtSNR.TabIndex = 113;
            // 
            // txtGeometryResolution
            // 
            this.txtGeometryResolution.Location = new System.Drawing.Point(412, 176);
            this.txtGeometryResolution.Name = "txtGeometryResolution";
            this.txtGeometryResolution.Size = new System.Drawing.Size(121, 21);
            this.txtGeometryResolution.TabIndex = 112;
            // 
            // txtDistanceResolution
            // 
            this.txtDistanceResolution.Location = new System.Drawing.Point(412, 135);
            this.txtDistanceResolution.Name = "txtDistanceResolution";
            this.txtDistanceResolution.Size = new System.Drawing.Size(121, 21);
            this.txtDistanceResolution.TabIndex = 111;
            // 
            // txtAzimuResolution
            // 
            this.txtAzimuResolution.Location = new System.Drawing.Point(412, 93);
            this.txtAzimuResolution.Name = "txtAzimuResolution";
            this.txtAzimuResolution.Size = new System.Drawing.Size(121, 21);
            this.txtAzimuResolution.TabIndex = 110;
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
            this.comboBoxPolar.Location = new System.Drawing.Point(412, 56);
            this.comboBoxPolar.Name = "comboBoxPolar";
            this.comboBoxPolar.Size = new System.Drawing.Size(121, 20);
            this.comboBoxPolar.TabIndex = 109;
            // 
            // txtBandWidth
            // 
            this.txtBandWidth.Location = new System.Drawing.Point(130, 206);
            this.txtBandWidth.Name = "txtBandWidth";
            this.txtBandWidth.Size = new System.Drawing.Size(143, 21);
            this.txtBandWidth.TabIndex = 108;
            // 
            // txtBandCenter
            // 
            this.txtBandCenter.Location = new System.Drawing.Point(130, 172);
            this.txtBandCenter.Name = "txtBandCenter";
            this.txtBandCenter.Size = new System.Drawing.Size(143, 21);
            this.txtBandCenter.TabIndex = 107;
            // 
            // txtSpeMax
            // 
            this.txtSpeMax.Location = new System.Drawing.Point(213, 132);
            this.txtSpeMax.Name = "txtSpeMax";
            this.txtSpeMax.Size = new System.Drawing.Size(60, 21);
            this.txtSpeMax.TabIndex = 106;
            // 
            // txtSpeMin
            // 
            this.txtSpeMin.Location = new System.Drawing.Point(130, 132);
            this.txtSpeMin.Name = "txtSpeMin";
            this.txtSpeMin.Size = new System.Drawing.Size(60, 21);
            this.txtSpeMin.TabIndex = 105;
            // 
            // comboBoxBandType
            // 
            this.comboBoxBandType.FormattingEnabled = true;
            this.comboBoxBandType.Location = new System.Drawing.Point(130, 93);
            this.comboBoxBandType.Name = "comboBoxBandType";
            this.comboBoxBandType.Size = new System.Drawing.Size(143, 20);
            this.comboBoxBandType.TabIndex = 104;
            // 
            // txtBandSwathWidth
            // 
            this.txtBandSwathWidth.Location = new System.Drawing.Point(130, 56);
            this.txtBandSwathWidth.Name = "txtBandSwathWidth";
            this.txtBandSwathWidth.Size = new System.Drawing.Size(143, 21);
            this.txtBandSwathWidth.TabIndex = 103;
            // 
            // txtBandID
            // 
            this.txtBandID.Location = new System.Drawing.Point(347, 19);
            this.txtBandID.Name = "txtBandID";
            this.txtBandID.Size = new System.Drawing.Size(150, 21);
            this.txtBandID.TabIndex = 102;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(252, 22);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 12);
            this.label13.TabIndex = 101;
            this.label13.Text = "波段模式ID：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(304, 213);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 100;
            this.label12.Text = "信噪比：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(304, 176);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 12);
            this.label11.TabIndex = 99;
            this.label11.Text = "空间分辨率：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(304, 135);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 12);
            this.label10.TabIndex = 98;
            this.label10.Text = "距离分辨率：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(304, 96);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 97;
            this.label9.Text = "方位分辨率：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(304, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 96;
            this.label7.Text = "极化方式：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 209);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 95;
            this.label6.Text = "频谱宽度：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 94;
            this.label5.Text = "频谱中心：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 93;
            this.label4.Text = "频谱范围：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 92;
            this.label3.Text = "波段类型：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 91;
            this.label1.Text = "幅宽：";
            // 
            // txtSensorID
            // 
            this.txtSensorID.AutoSize = true;
            this.txtSensorID.Location = new System.Drawing.Point(137, 22);
            this.txtSensorID.Name = "txtSensorID";
            this.txtSensorID.Size = new System.Drawing.Size(53, 12);
            this.txtSensorID.TabIndex = 90;
            this.txtSensorID.Text = "载荷ID：";
            // 
            // txtAEROSHIPID
            // 
            this.txtAEROSHIPID.AutoSize = true;
            this.txtAEROSHIPID.Location = new System.Drawing.Point(21, 22);
            this.txtAEROSHIPID.Name = "txtAEROSHIPID";
            this.txtAEROSHIPID.Size = new System.Drawing.Size(59, 12);
            this.txtAEROSHIPID.TabIndex = 89;
            this.txtAEROSHIPID.Text = "飞艇ID ：";
            // 
            // BandModify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 279);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonModify);
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
            this.Controls.Add(this.txtAEROSHIPID);
            this.Name = "BandModify";
            this.Text = "波段修改";
            this.Load += new System.EventHandler(this.BandModify_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Button ButtonModify;
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
        private System.Windows.Forms.Label txtAEROSHIPID;
    }
}