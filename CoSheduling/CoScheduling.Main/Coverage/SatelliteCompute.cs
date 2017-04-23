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
    public partial class SatelliteCompute : CP.WinFormsUI.Docking.DockContent
    {
        public SatelliteCompute()
        {
            InitializeComponent();
            //stkRoot = new AGI.STKObjects.AgStkObjectRoot();
        }
        private string m_ScDocument;
        /// <summary>
        /// stk程序根对象
        /// </summary>
        private AGI.STKObjects.AgStkObjectRoot root;
        private AGI.STKObjects.AgStkObjectRoot stkRoot
        {
            get
            {
                if (root == null)
                {
                    root = new AGI.STKObjects.AgStkObjectRootClass();
                }
                return root;
            }
        }
        
        /// <summary>
        /// 状态栏运行状态设置
        /// </summary>
        /// <param name="statusString"></param>
        private void setStatus(string statusString)
        {
            this.m_StatusBar.Text = statusString;
        }
        private void buttonScenOpen_Click(object sender, EventArgs e)
        {
            setStatus("正在打开场景，请稍后...");
            // 获取默认路径
            String stkHome = CoScheduling.Core.DBUtility.PubConstant.GetFilePath("Scenario");
            String geospatialIntelligencePath = stkHome + @"ExampleScenarios\Example.sc";

            FileDialog dlg = new OpenFileDialog();
            dlg.Title = "Open map";
            dlg.Filter = "STK Scenario Document (*.sc)|*.sc|STK VDF File (*.vdf)|*.vdf|All Files (*.*)|*.*";
            dlg.FileName = geospatialIntelligencePath;
            dlg.InitialDirectory = stkHome + @"Data\ExampleScenarios\";
            dlg.DefaultExt = "*.sc";
            DialogResult dlgRes = dlg.ShowDialog(this);
            Refresh();
            if (dlgRes == DialogResult.OK)
            {
                m_ScDocument = dlg.FileName;
                //SettingsManager.AddRecentScenario(m_ScDocument);
                OpenScenario(m_ScDocument);
                this.buttonPosition.Enabled = true;
            }
            setStatus("场景已打开，请执行其他操作！");
        }
        /// <summary>
        /// 通过文件打开一个场景 
        /// </summary>
        /// <param name="filename"></param>
        private void OpenScenario(String filename)
        {
            setStatus("正在载入场景...");
            if (filename.EndsWith(".vdf"))
            {
                stkRoot.LoadVDF(filename, "");
            }
            else
            {
                try
                {
                    stkRoot.LoadScenario(filename);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("错误：" + ex.ToString());
                }
            }
            //m_TreeViewSTKScenario.InitializeTreeView();
            //m_TreeViewSTKScenario.ExpandAll();
            setStatus("欢迎使用卫星任务规划系统！");
        }
    }
}
