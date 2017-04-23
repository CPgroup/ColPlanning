namespace CoScheduling.Main.HUMANDETECTION
{
    partial class HUMDETAdd
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
            this.ButtonReturn = new System.Windows.Forms.Button();
            this.ButtonReset = new System.Windows.Forms.Button();
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.txtPlatformName = new System.Windows.Forms.TextBox();
            this.txtMaxCruisingTime = new System.Windows.Forms.TextBox();
            this.txtNumberOfSensor = new System.Windows.Forms.TextBox();
            this.txtPlatformID = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ButtonReturn
            // 
            this.ButtonReturn.Location = new System.Drawing.Point(408, 166);
            this.ButtonReturn.Name = "ButtonReturn";
            this.ButtonReturn.Size = new System.Drawing.Size(75, 23);
            this.ButtonReturn.TabIndex = 225;
            this.ButtonReturn.Text = "返回";
            this.ButtonReturn.UseVisualStyleBackColor = true;
            this.ButtonReturn.Click += new System.EventHandler(this.ButtonReturn_Click);
            // 
            // ButtonReset
            // 
            this.ButtonReset.Location = new System.Drawing.Point(408, 119);
            this.ButtonReset.Name = "ButtonReset";
            this.ButtonReset.Size = new System.Drawing.Size(75, 23);
            this.ButtonReset.TabIndex = 224;
            this.ButtonReset.Text = "重置";
            this.ButtonReset.UseVisualStyleBackColor = true;
            this.ButtonReset.Click += new System.EventHandler(this.ButtonReset_Click);
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.Location = new System.Drawing.Point(408, 72);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(75, 23);
            this.ButtonAdd.TabIndex = 223;
            this.ButtonAdd.Text = "添加";
            this.ButtonAdd.UseVisualStyleBackColor = true;
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // txtPlatformName
            // 
            this.txtPlatformName.Location = new System.Drawing.Point(140, 79);
            this.txtPlatformName.Name = "txtPlatformName";
            this.txtPlatformName.Size = new System.Drawing.Size(154, 21);
            this.txtPlatformName.TabIndex = 222;
            // 
            // txtMaxCruisingTime
            // 
            this.txtMaxCruisingTime.Location = new System.Drawing.Point(140, 163);
            this.txtMaxCruisingTime.Name = "txtMaxCruisingTime";
            this.txtMaxCruisingTime.Size = new System.Drawing.Size(154, 21);
            this.txtMaxCruisingTime.TabIndex = 221;
            // 
            // txtNumberOfSensor
            // 
            this.txtNumberOfSensor.Location = new System.Drawing.Point(140, 121);
            this.txtNumberOfSensor.Name = "txtNumberOfSensor";
            this.txtNumberOfSensor.Size = new System.Drawing.Size(154, 21);
            this.txtNumberOfSensor.TabIndex = 220;
            // 
            // txtPlatformID
            // 
            this.txtPlatformID.Location = new System.Drawing.Point(140, 37);
            this.txtPlatformID.Name = "txtPlatformID";
            this.txtPlatformID.Size = new System.Drawing.Size(154, 21);
            this.txtPlatformID.TabIndex = 219;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(58, 166);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 12);
            this.label11.TabIndex = 218;
            this.label11.Text = "最大巡航时间：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 217;
            this.label4.Text = "传感器数量：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 216;
            this.label2.Text = "平台名称：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 215;
            this.label1.Text = "平台编号：";
            // 
            // HUMDETAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 262);
            this.Controls.Add(this.ButtonReturn);
            this.Controls.Add(this.ButtonReset);
            this.Controls.Add(this.ButtonAdd);
            this.Controls.Add(this.txtPlatformName);
            this.Controls.Add(this.txtMaxCruisingTime);
            this.Controls.Add(this.txtNumberOfSensor);
            this.Controls.Add(this.txtPlatformID);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "HUMDETAdd";
            this.Text = "HUMDETAdd";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonReturn;
        private System.Windows.Forms.Button ButtonReset;
        private System.Windows.Forms.Button ButtonAdd;
        private System.Windows.Forms.TextBox txtPlatformName;
        private System.Windows.Forms.TextBox txtMaxCruisingTime;
        private System.Windows.Forms.TextBox txtNumberOfSensor;
        private System.Windows.Forms.TextBox txtPlatformID;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}