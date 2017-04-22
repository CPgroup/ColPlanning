//----------------------------------------------------------------------------
//创建标识：李佳霖
// 创建描述: 飞艇添加窗体类
// 创建时间:2017.4.19
// 文件版本:1.0
// 功能描述: 对数据库中的飞艇数据进行添加
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
    public partial class AEROSHIPAdd : Form
    {
        public AEROSHIPAdd()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 飞艇添加按钮点击操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            //飞艇实体类，访问类
            CoScheduling.Core.Model.AEROSHIP_RANGE aeroship_range = new Core.Model.AEROSHIP_RANGE();
            CoScheduling.Core.DAL.AEROSHIP_RANGE dal_aeroship_range = new Core.DAL.AEROSHIP_RANGE();

            //给飞艇实体赋值
            try
            {
                aeroship_range.PLATFORM_ID = Convert.ToDecimal(this.txtPlatformID.Text);
                aeroship_range.PLATFORM_Name = this.txtPlatformName.Text;
                aeroship_range.NumberOfSensor = Convert.ToDecimal(this.txtNumberOfSensor.Text);
                aeroship_range.CruisingVelocity = Convert.ToDecimal(this.txtCruisingVelocity.Text);
                aeroship_range.PitchVelocity = Convert.ToDecimal(this.txtPitchVelocity.Text);
                aeroship_range.MaxVelocity = Convert.ToDecimal(this.txtMaxVelocity.Text);
                aeroship_range.MinVelocity = Convert.ToDecimal(this.txtMinVolocity.Text);
                aeroship_range.Acceleration = Convert.ToDecimal(this.txtAcceleration.Text);
                aeroship_range.CruisingTime = Convert.ToDecimal(this.txtCruisingTime.Text);
                aeroship_range.CruisingAltitude = Convert.ToDecimal(this.txtCruisAltitude.Text);
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
                dal_aeroship_range.Add(aeroship_range);
                MessageBox.Show("飞艇添加成功！");
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
            (this.txtPlatformID.Text) = "200001";
            this.txtPlatformName.Text = "No.2 AEROSHIP";
            (this.txtNumberOfSensor.Text) = "1";
            (this.txtCruisingVelocity.Text) = "24";
            (this.txtPitchVelocity.Text) = "5";
            (this.txtMaxVelocity.Text) = "30";
            (this.txtMinVolocity.Text) = "10";
            (this.txtAcceleration.Text) = "5";
            (this.txtCruisingTime.Text) = "30";
            (this.txtCruisAltitude.Text) = "200";
            (this.txtMaxAltitude.Text) = "500";
            (this.txtMaxDistance.Text) = "12";
            (this.txtPayLoad.Text) = "10";
            (this.txtMaxLoad.Text) = "20";
        }

        private void ButtonReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
