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

namespace CoScheduling.Main.SPYCAM_RANGE
{
    public partial class SPYCAMQuery : Form
    {
        public SPYCAMQuery()
        {
            InitializeComponent();
        }
        //摄像头相关类的实例化
        CoScheduling.Core.DAL.SPYCAM_RANGE dal_spycam_range = new CoScheduling.Core.DAL.SPYCAM_RANGE();
        /// <summary>
        /// 获取摄像头信息列表DataSet
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetSPYCAMInfoDataSet(string strWhere)
        {
            DataSet ds = new DataSet();
            ds = dal_spycam_range.GetListDataSet(strWhere);
            return ds;
        }
        //绑定摄像头信息表和dataGridViewSPYCAM控件
        public void bindSPYCAMInfo(string strWhere)
        {
            dataGridViewSPYCAM.AutoGenerateColumns = false;
            this.dataGridViewSPYCAM.DataSource = GetSPYCAMInfoDataSet(strWhere).Tables["SPYCAM_RANGE"];
        }

        private void SPYCAMQuery_Load(object sender, EventArgs e)
        {
            bindSPYCAMInfo("PLATFORM_ID is not null");
        }

        private void ButtonQuery_Click(object sender, EventArgs e)
        {
            string SPYCAMQueryCondition = "";
            DataSet DSSPYCAMQueryResult = new DataSet();

            //SPYCAM查询条件
            //PLATFORM_ID
            if (!string.IsNullOrEmpty(this.txtPLATFORMID.Text))
            {
                SPYCAMQueryCondition = SPYCAMQueryCondition + " PLATFORM_ID=" + this.txtPLATFORMID.Text;
            }
            else
            {
                SPYCAMQueryCondition = SPYCAMQueryCondition + " PLATFORM_ID is not null";
            }
            //PLATFORM_NAME
            if (!string.IsNullOrEmpty(this.txtPLATFORMName.Text))
            {
                SPYCAMQueryCondition = SPYCAMQueryCondition + " And PLATFORM_Name like '%" + this.txtPLATFORMName.Text + "%'";
            }
            else
            {
                SPYCAMQueryCondition = SPYCAMQueryCondition + " And PLATFORM_Name is not null";
            }

            //传感器数量
            if (!string.IsNullOrEmpty(this.txtNumberOfSensor.Text))
            {
                SPYCAMQueryCondition = SPYCAMQueryCondition + " And NumberOfSensor=" + this.txtNumberOfSensor.Text;
            }
            else
            {
                SPYCAMQueryCondition = SPYCAMQueryCondition + " And NumberOfSensor is not null";
            }
            //根据查询条件进行查询
            try
            {
                DSSPYCAMQueryResult = GetSPYCAMInfoDataSet(SPYCAMQueryCondition);
                this.dataGridViewSPYCAM.DataSource = DSSPYCAMQueryResult.Tables["SPYCAM_RANGE"];
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("请输入正确的参数！");
            }
            getSPYCAMNum();
        }
        /// <summary>
        /// 获取查询出来的SPYCAM记录数量
        /// </summary>
        private void getSPYCAMNum()
        {
            int TaskCount = Convert.ToInt16(dataGridViewSPYCAM.Rows.Count.ToString());
            this.txtAEROSHIPCount.Text = TaskCount.ToString();
        }




    }
}
