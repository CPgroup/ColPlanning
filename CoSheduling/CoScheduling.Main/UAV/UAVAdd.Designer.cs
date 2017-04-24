namespace CoScheduling.Main.UAV
{
    partial class UAVAdd
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
            this.txtPlatformName = new System.Windows.Forms.TextBox();
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.txtPitchVelocity = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAcceleration = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtMaxVelocity = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtMinVolocity = new System.Windows.Forms.TextBox();
            this.txtRollVelocity = new System.Windows.Forms.TextBox();
            this.txtCruisingVelocity = new System.Windows.Forms.TextBox();
            this.txtNumberOfSensor = new System.Windows.Forms.TextBox();
            this.txtPlatformID = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCruisingTime = new System.Windows.Forms.TextBox();
            this.txtMinTurnRadius = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBaseID = new System.Windows.Forms.TextBox();
            this.txtMinSlewAngle = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPayLoad = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtMaxDistance = new System.Windows.Forms.TextBox();
            this.txtMaxLoad = new System.Windows.Forms.TextBox();
            this.txtMaxAltitude = new System.Windows.Forms.TextBox();
            this.txtCruisAltitude = new System.Windows.Forms.TextBox();
            this.txtMaxSlewAngle = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ButtonReturn
            // 
            this.ButtonReturn.Location = new System.Drawing.Point(454, 400);
            this.ButtonReturn.Name = "ButtonReturn";
            this.ButtonReturn.Size = new System.Drawing.Size(75, 23);
            this.ButtonReturn.TabIndex = 160;
            this.ButtonReturn.Text = "返回";
            this.ButtonReturn.UseVisualStyleBackColor = true;
            // 
            // ButtonReset
            // 
            this.ButtonReset.Location = new System.Drawing.Point(372, 400);
            this.ButtonReset.Name = "ButtonReset";
            this.ButtonReset.Size = new System.Drawing.Size(75, 23);
            this.ButtonReset.TabIndex = 159;
            this.ButtonReset.Text = "重置";
            this.ButtonReset.UseVisualStyleBackColor = true;
            this.ButtonReset.Click += new System.EventHandler(this.ButtonReset_Click);
            // 
            // txtPlatformName
            // 
            this.txtPlatformName.Location = new System.Drawing.Point(107, 61);
            this.txtPlatformName.Name = "txtPlatformName";
            this.txtPlatformName.Size = new System.Drawing.Size(154, 21);
            this.txtPlatformName.TabIndex = 158;
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.Location = new System.Drawing.Point(291, 400);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(75, 23);
            this.ButtonAdd.TabIndex = 157;
            this.ButtonAdd.Text = "添加";
            this.ButtonAdd.UseVisualStyleBackColor = true;
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // txtPitchVelocity
            // 
            this.txtPitchVelocity.Location = new System.Drawing.Point(375, 19);
            this.txtPitchVelocity.Name = "txtPitchVelocity";
            this.txtPitchVelocity.Size = new System.Drawing.Size(154, 21);
            this.txtPitchVelocity.TabIndex = 21;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(25, 358);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 28;
            this.label14.Text = "加速度：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(293, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 25;
            this.label3.Text = "俯仰速度：";
            // 
            // txtAcceleration
            // 
            this.txtAcceleration.Location = new System.Drawing.Point(107, 355);
            this.txtAcceleration.Name = "txtAcceleration";
            this.txtAcceleration.Size = new System.Drawing.Size(154, 21);
            this.txtAcceleration.TabIndex = 24;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(25, 235);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 12);
            this.label13.TabIndex = 27;
            this.label13.Text = "最小速度：";
            // 
            // txtMaxVelocity
            // 
            this.txtMaxVelocity.Location = new System.Drawing.Point(107, 187);
            this.txtMaxVelocity.Name = "txtMaxVelocity";
            this.txtMaxVelocity.Size = new System.Drawing.Size(154, 21);
            this.txtMaxVelocity.TabIndex = 22;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(25, 190);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 26;
            this.label12.Text = "最大速度：";
            // 
            // txtMinVolocity
            // 
            this.txtMinVolocity.Location = new System.Drawing.Point(107, 229);
            this.txtMinVolocity.Name = "txtMinVolocity";
            this.txtMinVolocity.Size = new System.Drawing.Size(154, 21);
            this.txtMinVolocity.TabIndex = 23;
            // 
            // txtRollVelocity
            // 
            this.txtRollVelocity.Location = new System.Drawing.Point(107, 397);
            this.txtRollVelocity.Name = "txtRollVelocity";
            this.txtRollVelocity.Size = new System.Drawing.Size(154, 21);
            this.txtRollVelocity.TabIndex = 155;
            // 
            // txtCruisingVelocity
            // 
            this.txtCruisingVelocity.Location = new System.Drawing.Point(107, 145);
            this.txtCruisingVelocity.Name = "txtCruisingVelocity";
            this.txtCruisingVelocity.Size = new System.Drawing.Size(154, 21);
            this.txtCruisingVelocity.TabIndex = 153;
            // 
            // txtNumberOfSensor
            // 
            this.txtNumberOfSensor.Location = new System.Drawing.Point(107, 103);
            this.txtNumberOfSensor.Name = "txtNumberOfSensor";
            this.txtNumberOfSensor.Size = new System.Drawing.Size(154, 21);
            this.txtNumberOfSensor.TabIndex = 152;
            // 
            // txtPlatformID
            // 
            this.txtPlatformID.Location = new System.Drawing.Point(107, 19);
            this.txtPlatformID.Name = "txtPlatformID";
            this.txtPlatformID.Size = new System.Drawing.Size(154, 21);
            this.txtPlatformID.TabIndex = 149;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(25, 148);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 148;
            this.label11.Text = "巡航速度：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 400);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 147;
            this.label9.Text = "翻转速度：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 142;
            this.label4.Text = "传感器数量：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 141;
            this.label2.Text = "平台名称：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 140;
            this.label1.Text = "平台编号：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(25, 274);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 162;
            this.label10.Text = "巡航时间：";
            // 
            // txtCruisingTime
            // 
            this.txtCruisingTime.Location = new System.Drawing.Point(107, 271);
            this.txtCruisingTime.Name = "txtCruisingTime";
            this.txtCruisingTime.Size = new System.Drawing.Size(154, 21);
            this.txtCruisingTime.TabIndex = 161;
            // 
            // txtMinTurnRadius
            // 
            this.txtMinTurnRadius.Location = new System.Drawing.Point(379, 232);
            this.txtMinTurnRadius.Name = "txtMinTurnRadius";
            this.txtMinTurnRadius.Size = new System.Drawing.Size(150, 21);
            this.txtMinTurnRadius.TabIndex = 163;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(293, 358);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 170;
            this.label6.Text = "基地编号：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(293, 238);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 12);
            this.label7.TabIndex = 167;
            this.label7.Text = "最小转弯半径：";
            // 
            // txtBaseID
            // 
            this.txtBaseID.Location = new System.Drawing.Point(375, 355);
            this.txtBaseID.Name = "txtBaseID";
            this.txtBaseID.Size = new System.Drawing.Size(154, 21);
            this.txtBaseID.TabIndex = 166;
            // 
            // txtMinSlewAngle
            // 
            this.txtMinSlewAngle.Location = new System.Drawing.Point(375, 103);
            this.txtMinSlewAngle.Name = "txtMinSlewAngle";
            this.txtMinSlewAngle.Size = new System.Drawing.Size(154, 21);
            this.txtMinSlewAngle.TabIndex = 180;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(293, 316);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 169;
            this.label8.Text = "最大载荷：";
            // 
            // txtPayLoad
            // 
            this.txtPayLoad.Location = new System.Drawing.Point(375, 271);
            this.txtPayLoad.Name = "txtPayLoad";
            this.txtPayLoad.Size = new System.Drawing.Size(154, 21);
            this.txtPayLoad.TabIndex = 164;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(293, 274);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 12);
            this.label15.TabIndex = 168;
            this.label15.Text = "有效载荷：";
            // 
            // txtMaxDistance
            // 
            this.txtMaxDistance.Location = new System.Drawing.Point(375, 193);
            this.txtMaxDistance.Name = "txtMaxDistance";
            this.txtMaxDistance.Size = new System.Drawing.Size(154, 21);
            this.txtMaxDistance.TabIndex = 179;
            // 
            // txtMaxLoad
            // 
            this.txtMaxLoad.Location = new System.Drawing.Point(375, 313);
            this.txtMaxLoad.Name = "txtMaxLoad";
            this.txtMaxLoad.Size = new System.Drawing.Size(154, 21);
            this.txtMaxLoad.TabIndex = 165;
            // 
            // txtMaxAltitude
            // 
            this.txtMaxAltitude.Location = new System.Drawing.Point(107, 313);
            this.txtMaxAltitude.Name = "txtMaxAltitude";
            this.txtMaxAltitude.Size = new System.Drawing.Size(154, 21);
            this.txtMaxAltitude.TabIndex = 178;
            // 
            // txtCruisAltitude
            // 
            this.txtCruisAltitude.Location = new System.Drawing.Point(375, 145);
            this.txtCruisAltitude.Name = "txtCruisAltitude";
            this.txtCruisAltitude.Size = new System.Drawing.Size(154, 21);
            this.txtCruisAltitude.TabIndex = 177;
            // 
            // txtMaxSlewAngle
            // 
            this.txtMaxSlewAngle.Location = new System.Drawing.Point(375, 62);
            this.txtMaxSlewAngle.Name = "txtMaxSlewAngle";
            this.txtMaxSlewAngle.Size = new System.Drawing.Size(154, 21);
            this.txtMaxSlewAngle.TabIndex = 176;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(25, 316);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 12);
            this.label16.TabIndex = 175;
            this.label16.Text = "最大高度：";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(293, 196);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(65, 12);
            this.label17.TabIndex = 174;
            this.label17.Text = "最大距离：";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(293, 154);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(65, 12);
            this.label18.TabIndex = 173;
            this.label18.Text = "巡航高度：";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(293, 111);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(65, 12);
            this.label19.TabIndex = 172;
            this.label19.Text = "最小摆角：";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(293, 65);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(65, 12);
            this.label20.TabIndex = 171;
            this.label20.Text = "最大摆角：";
            // 
            // UAVAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 457);
            this.Controls.Add(this.txtMinTurnRadius);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtBaseID);
            this.Controls.Add(this.txtMinSlewAngle);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtPayLoad);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtMaxDistance);
            this.Controls.Add(this.txtMaxLoad);
            this.Controls.Add(this.txtMaxAltitude);
            this.Controls.Add(this.txtCruisAltitude);
            this.Controls.Add(this.txtMaxSlewAngle);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtCruisingTime);
            this.Controls.Add(this.txtPitchVelocity);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.ButtonReturn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ButtonReset);
            this.Controls.Add(this.txtAcceleration);
            this.Controls.Add(this.txtPlatformName);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.ButtonAdd);
            this.Controls.Add(this.txtMaxVelocity);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtRollVelocity);
            this.Controls.Add(this.txtMinVolocity);
            this.Controls.Add(this.txtCruisingVelocity);
            this.Controls.Add(this.txtNumberOfSensor);
            this.Controls.Add(this.txtPlatformID);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UAVAdd";
            this.Text = "无人机添加";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonReturn;
        private System.Windows.Forms.Button ButtonReset;
        private System.Windows.Forms.TextBox txtPlatformName;
        private System.Windows.Forms.Button ButtonAdd;
        private System.Windows.Forms.TextBox txtPitchVelocity;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAcceleration;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtMaxVelocity;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtMinVolocity;
        private System.Windows.Forms.TextBox txtRollVelocity;
        private System.Windows.Forms.TextBox txtCruisingVelocity;
        private System.Windows.Forms.TextBox txtNumberOfSensor;
        private System.Windows.Forms.TextBox txtPlatformID;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCruisingTime;
        private System.Windows.Forms.TextBox txtMinTurnRadius;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBaseID;
        private System.Windows.Forms.TextBox txtMinSlewAngle;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPayLoad;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtMaxDistance;
        private System.Windows.Forms.TextBox txtMaxLoad;
        private System.Windows.Forms.TextBox txtMaxAltitude;
        private System.Windows.Forms.TextBox txtCruisAltitude;
        private System.Windows.Forms.TextBox txtMaxSlewAngle;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
    }
}