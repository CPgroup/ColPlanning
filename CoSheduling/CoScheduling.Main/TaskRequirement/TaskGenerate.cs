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
    public partial class TaskGenerate : Form
    {
        public TaskGenerate()
        {
            InitializeComponent();
        }
        //任务需求实体类和访问类对象的建立
        CoScheduling.Core.Model.TaskRequirement task_requirement = new Core.Model.TaskRequirement();
        CoScheduling.Core.DAL.TaskRequirement dal_task_requirement = new Core.DAL.TaskRequirement();
        //任务观测区域实体类和访问类对象的建立
        //CoScheduling.Core.Model.TaskObsRegion task_obsregion = new Core.Model.TaskObsRegion();
        //CoScheduling.Core.DAL.TaskObsRegion dal_task_obsregion = new Core.DAL.TaskObsRegion();
        //灾害知识实体类和访问类的建立
        CoScheduling.Core.Model.DisaKnowledge disa_knowledge = new Core.Model.DisaKnowledge();
        CoScheduling.Core.DAL.DisaKnowledge dal_disa_knowledge = new Core.DAL.DisaKnowledge();

        string CheckedSensors = "";//用于生成并存储所需的观测资源传感器类型

        private void TaskGenerate_Load(object sender, EventArgs e)
        {
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

        /// <summary>
        /// 通过事件类型的字符串获得对应的事件类型ID
        /// </summary>
        /// <param name="DisaType"></param>
        /// <returns></returns>
        public decimal GetDisaTypeID(string DisaType)
        {
            decimal DisaTypeID = 0;
            switch (DisaType)
            {
                case "地震":
                    DisaTypeID = 1;
                    break;
                case "洪涝":
                    DisaTypeID = 2;
                    break;
                case "崩塌滑坡":
                    DisaTypeID = 3;
                    break;
                case "泥石流":
                    DisaTypeID = 4;
                    break;
                case "堰塞湖":
                    DisaTypeID = 5;
                    break;
                case "森林火灾":
                    DisaTypeID = 6;
                    break;
                case "海上溢油":
                    DisaTypeID = 7;
                    break;
                case "暴恐事件":
                    DisaTypeID = 8;
                    break;
                case "人群聚集":
                    DisaTypeID = 9;
                    break;
            }
            return DisaTypeID;
        }
        /// <summary>
        /// 获取任务信息列表DataSet
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetTaskInfoDataSet(string strWhere)
        {
            DataSet ds = new DataSet();
            ds = dal_task_requirement.GetListDataSet(strWhere);
            return ds;
        }
        public string GetSensorsNeeded(CoScheduling.Core.Model.DisaKnowledge disaknowledge)
        {
            string strSensors = "";
            if (disaknowledge.UV_Needed == true)
            {
                strSensors += "紫外" + " ";
            }
            if (disaknowledge.LasFlu_Needed == true)
            {
                strSensors += "激光荧光" + " ";
            }
            if (disaknowledge.VISNIR_Needed == true)
            {
                strSensors += "可见光 近红外" + " ";
            }
            if (disaknowledge.SIR_Needed == true)
            {
                strSensors += "短红外" + " ";
            }
            if (disaknowledge.MIR_Needed == true)
            {
                strSensors += "中红外" + " ";
            }
            if (disaknowledge.TIR_Needed == true)
            {
                strSensors += "热红外" + " ";
            }
            if (disaknowledge.SAR_X_Needed == true)
            {
                strSensors += "SAR_X" + " ";
            }
            if (disaknowledge.SAR_C_Needed == true)
            {
                strSensors += "SAR_C" + " ";
            }
            if (disaknowledge.SAR_S_Needed == true)
            {
                strSensors += "SAR_S" + " ";
            }
            if (disaknowledge.SAR_L_Needed == true)
            {
                strSensors += "SAR_L" + " ";
            }
            if (disaknowledge.HypSpe_Needed == true)
            {
                strSensors += "高光谱" + " ";
            }
            if (disaknowledge.CamSpy_Needed == true)
            {
                strSensors += "视频";
            }
            return strSensors;
        }

        private void ButtonGenerate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtTaskRegion.Text) ||
                this.dateOccurTime.Checked == false || this.comboBox_DisaType.SelectedItem.ToString() == "ALL")
            {
                MessageBox.Show("请输入完整的参数！");
            }
            else
            {
                DataSet DSTaskIDQueryResult = new DataSet();
                //任务ID生成,按照任务ID的命名规范，年+月+日+类型+编号
                DateTime dt = DateTime.Now;
                string strYear = dt.Year.ToString();
                string strMonth = dt.Month.ToString().PadLeft(2,'0');
                string strDay = dt.Day.ToString().PadLeft(2,'0');
                decimal DisasTypeID = GetDisaTypeID(this.comboBox_DisaType.SelectedItem.ToString());
                string strDisasType = DisasTypeID.ToString();
                string strTaskID = strYear.Substring(strYear.Length - 2, 2) + strMonth + strDay + strDisasType;
                //查找出当前年月日任务类型条件下数据库中已有的任务数量
                //按时间查询、按任务类型查询
                string TaskIDQuery = "";
                string temp = dt.Date.ToString();
                DateTime begintime = dt.Date;
                DateTime endtime = dt.Date.AddDays(1);
                TaskIDQuery += "SubmissionTime>='" + begintime.ToString() + "'";
                TaskIDQuery += " And SubmissionTime<='" + endtime.ToString() + "'";
                TaskIDQuery += " And DisasterType='" + this.comboBox_DisaType.SelectedItem.ToString() + "'";
                DSTaskIDQueryResult = GetTaskInfoDataSet(TaskIDQuery);
                int TaskNum = DSTaskIDQueryResult.Tables["TaskRequirements_general"].Rows.Count+1;
                string strNum = TaskNum.ToString().PadLeft(2, '0');
                task_requirement.TaskID = Convert.ToDecimal(strTaskID + strNum);
                
                //提交时间
                task_requirement.SubmissionTime = dt;
                //任务名称
                if (!string.IsNullOrEmpty(this.txtTaskName.Text))
                {
                    task_requirement.TaskName = this.txtTaskName.Text;
                }
                //任务优先级
                if (!string.IsNullOrEmpty(this.txtPriority.Text))
                {
                    task_requirement.TaskPriority = Convert.ToDecimal(this.txtPriority.Text);
                }

                //响应时间生成
                if (!string.IsNullOrEmpty(this.txtResTime.Text))
                {
                    task_requirement.RespondingTime = Convert.ToDecimal(this.txtResTime.Text);
                }
                //观测频率的生成
                if (!string.IsNullOrEmpty(this.txtObsFre.Text))
                {
                    task_requirement.ObservationFrequency = Convert.ToDecimal(this.txtObsFre.Text);
                }

                task_requirement.OccurTime = this.dateOccurTime.Value;
                DateTime datetime = new DateTime();
                datetime = task_requirement.OccurTime;
                //观测时间的生成
                if (this.dateStartTime.Checked == true && this.dateEndTime.Checked == true)
                {
                    task_requirement.StartTime = this.dateStartTime.Value;
                    task_requirement.EndTime = this.dateEndTime.Value;
                }
                else
                {
                    //若没有输入任务观测的开始和结束时间，按照事件发生之后的响应时间开始观测
                    task_requirement.StartTime = datetime.AddHours(Convert.ToDouble(task_requirement.RespondingTime));//datetime变量自身已经增加了两小时
                    task_requirement.EndTime = datetime.AddHours(10);
                }

                //观测区域的生成
                task_requirement.PolygonString = this.txtTaskRegion.Text;

                //传感器类型生成
                task_requirement.DisasterType = this.comboBox_DisaType.SelectedItem.ToString();
                //根据灾害类型获取所需要的传感器类型和最大空间分辨率
                disa_knowledge = dal_disa_knowledge.GetModel(DisasTypeID);
                //最大空间分辨率
                if (!string.IsNullOrEmpty(this.txtSpaRes.Text))
                {
                    task_requirement.SpaceResolution = Convert.ToDecimal(this.txtSpaRes.Text);
                }
                else
                {
                    task_requirement.SpaceResolution = disa_knowledge.Max_SpatialResolution;
                }
                //传感器类型
                string strSensors = GetSensorsNeeded(disa_knowledge);
                //判断遥感数据类型是否有输入数据
                foreach (Control control in this.groupBox_SensorTypes.Controls)
                {
                    if ((control as CheckBox).Checked)
                    {
                        CheckedSensors = CheckedSensors + (control as CheckBox).Text + " ";
                    }
                }
                if(CheckedSensors!="")
                {
                    task_requirement.SensorNeeded = CheckedSensors;
                }
                else
                {
                    task_requirement.SensorNeeded = strSensors;
                }
                
                MessageBox.Show("任务需求已生成");
                //生成任务的显示
                this.txtTaskID.Text = task_requirement.TaskID.ToString();
                this.txtTaskName.Text = task_requirement.TaskName;
                this.txtPriority.Text = task_requirement.TaskPriority.ToString();
                this.txtSpaRes.Text = task_requirement.SpaceResolution.ToString();
                this.txtObsFre.Text = task_requirement.ObservationFrequency.ToString();
                this.dateStartTime.Value = task_requirement.StartTime;
                this.dateEndTime.Value = task_requirement.EndTime;
                this.txtResTime.Text = task_requirement.RespondingTime.ToString();
                //组合框中成员的选中
                this.comboBox_DisaType.SelectedIndex = Convert.ToInt32(DisasTypeID);
                this.txtTaskRegion.Text = task_requirement.PolygonString;

                //遥感数据类型的选中显示
                string[] SensorsType =task_requirement.SensorNeeded.Split(' ');//按空格分隔各种传感器类型
                foreach (Control control in groupBox_SensorTypes.Controls)
                {
                    if (IsConcluded((control as CheckBox).Text, SensorsType))
                    {
                        (control as CheckBox).Checked = true;
                    }
                }
            }
        }
        /// <summary>
        /// 用于判断一个字符串是否在另一个字符串列表中，查看是否有现成的函数
        /// </summary>
        /// <param name="str"></param>
        /// <param name="strList"></param>
        /// <returns></returns>
        public bool IsConcluded(string str, string[] strList)
        {
            bool isconcluded = false;
            foreach (string strSegment in strList)
            {
                if (strSegment == str)
                    isconcluded = true;
            }
            return isconcluded;
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                dal_task_requirement.AddRecord(task_requirement);
                MessageBox.Show("任务记录添加成功！");
            }
            catch (Exception es)
            {
                MessageBox.Show(es.ToString());
            }
        }









    }
}
