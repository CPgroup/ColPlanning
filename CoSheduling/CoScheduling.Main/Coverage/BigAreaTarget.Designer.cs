namespace CoScheduling.Main.Coverage
{
    partial class BigAreaTarget
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
            this.buttonBigAreaTargetCancel = new System.Windows.Forms.Button();
            this.buttonBigAreaTargetOK = new System.Windows.Forms.Button();
            this.buttonBigAreaTargetSelect = new System.Windows.Forms.Button();
            this.textBoxFile = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonBigAreaTargetCancel
            // 
            this.buttonBigAreaTargetCancel.Location = new System.Drawing.Point(153, 180);
            this.buttonBigAreaTargetCancel.Name = "buttonBigAreaTargetCancel";
            this.buttonBigAreaTargetCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonBigAreaTargetCancel.TabIndex = 11;
            this.buttonBigAreaTargetCancel.Text = "取消";
            this.buttonBigAreaTargetCancel.UseVisualStyleBackColor = true;
            this.buttonBigAreaTargetCancel.Click += new System.EventHandler(this.buttonBigAreaTargetCancel_Click);
            // 
            // buttonBigAreaTargetOK
            // 
            this.buttonBigAreaTargetOK.Location = new System.Drawing.Point(48, 180);
            this.buttonBigAreaTargetOK.Name = "buttonBigAreaTargetOK";
            this.buttonBigAreaTargetOK.Size = new System.Drawing.Size(75, 23);
            this.buttonBigAreaTargetOK.TabIndex = 10;
            this.buttonBigAreaTargetOK.Text = "确定";
            this.buttonBigAreaTargetOK.UseVisualStyleBackColor = true;
            this.buttonBigAreaTargetOK.Click += new System.EventHandler(this.buttonBigAreaTargetOK_Click);
            // 
            // buttonBigAreaTargetSelect
            // 
            this.buttonBigAreaTargetSelect.Location = new System.Drawing.Point(219, 60);
            this.buttonBigAreaTargetSelect.Name = "buttonBigAreaTargetSelect";
            this.buttonBigAreaTargetSelect.Size = new System.Drawing.Size(53, 23);
            this.buttonBigAreaTargetSelect.TabIndex = 9;
            this.buttonBigAreaTargetSelect.Text = "选择";
            this.buttonBigAreaTargetSelect.UseVisualStyleBackColor = true;
            this.buttonBigAreaTargetSelect.Click += new System.EventHandler(this.buttonBigAreaTargetSelect_Click);
            // 
            // textBoxFile
            // 
            this.textBoxFile.Location = new System.Drawing.Point(12, 62);
            this.textBoxFile.Name = "textBoxFile";
            this.textBoxFile.Size = new System.Drawing.Size(200, 21);
            this.textBoxFile.TabIndex = 8;
            // 
            // BigAreaTarget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.buttonBigAreaTargetCancel);
            this.Controls.Add(this.buttonBigAreaTargetOK);
            this.Controls.Add(this.buttonBigAreaTargetSelect);
            this.Controls.Add(this.textBoxFile);
            this.Name = "BigAreaTarget";
            this.Text = "目标配置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBigAreaTargetCancel;
        private System.Windows.Forms.Button buttonBigAreaTargetOK;
        private System.Windows.Forms.Button buttonBigAreaTargetSelect;
        private System.Windows.Forms.TextBox textBoxFile;
    }
}