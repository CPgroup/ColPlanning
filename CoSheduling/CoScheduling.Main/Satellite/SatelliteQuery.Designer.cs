namespace CoScheduling.Main.Satellite
{
    partial class SatelliteQuery
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
            this.dataGridViewSat = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SAT_COUNTRY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SAT_CHARTER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSatCount = new System.Windows.Forms.TextBox();
            this.ButtonReturn = new System.Windows.Forms.Button();
            this.ButtonReset = new System.Windows.Forms.Button();
            this.ButtonQuery = new System.Windows.Forms.Button();
            this.groupBox_QueryCondition = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNumberOfSensor = new System.Windows.Forms.TextBox();
            this.txtPLATFORMID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPLATFORMName = new System.Windows.Forms.TextBox();
            this.txtSatCountry = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxSatCharter = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSat)).BeginInit();
            this.groupBox_QueryCondition.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewSat
            // 
            this.dataGridViewSat.AllowUserToAddRows = false;
            this.dataGridViewSat.AllowUserToDeleteRows = false;
            this.dataGridViewSat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.SAT_COUNTRY,
            this.SAT_CHARTER});
            this.dataGridViewSat.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewSat.Name = "dataGridViewSat";
            this.dataGridViewSat.RowHeadersWidth = 10;
            this.dataGridViewSat.RowTemplate.Height = 23;
            this.dataGridViewSat.Size = new System.Drawing.Size(568, 123);
            this.dataGridViewSat.TabIndex = 163;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "PLATFORM_ID";
            this.dataGridViewTextBoxColumn4.HeaderText = "平台ID";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 65;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "PLATFORM_Name";
            this.dataGridViewTextBoxColumn6.HeaderText = "平台名称";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 80;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "NumberOfSensor";
            this.dataGridViewTextBoxColumn8.HeaderText = "传感器数量";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 90;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "LaunchTime";
            this.dataGridViewTextBoxColumn9.HeaderText = "发射时间";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 80;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "EolTime";
            this.dataGridViewTextBoxColumn10.HeaderText = "终止时间";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Width = 80;
            // 
            // SAT_COUNTRY
            // 
            this.SAT_COUNTRY.DataPropertyName = "SAT_COUNTRY";
            this.SAT_COUNTRY.HeaderText = "所属国家";
            this.SAT_COUNTRY.Name = "SAT_COUNTRY";
            this.SAT_COUNTRY.Width = 80;
            // 
            // SAT_CHARTER
            // 
            this.SAT_CHARTER.DataPropertyName = "SAT_CHARTER";
            this.SAT_CHARTER.HeaderText = "宪章成员";
            this.SAT_CHARTER.Name = "SAT_CHARTER";
            this.SAT_CHARTER.Width = 80;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(414, 201);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 169;
            this.label5.Text = "查询结果数量";
            // 
            // txtSatCount
            // 
            this.txtSatCount.Location = new System.Drawing.Point(406, 223);
            this.txtSatCount.Name = "txtSatCount";
            this.txtSatCount.ReadOnly = true;
            this.txtSatCount.Size = new System.Drawing.Size(96, 21);
            this.txtSatCount.TabIndex = 168;
            // 
            // ButtonReturn
            // 
            this.ButtonReturn.Location = new System.Drawing.Point(416, 322);
            this.ButtonReturn.Name = "ButtonReturn";
            this.ButtonReturn.Size = new System.Drawing.Size(75, 23);
            this.ButtonReturn.TabIndex = 167;
            this.ButtonReturn.Text = "返回";
            this.ButtonReturn.UseVisualStyleBackColor = true;
            // 
            // ButtonReset
            // 
            this.ButtonReset.Location = new System.Drawing.Point(416, 275);
            this.ButtonReset.Name = "ButtonReset";
            this.ButtonReset.Size = new System.Drawing.Size(75, 23);
            this.ButtonReset.TabIndex = 166;
            this.ButtonReset.Text = "重置";
            this.ButtonReset.UseVisualStyleBackColor = true;
            // 
            // ButtonQuery
            // 
            this.ButtonQuery.Location = new System.Drawing.Point(416, 163);
            this.ButtonQuery.Name = "ButtonQuery";
            this.ButtonQuery.Size = new System.Drawing.Size(75, 23);
            this.ButtonQuery.TabIndex = 165;
            this.ButtonQuery.Text = "查询";
            this.ButtonQuery.UseVisualStyleBackColor = true;
            this.ButtonQuery.Click += new System.EventHandler(this.ButtonQuery_Click);
            // 
            // groupBox_QueryCondition
            // 
            this.groupBox_QueryCondition.Controls.Add(this.label8);
            this.groupBox_QueryCondition.Controls.Add(this.comboBoxSatCharter);
            this.groupBox_QueryCondition.Controls.Add(this.label7);
            this.groupBox_QueryCondition.Controls.Add(this.label6);
            this.groupBox_QueryCondition.Controls.Add(this.txtNumberOfSensor);
            this.groupBox_QueryCondition.Controls.Add(this.txtPLATFORMID);
            this.groupBox_QueryCondition.Controls.Add(this.label4);
            this.groupBox_QueryCondition.Controls.Add(this.label1);
            this.groupBox_QueryCondition.Controls.Add(this.label3);
            this.groupBox_QueryCondition.Controls.Add(this.txtPLATFORMName);
            this.groupBox_QueryCondition.Controls.Add(this.txtSatCountry);
            this.groupBox_QueryCondition.Controls.Add(this.label2);
            this.groupBox_QueryCondition.Location = new System.Drawing.Point(12, 150);
            this.groupBox_QueryCondition.Name = "groupBox_QueryCondition";
            this.groupBox_QueryCondition.Size = new System.Drawing.Size(295, 211);
            this.groupBox_QueryCondition.TabIndex = 164;
            this.groupBox_QueryCondition.TabStop = false;
            this.groupBox_QueryCondition.Text = "查询条件";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 157;
            this.label6.Text = "传感器数量：";
            // 
            // txtNumberOfSensor
            // 
            this.txtNumberOfSensor.Location = new System.Drawing.Point(92, 101);
            this.txtNumberOfSensor.Name = "txtNumberOfSensor";
            this.txtNumberOfSensor.Size = new System.Drawing.Size(179, 21);
            this.txtNumberOfSensor.TabIndex = 156;
            // 
            // txtPLATFORMID
            // 
            this.txtPLATFORMID.Location = new System.Drawing.Point(92, 20);
            this.txtPLATFORMID.Name = "txtPLATFORMID";
            this.txtPLATFORMID.Size = new System.Drawing.Size(179, 21);
            this.txtPLATFORMID.TabIndex = 149;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(133, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 155;
            this.label4.Text = "（模糊查询）";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 150;
            this.label1.Text = "平台ID：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 154;
            this.label3.Text = "所属国家：";
            // 
            // txtPLATFORMName
            // 
            this.txtPLATFORMName.Location = new System.Drawing.Point(92, 62);
            this.txtPLATFORMName.Name = "txtPLATFORMName";
            this.txtPLATFORMName.Size = new System.Drawing.Size(179, 21);
            this.txtPLATFORMName.TabIndex = 151;
            // 
            // txtSatCountry
            // 
            this.txtSatCountry.Location = new System.Drawing.Point(92, 140);
            this.txtSatCountry.Name = "txtSatCountry";
            this.txtSatCountry.Size = new System.Drawing.Size(179, 21);
            this.txtSatCountry.TabIndex = 153;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 152;
            this.label2.Text = "平台名称：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 181);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 12);
            this.label7.TabIndex = 158;
            this.label7.Text = "是否宪章成员：";
            // 
            // comboBoxSatCharter
            // 
            this.comboBoxSatCharter.FormattingEnabled = true;
            this.comboBoxSatCharter.Items.AddRange(new object[] {
            "(Either)",
            "是",
            "否"});
            this.comboBoxSatCharter.Location = new System.Drawing.Point(110, 178);
            this.comboBoxSatCharter.Name = "comboBoxSatCharter";
            this.comboBoxSatCharter.Size = new System.Drawing.Size(161, 20);
            this.comboBoxSatCharter.TabIndex = 229;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(133, 163);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 230;
            this.label8.Text = "（模糊查询）";
            // 
            // SatelliteQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 372);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSatCount);
            this.Controls.Add(this.ButtonReturn);
            this.Controls.Add(this.ButtonReset);
            this.Controls.Add(this.ButtonQuery);
            this.Controls.Add(this.groupBox_QueryCondition);
            this.Controls.Add(this.dataGridViewSat);
            this.Name = "SatelliteQuery";
            this.Text = "SatelliteQuery";
            this.Load += new System.EventHandler(this.SatelliteQuery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSat)).EndInit();
            this.groupBox_QueryCondition.ResumeLayout(false);
            this.groupBox_QueryCondition.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewSat;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn SAT_COUNTRY;
        private System.Windows.Forms.DataGridViewTextBoxColumn SAT_CHARTER;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSatCount;
        private System.Windows.Forms.Button ButtonReturn;
        private System.Windows.Forms.Button ButtonReset;
        private System.Windows.Forms.Button ButtonQuery;
        private System.Windows.Forms.GroupBox groupBox_QueryCondition;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNumberOfSensor;
        private System.Windows.Forms.TextBox txtPLATFORMID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPLATFORMName;
        private System.Windows.Forms.TextBox txtSatCountry;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxSatCharter;
        private System.Windows.Forms.Label label8;
    }
}