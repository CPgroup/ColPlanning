namespace CoScheduling.Main.Coverage
{
    partial class BigAreaAnalysisFile
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonCoverageProbability = new System.Windows.Forms.Button();
            this.textBoxCoverageProbability = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonCoverageWindow = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxCoverageWindow = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(364, 208);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 29;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(273, 208);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 28;
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(107, 40);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(241, 21);
            this.textBox1.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 26;
            this.label3.Text = "当前方案：";
            // 
            // buttonCoverageProbability
            // 
            this.buttonCoverageProbability.Location = new System.Drawing.Point(364, 137);
            this.buttonCoverageProbability.Name = "buttonCoverageProbability";
            this.buttonCoverageProbability.Size = new System.Drawing.Size(75, 23);
            this.buttonCoverageProbability.TabIndex = 25;
            this.buttonCoverageProbability.Text = "浏览";
            this.buttonCoverageProbability.UseVisualStyleBackColor = true;
            // 
            // textBoxCoverageProbability
            // 
            this.textBoxCoverageProbability.Location = new System.Drawing.Point(141, 139);
            this.textBoxCoverageProbability.Name = "textBoxCoverageProbability";
            this.textBoxCoverageProbability.Size = new System.Drawing.Size(207, 21);
            this.textBoxCoverageProbability.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 23;
            this.label2.Text = "覆盖响应文件夹：";
            // 
            // buttonCoverageWindow
            // 
            this.buttonCoverageWindow.Location = new System.Drawing.Point(364, 98);
            this.buttonCoverageWindow.Name = "buttonCoverageWindow";
            this.buttonCoverageWindow.Size = new System.Drawing.Size(75, 23);
            this.buttonCoverageWindow.TabIndex = 22;
            this.buttonCoverageWindow.Text = "浏览";
            this.buttonCoverageWindow.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 21;
            this.label1.Text = "覆盖窗口文件夹：";
            // 
            // textBoxCoverageWindow
            // 
            this.textBoxCoverageWindow.Location = new System.Drawing.Point(141, 100);
            this.textBoxCoverageWindow.Name = "textBoxCoverageWindow";
            this.textBoxCoverageWindow.Size = new System.Drawing.Size(207, 21);
            this.textBoxCoverageWindow.TabIndex = 20;
            // 
            // BigAreaAnalysisFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 270);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonCoverageProbability);
            this.Controls.Add(this.textBoxCoverageProbability);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonCoverageWindow);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxCoverageWindow);
            this.Name = "BigAreaAnalysisFile";
            this.Text = "BigAreaAnalysisFile";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonCoverageProbability;
        private System.Windows.Forms.TextBox textBoxCoverageProbability;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonCoverageWindow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxCoverageWindow;

    }
}