using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;
using System.Threading;
using Microsoft.Office.Interop.Word;
using ESRI.ArcGIS.NetworkAnalyst;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.DataSourcesRaster;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.DataManagementTools;
using ESRI.ArcGIS.Geoprocessor;
using ESRI.ArcGIS.Geoprocessing;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.AnalysisTools;
using CP.WinFormsUI;
using AGI;
using AGI.STKObjects;
using AGI.STKUtil;
using CoScheduling.Core.Model;
using AGI.STKesriDisplay;


namespace CoScheduling.Main
{
    public static class MainInterfaceCOV
    {
        public static void SetFrameworkControl(System.Windows.Forms.Form pMainForm,
                                                System.Windows.Forms.Form pSplashForm,
                                                System.Windows.Forms.StatusStrip pStatus,
                                                System.Windows.Forms.ToolStripStatusLabel pLabel,
                                                System.Windows.Forms.ToolStripProgressBar pProgress,
                                                CP.WinFormsUI.Docking.DockPanel pPanel,
                                                System.Windows.Forms.ToolStripStatusLabel pCoor)
        {

            //获取连接数据库字符串
            CoScheduling.Core.DBUtility.PubConstant.SetConnectionString();

            Program.gDockPane = pPanel;
            Program.gStatusLabel = pLabel;
            Program.gProgressBar = pProgress;
            Program.gMainForm = pMainForm;
            Program.gSplashForm = pSplashForm;
            Program.gStatusStrip = pStatus;
            Program.gLabelCoor = pCoor;
            //将主窗口控件传给Core类
            Core.Program.SetFrameworkControl(pMainForm, pStatus, pLabel, pProgress, pPanel, pCoor);
            //将主窗口控件传给MonitorTask类
            CoScheduling.MonitorTask.Program.SetFrameworkControl(pMainForm, pStatus, pLabel, pProgress, pPanel, pCoor);

            Program.gStatusLabel.Text = "正在加载地图控件，请稍候...";
            Program.gStatusStrip.Refresh();
            //Program.ShowMapControl();                            //加载地图控件   
            Program.ShowCoverage();                                //加载STK控件
            //Program.ShowFormUAVList();                           //加载无人机列表
            //Program.ShowFormDisaList();                          //加载灾区列表
            if (Program.gSplashForm != null)
                if (!Program.gSplashForm.IsDisposed)
                    Program.gSplashForm.Dispose();
            System.Diagnostics.Debug.WriteLine("Load ok!");
            Program.gStatusLabel.Text = "就绪.";
        }

        #region 覆盖分析控件
        //public int bigAreaSchemeID;
        internal static Coverage.SelectBigAreaScheme sclectscheme;

        //新方案
        public static void NewPlan()
        {
            CoScheduling.Main.Coverage.BigAreaScheme ConfigDialog = new CoScheduling.Main.Coverage.BigAreaScheme();
                //BigAreaScheme ConfigDialog = new BigAreaScheme();
            ConfigDialog.ShowDialog();
            CoScheduling.Core.Model.BIGAREA_SCHEME Scheme = new CoScheduling.Core.Model.BIGAREA_SCHEME();
            CoScheduling.Core.DAL.BIGAREA_SCHEME dal_Scheme = new CoScheduling.Core.DAL.BIGAREA_SCHEME();
            if (ConfigDialog.DialogResult == DialogResult.OK)//确认配置窗口的（按钮2）已点击
            {
                try
                {
                    //观测结果清空
                    //CoScheduling.Main.Coverage.Da

                    //此处有问题

                    PlanRes.dataGridViewTimewindow.DataSource = null;
                    PlanRes.dataGridViewResault.DataSource = null;
                     

                    formCOV.bigAreaSchemeID = ConfigDialog.Schemeid;
                    Scheme = dal_Scheme.GetModel(formCOV.bigAreaSchemeID);
                    ConfigDialog.Close();//关闭配置窗口
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("方案生成失败！");
                    formCOV.setStatus("欢迎使用卫星任务规划系统！");
                }
            }
        }

        //方案配置
        public static void PlanCon()
        {
            CoScheduling.Main.Coverage.SelectBigAreaScheme ConfigDialog = new CoScheduling.Main.Coverage.SelectBigAreaScheme();
            ConfigDialog.ShowDialog();
            CoScheduling.Core.Model.BIGAREA_SCHEME Scheme = new CoScheduling.Core.Model.BIGAREA_SCHEME();
            CoScheduling.Core.DAL.BIGAREA_SCHEME dal_Scheme = new CoScheduling.Core.DAL.BIGAREA_SCHEME();
            if (ConfigDialog.DialogResult == DialogResult.OK)//确认配置窗口的（按钮2）已点击
            {
                try
                {
                    //观测结果清空
                    //this.dataGridViewTimewindow.DataSource = null;
                    //this.dataGridViewResault.DataSource = null;
                    formCOV.bigAreaSchemeID = ConfigDialog.Schemeid;
                    Scheme = dal_Scheme.GetModel(formCOV.bigAreaSchemeID);
                    ConfigDialog.Close();//关闭配置窗口
                    //关闭界面中的场景
                    formCOV.stkRoot.CloseScenario();
                    //对于重复配置的条件下，应该先清除原有的配置方案
                    formCOV.ClearBiaAreaSchemeSat(formCOV.bigAreaSchemeID);
                    //根据最新任务ID配置卫星及载荷资源
                    formCOV.SetBigAreaSchemeSat(formCOV.bigAreaSchemeID);
                    sclectscheme.Text = Scheme.SCHEMENAME + "覆盖分析方案";
                    MessageBox.Show(Scheme.SCHEMENAME + "覆盖分析方案配置成功！");
                    //设置状态栏状态
                    formCOV.setStatus("当前为：" + Scheme.SCHEMENAME + "覆盖分析方案");
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("方案选择失败！");
                    formCOV.setStatus("欢迎使用卫星任务规划系统！");
                }
            }
        }

        /// <summary>
        /// 覆盖报告
        /// </summary>
        public static void CoverageRep()
        {
            CheckBigAreaSchemeID();
            DateTime time1 = System.DateTime.Now;
            string stkcmd = "";
            string filePath1 = CoScheduling.Core.DBUtility.PubConstant.GetFilePath("BigScenario") + formCOV.bigAreaSchemeID + "Report1\\";
            string filePath2 = CoScheduling.Core.DBUtility.PubConstant.GetFilePath("BigScenario") + formCOV.bigAreaSchemeID + "Report2\\";
            //创建文件夹
            if (!Directory.Exists(filePath1))
            {
                Directory.CreateDirectory(filePath1);
            }
            if (!Directory.Exists(filePath2))
            {
                Directory.CreateDirectory(filePath2);
            }
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


            #region 5.stk命令创建目标
            List<CoScheduling.Core.Model.BIGAREA_TARGET> targetList = new List<CoScheduling.Core.Model.BIGAREA_TARGET>();
            CoScheduling.Core.DAL.BIGAREA_TARGET dal_Target = new CoScheduling.Core.DAL.BIGAREA_TARGET();
            targetList = dal_Target.GetList("SCHEMEID=" + formCOV.bigAreaSchemeID);
            string targetTempName = "target";
            foreach (CoScheduling.Core.Model.BIGAREA_TARGET target in targetList)
            {
                //获取点目标信息
                string targetName = target.TARGETNAME;
                string targetLongitude = target.TARGETLON.ToString();
                string targetLatitude = target.TARGETLAT.ToString();
                ////生成点目标
                //stkcmd = "New / */Target " + targetName;
                //try
                //{
                //    stkRoot.ExecuteCommand(stkcmd);
                //}
                //catch (System.Exception ex)
                //{
                //    MessageBox.Show("创建点目标" + targetName + "失败！");
                //    continue;
                //}
                //为点目标重新赋值
                stkcmd = "Rename */Target/" + targetTempName + " " + targetName;
                formCOV.stkRoot.ExecuteCommand(stkcmd);
                targetTempName = targetName;
                //生成点坐标
                stkcmd = "SetPosition */Target/" + targetName + " Geodetic " + targetLatitude + " " + targetLongitude + " 0";
                try
                {
                    formCOV.stkRoot.ExecuteCommand(stkcmd);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("创建点目标" + targetName + "坐标失败！");
                    continue;
                }
                //this.viewFromButton.DropDownItems.Add("Target/" + targetName);
                string file1 = filePath1 + targetName + "Coverage.txt";
                string file2 = filePath2 + targetName + "ProbabilityCoverage.txt";
                foreach (CoScheduling.Core.Model.STKObject stkObject in stkObjects)
                {
                    try
                    {
                        stkcmd = "Cov */Target/" + targetName + " Asset */Satellite/" + stkObject.SAT_STKNAME + "/Sensor/" + stkObject.SENSOR_STKNAME + " Assign";
                        formCOV.stkRoot.ExecuteCommand(stkcmd);
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show("配置资源失败！");
                        return;
                    }
                }
                stkcmd = "Cov_RM */Target/" + targetName + " Access Compute \"Coverage\"";
                IAgExecCmdResult resultOne = formCOV.root.ExecuteCommand(stkcmd);
                string[] reports = new string[resultOne.Count - 1];
                for (int i = 0; i < resultOne.Count - 1; i++)
                {
                    reports[i] = resultOne[i + 1];
                }
                string byrow = string.Join("\r\n", reports);
                System.IO.StreamWriter sw = new System.IO.StreamWriter(file1, false, System.Text.Encoding.ASCII);
                try
                {
                    sw.Write(byrow);
                    sw.Flush();
                    sw.Close();
                }
                catch (IOException ex)
                {

                }
                stkcmd = "Cov_RM */Target/" + targetName + " Access Compute \"Probability of Coverage\"";
                IAgExecCmdResult resultTwo = formCOV.root.ExecuteCommand(stkcmd);
                string[] reports2 = new string[resultTwo.Count - 1];
                for (int i = 0; i < resultTwo.Count - 1; i++)
                {
                    reports2[i] = resultTwo[i + 1];
                }
                string byrow2 = string.Join("\r\n", reports2);
                System.IO.StreamWriter sw2 = new System.IO.StreamWriter(file2, false, System.Text.Encoding.ASCII);
                try
                {
                    sw2.Write(byrow2);
                    sw2.Flush();
                    sw2.Close();
                }
                catch (IOException ex)
                {

                }

            }
            #endregion 5.stk命令创建目标

            #region 2.获取场景内的目标
            ////2.获取场景内的目标
            //List<CoScheduling.Core.Model.STKTarget> stkTargets = new List<CoScheduling.Core.Model.STKTarget>();
            //try
            //{
            //    stkTargets = GetSTKTarget();
            //}
            //catch (System.Exception ex)
            //{
            //    MessageBox.Show("获取地面目标错误！计算终止！");
            //    return;
            //}
            //#endregion 2.获取场景内的目标

            //#region 3.对每个目标生成报告
            //foreach (CoScheduling.Core.Model.STKTarget stkTarget in stkTargets)
            //{
            //    string file1 = filePath1 + stkTarget.TARGET_NAME + "Coverage.txt";
            //    string file2 = filePath2 + stkTarget.TARGET_NAME + "ProbabilityCoverage.txt";
            //    foreach (CoScheduling.Core.Model.STKObject stkObject in stkObjects)
            //    {
            //        try
            //        {
            //            stkcmd="Cov */Target/"+stkTarget.TARGET_NAME+" Asset */Satellite/"+stkObject.SAT_STKNAME+"/Sensor/"+stkObject.SENSOR_STKNAME+" Assign";
            //            stkRoot.ExecuteCommand(stkcmd);
            //        }
            //        catch (System.Exception ex)
            //        {
            //            MessageBox.Show("配置资源失败！");
            //            return;
            //        }
            //    }
            //    stkcmd = "Cov_RM */Target/" + stkTarget.TARGET_NAME + " Access Compute \"Coverage\"";
            //    IAgExecCmdResult resultOne = root.ExecuteCommand(stkcmd);
            //    string[] reports = new string[resultOne.Count - 1];
            //    for (int i = 0; i < resultOne.Count - 1; i++)
            //    {
            //        reports[i] = resultOne[i + 1];
            //    }
            //    string byrow = string.Join("\r\n", reports);
            //    System.IO.StreamWriter sw = new System.IO.StreamWriter(file1, false, System.Text.Encoding.ASCII);
            //    try
            //    {
            //        sw.Write(byrow);
            //        sw.Flush();
            //        sw.Close();
            //    }
            //    catch (IOException ex)
            //    {

            //    }
            //    stkcmd = "Cov_RM */Target/" + stkTarget.TARGET_NAME + " Access Compute \"Probability of Coverage\"";
            //    IAgExecCmdResult resultTwo = root.ExecuteCommand(stkcmd);
            //    string[] reports2 = new string[resultTwo.Count - 1];
            //    for (int i = 0; i < resultTwo.Count - 1; i++)
            //    {
            //        reports2[i] = resultTwo[i + 1];
            //    }
            //    string byrow2 = string.Join("\r\n", reports2);
            //    System.IO.StreamWriter sw2 = new System.IO.StreamWriter(file2, false, System.Text.Encoding.ASCII);
            //    try
            //    {
            //        sw2.Write(byrow2);
            //        sw2.Flush();
            //        sw2.Close();
            //    }
            //    catch (IOException ex)
            //    {

            //    }
            //}
            #endregion 3.对每个目标生成报告
            DateTime time2 = System.DateTime.Now;
            MessageBox.Show("报告生成完毕！耗时：" + (time2 - time1));
        }

        /// <summary>
        /// 目标配置
        /// </summary>
      
        /// <summary>
        /// 配置函数1
        /// </summary>
        public static void CheckBigAreaSchemeID()
        {
            if (formCOV.bigAreaSchemeID == 0)
            {
                CoScheduling.Main.Coverage.SelectBigAreaScheme ConfigDialog = new CoScheduling.Main.Coverage.SelectBigAreaScheme();
                ConfigDialog.ShowDialog();
                if (ConfigDialog.DialogResult == DialogResult.OK)
                {
                    formCOV.bigAreaSchemeID = ConfigDialog.Schemeid;
                }
                else
                {
                    CoScheduling.Core.DAL.BIGAREA_SCHEME dal_scheme = new CoScheduling.Core.DAL.BIGAREA_SCHEME();
                    formCOV.bigAreaSchemeID = dal_scheme.GetLatestSchemeid();
                }
            }

        }
        
        /// <summary>
        /// 配置函数2
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static  List<CoScheduling.Main.Coverage.TargetPoint> GetPointList(string file)
        {
            StreamReader sr = new StreamReader(file);
            string pointsStr = sr.ReadToEnd();
            sr.Close();
            pointsStr = pointsStr.Replace("\r\n", ";");
            string[] pointListStr = pointsStr.Split(';');
            string[] pointStr = new string[3];
            List<CoScheduling.Main.Coverage.TargetPoint> pointList = new List<CoScheduling.Main.Coverage.TargetPoint>();
            for (int i = 1; i < pointListStr.Length; i++)
            {
                CoScheduling.Main.Coverage.TargetPoint point = new CoScheduling.Main.Coverage.TargetPoint();
                pointStr = pointListStr[i].Split(',');
                point.PointID = Convert.ToInt32(pointStr[0]);
                point.PointX = Convert.ToDecimal(pointStr[1]);
                point.PointY = Convert.ToDecimal(pointStr[2]);
                pointList.Add(point);
            }
            return pointList;
        }

