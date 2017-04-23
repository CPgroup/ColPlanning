using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CoScheduling.Main.Coverage
{
    public partial class SatelliteResaultList : CP.WinFormsUI.Docking.DockContent
    {
        public SatelliteResaultList()
        {
            InitializeComponent();
        }
        internal static Coverage.SatelliteResaultList SateList;
        private void SatelliteResaultList_Load(object sender, EventArgs e)
        {
            Main.Program.tvSatelliteResault = this.tvSatelliteResault;
            Main.Program.cmsTvSat = this.cmsTvSat;
        }
        #region TreeView操作
        private void tvSatelliteResault_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode node = e.Node;
            string tag = node.Tag.ToString();
            if (tag.StartsWith("S0"))    //为观测方案
            {
                if (node.Nodes[0].Text == "无观测任务") //未加载监测任务
                {
                    Coverage.SatelliteResaultHelper.LoadSatelliteTaskList(Main.Program.myMap, node, this.radioButton1.Checked);
                }
                node.ImageIndex = 1;
            }
            else if (tag.StartsWith("T1"))
            {
                Coverage.SatelliteResaultHelper.LoadSatelliteResaultList(Main.Program.myMap, node, this.radioButton1.Checked);
            }
        }
        private void tvSatelliteResault_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Main.MainInterface.SelectedNodeSat = e.Node;
            string tag = Main.MainInterface.SelectedNodeSat.Tag.ToString();
            Core.Model.TASK_SCHEME_LIST taskScheme = new Core.Model.TASK_SCHEME_LIST();
            Core.DAL.TASK_SCHEME_LIST dal_taskScheme = new Core.DAL.TASK_SCHEME_LIST();
            Core.DAL.SatelliteResault dal_satelliteResault = new Core.DAL.SatelliteResault();
            int schemeid = 0;
            if (tag.StartsWith("S")) //任务结点
            {
                int id;
                int.TryParse(tag.Substring(3), out id);
                schemeid = id;
            }
            else if (tag.StartsWith("T")) //任务结点
            {
                int id;
                int.TryParse(tag.Substring(3), out id);
                schemeid = dal_satelliteResault.getSchemeidByTaskid(id);
            }
            else if (tag.StartsWith("I")) //结果点
            {
                int id;
                int.TryParse(tag.Substring(3), out id);
                schemeid = dal_satelliteResault.getSchemeidByLstrseqid(id);
            }
            if (schemeid != 0)
            {
                taskScheme = dal_taskScheme.GetModel(schemeid);
                this.dateTimePicker1.MaxDate = DateTimePicker.MaximumDateTime;
                this.dateTimePicker1.MinDate = DateTimePicker.MinimumDateTime;
                this.dateTimePicker1.MaxDate = taskScheme.SCHEMEETIME;
                this.dateTimePicker1.MinDate = taskScheme.SCHEMEBTIME;
                this.dateTimePicker2.MaxDate = DateTimePicker.MaximumDateTime;
                this.dateTimePicker2.MinDate = DateTimePicker.MinimumDateTime;
                this.dateTimePicker2.MaxDate = taskScheme.SCHEMEETIME;
                this.dateTimePicker2.MinDate = taskScheme.SCHEMEBTIME;
                this.dateTimePicker1.Value = taskScheme.SCHEMEBTIME;
                this.dateTimePicker2.Value = taskScheme.SCHEMEETIME;
            }


        }
        #endregion TreeView操作

        private void buttonShowResaultByTime_Click(object sender, EventArgs e)
        {
            showSatelliteResault();
        }


        #region 功能函数
        /// <summary>
        /// 在地图上显示成像区域
        /// </summary>
        public  void showSatelliteResault()
        {
            if (Main.MainInterface.SelectedNodeSat == null)
            {
                MessageBox.Show("请先选择观测方案再进行操作！");
                return;
            }
            try
            {
                string tag = Main.MainInterface.SelectedNodeSat.Tag.ToString();

                if (tag.StartsWith("S")) //任务结点
                {
                    int id;
                    int.TryParse(Main.MainInterface.SelectedNodeSat.Tag.ToString().Substring(3), out id);
                    Main.Program.SetStatusLabel("正在加载任务... ...");
                    Coverage.SatelliteResaultHelper.LoadSatelliteResaultAreas(Main.Program.myMap, id, this.dateTimePicker1.Value, this.dateTimePicker2.Value);
                }
                else if (tag.StartsWith("T")) //任务结点
                {
                    int id;
                    int.TryParse(Main.MainInterface.SelectedNodeSat.Tag.ToString().Substring(3), out id);
                    Main.Program.SetStatusLabel("正在加载任务... ...");
                    Coverage.SatelliteResaultHelper.LoadSatelliteResaultAreasByTaskID(Main.Program.myMap, id, this.dateTimePicker1.Value, this.dateTimePicker2.Value);

                }
                else if (tag.StartsWith("I")) //结果点
                {
                    int id;
                    int.TryParse(Main.MainInterface.SelectedNodeSat.Tag.ToString().Substring(3), out id);
                    Main.Program.SetStatusLabel("正在加载任务... ...");
                    Core.Model.SatelliteResault satelliteResault = new Core.Model.SatelliteResault();
                    Core.DAL.SatelliteResault dal_satelliteResault = new Core.DAL.SatelliteResault();
                    satelliteResault = dal_satelliteResault.GetModel(id);
                    //读取并图上显示卫星观测区信息
                    Core.Map.MapHelper map = new Core.Map.MapHelper(Main.Program.myMap);
                    //map.ClearAllElement();
                    Coverage.SatelliteResaultHelper.LoadSatelliteResaultArea(map, satelliteResault);
                }

                Main.Program.SetStatusLabel("就绪.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误：" + ex);
            }
        }
        /// <summary>
        /// 重新加载树内容并刷新
        /// </summary>
        public void treeRefreshSat()
        {
            Coverage.SatelliteResaultHelper.LoadSatelliteSchemeList(this.tvSatelliteResault);
            tvSatelliteResault.Refresh();
            Main.MainInterface.SelectedNodeDisa = null;
        }
        /// <summary>
        /// 定位操作函数
        /// </summary>
        public void positionSat()
        {
            string tag = Main.MainInterface.SelectedNodeSat.Tag.ToString();
            if (Main.MainInterface.SelectedNodeSat == null)
            {
                MessageBox.Show("请先选择要显示的内容再进行操作！");
                return;
            }
            if (tag.StartsWith("S")) //观测方案
            {
                //int id;
                //int.TryParse(tag.Substring(3), out id);
                //Satellite.SatelliteResaultHelper.PositionResaultAreasBySchemeID(this.myMap, id);
                //Core.Map.MapHelper map = new Core.Map.MapHelper(myMap);
                MessageBox.Show("请选择具体的观测区域再进行定位");
            }
            else if (tag.StartsWith("T")) //观测任务
            {
                if (tag.Substring(1, 1) == "0") //为任务空结点
                    MessageBox.Show("未生成观测结果区域");
                else
                {
                    //int id;
                    //int.TryParse(tag.Substring(3), out id);
                    //Satellite.SatelliteResaultHelper.PositionResaultAreasByTaskID(this.myMap, id);
                    //利用助手加载任务信息并定位
                    MessageBox.Show("请选择具体的观测区域再进行定位");
                }
            }
            else if (tag.StartsWith("I")) //观测区域
            {
                int id;
                int.TryParse(tag.Substring(3), out id);
                Coverage.SatelliteResaultHelper.PositionResaultArea(Main.Program.myMap, id);
                Core.Map.MapHelper map = new Core.Map.MapHelper(Main.Program.myMap);
            }
        }
        #endregion

        private void buttonRefreshByOrder_Click(object sender, EventArgs e)
        {
            treeRefreshSat();
        }

        #region cmsTvsat
        private void cmiSatLoad_Click(object sender, EventArgs e)
        {
            showSatelliteResault();
        }

        private void cmiSatShow_Click(object sender, EventArgs e)
        {
            try
            {
                positionSat();
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误：" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmiSatInfo_Click(object sender, EventArgs e)
        {
            if (Main.MainInterface.SelectedNodeSat == null) //如果未选中任何结点，则显示观测方案管理界面
            {
                Coverage.SatlliteTaskManage newform = new Coverage.SatlliteTaskManage();
                newform.StartPosition = FormStartPosition.CenterScreen;
                newform.Show();
            }
            else
            {
                try
                {
                    string tag = Main.MainInterface.SelectedNodeSat.Tag.ToString();

                    if (tag.StartsWith("S")) //选中了观测方案后，显示观测方案信息
                    {
                        int id;
                        int.TryParse(Main.MainInterface.SelectedNodeSat.Tag.ToString().Substring(3), out id);
                        Main.Program.SetStatusLabel("正在加载任务... ...");
                        string schemeid = id.ToString();
                        Coverage.SatelliteTaskResault newform = new Coverage.SatelliteTaskResault(schemeid);
                        newform.StartPosition = FormStartPosition.CenterScreen;
                        newform.Show();
                    }
                    else if (tag.StartsWith("T")) //显示观测任务所对应的观测方案信息
                    {
                        int id;
                        int.TryParse(Main.MainInterface.SelectedNodeSat.Tag.ToString().Substring(3), out id);
                        Main.Program.SetStatusLabel("正在加载任务... ...");
                        Coverage.TaskSchemeDetail newform = new Coverage.TaskSchemeDetail(id);
                        newform.StartPosition = FormStartPosition.CenterScreen;
                        newform.Show();

                    }
                    else if (tag.StartsWith("I")) //显示具体的观测结果信息
                    {
                        int id;
                        int.TryParse(Main.MainInterface.SelectedNodeSat.Tag.ToString().Substring(3), out id);
                        Main.Program.SetStatusLabel("正在加载任务... ...");
                        Coverage.SatelliteResaultDetail newform = new Coverage.SatelliteResaultDetail(id);
                        newform.StartPosition = FormStartPosition.CenterScreen;
                        newform.Show();
                    }

                    Main.Program.SetStatusLabel("就绪.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("错误：" + ex);
                }
            }
        }

        private void cmiSatRefresh_Click(object sender, EventArgs e)
        {
            treeRefreshSat();
        }

        private void cmiSatTask_Click(object sender, EventArgs e)
        {
            if (Main.MainInterface.SelectedNodeSat == null) //如果未选中任何结点，则显示观测方案管理界面
            {
                MessageBox.Show("请先选择要显示的观测方案下的具体观测任务再进行操作！");
                return;
            }
            else
            {
                try
                {
                    string tag = Main.MainInterface.SelectedNodeSat.Tag.ToString();
                    if (tag.StartsWith("S")) //显示观测任务所对应的观测方案信息
                    {
                        MessageBox.Show("请先选择要显示的观测任务再进行操作！");
                    }
                    else if (tag.StartsWith("T")) //显示观测任务所对应的观测方案信息
                    {
                        int id;
                        int.TryParse(Main.MainInterface.SelectedNodeSat.Tag.ToString().Substring(3), out id);
                        Main.Program.SetStatusLabel("正在加载任务... ...");
                        Core.Model.TASK_LAYOUT_LIST taskLayoutList = new Core.Model.TASK_LAYOUT_LIST();
                        Core.DAL.TASK_LAYOUT_LIST dal_taskLayoutList = new Core.DAL.TASK_LAYOUT_LIST();
                        taskLayoutList = dal_taskLayoutList.GetModel(id);
                        //读取并图上显示卫星观测区信息
                        Core.Map.MapHelper map = new Core.Map.MapHelper(Main.Program.myMap);
                        //map.ClearAllElement();
                        Coverage.SatelliteResaultHelper.LoadSatelliteTaskArea(map, taskLayoutList);
                        Coverage.SatelliteResaultHelper.PositionTaskArea(Main.Program.myMap, id);

                    }
                    else if (tag.StartsWith("I")) //显示具体的观测结果信息
                    {
                        int id;
                        int.TryParse(Main.MainInterface.SelectedNodeSat.Tag.ToString().Substring(3), out id);
                        Main.Program.SetStatusLabel("正在加载任务... ...");
                        Core.Model.TASK_LAYOUT_LIST taskLayoutList = new Core.Model.TASK_LAYOUT_LIST();
                        Core.DAL.TASK_LAYOUT_LIST dal_taskLayoutList = new Core.DAL.TASK_LAYOUT_LIST();
                        Core.DAL.ImgLayoutTempTimewindow dal_imgTimeWindow = new Core.DAL.ImgLayoutTempTimewindow();
                        taskLayoutList = dal_taskLayoutList.GetModel(Convert.ToInt32(dal_imgTimeWindow.GetModel(id.ToString()).TASKID));
                        //读取并图上显示卫星观测区信息
                        Core.Map.MapHelper map = new Core.Map.MapHelper(Main.Program.myMap);
                        //map.ClearAllElement();
                        Coverage.SatelliteResaultHelper.LoadSatelliteTaskArea(map, taskLayoutList);
                    }

                    Main.Program.SetStatusLabel("就绪.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("错误：" + ex);
                }
            }

        }
        #endregion

        private void tvSatelliteResault_AfterSelect_1(object sender, TreeViewEventArgs e)
        {
            Main.MainInterface.SelectedNodeSat = e.Node;
            string tag = Main.MainInterface.SelectedNodeSat.Tag.ToString();
            Core.Model.TASK_SCHEME_LIST taskScheme = new Core.Model.TASK_SCHEME_LIST();
            Core.DAL.TASK_SCHEME_LIST dal_taskScheme = new Core.DAL.TASK_SCHEME_LIST();
            Core.DAL.SatelliteResault dal_satelliteResault = new Core.DAL.SatelliteResault();
            int schemeid = 0;
            if (tag.StartsWith("S")) //任务结点
            {
                int id;
                int.TryParse(tag.Substring(3), out id);
                schemeid = id;
            }
            else if (tag.StartsWith("T")) //任务结点
            {
                int id;
                int.TryParse(tag.Substring(3), out id);
                schemeid = dal_satelliteResault.getSchemeidByTaskid(id);
            }
            else if (tag.StartsWith("I")) //结果点
            {
                int id;
                int.TryParse(tag.Substring(3), out id);
                schemeid = dal_satelliteResault.getSchemeidByLstrseqid(id);
            }
            if (schemeid != 0)
            {
                taskScheme = dal_taskScheme.GetModel(schemeid);
                this.dateTimePicker1.MaxDate = DateTimePicker.MaximumDateTime;
                this.dateTimePicker1.MinDate = DateTimePicker.MinimumDateTime;
                this.dateTimePicker1.MaxDate = taskScheme.SCHEMEETIME;
                this.dateTimePicker1.MinDate = taskScheme.SCHEMEBTIME;
                this.dateTimePicker2.MaxDate = DateTimePicker.MaximumDateTime;
                this.dateTimePicker2.MinDate = DateTimePicker.MinimumDateTime;
                this.dateTimePicker2.MaxDate = taskScheme.SCHEMEETIME;
                this.dateTimePicker2.MinDate = taskScheme.SCHEMEBTIME;
                this.dateTimePicker1.Value = taskScheme.SCHEMEBTIME;
                this.dateTimePicker2.Value = taskScheme.SCHEMEETIME;
            }
        }

    }
}
