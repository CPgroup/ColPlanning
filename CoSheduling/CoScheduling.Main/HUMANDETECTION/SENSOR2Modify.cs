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
    public partial class SENSOR2Modify : Form
    {
        string sensor_id = "";
        string platform_id = "";
        public SENSOR2Modify(string sensorid)
        {
            sensor_id = sensorid;
            platform_id = sensor_id.Substring(0, 6);
            InitializeComponent();
        }
        public SENSOR2Modify()
        {
            InitializeComponent();
        }


        CoScheduling.Core.DAL.HUMANDETECTION_RANGE dal_humdet_range = new CoScheduling.Core.DAL.HUMANDETECTION_RANGE();
        CoScheduling.Core.Model.SENSOR_2 sensor2 = new Core.Model.SENSOR_2();
        CoScheduling.Core.DAL.SENSOR_2 dal_sensor2 = new Core.DAL.SENSOR_2();

        #region 操作函数
        /// <summary>
        /// 给comboBoxPLATFORM绑定无人机观测平台数据
        /// </summary>
        public void bindComboBoxPLATFORM()
        {
            DataSet ds = new DataSet();
            ds = dal_humdet_range.GetListDataSet("");
            string strItem = "";
            string strValue = "";
            List<ListItem> items = new List<ListItem>();
            for (int i = 0; i < ds.Tables["HUMANDETECTION_RANGE"].Rows.Count; i++)
            {
                strItem = ds.Tables["HUMANDETECTION_RANGE"].Rows[i]["PLATFORM_Name"].ToString();
                strValue = ds.Tables["HUMANDETECTION_RANGE"].Rows[i]["PLATFORM_ID"].ToString();
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

        private void SENSOR2Modify_Load(object sender, EventArgs e)
        {
            sensor2 = dal_sensor2.GetModel(Convert.ToDecimal(sensor_id));
            bindComboBoxPLATFORM();
            bindComboBoxSensorType();

            this.comboBoxPLATFORM.SelectedValue = platform_id;
            this.txtSensorName.Text = sensor2.SensorName;
            if (sensor2.SensorType == "1")
            {
                this.comboBoxSensorType.SelectedValue = "1";
            }
            else
            {
                this.comboBoxSensorType.SelectedValue = "0";
            }
            this.comboBoxSensorApplication.SelectedValue = sensor2.Application;
            this.txtPixel.Text = sensor2.Pixel.ToString();
            this.comboBoxSensorApplication.SelectedItem = sensor2.Application;
            this.txtResolution.Text = sensor2.Resolution.ToString();
            this.txtHorizontalResolution.Text = sensor2.HorizontalResolution.ToString();
            this.txtMinIllumination.Text = sensor2.MinIllumination.ToString();
            this.txtLookAngle.Text = sensor2.LookAngle.ToString();
            this.txtSquintAngle.Text = sensor2.SquintAngle.ToString();
            this.txtMaxDistance.Text = sensor2.MaxDistance.ToString();
            this.txtAperture.Text = sensor2.Aperture.ToString();
            this.txtFocalLength.Text = sensor2.FocalLength.ToString();
        }

        private void ButtonModify_Click(object sender, EventArgs e)
        {
            //给sensor2赋值
            try
            {
                sensor2.SensorID = Convert.ToDecimal(sensor_id);
                sensor2.SensorName = this.txtSensorName.Text;
                sensor2.PLATFORM_ID = Convert.ToDecimal(this.comboBoxPLATFORM.SelectedValue);
                sensor2.SensorType = this.comboBoxSensorType.SelectedValue.ToString();
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
                    string.IsNullOrEmpty(this.txtResolution.Text))
                {
                    MessageBox.Show("输入信息不完整！");
                    return;
                }
                //更新载荷表
                dal_sensor2.Update(sensor2);
                MessageBox.Show("志愿者监测设备载荷修改成功！");
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
