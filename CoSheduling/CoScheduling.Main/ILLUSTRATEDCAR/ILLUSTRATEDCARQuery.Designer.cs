namespace CoScheduling.Main.ILLUSTRATEDCAR
{
    partial class ILLUSTRATEDCARQuery
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
            this.label6 = new System.Windows.Forms.Label();
            this.txtNumberOfSensor = new System.Windows.Forms.TextBox();
            this.txtPLATFORMID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ButtonReset = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtILLCARCount = new System.Windows.Forms.TextBox();
            this.ButtonReturn = new System.Windows.Forms.Button();
            this.ButtonQuery = new System.Windows.Forms.Button();
            this.groupBox_QueryCondition = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaxVelocity = new System.Windows.Forms.TextBox();
            this.txtPLATFORMName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridViewILLCAR = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox_QueryCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewILLCAR)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 157;
            this.label6.Text = "传感器数量：";
            // 
            // txtNumberOfSensor
            // 
            this.txtNumberOfSensor.Location = new System.Drawing.Point(92, 98);
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
            this.label4.Location = new System.Drawing.Point(133, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 155;
            this.label4.Text = "（模糊查询）";
            // 
            // ButtonReset
            // 
            this.ButtonReset.Location = new System.Drawing.Point(403, 299);
            this.ButtonReset.Name = "ButtonReset";
            this.ButtonReset.Size = new System.Drawing.Size(75, 23);
            this.ButtonReset.TabIndex = 172;
            this.ButtonReset.Text = "重置";
            this.ButtonReset.UseVisualStyleBackColor = true;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 152;
            this.label2.Text = "平台名称：";
            // 
            // txtILLCARCount
            // 
            this.txtILLCARCount.Location = new System.Drawing.Point(393, 260);
            this.txtILLCARCount.Name = "txtILLCARCount";
            this.txtILLCARCount.ReadOnly = true;
            this.txtILLCARCount.Size = new System.Drawing.Size(96, 21);
            this.txtILLCARCount.TabIndex = 174;
            // 
            // ButtonReturn
            // 
            this.ButtonReturn.Location = new System.Drawing.Point(403, 338);
            this.ButtonReturn.Name = "ButtonReturn";
            this.ButtonReturn.Size = new System.Drawing.Size(75, 23);
            this.ButtonReturn.TabIndex = 173;
            this.ButtonReturn.Text = "返回";
            this.ButtonReturn.UseVisualStyleBackColor = true;
            // 
            // ButtonQuery
            // 
            this.ButtonQuery.Location = new System.Drawing.Point(403, 200);
            this.ButtonQuery.Name = "ButtonQuery";
            this.ButtonQuery.Size = new System.Drawing.Size(75, 23);
            this.ButtonQuery.TabIndex = 171;
            this.ButtonQuery.Text = "查询";
            this.ButtonQuery.UseVisualStyleBackColor = true;
            this.ButtonQuery.Click += new System.EventHandler(this.ButtonQuery_Click);
            // 
            // groupBox_QueryCondition
            // 
            this.groupBox_QueryCondition.Controls.Add(this.label3);
            this.groupBox_QueryCondition.Controls.Add(this.txtMaxVelocity);
            this.groupBox_QueryCondition.Controls.Add(this.label6);
            this.groupBox_QueryCondition.Controls.Add(this.txtNumberOfSensor);
            this.groupBox_QueryCondition.Controls.Add(this.txtPLATFORMID);
            this.groupBox_QueryCondition.Controls.Add(this.label4);
            this.groupBox_QueryCondition.Controls.Add(this.label1);
            this.groupBox_QueryCondition.Controls.Add(this.txtPLATFORMName);
            this.groupBox_QueryCondition.Controls.Add(this.label2);
            this.groupBox_QueryCondition.Location = new System.Drawing.Point(13, 191);
            this.groupBox_QueryCondition.Name = "groupBox_QueryCondition";
            this.groupBox_QueryCondition.Size = new System.Drawing.Size(295, 178);
            this.groupBox_QueryCondition.TabIndex = 170;
            this.groupBox_QueryCondition.TabStop = false;
            this.groupBox_QueryCondition.Text = "查询条件";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 159;
            this.label3.Text = "最大速度>=：";
            // 
            // txtMaxVelocity
            // 
            this.txtMaxVelocity.Location = new System.Drawing.Point(92, 136);
            this.txtMaxVelocity.Name = "txtMaxVelocity";
            this.txtMaxVelocity.Size = new System.Drawing.Size(179, 21);
            this.txtMaxVelocity.TabIndex = 158;
            // 
            // txtPLATFORMName
            // 
            this.txtPLATFORMName.Location = new System.Drawing.Point(92, 59);
            this.txtPLATFORMName.Name = "txtPLATFORMName";
            this.txtPLATFORMName.Size = new System.Drawing.Size(179, 21);
            this.txtPLATFORMName.TabIndex = 151;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(402, 238);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 175;
            this.label5.Text = "查询结果数量";
            // 
            // dataGridViewILLCAR
            // 
            this.dataGridViewILLCAR.AllowUserToAddRows = false;
            this.dataGridViewILLCAR.AllowUserToDeleteRows = false;
            this.dataGridViewILLCAR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewILLCAR.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10});
            this.dataGridViewILLCAR.Location = new System.Drawing.Point(13, 12);
            this.dataGridViewILLCAR.Name = "dataGridViewILLCAR";
            this.dataGridViewILLCAR.RowHeadersWidth = 10;
            this.dataGridViewILLCAR.RowTemplate.Height = 23;
            this.dataGridViewILLCAR.Size = new System.Drawing.Size(549, 173);
            this.dataGridViewILLCAR.TabIndex = 176;
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
            this.dataGridViewTextBoxColumn9.DataPropertyName = "MaxVelocity";
            this.dataGridViewTextBoxColumn9.HeaderText = "最大速度";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "MaxDistance";
            this.dataGridViewTextBoxColumn10.HeaderText = "最大距离";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // ILLUSTRATEDCARQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 381);
            this.Controls.Add(this.dataGridViewILLCAR);
            this.Controls.Add(this.ButtonReset);
            this.Controls.Add(this.txtILLCARCount);
            this.Controls.Add(this.ButtonReturn);
            this.Controls.Add(this.ButtonQuery);
            this.Controls.Add(this.groupBox_QueryCondition);
            this.Controls.Add(this.label5);
            this.Name = "ILLUSTRATEDCARQuery";
            this.Text = "ILLUSTRATEDCARQuery";
            this.Load += new System.EventHandler(this.ILLUSTRATEDCARQuery_Load);
            this.groupBox_QueryCondition.ResumeLayout(false);
            this.groupBox_QueryCondition.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewILLCAR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNumberOfSensor;
        private System.Windows.Forms.TextBox txtPLATFORMID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button ButtonReset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtILLCARCount;
        private System.Windows.Forms.Button ButtonReturn;
        private System.Windows.Forms.Button ButtonQuery;
        private System.Windows.Forms.GroupBox groupBox_QueryCondition;
        private System.Windows.Forms.TextBox txtPLATFORMName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMaxVelocity;
        private System.Windows.Forms.DataGridView dataGridViewILLCAR;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
    }
}