        /// <summary>
        /// 获取场景内的卫星及载荷资源
        /// </summary>
        /// <returns></returns>
        public static List<CoScheduling.Core.Model.STKObject> GetSTKObject()
        {
            List<CoScheduling.Core.Model.STKObject> stkObjects = new List<CoScheduling.Core.Model.STKObject>();
            //获取场景内的所有对象
            AgExecCmdResult results = (AgExecCmdResult)formCOV.stkRoot.ExecuteCommand("AllInstanceNames /");
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
        #region 窗体控件函数
        public static void addDateTimePicker(DateTime start, DateTime end)
        {
            //工具栏时间
            //在工具栏中加入时间
            DateTimePicker dtp = new DateTimePicker();
            dtp.Format = DateTimePickerFormat.Custom;//自定义格式
            dtp.CustomFormat = "yyyy-MM-dd HH:mm:ss";//自定义格式
            dtp.Width = 200;
            dtp.MinDate = start;
            dtp.MaxDate = end;
            dtp.Value = start;
            if (formCOV.toolStrip2.Items.Count == 3)
            {
                formCOV.toolStrip2.Items.Remove(formCOV.toolStrip2.Items[1]);
            }
            formCOV.toolStrip2.Items.Insert(1, new ToolStripControlHost(dtp));
        }
        #endregion 窗体控件函数
        /// <summary>
        /// 获取卫星星历数据
        /// </summary>
        /// <param name="satid"></param>
        /// <returns></returns>
        public static string getBigAreaSatelliteTleDate(decimal satid, decimal schemeid)
        {
            CoScheduling.Core.Model.BIGAREA_ORBIT satelliteOrbit = new CoScheduling.Core.Model.BIGAREA_ORBIT();
            CoScheduling.Core.DAL.BIGAREA_ORBIT dal_satelliteOrbit = new CoScheduling.Core.DAL.BIGAREA_ORBIT();
            try
            {
                satelliteOrbit = dal_satelliteOrbit.GetModel(satid, schemeid);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("获取卫星数据出错，请检查数据库连接！");
            }
            string satelliteTLEString = "";
            try
            {
                satelliteTLEString = satelliteOrbit.SATID.ToString() + " ";
                satelliteTLEString += satelliteOrbit.SAT_ORBITEPOCH + " ";
                satelliteTLEString += satelliteOrbit.SAT_MEANMOTION + " ";
                satelliteTLEString += satelliteOrbit.SAT_ECCENTRICITY + " ";
                satelliteTLEString += satelliteOrbit.SAT_INCLINATION + " ";
                satelliteTLEString += satelliteOrbit.SAT_ARGOFPERIGEE + " ";
                satelliteTLEString += satelliteOrbit.SAT_RAAN + " ";
                satelliteTLEString += satelliteOrbit.SAT_MEANANOMALY + " ";
                satelliteTLEString += satelliteOrbit.SAT_MEANMOTIONDOT + " ";
                satelliteTLEString += satelliteOrbit.SAT_MEANMOTIONDOTDOT + " ";
                satelliteTLEString += satelliteOrbit.SAT_BSTAR;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("卫星轨道数据问题，请重新配置卫星轨道数据！");
            }
            return satelliteTLEString;
        }
        /// <summary>
        /// 创建场景
        /// </summary>
        public static void EstablishScen()
        {
            CheckBigAreaSchemeID();
            #region 1.设置文件保存目录
            //1.设置文件保存目录
            //设置文件夹路径
            string filePath = CoScheduling.Core.DBUtility.PubConstant.GetFilePath("BigScenario") + formCOV.bigAreaSchemeID + "\\";
            //创建文件夹
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            #endregion 1.设置文件保存目录

            #region 2.stk命令创建场景环境
            //2.stk命令创建场景环境
            //执行stk命令的时候，需要配置线程环境为英语环境
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-GB", true);
            System.Threading.Thread.CurrentThread.CurrentCulture = culture;
            //创建场景

            string stkcmd = "New / Scenario See_DC";
            try
            {
                formCOV.stkRoot.ExecuteCommand(stkcmd);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("创建场景出错！");
                return;
            }
            //配置场景环境
            //开始时间、结束时间
            CoScheduling.Core.Model.BIGAREA_SCHEME Scheme = new CoScheduling.Core.Model.BIGAREA_SCHEME();
            CoScheduling.Core.DAL.BIGAREA_SCHEME dal_Scheme = new CoScheduling.Core.DAL.BIGAREA_SCHEME();
            Scheme = dal_Scheme.GetModel(formCOV.bigAreaSchemeID);
            //因为stk程序默认使用是UTC时间，与中国所用东八区时间相比晚8小时
            DateTime startTime = Scheme.SCHEMEBTIME.AddHours(-8);
            DateTime endTime = Scheme.SCHEMEETIME.AddHours(-8);
            stkcmd = "SetTimePeriod * \"" + startTime.ToString("dd MMM yyyy HH:mm:ss") + "\" \"" + endTime.ToString("dd MMM yyyy HH:mm:ss") + "\"";
            try
            {
                formCOV.stkRoot.ExecuteCommand(stkcmd);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("设置场景时间出错！");
                return;
            }
            //Epoch时间
            stkcmd = "SetEpoch * \"" + startTime.ToString("dd MMM yyyy HH:mm:ss") + "\"";
            try
            {
                formCOV.stkRoot.ExecuteCommand(stkcmd);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("设置场景Epoch出错！");
                return;
            }
            //步长
            stkcmd = "Animate * SetValues \"" + startTime.ToString("dd MMM yyyy HH:mm:ss") + "\" 60 0.5";
            try
            {
                formCOV.stkRoot.ExecuteCommand(stkcmd);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("设置场景步长出错！");
                return;
            }
            //工具栏时间
            //在工具栏中加入时间
            addDateTimePicker(startTime.AddHours(8), endTime.AddHours(8));
            #endregion 2.stk命令创建场景环境

            #region 3.stk命令创建卫星资源
            //3.stk命令创建卫星资源
            //获取任务专属卫星资源
            List<CoScheduling.Core.Model.BIGAREA_SATELLITE> SatelliteList = new List<CoScheduling.Core.Model.BIGAREA_SATELLITE>();
            CoScheduling.Core.DAL.BIGAREA_SATELLITE dal_Satellite = new CoScheduling.Core.DAL.BIGAREA_SATELLITE();
            try
            {
                SatelliteList = dal_Satellite.GetList("SCHEMEID=" + formCOV.bigAreaSchemeID);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("获取卫星数据出错，请检查数据库连接！");
                return;
            }
            //视角列表清空
            formCOV.viewFromButton.DropDownItems.Clear();
            CoScheduling.Core.Model.T_PUB_SATELLITE sat = new CoScheduling.Core.Model.T_PUB_SATELLITE();
            CoScheduling.Core.DAL.T_PUB_SATELLITE dal_sat = new CoScheduling.Core.DAL.T_PUB_SATELLITE();
            //创建卫星
            foreach (CoScheduling.Core.Model.BIGAREA_SATELLITE satellite in SatelliteList)
            {
                sat = dal_sat.GetModel(satellite.SATID);
                //卫星
                stkcmd = "New / */Satellite " + sat.SAT_ID;
                try
                {
                    formCOV.stkRoot.ExecuteCommand(stkcmd);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("创建" + sat.SAT_ID + "失败！");
                }
                //卫星轨道参数模型
                stkcmd = "SetState */Satellite/" + sat.SAT_ID;
                stkcmd += " " + sat.SAT_ROPAGATOR;
                stkcmd += " \"" + startTime.ToString("dd MMM yyyy HH:mm:ss") + "\" \"" + endTime.ToString("dd MMM yyyy HH:mm:ss") + "\"";
                stkcmd += " " + sat.SAT_STEP + " ";
                string satelliteTLEPara = getBigAreaSatelliteTleDate(sat.SAT_ID, formCOV.bigAreaSchemeID);
                stkcmd += satelliteTLEPara;
                try
                {
                    formCOV.stkRoot.ExecuteCommand(stkcmd);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("创建" + sat.SAT_ID + "轨道模型失败！");
                    continue;
                }
                formCOV.viewFromButton.DropDownItems.Add("Satellite/" + sat.SAT_ID);
            }
            #endregion 3.stk命令创建卫星资源

            #region 4.stk命令创建卫星载荷
            //4.stk命令创建卫星载荷
            //获取任务专属载荷资源
            List<CoScheduling.Core.Model.BIGAREA_SENSOR> taskSensorList = new List<CoScheduling.Core.Model.BIGAREA_SENSOR>();
            CoScheduling.Core.DAL.BIGAREA_SENSOR dal_taskSensor = new CoScheduling.Core.DAL.BIGAREA_SENSOR();
            try
            {
                taskSensorList = dal_taskSensor.GetList("SCHEMEID=" + formCOV.bigAreaSchemeID);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("获取载荷数据出错，请检查数据库连接！");
            }
            CoScheduling.Core.Model.T_PUB_SENSOR sensor = new CoScheduling.Core.Model.T_PUB_SENSOR();
            CoScheduling.Core.DAL.T_PUB_SENSOR dal_Sensor = new CoScheduling.Core.DAL.T_PUB_SENSOR();
            //创建载荷
            foreach (CoScheduling.Core.Model.BIGAREA_SENSOR privateSensor in taskSensorList)
            {
                sensor = dal_Sensor.GetModel(privateSensor.SENSORID);
                //载荷
                string sat_name = sensor.SAT_ID.ToString();
                string sensor_name = sensor.SENSOR_ID.ToString();
                stkcmd = "New / */Satellite/" + sat_name + "/Sensor " + sensor_name;
                try
                {
                    formCOV.stkRoot.ExecuteCommand(stkcmd);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("创建" + privateSensor.SATID + "的载荷" + privateSensor.SENSORID + "失败！");
                    continue;
                }
                //载荷覆盖模型
                int sensorType = Convert.ToInt32(sensor.TYPEID);
                string paraOne = sensor.SENSOR_PARONE.ToString();
                string paraTwo = sensor.SENSOR_PARTWO.ToString();
                string paraThree = sensor.SENSOR_PARTHREE.ToString();
                string paraFour = sensor.SENSOR_PARFOUR.ToString();
                switch (sensorType)
                {
                    case 1:
                        stkcmd = "Define */Satellite/" + sat_name + "/Sensor/" + sensor_name + " SimpleCone " + paraOne;
                        break;
                    case 2:
                        stkcmd = "Define */Satellite/" + sat_name + "/Sensor/" + sensor_name + " Rectangular " + paraOne + " " + paraTwo;
                        break;
                    case 3:
                        stkcmd = "Define */Satellite/" + sat_name + "/Sensor/" + sensor_name + " Conical " + paraOne + " " + paraTwo + " " + paraThree + " " + paraFour;
                        break;
                    default:
                        stkcmd = "Define */Satellite/" + sat_name + "/Sensor/" + sensor_name + " SimpleCone " + paraOne;
                        break;
                }
                try
                {
                    formCOV.stkRoot.ExecuteCommand(stkcmd);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("创建" + sensor.SAT_STKNAME + "的载荷" + sensor.SENSOR_STKNAME + "失败！参数错误！");
                    continue;
                }
                //载荷太阳角限制
                int satType = Convert.ToInt32(sensor.SATTYPE);
                //成像类型为2,测绘1,电子0
                if (satType > 0)
                {
                    stkcmd = "SetConstraint */Satellite/" + sat_name + "/Sensor/" + sensor_name + " SunElevation Min 0 Max 90";
                    try
                    {
                        formCOV.stkRoot.ExecuteCommand(stkcmd);
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show("创建" + sensor.SAT_ID + "的载荷" + sensor.SENSOR_ID + "太阳角失败！");
                        continue;
                    }
                }
            }
            #endregion 4.stk命令创建卫星载荷

            //生成点目标
            stkcmd = "New / */Target target";
            try
            {
                formCOV.stkRoot.ExecuteCommand(stkcmd);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("创建点目标失败！");
            }

            #region 6.保存场景
            filePath += "ScenarioShow.sc";
            stkcmd = "SaveAs / Scenario/* \"" + filePath + "\"";
            try
            {
                formCOV.stkRoot.ExecuteCommand(stkcmd);
                MessageBox.Show("观测任务规划场景创建成功！");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("保存文件失败！");
            }
            #endregion 6.保存场景
            MessageBox.Show("场景创建成功！");
        }

        public static void TargetCon()
        {
            CheckBigAreaSchemeID();
            CoScheduling.Main.Coverage.BigAreaTarget ConfigDialog = new CoScheduling.Main.Coverage.BigAreaTarget(formCOV.bigAreaSchemeID);
            ConfigDialog.ShowDialog();
            string file = "";
            if (ConfigDialog.DialogResult == DialogResult.OK)//确认配置窗口的（按钮2）已点击
            {
                try
                {
                    file = ConfigDialog.TargetFile;
                    List<CoScheduling.Main.Coverage.TargetPoint> points = GetPointList(file);
                    CoScheduling.Core.Model.BIGAREA_TARGET target = new CoScheduling.Core.Model.BIGAREA_TARGET();
                    CoScheduling.Core.DAL.BIGAREA_TARGET dal_target = new CoScheduling.Core.DAL.BIGAREA_TARGET();
                    dal_target.DeleteScheme(formCOV.bigAreaSchemeID);
                    target.SCHEMEID = formCOV.bigAreaSchemeID;
                    foreach (CoScheduling.Main.Coverage.TargetPoint point in points)
                    {
                        target.TARGETNAME = "PointTarget" + point.PointID;
                        target.TARGETLON = point.PointX;
                        target.TARGETLAT = point.PointY;
                        dal_target.Add(target);
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("目标选择失败！");
                    formCOV.setStatus("欢迎使用卫星任务规划系统！");
                }
            }
        }
        #endregion
        #region 卫星任务规划
        internal static Coverage.PlanningResults PlanRes;
        private static int schemeID;
        const double EarthRadio = 6371.004;
        const decimal EARTH_GM_SQRT = 631.34811461000454598031581632439M;
        /// <summary>
        /// 任务方案操作对象
        /// </summary>
        internal static CoScheduling.Core.DAL.TASK_SCHEME_LIST dal_taskScheme;
        internal static CoScheduling.Core.Model.TASK_SCHEME_LIST taskScheme;
        internal static CoScheduling.Core.DAL.SATELLITE_SENSOR_SELECTED dal_satellite_sensor_selected;
            //= new CoScheduling.Core.DAL.TASK_SCHEME_LIST();
        /// <summary>
        /// 任务方案ID
        /// </summary>
        public static int SchemeID
        {
            get { return schemeID; }
            set { schemeID = value; }
        }
        #region 获取最新任务
        /// <summary>
        /// 检查数据新鲜程度
        /// </summary>
        /// <param name="taskDate"></param>
        /// <returns>距离当前任务时间天数</returns>
        public static int checkDate(DateTime taskDate)
        {
            CoScheduling.Core.DAL.SatelliteOrbit dal_satelliteOrbit = new CoScheduling.Core.DAL.SatelliteOrbit();
            DateTime neareastDate = dal_satelliteOrbit.GetNearestDate(taskDate);
            TimeSpan ts = taskDate - neareastDate;
            int days = Convert.ToInt32(ts.Days);
            return days;
        }
        /// <summary>
        /// 清理方案配置资源函数
        /// </summary>
        /// <param name="taskSchemeID"></param>
        public static void ClearTaskSchemeConfigSatellite(int taskSchemeID)
        {
            dal_taskScheme.ClearSatScheme(taskSchemeID);
            dal_taskScheme.ClearSensorScheme(taskSchemeID);
            dal_taskScheme.ClearOrbitScheme(taskSchemeID);
        }
        /// <summary>
        /// 方案资源配置函数
        /// </summary>
        /// <param name="taskSchemeID"></param>
        public static void SetTaskSchemeConfigSatellite(int taskSchemeID)
        {
            dal_taskScheme.AddSatScheme(taskSchemeID);
            dal_taskScheme.AddSensorScheme(taskSchemeID);
            List<int> satid = dal_satellite_sensor_selected.GetCheckedSatID(true);
            foreach (int sateid in satid)
            {
                dal_taskScheme.AddOrbitScheme(taskSchemeID, sateid);
            }
        }
        public static void NewTask()
        {    
            try
            {
                //获取主程序
                formCOV.root = new AGI.STKObjects.AgStkObjectRoot();
                //首先要关闭已经存在的场景
                formCOV.root.CloseScenario();
                //清空结果列表
                PlanRes.dataGridViewTimewindow.DataSource = null;
                PlanRes.dataGridViewResault.DataSource = null;
                //获取最新观测任务ID
                schemeID = dal_taskScheme.GetLatestSchemeid();
                //根据最新任务ID设置最新任务
                taskScheme = dal_taskScheme.GetModel(schemeID);
                formCOV.Text = taskScheme.SCHEMENAME + "规划窗口";
                //检查卫星轨道数据库中的数据是否能够满足任务需求
                //continueProcess判断是否继续执行
                int days = checkDate(taskScheme.SCHEMEBTIME);
                bool continueProcess = true;
                if (days > 2)
                {
                    DialogResult result = MessageBox.Show("卫星轨道数据已过期！忽略请点击确定！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (result == DialogResult.OK)
                    {
                        //确定按钮的方法
                        continueProcess = true;
                    }
                    else
                    {
                        //取消按钮的方法
                        continueProcess = false;
                    }
                }
                if (continueProcess)
                {
                    //对于重复配置的条件下，应该先清除原有的配置方案
                    ClearTaskSchemeConfigSatellite(schemeID);
                    //根据最新任务ID配置卫星及载荷资源
                    SetTaskSchemeConfigSatellite(schemeID);
                    MessageBox.Show(taskScheme.SCHEMENAME + "任务方案及资源配置成功！");
                    //状态提示
                    formCOV.setStatus("当前任务为：" + taskScheme.SCHEMENAME + "。请点击“场景生成”按钮，执行下一步。");
                    //使场景创建和任务规划可用
                    /*
                    this.buttonComputeStep2.Enabled = true;
                    this.buttonComputeStep3.Enabled = false;
                     */
                    formCOV.buttonPosition.Enabled = false; ;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("方案配置失败！");
                formCOV.setStatus("欢迎使用卫星任务规划系统！");
            }

        }
        #endregion
        #region  卫星任务场景生成
        /// <summary>
        /// 创建任务场景公共函数
        /// </summary>
        /// <param name="maxSchemeID"></param>
        public static void CreateTaskSchemeLayoutScenario(int maxSchemeID)
        {
            #region 1.设置文件保存目录
            //1.设置文件保存目录
            //设置文件夹路径
            string filePath = CoScheduling.Core.DBUtility.PubConstant.GetFilePath("Scenario") + maxSchemeID + "\\";
            //创建文件夹
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            #endregion 1.设置文件保存目录

            #region 2.stk命令创建场景环境
            //2.stk命令创建场景环境
            //执行stk命令的时候，需要配置线程环境为英语环境
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-GB", true);
            System.Threading.Thread.CurrentThread.CurrentCulture = culture;
            //创建场景

            string stkcmd = "New / Scenario See_DC";
            try
            {
                formCOV.root.ExecuteCommand(stkcmd);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("创建场景出错！");
                return;
            }
            //配置场景环境
            //开始时间、结束时间
            taskScheme = dal_taskScheme.GetModel(maxSchemeID);
            //因为stk程序默认使用是UTC时间，与中国所用东八区时间相比晚8小时
            DateTime startTime = taskScheme.SCHEMEBTIME.AddHours(-8);
            DateTime endTime = taskScheme.SCHEMEETIME.AddHours(-8);
            stkcmd = "SetTimePeriod * \"" + startTime.ToString("dd MMM yyyy HH:mm:ss") + "\" \"" + endTime.ToString("dd MMM yyyy HH:mm:ss") + "\"";
            try
            {
                formCOV.root.ExecuteCommand(stkcmd);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("设置场景时间出错！");
                return;
            }
            //Epoch时间
            stkcmd = "SetEpoch * \"" + startTime.ToString("dd MMM yyyy HH:mm:ss") + "\"";
            try
            {
                formCOV.root.ExecuteCommand(stkcmd);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("设置场景Epoch出错！");
                return;
            }
            //步长
            stkcmd = "Animate * SetValues \"" + startTime.ToString("dd MMM yyyy HH:mm:ss") + "\" 60 0.5";
            try
            {
                formCOV.root.ExecuteCommand(stkcmd);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("设置场景步长出错！");
                return;
            }
            //工具栏时间
            //在工具栏中加入时间
            addDateTimePicker(startTime.AddHours(8), endTime.AddHours(8));
            #endregion 2.stk命令创建场景环境

            #region 3.stk命令创建卫星资源
            //3.stk命令创建卫星资源
            //获取任务专属卫星资源
            List<CoScheduling.Core.Model.TASKSCHEME_PRIVATE_SATELLITE> taskSatelliteList = new List<CoScheduling.Core.Model.TASKSCHEME_PRIVATE_SATELLITE>();
            CoScheduling.Core.DAL.TASKSCHEME_PRIVATE_SATELLITE dal_taskSatellite = new CoScheduling.Core.DAL.TASKSCHEME_PRIVATE_SATELLITE();
            try
            {
                taskSatelliteList = dal_taskSatellite.GetList(maxSchemeID);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("获取卫星数据出错，请检查数据库连接！");
                return;
            }
            //视角列表清空
            formCOV.viewFromButton.DropDownItems.Clear();
            //创建卫星
            foreach (CoScheduling.Core.Model.TASKSCHEME_PRIVATE_SATELLITE privateSatellite in taskSatelliteList)
            {
                //卫星
                stkcmd = "New / */Satellite " + privateSatellite.SAT_STKNAME;
                try
                {
                    formCOV.root.ExecuteCommand(stkcmd);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("创建" + privateSatellite.SAT_STKNAME + "失败！");
                }
                //卫星轨道参数模型
                stkcmd = "SetState */Satellite/" + privateSatellite.SAT_STKNAME;
                stkcmd += " " + privateSatellite.SAT_ROPAGATOR;
                stkcmd += " \"" + startTime.ToString("dd MMM yyyy HH:mm:ss") + "\" \"" + endTime.ToString("dd MMM yyyy HH:mm:ss") + "\"";
                stkcmd += " " + privateSatellite.SAT_STEP + " ";
                string satelliteTLEPara = getSatelliteTleDate(privateSatellite.SAT_ID);
                stkcmd += satelliteTLEPara;
                try
                {
                    formCOV.root.ExecuteCommand(stkcmd);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("创建" + privateSatellite.SAT_STKNAME + "轨道模型失败！");
                    continue;
                }
                formCOV.viewFromButton.DropDownItems.Add("Satellite/" + privateSatellite.SAT_STKNAME);
            }
            #endregion 3.stk命令创建卫星资源

            #region 4.stk命令创建卫星载荷
            //4.stk命令创建卫星载荷
            //获取任务专属载荷资源
            List<CoScheduling.Core.Model.TASKSCHEME_PRIVATE_SENSOR> taskSensorList = new List<CoScheduling.Core.Model.TASKSCHEME_PRIVATE_SENSOR>();
            CoScheduling.Core.DAL.TASKSCHEME_PRIVATE_SENSOR dal_taskSensor = new CoScheduling.Core.DAL.TASKSCHEME_PRIVATE_SENSOR();
            try
            {
                taskSensorList = dal_taskSensor.GetList(maxSchemeID);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("获取载荷数据出错，请检查数据库连接！");
            }
            //创建载荷
            foreach (CoScheduling.Core.Model.TASKSCHEME_PRIVATE_SENSOR privateSensor in taskSensorList)
            {
                //载荷
                string sat_name = privateSensor.SAT_STKNAME;
                string sensor_name = privateSensor.SENSOR_STKNAME;
                stkcmd = "New / */Satellite/" + sat_name + "/Sensor " + sensor_name;
                try
                {
                    formCOV.root.ExecuteCommand(stkcmd);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("创建" + privateSensor.SAT_STKNAME + "的载荷" + privateSensor.SENSOR_STKNAME + "失败！");
                    continue;
                }
                //载荷覆盖模型
                int sensorType = Convert.ToInt32(privateSensor.TYPEID);
                string paraOne = privateSensor.SENSOR_PARONE.ToString();
                string paraTwo = privateSensor.SENSOR_PARTWO.ToString();
                string paraThree = privateSensor.SENSOR_PARTHREE.ToString();
                string paraFour = privateSensor.SENSOR_PARFOUR.ToString();
                switch (sensorType)
                {
                    case 1:
                        stkcmd = "Define */Satellite/" + sat_name + "/Sensor/" + sensor_name + " SimpleCone " + paraOne;
                        break;
                    case 2:
                        stkcmd = "Define */Satellite/" + sat_name + "/Sensor/" + sensor_name + " Rectangular " + paraOne + " " + paraTwo;
                        break;
                    case 3:
                        stkcmd = "Define */Satellite/" + sat_name + "/Sensor/" + sensor_name + " Conical " + paraOne + " " + paraTwo + " " + paraThree + " " + paraFour;
                        break;
                    default:
                        stkcmd = "Define */Satellite/" + sat_name + "/Sensor/" + sensor_name + " SimpleCone " + paraOne;
                        break;
                }
                try
                {
                    formCOV.root.ExecuteCommand(stkcmd);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("创建" + privateSensor.SAT_STKNAME + "的载荷" + privateSensor.SENSOR_STKNAME + "失败！参数错误！");
                    continue;
                }
                //载荷太阳角限制
                int satType = Convert.ToInt32(privateSensor.SATTYPE);
                //成像类型为2,测绘1,电子0
                if (satType > 0)
                {
                    stkcmd = "SetConstraint */Satellite/" + sat_name + "/Sensor/" + sensor_name + " SunElevation Min 0 Max 90";
                    try
                    {
                        formCOV.root.ExecuteCommand(stkcmd);
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show("创建" + privateSensor.SAT_STKNAME + "的载荷" + privateSensor.SENSOR_STKNAME + "太阳角失败！");
                        continue;
                    }
                }
            }
            #endregion 4.stk命令创建卫星载荷

            #region 5.stk命令创建目标
            List<CoScheduling.Core.Model.TASK_LAYOUT_LIST> taskLayoutList = new List<CoScheduling.Core.Model.TASK_LAYOUT_LIST>();
            CoScheduling.Core.DAL.TASK_LAYOUT_LIST dal_taskLayout = new CoScheduling.Core.DAL.TASK_LAYOUT_LIST();
            taskLayoutList = dal_taskLayout.GetList(maxSchemeID);
            foreach (CoScheduling.Core.Model.TASK_LAYOUT_LIST taskLayout in taskLayoutList)
            {
                //TASKTYPE,0是点目标，1是面目标
                if (taskLayout.TASKTYPE == 0)
                {
                    //获取点目标信息
                    string targetName = "PointTarget" + taskLayout.TASKID.ToString();
                    string targetLongitude = taskLayout.LON.ToString();
                    string targetLatitude = taskLayout.LAT.ToString();
                    //生成点目标
                    stkcmd = "New / */Target " + targetName;
                    try
                    {
                        formCOV.root.ExecuteCommand(stkcmd);
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show("创建点目标" + targetName + "失败！");
                        continue;
                    }
                    //生成点坐标
                    stkcmd = "SetPosition */Target/" + targetName + " Geodetic " + targetLatitude + " " + targetLongitude + " 0";
                    try
                    {
                        formCOV.root.ExecuteCommand(stkcmd);
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show("创建点目标" + targetName + "坐标失败！");
                        continue;
                    }
                    formCOV.viewFromButton.DropDownItems.Add("Target/" + targetName);
                }
                else
                {
                    //获取区域目标信息
                    string targetName = "AreaTarget" + taskLayout.TASKID.ToString();
                    string targetPointNum = taskLayout.TARGET_ID.ToString();
                    string targetAreaString = taskLayout.AREASTRING;

                    //生成区域目标
                    stkcmd = "New / */AreaTarget " + targetName;
                    try
                    {
                        formCOV.root.ExecuteCommand(stkcmd);
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show("创建区域目标" + targetName + "失败！");
                        continue;
                    }
                    //生成区域目标坐标
                    //stkcmd = "SetBoundary */AreaTarget/" + targetName + " Pattern 4 " + targetLatitude2 + " " + targetLongitude1 + " " + targetLatitude2 + " " + targetLongitude2 + " " + targetLatitude1 + " " + targetLongitude2 + " " + targetLatitude1 + " " + targetLongitude1 + " ";
                    stkcmd = "SetBoundary */AreaTarget/" + targetName + " Pattern LatLon " + targetPointNum + " " + targetAreaString;
                    try
                    {
                        formCOV.root.ExecuteCommand(stkcmd);
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show("创建区域目标" + targetName + "坐标失败！");
                        continue;
                    }
                    formCOV.viewFromButton.DropDownItems.Add("AreaTarget/" + targetName);
                }
                stkcmd = "VO * View FromTo ToRegName \"Latitude, Longitude, Altitude\" ToName \"Latitude, Longitude, Altitude\" ToCallData \"Lat " + taskLayout.LAT.ToString() + " Lon " + taskLayout.LON.ToString() + " Alt 0\"";
                formCOV.root.ExecuteCommand(stkcmd);
            }

            #endregion 5.stk命令创建目标

            #region 6.保存场景
            filePath += "ScenarioShow.sc";
            stkcmd = "SaveAs / Scenario/* \"" + filePath + "\"";
            try
            {
                formCOV.root.ExecuteCommand(stkcmd);
                MessageBox.Show("观测任务规划场景创建成功！");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("保存文件失败！");
            }
            #endregion 6.保存场景
        }
        /// <summary>
        /// 获取卫星星历数据
        /// </summary>
        /// <param name="satid"></param>
        /// <returns></returns>
        public static  string getSatelliteTleDate(decimal satid)
        {
            CoScheduling.Core.Model.TASKSCHEME_PRIVATE_ORBIT satelliteOrbit = new CoScheduling.Core.Model.TASKSCHEME_PRIVATE_ORBIT();
            CoScheduling.Core.DAL.TASKSCHEME_PRIVATE_ORBIT dal_satelliteOrbit = new CoScheduling.Core.DAL.TASKSCHEME_PRIVATE_ORBIT();
            try
            {
                satelliteOrbit = dal_satelliteOrbit.GetModel(satid);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("获取卫星数据出错，请检查数据库连接！");
            }
            string satelliteTLEString = "";
            try
            {
                satelliteTLEString = satelliteOrbit.SAT_ID.ToString() + " ";
                satelliteTLEString += satelliteOrbit.SAT_ORBITEPOCH + " ";
                satelliteTLEString += satelliteOrbit.SAT_MEANMOTION + " ";
                satelliteTLEString += satelliteOrbit.SAT_ECCENTRICITY + " ";
                satelliteTLEString += satelliteOrbit.SAT_INCLINATION + " ";
                satelliteTLEString += satelliteOrbit.SAT_ARGOFPERIGEE + " ";
                satelliteTLEString += satelliteOrbit.SAT_RAAN + " ";
                satelliteTLEString += satelliteOrbit.SAT_MEANANOMALY + " ";
                satelliteTLEString += satelliteOrbit.SAT_MEANMOTIONDOT + " ";
                satelliteTLEString += satelliteOrbit.SAT_MEANMOTIONDOTDOT + " ";
                satelliteTLEString += satelliteOrbit.SAT_BSTAR;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("卫星轨道数据问题，请重新配置卫星轨道数据！");
            }
            return satelliteTLEString;
        }
        public static void ScenEstablish()
        {
            try
            {
                formCOV.setStatus("正在创建任务场景，请稍后...");
                //获取主程序
                formCOV.root = new AGI.STKObjects.AgStkObjectRoot();
                //首先要关闭已经存在的场景
                formCOV.root.CloseScenario();
                //创建任务场景
                CreateTaskSchemeLayoutScenario(schemeID);
                /*this.buttonComputeStep3.Enabled = true;*/
                formCOV.setStatus("任务场景创建完成。请点击“任务规划”按钮，执行下一步。");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                formCOV.setStatus("欢迎使用卫星任务规划系统！");
            }
        }

        #endregion
        #region 任务规划
        /// <summary>
        /// 清理已存在的规划结果
        /// </summary>
        /// <param name="taskSchemeID"></param>
        public static void clearTaskSchemeLayoutTimeWindow(int taskSchemeID)
        {
            CoScheduling.Core.DAL.ImgLayoutTempTimewindow dal_imgLayoutTempTimewindow = new CoScheduling.Core.DAL.ImgLayoutTempTimewindow();
            //CoScheduling.Core.DAL.LAYOUT_SATELLITE_TIMEWINDOW dal_layoutSatelliteTimewindow = new CoScheduling.Core.DAL.LAYOUT_SATELLITE_TIMEWINDOW();
            //CoScheduling.Core.DAL.IMG_LAYOUT_RESULT dal_imgLayoutResault = new CoScheduling.Core.DAL.IMG_LAYOUT_RESULT();
            dal_imgLayoutTempTimewindow.DeleteFour(schemeID.ToString());
        }
        /// <summary>
        /// 获取场景内的目标
        /// </summary>
        /// <returns></returns>
        public static List<CoScheduling.Core.Model.STKTarget> GetSTKTarget()
        {
            List<CoScheduling.Core.Model.STKTarget> stkTargets = new List<CoScheduling.Core.Model.STKTarget>();
            //获取场景内的所有对象
            AgExecCmdResult results = (AgExecCmdResult)formCOV.stkRoot.ExecuteCommand("AllInstanceNames /");
            //取出结果字符串
            string rs = results[0].Substring(1, results[0].Length - 2);
            string[] result = rs.Split(' ');
            for (int num = 0; num < result.Length; num++)
            {
                if (result[num].Contains("AreaTarget"))
                {
                    int targetBSign = result[num].LastIndexOf('/') + 1;
                    CoScheduling.Core.Model.STKTarget stkTarget = new CoScheduling.Core.Model.STKTarget();
                    stkTarget.TARGET_TYPE = "AreaTarget";
                    stkTarget.TARGET_NAME = result[num].Substring(targetBSign);
                    stkTarget.TARGET_ID = Convert.ToInt32(stkTarget.TARGET_NAME.Substring(10));
                    stkTargets.Add(stkTarget);
                }
                else if (result[num].Contains("Target"))
                {
                    int targetBSign = result[num].LastIndexOf('/') + 1;
                    CoScheduling.Core.Model.STKTarget stkTarget = new CoScheduling.Core.Model.STKTarget();
                    stkTarget.TARGET_TYPE = "Target";
                    stkTarget.TARGET_NAME = result[num].Substring(targetBSign);
                    stkTarget.TARGET_ID = Convert.ToInt32(stkTarget.TARGET_NAME.Substring(11));
                    stkTargets.Add(stkTarget);
                }
            }
            return stkTargets;
        }
        /// <summary>
        /// 计算场景内的所有资源对所有目标的时间窗口
        /// </summary>
        /// <param name="taskSchemeID"></param>
        public static void ComputerLayoutTaskSchemeTimeWindow(int taskSchemeID)
        {
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

            #region 2.获取场景内的目标
            //2.获取场景内的目标
            List<CoScheduling.Core.Model.STKTarget> stkTargets = new List<CoScheduling.Core.Model.STKTarget>();
            try
            {
                stkTargets = GetSTKTarget();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("获取地面目标错误！计算终止！");
                return;
            }
            #endregion 2.获取场景内的目标

            #region 3.计算每个资源对目标的时间窗口

            //3.计算每个资源对目标的时间窗口
            //原算法中有判断场景内卫星载荷资源与数据库中任务私有资源匹配的过程，这里就省略了；
            //场景是根据数据库建立的，只可能由于轨道或其他数据问题导致场景内资源比数据库中的少，反之不成立；
            //CoScheduling.Core.DAL.TASKSCHEME_PRIVATE_SENSOR taskSensor=new CoScheduling.Core.DAL.TASKSCHEME_PRIVATE_SENSOR();

            string strStkcmd = "";  //stk命令字符串
            //双重循环计算每个传感器对每个目标的时间窗口，外层循环传感器，内层循环目标
            foreach (CoScheduling.Core.Model.STKObject stkObject in stkObjects)
            {
                foreach (CoScheduling.Core.Model.STKTarget stkTarget in stkTargets)
                {
                    #region 处理点目标过程
                    //目标有两种，点目标处理
                    if (stkTarget.TARGET_TYPE == "Target")
                    {
                        //（1）通过Access命令获取时间窗口
                        strStkcmd = "Access */Satellite/" + stkObject.SAT_STKNAME + "/Sensor/" + stkObject.SENSOR_STKNAME + " */Target/" + stkTarget.TARGET_NAME + " TimePeriod Scenario";
                        IAgExecCmdResult resultOne = formCOV.root.ExecuteCommand(strStkcmd);
                        //报告中时间窗口开始位置
                        int rsBIndexofT = resultOne[0].IndexOf("/" + stkTarget.TARGET_NAME) + stkTarget.TARGET_NAME.Length + 1;
                        //时间窗口长度
                        int rsLengthofT = resultOne[0].Length - rsBIndexofT;
                        //时间窗口
                        string rsTimewindow = resultOne[0];
                        rsTimewindow = rsTimewindow.Substring(rsBIndexofT, rsLengthofT).Trim();

                        //（2）根据目标的STK名称取得任务信息（位置信息）
                        CoScheduling.Core.Model.TASK_LAYOUT_LIST taskLayout = new CoScheduling.Core.Model.TASK_LAYOUT_LIST();
                        CoScheduling.Core.DAL.TASK_LAYOUT_LIST dal_taskLayout = new CoScheduling.Core.DAL.TASK_LAYOUT_LIST();
                        int taskLayoutId = stkTarget.TARGET_ID;
                        taskLayout = dal_taskLayout.GetModel(taskLayoutId);
                        decimal targetPointLat = taskLayout.LAT;
                        decimal targetPointLon = taskLayout.LON;

                        //（3）处理时间窗口
                        //无时间窗口的情况：NoAccesses
                        //有时间窗口的情况：2  31 May 2014 02:58:17.071 31 May 2014 02:58:21.705  1 Jun 2014 03:19:45.069  1 Jun 2014 03:19:49.759
                        //2表示次数，后边是每次的开始时间和结束时间
                        //开始解析
                        if (rsTimewindow != "NoAccesses") //首先判断是否有时间窗口
                        {
                            //首先取出次数，用作控制
                            int windowTimeSign = rsTimewindow.IndexOf(" ");
                            int windowTime = Convert.ToInt32(rsTimewindow.Substring(0, windowTimeSign));
                            //预处理字符串，去除次数和多余空格
                            rsTimewindow = rsTimewindow.Substring(windowTimeSign + 1);
                            for (int windowNum = 0; windowNum < windowTime; windowNum++)
                            {
                                //一个时间记录长度为23或者24，当23时前后会有多余空格，所以所占位置是固定的
                                string timeStartStr = rsTimewindow.Substring(0, 25).Trim();
                                //将处理完的截去
                                rsTimewindow = rsTimewindow.Substring(25);
                                //处理结束时间
                                string timeEndStr = rsTimewindow.Substring(0, 25).Trim();
                                rsTimewindow = rsTimewindow.Substring(25);
                                DateTime timeWindowStart = Convert.ToDateTime(timeStartStr);
                                DateTime timeWindowEnd = Convert.ToDateTime(timeEndStr);

                                //（4）通过AER命令获取角度信息
                                strStkcmd = "AER */Satellite/" + stkObject.SAT_STKNAME + "/Sensor/" + stkObject.SENSOR_STKNAME + " */Target/" + stkTarget.TARGET_NAME + " TimePeriod \"" + timeStartStr + "\" \"" + timeEndStr + "\"";
                                IAgExecCmdResult resultTwo = formCOV.root.ExecuteCommand(strStkcmd);
                                //报告中有用数据开始的位置
                                int rsBIndexofA = resultTwo[0].IndexOf("/" + stkTarget.TARGET_NAME) + stkTarget.TARGET_NAME.Length + 2;
                                //报告长度
                                int rsLengthofA = resultTwo[0].Length - rsBIndexofA - 1;
                                //AER报告结果
                                string temprsAER = resultTwo[0];
                                temprsAER = temprsAER.Substring(rsBIndexofA, rsLengthofA);
                                string[] temprsAERs = temprsAER.Split('\n');
                                string rsAERstr = temprsAERs[0].Substring(timeStartStr.Length + 1).Trim();
                                string[] rsAER = rsAERstr.Split(' ');
                                string AZIMUTH = rsAER[0];
                                string ELEVATION = rsAER[1];
                                string RANGE = rsAER[2];

                                //（5）获取时间窗口内的三个时间（开始，中间，结束）的卫星位置
                                //the first six numbers represent position/velocity as latitude, longitude, altitude, rate of latitude change, rate of longitude change and rate of altitude change. 
                                //The next six numbers are ECF position/velocity vectors (Cartesian x, y, z). 
                                //The last six are position and velocity vectors returned in the default inertial frame for the central body (ICRF for Earth). 
                                //41.399640 -133.084782 794311.942615 -0.058698 -0.019789 -0.009113 -3679875.201967 -3934494.574169 4721101.964499 -4651.634203 -2249.571811 -5500.487308 209647.157899 5382855.310768 4721382.169232 1656.434698 4759.542793 -5499.914240
                                //开始时刻位置
                                strStkcmd = "Position */Satellite/" + stkObject.SAT_STKNAME + " \"" + timeStartStr + "\"";
                                IAgExecCmdResult resultThreeOne = formCOV.root.ExecuteCommand(strStkcmd);
                                string orbhStartPosition = resultThreeOne[0];
                                string[] positionStart = orbhStartPosition.Split(' ');
                                string sateBeginLat = positionStart[0];
                                string sateBeginLon = positionStart[1];
                                string sateBeginH = positionStart[2];
                                //结束时刻位置
                                strStkcmd = "Position */Satellite/" + stkObject.SAT_STKNAME + " \"" + timeEndStr + "\"";
                                IAgExecCmdResult resultThreeTwo = formCOV.root.ExecuteCommand(strStkcmd);
                                string orbhEndPosition = resultThreeTwo[0];
                                string[] positionEnd = orbhEndPosition.Split(' ');
                                string sateEndLat = positionEnd[0];
                                string sateEndLon = positionEnd[1];
                                string sateEndH = positionEnd[2];
                                //中间时刻位置
                                TimeSpan ts = timeWindowEnd - timeWindowStart;
                                double tsSecond = ts.TotalSeconds;
                                DateTime timeWindowMid = timeWindowStart.AddSeconds(tsSecond / 2);
                                string timeMidStr = timeWindowMid.ToString("dd MMM yyyy HH:mm:ss");
                                strStkcmd = "Position */Satellite/" + stkObject.SAT_STKNAME + " \"" + timeMidStr + "\"";
                                IAgExecCmdResult resultThreeThree = formCOV.root.ExecuteCommand(strStkcmd);
                                string orbhMidPosition = resultThreeThree[0];
                                string[] positionMid = orbhMidPosition.Split(' ');
                                string sateMidLat = positionMid[0];
                                string sateMidLon = positionMid[1];
                                string sateMidH = positionMid[2];
                                //（6）存储一次时间窗口
                                saveTaskSchemeSatelliteTimeWindow(schemeID, taskLayoutId, stkObject.SAT_STKNAME, stkObject.SENSOR_STKNAME, stkTarget.TARGET_NAME, timeWindowStart, timeWindowEnd, AZIMUTH, ELEVATION, RANGE, sateBeginLat, sateBeginLon, sateBeginH, sateMidLat, sateMidLon, sateMidH, sateEndLat, sateEndLon, sateEndH, targetPointLat, targetPointLon);
                            }
                        }
                    }
                    #endregion 处理点目标过程

                    #region 处理区域目标过程
                    //区域目标处理
                    else
                    {
                        //（1）通过Access命令获取时间窗口
                        strStkcmd = "Access */Satellite/" + stkObject.SAT_STKNAME + "/Sensor/" + stkObject.SENSOR_STKNAME + " */AreaTarget/" + stkTarget.TARGET_NAME + " TimePeriod Scenario";
                        IAgExecCmdResult resultOne = formCOV.root.ExecuteCommand(strStkcmd);
                        //报告中时间窗口开始位置
                        int rsBIndexofT = resultOne[0].IndexOf("/" + stkTarget.TARGET_NAME) + stkTarget.TARGET_NAME.Length + 1;
                        //时间窗口长度
                        int rsLengthofT = resultOne[0].Length - rsBIndexofT;
                        //时间窗口
                        string rsTimewindow = resultOne[0];
                        rsTimewindow = rsTimewindow.Substring(rsBIndexofT, rsLengthofT).Trim();

                        //（2）根据目标的STK名称取得任务信息（位置信息）
                        CoScheduling.Core.Model.TASK_LAYOUT_LIST taskLayout = new CoScheduling.Core.Model.TASK_LAYOUT_LIST();
                        CoScheduling.Core.DAL.TASK_LAYOUT_LIST dal_taskLayout = new CoScheduling.Core.DAL.TASK_LAYOUT_LIST();
                        int taskLayoutId = stkTarget.TARGET_ID;
                        taskLayout = dal_taskLayout.GetModel(taskLayoutId);
                        strStkcmd = "Position */AreaTarget/" + stkTarget.TARGET_NAME;
                        IAgExecCmdResult resultAreaPosition = formCOV.root.ExecuteCommand(strStkcmd);
                        string areaPositionStr = resultAreaPosition[0];
                        string[] areaPosition = areaPositionStr.Split(' ');
                        string targetSiteLat = areaPosition[0];
                        string targetSiteLon = areaPosition[1];

                        //（3）处理时间窗口
                        //无时间窗口的情况：NoAccesses
                        //有时间窗口的情况：2  31 May 2014 02:58:17.071 31 May 2014 02:58:21.705  1 Jun 2014 03:19:45.069  1 Jun 2014 03:19:49.759
                        //2表示次数，后边是每次的开始时间和结束时间
                        //开始解析
                        if (rsTimewindow != "NoAccesses") //首先判断是否有时间窗口
                        {
                            //首先取出次数，用作控制
                            int windowTimeSign = rsTimewindow.IndexOf(" ");
                            int windowTime = Convert.ToInt32(rsTimewindow.Substring(0, windowTimeSign));
                            //预处理字符串，去除次数和多余空格
                            rsTimewindow = rsTimewindow.Substring(windowTimeSign + 1);
                            for (int windowNum = 0; windowNum < windowTime; windowNum++)
                            {
                                #region stk命令解析字符串
                                //一个时间记录长度为23或者24，当23时前后会有多余空格，所以所占位置是固定的
                                string timeStartStr = rsTimewindow.Substring(0, 25).Trim();
                                //将处理完的截去
                                rsTimewindow = rsTimewindow.Substring(25);
                                //处理结束时间
                                string timeEndStr = rsTimewindow.Substring(0, 25).Trim();
                                rsTimewindow = rsTimewindow.Substring(25);
                                //开始时间
                                DateTime timeWindowStart = Convert.ToDateTime(timeStartStr);
                                //结束时间
                                DateTime timeWindowEnd = Convert.ToDateTime(timeEndStr);
                                TimeSpan windowSpan = timeWindowEnd - timeWindowStart;
                                //持续时间，单位s
                                double tsSecond = windowSpan.TotalSeconds;
                                int timeAreaSpyLastLen = (int)tsSecond;
                                //中间时刻                                
                                DateTime timeWindowMid = timeWindowStart.AddSeconds(tsSecond / 2);

                                //（4）通过AER命令获取角度信息
                                strStkcmd = "AER */Satellite/" + stkObject.SAT_STKNAME + "/Sensor/" + stkObject.SENSOR_STKNAME + " */AreaTarget/" + stkTarget.TARGET_NAME + " TimePeriod \"" + timeStartStr + "\" \"" + timeEndStr + "\"";
                                IAgExecCmdResult resultTwo = formCOV.root.ExecuteCommand(strStkcmd);
                                //报告中有用数据开始的位置
                                int rsBIndexofA = resultTwo[0].IndexOf("/" + stkTarget.TARGET_NAME) + stkTarget.TARGET_NAME.Length + 2;
                                //报告长度
                                int rsLengthofA = resultTwo[0].Length - rsBIndexofA - 1;
                                //AER报告结果
                                string temprsAER = resultTwo[0];
                                temprsAER = temprsAER.Substring(rsBIndexofA, rsLengthofA);
                                string[] temprsAERs = temprsAER.Split('\n');
                                string rsAERstr = temprsAERs[0].Substring(timeStartStr.Length + 1).Trim();
                                string[] rsAER = rsAERstr.Split(' ');
                                string AZIMUTH = rsAER[0];
                                string ELEVATION = rsAER[1];
                                string RANGE = rsAER[2];

                                //计算区域的具体内容，因为需要的参数较多，不另写函数
                                //（5）获取卫星及载荷参数
                                //获取载荷对象
                                CoScheduling.Core.Model.TASKSCHEME_PRIVATE_SENSOR taskSensor = new CoScheduling.Core.Model.TASKSCHEME_PRIVATE_SENSOR();
                                CoScheduling.Core.DAL.TASKSCHEME_PRIVATE_SENSOR dal_taskSensor = new CoScheduling.Core.DAL.TASKSCHEME_PRIVATE_SENSOR();
                                taskSensor = dal_taskSensor.GetModel(stkObject.SAT_STKNAME, stkObject.SENSOR_STKNAME, schemeID);
                                CoScheduling.Core.Model.T_PUB_SATELLITEPARA sensorPara = new CoScheduling.Core.Model.T_PUB_SATELLITEPARA();
                                CoScheduling.Core.DAL.T_PUB_SATELLITEPARA dal_sensorPara = new CoScheduling.Core.DAL.T_PUB_SATELLITEPARA();
                                sensorPara = dal_sensorPara.GetModel(taskSensor.SENSOR_ID);
                                //获取载荷参数
                                double sateAngleD = (double)taskSensor.SENSORANGLE;
                                double sateMaxAngleD = (double)taskSensor.SENSOR_PARONE;
                                double sateAngleHD = (double)taskSensor.SENSORANGLEH;
                                double sensorGSD = (double)sensorPara.MAXGSD;

                                //（6）计算成像情况
                                //获取中间时刻卫星位置信息
                                string timeMidStr = timeWindowMid.ToString("dd MMM yyyy HH:mm:ss");
                                strStkcmd = "Position */Satellite/" + stkObject.SAT_STKNAME + " \"" + timeMidStr + "\"";
                                IAgExecCmdResult resultThree = formCOV.root.ExecuteCommand(strStkcmd);
                                string orbhMidPosition = resultThree[0];
                                string[] positionMid = orbhMidPosition.Split(' ');
                                string sateMidLat = positionMid[0];
                                string sateMidLon = positionMid[1];
                                string sateMidH = positionMid[2];
                                #endregion stk命令解析字符串

                                #region 弧度化
                                //double sateMidLatD, sateMidLonD, sateMidHD, targetSiteLatD, targetSiteLonD;
                                //sateMidLatD = Convert.ToDouble(sateMidLat) * Math.PI / 180.0;
                                //sateMidLonD = Convert.ToDouble(sateMidLon) * Math.PI / 180.0;
                                //sateMidHD = Convert.ToDouble(sateMidH) / 1000;
                                //targetSiteLatD = Convert.ToDouble(targetSiteLat) * Math.PI / 180.0;
                                //targetSiteLonD = Convert.ToDouble(targetSiteLon) * Math.PI / 180.0;
                                //#endregion 弧度化

                                //#region 计算侧摆角度
                                ////卫星与目标间的夹角
                                //double newtgsangle = getSatelliteTargetAngle(sateMidLatD, sateMidLonD, targetSiteLatD, targetSiteLonD, sateMidHD);
                                ////弧度化
                                //double sangle = Math.Atan(newtgsangle) * 180 / Math.PI;
                                ////根据AER报告得到的夹角
                                //double a, b, rangeD;
                                //a = Convert.ToDouble(AZIMUTH);
                                //b = Convert.ToDouble(ELEVATION);
                                //rangeD = Convert.ToDouble(RANGE);
                                //double slewangle = GetYu(b, a);
                                //if (slewangle < 0)
                                //{
                                //    slewangle = -1.0 * sangle;
                                //}
                                //else
                                //{
                                //    slewangle = sangle;
                                //}

                                //if (sangle < sateAngleD)
                                //{
                                //    sangle = 0;
                                //}
                                //else if (sangle == sateAngleD)
                                //{
                                //    sangle = 0;
                                //}
                                //else
                                //{
                                //    if (!((sangle + sateAngleD) < sateMaxAngleD))
                                //    {
                                //        sangle = sateMaxAngleD - sateAngleD;
                                //    }
                                //}
                                //#endregion 计算侧摆角度

                                //#region 计算分辨率
                                //double currentGSD = GetBestGsd(sensorGSD, rangeD, sateMidHD, sangle);
                                //#endregion 计算分辨率

                                //#region 计算圈数
                                //int CircleNumber = ComputerSatelliteCircle(sensorPara.SATANGLEH, taskLayoutId, timeWindowStart.AddHours(8));
                                #endregion 计算圈数

                                #region 计算成像区域

                                #region 原始方法
                                strStkcmd = "Position */Satellite/" + stkObject.SAT_STKNAME + " \"" + timeStartStr + "\"";
                                IAgExecCmdResult resultThreeOne = formCOV.root.ExecuteCommand(strStkcmd);
                                string orbhStartPosition = resultThreeOne[0];
                                string[] positionStart = orbhStartPosition.Split(' ');
                                string sateBeginLat = positionStart[0];
                                string sateBeginLon = positionStart[1];
                                string sateBeginH = positionStart[2];
                                //结束时刻位置
                                strStkcmd = "Position */Satellite/" + stkObject.SAT_STKNAME + " \"" + timeEndStr + "\"";
                                IAgExecCmdResult resultThreeTwo = formCOV.root.ExecuteCommand(strStkcmd);
                                string orbhEndPosition = resultThreeTwo[0];
                                string[] positionEnd = orbhEndPosition.Split(' ');
                                string sateEndLat = positionEnd[0];
                                string sateEndLon = positionEnd[1];
                                string sateEndH = positionEnd[2];
                                //（6）存储一次时间窗口
                                saveTaskSchemeSatelliteTimeWindow(schemeID, taskLayoutId, stkObject.SAT_STKNAME, stkObject.SENSOR_STKNAME, stkTarget.TARGET_NAME, timeWindowStart, timeWindowEnd, AZIMUTH, ELEVATION, RANGE, sateBeginLat, sateBeginLon, sateBeginH, sateMidLat, sateMidLon, sateMidH, sateEndLat, sateEndLon, sateEndH, Convert.ToDecimal(targetSiteLat), Convert.ToDecimal(targetSiteLon));
                                #endregion 原始方法

                                #region 改进的每分钟一个步长的计算方法
                                ////区域字符串
                                //string imageSpyRegion, tempimageSpyRegion;
                                //string imageSpyRegionOne = "";
                                //string imageSpyRegionTwo = "";

                                ////时间间隔
                                //int timeAreaSpanSecond = 60;
                                //int miAreaTimeSpan = 1;
                                //int timeAreaSpan = 60;
                                ////时间控制变量
                                //DateTime spyxBtime, spyxEtime;
                                //DateTime spyMinBtime, sypMinEtime;
                                //for (int r = 0; r < timeAreaSpyLastLen; r = r + timeAreaSpanSecond)
                                //{
                                //    int z = r + timeAreaSpanSecond;
                                //    if (timeAreaSpyLastLen < z)
                                //    {
                                //        int timeAreaSpanBegin = r;

                                //        spyxBtime = timeWindowStart.AddSeconds(timeAreaSpanBegin);

                                //        strStkcmd = "Position */Satellite/" + stkObject.SAT_STKNAME + " \"" + spyxBtime.ToString("dd MMM yyyy HH:mm:ss") + "\"";
                                //        IAgExecCmdResult resultThreeOne = root.ExecuteCommand(strStkcmd);
                                //        string orbhPositionStr = resultThreeOne[0];
                                //        string[] orbhPosition = orbhPositionStr.Split(' ');
                                //        string sateBeginLat = orbhPosition[0];
                                //        string sateBeginLon = orbhPosition[1];
                                //        string sateBeginH = orbhPosition[2];

                                //        spyMinBtime = spyxBtime.AddSeconds(miAreaTimeSpan);

                                //        strStkcmd = "Position */Satellite/" + stkObject.SAT_STKNAME + " \"" + spyMinBtime.ToString("dd MMM yyyy HH:mm:ss") + "\"";
                                //        IAgExecCmdResult resultThreeTwo = root.ExecuteCommand(strStkcmd);
                                //        string orbhMinBPositionStr = resultThreeTwo[0];
                                //        string[] orbhMinBPosition = orbhMinBPositionStr.Split(' ');
                                //        string sateMinBBeginLat = orbhMinBPosition[0];
                                //        string sateMinBBeginLon = orbhMinBPosition[1];
                                //        string sateMinBBeginH = orbhMinBPosition[2];

                                //        //我不确定这里的赋值是否正确
                                //        spyxEtime = timeWindowEnd;

                                //        strStkcmd = "Position */Satellite/" + stkObject.SAT_STKNAME + " \"" + spyxEtime.ToString("dd MMM yyyy HH:mm:ss") + "\"";
                                //        IAgExecCmdResult resultThreeThree = root.ExecuteCommand(strStkcmd);
                                //        string orbhEndPositionStr = resultThreeThree[0];
                                //        string[] orbhEndPosition = orbhEndPositionStr.Split(' ');
                                //        string sateEndLat = orbhEndPosition[0];
                                //        string sateEndLon = orbhEndPosition[1];
                                //        string sateEndH = orbhEndPosition[2];

                                //        sypMinEtime = spyxEtime.AddSeconds(miAreaTimeSpan);

                                //        strStkcmd = "Position */Satellite/" + stkObject.SAT_STKNAME + " \"" + sypMinEtime.ToString("dd MMM yyyy HH:mm:ss") + "\"";
                                //        IAgExecCmdResult resultThreeFour = root.ExecuteCommand(strStkcmd);
                                //        string orbhMinEPositionStr = resultThreeFour[0];
                                //        string[] orbhMinEPosition = orbhMinEPositionStr.Split(' ');
                                //        string sateMinEEndLat = orbhEndPosition[0];
                                //        string sateMinEEndLon = orbhEndPosition[1];
                                //        string sateMinEEndH = orbhEndPosition[2]; 

                                //        int imageSpyRegionOneLen = imageSpyRegionOne.Length;
                                //        if (imageSpyRegionOneLen > 0)
                                //        {
                                //            tempimageSpyRegion = computerAreaThreeFourDotTaskSchemeSatelliteTimeWindow(sangle, slewangle, sateAngleD, sateMaxAngleD, sateAngleD, sateEndLat, sateEndLon, sateEndH, sateMinEEndLat, sateMinEEndLon, sateMinEEndH);
                                //            imageSpyRegionOne = imageSpyRegionOne + getOneThreeSite(tempimageSpyRegion);
                                //            imageSpyRegionTwo = imageSpyRegionTwo + getTwoFourSite(tempimageSpyRegion);
                                //        }
                                //        else
                                //        {
                                //            tempimageSpyRegion = computerAreaTaskSchemeSatelliteTimeWindow(sangle, slewangle, sateAngleD, sateMaxAngleD, sateAngleHD, sateBeginLat, sateBeginLon, sateBeginH, sateMinBBeginLat, sateMinBBeginLon, sateMinBBeginH, sateEndLat, sateEndLon, sateEndH, sateMinEEndLat, sateMinEEndLon, sateMinEEndH);
                                //            imageSpyRegionOne = imageSpyRegionOne + getOneThreeSite(tempimageSpyRegion);
                                //            imageSpyRegionTwo = imageSpyRegionTwo + getTwoFourSite(tempimageSpyRegion);
                                //        }
                                //    }
                                //    else
                                //    {
                                //        int timeAreaSpanBegin = r;

                                //        spyxBtime = timeWindowStart.AddSeconds(timeAreaSpanBegin);

                                //        strStkcmd = "Position */Satellite/"+ stkObject.SAT_STKNAME +" \""+spyxBtime.ToString("dd MMM yyyy HH:mm:ss")+"\"";
                                //        IAgExecCmdResult resultThreeOne = root.ExecuteCommand(strStkcmd);
                                //        string orbhPositionStr = resultThreeOne[0];
                                //        string[] orbhPosition = orbhPositionStr.Split(' ');
                                //        string sateBeginLat = orbhPosition[0];
                                //        string sateBeginLon = orbhPosition[1];
                                //        string sateBeginH = orbhPosition[2];

                                //        spyMinBtime = spyxBtime.AddSeconds(miAreaTimeSpan);

                                //        strStkcmd = "Position */Satellite/" + stkObject.SAT_STKNAME + " \"" + spyMinBtime.ToString("dd MMM yyyy HH:mm:ss") + "\"";
                                //        IAgExecCmdResult resultThreeTwo = root.ExecuteCommand(strStkcmd);
                                //        string orbhMinBPositionStr = resultThreeTwo[0];
                                //        string[] orbhMinBPosition = orbhMinBPositionStr.Split(' ');
                                //        string sateMinBBeginLat = orbhMinBPosition[0];
                                //        string sateMinBBeginLon = orbhMinBPosition[1];
                                //        string sateMinBBeginH = orbhMinBPosition[2];

                                //        spyxEtime = spyxBtime.AddSeconds(timeAreaSpan);

                                //        strStkcmd = "Position */Satellite/" + stkObject.SAT_STKNAME + " \"" + spyxEtime.ToString("dd MMM yyyy HH:mm:ss") + "\"";
                                //        IAgExecCmdResult resultThreeThree = root.ExecuteCommand(strStkcmd);
                                //        string orbhEndPositionStr = resultThreeThree[0];
                                //        string[] orbhEndPosition = orbhEndPositionStr.Split(' ');
                                //        string sateEndLat = orbhEndPosition[0];
                                //        string sateEndLon = orbhEndPosition[1];
                                //        string sateEndH = orbhEndPosition[2];

                                //        sypMinEtime = spyxEtime.AddSeconds(miAreaTimeSpan);

                                //        strStkcmd = "Position */Satellite/" + stkObject.SAT_STKNAME + " \"" + sypMinEtime.ToString("dd MMM yyyy HH:mm:ss") + "\"";
                                //        IAgExecCmdResult resultThreeFour = root.ExecuteCommand(strStkcmd);
                                //        string orbhMinEPositionStr = resultThreeFour[0];
                                //        string[] orbhMinEPosition = orbhMinEPositionStr.Split(' ');
                                //        string sateMinEEndLat = orbhEndPosition[0];
                                //        string sateMinEEndLon = orbhEndPosition[1];
                                //        string sateMinEEndH = orbhEndPosition[2]; 


                                //        int imageSpyRegionOneLen = imageSpyRegionOne.Length;
                                //        if (imageSpyRegionOneLen > 0)
                                //        {
                                //            tempimageSpyRegion = computerAreaThreeFourDotTaskSchemeSatelliteTimeWindow(sangle, slewangle, sateAngleD, sateMaxAngleD, sateAngleHD, sateEndLat, sateEndLon, sateEndH, sateMinEEndLat, sateMinEEndLon, sateMinEEndH);
                                //            imageSpyRegionOne = imageSpyRegionOne + getOneThreeSite(tempimageSpyRegion);

                                //            imageSpyRegionTwo = imageSpyRegionTwo + getTwoFourSite(tempimageSpyRegion);
                                //        }
                                //        else
                                //        {
                                //            tempimageSpyRegion = computerAreaTaskSchemeSatelliteTimeWindow(sangle, slewangle, sateAngleD, sateMaxAngleD, sateAngleHD, sateBeginLat, sateBeginLon, sateBeginH, sateMinBBeginLat, sateMinBBeginLon, sateMinBBeginH, sateEndLat, sateEndLon, sateEndH, sateMinEEndLat, sateMinEEndLon, sateMinEEndH);
                                //            imageSpyRegionOne = imageSpyRegionOne + getOneThreeSite(tempimageSpyRegion);

                                //            if (r < timeAreaSpyLastLen)
                                //            {
                                //                imageSpyRegionTwo = imageSpyRegionTwo + getTwoFourSite(tempimageSpyRegion);
                                //            }
                                //        }
                                //    }
                                //}

                                //imageSpyRegion = imageSpyRegionOne + getChangFrontBackSite(imageSpyRegionTwo);

                                #region 时间窗口入库
                                //CoScheduling.Core.Model.LAYOUT_SATELLITE_TIMEWINDOW layoutSatelliteTimewindow = new CoScheduling.Core.Model.LAYOUT_SATELLITE_TIMEWINDOW();
                                //CoScheduling.Core.DAL.LAYOUT_SATELLITE_TIMEWINDOW dal_layoutSatelliteTimewindow = new CoScheduling.Core.DAL.LAYOUT_SATELLITE_TIMEWINDOW();
                                //layoutSatelliteTimewindow.SAT_STKNAME = stkObject.SAT_STKNAME;
                                //layoutSatelliteTimewindow.SATID = taskSensor.SAT_ID;
                                //layoutSatelliteTimewindow.SENSOR_STKNAME = stkObject.SENSOR_STKNAME;
                                //layoutSatelliteTimewindow.SENSORID = taskSensor.SENSOR_ID;
                                //layoutSatelliteTimewindow.TARGET_STKNAME = stkTarget.TARGET_NAME;
                                //layoutSatelliteTimewindow.STARTTIME = timeWindowStart.AddHours(8);
                                //layoutSatelliteTimewindow.ENDTIME = timeWindowEnd.AddHours(8);
                                //layoutSatelliteTimewindow.SANGLE = Convert.ToDecimal(sangle);
                                //layoutSatelliteTimewindow.GSD = Convert.ToDecimal(currentGSD);
                                //layoutSatelliteTimewindow.CIRCLE = CircleNumber;
                                //layoutSatelliteTimewindow.TIMELONG = timeAreaSpyLastLen;
                                //layoutSatelliteTimewindow.IMAGEREGION = imageSpyRegion;
                                //layoutSatelliteTimewindow.SCHEMEID = schemeID;
                                //layoutSatelliteTimewindow.TASKID = taskLayoutId;
                                //dal_layoutSatelliteTimewindow.Add(layoutSatelliteTimewindow);
                                #endregion 时间窗口入库
                                #endregion

                                #endregion 计算成像区域

                            }
                        }
                    }
                    #endregion 处理区域目标过程

                }
            }
            #endregion 3.计算每个资源对目标的时间窗口
        }
        /// <summary>
        /// 对时间窗口成像区域，分辨率，侧摆角度等信息计算并存入数据库
        /// </summary>
        /// <param name="schemeID"></param>
        /// <param name="satName"></param>
        /// <param name="sensorName"></param>
        /// <param name="targetName"></param>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <param name="AZIMUTH"></param>
        /// <param name="ELEVATION"></param>
        /// <param name="RANGE"></param>
        /// <param name="sateBeginLat"></param>
        /// <param name="sateBeginLon"></param>
        /// <param name="sateBeginH"></param>
        /// <param name="sateMidLat"></param>
        /// <param name="sateMidLon"></param>
        /// <param name="sateMidH"></param>
        /// <param name="sateEndLat"></param>
        /// <param name="sateEndLon"></param>
        /// <param name="sateEndH"></param>
        /// <param name="targetLat"></param>
        /// <param name="targetLon"></param>
        public static void saveTaskSchemeSatelliteTimeWindow(int schemeID, int taskID, string satName, string sensorName, string targetName, DateTime beginTime, DateTime endTime, string AZIMUTH, string ELEVATION, string RANGE, string sateBeginLat, string sateBeginLon, string sateBeginH, string sateMidLat, string sateMidLon, string sateMidH, string sateEndLat, string sateEndLon, string sateEndH, decimal targetLat, decimal targetLon)
        {

            #region 弧度化
            //点目标经纬度
            double targetLatD = (double)targetLat * Math.PI / 180;
            double targetLonD = (double)targetLon * Math.PI / 180;
            //三时刻AER
            double sateBeginLatD, sateBeginLonD, sateBeginHD, sateMidLatD, sateMidLonD, sateMidHD, sateEndLatD, sateEndLonD, sateEndHD;
            sateBeginLatD = Convert.ToDouble(sateBeginLat) * Math.PI / 180.0;
            sateBeginLonD = Convert.ToDouble(sateBeginLon) * Math.PI / 180.0;
            sateBeginHD = Convert.ToDouble(sateBeginH) / 1000;

            sateMidLatD = Convert.ToDouble(sateMidLat) * Math.PI / 180.0;
            sateMidLonD = Convert.ToDouble(sateMidLon) * Math.PI / 180.0;
            sateMidHD = Convert.ToDouble(sateMidH) / 1000;

            sateEndLatD = Convert.ToDouble(sateEndLat) * Math.PI / 180.0;
            sateEndLonD = Convert.ToDouble(sateEndLon) * Math.PI / 180.0;
            sateEndHD = Convert.ToDouble(sateEndH) / 1000;
            #endregion 弧度化

            #region 计算侧摆角度
            //卫星与目标间的夹角
            double newtgsangle = getSatelliteTargetAngle(sateMidLatD, sateMidLonD, targetLatD, targetLonD, sateMidHD);
            //角度化
            double newangle = Math.Atan(newtgsangle) * 180 / Math.PI;
            //根据AER报告得到的夹角
            double a, b, rangeD;
            a = Convert.ToDouble(AZIMUTH);
            b = Convert.ToDouble(ELEVATION);
            rangeD = Convert.ToDouble(RANGE);
            double slewangle = GetYu(b, a);
            if (slewangle < 0)
            {
                slewangle = -1.0 * newangle;
            }
            else
            {
                slewangle = newangle;
            }
            double sangle = newangle;
            CoScheduling.Core.Model.TASKSCHEME_PRIVATE_SENSOR taskSensor = new CoScheduling.Core.Model.TASKSCHEME_PRIVATE_SENSOR();
            CoScheduling.Core.DAL.TASKSCHEME_PRIVATE_SENSOR dal_taskSensor = new CoScheduling.Core.DAL.TASKSCHEME_PRIVATE_SENSOR();
            taskSensor = dal_taskSensor.GetModel(satName, sensorName, schemeID);
            double sateAngleD = (double)taskSensor.SENSORANGLE;
            double sateMaxAngleD = (double)taskSensor.SENSOR_PARONE;
            double sateAngleHD = (double)taskSensor.SENSORANGLE;
            if (sangle < sateAngleD)
            {
                sangle = 0;
            }
            else if (sangle == sateAngleD)
            {
                sangle = 0;
            }
            else
            {
                if (!((sangle + sateAngleD) < sateMaxAngleD))
                {
                    sangle = sateMaxAngleD - sateAngleD;
                }
            }
            #endregion 计算侧摆角度

            #region 计算分辨率
            //获取载荷参数
            CoScheduling.Core.Model.T_PUB_SATELLITEPARA sensorPara = new CoScheduling.Core.Model.T_PUB_SATELLITEPARA();
            CoScheduling.Core.DAL.T_PUB_SATELLITEPARA dal_sensorPara = new CoScheduling.Core.DAL.T_PUB_SATELLITEPARA();
            sensorPara = dal_sensorPara.GetModel(taskSensor.SENSOR_ID);
            double sensorGSD = (double)sensorPara.MAXGSD;
            //计算当前分辨率
            double currentGSD = GetBestGsd(sensorGSD, rangeD, sateMidHD, sangle);
            #endregion 计算分辨率

            #region 计算在轨圈数
            int CircleNumber = ComputerSatelliteCircle(sensorPara.SATANGLEH, taskID, beginTime.AddHours(8));
            #endregion 计算在轨圈数

            #region 计算持续时间
            TimeSpan windowSpan = endTime - beginTime;
            int timeLastLen = (int)windowSpan.TotalSeconds;
            #endregion 计算持续时间

            #region 计算覆盖区域
            string imageSpyRegion = "";
            //开始点与中间点方位角
            double bearingMinBB = getABBearing(sateBeginLatD, sateBeginLonD, sateMidLatD, sateMidLonD);
            //中间点与结束点方位角
            double bearingMinEE = getABBearing(sateEndLatD, sateEndLonD, sateMidLatD, sateMidLonD);
            double bearingBB1 = bearingMinBB + 90;
            bearingBB1 = bearingBB1 - 360 * (int)(bearingBB1 / 360);

            double bearingBB2 = bearingMinBB + 270;
            bearingBB2 = bearingBB2 - 360 * (int)(bearingBB2 / 360);

            double bearingEE1 = bearingMinEE + 90;
            bearingEE1 = bearingEE1 - 360 * (int)(bearingEE1 / 360);

            double bearingEE2 = bearingMinEE + 270;
            bearingEE2 = bearingEE2 - 360 * (int)(bearingEE2 / 360);

            double sateAngleHalfD = sateAngleD;

            sateAngleHalfD = sateAngleHalfD * Math.PI / 180.0;

            double beforeDistance = getArcDistance(sateAngleHalfD, sateBeginHD);

            #region 测试扣除每次时间窗口前后
            //double beforeSiteLat = changetLAT(getBGFXSiteLat(sateBeginLatD, sateBeginLonD, beforeDistance, bearingMinBB));
            //beforeSiteLat = beforeSiteLat * Math.PI / 180.0;
            //double beforeSiteLon = changetLON(getBGFXSiteLon(sateBeginLatD, sateBeginLonD, beforeDistance, bearingMinBB));
            //beforeSiteLon = beforeSiteLon * Math.PI / 180.0;
            double beforeSiteLat = sateBeginLatD;
            double beforeSiteLon = sateBeginLonD;
            double lastDistance = getArcDistance(sateAngleHalfD, sateEndHD);
            //double lastSiteLat = changetLAT(getBGFXSiteLat(sateEndLatD, sateEndLonD, lastDistance, bearingMinEE));
            //lastSiteLat = lastSiteLat * Math.PI / 180.0;
            //double lastSiteLon = changetLON(getBGFXSiteLon(sateEndLatD, sateEndLonD, lastDistance, bearingMinEE));
            //lastSiteLon = lastSiteLon * Math.PI / 180.0;
            double lastSiteLat = sateEndLatD;
            double lastSiteLon = sateEndLonD;
            #endregion


            double halfMaxWAngle = sangle + sateAngleD;
            double halfMinWAngle = sangle - sateAngleD;
            double MaxAngle = halfMaxWAngle;
            double MinAngle = halfMinWAngle;
            halfMaxWAngle = halfMaxWAngle * Math.PI / 180.0;
            halfMinWAngle = halfMinWAngle * Math.PI / 180.0;

            double wMaxBDistance, wMinBDistance, wMaxEDistance, wMinEDistance, absHalfMinWAngle;

            wMaxBDistance = getArcDistance(halfMaxWAngle, sateBeginHD);
            wMaxEDistance = getArcDistance(halfMaxWAngle, sateEndHD);

            if (halfMinWAngle < 0)
            {
                absHalfMinWAngle = -1 * halfMinWAngle;
            }
            else
            {
                absHalfMinWAngle = halfMinWAngle;
            }
            wMinBDistance = getArcDistance(absHalfMinWAngle, sateBeginHD);
            wMinEDistance = getArcDistance(absHalfMinWAngle, sateEndHD);
            double bLat1, bLon1, bLat2, bLon2, bLat3, bLon3, bLat4, bLon4;
            if (!(slewangle > 0))
            {
                if (!(halfMinWAngle < 0))
                {
                    bLat1 = changetLAT(getBGFXSiteLat(beforeSiteLat, beforeSiteLon, wMaxBDistance, bearingBB1));
                    bLon1 = changetLON(getBGFXSiteLon(beforeSiteLat, beforeSiteLon, wMaxBDistance, bearingBB1));
                    bLat2 = changetLAT(getBGFXSiteLat(beforeSiteLat, beforeSiteLon, wMinBDistance, bearingBB1));
                    bLon2 = changetLON(getBGFXSiteLon(beforeSiteLat, beforeSiteLon, wMinBDistance, bearingBB1));
                    bLat3 = changetLAT(getBGFXSiteLat(lastSiteLat, lastSiteLon, wMaxEDistance, bearingEE2));
                    bLon3 = changetLON(getBGFXSiteLon(lastSiteLat, lastSiteLon, wMaxEDistance, bearingEE2));
                    bLat4 = changetLAT(getBGFXSiteLat(lastSiteLat, lastSiteLon, wMinEDistance, bearingEE2));
                    bLon4 = changetLON(getBGFXSiteLon(lastSiteLat, lastSiteLon, wMinEDistance, bearingEE2));
                }
                else
                {
                    halfMinWAngle = -1 * halfMinWAngle;
                    bLat1 = changetLAT(getBGFXSiteLat(beforeSiteLat, beforeSiteLon, wMaxBDistance, bearingBB1));
                    bLon1 = changetLON(getBGFXSiteLon(beforeSiteLat, beforeSiteLon, wMaxBDistance, bearingBB1));
                    bLat2 = changetLAT(getBGFXSiteLat(beforeSiteLat, beforeSiteLon, wMinBDistance, bearingBB2));
                    bLon2 = changetLON(getBGFXSiteLon(beforeSiteLat, beforeSiteLon, wMinBDistance, bearingBB2));
                    bLat3 = changetLAT(getBGFXSiteLat(lastSiteLat, lastSiteLon, wMaxEDistance, bearingEE2));
                    bLon3 = changetLON(getBGFXSiteLon(lastSiteLat, lastSiteLon, wMaxEDistance, bearingEE2));
                    bLat4 = changetLAT(getBGFXSiteLat(lastSiteLat, lastSiteLon, wMinEDistance, bearingEE1));
                    bLon4 = changetLON(getBGFXSiteLon(lastSiteLat, lastSiteLon, wMinEDistance, bearingEE1));
                }
            }
            else
            {

                if (!(halfMinWAngle < 0))
                {
                    bLat1 = changetLAT(getBGFXSiteLat(beforeSiteLat, beforeSiteLon, wMaxBDistance, bearingBB2));
                    bLon1 = changetLON(getBGFXSiteLon(beforeSiteLat, beforeSiteLon, wMaxBDistance, bearingBB2));
                    bLat2 = changetLAT(getBGFXSiteLat(beforeSiteLat, beforeSiteLon, wMinBDistance, bearingBB2));
                    bLon2 = changetLON(getBGFXSiteLon(beforeSiteLat, beforeSiteLon, wMinBDistance, bearingBB2));
                    bLat3 = changetLAT(getBGFXSiteLat(lastSiteLat, lastSiteLon, wMaxEDistance, bearingEE1));
                    bLon3 = changetLON(getBGFXSiteLon(lastSiteLat, lastSiteLon, wMaxEDistance, bearingEE1));
                    bLat4 = changetLAT(getBGFXSiteLat(lastSiteLat, lastSiteLon, wMinEDistance, bearingEE1));
                    bLon4 = changetLON(getBGFXSiteLon(lastSiteLat, lastSiteLon, wMinEDistance, bearingEE1));
                }
                else
                {
                    halfMinWAngle = -1 * halfMinWAngle;
                    bLat1 = changetLAT(getBGFXSiteLat(beforeSiteLat, beforeSiteLon, wMaxBDistance, bearingBB2));
                    bLon1 = changetLON(getBGFXSiteLon(beforeSiteLat, beforeSiteLon, wMaxBDistance, bearingBB2));
                    bLat2 = changetLAT(getBGFXSiteLat(beforeSiteLat, beforeSiteLon, wMinBDistance, bearingBB1));
                    bLon2 = changetLON(getBGFXSiteLon(beforeSiteLat, beforeSiteLon, wMinBDistance, bearingBB1));
                    bLat3 = changetLAT(getBGFXSiteLat(lastSiteLat, lastSiteLon, wMaxEDistance, bearingEE1));
                    bLon3 = changetLON(getBGFXSiteLon(lastSiteLat, lastSiteLon, wMaxEDistance, bearingEE1));
                    bLat4 = changetLAT(getBGFXSiteLat(lastSiteLat, lastSiteLon, wMinEDistance, bearingEE2));
                    bLon4 = changetLON(getBGFXSiteLon(lastSiteLat, lastSiteLon, wMinEDistance, bearingEE2));
                }
            }
            imageSpyRegion = bLon1 + "," + bLat1 + ";" + bLon2 + "," + bLat2 + ";" + bLon4 + "," + bLat4 + ";" + bLon3 + "," + bLat3 + ";";
            #endregion 计算覆盖区域

            #region 时间窗口入库
            CoScheduling.Core.Model.LAYOUT_SATELLITE_TIMEWINDOW layoutSatelliteTimewindow = new CoScheduling.Core.Model.LAYOUT_SATELLITE_TIMEWINDOW();
            CoScheduling.Core.DAL.LAYOUT_SATELLITE_TIMEWINDOW dal_layoutSatelliteTimewindow = new CoScheduling.Core.DAL.LAYOUT_SATELLITE_TIMEWINDOW();
            layoutSatelliteTimewindow.SAT_STKNAME = satName;
            layoutSatelliteTimewindow.SATID = taskSensor.SAT_ID;
            layoutSatelliteTimewindow.SENSOR_STKNAME = sensorName;
            layoutSatelliteTimewindow.SENSORID = taskSensor.SENSOR_ID;
            layoutSatelliteTimewindow.TARGET_STKNAME = targetName;
            //时间入库，调整为东八区时刻
            layoutSatelliteTimewindow.STARTTIME = beginTime.AddHours(8);
            layoutSatelliteTimewindow.ENDTIME = endTime.AddHours(8);
            layoutSatelliteTimewindow.SANGLE = Convert.ToDecimal(sangle);
            layoutSatelliteTimewindow.MAXSANGLE = Convert.ToDecimal(MaxAngle);
            layoutSatelliteTimewindow.MINSANGLE = Convert.ToDecimal(MinAngle);
            layoutSatelliteTimewindow.GSD = Convert.ToDecimal(currentGSD);
            layoutSatelliteTimewindow.CIRCLE = CircleNumber;
            layoutSatelliteTimewindow.TIMELONG = timeLastLen;
            layoutSatelliteTimewindow.IMAGEREGION = imageSpyRegion;
            layoutSatelliteTimewindow.SCHEMEID = schemeID;
            layoutSatelliteTimewindow.TASKID = taskID;
            dal_layoutSatelliteTimewindow.Add(layoutSatelliteTimewindow);
            #endregion 时间窗口入库
        }
        /// <summary>
        /// 复制卫星时间窗口到临时表
        /// </summary>
        /// <param name="schemeID"></param>
        public static void copyTaskSchemeTimeWindowTemp(int schemeID)
        {
            CoScheduling.Core.DAL.ImgLayoutTempTimewindow dal_imgLayoutTempTimewindow = new CoScheduling.Core.DAL.ImgLayoutTempTimewindow();
            dal_imgLayoutTempTimewindow.CopyFromLayoutSatelliteTimewindow(schemeID.ToString());
        }
        /// <summary>
        /// 删选临时表中的卫星时间窗口
        /// </summary>
        /// <param name="schemeID"></param>
        public static void choicePossibleTimeWindow(int schemeID)
        {
            //根据schemeid找出所有任务
            List<CoScheduling.Core.Model.TASK_LAYOUT_LIST> taskLayoutList = new List<CoScheduling.Core.Model.TASK_LAYOUT_LIST>();
            CoScheduling.Core.DAL.TASK_LAYOUT_LIST dal_taskLayout = new CoScheduling.Core.DAL.TASK_LAYOUT_LIST();
            taskLayoutList = dal_taskLayout.GetList(schemeID);
            foreach (CoScheduling.Core.Model.TASK_LAYOUT_LIST taskLayout in taskLayoutList)
            {
                int targetId;
                decimal maxGSD;
                DateTime simBtime, simEtime;
                targetId = taskLayout.TASKID;
                maxGSD = taskLayout.MAXGSD;
                simBtime = taskLayout.STARTTIME;
                simEtime = taskLayout.ENDTIME;
                //删除不符合要求的时间窗口
                deleteImpossibleTimeWindows(targetId, schemeID, maxGSD, simBtime, simEtime);
                //应该更新临时观测时间窗口表的时间
                updateImpossibleTimeWindows(targetId, schemeID, simBtime, simEtime);
            }
        }
        /// <summary>
        /// 删除不符合分辨率，时间要求的时间窗口
        /// </summary>
        /// <param name="taskID"></param>
        /// <param name="schemeID"></param>
        /// <param name="imgGSD"></param>
        /// <param name="simBtime"></param>
        /// <param name="simEtime"></param>
        public static void deleteImpossibleTimeWindows(int taskID, int schemeID, decimal imgGSD, DateTime simBtime, DateTime simEtime)
        {
            CoScheduling.Core.DAL.ImgLayoutTempTimewindow dal_imgLayoutTempTimewindow = new CoScheduling.Core.DAL.ImgLayoutTempTimewindow();
            //删除不满足分辨率要求的时间窗口
            dal_imgLayoutTempTimewindow.DeleteByGSD(schemeID, taskID, imgGSD);
            //删除任务结束后才开始的时间窗口
            dal_imgLayoutTempTimewindow.DeleteAfterEnd(schemeID, taskID, simEtime);
            //删除任务开始前就结束的时间窗口
            dal_imgLayoutTempTimewindow.DeleteBeforeStart(schemeID, taskID, simBtime);

        }
        /// <summary>
        /// 更新任务时间边缘的时间窗口
        /// </summary>
        /// <param name="taskID"></param>
        /// <param name="schemeID"></param>
        /// <param name="simBtime"></param>
        /// <param name="simEtime"></param>
        public static void updateImpossibleTimeWindows(int taskID, int schemeID, DateTime simBtime, DateTime simEtime)
        {
            CoScheduling.Core.DAL.ImgLayoutTempTimewindow dal_imgLayoutTempTimewindow = new CoScheduling.Core.DAL.ImgLayoutTempTimewindow();
            //更新开始时刻的时间窗口
            dal_imgLayoutTempTimewindow.UpdateBeforeStart(schemeID, taskID, simBtime);
            //更新结束时刻的时间窗口
            dal_imgLayoutTempTimewindow.UpdateAfterEnd(schemeID, taskID, simEtime);

        }
        /// <summary>
        /// 进行任务规划
        /// </summary>
        /// <param name="schemeID"></param>
        public static void planingTimeWindow(int schemeID)
        {
            //获取方案下的任务列表
            List<CoScheduling.Core.Model.TASK_LAYOUT_LIST> taskLayoutList = new List<CoScheduling.Core.Model.TASK_LAYOUT_LIST>();
            CoScheduling.Core.DAL.TASK_LAYOUT_LIST dal_taskLayout = new CoScheduling.Core.DAL.TASK_LAYOUT_LIST();
            taskLayoutList = dal_taskLayout.GetList(schemeID);
            //对每个任务进行解析
            foreach (CoScheduling.Core.Model.TASK_LAYOUT_LIST taskLayout in taskLayoutList)
            {
                int targetId = taskLayout.TARGET_ID;
                int taskId = taskLayout.TASKID;
                DateTime starttime = taskLayout.STARTTIME;
                DateTime endtime = taskLayout.ENDTIME;
                int priority = taskLayout.PRIORITY;
                int isContinue;
                //如果是区域任务，则全部用连续任务对待
                if (taskLayout.TASKTYPE == 1)
                {
                    isContinue = 1;
                }
                else
                {
                    isContinue = taskLayout.ISCONTINUEDSPY;
                }
                //获取该任务的所有时间窗口
                List<CoScheduling.Core.Model.ImgLayoutTempTimewindow> imgLayoutTempTimewindowList = new List<CoScheduling.Core.Model.ImgLayoutTempTimewindow>();
                CoScheduling.Core.DAL.ImgLayoutTempTimewindow dal_imgLayoutTempTimewindowList = new CoScheduling.Core.DAL.ImgLayoutTempTimewindow();
                //该任务的时间窗口数量
                int taskTimeWindow = dal_imgLayoutTempTimewindowList.GetCount("TASKID=" + taskId);
                //判断该任务是否有时间窗口
                //如果有，则执行if下的操作
                if (taskTimeWindow > 0)
                {
                    int ifhaveTimeWindows = dal_imgLayoutTempTimewindowList.GetCount("TASKID=" + taskId + " AND IS_OCCUPY=0 AND IS_AFFECT=0");
                    //未被占用且未受影响的时间窗口
                    if (ifhaveTimeWindows > 0)
                    {
                        //获取未被占用和未受影响的时间窗口
                        imgLayoutTempTimewindowList = dal_imgLayoutTempTimewindowList.GetListByTaskID(taskId, "IS_OCCUPY=0 AND IS_AFFECT=0");
                        //连续任务处理
                        if (isContinue == 1)
                        {
                            #region 连续任务处理
                            int subTaskid = 1;
                            //对每个时间窗口进行以下三项操作：1.符合条件的入库；2.该卫星相同时间的其他窗口影响；3.开关机，时间影响
                            foreach (CoScheduling.Core.Model.ImgLayoutTempTimewindow imgLayoutTempTimewindow in imgLayoutTempTimewindowList)
                            {
                                //1.符合条件的时间窗口入库
                                CoScheduling.Core.Model.IMG_LAYOUT_RESULT imgLayoutResault = new CoScheduling.Core.Model.IMG_LAYOUT_RESULT();
                                CoScheduling.Core.DAL.IMG_LAYOUT_RESULT dal_imgLayoutResault = new CoScheduling.Core.DAL.IMG_LAYOUT_RESULT();
                                imgLayoutResault.LSTR_SEQID = imgLayoutTempTimewindow.LSTR_SEQID;
                                imgLayoutResault.MPPERIODID = 1;
                                imgLayoutResault.SCHEMEID = imgLayoutTempTimewindow.SCHEMEID;
                                imgLayoutResault.TASKID = imgLayoutTempTimewindow.TASKID;

                                imgLayoutResault.SUBTASKID = subTaskid.ToString();
                                imgLayoutResault.SATID = imgLayoutTempTimewindow.SATID;
                                imgLayoutResault.SATSTKNAME = imgLayoutTempTimewindow.SAT_STKNAME;
                                imgLayoutResault.SENSORID = imgLayoutTempTimewindow.SENSOR_ID;
                                imgLayoutResault.SENSORSTKNAME = imgLayoutTempTimewindow.SENSOR_STKNAME;
                                imgLayoutResault.ZCSTARTTIME = imgLayoutTempTimewindow.STARTTIME;
                                imgLayoutResault.ZCENDTIME = imgLayoutTempTimewindow.ENDTIME;
                                imgLayoutResault.DATACAP = imgLayoutTempTimewindow.TIMELONG;
                                imgLayoutResault.SLEWANGLE = Convert.ToDouble(imgLayoutTempTimewindow.SANGLE);
                                imgLayoutResault.RESOLUTION = Convert.ToDouble(imgLayoutTempTimewindow.GSD);
                                imgLayoutResault.QUANTITY = Convert.ToDouble(imgLayoutTempTimewindow.GSD);
                                imgLayoutResault.PRECISION = 0;
                                imgLayoutResault.IMAGEREGION = imgLayoutTempTimewindow.IMAGEREGION;
                                imgLayoutResault.COMPOSEDNUMBER = taskId + "-" + subTaskid;
                                imgLayoutResault.GROUNDID = "";
                                imgLayoutResault.DLTYPE = 0;
                                imgLayoutResault.DLWINDOWID = 0;
                                imgLayoutResault.DOWNSTART = imgLayoutTempTimewindow.STARTTIME;
                                imgLayoutResault.DOWNEND = imgLayoutTempTimewindow.ENDTIME;
                                imgLayoutResault.TASK_TYPE = taskLayout.TASKTYPE;
                                imgLayoutResault.TASKSTARTTIME = taskLayout.STARTTIME;
                                imgLayoutResault.TASKENDTIME = taskLayout.ENDTIME;
                                imgLayoutResault.PRIORITY = taskLayout.PRIORITY;
                                imgLayoutResault.SIMTASK_STATE = imgLayoutTempTimewindow.IS_AFFECT;
                                imgLayoutResault.TARGET_ID = taskLayout.TASKID;
                                imgLayoutResault.IS_ABLE = 0;
                                imgLayoutResault.IF_SEND = 0;
                                imgLayoutResault.ISCONTINUEDSPY = isContinue;
                                dal_imgLayoutResault.Add(imgLayoutResault);
                                //连续任务的子任务编号++
                                subTaskid++;
                                //2.该卫星相同时间的其他窗口影响
                                UpdateLayoutResult(imgLayoutResault);
                                //3.更新其他受影响的时间窗口，开关机，同一圈工作时长等
                                UpdateOtherConflictResult(imgLayoutResault.LSTR_SEQID);
                            }
                            #endregion 连续任务处理
                        }
                        else
                        {
                            #region 非连续任务处理
                            int subTaskid = 1;
                            //对每个时间窗口进行以下三项操作：1.符合条件的入库；2.该卫星相同时间的其他窗口影响；3.开关机，时间影响
                            foreach (CoScheduling.Core.Model.ImgLayoutTempTimewindow imgLayoutTempTimewindow in imgLayoutTempTimewindowList)
                            {
                                //1.符合条件的时间窗口入库
                                CoScheduling.Core.Model.IMG_LAYOUT_RESULT imgLayoutResault = new CoScheduling.Core.Model.IMG_LAYOUT_RESULT();
                                CoScheduling.Core.DAL.IMG_LAYOUT_RESULT dal_imgLayoutResault = new CoScheduling.Core.DAL.IMG_LAYOUT_RESULT();
                                imgLayoutResault.LSTR_SEQID = imgLayoutTempTimewindow.LSTR_SEQID;
                                imgLayoutResault.MPPERIODID = 1;
                                imgLayoutResault.SCHEMEID = imgLayoutTempTimewindow.SCHEMEID;
                                imgLayoutResault.TASKID = imgLayoutTempTimewindow.TASKID;
                                //连续任务的子任务编号++
                                imgLayoutResault.SUBTASKID = subTaskid.ToString();
                                imgLayoutResault.SATID = imgLayoutTempTimewindow.SATID;
                                imgLayoutResault.SATSTKNAME = imgLayoutTempTimewindow.SAT_STKNAME;
                                imgLayoutResault.SENSORID = imgLayoutTempTimewindow.SENSOR_ID;
                                imgLayoutResault.SENSORSTKNAME = imgLayoutTempTimewindow.SENSOR_STKNAME;
                                imgLayoutResault.ZCSTARTTIME = imgLayoutTempTimewindow.STARTTIME;
                                imgLayoutResault.ZCENDTIME = imgLayoutTempTimewindow.ENDTIME;
                                imgLayoutResault.DATACAP = imgLayoutTempTimewindow.TIMELONG;
                                imgLayoutResault.SLEWANGLE = Convert.ToDouble(imgLayoutTempTimewindow.SANGLE);
                                imgLayoutResault.RESOLUTION = Convert.ToDouble(imgLayoutTempTimewindow.GSD);
                                imgLayoutResault.QUANTITY = Convert.ToDouble(imgLayoutTempTimewindow.GSD);
                                imgLayoutResault.PRECISION = 0;
                                imgLayoutResault.IMAGEREGION = imgLayoutTempTimewindow.IMAGEREGION;
                                imgLayoutResault.COMPOSEDNUMBER = taskId + "-" + subTaskid;
                                imgLayoutResault.GROUNDID = "";
                                imgLayoutResault.DLTYPE = 0;
                                imgLayoutResault.DLWINDOWID = 0;
                                imgLayoutResault.DOWNSTART = imgLayoutTempTimewindow.STARTTIME;
                                imgLayoutResault.DOWNEND = imgLayoutTempTimewindow.ENDTIME;
                                imgLayoutResault.TASK_TYPE = taskLayout.TASKTYPE;
                                imgLayoutResault.TASKSTARTTIME = taskLayout.STARTTIME;
                                imgLayoutResault.TASKENDTIME = taskLayout.ENDTIME;
                                imgLayoutResault.PRIORITY = taskLayout.PRIORITY;
                                imgLayoutResault.SIMTASK_STATE = imgLayoutTempTimewindow.IS_AFFECT;
                                imgLayoutResault.TARGET_ID = taskLayout.TASKID;
                                imgLayoutResault.IS_ABLE = 0;
                                imgLayoutResault.IF_SEND = 0;
                                imgLayoutResault.ISCONTINUEDSPY = isContinue;
                                dal_imgLayoutResault.Add(imgLayoutResault);
                                //2.该卫星相同时间的其他窗口影响
                                UpdateLayoutResult(imgLayoutResault);
                                //3.更新其他受影响的时间窗口，开关机，同一圈工作时长等
                                UpdateOtherConflictResult(imgLayoutResault.LSTR_SEQID);
                            }
                            #endregion 非连续任务处理
                        }
                    }
                    //未被占用或未受影响的时间窗口
                    //不存在没有占用和影响的窗口
                    else
                    {
                        #region 不存在没有占用和影响的窗口
                        int subTaskid = 1;
                        imgLayoutTempTimewindowList = dal_imgLayoutTempTimewindowList.GetListByTaskID(taskId, "IS_OCCUPY<>0 OR IS_AFFECT<>0");
                        int minPRIORITY = 1000;
                        decimal minSECseqId = 0;
                        string minAffOcu = "";
                        foreach (CoScheduling.Core.Model.ImgLayoutTempTimewindow imgLayoutTempTimewindow in imgLayoutTempTimewindowList)
                        {
                            //1.对任务优先级做处理
                            int affPriority = getAffTaskPrioritySum(imgLayoutTempTimewindow.AFF_OCUSTR, imgLayoutTempTimewindow.SCHEMEID);
                            if (minPRIORITY > affPriority)
                            {
                                minPRIORITY = affPriority;
                                minSECseqId = imgLayoutTempTimewindow.LSTR_SEQID;
                                minAffOcu = imgLayoutTempTimewindow.AFF_OCUSTR;
                            }
                        }
                        //得到当前任务的优先级
                        int currentTaskPriority = taskLayout.PRIORITY;
                        if (currentTaskPriority > minPRIORITY)
                        {
                            //如果成立，则可替换，否则不可操作
                            //更新规划结果
                            updateTaskResultRecord(minAffOcu, schemeID, minSECseqId);

                            //2.符合条件的时间窗口入库
                            CoScheduling.Core.Model.ImgLayoutTempTimewindow imgLayoutTempTimewindow = new CoScheduling.Core.Model.ImgLayoutTempTimewindow();
                            imgLayoutTempTimewindow = dal_imgLayoutTempTimewindowList.GetModel(minSECseqId.ToString());
                            CoScheduling.Core.Model.IMG_LAYOUT_RESULT imgLayoutResault = new CoScheduling.Core.Model.IMG_LAYOUT_RESULT();
                            CoScheduling.Core.DAL.IMG_LAYOUT_RESULT dal_imgLayoutResault = new CoScheduling.Core.DAL.IMG_LAYOUT_RESULT();
                            imgLayoutResault.LSTR_SEQID = imgLayoutTempTimewindow.LSTR_SEQID;
                            imgLayoutResault.MPPERIODID = 1;
                            imgLayoutResault.SCHEMEID = imgLayoutTempTimewindow.SCHEMEID;
                            imgLayoutResault.TASKID = imgLayoutTempTimewindow.TASKID;
                            imgLayoutResault.SUBTASKID = subTaskid.ToString();
                            imgLayoutResault.SATID = imgLayoutTempTimewindow.SATID;
                            imgLayoutResault.SATSTKNAME = imgLayoutTempTimewindow.SAT_STKNAME;
                            imgLayoutResault.SENSORID = imgLayoutTempTimewindow.SENSOR_ID;
                            imgLayoutResault.SENSORSTKNAME = imgLayoutTempTimewindow.SENSOR_STKNAME;
                            imgLayoutResault.ZCSTARTTIME = imgLayoutTempTimewindow.STARTTIME;
                            imgLayoutResault.ZCENDTIME = imgLayoutTempTimewindow.ENDTIME;
                            imgLayoutResault.DATACAP = imgLayoutTempTimewindow.TIMELONG;
                            imgLayoutResault.SLEWANGLE = Convert.ToDouble(imgLayoutTempTimewindow.SANGLE);
                            imgLayoutResault.RESOLUTION = Convert.ToDouble(imgLayoutTempTimewindow.GSD);
                            imgLayoutResault.QUANTITY = Convert.ToDouble(imgLayoutTempTimewindow.GSD);
                            imgLayoutResault.PRECISION = 0;
                            imgLayoutResault.IMAGEREGION = imgLayoutTempTimewindow.IMAGEREGION;
                            imgLayoutResault.COMPOSEDNUMBER = taskId + "-" + subTaskid;
                            imgLayoutResault.GROUNDID = "";
                            imgLayoutResault.DLTYPE = 0;
                            imgLayoutResault.DLWINDOWID = 0;
                            imgLayoutResault.DOWNSTART = imgLayoutTempTimewindow.STARTTIME;
                            imgLayoutResault.DOWNEND = imgLayoutTempTimewindow.ENDTIME;
                            imgLayoutResault.TASK_TYPE = taskLayout.TASKTYPE;
                            imgLayoutResault.TASKSTARTTIME = taskLayout.STARTTIME;
                            imgLayoutResault.TASKENDTIME = taskLayout.ENDTIME;
                            imgLayoutResault.PRIORITY = imgLayoutTempTimewindow.PRIORITY;
                            imgLayoutResault.SIMTASK_STATE = imgLayoutTempTimewindow.IS_AFFECT;
                            imgLayoutResault.TARGET_ID = taskLayout.TASKID;
                            imgLayoutResault.IS_ABLE = 0;
                            imgLayoutResault.IF_SEND = 0;
                            imgLayoutResault.ISCONTINUEDSPY = isContinue;
                            dal_imgLayoutResault.Add(imgLayoutResault);
                            //3.该卫星相同时间的其他窗口影响
                            UpdateLayoutResult(imgLayoutResault);
                            //4.更新其他受影响的时间窗口，开关机，同一圈工作时长等
                            UpdateOtherConflictResult(imgLayoutResault.LSTR_SEQID);
                        }
                        //计算相关影响观测窗口的任务优先级之和
                        #endregion 不存在没有占用和影响的窗口
                    }
                }
                //无成像窗口
                else
                {
                    //插入无效的记录，不做任何工作
                }
            }
        }
        /// <summary>
        /// 根据任务优先级结果更新IMG_LAYOUT_TEMPTIMEWINDOW，并删除IMG_LAYOUT_RESULT中重新分配给其他任务的结果
        /// </summary>
        /// <param name="AffrecordStr"></param>
        /// <param name="schemeid"></param>
        /// <param name="curRecord"></param>
        public static void updateTaskResultRecord(string AffrecordStr, int schemeid, decimal curRecord)
        {
            int allSeqID = AffrecordStr.Length;
            if (allSeqID > 0)
            {
                AffrecordStr = AffrecordStr.Substring(0, allSeqID - 1).Trim();
            }
            CoScheduling.Core.DAL.IMG_LAYOUT_RESULT dal_imgLayoutResualt = new CoScheduling.Core.DAL.IMG_LAYOUT_RESULT();
            dal_imgLayoutResualt.DeleteByCondition("LSTR_SEQID IN (" + AffrecordStr + ") and SCHEMEID=" + schemeid);
            CoScheduling.Core.DAL.ImgLayoutTempTimewindow dal_imgLayoutTempTimewindow = new CoScheduling.Core.DAL.ImgLayoutTempTimewindow();
            dal_imgLayoutTempTimewindow.UpdateByLSTR_SEQID(curRecord, AffrecordStr);
        }
        /// <summary>
        /// 获取影响当前任务的所有任务的优先级之和
        /// </summary>
        /// <param name="AffrecordStr"></param>
        /// <param name="schemeid"></param>
        /// <returns></returns>
        public static int getAffTaskPrioritySum(string AffrecordStr, decimal schemeid)
        {
            int sumPriority = 0;
            string[] sqeid = AffrecordStr.Split(',');
            for (int i = 0; i < sqeid.Length - 1; i++)
            {
                CoScheduling.Core.Model.ImgLayoutTempTimewindow imgLayoutTempTimewindow = new CoScheduling.Core.Model.ImgLayoutTempTimewindow();
                CoScheduling.Core.DAL.ImgLayoutTempTimewindow dal_imgLayoutTempTimewindow = new CoScheduling.Core.DAL.ImgLayoutTempTimewindow();
                imgLayoutTempTimewindow = dal_imgLayoutTempTimewindow.GetModel(sqeid[i]);

                CoScheduling.Core.Model.TASK_LAYOUT_LIST taskLayout = new CoScheduling.Core.Model.TASK_LAYOUT_LIST();
                CoScheduling.Core.DAL.TASK_LAYOUT_LIST dal_taskLayout = new CoScheduling.Core.DAL.TASK_LAYOUT_LIST();
                taskLayout = dal_taskLayout.GetModel(Convert.ToInt32(imgLayoutTempTimewindow.TASKID));

                CoScheduling.Core.DAL.IMG_LAYOUT_RESULT dal_imgLayoutResault = new CoScheduling.Core.DAL.IMG_LAYOUT_RESULT();
                int isContinue = 0;
                //如果是区域任务，则全部用连续任务对待
                if (taskLayout.TASKTYPE == 1)
                {
                    isContinue = 1;
                }
                else
                {
                    isContinue = taskLayout.ISCONTINUEDSPY;
                }

                if (isContinue == 0)
                {
                    //单次观测
                    sumPriority = sumPriority + Convert.ToInt32(imgLayoutTempTimewindow.PRIORITY);
                }
                else
                {
                    //连续观测任务是否存在两个或两个以上的观测窗口
                    int haveMoreWindows = dal_imgLayoutResault.GetCount("TASKID = " + imgLayoutTempTimewindow.TASKID + " AND AND IS_ABLE=1");
                    if (haveMoreWindows > 1)
                    {
                        //不进行累加
                        sumPriority = sumPriority;
                    }
                    else
                    {
                        sumPriority = sumPriority + Convert.ToInt32(imgLayoutTempTimewindow.PRIORITY);
                    }
                }
            }
            return sumPriority;
        }
        /// <summary>
        /// 更新受其它影响的时间窗口
        /// </summary>
        /// <param name="recordID"></param>
        public static void UpdateOtherConflictResult(decimal recordID)
        {
            //获取时间窗口
            CoScheduling.Core.Model.ImgLayoutTempTimewindow imgLayoutTempTimewindow = new CoScheduling.Core.Model.ImgLayoutTempTimewindow();
            CoScheduling.Core.DAL.ImgLayoutTempTimewindow dal_imgLayoutTempTimewindow = new CoScheduling.Core.DAL.ImgLayoutTempTimewindow();
            imgLayoutTempTimewindow = dal_imgLayoutTempTimewindow.GetModel(recordID.ToString());
            //获取该窗口的卫星参数
            CoScheduling.Core.Model.T_PUB_SATELLITEPARA satellitePara = new CoScheduling.Core.Model.T_PUB_SATELLITEPARA();
            CoScheduling.Core.DAL.T_PUB_SATELLITEPARA dal_satellitePara = new CoScheduling.Core.DAL.T_PUB_SATELLITEPARA();
            satellitePara = dal_satellitePara.GetModel(imgLayoutTempTimewindow.SENSOR_ID);
            //依据获取的卫星编号，去查它的单圈开关机次数和单圈最长工作时间（秒）
            List<CoScheduling.Core.Model.ImgLayoutTempTimewindow> imgLayoutTempTimewindowList = new List<CoScheduling.Core.Model.ImgLayoutTempTimewindow>();
            imgLayoutTempTimewindowList = dal_imgLayoutTempTimewindow.GetListByCondition("SCHEMEID=" + imgLayoutTempTimewindow.SCHEMEID + " AND SENSOR_ID=" + imgLayoutTempTimewindow.SENSOR_ID + " and circle=" + imgLayoutTempTimewindow.CIRCLE + " and is_occupy=1");
            int circleNum = 0;
            decimal timeLong = 0;
            //得到了当前记录所在圈次的开关机次和工作时间
            //它自身的圈次已经加上了，因此在此不要再加圈次和工作时间了
            foreach (CoScheduling.Core.Model.ImgLayoutTempTimewindow imgLayoutTemp in imgLayoutTempTimewindowList)
            {
                circleNum++;
                timeLong = timeLong + imgLayoutTemp.TIMELONG;
            }
            //如果开关机次数与星次数相等，则更新此圈中所有的影响为1
            //卫星单圈最长工作时间,或者最长工作时间在本圈次还剩下五秒后，就不能再用了
            if ((circleNum == satellitePara.OPENCLOSETIME) || (timeLong > satellitePara.WORKLASTTIME) || (satellitePara.WORKLASTTIME - timeLong < 5))
            {
                decimal LSTR_SEQID = recordID;
                decimal IS_AFFECT = 1;
                decimal satid = imgLayoutTempTimewindow.SATID;
                decimal schemeid = imgLayoutTempTimewindow.SCHEMEID;
                decimal circle = imgLayoutTempTimewindow.CIRCLE;
                dal_imgLayoutTempTimewindow.UpdateOtherAff(LSTR_SEQID, satid, schemeid, circle, IS_AFFECT);
            }
        }
        /// <summary>
        /// 显示卫星资源时间窗口
        /// </summary>
        /// <param name="schemeid"></param>
        public static void showSatelliteTimewindow(int schemeid)
        {
            PlanRes.dataGridViewTimewindow.AutoGenerateColumns = false;
            CoScheduling.Core.DAL.ImgLayoutTempTimewindow dal = new CoScheduling.Core.DAL.ImgLayoutTempTimewindow();
            List<CoScheduling.Core.Model.ImgLayoutTempTimewindow> list_model = new List<CoScheduling.Core.Model.ImgLayoutTempTimewindow>();
            list_model = dal.GetListBySchemeID(schemeid.ToString());
            PlanRes.dataGridViewTimewindow.DataSource = list_model;
        }
        /// <summary>
        /// 显示卫星规划结果
        /// </summary>
        /// <param name="schemeid"></param>
        public static void showSatelliteResault(int schemeid)
        {
            PlanRes.dataGridViewResault.AutoGenerateColumns = false;
            CoScheduling.Core.DAL.IMG_LAYOUT_RESULT dal = new CoScheduling.Core.DAL.IMG_LAYOUT_RESULT();
            List<CoScheduling.Core.Model.IMG_LAYOUT_RESULT> list_model = new List<CoScheduling.Core.Model.IMG_LAYOUT_RESULT>();
            list_model = dal.GetList("SCHEMEID=" + schemeid);
            PlanRes.dataGridViewResault.DataSource = list_model;
        }
        /// <summary>
        /// 更新受影响的临时窗口
        /// </summary>
        /// <param name="imgLayoutResault"></param>
        public static void UpdateLayoutResult(IMG_LAYOUT_RESULT imgLayoutResault)
        {
            CoScheduling.Core.DAL.ImgLayoutTempTimewindow dal_imgLayoutTempTimewindow = new CoScheduling.Core.DAL.ImgLayoutTempTimewindow();
            decimal LSTR_SEQID = imgLayoutResault.LSTR_SEQID;
            decimal IS_OCCUPY = 1;
            //更新当前时间窗口的占用符号
            dal_imgLayoutTempTimewindow.UpdateOccupy(LSTR_SEQID, IS_OCCUPY);
            //更新受当前时间窗口影响的同一卫星的其他时间窗口的影响符号
            decimal IS_AFFECT = 1;
            decimal satid = imgLayoutResault.SATID;
            decimal schemeid = imgLayoutResault.SCHEMEID;
            DateTime starttime = imgLayoutResault.ZCSTARTTIME;
            DateTime endtime = imgLayoutResault.ZCENDTIME;
            dal_imgLayoutTempTimewindow.UpdateOtherAffS(LSTR_SEQID, satid, schemeid, starttime, endtime, IS_AFFECT);
            dal_imgLayoutTempTimewindow.UpdateOtherAffE(LSTR_SEQID, satid, schemeid, starttime, endtime, IS_AFFECT);
        }
        public static void TaskPlanning()
        {
            formCOV.setStatus("时间窗口计算...");
            //1.清除任务观测结果
            clearTaskSchemeLayoutTimeWindow(schemeID);
            //2.计算所有资源对目标的访问时间窗口
            ComputerLayoutTaskSchemeTimeWindow(schemeID);
            //3.把时间窗口放到一个临时表中－img_layouttemp_str
            copyTaskSchemeTimeWindowTemp(schemeID);
            //4.根据目标侦察的时间，分辨率要求，进行数据筛选
            choicePossibleTimeWindow(schemeID);
            formCOV.setStatus("卫星任务规划...");
            //5.根据任务优先级进行规划
            planingTimeWindow(schemeID);
            formCOV.buttonPosition.Enabled = true;
            MessageBox.Show("任务规划完成！");
            //6.显示能力结果
            showSatelliteTimewindow(schemeID);
            showSatelliteResault(schemeID);
            formCOV.setStatus("卫星任务规划完成。请点击“获取轨道”按钮，执行下一步。");
        }

        #endregion
       #endregion

        #region STK辅助功能

        internal static string m_ScDocument;
        internal static Coverage.CoverageMain formCOV;
        public static void ShowScen()
        {
            //代开已保存好的场景
            formCOV.setStatus("正在打开场景，请稍后...");
            // 获取默认路径
            String stkHome = CoScheduling.Core.DBUtility.PubConstant.GetFilePath("Scenario");
            String geospatialIntelligencePath = stkHome + @"ExampleScenarios\Example.sc";

            FileDialog dlg = new OpenFileDialog();
            dlg.Title = "Open map";
            dlg.Filter = "STK Scenario Document (*.sc)|*.sc|STK VDF File (*.vdf)|*.vdf|All Files (*.*)|*.*";
            dlg.FileName = geospatialIntelligencePath;
            dlg.InitialDirectory = stkHome + @"Data\ExampleScenarios\";
            dlg.DefaultExt = "*.sc";
            DialogResult dlgRes = dlg.ShowDialog(formCOV);
            //Refresh();

            if (dlgRes == DialogResult.OK)
            {
                m_ScDocument = dlg.FileName;
                //SettingsManager.AddRecentScenario(m_ScDocument);
                formCOV.OpenScenario(m_ScDocument);
                //Coverage.CoverageMain.buttonPosition.Enabled = true;
            }
            formCOV.setStatus("场景已打开，请执行其他操作！");
        }

        public static void OpenScen()
        {
            //关闭界面中的场景
            formCOV.stkRoot.CloseScenario();
            formCOV.buttonPosition.Enabled = false;
        }

        #region 获取卫星轨道
        public static void GainScen()
        {
            
            DateTime start = System.DateTime.Now;
            formCOV.GenerateSatelliteOrbit();
            DateTime end = System.DateTime.Now;
            MessageBox.Show("生成完成！用时" + (end - start).ToString());
            formCOV.setStatus("");
        }
        #endregion
        #endregion
        #region 相关计算公式
        /// <summary>
        /// 根据经纬度计算卫星与地面目标的角度
        /// </summary>
        /// <param name="latS">卫星纬度，弧度</param>
        /// <param name="lonS">卫星经度，弧度</param>
        /// <param name="latT">目标纬度，弧度</param>
        /// <param name="lonT">目标经度，弧度</param>
        /// <param name="satH">卫星高度，千米</param>
        /// <returns></returns>
        public static double getSatelliteTargetAngle(double latS, double lonS, double latT, double lonT, double satH)
        {
            double satelliteAngle;
            double distTS = getDisAB(latS, lonS, latT, lonT);
            double tsCAngle = getBAngle(distTS);
            double disTO = EarthRadio * Math.Sin(tsCAngle);
            double disTS = 2.0 * EarthRadio * Math.Sin(tsCAngle / 2.0);
            double disOS = disTS * Math.Sin(Math.Acos(disTO / disTS));
            satelliteAngle = Math.Atan(disTO / (disOS + satH));
            return satelliteAngle;
        }
        /// <summary>
        /// 根据两物体间的天顶角与方位角计算夹角
        /// </summary>
        /// <param name="azi">ELEVATION</param>
        /// <param name="azim">AZIMUTH</param>
        /// <returns></returns>
        public static double GetYu(double azi, double azim)
        {
            double aa;
            if (azi >= 0)
            {
                aa = 90 - azi;
            }
            else
            {
                azi = -azi;
                aa = 90 - azi;
                aa = -aa;
            }
            if (azim < 180)
                aa = -aa;
            return aa;
        }
        /// <summary>
        /// 获取当前卫星的分辩率－－粗糙值
        /// </summary>
        /// <param name="mingsd">最大分辨率</param>
        /// <param name="range">卫星与目标间距离</param>
        /// <param name="orbh">卫星轨道当前高度</param>
        /// <param name="sle">侧摆角</param>
        /// <returns></returns>static
        public static double GetBestGsd(double mingsd, double range, double orbh, double sle)
        {
            double bestgsd;
            double bg;
            bg = Math.Cos(sle * Math.PI / 180);
            bestgsd = Math.Sqrt(bg);//Convert.ToSingle(sqrt(bg));
            bestgsd = (mingsd * range / (orbh * bestgsd));
            //bestgsd = Math.Round(bestgsd, 2);//Convert.ToSingle(Math.Round(bestgsd, 2));将分辩率取出一定的精度，2为小数点后二位
            return bestgsd;
        }
        /// <summary>
        /// 计算卫星从任务开始到指定时间运行的圈数
        /// </summary>
        /// <param name="satH">卫星高度</param>
        /// <param name="taskid">任务ID</param>
        /// <param name="beginTime">指定时间</param>
        /// <returns></returns>
        public static int ComputerSatelliteCircle(decimal satH, int taskid, DateTime beginTime)
        {
            int circleNumber = 1;
            //根据schemeid找到任务开始时间
            CoScheduling.Core.Model.TASK_LAYOUT_LIST taskLayout = new CoScheduling.Core.Model.TASK_LAYOUT_LIST();
            CoScheduling.Core.DAL.TASK_LAYOUT_LIST dal_taskLayout = new CoScheduling.Core.DAL.TASK_LAYOUT_LIST();
            taskLayout = dal_taskLayout.GetModel(taskid);
            DateTime simBtime = taskLayout.STARTTIME;
            //根据卫星高度计算它的半长轴
            double satelliteSem = (double)satH + EarthRadio;
            //轨道周期粗略估算
            double T = 2 * Math.PI * Math.Pow(satelliteSem, 1.5) / (double)EARTH_GM_SQRT;
            //时间差
            TimeSpan timeLenSP = beginTime - simBtime;
            //将时间差转化为秒
            double timeLen = timeLenSP.TotalSeconds;
            //计算圈数
            circleNumber = (int)Math.Ceiling(timeLen / T);
            return circleNumber;
        }
        /// <summary>
        /// 计算AB两点方位角
        /// </summary>
        /// <param name="latA"></param>
        /// <param name="lonA"></param>
        /// <param name="latB"></param>
        /// <param name="lonB"></param>
        /// <returns></returns>
        public static  double getABBearing(double latA, double lonA, double latB, double lonB)
        {
            double Bearing;
            double x, y, A;
            x = Math.Sin(lonB - lonA) * Math.Cos(latB);
            y = Math.Cos(latA) * Math.Sin(latB) - Math.Sin(latA) * Math.Cos(latB) * Math.Cos(lonB - lonA);
            A = Math.Atan2(x, y);
            A = A * 180.0 / Math.PI + 180.0;
            Bearing = A - 360 * (int)(A / 360);
            return Bearing;
        }
        /// <summary>
        /// 已知卫星高度和夹角，计算地面弧长
        /// </summary>
        /// <param name="sateAngle">夹角</param>
        /// <param name="sateH">高度</param>
        /// <returns></returns>
        public static double getArcDistance(double sateAngle, double sateH)
        {
            double ArcDistance;
            double ifEarthDot = (sateH + EarthRadio) * Math.Sin(sateAngle) / EarthRadio;
            if (ifEarthDot > 1)
            {
                ArcDistance = EarthRadio * Math.Acos(EarthRadio / (EarthRadio + sateH));
            }
            else if (ifEarthDot == 1)
            {
                ArcDistance = EarthRadio * Math.Acos(EarthRadio / (EarthRadio + sateH));
            }
            else
            {
                ArcDistance = EarthRadio * (Math.Asin((EarthRadio + sateH) * Math.Sin(sateAngle) / EarthRadio) - sateAngle);
            }
            return ArcDistance;
        }
        /// <summary>
        /// 纬度格式化
        /// </summary>
        /// <param name="lat"></param>
        /// <returns></returns>
        public static double changetLAT(double lat)
        {
            double cLAT;
            if (lat > 90)
                cLAT = 180 - lat;
            else if (lat < -90)
                cLAT = -180 - lat;
            else
                cLAT = lat;
            return cLAT;
        }

        /// <summary>
        /// 经度格式化
        /// </summary>
        /// <param name="lon"></param>
        /// <returns></returns>
        public static double changetLON(double lon)
        {
            double cLON;
            if (lon > 180)
                cLON = lon - 360;
            else if (lon < -180)
                cLON = lon + 360;
            else
                cLON = lon;
            return cLON;
        }
        /// <summary>
        /// 矫正纬度
        /// </summary>
        /// <param name="latA"></param>
        /// <param name="lonA"></param>
        /// <param name="L"></param>
        /// <param name="Bearing"></param>
        /// <returns></returns>
        public static double getBGFXSiteLat(double latA, double lonA, double L, double Bearing)
        {
            double BGFXSiteLat;
            double xBearing = Bearing * Math.PI / 180.0;
            double c = L / EarthRadio;
            double a = Math.Acos(Math.Cos(Math.PI / 2 - latA) * Math.Cos(c) + Math.Sin(Math.PI / 2 - latA) * Math.Sin(c) * Math.Cos(xBearing));
            double d = Math.Asin(Math.Sin(c) * Math.Sin(xBearing) / Math.Sin(a));
            BGFXSiteLat = (Math.PI / 2 - a) * 180 / Math.PI;
            return BGFXSiteLat;
        }
        /// <summary>
        /// 矫正经度
        /// </summary>
        /// <param name="latA"></param>
        /// <param name="lonA"></param>
        /// <param name="L"></param>
        /// <param name="Bearing"></param>
        /// <returns></returns>
        public static double getBGFXSiteLon(double latA, double lonA, double L, double Bearing)
        {
            double BGFXSiteLon;
            double lonAD = lonA * 180.0 / Math.PI;
            double xBearing = Bearing * Math.PI / 180.0;
            double c = L / EarthRadio;
            double a = Math.Acos(Math.Cos(Math.PI / 2 - latA) * Math.Cos(c) + Math.Sin(Math.PI / 2 - latA) * Math.Sin(c) * Math.Cos(xBearing));
            double d = Math.Asin(Math.Sin(c) * Math.Sin(xBearing) / Math.Sin(a));
            BGFXSiteLon = lonAD + d * 180 / Math.PI;
            return BGFXSiteLon;
        }
        /// <summary>
        /// 计算A,B两点经纬度距离
        /// </summary>
        /// <param name="latA">A点纬度，弧度</param>
        /// <param name="lonA">A点经度，弧度<A/param>
        /// <param name="latB">B点纬度，弧度</param>
        /// <param name="lonB">B点经度，弧度</param>
        /// <returns>double型距离</returns>
        public static double getDisAB(double latA, double lonA, double latB, double lonB)
        {
            double distanceAB;
            distanceAB = EarthRadio * Math.Acos(Math.Cos(latA) * Math.Cos(latB) * Math.Cos(lonB - lonA) + Math.Sin(latA) * Math.Sin(latB));
            return distanceAB;
        }
        /// <summary>
        /// 计算球面长度对应的弧度值
        /// </summary>
        /// <param name="distanceAB">球面距离，千米</param>
        /// <returns>double弧度值</returns>
        public static double getBAngle(double distanceAB)
        {
            double bAngle;
            bAngle = distanceAB / EarthRadio;
            return bAngle;
        }
        #endregion/

    }
}
