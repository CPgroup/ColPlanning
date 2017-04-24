﻿using System;
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
    public partial class TaskAdd : Form
    {
        public TaskAdd()
        {
            InitializeComponent();
        }

        private void TaskAdd_Load(object sender, EventArgs e)
        {
            this.txtTaskID.Text = "2";
            this.txtTaskName.Text = "长江流域洪涝";
            this.txtPriority.Text = "3";
            this.txtSpaRes.Text = "100";
            this.txtObsFre.Text = "1";
            this.txtResTime.Text = "2";

            this.txtMinLon.Text = "110";
            this.txtMinLat.Text = "120";
            this.txtMaxLon.Text = "130";
            this.txtMaxLat.Text = "140";
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            //任务需求实体类，访问类对象建立
            CoScheduling.Core.Model.TaskRequirement task_requirement = new Core.Model.TaskRequirement();
            CoScheduling.Core.DAL.TaskRequirement dal_task_requirement = new Core.DAL.TaskRequirement();
            //任务观测区域边界点实体类，访问类对象建立(边界点实体需要修改，边界点的集合)
            //List<CoScheduling.Core.Model.TaskRegionPoint> task_region_point = new List<Core.Model.TaskRegionPoint>();
            //CoScheduling.Core.DAL.TaskRegionPoint dal_task_region_point=new Core.DAL.TaskRegionPoint();
            CoScheduling.Core.Model.TaskObsRegion task_obsregion = new Core.Model.TaskObsRegion();
            CoScheduling.Core.DAL.TaskObsRegion dal_task_obsregion = new Core.DAL.TaskObsRegion();


            //给任务需求实体赋值
            string CheckedSensors = "";//存储所需的观测资源传感器类型
            try
            {
                task_requirement.TaskID = Convert.ToDecimal(this.txtTaskID.Text);
                task_requirement.TaskName = this.txtTaskName.Text;
                task_requirement.TaskPriority = Convert.ToDecimal(this.txtPriority.Text);
                task_requirement.SubmissionTime = DateTime.Now;//获取当前系统时间
                task_requirement.DisasterType = this.comboBox_DisaType.SelectedItem.ToString();
                task_requirement.StartTime = this.dateStartTime.Value;
                task_requirement.EndTime = this.dateEndTime.Value;
                task_requirement.RespondingTime = Convert.ToDecimal(this.txtResTime.Text);
                task_requirement.ObservationFrequency = Convert.ToDecimal(this.txtObsFre.Text);
                //找出所有的打钩的CheckBox，然后以空格为分割存入CheckedSensors字符串
                foreach (Control control in groupBox_SensorTypes.Controls)
                {
                    if ((control as CheckBox).Checked)
                    {
                        CheckedSensors = CheckedSensors + (control as CheckBox).Text + " ";
                    }
                }

                task_requirement.SensorNeeded = CheckedSensors; //Checkbox的用法
                task_requirement.SpaceResolution = Convert.ToDecimal(this.txtSpaRes.Text);
                task_requirement.OccurTime = DateTime.Now;
                //给观测区域经纬度范围赋值
                task_obsregion.TaskID = task_requirement.TaskID;
                task_obsregion.MinLon = Convert.ToDecimal(this.txtMinLon.Text);
                task_obsregion.MaxLon = Convert.ToDecimal(this.txtMaxLon.Text);
                task_obsregion.MinLat = Convert.ToDecimal(this.txtMinLat.Text);
                task_obsregion.MaxLat = Convert.ToDecimal(this.txtMaxLat.Text);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("请输入合法参数！");
                return;
            }

            try
            {
                //检查是否为空,应该只是必填项检查
                if (string.IsNullOrEmpty(this.txtTaskID.Text) || string.IsNullOrEmpty(this.txtTaskName.Text) || string.IsNullOrEmpty(this.comboBox_DisaType.SelectedItem.ToString()) ||
                    string.IsNullOrEmpty(this.dateStartTime.Text) || string.IsNullOrEmpty(this.dateEndTime.Text) || string.IsNullOrEmpty(this.txtResTime.Text) ||
                    string.IsNullOrEmpty(this.txtObsFre.Text) || string.IsNullOrEmpty(CheckedSensors) || string.IsNullOrEmpty(this.txtSpaRes.Text) ||
                     string.IsNullOrEmpty(this.txtMinLon.Text) || string.IsNullOrEmpty(this.txtMinLat.Text) || string.IsNullOrEmpty(this.txtMaxLon.Text) ||
                     string.IsNullOrEmpty(this.txtMaxLat.Text) ||
                    this.dateStartTime.Value > this.dateEndTime.Value)
                {
                    MessageBox.Show("输入信息不完整！");
                    return;
                }
                //添加
                dal_task_requirement.AddRecord(task_requirement);
                dal_task_obsregion.Add(task_obsregion);
                MessageBox.Show("任务记录添加成功！");
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
