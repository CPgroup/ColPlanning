using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using AGI;
using AGI.STKObjects;
using AGI.STKUtil;
using CoScheduling.Core.Model;
using AGI.STKesriDisplay;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;

namespace CoScheduling.Main.Coverage
{
    public partial class CoverageMain : CP.WinFormsUI.Docking.DockContent
    {
        public CoverageMain()
        {
            InitializeComponent();
        }
        #region
        //internal static System.Windows.Forms.Button buttonPosition;
        private const short GLOBETAP_INDEX_2D = 1;
        private const short GLOBETAP_INDEX_3D = 0;
        private string m_MapDocument;
        private AGI.STKesriDisplay.AgEsri3dRenderer m_Renderer;
        private ToolOptions m_Options = new ToolOptions();
        private ScenarioTreeView m_TreeViewSTKScenario;
        private AGI.STKesriDisplay._IAgEsri3dRendererEvents_OnDrawProgressEventHandler m_OnDrawProgressEventHandler;
        private AGI.STKesriDisplay._IAgEsri3dRendererEvents_OnDrawEndEventHandler m_OnDrawEndEventHandler;
        private AGI.STKesriDisplay._IAgEsri3dRendererEvents_OnMapDocumentOpenedEventHandler m_OnMapDocumentOpenedEventHandler;
        //private ToolBarButton m_AddDataButton;
        //private IContainer components;
        private AGI.STKesriDisplay._IAgEsri3dRendererEvents_OnMapDocumentClosedEventHandler m_OnMapDocumentClosedEventHandler;
        //private string m_ScDocument;
        public int bigAreaSchemeID;
        internal static CoScheduling.Core.DAL.TASK_SCHEME_LIST dal_taskScheme = new CoScheduling.Core.DAL.TASK_SCHEME_LIST();
        #endregion 
        public AGI.STKObjects.AgStkObjectRoot root;
        public AGI.STKObjects.AgStkObjectRoot stkRoot
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

        public void setStatus(string statusString)
        {
            this.m_StatusBar.Text = statusString;
        }

        #region 工具栏
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        private void scTimeButton_Click(object sender, EventArgs e)
        {
            if (root.CurrentScenario != null)
            {
                //把时间从东八区时间设置为UTC时间
                DateTime currentTime = Convert.ToDateTime(this.toolStrip2.Items[1].Text).AddHours(-8);
                //string setTime = String.Format("{0:r}", currentTime);
                string setTime = "SetAnimation * CurrentTime \"" + currentTime.ToString("dd MMM yyyy HH:mm:ss") + "\"";
                root.ExecuteCommand(setTime);
                //root.ExecuteCommand("SetAnimation * CurrentTime \"16 Sep 1992 01:00:00.000\"");
            }
        }

        private void resetAnimButton_Click(object sender, EventArgs e)
        {
            stkRoot.Rewind();
        }

        private void stepRevAnimButton_Click(object sender, EventArgs e)
        {
            stkRoot.StepBackward();
        }

        private void startRevAnimButton_Click(object sender, EventArgs e)
        {
            stkRoot.PlayBackward();
        }

        private void pauseAnimButton_Click(object sender, EventArgs e)
        {
            stkRoot.Pause();
        }

        private void startFwdAnimButton_Click(object sender, EventArgs e)
        {
            stkRoot.PlayForward();
        }

        private void stepFwdAnimButton_Click(object sender, EventArgs e)
        {
            stkRoot.StepForward();
        }

        private void decTimeStepAnimButton_Click(object sender, EventArgs e)
        {
            stkRoot.Slower();
        }

        private void incTimeStepAnimButton_Click(object sender, EventArgs e)
        {
            stkRoot.Faster();
        }

        private void viewFromButton_Click(object sender, EventArgs e)
        {

        }

        private void homeViewButton_Click(object sender, EventArgs e)
        {
            SendCommand("VO * View Home");
        }

        private void orientNorthButton_Click(object sender, EventArgs e)
        {
            SendCommand("VO * View North");
        }

        private void orientTopButton_Click(object sender, EventArgs e)
        {
            SendCommand("VO * View Top");
        }

