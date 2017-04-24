//----------------------------------------------------------------------------
//创建标识：李佳霖
// 创建描述: 飞艇修改窗体类
// 创建时间:2017.4.19
// 文件版本:1.0
// 功能描述: 对数据库中的飞艇数据进行修改
// 修改标识: 
// 修改描述: 
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CoScheduling.Main.AEROSHIP
{
    public partial class AEROSHIPModify : Form
    {
        string aeroship_id = "";
        public AEROSHIPModify(string aeroshipid)
        {
            aeroship_id = aeroshipid;
            InitializeComponent();
        }
        public AEROSHIPModify()
        {
            InitializeComponent();
        }
        CoScheduling.Core.Model.AEROSHIP_RANGE aeroship_range = new Core.Model.AEROSHIP_RANGE();
        CoScheduling.Core.DAL.AEROSHIP_RANGE dal_aeroship_range = new Core.DAL.AEROSHIP_RANGE();

        private void AEROSHIPModify_Load(object sender, EventArgs e)
        {
            //根据飞艇id获取无人机实体
            aeroship_range = dal_aeroship_range.GetModel(Convert.ToDecimal(aeroship_id));
            //根据获取的飞艇实体，给界面控件赋值
            (this.txtPlatformID.Text) = aeroship_range.PLATFORM_ID.ToString();
            this.txtPlatformName.Text = aeroship_range.PLATFORM_Name;
            (this.txtNumberOfSensor.Text) = aeroship_range.NumberOfSensor.ToString();
            (this.txtCruisingVelocity.Text) = aeroship_range.CruisingVelocity.ToString();
            (this.txtPitchVelocity.Text) = aeroship_range.PitchVelocity.ToString();
            (this.txtMaxVelocity.Text) = aeroship_range.MaxVelocity.ToString();
            (this.txtMinVolocity.Text) = aeroship_range.MinVelocity.ToString();
            (this.txtAcceleration.Text) = aeroship_range.Acceleration.ToString();
            (this.txtCruisingTime.Text) = aeroship_range.CruisingTime.ToString();
            (this.txtCruisAltitude.Text) = aeroship_range.CruisingAltitude.ToString();

            (this.txtMaxAltitude.Text) = aeroship_range.MaxAltitude.ToString();
            (this.txtMaxDistance.Text) = aeroship_range.MaxDistance.ToString();
            (this.txtPayLoad.Text) = aeroship_range.PayLoad.ToString();
            (this.txtMaxLoad.Text) = aeroship_range.MaxLoad.ToString();
            
        }

        private void ButtonModify_Click(object sender, EventArgs e)
        {
            //给UAV实体赋值
            try
            {
                aeroship_range.PLATFORM_ID = Convert.ToDecimal(this.txtPlatformID.Text);
                aeroship_range.PLATFORM_Name = this.txtPlatformName.Text;
                aeroship_range.NumberOfSensor = Convert.ToDecimal(this.txtNumberOfSensor.Text);
                aeroship_range.CruisingAltitude = Convert.ToDecimal(this.txtCruisAltitude.Text);
                aeroship_range.PitchVelocity = Convert.ToDecimal(this.txtPitchVelocity.Text);
                aeroship_range.MaxVelocity = Convert.ToDecimal(this.txtMaxVelocity.Text);
                aeroship_range.MinVelocity = Convert.ToDecimal(this.txtMinVolocity.Text);
                aeroship_range.Acceleration = Convert.ToDecimal(this.txtAcceleration.Text);
                aeroship_range.CruisingTime = Convert.ToDecimal(this.txtCruisingTime.Text);
                aeroship_range.CruisingAltitude = Convert.ToDecimal(this.txtMaxAltitude.Text);

                aeroship_range.MaxAltitude = Convert.ToDecimal(this.txtMaxAltitude.Text);
                aeroship_range.MaxDistance = Convert.ToDecimal(this.txtMaxDistance.Text);
                aeroship_range.PayLoad = Convert.ToDecimal(this.txtPayLoad.Text);
                aeroship_range.MaxLoad = Convert.ToDecimal(this.txtMaxLoad.Text);
                
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
                dal_aeroship_range.Update(aeroship_range);
                MessageBox.Show("飞艇信息修改成功！");
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
