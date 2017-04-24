//----------------------------------------------------------------------------
//创建标识：李佳霖
// 创建描述: 第二类传感器添加窗体类
// 创建时间:2017.4.19
// 文件版本:1.0
// 功能描述: 对数据库中的志愿者传感器进行修改
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
    //志愿者传感器观测资源的添加窗口
    public partial class SENSOR2Add : Form
    {
        
        string sensor_id = "";
        string platform_id = "";
        public SENSOR2Add(string platformid)
        {
            platform_id = platformid;
            InitializeComponent();
        }
        public SENSOR2Add()
        {
            InitializeComponent();
        }
        CoScheduling.Core.DAL.HUMANDETECTION_RANGE dal_humdet_range = new CoScheduling.Core.DAL.HUMANDETECTION_RANGE();
        CoScheduling.Core.Model.HUMANDETECTION_RANGE humdet_range = new CoScheduling.Core.Model.HUMANDETECTION_RANGE();

        #region 操作函数
        /// <summary>
        /// 给lablePLATFORM绑定摄像头数据
        /// </summary>
        public void bindlablePLATFORM()
        {
            humdet_range = dal_humdet_range.GetModel(Convert.ToInt32(platform_id));
            this.labelPLATFORM.Text = humdet_range.PLATFORM_Name;
            this.labelPLATFORMID.Text = platform_id;
        }
        /// <summary>
        /// 给comboBoxSensorType绑定摄像头数据
        /// </summary>
        public void bindComboBoxSensorType()
        {
            List<ListItem> items = new List<ListItem>();
            items.Add(new ListItem("1", "光学"));
            items.Add(new ListItem("0", "雷达"));
            comboBoxSensorType.DisplayMember = "Text";
            comboBoxSensorType.ValueMember = "Value";
            comboBoxSensorType.DataSource = items;
        }
        #endregion 操作函数
        /// <summary>
        /// 窗体载入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SENSOR2Add_Load(object sender, EventArgs e)
        {
            bindlablePLATFORM();
            bindComboBoxSensorType();
        }
        /// <summary>
        /// 添加事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            CoScheduling.Core.Model.SENSOR_2 sensor2 = new Core.Model.SENSOR_2();
            CoScheduling.Core.DAL.SENSOR_2 dal_sensor2 = new Core.DAL.SENSOR_2();
            //给sensor2实体赋值
            try
            {
                sensor2.SensorID = dal_sensor2.GetSensorID(platform_id);
                if (string.IsNullOrEmpty(this.txtSensorName.Text) == false)
                {
                    sensor2.SensorName = this.txtSensorName.Text;
                }
                sensor2.PLATFORM_ID = Convert.ToDecimal(platform_id);
                sensor2.SensorType = Convert.ToString(this.comboBoxSensorType.SelectedValue);
                sensor2.Application = this.comboBoxSensorApplication.SelectedItem.ToString();
                sensor2.Pixel = Convert.ToDecimal(this.txtPixel.Text);
                sensor2.Resolution = Convert.ToDecimal(this.txtResolution.Text);
                sensor2.HorizontalResolution = Convert.ToDecimal(this.txtHorizontalResolution.Text);
                sensor2.MinIllumination = Convert.ToDecimal(this.txtMinIllumination.Text);
                sensor2.LookAngle = Convert.ToDecimal(this.txtLookAngle.Text);
                sensor2.SquintAngle = Convert.ToDecimal(this.txtSquintAngle.Text);
                sensor2.MaxDistance = Convert.ToDecimal(this.txtMaxDistance.Text);
                sensor2.Aperture = Convert.ToDecimal(this.txtAperture.Text);
                sensor2.FocalLength = Convert.ToDecimal(this.txtFocalLength.Text);
                sensor2.MAXGSD = sensor2.Resolution;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("请输入合法参数！");
                return;
            }
            try
            {
                //检查是否为空
                if (string.IsNullOrEmpty(this.txtSensorName.Text) ||
                    string.IsNullOrEmpty(this.comboBoxSensorType.SelectedItem.ToString()))
                {
                    MessageBox.Show("输入信息不完整！");
                    return;
                }
                //添加载荷
                dal_sensor2.Add(sensor2);
                MessageBox.Show("志愿者监测设备载荷添加成功！");
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
            this.txtSensorName.Text = "1号传感器";
            this.comboBoxSensorType.SelectedValue = "1";
            this.comboBoxSensorApplication.SelectedValue = "";
            this.txtPixel.Text = "100";
            this.txtResolution.Text = "0.2";
            this.txtHorizontalResolution.Text = "1";
            this.txtMinIllumination.Text = "6";
            this.txtLookAngle.Text = "6";
            this.txtSquintAngle.Text = "0.5";
            this.txtMaxDistance.Text = "100";
            this.txtAperture.Text = "2.0";
            this.txtFocalLength.Text = "0.5";
        }










    }
}
