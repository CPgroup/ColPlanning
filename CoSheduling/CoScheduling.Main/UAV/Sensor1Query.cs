using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OracleClient;
using CoScheduling.Core.Model;
using CoScheduling.Core.DAL;

namespace CoScheduling.Main.UAV
{
    public partial class Sensor1Query : Form
    {
        public Sensor1Query()
        {
            InitializeComponent();
        }
        //第一类传感器相关类的实例化
        CoScheduling.Core.DAL.Sensor_1 dal_sensor_1 = new Core.DAL.Sensor_1();
        /// <summary>
        /// 获取第一类传感器信息列表DataSet
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetSensor1InfoDataSet(string strWhere)
        {
            DataSet ds = new DataSet();
            ds = dal_sensor_1.GetListDataSet(strWhere);
            return ds;
        }

        //绑定第一类传感器信息表和dataGridViewSensor控件
        public void bindSensor1Info(string strWhere)
        {
            dataGridViewSensor.AutoGenerateColumns = false;
            this.dataGridViewSensor.DataSource = GetSensor1InfoDataSet(strWhere).Tables["SENSOR_1"];
        }
        /// <summary>
        /// 给comboBoxSensorType绑定传感器类型数据
        /// </summary>
        public void bindComboBoxSensorType()
        {
            List<ListItem> items = new List<ListItem>();
            items.Add(new ListItem("-1", "ALL"));
            items.Add(new ListItem("1", "光学"));
            items.Add(new ListItem("0", "雷达"));
            comboBoxSensorType.DisplayMember = "Text";
            comboBoxSensorType.ValueMember = "Value";
            comboBoxSensorType.DataSource = items;
        }

        private void Sensor1Query_Load(object sender, EventArgs e)
        {
            bindSensor1Info("SensorID is not null");
            bindComboBoxSensorType();
        }

        private void ButtonQuery_Click(object sender, EventArgs e)
        {
            string Sensor1QueryCondition = "";
            DataSet DSSensor1QueryResult = new DataSet();

            //Sensor1查询条件
            //SensorID
            if (!string.IsNullOrEmpty(this.txtSensor1ID.Text))
            {
                Sensor1QueryCondition = Sensor1QueryCondition + " SensorID=" + this.txtSensor1ID.Text;
            }
            else
            {
                Sensor1QueryCondition = Sensor1QueryCondition + " SensorID is not null";
            }
            //SensorName
            if (!string.IsNullOrEmpty(this.txtSensor1Name.Text))
            {
                Sensor1QueryCondition = Sensor1QueryCondition + " And SensorName like '%" + this.txtSensor1Name.Text + "%'";
            }
            else
            {
                Sensor1QueryCondition = Sensor1QueryCondition + " And SensorName is not null";
            }
            //PLATFORM_ID
            if (!string.IsNullOrEmpty(this.txtPLATFORMID.Text))
            {
                Sensor1QueryCondition = Sensor1QueryCondition + " And PLATFORM_ID=" + this.txtPLATFORMID.Text;
            }
            else
            {
                Sensor1QueryCondition = Sensor1QueryCondition + " And PLATFORM_ID is not null";
            }
            //传感器类型
            if (this.comboBoxSensorType.SelectedItem.ToString()!="ALL")
            {
                Sensor1QueryCondition = Sensor1QueryCondition + " And SensorType='" + this.comboBoxSensorType.SelectedValue.ToString()+"'";
            }
            else
            {
                Sensor1QueryCondition = Sensor1QueryCondition + " And SensorType is not null";
            }
            //空间分辨率
            if (!string.IsNullOrEmpty(this.txtGeoResolution.Text))
            {
                Sensor1QueryCondition = Sensor1QueryCondition + " And GeometryResolution<=" + this.txtGeoResolution.Text;
            }
            else
            {
                Sensor1QueryCondition = Sensor1QueryCondition + " And GeometryResolution is not null";
            }
            //根据查询条件进行查询
            try
            {
                DSSensor1QueryResult = GetSensor1InfoDataSet(Sensor1QueryCondition);
                this.dataGridViewSensor.DataSource = DSSensor1QueryResult.Tables["SENSOR_1"];
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            getSensor1Num();
        }

        /// <summary>
        /// 获取查询出来的Sensor1记录数量
        /// </summary>
        private void getSensor1Num()
        {
            int TaskCount = Convert.ToInt16(dataGridViewSensor.Rows.Count.ToString());
            this.txtSensor1Count.Text = TaskCount.ToString();
        }

        private void groupBox_QueryCondition_Enter(object sender, EventArgs e)
        {

        }

        private void txtUAVCount_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {

        }

        private void ButtonReturn_Click(object sender, EventArgs e)
        {

        }



    }
}
