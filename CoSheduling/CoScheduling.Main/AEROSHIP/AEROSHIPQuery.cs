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

namespace CoScheduling.Main.AEROSHIP
{
    public partial class AEROSHIPQuery : Form
    {
        public AEROSHIPQuery()
        {
            InitializeComponent();
        }

        //飞艇相关类的实例化
        CoScheduling.Core.DAL.AEROSHIP_RANGE dal_aeroship_range = new CoScheduling.Core.DAL.AEROSHIP_RANGE();
        /// <summary>
        /// 获取飞艇信息列表DataSet
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetAEROSHIPInfoDataSet(string strWhere)
        {
            DataSet ds = new DataSet();
            ds = dal_aeroship_range.GetListDataSet(strWhere);
            return ds;
        }
        //绑定无人机信息表和dataGridViewUAV控件
        public void bindAEROSHIPInfo(string strWhere)
        {
            dataGridViewAEROSHIP.AutoGenerateColumns = false;
            this.dataGridViewAEROSHIP.DataSource = GetAEROSHIPInfoDataSet(strWhere).Tables["AEROSHIP_RANGE"];
        }

        private void AEROSHIPQuery_Load(object sender, EventArgs e)
        {
            bindAEROSHIPInfo("PLATFORM_ID is not null");
        }

        private void ButtonQuery_Click(object sender, EventArgs e)
        {
            string AEROSHIPQueryCondition = "";
            DataSet DSAEROSHIPQueryResult = new DataSet();

            //UAV查询条件
            //PLATFORM_ID
            if (!string.IsNullOrEmpty(this.txtPLATFORMID.Text))
            {
                AEROSHIPQueryCondition = AEROSHIPQueryCondition + " PLATFORM_ID=" + this.txtPLATFORMID.Text;
            }
            else
            {
                AEROSHIPQueryCondition = AEROSHIPQueryCondition + " PLATFORM_ID is not null";
            }
            //PLATFORM_NAME
            if (!string.IsNullOrEmpty(this.txtPLATFORMName.Text))
            {
                AEROSHIPQueryCondition = AEROSHIPQueryCondition + " And PLATFORM_Name like '%" + this.txtPLATFORMName.Text + "%'";
            }
            else
            {
                AEROSHIPQueryCondition = AEROSHIPQueryCondition + " And PLATFORM_Name is not null";
            }
            
            //传感器数量
            if (!string.IsNullOrEmpty(this.txtNumberOfSensor.Text))
            {
                AEROSHIPQueryCondition = AEROSHIPQueryCondition + " And NumberOfSensor=" + this.txtNumberOfSensor.Text;
            }
            else
            {
                AEROSHIPQueryCondition = AEROSHIPQueryCondition + " And NumberOfSensor is not null";
            }
            //根据查询条件进行查询
            try
            {
                DSAEROSHIPQueryResult = GetAEROSHIPInfoDataSet(AEROSHIPQueryCondition);
                this.dataGridViewAEROSHIP.DataSource = DSAEROSHIPQueryResult.Tables["AEROSHIP_RANGE"];
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("请输入正确的参数！");
            }
            getAEROSHIPNum();
        }
        /// <summary>
        /// 获取查询出来的UAV记录数量
        /// </summary>
        private void getAEROSHIPNum()
        {
            int TaskCount = Convert.ToInt16(dataGridViewAEROSHIP.Rows.Count.ToString());
            this.txtAEROSHIPCount.Text = TaskCount.ToString();
        }
    }
}
