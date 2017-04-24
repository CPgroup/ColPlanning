namespace CoScheduling.Main.UAV
{
    partial class BandQuery
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
            this.dataGridViewBand = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBandCount = new System.Windows.Forms.TextBox();
            this.ButtonReturn = new System.Windows.Forms.Button();
            this.ButtonReset = new System.Windows.Forms.Button();
            this.ButtonQuery = new System.Windows.Forms.Button();
            this.groupBox_QueryCondition = new System.Windows.Forms.GroupBox();
            this.comboBoxBandType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBandID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSensor1ID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBandName = new System.Windows.Forms.TextBox();
            this.txtPLATFORMID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBand)).BeginInit();
            this.groupBox_QueryCondition.SuspendLayout();
            this.SuspendLayout();
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
            this.dataGridViewBand.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewBand.Name = "dataGridViewBand";
            this.dataGridViewBand.RowHeadersWidth = 10;
            this.dataGridViewBand.RowTemplate.Height = 23;
            this.dataGridViewBand.Size = new System.Drawing.Size(455, 229);
            this.dataGridViewBand.TabIndex = 149;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "BandID";
            this.dataGridViewTextBoxColumn13.HeaderText = "波段ID";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.Width = 80;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "BAND_MODE_NAME";
            this.dataGridViewTextBoxColumn14.HeaderText = "波段名称";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.Width = 90;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "BandType";
            this.dataGridViewTextBoxColumn15.HeaderText = "波段类型";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.Width = 90;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "SensorID";
            this.dataGridViewTextBoxColumn16.HeaderText = "传感器ID";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.Width = 90;
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.DataPropertyName = "PLATFORM_ID";
            this.dataGridViewTextBoxColumn19.HeaderText = "平台ID";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.ToolTipText = "该时间为UTC时间";
            this.dataGridViewTextBoxColumn19.Width = 80;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(351, 303);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 173;
            this.label5.Text = "查询结果数量";
            // 
            // txtBandCount
            // 
            this.txtBandCount.Location = new System.Drawing.Point(343, 325);
            this.txtBandCount.Name = "txtBandCount";
            this.txtBandCount.ReadOnly = true;
            this.txtBandCount.Size = new System.Drawing.Size(96, 21);
            this.txtBandCount.TabIndex = 172;
            // 
            // ButtonReturn
            // 
            this.ButtonReturn.Location = new System.Drawing.Point(353, 438);
            this.ButtonReturn.Name = "ButtonReturn";
            this.ButtonReturn.Size = new System.Drawing.Size(75, 23);
            this.ButtonReturn.TabIndex = 171;
            this.ButtonReturn.Text = "返回";
            this.ButtonReturn.UseVisualStyleBackColor = true;
            // 
            // ButtonReset
            // 
            this.ButtonReset.Location = new System.Drawing.Point(353, 399);
            this.ButtonReset.Name = "ButtonReset";
            this.ButtonReset.Size = new System.Drawing.Size(75, 23);
            this.ButtonReset.TabIndex = 170;
            this.ButtonReset.Text = "重置";
            this.ButtonReset.UseVisualStyleBackColor = true;
            // 
            // ButtonQuery
            // 
            this.ButtonQuery.Location = new System.Drawing.Point(353, 265);
            this.ButtonQuery.Name = "ButtonQuery";
            this.ButtonQuery.Size = new System.Drawing.Size(75, 23);
            this.ButtonQuery.TabIndex = 169;
            this.ButtonQuery.Text = "查询";
            this.ButtonQuery.UseVisualStyleBackColor = true;
            this.ButtonQuery.Click += new System.EventHandler(this.ButtonQuery_Click);
            // 
            // groupBox_QueryCondition
            // 
            this.groupBox_QueryCondition.Controls.Add(this.comboBoxBandType);
            this.groupBox_QueryCondition.Controls.Add(this.label7);
            this.groupBox_QueryCondition.Controls.Add(this.txtBandID);
            this.groupBox_QueryCondition.Controls.Add(this.label6);
            this.groupBox_QueryCondition.Controls.Add(this.txtSensor1ID);
            this.groupBox_QueryCondition.Controls.Add(this.label4);
            this.groupBox_QueryCondition.Controls.Add(this.label1);
            this.groupBox_QueryCondition.Controls.Add(this.label3);
            this.groupBox_QueryCondition.Controls.Add(this.txtBandName);
            this.groupBox_QueryCondition.Controls.Add(this.txtPLATFORMID);
            this.groupBox_QueryCondition.Controls.Add(this.label2);
            this.groupBox_QueryCondition.Location = new System.Drawing.Point(12, 247);
            this.groupBox_QueryCondition.Name = "groupBox_QueryCondition";
            this.groupBox_QueryCondition.Size = new System.Drawing.Size(295, 218);
            this.groupBox_QueryCondition.TabIndex = 168;
            this.groupBox_QueryCondition.TabStop = false;
            this.groupBox_QueryCondition.Text = "查询条件";
            // 
            // comboBoxBandType
            // 
            this.comboBoxBandType.FormattingEnabled = true;
            this.comboBoxBandType.Location = new System.Drawing.Point(92, 100);
            this.comboBoxBandType.Name = "comboBoxBandType";
            this.comboBoxBandType.Size = new System.Drawing.Size(179, 20);
            this.comboBoxBandType.TabIndex = 269;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 159;
            this.label7.Text = "波段ID：";
            // 
            // txtBandID
            // 
            this.txtBandID.Location = new System.Drawing.Point(92, 20);
            this.txtBandID.Name = "txtBandID";
            this.txtBandID.Size = new System.Drawing.Size(179, 21);
            this.txtBandID.TabIndex = 158;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 157;
            this.label6.Text = "波段类型：";
            // 
            // txtSensor1ID
            // 
            this.txtSensor1ID.Location = new System.Drawing.Point(92, 141);
            this.txtSensor1ID.Name = "txtSensor1ID";
            this.txtSensor1ID.Size = new System.Drawing.Size(179, 21);
            this.txtSensor1ID.TabIndex = 149;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(133, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 155;
            this.label4.Text = "（模糊查询）";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 150;
            this.label1.Text = "传感器ID：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 154;
            this.label3.Text = "平台ID：";
            // 
            // txtBandName
            // 
            this.txtBandName.Location = new System.Drawing.Point(92, 59);
            this.txtBandName.Name = "txtBandName";
            this.txtBandName.Size = new System.Drawing.Size(179, 21);
            this.txtBandName.TabIndex = 151;
            // 
            // txtPLATFORMID
            // 
            this.txtPLATFORMID.Location = new System.Drawing.Point(92, 181);
            this.txtPLATFORMID.Name = "txtPLATFORMID";
            this.txtPLATFORMID.Size = new System.Drawing.Size(179, 21);
            this.txtPLATFORMID.TabIndex = 153;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 152;
            this.label2.Text = "波段名称：";
            // 
            // BandQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 477);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBandCount);
            this.Controls.Add(this.ButtonReturn);
            this.Controls.Add(this.ButtonReset);
            this.Controls.Add(this.ButtonQuery);
            this.Controls.Add(this.groupBox_QueryCondition);
            this.Controls.Add(this.dataGridViewBand);
            this.Name = "BandQuery";
            this.Text = "BandQuery";
            this.Load += new System.EventHandler(this.BandQuery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBand)).EndInit();
            this.groupBox_QueryCondition.ResumeLayout(false);
            this.groupBox_QueryCondition.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewBand;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBandCount;
        private System.Windows.Forms.Button ButtonReturn;
        private System.Windows.Forms.Button ButtonReset;
        private System.Windows.Forms.Button ButtonQuery;
        private System.Windows.Forms.GroupBox groupBox_QueryCondition;
        private System.Windows.Forms.ComboBox comboBoxBandType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBandID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSensor1ID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBandName;
        private System.Windows.Forms.TextBox txtPLATFORMID;
        private System.Windows.Forms.Label label2;
    }
}