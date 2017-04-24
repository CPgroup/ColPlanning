namespace CoScheduling.Main.Coverage
{
    partial class BigAreaScheme
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
            this.dateTimePickerBigAreaSchemeEndTime = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerBigAreaSchemeStartTime = new System.Windows.Forms.DateTimePicker();
            this.buttonBigAreaSchemeClose = new System.Windows.Forms.Button();
            this.button1BigAreaSchemeOK = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxBigAreaSchemeName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // dateTimePickerBigAreaSchemeEndTime
            // 
            this.dateTimePickerBigAreaSchemeEndTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePickerBigAreaSchemeEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerBigAreaSchemeEndTime.Location = new System.Drawing.Point(84, 138);
            this.dateTimePickerBigAreaSchemeEndTime.Name = "dateTimePickerBigAreaSchemeEndTime";
            this.dateTimePickerBigAreaSchemeEndTime.Size = new System.Drawing.Size(195, 21);
            this.dateTimePickerBigAreaSchemeEndTime.TabIndex = 23;
            // 
            // dateTimePickerBigAreaSchemeStartTime
            // 
            this.dateTimePickerBigAreaSchemeStartTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePickerBigAreaSchemeStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerBigAreaSchemeStartTime.Location = new System.Drawing.Point(84, 81);
            this.dateTimePickerBigAreaSchemeStartTime.Name = "dateTimePickerBigAreaSchemeStartTime";
            this.dateTimePickerBigAreaSchemeStartTime.Size = new System.Drawing.Size(195, 21);
            this.dateTimePickerBigAreaSchemeStartTime.TabIndex = 22;
            // 
            // buttonBigAreaSchemeClose
            // 
            this.buttonBigAreaSchemeClose.Location = new System.Drawing.Point(169, 196);
            this.buttonBigAreaSchemeClose.Name = "buttonBigAreaSchemeClose";
            this.buttonBigAreaSchemeClose.Size = new System.Drawing.Size(75, 23);
            this.buttonBigAreaSchemeClose.TabIndex = 21;
            this.buttonBigAreaSchemeClose.Text = "取消";
            this.buttonBigAreaSchemeClose.UseVisualStyleBackColor = true;
            this.buttonBigAreaSchemeClose.Click += new System.EventHandler(this.buttonBigAreaSchemeClose_Click);
            // 
            // button1BigAreaSchemeOK
            // 
            this.button1BigAreaSchemeOK.Location = new System.Drawing.Point(49, 196);
            this.button1BigAreaSchemeOK.Name = "button1BigAreaSchemeOK";
            this.button1BigAreaSchemeOK.Size = new System.Drawing.Size(75, 23);
            this.button1BigAreaSchemeOK.TabIndex = 20;
            this.button1BigAreaSchemeOK.Text = "确定";
            this.button1BigAreaSchemeOK.UseVisualStyleBackColor = true;
            this.button1BigAreaSchemeOK.Click += new System.EventHandler(this.button1BigAreaSchemeOK_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 19;
            this.label3.Text = "结束时间：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 18;
            this.label2.Text = "开始时间：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 17;
            this.label1.Text = "方案名称：";
            // 
            // textBoxBigAreaSchemeName
            // 
            this.textBoxBigAreaSchemeName.Location = new System.Drawing.Point(84, 34);
            this.textBoxBigAreaSchemeName.Name = "textBoxBigAreaSchemeName";
            this.textBoxBigAreaSchemeName.Size = new System.Drawing.Size(195, 21);
            this.textBoxBigAreaSchemeName.TabIndex = 16;
            // 
            // BigAreaScheme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 252);
            this.Controls.Add(this.dateTimePickerBigAreaSchemeEndTime);
            this.Controls.Add(this.dateTimePickerBigAreaSchemeStartTime);
            this.Controls.Add(this.buttonBigAreaSchemeClose);
            this.Controls.Add(this.button1BigAreaSchemeOK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxBigAreaSchemeName);
            this.Name = "BigAreaScheme";
            this.Text = "覆盖分析方案";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePickerBigAreaSchemeEndTime;
        private System.Windows.Forms.DateTimePicker dateTimePickerBigAreaSchemeStartTime;
        private System.Windows.Forms.Button buttonBigAreaSchemeClose;
        private System.Windows.Forms.Button button1BigAreaSchemeOK;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxBigAreaSchemeName;
    }
}