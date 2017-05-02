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


namespace CoScheduling.Main.TaskRequirement
{
    public partial class TaskQuery : Form
    {
        public TaskQuery()
        {
            InitializeComponent();
        }

        //任务需求相关类实例化
        CoScheduling.Core.DAL.TaskRequirement dal_taskrequirement = new CoScheduling.Core.DAL.TaskRequirement();
        CoScheduling.Core.DAL.TaskObsRegion dal_taskobsregion = new CoScheduling.Core.DAL.TaskObsRegion();
        /// <summary>
        /// 获取任务信息列表DataSet
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetTaskInfoDataSet(string strWhere)
        {
            DataSet ds = new DataSet();
            ds = dal_taskrequirement.GetListDataSet(strWhere);
            return ds;
        }
        public DataSet GetTaskObsRegionDataSet(string strWhere)
        {
            DataSet ds = new DataSet();
            ds = dal_taskobsregion.GetListDataSet(strWhere);
            return ds;
        }

        public void bindTaskInfo(string strWhere)
        {
            dataGridViewTask.AutoGenerateColumns = false;
            this.dataGridViewTask.DataSource = GetTaskInfoDataSet(strWhere).Tables["TaskRequirements_general"];//Table函数的意义？
        }

        private void TaskQuery_Load(object sender, EventArgs e)
        {
            bindTaskInfo("TaskID is not null");
            //为灾害类型下拉框添加项目
            comboBox_DisaType.Items.Add("ALL");
            comboBox_DisaType.Items.Add("地震");
            comboBox_DisaType.Items.Add("洪涝");
            comboBox_DisaType.Items.Add("崩塌滑坡");
            comboBox_DisaType.Items.Add("泥石流");
            comboBox_DisaType.Items.Add("堰塞湖");
            comboBox_DisaType.Items.Add("森林火灾");
            comboBox_DisaType.Items.Add("海上溢油");
            comboBox_DisaType.Items.Add("暴恐事件");
            comboBox_DisaType.Items.Add("人群聚集");

            comboBox_DisaType.SelectedIndex = 0;
        }

        private void ButtonQuery_Click(object sender, EventArgs e)
        {
            string TaskQueryCondition = "";
            string TaskObsRegQueryCondition = "";
            DataSet DSTaskQueryResult = new DataSet();
            DataSet DSTaskObsRegQueResult = new DataSet();

            //任务查询条件
            //任务编号
            if (!string.IsNullOrEmpty(this.txtTaskID.Text))
            {
                TaskQueryCondition = TaskQueryCondition + " TaskID=" + this.txtTaskID.Text;
            }
            else
            {
                TaskQueryCondition = TaskQueryCondition + " TaskID IS NOT NULL";
            }
            //灾害类型
            if (this.comboBox_DisaType.SelectedItem.ToString() != "ALL")
            {
                TaskQueryCondition = TaskQueryCondition + " And DisasterType='" + this.comboBox_DisaType.SelectedItem.ToString() + "'";
            }
            else
            {
                TaskQueryCondition = TaskQueryCondition + " And DisasterType is not null";
            }
            // 开始时间和结束时间
            if (this.dateStartTime.Checked == true && this.dateEndTime.Checked == true)
            {
                TaskQueryCondition = TaskQueryCondition + " And StartTime>='" + this.dateStartTime.Value.ToString() + "'";
                TaskQueryCondition = TaskQueryCondition + " And EndTime<='" + this.dateEndTime.Value.ToString() + "'";
            }
            else
            {
                TaskQueryCondition = TaskQueryCondition + " And StartTime is not null and EndTime is not null";
            }
            
            //根据除了空间范围之外的其他条件，首先获取general表中符合条件的任务
           
            string strwhere = TaskQueryCondition;
            try
            {
                DSTaskQueryResult = GetTaskInfoDataSet(strwhere);
                //this.dataGridViewTask.DataSource = DSTaskQueryResult.Tables["TaskRequirements_general"];
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("请输入正确的参数！");
            }
            DataTable DTTask = DSTaskQueryResult.Tables["TaskRequirements_general"];

            //根据待观测区域的范围判断是否在指定范围之内的观测区域矩形
            //不加else语句，默认控件内容为空的情况下，不添加关于空间范围的条件
            decimal maxLon, maxLat, minLon, minLat;//任务区域的经纬度范围
            string taskregionstring= "";
            bool IsInRectangle;
            if (!string.IsNullOrEmpty(this.txtMinLon.Text) &&
                !string.IsNullOrEmpty(this.txtMaxLon.Text) &&
                !string.IsNullOrEmpty(this.txtMinLat.Text) &&
                !string.IsNullOrEmpty(this.txtMaxLat.Text))//如果规定了范围
            {
                for(int i=DTTask.Rows.Count-1;i>=0;i--)
                {
                    IsInRectangle = false;
                    taskregionstring = DTTask.Rows[i]["PolygonString"].ToString();//第i个任务的任务区域属性
                    string[] strpointcoord = taskregionstring.Split(';');//分割后每个点的坐标对
                    maxLon = Convert.ToDecimal(strpointcoord[0].Split(',')[0]);
                    minLon = Convert.ToDecimal(strpointcoord[0].Split(',')[0]);
                    maxLat = Convert.ToDecimal(strpointcoord[0].Split(',')[1]);
                    minLat = Convert.ToDecimal(strpointcoord[0].Split(',')[1]);
                    for(int j=1;j<strpointcoord.Length-1;j++)
                    {
                        if (Convert.ToDecimal(strpointcoord[j].Split(',')[0])>maxLon)
                        {
                            maxLon=Convert.ToDecimal(strpointcoord[j].Split(',')[0]);
                        }
                        else if(Convert.ToDecimal(strpointcoord[j].Split(',')[0])<minLon)
                        {
                            minLon=Convert.ToDecimal(strpointcoord[j].Split(',')[0]);
                        }
                        if(Convert.ToDecimal(strpointcoord[j].Split(',')[1])>maxLat)
                        {
                            maxLat = Convert.ToDecimal(strpointcoord[j].Split(',')[0]);
                        }
                        else if(Convert.ToDecimal(strpointcoord[j].Split(',')[1])<minLon)
                        {
                            minLat = Convert.ToDecimal(strpointcoord[j].Split(',')[1]);
                        }
                    }
                    //如果任务区域在查询条件矩形之内，则满足条件
                    if (maxLon<=Convert.ToDecimal(this.txtMaxLon.Text)&&
                        minLon>=Convert.ToDecimal(this.txtMinLon.Text)&&
                        maxLat<=Convert.ToDecimal(this.txtMaxLat.Text)&&
                        minLat>=Convert.ToDecimal(this.txtMinLat.Text))
                    {
                        IsInRectangle = true;
                    }
                    if(IsInRectangle==false)
                    {
                        DTTask.Rows[i].Delete();
                    }

                }
                DTTask.AcceptChanges();
            }

            this.dataGridViewTask.DataSource = DTTask;
            getTaskNum();
        }
        /// <summary>
        /// 获取查询出来的任务记录数量
        /// </summary>
        private void getTaskNum()
        {
            int TaskCount = Convert.ToInt16(dataGridViewTask.Rows.Count.ToString());
            this.txtTaskCount.Text = TaskCount.ToString();
        }


    }
}
