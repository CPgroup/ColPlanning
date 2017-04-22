using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CoScheduling.Main.UAV
{
    public partial class UAVAdd : Form
    {
        public UAVAdd()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 无人机添加按钮点击操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            //无人机实体类，访问类
            CoScheduling.Core.Model.UAV_RANGE uav_range = new Core.Model.UAV_RANGE();
            CoScheduling.Core.DAL.UAV_RANGE dal_uav_range = new Core.DAL.UAV_RANGE();

            //给UAV实体赋值
            try
            {
                uav_range.PLATFORM_ID = Convert.ToDecimal(this.txtPlatformID.Text);
                uav_range.PLATFORM_Name = this.txtPlatformName.Text;
                uav_range.NumberOfSensor = Convert.ToDecimal(this.txtNumberOfSensor.Text);
                uav_range.CruisingVelocity = Convert.ToDecimal(this.txtCruisingVelocity.Text);
                uav_range.RollVelocity = Convert.ToDecimal(this.txtRollVelocity.Text);
                uav_range.PitchVelocity = Convert.ToDecimal(this.txtPitchVelocity.Text);
                uav_range.MaxVelocity = Convert.ToDecimal(this.txtMaxVelocity.Text);
                uav_range.MinVelocity = Convert.ToDecimal(this.txtMinVolocity.Text);
                uav_range.Acceleration = Convert.ToDecimal(this.txtAcceleration.Text);
                uav_range.CruisingTime = Convert.ToDecimal(this.txtCruisingTime.Text);
                uav_range.MaxSlewAngle = Convert.ToDecimal(this.txtMaxSlewAngle.Text);
                uav_range.MinSlewAngle = Convert.ToDecimal(this.txtMinSlewAngle.Text);
                uav_range.CruisingAltitude = Convert.ToDecimal(this.txtCruisAltitude.Text);
                uav_range.MaxAltitude = Convert.ToDecimal(this.txtMaxAltitude.Text);
                uav_range.MaxDistance = Convert.ToDecimal(this.txtMaxDistance.Text);
                uav_range.MinTurningRadius = Convert.ToDecimal(this.txtMinTurnRadius.Text);
                uav_range.PayLoad = Convert.ToDecimal(this.txtPayLoad.Text);
                uav_range.MaxLoad = Convert.ToDecimal(this.txtMaxLoad.Text);
                uav_range.Base_ID = Convert.ToDecimal(this.txtBaseID.Text);
            }
            catch(System.Exception ex)
            {
                MessageBox.Show("请输入合法参数！");
                return;
            }
            try
            {
                //检查必填项是否为空
                if (string.IsNullOrEmpty(this.txtPlatformID.Text) || 
                    string.IsNullOrEmpty(this.txtPlatformName.Text) || 
                    string.IsNullOrEmpty(this.txtCruisingVelocity.Text) || 
                    string.IsNullOrEmpty(this.txtCruisingTime.Text))
                {
                    MessageBox.Show("输入信息不完整！");
                    return;
                }
                //添加
                dal_uav_range.Add(uav_range);
                MessageBox.Show("无人机添加成功！");
                //回传给父窗体消息
                DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.ToString());
            }
        }

        //重置按钮操作
        private void ButtonReset_Click(object sender, EventArgs e)
        {
            (this.txtPlatformID.Text)="300002";
            this.txtPlatformName.Text = "No.2UAV";
            (this.txtNumberOfSensor.Text) = "1";
            (this.txtCruisingVelocity.Text) = "24";
            this.txtRollVelocity.Text = "5";
            (this.txtPitchVelocity.Text) = "5";
            (this.txtMaxVelocity.Text) = "30";
            (this.txtMinVolocity.Text) = "10";
            (this.txtAcceleration.Text) = "5";
            (this.txtCruisingTime.Text) = "30";
            (this.txtMaxSlewAngle.Text) = "30";
            (this.txtMinSlewAngle.Text) = "30";
            (this.txtCruisAltitude.Text) = "200";
            (this.txtMaxAltitude.Text) = "500";
            (this.txtMaxDistance.Text) = "12";
            (this.txtMinTurnRadius.Text) = "5";
            (this.txtPayLoad.Text) = "10";
            (this.txtMaxLoad.Text) = "20";
            (this.txtBaseID.Text) = "3";
;        }
    }
}
