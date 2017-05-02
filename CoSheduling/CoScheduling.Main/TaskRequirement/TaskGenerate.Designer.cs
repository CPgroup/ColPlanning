namespace CoScheduling.Main.TaskRequirement
{
    partial class TaskGenerate
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
            this.label15 = new System.Windows.Forms.Label();
            this.dateOccurTime = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox_SensorTypes = new System.Windows.Forms.GroupBox();
            this.checkBox_UV = new System.Windows.Forms.CheckBox();
            this.checkBox1_TIR = new System.Windows.Forms.CheckBox();
            this.checkBox_LasFlu = new System.Windows.Forms.CheckBox();
            this.checkBox_VIS = new System.Windows.Forms.CheckBox();
            this.checkBox_HypSpe = new System.Windows.Forms.CheckBox();
            this.checkBox_NIR = new System.Windows.Forms.CheckBox();
            this.checkBox_SARL = new System.Windows.Forms.CheckBox();
            this.checkBox_SIR = new System.Windows.Forms.CheckBox();
            this.checkBox_SARS = new System.Windows.Forms.CheckBox();
            this.checkBox_SARC = new System.Windows.Forms.CheckBox();
            this.checkBox_MIR = new System.Windows.Forms.CheckBox();
            this.checkBox_SARX = new System.Windows.Forms.CheckBox();
            this.comboBox_DisaType = new System.Windows.Forms.ComboBox();
            this.ButtonReturn = new System.Windows.Forms.Button();
            this.ButtonGenerate = new System.Windows.Forms.Button();
            this.txtTaskName = new System.Windows.Forms.TextBox();
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.txtObsFre = new System.Windows.Forms.TextBox();
            this.txtResTime = new System.Windows.Forms.TextBox();
            this.txtSpaRes = new System.Windows.Forms.TextBox();
            this.txtPriority = new System.Windows.Forms.TextBox();
            this.dateEndTime = new System.Windows.Forms.DateTimePicker();
            this.dateStartTime = new System.Windows.Forms.DateTimePicker();
            this.txtTaskID = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox_ObsRegion = new System.Windows.Forms.GroupBox();
            this.txtTaskRegion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox_SensorTypes.SuspendLayout();
            this.groupBox_ObsRegion.SuspendLayout();
            this.SuspendLayout();
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(42, 397);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(125, 12);
            this.label15.TabIndex = 168;
            this.label15.Text = "注：标红属性为必填项";
            // 
            // dateOccurTime
            // 
            this.dateOccurTime.Checked = false;
            this.dateOccurTime.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.dateOccurTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateOccurTime.Location = new System.Drawing.Point(378, 35);
            this.dateOccurTime.Name = "dateOccurTime";
            this.dateOccurTime.ShowCheckBox = true;
            this.dateOccurTime.Size = new System.Drawing.Size(154, 21);
            this.dateOccurTime.TabIndex = 167;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(296, 38);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 166;
            this.label10.Text = "发生时间：";
            // 
            // groupBox_SensorTypes
            // 
            this.groupBox_SensorTypes.Controls.Add(this.checkBox_UV);
            this.groupBox_SensorTypes.Controls.Add(this.checkBox1_TIR);
            this.groupBox_SensorTypes.Controls.Add(this.checkBox_LasFlu);
            this.groupBox_SensorTypes.Controls.Add(this.checkBox_VIS);
            this.groupBox_SensorTypes.Controls.Add(this.checkBox_HypSpe);
            this.groupBox_SensorTypes.Controls.Add(this.checkBox_NIR);
            this.groupBox_SensorTypes.Controls.Add(this.checkBox_SARL);
            this.groupBox_SensorTypes.Controls.Add(this.checkBox_SIR);
            this.groupBox_SensorTypes.Controls.Add(this.checkBox_SARS);
            this.groupBox_SensorTypes.Controls.Add(this.checkBox_SARC);
            this.groupBox_SensorTypes.Controls.Add(this.checkBox_MIR);
            this.groupBox_SensorTypes.Controls.Add(this.checkBox_SARX);
            this.groupBox_SensorTypes.Location = new System.Drawing.Point(302, 150);
            this.groupBox_SensorTypes.Name = "groupBox_SensorTypes";
            this.groupBox_SensorTypes.Size = new System.Drawing.Size(242, 193);
            this.groupBox_SensorTypes.TabIndex = 165;
            this.groupBox_SensorTypes.TabStop = false;
            this.groupBox_SensorTypes.Text = "遥感数据类型";
            // 
            // checkBox_UV
            // 
            this.checkBox_UV.AutoSize = true;
            this.checkBox_UV.Location = new System.Drawing.Point(38, 28);
            this.checkBox_UV.Name = "checkBox_UV";
            this.checkBox_UV.Size = new System.Drawing.Size(48, 16);
            this.checkBox_UV.TabIndex = 36;
            this.checkBox_UV.Text = "紫外";
            this.checkBox_UV.UseVisualStyleBackColor = true;
            // 
            // checkBox1_TIR
            // 
            this.checkBox1_TIR.AutoSize = true;
            this.checkBox1_TIR.Location = new System.Drawing.Point(143, 28);
            this.checkBox1_TIR.Name = "checkBox1_TIR";
            this.checkBox1_TIR.Size = new System.Drawing.Size(60, 16);
            this.checkBox1_TIR.TabIndex = 69;
            this.checkBox1_TIR.Text = "热红外";
            this.checkBox1_TIR.UseVisualStyleBackColor = true;
            // 
            // checkBox_LasFlu
            // 
            this.checkBox_LasFlu.AutoSize = true;
            this.checkBox_LasFlu.Location = new System.Drawing.Point(38, 56);
            this.checkBox_LasFlu.Name = "checkBox_LasFlu";
            this.checkBox_LasFlu.Size = new System.Drawing.Size(72, 16);
            this.checkBox_LasFlu.TabIndex = 37;
            this.checkBox_LasFlu.Text = "激光荧光";
            this.checkBox_LasFlu.UseVisualStyleBackColor = true;
            // 
            // checkBox_VIS
            // 
            this.checkBox_VIS.AutoSize = true;
            this.checkBox_VIS.Location = new System.Drawing.Point(38, 84);
            this.checkBox_VIS.Name = "checkBox_VIS";
            this.checkBox_VIS.Size = new System.Drawing.Size(60, 16);
            this.checkBox_VIS.TabIndex = 59;
            this.checkBox_VIS.Text = "可见光";
            this.checkBox_VIS.UseVisualStyleBackColor = true;
            // 
            // checkBox_HypSpe
            // 
            this.checkBox_HypSpe.AutoSize = true;
            this.checkBox_HypSpe.Location = new System.Drawing.Point(143, 168);
            this.checkBox_HypSpe.Name = "checkBox_HypSpe";
            this.checkBox_HypSpe.Size = new System.Drawing.Size(60, 16);
            this.checkBox_HypSpe.TabIndex = 67;
            this.checkBox_HypSpe.Text = "高光谱";
            this.checkBox_HypSpe.UseVisualStyleBackColor = true;
            // 
            // checkBox_NIR
            // 
            this.checkBox_NIR.AutoSize = true;
            this.checkBox_NIR.Location = new System.Drawing.Point(38, 112);
            this.checkBox_NIR.Name = "checkBox_NIR";
            this.checkBox_NIR.Size = new System.Drawing.Size(60, 16);
            this.checkBox_NIR.TabIndex = 60;
            this.checkBox_NIR.Text = "近红外";
            this.checkBox_NIR.UseVisualStyleBackColor = true;
            // 
            // checkBox_SARL
            // 
            this.checkBox_SARL.AutoSize = true;
            this.checkBox_SARL.Location = new System.Drawing.Point(143, 140);
            this.checkBox_SARL.Name = "checkBox_SARL";
            this.checkBox_SARL.Size = new System.Drawing.Size(54, 16);
            this.checkBox_SARL.TabIndex = 66;
            this.checkBox_SARL.Text = "SAR_L";
            this.checkBox_SARL.UseVisualStyleBackColor = true;
            // 
            // checkBox_SIR
            // 
            this.checkBox_SIR.AutoSize = true;
            this.checkBox_SIR.Location = new System.Drawing.Point(38, 140);
            this.checkBox_SIR.Name = "checkBox_SIR";
            this.checkBox_SIR.Size = new System.Drawing.Size(60, 16);
            this.checkBox_SIR.TabIndex = 61;
            this.checkBox_SIR.Text = "短红外";
            this.checkBox_SIR.UseVisualStyleBackColor = true;
            // 
            // checkBox_SARS
            // 
            this.checkBox_SARS.AutoSize = true;
            this.checkBox_SARS.Location = new System.Drawing.Point(143, 112);
            this.checkBox_SARS.Name = "checkBox_SARS";
            this.checkBox_SARS.Size = new System.Drawing.Size(54, 16);
            this.checkBox_SARS.TabIndex = 65;
            this.checkBox_SARS.Text = "SAR_S";
            this.checkBox_SARS.UseVisualStyleBackColor = true;
            // 
            // checkBox_SARC
            // 
            this.checkBox_SARC.AutoSize = true;
            this.checkBox_SARC.Location = new System.Drawing.Point(143, 84);
            this.checkBox_SARC.Name = "checkBox_SARC";
            this.checkBox_SARC.Size = new System.Drawing.Size(54, 16);
            this.checkBox_SARC.TabIndex = 64;
            this.checkBox_SARC.Text = "SAR_C";
            this.checkBox_SARC.UseVisualStyleBackColor = true;
            // 
            // checkBox_MIR
            // 
            this.checkBox_MIR.AutoSize = true;
            this.checkBox_MIR.Location = new System.Drawing.Point(38, 168);
            this.checkBox_MIR.Name = "checkBox_MIR";
            this.checkBox_MIR.Size = new System.Drawing.Size(60, 16);
            this.checkBox_MIR.TabIndex = 62;
            this.checkBox_MIR.Text = "中红外";
            this.checkBox_MIR.UseVisualStyleBackColor = true;
            // 
            // checkBox_SARX
            // 
            this.checkBox_SARX.AutoSize = true;
            this.checkBox_SARX.Location = new System.Drawing.Point(143, 56);
            this.checkBox_SARX.Name = "checkBox_SARX";
            this.checkBox_SARX.Size = new System.Drawing.Size(54, 16);
            this.checkBox_SARX.TabIndex = 63;
            this.checkBox_SARX.Text = "SAR_X";
            this.checkBox_SARX.UseVisualStyleBackColor = true;
            // 
            // comboBox_DisaType
            // 
            this.comboBox_DisaType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_DisaType.FormattingEnabled = true;
            this.comboBox_DisaType.Location = new System.Drawing.Point(380, 105);
            this.comboBox_DisaType.Name = "comboBox_DisaType";
            this.comboBox_DisaType.Size = new System.Drawing.Size(154, 20);
            this.comboBox_DisaType.TabIndex = 164;
            // 
            // ButtonReturn
            // 
            this.ButtonReturn.Location = new System.Drawing.Point(470, 352);
            this.ButtonReturn.Name = "ButtonReturn";
            this.ButtonReturn.Size = new System.Drawing.Size(75, 23);
            this.ButtonReturn.TabIndex = 163;
            this.ButtonReturn.Text = "返回";
            this.ButtonReturn.UseVisualStyleBackColor = true;
            // 
            // ButtonGenerate
            // 
            this.ButtonGenerate.Location = new System.Drawing.Point(305, 352);
            this.ButtonGenerate.Name = "ButtonGenerate";
            this.ButtonGenerate.Size = new System.Drawing.Size(75, 23);
            this.ButtonGenerate.TabIndex = 162;
            this.ButtonGenerate.Text = "任务生成";
            this.ButtonGenerate.UseVisualStyleBackColor = true;
            this.ButtonGenerate.Click += new System.EventHandler(this.ButtonGenerate_Click);
            // 
            // txtTaskName
            // 
            this.txtTaskName.Location = new System.Drawing.Point(120, 54);
            this.txtTaskName.Name = "txtTaskName";
            this.txtTaskName.Size = new System.Drawing.Size(154, 21);
            this.txtTaskName.TabIndex = 161;
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.Location = new System.Drawing.Point(387, 352);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(75, 23);
            this.ButtonAdd.TabIndex = 160;
            this.ButtonAdd.Text = "添加";
            this.ButtonAdd.UseVisualStyleBackColor = true;
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // txtObsFre
            // 
            this.txtObsFre.Location = new System.Drawing.Point(120, 187);
            this.txtObsFre.Name = "txtObsFre";
            this.txtObsFre.Size = new System.Drawing.Size(154, 21);
            this.txtObsFre.TabIndex = 158;
            // 
            // txtResTime
            // 
            this.txtResTime.Location = new System.Drawing.Point(380, 60);
            this.txtResTime.Name = "txtResTime";
            this.txtResTime.Size = new System.Drawing.Size(154, 21);
            this.txtResTime.TabIndex = 157;
            // 
            // txtSpaRes
            // 
            this.txtSpaRes.Location = new System.Drawing.Point(145, 142);
            this.txtSpaRes.Name = "txtSpaRes";
            this.txtSpaRes.Size = new System.Drawing.Size(129, 21);
            this.txtSpaRes.TabIndex = 156;
            // 
            // txtPriority
            // 
            this.txtPriority.Location = new System.Drawing.Point(120, 97);
            this.txtPriority.Name = "txtPriority";
            this.txtPriority.Size = new System.Drawing.Size(154, 21);
            this.txtPriority.TabIndex = 155;
            // 
            // dateEndTime
            // 
            this.dateEndTime.Checked = false;
            this.dateEndTime.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.dateEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateEndTime.Location = new System.Drawing.Point(120, 268);
            this.dateEndTime.Name = "dateEndTime";
            this.dateEndTime.ShowCheckBox = true;
            this.dateEndTime.Size = new System.Drawing.Size(154, 21);
            this.dateEndTime.TabIndex = 154;
            // 
            // dateStartTime
            // 
            this.dateStartTime.Checked = false;
            this.dateStartTime.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.dateStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateStartTime.Location = new System.Drawing.Point(120, 229);
            this.dateStartTime.Name = "dateStartTime";
            this.dateStartTime.ShowCheckBox = true;
            this.dateStartTime.Size = new System.Drawing.Size(154, 21);
            this.dateStartTime.TabIndex = 153;
            // 
            // txtTaskID
            // 
            this.txtTaskID.Enabled = false;
            this.txtTaskID.Location = new System.Drawing.Point(120, 11);
            this.txtTaskID.Name = "txtTaskID";
            this.txtTaskID.Size = new System.Drawing.Size(154, 21);
            this.txtTaskID.TabIndex = 152;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(38, 145);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(101, 12);
            this.label11.TabIndex = 151;
            this.label11.Text = "最大空间分辨率：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(38, 191);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 150;
            this.label9.Text = "观测频率：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(309, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 149;
            this.label8.Text = "响应时间：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(38, 271);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 148;
            this.label7.Text = "结束时间：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 234);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 147;
            this.label6.Text = "开始时间：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(309, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 146;
            this.label5.Text = "灾害类型：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 145;
            this.label4.Text = "任务优先级：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 144;
            this.label2.Text = "事件名称：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 143;
            this.label1.Text = "任务编号：";
            // 
            // groupBox_ObsRegion
            // 
            this.groupBox_ObsRegion.Controls.Add(this.label3);
            this.groupBox_ObsRegion.Controls.Add(this.txtTaskRegion);
            this.groupBox_ObsRegion.ForeColor = System.Drawing.Color.Red;
            this.groupBox_ObsRegion.Location = new System.Drawing.Point(32, 298);
            this.groupBox_ObsRegion.Name = "groupBox_ObsRegion";
            this.groupBox_ObsRegion.Size = new System.Drawing.Size(255, 82);
            this.groupBox_ObsRegion.TabIndex = 169;
            this.groupBox_ObsRegion.TabStop = false;
            this.groupBox_ObsRegion.Text = "观测区域范围";
            // 
            // txtTaskRegion
            // 
            this.txtTaskRegion.Location = new System.Drawing.Point(20, 27);
            this.txtTaskRegion.Name = "txtTaskRegion";
            this.txtTaskRegion.Size = new System.Drawing.Size(213, 21);
            this.txtTaskRegion.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 12);
            this.label3.TabIndex = 125;
            this.label3.Text = "输入格式：Lon,Lat;";
            // 
            // TaskGenerate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 425);
            this.Controls.Add(this.groupBox_ObsRegion);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dateOccurTime);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox_SensorTypes);
            this.Controls.Add(this.comboBox_DisaType);
            this.Controls.Add(this.ButtonReturn);
            this.Controls.Add(this.ButtonGenerate);
            this.Controls.Add(this.txtTaskName);
            this.Controls.Add(this.ButtonAdd);
            this.Controls.Add(this.txtObsFre);
            this.Controls.Add(this.txtResTime);
            this.Controls.Add(this.txtSpaRes);
            this.Controls.Add(this.txtPriority);
            this.Controls.Add(this.dateEndTime);
            this.Controls.Add(this.dateStartTime);
            this.Controls.Add(this.txtTaskID);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "TaskGenerate";
            this.Text = "TaskGenerate";
            this.Load += new System.EventHandler(this.TaskGenerate_Load);
            this.groupBox_SensorTypes.ResumeLayout(false);
            this.groupBox_SensorTypes.PerformLayout();
            this.groupBox_ObsRegion.ResumeLayout(false);
            this.groupBox_ObsRegion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker dateOccurTime;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox_SensorTypes;
        private System.Windows.Forms.CheckBox checkBox_UV;
        private System.Windows.Forms.CheckBox checkBox1_TIR;
        private System.Windows.Forms.CheckBox checkBox_LasFlu;
        private System.Windows.Forms.CheckBox checkBox_VIS;
        private System.Windows.Forms.CheckBox checkBox_HypSpe;
        private System.Windows.Forms.CheckBox checkBox_NIR;
        private System.Windows.Forms.CheckBox checkBox_SARL;
        private System.Windows.Forms.CheckBox checkBox_SIR;
        private System.Windows.Forms.CheckBox checkBox_SARS;
        private System.Windows.Forms.CheckBox checkBox_SARC;
        private System.Windows.Forms.CheckBox checkBox_MIR;
        private System.Windows.Forms.CheckBox checkBox_SARX;
        private System.Windows.Forms.ComboBox comboBox_DisaType;
        private System.Windows.Forms.Button ButtonReturn;
        private System.Windows.Forms.Button ButtonGenerate;
        private System.Windows.Forms.TextBox txtTaskName;
        private System.Windows.Forms.Button ButtonAdd;
        private System.Windows.Forms.TextBox txtObsFre;
        private System.Windows.Forms.TextBox txtResTime;
        private System.Windows.Forms.TextBox txtSpaRes;
        private System.Windows.Forms.TextBox txtPriority;
        private System.Windows.Forms.DateTimePicker dateEndTime;
        private System.Windows.Forms.DateTimePicker dateStartTime;
        private System.Windows.Forms.TextBox txtTaskID;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox_ObsRegion;
        private System.Windows.Forms.TextBox txtTaskRegion;
        private System.Windows.Forms.Label label3;
    }
}