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
    public partial class UAVQuery : Form
    {
        public UAVQuery()
        {
            InitializeComponent();
        }

        //无人机相关类的实例化
        CoScheduling.Core.DAL.UAV_RANGE dal_uav_range = new Core.DAL.UAV_RANGE();
        /// <summary>
        /// 获取无人机信息列表DataSet
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetUAVInfoDataSet(string strWhere)
        {
            DataSet ds = new DataSet();
            ds =dal_uav_range.GetListDataSet(strWhere);
            return ds;
        }
        //绑定无人机信息表和dataGridViewUAV控件
        public void bindUAVInfo(string strWhere)
        {
            dataGridViewUAV.AutoGenerateColumns = false;
            this.dataGridViewUAV.DataSource = GetUAVInfoDataSet(strWhere).Tables["UAV_RANGE"];
        }

        private void UAVQuery_Load(object sender, EventArgs e)
        {
            bindUAVInfo("PLATFORM_ID is not null");
        }

        private void ButtonQuery_Click(object sender, EventArgs e)
        {
            string UAVQueryCondition = "";
            DataSet DSUAVQueryResult = new DataSet();

            //UAV查询条件
            //PLATFORM_ID
            if(!string.IsNullOrEmpty(this.txtPLATFORMID.Text))
            {
                UAVQueryCondition = UAVQueryCondition + " PLATFORM_ID=" + this.txtPLATFORMID.Text;
            }
            else
            {
                UAVQueryCondition = UAVQueryCondition + " PLATFORM_ID is not null";
            }
            //PLATFORM_NAME
            if (!string.IsNullOrEmpty(this.txtPLATFORMName.Text))
            {
                UAVQueryCondition = UAVQueryCondition + " And PLATFORM_Name like '%" + this.txtPLATFORMName.Text+"%'";
            }
            else
            {
                UAVQueryCondition = UAVQueryCondition + " And PLATFORM_Name is not null";
            }
            //UAV基地ID
            if (!string.IsNullOrEmpty(this.txtBaseID.Text))
            {
                UAVQueryCondition = UAVQueryCondition + " And Base_ID=" + this.txtBaseID.Text;
            }
            else
            {
                UAVQueryCondition = UAVQueryCondition + " And Base_ID is not null";
            }
            //传感器数量
            if (!string.IsNullOrEmpty(this.txtNumberOfSensor.Text))
            {
                UAVQueryCondition = UAVQueryCondition + " And NumberOfSensor=" + this.txtNumberOfSensor.Text;
            }
            else
            {
                UAVQueryCondition = UAVQueryCondition + " And NumberOfSensor is not null";
            }
            //根据查询条件进行查询
            try
            {
                DSUAVQueryResult = GetUAVInfoDataSet(UAVQueryCondition);
                this.dataGridViewUAV.DataSource = DSUAVQueryResult.Tables["UAV_RANGE"];
            }
            catch(System.Exception ex)
            {
                MessageBox.Show("请输入正确的参数！");
            }
            getUAVNum();
        }
        /// <summary>
        /// 获取查询出来的UAV记录数量
        /// </summary>
        private void getUAVNum()
        {
            int TaskCount = Convert.ToInt16(dataGridViewUAV.Rows.Count.ToString());
            this.txtUAVCount.Text = TaskCount.ToString();
        }




    }
}
