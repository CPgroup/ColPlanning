using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CoScheduling.Main.ILLUSTRATEDCAR
{
    public partial class ILLUSTRATEDCARModify : Form
    {
        string illustratedcar_id = "";
        public ILLUSTRATEDCARModify(string illustratedcarid)
        {
            illustratedcar_id = illustratedcarid;
            InitializeComponent();
        }
        public ILLUSTRATEDCARModify()
        {
            InitializeComponent();
        }
        CoScheduling.Core.Model.ILLUSTRATEDCAR_RANGE illustratedcar_range = new Core.Model.ILLUSTRATEDCAR_RANGE();
        CoScheduling.Core.DAL.ILLUSTRATEDCAR_RANGE dal_illustratedcar_range = new Core.DAL.ILLUSTRATEDCAR_RANGE();

        private void ILLUSTRATEDCARModify_Load(object sender, EventArgs e)
        {
            //根据地面测量车id获取无人机实体
            illustratedcar_range = dal_illustratedcar_range.GetModel(Convert.ToDecimal(illustratedcar_id));
            //根据获取的无人机实体，给界面控件赋值
            (this.txtPlatformID.Text) = illustratedcar_range.PLATFORM_ID.ToString();
            this.txtPlatformName.Text = illustratedcar_range.PLATFORM_Name;
            (this.txtNumberOfSensor.Text) = illustratedcar_range.NumberOfSensor.ToString();
            (this.txtMaxVelocity.Text) = illustratedcar_range.MaxVelocity.ToString();
            this.txtAcceleration.Text = illustratedcar_range.Acceleration.ToString();
            (this.txtMaxDistance.Text) = illustratedcar_range.MaxDistance.ToString();
            (this.txtApprochAngle.Text) = illustratedcar_range.ApproachAngle.ToString();
            (this.txtDepartureAngle.Text) = illustratedcar_range.DepartureAngle.ToString();
            (this.txtMinGoundClearance.Text) = illustratedcar_range.MinimumGroundClearance.ToString();
            (this.txtWheelBase.Text) = illustratedcar_range.WheelBase.ToString();
            (this.txtAziAngle.Text) = illustratedcar_range.AzimuthAngle.ToString();
            (this.txtAziAngleVelocity.Text) = illustratedcar_range.AzimuthAngleVelocity.ToString();
            (this.txtPitAngle.Text) = illustratedcar_range.PitchAngle.ToString() ;
            (this.txtPitAngleVelocity.Text) = illustratedcar_range.PitchAngleVelocity.ToString();
            (this.txtPolAngle.Text) = illustratedcar_range.PolarizationAngle.ToString();
            (this.txtPolAngleVelocity.Text) = illustratedcar_range.PolarizationAngleVelocity.ToString();
        }

        private void ButtonModify_Click(object sender, EventArgs e)
        {
            //给地面测量车实体赋值
            try
            {
                illustratedcar_range.PLATFORM_ID = Convert.ToDecimal(this.txtPlatformID.Text);
                illustratedcar_range.PLATFORM_Name = this.txtPlatformName.Text;
                illustratedcar_range.NumberOfSensor = Convert.ToDecimal(this.txtNumberOfSensor.Text);
                illustratedcar_range.MaxVelocity = Convert.ToDecimal(this.txtMaxVelocity.Text);
                illustratedcar_range.Acceleration = Convert.ToDecimal(this.txtAcceleration.Text);
                illustratedcar_range.MaxDistance = Convert.ToDecimal(this.txtMaxDistance.Text);
                illustratedcar_range.ApproachAngle = Convert.ToDecimal(this.txtApprochAngle.Text);
                illustratedcar_range.DepartureAngle = Convert.ToDecimal(this.txtDepartureAngle.Text);
                illustratedcar_range.MinimumGroundClearance = Convert.ToDecimal(this.txtMinGoundClearance.Text);
                illustratedcar_range.WheelBase = Convert.ToDecimal(this.txtWheelBase.Text);
                illustratedcar_range.AzimuthAngle = Convert.ToDecimal(this.txtAziAngle.Text);
                illustratedcar_range.AzimuthAngleVelocity = Convert.ToDecimal(this.txtAziAngleVelocity.Text);
                illustratedcar_range.PitchAngle = Convert.ToDecimal(this.txtPitAngle.Text);
                illustratedcar_range.PitchAngleVelocity = Convert.ToDecimal(this.txtPitAngleVelocity.Text);
                illustratedcar_range.PolarizationAngle = Convert.ToDecimal(this.txtPolAngle.Text);
                illustratedcar_range.PolarizationAngleVelocity = Convert.ToDecimal(this.txtPolAngleVelocity.Text);
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
                    string.IsNullOrEmpty(this.txtMaxVelocity.Text) ||
                    string.IsNullOrEmpty(this.txtMaxDistance.Text))
                {
                    MessageBox.Show("输入信息不完整！");
                    return;
                }
                //添加
                dal_illustratedcar_range.Update(illustratedcar_range);
                MessageBox.Show("地面测量车信息修改成功！");
                //回传给父窗体消息
                DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.ToString());
            }
        }

        private void ButtonReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }











    }
}
