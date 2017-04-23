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

namespace CoScheduling.Main.Coverage
{
    public partial class TaskSchemeDetail : Form
    {
        #region 全局实体对象及实体对象数据访问对象
        int taskid;
        //使用到的实体对象
        CoScheduling.Core.Model.TASK_SCHEME_LIST taskSchemeList = new CoScheduling.Core.Model.TASK_SCHEME_LIST();
        CoScheduling.Core.Model.TASK_LAYOUT_LIST taskLayoutList = new CoScheduling.Core.Model.TASK_LAYOUT_LIST();
        //实体对象对应的数据访问对象
        CoScheduling.Core.DAL.TASK_SCHEME_LIST dal_taskSchemeList = new CoScheduling.Core.DAL.TASK_SCHEME_LIST();
        CoScheduling.Core.DAL.TASK_LAYOUT_LIST dal_taskLayoutList = new CoScheduling.Core.DAL.TASK_LAYOUT_LIST();
        #endregion
        public TaskSchemeDetail(int id)
        {
            taskid = id;
            InitializeComponent();
        }
        #region Load方法
        private void TaskSchemeAdd_Load(object sender, EventArgs e)
        {
            showSchemeDetail(taskid);
            showTaskLayout();

        }
        #endregion Load方法

        #region DataGridView操作方法
        public void showTaskLayout()
        {
            GridViewTaskLayout.AutoGenerateColumns = false;
            DataSet ds = dal_taskLayoutList.GetListDataSet("SCHEMEID=" + taskSchemeList.SCHEMEID);
            //for (int i = 0; i < ds.Tables["TASK_LAYOUT_LIST"].Rows.Count; i++)
            //{
            //    ds.Tables["TASK_LAYOUT_LIST"].Rows[i]["STARTTIME"] = Convert.ToDateTime(ds.Tables["TASK_LAYOUT_LIST"].Rows[i]["STARTTIME"]); //循环修改列传值
            //    ds.Tables["TASK_LAYOUT_LIST"].Rows[i]["ENDTIME"] = Convert.ToDateTime(ds.Tables["TASK_LAYOUT_LIST"].Rows[i]["ENDTIME"]); //循环修改列传值
            //}
            //ds.AcceptChanges();
            GridViewTaskLayout.DataSource = ds.Tables["TASK_LAYOUT_LIST"];
        }

        //DataGridView选中行,显示任务详情
        private void GridViewTaskLayout_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.GridViewTaskLayout.CurrentRow != null)
            {
                //获取当前行的任务ID
                int selectTaskID = Convert.ToInt32(this.GridViewTaskLayout.CurrentRow.Cells[0].Value);
                //用于做增删改的实体对象，避免与全局的实体对象冲突
                CoScheduling.Core.Model.TASK_LAYOUT_LIST taskLayoutListTemp = new CoScheduling.Core.Model.TASK_LAYOUT_LIST();
                //给实体对象赋值为当前选中的任务
                taskLayoutListTemp = dal_taskLayoutList.GetModel(selectTaskID);
                //给观测任务参数设置传入当前选中任务
                this.txtTaskName.Text = taskLayoutListTemp.TASKNAME;
                this.txtTaskPriority.Text = taskLayoutListTemp.PRIORITY.ToString();
                this.txtResolution.Text = taskLayoutListTemp.MAXGSD.ToString();
                if (taskLayoutListTemp.TASKTYPE == 0)
                {
                    this.comboTaskType.SelectedItem = "点目标";
                    this.txtLat1.Text = taskLayoutListTemp.LAT.ToString();
                    this.txtLat2.Text = taskLayoutListTemp.LAT.ToString();
                    this.txtLon1.Text = taskLayoutListTemp.LON.ToString();
                    this.txtLon2.Text = taskLayoutListTemp.LON.ToString();
                }
                else
                {
                    this.comboTaskType.SelectedItem = "区域目标";
                    string[] latlonStr = taskLayoutListTemp.AREASTRING.Split(' ');
                    if (latlonStr.Length == 9)
                    {
                        this.txtLat1.Text = latlonStr[4].ToString();
                        this.txtLat2.Text = latlonStr[0].ToString();
                        this.txtLon1.Text = latlonStr[1].ToString();
                        this.txtLon2.Text = latlonStr[3].ToString();
                    }
                    else
                    {
                        this.txtLat1.Text = "";
                        this.txtLat2.Text = "";
                        this.txtLon1.Text = "";
                        this.txtLon2.Text = "";
                    }

                }
                this.dateTaskStartTime.Value = taskLayoutListTemp.STARTTIME.AddHours(-8);
                this.dateTaskEndTime.Value = taskLayoutListTemp.ENDTIME.AddHours(-8);
            }

        }

        #endregion DataGridView操作方法

        #region 任务添加操作方法
        public void showSchemeDetail(int id)
        {
            taskLayoutList = dal_taskLayoutList.GetModel(id);
            taskSchemeList = dal_taskSchemeList.GetModel(taskLayoutList.SCHEMEID);
            this.txtSchemeName.Text = taskSchemeList.SCHEMENAME;
            this.dateTaskStart.Value = taskSchemeList.SCHEMEBTIME.AddHours(-8);
            this.dateTaskEnd.Value = taskSchemeList.SCHEMEETIME.AddHours(-8);
        }


        #endregion 任务添加操作方法
    }
}
