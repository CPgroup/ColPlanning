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
    public partial class SatModify : Form
    {
        string satellite_id = "";
        public SatModify(string satelliteid)
        {
            satellite_id = satelliteid;
            InitializeComponent();
        }
        public SatModify()
        {
            InitializeComponent();
        }

        //卫星实体类，访问类
        CoScheduling.Core.Model.SATELLITE_RANGE satellite_range = new Core.Model.SATELLITE_RANGE();
        CoScheduling.Core.DAL.SATELLITE_RANGE dal_satellite_range = new Core.DAL.SATELLITE_RANGE();

        private void SatModify_Load(object sender, EventArgs e)
        {
            //根据卫星ID获取卫星实体 
            satellite_range = dal_satellite_range.GetModel(Convert.ToDecimal(satellite_id));
            
            //根据获取的卫星实体，给界面控件赋值
            this.txtPlatformID.Text = satellite_range.PLATFORM_ID.ToString();
            this.txtPlatformID.Enabled = false;
            this.txtPlatformName.Text = satellite_range.PLATFORM_NAME;
            this.txtNumberOfSensor.Text = satellite_range.NumberOfSensor.ToString(); ;
            this.dateTimePickerLaunchTime.Value = satellite_range.LaunchTime;
            this.dateTimePickerEndTime.Value = satellite_range.EolTime;
            this.txtMinSlewAngle.Text = satellite_range.MinSlewAngle.ToString();
            this.txtMaxSlewAngle.Text = satellite_range.MaxSlewAngle.ToString();
            this.txtAngleVelocity.Text = satellite_range.AngularVelocity.ToString();
            this.txtAngleAcceleration.Text = satellite_range.AngularAcceleration.ToString();
            this.comboBoxOrbitClass.SelectedItem = satellite_range.OrbitClass.ToString();
            this.comboBoxOrbitType.SelectedItem = satellite_range.OrbitType.ToString();
            this.txtLonGEO.Text = satellite_range.LongitudeOfGEO.ToString();
            this.txtPerigee.Text = satellite_range.Perigee.ToString();
            this.txtApogee.Text = satellite_range.Apogee.ToString();
            this.txtPeriod.Text = satellite_range.Period.ToString();
            this.txtSatCountry.Text = satellite_range.SAT_COUNTRY.ToString();
            if (satellite_range.SAT_CHARTER == 1)
            {
                this.comboBoxSatCharter.SelectedItem = "是";
            }
            else
            {
                this.comboBoxSatCharter.SelectedItem = "否";
            }

        }




        private void ButtonReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxOrbitClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBoxOrbitClass.SelectedItem.ToString() == "GEO")
            {
                this.txtLonGEO.ReadOnly = false;
            }
            else
            {
                this.txtLonGEO.ReadOnly = true;
            }
        }

        private void ButtonModify_Click(object sender, EventArgs e)
        {
            //给UAV实体赋值
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
                    this.dateTimePickerLaunchTime.Value > this.dateTimePickerEndTime.Value ||
                    string.IsNullOrEmpty(this.comboBoxOrbitClass.SelectedItem.ToString()) ||
                    string.IsNullOrEmpty(this.comboBoxOrbitType.SelectedItem.ToString()))
                {
                    MessageBox.Show("输入信息不完整！");
                    return;
                }
                //修改
                dal_satellite_range.Update(satellite_range);
                MessageBox.Show("卫星信息修改成功！");
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
