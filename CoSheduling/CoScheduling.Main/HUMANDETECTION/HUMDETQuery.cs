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

namespace CoScheduling.Main.HUMANDETECTION
{
    public partial class HUMDETQuery : Form
    {
        public HUMDETQuery()
        {
            InitializeComponent();
        }
        //摄像头相关类的实例化
        CoScheduling.Core.DAL.HUMANDETECTION_RANGE dal_humdet_range = new CoScheduling.Core.DAL.HUMANDETECTION_RANGE();
        /// <summary>
        /// 获取志愿者信息列表DataSet
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetHUMDETInfoDataSet(string strWhere)
        {
            DataSet ds = new DataSet();
            ds = dal_humdet_range.GetListDataSet(strWhere);
            return ds;
        }
        //绑定志愿者信息表和dataGridViewHUMDET控件
        public void bindHUMDETInfo(string strWhere)
        {
            dataGridViewHUMDET.AutoGenerateColumns = false;
            this.dataGridViewHUMDET.DataSource = GetHUMDETInfoDataSet(strWhere).Tables["HUMANDETECTION_RANGE"];
        }

        private void HUMDETQuery_Load(object sender, EventArgs e)
        {
            bindHUMDETInfo("PLATFORM_ID is not null");
        }

        private void ButtonQuery_Click(object sender, EventArgs e)
        {
            string HUMDETQueryCondition = "";
            DataSet DSHUMDETQueryResult = new DataSet();

            //HUMDET查询条件
            //PLATFORM_ID
            if (!string.IsNullOrEmpty(this.txtPLATFORMID.Text))
            {
                HUMDETQueryCondition = HUMDETQueryCondition + " PLATFORM_ID=" + this.txtPLATFORMID.Text;
            }
            else
            {
                HUMDETQueryCondition = HUMDETQueryCondition + " PLATFORM_ID is not null";
            }
            //PLATFORM_NAME
            if (!string.IsNullOrEmpty(this.txtPLATFORMName.Text))
            {
                HUMDETQueryCondition = HUMDETQueryCondition + " And PLATFORM_Name like '%" + this.txtPLATFORMName.Text + "%'";
            }
            else
            {
                HUMDETQueryCondition = HUMDETQueryCondition + " And PLATFORM_Name is not null";
            }

            //传感器数量
            if (!string.IsNullOrEmpty(this.txtNumberOfSensor.Text))
            {
                HUMDETQueryCondition = HUMDETQueryCondition + " And NumberOfSensor=" + this.txtNumberOfSensor.Text;
            }
            else
            {
                HUMDETQueryCondition = HUMDETQueryCondition + " And NumberOfSensor is not null";
            }
            //根据查询条件进行查询
            try
            {
                DSHUMDETQueryResult = GetHUMDETInfoDataSet(HUMDETQueryCondition);
                this.dataGridViewHUMDET.DataSource = DSHUMDETQueryResult.Tables["HUMANDETECTION_RANGE"];
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("请输入正确的参数！");
            }
            getHUMDETNum();
        }
        /// <summary>
        /// 获取查询出来的HUMDET记录数量
        /// </summary>
        private void getHUMDETNum()
        {
            int TaskCount = Convert.ToInt16(dataGridViewHUMDET.Rows.Count.ToString());
            this.txtHUMDETCount.Text = TaskCount.ToString();
        }

    }
}
