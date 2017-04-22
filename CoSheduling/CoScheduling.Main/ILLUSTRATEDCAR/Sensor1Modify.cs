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
    public partial class Sensor1Modify : Form
    {
        string sensor_id = "";
        string platform_id = "";
        public Sensor1Modify(string sensorid)
        {
            sensor_id = sensorid;
            platform_id = sensor_id.Substring(0, 6);
            InitializeComponent();
        }
        public Sensor1Modify()
        {
            InitializeComponent();
        }
        CoScheduling.Core.DAL.ILLUSTRATEDCAR_RANGE dal_illustratedcar_range = new CoScheduling.Core.DAL.ILLUSTRATEDCAR_RANGE();
        CoScheduling.Core.Model.Sensor_1 sensor1 = new Core.Model.Sensor_1();
        CoScheduling.Core.DAL.Sensor_1 dal_sensor1 = new Core.DAL.Sensor_1();

        #region 操作函数
        /// <summary>
        /// 给comboBoxPLATFORM绑定无人机观测平台数据
        /// </summary>
        public void bindComboBoxPLATFORM()
        {
            DataSet ds = new DataSet();
            ds = dal_illustratedcar_range.GetListDataSet("");
            string strItem = "";
            string strValue = "";
            List<ListItem> items = new List<ListItem>();
            for (int i = 0; i < ds.Tables["ILLUSTRATEDCAR_RANGE"].Rows.Count; i++)
            {
                strItem = ds.Tables["ILLUSTRATEDCAR_RANGE"].Rows[i]["PLATFORM_Name"].ToString();
                strValue = ds.Tables["ILLUSTRATEDCAR_RANGE"].Rows[i]["PLATFORM_ID"].ToString();
                items.Add(new ListItem(strValue, strItem));
            }
            //将数据源的属性与ComboBox的属性对应
            comboBoxPLATFORM.DisplayMember = "Text";        //显示
            comboBoxPLATFORM.ValueMember = "Value";        //值
            comboBoxPLATFORM.DataSource = items;        //绑定数据
            comboBoxPLATFORM.SelectedValue = platform_id;        //设定选择项
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

        private void Sensor1Modify_Load(object sender, EventArgs e)
        {
            sensor1 = dal_sensor1.GetModel(Convert.ToDecimal(sensor_id));
            bindComboBoxPLATFORM();
            bindComboBoxSensorType();

            this.comboBoxPLATFORM.SelectedValue = platform_id;
            this.txtSensorName.Text = sensor1.SensorName;
            this.txtGeoResolution.Text = sensor1.GeometryResolution.ToString();
            if (sensor1.SensorType == "1")
            {
                this.comboBoxSensorType.SelectedValue = "1";
            }
            else
            {
                this.comboBoxSensorType.SelectedValue = "0";
            }
            this.txtBandNumber.Text = sensor1.BandNumber.ToString();
            this.comboBoxSensorApplication.SelectedItem = sensor1.Application;
            this.txtInclination.Text = sensor1.Inclination.ToString();
            this.txtSwathVelocity.Text = sensor1.SwathVelocity.ToString();
            this.txtSwathWidth.Text = sensor1.SwathWidth.ToString();
            this.txtBandCenter.Text = sensor1.BandCenter.ToString();
            this.txtLookAngle.Text = sensor1.LookAngle.ToString();
            this.txtSquintAngle.Text = sensor1.SquintAngle.ToString();
            this.txtAziDireResolution.Text = sensor1.AzimuthDirectionResolution.ToString();
        }

        private void ButtonModify_Click(object sender, EventArgs e)
        {
            //给sensor1赋值
            try
            {
                sensor1.SensorID = Convert.ToDecimal(sensor_id);
                sensor1.SensorName = this.txtSensorName.Text;
                sensor1.PLATFORM_ID = Convert.ToDecimal(this.comboBoxPLATFORM.SelectedValue);
                sensor1.SensorType = this.comboBoxSensorType.SelectedValue.ToString();
                sensor1.BandNumber = Convert.ToDecimal(this.txtBandNumber.Text);
                sensor1.Application = this.comboBoxSensorApplication.SelectedItem.ToString();
                sensor1.Inclination = Convert.ToDecimal(this.txtInclination.Text);
                sensor1.SwathVelocity = Convert.ToDecimal(this.txtSwathVelocity.Text);
                sensor1.SwathWidth = Convert.ToDecimal(this.txtSwathWidth.Text);
                sensor1.GeometryResolution = Convert.ToDecimal(this.txtGeoResolution.Text);
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
                //更新载荷表
                dal_sensor1.Update(sensor1);
                MessageBox.Show("地面测量车载荷修改成功！");
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
