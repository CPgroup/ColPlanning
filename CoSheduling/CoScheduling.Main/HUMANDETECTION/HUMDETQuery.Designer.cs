namespace CoScheduling.Main.HUMANDETECTION
{
    partial class HUMDETQuery
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
            this.ButtonQuery = new System.Windows.Forms.Button();
            this.txtNumberOfSensor = new System.Windows.Forms.TextBox();
            this.txtPLATFORMID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPLATFORMName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtHUMDETCount = new System.Windows.Forms.TextBox();
            this.ButtonReturn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox_QueryCondition = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ButtonReset = new System.Windows.Forms.Button();
            this.dataGridViewHUMDET = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox_QueryCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHUMDET)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonQuery
            // 
            this.ButtonQuery.Location = new System.Drawing.Point(429, 175);
            this.ButtonQuery.Name = "ButtonQuery";
            this.ButtonQuery.Size = new System.Drawing.Size(75, 23);
            this.ButtonQuery.TabIndex = 184;
            this.ButtonQuery.Text = "查询";
            this.ButtonQuery.UseVisualStyleBackColor = true;
            this.ButtonQuery.Click += new System.EventHandler(this.ButtonQuery_Click);
            // 
            // txtNumberOfSensor
            // 
            this.txtNumberOfSensor.Location = new System.Drawing.Point(92, 143);
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
            this.label4.Location = new System.Drawing.Point(133, 106);
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
            // txtPLATFORMName
            // 
            this.txtPLATFORMName.Location = new System.Drawing.Point(92, 82);
            this.txtPLATFORMName.Name = "txtPLATFORMName";
            this.txtPLATFORMName.Size = new System.Drawing.Size(179, 21);
            this.txtPLATFORMName.TabIndex = 151;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(428, 213);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 188;
            this.label5.Text = "查询结果数量";
            // 
            // txtHUMDETCount
            // 
            this.txtHUMDETCount.Location = new System.Drawing.Point(419, 235);
            this.txtHUMDETCount.Name = "txtHUMDETCount";
            this.txtHUMDETCount.ReadOnly = true;
            this.txtHUMDETCount.Size = new System.Drawing.Size(96, 21);
            this.txtHUMDETCount.TabIndex = 187;
            // 
            // ButtonReturn
            // 
            this.ButtonReturn.Location = new System.Drawing.Point(429, 313);
            this.ButtonReturn.Name = "ButtonReturn";
            this.ButtonReturn.Size = new System.Drawing.Size(75, 23);
            this.ButtonReturn.TabIndex = 186;
            this.ButtonReturn.Text = "返回";
            this.ButtonReturn.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 157;
            this.label6.Text = "传感器数量：";
            // 
            // groupBox_QueryCondition
            // 
            this.groupBox_QueryCondition.Controls.Add(this.label6);
            this.groupBox_QueryCondition.Controls.Add(this.txtNumberOfSensor);
            this.groupBox_QueryCondition.Controls.Add(this.txtPLATFORMID);
            this.groupBox_QueryCondition.Controls.Add(this.label4);
            this.groupBox_QueryCondition.Controls.Add(this.label1);
            this.groupBox_QueryCondition.Controls.Add(this.txtPLATFORMName);
            this.groupBox_QueryCondition.Controls.Add(this.label2);
            this.groupBox_QueryCondition.Location = new System.Drawing.Point(39, 166);
            this.groupBox_QueryCondition.Name = "groupBox_QueryCondition";
            this.groupBox_QueryCondition.Size = new System.Drawing.Size(295, 178);
            this.groupBox_QueryCondition.TabIndex = 183;
            this.groupBox_QueryCondition.TabStop = false;
            this.groupBox_QueryCondition.Text = "查询条件";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 152;
            this.label2.Text = "平台名称：";
            // 
            // ButtonReset
            // 
            this.ButtonReset.Location = new System.Drawing.Point(429, 274);
            this.ButtonReset.Name = "ButtonReset";
            this.ButtonReset.Size = new System.Drawing.Size(75, 23);
            this.ButtonReset.TabIndex = 185;
            this.ButtonReset.Text = "重置";
            this.ButtonReset.UseVisualStyleBackColor = true;
            // 
            // dataGridViewHUMDET
            // 
            this.dataGridViewHUMDET.AllowUserToAddRows = false;
            this.dataGridViewHUMDET.AllowUserToDeleteRows = false;
            this.dataGridViewHUMDET.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHUMDET.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9});
            this.dataGridViewHUMDET.Location = new System.Drawing.Point(10, 12);
            this.dataGridViewHUMDET.Name = "dataGridViewHUMDET";
            this.dataGridViewHUMDET.RowHeadersWidth = 10;
            this.dataGridViewHUMDET.RowTemplate.Height = 23;
            this.dataGridViewHUMDET.Size = new System.Drawing.Size(549, 148);
            this.dataGridViewHUMDET.TabIndex = 182;
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
            this.dataGridViewTextBoxColumn9.DataPropertyName = "MaxCruisingTime";
            this.dataGridViewTextBoxColumn9.HeaderText = "最大续航时间";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // HUMDETQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 356);
            this.Controls.Add(this.ButtonQuery);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtHUMDETCount);
            this.Controls.Add(this.ButtonReturn);
            this.Controls.Add(this.groupBox_QueryCondition);
            this.Controls.Add(this.ButtonReset);
            this.Controls.Add(this.dataGridViewHUMDET);
            this.Name = "HUMDETQuery";
            this.Text = "志愿者观测设备查询";
            this.Load += new System.EventHandler(this.HUMDETQuery_Load);
            this.groupBox_QueryCondition.ResumeLayout(false);
            this.groupBox_QueryCondition.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHUMDET)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonQuery;
        private System.Windows.Forms.TextBox txtNumberOfSensor;
        private System.Windows.Forms.TextBox txtPLATFORMID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPLATFORMName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtHUMDETCount;
        private System.Windows.Forms.Button ButtonReturn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox_QueryCondition;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ButtonReset;
        private System.Windows.Forms.DataGridView dataGridViewHUMDET;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
    }
}