using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CoScheduling.Main.Satellite
{
    public partial class SatAdd : Form
    {
        public SatAdd()
        {
            InitializeComponent();
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            //卫星实体类，访问类

            CoScheduling.Core.Model.SATELLITE_RANGE satellite_range = new Core.Model.SATELLITE_RANGE();
            CoScheduling.Core.DAL.SATELLITE_RANGE dal_satellite_range = new Core.DAL.SATELLITE_RANGE();
            //给卫星实体赋值
            try
            {
                //卫星信息
                satellite_range.PLATFORM_ID = Convert.ToDecimal(this.txtPlatformID.Text);
                satellite_range.PLATFORM_NAME = this.txtPlatformName.Text;
                satellite_range.NumberOfSensor = Convert.ToDecimal(this.txtNumberOfSensor.Text);
                satellite_range.LaunchTime = this.dateTimePickerLaunchTime.Value;
                satellite_range.EolTime = this.dateTimePickerEndTime.Value;
                satellite_range.MinSlewAngle = Convert.ToDecimal(this.txtMinSlewAngle.Text);
                satellite_range.MaxSlewAngle = Convert.ToDecimal(this.txtMaxSlewAngle.Text);
                satellite_range.AngularVelocity = Convert.ToDecimal(this.txtAngleVelocity.Text);
                satellite_range.AngularAcceleration = Convert.ToDecimal(this.txtAngleAcceleration.Text);
                //轨道信息
                satellite_range.OrbitClass = this.comboBoxOrbitClass.SelectedItem.ToString();
                satellite_range.OrbitType = this.comboBoxOrbitType.SelectedItem.ToString();
                satellite_range.LongitudeOfGEO = Convert.ToDecimal(this.txtLonGEO.Text);
                satellite_range.Perigee = Convert.ToDecimal(this.txtPerigee.Text);
                satellite_range.Apogee = Convert.ToDecimal(this.txtApogee.Text);
                satellite_range.Period = Convert.ToDecimal(this.txtPeriod.Text);
                
                //社会信息

                satellite_range.SAT_COUNTRY = this.txtSatCountry.Text;
                if (this.comboBoxSatCharter.SelectedItem.ToString() == "是")
                {
                    satellite_range.SAT_CHARTER = 1;
                }
                else
                {
                    satellite_range.SAT_CHARTER = 0;
                }

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
                    string.IsNullOrEmpty(this.txtNumberOfSensor.Text) ||
                    this.dateTimePickerLaunchTime.Value > this.dateTimePickerEndTime.Value||
                    string.IsNullOrEmpty(this.comboBoxOrbitClass.SelectedItem.ToString())||
                    string.IsNullOrEmpty(this.comboBoxOrbitType.SelectedItem.ToString()))
                {
                    MessageBox.Show("输入信息不完整！");
                    return;
                }
                //添加
                dal_satellite_range.Add(satellite_range);
                MessageBox.Show("卫星添加成功！");
                //回传给父窗体消息
                DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.ToString());
            }

        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            this.txtPlatformID.Text = "";
            this.txtPlatformName.Text="";
            this.txtNumberOfSensor.Text="";
            this.dateTimePickerLaunchTime.Value=DateTime.Now.Date;
            this.dateTimePickerEndTime.Value=DateTime.Now.Date;
            this.txtMinSlewAngle.Text="";
            this.txtMaxSlewAngle.Text="";
            this.txtAngleVelocity.Text="";
            this.txtAngleAcceleration.Text="";
            this.comboBoxOrbitClass.SelectedItem="";
            this.comboBoxOrbitType.SelectedItem="";
            this.txtLonGEO.Text="";
            this.txtPerigee.Text="";
            this.txtApogee.Text="";
            this.txtPeriod.Text="";
            this.txtSatCountry.Text="";
            this.comboBoxSatCharter.SelectedItem = "";
        }

















    }
}
