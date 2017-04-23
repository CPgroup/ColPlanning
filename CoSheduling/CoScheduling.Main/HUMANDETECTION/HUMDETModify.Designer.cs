namespace CoScheduling.Main.HUMANDETECTION
{
    partial class HUMDETModify
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
            this.txtPlatformName = new System.Windows.Forms.TextBox();
            this.txtMaxCruisingTime = new System.Windows.Forms.TextBox();
            this.txtNumberOfSensor = new System.Windows.Forms.TextBox();
            this.txtPlatformID = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.ButtonModify = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtPlatformName
            // 
            this.txtPlatformName.Location = new System.Drawing.Point(154, 101);
            this.txtPlatformName.Name = "txtPlatformName";
            this.txtPlatformName.Size = new System.Drawing.Size(154, 21);
            this.txtPlatformName.TabIndex = 230;
            // 
            // txtMaxCruisingTime
            // 
            this.txtMaxCruisingTime.Location = new System.Drawing.Point(154, 185);
            this.txtMaxCruisingTime.Name = "txtMaxCruisingTime";
            this.txtMaxCruisingTime.Size = new System.Drawing.Size(154, 21);
            this.txtMaxCruisingTime.TabIndex = 229;
            // 
            // txtNumberOfSensor
            // 
            this.txtNumberOfSensor.Location = new System.Drawing.Point(154, 143);
            this.txtNumberOfSensor.Name = "txtNumberOfSensor";
            this.txtNumberOfSensor.Size = new System.Drawing.Size(154, 21);
            this.txtNumberOfSensor.TabIndex = 228;
            // 
            // txtPlatformID
            // 
            this.txtPlatformID.Location = new System.Drawing.Point(154, 59);
            this.txtPlatformID.Name = "txtPlatformID";
            this.txtPlatformID.Size = new System.Drawing.Size(154, 21);
            this.txtPlatformID.TabIndex = 227;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(72, 188);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 12);
            this.label11.TabIndex = 226;
            this.label11.Text = "最大巡航时间：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(72, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 225;
            this.label4.Text = "传感器数量：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 224;
            this.label2.Text = "平台名称：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 223;
            this.label1.Text = "平台编号：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(381, 151);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 259;
            this.button1.Text = "返回";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ButtonModify
            // 
            this.ButtonModify.Location = new System.Drawing.Point(381, 94);
            this.ButtonModify.Name = "ButtonModify";
            this.ButtonModify.Size = new System.Drawing.Size(75, 23);
            this.ButtonModify.TabIndex = 258;
            this.ButtonModify.Text = "修改";
            this.ButtonModify.UseVisualStyleBackColor = true;
            this.ButtonModify.Click += new System.EventHandler(this.ButtonModify_Click);
            // 
            // HUMDETModify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 262);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ButtonModify);
            this.Controls.Add(this.txtPlatformName);
            this.Controls.Add(this.txtMaxCruisingTime);
            this.Controls.Add(this.txtNumberOfSensor);
            this.Controls.Add(this.txtPlatformID);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "HUMDETModify";
            this.Text = "HUMDETModify";
            this.Load += new System.EventHandler(this.HUMDETModify_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPlatformName;
        private System.Windows.Forms.TextBox txtMaxCruisingTime;
        private System.Windows.Forms.TextBox txtNumberOfSensor;
        private System.Windows.Forms.TextBox txtPlatformID;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button ButtonModify;
    }
}