        private void zoomInVO_Click(object sender, EventArgs e)
        {
            if (this.tabControlSatCompute.SelectedIndex == GLOBETAP_INDEX_3D)
                axAgUiAxVOCntrl1.ZoomIn();
            else
                axAgUiAx2DCntrl1.ZoomIn();
        }

        private void zoomOutVO_Click(object sender, EventArgs e)
        {
            if (this.tabControlSatCompute.SelectedIndex == GLOBETAP_INDEX_3D)
                SendCommand("VO * View Home");
            else
                axAgUiAx2DCntrl1.ZoomOut();
        }
        #endregion
        
        #region STK操作函数
        private void SendCommand(string command)
        {
            AGI.STKX.IAgExecCmdResult rVal = null;
            try
            {
                rVal = this.axAgUiAxVOCntrl1.Application.ExecuteCommand(command);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        internal static string m_ScDocument;
        public void OpenScenario(String filename)
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
                    //stkRoot.LoadScenario(filename);
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

        public void ScenOpen()
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
                this.OpenScenario(m_ScDocument);
                this.buttonPosition.Enabled = true;
            }
            setStatus("场景已打开，请执行其他操作！");
        }

        private void OpenMap()
        {
            if (m_MapDocument != null && m_MapDocument != "")
            {
                // Check if a scenario is opened                

                // If not, create one
                if (stkRoot.CurrentScenario == null)
                {
                    setStatus("创建新场景...");
                    stkRoot.NewScenario("Scenario1");
                    setStatus("");
                }

                m_TreeViewSTKScenario.InitializeTreeView();

                AGI.STKesriDisplay.AgEsri3dRendererFactory factory
                    = new AGI.STKesriDisplay.AgEsri3dRendererFactory();
                m_Renderer = factory.GetRenderer(1);

                this.m_Options.ApplyTo(m_Renderer);
                if (m_Renderer.MapDocument != null)
                {
                    m_Renderer.CloseMapDocument(AgESTKesriCallOptions.eEsri3dBlocking);
                }

                m_Renderer.OpenMapDocument(m_MapDocument, "");

                m_Renderer.OnDrawProgress += m_OnDrawProgressEventHandler;
                m_Renderer.OnDrawEnd += m_OnDrawEndEventHandler;
                m_Renderer.OnMapDocumentOpened += m_OnMapDocumentOpenedEventHandler;
                m_Renderer.OnMapDocumentClosed += m_OnMapDocumentClosedEventHandler;
            }
        }

        private void UnloadMap()
        {
            if (m_Renderer != null)
            {
                m_Renderer.CloseMapDocument(AgESTKesriCallOptions.eEsri3dBlocking);
                m_Renderer = null;
            }
        }

        private int schemeID;
        /// <summary>
        ///为场景内卫星生成轨道数据
        /// </summary>
        public void GenerateSatelliteOrbit()
        {
            //setStatus("开始生成轨道文件");
            #region 1.获取场景内的卫星及载荷资源
            List<CoScheduling.Core.Model.STKObject> stkObjects = new List<CoScheduling.Core.Model.STKObject>();
            try
            {
                stkObjects = GetSTKObject();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("获取卫星资源错误！计算终止！");
                return;
            }
            #endregion 1.获取场景内的卫星及载荷资源

            #region 2.为每颗卫星生成报告
            //设置文件夹路径
            string filePath = CoScheduling.Core.DBUtility.PubConstant.GetFilePath("Scenario") + schemeID + "Orbit\\";
            //创建文件夹
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            string strStkcmd = "";  //stk命令字符串
            foreach (CoScheduling.Core.Model.STKObject stkObject in stkObjects)
            {
                string file = filePath + stkObject.SAT_STKNAME + ".txt";
                if (!File.Exists(file))
                {
                    strStkcmd = "Report_RM */Satellite/" + stkObject.SAT_STKNAME + " Style \"LLA Position\" TimeStep 1";
                    IAgExecCmdResult resultOne = root.ExecuteCommand(strStkcmd);
                    string[] reports = new string[resultOne.Count - 1];
                    for (int i = 0; i < resultOne.Count - 1; i++)
                    {
                        reports[i] = resultOne[i + 1];
                    }
                    string byrow = string.Join("\r\n", reports);
                    System.IO.StreamWriter sw = new System.IO.StreamWriter(file, false, System.Text.Encoding.GetEncoding("utf-8"));
                    try
                    {
                        sw.Write(byrow);
                        sw.Flush();
                        sw.Close();
                    }
                    catch (IOException e)
                    {

                    }
                }
            }
            #endregion
            //setStatus("轨道文件生成成功！");
        }

