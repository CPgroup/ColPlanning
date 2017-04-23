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
    public partial class ILLUSTRATEDCARQuery : Form
    {

        public ILLUSTRATEDCARQuery()
        {
            InitializeComponent();
        }
        //地面测量车相关类的实例化
        CoScheduling.Core.DAL.ILLUSTRATEDCAR_RANGE dal_illustratedcar_range = new Core.DAL.ILLUSTRATEDCAR_RANGE();

        /// <summary>
        /// 获取地面测量车信息列表DataSet
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetILLCARInfoDataSet(string strWhere)
        {
            DataSet ds = new DataSet();
            ds = dal_illustratedcar_range.GetListDataSet(strWhere);
            return ds;
        }
        //绑定地面测量车信息表和dataGridViewILLCAR控件
        public void bindILLCARInfo(string strWhere)
        {
            dataGridViewILLCAR.AutoGenerateColumns = false;
            this.dataGridViewILLCAR.DataSource = GetILLCARInfoDataSet(strWhere).Tables["ILLUSTRATEDCAR_RANGE"];
        }

        private void ILLUSTRATEDCARQuery_Load(object sender, EventArgs e)
        {
            bindILLCARInfo("PLATFORM_ID is not null");
        }

        private void ButtonQuery_Click(object sender, EventArgs e)
        {
            string ILLCARQueryCondition = "";
            DataSet DSILLCARQueryResult = new DataSet();

            //测量车查询条件
            //PLATFORM_ID
            if (!string.IsNullOrEmpty(this.txtPLATFORMID.Text))
            {
                ILLCARQueryCondition = ILLCARQueryCondition + " PLATFORM_ID=" + this.txtPLATFORMID.Text;
            }
            else
            {
                ILLCARQueryCondition = ILLCARQueryCondition + " PLATFORM_ID is not null";
            }
            //PLATFORM_NAME
            if (!string.IsNullOrEmpty(this.txtPLATFORMName.Text))
            {
                ILLCARQueryCondition = ILLCARQueryCondition + " And PLATFORM_Name like '%" + this.txtPLATFORMName.Text + "%'";
            }
            else
            {
                ILLCARQueryCondition = ILLCARQueryCondition + " And PLATFORM_Name is not null";
            }
            //传感器数量
            if (!string.IsNullOrEmpty(this.txtNumberOfSensor.Text))
            {
                ILLCARQueryCondition = ILLCARQueryCondition + " And NumberOfSensor=" + this.txtNumberOfSensor.Text;
            }
            else
            {
                ILLCARQueryCondition = ILLCARQueryCondition + " And NumberOfSensor is not null";
            }

            //巡航速度
            if(!string.IsNullOrEmpty(this.txtMaxVelocity.Text))
            {
                ILLCARQueryCondition = ILLCARQueryCondition + " And MaxVelocity>=" + this.txtMaxVelocity.Text;
            }
            else
            {
                ILLCARQueryCondition = ILLCARQueryCondition + " And MaxVelocity is not null";
            }

            //根据查询条件进行查询
            try
            {
                DSILLCARQueryResult = GetILLCARInfoDataSet(ILLCARQueryCondition);
                this.dataGridViewILLCAR.DataSource = DSILLCARQueryResult.Tables["ILLUSTRATEDCAR_RANGE"];
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            getILLCARNum();

        }

        /// <summary>
        /// 获取查询出来的UAV记录数量
        /// </summary>
        private void getILLCARNum()
        {
            int TaskCount = Convert.ToInt16(dataGridViewILLCAR.Rows.Count.ToString());
            this.txtILLCARCount.Text = TaskCount.ToString();
        }








    }
}
