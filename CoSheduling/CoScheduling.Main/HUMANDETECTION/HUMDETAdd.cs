//----------------------------------------------------------------------------
//创建标识：李佳霖
// 创建描述: 志愿者设备添加窗体类
// 创建时间:2017.4.19
// 文件版本:1.0
// 功能描述: 对数据库中的志愿者设备数据进行添加
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

namespace CoScheduling.Main.HUMANDETECTION
{
    public partial class HUMDETAdd : Form
    {
        public HUMDETAdd()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 摄像头添加按钮点击操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            //志愿者实体类，访问类
            CoScheduling.Core.Model.HUMANDETECTION_RANGE humdet_range = new Core.Model.HUMANDETECTION_RANGE();
            CoScheduling.Core.DAL.HUMANDETECTION_RANGE dal_humdet_range = new Core.DAL.HUMANDETECTION_RANGE();

            //给志愿者实体赋值
            try
            {
                humdet_range.PLATFORM_ID = Convert.ToDecimal(this.txtPlatformID.Text);
                humdet_range.PLATFORM_Name = this.txtPlatformName.Text;
                humdet_range.NumberOfSensor = Convert.ToDecimal(this.txtNumberOfSensor.Text);
                humdet_range.MaxCruisingTime = Convert.ToDecimal(this.txtMaxCruisingTime.Text);
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
                    string.IsNullOrEmpty(this.txtPlatformName.Text))
                {
                    MessageBox.Show("输入信息不完整！");
                    return;
                }
                //添加
                dal_humdet_range.Add(humdet_range);
                MessageBox.Show("志愿者监测设备添加成功！");
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
            (this.txtPlatformID.Text) = "600001";
            this.txtPlatformName.Text = "No.2 HumanDetection";
            (this.txtNumberOfSensor.Text) = "1";
            (this.txtMaxCruisingTime.Text) = "24";
            
        }

        private void ButtonReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
