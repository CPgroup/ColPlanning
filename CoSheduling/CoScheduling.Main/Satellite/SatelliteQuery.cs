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

namespace CoScheduling.Main.Satellite
{
    public partial class SatelliteQuery : Form
    {
        public SatelliteQuery()
        {
            InitializeComponent();
        }

        //卫星相关类的实例化
        CoScheduling.Core.DAL.SATELLITE_RANGE dal_satellite_range = new Core.DAL.SATELLITE_RANGE();
        /// <summary>
        /// 获取卫星信息列表DataSet
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetSatInfoDataSet(string strWhere)
        {
            DataSet ds = new DataSet();
            ds = dal_satellite_range.GetListDataSet(strWhere);
            return ds;
        }
        //绑定卫星信息表和dataGridViewSat控件
        public void bindSatInfo(string strWhere)
        {
            dataGridViewSat.AutoGenerateColumns = false;
            this.dataGridViewSat.DataSource = GetSatInfoDataSet(strWhere).Tables["SATELLITE_RANGE"];
        }

        private void SatelliteQuery_Load(object sender, EventArgs e)
        {
            bindSatInfo("PLATFORM_ID is not null");
            this.comboBoxSatCharter.SelectedIndex = 0;
        }

        private void ButtonQuery_Click(object sender, EventArgs e)
        {
            string SatQueryCondition = "";
            DataSet DSSatQueryResult = new DataSet();

            //卫星查询条件
            //PLATFORM_ID
            if (!string.IsNullOrEmpty(this.txtPLATFORMID.Text))
            {
                SatQueryCondition = SatQueryCondition + " PLATFORM_ID=" + this.txtPLATFORMID.Text;
            }
            else
            {
                SatQueryCondition = SatQueryCondition + " PLATFORM_ID is not null";
            }
            //PLATFORM_NAME
            if (!string.IsNullOrEmpty(this.txtPLATFORMName.Text))
            {
                SatQueryCondition = SatQueryCondition + " And PLATFORM_Name like '%" + this.txtPLATFORMName.Text + "%'";
            }
            else
            {
                SatQueryCondition = SatQueryCondition + " And PLATFORM_Name is not null";
            }
            
            //传感器数量
            if (!string.IsNullOrEmpty(this.txtNumberOfSensor.Text))
            {
                SatQueryCondition = SatQueryCondition + " And NumberOfSensor=" + this.txtNumberOfSensor.Text;
            }
            else
            {
                SatQueryCondition = SatQueryCondition + " And NumberOfSensor is not null";
            }
            //所属国家
            if (!string.IsNullOrEmpty(this.txtSatCountry.Text))
            {
                SatQueryCondition = SatQueryCondition + " And SAT_COUNTRY like '%" + this.txtSatCountry.Text + "%'";
            }
            else
            {
                SatQueryCondition = SatQueryCondition + " And SAT_COUNTRY is not null";
            }
            //是否为宪章成员
            if (this.comboBoxSatCharter.SelectedItem.ToString()=="是")
            {
                SatQueryCondition = SatQueryCondition + " And SAT_CHARTER=" + "1";
            }
            else if (this.comboBoxSatCharter.SelectedItem.ToString() == "否")
            {
                SatQueryCondition = SatQueryCondition + " And SAT_CHARTER=" + "0";
            }
            else
            {
                SatQueryCondition = SatQueryCondition + " And SAT_CHARTER is not null";
            }
            //根据查询条件进行查询
            try
            {
                DSSatQueryResult = GetSatInfoDataSet(SatQueryCondition);
                this.dataGridViewSat.DataSource = DSSatQueryResult.Tables["SATELLITE_RANGE"];
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("请输入正确的参数！");
            }
            getSatNum();
        }

        /// <summary>
        /// 获取查询出来的卫星记录数量
        /// </summary>
        private void getSatNum()
        {
            int TaskCount = Convert.ToInt16(dataGridViewSat.Rows.Count.ToString());
            this.txtSatCount.Text = TaskCount.ToString();
        }









    }
}
