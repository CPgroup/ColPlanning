//----------------------------------------------------------------------------
//创建标识：李佳霖
// 创建描述: 摄像头修改窗体类
// 创建时间:2017.4.19
// 文件版本:1.0
// 功能描述: 对数据库中的摄像头数据进行修改
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

namespace CoScheduling.Main.SPYCAM_RANGE
{
    public partial class SPYCAMModify : Form
    {
        string spycam_id = "";
        public SPYCAMModify(string aeroshipid)
        {
            spycam_id = aeroshipid;
            InitializeComponent();
        }
        public SPYCAMModify()
        {
            InitializeComponent();
        }
        CoScheduling.Core.Model.SPYCAM_RANGE spycam_range = new Core.Model.SPYCAM_RANGE();
        CoScheduling.Core.DAL.SPYCAM_RANGE dal_spycam_range = new Core.DAL.SPYCAM_RANGE();

        private void SPYCAMModify_Load(object sender, EventArgs e)
        {
            //根据摄像头id获取无人机实体
            spycam_range = dal_spycam_range.GetModel(Convert.ToDecimal(spycam_id));
            //根据获取的飞艇实体，给界面控件赋值
            (this.txtPlatformID.Text) = spycam_range.PLATFORM_ID.ToString();
            this.txtPlatformName.Text = spycam_range.PLATFORM_Name;
            (this.txtNumberOfSensor.Text) = spycam_range.NumberOfSensor.ToString();
            (this.txtHorizontalRotAngle.Text) = spycam_range.HorizontalRotationAngle.ToString();
            (this.txtVerticalRotAngle.Text) = spycam_range.VerticalRotationAngle.ToString();
            
        }

        private void ButtonModify_Click(object sender, EventArgs e)
        {
            //给UAV实体赋值
            try
            {
                spycam_range.PLATFORM_ID = Convert.ToDecimal(this.txtPlatformID.Text);
                spycam_range.PLATFORM_Name = this.txtPlatformName.Text;
                spycam_range.NumberOfSensor = Convert.ToDecimal(this.txtNumberOfSensor.Text);
                spycam_range.HorizontalRotationAngle = Convert.ToDecimal(this.txtHorizontalRotAngle.Text);
                spycam_range.VerticalRotationAngle = Convert.ToDecimal(this.txtVerticalRotAngle.Text);

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
                    string.IsNullOrEmpty(this.txtPlatformName.Text) )
                {
                    MessageBox.Show("输入信息不完整！");
                    return;
                }
                //添加
                dal_spycam_range.Update(spycam_range);
                MessageBox.Show("摄像头信息修改成功！");
                //回传给父窗体消息
                DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
