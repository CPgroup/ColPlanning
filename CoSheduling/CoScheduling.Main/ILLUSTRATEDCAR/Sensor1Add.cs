//----------------------------------------------------------------------------
// 创建标识：李佳霖
// 创建描述: 第一类传感器添加窗体类
// 创建时间:2017.4.19
// 文件版本:1.0
// 功能描述: 对数据库中的地面测量车传感器进行修改
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

namespace CoScheduling.Main.ILLUSTRATEDCAR
{
    //地面测量车传感器观测资源的添加窗口
    public partial class Sensor1Add : Form
    {
        string sensor_id = "";
        string platform_id = "";
        public Sensor1Add(string platformid)
        {
            platform_id = platformid;
            InitializeComponent();
        }
        public Sensor1Add()
        {
            InitializeComponent();
        }
        CoScheduling.Core.DAL.ILLUSTRATEDCAR_RANGE dal_illustratedcar_range = new CoScheduling.Core.DAL.ILLUSTRATEDCAR_RANGE();
        CoScheduling.Core.Model.ILLUSTRATEDCAR_RANGE illustratedcar_range = new CoScheduling.Core.Model.ILLUSTRATEDCAR_RANGE();
        #region 操作函数
        /// <summary>
        /// 给lablePLATFORM绑定卫星数据
        /// </summary>
        public void bindlablePLATFORM()
        {
            illustratedcar_range = dal_illustratedcar_range.GetModel(Convert.ToInt32(platform_id));
            this.labelPLATFORM.Text = illustratedcar_range.PLATFORM_Name;
            this.labelPLATFORMID.Text = platform_id;
        }
        /// <summary>
        /// 给comboBoxSensorType绑定卫星数据
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

        private void Sensor1Add_Load(object sender, EventArgs e)
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
            CoScheduling.Core.Model.Sensor_1 sensor1 = new Core.Model.Sensor_1();
            CoScheduling.Core.DAL.Sensor_1 dal_sensor1 = new Core.DAL.Sensor_1();
            //给sensor1实体赋值
            try
            {
                sensor1.SensorID = dal_sensor1.GetSensorID(platform_id);
                if (string.IsNullOrEmpty(this.txtSensorName.Text) == false)
                {
                    sensor1.SensorName = this.txtSensorName.Text;
                }
                sensor1.SensorType = Convert.ToString(this.comboBoxSensorType.SelectedValue);
                sensor1.BandNumber = Convert.ToDecimal(this.txtBandNumber.Text);
                sensor1.Application = this.comboBoxSensorApplication.SelectedItem.ToString();
                sensor1.Inclination = Convert.ToDecimal(this.txtInclination.Text);
                sensor1.SwathVelocity = Convert.ToDecimal(this.txtSwathVelocity.Text);
                sensor1.SwathWidth = Convert.ToDecimal(this.txtSwathWidth.Text);
                sensor1.GeometryResolution = Convert.ToDecimal(this.txtGeoResolution.Text);
                sensor1.PLATFORM_ID = Convert.ToDecimal(platform_id);
                sensor1.BandCenter = Convert.ToDecimal(this.txtBandCenter.Text);
                sensor1.LookAngle = Convert.ToDecimal(this.txtLookAngle.Text);
                sensor1.SquintAngle = Convert.ToDecimal(this.txtSquintAngle.Text);
                sensor1.AzimuthDirectionResolution = Convert.ToDecimal(this.txtAziDireResolution.Text);
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
                    string.IsNullOrEmpty(this.comboBoxSensorType.SelectedItem.ToString()) ||
                    string.IsNullOrEmpty(this.txtGeoResolution.Text))
                {
                    MessageBox.Show("输入信息不完整！");
                    return;
                }
                //添加载荷
                dal_sensor1.Add(sensor1);
                MessageBox.Show("飞艇载荷添加成功！");
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
            this.txtBandNumber.Text = "1";
            this.comboBoxSensorApplication.SelectedValue = "";
            this.txtInclination.Text = "6";
            this.txtSwathVelocity.Text = "6";
            this.txtSwathWidth.Text = "6";
            this.txtGeoResolution.Text = "0.2";
            this.txtBandCenter.Text = "1";
            this.txtLookAngle.Text = "6";
            this.txtSquintAngle.Text = "6";
            this.txtAziDireResolution.Text = "0.5";
        }








    }
}
