namespace CoScheduling.Main.Coverage
{
    partial class BigAreaSchemaManage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonModify = new System.Windows.Forms.Button();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxSchemeName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewScheme = new System.Windows.Forms.DataGridView();
            this.SCHEMEID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SCHEMENAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SCHEMEBTIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SCHEMEETIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewScheme)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(211, 388);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 23);
            this.buttonClear.TabIndex = 21;
            this.buttonClear.Text = "清除结果";
            this.buttonClear.UseVisualStyleBackColor = true;
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(486, 388);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 20;
            this.buttonClose.Text = "关闭";
            this.buttonClose.UseVisualStyleBackColor = true;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(98, 388);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 19;
            this.buttonDelete.Text = "删除";
            this.buttonDelete.UseVisualStyleBackColor = true;
            // 
            // buttonModify
            // 
            this.buttonModify.Location = new System.Drawing.Point(17, 388);
            this.buttonModify.Name = "buttonModify";
            this.buttonModify.Size = new System.Drawing.Size(75, 23);
            this.buttonModify.TabIndex = 18;
            this.buttonModify.Text = "修改";
            this.buttonModify.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePickerEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerEnd.Location = new System.Drawing.Point(361, 336);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(200, 21);
            this.dateTimePickerEnd.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(293, 341);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "结束时间：";
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePickerStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerStart.Location = new System.Drawing.Point(86, 336);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(200, 21);
            this.dateTimePickerStart.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 342);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "开始时间：";
            // 
            // textBoxSchemeName
            // 
            this.textBoxSchemeName.Location = new System.Drawing.Point(86, 299);
            this.textBoxSchemeName.Name = "textBoxSchemeName";
            this.textBoxSchemeName.Size = new System.Drawing.Size(475, 21);
            this.textBoxSchemeName.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 302);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "方案名称：";
            // 
            // dataGridViewScheme
            // 
            this.dataGridViewScheme.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewScheme.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewScheme.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SCHEMEID,
            this.SCHEMENAME,
            this.SCHEMEBTIME,
            this.SCHEMEETIME});
            this.dataGridViewScheme.Location = new System.Drawing.Point(14, 20);
            this.dataGridViewScheme.MultiSelect = false;
            this.dataGridViewScheme.Name = "dataGridViewScheme";
            this.dataGridViewScheme.ReadOnly = true;
            this.dataGridViewScheme.RowTemplate.Height = 23;
            this.dataGridViewScheme.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewScheme.Size = new System.Drawing.Size(547, 258);
            this.dataGridViewScheme.TabIndex = 11;
            // 
            // SCHEMEID
            // 
            this.SCHEMEID.DataPropertyName = "SCHEMEID";
            this.SCHEMEID.HeaderText = "方案ID";
            this.SCHEMEID.Name = "SCHEMEID";
            this.SCHEMEID.ReadOnly = true;
            this.SCHEMEID.Visible = false;
            // 
            // SCHEMENAME
            // 
            this.SCHEMENAME.DataPropertyName = "SCHEMENAME";
            this.SCHEMENAME.HeaderText = "方案名称";
            this.SCHEMENAME.Name = "SCHEMENAME";
            this.SCHEMENAME.ReadOnly = true;
            // 
            // SCHEMEBTIME
            // 
            this.SCHEMEBTIME.DataPropertyName = "SCHEMEBTIME";
            dataGridViewCellStyle1.Format = "yyyy-MM-dd HH:mm:ss";
            this.SCHEMEBTIME.DefaultCellStyle = dataGridViewCellStyle1;
            this.SCHEMEBTIME.HeaderText = "开始时间";
            this.SCHEMEBTIME.Name = "SCHEMEBTIME";
            this.SCHEMEBTIME.ReadOnly = true;
            // 
            // SCHEMEETIME
            // 
            this.SCHEMEETIME.DataPropertyName = "SCHEMEETIME";
            dataGridViewCellStyle2.Format = "yyyy-MM-dd HH:mm:ss";
            this.SCHEMEETIME.DefaultCellStyle = dataGridViewCellStyle2;
            this.SCHEMEETIME.HeaderText = "结束时间";
            this.SCHEMEETIME.Name = "SCHEMEETIME";
            this.SCHEMEETIME.ReadOnly = true;
            // 
            // BigAreaSchemaManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 431);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonModify);
            this.Controls.Add(this.dateTimePickerEnd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePickerStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxSchemeName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewScheme);
            this.Name = "BigAreaSchemaManage";
            this.Text = "BigAreaSchemaManage";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewScheme)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonModify;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxSchemeName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewScheme;
        private System.Windows.Forms.DataGridViewTextBoxColumn SCHEMEID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SCHEMENAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn SCHEMEBTIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn SCHEMEETIME;
    }
}