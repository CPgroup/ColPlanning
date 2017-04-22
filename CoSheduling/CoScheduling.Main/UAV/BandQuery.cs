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
    public partial class BandQuery : Form
    {
        public BandQuery()
        {
            InitializeComponent();
        }
        //波段相关类的实例化
        CoScheduling.Core.DAL.Sensor_Band_Mode dal_sensor_band_mode = new Core.DAL.Sensor_Band_Mode();
        /// <summary>
        /// 获取波段信息列表DataSet
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetBandInfoDataSet(string strWhere)
        {
            DataSet ds = new DataSet();
            ds = dal_sensor_band_mode.GetListDataSet(strWhere);
            return ds;
        }
        //绑定波段信息表和dataGridViewBand控件
        public void bindBandInfo(string strWhere)
        {
            dataGridViewBand.AutoGenerateColumns = false;
            this.dataGridViewBand.DataSource = GetBandInfoDataSet(strWhere).Tables["SENSOR_BAND_MODE"];
        }
        /// <summary>
        /// 给comboBoxBandType绑定传感器类型数据
        /// </summary>
        public void bindComboBoxBandType()
        {
            List<ListItem> items = new List<ListItem>();
            items.Add(new ListItem("0", "ALL"));
            items.Add(new ListItem("1", "PAN"));
            items.Add(new ListItem("2", "VIS"));
            items.Add(new ListItem("3", "NIR"));
            items.Add(new ListItem("4", "SWIR"));
            items.Add(new ListItem("5", "MWIR"));
            items.Add(new ListItem("6", "TIR"));
            items.Add(new ListItem("7", "FIR"));
            items.Add(new ListItem("8", "UV"));
            items.Add(new ListItem("9", "UV - VIS"));
            items.Add(new ListItem("10", "UV - NIR"));
            items.Add(new ListItem("11", "UV - MWIR"));
            items.Add(new ListItem("12", "UV - FIR"));
            items.Add(new ListItem("13", "VIS - NIR"));
            items.Add(new ListItem("14", "VIS - MWIR"));
            items.Add(new ListItem("15", "VIS - TIR"));
            items.Add(new ListItem("16", "VIS - FIR"));
            items.Add(new ListItem("17", "NIR - SWIR"));
            items.Add(new ListItem("18", "MWIR - FIR"));
            items.Add(new ListItem("19", "MWIR - TIR"));
            items.Add(new ListItem("20", "TIR - FIR"));
            items.Add(new ListItem("21", "L"));
            items.Add(new ListItem("22", "S"));
            items.Add(new ListItem("23", "C"));
            items.Add(new ListItem("24", "X"));
            items.Add(new ListItem("25", "Ku"));
            items.Add(new ListItem("26", "K"));
            items.Add(new ListItem("27", "Ka"));
            items.Add(new ListItem("28", "V"));
            items.Add(new ListItem("29", "W"));
            items.Add(new ListItem("30", "mm"));
            items.Add(new ListItem("31", "MW"));

            comboBoxBandType.DisplayMember = "Text";
            comboBoxBandType.ValueMember = "Value";
            comboBoxBandType.DataSource = items;
        }

        private void BandQuery_Load(object sender, EventArgs e)
        {
            bindBandInfo("BandID is not null");
            bindComboBoxBandType();
        }

        private void ButtonQuery_Click(object sender, EventArgs e)
        {
            string BandQueryCondition = "";
            DataSet DSBandQueryResult = new DataSet();

            //Band查询条件
            //BandID
            if (!string.IsNullOrEmpty(this.txtBandID.Text))
            {
                BandQueryCondition = BandQueryCondition + " BandID=" + this.txtBandID.Text;
            }
            else
            {
                BandQueryCondition = BandQueryCondition + " BandID is not null";
            }
            //BandName
            if (!string.IsNullOrEmpty(this.txtBandName.Text))
            {
                BandQueryCondition = BandQueryCondition + " And BAND_MODE_NAME like '%" + this.txtBandName.Text + "%'";
            }
            else
            {
                BandQueryCondition = BandQueryCondition + " And BAND_MODE_NAME is not null";
            }
            //波段类型
            if (this.comboBoxBandType.SelectedItem.ToString() != "ALL")
            {
                BandQueryCondition = BandQueryCondition + " And BandType='" + this.comboBoxBandType.SelectedItem.ToString() + "'";
            }
            else
            {
                BandQueryCondition = BandQueryCondition + " And BandType is not null";
            }
            //SensorID
            if (!string.IsNullOrEmpty(this.txtSensor1ID.Text))
            {
                BandQueryCondition = BandQueryCondition + " And SensorID=" + this.txtSensor1ID.Text;
            }
            else
            {
                BandQueryCondition = BandQueryCondition + " And SensorID is not null";
            }
            //PLATFORM_ID
            if (!string.IsNullOrEmpty(this.txtPLATFORMID.Text))
            {
                BandQueryCondition = BandQueryCondition + " And PLATFORM_ID=" + this.txtPLATFORMID.Text;
            }
            else
            {
                BandQueryCondition = BandQueryCondition + " And PLATFORM_ID is not null";
            }
            //根据查询条件进行查询
            try
            {
                DSBandQueryResult = GetBandInfoDataSet(BandQueryCondition);
                this.dataGridViewBand.DataSource = DSBandQueryResult.Tables["SENSOR_BAND_MODE"];
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            getBandNum();
        }
        /// <summary>
        /// 获取查询出来的Band记录数量
        /// </summary>
        private void getBandNum()
        {
            int TaskCount = Convert.ToInt16(dataGridViewBand.Rows.Count.ToString());
            this.txtBandCount.Text = TaskCount.ToString();
        }









    }
}
