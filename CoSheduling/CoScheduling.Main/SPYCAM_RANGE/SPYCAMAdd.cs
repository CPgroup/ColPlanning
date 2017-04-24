//----------------------------------------------------------------------------
//创建标识：李佳霖
// 创建描述: 摄像头添加窗体类
// 创建时间:2017.4.19
// 文件版本:1.0
// 功能描述: 对数据库中的摄像头数据进行添加
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
    public partial class SPYCAMAdd : Form
    {
        public SPYCAMAdd()
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
            //摄像头实体类，访问类
            CoScheduling.Core.Model.SPYCAM_RANGE spycam_range = new Core.Model.SPYCAM_RANGE();
            CoScheduling.Core.DAL.SPYCAM_RANGE dal_spycam_range = new Core.DAL.SPYCAM_RANGE();

            //给摄像头实体赋值
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
                    string.IsNullOrEmpty(this.txtPlatformName.Text))
                {
                    MessageBox.Show("输入信息不完整！");
                    return;
                }
                //添加
                dal_spycam_range.Add(spycam_range);
                MessageBox.Show("摄像头添加成功！");
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
            (this.txtPlatformID.Text) = "400001";
            this.txtPlatformName.Text = "No.2 SPYCAM";
            (this.txtNumberOfSensor.Text) = "1";
            (this.txtHorizontalRotAngle.Text) = "24";
            (this.txtVerticalRotAngle.Text) = "5";

        }

        private void ButtonReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
