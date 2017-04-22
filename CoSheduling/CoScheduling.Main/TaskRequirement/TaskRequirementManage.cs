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
    public partial class TaskRequirementManage : Form
    {
        public TaskRequirementManage()
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

        public void bindTaskInfo(string strWhere)
        {
            dataGridViewTask.AutoGenerateColumns = false;
            this.dataGridViewTask.DataSource = GetTaskInfoDataSet(strWhere).Tables["TaskRequirements_general"];//Table函数的意义？
        }

        private void TaskRequirementManage_Load(object sender, EventArgs e)
        {
            bindTaskInfo("TaskID is not null");
        }

        private void ButtonTaskAdd_Click(object sender, EventArgs e)
        {
            TaskRequirement.TaskAdd newform = new TaskRequirement.TaskAdd();
            newform.StartPosition = FormStartPosition.CenterScreen;
            //子窗体关闭，刷新任务列表
            if (newform.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                bindTaskInfo("");
            }
            newform.Dispose();
        }

        private void ButtonTaskModify_Click(object sender, EventArgs e)
        {
            string task_id = this.dataGridViewTask.CurrentRow.Cells[0].Value.ToString();
            TaskRequirement.TaskModify newform = new TaskRequirement.TaskModify(task_id);
            newform.StartPosition = FormStartPosition.CenterScreen;
            //子窗体关闭，刷新任务列表
            if (newform.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                bindTaskInfo("");
            }
            newform.Dispose();
        }

        private void ButtonTaskDelete_Click(object sender, EventArgs e)
        {
            string task_id = this.dataGridViewTask.CurrentRow.Cells[0].Value.ToString();
            if (MessageBox.Show("确定删除任务记录?此删除不可恢复！", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    dal_taskrequirement.Delete(Convert.ToDecimal(task_id));
                    dal_taskobsregion.Delete(Convert.ToDecimal(task_id));
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("删除失败！失败原因：" + ex.ToString());
                }
            }
            bindTaskInfo("");
        }

    }
}