        /// <summary>
        /// 获取场景内的卫星及载荷资源
        /// </summary>
        /// <returns></returns>
        public List<CoScheduling.Core.Model.STKObject> GetSTKObject()
        {
            List<CoScheduling.Core.Model.STKObject> stkObjects = new List<CoScheduling.Core.Model.STKObject>();
            //获取场景内的所有对象
            AgExecCmdResult results = (AgExecCmdResult)stkRoot.ExecuteCommand("AllInstanceNames /");
            //取出结果字符串
            string rs = results[0].Substring(1, results[0].Length - 2);
            string[] result = rs.Split(' ');
            for (int num = 0; num < result.Length; num++)
            {
                if (result[num].Contains("Sensor"))
                {
                    int satBSign = result[num].IndexOf("Satellite/") + 10;
                    int satESign = result[num].IndexOf("/Sensor/");
                    int sensorBSign = result[num].LastIndexOf('/') + 1;

                    CoScheduling.Core.Model.STKObject stkObject = new CoScheduling.Core.Model.STKObject();
                    stkObject.SAT_STKNAME = result[num].Substring(satBSign, satESign - satBSign);
                    stkObject.SENSOR_STKNAME = result[num].Substring(sensorBSign);
                    stkObjects.Add(stkObject);
                }
            }
            return stkObjects;
        }
        #endregion

        #region 打开/关闭场景
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*setStatus("正在打开场景，请稍后...");
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
            setStatus("场景已打开，请执行其他操作！");*/

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

        private void closeScenarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //关闭界面中的场景
            stkRoot.CloseScenario();
            this.buttonPosition.Enabled = false;
        }

#endregion
        #region 打开/关闭地图
        private void openMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 获取默认地图路径
            String stkHome = CoScheduling.Core.DBUtility.PubConstant.GetFilePath("Scenario");
            String bordMxdPath = stkHome + @"ArcGIS Data\base.mxd";

            FileDialog dlg = new OpenFileDialog();
            dlg.Title = "Open map";
            dlg.Filter = "ArcMap Document (*.mxd)|*.mxd|All Files (*.*)|*.*";
            dlg.InitialDirectory = stkHome + @"ArcGIS Data";
            dlg.FileName = bordMxdPath;
            dlg.DefaultExt = ".mxd";

