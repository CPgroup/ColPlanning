using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CoScheduling.Main.TaskRequirement
{
    public partial class UAVModify : Form
    {
        string uav_id = "";
        public UAVModify(string uavid)
        {
            uav_id = uavid;
            InitializeComponent();
        }
        public UAVModify()
        {
            InitializeComponent();
        }
        CoScheduling.Core.Model.UAV_RANGE uav_range = new Core.Model.UAV_RANGE();
        CoScheduling.Core.DAL.UAV_RANGE dal_uav_range = new Core.DAL.UAV_RANGE();

        private void UAVModify_Load(object sender, EventArgs e)
        {
            //根据无人机id获取无人机实体
            uav_range = dal_uav_range.GetModel(Convert.ToDecimal(uav_id));
            //根据获取的无人机实体，给界面控件赋值
            (this.txtPlatformID.Text) = uav_range.PLATFORM_ID.ToString();
            this.txtPlatformName.Text = uav_range.PLATFORM_Name;
            (this.txtNumberOfSensor.Text) = uav_range.NumberOfSensor.ToString();
            (this.txtCruisingVelocity.Text) = uav_range.CruisingVelocity.ToString();
            this.txtRollVelocity.Text = uav_range.RollVelocity.ToString();
            (this.txtPitchVelocity.Text) = uav_range.PitchVelocity.ToString();
            (this.txtMaxVelocity.Text) = uav_range.MaxVelocity.ToString();
            (this.txtMinVolocity.Text) = uav_range.MinVelocity.ToString();
            (this.txtAcceleration.Text) = uav_range.Acceleration.ToString();
            (this.txtCruisingTime.Text) = uav_range.CruisingTime.ToString();
            (this.txtMaxSlewAngle.Text) = uav_range.MaxSlewAngle.ToString();
            (this.txtMinSlewAngle.Text) = uav_range.MinSlewAngle.ToString();
            (this.txtCruisAltitude.Text) = uav_range.CruisingAltitude.ToString();
            (this.txtMaxAltitude.Text) = uav_range.MaxAltitude.ToString();
            (this.txtMaxDistance.Text) = uav_range.MaxDistance.ToString();
            (this.txtMinTurnRadius.Text) = uav_range.MinTurningRadius.ToString();
            (this.txtPayLoad.Text) = uav_range.PayLoad.ToString();
            (this.txtMaxLoad.Text) = uav_range.MaxLoad.ToString();
            (this.txtBaseID.Text) = uav_range.Base_ID.ToString();
            

        }

        private void ButtonModify_Click(object sender, EventArgs e)
        {
            //给UAV实体赋值
            try
            {
                uav_range.PLATFORM_ID = Convert.ToDecimal(this.txtPlatformID.Text);
                uav_range.PLATFORM_Name = this.txtPlatformName.Text;
                uav_range.NumberOfSensor = Convert.ToDecimal(this.txtNumberOfSensor.Text);
                uav_range.CruisingAltitude = Convert.ToDecimal(this.txtCruisAltitude.Text);
                uav_range.RollVelocity = Convert.ToDecimal(this.txtRollVelocity.Text);
                uav_range.PitchVelocity = Convert.ToDecimal(this.txtPitchVelocity.Text);
                uav_range.MaxVelocity = Convert.ToDecimal(this.txtMaxVelocity.Text);
                uav_range.MinVelocity = Convert.ToDecimal(this.txtMinVolocity.Text);
                uav_range.Acceleration = Convert.ToDecimal(this.txtAcceleration.Text);
                uav_range.CruisingTime = Convert.ToDecimal(this.txtCruisingTime.Text);
                uav_range.MaxSlewAngle = Convert.ToDecimal(this.txtMaxSlewAngle.Text);
                uav_range.MinSlewAngle = Convert.ToDecimal(this.txtMinSlewAngle.Text);
                uav_range.CruisingAltitude = Convert.ToDecimal(this.txtMaxAltitude.Text);
                uav_range.MaxAltitude = Convert.ToDecimal(this.txtMaxAltitude.Text);
                uav_range.MaxDistance = Convert.ToDecimal(this.txtMaxDistance.Text);
                uav_range.MinTurningRadius = Convert.ToDecimal(this.txtMinTurnRadius.Text);
                uav_range.PayLoad = Convert.ToDecimal(this.txtPayLoad.Text);
                uav_range.MaxLoad = Convert.ToDecimal(this.txtMaxLoad.Text);
                uav_range.Base_ID = Convert.ToDecimal(this.txtBaseID.Text);
            }
            catch (System.Exception ex)
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
                dal_uav_range.Update(uav_range);
                MessageBox.Show("无人机信息修改成功！");
                //回传给父窗体消息
                DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.ToString());
            }
        }





    }
}
