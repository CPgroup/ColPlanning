using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CoScheduling.Main.TaskRequirement
{
    public partial class TaskModify : Form
    {
        string task_id = "";
        public TaskModify(string taskid)
        {
            task_id = taskid;
            InitializeComponent();
        }
        public TaskModify()
        {
            InitializeComponent();
        }
        //任务需求相关类的实例化
        CoScheduling.Core.Model.TaskRequirement taskrequirement = new Core.Model.TaskRequirement();
        CoScheduling.Core.DAL.TaskRequirement dal_taskrequirement = new Core.DAL.TaskRequirement();
        //List<CoScheduling.Core.Model.TaskRegionPoint> taskregionpoint = new List<Core.Model.TaskRegionPoint>();
        ////CoScheduling.Core.Model.TaskRegionPoint taskregionpoint = new Core.Model.TaskRegionPoint();
        //CoScheduling.Core.DAL.TaskRegionPoint dal_taskregionpoint = new Core.DAL.TaskRegionPoint();
        CoScheduling.Core.Model.TaskObsRegion taskobsregion = new Core.Model.TaskObsRegion();
        CoScheduling.Core.DAL.TaskObsRegion dal_taskobsregion = new Core.DAL.TaskObsRegion();

        private void TaskModify_Load(object sender, EventArgs e)
        {
            //根据任务ID获取任务实体
            taskrequirement = dal_taskrequirement.GetModel(Convert.ToDecimal(task_id));
            taskobsregion = dal_taskobsregion.GetModel(Convert.ToDecimal(task_id));
            //根据任务ID获取任务观测区域边界点实体
            //taskregionpoint = dal_taskregionpoint.GetModel(Convert.ToDecimal(task_id));

            this.txtTaskID.Text = taskrequirement.TaskID.ToString();
            this.txtTaskName.Text = taskrequirement.TaskName;
            this.txtPriority.Text = taskrequirement.TaskPriority.ToString();
            this.txtSpaRes.Text = taskrequirement.SpaceResolution.ToString();
            this.txtObsFre.Text = taskrequirement.ObservationFrequency.ToString();
            this.dateStartTime.Value = taskrequirement.StartTime;
            this.dateEndTime.Value = taskrequirement.EndTime;
            this.txtResTime.Text = taskrequirement.RespondingTime.ToString();
            this.comboBox_DisaType.SelectedItem = taskrequirement.DisasterType;//有问题，需修改
            //this.comboBox_SensorType.SelectedItem = taskrequirement.SensorNeeded.ToString();
            this.txtMinLon.Text = taskobsregion.MinLon.ToString();
            this.txtMinLat.Text = taskobsregion.MinLat.ToString();
            this.txtMaxLon.Text = taskobsregion.MaxLon.ToString();
            this.txtMaxLat.Text = taskobsregion.MaxLat.ToString();
        }

        private void ButtonModify_Click(object sender, EventArgs e)
        {
            //给任务需求实体赋值
            int cnt = 0;//用于记录每个任务观测区域的边界点数
            string CheckedSensors = "";
            try
            {
                taskrequirement.TaskID = Convert.ToDecimal(this.txtTaskID.Text);
                taskrequirement.TaskName = this.txtTaskName.Text;
                taskrequirement.TaskPriority = Convert.ToDecimal(this.txtPriority.Text);
                taskrequirement.SubmissionTime = DateTime.Now;//获取当前系统时间
                taskrequirement.DisasterType = this.comboBox_DisaType.SelectedItem.ToString();
                taskrequirement.StartTime = this.dateStartTime.Value;
                taskrequirement.EndTime = this.dateEndTime.Value;
                taskrequirement.RespondingTime = Convert.ToDecimal(this.txtResTime.Text);
                taskrequirement.ObservationFrequency = Convert.ToDecimal(this.txtObsFre.Text);
                //taskrequirement.SensorNeeded = this.comboBox_SensorType.SelectedItem.ToString(); 

                foreach (Control control in groupBox_SensorTypes.Controls)
                {
                    if ((control as CheckBox).Checked)
                    {
                        CheckedSensors += (control as CheckBox).Text + " ";
                    }
                }
                taskrequirement.SensorNeeded = CheckedSensors;
                taskrequirement.SpaceResolution = Convert.ToDecimal(this.txtSpaRes.Text);
                taskrequirement.OccurTime = DateTime.Now;
                //给观测区域经纬度范围赋值
                taskobsregion.TaskID = taskrequirement.TaskID;
                taskobsregion.MinLon = Convert.ToDecimal(this.txtMinLon.Text);
                taskobsregion.MaxLon = Convert.ToDecimal(this.txtMaxLon.Text);
                taskobsregion.MinLat = Convert.ToDecimal(this.txtMinLat.Text);
                taskobsregion.MaxLat = Convert.ToDecimal(this.txtMaxLat.Text);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("请输入合法参数！");
                return;
            }

            try
            {
                //检查是否为空
                if (string.IsNullOrEmpty(this.txtTaskID.Text) || string.IsNullOrEmpty(this.txtTaskName.Text) || string.IsNullOrEmpty(this.comboBox_DisaType.SelectedItem.ToString()) ||
                    string.IsNullOrEmpty(this.dateStartTime.Text) || string.IsNullOrEmpty(this.dateEndTime.Text) || string.IsNullOrEmpty(this.txtResTime.Text) ||
                    string.IsNullOrEmpty(this.txtObsFre.Text) || //string.IsNullOrEmpty(this.comboBox_SensorType.SelectedItem.ToString()) || 
                    string.IsNullOrEmpty(this.txtSpaRes.Text) ||
                     string.IsNullOrEmpty(this.txtMinLon.Text) || string.IsNullOrEmpty(this.txtMinLat.Text) || string.IsNullOrEmpty(this.txtMaxLon.Text) ||
                     string.IsNullOrEmpty(this.txtMaxLat.Text) ||
                    this.dateStartTime.Value > this.dateEndTime.Value)
                {
                    MessageBox.Show("输入信息不完整！");
                    return;
                }
                //修改
                //dal_taskrequirement.AddRecord(taskrequirement);
                dal_taskrequirement.Update(taskrequirement);
                dal_taskobsregion.Update(taskobsregion);

                MessageBox.Show("任务记录修改成功！");
                //回传给父窗体消息
                DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();

            }
            catch (Exception es)
            {
                MessageBox.Show(es.ToString());
            }
        }


    }
}