            DialogResult dlgRes = dlg.ShowDialog(this);
            Refresh();
            if (dlgRes == DialogResult.OK)
            {
                m_MapDocument = dlg.FileName;
                //SettingsManager.AddRecentMap(m_MapDocument);
                //this.LoadRecentFiles();
                try
                {
                    OpenMap();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void closeMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnloadMap();
        }
        #endregion

        private void buttonPosition_Click(object sender, EventArgs e)
        {
            SendCommand("New / Scenario Test");
        }
        #region
        public void ClearBiaAreaSchemeSat(int SchemeID)
        {
            CoScheduling.Core.DAL.BIGAREA_SATELLITE satelliteList = new CoScheduling.Core.DAL.BIGAREA_SATELLITE();
            CoScheduling.Core.DAL.BIGAREA_SENSOR sensorList = new CoScheduling.Core.DAL.BIGAREA_SENSOR();
            CoScheduling.Core.DAL.BIGAREA_ORBIT orbitList = new CoScheduling.Core.DAL.BIGAREA_ORBIT();
            satelliteList.DeleteScheme(SchemeID);
            sensorList.DeleteScheme(SchemeID);
            orbitList.DeleteScheme(SchemeID);
        }

        public void SetBigAreaSchemeSat(int SchemeID)
        {
            List<CoScheduling.Core.Model.SATELLITE_SENSOR_SELECTED> selectedSatelliteList = new List<CoScheduling.Core.Model.SATELLITE_SENSOR_SELECTED>();
            CoScheduling.Core.DAL.SATELLITE_SENSOR_SELECTED dal_selectedSatelliteList = new CoScheduling.Core.DAL.SATELLITE_SENSOR_SELECTED();

            CoScheduling.Core.DAL.BIGAREA_SATELLITE dal_satelliteList = new CoScheduling.Core.DAL.BIGAREA_SATELLITE();
            CoScheduling.Core.DAL.BIGAREA_SENSOR dal_sensorList = new CoScheduling.Core.DAL.BIGAREA_SENSOR();
            CoScheduling.Core.DAL.BIGAREA_ORBIT dal_orbitList = new CoScheduling.Core.DAL.BIGAREA_ORBIT();
            CoScheduling.Core.DAL.SatelliteOrbit dal_orbit = new CoScheduling.Core.DAL.SatelliteOrbit();
            CoScheduling.Core.DAL.BIGAREA_SCHEME dal_scheme = new CoScheduling.Core.DAL.BIGAREA_SCHEME();
            List<int> satidList = new List<int>();
            CoScheduling.Core.Model.BIGAREA_SATELLITE satelliteList = new CoScheduling.Core.Model.BIGAREA_SATELLITE();
            CoScheduling.Core.Model.BIGAREA_SENSOR sensorList = new CoScheduling.Core.Model.BIGAREA_SENSOR();
            CoScheduling.Core.Model.BIGAREA_ORBIT orbitList = new CoScheduling.Core.Model.BIGAREA_ORBIT();
            CoScheduling.Core.Model.SatelliteOrbit orbit = new CoScheduling.Core.Model.SatelliteOrbit();
            CoScheduling.Core.Model.BIGAREA_SCHEME scheme = new CoScheduling.Core.Model.BIGAREA_SCHEME();
            scheme = dal_scheme.GetModel(SchemeID);

            satidList = dal_selectedSatelliteList.GetCheckedSatID(true);
            satelliteList.SCHEMEID = SchemeID;
            sensorList.SCHEMEID = SchemeID;
            orbitList.SCHEMEID = SchemeID;
            foreach (int satid in satidList)
            {
                satelliteList.SATID = satid;
                dal_satelliteList.Add(satelliteList);
                orbit = dal_orbit.GetModel(satid, scheme.SCHEMEBTIME);

                orbitList.SATID = satid;
                orbitList.SAT_ARGOFPERIGEE = orbit.SAT_ARGOFPERIGEE;
                orbitList.SAT_BSTAR = orbit.SAT_BSTAR;
                orbitList.SAT_ECCENTRICITY = orbit.SAT_ECCENTRICITY;
                orbitList.SAT_INCLINATION = orbit.SAT_INCLINATION;
                orbitList.SAT_MEANANOMALY = orbit.SAT_MEANANOMALY;
                orbitList.SAT_MEANMOTION = orbit.SAT_MEANMOTION;
                orbitList.SAT_MEANMOTIONDOT = orbit.SAT_MEANMOTIONDOT;
                orbitList.SAT_MEANMOTIONDOTDOT = orbit.SAT_MEANMOTIONDOTDOT;
                orbitList.SAT_ORBITEPOCH = orbit.SAT_ORBITEPOCH;
                orbitList.SAT_RAAN = orbit.SAT_RAAN;
                orbitList.SAT_TLE1 = orbit.SAT_TLE1;
                orbitList.SAT_TLE2 = orbit.SAT_TLE2;
                dal_orbitList.Add(orbitList);
            }
            selectedSatelliteList = dal_selectedSatelliteList.GetCheckedList();
            foreach (CoScheduling.Core.Model.SATELLITE_SENSOR_SELECTED sensor in selectedSatelliteList)
            {
                sensorList.SATID = sensor.SAT_ID;
                sensorList.SENSORID = sensor.SENSOR_ID;
                dal_sensorList.Add(sensorList);
            }
        }
        #endregion
    }
}
