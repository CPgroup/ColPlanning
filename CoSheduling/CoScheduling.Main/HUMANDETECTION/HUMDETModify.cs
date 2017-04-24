//----------------------------------------------------------------------------
//创建标识：李佳霖
// 创建描述: 志愿者监测设备修改窗体类
// 创建时间:2017.4.19
// 文件版本:1.0
// 功能描述: 对数据库中的志愿者监测设备数据进行修改
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
    public partial class HUMDETModify : Form
    {
        string humdet_id = "";
        public HUMDETModify(string humdetid)
        {
            humdet_id = humdetid;
            InitializeComponent();
        }
        public HUMDETModify()
        {
            InitializeComponent();
        }
        CoScheduling.Core.Model.HUMANDETECTION_RANGE humdet_range = new Core.Model.HUMANDETECTION_RANGE();
        CoScheduling.Core.DAL.HUMANDETECTION_RANGE dal_humdet_range = new Core.DAL.HUMANDETECTION_RANGE();

        private void HUMDETModify_Load(object sender, EventArgs e)
        {
            //根据志愿者id获取无人机实体
            humdet_range = dal_humdet_range.GetModel(Convert.ToDecimal(humdet_id));
            //根据获取的志愿者实体，给界面控件赋值
            (this.txtPlatformID.Text) = humdet_range.PLATFORM_ID.ToString();
            this.txtPlatformName.Text = humdet_range.PLATFORM_Name;
            (this.txtNumberOfSensor.Text) = humdet_range.NumberOfSensor.ToString();
            (this.txtMaxCruisingTime.Text) = humdet_range.MaxCruisingTime.ToString();
        }

        private void ButtonModify_Click(object sender, EventArgs e)
        {
            //给UAV实体赋值
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
                dal_humdet_range.Update(humdet_range);
                MessageBox.Show("志愿者信息修改成功！");
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
