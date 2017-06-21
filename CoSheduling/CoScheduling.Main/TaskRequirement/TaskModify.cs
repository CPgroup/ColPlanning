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


        private void TaskModify_Load(object sender, EventArgs e)
        {
            //根据任务ID获取任务实体
            taskrequirement = dal_taskrequirement.GetModel(Convert.ToDecimal(task_id));
            //taskobsregion = dal_taskobsregion.GetModel(Convert.ToDecimal(task_id));
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
            //观测区域编辑框内容载入
            this.txtTaskRegion.Text =taskrequirement.PolygonString;
        }

        private void ButtonModify_Click(object sender, EventArgs e)
        {
            //给任务需求实体赋值
            int cnt = 0;//用于记录每个任务观测区域的边界点数
            string CheckedSensors = "";
            decimal LonTemp, LatTemp;
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
                string[] strTxt = this.txtTaskRegion.Text.Split(";".ToCharArray());
                if (strTxt.Length >= 3)
                {
                    taskrequirement.PolygonString = this.txtTaskRegion.Text;
                }
                else
                {
                    MessageBox.Show("区域边界点无法构成多边形！");
                    return;
                }
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
                    string.IsNullOrEmpty(this.txtObsFre.Text) || string.IsNullOrEmpty(CheckedSensors) || string.IsNullOrEmpty(this.txtSpaRes.Text) ||
                     string.IsNullOrEmpty(this.txtTaskRegion.Text) || this.dateStartTime.Value > this.dateEndTime.Value)
                {
                    MessageBox.Show("输入信息不完整！");
                    return;
                }
                //修改
                dal_taskrequirement.Update(taskrequirement);

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
