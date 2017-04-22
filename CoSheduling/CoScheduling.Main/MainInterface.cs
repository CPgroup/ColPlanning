using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Linq;
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
using ESRI.ArcGIS.NetworkAnalysis;
using ESRI.ArcGIS.NetworkAnalyst;
using ESRI.ArcGIS.AnalysisTools;
using CP.WinFormsUI;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;

namespace CoScheduling.Main
{
    /// <summary>
    /// 类名：主程序接口
    /// 作者：李光强
    /// 时间：2014.3.9.
    /// 版本：1.0
    /// </summary>
    /// <remarks>与框架接口对接，接受框架接口函数调用，打开系统内功能模块</remarks>
    public static class MainInterface
    {

        public static TreeNode SelectedNodeDisa;     //灾区目录的选中结点
        public static TreeNode SelectedNodeSat;       //卫星观测结果目录的选中结点
        public static int CurrentDisaAreaID = -1;      //当前显示的灾区ID ,默认为最近一个灾区的ID
        public static int isFinishPlan = 0;          //是否完成任务规划，1--完成；0--未完成
        public static int isGatherPointChanged = 0;  //是否重新生成集结点，1--是；0--否
        public static bool IsDisaModified = false;//灾区信息是否被修改
        /// <summary>
        /// DEM图层
        /// </summary>
        public static IRasterLayer DEMRasterLayer;
        /// <summary>
        /// 居民地图层
        /// </summary>
        public static IFeatureLayer ResidentLayer;
        /// <summary>
        /// 道路图层
        /// </summary>
        public static IFeatureLayer RoadLayer;
        /// <summary>
        /// 水系图层
        /// </summary>
        public static IFeatureLayer HydroLayer;

        #region 公共函数部分
        /// <summary>
        /// 获取主窗口中的控件
        /// </summary>
        /// <param name="pLabel">提示框</param>
        /// <param name="pProgress">进度条</param>
        /// <param name="pPanel">浮动面板</param>
        /// <param name="pPictureBox">主窗口中的图片</param>
        /// <param name="pForm">主窗口</param>
        /// <param name="pStatus">主窗口状态栏</param>
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
            Program.ShowMapControl();                            //加载地图控件   
            //Program.ShowCoverage();
            //Program.ShowFormUAVList();                           //加载无人机列表
            //Program.ShowFormDisaList();                          //加载灾区列表
            if (Program.gSplashForm != null)
                if (!Program.gSplashForm.IsDisposed)
                    Program.gSplashForm.Dispose();
            System.Diagnostics.Debug.WriteLine("Load ok!");
            Program.gStatusLabel.Text = "就绪.";
        }

        /// <summary>
        /// 清空指定的文件夹，但不删除文件夹
        /// </summary>
        /// <param name="dir"></param>
        public static void DeleteFolder(string dir)
        {
            foreach (string d in Directory.GetFileSystemEntries(dir))
            {
                if (File.Exists(d))
                {
                    FileInfo fi = new FileInfo(d);
                    if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
                        fi.Attributes = FileAttributes.Normal;
                    File.Delete(d);//直接删除其中的文件  
                }
                else
                {
                    DirectoryInfo d1 = new DirectoryInfo(d);
                    if (d1.GetFiles().Length != 0)
                    {
                        DeleteFolder(d1.FullName);////递归删除子文件夹
                    }
                    Directory.Delete(d);
                }
            }
        }        /// <summary>
        /// 删除文件夹及其内容
        /// </summary>
        /// <param name="dir"></param>
        public static void DeleteFolder1(string dir)
        {
            foreach (string d in Directory.GetFileSystemEntries(dir))
            {
                if (File.Exists(d))
                {
                    FileInfo fi = new FileInfo(d);
                    if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
                        fi.Attributes = FileAttributes.Normal;
                    File.Delete(d);//直接删除其中的文件  
                }
                else
                    DeleteFolder(d);////递归删除子文件夹
                Directory.Delete(d);
            }
        }

        /// <summary>
        /// 根据图层名获取图层
        /// </summary>
        /// <param name="IN_Name"></param>
        /// <returns></returns>
        private static ILayer PRV_GetLayersByName(string IN_Name)
        {
            IEnumLayer Temp_AllLayer = Program.myMap.Map.Layers;
            ILayer Each_Layer = Temp_AllLayer.Next();
            while (Each_Layer != null)
            {
                if (Each_Layer.Name.Contains(IN_Name))
                    return Each_Layer;
                Each_Layer = Temp_AllLayer.Next();
            }
            return null;
        }

        /// <summary>
        /// 根据图层名获取图层序号
        /// </summary>
        /// <param name="IN_LayerName"></param>
        /// <returns></returns>
        private static int PRV_GetIndexOfLayer(string IN_LayerName)
        {
            for (int i = 0; i < Program.myMap.LayerCount; i++)
            {
                if (Program.myMap.get_Layer(i).Name == IN_LayerName)
                    return i;
            }
            return -1;
        }
        #endregion

        #region 观测资源管理

        #region 无人机管理

        /// <summary>
        /// 无人机列表
        /// </summary>
        public static void UAVlist()
        {
            //事件函数
        }


        #endregion
        #endregion

        public static void TaskManage()
        {
            TaskRequirement.TaskRequirementManage newform = new TaskRequirement.TaskRequirementManage();
            newform.StartPosition = FormStartPosition.CenterScreen;
            newform.Show();
        }

        public static void TaskQuery()
        {
            TaskRequirement.TaskQuery newform = new TaskRequirement.TaskQuery();
            newform.StartPosition = FormStartPosition.CenterScreen;
            newform.Show();
        }

        public static void TaskGenerate()
        {
            TaskRequirement.TaskGenerate newform = new TaskRequirement.TaskGenerate();
            newform.StartPosition = FormStartPosition.CenterScreen;
            newform.Show();
        }
        public static void TaskResMatch()
        {
            TaskRequirement.TaskResMatch newform = new TaskRequirement.TaskResMatch();
            newform.StartPosition = FormStartPosition.CenterScreen;
            newform.Show();
        }
        public static void UAVManage()
        {
            TaskRequirement.UAVManage newform = new TaskRequirement.UAVManage();
            newform.StartPosition = FormStartPosition.CenterScreen;
            newform.Show();
        }
        public static void UAVQuery()
        {
            UAV.UAVQuery newform = new UAV.UAVQuery();
            newform.StartPosition = FormStartPosition.CenterScreen;
            newform.Show();
        }
        public static void Sensor1Query()
        {
            UAV.Sensor1Query newform = new UAV.Sensor1Query();
            newform.StartPosition = FormStartPosition.CenterScreen;
            newform.Show();
        }
        public static void BandQuery()
        {
            UAV.BandQuery newform = new UAV.BandQuery();
            newform.StartPosition = FormStartPosition.CenterScreen;
            newform.Show();
        }


        public static void SatelliteManage()
        {
            Satellite.SatelliteManage newform = new Satellite.SatelliteManage();
            newform.StartPosition = FormStartPosition.CenterScreen;
            newform.Show();
        }

        public static void SatQuery()
        {
            Satellite.SatelliteQuery newform = new Satellite.SatelliteQuery();
            newform.StartPosition = FormStartPosition.CenterScreen;
            newform.Show();
        }

        
        public static void AEROSHIPManage()
        {
            AEROSHIP.AEROSHIPManage newform = new AEROSHIP.AEROSHIPManage();
            newform.StartPosition = FormStartPosition.CenterScreen;
            newform.Show();
        }
       
        public static void AEROSHIPQuery()
        {
            AEROSHIP.AEROSHIPQuery newform = new AEROSHIP.AEROSHIPQuery();
            newform.StartPosition = FormStartPosition.CenterScreen;
            newform.Show();
        }
       
        public static void ILLUSTRATEDCARManage()
        {
            ILLUSTRATEDCAR.ILLUSTRATEDCARManage newform = new ILLUSTRATEDCAR.ILLUSTRATEDCARManage();
            newform.StartPosition = FormStartPosition.CenterScreen;
            newform.Show();
        }
     
        public static void ILLUSTRATEDCARQuery()
        {
            ILLUSTRATEDCAR.ILLUSTRATEDCARQuery newform = new ILLUSTRATEDCAR.ILLUSTRATEDCARQuery();
            newform.StartPosition = FormStartPosition.CenterScreen;
            newform.Show();
        }

        public static void SPYCAMManage()
        {
            SPYCAM_RANGE.SPYCAMManage newform = new SPYCAM_RANGE.SPYCAMManage();
            newform.StartPosition = FormStartPosition.CenterScreen;
            newform.Show();
        }
       
        //public static void SPYCAMQuery()
        //{
        //    SPYCAM_RANGE.SPYCAMQuery newform = new SPYCAM_RANGE.SPYCAMQuery();
        //    newform.StartPosition = FormStartPosition.CenterScreen;
        //    newform.Show();
        //}
        public static void SPYCAMQuery()
        {
            SPYCAM_RANGE.SPYCAMQuery newform = new SPYCAM_RANGE.SPYCAMQuery();
            newform.StartPosition = FormStartPosition.CenterScreen;
            newform.Show();
        }
        public static void HUMDETManage()
        {
            HUMANDETECTION.HUMANDETECTIONManage newform = new HUMANDETECTION.HUMANDETECTIONManage();
            newform.StartPosition = FormStartPosition.CenterScreen;
            newform.Show();
        }

        public static void HUMDETQuery()
        {
            HUMANDETECTION.HUMDETQuery newform = new HUMANDETECTION.HUMDETQuery();
            newform.StartPosition = FormStartPosition.CenterScreen;
            newform.Show();
        }
        #region 任务规划调度

        #region 任务规划

        #region 面向多任务多平台的区域目标分解方法
        /// <summary>
        /// 任务分解 子任务生成
        /// 输入为卫星、无人机、飞艇、车的图层序号
        /// </summary>
        public static void taskDis(int satLayNO, int satAttribute, int UAVLayNO, int ASLayNO, int CarLayNO, int PolygonTaskNO)
        {
            #region 调用matlab
            //MLApp.MLApp matlab = null;
            //Type matlabAppType = System.Type.GetTypeFromProgID("Matlab.Application");
            //matlab = System.Activator.CreateInstance(matlabAppType) as MLApp.MLApp;
            ////VSAllocation.Class1 PlanAll = new Class1();

            //string path_project = System.AppDomain.CurrentDomain.BaseDirectory;   //工程文件的路径，如bin  
            //string path_matlab = "cd('" + path_project + "')";     //自定义matlab工作路径    
            //matlab.Execute(path_matlab);
            //matlab.Execute("clear all");//<span style="color:#ff6666;">//这条语句也很重要，先注释掉，下面讲解</span> 
            ////MWNumericArray ReturnMadt = new MWNumericArray(MWArrayComplexity.Real, 1, 1);//收益矩阵 行：资源  列：元任务 
            #endregion



            string tStart = "0700";//开始观测时间 格式4位数 前两位小时 后两位分钟
            double fi;//收益参数
            double fi2;
            double tR = 0.3;//控制资源负载度
            double alpha = 0.5;//收益参数 阿尔法
            double beta = 1 - alpha;//贝塔
            //int satNo=2;//卫星个数
            int SThour;//开始观测时间 小时
            int STmin;//开始观测时间 分钟
            if (tStart.Length > 3)
            {
                SThour = int.Parse(tStart.Substring(0, 2));//开始观测时间 小时        
            }
            else
            {
                SThour = int.Parse(tStart.Substring(0, 1));//开始观测时间 小时
            }
            STmin = int.Parse(tStart.Substring(tStart.Length - 2, 2));//开始观测时间 分钟
            //double conRadixi = 0.7;//半径折损系数 与数据属性表中半径属性一致
            IMapLayers mapLayers = Program.myMap.Map as IMapLayers;//IFeatureLayer pFeatureLayer;
            ILayer layer;
            ILayer ASlayer;//飞艇图层
            IList<R_TInfo> RTinfoList = new List<R_TInfo>();//存储每一个无人机和任务id初步筛选匹配结果
            DeleteFolder(System.AppDomain.CurrentDomain.BaseDirectory + "Data\\cache");//删除cache下所有文件  
            //卫星 无人机 飞艇 测量车覆盖面路径（缓冲区路径）
            layer = mapLayers.get_Layer(UAVLayNO);
            ASlayer = mapLayers.get_Layer(ASLayNO);
            ILayer CarLayer = mapLayers.get_Layer(CarLayNO);
            IFeatureLayer CarFeatureLayer = CarLayer as IFeatureLayer;
            IFeatureLayer ASfeatureLayer = ASlayer as IFeatureLayer;
            ILayer satLayer = mapLayers.get_Layer(satLayNO);//SatElementTask 图层
            IFeatureLayer SatFeLayer = satLayer as IFeatureLayer;
            ILayer satAtributeLayer = mapLayers.get_Layer(satAttribute);//主要使用卫星的各种属性 后期可从sql数据库中获取 SateliteLine图层
            IFeatureLayer ptaskFeatureLayer = (IFeatureLayer)mapLayers.get_Layer(PolygonTaskNO);
            IFeatureLayer UAVFeatureLayer = (IFeatureLayer)layer;//无人机图层
            //ILayer CarToTaskLineLayer = mapLayers.get_Layer(CarToTaskLineNo);
            //----------------------------------------------------调用本文分解方法----------------------------------------------------------------------------------------------------
            IFeatureLayer subTaskLayer;//最终元任务图层 subTaskLayer 元任务集
            List<RTsubTInfo> lstTaskFC;////输出元任务对应关系
            List<RTFeatureInfo> lstFC;//资源相对任务的观测区域 子任务
            List<R_TInfo> SattoTaskFIDlist;//sat相对于任务的FID 以便为条带命名 卫星资源FID  源任务FID 子任务FID
            ElementTask(Program.myMap.Map, layer, UAVFeatureLayer, CarFeatureLayer, mapLayers, ptaskFeatureLayer, RTinfoList, SThour, STmin, tStart, ASfeatureLayer, SatFeLayer, out  subTaskLayer, out lstTaskFC, out lstFC, out SattoTaskFIDlist);



            // OpenShape(UavToTasdfkUnionPath);//如果在图层上显示 PolygonTaskNO等图层NO要+1 //////////////////////////////////////////////////////////////////////////////////////////
            Program.myMap.Refresh();
            //地图缩放到阿克苏地区
            ILayer akesulayer = PRV_GetLayersByName("BaiCity");
            IFeatureLayer ss = akesulayer as FeatureLayer;
            IFeature Akesu = ss.FeatureClass.GetFeature(0) as IFeature;
            Program.myMap.Extent = Akesu.Shape.Envelope;// Program.myMap.FullExtent;
            Program.myMap.Refresh();
            Program.myMap.Update();


            #region 冲突判断

            //冲突判断部分开始--------------------------------------(冲突判断开始)------------------------------------------
            //IQueryFilter UAVQueryFilter = new QueryFilter();//IQueryFilter还可以用来选择要素 select search 方法
            //UAVQueryFilter.WhereClause = "FID >= 0";//和null效果是一样的 全选 
            //int UAVcount = UAVFeatureLayer.FeatureClass.FeatureCount(UAVQueryFilter);
            //查询UAV的个数

            #region 确定每个元任务的观测时长
            //根据subt与资源观测任务的面积比值确定时间  小时
            for (int i = 0; i < lstTaskFC.Count; i++)
            {
                List<int> uavFid = lstTaskFC[i].UAVFID;//观测此元任务的无人机列表
                List<double> UavTime = new List<double>(new double[uavFid.Count]);//无人机观测时长                
                for (int k = 0; k < uavFid.Count; k++)
                {
                    for (int j = 0; j < lstFC.Count; j++)
                    {
                        if (uavFid[k].ToString() == lstFC[j].UAVFID && lstTaskFC[i].TFID.ToString() == lstFC[j].TFID)
                        {
                            UavTime[k] = lstFC[j].RtoTtime * (lstTaskFC[i].subTArea / lstFC[j].areaT); //获取元任务的观测时间
                        }

                    }
                }

                List<int> asFid = lstTaskFC[i].ASFID;//观测此元任务的AS列表
                List<double> ASTime = new List<double>(new double[asFid.Count]);//AS观测时长                
                for (int k = 0; k < asFid.Count; k++)
                {
                    for (int j = 0; j < lstFC.Count; j++)
                    {
                        if (asFid[k].ToString() == lstFC[j].ASFID && lstTaskFC[i].TFID.ToString() == lstFC[j].TFID)
                        {
                            ASTime[k] = lstFC[j].RtoTtime * (lstTaskFC[i].subTArea / lstFC[j].areaT); //获取元任务的观测时间
                        }

                    }
                }

                List<int> CarFid = lstTaskFC[i].CarFID;//观测此元任务的Car列表
                List<double> CarTime = new List<double>(new double[CarFid.Count]);//Car观测时长                
                for (int k = 0; k < CarFid.Count; k++)
                {
                    for (int j = 0; j < lstFC.Count; j++)
                    {
                        if (CarFid[k].ToString() == lstFC[j].CarFID && lstTaskFC[i].TFID.ToString() == lstFC[j].TFID)
                        {
                            CarTime[k] = lstFC[j].RtoTtime * (lstTaskFC[i].subTArea / lstFC[j].areaT); //获取元任务的观测时间
                        }

                    }
                }

                lstTaskFC[i].UAVTime = UavTime;
                lstTaskFC[i].ASTime = ASTime;
                lstTaskFC[i].CarTime = CarTime;
            }
            #endregion

            #region UAV冲突判断
            //UAV冲突判断开始--------------------------------------(uav冲突判断开始)------------------------------------------
            List<RT_FID> UavRTFIDlist = new List<RT_FID>();//无人机FID 及此无人机能够观测的元任务集FIDlist ,以及元任务发生冲突的list★★★★★★★★★★★★★★★★ 资源FID：int，元任务FID：list<int>,元任务个数：int
            int UAVcount = UAVFeatureLayer.FeatureClass.FeatureCount(null);//无人机个数 null就是全选
            for (int i = 0; i < UAVcount; i++)//资源FID
            {
                List<int> subFIdlist = new List<int>();//存储每个资源能够观测的元任务fid列表
                for (int j = 0; j < lstTaskFC.Count; j++)//元任务FID
                {
                    List<int> uavFIDList = lstTaskFC[j].UAVFID;
                    for (int k = 0; k < uavFIDList.Count; k++)//遍历每个元任务下的观测资源（能够观测到此元任务的资源）
                    {
                        if (i == uavFIDList[k])
                        {
                            subFIdlist.Add(j);
                            break;
                        }
                    }
                }

                List<ConflictTFID> conFIdlist = new List<ConflictTFID>();//存储每个资源能够观测的元任务中发生冲突的元任务ID列表list<(int,int)>
                List<StartTime> EleTStimeList = new List<StartTime>();//存储每个资源观测的元任务的开始观测时间
                if (subFIdlist.Count > 1)//当前观测资源能够观测到的元任务不为空且大于1，满足两两冲突的基本条件
                {
                    //无人机冲突判断 UAV假设全部观测完一个任务后再观测其他任务  因此冲突判断条件为：任务i开始时间+任务i执行时间+任务u执行时间大于任务u结束时间
                    for (int j = 0; j < subFIdlist.Count - 1; j++)
                    {
                        int firstSTH = 0;//第一个任务的开始观测时间
                        int firstSTM = 0;
                        int lastSTH = 0;
                        int lastSTM = 0;
                        for (int k = j + 1; k < subFIdlist.Count; k++)
                        {
                            //IFeature firstSubFeature = subTaskLayer.FeatureClass.GetFeature(subFIdlist[j]);//获取第一个冲突元任务要素
                            //IFeature secondSubFeature = subTaskLayer.FeatureClass.GetFeature(subFIdlist[k]);//获取第一个冲突元任务要素
                            //根据元任务fid获取其时间窗口  （获取源任务再得到时间）
                            int fisttTFID = 0;//源任务FID
                            int secondTFID = 0;
                            double firstsubTarea = 0;//元任务面积
                            double secondsubTarea = 0;
                            int firstThour;//任务结束时间 小时   
                            int firstTmin;
                            int secondThour;//任务结束时间 小时   
                            int secondTmin;
                            double firstsubTtime = 0;//第一个冲突元任务的观测持续时间
                            double secondsubTtime = 0;//第一个冲突元任务的观测持续时间
                            for (int ti = 0; ti < lstTaskFC.Count; ti++)
                            {
                                if (lstTaskFC[ti].subTFID == subFIdlist[j].ToString())
                                {
                                    fisttTFID = int.Parse(lstTaskFC[ti].TFID);
                                    firstsubTarea = lstTaskFC[ti].subTArea;
                                }
                                if (lstTaskFC[ti].subTFID == subFIdlist[k].ToString())
                                {
                                    secondTFID = int.Parse(lstTaskFC[ti].TFID);
                                    secondsubTarea = lstTaskFC[ti].subTArea;
                                }
                                if (firstsubTarea != 0 && secondsubTarea != 0)
                                {
                                    break;
                                }
                            }
                            IFeature firstTFeature = ptaskFeatureLayer.FeatureClass.GetFeature(fisttTFID);//获取第一个冲突元任务所属源任务要素 为了获取时间窗口
                            IFeature secondTFeature = ptaskFeatureLayer.FeatureClass.GetFeature(secondTFID);//获取第二个冲突元任务所属源任务要素
                            string firstTe = firstTFeature.get_Value(5).ToString();//结束时间
                            string seconTe = secondTFeature.get_Value(5).ToString();
                            string firstTs = firstTFeature.get_Value(4).ToString();//开始时间
                            string seconTs = secondTFeature.get_Value(4).ToString();
                            //时间确定 
                            #region 时间确定
                            if (firstTe.Length > 3)
                            {
                                firstThour = int.Parse(firstTe.Substring(0, 2));//任务结束时间 小时                 
                            }
                            else
                            {
                                firstThour = int.Parse(firstTe.Substring(0, 1));//任务结束时间 小时
                            }
                            firstTmin = int.Parse(firstTe.Substring(firstTe.Length - 2, 2));//任务结束时间 分钟 

                            if (seconTe.Length > 3)
                            {
                                secondThour = int.Parse(seconTe.Substring(0, 2));//任务结束时间 小时                 
                            }
                            else
                            {
                                secondThour = int.Parse(seconTe.Substring(0, 1));//任务结束时间 小时
                            }
                            secondTmin = int.Parse(seconTe.Substring(seconTe.Length - 2, 2));//任务结束时间 分钟 
                            //两个任务的开始观测时间

                            string EleTToPointPath = System.AppDomain.CurrentDomain.BaseDirectory + "Data\\cache\\" + "EleToPo.shp";//将当前元任务转成点目标，为了求无人机基站到质心距离  
                            string singleEleT = System.AppDomain.CurrentDomain.BaseDirectory + "Data\\cache\\" + "SinEle.shp";
                            GPselectTool(subTaskLayer, singleEleT, "FID=", subFIdlist[j]);//选出单个元任务 当前
                            IFeatureLayer firstEleTFL = OpenFile_LayerFile(singleEleT);//单个元任务 第一个
                            GPFeatureToPointTool(firstEleTFL, EleTToPointPath);
                            IFeatureLayer PointFeatureLayer = OpenFile_LayerFile(EleTToPointPath);//将当前元任务转成点目标
                            IPoint pointfe = PointFeatureLayer.FeatureClass.GetFeature(0).Shape as IPoint;//将当前无人机最大缓冲区半径内能够观测的任务区域转成的点目标
                            IPoint UavPoint = UAVFeatureLayer.FeatureClass.GetFeature(i).Shape as IPoint;//将当前无人机转成的点目标
                            double UACd = Math.Sqrt(Math.Pow(pointfe.X - UavPoint.X, 2) + Math.Pow(pointfe.Y - UavPoint.Y, 2));//无人机基地到无人机最大缓冲区半径内能够观测的任务区域的质心距离 米
                            double UavV = double.Parse(UAVFeatureLayer.FeatureClass.GetFeature(i).get_Value(5).ToString());
                            if (firstTs.Length > 3)
                            {
                                firstSTH = int.Parse(firstTs.Substring(0, 2));//任务开始时间 小时                 
                            }
                            else
                            {
                                firstSTH = int.Parse(firstTs.Substring(0, 1));//任务开始时间 小时
                            }
                            firstSTM = int.Parse(firstTs.Substring(firstTs.Length - 2, 2));//任务开始时间 分钟 
                            if ((firstSTH * 60 + firstSTM) > (SThour * 60 + STmin))//开始时间取  较大值
                            {
                                double st = firstSTH + (double)firstSTM / 60 - (UACd / 1000 / UavV);
                                firstSTH = (int)Math.Floor(st);
                                firstSTM = (int)((double)(st - firstSTH) * 60);
                                if (st < (SThour + (double)STmin / 60))
                                {
                                    firstSTH = SThour;
                                    firstSTM = STmin;
                                }
                            }
                            else
                            {
                                firstSTH = SThour;
                                firstSTM = STmin;
                            }
                            int secondSTH;
                            int secondSTM;
                            GPselectTool(subTaskLayer, singleEleT, "FID=", subFIdlist[k]);//选出单个元任务 当前
                            IFeatureLayer secondEleTFL = OpenFile_LayerFile(singleEleT);//单个元任务 第一个
                            GPFeatureToPointTool(secondEleTFL, EleTToPointPath);
                            IFeatureLayer secondPointFeatureLayer = OpenFile_LayerFile(EleTToPointPath);//将当前元任务转成点目标
                            IPoint SecondPointfe = secondPointFeatureLayer.FeatureClass.GetFeature(0).Shape as IPoint;//将
                            double secondUACd = Math.Sqrt(Math.Pow(SecondPointfe.X - UavPoint.X, 2) + Math.Pow(SecondPointfe.Y - UavPoint.Y, 2));
                            if (seconTs.Length > 3)
                            {
                                secondSTH = int.Parse(seconTs.Substring(0, 2));//任务开始时间 小时                 
                            }
                            else
                            {
                                secondSTH = int.Parse(seconTs.Substring(0, 1));//任务开始时间 小时
                            }
                            secondSTM = int.Parse(seconTs.Substring(seconTs.Length - 2, 2));//任务开始时间 分钟 
                            if ((secondSTH * 60 + secondSTM) > (SThour * 60 + STmin))//开始时间取  较大值
                            {
                                double st = secondSTH + (double)secondSTM / 60 - (secondUACd / 1000 / UavV);
                                secondSTH = (int)Math.Floor(st);
                                secondSTM = (int)((double)(st - secondSTH) * 60);
                                if (st < (SThour + (double)STmin / 60))
                                {
                                    secondSTH = SThour;
                                    secondSTM = STmin;
                                }
                            }
                            else
                            {
                                secondSTH = SThour;
                                secondSTM = STmin;
                            }

                            #endregion

                            //根据subt与资源观测任务的面积比值确定元任务持续观测时间
                            for (int Uavi = 0; Uavi < lstFC.Count; Uavi++)
                            {
                                if (lstFC[Uavi].UAVFID == i.ToString() && lstFC[Uavi].TFID == fisttTFID.ToString()) //如果资源和源任务都匹配 那么元任务属于此子任务
                                {
                                    firstsubTtime = firstsubTarea / lstFC[Uavi].areaT * lstFC[Uavi].RtoTtime;  //任务持续时间 小时 
                                }

                                if (lstFC[Uavi].UAVFID == i.ToString() && lstFC[Uavi].TFID == secondTFID.ToString()) //如果资源和源任务都匹配 那么元任务属于此子任务
                                {
                                    secondsubTtime = secondsubTarea / lstFC[Uavi].areaT * lstFC[Uavi].RtoTtime;  //任务持续时间 小时
                                }
                                if (firstsubTtime != 0 && secondsubTtime != 0)
                                {
                                    break;
                                }
                            }

                            //判断任务先后顺序  冲突判断
                            bool firstP = (firstSTH + (double)firstSTM / 60 + firstsubTtime + secondsubTtime) > (secondThour + (double)secondTmin / 60);
                            bool secondP = (secondSTH + (double)secondSTM / 60 + firstsubTtime + secondsubTtime) > (firstThour + (double)firstTmin / 60);
                            if (firstP && secondP)
                            {
                                ConflictTFID conflictFidInfo = new ConflictTFID() { firstTFID = subFIdlist[j], secondTFID = subFIdlist[k] };
                                conFIdlist.Add(conflictFidInfo);
                            }



                            lastSTH = secondSTH;
                            lastSTM = secondSTM;

                            //if ((firstThour * 60 + firstTmin) < (secondThour * 60 + secondTmin))//第二个任务后执行  SThour;//开始观测时间 小时 STmin;//开始观测时间 分钟
                            //{

                            //    if ((firstSTH + (double)firstSTM / 60 + firstsubTtime + secondsubTtime) > (secondThour + (double)secondTmin / 60)) //无人机判断冲突  任务开始时间是：（开始观测时间）和（任务窗口开始时间）的最大值-----------？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？---------从lsttaskfc可获得----
                            //    {
                            //        ConflictTFID conflictFidInfo = new ConflictTFID() { firstTFID = subFIdlist[j], secondTFID = subFIdlist[k] };
                            //        conFIdlist.Add(conflictFidInfo);
                            //    }

                            //}
                            //else
                            //{
                            //    if ((SThour + (double)STmin / 60 + firstsubTtime + secondsubTtime) > (firstThour + (double)firstTmin / 60)) //无人机判断冲突  
                            //    {
                            //        ConflictTFID conflictFidInfo = new ConflictTFID() { firstTFID = subFIdlist[j], secondTFID = subFIdlist[k] };
                            //        conFIdlist.Add(conflictFidInfo);
                            //    }
                            //}

                        }//第二个任务 k

                        StartTime EleTstartT = new StartTime() { Hour = firstSTH, Min = firstSTM };
                        EleTStimeList.Add(EleTstartT);

                        if (j == subFIdlist.Count - 2)
                        {
                            StartTime EleTstartTs = new StartTime() { Hour = lastSTH, Min = lastSTM };
                            EleTStimeList.Add(EleTstartTs);
                        }
                    }//第一个任务 j

                }//(subFIdlist.Count > 1) 当前资源观测的元任务个数大于1

                RT_FID rtFidInfo = new RT_FID() { RFID = i, subTaskFID = subFIdlist, ConflictTaskFID = conFIdlist, taskCount = subFIdlist.Count, EleTstartTime = EleTStimeList };
                UavRTFIDlist.Add(rtFidInfo);
            }//无人机资源结束 
            //UAV冲突判断结束--------------------------------------(uav冲突判断结束)------------------------------------------ 
            #endregion

            IFeatureLayer satAtributeFL = satAtributeLayer as IFeatureLayer; //SateliteLine
            //卫星冲突判断
            List<RT_FID> satRTFIDlist;//卫星FID 及此卫星能够观测的子任务集FIDlist ,以及元任务发生冲突的list
            SatConflic(satAtributeLayer, satAtributeFL, SattoTaskFIDlist, SatFeLayer, out satRTFIDlist);//卫星冲突判断

            #region 飞艇冲突判断
            //飞艇冲突判断开始--------------------------------------(AS冲突判断开始)------------------------------------------
            List<RT_FID> ASRTFIDlist = new List<RT_FID>();//飞艇FID 及此飞艇能够观测的元任务集FIDlist ,以及元任务发生冲突的list★★★★★★★★★★★★★★★★ 资源FID：int，元任务FID：list<int>,元任务个数：int
            int AScount = ASfeatureLayer.FeatureClass.FeatureCount(null);//飞艇个数 null就是全选
            #region 将sub任务转为点目标
            string ConflictTPOint = System.AppDomain.CurrentDomain.BaseDirectory + "Data\\cache\\" + "subTDis.shp";
            GPFeatureToPointTool(subTaskLayer, ConflictTPOint); //将元任务转为点目标 以便求距离
            IFeatureLayer ASConflictTPointFL = OpenFile_LayerFile(ConflictTPOint);
            #endregion
            for (int i = 0; i < AScount; i++)//资源FID
            {
                List<int> subFIdlist = new List<int>();//存储每个资源能够观测的元任务fid列表
                for (int j = 0; j < lstTaskFC.Count; j++)//元任务FID
                {
                    List<int> ASFIDList = lstTaskFC[j].ASFID;
                    for (int k = 0; k < ASFIDList.Count; k++)//遍历每个元任务下的观测资源（能够观测到此元任务的资源）
                    {
                        if (i == ASFIDList[k])
                        {
                            subFIdlist.Add(j);
                            break;
                        }
                    }
                }
                IFeature ASFea = ASfeatureLayer.FeatureClass.GetFeature(i);//当前飞艇（获取属性）
                double Vas = double.Parse(ASFea.get_Value(5).ToString()); //飞艇速度 km/h
                List<ConflictTFID> ASconFIdlist = new List<ConflictTFID>();//存储每个资源能够观测的元任务中发生冲突的元任务ID列表list<(int,int)>
                List<StartTime> EleTStimeList = new List<StartTime>();//存储开始观测时间
                if (subFIdlist.Count > 1)//当前观测资源能够观测到的元任务不为空且大于1，满足两两冲突的基本条件
                {
                    //飞艇冲突判断 AS假设全部观测完一个任务后再观测其他任务  因此冲突判断条件为：开始时间+执行任务两个任务的时间+航行到两个地点飞行时间 大于 第二个任务结束时间 则冲突
                    for (int j = 0; j < subFIdlist.Count - 1; j++)
                    {
                        int firstASSTH = 0;
                        int firstASSTM = 0;//第一个任务的开始观测时间

                        int lastSTH = 0;
                        int lastSTM = 0;
                        for (int k = j + 1; k < subFIdlist.Count; k++)
                        {
                            //IFeatureLayer firstSubFL = subTaskLayer.FeatureClass.  //.GetFeature(subFIdlist[j]);//获取第一个冲突元任务要素 获取两者间距离 米
                            //IFeature secondSubFeature = subTaskLayer.FeatureClass.GetFeature(subFIdlist[k]);//获取第一个冲突元任务要素
                            double TaskDis;//冲突任务之间距离 米
                            #region 两个冲突任务间距离 米

                            IPoint firstPoint = ASConflictTPointFL.FeatureClass.GetFeature(subFIdlist[j]).Shape as IPoint;//获取第一个冲突元任务要素（点目标）
                            IPoint secondPoint = ASConflictTPointFL.FeatureClass.GetFeature(subFIdlist[k]).Shape as IPoint;//将当前subT转成的点目标
                            TaskDis = Math.Sqrt(Math.Pow(firstPoint.X - secondPoint.X, 2) + Math.Pow(firstPoint.Y - secondPoint.Y, 2));//两冲突任务的质心距离 米 
                            #endregion

                            //根据元任务fid获取其时间窗口  （获取源任务再得到时间）
                            int fisttTFID = 0;//源任务FID
                            int secondTFID = 0;
                            double firstsubTarea = 0;//元任务面积
                            double secondsubTarea = 0;
                            int firstThour;//结束时间
                            int firstTmin;
                            int secondThour;
                            int secondTmin;
                            double firstsubTtime = 0;//第一个冲突元任务的观测持续时间
                            double secondsubTtime = 0;//第一个冲突元任务的观测持续时间
                            double AStofirstTDis;//AS到第一个任务的距离
                            double AStosecondTDis;//AS到第二个任务的距离
                            for (int ti = 0; ti < lstTaskFC.Count; ti++)
                            {
                                if (lstTaskFC[ti].subTFID == subFIdlist[j].ToString())//元任务FID匹配
                                {
                                    fisttTFID = int.Parse(lstTaskFC[ti].TFID);
                                    firstsubTarea = lstTaskFC[ti].subTArea;
                                }
                                if (lstTaskFC[ti].subTFID == subFIdlist[k].ToString())
                                {
                                    secondTFID = int.Parse(lstTaskFC[ti].TFID);
                                    secondsubTarea = lstTaskFC[ti].subTArea;
                                }
                                if (firstsubTarea != 0 && secondsubTarea != 0)
                                {
                                    break;
                                }
                            }
                            IFeature firstTFeature = ptaskFeatureLayer.FeatureClass.GetFeature(fisttTFID);//获取第一个冲突元任务所属源任务要素 为了获取时间窗口
                            IFeature secondTFeature = ptaskFeatureLayer.FeatureClass.GetFeature(secondTFID);//获取第二个冲突元任务所属源任务要素
                            string firstTe = firstTFeature.get_Value(5).ToString();//结束时间
                            string seconTe = secondTFeature.get_Value(5).ToString();
                            string firstTs = firstTFeature.get_Value(4).ToString();//开始时间
                            string seconTs = secondTFeature.get_Value(4).ToString();

                            #region 时间确定
                            //时间确定 
                            if (firstTe.Length > 3)
                            {
                                firstThour = int.Parse(firstTe.Substring(0, 2));//任务结束时间 小时                 
                            }
                            else
                            {
                                firstThour = int.Parse(firstTe.Substring(0, 1));//任务结束时间 小时
                            }
                            firstTmin = int.Parse(firstTe.Substring(firstTe.Length - 2, 2));//任务结束时间 分钟 

                            if (seconTe.Length > 3)
                            {
                                secondThour = int.Parse(seconTe.Substring(0, 2));//任务结束时间 小时                 
                            }
                            else
                            {
                                secondThour = int.Parse(seconTe.Substring(0, 1));//任务结束时间 小时
                            }
                            secondTmin = int.Parse(seconTe.Substring(seconTe.Length - 2, 2));//任务结束时间 分钟 

                            //根据subt与资源观测任务的面积比值确定时间
                            for (int ASi = 0; ASi < lstFC.Count; ASi++)
                            {
                                if (lstFC[ASi].ASFID == i.ToString() && lstFC[ASi].TFID == fisttTFID.ToString()) //如果资源和源任务都匹配 那么元任务属于此子任务
                                {
                                    firstsubTtime = firstsubTarea / lstFC[ASi].areaT * lstFC[ASi].RtoTtime;  //任务持续时间 小时 
                                }

                                if (lstFC[ASi].ASFID == i.ToString() && lstFC[ASi].TFID == secondTFID.ToString()) //如果资源和源任务都匹配 那么元任务属于此子任务
                                {
                                    secondsubTtime = secondsubTarea / lstFC[ASi].areaT * lstFC[ASi].RtoTtime;  //任务持续时间 小时
                                }
                                if (firstsubTtime != 0 && secondsubTtime != 0)
                                {
                                    break;
                                }
                            }
                            //两个任务的开始观测时间

                            string EleTToPointPath = System.AppDomain.CurrentDomain.BaseDirectory + "Data\\cache\\" + "EleToPo.shp";//将当前元任务转成点目标，为了求无人机基站到质心距离  
                            string singleEleT = System.AppDomain.CurrentDomain.BaseDirectory + "Data\\cache\\" + "SinEle.shp";
                            GPselectTool(subTaskLayer, singleEleT, "FID=", subFIdlist[j]);//选出单个元任务 当前
                            IFeatureLayer firstEleTFL = OpenFile_LayerFile(singleEleT);//单个元任务 第一个
                            GPFeatureToPointTool(firstEleTFL, EleTToPointPath);
                            IFeatureLayer PointFeatureLayer = OpenFile_LayerFile(EleTToPointPath);//将当前元任务转成点目标
                            //IPoint pointfe = PointFeatureLayer.FeatureClass.GetFeature(0).Shape as IPoint;//将当前无人机最大缓冲区半径内能够观测的任务区域转成的点目标
                            IPoint AStoPoint = ASFea.Shape as IPoint;//将当前AS转成的点目标
                            double ASd = Math.Sqrt(Math.Pow(firstPoint.X - AStoPoint.X, 2) + Math.Pow(firstPoint.Y - AStoPoint.Y, 2));//无人机基地到无人机最大缓冲区半径内能够观测的任务区域的质心距离 米
                            double ASV = double.Parse(ASfeatureLayer.FeatureClass.GetFeature(i).get_Value(5).ToString());
                            if (firstTs.Length > 3)
                            {
                                firstASSTH = int.Parse(firstTs.Substring(0, 2));//任务开始时间 小时                 
                            }
                            else
                            {
                                firstASSTH = int.Parse(firstTs.Substring(0, 1));//任务开始时间 小时
                            }
                            firstASSTM = int.Parse(firstTs.Substring(firstTs.Length - 2, 2));//任务开始时间 分钟 
                            if ((firstASSTH * 60 + firstASSTM) > (SThour * 60 + STmin))//开始时间取  较大值
                            {
                                double st = firstASSTH + (double)firstASSTM / 60 - (ASd / 1000 / ASV);
                                firstASSTH = (int)Math.Floor(st);
                                firstASSTM = (int)((double)(st - firstASSTH) * 60);
                                if (st < (SThour + (double)STmin / 60))
                                {
                                    firstASSTH = SThour;
                                    firstASSTM = STmin;
                                }
                            }
                            else
                            {
                                firstASSTH = SThour;
                                firstASSTM = STmin;
                            }
                            int secondAsSTH;
                            int secondAsSTM;
                            GPselectTool(subTaskLayer, singleEleT, "FID=", subFIdlist[k]);//选出单个元任务 当前
                            IFeatureLayer secondEleTFL = OpenFile_LayerFile(singleEleT);//单个元任务 第一个
                            GPFeatureToPointTool(secondEleTFL, EleTToPointPath);
                            IFeatureLayer secondPointFeatureLayer = OpenFile_LayerFile(EleTToPointPath);//将当前元任务转成点目标
                            //IPoint SecondPointfe = secondPointFeatureLayer.FeatureClass.GetFeature(0).Shape as IPoint;//将
                            double secondASd = Math.Sqrt(Math.Pow(secondPoint.X - AStoPoint.X, 2) + Math.Pow(secondPoint.Y - AStoPoint.Y, 2));
                            if (seconTs.Length > 3)
                            {
                                secondAsSTH = int.Parse(seconTs.Substring(0, 2));//任务开始时间 小时                 
                            }
                            else
                            {
                                secondAsSTH = int.Parse(seconTs.Substring(0, 1));//任务开始时间 小时
                            }
                            secondAsSTM = int.Parse(seconTs.Substring(seconTs.Length - 2, 2));//任务开始时间 分钟 
                            if ((secondAsSTH * 60 + secondAsSTM) > (SThour * 60 + STmin))//开始时间取  较大值
                            {
                                double st = secondAsSTH + (double)secondAsSTM / 60 - (secondASd / 1000 / ASV);
                                secondAsSTH = (int)Math.Floor(st);
                                secondAsSTM = (int)((double)(st - secondAsSTH) * 60);
                                if (st < (SThour + (double)STmin / 60))
                                {
                                    secondAsSTH = SThour;
                                    secondAsSTM = STmin;
                                }
                            }
                            else
                            {
                                secondAsSTH = SThour;
                                secondAsSTM = STmin;
                            }

                            #endregion

                            //判断任务先后顺序  冲突判断
                            //IPoint ASPoint = ASFea.Shape as IPoint;//将AS当作point求当前飞艇到任务的距离
                            //飞艇的冲突判定未考虑航行路线的选择，选择不同路线可能会导致不同的冲突判定结果.暂未考虑-------------------------------------------------------------------------------
                            //if ((firstThour * 60 + firstTmin) < (secondThour * 60 + secondTmin))//第二个任务后执行  SThour;//开始观测时间 小时 STmin;//开始观测时间 分钟
                            //{
                            bool ConflictFirst = false;//第一种路线情况冲突时为true
                            bool ConflictSecond = false;//第二种路线情况冲突时为true
                            //AStofirstTDis = Math.Sqrt(Math.Pow(firstPoint.X - AStoPoint.X, 2) + Math.Pow(firstPoint.Y - AStoPoint.Y, 2));
                            if ((firstASSTH + (double)firstASSTM / 60 + firstsubTtime + secondsubTtime + (ASd + TaskDis) / 1000 / Vas) > (secondThour + (double)secondTmin / 60)) //AS判断冲突  小时
                            {
                                ConflictFirst = true;//第一种路线情况冲突时为true
                                //ConflictTFID conflictFidInfo = new ConflictTFID() { firstTFID = subFIdlist[j], secondTFID = subFIdlist[k] };
                                //ASconFIdlist.Add(conflictFidInfo);
                            }

                            //}
                            //else
                            //{
                            //AStosecondTDis = Math.Sqrt(Math.Pow(secondPoint.X - AStoPoint.X, 2) + Math.Pow(secondPoint.Y - AStoPoint.Y, 2));
                            if ((secondAsSTH + (double)secondAsSTM / 60 + firstsubTtime + secondsubTtime + (secondASd + TaskDis) / 1000 / Vas) > (firstThour + (double)firstTmin / 60)) //AS判断冲突  
                            {
                                ConflictSecond = true;//第二种路线情况冲突时为true
                                //ConflictTFID conflictFidInfo = new ConflictTFID() { firstTFID = subFIdlist[j], secondTFID = subFIdlist[k] };
                                //ASconFIdlist.Add(conflictFidInfo);
                            }
                            if (ConflictFirst && ConflictSecond)//两种路线情况都发生了冲突
                            {
                                ConflictTFID conflictFidInfo = new ConflictTFID() { firstTFID = subFIdlist[j], secondTFID = subFIdlist[k] };
                                ASconFIdlist.Add(conflictFidInfo);
                            }
                            //}

                            //StartTime EleTstartT = new StartTime() { Hour = firstASSTH, Min = firstASSTM };
                            //EleTStimeList.Add(EleTstartT);
                            //if (k == subFIdlist.Count - 1)
                            //{
                            //    StartTime EleTstartTs = new StartTime() { Hour = secondAsSTH, Min = secondAsSTM };
                            //    EleTStimeList.Add(EleTstartTs);
                            //}

                            lastSTH = secondAsSTH;
                            lastSTM = secondAsSTM;

                        }//第二个任务 k
                        StartTime EleTstarttime = new StartTime() { Hour = firstASSTH, Min = firstASSTM };
                        EleTStimeList.Add(EleTstarttime);

                        if (j == subFIdlist.Count - 2)
                        {
                            StartTime EleTstartTs = new StartTime() { Hour = lastSTH, Min = lastSTM };
                            EleTStimeList.Add(EleTstartTs);
                        }

                    }//第一个任务 j

                }//(subFIdlist.Count > 1) 当前资源观测的元任务个数大于1

                RT_FID rtFidInfo = new RT_FID() { RFID = i, subTaskFID = subFIdlist, ConflictTaskFID = ASconFIdlist, taskCount = subFIdlist.Count, EleTstartTime = EleTStimeList };
                ASRTFIDlist.Add(rtFidInfo);
            }//飞艇资源结束 
            //AS冲突判断结束--------------------------------------(AS冲突判断结束)------------------------------------------ 
            #endregion

            #region 监测车冲突判断
            //Car冲突判断开始--------------------------------------(car冲突判断开始)------------------------------------------
            List<RT_FID> CarRTFIDlist = new List<RT_FID>();//carFID 及此car能够观测的元任务集FIDlist ,以及元任务发生冲突的list★★★★★★★★★★★★★★★★ 资源FID：int，元任务FID：list<int>,元任务个数：int
            int Carcount = CarFeatureLayer.FeatureClass.FeatureCount(null);//CAR个数 null就是全选


            IFeatureLayer ElePointFL = OpenFile_LayerFile(ConflictTPOint);//元任务转成的点目标

            for (int i = 0; i < Carcount; i++)//资源FID
            {
                List<int> subFIdlist = new List<int>();//存储每个资源能够观测的元任务fid列表
                for (int j = 0; j < lstTaskFC.Count; j++)//元任务FID
                {
                    List<int> CarFIDList = lstTaskFC[j].CarFID;
                    for (int k = 0; k < CarFIDList.Count; k++)//遍历每个元任务下的观测资源（能够观测到此元任务的资源）
                    {
                        if (i == CarFIDList[k])
                        {
                            subFIdlist.Add(j);
                            break;
                        }
                    }
                }
                IFeature CarFea = CarFeatureLayer.FeatureClass.GetFeature(i);//当前Car（获取属性）
                double CarV = double.Parse(CarFea.get_Value(5).ToString()); //速度 km/h
                double CarMile = double.Parse(CarFea.get_Value(7).ToString()); //里程 km
                List<ConflictTFID> CarconFIdlist = new List<ConflictTFID>();//存储每个资源能够观测的元任务中发生冲突的元任务ID列表list<(int,int)>
                List<StartTime> EleTStimeList = new List<StartTime>();//存储开始观测时间
                if (subFIdlist.Count > 1)//当前观测资源能够观测到的元任务不为空且大于1，满足两两冲突的基本条件
                {
                    //Car冲突判断 假设全部观测完一个任务后再观测其他任务  因此冲突判断条件为：开始时间+执行任务两个任务的时间+车到两个地点路上时间 大于 第二个任务结束时间 则冲突
                    for (int j = 0; j < subFIdlist.Count - 1; j++)
                    {
                        int lastSTH = 0;
                        int lastSTM = 0;
                        double CarToFirsttaskDis;//车到第一个元任务的距离 米
                        IPoint CartoPoint = CarFea.Shape as IPoint;//将当前车转成的点目标
                        IPoint firstPoint = ElePointFL.FeatureClass.GetFeature(subFIdlist[j]).Shape as IPoint;//获取第一个冲突元任务要素（点目标）
                        #region 当前车到第一个元任务的距离 米
                        //几何网络
                        IGeometricNetwork mGeometricNetwork;

                        //获取给定点最近的Network元素
                        IPointToEID mPointToEID = new PointToEIDClass();
                        //获取几何网络文件路径
                        //注意修改此路径为当前存储路径
                        string strPath = System.AppDomain.CurrentDomain.BaseDirectory + "Data\\RoadData.gdb";//+"E:\GIS设计与开发\例子数据\Network\USA_Highway_Network_GDB.mdb";
                        //打开工作空间
                        IWorkspaceFactory pWorkspaceFactory = new ESRI.ArcGIS.DataSourcesGDB.FileGDBWorkspaceFactory();
                        IFeatureWorkspace pFeatureWorkspace = pWorkspaceFactory.OpenFromFile(strPath, 0) as IFeatureWorkspace;
                        //获取要素数据集
                        //注意名称的设置要与上面创建保持一致
                        IFeatureDataset pFeatureDataset = pFeatureWorkspace.OpenFeatureDataset("RaadDataSet");//修改成从xml读取

                        //获取network集合
                        INetworkCollection pNetWorkCollection = pFeatureDataset as INetworkCollection;
                        //获取network的数量,为零时返回
                        int intNetworkCount = pNetWorkCollection.GeometricNetworkCount;
                        if (intNetworkCount < 1)
                        { MessageBox.Show("要素类数量为0！"); }
                        //FeatureDataset可能包含多个network，我们获取指定的network
                        //注意network的名称的设置要与上面创建保持一致
                        mGeometricNetwork = pNetWorkCollection.get_GeometricNetworkByName("RaadDataSet_Net");//修改成从xml读取
                        //设置mPointToEID属性
                        mPointToEID.SourceMap = Program.myMap.Map;
                        mPointToEID.GeometricNetwork = mGeometricNetwork;
                        mPointToEID.SnapTolerance = 200000; //捕捉容差 2000m？

                        IPointCollection CarFTPointCollection = new MultipointClass();//给定点的集合
                        CarFTPointCollection.AddPoint(CartoPoint);
                        CarFTPointCollection.AddPoint(firstPoint);
                        //路径计算
                        IEnumNetEID CarFEnumNetEID_Junctions;//返回路径的节点
                        IEnumNetEID CarFEnumNetEID_Edges;//返回路径边
                        double CarFPathCost;//返回总代价（边长 距离）
                        CoScheduling.Core.Map.MapHelper MapHelp = new Core.Map.MapHelper();
                        MapHelp.SolvePath("weight", mGeometricNetwork, CarFTPointCollection, mPointToEID, out  CarFEnumNetEID_Junctions, out  CarFEnumNetEID_Edges, out   CarFPathCost);
                        IPolyline CarFResultLine = MapHelp.PathToPolyLine(Program.myMap.Map, mGeometricNetwork, CarFEnumNetEID_Edges);//将路径结果转为线
                        CarToFirsttaskDis = CarFResultLine.Length;//两冲突任务的质心距离 米 
                        #endregion

                        int fisttTFID = 0;//源任务FID
                        double firstsubTarea = 0;//元任务面积
                        #region 确定源任务id及元任务面积
                        for (int ti = 0; ti < lstTaskFC.Count; ti++)
                        {
                            if (lstTaskFC[ti].subTFID == subFIdlist[j].ToString())//元任务FID匹配
                            {
                                fisttTFID = int.Parse(lstTaskFC[ti].TFID);
                                firstsubTarea = lstTaskFC[ti].subTArea;
                            }

                            if (firstsubTarea != 0)
                            {
                                break;
                            }
                        }
                        #endregion

                        int firstCarSTH = 0;
                        int firstCarSTM = 0;//第一个任务的开始观测时间
                        int firstThour;//第一个元任务结束时间
                        int firstTmin;
                        double firstsubTtime = 0;//第一个冲突元任务的观测持续时间
                        #region 第一个元任务时间确定
                        IFeature firstTFeature = ptaskFeatureLayer.FeatureClass.GetFeature(fisttTFID);//获取第一个冲突元任务所属源任务要素 为了获取时间窗口
                        string firstTe = firstTFeature.get_Value(5).ToString();//结束时间
                        string firstTs = firstTFeature.get_Value(4).ToString();//开始时间
                        //时间确定 
                        if (firstTe.Length > 3)
                        {
                            firstThour = int.Parse(firstTe.Substring(0, 2));//任务结束时间 小时                 
                        }
                        else
                        {
                            firstThour = int.Parse(firstTe.Substring(0, 1));//任务结束时间 小时
                        }
                        firstTmin = int.Parse(firstTe.Substring(firstTe.Length - 2, 2));//任务结束时间 分钟 

                        if (firstTs.Length > 3)
                        {
                            firstCarSTH = int.Parse(firstTs.Substring(0, 2));//任务开始时间 小时                 
                        }
                        else
                        {
                            firstCarSTH = int.Parse(firstTs.Substring(0, 1));//任务开始时间 小时
                        }
                        firstCarSTM = int.Parse(firstTs.Substring(firstTs.Length - 2, 2));//任务开始时间 分钟 

                        //根据subt与资源观测任务的面积比值确定持续时间
                        for (int Cari = 0; Cari < lstFC.Count; Cari++)
                        {
                            if (lstFC[Cari].CarFID == i.ToString() && lstFC[Cari].TFID == fisttTFID.ToString()) //如果资源和源任务都匹配 那么元任务属于此子任务
                            {
                                firstsubTtime = firstsubTarea / lstFC[Cari].areaT * lstFC[Cari].RtoTtime;  //任务持续时间 小时 
                            }


                            if (firstsubTtime != 0)
                            {
                                break;
                            }
                        }

                        if ((firstCarSTH * 60 + firstCarSTM) > (SThour * 60 + STmin))//开始时间取  较大值
                        {
                            double st = firstCarSTH + (double)firstCarSTM / 60 - (CarToFirsttaskDis / 1000 / CarV);
                            firstCarSTH = (int)Math.Floor(st);
                            firstCarSTM = (int)((double)(st - firstCarSTH) * 60);
                            if (st < (SThour + (double)STmin / 60))
                            {
                                firstCarSTH = SThour;
                                firstCarSTM = STmin;
                            }
                        }
                        else
                        {
                            firstCarSTH = SThour;
                            firstCarSTM = STmin;
                        }


                        #endregion
                        for (int k = j + 1; k < subFIdlist.Count; k++)
                        {
                            double TaskDis;//冲突任务之间距离 米

                            double CarToSecondtaskDis;//车到第二个元任务的距离 米
                            IPoint secondPoint = ElePointFL.FeatureClass.GetFeature(subFIdlist[k]).Shape as IPoint;//将当前subT转成的点目标
                            #region 距离计算

                            #region 两个冲突任务间距离 米

                            IPointCollection mPointCollection = new MultipointClass();//给定点的集合
                            mPointCollection.AddPoint(firstPoint);
                            mPointCollection.AddPoint(secondPoint);

                            //路径计算
                            IEnumNetEID mEnumNetEID_Junctions;//返回路径的节点
                            IEnumNetEID mEnumNetEID_Edges;//返回路径边
                            double mdblPathCost;//返回总代价（边长 距离）

                            MapHelp.SolvePath("weight", mGeometricNetwork, mPointCollection, mPointToEID, out  mEnumNetEID_Junctions, out  mEnumNetEID_Edges, out   mdblPathCost);
                            IPolyline ResultLine = MapHelp.PathToPolyLine(Program.myMap.Map, mGeometricNetwork, mEnumNetEID_Edges);//将路径结果转为线
                            TaskDis = ResultLine.Length;//两冲突任务的质心距离 米 

                            #endregion



                            #region 车到第二个元任务的距离 米
                            IPointCollection CarSTPointCollection = new MultipointClass();//给定点的集合
                            CarSTPointCollection.AddPoint(CartoPoint);
                            CarSTPointCollection.AddPoint(secondPoint);
                            //路径计算
                            IEnumNetEID CarSEnumNetEID_Junctions;//返回路径的节点
                            IEnumNetEID CarSEnumNetEID_Edges;//返回路径边
                            double CarSPathCost;//返回总代价（边长 距离）

                            MapHelp.SolvePath("weight", mGeometricNetwork, CarSTPointCollection, mPointToEID, out  CarSEnumNetEID_Junctions, out  CarSEnumNetEID_Edges, out   CarSPathCost);
                            IPolyline CarSResultLine = MapHelp.PathToPolyLine(Program.myMap.Map, mGeometricNetwork, CarSEnumNetEID_Edges);//将路径结果转为线
                            CarToSecondtaskDis = CarSResultLine.Length;//两冲突任务的质心距离 米 
                            #endregion

                            #endregion

                            //根据元任务fid获取其时间窗口  （获取源任务再得到时间）

                            int secondTFID = 0;

                            double secondsubTarea = 0;

                            #region 确定源任务id及元任务面积
                            for (int ti = 0; ti < lstTaskFC.Count; ti++)
                            {

                                if (lstTaskFC[ti].subTFID == subFIdlist[k].ToString())
                                {
                                    secondTFID = int.Parse(lstTaskFC[ti].TFID);
                                    secondsubTarea = lstTaskFC[ti].subTArea;
                                }
                                if (secondsubTarea != 0)
                                {
                                    break;
                                }
                            }
                            #endregion

                            int secondThour;//第二个结束时间
                            int secondTmin;

                            double secondsubTtime = 0;//第一个冲突元任务的观测持续时间

                            int secondCarSTH;//第二个任务的开始观测时间
                            int secondCarSTM;
                            #region 时间确定


                            IFeature secondTFeature = ptaskFeatureLayer.FeatureClass.GetFeature(secondTFID);//获取第二个冲突元任务所属源任务要素

                            string seconTe = secondTFeature.get_Value(5).ToString();

                            string seconTs = secondTFeature.get_Value(4).ToString();



                            if (seconTe.Length > 3)
                            {
                                secondThour = int.Parse(seconTe.Substring(0, 2));//任务结束时间 小时                 
                            }
                            else
                            {
                                secondThour = int.Parse(seconTe.Substring(0, 1));//任务结束时间 小时
                            }
                            secondTmin = int.Parse(seconTe.Substring(seconTe.Length - 2, 2));//任务结束时间 分钟 

                            //根据subt与资源观测任务的面积比值确定持续时间
                            for (int Cari = 0; Cari < lstFC.Count; Cari++)
                            {


                                if (lstFC[Cari].CarFID == i.ToString() && lstFC[Cari].TFID == secondTFID.ToString()) //如果资源和源任务都匹配 那么元任务属于此子任务
                                {
                                    secondsubTtime = secondsubTarea / lstFC[Cari].areaT * lstFC[Cari].RtoTtime;  //任务持续时间 小时
                                }
                                if (secondsubTtime != 0)
                                {
                                    break;
                                }
                            }
                            //两个任务的开始观测时间


                            if (seconTs.Length > 3)
                            {
                                secondCarSTH = int.Parse(seconTs.Substring(0, 2));//任务开始时间 小时                 
                            }
                            else
                            {
                                secondCarSTH = int.Parse(seconTs.Substring(0, 1));//任务开始时间 小时
                            }
                            secondCarSTM = int.Parse(seconTs.Substring(seconTs.Length - 2, 2));//任务开始时间 分钟 
                            if ((secondCarSTH * 60 + secondCarSTM) > (SThour * 60 + STmin))//开始时间取  较大值
                            {
                                double st = secondCarSTH + (double)secondCarSTM / 60 - (CarToSecondtaskDis / 1000 / CarV);
                                secondCarSTH = (int)Math.Floor(st);
                                secondCarSTM = (int)((double)(st - secondCarSTH) * 60);
                                if (st < (SThour + (double)STmin / 60))
                                {
                                    secondCarSTH = SThour;
                                    secondCarSTM = STmin;
                                }
                            }
                            else
                            {
                                secondCarSTH = SThour;
                                secondCarSTM = STmin;
                            }

                            #endregion

                            //判断任务先后顺序  冲突判断


                            bool ConflictFirst = false;//第一种路线情况冲突时为true
                            bool ConflictSecond = false;//第二种路线情况冲突时为true                         
                            if ((firstCarSTH + (double)firstCarSTM / 60 + firstsubTtime + secondsubTtime + (CarToFirsttaskDis + TaskDis) / 1000 / CarV) > (secondThour + (double)secondTmin / 60)) //判断冲突  小时
                            {
                                ConflictFirst = true;//第一种路线情况冲突时为true                                
                            }

                            if ((secondCarSTH + (double)secondCarSTM / 60 + firstsubTtime + secondsubTtime + (CarToSecondtaskDis + TaskDis) / 1000 / CarV) > (firstThour + (double)firstTmin / 60)) //判断冲突  
                            {
                                ConflictSecond = true;//第二种路线情况冲突时为true                                
                            }
                            if (ConflictFirst && ConflictSecond)//两种路线情况都发生了冲突
                            {
                                ConflictTFID conflictFidInfo = new ConflictTFID() { firstTFID = subFIdlist[j], secondTFID = subFIdlist[k] };
                                CarconFIdlist.Add(conflictFidInfo);
                            }
                            else if (CarToFirsttaskDis + TaskDis > CarMile * 1000 && CarToSecondtaskDis + TaskDis > CarMile * 1000)
                            {
                                ConflictTFID conflictFidInfo = new ConflictTFID() { firstTFID = subFIdlist[j], secondTFID = subFIdlist[k] };
                                CarconFIdlist.Add(conflictFidInfo);
                            }
                            lastSTH = secondCarSTH;
                            lastSTM = secondCarSTM;

                        }//第二个任务 k
                        StartTime EleTstarttime = new StartTime() { Hour = firstCarSTH, Min = firstCarSTM };
                        EleTStimeList.Add(EleTstarttime);

                        if (j == subFIdlist.Count - 2)
                        {
                            StartTime EleTstartTs = new StartTime() { Hour = lastSTH, Min = lastSTM };
                            EleTStimeList.Add(EleTstartTs);
                        }

                    }//第一个任务 j

                }//(subFIdlist.Count > 1) 当前资源观测的元任务个数大于1

                RT_FID rtFidInfo = new RT_FID() { RFID = i, subTaskFID = subFIdlist, ConflictTaskFID = CarconFIdlist, taskCount = subFIdlist.Count, EleTstartTime = EleTStimeList };
                CarRTFIDlist.Add(rtFidInfo);
            }//Car资源结束 
            //Car冲突判断结束--------------------------------------(Car冲突判断结束)------------------------------------------ 
            #endregion

            //冲突判断部分结束--------------------------------------(冲突判断结束)------------------------------------------

            #endregion

            #region 启发式准则模型构建 及 收益

            //先以每个资源为视角计算资源观测到任务的收益 最后在统一到各个子规划中心上 
            int TNO = ptaskFeatureLayer.FeatureClass.FeatureCount(null);// 源任务个数
            fi2 = (double)TNO / lstTaskFC.Count * 5;
            if (fi2 > 1)
            { fi2 = 1; }
            fi = 1 - fi2;
            #region 无人机子规划中心启发式准则模型
            //无人机子规划中心模型.
            //double UAVPlanCenGain = 0;//无人机子规划中心总体收益 元任务不一定分配给此规划中心 要在算法上计算 
            for (int i = 0; i < UavRTFIDlist.Count; i++)
            {
                int UAVFID = UavRTFIDlist[i].RFID;//资源FID‘
                List<int> subFIDList = UavRTFIDlist[i].subTaskFID;//当前资源能够观测到的元任务list集合
                List<ConflictTFID> ConTFID = UavRTFIDlist[i].ConflictTaskFID;//当前资源能够观测的元任务的冲突集合
                List<StartTime> EleTimeS = UavRTFIDlist[i].EleTstartTime;//当前资源观测元任务的开始时间集合
                //List<StartTime> EleStartTime

                List<double> ConRatelist = new List<double>(new double[subFIDList.Count]);//元任务冲突率 每一个资源相对于每一个元任务 list长度为观测元任务个数
                List<double> ConDgreelist = new List<double>(new double[subFIDList.Count]);//元任务冲突率
                List<double> ConLeftElist = new List<double>(new double[subFIDList.Count]);//元任务冲突剩余能力 存储冲突之后能够观测的当前任务的面积s之和 （所有冲突之后的面积之和S1+S2+...+Sjm） （不是概率p）
                List<double> LoadDgreelist = new List<double>(new double[subFIDList.Count]);//当前资源观测元任务的负载度

                List<double> UAVReturnsList = new List<double>(new double[subFIDList.Count]);//每一个资源相对于每一个元任务的收益
                for (int j = 0; j < subFIDList.Count; j++)
                {
                    int subTFID = subFIDList[j];//获取当前资源观测的一个元任务FID 当前元任务
                    List<int> ConflictsubTfid = new List<int>();//与当前元任务冲突的元任务FID集合
                    double subTarea = lstTaskFC[subTFID].subTArea;
                    double subTweight = lstTaskFC[subTFID].subTWeight;//元任务权重
                    double subTtime = 0;//当前元任务的观测时长
                    double ConflisubTtime = 0;//与当前任务冲突的元任务的观测时长
                    string subTwinE = "0";//当前元任务的结束观测时间
                    string subTwinS = "0";//当前元任务的开始观测时间
                    string confisubTWinE = "0";//与当前任务冲突的元任务的观测结束时间

                    #region ConflictsubTfid赋值
                    for (int k = 0; k < ConTFID.Count; k++)
                    {
                        if (ConTFID[k].firstTFID == subTFID)
                        {
                            ConflictsubTfid.Add(ConTFID[k].secondTFID);
                        }
                        else if (ConTFID[k].secondTFID == subTFID)
                        {
                            ConflictsubTfid.Add(ConTFID[k].firstTFID);
                        }
                    }
                    #endregion

                    ConRatelist[j] = (double)ConflictsubTfid.Count / subFIDList.Count;//冲突率 jm/jn ----------------------------------------------------------------------------
                    double conTWeight;//与当前元任务冲突的任务的权重
                    double conTArea;//与当前元任务冲突的任务的面积
                    double conTLevel;//与当前元任务冲突的任务的覆盖级别
                    double conIndSum = 0;//三个指标计算之和   冲突度模型括号里面和
                    for (int k = 0; k < ConflictsubTfid.Count; k++)
                    {
                        conTWeight = lstTaskFC[ConflictsubTfid[k]].subTWeight;//获取与当前元任务冲突的任务的权重 lstTaskFC的第几个即对应元任务的FID
                        conTArea = lstTaskFC[ConflictsubTfid[k]].subTArea;//获取与当前元任务冲突的任务的面积
                        conTLevel = lstTaskFC[ConflictsubTfid[k]].CoverL;//获取与当前元任务冲突的任务的覆盖级别
                        conIndSum = conIndSum + conTWeight / (conTWeight + subTweight) + conTArea / (conTArea + subTarea) + (1 - conTLevel / (conTLevel + (double)lstTaskFC[subTFID].CoverL));
                    }
                    ConDgreelist[j] = conIndSum / ((double)3 * ConflictsubTfid.Count);//冲突度 -------------------------------------------------------------------------------------
                    double subTleftArea = 0;//当前元任务所有冲突剩余面积之和

                    int subThour;//当前元任务结束时间 小时
                    int subTmin;//当前元任务结束时间 分钟
                    int subTShour;//当前元任务开始时间 小时
                    int subTSmin;//分钟
                    #region 当前元任务时间确定
                    //当前元任务时间确定
                    for (int k = 0; k < lstTaskFC.Count; k++)
                    {
                        if (lstTaskFC[k].subTFID == subTFID.ToString())
                        {
                            List<int> UavFIDlist = lstTaskFC[k].UAVFID;
                            for (int ui = 0; ui < UavFIDlist.Count; ui++)
                            {
                                if (UavFIDlist[ui] == UAVFID)
                                { subTtime = lstTaskFC[k].UAVTime[ui]; }//当前元任务的观测时长
                            }
                            subTwinE = lstTaskFC[k].subTWinE;//当前元任务的结束观测时间
                            subTwinS = lstTaskFC[k].subTWinS;//当前元任务的开始观测时间
                        }
                    }
                    if (subTwinE.Length > 3)
                    {
                        subThour = int.Parse(subTwinE.Substring(0, 2));//任务结束时间 小时                 
                    }
                    else
                    {
                        subThour = int.Parse(subTwinE.Substring(0, 1));//任务结束时间 小时
                    }
                    subTmin = int.Parse(subTwinE.Substring(subTwinE.Length - 2, 2));//任务结束时间 分钟  
                    if (subTwinS.Length > 3)
                    {
                        subTShour = int.Parse(subTwinS.Substring(0, 2));//任务结束时间 小时                 
                    }
                    else
                    {
                        subTShour = int.Parse(subTwinS.Substring(0, 1));//任务结束时间 小时
                    }
                    subTSmin = int.Parse(subTwinS.Substring(subTwinS.Length - 2, 2));//任务结束时间 分钟  
                    #endregion
                    double subTS = subTShour + (double)subTSmin / 60;//当前元任务开始时间
                    double subTE = subThour + (double)subTmin / 60;//当前元任务开始时间

                    //根据剩余观测时间估计完成面积 参考冲突判断部分
                    #region 剩余能力


                    for (int l = 0; l < ConflictsubTfid.Count; l++)
                    {
                        int ConsubTFID = ConflictsubTfid[l];//与当前元任务冲突的元任务FID                   


                        int consubThour;//冲突元任务结束时间 小时
                        int consubTmin;//冲突元任务结束时间 分钟
                        //时间确定 
                        #region 冲突元任务时间确定

                        for (int k = 0; k < lstTaskFC.Count; k++)
                        {

                            if (lstTaskFC[k].subTFID == ConsubTFID.ToString())
                            {
                                List<int> conUavFIDlist = lstTaskFC[k].UAVFID;//冲突元任务的FID list
                                for (int ui = 0; ui < conUavFIDlist.Count; ui++)
                                {
                                    if (conUavFIDlist[ui] == UAVFID)
                                    { ConflisubTtime = lstTaskFC[k].UAVTime[ui]; }//冲突元任务的观测时长
                                }
                                confisubTWinE = lstTaskFC[k].subTWinE;//与当前任务冲突的元任务的观测结束时间
                            }

                        }



                        if (confisubTWinE.Length > 3)
                        {
                            consubThour = int.Parse(confisubTWinE.Substring(0, 2));//任务结束时间 小时                 
                        }
                        else
                        {
                            consubThour = int.Parse(confisubTWinE.Substring(0, 1));//任务结束时间 小时
                        }
                        consubTmin = int.Parse(confisubTWinE.Substring(confisubTWinE.Length - 2, 2));//任务结束时间 分钟  
                        #endregion
                        //当前元任务的开始时间 
                        int EleTHour = EleTimeS[j].Hour;
                        int EleTMin = EleTimeS[j].Min;
                        int ConTHour = 0;
                        int ConTMin = 0;
                        for (int k = 0; k < subFIDList.Count; k++)
                        {
                            if (ConsubTFID == subFIDList[k])
                            {
                                ConTHour = EleTimeS[k].Hour;
                                ConTMin = EleTimeS[k].Min;
                                break;
                            }
                        }
                        //考虑两种先后观测顺序  剩余观测面积最大的情况为准
                        //先观察当前任务 剩余能力
                        //从UavRTFIDlist中获取开始时间  ---------------------------------------------------------------------------
                        double AreaRateFirst = (consubThour + (double)consubTmin / 60 - (EleTHour + (double)EleTMin / 60) - ConflisubTtime) / subTtime;
                        double AreaRateSecond = (subThour + (double)subTmin / 60 - (ConTHour + (double)ConTMin / 60) - ConflisubTtime) / subTtime;
                        //if (AreaRateFirst > 0 && AreaRateFirst < 1 && AreaRateSecond > 0 && AreaRateSecond < 1)
                        //{//小于0的情况说明剩余能力为0
                        if (AreaRateFirst > AreaRateSecond)
                        {
                            if (AreaRateFirst > 0 && AreaRateFirst < 1)
                            {
                                subTleftArea = subTleftArea + AreaRateFirst * subTarea;
                            }
                            else if (AreaRateFirst > 1)//说明不会冲突
                            { }
                        }
                        else
                        {
                            if (AreaRateSecond > 0 && AreaRateSecond < 1)
                            {
                                subTleftArea = subTleftArea + AreaRateSecond * subTarea;
                            }
                            else if (AreaRateSecond > 1)//说明不会冲突
                            { }

                        }
                        //}
                        //else//存在一种情况不冲突
                        //{ }


                        //if ((subThour * 60 + subTmin) < (consubThour * 60 + consubTmin))//当前任务先执行 冲突任务后执行  SThour;//开始观测时间 小时 STmin;//开始观测时间 分钟
                        //{
                        //    double AreaRate = (consubThour + (double)consubTmin / 60 - (SThour + (double)STmin / 60) - ConflisubTtime) / subTtime;//任务开始时间是：（开始观测时间）和（任务窗口开始时间）的最大值-----------？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？---------从lsttaskfc可获得----
                        //    if (AreaRate > 0 && AreaRate < 1)
                        //    {
                        //        subTleftArea = subTleftArea + AreaRate * subTarea;
                        //    }
                        //    else if (AreaRate > 1)//说明不会冲突
                        //    { }
                        //}
                        //else//冲突任务先执行 当前任务后执行
                        //{
                        //    double AreaRate = (subThour + (double)subTmin / 60 - (SThour + (double)STmin / 60) - ConflisubTtime) / subTtime;//任务开始时间是：（开始观测时间）和（任务窗口开始时间）的最大值-----------？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？---------从lsttaskfc可获得----
                        //    if (AreaRate > 0 && AreaRate < 1)
                        //    {
                        //        subTleftArea = subTleftArea + AreaRate * subTarea;
                        //    }
                        //    else if (AreaRate > 1)
                        //    { }
                        //}


                    }
                    #endregion
                    ConLeftElist[j] = subTleftArea;//剩余能力 -------------------------------------------------------------------------------------

                    #region 资源负载度
                    //当前资源负载度（在当前元任务时间窗口下的资源负载度） 
                    //确定交集时间
                    string otherTwinS = "";//另一个元任务的开始时间
                    string otherTwinE = "";//结束时间
                    int otherTEhour;//另一个元任务结束时间 小时
                    int otherTEmin;//另一个元任务结束时间 分钟
                    int otherTShour;//另一个元任务开始时间 小时
                    int otherTSmin;//分钟
                    double sumOtherArea = 0;//所有其他元任务在当前元任务时间窗口下能够观测的面积之和
                    for (int k = 0; k < subFIDList.Count; k++)//当前资源能够观测的所有元任务
                    {
                        if (k != j)
                        {
                            #region 时间确定
                            //时间确定
                            otherTwinS = lstTaskFC[subFIDList[k]].subTWinS;
                            otherTwinE = lstTaskFC[subFIDList[k]].subTWinE;
                            if (otherTwinS.Length > 3)
                            {
                                otherTShour = int.Parse(otherTwinS.Substring(0, 2));//任务结束时间 小时                 
                            }
                            else
                            {
                                otherTShour = int.Parse(otherTwinS.Substring(0, 1));//任务结束时间 小时
                            }
                            otherTSmin = int.Parse(otherTwinS.Substring(otherTwinS.Length - 2, 2));//任务结束时间 分钟   
                            if (otherTwinE.Length > 3)
                            {
                                otherTEhour = int.Parse(otherTwinE.Substring(0, 2));//任务结束时间 小时                 
                            }
                            else
                            {
                                otherTEhour = int.Parse(otherTwinE.Substring(0, 1));//任务结束时间 小时
                            }
                            otherTEmin = int.Parse(otherTwinE.Substring(otherTwinE.Length - 2, 2));//任务结束时间 分钟   
                            #endregion
                            double otherTS = otherTShour + (double)otherTSmin / 60;//另一个元任务开始时间
                            double otherTE = otherTEhour + (double)otherTEmin / 60;//结束时间
                            double Tinter = 0;//交集时间 小时
                            #region 确定交集时间
                            if (otherTE - subTS > 0)//判断时间是否有交集
                            {
                                if (subTE - otherTS > 0)//判断时间是否有交集
                                {
                                    if (subTS > otherTS)//otherT时间优先
                                    {
                                        if (subTE > otherTE)//交叉 other优先
                                        { Tinter = otherTE - subTS; }
                                        else// other包含sub
                                        { Tinter = subTE - subTS; }
                                    }
                                    else//当前T时间优先
                                    {
                                        if (subTE < otherTE)//交叉 sub优先
                                        { Tinter = subTE - otherTS; }
                                        else// sub包含other
                                        { Tinter = otherTE - otherTS; }
                                    }
                                }
                            }
                            #endregion

                            double otherTarea = lstTaskFC[subFIDList[k]].subTArea;//other元任务面积
                            sumOtherArea = sumOtherArea + (Tinter * otherTarea) / (otherTE - otherTS);
                        }
                    }
                    double UV = double.Parse(UAVFeatureLayer.FeatureClass.GetFeature(UAVFID).get_Value(5).ToString());//巡航速度 km/h
                    double UW = double.Parse(UAVFeatureLayer.FeatureClass.GetFeature(UAVFID).get_Value(8).ToString());//幅宽 m
                    double Loadd = sumOtherArea / ((subTE - subTS) * tR * UV * UW * 1000);
                    if (Loadd > 1)
                    { LoadDgreelist[j] = 1; }
                    else
                    { LoadDgreelist[j] = Loadd; }

                    #endregion

                    if (ConRatelist[j] > 0 && ConRatelist[j] < 1)//冲突率大于0小于1
                    {
                        if (ConDgreelist[j] >= 0 && ConDgreelist[j] < 1)//冲突度大于等于0小于1
                        {
                            if (ConLeftElist[j] >= 0)
                            {
                                //资源i观测元任务j的收益                  
                                //UAVReturnsList[j] = alpha  * subTarea * (1 - ConRatelist[j] * ConDgreelist[j]) + beta * ConLeftElist[j] / (double)ConflictsubTfid.Count;//资源i观测元任务j的收益（非加权 仅面积）---------------------;
                                //面积加权当作收益
                                UAVReturnsList[j] = fi * (1 - LoadDgreelist[j]) * subTweight * subTarea / subFIDList.Count + fi2 * (alpha * subTweight * subTarea * (1 - ConRatelist[j] * ConDgreelist[j]) + beta * subTweight * ConLeftElist[j] / (double)ConflictsubTfid.Count);
                            }
                            else
                            { }
                        }
                        else
                        {

                        }
                    }
                    else if (ConRatelist[j] == 0) //冲突率=0 即没有冲突
                    {
                        //UAVReturnsList[j] = alpha  * subTarea;
                        UAVReturnsList[j] = fi * (1 - LoadDgreelist[j]) * subTweight * subTarea / subFIDList.Count + fi2 * alpha * subTweight * subTarea;//资源i观测元任务j的收益---------------------;
                    }
                    else
                    { }
                }
                UavRTFIDlist[i].conRate = ConRatelist;
                UavRTFIDlist[i].conDegree = ConDgreelist;
                UavRTFIDlist[i].leftEn = ConLeftElist;
                UavRTFIDlist[i].Returns = UAVReturnsList;
            }

            #endregion

            #region 飞艇子规划中心启发式准则模型
            //飞艇子规划中心模型.
            //double ASPlanCenGain = 0;//飞艇子规划中心总体收益 元任务不一定分配给此规划中心 要在算法上计算 
            for (int i = 0; i < ASRTFIDlist.Count; i++)
            {
                int ASRFID = ASRTFIDlist[i].RFID;//资源FID‘
                IFeature ASFea = ASfeatureLayer.FeatureClass.GetFeature(ASRFID);//当前飞艇（获取属性）
                double Vas = double.Parse(ASFea.get_Value(5).ToString()); //飞艇速度 km/h
                List<int> subFIDList = ASRTFIDlist[i].subTaskFID;//当前资源能够观测到的元任务list集合
                List<ConflictTFID> ConTFID = ASRTFIDlist[i].ConflictTaskFID;//当前资源能够观测的元任务的冲突集合
                List<StartTime> EleTStime = ASRTFIDlist[i].EleTstartTime;
                List<double> ConRatelist = new List<double>(new double[subFIDList.Count]);//元任务冲突率 每一个资源相对于每一个元任务 list长度为观测元任务个数
                List<double> ConDgreelist = new List<double>(new double[subFIDList.Count]);//元任务冲突率
                List<double> ConLeftElist = new List<double>(new double[subFIDList.Count]);//元任务冲突剩余能力 存储冲突之后能够观测的当前任务的面积s之和 （所有冲突之后的面积之和S1+S2+...+Sjm） （不是概率p）
                List<double> LoadDgreelist = new List<double>(new double[subFIDList.Count]);//当前资源观测元任务的负载度
                List<double> ASReturnsList = new List<double>(new double[subFIDList.Count]);//每一个资源相对于每一个元任务的收益
                for (int j = 0; j < subFIDList.Count; j++)//遍历当前资源能够观测到的元任务
                {
                    int subTFID = subFIDList[j];//获取当前资源观测的一个元任务FID 当前元任务
                    List<int> ConflictsubTfid = new List<int>();//与当前元任务冲突的元任务FID集合
                    double subTtime = 0;//当前元任务的观测时长
                    double ConflisubTtime = 0;//与当前任务冲突的元任务的观测时长
                    string subTwinE = "0";//当前元任务的结束观测时间
                    string subTwinS = "0";//当前元任务开始观测时间
                    string confisubTWinE = "0";//与当前任务冲突的元任务的观测结束时间
                    double subTArea = lstTaskFC[subTFID].subTArea;//当前元任务面积
                    double subTweight = lstTaskFC[subTFID].subTWeight;//当前元任务权重
                    #region ConflictsubTfid赋值
                    for (int k = 0; k < ConTFID.Count; k++)
                    {
                        if (ConTFID[k].firstTFID == subTFID)
                        {
                            ConflictsubTfid.Add(ConTFID[k].secondTFID);
                        }
                        else if (ConTFID[k].secondTFID == subTFID)
                        {
                            ConflictsubTfid.Add(ConTFID[k].firstTFID);
                        }
                    }
                    #endregion

                    ConRatelist[j] = (double)ConflictsubTfid.Count / subFIDList.Count;//冲突率 jm/jn ----------------------------------------------------------------------------
                    double conTWeight;//与当前元任务冲突的任务的权重
                    double conTArea;//与当前元任务冲突的任务的面积
                    double conTLevel;//与当前元任务冲突的任务的覆盖级别
                    double conIndSum = 0;//三个指标计算之和   冲突度模型括号里面和
                    for (int k = 0; k < ConflictsubTfid.Count; k++)
                    {
                        conTWeight = lstTaskFC[ConflictsubTfid[k]].subTWeight;//获取与当前元任务冲突的任务的权重 lstTaskFC的第几个即对应元任务的FID
                        conTArea = lstTaskFC[ConflictsubTfid[k]].subTArea;//获取与当前元任务冲突的任务的面积
                        conTLevel = lstTaskFC[ConflictsubTfid[k]].CoverL;//获取与当前元任务冲突的任务的覆盖级别
                        conIndSum = conIndSum + conTWeight / (conTWeight + subTweight) + conTArea / (conTArea + subTArea) + (1 - conTLevel / (conTLevel + (double)lstTaskFC[subTFID].CoverL));
                    }
                    ConDgreelist[j] = conIndSum / ((double)3 * ConflictsubTfid.Count);//冲突度 -------------------------------------------------------------------------------------
                    int subThour;//当前元任务结束时间 小时
                    int subTmin;//当前元任务结束时间 分钟
                    int subTShour;//当前元任务开始时间 小时
                    int subTSmin;//分钟
                    #region 当前任务时间确定
                    for (int k = 0; k < lstTaskFC.Count; k++)
                    {
                        if (lstTaskFC[k].subTFID == subTFID.ToString())
                        {
                            List<int> ASFIDlist = lstTaskFC[k].ASFID;
                            for (int ui = 0; ui < ASFIDlist.Count; ui++)
                            {
                                if (ASFIDlist[ui] == ASRFID)
                                { subTtime = lstTaskFC[k].ASTime[ui]; }//当前元任务的观测时长
                            }
                            subTwinE = lstTaskFC[k].subTWinE;//当前元任务的结束观测时间
                            subTwinS = lstTaskFC[k].subTWinS;//当前元任务的开始观测时间
                        }
                    }
                    if (subTwinS.Length > 3)
                    {
                        subTShour = int.Parse(subTwinS.Substring(0, 2));//任务结束时间 小时                 
                    }
                    else
                    {
                        subTShour = int.Parse(subTwinS.Substring(0, 1));//任务结束时间 小时
                    }
                    subTSmin = int.Parse(subTwinS.Substring(subTwinS.Length - 2, 2));//任务结束时间 分钟  
                    if (subTwinE.Length > 3)
                    {
                        subThour = int.Parse(subTwinE.Substring(0, 2));//任务结束时间 小时                 
                    }
                    else
                    {
                        subThour = int.Parse(subTwinE.Substring(0, 1));//任务结束时间 小时
                    }
                    subTmin = int.Parse(subTwinE.Substring(subTwinE.Length - 2, 2));//任务结束时间 分钟 
                    #endregion
                    double subTS = subTShour + (double)subTSmin / 60;//当前元任务开始时间
                    double subTE = subThour + (double)subTmin / 60;//当前元任务开始时间
                    double subTleftArea = 0;//当前元任务所有冲突剩余面积之和
                    //根据剩余观测时间估计完成面积 参考冲突判断部分
                    #region 剩余能力
                    for (int l = 0; l < ConflictsubTfid.Count; l++)
                    {
                        int ConsubTFID = ConflictsubTfid[l];//与当前元任务冲突的元任务FID

                        int consubThour;//冲突元任务结束时间 小时
                        int consubTmin;//冲突元任务结束时间 分钟
                        //时间确定 
                        #region 结束时间确定
                        for (int k = 0; k < lstTaskFC.Count; k++)
                        {

                            if (lstTaskFC[k].subTFID == ConsubTFID.ToString())
                            {
                                List<int> conASFIDlist = lstTaskFC[k].ASFID;//冲突元任务的资源FID list
                                for (int ui = 0; ui < conASFIDlist.Count; ui++)
                                {
                                    if (conASFIDlist[ui] == ASRFID)
                                    { ConflisubTtime = lstTaskFC[k].ASTime[ui]; }//冲突元任务的观测时长
                                }
                                confisubTWinE = lstTaskFC[k].subTWinE;//与当前任务冲突的元任务的观测结束时间
                            }

                        }



                        if (confisubTWinE.Length > 3)
                        {
                            consubThour = int.Parse(confisubTWinE.Substring(0, 2));//任务结束时间 小时                 
                        }
                        else
                        {
                            consubThour = int.Parse(confisubTWinE.Substring(0, 1));//任务结束时间 小时
                        }
                        consubTmin = int.Parse(confisubTWinE.Substring(confisubTWinE.Length - 2, 2));//任务结束时间 分钟  
                        #endregion

                        double TaskDis;//元任务之间距离 米
                        #region 两个冲突任务间距离 米
                        IPoint subTPoint = ASConflictTPointFL.FeatureClass.GetFeature(subTFID).Shape as IPoint;//获取当前元任务要素（点目标）
                        IPoint conTPoint = ASConflictTPointFL.FeatureClass.GetFeature(ConsubTFID).Shape as IPoint;//将冲突转成的点目标
                        TaskDis = Math.Sqrt(Math.Pow(subTPoint.X - conTPoint.X, 2) + Math.Pow(subTPoint.Y - conTPoint.Y, 2));//两冲突任务的质心距离 米 
                        #endregion
                        IPoint ASPoint = ASFea.Shape as IPoint;//将AS当作point求当前飞艇到任务的距离
                        double AStosubTDisFirst;//飞艇到元任务距离
                        AStosubTDisFirst = Math.Sqrt(Math.Pow(subTPoint.X - ASPoint.X, 2) + Math.Pow(subTPoint.Y - ASPoint.Y, 2));
                        double AStosubTDisSecond = Math.Sqrt(Math.Pow(conTPoint.X - ASPoint.X, 2) + Math.Pow(conTPoint.Y - ASPoint.Y, 2));//飞艇到冲突任务距离
                        //当前元任务的开始时间 
                        int EleTHour = EleTStime[j].Hour;
                        int EleTMin = EleTStime[j].Min;
                        int ConTHour = 0;
                        int ConTMin = 0;
                        for (int k = 0; k < subFIDList.Count; k++)
                        {
                            if (ConsubTFID == subFIDList[k])
                            {
                                ConTHour = EleTStime[k].Hour;
                                ConTMin = EleTStime[k].Min;
                                break;
                            }
                        }
                        //考虑两种先后观测顺序  剩余观测面积最大的情况为准
                        //先观察当前任务 剩余能力
                        //从ASRTFIDlist中获取开始时间  ---------------------------------------------------------------------------

                        double AreaRateFirst = (consubThour + (double)consubTmin / 60 - (EleTHour + (double)EleTMin / 60) - ConflisubTtime - (AStosubTDisFirst + TaskDis) / Vas / 1000) / subTtime;

                        double AreaRateSecond = (subThour + (double)subTmin / 60 - (ConTHour + (double)ConTMin / 60) - ConflisubTtime - (AStosubTDisSecond + TaskDis) / Vas / 1000) / subTtime;

                        //if (AreaRateFirst > 0 && AreaRateFirst < 1 && AreaRateSecond > 0 && AreaRateSecond < 1)
                        //{
                        //    if (AreaRateFirst > AreaRateSecond)
                        //    {
                        //        subTleftArea = subTleftArea + AreaRateFirst * subTArea;
                        //    }
                        //    else
                        //    {
                        //        subTleftArea = subTleftArea + AreaRateSecond * subTArea;
                        //    }
                        //}
                        //else//存在一种情况不冲突
                        //{ }
                        if (AreaRateFirst > AreaRateSecond)
                        {
                            if (AreaRateFirst > 0 && AreaRateFirst < 1)
                            {
                                subTleftArea = subTleftArea + AreaRateFirst * subTArea;
                            }
                            else if (AreaRateFirst > 1)//说明不会冲突
                            { }
                        }
                        else
                        {
                            if (AreaRateSecond > 0 && AreaRateSecond < 1)
                            {
                                subTleftArea = subTleftArea + AreaRateSecond * subTArea;
                            }
                            else if (AreaRateSecond > 1)//说明不会冲突
                            { }

                        }
                        //if ((subThour * 60 + subTmin) < (consubThour * 60 + consubTmin))//当前任务先执行 冲突任务后执行  SThour;//开始观测时间 小时 STmin;//开始观测时间 分钟
                        //{
                        //    AStosubTDis = Math.Sqrt(Math.Pow(subTPoint.X - ASPoint.X, 2) + Math.Pow(subTPoint.Y - ASPoint.Y, 2));
                        //    double AreaRate = (consubThour + (double)consubTmin / 60 - (SThour + (double)STmin / 60) - ConflisubTtime - (AStosubTDis + TaskDis) / Vas / 1000) / subTtime;//任务开始时间是：（开始观测时间）和（任务窗口开始时间）的最大值-----------？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？---------从lsttaskfc可获得----
                        //    if (AreaRate > 0 && AreaRate < 1)
                        //    {
                        //        subTleftArea = subTleftArea + AreaRate * subTArea;
                        //    }
                        //    else if (AreaRate > 1)//飞艇的冲突判定未考虑航行路线的选择，选择不同路线可能会导致不同的冲突判定结果.AreaRate > 1说明另一种航行路线路线任务是不冲突的，即可完成全部面积
                        //    {//已考虑两种路线情况 不会发生AreaRate > 1
                        //        subTleftArea = subTleftArea + subTArea;
                        //    }
                        //}
                        //else//冲突任务先执行 当前任务后执行
                        //{
                        //    AStosubTDis = Math.Sqrt(Math.Pow(conTPoint.X - ASPoint.X, 2) + Math.Pow(conTPoint.Y - ASPoint.Y, 2));
                        //    double AreaRate = (subThour + (double)subTmin / 60 - (SThour + (double)STmin / 60) - ConflisubTtime - (AStosubTDis + TaskDis) / Vas / 1000) / subTtime;//任务开始时间是：（开始观测时间）和（任务窗口开始时间）的最大值-----------？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？---------从lsttaskfc可获得----
                        //    if (AreaRate > 0 && AreaRate < 1)
                        //    {
                        //        subTleftArea = subTleftArea + AreaRate * subTArea;
                        //    }
                        //    else if (AreaRate > 1)//飞艇的冲突判定未考虑航行路线的选择，选择不同路线可能会导致不同的冲突判定结果.AreaRate > 1说明另一种航行路线路线任务是不冲突的，即可完成全部面积
                        //    {//已考虑两种路线情况 不会发生AreaRate > 1
                        //        subTleftArea = subTleftArea + subTArea;
                        //    }
                        //}


                    }
                    #endregion
                    ConLeftElist[j] = subTleftArea;//剩余能力之和 ----------------------------------------------------------------------------------

                    #region 资源负载度
                    //当前资源负载度（在当前元任务时间窗口下的资源负载度） 
                    //确定交集时间
                    string otherTwinS = "";//另一个元任务的开始时间
                    string otherTwinE = "";//结束时间
                    int otherTEhour;//另一个元任务结束时间 小时
                    int otherTEmin;//另一个元任务结束时间 分钟
                    int otherTShour;//另一个元任务开始时间 小时
                    int otherTSmin;//分钟
                    double sumOtherArea = 0;//所有其他元任务在当前元任务时间窗口下能够观测的面积之和
                    for (int k = 0; k < subFIDList.Count; k++)//当前资源能够观测的所有元任务
                    {
                        if (k != j)
                        {
                            #region 时间确定
                            //时间确定
                            otherTwinS = lstTaskFC[subFIDList[k]].subTWinS;
                            otherTwinE = lstTaskFC[subFIDList[k]].subTWinE;
                            if (otherTwinS.Length > 3)
                            {
                                otherTShour = int.Parse(otherTwinS.Substring(0, 2));//任务结束时间 小时                 
                            }
                            else
                            {
                                otherTShour = int.Parse(otherTwinS.Substring(0, 1));//任务结束时间 小时
                            }
                            otherTSmin = int.Parse(otherTwinS.Substring(otherTwinS.Length - 2, 2));//任务结束时间 分钟   
                            if (otherTwinE.Length > 3)
                            {
                                otherTEhour = int.Parse(otherTwinE.Substring(0, 2));//任务结束时间 小时                 
                            }
                            else
                            {
                                otherTEhour = int.Parse(otherTwinE.Substring(0, 1));//任务结束时间 小时
                            }
                            otherTEmin = int.Parse(otherTwinE.Substring(otherTwinE.Length - 2, 2));//任务结束时间 分钟   
                            #endregion
                            double otherTS = otherTShour + (double)otherTSmin / 60;//另一个元任务开始时间
                            double otherTE = otherTEhour + (double)otherTEmin / 60;//结束时间
                            double Tinter = 0;//交集时间 小时
                            #region 确定交集时间
                            if (otherTE - subTS > 0)//判断时间是否有交集
                            {
                                if (subTE - otherTS > 0)//判断时间是否有交集
                                {
                                    if (subTS > otherTS)//otherT时间优先
                                    {
                                        if (subTE > otherTE)//交叉 other优先
                                        { Tinter = otherTE - subTS; }
                                        else// other包含sub
                                        { Tinter = subTE - subTS; }
                                    }
                                    else//当前T时间优先
                                    {
                                        if (subTE < otherTE)//交叉 sub优先
                                        { Tinter = subTE - otherTS; }
                                        else// sub包含other
                                        { Tinter = otherTE - otherTS; }
                                    }
                                }
                            }
                            #endregion

                            double otherTarea = lstTaskFC[subFIDList[k]].subTArea;//other元任务面积
                            sumOtherArea = sumOtherArea + (Tinter * otherTarea) / (otherTE - otherTS);
                        }
                    }
                    //double UV = double.Parse(UAVFeatureLayer.FeatureClass.GetFeature(UAVFID).get_Value(5).ToString());//巡航速度 km/h
                    double ASW = double.Parse(ASFea.get_Value(7).ToString());//幅宽 m
                    double Loadd = sumOtherArea / ((subTE - subTS) * tR * Vas * ASW * 1000);
                    if (Loadd > 1)
                    { LoadDgreelist[j] = 1; }
                    else
                    { LoadDgreelist[j] = Loadd; }

                    #endregion

                    if (ConRatelist[j] > 0 && ConRatelist[j] < 1)//冲突率大于0小于1
                    {
                        if (ConDgreelist[j] >= 0 && ConDgreelist[j] < 1)//冲突度大于等于0小于1
                        {
                            if (ConLeftElist[j] >= 0)
                            {
                                //资源i观测元任务j的收益                  
                                //ASReturnsList[j] = alpha * subTArea * (1 - ConRatelist[j] * ConDgreelist[j]) + beta * ConLeftElist[j] / (double)ConflictsubTfid.Count;//资源i观测元任务j的收益---------------------
                                ASReturnsList[j] = fi * (1 - LoadDgreelist[j]) * subTweight * subTArea / subFIDList.Count + fi2 * (alpha * subTweight * subTArea * (1 - ConRatelist[j] * ConDgreelist[j]) + beta * subTweight * ConLeftElist[j] / (double)ConflictsubTfid.Count);
                            }
                            else
                            { }
                        }
                        else
                        { }
                    }
                    else if (ConRatelist[j] == 0) //冲突率=0 即没有冲突
                    {
                        //ASReturnsList[j] = alpha * subTArea;//资源i观测元任务j的收益---------------------;
                        ASReturnsList[j] = fi * (1 - LoadDgreelist[j]) * subTweight * subTArea / subFIDList.Count + fi2 * alpha * subTweight * subTArea;
                    }
                    else
                    { }


                }
                ASRTFIDlist[i].conRate = ConRatelist;
                ASRTFIDlist[i].conDegree = ConDgreelist;
                ASRTFIDlist[i].leftEn = ConLeftElist;
                ASRTFIDlist[i].Returns = ASReturnsList;
            }

            #endregion

            #region 地面车子规划中心启发式准则模型
            //车辆子规划中心模型.
            //double ASPlanCenGain = 0;//车辆子规划中心总体收益 元任务不一定分配给此规划中心 要在算法上计算 
            for (int i = 0; i < CarRTFIDlist.Count; i++)
            {
                int CarRFID = CarRTFIDlist[i].RFID;//资源FID‘
                IFeature CarFea = CarFeatureLayer.FeatureClass.GetFeature(CarRFID);//当前车辆（获取属性）
                double CarV = double.Parse(CarFea.get_Value(5).ToString()); //车辆速度 km/h
                double CarOberV = double.Parse(CarFea.get_Value(8).ToString());//观测速度 m
                double CarW = double.Parse(CarFea.get_Value(6).ToString());//幅宽 m
                List<int> subFIDList = CarRTFIDlist[i].subTaskFID;//当前资源能够观测到的元任务list集合
                List<ConflictTFID> ConTFID = CarRTFIDlist[i].ConflictTaskFID;//当前资源能够观测的元任务的冲突集合
                List<StartTime> EleTStime = CarRTFIDlist[i].EleTstartTime;//当前资源观测元任务的开始时间集合
                List<double> ConRatelist = new List<double>(new double[subFIDList.Count]);//元任务冲突率 每一个资源相对于每一个元任务 list长度为观测元任务个数
                List<double> ConDgreelist = new List<double>(new double[subFIDList.Count]);//元任务冲突率
                List<double> ConLeftElist = new List<double>(new double[subFIDList.Count]);//元任务冲突剩余能力 存储冲突之后能够观测的当前任务的面积s之和 （所有冲突之后的面积之和S1+S2+...+Sjm） （不是概率p）
                List<double> LoadDgreelist = new List<double>(new double[subFIDList.Count]);//当前资源观测元任务的负载度
                List<double> CarReturnsList = new List<double>(new double[subFIDList.Count]);//每一个资源相对于每一个元任务的收益

                for (int j = 0; j < subFIDList.Count; j++)//遍历当前资源能够观测到的元任务
                {
                    int subTFID = subFIDList[j];//获取当前资源观测的一个元任务FID 当前元任务
                    List<int> ConflictsubTfid = new List<int>();//与当前元任务冲突的元任务FID集合
                    #region ConflictsubTfid赋值
                    for (int k = 0; k < ConTFID.Count; k++)
                    {
                        if (ConTFID[k].firstTFID == subTFID)
                        {
                            ConflictsubTfid.Add(ConTFID[k].secondTFID);
                        }
                        else if (ConTFID[k].secondTFID == subTFID)
                        {
                            ConflictsubTfid.Add(ConTFID[k].firstTFID);
                        }
                    }
                    #endregion

                    double subTtime = 0;//当前元任务的观测时长
                    double ConflisubTtime = 0;//与当前任务冲突的元任务的观测时长

                    string subTwinE = "0";//当前元任务的结束观测时间
                    string subTwinS = "0";//当前元任务开始观测时间
                    string confisubTWinE = "0";//与当前任务冲突的元任务的观测结束时间
                    double subTArea = lstTaskFC[subTFID].subTArea;//当前元任务面积
                    double subTweight = lstTaskFC[subTFID].subTWeight;//当前元任务权重

                    ConRatelist[j] = (double)ConflictsubTfid.Count / subFIDList.Count;//冲突率 jm/jn ----------------------------------------------------------------------------
                    double conTWeight;//与当前元任务冲突的任务的权重
                    double conTArea;//与当前元任务冲突的任务的面积
                    double conTLevel;//与当前元任务冲突的任务的覆盖级别
                    double conIndSum = 0;//三个指标计算之和   冲突度模型括号里面和
                    for (int k = 0; k < ConflictsubTfid.Count; k++)
                    {
                        conTWeight = lstTaskFC[ConflictsubTfid[k]].subTWeight;//获取与当前元任务冲突的任务的权重 lstTaskFC的第几个即对应元任务的FID
                        conTArea = lstTaskFC[ConflictsubTfid[k]].subTArea;//获取与当前元任务冲突的任务的面积
                        conTLevel = lstTaskFC[ConflictsubTfid[k]].CoverL;//获取与当前元任务冲突的任务的覆盖级别
                        conIndSum = conIndSum + conTWeight / (conTWeight + subTweight) + conTArea / (conTArea + subTArea) + (1 - conTLevel / (conTLevel + (double)lstTaskFC[subTFID].CoverL));
                    }
                    ConDgreelist[j] = conIndSum / ((double)3 * ConflictsubTfid.Count);//冲突度 -------------------------------------------------------------------------------------
                    int subThour;//当前元任务结束时间 小时
                    int subTmin;//当前元任务结束时间 分钟
                    int subTShour;//当前元任务开始时间 小时
                    int subTSmin;//分钟
                    #region 当前任务时间确定
                    for (int k = 0; k < lstTaskFC.Count; k++)
                    {
                        if (lstTaskFC[k].subTFID == subTFID.ToString())
                        {
                            List<int> CarFIDlist = lstTaskFC[k].CarFID;
                            for (int ui = 0; ui < CarFIDlist.Count; ui++)
                            {
                                if (CarFIDlist[ui] == CarRFID)
                                { subTtime = lstTaskFC[k].CarTime[ui]; }// .ASTime[ui]; }//当前元任务的观测时长
                            }
                            subTwinE = lstTaskFC[k].subTWinE;//当前元任务的结束观测时间
                            subTwinS = lstTaskFC[k].subTWinS;//当前元任务的开始观测时间
                        }
                    }
                    if (subTwinS.Length > 3)
                    {
                        subTShour = int.Parse(subTwinS.Substring(0, 2));//任务结束时间 小时                 
                    }
                    else
                    {
                        subTShour = int.Parse(subTwinS.Substring(0, 1));//任务结束时间 小时
                    }
                    subTSmin = int.Parse(subTwinS.Substring(subTwinS.Length - 2, 2));//任务结束时间 分钟  
                    if (subTwinE.Length > 3)
                    {
                        subThour = int.Parse(subTwinE.Substring(0, 2));//任务结束时间 小时                 
                    }
                    else
                    {
                        subThour = int.Parse(subTwinE.Substring(0, 1));//任务结束时间 小时
                    }
                    subTmin = int.Parse(subTwinE.Substring(subTwinE.Length - 2, 2));//任务结束时间 分钟 
                    #endregion
                    double subTS = subTShour + (double)subTSmin / 60;//当前元任务开始时间
                    double subTE = subThour + (double)subTmin / 60;//当前元任务结束时间
                    double subTleftArea = 0;//当前元任务所有冲突剩余面积之和
                    //根据剩余观测时间估计完成面积 参考冲突判断部分
                    #region 剩余能力
                    for (int l = 0; l < ConflictsubTfid.Count; l++)
                    {
                        int ConsubTFID = ConflictsubTfid[l];//与当前元任务冲突的元任务FID

                        int consubThour;//冲突元任务结束时间 小时
                        int consubTmin;//冲突元任务结束时间 分钟
                        //时间确定 
                        #region 结束时间确定
                        for (int k = 0; k < lstTaskFC.Count; k++)
                        {

                            if (lstTaskFC[k].subTFID == ConsubTFID.ToString())
                            {
                                List<int> conCarFIDlist = lstTaskFC[k].CarFID;//冲突元任务的资源FID list
                                for (int ui = 0; ui < conCarFIDlist.Count; ui++)
                                {
                                    if (conCarFIDlist[ui] == CarRFID)
                                    { ConflisubTtime = lstTaskFC[k].CarTime[ui]; }//冲突元任务的观测时长
                                }
                                confisubTWinE = lstTaskFC[k].subTWinE;//与当前任务冲突的元任务的观测结束时间
                            }

                        }



                        if (confisubTWinE.Length > 3)
                        {
                            consubThour = int.Parse(confisubTWinE.Substring(0, 2));//任务结束时间 小时                 
                        }
                        else
                        {
                            consubThour = int.Parse(confisubTWinE.Substring(0, 1));//任务结束时间 小时
                        }
                        consubTmin = int.Parse(confisubTWinE.Substring(confisubTWinE.Length - 2, 2));//任务结束时间 分钟  
                        #endregion

                        double TaskDis;//元任务之间距离 米                      
                        double CartosubTDisFirst;//车到当前元任务的距离 米
                        double CartosubTDisSecond;//车到冲突元任务的距离 米
                        #region 距离计算
                        IPoint CartoPoint = CarFea.Shape as IPoint;//将当前车转成的点目标
                        #region 两个冲突任务间距离 米
                        //几何网络
                        IGeometricNetwork mGeometricNetwork;

                        //获取给定点最近的Network元素
                        IPointToEID mPointToEID = new PointToEIDClass();
                        //获取几何网络文件路径
                        //注意修改此路径为当前存储路径
                        string strPath = System.AppDomain.CurrentDomain.BaseDirectory + "Data\\RoadData.gdb";//+"E:\GIS设计与开发\例子数据\Network\USA_Highway_Network_GDB.mdb";
                        //打开工作空间
                        IWorkspaceFactory pWorkspaceFactory = new ESRI.ArcGIS.DataSourcesGDB.FileGDBWorkspaceFactory();
                        IFeatureWorkspace pFeatureWorkspace = pWorkspaceFactory.OpenFromFile(strPath, 0) as IFeatureWorkspace;
                        //获取要素数据集
                        //注意名称的设置要与上面创建保持一致
                        IFeatureDataset pFeatureDataset = pFeatureWorkspace.OpenFeatureDataset("RaadDataSet");//修改成从xml读取

                        //获取network集合
                        INetworkCollection pNetWorkCollection = pFeatureDataset as INetworkCollection;
                        //获取network的数量,为零时返回
                        int intNetworkCount = pNetWorkCollection.GeometricNetworkCount;
                        if (intNetworkCount < 1)
                        { MessageBox.Show("要素类数量为0！"); }
                        //FeatureDataset可能包含多个network，我们获取指定的network
                        //注意network的名称的设置要与上面创建保持一致
                        mGeometricNetwork = pNetWorkCollection.get_GeometricNetworkByName("RaadDataSet_Net");//修改成从xml读取
                        //设置mPointToEID属性
                        mPointToEID.SourceMap = Program.myMap.Map;
                        mPointToEID.GeometricNetwork = mGeometricNetwork;
                        mPointToEID.SnapTolerance = 200000; //捕捉容差 2000m？


                        IPoint subTPoint = ElePointFL.FeatureClass.GetFeature(subTFID).Shape as IPoint;//获取当前元任务要素（点目标） ElePointFL：元任务转成的点目标
                        IPoint conTPoint = ElePointFL.FeatureClass.GetFeature(ConsubTFID).Shape as IPoint;//将冲突转成的点目标

                        IPointCollection mPointCollection = new MultipointClass();//给定点的集合
                        mPointCollection.AddPoint(subTPoint);
                        mPointCollection.AddPoint(conTPoint);

                        //路径计算
                        IEnumNetEID mEnumNetEID_Junctions;//返回路径的节点
                        IEnumNetEID mEnumNetEID_Edges;//返回路径边
                        double mdblPathCost;//返回总代价（边长 距离）
                        CoScheduling.Core.Map.MapHelper MapHelp = new Core.Map.MapHelper();
                        MapHelp.SolvePath("weight", mGeometricNetwork, mPointCollection, mPointToEID, out  mEnumNetEID_Junctions, out  mEnumNetEID_Edges, out   mdblPathCost);
                        IPolyline ResultLine = MapHelp.PathToPolyLine(Program.myMap.Map, mGeometricNetwork, mEnumNetEID_Edges);//将路径结果转为线
                        TaskDis = ResultLine.Length;//两冲突任务的质心距离 米 


                        #endregion

                        #region 当前车到第一个元任务的距离 米
                        IPointCollection CarFTPointCollection = new MultipointClass();//给定点的集合
                        CarFTPointCollection.AddPoint(CartoPoint);
                        CarFTPointCollection.AddPoint(subTPoint);
                        //路径计算
                        IEnumNetEID CarFEnumNetEID_Junctions;//返回路径的节点
                        IEnumNetEID CarFEnumNetEID_Edges;//返回路径边
                        double CarFPathCost;//返回总代价（边长 距离）

                        MapHelp.SolvePath("weight", mGeometricNetwork, CarFTPointCollection, mPointToEID, out  CarFEnumNetEID_Junctions, out  CarFEnumNetEID_Edges, out   CarFPathCost);
                        IPolyline CarFResultLine = MapHelp.PathToPolyLine(Program.myMap.Map, mGeometricNetwork, CarFEnumNetEID_Edges);//将路径结果转为线
                        CartosubTDisFirst = CarFResultLine.Length;//两冲突任务的质心距离 米 
                        #endregion

                        #region 车到第二个元任务的距离 米
                        IPointCollection CarSTPointCollection = new MultipointClass();//给定点的集合
                        CarSTPointCollection.AddPoint(CartoPoint);
                        CarSTPointCollection.AddPoint(conTPoint);
                        //路径计算
                        IEnumNetEID CarSEnumNetEID_Junctions;//返回路径的节点
                        IEnumNetEID CarSEnumNetEID_Edges;//返回路径边
                        double CarSPathCost;//返回总代价（边长 距离）

                        MapHelp.SolvePath("weight", mGeometricNetwork, CarSTPointCollection, mPointToEID, out  CarSEnumNetEID_Junctions, out  CarSEnumNetEID_Edges, out   CarSPathCost);
                        IPolyline CarSResultLine = MapHelp.PathToPolyLine(Program.myMap.Map, mGeometricNetwork, CarSEnumNetEID_Edges);//将路径结果转为线
                        CartosubTDisSecond = CarSResultLine.Length;//两冲突任务的质心距离 米 
                        #endregion

                        #endregion


                        int EleTHour = EleTStime[j].Hour;//当前资源观测元任务的开始时间
                        int EleTMin = EleTStime[j].Min;
                        int ConTHour = 0;//当前资源观测冲突元任务的开始时间
                        int ConTMin = 0;
                        for (int k = 0; k < subFIDList.Count; k++)
                        {
                            if (ConsubTFID == subFIDList[k])
                            {
                                ConTHour = EleTStime[k].Hour;
                                ConTMin = EleTStime[k].Min;
                                break;
                            }
                        }
                        //考虑两种先后观测顺序  剩余观测面积最大的情况为准
                        //先观察当前任务 剩余能力
                        //从CarRTFIDlist中获取开始时间  ---------------------------------------------------------------------------

                        double AreaRateFirst = (consubThour + (double)consubTmin / 60 - (EleTHour + (double)EleTMin / 60) - ConflisubTtime - (CartosubTDisFirst + TaskDis) / CarV / 1000) / subTtime;

                        double AreaRateSecond = (subThour + (double)subTmin / 60 - (ConTHour + (double)ConTMin / 60) - ConflisubTtime - (CartosubTDisSecond + TaskDis) / CarV / 1000) / subTtime;


                        if (AreaRateFirst > AreaRateSecond)
                        {
                            if (AreaRateFirst > 0 && AreaRateFirst < 1)
                            {
                                subTleftArea = subTleftArea + AreaRateFirst * subTArea;
                            }
                            else if (AreaRateFirst > 1)//说明不会冲突
                            { }
                        }
                        else
                        {
                            if (AreaRateSecond > 0 && AreaRateSecond < 1)
                            {
                                subTleftArea = subTleftArea + AreaRateSecond * subTArea;
                            }
                            else if (AreaRateSecond > 1)//说明不会冲突
                            { }

                        }



                    }
                    #endregion
                    ConLeftElist[j] = subTleftArea;//剩余能力之和 ----------------------------------------------------------------------------------

                    #region 资源负载度
                    //当前资源负载度（在当前元任务时间窗口下的资源负载度） 
                    //确定交集时间
                    string otherTwinS = "";//另一个元任务的开始时间
                    string otherTwinE = "";//结束时间
                    int otherTEhour;//另一个元任务结束时间 小时
                    int otherTEmin;//另一个元任务结束时间 分钟
                    int otherTShour;//另一个元任务开始时间 小时
                    int otherTSmin;//分钟
                    double sumOtherArea = 0;//所有其他元任务在当前元任务时间窗口下能够观测的面积之和
                    for (int k = 0; k < subFIDList.Count; k++)//当前资源能够观测的所有元任务
                    {
                        if (k != j)
                        {
                            #region 时间确定
                            //时间确定
                            otherTwinS = lstTaskFC[subFIDList[k]].subTWinS;
                            otherTwinE = lstTaskFC[subFIDList[k]].subTWinE;
                            if (otherTwinS.Length > 3)
                            {
                                otherTShour = int.Parse(otherTwinS.Substring(0, 2));//任务结束时间 小时                 
                            }
                            else
                            {
                                otherTShour = int.Parse(otherTwinS.Substring(0, 1));//任务结束时间 小时
                            }
                            otherTSmin = int.Parse(otherTwinS.Substring(otherTwinS.Length - 2, 2));//任务结束时间 分钟   
                            if (otherTwinE.Length > 3)
                            {
                                otherTEhour = int.Parse(otherTwinE.Substring(0, 2));//任务结束时间 小时                 
                            }
                            else
                            {
                                otherTEhour = int.Parse(otherTwinE.Substring(0, 1));//任务结束时间 小时
                            }
                            otherTEmin = int.Parse(otherTwinE.Substring(otherTwinE.Length - 2, 2));//任务结束时间 分钟   
                            #endregion
                            double otherTS = otherTShour + (double)otherTSmin / 60;//另一个元任务开始时间
                            double otherTE = otherTEhour + (double)otherTEmin / 60;//结束时间
                            double Tinter = 0;//交集时间 小时
                            #region 确定交集时间
                            if (otherTE - subTS > 0)//判断时间是否有交集
                            {
                                if (subTE - otherTS > 0)//判断时间是否有交集
                                {
                                    if (subTS > otherTS)//otherT时间优先
                                    {
                                        if (subTE > otherTE)//交叉 other优先
                                        { Tinter = otherTE - subTS; }
                                        else// other包含sub
                                        { Tinter = subTE - subTS; }
                                    }
                                    else//当前T时间优先
                                    {
                                        if (subTE < otherTE)//交叉 sub优先
                                        { Tinter = subTE - otherTS; }
                                        else// sub包含other
                                        { Tinter = otherTE - otherTS; }
                                    }
                                }
                            }
                            #endregion

                            double otherTarea = lstTaskFC[subFIDList[k]].subTArea;//other元任务面积
                            sumOtherArea = sumOtherArea + (Tinter * otherTarea) / (otherTE - otherTS);
                        }
                    }
                    //double UV = double.Parse(UAVFeatureLayer.FeatureClass.GetFeature(UAVFID).get_Value(5).ToString());//巡航速度 km/h

                    double Loadd = sumOtherArea / ((subTE - subTS) * tR * CarOberV * CarW * 1000);
                    if (Loadd > 1)
                    { LoadDgreelist[j] = 1; }
                    else
                    { LoadDgreelist[j] = Loadd; }

                    #endregion

                    if (ConRatelist[j] > 0 && ConRatelist[j] < 1)//冲突率大于0小于1
                    {
                        if (ConDgreelist[j] >= 0 && ConDgreelist[j] < 1)//冲突度大于等于0小于1
                        {
                            if (ConLeftElist[j] >= 0)
                            {
                                //资源i观测元任务j的收益                  
                                //ASReturnsList[j] = alpha * subTArea * (1 - ConRatelist[j] * ConDgreelist[j]) + beta * ConLeftElist[j] / (double)ConflictsubTfid.Count;//资源i观测元任务j的收益---------------------
                                CarReturnsList[j] = fi * (1 - LoadDgreelist[j]) * subTweight * subTArea / subFIDList.Count + fi2 * (alpha * subTweight * subTArea * (1 - ConRatelist[j] * ConDgreelist[j]) + beta * subTweight * ConLeftElist[j] / (double)ConflictsubTfid.Count);
                            }
                            else
                            { }
                        }
                        else
                        { }
                    }
                    else if (ConRatelist[j] == 0) //冲突率=0 即没有冲突
                    {
                        //ASReturnsList[j] = alpha * subTArea;//资源i观测元任务j的收益---------------------;
                        CarReturnsList[j] = fi * (1 - LoadDgreelist[j]) * subTweight * subTArea / subFIDList.Count + fi2 * alpha * subTweight * subTArea;
                    }
                    else
                    { }


                }
                CarRTFIDlist[i].conRate = ConRatelist;
                CarRTFIDlist[i].conDegree = ConDgreelist;
                CarRTFIDlist[i].leftEn = ConLeftElist;
                CarRTFIDlist[i].Returns = CarReturnsList;
            }

            #endregion

            #region 卫星子规划中心启发式准则模型
            //卫星子规划中心模型.
            //卫星不观测元任务 只考虑卫星观测的子任务不进行划分
            double SatPlanCenGain = 0;//卫星子规划中心总体收益 元任务不一定分配给此规划中心 要在算法上计算 
            // satAtributeFL:SateliteLine卫星集合   SatFeLayer:SatElementTask冲突子任务集合
            for (int i = 0; i < satRTFIDlist.Count; i++)
            {
                int SatRFID = satRTFIDlist[i].RFID;//卫星FID‘
                IFeature SatFea = satAtributeFL.FeatureClass.GetFeature(SatRFID);//当前卫星（获取属性）SatelinteLine图层

                double Vengel = double.Parse(SatFea.get_Value(10).ToString()); //侧摆角转向速度 度每秒
                double storeV = double.Parse(SatFea.get_Value(9).ToString()); //星上存储容量 GB
                double intervalT = double.Parse(SatFea.get_Value(11).ToString()); //开机间隔时间 秒
                double staT = double.Parse(SatFea.get_Value(12).ToString()); //侧摆之后稳定时间 秒


                List<int> subFIDList = satRTFIDlist[i].subTaskFID;//当前资源能够观测到的卫星子任务任务list集合
                List<ConflictTFID> ConTFID = satRTFIDlist[i].ConflictTaskFID;//当前卫星能够观测的子任务的冲突集合 SatElementTask的FID
                List<double> ConRatelist = new List<double>(new double[subFIDList.Count]);//元任务冲突率 每一个资源相对于每一个元任务 list长度为观测元任务个数
                List<double> ConDgreelist = new List<double>(new double[subFIDList.Count]);//元任务冲突度
                List<double> ConLeftElist = new List<double>(new double[subFIDList.Count]);//元任务冲突剩余能力 存储冲突之后能够观测的当前任务的面积s之和 （所有冲突之后的面积之和S1+S2+...+Sjm） （不是概率p）
                List<double> LoadDgreelist = new List<double>(new double[subFIDList.Count]);//任务负载度
                List<double> SatReturns = new List<double>(new double[subFIDList.Count]);//每一个资源观测每一个任务的收益
                for (int j = 0; j < subFIDList.Count; j++)//遍历当前资源能够观测到的元任务
                {
                    int subTFID = subFIDList[j];//获取当前资源观测的一个任务FID 卫星观测当前子任务
                    List<int> ConflictsubTfid = new List<int>();//与当前子任务冲突的子任务FID集合

                    #region ConflictsubTfid赋值
                    for (int k = 0; k < ConTFID.Count; k++)
                    {
                        if (ConTFID[k].firstTFID == subTFID)
                        {
                            ConflictsubTfid.Add(ConTFID[k].secondTFID);
                        }
                        else if (ConTFID[k].secondTFID == subTFID)
                        {
                            ConflictsubTfid.Add(ConTFID[k].firstTFID);
                        }
                    }
                    #endregion

                    ConRatelist[j] = (double)ConflictsubTfid.Count / subFIDList.Count;//冲突率 jm/jn ----------------------------------------------------------------------------

                    IFeature CurrentFe = SatFeLayer.FeatureClass.GetFeature(subTFID);//SatElementTask中当前子任务要素
                    IPolygon CurrentTPolygon = CurrentFe.Shape as IPolygon;
                    IArea CurrentTarea = CurrentTPolygon as IArea;
                    double currentTWeight = double.Parse(CurrentFe.get_Value(6).ToString());//当前子任务的权重
                    double currentTArea = CurrentTarea.Area;//当前子任务的面积
                    double currentTLevel = 1;
                    double conTWeight;//与当前元任务冲突的任务的权重
                    double conTArea;//与当前元任务冲突的任务的面积
                    double conTLevel;//与当前元任务冲突的任务的覆盖级别
                    double conIndSum = 0;//三个指标计算之和   冲突度模型括号里面和
                    for (int k = 0; k < ConflictsubTfid.Count; k++)
                    {
                        IFeature conFe = SatFeLayer.FeatureClass.GetFeature(ConflictsubTfid[k]);//SatElementTask中与当前子任务冲突的子任务要素
                        IPolygon ConTPolygon = conFe.Shape as IPolygon;
                        IArea ConTarea = ConTPolygon as IArea;
                        conTWeight = double.Parse(conFe.get_Value(6).ToString()); //获取与当前元任务冲突的任务的权重
                        conTArea = ConTarea.Area;//获取与当前元任务冲突的任务的面积
                        conTLevel = 1;//卫星子任务的覆盖级别默认为1 
                        conIndSum = conIndSum + conTWeight / (conTWeight + currentTWeight) + conTArea / (conTArea + currentTArea) + (1 - conTLevel / (conTLevel + currentTLevel));
                    }
                    ConDgreelist[j] = conIndSum / ((double)3 * ConflictsubTfid.Count);//冲突度 -------------------------------------------------------------------------------------                  
                    //卫星一旦冲突即不观测冲突任务，所以剩余能力为0
                    #region 卫星一旦冲突即不观测 冲突任务
                    double subTleftArea = 0;//当前元任务所有冲突剩余面积之和
                    #endregion

                    ConLeftElist[j] = subTleftArea;//剩余能力 -------------------------------------------------------------------------------------

                    #region 资源负载度
                    //当前资源负载度（在当前元任务时间窗口下的资源负载度） 

                    string subTwinS = CurrentFe.get_Value(10).ToString();//获取当前任务的开始观测时间
                    string subTwinE = CurrentFe.get_Value(11).ToString();//获取任务的结束观测时间

                    int subThour;//当前元任务结束时间 小时
                    double subTmin;//当前元任务结束时间 分钟
                    int subTShour;//当前元任务开始时间 小时
                    double subTSmin;//分钟
                    #region 当前任务时间确定
                    if (subTwinS.Contains("."))
                    {
                        string HourAndMin = subTwinS.Substring(0, subTwinS.IndexOf("."));
                        if (HourAndMin.Length > 3)
                        {
                            subTShour = int.Parse(HourAndMin.Substring(0, 2));//第一个任务开始观测时间  小时                 
                        }
                        else
                        {
                            subTShour = int.Parse(HourAndMin.Substring(0, 1));//
                        }
                        subTSmin = double.Parse(HourAndMin.Substring(HourAndMin.Length - 2, 2) + subTwinS.Substring(subTwinS.IndexOf(".")));//第一个任务开始观测时间  分钟  
                    }
                    else
                    {
                        if (subTwinS.Length > 3)
                        {
                            subTShour = int.Parse(subTwinS.Substring(0, 2));// 
                        }
                        else
                        {
                            subTShour = int.Parse(subTwinS.Substring(0, 1));//
                        }
                        subTSmin = int.Parse(subTwinS.Substring(subTwinS.Length - 2, 2));//
                    }

                    /////////////////

                    if (subTwinE.Contains("."))
                    {
                        string HourAndMin = subTwinE.Substring(0, subTwinE.IndexOf("."));
                        if (HourAndMin.Length > 3)
                        {
                            subThour = int.Parse(HourAndMin.Substring(0, 2));//第一个任务开始观测时间  小时                 
                        }
                        else
                        {
                            subThour = int.Parse(HourAndMin.Substring(0, 1));//
                        }
                        subTmin = double.Parse(HourAndMin.Substring(HourAndMin.Length - 2, 2) + subTwinE.Substring(subTwinE.IndexOf(".")));//第一个任务开始观测时间  分钟  
                    }
                    else
                    {
                        if (subTwinE.Length > 3)
                        {
                            subThour = int.Parse(subTwinE.Substring(0, 2));// 
                        }
                        else
                        {
                            subThour = int.Parse(subTwinE.Substring(0, 1));//
                        }
                        subTmin = int.Parse(subTwinE.Substring(subTwinE.Length - 2, 2));//
                    }
                    #endregion
                    double subTS = subTShour + (double)subTSmin / 60;//当前元任务开始时间
                    double subTE = subThour + (double)subTmin / 60;//当前元任务开始时间
                    //确定交集时间
                    string otherTwinS = "";//另一个元任务的开始时间
                    string otherTwinE = "";//结束时间
                    int otherTEhour;//另一个元任务结束时间 小时
                    double otherTEmin;//另一个元任务结束时间 分钟
                    int otherTShour;//另一个元任务开始时间 小时
                    double otherTSmin;//分钟
                    double sumTinter = 0;//所有其他元任务在当前元任务时间窗口下能够观测的面积之和
                    for (int k = 0; k < subFIDList.Count; k++)//当前资源能够观测的所有元任务
                    {
                        if (k != j)
                        {
                            #region 时间确定
                            //时间确定

                            otherTwinS = SatFeLayer.FeatureClass.GetFeature(subFIDList[k]).get_Value(10).ToString();//另一个任务开始观测时间
                            otherTwinE = SatFeLayer.FeatureClass.GetFeature(subFIDList[k]).get_Value(11).ToString();

                            if (otherTwinS.Contains("."))
                            {
                                string HourAndMin = otherTwinS.Substring(0, otherTwinS.IndexOf("."));
                                if (HourAndMin.Length > 3)
                                {
                                    otherTShour = int.Parse(HourAndMin.Substring(0, 2));//第一个任务开始观测时间  小时                 
                                }
                                else
                                {
                                    otherTShour = int.Parse(HourAndMin.Substring(0, 1));//
                                }
                                otherTSmin = double.Parse(HourAndMin.Substring(HourAndMin.Length - 2, 2) + otherTwinS.Substring(otherTwinS.IndexOf(".")));//第一个任务开始观测时间  分钟  
                            }
                            else
                            {
                                if (otherTwinS.Length > 3)
                                {
                                    otherTShour = int.Parse(otherTwinS.Substring(0, 2));// 
                                }
                                else
                                {
                                    otherTShour = int.Parse(otherTwinS.Substring(0, 1));//
                                }
                                otherTSmin = int.Parse(otherTwinS.Substring(otherTwinS.Length - 2, 2));//
                            }

                            /////////////////

                            if (otherTwinE.Contains("."))
                            {
                                string HourAndMin = otherTwinE.Substring(0, otherTwinE.IndexOf("."));
                                if (HourAndMin.Length > 3)
                                {
                                    otherTEhour = int.Parse(HourAndMin.Substring(0, 2));//第一个任务开始观测时间  小时                 
                                }
                                else
                                {
                                    otherTEhour = int.Parse(HourAndMin.Substring(0, 1));//
                                }
                                otherTEmin = double.Parse(HourAndMin.Substring(HourAndMin.Length - 2, 2) + otherTwinE.Substring(otherTwinE.IndexOf(".")));//第一个任务开始观测时间  分钟  
                            }
                            else
                            {
                                if (otherTwinE.Length > 3)
                                {
                                    otherTEhour = int.Parse(otherTwinE.Substring(0, 2));// 
                                }
                                else
                                {
                                    otherTEhour = int.Parse(otherTwinE.Substring(0, 1));//
                                }
                                otherTEmin = int.Parse(otherTwinE.Substring(otherTwinE.Length - 2, 2));//
                            }
                            #endregion
                            double otherTS = otherTShour + (double)otherTSmin / 60;//另一个元任务开始时间
                            double otherTE = otherTEhour + (double)otherTEmin / 60;//结束时间
                            double Tinter = 0;//交集时间 小时
                            #region 确定交集时间
                            if (otherTE - subTS > 0)//判断时间是否有交集
                            {
                                if (subTE - otherTS > 0)//判断时间是否有交集
                                {
                                    if (subTS > otherTS)//otherT时间优先
                                    {
                                        if (subTE > otherTE)//交叉 other优先
                                        { Tinter = otherTE - subTS; }
                                        else// other包含sub
                                        { Tinter = subTE - subTS; }
                                    }
                                    else//当前T时间优先
                                    {
                                        if (subTE < otherTE)//交叉 sub优先
                                        { Tinter = subTE - otherTS; }
                                        else// sub包含other
                                        { Tinter = otherTE - otherTS; }
                                    }
                                }
                            }
                            #endregion
                            //IFeature otherFe = SatFeLayer.FeatureClass.GetFeature(subFIDList[k]);//SatElementTask中当前子任务要素
                            //IPolygon otherTPolygon = otherFe.Shape as IPolygon;
                            //IArea otherTarea = otherTPolygon as IArea;
                            //double otherTarea = lstTaskFC[subFIDList[k]].subTArea;//other元任务面积
                            sumTinter = sumTinter + Tinter;
                        }
                    }

                    //double ASW = double.Parse(ASFea.get_Value(7).ToString());//幅宽 m
                    double Loadd = sumTinter / (subTE - subTS);
                    if (Loadd > 1)
                    { LoadDgreelist[j] = 1; }
                    else
                    { LoadDgreelist[j] = Loadd; }

                    #endregion

                    if (ConRatelist[j] > 0 && ConRatelist[j] < 1)//冲突率大于0小于1
                    {
                        if (ConDgreelist[j] >= 0 && ConDgreelist[j] < 1)//冲突度大于等于0小于1
                        {
                            if (ConLeftElist[j] >= 0)
                            {
                                //资源i观测元任务j的收益                  
                                //SatReturns[j] = alpha * currentTArea * (1 - ConRatelist[j] * ConDgreelist[j]) + beta * ConLeftElist[j] / (double)ConflictsubTfid.Count;//资源i观测元任务j的收益---------------------
                                SatReturns[j] = fi * (1 - LoadDgreelist[j]) * currentTWeight * currentTArea / subFIDList.Count + fi2 * (alpha * currentTWeight * currentTArea * (1 - ConRatelist[j] * ConDgreelist[j]) + beta * currentTWeight * ConLeftElist[j] / (double)ConflictsubTfid.Count);
                            }
                            else
                            { }
                        }
                        else
                        { }
                    }
                    else if (ConRatelist[j] == 0) //冲突率=0 即没有冲突
                    {
                        //SatReturns[j] = alpha * currentTArea;//资源i观测元任务j的收益---------------------;
                        SatReturns[j] = fi * (1 - LoadDgreelist[j]) * currentTWeight * currentTArea / subFIDList.Count + fi2 * alpha * currentTWeight * currentTArea;
                    }
                    else
                    { }


                }
                satRTFIDlist[i].conRate = ConRatelist;
                satRTFIDlist[i].conDegree = ConDgreelist;
                satRTFIDlist[i].leftEn = ConLeftElist;
                satRTFIDlist[i].Returns = SatReturns;
            }

            #endregion

            #endregion

            //MWNumericArray RetdurnMadt = new MWNumericArray(MWArrayComplexity.Real, 1, 1);//收益矩阵 行：资源  列：元任务

            #region 构建卫星观测子任务与元任务的对应关系
            List<Sat_ElementTFID> SatTElementT = new List<Sat_ElementTFID>();//存储每一个卫星观测子任务与能够覆盖的元任务的FID对应关系/////////////////////////////////////////////////////////// 

            //IFeature CurrentFe = SatFeLayer.FeatureClass.GetFeature(subTFID);//SatElementTask中当前子任务要素
            IQueryFilter satpFilter = new QueryFilter();//实例化一个查询条件对象 
            satpFilter.WhereClause = "FID >= 0";//将查询条件赋值     选择所有的子任务
            IFeatureCursor satsubTaskfeatureCursor = SatFeLayer.Search(satpFilter, false);// SatFeLayer为卫星观测子任务
            IFeature satsubTaskFeature = satsubTaskfeatureCursor.NextFeature();//遍历查询结果  子任务

            while (satsubTaskFeature != null)
            {
                List<int> ElementFID = new List<int>();//存储当前卫星观测子任务能够覆盖的元任务list


                ISpatialFilter pContainFilter = new SpatialFilterClass();
                pContainFilter.Geometry = satsubTaskFeature.Shape;//卫星观测的一个子任务
                pContainFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelContains;//空间关系选择条件 用包含选择 卫星观测的一个子任务包含的元任务
                IFeatureCursor OriTaskfeatureCursor = subTaskLayer.FeatureClass.Search(pContainFilter, false);//subTaskLayer是最终的元任务
                IFeature ElementTFeature = OriTaskfeatureCursor.NextFeature();//查询卫星观测的一个子任务包含的元任务
                while (ElementTFeature != null)//卫星观测的一个子任务包含的元任务
                {
                    ElementFID.Add(int.Parse(ElementTFeature.get_Value(0).ToString()));//获取当前卫星观测子任务包含的元任务FID列表

                    ElementTFeature = OriTaskfeatureCursor.NextFeature();//查询卫星观测的一个子任务包含的元任务
                }




                Sat_ElementTFID satTtoElementT = new Sat_ElementTFID() { SatTFID = int.Parse(satsubTaskFeature.get_Value(0).ToString()), ElementTaskFID = ElementFID, SatFID = int.Parse(satsubTaskFeature.get_Value(16).ToString()) };
                SatTElementT.Add(satTtoElementT);
                satsubTaskFeature = satsubTaskfeatureCursor.NextFeature();//遍历查询结果  子任务
            }
            #endregion

            #region 信息输出excel 顺序：无人机 飞艇 车 卫星
            ////建立Excel对象
            Microsoft.Office.Interop.Excel.Application ElemtTExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workbooks = ElemtTExcel.Application.Workbooks.Add(true);
            ElemtTExcel.Visible = true; // isShowExcle;//是否打开该Excel文件

            for (int i = 0; i < 4; i++)//新建几个sheet
            { ElemtTExcel.Sheets.Add(); }

            //将元任务信息输出 lstTaskFC 以便在matlab中画图
            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbooks.Sheets[1];
            worksheet.Name = "ElementTinfo";
            //填充数据

            for (int j = 0; j < lstTaskFC.Count; j++)// 列数：元任务个数
            {
                worksheet.Cells[1, j + 1] = lstTaskFC[j].subTArea; //存储每一个子任务的面积
                worksheet.Cells[2, j + 1] = lstTaskFC[j].subTWeight; //存储每一个子任务的权重
            }


            #region 子规划平台观测元任务的收益 形成收益矩阵 每一列表示元任务 每一行表示每一个资源（3个）
            //将子规划平台观测元任务的收益 添加到lsttaskFc中  一个元任务对应所有资源收益（）
            ////声明一个m行n列的收益矩阵 m：所有资源个数   n：元任务个数
            int ResouceNO = UavRTFIDlist.Count + ASRTFIDlist.Count + CarRTFIDlist.Count + satRTFIDlist.Count;//资源数目
            int ElemTno = subTaskLayer.FeatureClass.FeatureCount(null);//元任务数目
            double[,] ReMa = new double[ResouceNO, ElemTno];
            for (int i = 0; i < lstTaskFC.Count; i++)//遍历元任务
            {
                int ElemTFID = int.Parse(lstTaskFC[i].subTFID.ToString());//元任务FID
                //无人机平台收益
                List<int> UavFidlst = lstTaskFC[i].UAVFID;//能够观测到此元任务的无人机列表
                for (int j = 0; j < UavFidlst.Count; j++)//遍历能够观测到此元任务的每一个无人机
                {
                    int UavFid = UavFidlst[j];//无人机FID
                    for (int k = 0; k < UavRTFIDlist.Count; k++)//遍历无人机列表
                    {
                        if (UavFid == UavRTFIDlist[k].RFID)//选中此无人机
                        {
                            for (int l = 0; l < UavRTFIDlist[k].subTaskFID.Count; l++)//遍历此无人机能够观测的元任务
                            {
                                if (UavRTFIDlist[k].subTaskFID[l] == ElemTFID)
                                {
                                    ReMa[UavFid, ElemTFID] = UavRTFIDlist[k].Returns[l];//每一个资源观测每一个元任务形成的收益矩阵
                                    lstTaskFC[i].UAVReturns = lstTaskFC[i].UAVReturns + UavRTFIDlist[k].Returns[l];//获取子规划中心观测此元任务收益 平台收益矩阵
                                    break;
                                }
                            }
                            break;
                        }
                    }
                }
                //飞艇平台收益
                List<int> ASFidlst = lstTaskFC[i].ASFID;//能够观测到此元任务的飞艇列表
                for (int j = 0; j < ASFidlst.Count; j++)//遍历能够观测到此元任务的每一个AS
                {
                    int AsFid = ASFidlst[j];//AS FID
                    for (int k = 0; k < ASRTFIDlist.Count; k++)//遍历AS列表
                    {
                        if (AsFid == ASRTFIDlist[k].RFID)//选中此AS
                        {
                            for (int l = 0; l < ASRTFIDlist[k].subTaskFID.Count; l++)//遍历此AS能够观测的元任务
                            {
                                if (ASRTFIDlist[k].subTaskFID[l] == ElemTFID)
                                {
                                    ReMa[UavRTFIDlist.Count + AsFid, ElemTFID] = ASRTFIDlist[k].Returns[l];//每一个资源观测每一个元任务形成的收益矩阵
                                    lstTaskFC[i].ASReturns = lstTaskFC[i].ASReturns + ASRTFIDlist[k].Returns[l];//获取子规划中心观测此元任务收益
                                    break;
                                }
                            }
                            break;
                        }
                    }
                }
                //地面车平台收益
                List<int> CarFidlst = lstTaskFC[i].CarFID;//能够观测到此元任务的Car列表
                for (int j = 0; j < CarFidlst.Count; j++)//遍历能够观测到此元任务的每一个car
                {
                    int CarFid = CarFidlst[j];//car FID

                    for (int k = 0; k < CarRTFIDlist.Count; k++)//遍历car列表
                    {
                        if (CarFid == CarRTFIDlist[k].RFID)//选中此car
                        {
                            for (int l = 0; l < CarRTFIDlist[k].subTaskFID.Count; l++)//遍历此car能够观测的元任务
                            {
                                if (CarRTFIDlist[k].subTaskFID[l] == ElemTFID)
                                {
                                    ReMa[UavRTFIDlist.Count + ASRTFIDlist.Count + CarFid, ElemTFID] = CarRTFIDlist[k].Returns[l];//每一个资源观测每一个元任务形成的收益矩阵
                                    lstTaskFC[i].CarReturns = lstTaskFC[i].CarReturns + CarRTFIDlist[k].Returns[l];//获取子规划中心观测此元任务收益
                                    break;
                                }
                            }
                            break;
                        }
                    }
                }
                //卫星平台收益
                for (int j = 0; j < SatTElementT.Count; j++)//遍历卫星观测的子任务
                {
                    int SatFID = SatTElementT[j].SatFID;//卫星FID
                    for (int l = 0; l < SatTElementT[j].ElementTaskFID.Count; l++)//遍历卫星观测的一个子任务包含的元任务
                    {
                        if (SatTElementT[j].ElementTaskFID[l] == ElemTFID)//如果卫星观测的一个子任务包含的元任务等于当前元任务
                        {
                            for (int si = 0; si < satRTFIDlist.Count; si++)//遍历卫星 
                            {
                                if (satRTFIDlist[si].RFID == SatFID)
                                {
                                    for (int ti = 0; ti < satRTFIDlist[si].subTaskFID.Count; ti++)//遍历当前卫星可观测的子任务
                                    {
                                        if (satRTFIDlist[si].subTaskFID[ti] == SatTElementT[j].SatTFID)//选择卫星观测的子任务
                                        {
                                            double satTR = satRTFIDlist[si].Returns[ti];//卫星观测子任务的收益
                                            ReMa[UavRTFIDlist.Count + ASRTFIDlist.Count + CarRTFIDlist.Count + SatFID, ElemTFID] = satTR / SatTElementT[j].ElementTaskFID.Count; //每一个资源观测每一个元任务形成的收益矩阵
                                            lstTaskFC[i].SatReturns = lstTaskFC[i].SatReturns + satTR / SatTElementT[j].ElementTaskFID.Count;//将元任务的卫星观测收益表达为 卫星观测子任务的收益与该子任务包含元任务个数的比值 没考虑面积的占比关系
                                            break;
                                        }
                                    }
                                    break;
                                }

                            }
                            break;
                        }
                    }
                }
                //List<int> SatFidlst = lstTaskFC[i].SatFID;//能够观测到此元任务的卫星列表
            }

            #endregion

            worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbooks.Sheets[2];
            worksheet.Name = "Returns";
            #region 将收益输出成excel  每一列对应元任务 每一行对应资源
            #region 平台对元任务的收益矩阵 （已注释）
            //Microsoft.Office.Interop.Excel.Application pexcel = new Microsoft.Office.Interop.Excel.Application();
            //pexcel.Application.Workbooks.Add(true);
            //pexcel.Visible = true; // isShowExcle;//是否打开该Excel文件
            //for (int c = 0; c < 3; c++)//3行 无人机 飞艇  卫星
            //{
            //    for (int j = 0; j < lstTaskFC.Count; j++)// 元任务个数既是列数
            //    {
            //        if (c == 0)//无人机
            //        {
            //            pexcel.Cells[c + 1, j + 1] = lstTaskFC[j].UAVReturns;//UAV子规划中心观测此元任务的收益
            //        }
            //        else if (c == 1)//AS
            //        {
            //            pexcel.Cells[c + 1, j + 1] = lstTaskFC[j].ASReturns;
            //        }
            //        else//Sat
            //        {
            //            pexcel.Cells[c + 1, j + 1] = lstTaskFC[j].SatReturns;
            //        }

            //    }
            //} 
            #endregion

            #region 资源对每一个元任务收益矩阵

            try
            {
                for (int c = 0; c < ResouceNO; c++)//行数 资源总个数 无人机+飞艇+卫星
                {
                    for (int j = 0; j < ElemTno; j++)// 元任务个数既是列数
                    {
                        worksheet.Cells[c + 1, j + 1] = ReMa[c, j];//每一个观测此元任务的收益
                    }
                }
            }

            catch
            { }

            #endregion

            #endregion

            worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbooks.Sheets[3];
            worksheet.Name = "ElementT";
            #region  将卫星子任务与元任务对应关系输出excel
            //将卫星子任务与元任务对应关系输出excel 在matlab中求解 第一列表示观测当前子任务的卫星fid
            ////建立Excel对象
            //Microsoft.Office.Interop.Excel.Application ElemtTExcel = new Microsoft.Office.Interop.Excel.Application();
            //ElemtTExcel.Application.Workbooks.Add(true);
            //ElemtTExcel.Visible = true; // isShowExcle;//是否打开该Excel文件
            //填充数据
            for (int c = 0; c < SatTElementT.Count; c++)//行数：卫星观测子任务个数 SatTElementT：卫星观测子任务与元任务的对应关系
            {
                worksheet.Cells[c + 1, 1] = SatTElementT[c].SatFID;//第一列存储卫星fid
                for (int j = 0; j < SatTElementT[c].ElementTaskFID.Count; j++)// 当前子任务包含的元任务个数既是列数
                {

                    worksheet.Cells[c + 1, j + 2] = SatTElementT[c].ElementTaskFID[j];//存储每一个子任务包含的元任务FID


                }
            }
            #endregion

            worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbooks.Sheets[4];
            worksheet.Name = "ConElemTfid";
            #region 每个资源观测元任务的冲突关系输出excel

            //将每个资源观测元任务的冲突关系输出excel 在matlab中求解
            //excel 最大行数是1048576行，最大列数是16384列.列数大于16384报错，将行列转置.为了迎合网格 保持一致
            //填充数据
            //for (int c = 0; c < ResouceNO; c++) //行号与收益矩阵中对应 每一行都代表一个资源 
            //{
            //    if (c < UavRTFIDlist.Count)//每一个无人机资源的冲突
            //    {
            int FirstElementTFID = -1;//第一个冲突元任务的fid
            int SecondElementTFID = -1;
            for (int t = 0; t < UavRTFIDlist.Count; t++)//遍历无人机资源
            {
                int UavFid = UavRTFIDlist[t].RFID;//当前资源FID
                List<ConflictTFID> ConfiTFIDlist = UavRTFIDlist[t].ConflictTaskFID;//当前资源下的 元任务冲突列表
                for (int e = 0; e < ConfiTFIDlist.Count; e++)
                {
                    FirstElementTFID = ConfiTFIDlist[e].firstTFID;//冲突元任务的第一个
                    SecondElementTFID = ConfiTFIDlist[e].secondTFID;//冲突元任务的第二个
                    worksheet.Cells[2 * e + 1, UavFid + 1] = FirstElementTFID;
                    worksheet.Cells[2 * e + 2, UavFid + 1] = SecondElementTFID;
                }

            }
            for (int i = 0; i < ASRTFIDlist.Count; i++)
            {
                int ASrFid = ASRTFIDlist[i].RFID;//资源fid
                List<ConflictTFID> asConfiTFidlist = ASRTFIDlist[i].ConflictTaskFID;
                for (int j = 0; j < asConfiTFidlist.Count; j++)
                {
                    FirstElementTFID = asConfiTFidlist[j].firstTFID;
                    SecondElementTFID = asConfiTFidlist[j].secondTFID;
                    worksheet.Cells[2 * j + 1, UavRTFIDlist.Count + ASrFid + 1] = FirstElementTFID;
                    worksheet.Cells[2 * j + 2, UavRTFIDlist.Count + ASrFid + 1] = SecondElementTFID;

                }
            }

            for (int i = 0; i < CarRTFIDlist.Count; i++)
            {
                int CarFid = CarRTFIDlist[i].RFID;//资源fid
                List<ConflictTFID> CarConfiTFidlist = CarRTFIDlist[i].ConflictTaskFID;
                for (int j = 0; j < CarConfiTFidlist.Count; j++)
                {
                    FirstElementTFID = CarConfiTFidlist[j].firstTFID;
                    SecondElementTFID = CarConfiTFidlist[j].secondTFID;
                    worksheet.Cells[2 * j + 1, UavRTFIDlist.Count + ASRTFIDlist.Count + CarFid + 1] = FirstElementTFID;
                    worksheet.Cells[2 * j + 2, UavRTFIDlist.Count + ASRTFIDlist.Count + CarFid + 1] = SecondElementTFID;

                }
            }

            for (int i = 0; i < satRTFIDlist.Count; i++)
            {
                int satRFid = satRTFIDlist[i].RFID;//资源fid
                int FirSatTfid;
                int SecSatTfid;
                List<ConflictTFID> satConfiTFidlist = satRTFIDlist[i].ConflictTaskFID;//卫星观测子任务冲突 fid
                for (int j = 0; j < satConfiTFidlist.Count; j++)
                {
                    FirSatTfid = satConfiTFidlist[j].firstTFID;//冲突子任务fid
                    SecSatTfid = satConfiTFidlist[j].secondTFID;
                    //根据子任务确定元任务
                    for (int t = 0; t < SatTElementT.Count; t++)
                    {
                        if (FirSatTfid == SatTElementT[t].SatTFID)
                        {
                            FirstElementTFID = SatTElementT[t].ElementTaskFID[0];//只需获取冲突子任务包含的第一个元任务即可
                        }
                        else if (SecSatTfid == SatTElementT[t].SatTFID)
                        {
                            SecondElementTFID = SatTElementT[t].ElementTaskFID[0];
                        }

                    }
                    worksheet.Cells[2 * j + 1, UavRTFIDlist.Count + ASRTFIDlist.Count + CarRTFIDlist.Count + satRFid + 1] = FirstElementTFID;
                    worksheet.Cells[2 * j + 2, UavRTFIDlist.Count + ASRTFIDlist.Count + CarRTFIDlist.Count + satRFid + 1] = SecondElementTFID;

                }
            }
            //    }
            //    else if (c < UavRTFIDlist.Count + ASRTFIDlist.Count)//每一个飞艇资源的冲突
            //    { }
            //    else//每一个卫星资源的冲突
            //    { }
            //}
            #endregion



            ////worksheet.SaveAs(System.AppDomain.CurrentDomain.BaseDirectory + "Data\\fisrt.xlsx");
            ////worksheet2.SaveAs(System.AppDomain.CurrentDomain.BaseDirectory + "Data\\fisrt2.xlsx");
            ////workbooks.Close(false);
            ////ElemtTExcel.Quit();
            #endregion

            #region 调用matlab进行分配计算 已注释
            ////MLApp.MLApp matlab = null;
            ////Type matlabAppType = System.Type.GetTypeFromProgID("Matlab.Application");
            ////matlab = System.Activator.CreateInstance(matlabAppType) as MLApp.MLApp;

            ////string path_project = System.AppDomain.CurrentDomain.BaseDirectory;   //工程文件的路径，如bin  
            ////string path_matlab = "cd('" + path_project + "')";     //自定义matlab工作路径    
            ////matlab.Execute(path_matlab);
            ////matlab.Execute("clear all");//<span style="color:#ff6666;">//这条语句也很重要，先注释掉，下面讲解</span> 

            //int ResouceNumber = UavRTFIDlist.Count + ASRTFIDlist.Count + satRTFIDlist.Count;//资源数目
            //int ElemTNumber = subTaskLayer.FeatureClass.FeatureCount(null);//元任务数目 
            ////MWNumericArray ReturnMat = new MWNumericArray(MWArrayComplexity.Real, ResouceNumber, ElemTNumber);//收益矩阵 行：资源  列：元任务
            //MWNumericArray ReturnMat = new MWNumericArray(MWArrayComplexity.Real, ResouceNumber, ElemTNumber);//收益矩阵 行：资源  列：元任务

            //#region 构建收益矩阵
            //double[,] ReMa = new double[ResouceNumber, ElemTNumber];
            //for (int i = 0; i < lstTaskFC.Count; i++)//遍历元任务
            //{
            //    int ElemTFID = int.Parse(lstTaskFC[i].subTFID.ToString());//元任务FID
            //    //无人机平台收益
            //    List<int> UavFidlst = lstTaskFC[i].UAVFID;//能够观测到此元任务的无人机列表
            //    for (int j = 0; j < UavFidlst.Count; j++)//遍历能够观测到此元任务的每一个无人机
            //    {
            //        int UavFid = UavFidlst[j];//无人机FID
            //        for (int k = 0; k < UavRTFIDlist.Count; k++)//遍历无人机列表
            //        {
            //            if (UavFid == UavRTFIDlist[k].RFID)//选中此无人机
            //            {
            //                for (int l = 0; l < UavRTFIDlist[k].subTaskFID.Count; l++)//遍历此无人机能够观测的元任务
            //                {
            //                    if (UavRTFIDlist[k].subTaskFID[l] == ElemTFID)
            //                    {
            //                        ReMa[UavFid, ElemTFID] = UavRTFIDlist[k].Returns[l];//每一个资源观测每一个元任务形成的收益矩阵
            //                        lstTaskFC[i].UAVReturns = lstTaskFC[i].UAVReturns + UavRTFIDlist[k].Returns[l];//获取子规划中心观测此元任务收益 平台收益矩阵
            //                        break;
            //                    }
            //                }
            //                break;
            //            }
            //        }
            //    }
            //    //飞艇平台收益
            //    List<int> ASFidlst = lstTaskFC[i].ASFID;//能够观测到此元任务的飞艇列表
            //    for (int j = 0; j < ASFidlst.Count; j++)//遍历能够观测到此元任务的每一个AS
            //    {
            //        int AsFid = ASFidlst[j];//AS FID
            //        for (int k = 0; k < ASRTFIDlist.Count; k++)//遍历AS列表
            //        {
            //            if (AsFid == ASRTFIDlist[k].RFID)//选中此AS
            //            {
            //                for (int l = 0; l < ASRTFIDlist[k].subTaskFID.Count; l++)//遍历此AS能够观测的元任务
            //                {
            //                    if (ASRTFIDlist[k].subTaskFID[l] == ElemTFID)
            //                    {
            //                        ReMa[UavRTFIDlist.Count + AsFid, ElemTFID] = ASRTFIDlist[k].Returns[l];//每一个资源观测每一个元任务形成的收益矩阵
            //                        lstTaskFC[i].ASReturns = lstTaskFC[i].ASReturns + ASRTFIDlist[k].Returns[l];//获取子规划中心观测此元任务收益
            //                        break;
            //                    }
            //                }
            //                break;
            //            }
            //        }
            //    }
            //    //卫星平台收益
            //    for (int j = 0; j < SatTElementT.Count; j++)//遍历卫星观测的子任务
            //    {
            //        int SatFID = SatTElementT[j].SatFID;//卫星FID
            //        for (int l = 0; l < SatTElementT[j].ElementTaskFID.Count; l++)//遍历卫星观测的一个子任务包含的元任务
            //        {
            //            if (SatTElementT[j].ElementTaskFID[l] == ElemTFID)//如果卫星观测的一个子任务包含的元任务等于当前元任务
            //            {
            //                for (int si = 0; si < satRTFIDlist.Count; si++)//遍历卫星 
            //                {
            //                    if (satRTFIDlist[si].RFID == SatFID)
            //                    {
            //                        for (int ti = 0; ti < satRTFIDlist[si].subTaskFID.Count; ti++)//遍历当前卫星可观测的子任务
            //                        {
            //                            if (satRTFIDlist[si].subTaskFID[ti] == SatTElementT[j].SatTFID)//选择卫星观测的子任务
            //                            {
            //                                double satTR = satRTFIDlist[si].Returns[ti];//卫星观测子任务的收益
            //                                ReMa[UavRTFIDlist.Count + ASRTFIDlist.Count + SatFID, ElemTFID] = satTR / SatTElementT[j].ElementTaskFID.Count; //每一个资源观测每一个元任务形成的收益矩阵
            //                                lstTaskFC[i].SatReturns = lstTaskFC[i].SatReturns + satTR / SatTElementT[j].ElementTaskFID.Count;//将元任务的卫星观测收益表达为 卫星观测子任务的收益与该子任务包含元任务个数的比值 没考虑面积的占比关系
            //                                break;
            //                            }
            //                        }
            //                        break;
            //                    }

            //                }
            //                break;
            //            }
            //        }
            //    }
            //    //List<int> SatFidlst = lstTaskFC[i].SatFID;//能够观测到此元任务的卫星列表
            //}
            //ReturnMat = ReMa;
            //#endregion

            //MWNumericArray OritoEleMat;//卫星子任务与元任务对应关系矩阵

            //#region 构建卫星子任务与元任务对应关系矩阵
            ////找出行数 列数  行数：卫星子任务个数  列数：（第一列卫星fid 第二列此卫星子任务包含元任务个数）最大元任务个数+2
            //int TaskRow = 0;//最大元任务个数
            //for (int c = 0; c < SatTElementT.Count; c++)//行数：卫星观测子任务个数 SatTElementT：卫星观测子任务与元任务的对应关系
            //{
            //    if (TaskRow < SatTElementT[c].ElementTaskFID.Count)
            //    { TaskRow = SatTElementT[c].ElementTaskFID.Count; }
            //}
            //OritoEleMat = new MWNumericArray(MWArrayComplexity.Real, SatTElementT.Count, TaskRow + 2);
            //for (int c = 0; c < SatTElementT.Count; c++)//行数：卫星观测子任务个数 SatTElementT：卫星观测子任务与元任务的对应关系
            //{
            //    OritoEleMat[c + 1, 1] = SatTElementT[c].SatFID;//第一列存储卫星fid
            //    OritoEleMat[c + 1, 2] = SatTElementT[c].ElementTaskFID.Count;//第二列存储此卫星子任务包含元任务个数
            //    for (int j = 0; j < SatTElementT[c].ElementTaskFID.Count; j++)// 当前子任务包含的元任务个数既是列数
            //    {
            //        OritoEleMat[c + 1, j + 3] = SatTElementT[c].ElementTaskFID[j];//存储每一个子任务包含的元任务FID
            //    }
            //}
            //#endregion

            //MWNumericArray ConfliMat;//元任务冲突关系矩阵
            //#region 元任务冲突关系矩阵
            //int MaxConNum = 0;//最大冲突元任务个数
            //for (int t = 0; t < UavRTFIDlist.Count; t++)//遍历无人机资源
            //{
            //    if (MaxConNum < UavRTFIDlist[t].ConflictTaskFID.Count)
            //    { MaxConNum = UavRTFIDlist[t].ConflictTaskFID.Count; }
            //}
            //for (int i = 0; i < ASRTFIDlist.Count; i++)
            //{
            //    if (MaxConNum < ASRTFIDlist[i].ConflictTaskFID.Count)
            //    { MaxConNum = ASRTFIDlist[i].ConflictTaskFID.Count; }
            //}
            //for (int i = 0; i < satRTFIDlist.Count; i++)
            //{
            //    if (MaxConNum < satRTFIDlist[i].ConflictTaskFID.Count)
            //    { MaxConNum = satRTFIDlist[i].ConflictTaskFID.Count; }
            //}
            //ConfliMat = new MWNumericArray(MWArrayComplexity.Real, ResouceNumber, MaxConNum * 2 + 1);
            ////以上是定义矩阵大小


            //for (int t = 0; t < UavRTFIDlist.Count; t++)//遍历无人机资源
            //{
            //    int UavFid = UavRTFIDlist[t].RFID;//当前资源FID
            //    ConfliMat[UavFid + 1, 1] = UavRTFIDlist[t].ConflictTaskFID.Count * 2;//第一列是冲突元任务的个数
            //    List<ConflictTFID> ConfiTFIDlist = UavRTFIDlist[t].ConflictTaskFID;//当前资源下的 元任务冲突列表
            //    for (int e = 0; e < ConfiTFIDlist.Count; e++)
            //    {
            //        ConfliMat[UavFid + 1, 2 * e + 2] = ConfiTFIDlist[e].firstTFID;//冲突元任务的第一个
            //        ConfliMat[UavFid + 1, 2 * e + 3] = ConfiTFIDlist[e].secondTFID;//冲突元任务的第二个
            //    }

            //}
            ////飞艇
            //for (int i = 0; i < ASRTFIDlist.Count; i++)
            //{
            //    int ASrFid = ASRTFIDlist[i].RFID;//资源fid
            //    ConfliMat[UavRTFIDlist.Count + ASrFid + 1, 1] = ASRTFIDlist[i].ConflictTaskFID.Count * 2;//第一列是冲突元任务的个数
            //    List<ConflictTFID> asConfiTFidlist = ASRTFIDlist[i].ConflictTaskFID;
            //    for (int j = 0; j < asConfiTFidlist.Count; j++)
            //    {
            //        ConfliMat[UavRTFIDlist.Count + ASrFid + 1, 2 * j + 2] = asConfiTFidlist[j].firstTFID;//冲突元任务的第一个
            //        ConfliMat[UavRTFIDlist.Count + ASrFid + 1, 2 * j + 3] = asConfiTFidlist[j].secondTFID;//冲突元任务的第二个

            //    }
            //}
            ////卫星
            //int FirstElementTFID = -1;
            //int SecondElementTFID = -1;
            //for (int i = 0; i < satRTFIDlist.Count; i++)
            //{
            //    int satRFid = satRTFIDlist[i].RFID;//资源fid
            //    int FirSatTfid;
            //    int SecSatTfid;
            //    ConfliMat[UavRTFIDlist.Count + ASRTFIDlist.Count + satRFid + 1, 1] = satRTFIDlist[i].ConflictTaskFID.Count * 2;//第一列是冲突元任务的个数
            //    List<ConflictTFID> satConfiTFidlist = satRTFIDlist[i].ConflictTaskFID;//卫星观测子任务冲突 fid
            //    for (int j = 0; j < satConfiTFidlist.Count; j++)
            //    {
            //        FirSatTfid = satConfiTFidlist[j].firstTFID;//冲突子任务fid
            //        SecSatTfid = satConfiTFidlist[j].secondTFID;
            //        //根据子任务确定元任务
            //        for (int t = 0; t < SatTElementT.Count; t++)
            //        {
            //            if (FirSatTfid == SatTElementT[t].SatTFID)
            //            {
            //                FirstElementTFID = SatTElementT[t].ElementTaskFID[0];//只需获取冲突子任务包含的第一个元任务即可
            //            }
            //            else if (SecSatTfid == SatTElementT[t].SatTFID)
            //            {
            //                SecondElementTFID = SatTElementT[t].ElementTaskFID[0];
            //            }

            //        }
            //        ConfliMat[UavRTFIDlist.Count + ASRTFIDlist.Count + satRFid + 1, 2 * j + 2] = FirstElementTFID;//冲突元任务的第一个
            //        ConfliMat[UavRTFIDlist.Count + ASRTFIDlist.Count + satRFid + 1, 2 * j + 3] = SecondElementTFID;//冲突元任务的第二个

            //    }
            //}
            //#endregion


            //MWArray ReturnMwa = ReturnMat;
            //MWArray OritoEleMwa = OritoEleMat;
            //MWArray ConfliMwa = ConfliMat;
            //MWArray UavNoMwa = UavRTFIDlist.Count;
            //MWArray ASNoMwa = ASRTFIDlist.Count;


            ////MWArray aab = te.testfunc(paraF, paraS);
            //try
            //{
            //    //object resultObj = PlanAll.VSAllocation(2, ReturnMwa, OritoEleMwa, ConfliMwa, UavNoMwa, ASNoMwa);// 2 表示返回的结果数量，要小于等于matlab对应函数实际的返回值数量
            //    //object[] resultObjs = (object[])resultObj;

            //    //double[,] AllocationPlan = (double[,])resultObjs[0];
            //    //double[,] MaxR = (double[,])resultObjs[1];
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
            #endregion

            #region 测试收益和 已注释
            //测试无人机收益和 是否与 lsttaskFC中 sum一致
            //double uavRsum = 0;
            //for (int i = 0; i < UavRTFIDlist.Count; i++)
            //{
            //    for (int j = 0; j < UavRTFIDlist[i].Returns.Count; j++)
            //    {
            //        uavRsum = uavRsum + UavRTFIDlist[i].Returns[j];
            //    }
            //}
            //double uaR=0;
            //for (int i = 0; i < lstTaskFC.Count; i++)
            //{
            //    uaR = uaR + lstTaskFC[i].UAVReturns;
            //}
            //if (uavRsum == uaR)
            //{ }

            ////测试卫星收益和 是否与 lsttaskFC中 sum一致
            //double satRsum = 0;
            //for (int i = 0; i < satRTFIDlist.Count; i++)
            //{
            //    for (int j = 0; j < satRTFIDlist[i].Returns.Count; j++)
            //    {
            //        satRsum = satRsum + satRTFIDlist[i].Returns[j];
            //    }
            //}
            //double satR = 0;
            //for (int i = 0; i < lstTaskFC.Count; i++)
            //{
            //    satR = satR + lstTaskFC[i].SatReturns;
            //}
            //if (satRsum == satR)
            //{ }
            #endregion


            //将收益输出成txt 或excel 在matlab中求解
            //建立Excel对象
            //Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            //excel.Application.Workbooks.Add(true);
            //excel.Visible = true; // isShowExcle;//是否打开该Excel文件
            //填充数据

        }
        #endregion

        #region 面积优先分配
        public static void AreaFirst(int satLayNO, int satAttribute, int UAVLayNO, int ASLayNO, int CarLayNO, int PolygonTaskNO, int ContrastPlan, TextBox textbox)
        {
            //ContrastPlan是对比方案 0：面积优先  1：权重优先 2：面积*权重优先

            string tStart = "0700";//开始观测时间 格式4位数 前两位小时 后两位分钟
            //int satNo=2;//卫星个数
            int SThour;//开始观测时间 小时
            int STmin;//开始观测时间 分钟
            if (tStart.Length > 3)
            {
                SThour = int.Parse(tStart.Substring(0, 2));//开始观测时间 小时        
            }
            else
            {
                SThour = int.Parse(tStart.Substring(0, 1));//开始观测时间 小时
            }
            STmin = int.Parse(tStart.Substring(tStart.Length - 2, 2));//开始观测时间 分钟
            //double conRadixi = 0.7;//半径折损系数 与数据属性表中半径属性一致
            IMapLayers mapLayers = Program.myMap.Map as IMapLayers;//IFeatureLayer pFeatureLayer;
            ILayer layer;
            ILayer ASlayer;//飞艇图层
            IList<R_TInfo> RTinfoList = new List<R_TInfo>();//存储每一个无人机和任务id初步筛选匹配结果
            DeleteFolder(System.AppDomain.CurrentDomain.BaseDirectory + "Data\\cache");//删除cache下所有文件  
            //卫星 无人机 飞艇 测量车覆盖面路径（缓冲区路径）
            layer = mapLayers.get_Layer(UAVLayNO);
            ASlayer = mapLayers.get_Layer(ASLayNO);
            ILayer CarLayer = mapLayers.get_Layer(CarLayNO);
            IFeatureLayer CarFeatureLayer = CarLayer as IFeatureLayer;
            IFeatureLayer ASfeatureLayer = ASlayer as IFeatureLayer;
            ILayer satLayer = mapLayers.get_Layer(satLayNO);//SatElementTask 图层
            IFeatureLayer SatFeLayer = satLayer as IFeatureLayer;
            ILayer satAtributeLayer = mapLayers.get_Layer(satAttribute);//主要使用卫星的各种属性 后期可从sql数据库中获取 SateliteLine图层
            IFeatureLayer SatAtrriFeLayer = satAtributeLayer as IFeatureLayer;
            IFeatureLayer ptaskFeatureLayer = (IFeatureLayer)mapLayers.get_Layer(PolygonTaskNO);
            IFeatureLayer UAVFeatureLayer = (IFeatureLayer)layer;//无人机图层
            //ILayer CarToTaskLineLayer = mapLayers.get_Layer(CarToTaskLineNo);
            //----------------------------------------------------调用本文分解方法----------------------------------------------------------------------------------------------------
            IFeatureLayer subTaskLayer;//最终元任务图层 subTaskLayer 元任务集 "UToTaUni.shp"
            List<RTsubTInfo> lstTaskFC;////输出元任务对应关系
            List<RTFeatureInfo> lstFC;//资源相对任务的观测区域 子任务
            List<R_TInfo> SattoTaskFIDlist;//sat相对于任务的FID 以便为条带命名 卫星资源FID  源任务FID 子任务FID
            ElementTask(Program.myMap.Map, layer, UAVFeatureLayer, CarFeatureLayer, mapLayers, ptaskFeatureLayer, RTinfoList, SThour, STmin, tStart, ASfeatureLayer, SatFeLayer, out  subTaskLayer, out lstTaskFC, out lstFC, out SattoTaskFIDlist);

            //分配原则：面积优先 按照卫星-无人机-飞艇-车顺序分配

            int SatCount = SatAtrriFeLayer.FeatureClass.FeatureCount(null);//卫星个数
            int UavCount = UAVFeatureLayer.FeatureClass.FeatureCount(null);//无人机个数
            int AsCount = ASfeatureLayer.FeatureClass.FeatureCount(null);//飞艇个数
            List<RtoEleT_FID> SattoEleT = new List<RtoEleT_FID>();//每一个卫星实际观测的子任务FID  list列表示卫星fid

            //先确定卫星观测子任务（SattoTaskFIDlist）satRTFIDlist，然后根据子任务和元任务的对应关系排除已观测元任务 SatTElementT，再将剩余元任务分配到其他资源
            //IFeatureLayer satAtributeFL = SatAtrriFeLayer; //SateliteLine

            #region 根据卫星冲突判断 确定卫星最终观测的子任务
            List<RT_FID> satRTFIDlist;//卫星FID 及此卫星能够观测的子任务集FIDlist ,以及元任务发生冲突的list
            SatConflic(satAtributeLayer, SatAtrriFeLayer, SattoTaskFIDlist, SatFeLayer, out satRTFIDlist);//卫星冲突判断
            for (int i = 0; i < satRTFIDlist.Count; i++)//遍历卫星
            {
                List<int> SubTfid = satRTFIDlist[i].subTaskFID;//当前卫星能够观测的子任务
                List<int> SatSubTsort;
                SubTsort(SubTfid, SatFeLayer, 3, 6, ContrastPlan, out SatSubTsort);//将当前卫星能够观测的子任务按照面积大小进行排序以保证面积优先（可修改为权重）☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆

                List<int> SingleSatSubT = new List<int>();//单个卫星确认实际观测的子任务fid集
                List<ConflictTFID> ConfliSubT = satRTFIDlist[i].ConflictTaskFID;//当前卫星观测子任务中发生冲突的集合对
                for (int j = 0; j < SatSubTsort.Count; j++)//遍历当前卫星可观测的子任务
                {
                    int EleTfid = SatSubTsort[j];//当前子任务FID

                    if (SingleSatSubT.Count != 0)//当前卫星已有确定的观测目标 则需要判断已确定目标与当前子任务是否冲突
                    {
                        // List<int> SatEleT = SattoEleT[i].EleTaskFID;//获取当前卫星已经确定观测的子任务集
                        if (SattoSubT(SingleSatSubT, EleTfid, ConfliSubT))//如果不冲突 返回ture 则将当前子任务添加到确定观测列表
                        {

                            SingleSatSubT.Add(EleTfid);//将当前元任务添加到此卫星的最终观测列表
                            continue;
                        }
                    }
                    else//当前卫星还没有已确定的观测子任务 则直接添加
                    {
                        SingleSatSubT.Add(EleTfid);//将当前元任务添加到此卫星的最终观测列表
                        continue;//判断下一个子任务
                    }
                }
                RtoEleT_FID flagStoT = new RtoEleT_FID() { RFID = i, EleTaskFID = SingleSatSubT };
                SattoEleT.Add(flagStoT);
            }
            #endregion
            List<RTsubTInfo> AreaLstTaskFC = new List<RTsubTInfo>(lstTaskFC);
            #region 根据子任务和元任务的对应关系排除已观测元任务
            //根据子任务和元任务的对应关系排除已观测元任务 SattoEleT
            List<Sat_ElementTFID> SatTElementT;//存储每一个卫星观测子任务与能够覆盖的元任务的FID对应关系
            SatSubTtoEleT(SatFeLayer, subTaskLayer, out SatTElementT);
            //删除卫星确定观测子任务对应的元任务
            List<int> satSubT = new List<int>();//所有卫星确定观测的子任务集
            for (int i = 0; i < SattoEleT.Count; i++)//遍历卫星
            {
                satSubT = satSubT.Union(SattoEleT[i].EleTaskFID).ToList<int>();//合并当前卫星确定观测的子任务集                 
            }
            //根据确定观测子任务集和对应关系筛选 所有已确定被卫星观测的元任务集
            List<int> SatSuretoEleT = new List<int>();//所有卫星确定观测的元任务集（子任务对应关系得到）
            for (int i = 0; i < SatTElementT.Count; i++)
            {
                for (int j = 0; j < satSubT.Count; j++)
                {
                    if (SatTElementT[i].SatTFID == satSubT[j])
                    {
                        SatSuretoEleT = SatSuretoEleT.Union(SatTElementT[i].ElementTaskFID).ToList<int>();
                    }
                }
            }

            //删除卫星确定观测子任务对应的元任务
            for (int i = AreaLstTaskFC.Count - 1; i >= 0; i--)
            {
                if (SatSuretoEleT.Contains(int.Parse(AreaLstTaskFC[i].subTFID)))
                {
                    AreaLstTaskFC.RemoveAt(i);
                }

            }
            #endregion

            //将已经移除卫星观测的元任务按照指定规则排序（从大到小）降序☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
            if (ContrastPlan == 0)//按照面积排序
            {
                AreaLstTaskFC.Sort(new Comparison<RTsubTInfo>((RTsubTInfo s1, RTsubTInfo s2) => { return (int)(s2.subTArea * 100000 - s1.subTArea * 100000); }));//按照面积降序排列
            }
            else if (ContrastPlan == 1)//按照权重排序
            {
                AreaLstTaskFC.Sort(new Comparison<RTsubTInfo>((RTsubTInfo s1, RTsubTInfo s2) => { return (int)(s2.subTWeight * 100000 - s1.subTWeight * 100000); }));
            }
            else//按照面积*权重排序
            {
                AreaLstTaskFC.Sort(new Comparison<RTsubTInfo>(new MyComparator().compare));//
            }



            //将剩余元任务按照无人机 飞艇 车的顺序分配按照面积大小分配
            #region 将元任务转为点目标  飞艇中冲突判断求距离用到
            string ConflictTPOint = System.AppDomain.CurrentDomain.BaseDirectory + "Data\\cache\\" + "EleDis.shp";
            GPFeatureToPointTool(subTaskLayer, ConflictTPOint); //将元任务转为点目标 以便求距离
            IFeatureLayer EleTPointFL = OpenFile_LayerFile(ConflictTPOint);
            #endregion
            List<RtoEleT> UavtoEleT = new List<RtoEleT>();//UAV实际观测的元任务任务FID 对应关系
            List<RtoEleT> AstoEleT = new List<RtoEleT>();//AS实际观测的元任务FID.
            List<RtoEleT> CartoEleT = new List<RtoEleT>();//car实际观测的元任务FID
            #region 剩余元任务分配给UAV AS
            for (int i = 0; i < AreaLstTaskFC.Count; i++)//元任务遍历
            {
                int para = 0;//标志 是否完成
                int EleTfid = int.Parse(AreaLstTaskFC[i].subTFID);//当前元任务FID
                List<int> UavFidlist = AreaLstTaskFC[i].UAVFID;//获取当前元任务的可观测UAV
                List<int> AsFidlist = AreaLstTaskFC[i].ASFID;//获取当前元任务的可观测AS
                List<int> CarFidlist = AreaLstTaskFC[i].CarFID;//获取当前元任务的可观测car
                if (UavFidlist.Count != 0)//有无人机可以观测
                {
                    for (int j = 0; j < UavFidlist.Count; j++)//遍历可以观测到此元任务的UAV
                    {
                        int Uavfid = UavFidlist[j];//当前无人机fid
                        if (UavtoEleT.Count != 0)//如果UAV实际观测的元任务列表不为空 则判断里面是否包含当前无人机 
                        {
                            List<int> SingleUavToEleT = new List<int>();//当前无人机已经确定观测的元任务列表
                            for (int k = 0; k < UavtoEleT.Count; k++)
                            {
                                if (UavtoEleT[k].ResouceFID == Uavfid)//如果UAV实际观测的元任务列表包含当前无人机
                                {
                                    SingleUavToEleT.Add(UavtoEleT[k].TaskFID);
                                }
                            }
                            if (SingleUavToEleT.Count != 0)//如果当前无人机已经有确定观测的元任务
                            {
                                if (UAVtoSubT(SingleUavToEleT, EleTfid, Uavfid, ptaskFeatureLayer, lstTaskFC, lstFC))
                                {
                                    RtoEleT flagRtoElet = new RtoEleT() { ResouceFID = Uavfid, TaskFID = EleTfid };
                                    UavtoEleT.Add(flagRtoElet);
                                    para = 1;
                                    break;
                                }
                            }
                            else//当前无人机没有确定观测的元任务 则直接将此元任务加进列表
                            {
                                RtoEleT flagRtoElet = new RtoEleT() { ResouceFID = Uavfid, TaskFID = EleTfid };
                                UavtoEleT.Add(flagRtoElet);
                                para = 1;
                                break;
                            }
                        }
                        else//如果UAV实际观测的元任务列表为空（第一个） 则直接将此元任务加进列表
                        {
                            RtoEleT flagRtoElet = new RtoEleT() { ResouceFID = Uavfid, TaskFID = EleTfid };
                            UavtoEleT.Add(flagRtoElet);
                            para = 1;
                            break;
                        }

                        //List<int> SatEleT = SattoEleT[SatFid[j]].EleTaskFID;//获取当前卫星已经确定观测的元任务集


                    }
                    if (para == 1)
                        continue;//如果当前元任务已判断完毕 则进行下一个元任务的判断

                }
                if (AsFidlist.Count != 0)//没有无人机可以观测 但是有飞艇可以观测
                {
                    for (int j = 0; j < AsFidlist.Count; j++)//遍历可以观测到此元任务的AS
                    {
                        int ASfid = AsFidlist[j];//当前飞艇fid
                        if (AstoEleT.Count != 0)//如果AS实际观测的元任务列表不为空 则判断里面是否包含当前飞艇 
                        {
                            List<int> SingleASToEleT = new List<int>();//当前飞艇已经确定观测的元任务列表
                            for (int k = 0; k < AstoEleT.Count; k++)
                            {
                                if (AstoEleT[k].ResouceFID == ASfid)//如果AS实际观测的元任务列表包含当前AS
                                {
                                    SingleASToEleT.Add(AstoEleT[k].TaskFID);
                                }
                            }
                            if (SingleASToEleT.Count != 0)//如果当前AS已经有确定观测的元任务
                            {
                                if (AStoSubT(SingleASToEleT, EleTfid, ASfid, ptaskFeatureLayer, lstTaskFC, lstFC, EleTPointFL, ASfeatureLayer))
                                {
                                    RtoEleT flagRtoElet = new RtoEleT() { ResouceFID = ASfid, TaskFID = EleTfid };
                                    AstoEleT.Add(flagRtoElet);
                                    para = 1;
                                    break;
                                }
                            }
                            else//当前AS没有确定观测的元任务 则直接将此元任务加进列表
                            {
                                RtoEleT flagRtoElet = new RtoEleT() { ResouceFID = ASfid, TaskFID = EleTfid };
                                AstoEleT.Add(flagRtoElet);
                                para = 1;
                                break;
                            }



                        }
                        else//如果AS实际观测的元任务列表为空（第一个） 则直接将此元任务加进列表
                        {
                            RtoEleT flagRtoElet = new RtoEleT() { ResouceFID = ASfid, TaskFID = EleTfid };
                            AstoEleT.Add(flagRtoElet);
                            para = 1;
                            break;
                        }
                    }
                    if (para == 1)
                    { continue; }
                }
                if (CarFidlist.Count != 0)//有车可以观测
                {
                    for (int j = 0; j < CarFidlist.Count; j++)//遍历可以观测到此元任务的car
                    {
                        int Carfid = CarFidlist[j];//当前car fid
                        if (CartoEleT.Count != 0)//如果car实际观测的元任务列表不为空 则判断里面是否包含当前car 
                        {
                            List<int> SingleCarToEleT = new List<int>();//当前car已经确定观测的元任务列表
                            for (int k = 0; k < CartoEleT.Count; k++)
                            {
                                if (CartoEleT[k].ResouceFID == Carfid)//如果car实际观测的元任务列表包含当前car
                                {
                                    SingleCarToEleT.Add(CartoEleT[k].TaskFID);
                                }
                            }
                            if (SingleCarToEleT.Count != 0)//如果当前car已经有确定观测的元任务
                            {
                                if (CartoSubT(SingleCarToEleT, EleTfid, Carfid, ptaskFeatureLayer, lstTaskFC, lstFC, EleTPointFL, CarFeatureLayer))
                                {
                                    RtoEleT flagRtoElet = new RtoEleT() { ResouceFID = Carfid, TaskFID = EleTfid };
                                    CartoEleT.Add(flagRtoElet);
                                    break;
                                }
                            }
                            else//当前car没有确定观测的元任务 则直接将此元任务加进列表
                            {
                                RtoEleT flagRtoElet = new RtoEleT() { ResouceFID = Carfid, TaskFID = EleTfid };
                                CartoEleT.Add(flagRtoElet);
                                break;
                            }



                        }
                        else//如果car实际观测的元任务列表为空（第一个） 则直接将此元任务加进列表
                        {
                            RtoEleT flagRtoElet = new RtoEleT() { ResouceFID = Carfid, TaskFID = EleTfid };
                            CartoEleT.Add(flagRtoElet);
                            break;
                        }
                    }
                }
            }
            #endregion


            //属性表添加字段
            //定义新字段
            IField pField = new FieldClass();
            //字段编辑
            IFieldEdit pFieldEdit = pField as IFieldEdit;
            //新建字段名
            pFieldEdit.Name_2 = "Plan" + ContrastPlan;//为了区别不同对比方案
            pFieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
            subTaskLayer.FeatureClass.AddField(pField);//添加字段
            //卫星规划结果显示
            for (int i = 0; i < SatSuretoEleT.Count; i++)//SatSuretoEleT：所有卫星确定观测的元任务集合
            {
                int satEleTfid = SatSuretoEleT[i];//当前确定观测的元任务fid
                IFeature pfeature = subTaskLayer.FeatureClass.GetFeature(satEleTfid);//获取当前元任务要素
                pfeature.set_Value(subTaskLayer.FeatureClass.Fields.FindField("Plan" + ContrastPlan), "sat");//设值
                pfeature.Store();
            }
            //UAV AS规划结果显示
            for (int i = 0; i < UavtoEleT.Count; i++)//UAV
            {
                IFeature pfeature = subTaskLayer.FeatureClass.GetFeature(UavtoEleT[i].TaskFID);//获取当前元任务要素
                pfeature.set_Value(subTaskLayer.FeatureClass.Fields.FindField("Plan" + ContrastPlan), "UAV" + UavtoEleT[i].ResouceFID);//设值
                pfeature.Store();
            }
            for (int i = 0; i < AstoEleT.Count; i++)//AS
            {
                IFeature pfeature = subTaskLayer.FeatureClass.GetFeature(AstoEleT[i].TaskFID);//获取当前元任务要素
                pfeature.set_Value(subTaskLayer.FeatureClass.Fields.FindField("Plan" + ContrastPlan), "AS" + AstoEleT[i].ResouceFID);//设值
                pfeature.Store();
            }
            for (int i = 0; i < CartoEleT.Count; i++)//AS
            {
                IFeature pfeature = subTaskLayer.FeatureClass.GetFeature(CartoEleT[i].TaskFID);//获取当前元任务要素
                pfeature.set_Value(subTaskLayer.FeatureClass.Fields.FindField("Plan" + ContrastPlan), "Car" + CartoEleT[i].ResouceFID);//设值
                pfeature.Store();
            }

            //计算无人机、飞艇 （资源观测面积/资源性能）的方差 以表示均衡度  UAV AS分别求，然后取平均（a+b）/2
            //double[] UavResouce = new double[UavCount];//能观测的元任务面积和 行表示无人机资源序号 
            //double[] ASResouce = new double[AsCount];//能观测的元任务面积和 行表示AS资源序号 


            //计算并输出可观测的元任务总面积、加权面积、任务完成率（加权面积占比）
            double SureArea = 0;//观测总面积
            double SureWeiArea = 0;//观测总加权面积
            double AllWeiArea = 0;//所有元任务总加权面积  为了求比率
            double AllArea = 0;//所有元任务总面积
            int FinishT = 0;//完成元任务个数
            for (int i = 0; i < lstTaskFC.Count; i++)
            {
                int HaveObe = 0;//是否已经被观测 临时值
                for (int j = 0; j < SatSuretoEleT.Count; j++)
                {
                    if (lstTaskFC[i].subTFID == SatSuretoEleT[j].ToString())
                    {
                        SureArea = SureArea + lstTaskFC[i].subTArea;
                        SureWeiArea = SureWeiArea + lstTaskFC[i].subTArea * lstTaskFC[i].subTWeight;
                        HaveObe = 1;
                        break;
                    }
                }
                if (HaveObe == 0)//如果此元任务没有被卫星观测
                {
                    for (int j = 0; j < UavtoEleT.Count; j++)
                    {
                        if (lstTaskFC[i].subTFID == UavtoEleT[j].TaskFID.ToString())
                        {
                            SureArea = SureArea + lstTaskFC[i].subTArea;
                            SureWeiArea = SureWeiArea + lstTaskFC[i].subTArea * lstTaskFC[i].subTWeight;
                            //UavResouce[UavtoEleT[j].ResouceFID] = UavResouce[UavtoEleT[j].ResouceFID] + lstTaskFC[i].subTArea;
                            HaveObe = 1;
                            break;
                        }
                    }
                }
                if (HaveObe == 0)//如果此元任务没有被卫星、UAV观测
                {
                    for (int j = 0; j < AstoEleT.Count; j++)
                    {
                        if (lstTaskFC[i].subTFID == AstoEleT[j].TaskFID.ToString())
                        {
                            SureArea = SureArea + lstTaskFC[i].subTArea;
                            SureWeiArea = SureWeiArea + lstTaskFC[i].subTArea * lstTaskFC[i].subTWeight;
                            //ASResouce[AstoEleT[j].ResouceFID] = ASResouce[AstoEleT[j].ResouceFID] + lstTaskFC[i].subTArea;
                            HaveObe = 1;
                            break;
                        }
                    }
                }
                if (HaveObe == 0)//如果此元任务没有被卫星、UAV AS观测
                {
                    for (int j = 0; j < CartoEleT.Count; j++)
                    {
                        if (lstTaskFC[i].subTFID == CartoEleT[j].TaskFID.ToString())
                        {
                            SureArea = SureArea + lstTaskFC[i].subTArea;
                            SureWeiArea = SureWeiArea + lstTaskFC[i].subTArea * lstTaskFC[i].subTWeight;
                            //ASResouce[AstoEleT[j].ResouceFID] = ASResouce[AstoEleT[j].ResouceFID] + lstTaskFC[i].subTArea;
                            HaveObe = 1;
                            break;
                        }
                    }
                }
                if (HaveObe == 1)//如果此元任务可以被观测
                { FinishT = FinishT + 1; }
                AllWeiArea = AllWeiArea + lstTaskFC[i].subTArea * lstTaskFC[i].subTWeight;
                AllArea = AllArea + lstTaskFC[i].subTArea;
            }



            //double stdDevUav = CalculateStdDev(UavResouce);
            //double stdDevAs = CalculateStdDev(ASResouce);

            double FinishRad = SureWeiArea / AllWeiArea;
            double FinishAreaRate = SureArea / AllArea;
            textbox.Text = "加权面积比：" + FinishRad + "\r\n" + "面积比：" + FinishAreaRate + "\r\n" + "完成元任务个数：" + FinishT + "/" + lstTaskFC.Count; //"Uav标准差：" + stdDevUav + "\r\n" + "AS标准差：" + stdDevAs + "\r\n" + "平均标准差：" + (stdDevUav + stdDevAs) / 2;

        }
        #endregion

        #region 网格分解 规划
        /// <summary>
        /// 按照网格分解
        /// </summary>
        /// <param name="satLayNO"></param>
        /// <param name="satAttribute"></param>
        /// <param name="UAVLayNO"></param>
        /// <param name="ASLayNO"></param>
        /// <param name="CarLayNO"></param>
        /// <param name="PolygonTaskNO"></param>
        public static void GridTaskDis(int satLayNO, int satAttribute, int UAVLayNO, int ASLayNO, int CarLayNO, int PolygonTaskNO, ProgressBar proBar)
        {
            string ResearchArea = "BaiCity";//研究区域图层名 此图层作为划分网格的底图   BaiCity Akesu
            double flagM = 0.8;//续航里程衰减参数 控制可观测范围
            double tR = 0.7; //tR假设tR%时间用来观测 用于控制资源负载度
            double GridLength = 500;//网格大小 m
            double fi;//收益参数
            double fi2;
            double alpha = 0.5;//收益参数 阿尔法
            double beta = 1 - alpha;//贝塔
            string tStart = "0700";//开始观测时间 格式4位数 前两位小时 后两位分钟
            int SThour;
            int STmin;
            if (tStart.Length > 3)
            {
                SThour = int.Parse(tStart.Substring(0, 2));//开始观测时间 小时        
            }
            else
            {
                SThour = int.Parse(tStart.Substring(0, 1));//开始观测时间 小时
            }
            STmin = int.Parse(tStart.Substring(tStart.Length - 2, 2));//开始观测时间 分钟


            IMapLayers CurrentMapLayers = Program.myMap.Map as IMapLayers;//IFeatureLayer pFeatureLayer;
            ILayer UAVilayer = CurrentMapLayers.get_Layer(UAVLayNO);//无人机图层
            IFeatureLayer UavFL = (FeatureLayer)UAVilayer;
            ILayer ASilayer = CurrentMapLayers.get_Layer(ASLayNO);//飞艇图层   
            IFeatureLayer ASFL = (FeatureLayer)ASilayer;
            ILayer SatTaskiLayer = CurrentMapLayers.get_Layer(satLayNO);//SatElementTask 图层
            IFeatureLayer SatFL = (FeatureLayer)SatTaskiLayer;
            ILayer CarLayer = CurrentMapLayers.get_Layer(CarLayNO);//车辆图层
            IFeatureLayer CarFeatureLayer = CarLayer as IFeatureLayer;


            ILayer SatAtributeiLayer = CurrentMapLayers.get_Layer(satAttribute);//主要使用卫星的各种属性 后期可从sql数据库中获取 SateliteLine图层
            IFeatureLayer ptaskFeatureLayer = (IFeatureLayer)CurrentMapLayers.get_Layer(PolygonTaskNO);
            DeleteFolder(System.AppDomain.CurrentDomain.BaseDirectory + "Data\\CacheGrid");//删除CacheGrid下所有文件  
            string GridPath = System.AppDomain.CurrentDomain.BaseDirectory + "Data\\CacheGrid\\" + "Gird.shp";
            //string distan = UAVFeatureLayer.FeatureClass.Fields.get_Field(6).Name.ToString();//获取续航半径字段 第6个字段 最大半径为航程一半
            ILayer akesulayer = PRV_GetLayersByName(ResearchArea);
            IFeatureLayer ss = akesulayer as FeatureLayer;
            IFeature Akesu = ss.FeatureClass.GetFeature(0) as IFeature;
            GPCreatFishnetTool(Akesu, GridPath, GridLength);
            IFeatureLayer GridFL = OpenFile_LayerFile(GridPath);
            string GridTaskPath = System.AppDomain.CurrentDomain.BaseDirectory + "Data\\CacheGrid\\" + "GirdTask.shp";
            GPIntersectTool(GridFL.FeatureClass, ptaskFeatureLayer.FeatureClass, GridTaskPath);//考虑用空间关系选择 而不是切割
            IFeatureLayer GridTaskFL = OpenFile_LayerFile(GridTaskPath);//网格元任务  
            //时间进度条 网格元任务对应关系 属性信息 即元任务多元组
            proBar.Maximum = GridTaskFL.FeatureClass.FeatureCount(null);
            proBar.Value = 0;
            //Program.SetProgreeMax(GridTaskFL.FeatureClass.FeatureCount(null));
            int GridEleTNO = 0;//第几个网格元任务 为时间进度条服务

            #region 对应关系 元任务属性 即GridlstTaskFC
            //对应关系 元任务属性 即lsttaskFC 
            //将网格转成点  求网格点到无人机/飞艇的质心距离 如果质心距离满足时间、航程约束 则可以被观测
            List<RTsubTInfo> GridlstTaskFC = new List<RTsubTInfo>();//★★★★★★★★★★★★★★★★存储网格元任务对应关系

            IQueryFilter GridpFilter = new QueryFilter();//实例化一个查询条件对象 
            GridpFilter.WhereClause = "FID >= 0";//将查询条件赋值     选择所有的子任务
            IFeatureCursor GridEleTaskfeatureCursor = GridTaskFL.Search(GridpFilter, false);// GridTaskFL为grid元任务
            IFeature GridEleTaskFeature = GridEleTaskfeatureCursor.NextFeature();//遍历查询结果  子任务
            string GridOriTFID = "-1";//原任务FID
            while (GridEleTaskFeature != null)
            {
                double subTweight = 0;//当前子任务所属原任务的权重
                string subTWinS = "";//当前子任务所属原任务的开始时间
                string subTWinE = "";//当前子任务所属原任务的结束时间
                ISpatialFilter GridpContainFilter = new SpatialFilterClass();
                GridpContainFilter.Geometry = GridEleTaskFeature.Shape;
                GridpContainFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;//空间关系选择条件 用相交选择该子任务的原始任务
                IFeatureCursor OriTaskfeatureCursor = ptaskFeatureLayer.FeatureClass.Search(GridpContainFilter, false);//ptaskFeatureLayer是源任务
                IFeature OriTaskTFeature = OriTaskfeatureCursor.NextFeature();//查询与子任务相交的原任务区
                while (OriTaskTFeature != null)//有且仅有一个与子任务相交的原任务区
                {

                    GridOriTFID = OriTaskTFeature.get_Value(0).ToString();//当前子任务所属原任务的FID  
                    subTweight = double.Parse(OriTaskTFeature.get_Value(9).ToString());//当前子任务所属原任务的权重
                    subTWinS = OriTaskTFeature.get_Value(4).ToString();//当前子任务所属原任务的开始时间
                    subTWinE = OriTaskTFeature.get_Value(5).ToString();//当前子任务所属原任务的结束时间

                    OriTaskTFeature = OriTaskfeatureCursor.NextFeature();
                }
                string singleGirdT = System.AppDomain.CurrentDomain.BaseDirectory + "Data\\CacheGrid\\" + "SGridT.shp";
                GPselectTool(GridTaskFL, singleGirdT, "FID=", int.Parse(GridEleTaskFeature.get_Value(0).ToString()));//选出单个Grid元任务 当前
                IFeatureLayer singleGirdTFL = OpenFile_LayerFile(singleGirdT);
                string gridTaskToPointPath = System.AppDomain.CurrentDomain.BaseDirectory + "Data\\CacheGrid\\" + "GridTToPo.shp";//将当前网格元任务区域转成点目标，为了求无人机基站到质心距离  
                GPFeatureToPointTool(singleGirdTFL, gridTaskToPointPath);//将当前网格元任务区域转成点目标
                IFeatureLayer GirdPointFeatureLayer = OpenFile_LayerFile(gridTaskToPointPath);
                IPoint singleGirdTpoint = GirdPointFeatureLayer.FeatureClass.GetFeature(0).Shape as IPoint;//
                int TWEhour;//任务结束时间 小时
                int TWEmin;//任务结束时间 分钟

                #region 确定时间
                //确定时间

                if (subTWinE.Length > 3)
                {
                    TWEhour = int.Parse(subTWinE.Substring(0, 2));//任务结束时间 小时                 
                }
                else
                {
                    TWEhour = int.Parse(subTWinE.Substring(0, 1));//任务结束时间 小时
                }
                TWEmin = int.Parse(subTWinE.Substring(subTWinE.Length - 2, 2));//任务结束时间 分钟 

                #endregion

                #region 无人机FID确定
                //无人机 求网格点到无人机/飞艇的质心距离 如果质心距离满足时间、航程约束 则可以被观测
                List<int> ReUAVID = new List<int>();//每一个子任务的无人机资源FID 列表                 
                for (int i = 0; i < UavFL.FeatureClass.FeatureCount(null); i++)
                {
                    //double MaxConObeT = double.Parse(UavEveryFeature.get_Value(9).ToString());//最大连续开机时间 小时

                    IFeature SingleUav = UavFL.FeatureClass.GetFeature(i);//当前无人机                    
                    double Mileage = double.Parse(SingleUav.get_Value(7).ToString());//续航里程
                    Mileage = Mileage * flagM;//
                    double Vuav = double.Parse(SingleUav.get_Value(5).ToString());//巡航速度
                    double UavWidth = double.Parse(SingleUav.get_Value(8).ToString());//无人机幅宽 
                    IPoint UavPoint = SingleUav.Shape as IPoint;//将当前无人机转成的点目标
                    double dcen = Math.Sqrt(Math.Pow(singleGirdTpoint.X - UavPoint.X, 2) + Math.Pow(singleGirdTpoint.Y - UavPoint.Y, 2));//无人机基地到当前元任务的质心距离 米
                    #region 确定时间
                    int STH;
                    int STM;
                    if (subTWinS.Length > 3)
                    {
                        STH = int.Parse(subTWinS.Substring(0, 2));//任务开始时间 小时                 
                    }
                    else
                    {
                        STH = int.Parse(subTWinS.Substring(0, 1));//任务开始时间 小时
                    }
                    STM = int.Parse(subTWinS.Substring(subTWinS.Length - 2, 2));//任务开始时间 分钟 


                    if (STH * 60 + STM > SThour * 60 + STmin)//开始时间取  较大值
                    {
                        double st = STH + (double)STM / 60 - (dcen / 1000 / Vuav);
                        STH = (int)Math.Floor(st);
                        STM = (int)((double)(st - STH) * 60);
                        if (st < (SThour + (double)STmin / 60))
                        {
                            STH = SThour;
                            STM = STmin;
                        }
                    }
                    else
                    {
                        STH = SThour;
                        STM = STmin;
                    }
                    #endregion
                    if (dcen < Mileage / 2 - GridLength)//满足距离约束
                    {
                        double tsee = (GridLength / 1000) * (GridLength / 1000) / Vuav / UavWidth / 1000;//观测时间 h
                        //假设元任务观测不需要时间 时间约束只需满足 时间窗口之内到达即可 (TWEhour * 60 + TWEmin - (STH * 60 + STM) - dcen / 1000 / Vuav * 60) / 60 * Vuav * 1000 * UavWidth
                        if ((TWEhour * 60 + TWEmin - STH * 60 - STM - (dcen / Vuav / 1000) * 60) - tsee * 60 > 0)//满足时间约束
                        {
                            //满足距离约束、时间约束 则任务当前元任务可以被无人机观测
                            ReUAVID.Add(int.Parse(SingleUav.get_Value(0).ToString()));
                        }
                    }

                    //double TLongUToT = (Mileage - 2 * dcen) / 1000 / Vuav; //当前无人机相对于当前任务单次观测最长时间 距离考虑用质心距离统一代替 小时

                }

                #endregion

                #region 飞艇FID确定
                List<int> ReASID = new List<int>();//每一个子任务的飞艇资源FID 列表 

                for (int i = 0; i < ASFL.FeatureClass.FeatureCount(null); i++)
                {
                    IFeature SingleAS = ASFL.FeatureClass.GetFeature(i);//当前飞艇  
                    double ASv = double.Parse(SingleAS.get_Value(5).ToString());//巡航速度//巡航速度
                    double ASWidth = double.Parse(SingleAS.get_Value(7).ToString());//无人机幅宽 
                    IPoint ASPoint = SingleAS.Shape as IPoint;//将当前无人机转成的点目标
                    double dcen = Math.Sqrt(Math.Pow(singleGirdTpoint.X - ASPoint.X, 2) + Math.Pow(singleGirdTpoint.Y - ASPoint.Y, 2));//飞艇到当前元任务的质心距离 米.
                    #region 时间确定
                    int AsSTH;
                    int AsSTM;
                    if (subTWinS.Length > 3)
                    {
                        AsSTH = int.Parse(subTWinS.Substring(0, 2));//任务开始时间 小时                 
                    }
                    else
                    {
                        AsSTH = int.Parse(subTWinS.Substring(0, 1));//任务开始时间 小时
                    }
                    AsSTM = int.Parse(subTWinS.Substring(subTWinS.Length - 2, 2));//任务开始时间 分钟 
                    if ((AsSTH * 60 + AsSTM) > (SThour * 60 + STmin))//开始时间取  较大值
                    {
                        double st = AsSTH + (double)AsSTM / 60 - (dcen / 1000 / ASv);
                        AsSTH = (int)Math.Floor(st);
                        AsSTM = (int)((double)(st - AsSTH) * 60); //(int)(st - AsSTH) * 60;
                        if (st < (SThour + (double)STmin / 60))
                        {
                            AsSTH = SThour;
                            AsSTM = STmin;
                        }
                    }
                    else
                    {
                        AsSTH = SThour;
                        AsSTM = STmin;
                    }
                    #endregion

                    double tsee = (GridLength / 1000) * (GridLength / 1000) / ASv / ASWidth / 1000;//观测时间 h
                    //假设元任务观测不需要时间 时间约束只需满足 时间窗口之内到达即可
                    if ((TWEhour * 60 + TWEmin - AsSTH * 60 - AsSTM - (dcen / ASv / 1000) * 60) - tsee * 60 > 0)//满足时间约束
                    {
                        //满足时间约束 则任务当前元任务可以被AS观测
                        ReASID.Add(int.Parse(SingleAS.get_Value(0).ToString()));
                    }

                }

                #endregion

                #region 车 FID确定
                List<int> ReCarID = new List<int>();//每一个子任务的Car资源FID 列表 

                for (int i = 0; i < CarFeatureLayer.FeatureClass.FeatureCount(null); i++)
                {
                    IFeature SingleCar = CarFeatureLayer.FeatureClass.GetFeature(i);//当前车辆  
                    double CarV = double.Parse(SingleCar.get_Value(5).ToString());//巡航速度//巡航速度
                    double CaroberV = double.Parse(SingleCar.get_Value(8).ToString());//巡航速度//巡航速度
                    double CarWidth = double.Parse(SingleCar.get_Value(6).ToString());//幅宽 
                    double CarMile = double.Parse(SingleCar.get_Value(6).ToString());//里程
                    IPoint CarPoint = SingleCar.Shape as IPoint;//将当前无人机转成的点目标
                    double dcen;//车辆距离当前网格的距离 m

                    #region 车辆距离当前网格的距离确定 m

                    #region 网络设置
                    //几何网络
                    IGeometricNetwork mGeometricNetwork;

                    //获取给定点最近的Network元素
                    IPointToEID mPointToEID = new PointToEIDClass();
                    //获取几何网络文件路径
                    //注意修改此路径为当前存储路径
                    string strPath = System.AppDomain.CurrentDomain.BaseDirectory + "Data\\RoadData.gdb";//+"E:\GIS设计与开发\例子数据\Network\USA_Highway_Network_GDB.mdb";
                    //打开工作空间
                    IWorkspaceFactory pWorkspaceFactory = new ESRI.ArcGIS.DataSourcesGDB.FileGDBWorkspaceFactory();
                    IFeatureWorkspace pFeatureWorkspace = pWorkspaceFactory.OpenFromFile(strPath, 0) as IFeatureWorkspace;
                    //获取要素数据集
                    //注意名称的设置要与上面创建保持一致
                    IFeatureDataset pFeatureDataset = pFeatureWorkspace.OpenFeatureDataset("RaadDataSet");//修改成从xml读取

                    //获取network集合
                    INetworkCollection pNetWorkCollection = pFeatureDataset as INetworkCollection;
                    //获取network的数量,为零时返回
                    int intNetworkCount = pNetWorkCollection.GeometricNetworkCount;
                    if (intNetworkCount < 1)
                    { MessageBox.Show("要素类数量为0！"); }
                    //FeatureDataset可能包含多个network，我们获取指定的network
                    //注意network的名称的设置要与上面创建保持一致
                    mGeometricNetwork = pNetWorkCollection.get_GeometricNetworkByName("RaadDataSet_Net");//修改成从xml读取
                    //设置mPointToEID属性
                    mPointToEID.SourceMap = Program.myMap.Map;
                    mPointToEID.GeometricNetwork = mGeometricNetwork;
                    mPointToEID.SnapTolerance = 200000; //捕捉容差  大于里程的网格捕捉不到？？ 

                    #endregion
                    #region 距离确定

                    IPointCollection mPointCollection = new MultipointClass();//给定点的集合
                    mPointCollection.AddPoint(CarPoint);
                    mPointCollection.AddPoint(singleGirdTpoint);

                    //路径计算
                    IEnumNetEID mEnumNetEID_Junctions;//返回路径的节点
                    IEnumNetEID mEnumNetEID_Edges;//返回路径边
                    double mdblPathCost;//返回总代价（边长 距离）
                    CoScheduling.Core.Map.MapHelper MapHelp = new Core.Map.MapHelper();
                    MapHelp.SolvePath("weight", mGeometricNetwork, mPointCollection, mPointToEID, out  mEnumNetEID_Junctions, out  mEnumNetEID_Edges, out   mdblPathCost);
                    IPolyline ResultLine = MapHelp.PathToPolyLine(Program.myMap.Map, mGeometricNetwork, mEnumNetEID_Edges);//将路径结果转为线
                    if (ResultLine.IsEmpty)
                    { dcen = 9999999999; }
                    else
                    { dcen = ResultLine.Length; }// 米 

                    #endregion
                    #endregion


                    int CarSTH;//任务开始时间 
                    int CarSTM;
                    #region 时间确定
                    if (subTWinS.Length > 3)
                    {
                        CarSTH = int.Parse(subTWinS.Substring(0, 2));//任务开始时间 小时                 
                    }
                    else
                    {
                        CarSTH = int.Parse(subTWinS.Substring(0, 1));//任务开始时间 小时
                    }
                    CarSTM = int.Parse(subTWinS.Substring(subTWinS.Length - 2, 2));//任务开始时间 分钟 
                    if ((CarSTH * 60 + CarSTM) > (SThour * 60 + STmin))//开始时间取  较大值
                    {
                        double st = CarSTH + (double)CarSTM / 60 - (dcen / 1000 / CarV);
                        CarSTH = (int)Math.Floor(st);
                        CarSTM = (int)((double)(st - CarSTH) * 60); //(int)(st - AsSTH) * 60;
                        if (st < (SThour + (double)STmin / 60))
                        {
                            CarSTH = SThour;
                            CarSTM = STmin;
                        }
                    }
                    else
                    {
                        CarSTH = SThour;
                        CarSTM = STmin;
                    }
                    #endregion

                    double tsee = (GridLength / 1000) * (GridLength / 1000) / CaroberV / CarWidth / 1000;//观测时间 h
                    //假设元任务观测不需要时间 时间约束只需满足 时间窗口之内到达即可
                    if (((TWEhour * 60 + TWEmin - CarSTH * 60 - CarSTM - (dcen / CarV / 1000) * 60) - tsee * 60) > 0 && dcen < (CarMile * 1000))//满足时间约束
                    {
                        //满足时间约束 则任务当前元任务可以被AS观测
                        ReCarID.Add(int.Parse(SingleCar.get_Value(0).ToString()));
                    }

                }

                #endregion

                #region 卫星FID确定
                // 卫星：空间关系 包含  
                List<int> ReSatID = new List<int>();//每一个子任务的卫星资源FID 列表 

                for (int i = 0; i < SatFL.FeatureClass.FeatureCount(null); i++)
                {
                    string oneSatPath = System.AppDomain.CurrentDomain.BaseDirectory + "Data\\CacheGrid\\" + "onesat.shp"; ;
                    GPselectTool(SatFL, oneSatPath, "FID=", int.Parse(SatFL.FeatureClass.GetFeature(i).get_Value(0).ToString()));// 相当于缓冲区 这里是卫星覆盖的子区域 
                    IFeatureLayer OneSatEleTFL = OpenFile_LayerFile(oneSatPath);
                    //string aa = OneSatEleTFL.FeatureClass.GetFeature(0).get_Value(15).ToString(); 下面if中要加tostring（）， 否则object不会等于string ，即不能进入循环
                    if (GridOriTFID == OneSatEleTFL.FeatureClass.GetFeature(0).get_Value(15).ToString())//查找与原任务id匹配的序列 以确定条带
                    {
                        ISpatialFilter psatBFFilter = new SpatialFilterClass();
                        psatBFFilter.Geometry = GridEleTaskFeature.Shape;
                        psatBFFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelWithin;//空间关系选择条件 选择能够观测到该子任务的缓冲区 （subT在UtoTBF内部，子任务是query ，缓冲区是target）——
                        IFeatureCursor TasktosatBFCursor = OneSatEleTFL.FeatureClass.Search(psatBFFilter, false);
                        IFeature satBFFeature = TasktosatBFCursor.NextFeature();//查询包含子任务的缓冲区
                        if (satBFFeature != null)
                        {
                            //RTsubTInfo RTFNOinfo = new RTsubTInfo() { RID = (int.Parse(RTinfoList[j].ResouceID) - 1).ToString(), TID = (int.Parse(RTinfoList[j].TaskID) - 1).ToString(), subTID = subTaskFeature.get_Value(0).ToString() };
                            //lstTaskFC.Add(RTFNOinfo);
                            ReSatID.Add(int.Parse(OneSatEleTFL.FeatureClass.GetFeature(0).get_Value(16).ToString()));
                            satBFFeature = TasktosatBFCursor.NextFeature();
                        }

                    }
                }


                #endregion


                IPolygon GridTPolygon = GridEleTaskFeature.Shape as IPolygon;
                IArea gridTarea = GridTPolygon as IArea;

                
                RTsubTInfo RTFNOinfo = new RTsubTInfo() { TFID = (int.Parse(GridOriTFID)).ToString(), subTFID = GridEleTaskFeature.get_Value(0).ToString(), UAVFID = ReUAVID, ASFID = ReASID, CarFID = ReCarID, SatFID = ReSatID, CoverL = ReUAVID.Count + ReASID.Count + ReSatID.Count + ReCarID.Count, subTArea = gridTarea.Area, subTWeight = subTweight, subTWinS = subTWinS, subTWinE = subTWinE, CarReturns = 0, UAVReturns = 0, ASReturns = 0, SatReturns = 0 };

                GridlstTaskFC.Add(RTFNOinfo);

                //进度条
                proBar.Value = GridEleTNO;
                GridEleTNO++;

                GridEleTaskFeature = GridEleTaskfeatureCursor.NextFeature();
            }

            #endregion

            //进度条
            proBar.Value = GridTaskFL.FeatureClass.FeatureCount(null);

            #region 冲突判断
            //冲突判断
            //假设网格元任务观测不需耗时 
            string gridToPointPath = System.AppDomain.CurrentDomain.BaseDirectory + "Data\\CacheGrid\\" + "GTToPo.shp";//将当前网格元任务区域转成点目标，为了求无人机基站到质心距离  
            GPFeatureToPointTool(GridTaskFL, gridToPointPath);//将当前网格元任务区域转成点目标
            IFeatureLayer GirdPointFL = OpenFile_LayerFile(gridToPointPath);

            #region UAV冲突判断
            //UAV冲突判断
            List<RT_FID> GridUavRTFIDlist = new List<RT_FID>();//无人机FID 及此无人机能够观测的元任务集FIDlist ,以及元任务发生冲突的list★★★★★★★★★★★★★★★★ 资源FID：int，元任务FID：list<int>,元任务个数：int
            int UAVcount = UavFL.FeatureClass.FeatureCount(null);//无人机个数 null就是全选
            for (int i = 0; i < UAVcount; i++)//资源FID
            {
                List<int> EleTFIdlist = new List<int>();//存储每个资源能够观测的元任务fid列表
                for (int j = 0; j < GridlstTaskFC.Count; j++)//元任务FID
                {
                    List<int> uavFIDList = GridlstTaskFC[j].UAVFID;
                    for (int k = 0; k < uavFIDList.Count; k++)//遍历每个元任务下的观测资源（能够观测到此元任务的资源）
                    {
                        if (i == uavFIDList[k])
                        {
                            EleTFIdlist.Add(j);
                            break;
                        }
                    }
                }
                IFeature UAVFea = UavFL.FeatureClass.GetFeature(i);//当前UAV（获取属性）
                double UavV = double.Parse(UAVFea.get_Value(5).ToString()); //UAV速度 km/h

                List<StartTime> EleTStimeList = new List<StartTime>();//存储开始观测时间
                List<ConflictTFID> conFIdlist = new List<ConflictTFID>();//存储每个资源能够观测的元任务中发生冲突的元任务ID列表list<(int,int)>
                IPoint UAVtoPoint = UAVFea.Shape as IPoint;//将当前UAV转成的点目标

                if (EleTFIdlist.Count > 1)
                {
                    for (int j = 0; j < EleTFIdlist.Count - 1; j++)
                    {
                        int firstSTH = 0;//第一个任务的开始观测时间
                        int firstSTM = 0;
                        int lastSTH = 0;
                        int lastSTM = 0;

                        int fisttTFID = 0;//第一个源任务FID
                        #region 确定第一个元任务的源任务FID
                        for (int ti = 0; ti < GridlstTaskFC.Count; ti++)
                        {
                            if (GridlstTaskFC[ti].subTFID == EleTFIdlist[j].ToString())//元任务FID匹配
                            {
                                fisttTFID = int.Parse(GridlstTaskFC[ti].TFID);
                                break;
                            }

                        }
                        #endregion
                        double UtoFirstDis;//当前UAV与第一个任务的距离 
                        IPoint firstPoint = GirdPointFL.FeatureClass.GetFeature(EleTFIdlist[j]).Shape as IPoint;//获取第一个冲突元任务要素（点目标）
                        UtoFirstDis = Math.Sqrt(Math.Pow(firstPoint.X - UAVtoPoint.X, 2) + Math.Pow(firstPoint.Y - UAVtoPoint.Y, 2));//UAV到第一个任务的距离

                        int firstThour;//任务结束时间 小时   
                        int firstTmin;
                        IFeature firstTFeature = ptaskFeatureLayer.FeatureClass.GetFeature(fisttTFID);//获取第一个冲突元任务所属源任务要素 为了获取时间窗口
                        string firstTe = firstTFeature.get_Value(5).ToString();//结束时间
                        string firstTs = firstTFeature.get_Value(4).ToString();//开始时间
                        //时间确定
                        #region 时间确定
                        if (firstTe.Length > 3)
                        {
                            firstThour = int.Parse(firstTe.Substring(0, 2));//任务结束时间 小时                 
                        }
                        else
                        {
                            firstThour = int.Parse(firstTe.Substring(0, 1));//任务结束时间 小时
                        }
                        firstTmin = int.Parse(firstTe.Substring(firstTe.Length - 2, 2));//任务结束时间 分钟 
                        //第一个任务开始时间
                        if (firstTs.Length > 3)
                        {
                            firstSTH = int.Parse(firstTs.Substring(0, 2));//任务开始时间 小时                 
                        }
                        else
                        {
                            firstSTH = int.Parse(firstTs.Substring(0, 1));//任务开始时间 小时
                        }
                        firstSTM = int.Parse(firstTs.Substring(firstTs.Length - 2, 2));//任务开始时间 分钟 
                        if ((firstSTH * 60 + firstSTM) > (SThour * 60 + STmin))//开始时间取  较大值
                        {
                            double st = firstSTH + (double)firstSTM / 60 - (UtoFirstDis / 1000 / UavV);
                            firstSTH = (int)Math.Floor(st);
                            firstSTM = (int)((double)(st - firstSTH) * 60);
                            if (st < (SThour + (double)STmin / 60))
                            {
                                firstSTH = SThour;
                                firstSTM = STmin;
                            }
                        }
                        else
                        {
                            firstSTH = SThour;
                            firstSTM = STmin;
                        }
                        #endregion
                        for (int k = j + 1; k < EleTFIdlist.Count; k++)
                        {

                            int secondTFID = 0;//第二个源任务FID
                            #region 确定第二个元任务的源任务FID
                            for (int ti = 0; ti < GridlstTaskFC.Count; ti++)
                            {
                                if (GridlstTaskFC[ti].subTFID == EleTFIdlist[k].ToString())
                                {
                                    secondTFID = int.Parse(GridlstTaskFC[ti].TFID);
                                    break;
                                }

                            }
                            #endregion


                            double TaskDis;//两个冲突任务间距离 米 
                            double UtoSecondDis;
                            #region UAV、 任务间距离 米

                            IPoint secondPoint = GirdPointFL.FeatureClass.GetFeature(EleTFIdlist[k]).Shape as IPoint;//将当前subT转成的点目标
                            TaskDis = Math.Sqrt(Math.Pow(firstPoint.X - secondPoint.X, 2) + Math.Pow(firstPoint.Y - secondPoint.Y, 2));//两冲突任务的质心距离 米 

                            UtoSecondDis = Math.Sqrt(Math.Pow(secondPoint.X - UAVtoPoint.X, 2) + Math.Pow(secondPoint.Y - UAVtoPoint.Y, 2));
                            #endregion


                            int secondThour;//任务结束时间 小时   
                            int secondTmin;

                            IFeature secondTFeature = ptaskFeatureLayer.FeatureClass.GetFeature(secondTFID);//获取第二个冲突元任务所属源任务要素

                            string seconTe = secondTFeature.get_Value(5).ToString();//结束时间
                            string seconTs = secondTFeature.get_Value(4).ToString();  //开始时间
                            #region 确定时间
                            //时间确定 
                            if (seconTe.Length > 3)
                            {
                                secondThour = int.Parse(seconTe.Substring(0, 2));//任务结束时间 小时                 
                            }
                            else
                            {
                                secondThour = int.Parse(seconTe.Substring(0, 1));//任务结束时间 小时
                            }
                            secondTmin = int.Parse(seconTe.Substring(seconTe.Length - 2, 2));//任务结束时间 分钟 
                            //任务开始时间 
                            //第二个任务开始时间
                            int secondSTH;
                            int secondSTM;
                            if (seconTs.Length > 3)
                            {
                                secondSTH = int.Parse(seconTs.Substring(0, 2));//任务开始时间 小时                 
                            }
                            else
                            {
                                secondSTH = int.Parse(seconTs.Substring(0, 1));//任务开始时间 小时
                            }
                            secondSTM = int.Parse(seconTs.Substring(seconTs.Length - 2, 2));//任务开始时间 分钟 
                            if ((secondSTH * 60 + secondSTM) > (SThour * 60 + STmin))//开始时间取  较大值
                            {
                                double st = secondSTH + (double)secondSTM / 60 - (UtoSecondDis / 1000 / UavV);
                                secondSTH = (int)Math.Floor(st);
                                secondSTM = (int)((double)(st - secondSTH) * 60);
                                if (st < (SThour + (double)STmin / 60))
                                {
                                    secondSTH = SThour;
                                    secondSTM = STmin;
                                }
                            }
                            else
                            {
                                secondSTH = SThour;
                                secondSTM = STmin;
                            }
                            #endregion

                            bool ConflictFirst = false;//第一种路线情况冲突时为true
                            bool ConflictSecond = false;//第二种路线情况冲突时为true
                            if ((firstSTH + (double)firstSTM / 60 + (UtoFirstDis + UtoSecondDis + TaskDis) / 1000 / UavV) > (secondThour + (double)secondTmin / 60)) //UAV判断冲突  小时
                            {
                                ConflictFirst = true;//第一种路线情况冲突时为true

                            }
                            if ((secondSTH + (double)secondSTM / 60 + (UtoFirstDis + UtoSecondDis + TaskDis) / 1000 / UavV) > (firstThour + (double)firstTmin / 60)) //判断冲突  
                            {
                                ConflictSecond = true;//第二种路线情况冲突时为true

                            }
                            if (ConflictFirst && ConflictSecond)//两种路线情况都发生了冲突
                            {
                                ConflictTFID conflictFidInfo = new ConflictTFID() { firstTFID = EleTFIdlist[j], secondTFID = EleTFIdlist[k] };
                                conFIdlist.Add(conflictFidInfo);
                            }
                            lastSTH = secondSTH;
                            lastSTM = secondSTM;

                        }//第二个任务k
                        StartTime EleTstartT = new StartTime() { Hour = firstSTH, Min = firstSTM };
                        EleTStimeList.Add(EleTstartT);

                        if (j == EleTFIdlist.Count - 2)
                        {
                            StartTime EleTstartTs = new StartTime() { Hour = lastSTH, Min = lastSTM };
                            EleTStimeList.Add(EleTstartTs);
                        }
                    }//任务j
                }

                RT_FID rtFidInfo = new RT_FID() { RFID = i, subTaskFID = EleTFIdlist, ConflictTaskFID = conFIdlist, taskCount = EleTFIdlist.Count, EleTstartTime = EleTStimeList };
                GridUavRTFIDlist.Add(rtFidInfo);
            }//uav资源
            #endregion

            #region 飞艇冲突判断
            //AS冲突判断
            List<RT_FID> GridASRTFIDlist = new List<RT_FID>();//ASFID 及此AS能够观测的元任务集FIDlist ,以及元任务发生冲突的list★★★★★★★★★★★★★★★★ 资源FID：int，元任务FID：list<int>,元任务个数：int
            int AScount = ASFL.FeatureClass.FeatureCount(null);//AS个数 null就是全选
            for (int i = 0; i < AScount; i++)//资源FID
            {
                List<int> EleTFIdlist = new List<int>();//存储每个资源能够观测的元任务fid列表
                for (int j = 0; j < GridlstTaskFC.Count; j++)//元任务FID
                {
                    List<int> ASFIDList = GridlstTaskFC[j].ASFID;
                    for (int k = 0; k < ASFIDList.Count; k++)//遍历每个元任务下的观测资源（能够观测到此元任务的资源）
                    {
                        if (i == ASFIDList[k])
                        {
                            EleTFIdlist.Add(j);
                            break;
                        }
                    }
                }
                IFeature ASFea = ASFL.FeatureClass.GetFeature(i);//当前AS（获取属性）
                double ASV = double.Parse(ASFea.get_Value(5).ToString()); //速度 km/h

                List<StartTime> EleTStimeList = new List<StartTime>();//存储开始观测时间
                List<ConflictTFID> conFIdlist = new List<ConflictTFID>();//存储每个资源能够观测的元任务中发生冲突的元任务ID列表list<(int,int)>
                IPoint AStoPoint = ASFea.Shape as IPoint;//将当前AS转成的点目标

                if (EleTFIdlist.Count > 1)
                {
                    for (int j = 0; j < EleTFIdlist.Count - 1; j++)
                    {
                        int firstSTH = 0;//第一个任务的开始观测时间
                        int firstSTM = 0;
                        int lastSTH = 0;
                        int lastSTM = 0;

                        int fisttTFID = 0;//第一个源任务FID
                        #region 确定第一个元任务的源任务FID
                        for (int ti = 0; ti < GridlstTaskFC.Count; ti++)
                        {
                            if (GridlstTaskFC[ti].subTFID == EleTFIdlist[j].ToString())//元任务FID匹配
                            {
                                fisttTFID = int.Parse(GridlstTaskFC[ti].TFID);
                                break;
                            }

                        }
                        #endregion
                        double AStoFirstDis;//当前AS与第一个任务的距离 
                        IPoint firstPoint = GirdPointFL.FeatureClass.GetFeature(EleTFIdlist[j]).Shape as IPoint;//获取第一个冲突元任务要素（点目标）
                        AStoFirstDis = Math.Sqrt(Math.Pow(firstPoint.X - AStoPoint.X, 2) + Math.Pow(firstPoint.Y - AStoPoint.Y, 2));//UAV到第一个任务的距离

                        int firstThour;//任务结束时间 小时   
                        int firstTmin;
                        IFeature firstTFeature = ptaskFeatureLayer.FeatureClass.GetFeature(fisttTFID);//获取第一个冲突元任务所属源任务要素 为了获取时间窗口
                        string firstTe = firstTFeature.get_Value(5).ToString();//结束时间
                        string firstTs = firstTFeature.get_Value(4).ToString();//开始时间
                        //时间确定
                        #region 时间确定
                        if (firstTe.Length > 3)
                        {
                            firstThour = int.Parse(firstTe.Substring(0, 2));//任务结束时间 小时                 
                        }
                        else
                        {
                            firstThour = int.Parse(firstTe.Substring(0, 1));//任务结束时间 小时
                        }
                        firstTmin = int.Parse(firstTe.Substring(firstTe.Length - 2, 2));//任务结束时间 分钟 
                        //第一个任务开始时间
                        if (firstTs.Length > 3)
                        {
                            firstSTH = int.Parse(firstTs.Substring(0, 2));//任务开始时间 小时                 
                        }
                        else
                        {
                            firstSTH = int.Parse(firstTs.Substring(0, 1));//任务开始时间 小时
                        }
                        firstSTM = int.Parse(firstTs.Substring(firstTs.Length - 2, 2));//任务开始时间 分钟 
                        if ((firstSTH * 60 + firstSTM) > (SThour * 60 + STmin))//开始时间取  较大值
                        {
                            double st = firstSTH + (double)firstSTM / 60 - (AStoFirstDis / 1000 / ASV);
                            firstSTH = (int)Math.Floor(st);
                            firstSTM = (int)((double)(st - firstSTH) * 60);
                            if (st < (SThour + (double)STmin / 60))
                            {
                                firstSTH = SThour;
                                firstSTM = STmin;
                            }
                        }
                        else
                        {
                            firstSTH = SThour;
                            firstSTM = STmin;
                        }
                        #endregion
                        for (int k = j + 1; k < EleTFIdlist.Count; k++)
                        {

                            int secondTFID = 0;//第二个源任务FID
                            #region 确定第二个元任务的源任务FID
                            for (int ti = 0; ti < GridlstTaskFC.Count; ti++)
                            {
                                if (GridlstTaskFC[ti].subTFID == EleTFIdlist[k].ToString())
                                {
                                    secondTFID = int.Parse(GridlstTaskFC[ti].TFID);
                                    break;
                                }

                            }
                            #endregion


                            double TaskDis;//两个冲突任务间距离 米 
                            double AStoSecondDis;
                            #region UAV、 任务间距离 米

                            IPoint secondPoint = GirdPointFL.FeatureClass.GetFeature(EleTFIdlist[k]).Shape as IPoint;//将当前subT转成的点目标
                            TaskDis = Math.Sqrt(Math.Pow(firstPoint.X - secondPoint.X, 2) + Math.Pow(firstPoint.Y - secondPoint.Y, 2));//两冲突任务的质心距离 米 

                            AStoSecondDis = Math.Sqrt(Math.Pow(secondPoint.X - AStoPoint.X, 2) + Math.Pow(secondPoint.Y - AStoPoint.Y, 2));
                            #endregion


                            int secondThour;//任务结束时间 小时   
                            int secondTmin;

                            IFeature secondTFeature = ptaskFeatureLayer.FeatureClass.GetFeature(secondTFID);//获取第二个冲突元任务所属源任务要素

                            string seconTe = secondTFeature.get_Value(5).ToString();//结束时间
                            string seconTs = secondTFeature.get_Value(4).ToString();  //开始时间
                            #region 确定时间
                            //时间确定 
                            if (seconTe.Length > 3)
                            {
                                secondThour = int.Parse(seconTe.Substring(0, 2));//任务结束时间 小时                 
                            }
                            else
                            {
                                secondThour = int.Parse(seconTe.Substring(0, 1));//任务结束时间 小时
                            }
                            secondTmin = int.Parse(seconTe.Substring(seconTe.Length - 2, 2));//任务结束时间 分钟 
                            //任务开始时间 
                            //第二个任务开始时间
                            int secondSTH;
                            int secondSTM;
                            if (seconTs.Length > 3)
                            {
                                secondSTH = int.Parse(seconTs.Substring(0, 2));//任务开始时间 小时                 
                            }
                            else
                            {
                                secondSTH = int.Parse(seconTs.Substring(0, 1));//任务开始时间 小时
                            }
                            secondSTM = int.Parse(seconTs.Substring(seconTs.Length - 2, 2));//任务开始时间 分钟 
                            if ((secondSTH * 60 + secondSTM) > (SThour * 60 + STmin))//开始时间取  较大值
                            {
                                double st = secondSTH + (double)secondSTM / 60 - (AStoSecondDis / 1000 / ASV);
                                secondSTH = (int)Math.Floor(st);
                                secondSTM = (int)((double)(st - secondSTH) * 60);
                                if (st < (SThour + (double)STmin / 60))
                                {
                                    secondSTH = SThour;
                                    secondSTM = STmin;
                                }
                            }
                            else
                            {
                                secondSTH = SThour;
                                secondSTM = STmin;
                            }
                            #endregion

                            bool ConflictFirst = false;//第一种路线情况冲突时为true
                            bool ConflictSecond = false;//第二种路线情况冲突时为true
                            if ((firstSTH + (double)firstSTM / 60 + (AStoFirstDis + TaskDis) / 1000 / ASV) > (secondThour + (double)secondTmin / 60)) //判断冲突  小时
                            {
                                ConflictFirst = true;//第一种路线情况冲突时为true

                            }
                            if ((secondSTH + (double)secondSTM / 60 + (AStoSecondDis + TaskDis) / 1000 / ASV) > (firstThour + (double)firstTmin / 60)) //判断冲突  
                            {
                                ConflictSecond = true;//第二种路线情况冲突时为true

                            }
                            if (ConflictFirst && ConflictSecond)//两种路线情况都发生了冲突
                            {
                                ConflictTFID conflictFidInfo = new ConflictTFID() { firstTFID = EleTFIdlist[j], secondTFID = EleTFIdlist[k] };
                                conFIdlist.Add(conflictFidInfo);
                            }
                            lastSTH = secondSTH;
                            lastSTM = secondSTM;

                        }//第二个任务k
                        StartTime EleTstartT = new StartTime() { Hour = firstSTH, Min = firstSTM };
                        EleTStimeList.Add(EleTstartT);

                        if (j == EleTFIdlist.Count - 2)
                        {
                            StartTime EleTstartTs = new StartTime() { Hour = lastSTH, Min = lastSTM };
                            EleTStimeList.Add(EleTstartTs);
                        }
                    }//任务j
                }

                RT_FID rtFidInfo = new RT_FID() { RFID = i, subTaskFID = EleTFIdlist, ConflictTaskFID = conFIdlist, taskCount = EleTFIdlist.Count, EleTstartTime = EleTStimeList };
                GridASRTFIDlist.Add(rtFidInfo);
            }//uav资源
            #endregion

            #region 车辆冲突判断
            //Car冲突判断
            List<RT_FID> GridCarRTFIDlist = new List<RT_FID>();//CarFID 及此Car能够观测的元任务集FIDlist ,以及元任务发生冲突的list★★★★★★★★★★★★★★★★ 资源FID：int，元任务FID：list<int>,元任务个数：int
            int Carcount = CarFeatureLayer.FeatureClass.FeatureCount(null);//Car个数 null就是全选
            for (int i = 0; i < Carcount; i++)//资源FID
            {
                List<int> EleTFIdlist = new List<int>();//存储每个资源能够观测的元任务fid列表
                for (int j = 0; j < GridlstTaskFC.Count; j++)//元任务FID
                {
                    List<int> CarFIDList = GridlstTaskFC[j].CarFID;
                    for (int k = 0; k < CarFIDList.Count; k++)//遍历每个元任务下的观测资源（能够观测到此元任务的资源）
                    {
                        if (i == CarFIDList[k])
                        {
                            EleTFIdlist.Add(j);
                            break;
                        }
                    }
                }
                IFeature CarFea = CarFeatureLayer.FeatureClass.GetFeature(i);//当前Car（获取属性）
                double CarV = double.Parse(CarFea.get_Value(5).ToString()); //速度 km/h
                double CarOberV = double.Parse(CarFea.get_Value(8).ToString()); //观测速度 km/h
                double CarMile = double.Parse(CarFea.get_Value(7).ToString()); //里程 km

                List<StartTime> EleTStimeList = new List<StartTime>();//存储开始观测时间
                List<ConflictTFID> conFIdlist = new List<ConflictTFID>();//存储每个资源能够观测的元任务中发生冲突的元任务ID列表list<(int,int)>
                IPoint CartoPoint = CarFea.Shape as IPoint;//将当前Car转成的点目标

                if (EleTFIdlist.Count > 1)
                {
                    for (int j = 0; j < EleTFIdlist.Count - 1; j++)
                    {

                        int lastSTH = 0;
                        int lastSTM = 0;

                        double CartoFirstDis;//当前Car与第一个任务的距离 
                        IPoint firstPoint = GirdPointFL.FeatureClass.GetFeature(EleTFIdlist[j]).Shape as IPoint;//获取第一个冲突元任务要素（点目标）
                        //CartoFirstDis = Math.Sqrt(Math.Pow(firstPoint.X - CartoPoint.X, 2) + Math.Pow(firstPoint.Y - CartoPoint.Y, 2));//UAV到第一个任务的距离


                        #region 距离计算 车到第一个冲突任务间距离 米
                        //几何网络
                        IGeometricNetwork mGeometricNetwork;

                        //获取给定点最近的Network元素
                        IPointToEID mPointToEID = new PointToEIDClass();
                        //获取几何网络文件路径
                        //注意修改此路径为当前存储路径
                        string strPath = System.AppDomain.CurrentDomain.BaseDirectory + "Data\\RoadData.gdb";//+"E:\GIS设计与开发\例子数据\Network\USA_Highway_Network_GDB.mdb";
                        //打开工作空间
                        IWorkspaceFactory pWorkspaceFactory = new ESRI.ArcGIS.DataSourcesGDB.FileGDBWorkspaceFactory();
                        IFeatureWorkspace pFeatureWorkspace = pWorkspaceFactory.OpenFromFile(strPath, 0) as IFeatureWorkspace;
                        //获取要素数据集
                        //注意名称的设置要与上面创建保持一致
                        IFeatureDataset pFeatureDataset = pFeatureWorkspace.OpenFeatureDataset("RaadDataSet");//修改成从xml读取

                        //获取network集合
                        INetworkCollection pNetWorkCollection = pFeatureDataset as INetworkCollection;
                        //获取network的数量,为零时返回
                        int intNetworkCount = pNetWorkCollection.GeometricNetworkCount;
                        if (intNetworkCount < 1)
                        { MessageBox.Show("要素类数量为0！"); }
                        //FeatureDataset可能包含多个network，我们获取指定的network
                        //注意network的名称的设置要与上面创建保持一致
                        mGeometricNetwork = pNetWorkCollection.get_GeometricNetworkByName("RaadDataSet_Net");//修改成从xml读取
                        //设置mPointToEID属性
                        mPointToEID.SourceMap = Program.myMap.Map;
                        mPointToEID.GeometricNetwork = mGeometricNetwork;
                        mPointToEID.SnapTolerance = 200000; //捕捉容差 2000m？


                        IPointCollection mPointCollection = new MultipointClass();//给定点的集合
                        mPointCollection.AddPoint(CartoPoint);
                        mPointCollection.AddPoint(firstPoint);

                        //路径计算
                        IEnumNetEID mEnumNetEID_Junctions;//返回路径的节点
                        IEnumNetEID mEnumNetEID_Edges;//返回路径边
                        double mdblPathCost;//返回总代价（边长 距离）
                        CoScheduling.Core.Map.MapHelper MapHelp = new Core.Map.MapHelper();
                        MapHelp.SolvePath("weight", mGeometricNetwork, mPointCollection, mPointToEID, out  mEnumNetEID_Junctions, out  mEnumNetEID_Edges, out   mdblPathCost);
                        IPolyline ResultLine = MapHelp.PathToPolyLine(Program.myMap.Map, mGeometricNetwork, mEnumNetEID_Edges);//将路径结果转为线
                        CartoFirstDis = ResultLine.Length;//两冲突任务的质心距离 米 


                        #endregion



                        string firstTe = "";//第一个任务的结束时间窗口
                        string firstTs = "";//第一个任务的开始时间窗口

                        #region 确定第一个元任务的开始/结束时间窗口
                        for (int ti = 0; ti < GridlstTaskFC.Count; ti++)
                        {
                            if (GridlstTaskFC[ti].subTFID == EleTFIdlist[j].ToString())//元任务FID匹配
                            {
                                //fisttTFID = int.Parse(GridlstTaskFC[ti].TFID);
                                firstTe = GridlstTaskFC[ti].subTWinE;//结束时间
                                firstTs = GridlstTaskFC[ti].subTWinS;//开始时间
                                break;
                            }

                        }
                        #endregion

                        int firstSTH = 0;//第一个任务的开始观测时间
                        int firstSTM = 0;
                        int firstThour;//第一个任务的任务结束时间 小时   
                        int firstTmin;

                        //时间确定
                        #region 时间确定
                        if (firstTe.Length > 3)
                        {
                            firstThour = int.Parse(firstTe.Substring(0, 2));//任务结束时间 小时                 
                        }
                        else
                        {
                            firstThour = int.Parse(firstTe.Substring(0, 1));//任务结束时间 小时
                        }
                        firstTmin = int.Parse(firstTe.Substring(firstTe.Length - 2, 2));//任务结束时间 分钟 
                        //第一个任务开始时间
                        if (firstTs.Length > 3)
                        {
                            firstSTH = int.Parse(firstTs.Substring(0, 2));//任务开始时间 小时                 
                        }
                        else
                        {
                            firstSTH = int.Parse(firstTs.Substring(0, 1));//任务开始时间 小时
                        }
                        firstSTM = int.Parse(firstTs.Substring(firstTs.Length - 2, 2));//任务开始时间 分钟 
                        if ((firstSTH * 60 + firstSTM) > (SThour * 60 + STmin))//开始时间取  较大值
                        {
                            double st = firstSTH + (double)firstSTM / 60 - (CartoFirstDis / 1000 / CarV);
                            firstSTH = (int)Math.Floor(st);
                            firstSTM = (int)((double)(st - firstSTH) * 60);
                            if (st < (SThour + (double)STmin / 60))
                            {
                                firstSTH = SThour;
                                firstSTM = STmin;
                            }
                        }
                        else
                        {
                            firstSTH = SThour;
                            firstSTM = STmin;
                        }
                        #endregion


                        for (int k = j + 1; k < EleTFIdlist.Count; k++)
                        {

                            double TaskDis;//两个冲突任务间距离 米 
                            double CartoSecondDis;//当前Car与第二个任务的距离
                            IPoint secondPoint = GirdPointFL.FeatureClass.GetFeature(EleTFIdlist[k]).Shape as IPoint;//将当前subT转成的点目标
                            #region 当前车到第二个元任务的距离 米
                            IPointCollection CarFTPointCollection = new MultipointClass();//给定点的集合
                            CarFTPointCollection.AddPoint(CartoPoint);
                            CarFTPointCollection.AddPoint(secondPoint);
                            //路径计算
                            IEnumNetEID CarFEnumNetEID_Junctions;//返回路径的节点
                            IEnumNetEID CarFEnumNetEID_Edges;//返回路径边
                            double CarFPathCost;//返回总代价（边长 距离）

                            MapHelp.SolvePath("weight", mGeometricNetwork, CarFTPointCollection, mPointToEID, out  CarFEnumNetEID_Junctions, out  CarFEnumNetEID_Edges, out   CarFPathCost);
                            IPolyline CarFResultLine = MapHelp.PathToPolyLine(Program.myMap.Map, mGeometricNetwork, CarFEnumNetEID_Edges);//将路径结果转为线
                            CartoSecondDis = CarFResultLine.Length;// 米 
                            #endregion

                            #region 两个冲突任务间距离 米
                            IPointCollection CarSTPointCollection = new MultipointClass();//给定点的集合
                            CarSTPointCollection.AddPoint(firstPoint);
                            CarSTPointCollection.AddPoint(secondPoint);
                            //路径计算
                            IEnumNetEID CarSEnumNetEID_Junctions;//返回路径的节点
                            IEnumNetEID CarSEnumNetEID_Edges;//返回路径边
                            double CarSPathCost;//返回总代价（边长 距离）

                            MapHelp.SolvePath("weight", mGeometricNetwork, CarSTPointCollection, mPointToEID, out  CarSEnumNetEID_Junctions, out  CarSEnumNetEID_Edges, out   CarSPathCost);
                            IPolyline CarSResultLine = MapHelp.PathToPolyLine(Program.myMap.Map, mGeometricNetwork, CarSEnumNetEID_Edges);//将路径结果转为线
                            TaskDis = CarSResultLine.Length;//两冲突任务的质心距离 米 
                            #endregion



                            string seconTe = "";//结束时间
                            string seconTs = "";  //开始时间
                            //int secondTFID = 0;//第二个源任务FID
                            #region 确定第二个元任务的开始/结束时间窗口
                            for (int ti = 0; ti < GridlstTaskFC.Count; ti++)
                            {
                                if (GridlstTaskFC[ti].subTFID == EleTFIdlist[k].ToString())
                                {
                                    seconTs = GridlstTaskFC[ti].subTWinS;
                                    seconTe = GridlstTaskFC[ti].subTWinE;
                                    //secondTFID = int.Parse(GridlstTaskFC[ti].TFID);
                                    break;
                                }

                            }
                            #endregion


                            int secondThour;//任务结束时间 小时   
                            int secondTmin;
                            #region 确定时间
                            //时间确定 
                            if (seconTe.Length > 3)
                            {
                                secondThour = int.Parse(seconTe.Substring(0, 2));//任务结束时间 小时                 
                            }
                            else
                            {
                                secondThour = int.Parse(seconTe.Substring(0, 1));//任务结束时间 小时
                            }
                            secondTmin = int.Parse(seconTe.Substring(seconTe.Length - 2, 2));//任务结束时间 分钟 
                            //任务开始时间 
                            //第二个任务开始时间
                            int secondSTH;
                            int secondSTM;
                            if (seconTs.Length > 3)
                            {
                                secondSTH = int.Parse(seconTs.Substring(0, 2));//任务开始时间 小时                 
                            }
                            else
                            {
                                secondSTH = int.Parse(seconTs.Substring(0, 1));//任务开始时间 小时
                            }
                            secondSTM = int.Parse(seconTs.Substring(seconTs.Length - 2, 2));//任务开始时间 分钟 
                            if ((secondSTH * 60 + secondSTM) > (SThour * 60 + STmin))//开始时间取  较大值
                            {
                                double st = secondSTH + (double)secondSTM / 60 - (CartoSecondDis / 1000 / CarV);
                                secondSTH = (int)Math.Floor(st);
                                secondSTM = (int)((double)(st - secondSTH) * 60);
                                if (st < (SThour + (double)STmin / 60))
                                {
                                    secondSTH = SThour;
                                    secondSTM = STmin;
                                }
                            }
                            else
                            {
                                secondSTH = SThour;
                                secondSTM = STmin;
                            }
                            #endregion
                            double ContiTime = GridLength / 1000 / CarOberV; //单个网格持续观测时间 h

                            bool ConflictFirst = false;//第一种路线情况冲突时为true
                            bool ConflictSecond = false;//第二种路线情况冲突时为true
                            if ((firstSTH + (double)firstSTM / 60 + ContiTime + (CartoFirstDis + TaskDis) / 1000 / CarV) > (secondThour + (double)secondTmin / 60)) //判断冲突  小时
                            {
                                ConflictFirst = true;//第一种路线情况冲突时为true

                            }
                            if ((secondSTH + (double)secondSTM / 60 + ContiTime + (CartoSecondDis + TaskDis) / 1000 / CarV) > (firstThour + (double)firstTmin / 60)) //判断冲突  
                            {
                                ConflictSecond = true;//第二种路线情况冲突时为true

                            }
                            if (ConflictFirst && ConflictSecond)//两种路线情况都发生了冲突
                            {
                                ConflictTFID conflictFidInfo = new ConflictTFID() { firstTFID = EleTFIdlist[j], secondTFID = EleTFIdlist[k] };
                                conFIdlist.Add(conflictFidInfo);
                            }
                            else if (CartoFirstDis + TaskDis > CarMile * 1000 && CartoSecondDis + TaskDis > CarMile * 1000)
                            {
                                ConflictTFID conflictFidInfo = new ConflictTFID() { firstTFID = EleTFIdlist[j], secondTFID = EleTFIdlist[k] };
                                conFIdlist.Add(conflictFidInfo);
                            }

                            lastSTH = secondSTH;
                            lastSTM = secondSTM;

                        }//第二个任务k
                        StartTime EleTstartT = new StartTime() { Hour = firstSTH, Min = firstSTM };
                        EleTStimeList.Add(EleTstartT);

                        if (j == EleTFIdlist.Count - 2)
                        {
                            StartTime EleTstartTs = new StartTime() { Hour = lastSTH, Min = lastSTM };
                            EleTStimeList.Add(EleTstartTs);
                        }
                    }//任务j
                }

                RT_FID rtFidInfo = new RT_FID() { RFID = i, subTaskFID = EleTFIdlist, ConflictTaskFID = conFIdlist, taskCount = EleTFIdlist.Count, EleTstartTime = EleTStimeList };
                GridCarRTFIDlist.Add(rtFidInfo);
            }
            #endregion

            #region 卫星冲突判断
            //卫星冲突判断开始--------------------------------------(sat冲突判断开始)------------------------------------------ 
            IFeatureLayer satAtributeFL = SatAtributeiLayer as IFeatureLayer; //SateliteLine 
            int satNo = satAtributeFL.FeatureClass.FeatureCount(null);
            List<RT_FID> satRTFIDlist = new List<RT_FID>();//卫星FID 及此卫星能够观测的元任务集FIDlist ,以及元任务发生冲突的list★★★★★★★★★★★★★★★★ 资源FID：int，元任务FID：list<int>,元任务个数：int  
            for (int i = 0; i < satNo; i++) //卫星FID                      SattoTaskFIDlist
            {//对于卫星 不需判断每个元任务的冲突 因为假定卫星要么观测一个任务的完整条带 要么完全不观测
                List<int> satSubFIdlist = new List<int>();//存储每个资源能够观测的satElemT任务fid列表

                for (int j = 0; j < SatFL.FeatureClass.FeatureCount(null); j++)//遍历卫星子任务
                {
                    if (i.ToString() == SatFL.FeatureClass.GetFeature(j).get_Value(16).ToString())
                    {
                        satSubFIdlist.Add(int.Parse(SatFL.FeatureClass.GetFeature(j).get_Value(0).ToString()));//卫星观测任务FID 即SatElementTask中FID 2 3 5 6
                    }
                }
                IFeature SATatributeFeature = satAtributeFL.FeatureClass.GetFeature(i);//当前卫星（获取属性）
                double Vengel = double.Parse(SATatributeFeature.get_Value(10).ToString()); //侧摆角转向速度 度每秒
                double storeV = double.Parse(SATatributeFeature.get_Value(9).ToString()); //星上存储容量 GB
                double intervalT = double.Parse(SATatributeFeature.get_Value(11).ToString()); //开机间隔时间 秒
                double staT = double.Parse(SATatributeFeature.get_Value(12).ToString()); //侧摆之后稳定时间 秒
                List<ConflictTFID> satConFIdlist = new List<ConflictTFID>();//存储每个卫星能够观测的SatElemT中发生冲突的任务FID列表list<(int,int)>
                if (satSubFIdlist.Count > 1)//当前观测资源能够观测到的元任务不为空且大于1，满足两两冲突的基本条件
                {
                    //卫星冲突判断  转角时间约束 和容量约束
                    for (int j = 0; j < satSubFIdlist.Count - 1; j++)
                    {
                        for (int k = j + 1; k < satSubFIdlist.Count; k++)
                        {


                            IFeature firstSATTask = SatFL.FeatureClass.GetFeature(satSubFIdlist[j]);//获取第一个冲突任务要素
                            IFeature secondSATTask = SatFL.FeatureClass.GetFeature(satSubFIdlist[k]);//获取第二个冲突任务要素
                            string firstTaskStime = firstSATTask.get_Value(10).ToString();//获取第一个冲突任务的开始观测时间
                            string firstTaskEtime = firstSATTask.get_Value(11).ToString();//获取第一个冲突任务的结束观测时间
                            string secondTaskStime = secondSATTask.get_Value(10).ToString();//获取第二个冲突任务的开始观测时间
                            string secondTaskEtime = secondSATTask.get_Value(11).ToString();//获取第二个冲突任务的结束观测时间
                            double firstAngel = double.Parse(firstSATTask.get_Value(12).ToString());//获取第一个冲突任务的侧摆角 度
                            double secondAngel = double.Parse(secondSATTask.get_Value(12).ToString());//获取第二个冲突任务的侧摆角 
                            double firstStore = double.Parse(firstSATTask.get_Value(14).ToString());//
                            double secondStore = double.Parse(secondSATTask.get_Value(14).ToString());//获取第二个冲突任务的需要容量 G

                            //确定时间
                            int firstTShour = 0;//第一个冲突任务的开始观测时间 小时
                            double firstTSmin = 0;//第一个冲突任务的开始观测时间 分钟
                            int firstTEhour = 0;//第一个冲突任务的结束观测时间 小时
                            double firstTEmin = 0;//第一个冲突任务的结束观测时间 分钟
                            int secondTShour = 0;//第二个冲突任务的开始观测时间 小时
                            double secondTSmin = 0;//第二个冲突任务的开始观测时间 分钟
                            int secondTEhour = 0;//第二个冲突任务的结束观测时间 小时
                            double secondTEmin = 0;//第二个冲突任务的结束观测时间 分钟
                            #region 确定时间

                            if (firstTaskStime.Contains("."))
                            {
                                string HourAndMin = firstTaskStime.Substring(0, firstTaskStime.IndexOf("."));
                                if (HourAndMin.Length > 3)
                                {
                                    firstTShour = int.Parse(HourAndMin.Substring(0, 2));//第一个任务开始观测时间  小时                 
                                }
                                else
                                {
                                    firstTShour = int.Parse(HourAndMin.Substring(0, 1));//
                                }
                                firstTSmin = double.Parse(HourAndMin.Substring(HourAndMin.Length - 2, 2) + firstTaskStime.Substring(firstTaskStime.IndexOf(".")));//第一个任务开始观测时间  分钟  
                            }
                            else
                            {
                                if (firstTaskStime.Length > 3)
                                {
                                    firstTShour = int.Parse(firstTaskStime.Substring(0, 2));// 
                                }
                                else
                                {
                                    firstTShour = int.Parse(firstTaskStime.Substring(0, 1));//
                                }
                                firstTSmin = int.Parse(firstTaskStime.Substring(firstTaskStime.Length - 2, 2));//
                            }

                            /////////////////

                            if (firstTaskEtime.Contains("."))
                            {
                                string HourAndMin = firstTaskEtime.Substring(0, firstTaskEtime.IndexOf("."));
                                if (HourAndMin.Length > 3)
                                {
                                    firstTEhour = int.Parse(HourAndMin.Substring(0, 2));//第一个任务开始观测时间  小时                 
                                }
                                else
                                {
                                    firstTEhour = int.Parse(HourAndMin.Substring(0, 1));//
                                }
                                firstTEmin = double.Parse(HourAndMin.Substring(HourAndMin.Length - 2, 2) + firstTaskEtime.Substring(firstTaskEtime.IndexOf(".")));//第一个任务开始观测时间  分钟  
                            }
                            else
                            {
                                if (firstTaskEtime.Length > 3)
                                {
                                    firstTEhour = int.Parse(firstTaskEtime.Substring(0, 2));// 
                                }
                                else
                                {
                                    firstTEhour = int.Parse(firstTaskEtime.Substring(0, 1));//
                                }
                                firstTEmin = int.Parse(firstTaskEtime.Substring(firstTaskEtime.Length - 2, 2));//
                            }

                            /////////////////

                            if (secondTaskStime.Contains("."))
                            {
                                string HourAndMin = secondTaskStime.Substring(0, secondTaskStime.IndexOf("."));
                                if (HourAndMin.Length > 3)
                                {
                                    secondTShour = int.Parse(HourAndMin.Substring(0, 2));//第一个任务开始观测时间  小时                 
                                }
                                else
                                {
                                    secondTShour = int.Parse(HourAndMin.Substring(0, 1));//
                                }
                                secondTSmin = double.Parse(HourAndMin.Substring(HourAndMin.Length - 2, 2) + secondTaskStime.Substring(secondTaskStime.IndexOf(".")));//第一个任务开始观测时间  分钟  
                            }
                            else
                            {
                                if (secondTaskStime.Length > 3)
                                {
                                    secondTShour = int.Parse(secondTaskStime.Substring(0, 2));// 
                                }
                                else
                                {
                                    secondTShour = int.Parse(secondTaskStime.Substring(0, 1));//
                                }
                                secondTSmin = int.Parse(secondTaskStime.Substring(secondTaskStime.Length - 2, 2));//
                            }

                            /////////////////

                            if (secondTaskEtime.Contains("."))
                            {
                                string HourAndMin = secondTaskEtime.Substring(0, secondTaskEtime.IndexOf("."));
                                if (HourAndMin.Length > 3)
                                {
                                    secondTEhour = int.Parse(HourAndMin.Substring(0, 2));//第一个任务开始观测时间  小时                 
                                }
                                else
                                {
                                    secondTEhour = int.Parse(HourAndMin.Substring(0, 1));//
                                }
                                secondTEmin = double.Parse(HourAndMin.Substring(HourAndMin.Length - 2, 2) + secondTaskEtime.Substring(secondTaskEtime.IndexOf(".")));//第一个任务开始观测时间  分钟  
                            }
                            else
                            {
                                if (secondTaskEtime.Length > 3)
                                {
                                    secondTEhour = int.Parse(secondTaskEtime.Substring(0, 2));// 
                                }
                                else
                                {
                                    secondTEhour = int.Parse(secondTaskEtime.Substring(0, 1));//
                                }
                                secondTEmin = int.Parse(secondTaskEtime.Substring(secondTaskEtime.Length - 2, 2));//
                            }

                            #endregion


                            if ((firstTShour * 60 + firstTSmin) < (secondTShour * 60 + secondTSmin))
                            {
                                if (firstTEhour * 3600 + firstTEmin * 60 + Math.Abs(firstAngel - secondAngel) / Vengel + intervalT + staT > secondTShour * 3600 + secondTSmin * 60)//化成秒比较
                                {
                                    //冲突
                                    ConflictTFID conflictFidInfo = new ConflictTFID() { firstTFID = satSubFIdlist[j], secondTFID = satSubFIdlist[k] };//存储的是SatElementTask的FID
                                    satConFIdlist.Add(conflictFidInfo);
                                }
                                else if (firstStore + secondStore > storeV)
                                {
                                    ConflictTFID conflictFidInfo = new ConflictTFID() { firstTFID = satSubFIdlist[j], secondTFID = satSubFIdlist[k] };//存储的是SatElementTask的FID
                                    satConFIdlist.Add(conflictFidInfo);
                                }
                            }
                            else
                            {
                                if (secondTEhour * 3600 + secondTEmin * 60 + Math.Abs(firstAngel - secondAngel) / Vengel + intervalT + staT > firstTShour * 3600 + firstTSmin * 60)//化成秒比较
                                {
                                    //冲突
                                    ConflictTFID conflictFidInfo = new ConflictTFID() { firstTFID = satSubFIdlist[j], secondTFID = satSubFIdlist[k] };//存储的是SatElementTask的FID
                                    satConFIdlist.Add(conflictFidInfo);
                                }
                                else if (firstStore + secondStore > storeV)
                                {
                                    ConflictTFID conflictFidInfo = new ConflictTFID() { firstTFID = satSubFIdlist[j], secondTFID = satSubFIdlist[k] };//存储的是SatElementTask的FID
                                    satConFIdlist.Add(conflictFidInfo);
                                }
                            }



                        }//第二个任务 k
                    }//第一个任务 j

                }//(subFIdlist.Count > 1) 当前资源观测的元任务个数大于1

                RT_FID rtFidInfo = new RT_FID() { RFID = i, subTaskFID = satSubFIdlist, ConflictTaskFID = satConFIdlist, taskCount = satSubFIdlist.Count };
                satRTFIDlist.Add(rtFidInfo);
            }
            //卫星冲突判断结束--------------------------------------(sat冲突判断结束)------------------------------------------ 

            #endregion


            #endregion

            #region 启发式准则模型构建 及 收益
            //模型构建 收益函数
            int TNO = ptaskFeatureLayer.FeatureClass.FeatureCount(null);// 源任务个数
            fi2 = (double)TNO / GridlstTaskFC.Count * 5;
            fi = 1 - fi2;
            #region 无人机子规划中心启发式准则模型
            for (int i = 0; i < GridUavRTFIDlist.Count; i++)
            {
                int UAVFID = GridUavRTFIDlist[i].RFID;//资源FID‘
                List<int> subFIDList = GridUavRTFIDlist[i].subTaskFID;//当前资源能够观测到的元任务list集合
                List<ConflictTFID> ConTFID = GridUavRTFIDlist[i].ConflictTaskFID;//当前资源能够观测的元任务的冲突集合
                //List<StartTime> EleTimeS = GridUavRTFIDlist[i].EleTstartTime;//当前资源观测元任务的开始时间集合
                //List<StartTime> EleStartTime

                List<double> ConRatelist = new List<double>(new double[subFIDList.Count]);//元任务冲突率 每一个资源相对于每一个元任务 list长度为观测元任务个数
                List<double> ConDgreelist = new List<double>(new double[subFIDList.Count]);//元任务冲突度
                List<double> LoadDgreelist = new List<double>(new double[subFIDList.Count]);//当前资源观测元任务的负载度
                List<double> UAVReturnsList = new List<double>(new double[subFIDList.Count]);//每一个资源相对于每一个元任务的收益
                for (int j = 0; j < subFIDList.Count; j++)
                {

                    int subTFID = subFIDList[j];//获取当前资源观测的一个元任务FID 当前元任务
                    List<int> ConflictsubTfid = new List<int>();//与当前元任务冲突的元任务FID集合
                    double subTarea = GridlstTaskFC[subTFID].subTArea;
                    double subTweight = GridlstTaskFC[subTFID].subTWeight;//元任务权重
                    //double subTtime = 0;//当前元任务的观测时长
                    //double ConflisubTtime = 0;//与当前任务冲突的元任务的观测时长
                    //string subTwinE = "0";//当前元任务的结束观测时间
                    //string confisubTWinE = "0";//与当前任务冲突的元任务的观测结束时间

                    #region ConflictsubTfid赋值
                    for (int k = 0; k < ConTFID.Count; k++)
                    {
                        if (ConTFID[k].firstTFID == subTFID)
                        {
                            ConflictsubTfid.Add(ConTFID[k].secondTFID);
                        }
                        else if (ConTFID[k].secondTFID == subTFID)
                        {
                            ConflictsubTfid.Add(ConTFID[k].firstTFID);
                        }
                    }
                    #endregion

                    ConRatelist[j] = (double)ConflictsubTfid.Count / subFIDList.Count;//冲突率 jm/jn ----------------------------------------------------------------------------
                    double conTWeight;//与当前元任务冲突的任务的权重
                    double conTArea;//与当前元任务冲突的任务的面积
                    double conTLevel;//与当前元任务冲突的任务的覆盖级别
                    double conIndSum = 0;//三个指标计算之和   冲突度模型括号里面和
                    for (int k = 0; k < ConflictsubTfid.Count; k++)
                    {
                        conTWeight = GridlstTaskFC[ConflictsubTfid[k]].subTWeight;//获取与当前元任务冲突的任务的权重 lstTaskFC的第几个即对应元任务的FID
                        conTArea = GridlstTaskFC[ConflictsubTfid[k]].subTArea;//获取与当前元任务冲突的任务的面积
                        conTLevel = GridlstTaskFC[ConflictsubTfid[k]].CoverL;//获取与当前元任务冲突的任务的覆盖级别
                        conIndSum = conIndSum + conTWeight / (conTWeight + subTweight) + conTArea / (conTArea + subTarea) + (1 - conTLevel / (conTLevel + (double)GridlstTaskFC[subTFID].CoverL));
                    }
                    ConDgreelist[j] = conIndSum / ((double)3 * ConflictsubTfid.Count);//冲突度 -------------------------------------------------------------------------------------
                    //double subTleftArea = 0;//当前元任务所有冲突剩余面积之和
                    //网格元任务一旦冲突 则剩余能力为0

                    //ConLeftElist[j] = subTleftArea;//剩余能力 -------------------------------------------------------------------------------------
                    double subTleftArea = 0;//当前元任务所有冲突剩余面积之和

                    string subTwinE = "0";//当前元任务的结束观测时间
                    string subTwinS = "0";//当前元任务开始观测时间
                    int subThour;//当前元任务结束时间 小时
                    int subTmin;//当前元任务结束时间 分钟
                    int subTShour;//当前元任务开始时间 小时
                    int subTSmin;//分钟
                    #region 当前元任务时间确定
                    //当前元任务时间确定

                    subTwinE = GridlstTaskFC[subTFID].subTWinE;//当前元任务的结束观测时间
                    subTwinS = GridlstTaskFC[subTFID].subTWinS;//当前元任务的开始观测时间

                    if (subTwinE.Length > 3)
                    {
                        subThour = int.Parse(subTwinE.Substring(0, 2));//任务结束时间 小时                 
                    }
                    else
                    {
                        subThour = int.Parse(subTwinE.Substring(0, 1));//任务结束时间 小时
                    }
                    subTmin = int.Parse(subTwinE.Substring(subTwinE.Length - 2, 2));//任务结束时间 分钟  
                    if (subTwinS.Length > 3)
                    {
                        subTShour = int.Parse(subTwinS.Substring(0, 2));//任务结束时间 小时                 
                    }
                    else
                    {
                        subTShour = int.Parse(subTwinS.Substring(0, 1));//任务结束时间 小时
                    }
                    subTSmin = int.Parse(subTwinS.Substring(subTwinS.Length - 2, 2));//任务结束时间 分钟  
                    #endregion
                    double subTS = subTShour + (double)subTSmin / 60;//当前元任务开始时间
                    double subTE = subThour + (double)subTmin / 60;//当前元任务结束时间

                    #region 资源负载度
                    //当前资源负载度（在当前元任务时间窗口下的资源负载度） 
                    //确定交集时间
                    string otherTwinS = "";//另一个元任务的开始时间
                    string otherTwinE = "";//结束时间
                    int otherTEhour;//另一个元任务结束时间 小时
                    int otherTEmin;//另一个元任务结束时间 分钟
                    int otherTShour;//另一个元任务开始时间 小时
                    int otherTSmin;//分钟
                    double sumOtherArea = 0;//所有其他元任务在当前元任务时间窗口下能够观测的面积之和
                    for (int k = 0; k < subFIDList.Count; k++)//当前资源能够观测的所有元任务
                    {
                        if (k != j)
                        {
                            #region 时间确定
                            //时间确定
                            otherTwinS = GridlstTaskFC[subFIDList[k]].subTWinS;
                            otherTwinE = GridlstTaskFC[subFIDList[k]].subTWinE;
                            if (otherTwinS.Length > 3)
                            {
                                otherTShour = int.Parse(otherTwinS.Substring(0, 2));//任务结束时间 小时                 
                            }
                            else
                            {
                                otherTShour = int.Parse(otherTwinS.Substring(0, 1));//任务结束时间 小时
                            }
                            otherTSmin = int.Parse(otherTwinS.Substring(otherTwinS.Length - 2, 2));//任务结束时间 分钟   
                            if (otherTwinE.Length > 3)
                            {
                                otherTEhour = int.Parse(otherTwinE.Substring(0, 2));//任务结束时间 小时                 
                            }
                            else
                            {
                                otherTEhour = int.Parse(otherTwinE.Substring(0, 1));//任务结束时间 小时
                            }
                            otherTEmin = int.Parse(otherTwinE.Substring(otherTwinE.Length - 2, 2));//任务结束时间 分钟   
                            #endregion
                            double otherTS = otherTShour + (double)otherTSmin / 60;//另一个元任务开始时间
                            double otherTE = otherTEhour + (double)otherTEmin / 60;//结束时间
                            double Tinter = 0;//交集时间 小时
                            #region 确定交集时间
                            if (otherTE - subTS > 0)//判断时间是否有交集
                            {
                                if (subTE - otherTS > 0)//判断时间是否有交集
                                {
                                    if (subTS > otherTS)//otherT时间优先
                                    {
                                        if (subTE > otherTE)//交叉 other优先
                                        { Tinter = otherTE - subTS; }
                                        else// other包含sub
                                        { Tinter = subTE - subTS; }
                                    }
                                    else//当前T时间优先
                                    {
                                        if (subTE < otherTE)//交叉 sub优先
                                        { Tinter = subTE - otherTS; }
                                        else// sub包含other
                                        { Tinter = otherTE - otherTS; }
                                    }
                                }
                            }
                            #endregion

                            double otherTarea = GridlstTaskFC[subFIDList[k]].subTArea;//other元任务面积
                            sumOtherArea = sumOtherArea + (Tinter * otherTarea) / (otherTE - otherTS);
                        }
                    }
                    double UV = double.Parse(UavFL.FeatureClass.GetFeature(UAVFID).get_Value(5).ToString());//巡航速度 km/h
                    double UW = double.Parse(UavFL.FeatureClass.GetFeature(UAVFID).get_Value(8).ToString());//幅宽 m
                    double Loadd = sumOtherArea / ((subTE - subTS) * tR * UV * UW * 1000); //tR假设70%的时间用来飞  30%时间用来观测
                    if (Loadd > 1)
                    { LoadDgreelist[j] = 1; }
                    else
                    { LoadDgreelist[j] = Loadd; }

                    #endregion

                    if (ConRatelist[j] > 0 && ConRatelist[j] < 1)//冲突率大于0小于1
                    {
                        if (ConDgreelist[j] >= 0 && ConDgreelist[j] < 1)//冲突度大于等于0小于1
                        {

                            //资源i观测元任务j的收益                  
                            //UAVReturnsList[j] = alpha  * subTarea * (1 - ConRatelist[j] * ConDgreelist[j]) + beta * ConLeftElist[j] / (double)ConflictsubTfid.Count;//资源i观测元任务j的收益（非加权 仅面积）---------------------;
                            //面积加权当作收益
                            UAVReturnsList[j] = fi * (1 - LoadDgreelist[j]) * subTweight * subTarea / subFIDList.Count + fi2 * (alpha * subTarea * subTweight * (1 - ConRatelist[j] * ConDgreelist[j]));


                        }
                        else
                        {

                        }
                    }
                    else if (ConRatelist[j] == 0) //冲突率=0 即没有冲突
                    {
                        //UAVReturnsList[j] = alpha  * subTarea;
                        UAVReturnsList[j] = fi * (1 - LoadDgreelist[j]) * subTweight * subTarea / subFIDList.Count + fi2 * alpha * subTarea * subTweight;//资源i观测元任务j的收益---------------------;
                    }
                    else
                    { }
                }
                GridUavRTFIDlist[i].conRate = ConRatelist;
                GridUavRTFIDlist[i].conDegree = ConDgreelist;
                //UavRTFIDlist[i].leftEn = ConLeftElist;
                GridUavRTFIDlist[i].Returns = UAVReturnsList;
            }
            #endregion

            #region AS子规划中心启发式准则模型
            //AS收益
            for (int i = 0; i < GridASRTFIDlist.Count; i++)
            {
                int ASFID = GridASRTFIDlist[i].RFID;//资源FID‘
                List<int> subFIDList = GridASRTFIDlist[i].subTaskFID;//当前资源能够观测到的元任务list集合
                List<ConflictTFID> ConTFID = GridASRTFIDlist[i].ConflictTaskFID;//当前资源能够观测的元任务的冲突集合
                //List<StartTime> EleTimeS = GridASRTFIDlist[i].EleTstartTime;//当前资源观测元任务的开始时间集合
                //List<StartTime> EleStartTime

                List<double> ConRatelist = new List<double>(new double[subFIDList.Count]);//元任务冲突率 每一个资源相对于每一个元任务 list长度为观测元任务个数
                List<double> ConDgreelist = new List<double>(new double[subFIDList.Count]);//元任务冲突度
                List<double> LoadDgreelist = new List<double>(new double[subFIDList.Count]);//当前资源观测元任务的负载度
                List<double> ASReturnsList = new List<double>(new double[subFIDList.Count]);//每一个资源相对于每一个元任务的收益
                for (int j = 0; j < subFIDList.Count; j++)
                {

                    int subTFID = subFIDList[j];//获取当前资源观测的一个元任务FID 当前元任务
                    List<int> ConflictsubTfid = new List<int>();//与当前元任务冲突的元任务FID集合                   
                    double subTweight = GridlstTaskFC[subTFID].subTWeight;//元任务权重
                    double subTarea = GridlstTaskFC[subTFID].subTArea;
                    #region ConflictsubTfid赋值
                    for (int k = 0; k < ConTFID.Count; k++)
                    {
                        if (ConTFID[k].firstTFID == subTFID)
                        {
                            ConflictsubTfid.Add(ConTFID[k].secondTFID);
                        }
                        else if (ConTFID[k].secondTFID == subTFID)
                        {
                            ConflictsubTfid.Add(ConTFID[k].firstTFID);
                        }
                    }
                    #endregion

                    ConRatelist[j] = (double)ConflictsubTfid.Count / subFIDList.Count;//冲突率 jm/jn ----------------------------------------------------------------------------
                    double conTWeight;//与当前元任务冲突的任务的权重     
                    double conTArea;//冲突面积
                    double conTLevel;//与当前元任务冲突的任务的覆盖级别
                    double conIndSum = 0;//三个指标计算之和   冲突度模型括号里面和
                    for (int k = 0; k < ConflictsubTfid.Count; k++)
                    {
                        conTArea = GridlstTaskFC[ConflictsubTfid[k]].subTArea;//获取与当前元任务冲突的任务的面积
                        conTWeight = GridlstTaskFC[ConflictsubTfid[k]].subTWeight;//获取与当前元任务冲突的任务的权重 lstTaskFC的第几个即对应元任务的FID   
                        conTLevel = GridlstTaskFC[ConflictsubTfid[k]].CoverL;//获取与当前元任务冲突的任务的覆盖级别
                        conIndSum = conIndSum + conTWeight / (conTWeight + subTweight) + conTArea / (conTArea + subTarea) + (1 - conTLevel / (conTLevel + (double)GridlstTaskFC[subTFID].CoverL));
                    }
                    ConDgreelist[j] = conIndSum / ((double)3 * ConflictsubTfid.Count);//冲突度 -------------------------------------------------------------------------------------
                    //double subTleftArea = 0;//当前元任务所有冲突剩余面积之和
                    //网格元任务一旦冲突 则剩余能力为0

                    //ConLeftElist[j] = subTleftArea;//剩余能力 -------------------------------------------------------------------------------------

                    string subTwinE = "0";//当前元任务的结束观测时间
                    string subTwinS = "0";//当前元任务开始观测时间
                    int subThour;//当前元任务结束时间 小时
                    int subTmin;//当前元任务结束时间 分钟
                    int subTShour;//当前元任务开始时间 小时
                    int subTSmin;//分钟
                    #region 当前元任务时间确定
                    //当前元任务时间确定

                    subTwinE = GridlstTaskFC[subTFID].subTWinE;//当前元任务的结束观测时间
                    subTwinS = GridlstTaskFC[subTFID].subTWinS;//当前元任务的开始观测时间

                    if (subTwinE.Length > 3)
                    {
                        subThour = int.Parse(subTwinE.Substring(0, 2));//任务结束时间 小时                 
                    }
                    else
                    {
                        subThour = int.Parse(subTwinE.Substring(0, 1));//任务结束时间 小时
                    }
                    subTmin = int.Parse(subTwinE.Substring(subTwinE.Length - 2, 2));//任务结束时间 分钟  
                    if (subTwinS.Length > 3)
                    {
                        subTShour = int.Parse(subTwinS.Substring(0, 2));//任务结束时间 小时                 
                    }
                    else
                    {
                        subTShour = int.Parse(subTwinS.Substring(0, 1));//任务结束时间 小时
                    }
                    subTSmin = int.Parse(subTwinS.Substring(subTwinS.Length - 2, 2));//任务结束时间 分钟  
                    #endregion
                    double subTS = subTShour + (double)subTSmin / 60;//当前元任务开始时间
                    double subTE = subThour + (double)subTmin / 60;//当前元任务结束时间

                    #region 资源负载度
                    //当前资源负载度（在当前元任务时间窗口下的资源负载度） 
                    //确定交集时间
                    string otherTwinS = "";//另一个元任务的开始时间
                    string otherTwinE = "";//结束时间
                    int otherTEhour;//另一个元任务结束时间 小时
                    int otherTEmin;//另一个元任务结束时间 分钟
                    int otherTShour;//另一个元任务开始时间 小时
                    int otherTSmin;//分钟
                    double sumOtherArea = 0;//所有其他元任务在当前元任务时间窗口下能够观测的面积之和
                    for (int k = 0; k < subFIDList.Count; k++)//当前资源能够观测的所有元任务
                    {
                        if (k != j)
                        {
                            #region 时间确定
                            //时间确定
                            otherTwinS = GridlstTaskFC[subFIDList[k]].subTWinS;
                            otherTwinE = GridlstTaskFC[subFIDList[k]].subTWinE;
                            if (otherTwinS.Length > 3)
                            {
                                otherTShour = int.Parse(otherTwinS.Substring(0, 2));//任务结束时间 小时                 
                            }
                            else
                            {
                                otherTShour = int.Parse(otherTwinS.Substring(0, 1));//任务结束时间 小时
                            }
                            otherTSmin = int.Parse(otherTwinS.Substring(otherTwinS.Length - 2, 2));//任务结束时间 分钟   
                            if (otherTwinE.Length > 3)
                            {
                                otherTEhour = int.Parse(otherTwinE.Substring(0, 2));//任务结束时间 小时                 
                            }
                            else
                            {
                                otherTEhour = int.Parse(otherTwinE.Substring(0, 1));//任务结束时间 小时
                            }
                            otherTEmin = int.Parse(otherTwinE.Substring(otherTwinE.Length - 2, 2));//任务结束时间 分钟   
                            #endregion
                            double otherTS = otherTShour + (double)otherTSmin / 60;//另一个元任务开始时间
                            double otherTE = otherTEhour + (double)otherTEmin / 60;//结束时间
                            double Tinter = 0;//交集时间 小时
                            #region 确定交集时间
                            if (otherTE - subTS > 0)//判断时间是否有交集
                            {
                                if (subTE - otherTS > 0)//判断时间是否有交集
                                {
                                    if (subTS > otherTS)//otherT时间优先
                                    {
                                        if (subTE > otherTE)//交叉 other优先
                                        { Tinter = otherTE - subTS; }
                                        else// other包含sub
                                        { Tinter = subTE - subTS; }
                                    }
                                    else//当前T时间优先
                                    {
                                        if (subTE < otherTE)//交叉 sub优先
                                        { Tinter = subTE - otherTS; }
                                        else// sub包含other
                                        { Tinter = otherTE - otherTS; }
                                    }
                                }
                            }
                            #endregion

                            double otherTarea = GridlstTaskFC[subFIDList[k]].subTArea;//other元任务面积
                            sumOtherArea = sumOtherArea + (Tinter * otherTarea) / (otherTE - otherTS);
                        }
                    }
                    double UV = double.Parse(ASFL.FeatureClass.GetFeature(ASFID).get_Value(5).ToString());//巡航速度 km/h
                    double UW = double.Parse(ASFL.FeatureClass.GetFeature(ASFID).get_Value(7).ToString());//幅宽 m
                    double Loadd = sumOtherArea / ((subTE - subTS) * tR * UV * UW * 1000);
                    if (Loadd > 1)
                    { LoadDgreelist[j] = 1; }
                    else
                    { LoadDgreelist[j] = Loadd; }

                    #endregion


                    if (ConRatelist[j] > 0 && ConRatelist[j] < 1)//冲突率大于0小于1
                    {
                        if (ConDgreelist[j] >= 0 && ConDgreelist[j] < 1)//冲突度大于等于0小于1
                        {

                            //资源i观测元任务j的收益                  
                            //UAVReturnsList[j] = alpha  * subTarea * (1 - ConRatelist[j] * ConDgreelist[j]) + beta * ConLeftElist[j] / (double)ConflictsubTfid.Count;//资源i观测元任务j的收益（非加权 仅面积）---------------------;
                            //面积加权当作收益
                            ASReturnsList[j] = fi * (1 - LoadDgreelist[j]) * subTweight * subTarea / subFIDList.Count + fi2 * (alpha * subTarea * subTweight * (1 - ConRatelist[j] * ConDgreelist[j]));


                        }
                        else
                        {

                        }
                    }
                    else if (ConRatelist[j] == 0) //冲突率=0 即没有冲突
                    {
                        //UAVReturnsList[j] = alpha  * subTarea;
                        ASReturnsList[j] = fi * (1 - LoadDgreelist[j]) * subTweight * subTarea / subFIDList.Count + fi2 * alpha * subTarea * subTweight;//资源i观测元任务j的收益---------------------;
                    }
                    else
                    { }
                }
                GridASRTFIDlist[i].conRate = ConRatelist;
                GridASRTFIDlist[i].conDegree = ConDgreelist;
                //UavRTFIDlist[i].leftEn = ConLeftElist;
                GridASRTFIDlist[i].Returns = ASReturnsList;
            }
            #endregion

            #region 车辆子规划中心启发式准则模型
            //Car收益
            for (int i = 0; i < GridCarRTFIDlist.Count; i++)
            {
                int CarFID = GridCarRTFIDlist[i].RFID;//资源FID‘
                List<int> subFIDList = GridCarRTFIDlist[i].subTaskFID;//当前资源能够观测到的元任务list集合
                List<ConflictTFID> ConTFID = GridCarRTFIDlist[i].ConflictTaskFID;//当前资源能够观测的元任务的冲突集合
                //List<StartTime> EleTimeS = GridCarRTFIDlist[i].EleTstartTime;//当前资源观测元任务的开始时间集合
                //List<StartTime> EleStartTime

                List<double> ConRatelist = new List<double>(new double[subFIDList.Count]);//元任务冲突率 每一个资源相对于每一个元任务 list长度为观测元任务个数
                List<double> ConDgreelist = new List<double>(new double[subFIDList.Count]);//元任务冲突度
                List<double> LoadDgreelist = new List<double>(new double[subFIDList.Count]);//当前资源观测元任务的负载度
                List<double> CarReturnsList = new List<double>(new double[subFIDList.Count]);//每一个资源相对于每一个元任务的收益
                for (int j = 0; j < subFIDList.Count; j++)
                {

                    int subTFID = subFIDList[j];//获取当前资源观测的一个元任务FID 当前元任务
                    List<int> ConflictsubTfid = new List<int>();//与当前元任务冲突的元任务FID集合                   
                    double subTweight = GridlstTaskFC[subTFID].subTWeight;//元任务权重
                    double subTarea = GridlstTaskFC[subTFID].subTArea;
                    #region ConflictsubTfid赋值
                    for (int k = 0; k < ConTFID.Count; k++)
                    {
                        if (ConTFID[k].firstTFID == subTFID)
                        {
                            ConflictsubTfid.Add(ConTFID[k].secondTFID);
                        }
                        else if (ConTFID[k].secondTFID == subTFID)
                        {
                            ConflictsubTfid.Add(ConTFID[k].firstTFID);
                        }
                    }
                    #endregion

                    ConRatelist[j] = (double)ConflictsubTfid.Count / subFIDList.Count;//冲突率 jm/jn ----------------------------------------------------------------------------
                    double conTWeight;//与当前元任务冲突的任务的权重     
                    double conTArea;//冲突面积
                    double conTLevel;//与当前元任务冲突的任务的覆盖级别
                    double conIndSum = 0;//三个指标计算之和   冲突度模型括号里面和
                    for (int k = 0; k < ConflictsubTfid.Count; k++)
                    {
                        conTArea = GridlstTaskFC[ConflictsubTfid[k]].subTArea;//获取与当前元任务冲突的任务的面积
                        conTWeight = GridlstTaskFC[ConflictsubTfid[k]].subTWeight;//获取与当前元任务冲突的任务的权重 lstTaskFC的第几个即对应元任务的FID   
                        conTLevel = GridlstTaskFC[ConflictsubTfid[k]].CoverL;//获取与当前元任务冲突的任务的覆盖级别
                        conIndSum = conIndSum + conTWeight / (conTWeight + subTweight) + conTArea / (conTArea + subTarea) + (1 - conTLevel / (conTLevel + (double)GridlstTaskFC[subTFID].CoverL));
                    }
                    ConDgreelist[j] = conIndSum / ((double)3 * ConflictsubTfid.Count);//冲突度 -------------------------------------------------------------------------------------
                    //double subTleftArea = 0;//当前元任务所有冲突剩余面积之和
                    //网格元任务一旦冲突 则剩余能力为0

                    //ConLeftElist[j] = subTleftArea;//剩余能力 -------------------------------------------------------------------------------------

                    string subTwinE = "0";//当前元任务的结束观测时间
                    string subTwinS = "0";//当前元任务开始观测时间
                    int subThour;//当前元任务结束时间 小时
                    int subTmin;//当前元任务结束时间 分钟
                    int subTShour;//当前元任务开始时间 小时
                    int subTSmin;//分钟
                    #region 当前元任务时间确定
                    //当前元任务时间确定

                    subTwinE = GridlstTaskFC[subTFID].subTWinE;//当前元任务的结束观测时间
                    subTwinS = GridlstTaskFC[subTFID].subTWinS;//当前元任务的开始观测时间

                    if (subTwinE.Length > 3)
                    {
                        subThour = int.Parse(subTwinE.Substring(0, 2));//任务结束时间 小时                 
                    }
                    else
                    {
                        subThour = int.Parse(subTwinE.Substring(0, 1));//任务结束时间 小时
                    }
                    subTmin = int.Parse(subTwinE.Substring(subTwinE.Length - 2, 2));//任务结束时间 分钟  
                    if (subTwinS.Length > 3)
                    {
                        subTShour = int.Parse(subTwinS.Substring(0, 2));//任务结束时间 小时                 
                    }
                    else
                    {
                        subTShour = int.Parse(subTwinS.Substring(0, 1));//任务结束时间 小时
                    }
                    subTSmin = int.Parse(subTwinS.Substring(subTwinS.Length - 2, 2));//任务结束时间 分钟  
                    #endregion
                    double subTS = subTShour + (double)subTSmin / 60;//当前元任务开始时间
                    double subTE = subThour + (double)subTmin / 60;//当前元任务结束时间

                    #region 资源负载度
                    //当前资源负载度（在当前元任务时间窗口下的资源负载度） 
                    //确定交集时间
                    string otherTwinS = "";//另一个元任务的开始时间
                    string otherTwinE = "";//结束时间
                    int otherTEhour;//另一个元任务结束时间 小时
                    int otherTEmin;//另一个元任务结束时间 分钟
                    int otherTShour;//另一个元任务开始时间 小时
                    int otherTSmin;//分钟
                    double sumOtherArea = 0;//所有其他元任务在当前元任务时间窗口下能够观测的面积之和
                    for (int k = 0; k < subFIDList.Count; k++)//当前资源能够观测的所有元任务
                    {
                        if (k != j)
                        {
                            #region 时间确定
                            //时间确定
                            otherTwinS = GridlstTaskFC[subFIDList[k]].subTWinS;
                            otherTwinE = GridlstTaskFC[subFIDList[k]].subTWinE;
                            if (otherTwinS.Length > 3)
                            {
                                otherTShour = int.Parse(otherTwinS.Substring(0, 2));//任务结束时间 小时                 
                            }
                            else
                            {
                                otherTShour = int.Parse(otherTwinS.Substring(0, 1));//任务结束时间 小时
                            }
                            otherTSmin = int.Parse(otherTwinS.Substring(otherTwinS.Length - 2, 2));//任务结束时间 分钟   
                            if (otherTwinE.Length > 3)
                            {
                                otherTEhour = int.Parse(otherTwinE.Substring(0, 2));//任务结束时间 小时                 
                            }
                            else
                            {
                                otherTEhour = int.Parse(otherTwinE.Substring(0, 1));//任务结束时间 小时
                            }
                            otherTEmin = int.Parse(otherTwinE.Substring(otherTwinE.Length - 2, 2));//任务结束时间 分钟   
                            #endregion
                            double otherTS = otherTShour + (double)otherTSmin / 60;//另一个元任务开始时间
                            double otherTE = otherTEhour + (double)otherTEmin / 60;//结束时间
                            double Tinter = 0;//交集时间 小时
                            #region 确定交集时间
                            if (otherTE - subTS > 0)//判断时间是否有交集
                            {
                                if (subTE - otherTS > 0)//判断时间是否有交集
                                {
                                    if (subTS > otherTS)//otherT时间优先
                                    {
                                        if (subTE > otherTE)//交叉 other优先
                                        { Tinter = otherTE - subTS; }
                                        else// other包含sub
                                        { Tinter = subTE - subTS; }
                                    }
                                    else//当前T时间优先
                                    {
                                        if (subTE < otherTE)//交叉 sub优先
                                        { Tinter = subTE - otherTS; }
                                        else// sub包含other
                                        { Tinter = otherTE - otherTS; }
                                    }
                                }
                            }
                            #endregion

                            double otherTarea = GridlstTaskFC[subFIDList[k]].subTArea;//other元任务面积
                            sumOtherArea = sumOtherArea + (Tinter * otherTarea) / (otherTE - otherTS);
                        }
                    }
                    double CarOberV = double.Parse(CarFeatureLayer.FeatureClass.GetFeature(CarFID).get_Value(8).ToString());//观测速度 km/h
                    double CarW = double.Parse(CarFeatureLayer.FeatureClass.GetFeature(CarFID).get_Value(6).ToString());//幅宽 m
                    double Loadd = sumOtherArea / ((subTE - subTS) * tR * CarOberV * CarW * 1000);
                    if (Loadd > 1)
                    { LoadDgreelist[j] = 1; }
                    else
                    { LoadDgreelist[j] = Loadd; }

                    #endregion


                    if (ConRatelist[j] > 0 && ConRatelist[j] < 1)//冲突率大于0小于1
                    {
                        if (ConDgreelist[j] >= 0 && ConDgreelist[j] < 1)//冲突度大于等于0小于1
                        {

                            //资源i观测元任务j的收益                  
                            //UAVReturnsList[j] = alpha  * subTarea * (1 - ConRatelist[j] * ConDgreelist[j]) + beta * ConLeftElist[j] / (double)ConflictsubTfid.Count;//资源i观测元任务j的收益（非加权 仅面积）---------------------;
                            //面积加权当作收益
                            CarReturnsList[j] = fi * (1 - LoadDgreelist[j]) * subTweight * subTarea / subFIDList.Count + fi2 * (alpha * subTarea * subTweight * (1 - ConRatelist[j] * ConDgreelist[j]));


                        }
                        else
                        {

                        }
                    }
                    else if (ConRatelist[j] == 0) //冲突率=0 即没有冲突
                    {
                        //UAVReturnsList[j] = alpha  * subTarea;
                        CarReturnsList[j] = fi * (1 - LoadDgreelist[j]) * subTweight * subTarea / subFIDList.Count + fi2 * alpha * subTarea * subTweight;//资源i观测元任务j的收益---------------------;
                    }
                    else
                    { }
                }
                GridCarRTFIDlist[i].conRate = ConRatelist;
                GridCarRTFIDlist[i].conDegree = ConDgreelist;
                //UavRTFIDlist[i].leftEn = ConLeftElist;
                GridCarRTFIDlist[i].Returns = CarReturnsList;
            }
            #endregion

            #region Sat子规划中心启发式准则模型
            //卫星收益
            //卫星子规划中心模型.
            //卫星不观测元任务 只考虑卫星观测的子任务不进行划分
            //double SatPlanCenGain = 0;//卫星子规划中心总体收益 元任务不一定分配给此规划中心 要在算法上计算 
            // satAtributeFL:SateliteLine卫星集合   SatFeLayer:SatElementTask冲突子任务集合
            for (int i = 0; i < satRTFIDlist.Count; i++)
            {
                int SatRFID = satRTFIDlist[i].RFID;//卫星FID‘
                IFeature SatFea = satAtributeFL.FeatureClass.GetFeature(SatRFID);//当前卫星（获取属性）SatelinteLine图层

                double Vengel = double.Parse(SatFea.get_Value(10).ToString()); //侧摆角转向速度 度每秒
                double storeV = double.Parse(SatFea.get_Value(9).ToString()); //星上存储容量 GB
                double intervalT = double.Parse(SatFea.get_Value(11).ToString()); //开机间隔时间 秒
                double staT = double.Parse(SatFea.get_Value(12).ToString()); //侧摆之后稳定时间 秒


                List<int> subFIDList = satRTFIDlist[i].subTaskFID;//当前资源能够观测到的元任务list集合
                List<ConflictTFID> ConTFID = satRTFIDlist[i].ConflictTaskFID;//当前卫星能够观测的子任务的冲突集合 SatElementTask的FID
                List<double> ConRatelist = new List<double>(new double[subFIDList.Count]);//元任务冲突率 每一个资源相对于每一个元任务 list长度为观测元任务个数
                List<double> ConDgreelist = new List<double>(new double[subFIDList.Count]);//元任务冲突度
                List<double> ConLeftElist = new List<double>(new double[subFIDList.Count]);//元任务冲突剩余能力 存储冲突之后能够观测的当前任务的面积s之和 （所有冲突之后的面积之和S1+S2+...+Sjm） （不是概率p）
                List<double> LoadDgreelist = new List<double>(new double[subFIDList.Count]);//任务负载度
                List<double> SatReturns = new List<double>(new double[subFIDList.Count]);//每一个资源观测每一个任务的收益
                for (int j = 0; j < subFIDList.Count; j++)//遍历当前资源能够观测到的元任务
                {
                    int subTFID = subFIDList[j];//获取当前资源观测的一个任务FID 卫星观测当前子任务
                    List<int> ConflictsubTfid = new List<int>();//与当前子任务冲突的子任务FID集合

                    #region ConflictsubTfid赋值
                    for (int k = 0; k < ConTFID.Count; k++)
                    {
                        if (ConTFID[k].firstTFID == subTFID)
                        {
                            ConflictsubTfid.Add(ConTFID[k].secondTFID);
                        }
                        else if (ConTFID[k].secondTFID == subTFID)
                        {
                            ConflictsubTfid.Add(ConTFID[k].firstTFID);
                        }
                    }
                    #endregion

                    ConRatelist[j] = (double)ConflictsubTfid.Count / subFIDList.Count;//冲突率 jm/jn ----------------------------------------------------------------------------

                    IFeature CurrentFe = SatFL.FeatureClass.GetFeature(subTFID);//SatElementTask中当前子任务要素
                    IPolygon CurrentTPolygon = CurrentFe.Shape as IPolygon;
                    IArea CurrentTarea = CurrentTPolygon as IArea;
                    double currentTWeight = double.Parse(CurrentFe.get_Value(6).ToString());//当前子任务的权重
                    double currentTArea = CurrentTarea.Area;//当前子任务的面积
                    double currentTLevel = 1;
                    double conTWeight;//与当前元任务冲突的任务的权重
                    double conTArea;//与当前元任务冲突的任务的面积
                    double conTLevel;//与当前元任务冲突的任务的覆盖级别
                    double conIndSum = 0;//三个指标计算之和   冲突度模型括号里面和
                    for (int k = 0; k < ConflictsubTfid.Count; k++)
                    {
                        IFeature conFe = SatFL.FeatureClass.GetFeature(ConflictsubTfid[k]);//SatElementTask中与当前子任务冲突的子任务要素
                        IPolygon ConTPolygon = conFe.Shape as IPolygon;
                        IArea ConTarea = ConTPolygon as IArea;
                        conTWeight = double.Parse(conFe.get_Value(6).ToString()); //获取与当前元任务冲突的任务的权重
                        conTArea = ConTarea.Area;//获取与当前元任务冲突的任务的面积
                        conTLevel = 1;//卫星子任务的覆盖级别默认为1 
                        conIndSum = conIndSum + conTWeight / (conTWeight + currentTWeight) + conTArea / (conTArea + currentTArea) + (1 - conTLevel / (conTLevel + currentTLevel));
                    }
                    ConDgreelist[j] = conIndSum / ((double)3 * ConflictsubTfid.Count);//冲突度 -------------------------------------------------------------------------------------                  
                    //卫星一旦冲突即不观测冲突任务，所以剩余能力为0
                    #region 卫星一旦冲突即不观测 冲突任务
                    double subTleftArea = 0;//当前元任务所有冲突剩余面积之和
                    #endregion

                    ConLeftElist[j] = subTleftArea;//剩余能力 -------------------------------------------------------------------------------------

                    #region 资源负载度
                    //当前资源负载度（在当前元任务时间窗口下的资源负载度） 

                    string subTwinS = CurrentFe.get_Value(10).ToString();//获取当前任务的开始观测时间
                    string subTwinE = CurrentFe.get_Value(11).ToString();//获取任务的结束观测时间

                    int subThour;//当前元任务结束时间 小时
                    double subTmin;//当前元任务结束时间 分钟
                    int subTShour;//当前元任务开始时间 小时
                    double subTSmin;//分钟
                    #region 当前任务时间确定
                    if (subTwinS.Contains("."))
                    {
                        string HourAndMin = subTwinS.Substring(0, subTwinS.IndexOf("."));
                        if (HourAndMin.Length > 3)
                        {
                            subTShour = int.Parse(HourAndMin.Substring(0, 2));//第一个任务开始观测时间  小时                 
                        }
                        else
                        {
                            subTShour = int.Parse(HourAndMin.Substring(0, 1));//
                        }
                        subTSmin = double.Parse(HourAndMin.Substring(HourAndMin.Length - 2, 2) + subTwinS.Substring(subTwinS.IndexOf(".")));//第一个任务开始观测时间  分钟  
                    }
                    else
                    {
                        if (subTwinS.Length > 3)
                        {
                            subTShour = int.Parse(subTwinS.Substring(0, 2));// 
                        }
                        else
                        {
                            subTShour = int.Parse(subTwinS.Substring(0, 1));//
                        }
                        subTSmin = int.Parse(subTwinS.Substring(subTwinS.Length - 2, 2));//
                    }

                    /////////////////

                    if (subTwinE.Contains("."))
                    {
                        string HourAndMin = subTwinE.Substring(0, subTwinE.IndexOf("."));
                        if (HourAndMin.Length > 3)
                        {
                            subThour = int.Parse(HourAndMin.Substring(0, 2));//第一个任务开始观测时间  小时                 
                        }
                        else
                        {
                            subThour = int.Parse(HourAndMin.Substring(0, 1));//
                        }
                        subTmin = double.Parse(HourAndMin.Substring(HourAndMin.Length - 2, 2) + subTwinE.Substring(subTwinE.IndexOf(".")));//第一个任务开始观测时间  分钟  
                    }
                    else
                    {
                        if (subTwinE.Length > 3)
                        {
                            subThour = int.Parse(subTwinE.Substring(0, 2));// 
                        }
                        else
                        {
                            subThour = int.Parse(subTwinE.Substring(0, 1));//
                        }
                        subTmin = int.Parse(subTwinE.Substring(subTwinE.Length - 2, 2));//
                    }
                    #endregion
                    double subTS = subTShour + (double)subTSmin / 60;//当前元任务开始时间
                    double subTE = subThour + (double)subTmin / 60;//当前元任务开始时间
                    //确定交集时间
                    string otherTwinS = "";//另一个元任务的开始时间
                    string otherTwinE = "";//结束时间
                    int otherTEhour;//另一个元任务结束时间 小时
                    double otherTEmin;//另一个元任务结束时间 分钟
                    int otherTShour;//另一个元任务开始时间 小时
                    double otherTSmin;//分钟
                    double sumTinter = 0;//所有其他元任务在当前元任务时间窗口下能够观测的面积之和
                    for (int k = 0; k < subFIDList.Count; k++)//当前资源能够观测的所有元任务
                    {
                        if (k != j)
                        {
                            #region 时间确定
                            //时间确定

                            otherTwinS = SatFL.FeatureClass.GetFeature(subFIDList[k]).get_Value(10).ToString();//另一个任务开始观测时间
                            otherTwinE = SatFL.FeatureClass.GetFeature(subFIDList[k]).get_Value(11).ToString();

                            if (otherTwinS.Contains("."))
                            {
                                string HourAndMin = otherTwinS.Substring(0, otherTwinS.IndexOf("."));
                                if (HourAndMin.Length > 3)
                                {
                                    otherTShour = int.Parse(HourAndMin.Substring(0, 2));//第一个任务开始观测时间  小时                 
                                }
                                else
                                {
                                    otherTShour = int.Parse(HourAndMin.Substring(0, 1));//
                                }
                                otherTSmin = double.Parse(HourAndMin.Substring(HourAndMin.Length - 2, 2) + otherTwinS.Substring(otherTwinS.IndexOf(".")));//第一个任务开始观测时间  分钟  
                            }
                            else
                            {
                                if (otherTwinS.Length > 3)
                                {
                                    otherTShour = int.Parse(otherTwinS.Substring(0, 2));// 
                                }
                                else
                                {
                                    otherTShour = int.Parse(otherTwinS.Substring(0, 1));//
                                }
                                otherTSmin = int.Parse(otherTwinS.Substring(otherTwinS.Length - 2, 2));//
                            }

                            /////////////////

                            if (otherTwinE.Contains("."))
                            {
                                string HourAndMin = otherTwinE.Substring(0, otherTwinE.IndexOf("."));
                                if (HourAndMin.Length > 3)
                                {
                                    otherTEhour = int.Parse(HourAndMin.Substring(0, 2));//第一个任务开始观测时间  小时                 
                                }
                                else
                                {
                                    otherTEhour = int.Parse(HourAndMin.Substring(0, 1));//
                                }
                                otherTEmin = double.Parse(HourAndMin.Substring(HourAndMin.Length - 2, 2) + otherTwinE.Substring(otherTwinE.IndexOf(".")));//第一个任务开始观测时间  分钟  
                            }
                            else
                            {
                                if (otherTwinE.Length > 3)
                                {
                                    otherTEhour = int.Parse(otherTwinE.Substring(0, 2));// 
                                }
                                else
                                {
                                    otherTEhour = int.Parse(otherTwinE.Substring(0, 1));//
                                }
                                otherTEmin = int.Parse(otherTwinE.Substring(otherTwinE.Length - 2, 2));//
                            }
                            #endregion
                            double otherTS = otherTShour + (double)otherTSmin / 60;//另一个元任务开始时间
                            double otherTE = otherTEhour + (double)otherTEmin / 60;//结束时间
                            double Tinter = 0;//交集时间 小时
                            #region 确定交集时间
                            if (otherTE - subTS > 0)//判断时间是否有交集
                            {
                                if (subTE - otherTS > 0)//判断时间是否有交集
                                {
                                    if (subTS > otherTS)//otherT时间优先
                                    {
                                        if (subTE > otherTE)//交叉 other优先
                                        { Tinter = otherTE - subTS; }
                                        else// other包含sub
                                        { Tinter = subTE - subTS; }
                                    }
                                    else//当前T时间优先
                                    {
                                        if (subTE < otherTE)//交叉 sub优先
                                        { Tinter = subTE - otherTS; }
                                        else// sub包含other
                                        { Tinter = otherTE - otherTS; }
                                    }
                                }
                            }
                            #endregion
                            //IFeature otherFe = SatFeLayer.FeatureClass.GetFeature(subFIDList[k]);//SatElementTask中当前子任务要素
                            //IPolygon otherTPolygon = otherFe.Shape as IPolygon;
                            //IArea otherTarea = otherTPolygon as IArea;
                            //double otherTarea = lstTaskFC[subFIDList[k]].subTArea;//other元任务面积
                            sumTinter = sumTinter + Tinter;
                        }
                    }

                    //double ASW = double.Parse(ASFea.get_Value(7).ToString());//幅宽 m
                    double Loadd = sumTinter / (subTE - subTS);
                    if (Loadd > 1)
                    { LoadDgreelist[j] = 1; }
                    else
                    { LoadDgreelist[j] = Loadd; }

                    #endregion

                    if (ConRatelist[j] > 0 && ConRatelist[j] < 1)//冲突率大于0小于1
                    {
                        if (ConDgreelist[j] >= 0 && ConDgreelist[j] < 1)//冲突度大于等于0小于1
                        {

                            //资源i观测元任务j的收益                  
                            //SatReturns[j] = alpha * currentTArea * (1 - ConRatelist[j] * ConDgreelist[j]) + beta * ConLeftElist[j] / (double)ConflictsubTfid.Count;//资源i观测元任务j的收益---------------------
                            SatReturns[j] = fi * (1 - LoadDgreelist[j]) * currentTWeight * currentTArea / subFIDList.Count + fi2 * (alpha * currentTWeight * currentTArea * (1 - ConRatelist[j] * ConDgreelist[j]));

                        }
                        else
                        { }
                    }
                    else if (ConRatelist[j] == 0) //冲突率=0 即没有冲突
                    {
                        //SatReturns[j] = alpha * currentTArea;//资源i观测元任务j的收益---------------------;
                        SatReturns[j] = fi * (1 - LoadDgreelist[j]) * currentTWeight * currentTArea / subFIDList.Count + fi2 * alpha * currentTWeight * currentTArea;
                    }
                    else
                    { }


                }
                satRTFIDlist[i].conRate = ConRatelist;
                satRTFIDlist[i].conDegree = ConDgreelist;
                satRTFIDlist[i].leftEn = ConLeftElist;
                satRTFIDlist[i].Returns = SatReturns;
            }
            #endregion


            #endregion
            List<Sat_ElementTFID> SatTElementT;//存储每一个卫星观测子任务与能够覆盖的元任务的FID对应关系
            SatSubTtoEleT(SatFL, GridTaskFL, out SatTElementT);

            #region 信息输出excel
            //建立Excel对象
            Microsoft.Office.Interop.Excel.Application ElemtTExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workbooks = ElemtTExcel.Application.Workbooks.Add(true);
            ElemtTExcel.Visible = true; // isShowExcle;//是否打开该Excel文件

            for (int i = 0; i < 4; i++)//新建几个sheet
            { ElemtTExcel.Sheets.Add(); }

            //将元任务信息输出 lstTaskFC 以便在matlab中画图
            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbooks.Sheets[1];
            worksheet.Name = "GridElementTinfo";
            //填充数据

            for (int j = 0; j < GridlstTaskFC.Count; j++)// 列数：元任务个数
            {
                worksheet.Cells[2, j + 1] = GridlstTaskFC[j].subTWeight; //存储每一个子任务的权重

            }


            #region 子规划平台观测元任务的收益 形成收益矩阵 每一列表示元任务 每一行表示每一个资源（3个）
            //将子规划平台观测元任务的收益 添加到lsttaskFc中  一个元任务对应所有资源收益（）
            //声明一个m行n列的收益矩阵 m：所有资源个数   n：元任务个数
            int ResouceNO = GridUavRTFIDlist.Count + GridASRTFIDlist.Count + GridCarRTFIDlist.Count + satRTFIDlist.Count;//资源数目
            int ElemTno = GridTaskFL.FeatureClass.FeatureCount(null);//元任务数目
            double[,] ReMa = new double[ResouceNO, ElemTno];
            for (int i = 0; i < GridlstTaskFC.Count; i++)//遍历元任务
            {
                int ElemTFID = int.Parse(GridlstTaskFC[i].subTFID.ToString());//元任务FID
                //无人机平台收益
                List<int> UavFidlst = GridlstTaskFC[i].UAVFID;//能够观测到此元任务的无人机列表
                for (int j = 0; j < UavFidlst.Count; j++)//遍历能够观测到此元任务的每一个无人机
                {
                    int UavFid = UavFidlst[j];//无人机FID
                    for (int k = 0; k < GridUavRTFIDlist.Count; k++)//遍历无人机列表
                    {
                        if (UavFid == GridUavRTFIDlist[k].RFID)//选中此无人机
                        {
                            for (int l = 0; l < GridUavRTFIDlist[k].subTaskFID.Count; l++)//遍历此无人机能够观测的元任务
                            {
                                if (GridUavRTFIDlist[k].subTaskFID[l] == ElemTFID)
                                {
                                    ReMa[UavFid, ElemTFID] = GridUavRTFIDlist[k].Returns[l];//每一个资源观测每一个元任务形成的收益矩阵
                                    GridlstTaskFC[i].UAVReturns = GridlstTaskFC[i].UAVReturns + GridUavRTFIDlist[k].Returns[l];//获取子规划中心观测此元任务收益 平台收益矩阵
                                    break;
                                }
                            }
                            break;
                        }
                    }
                }
                //飞艇平台收益
                List<int> ASFidlst = GridlstTaskFC[i].ASFID;//能够观测到此元任务的飞艇列表
                for (int j = 0; j < ASFidlst.Count; j++)//遍历能够观测到此元任务的每一个AS
                {
                    int AsFid = ASFidlst[j];//AS FID
                    for (int k = 0; k < GridASRTFIDlist.Count; k++)//遍历AS列表
                    {
                        if (AsFid == GridASRTFIDlist[k].RFID)//选中此AS
                        {
                            for (int l = 0; l < GridASRTFIDlist[k].subTaskFID.Count; l++)//遍历此AS能够观测的元任务
                            {
                                if (GridASRTFIDlist[k].subTaskFID[l] == ElemTFID)
                                {
                                    ReMa[GridUavRTFIDlist.Count + AsFid, ElemTFID] = GridASRTFIDlist[k].Returns[l];//每一个资源观测每一个元任务形成的收益矩阵
                                    GridlstTaskFC[i].ASReturns = GridlstTaskFC[i].ASReturns + GridASRTFIDlist[k].Returns[l];//获取子规划中心观测此元任务收益
                                    break;
                                }
                            }
                            break;
                        }
                    }
                }
                //地面车平台收益
                List<int> CarFidlst = GridlstTaskFC[i].CarFID;//能够观测到此元任务的Car列表
                for (int j = 0; j < CarFidlst.Count; j++)//遍历能够观测到此元任务的每一个car
                {
                    int CarFid = CarFidlst[j];//car FID

                    for (int k = 0; k < GridCarRTFIDlist.Count; k++)//遍历car列表
                    {
                        if (CarFid == GridCarRTFIDlist[k].RFID)//选中此car
                        {
                            for (int l = 0; l < GridCarRTFIDlist[k].subTaskFID.Count; l++)//遍历此car能够观测的元任务
                            {
                                if (GridCarRTFIDlist[k].subTaskFID[l] == ElemTFID)
                                {
                                    ReMa[GridUavRTFIDlist.Count + GridASRTFIDlist.Count + CarFid, ElemTFID] = GridCarRTFIDlist[k].Returns[l];//每一个资源观测每一个元任务形成的收益矩阵
                                    GridlstTaskFC[i].CarReturns = GridlstTaskFC[i].CarReturns + GridCarRTFIDlist[k].Returns[l];//获取子规划中心观测此元任务收益
                                    break;
                                }
                            }
                            break;
                        }
                    }
                }
                //卫星平台收益
                for (int j = 0; j < SatTElementT.Count; j++)//遍历卫星观测的子任务
                {
                    int SatFID = SatTElementT[j].SatFID;//卫星FID
                    for (int l = 0; l < SatTElementT[j].ElementTaskFID.Count; l++)//遍历卫星观测的一个子任务包含的元任务
                    {
                        if (SatTElementT[j].ElementTaskFID[l] == ElemTFID)//如果卫星观测的一个子任务包含的元任务等于当前元任务
                        {
                            for (int si = 0; si < satRTFIDlist.Count; si++)//遍历卫星 
                            {
                                if (satRTFIDlist[si].RFID == SatFID)
                                {
                                    for (int ti = 0; ti < satRTFIDlist[si].subTaskFID.Count; ti++)//遍历当前卫星可观测的子任务
                                    {
                                        if (satRTFIDlist[si].subTaskFID[ti] == SatTElementT[j].SatTFID)//选择卫星观测的子任务
                                        {
                                            double satTR = satRTFIDlist[si].Returns[ti];//卫星观测子任务的收益
                                            ReMa[GridUavRTFIDlist.Count + GridASRTFIDlist.Count + GridCarRTFIDlist.Count + SatFID, ElemTFID] = satTR / SatTElementT[j].ElementTaskFID.Count; //每一个资源观测每一个元任务形成的收益矩阵
                                            GridlstTaskFC[i].SatReturns = GridlstTaskFC[i].SatReturns + satTR / SatTElementT[j].ElementTaskFID.Count;//将元任务的卫星观测收益表达为 卫星观测子任务的收益与该子任务包含元任务个数的比值 没考虑面积的占比关系
                                            break;
                                        }
                                    }
                                    break;
                                }

                            }
                            break;
                        }
                    }
                }
                //List<int> SatFidlst = lstTaskFC[i].SatFID;//能够观测到此元任务的卫星列表
            }

            #endregion

            worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbooks.Sheets[2];
            worksheet.Name = "GridReturns";


            #region 资源对每一个元任务收益矩阵 每一列对应元任务 每一行对应资源

            try
            {
                for (int c = 0; c < ResouceNO; c++)//行数 资源总个数 无人机+飞艇+卫星
                {
                    for (int j = 0; j < ElemTno; j++)// 元任务个数既是列数
                    {
                        worksheet.Cells[c + 1, j + 1] = ReMa[c, j];//每一个观测此元任务的收益
                    }
                }
            }

            catch
            { }

            #endregion



            worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbooks.Sheets[3];
            worksheet.Name = "GridElementT";
            #region  将卫星子任务与元任务对应关系输出excel
            //将卫星子任务与元任务对应关系输出excel 在matlab中求解 第一列表示观测当前子任务的卫星fid
            //建立Excel对象
            //Microsoft.Office.Interop.Excel.Application ElemtTExcel = new Microsoft.Office.Interop.Excel.Application();
            //ElemtTExcel.Application.Workbooks.Add(true);
            //ElemtTExcel.Visible = true; // isShowExcle;//是否打开该Excel文件
            //填充数据
            for (int c = 0; c < SatTElementT.Count; c++)//行数：卫星观测子任务个数 SatTElementT：卫星观测子任务与元任务的对应关系
            {
                worksheet.Cells[c + 1, 1] = SatTElementT[c].SatFID;//第一列存储卫星fid
                for (int j = 0; j < SatTElementT[c].ElementTaskFID.Count; j++)// 当前子任务包含的元任务个数既是列数
                {

                    worksheet.Cells[c + 1, j + 2] = SatTElementT[c].ElementTaskFID[j];//存储每一个子任务包含的元任务FID


                }
            }
            #endregion

            worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbooks.Sheets[4];
            worksheet.Name = "GridConElemTfid";
            #region 每个资源观测元任务的冲突关系输出excel

            //将每个资源观测元任务的冲突关系输出excel 在matlab中求解
            //excel 最大行数是1048576行，最大列数是16384列.列数大于16384报错，将行列转置
            int FirstElementTFID = -1;//第一个冲突元任务的fid
            int SecondElementTFID = -1;
            for (int t = 0; t < GridUavRTFIDlist.Count; t++)//遍历无人机资源
            {
                int UavFid = GridUavRTFIDlist[t].RFID;//当前资源FID
                List<ConflictTFID> ConfiTFIDlist = GridUavRTFIDlist[t].ConflictTaskFID;//当前资源下的 元任务冲突列表
                for (int e = 0; e < ConfiTFIDlist.Count; e++)
                {
                    FirstElementTFID = ConfiTFIDlist[e].firstTFID;//冲突元任务的第一个
                    SecondElementTFID = ConfiTFIDlist[e].secondTFID;//冲突元任务的第二个
                    worksheet.Cells[2 * e + 1, UavFid + 1] = FirstElementTFID;
                    worksheet.Cells[2 * e + 2, UavFid + 1] = SecondElementTFID;
                }

            }
            for (int i = 0; i < GridASRTFIDlist.Count; i++)
            {
                int ASrFid = GridASRTFIDlist[i].RFID;//资源fid
                List<ConflictTFID> asConfiTFidlist = GridASRTFIDlist[i].ConflictTaskFID;
                for (int j = 0; j < asConfiTFidlist.Count; j++)
                {
                    FirstElementTFID = asConfiTFidlist[j].firstTFID;
                    SecondElementTFID = asConfiTFidlist[j].secondTFID;
                    //如果冲突大于1048576 则把冲突放在最后一列
                    double col = Math.Floor((double)(2 * j + 1) / 1048576);
                    if ((2 * j + 1) <= 1048575)
                    {
                        worksheet.Cells[2 * j + 1, GridUavRTFIDlist.Count + ASrFid + 1] = FirstElementTFID; //excel 最大行1048576 已超过最大行数报错
                        worksheet.Cells[2 * j + 2, GridUavRTFIDlist.Count + ASrFid + 1] = SecondElementTFID;
                    }
                    else
                    {
                        worksheet.Cells[2 * j + 1 - col * 1048576, GridUavRTFIDlist.Count + col * GridASRTFIDlist.Count + satRTFIDlist.Count + GridCarRTFIDlist.Count + ASrFid + 1] = FirstElementTFID; //excel 最大行1048576 已超过最大行数报错
                        worksheet.Cells[2 * j + 2 - col * 1048576, GridUavRTFIDlist.Count + col * GridASRTFIDlist.Count + satRTFIDlist.Count + GridCarRTFIDlist.Count + ASrFid + 1] = SecondElementTFID;
                    }
                }
            }
            for (int i = 0; i < GridCarRTFIDlist.Count; i++)
            {
                int CarFid = GridCarRTFIDlist[i].RFID;//资源fid
                List<ConflictTFID> CarConfiTFidlist = GridCarRTFIDlist[i].ConflictTaskFID;
                for (int j = 0; j < CarConfiTFidlist.Count; j++)
                {
                    FirstElementTFID = CarConfiTFidlist[j].firstTFID;
                    SecondElementTFID = CarConfiTFidlist[j].secondTFID;
                    worksheet.Cells[2 * j + 1, GridUavRTFIDlist.Count + GridASRTFIDlist.Count + CarFid + 1] = FirstElementTFID;
                    worksheet.Cells[2 * j + 2, GridUavRTFIDlist.Count + GridASRTFIDlist.Count + CarFid + 1] = SecondElementTFID;

                }
            }
            for (int i = 0; i < satRTFIDlist.Count; i++)
            {
                int satRFid = satRTFIDlist[i].RFID;//资源fid
                int FirSatTfid;
                int SecSatTfid;
                List<ConflictTFID> satConfiTFidlist = satRTFIDlist[i].ConflictTaskFID;//卫星观测子任务冲突 fid
                for (int j = 0; j < satConfiTFidlist.Count; j++)
                {
                    FirSatTfid = satConfiTFidlist[j].firstTFID;//冲突子任务fid
                    SecSatTfid = satConfiTFidlist[j].secondTFID;
                    //根据子任务确定元任务
                    for (int t = 0; t < SatTElementT.Count; t++)
                    {
                        if (FirSatTfid == SatTElementT[t].SatTFID)
                        {
                            FirstElementTFID = SatTElementT[t].ElementTaskFID[0];//只需获取冲突子任务包含的第一个元任务即可
                        }
                        else if (SecSatTfid == SatTElementT[t].SatTFID)
                        {
                            SecondElementTFID = SatTElementT[t].ElementTaskFID[0];
                        }

                    }
                    worksheet.Cells[2 * j + 1, GridUavRTFIDlist.Count + GridASRTFIDlist.Count + GridCarRTFIDlist.Count + satRFid + 1] = FirstElementTFID;
                    worksheet.Cells[2 * j + 2, GridUavRTFIDlist.Count + GridASRTFIDlist.Count + GridCarRTFIDlist.Count + satRFid + 1] = SecondElementTFID;

                }
            }
            //}
            //else if (c < UavRTFIDlist.Count + ASRTFIDlist.Count)//每一个飞艇资源的冲突
            //{ }
            //else//每一个卫星资源的冲突
            //{ }
            //}
            #endregion

            //worksheet.SaveAs(System.AppDomain.CurrentDomain.BaseDirectory + "Data\\fisrt.xlsx");
            //worksheet2.SaveAs(System.AppDomain.CurrentDomain.BaseDirectory + "Data\\fisrt2.xlsx");
            //workbooks.Close(false);
            //ElemtTExcel.Quit();
            #endregion


        }
        #endregion

        #region GP工具

        private static void GPBufferTool(ILayer in_features, string out_features, string distance)
        {


            try
            {
                // Initialize the Geoprocessor 
                Geoprocessor GP = new Geoprocessor();

                // Initialize the MakeFeatureLayer tool
                ESRI.ArcGIS.AnalysisTools.Buffer buffertool = new ESRI.ArcGIS.AnalysisTools.Buffer();
                GP.OverwriteOutput = true;
                buffertool.in_features = in_features; //根据图层名称获取图层 System.AppDomain.CurrentDomain.BaseDirectory + "Data\\Car.shp"; //
                buffertool.out_feature_class = out_features; //@"E\test.gdb\road_bf30"; //
                buffertool.buffer_distance_or_field = distance;
                // buffertool.dissolve_option = "ALL";
                // RunTool(GP, buffertool, null);
                GP.Execute(buffertool, null);
                //IFeatureLayer mFeatureClass = (IFeatureLayer)GP.Execute(buffertool, null);
                //Program.myMap.Map.AddLayer(mFeatureClass);
                //OpenShape(out_features);
                //Program.myMap.Refresh();

            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }


        private static void GPselectTool(IFeatureLayer in_features, string out_features, string clause, int idvalue)
        {


            try
            {
                // Initialize the Geoprocessor 
                Geoprocessor GP = new Geoprocessor();

                // Initialize the MakeFeatureLayer tool
                ESRI.ArcGIS.AnalysisTools.Select selecetool = new ESRI.ArcGIS.AnalysisTools.Select();
                GP.OverwriteOutput = true;
                selecetool.in_features = in_features; //根据图层名称获取图层 System.AppDomain.CurrentDomain.BaseDirectory + "Data\\Car.shp"; //
                selecetool.out_feature_class = out_features; //@"E\test.gdb\road_bf30"; //
                selecetool.where_clause = clause + idvalue;
                // buffertool.dissolve_option = "ALL";
                // RunTool(GP, buffertool, null);
                GP.Execute(selecetool, null);
                //IFeatureLayer mFeatureClass = (IFeatureLayer)GP.Execute(buffertool, null);
                //Program.myMap.Map.AddLayer(mFeatureClass);
                //return OpenShape(out_features);
                //Program.myMap.Refresh();

            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        private static void GPIntersectTool(IFeatureClass inputFeatClass, IFeatureClass clipFeatClass, string out_features)
        {


            try
            {
                IGpValueTableObject valTbl = new GpValueTableObjectClass();
                valTbl.SetColumns(2);
                object row = "";
                object rank = 1;

                row = inputFeatClass;
                valTbl.SetRow(0, ref row);
                valTbl.SetValue(0, 1, ref rank);

                row = clipFeatClass;
                valTbl.SetRow(1, ref row);
                rank = 2;
                valTbl.SetValue(1, 1, ref rank);

                // Initialize the Geoprocessor 
                Geoprocessor GP = new Geoprocessor();

                // Initialize the MakeFeatureLayer tool
                ESRI.ArcGIS.AnalysisTools.Intersect interSetool = new ESRI.ArcGIS.AnalysisTools.Intersect();
                GP.OverwriteOutput = true;
                interSetool.in_features = valTbl; // @"E:\Cooperative monitoring\program\CPclone\bin\Data\UAV_Buffer.shp;E:\Cooperative monitoring\program\CPclone\bin\Data\TaskArea.shp";//datapath + "\\"+in_features+".shp;" + datapath + "\\"+clipFeat+".shp"; //根据图层名称获取图层 System.AppDomain.CurrentDomain.BaseDirectory + "Data\\Car.shp"; //                
                interSetool.out_feature_class = out_features; //@"E\test.gdb\road_bf30"; //
                interSetool.join_attributes = "ALL";  // = "id=" + idvalue;
                interSetool.output_type = "INPUT";
                // buffertool.dissolve_option = "ALL";
                // RunTool(GP, buffertool, null);
                GP.Execute(interSetool, null);
                //IFeatureLayer mFeatureClass = (IFeatureLayer)GP.Execute(buffertool, null);
                //Program.myMap.Map.AddLayer(mFeatureClass);
                //return OpenShape(out_features);
                //Program.myMap.Refresh();

            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }
        private static void GPFeatureToPointTool(IFeatureLayer in_features, string out_features)
        {


            try
            {
                Geoprocessor GP = new Geoprocessor();

                ESRI.ArcGIS.DataManagementTools.FeatureToPoint FeToPointTool = new ESRI.ArcGIS.DataManagementTools.FeatureToPoint();
                IGeometry ige = in_features.FeatureClass.GetFeature(0).Shape;
                GP.OverwriteOutput = true;
                IPolygon pointfe = ige as IPolygon;
                FeToPointTool.in_features = in_features;// "E:\\Cooperative monitoring\\program\\CPclone\\bin\\Data\\cache\\0UMaxT.shp";
                FeToPointTool.out_feature_class = out_features;
                //FeToPointTool.point_location = "CENTROID ";// "FALSE";

                GP.Execute(FeToPointTool, null);
                //IFeatureLayer mFeatureClass = (IFeatureLayer)GP.Execute(buffertool, null);
                //Program.myMap.Map.AddLayer(mFeatureClass);
                //return OpenShape(out_features);
                //Program.myMap.Refresh();

            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }


        /// <summary>
        /// 生成网格
        /// </summary>
        /// <param name="in_features"></param>
        /// <param name="out_features"></param>
        private static void GPCreatFishnetTool(IFeature in_features, string out_features, double length)
        {



            Geoprocessor GP = new Geoprocessor();

            ESRI.ArcGIS.DataManagementTools.CreateFishnet CreatFishnetTool = new ESRI.ArcGIS.DataManagementTools.CreateFishnet();
            //IGeometry ige = in_features.FeatureClass.GetFeature(0).Shape;
            GP.OverwriteOutput = true;
            //IPolygon pointfe = ige as IPolygon;
            //CreatFishnetTool.template = in_features.FeatureClass;
            //IPoint pt = new ESRI.ArcGIS.Geometry.Point();
            //pt.X = in_features.Extent.XMin;
            //pt.Y = in_features.Extent.YMin;

            CreatFishnetTool.origin_coord = in_features.Extent.XMin.ToString() + "  " + in_features.Extent.YMin.ToString(); // "1637536.51 1215992.6167";//
            CreatFishnetTool.y_axis_coord = in_features.Extent.XMin.ToString() + "  " + (in_features.Extent.YMin + 10).ToString();//必须和origin_coord不同
            CreatFishnetTool.corner_coord = in_features.Extent.XMax.ToString() + "  " + in_features.Extent.YMax.ToString();//"1637945.0369 1216870.9581"; //
            CreatFishnetTool.out_feature_class = out_features;// @"D:\test\test.gdb\createFish";
            CreatFishnetTool.cell_height = length;
            CreatFishnetTool.cell_width = length;
            CreatFishnetTool.number_columns = 0;
            CreatFishnetTool.number_rows = 0;
            CreatFishnetTool.labels = "FALSE";//"TRUE";//
            CreatFishnetTool.geometry_type = "POLYGON";

            //FeToPointTool.point_location = "CENTROID ";// "FALSE";
            try
            {
                GP.Execute(CreatFishnetTool, null);
                //IFeatureLayer mFeatureClass = (IFeatureLayer)GP.Execute(buffertool, null);
                //Program.myMap.Map.AddLayer(mFeatureClass);
                //return OpenShape(out_features);
                //Program.myMap.Refresh();

            }
            catch (Exception err)
            {
                for (int i = 0; i < GP.MessageCount; i++)//遍历显示错误信息 ！！！！！！！！！！！！！
                    MessageBox.Show(GP.GetMessage(i));
                //Console.WriteLine(err.Message);
            }
        }

        private static void GPUnionTool(List<IFeatureLayer> lstFeatureClass, string out_features)
        {

            try
            {
                //IVariantArray parameters = new VarArrayClass();
                IGpValueTableObject valTbl = new GpValueTableObjectClass();
                valTbl.SetColumns(1);
                IFeatureClass ff;

                object row = "";
                object rank = 1;
                for (int i = 0; i < lstFeatureClass.Count; i++)
                {
                    ff = lstFeatureClass[i].FeatureClass;
                    row = ff;
                    //valTbl.SetRow(i, ref row);
                    valTbl.AddRow(row);
                    //valTbl.SetValue(i, 1, ref rank);
                    //parameters.Add(filePath + lstFeatureClass[i].Name+ ".shp" );
                }



                Geoprocessor GP = new Geoprocessor();

                // Initialize the MakeFeatureLayer tool
                ESRI.ArcGIS.AnalysisTools.Union Uniontool = new ESRI.ArcGIS.AnalysisTools.Union();
                GP.OverwriteOutput = true;

                Uniontool.in_features = valTbl; // @"E:\Cooperative monitoring\program\CPclone\bin\Data\UAV_Buffer.shp;E:\Cooperative monitoring\program\CPclone\bin\Data\TaskArea.shp";//datapath + "\\"+in_features+".shp;" + datapath + "\\"+clipFeat+".shp"; //根据图层名称获取图层 System.AppDomain.CurrentDomain.BaseDirectory + "Data\\Car.shp"; //                
                Uniontool.out_feature_class = out_features; //@"E\test.gdb\road_bf30"; //
                Uniontool.join_attributes = "ONLY_FID";  // = "id=" + idvalue;

                // buffertool.dissolve_option = "ALL";
                // RunTool(GP, buffertool, null);
                GP.Execute(Uniontool, null);
                //IFeatureLayer mFeatureClass = (IFeatureLayer)GP.Execute(buffertool, null);
                //Program.myMap.Map.AddLayer(mFeatureClass);
                //return OpenShape(out_features);
                //Program.myMap.Refresh();

            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }
        // Function for returning the tool messages.

        private static void GPNearTool(IFeatureLayer InputFeature, IFeatureLayer NearFeature)
        {//使用下面mindis函数

            try
            {

                IGpValueTableObject valTbl = new GpValueTableObjectClass();
                valTbl.SetColumns(1);
                //IFeatureClass ff;

                object row = "";
                object rank = 1;

                row = NearFeature.FeatureClass;
                //valTbl.SetRow(i, ref row);
                valTbl.AddRow(row);
                //valTbl.SetValue(i, 1, ref rank);
                //parameters.Add(filePath + lstFeatureClass[i].Name+ ".shp" );



                Geoprocessor GP = new Geoprocessor();

                // Initialize the MakeFeatureLayer tool
                ESRI.ArcGIS.AnalysisTools.Near Neartool = new ESRI.ArcGIS.AnalysisTools.Near();
                GP.OverwriteOutput = true;


                Neartool.in_features = InputFeature; // @"E:\Cooperative monitoring\program\CPclone\bin\Data\UAV_Buffer.shp;E:\Cooperative monitoring\program\CPclone\bin\Data\TaskArea.shp";//datapath + "\\"+in_features+".shp;" + datapath + "\\"+clipFeat+".shp"; //根据图层名称获取图层 System.AppDomain.CurrentDomain.BaseDirectory + "Data\\Car.shp"; //                
                Neartool.near_features = valTbl;

                //Uniontool.join_attributes = "ONLY_FID";  // = "id=" + idvalue;

                // buffertool.dissolve_option = "ALL";
                // RunTool(GP, buffertool, null);
                GP.Execute(Neartool, null);
                //IFeatureLayer mFeatureClass = (IFeatureLayer)GP.Execute(buffertool, null);
                //Program.myMap.Map.AddLayer(mFeatureClass);
                //return OpenShape(out_features);
                //Program.myMap.Refresh();

            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        //private static void ReturnMessages(Geoprocessor gp)
        //{
        //    if (gp.MessageCount > 0)
        //    {
        //        for (int Count = 0; Count <= gp.MessageCount - 1; Count++)
        //        {
        //            Console.WriteLine(gp.GetMessage(Count));
        //        }
        //    }

        //}
        #endregion

        #region 本文分解方法 面向多平台的面状目标分解方法
        public static void ElementTask(IMap pMap, ILayer layer, IFeatureLayer UAVFeatureLayer, IFeatureLayer CarFeatureLayer, IMapLayers mapLayers, IFeatureLayer ptaskFeatureLayer, IList<R_TInfo> RTinfoList, int SThour, int STmin, string tStart, IFeatureLayer ASfeatureLayer, IFeatureLayer SatFeLayer, out IFeatureLayer LastsubTaskLayer, out  List<RTsubTInfo> lstEleTFC, out List<RTFeatureInfo> lstsubTFC, out List<R_TInfo> SatTaskFID)
        {
            #region 任务分解 确定每一资源观测区域

            List<RTFeatureInfo> lstFC = new List<RTFeatureInfo>();//存储每个资源相对于每个任务的具体观测区域 时间 要素图层

            #region 地面车观测区域确定
            string CarToTaskLineLayerPath = System.AppDomain.CurrentDomain.BaseDirectory + "Data\\MidData\\CarToTaskLine.shp";
            IFeatureLayer LineFeatureLayer = OpenFile_LayerFile(CarToTaskLineLayerPath);//每一个车观测每一个任务的最短路径
            //IFeatureLayer LineFeatureLayer = CarToTaskLineLayer as IFeatureLayer;//存储每一个车观测每一个任务的最短路径

            #region 获取每一个车观测每一个任务的最短路径 及最终观测区域
            //清空     LineFeatureLayer内要素
            if (LineFeatureLayer.FeatureClass.FeatureCount(null) != 0)//判断如果LineFeatureLayer内不为空 则删除所有值
            {
                ITable pTable = LineFeatureLayer.FeatureClass as ITable;
                pTable.DeleteSearchedRows(null);
            }
            //获取面状图层 将每一个车辆观测的每一个任务的具体区域填到该图层
            string CartoTaskPolygonPath = System.AppDomain.CurrentDomain.BaseDirectory + "Data\\MidData\\CartoTaskPolygon.shp";
            IFeatureLayer CartoTaskPolygonFeatureLayer = OpenFile_LayerFile(CartoTaskPolygonPath);//每一个车观测每一个任务的具体区域
            if (CartoTaskPolygonFeatureLayer.FeatureClass.FeatureCount(null) != 0)//判断如果CartoTaskPolygonFeatureLayer内不为空 则删除所有值
            {
                ITable pTable = CartoTaskPolygonFeatureLayer.FeatureClass as ITable;
                pTable.DeleteSearchedRows(null);
            }

            //几何网络
            IGeometricNetwork mGeometricNetwork;

            //获取给定点最近的Network元素
            IPointToEID mPointToEID = new PointToEIDClass();
            ////返回结果变量
            //IEnumNetEID mEnumNetEID_Junctions;
            //IEnumNetEID mEnumNetEID_Edges;
            //double mdblPathCost;

            //获取几何网络文件路径
            //注意修改此路径为当前存储路径
            string strPath = System.AppDomain.CurrentDomain.BaseDirectory + "Data\\RoadData.gdb";//+"E:\GIS设计与开发\例子数据\Network\USA_Highway_Network_GDB.mdb";
            //打开工作空间
            IWorkspaceFactory pWorkspaceFactory = new ESRI.ArcGIS.DataSourcesGDB.FileGDBWorkspaceFactory();
            IFeatureWorkspace pFeatureWorkspace = pWorkspaceFactory.OpenFromFile(strPath, 0) as IFeatureWorkspace;
            //获取要素数据集
            //注意名称的设置要与上面创建保持一致
            IFeatureDataset pFeatureDataset = pFeatureWorkspace.OpenFeatureDataset("RaadDataSet");//修改成从xml读取

            //获取network集合
            INetworkCollection pNetWorkCollection = pFeatureDataset as INetworkCollection;
            //获取network的数量,为零时返回
            int intNetworkCount = pNetWorkCollection.GeometricNetworkCount;
            if (intNetworkCount < 1)
            { MessageBox.Show("要素类数量为0！"); }
            //FeatureDataset可能包含多个network，我们获取指定的network
            //注意network的名称的设置要与上面创建保持一致
            mGeometricNetwork = pNetWorkCollection.get_GeometricNetworkByName("RaadDataSet_Net");//修改成从xml读取

            ////将Network中的每个要素类作为一个图层加入地图控件
            //IFeatureClassContainer pFeatClsContainer = mGeometricNetwork as IFeatureClassContainer;
            ////获取要素类数量，为零时返回
            //int intFeatClsCount = pFeatClsContainer.ClassCount;
            ////if (intFeatClsCount < 1)
            ////    return;
            //IFeatureClass pFeatureClass = pFeatClsContainer.get_Class(0);//默认仅有一个要素类
            ////IFeatureLayer pFeatureLayer.FeatureClass=pFeatureClass;

            //设置mPointToEID属性
            mPointToEID.SourceMap = pMap;
            mPointToEID.GeometricNetwork = mGeometricNetwork;
            mPointToEID.SnapTolerance = 200000; //捕捉容差 2000m？


            //设置起始点

            string TaskPointPath = System.AppDomain.CurrentDomain.BaseDirectory + "Data\\cache\\OriTaskPo.shp";
            GPFeatureToPointTool(ptaskFeatureLayer, TaskPointPath);//将源任务转为点目标
            IFeatureLayer OriTaskPointFeatureLayer = OpenFile_LayerFile(TaskPointPath);//源任务目标
            int OriTaskNum = OriTaskPointFeatureLayer.FeatureClass.FeatureCount(null);//源任务个数
            int CarNum = CarFeatureLayer.FeatureClass.FeatureCount(null);//车辆个数
            double mileage;//车辆续航里程 km
            double carV;//车辆速度KM/h

            for (int i = 0; i < OriTaskNum; i++)
            {
                IPolygon SingleTaskPolygon = ptaskFeatureLayer.FeatureClass.GetFeature(i).Shape as IPolygon;//获取每一个源任务面目标

                IPoint SingleTaskPoint = OriTaskPointFeatureLayer.FeatureClass.GetFeature(i).Shape as IPoint;//获取每一个源任务点目标
                string TaskEndTime = OriTaskPointFeatureLayer.FeatureClass.GetFeature(i).get_Value(5).ToString();//当前任务结束时间窗口
                string TaskStartTimeWin = OriTaskPointFeatureLayer.FeatureClass.GetFeature(i).get_Value(4).ToString();//当前任务开始时间窗口
                int CarTaskEhour;//任务结束时间 小时
                int CarTaskEmin;//任务结束时间 分钟
                int STH;//任务开始时间 小时 观测资源开始执行时间
                int STM;//任务开始时间 分钟 观测资源开始执行时间
                #region 确定时间
                if (TaskEndTime.Length > 3)
                {
                    CarTaskEhour = int.Parse(TaskEndTime.Substring(0, 2));//任务结束时间 小时                 
                }
                else
                {
                    CarTaskEhour = int.Parse(TaskEndTime.Substring(0, 1));//任务结束时间 小时
                }
                CarTaskEmin = int.Parse(TaskEndTime.Substring(TaskEndTime.Length - 2, 2));//任务结束时间 分钟 

                if (TaskStartTimeWin.Length > 3)
                {
                    STH = int.Parse(TaskStartTimeWin.Substring(0, 2));//任务开始时间 小时                 
                }
                else
                {
                    STH = int.Parse(TaskStartTimeWin.Substring(0, 1));//任务开始时间 小时
                }
                STM = int.Parse(TaskStartTimeWin.Substring(TaskStartTimeWin.Length - 2, 2));//任务开始时间 分钟 


                #endregion

                for (int j = 0; j < CarNum; j++)
                {
                    IPoint SingleCarPoint = CarFeatureLayer.FeatureClass.GetFeature(j).Shape as IPoint;//获取每一个车辆目标                    
                    IPointCollection mPointCollection = new MultipointClass();//给定点的集合
                    mPointCollection.AddPoint(SingleTaskPoint);
                    mPointCollection.AddPoint(SingleCarPoint);

                    //路径计算
                    IEnumNetEID mEnumNetEID_Junctions;//返回路径的节点
                    IEnumNetEID mEnumNetEID_Edges;//返回路径边
                    double mdblPathCost;//返回总代价（边长 距离）
                    CoScheduling.Core.Map.MapHelper MapHelp = new Core.Map.MapHelper();
                    MapHelp.SolvePath("weight", mGeometricNetwork, mPointCollection, mPointToEID, out  mEnumNetEID_Junctions, out  mEnumNetEID_Edges, out   mdblPathCost);
                    IPolyline ResultLine = MapHelp.PathToPolyLine(pMap, mGeometricNetwork, mEnumNetEID_Edges);//将路径结果转为线
                    //IFeatureLayer LineFeL = new FeatureLayerClass();

                    //IFeature pFeature = LineFeL.FeatureClass.CreateFeature();



                    //初步判断是否能观测到此任务
                    mileage = double.Parse(CarFeatureLayer.FeatureClass.GetFeature(j).get_Value(7).ToString());//续航里程
                    carV = double.Parse(CarFeatureLayer.FeatureClass.GetFeature(j).get_Value(5).ToString());//速度
                    double carOberV = double.Parse(CarFeatureLayer.FeatureClass.GetFeature(j).get_Value(8).ToString());//观测时速度
                    double CarToTaskDis = ResultLine.Length;//点到任务区的距离 m

                    //判断是否能观测到当前任务 两种约束：距离约束和时间约束
                    if (mileage * 1000 > CarToTaskDis)//路线距离小于续航里程 则满足距离约束
                    {
                        #region 确定开始时间（汽车开始出发时间）
                        if ((STH * 60 + STM) > (SThour * 60 + STmin))//开始时间取  较大值
                        {
                            double st = STH + (double)STM / 60 - (CarToTaskDis / 1000 / carV);
                            STH = (int)Math.Floor(st);
                            STM = (int)((double)(st - STH) * 60);
                            if (st < (SThour + (double)STmin / 60))
                            {
                                STH = SThour;
                                STM = STmin;
                            }
                        }
                        else
                        {
                            STH = SThour;
                            STM = STmin;
                        }
                        #endregion
                        //时间约束 
                        double CarTimeCon = (CarTaskEhour + CarTaskEmin / 60) - (STH + STM / 60 + CarToTaskDis / 1000 / carV);//时间约束如果结束时间-开始时间-路上时间>0 则能观测到此任务
                        if (CarTimeCon > 0)//满足时间约束  可以观测
                        {
                            //将最短路线结果填充到featureLayer中 为了构建缓冲区
                            IFeature pFeature = LineFeatureLayer.FeatureClass.CreateFeature();
                            pFeature.Shape = ResultLine;
                            pFeature.set_Value(LineFeatureLayer.FeatureClass.Fields.FindField("CarFid"), j);//设值
                            pFeature.set_Value(LineFeatureLayer.FeatureClass.Fields.FindField("TaskFid"), i);//设值
                            pFeature.Store();
                            //获取幅宽  缓冲区半径
                            double carBreath = double.Parse(CarFeatureLayer.FeatureClass.GetFeature(j).get_Value(6).ToString());//幅宽
                            ITopologicalOperator TopolOperator = ResultLine as ITopologicalOperator;
                            IGeometry bufferGeo = TopolOperator.Buffer(carBreath);
                            ITopologicalOperator pTopo = SingleTaskPolygon as ITopologicalOperator;//面任务目标
                            IPolygon pIntersectGeo = pTopo.Intersect(bufferGeo, esriGeometryDimension.esriGeometry2Dimension) as IPolygon;

                            if (pIntersectGeo.IsEmpty)//如果交集为空则说明 当前车辆观测不到此区域
                            { }
                            else
                            {
                                //将每个车观测每个任务的具体区域结果填充到featureLayer中 
                                IFeature PolygonFeature = CartoTaskPolygonFeatureLayer.FeatureClass.CreateFeature();
                                PolygonFeature.Shape = pIntersectGeo;
                                PolygonFeature.set_Value(LineFeatureLayer.FeatureClass.Fields.FindField("CarFid"), j);//设值
                                PolygonFeature.set_Value(LineFeatureLayer.FeatureClass.Fields.FindField("TaskFid"), i);//设值
                                PolygonFeature.Store();




                                IArea pArea = (IArea)pIntersectGeo;
                                //估计观测时长 小时
                                double oberTime = pArea.Area / carBreath / 1000 / carOberV;//小时

                                RTFeatureInfo RTFinfo = new RTFeatureInfo() { CarFID = j.ToString(), ASFID = "-1", UAVFID = "-1", SATFID = "-1", TFID = i.ToString(), RtoTFL = PolygonFeature, RtoTtime = oberTime, areaT = pArea.Area };
                                lstFC.Add(RTFinfo);//每个car相对于每个任务的最终观测区域 和资源ID和面状任务区ID对应关系，表明car最终观测到此任务区
                            }
                            //string CarBufferPath = System.AppDomain.CurrentDomain.BaseDirectory + "Data\\cache\\CarLineBuffer.shp";
                            //GPBufferTool((ILayer)ASOneLayer, ASToTaskBFpath, oberASd.ToString());
                        }
                    }


                    //Program.myMap.AddLayer(LineFeL as ILayer, 0);
                }
            }

            #endregion


            //ESRI.ArcGIS.AnalysisTools.Buffer buffer buffer=new ESRI.ArcGIS.AnalysisTools.Buffer(,)

            #endregion

            #region 无人机观测区域确定
            //无人机及实际观测范围--------------------------------------(无人机开始)------------------------------------------

            string BufferPath = System.AppDomain.CurrentDomain.BaseDirectory + "Data\\cache\\" + layer.Name + "BF.shp";
            string distan = UAVFeatureLayer.FeatureClass.Fields.get_Field(6).Name.ToString();//获取续航半径字段 第6个字段 最大半径为航程一半
            GPBufferTool(layer, BufferPath, distan);
            OpenShape(BufferPath);//如果在图层上显示 PolygonTaskNO等图层NO要+1 //////////////////////////////////////////////////////////////////////////////////////////
            Program.myMap.Refresh();
            //Program.myMap.Extent = Program.myMap.FullExtent;
            //Program.myMap.Refresh();
            IFeatureLayer UAVbuFeatureLayer = (IFeatureLayer)mapLayers.get_Layer(0);//得到刚生成的无人机最大缓冲区
            //pFeatureLayer = layer as IFeatureLayer;//可用此获取属性表

            //获取每一个面状任务区  并且使无人机根据此面状任务task生成缓冲区，为了简化计算，先根据无人机的最大航程范围确定无人机可能会观测到的任务集，在根据每一个无人机和他的任务集进行缓冲区构建

            //IFeatureLayerDefinition pFeatureLayerDefinition = (IFeatureLayerDefinition)pFeatureLayer;
            //pFeatureLayer.FeatureClass.Indexes(1)

            IQueryFilter pQueryFilter = new QueryFilter();//实例化一个查询条件对象 
            pQueryFilter.WhereClause = "Id > 0";//将查询条件赋值     选择所有的无人机 为每一个无人机构建可能观测到的任务集
            IFeatureCursor featureCursor = UAVbuFeatureLayer.Search(pQueryFilter, false);
            IFeature Feature = featureCursor.NextFeature();//遍历查询结果  无人机缓冲区
            //获取每一个无人机
            while (Feature != null)
            {
                //选择和当前无人机缓冲区Feature相交的任务区
                ISpatialFilter pSpatialFilter = new SpatialFilterClass();
                pSpatialFilter.Geometry = Feature.Shape;
                pSpatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;//空间关系选择条件 这里用相交
                IFeatureCursor taskfeatureCursor = ptaskFeatureLayer.FeatureClass.Search(pSpatialFilter, false);
                IFeature pFeature = taskfeatureCursor.NextFeature();//查询的当前无人机缓冲区内 相交的面状任务区
                while (pFeature != null)
                {
                    R_TInfo Rinfo = new R_TInfo() { ResouceFID = Feature.get_Value(0).ToString(), TaskFID = pFeature.get_Value(0).ToString() };
                    RTinfoList.Add(Rinfo);//存储无人机ID和面状任务区ID对应关系，表明无人机可能观测到此任务区（空间上）
                    //验证是否获取到当前无人机缓冲区内的面状任务区
                    //string hehe = pFeature.get_Value(2).ToString();
                    //string he = pFeature.get_Value(3).ToString();
                    //MessageBox.Show("id:"+hehe+"+area:"+he);
                    pFeature = taskfeatureCursor.NextFeature();
                }
                Feature = featureCursor.NextFeature();
            }



            //求每一个无人机相对于每一个任务区的交集
            // R_TInfo Rinfor = new R_TInfo();
            //Rinfor.ResouceID
            IFeatureLayer UAVlayer = (FeatureLayer)layer;
            string UavToTaskpath;//根据每一个任务确定的无人机缓冲区路径
            string seleceUavPath;//选择每一个无人机路径
            string selTaskPath;//选择每一个任务路径
            string UavBfToTaskPath;//第i组无人机和任务组合  无人机观测到当前任务的区域存储路径
            //IFeatureCursor pFeatureCursor;             
            IFeatureLayer UavEveryLayer;//选择出的每一个无人机 作为一个要素图层
            IFeatureLayer TaskEveryLayer;//选择出的每一个任务 作为一个要素图层
            IFeature UavEveryFeature;//选择出的每一个无人机 作为一个要素
            IFeature TaskEveryFeature;//选择出的每一个任务 作为一个要素
            IFeatureLayer UavEBFLayer;//每一个无人机相对于当前任务形成的缓冲区 要素图层
            double Mileage;//无人机续航里程
            double MaxConObeT;//无人机最大连续观测时间
            double Vuav;//无人机续航速度 km/h
            double tu_one;//单次观测的观测时间
            double Sone;//单次观测面积
            double UavWidth;//无人机幅宽
            double Scstr;//在时间窗口约束下能够完成的面积
            string TsakWinS;//任务时间窗口开始时间 格式4位数 前两位小时 后两位分钟
            string TaskWinE;//任务时间窗口结束时间 格式4位数 前两位小时 后两位分钟
            int TWEhour;//任务时间窗口结束时间 小时
            int TWEmin;//任务时间窗口结束时间 分钟


            double ober_urad = 0;//每一个UAV相对于每一个任务的观测半径    
            IFeatureLayer subTaskLayer;//最终的任务子集-------★★★★★------

            //List<R_TFIDtime> RTtimeList = new List<R_TFIDtime>();//资源对应任务所花费时间   小时     
            double UtoTtime = 0;//每一个任务相对每一个资源执行的总花费时间
            for (int i = 0; i < RTinfoList.Count; i++)
            {
                //IFeature Uavf = UAVlayer.FeatureClass.GetFeature(int.Parse(RTinfoList[i].ResouceID) - 1);
                seleceUavPath = System.AppDomain.CurrentDomain.BaseDirectory + "Data\\cache\\" + i + UAVlayer.Name + "sl.shp";
                GPselectTool(UAVlayer, seleceUavPath, "FID=", int.Parse(RTinfoList[i].ResouceFID));//选出单个无人机 以便根据具体任务区构建缓冲区
                selTaskPath = System.AppDomain.CurrentDomain.BaseDirectory + "Data\\cache\\" + i + ptaskFeatureLayer.Name + "sl.shp";
                GPselectTool(ptaskFeatureLayer, selTaskPath, "FID=", int.Parse(RTinfoList[i].TaskFID));//选出单个任务 以便根据具体任务区构建缓冲区
                UavEveryLayer = OpenFile_LayerFile(seleceUavPath);// mapLayers.get_Layer(0) as FeatureLayer;
                TaskEveryLayer = OpenFile_LayerFile(selTaskPath);
                UavEveryFeature = UavEveryLayer.FeatureClass.GetFeature(0);
                TaskEveryFeature = TaskEveryLayer.FeatureClass.GetFeature(0);
                Mileage = double.Parse(UavEveryFeature.get_Value(7).ToString());//续航里程
                Vuav = double.Parse(UavEveryFeature.get_Value(5).ToString());//巡航速度
                MaxConObeT = double.Parse(UavEveryFeature.get_Value(9).ToString());//最大连续开机时间 小时
                UavWidth = double.Parse(UavEveryFeature.get_Value(8).ToString());//无人机幅宽
                TsakWinS = TaskEveryFeature.get_Value(4).ToString();//任务开始时间
                TaskWinE = TaskEveryFeature.get_Value(5).ToString();//任务结束时间

                //首先用无人机最大半径切割当前任务区 获取能够覆盖的最大任务范围    
                string UavMaxBF = System.AppDomain.CurrentDomain.BaseDirectory + "Data\\cache\\" + i + "UMaxBF.shp";//选择当前无人机缓冲区
                GPselectTool(UAVbuFeatureLayer, UavMaxBF, "FID=", int.Parse(RTinfoList[i].ResouceFID));//UAVbuFeatureLayer是已生成的所有无人机最大半径缓冲区
                IFeatureLayer ifluav = OpenFile_LayerFile(UavMaxBF);//获取当前无人机最大缓冲区
                string UavMaxTask = System.AppDomain.CurrentDomain.BaseDirectory + "Data\\cache\\" + i + "UMaxT.shp";//当前无人机最大缓冲区半径内能够观测的任务区域
                GPIntersectTool(ifluav.FeatureClass, TaskEveryLayer.FeatureClass, UavMaxTask);
                IFeatureLayer UavMaxToTaskFeatureLayer = OpenFile_LayerFile(UavMaxTask);
                string featureToPointPath = System.AppDomain.CurrentDomain.BaseDirectory + "Data\\cache\\" + i + "FeaToPo.shp";//将当前无人机最大缓冲区半径内能够观测的任务区域转成点目标，为了求无人机基站到质心距离  
                GPFeatureToPointTool(UavMaxToTaskFeatureLayer, featureToPointPath);
                IFeatureLayer PointFeatureLayer = OpenFile_LayerFile(featureToPointPath);
                IPoint pointfe = PointFeatureLayer.FeatureClass.GetFeature(0).Shape as IPoint;//将当前无人机最大缓冲区半径内能够观测的任务区域转成的点目标
                IPoint UavPoint = UavEveryLayer.FeatureClass.GetFeature(0).Shape as IPoint;//将当前无人机转成的点目标
                double dcen = Math.Sqrt(Math.Pow(pointfe.X - UavPoint.X, 2) + Math.Pow(pointfe.Y - UavPoint.Y, 2));//无人机基地到无人机最大缓冲区半径内能够观测的任务区域的质心距离 米
                double TLongUToT = (Mileage - 2 * dcen) / 1000 / Vuav; //当前无人机相对于当前任务单次观测最长时间 距离考虑用质心距离统一代替 小时
                if (TLongUToT < MaxConObeT)//小时
                { tu_one = TLongUToT; } //小时
                else
                { tu_one = MaxConObeT; }
                Sone = tu_one * Vuav * UavWidth * 1000;//单次观测面积 平方米
                IPolygon UavMaxTaskPolygon = UavMaxToTaskFeatureLayer.FeatureClass.GetFeature(0).Shape as IPolygon;
                IArea Uarea = UavMaxTaskPolygon as IArea;
                int K_Ober = (int)Math.Ceiling(Uarea.Area / Sone); //无人机观测次数k 平方米 向上取整

                //时间确定 
                #region 确定时间
                if (TaskWinE.Length > 3)
                {
                    TWEhour = int.Parse(TaskWinE.Substring(0, 2));//任务结束时间 小时                 
                }
                else
                {
                    TWEhour = int.Parse(TaskWinE.Substring(0, 1));//任务结束时间 小时
                }
                TWEmin = int.Parse(TaskWinE.Substring(TaskWinE.Length - 2, 2));//任务结束时间 分钟 
                int STH;
                int STM;
                if (TsakWinS.Length > 3)
                {
                    STH = int.Parse(TsakWinS.Substring(0, 2));//任务开始时间 小时                 
                }
                else
                {
                    STH = int.Parse(TsakWinS.Substring(0, 1));//任务开始时间 小时
                }
                STM = int.Parse(TsakWinS.Substring(TsakWinS.Length - 2, 2));//任务开始时间 分钟 
                if ((STH * 60 + STM) > (SThour * 60 + STmin))//开始时间取  较大值
                {
                    double st = STH + (double)STM / 60 - (dcen / 1000 / Vuav);
                    STH = (int)Math.Floor(st);
                    STM = (int)((double)(st - STH) * 60);
                    if (st < (SThour + (double)STmin / 60))
                    {
                        STH = SThour;
                        STM = STmin;
                    }
                }
                else
                {
                    STH = SThour;
                    STM = STmin;
                }

                #endregion
                //double SinMaxT = (Mileage) / (2 * (Vuav) * 0.2777778) / 60; //最远单程飞行时间 分钟


                if (int.Parse(tStart) < int.Parse(TaskWinE))//保证开始观测时间（无人机出发时间）小于任务结束时间
                {
                    if (K_Ober == 1) //飞行一次即可完成的任务
                    {
                        if (TWEhour * 60 + TWEmin - (STH * 60 + STM) - dcen / 1000 / Vuav * 60 - tu_one * 60 > 0)
                        {
                            ober_urad = Mileage / 2;//满足时间约束 半径等于续航里程/2
                            UtoTtime = (dcen / 1000 / Vuav) * 2 + tu_one;

                        }
                        else  //不满足时间窗口约束 则确定在时间窗口约束下能够完成的面积
                        {
                            Scstr = (TWEhour * 60 + TWEmin - (STH * 60 + STM) - dcen / 1000 / Vuav * 60) / 60 * Vuav * 1000 * UavWidth;
                            //根据Scstr确定半径ober_urad 
                            if (Scstr > 0)
                            {
                                ///////////////////////////////////////////算法A///////////////////////////////////////////////////////////////////
                                ober_urad = AreaToRadius(UavEveryLayer, TaskEveryLayer, Scstr, Mileage / 2);

                                UtoTtime = (TWEhour * 60 + TWEmin - (STH * 60 + STM) + dcen / 1000 / Vuav * 60) / 60;

                            }
                        }

                    }
                    else if (K_Ober > 1)//飞行多次才可完成的任务
                    {
                        double Tdut = 2 * dcen / 1000 / Vuav + tu_one;//每次任务持续时间 小时   （大于1次） 
                        double chageRate = Math.Abs(double.Parse(UavEveryFeature.get_Value(10).ToString()));//充电斜率 电量与时间 小时
                        double consumRate = Math.Abs(double.Parse(UavEveryFeature.get_Value(11).ToString()));//耗电斜率 电量与时间 小时
                        double tk; //执行k次任务所需时间 小时
                        //观测次数大于1的情况                        
                        tk = (K_Ober - 1) * Tdut + (K_Ober - 1) * (Tdut * consumRate / chageRate) + dcen / 1000 / Vuav + tu_one;

                        if (TWEhour * 60 + TWEmin - (STH * 60 + STM) - tk * 60 > 0)
                        {
                            ober_urad = Mileage / 2;//满足时间约束 半径等于续航里程/2
                            UtoTtime = K_Ober * Tdut + 0.25 * K_Ober * Tdut;//充电时间 一定值 这里与上文一致 0.2/0.8

                        }
                        else //不满足时间窗口约束 则首先确定满足时间窗口的最大观测面积Scstr
                        {
                            if (TWEhour * 60 + TWEmin - (STH * 60 + STM) - dcen / 1000 / Vuav * 60 - tu_one * 60 < 0)
                            {//一次都不满足情况 
                                Scstr = (TWEhour * 60 + TWEmin - (STH * 60 + STM) - dcen / 1000 / Vuav * 60) / 60 * Vuav * 1000 * UavWidth;
                                //根据Scstr确定半径ober_urad  
                                if (Scstr > 0)
                                {
                                    /////////////////////////（算法A）循环逼近半径/////////////////////////////////////////
                                    ober_urad = AreaToRadius(UavEveryLayer, TaskEveryLayer, Scstr, Mileage / 2);
                                    UtoTtime = (TWEhour * 60 + TWEmin - (STH * 60 + STM) + dcen / 1000 / Vuav * 60) / 60;

                                }

                            }
                            else//能够满足至少一次观测情况
                            {
                                double kk;//第j次观测完成所花费时间 小时
                                for (int j = 2; j <= K_Ober; j++)
                                {
                                    kk = (j - 1) * Tdut + (j - 1) * (Tdut * consumRate / chageRate) + dcen / 1000 / Vuav + tu_one;
                                    if (TWEhour * 60 + TWEmin - (STH * 60 + STM) - kk * 60 < 0)
                                    {
                                        double jt = TWEhour * 60 + TWEmin - (STH * 60 + STM) - ((j - 1) * Tdut + (j - 1) * (Tdut * consumRate / chageRate)) * 60 - dcen / 1000 / Vuav * 60;    //第j次能够观测的时间（可能能够完成部分）
                                        if (jt > 0)
                                        {
                                            Scstr = (j - 1) * Sone + jt / 60 * Vuav * UavWidth * 1000; ;//满足多次情况的完成面积
                                        }
                                        else
                                        {
                                            Scstr = (j - 1) * Sone;//满足多次情况的完成面积
                                        }

                                        //根据Scstr确定半径ober_urad  
                                        if (Scstr > 0)
                                        {
                                            /////////////////////////（算法A）循环逼近半径/////////////////////////////////////////
                                            ober_urad = AreaToRadius(UavEveryLayer, TaskEveryLayer, Scstr, Mileage / 2);
                                            UtoTtime = (TWEhour * 60 + TWEmin - (STH * 60 + STM) + dcen / 1000 / Vuav * 60) / 60;

                                            break;
                                        }
                                    }
                                }
                            }
                        }


                    }



                }
                else
                { ober_urad = 0; }//开始观测时间大于任务结束时间 观测半径为0

                if (ober_urad > 0)//观测半径>0 有实际意义
                {
                    UavToTaskpath = System.AppDomain.CurrentDomain.BaseDirectory + "Data\\cache\\" + UavEveryLayer.Name + "BF.shp";
                    //计算在当前无人机和当前任务时间约束下的 无人机半径
                    //string Mileage=UAVlayer.FeatureClass.Fields.get_Field(int.Parse(RTinfoList[i].ResouceID);
                    //通过Ifeature获取属性值 http://blog.163.com/song_zhuyue/blog/static/17343278720101074524281/  http://blog.sina.com.cn/s/blog_84f7fbbb0101975m.html                 
                    //pFeatureCursor = UavEveryLayer.FeatureClass.Search(null, false);
                    //pFeature= pFeatureCursor.NextFeature();
                    //-----------------------------------------------以上是可覆盖半径 实际观测半径如下（折损系数）----------------------------------------------------------------------------------------
                    //ober_urad = ober_urad / 2 * conRadixi;//实际观测半径
                    //根据当前无人机和当前任务时间约束下的 无人机半径 构建缓冲区
                    GPBufferTool((ILayer)UavEveryLayer, UavToTaskpath, ober_urad.ToString());
                    //OpenShape(UavToTaskpath);
                    //Program.myMap.Refresh();
                    UavEBFLayer = OpenFile_LayerFile(UavToTaskpath);
                    //根据缓冲区和对应任务区构建此无人机能够观测到的此任务区  （Intersect工具 无人机观测范围和任务的重叠部分）
                    //IMapLayers mapLayers = Program.myMap.Map as IMapLayers;//IFeatureLayer pFeatureLayer;
                    //ILayer layer;
                    //ILayer la2;               
                    //DeleteFolder(System.AppDomain.CurrentDomain.BaseDirectory + "Data\\cache");//删除cache下所有文件  
                    ////卫星 无人机 飞艇 测量车覆盖面路径（缓冲区路径）
                    //layer = mapLayers.get_Layer(8);
                    //la2 = mapLayers.get_Layer(12);
                    //IFeatureLayer UAVFeatureLayer = (IFeatureLayer)layer;
                    //IFeatureLayer FeatureLayer = (IFeatureLayer)la2;
                    UavBfToTaskPath = System.AppDomain.CurrentDomain.BaseDirectory + "Data\\cache\\" + i + UAVlayer.Name + "To" + ptaskFeatureLayer.Name + ".shp";
                    //当前第i组无人机任务   每一个无人机相对于每一个任务区的交集----------------------------------------------------------------------------------------------
                    GPIntersectTool(UavEBFLayer.FeatureClass, TaskEveryLayer.FeatureClass, UavBfToTaskPath);
                    //OpenShape(UavBfToTaskPath);//如果在图层上显示 PolygonTaskNO等图层NO要+1 //////////////////////////////////////////////////////////////////////////////////////////
                    //Program.myMap.Refresh();
                    IFeatureLayer UavToTTrueObe = OpenFile_LayerFile(UavBfToTaskPath);

                    IPolygon UAVsubTPolygon = UavToTTrueObe.FeatureClass.GetFeature(0).Shape as IPolygon;
                    IArea uavTarea = UAVsubTPolygon as IArea;

                    //lstFC.Add(UavToTTrueObe);
                    RTFeatureInfo RTFinfo = new RTFeatureInfo() { UAVFID = RTinfoList[i].ResouceFID, ASFID = "-1", SATFID = "-1", CarFID = "-1", TFID = RTinfoList[i].TaskFID, RtoTFL = UavToTTrueObe.FeatureClass.GetFeature(0), areaT = uavTarea.Area, RtoTtime = UtoTtime };
                    lstFC.Add(RTFinfo);//每个无人机相对于每个任务的最终观测区域 和无人机ID和面状任务区ID对应关系，表明无人机最终观测到此任务区

                }

            }
            //无人机及实际观测范围--------------------------------------(无人机结束)------------------------------------------

            #endregion

            #region 飞艇观测区域确定

            //飞艇及实际观测范围--------------------------------------(飞艇开始)------------------------------------------


            double ASv;//巡航速度
            double ASconT;//持续观测时间
            double ASwidth;//幅宽
            List<R_TInfo> AStoTaskFIDlist = new List<R_TInfo>();//AS相对于任务的FID 以便为缓冲区命名
            int ASFID = 0;//获取每一个AS的FID以便为缓冲区命名
            double AStoTtime = 0;//每一个任务相对每一个资源执行的总花费时间 小时
            IQueryFilter pASFilter = new QueryFilter();//实例化一个查询条件对象 
            pASFilter.WhereClause = "FID >= 0";//将查询条件赋值     遍历每一个飞艇
            IFeatureCursor ASfeatureCursor = ASfeatureLayer.Search(pASFilter, false);
            IFeature ASFeature = ASfeatureCursor.NextFeature();//遍历查询结果  每一个飞艇要素
            //获取每一个飞艇
            while (ASFeature != null)
            {
                //ptaskFeatureLayer//任务featurelayer
                int TaskFID = 0;//获取每一个任务的FID以便为缓冲区命名 
                string selASPath = System.AppDomain.CurrentDomain.BaseDirectory + "Data\\cache\\" + "OneAS.shp";
                GPselectTool(ASfeatureLayer, selASPath, "FID=", int.Parse(ASFeature.get_Value(0).ToString()));//选出单个飞艇 
                IFeatureLayer ASOneLayer = OpenFile_LayerFile(selASPath);//选出单个飞艇作为要素图层
                IFeatureLayer ASoneBFLayer;//单个飞艇相对于当前任务的缓冲区图层
                string taskPointPath = System.AppDomain.CurrentDomain.BaseDirectory + "Data\\cache\\" + "TaskPoint.shp";//把所有任务面转成任务点图层
                GPFeatureToPointTool(ptaskFeatureLayer, taskPointPath);
                IFeatureLayer taskPointFeatureLayer = OpenFile_LayerFile(taskPointPath);
                IQueryFilter taskFilter = new QueryFilter();//实例化一个查询条件对象 
                taskFilter.WhereClause = "FID >= 0";//将查询条件赋值     遍历每一个任务点
                IFeatureCursor TaskPointfeatureCursor = taskPointFeatureLayer.Search(taskFilter, false);
                IFeature taskPointFeature = TaskPointfeatureCursor.NextFeature();//遍历查询结果  每一个任务点要素
                while (taskPointFeature != null)
                {
                    string oneTaskPath = System.AppDomain.CurrentDomain.BaseDirectory + "Data\\cache\\" + "Onetask.shp";
                    GPselectTool(ptaskFeatureLayer, oneTaskPath, "FID=", int.Parse(taskPointFeature.get_Value(0).ToString()));//选出单个任务区 
                    IFeatureLayer taskOneLayer = OpenFile_LayerFile(oneTaskPath);//选出单个任务区作为要素图层

                    IPoint taskFeaturePoint = taskPointFeature.Shape as IPoint;//将当前任务区域转成的点目标
                    IPoint ASFeaturePoint = ASFeature.Shape as IPoint;//将当前飞艇转成的点目标
                    double ASdcen = Math.Sqrt(Math.Pow(taskFeaturePoint.X - ASFeaturePoint.X, 2) + Math.Pow(taskFeaturePoint.Y - ASFeaturePoint.Y, 2));//飞艇到任务区域的质心距离 米
                    double Tas;//有效观测时间 小时
                    double TmaxAS;//用来判断最大航行距离 小时
                    double oberASd;//观测半径
                    double ASScstr;//在时间约束下能够完成的面积
                    string ASToTaskBFpath;//AS相对任务的观测缓冲区路径
                    string ASBfToTaskPath;//as相对与具体任务的观测范围存储路径
                    ASv = double.Parse(ASFeature.get_Value(5).ToString());//巡航速度
                    ASconT = double.Parse(ASFeature.get_Value(6).ToString());//持续观测时间
                    ASwidth = double.Parse(ASFeature.get_Value(7).ToString());//幅宽
                    string ASTsakWinS = taskPointFeature.get_Value(4).ToString();//任务开始时间
                    string ASTaskWinE = taskPointFeature.get_Value(5).ToString();//任务结束时间
                    int ASTWEhour;
                    int ASTWEmin;
                    #region 确定时间
                    //确定时间
                    if (ASTaskWinE.Length > 3)
                    {
                        ASTWEhour = int.Parse(ASTaskWinE.Substring(0, 2));//任务结束时间 小时                 
                    }
                    else
                    {
                        ASTWEhour = int.Parse(ASTaskWinE.Substring(0, 1));//任务结束时间 小时
                    }
                    ASTWEmin = int.Parse(ASTaskWinE.Substring(ASTaskWinE.Length - 2, 2));//任务结束时间 分钟 
                    if (tStart.Length > 3)
                    {
                        SThour = int.Parse(tStart.Substring(0, 2));//开始观测时间 小时        
                    }
                    else
                    {
                        SThour = int.Parse(tStart.Substring(0, 1));//开始观测时间 小时
                    }
                    STmin = int.Parse(tStart.Substring(tStart.Length - 2, 2));//开始观测时间 分钟
                    int AsSTH;
                    int AsSTM;
                    if (ASTsakWinS.Length > 3)
                    {
                        AsSTH = int.Parse(ASTsakWinS.Substring(0, 2));//任务开始时间 小时                 
                    }
                    else
                    {
                        AsSTH = int.Parse(ASTsakWinS.Substring(0, 1));//任务开始时间 小时
                    }
                    AsSTM = int.Parse(ASTsakWinS.Substring(ASTsakWinS.Length - 2, 2));//任务开始时间 分钟 
                    if ((AsSTH * 60 + AsSTM) > (SThour * 60 + STmin))//开始时间取  较大值
                    {
                        double st = AsSTH + (double)AsSTM / 60 - (ASdcen / 1000 / ASv);
                        AsSTH = (int)Math.Floor(st);
                        AsSTM = (int)((double)(st - AsSTH) * 60); //(int)(st - AsSTH) * 60;
                        if (st < (SThour + (double)STmin / 60))
                        {
                            AsSTH = SThour;
                            AsSTM = STmin;
                        }
                    }
                    else
                    {
                        AsSTH = SThour;
                        AsSTM = STmin;
                    }
                    #endregion



                    if ((ASTWEhour * 60 + ASTWEmin - AsSTH * 60 - AsSTM - (ASdcen / ASv / 1000) * 60) < ASconT * 60)
                    {
                        Tas = (ASTWEhour * 60 + ASTWEmin - AsSTH * 60 - AsSTM - (ASdcen / ASv / 1000) * 60) / 60;//有效观测时间 小时
                        //TmaxAS = ASconT;
                    }
                    else
                    {
                        Tas = ASconT; //有效观测时间 小时
                        //TmaxAS = (TWEhour * 60 + TWEmin - SThour * 60 - STmin - (ASdcen / ASv / 1000) * 60) / 60;
                    }
                    if (Tas > 0)//观测该任务的时间必须 >0 才有意义 ，说明可以观测到该任务
                    {
                        ASScstr = Tas * ASv * ASwidth * 1000;//能够观测的面积  平方米
                        TmaxAS = (ASTWEhour * 60 + ASTWEmin - AsSTH * 60 - AsSTM) / 60;
                        //根据Scstr确定半径ober_urad  
                        /////////////////////////（算法A）循环逼近半径/////////////////////////////////////////
                        oberASd = AreaToRadius(ASOneLayer, taskOneLayer, ASScstr, TmaxAS * ASv * 1000); //(TmaxAS的确定？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？ 
                        if (oberASd > 0)//观测半径>0 有实际意义
                        {
                            R_TInfo AStoTinfo = new R_TInfo() { ResouceFID = ASFID.ToString(), TaskFID = TaskFID.ToString() };
                            AStoTaskFIDlist.Add(AStoTinfo);//AS相对于任务的FID 以便为缓冲区命名 后面调用
                            ASToTaskBFpath = System.AppDomain.CurrentDomain.BaseDirectory + "Data\\cache\\" + AStoTaskFIDlist.Count + "ASBF.shp";// ASFID + "_" + TaskFID + "#ASBF.shp";
                            //根据当前飞艇和当前任务时间约束下的 观测半径 构建缓冲区
                            GPBufferTool((ILayer)ASOneLayer, ASToTaskBFpath, oberASd.ToString());
                            ASoneBFLayer = OpenFile_LayerFile(ASToTaskBFpath);
                            //根据缓冲区和对应任务区构建此飞艇能够观测到的此任务区  （Intersect工具 观测范围和任务的重叠部分）                            
                            ASBfToTaskPath = System.AppDomain.CurrentDomain.BaseDirectory + "Data\\cache\\" + AStoTaskFIDlist.Count + "AstoT.shp";
                            GPIntersectTool(ASoneBFLayer.FeatureClass, taskOneLayer.FeatureClass, ASBfToTaskPath);
                            IFeatureLayer ASToTTrueObe = OpenFile_LayerFile(ASBfToTaskPath);
                            IArea ASTarea;
                            double areaAS;
                            if (ASToTTrueObe.FeatureClass.FeatureCount(null) > 0)
                            {
                                IPolygon ASsubTPolygon = ASToTTrueObe.FeatureClass.GetFeature(0).Shape as IPolygon;//交集可能为空
                                ASTarea = ASsubTPolygon as IArea;
                                areaAS = ASTarea.Area;
                            }
                            else
                            {
                                areaAS = 0;
                            }


                            RTFeatureInfo RTFinfo = new RTFeatureInfo() { ASFID = ASFeature.get_Value(0).ToString(), UAVFID = "-1", SATFID = "-1", TFID = taskPointFeature.get_Value(0).ToString(), RtoTFL = ASToTTrueObe.FeatureClass.GetFeature(0), RtoTtime = Tas, areaT = areaAS };
                            lstFC.Add(RTFinfo);//每个飞艇相对于每个任务的最终观测区域 和飞艇ID和面状任务区ID对应关系，表明飞艇最终观测到此任务区


                        }
                    }

                    TaskFID = TaskFID + 1;
                    taskPointFeature = TaskPointfeatureCursor.NextFeature();
                }


                ASFID = ASFID + 1;
                ASFeature = ASfeatureCursor.NextFeature();
            }
            //飞艇及实际观测范围--------------------------------------(飞艇结束)------------------------------------------

            #endregion

            #region 卫星观测区域确定

            //卫星及实际观测范围--------------------------------------(卫星开始)------------------------------------------
            List<R_TInfo> SattoTaskFIDlist = new List<R_TInfo>();//sat相对于任务的FID 以便为条带命名 卫星资源FID  源任务FID 子任务FID

            IQueryFilter pSatFilter = new QueryFilter();//实例化一个查询条件对象 
            pSatFilter.WhereClause = "FID >= 0";//将查询条件赋值     遍历每一个
            IFeatureCursor SatfeatureCursor = SatFeLayer.Search(pSatFilter, false);
            IFeature SatFeature = SatfeatureCursor.NextFeature();//遍历查询结果  每一个卫星条带
            //获取每一个卫星条带
            while (SatFeature != null)
            {
                R_TInfo satinfo = new R_TInfo() { ResouceFID = SatFeature.get_Value(16).ToString(), TaskFID = SatFeature.get_Value(15).ToString(), SatEleTFID = int.Parse(SatFeature.get_Value(0).ToString()) };//卫星资源FID  源任务FID 子任务FID
                SattoTaskFIDlist.Add(satinfo);//AS相对于任务的FID 以便为缓冲区命名 后面调用

                //string oneSatTaskPath = System.AppDomain.CurrentDomain.BaseDirectory + "Data\\cache\\" + "OneStask.shp";
                //GPselectTool(ptaskFeatureLayer, oneSatTaskPath, "FID=", int.Parse(SatFeature.get_Value(5).ToString()));//选出单个任务区 
                //IFeatureLayer SattaskOneLayer = OpenFile_LayerFile(oneSatTaskPath);//选出单个任务区作为要素图层

                string oneSatPath = System.AppDomain.CurrentDomain.BaseDirectory + "Data\\cache\\" + SattoTaskFIDlist.Count + "OneSat.shp";
                GPselectTool(SatFeLayer, oneSatPath, "FID=", int.Parse(SatFeature.get_Value(0).ToString()));// 相当于缓冲区 这里是卫星覆盖的子区域 
                IFeatureLayer ASToTTrueObe = OpenFile_LayerFile(oneSatPath);

                //根据卫星条带和对应任务区构建此卫星能够观测到的此任务区  （Intersect工具 观测范围和任务的重叠部分）                            
                //string SatBfToTaskPath = System.AppDomain.CurrentDomain.BaseDirectory + "Data\\cache\\" + SattoTaskFIDlist.Count + "SattoT.shp";
                ////GPIntersectTool(SatTirpLayer.FeatureClass, SattaskOneLayer.FeatureClass, SatBfToTaskPath);
                //IFeatureLayer ASToTTrueObe = OpenFile_LayerFile(SatBfToTaskPath);

                RTFeatureInfo sRTFinfo = new RTFeatureInfo() { SATFID = SatFeature.get_Value(16).ToString(), CarFID = "-1", UAVFID = "-1", ASFID = "-1", TFID = SatFeature.get_Value(15).ToString(), RtoTFL = ASToTTrueObe.FeatureClass.GetFeature(0) };
                lstFC.Add(sRTFinfo);//每个飞艇相对于每个任务的最终观测区域 和飞艇ID和面状任务区ID对应关系，表明飞艇最终观测到此任务区


                SatFeature = SatfeatureCursor.NextFeature();
            }


            //卫星及实际观测范围--------------------------------------(卫星结束)------------------------------------------

            #endregion



            #endregion

            #region 任务分解 交集求元任务

            //通过交集求最终的元任务集并显示--------------------------------------(交集求元任务开始)------------------------------------------
            //将资源观测到任务的实际区域交叉分割 形成最终的子任务   每一次叠加操作 都要更新每个任务的观测资源集

            #region 将feature转为featurelayer
            string firstPolygonPath = System.AppDomain.CurrentDomain.BaseDirectory + "Data\\MidData\\firstPolygon.shp";
            IFeatureLayer FCartoTaskFeatureLayer = OpenFile_LayerFile(firstPolygonPath);//每一个车观测每一个任务的具体区域

            if (FCartoTaskFeatureLayer.FeatureClass.FeatureCount(null) != 0)//判断如果CartoTaskPolygonFeatureLayer内不为空 则删除所有值
            {
                ITable pTable = FCartoTaskFeatureLayer.FeatureClass as ITable;
                pTable.DeleteSearchedRows(null);
            }
            IFeature FPolygonFeature = FCartoTaskFeatureLayer.FeatureClass.CreateFeature();
            FPolygonFeature.Shape = lstFC[0].RtoTFL.Shape;
            FPolygonFeature.Store();

            string secondPolygonPath = System.AppDomain.CurrentDomain.BaseDirectory + "Data\\MidData\\secondPolygon.shp";
            IFeatureLayer SCartoTaskFeatureLayer = OpenFile_LayerFile(secondPolygonPath);//每一个车观测每一个任务的具体区域



            #endregion

            string UavToTasdfkUnionPath;
            //IFeatureLayer replaceLayer = lstFC[0].RtoTFL;
            List<IFeatureLayer> lstTWOFC = new List<IFeatureLayer>();//Union工具只能输入两个图层 以后可修改
            for (int i = 1; i < lstFC.Count; i++)
            {
                #region 将feature转为featurelayer

                if (SCartoTaskFeatureLayer.FeatureClass.FeatureCount(null) != 0)//判断如果CartoTaskPolygonFeatureLayer内不为空 则删除所有值
                {
                    ITable pTable = SCartoTaskFeatureLayer.FeatureClass as ITable;
                    pTable.DeleteSearchedRows(null);
                }


                IFeature SPolygonFeature = SCartoTaskFeatureLayer.FeatureClass.CreateFeature();
                SPolygonFeature.Shape = lstFC[i].RtoTFL.Shape;
                SPolygonFeature.Store();
                #endregion

                UavToTasdfkUnionPath = System.AppDomain.CurrentDomain.BaseDirectory + "Data\\cache\\" + i.ToString() + "Uni.shp";
                lstTWOFC.Add(FCartoTaskFeatureLayer);
                lstTWOFC.Add(SCartoTaskFeatureLayer);
                GPUnionTool(lstTWOFC, UavToTasdfkUnionPath);
                FCartoTaskFeatureLayer = OpenFile_LayerFile(UavToTasdfkUnionPath);
                lstTWOFC.Clear();
            }
            //以上不包括无人机无法到达观测的子任务  以上结果和TaskArea再进行一次Union可解决
            lstTWOFC.Clear();
            lstTWOFC.Add(FCartoTaskFeatureLayer);//能够观测到的区域分割结果
            lstTWOFC.Add(ptaskFeatureLayer);//任务区
            string UavToTaUnionPath = System.AppDomain.CurrentDomain.BaseDirectory + "Data\\cache\\" + "UToTaUni.shp";
            GPUnionTool(lstTWOFC, UavToTaUnionPath);
            subTaskLayer = OpenFile_LayerFile(UavToTaUnionPath);
            Program.myMap.AddLayer(subTaskLayer as ILayer, 0);
            //通过交集求最终的元任务集并显示--------------------------------------(交集求元任务结束)------------------------------------------

            #endregion


            #region 元任务构建 对应关系确定
            //求元任务集中每一个 元任务的原任务、资源、覆盖级别对应关系--------------------------------------(对应关系开始)------------------------------------------
            //每一个子任务的所属任务FID  所属观测资源FID  子任务FID 覆盖级别
            List<RTsubTInfo> lstTaskFC = new List<RTsubTInfo>();//★★★★★★★★★★★★★★★★存储对应关系 
            IQueryFilter pFilter = new QueryFilter();//实例化一个查询条件对象 
            pFilter.WhereClause = "FID >= 0";//将查询条件赋值     选择所有的子任务
            IFeatureCursor subTaskfeatureCursor = subTaskLayer.Search(pFilter, false);// subTaskLayer为最终元任务
            IFeature subTaskFeature = subTaskfeatureCursor.NextFeature();//遍历查询结果  子任务
            string OriTFID = "-1";//原任务FID
            while (subTaskFeature != null)
            {
                ISpatialFilter pContainFilter = new SpatialFilterClass();
                pContainFilter.Geometry = subTaskFeature.Shape;
                pContainFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;//空间关系选择条件 用相交选择该子任务的原始任务
                IFeatureCursor OriTaskfeatureCursor = ptaskFeatureLayer.FeatureClass.Search(pContainFilter, false);//ptaskFeatureLayer是源任务
                IFeature pTFeature = OriTaskfeatureCursor.NextFeature();//查询与子任务相交的原任务区
                while (pTFeature != null)//有且仅有一个与子任务相交的原任务区
                {

                    OriTFID = pTFeature.get_Value(0).ToString();//当前子任务所属原任务的FID  
                    double subTweight = double.Parse(pTFeature.get_Value(9).ToString());//当前子任务所属原任务的权重
                    string subTWinS = pTFeature.get_Value(4).ToString();//当前子任务所属原任务的开始时间
                    string subTWinE = pTFeature.get_Value(5).ToString();//当前子任务所属原任务的结束时间
                    int coverNO = 0;
                    List<int> ReUAVID = new List<int>();//每一个子任务的无人机资源FID 列表                    
                    //确定所属资源FID   无人机/////////////////////////////////////////////////////////////////////////////////////////////
                    //////////////////////////////
                    for (int j = 0; j < RTinfoList.Count; j++)
                    {
                        if (int.Parse(OriTFID) == int.Parse(RTinfoList[j].TaskFID))//查找与原任务id匹配的序列 以确定缓冲区
                        {
                            string UtoTBFpath = System.AppDomain.CurrentDomain.BaseDirectory + "Data\\cache\\" + j + layer.Name + "slBF.shp";
                            if (File.Exists(UtoTBFpath))//判断文件是否存在
                            {
                                IFeatureLayer UtoTBFfl = OpenFile_LayerFile(UtoTBFpath);
                                //不能用相交？ 接触的情况也能查出来
                                ISpatialFilter pRBFFilter = new SpatialFilterClass();
                                pRBFFilter.Geometry = subTaskFeature.Shape;
                                pRBFFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelWithin;//空间关系选择条件 选择能够观测到该子任务的缓冲区 （subT在UtoTBF内部，子任务是query ，缓冲区是target）——
                                IFeatureCursor TasktoRBFCursor = UtoTBFfl.FeatureClass.Search(pRBFFilter, false);
                                IFeature BFFeature = TasktoRBFCursor.NextFeature();//查询包含子任务的缓冲区
                                if (BFFeature != null)
                                {
                                    //RTsubTInfo RTFNOinfo = new RTsubTInfo() { RID = (int.Parse(RTinfoList[j].ResouceID) - 1).ToString(), TID = (int.Parse(RTinfoList[j].TaskID) - 1).ToString(), subTID = subTaskFeature.get_Value(0).ToString() };
                                    //lstTaskFC.Add(RTFNOinfo);
                                    ReUAVID.Add(int.Parse(RTinfoList[j].ResouceFID));
                                    BFFeature = TasktoRBFCursor.NextFeature();
                                }
                            }
                            else
                            { }

                        }
                    }

                    //确定元任务所属car
                    List<int> ReCarID = new List<int>();//每一个元任务的car资源fid列表
                    #region 确定元任务所属car

                    //不能用相交？ 接触的情况也能查出来
                    ISpatialFilter carRBFFilter = new SpatialFilterClass();
                    carRBFFilter.Geometry = subTaskFeature.Shape;
                    carRBFFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelWithin;//空间关系选择条件 选择能够观测到该子任务的缓冲区 （subT在UtoTBF内部，子任务是query ，缓冲区是target）——
                    IFeatureCursor carTasktoRBFCursor = CartoTaskPolygonFeatureLayer.FeatureClass.Search(carRBFFilter, false);
                    IFeature CarBFFeature = carTasktoRBFCursor.NextFeature();//查询包含子任务的缓冲区 
                    if (CarBFFeature != null)
                    {
                        ReCarID.Add(int.Parse(CarBFFeature.get_Value(3).ToString()));//如果子任务在此缓冲区内，则缓冲区对应的CarFid能观察到此元任务，同时此缓冲区对应的源任务FID必将等于元任务对应的源任务fid
                        if (CarBFFeature.get_Value(4).ToString() != OriTFID)//验证此缓冲区对应的源任务FID是否等于元任务对应的源任务fid
                        { MessageBox.Show("确定元任务所属car有问题。"); }
                        CarBFFeature = carTasktoRBFCursor.NextFeature();
                    }
                    #endregion





                    List<int> ReASID = new List<int>();//每一个子任务的飞艇资源FID 列表
                    //确定所属资源FID  飞艇/////////////////////////////////////////////////////////////////////////////////////////
                    for (int asi = 0; asi < AStoTaskFIDlist.Count; asi++)
                    {
                        if (OriTFID == AStoTaskFIDlist[asi].TaskFID)//查找与原任务id匹配的序列 以确定缓冲区
                        {
                            string AStoTBFpath = System.AppDomain.CurrentDomain.BaseDirectory + "Data\\cache\\" + (asi + 1).ToString() + "ASBF.shp";
                            IFeatureLayer AStoTBFfl = OpenFile_LayerFile(AStoTBFpath);
                            ISpatialFilter pASBFFilter = new SpatialFilterClass();
                            pASBFFilter.Geometry = subTaskFeature.Shape;
                            pASBFFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelWithin;//空间关系选择条件 选择能够观测到该子任务的缓冲区 （subT在UtoTBF内部，子任务是query ，缓冲区是target）——
                            IFeatureCursor TasktoASBFCursor = AStoTBFfl.FeatureClass.Search(pASBFFilter, false);
                            IFeature ASBFFeature = TasktoASBFCursor.NextFeature();//查询包含子任务的缓冲区
                            if (ASBFFeature != null)
                            {
                                //RTsubTInfo RTFNOinfo = new RTsubTInfo() { RID = (int.Parse(RTinfoList[j].ResouceID) - 1).ToString(), TID = (int.Parse(RTinfoList[j].TaskID) - 1).ToString(), subTID = subTaskFeature.get_Value(0).ToString() };
                                //lstTaskFC.Add(RTFNOinfo);
                                ReASID.Add(int.Parse(AStoTaskFIDlist[asi].ResouceFID));
                                ASBFFeature = TasktoASBFCursor.NextFeature();
                            }

                        }
                    }
                    //确定所属资源FID  卫星/////////////////////////////////////////////////////////////////////////////////////////
                    List<int> ReSatID = new List<int>();//每一个子任务的飞艇资源FID 列表                   
                    for (int sati = 0; sati < SattoTaskFIDlist.Count; sati++)
                    {
                        if (OriTFID == SattoTaskFIDlist[sati].TaskFID)//查找与原任务id匹配的序列 以确定条带
                        {

                            string SATtoTBFpath = System.AppDomain.CurrentDomain.BaseDirectory + "Data\\cache\\" + (sati + 1).ToString() + "OneSat.shp";
                            IFeatureLayer SATtoTBFfl = OpenFile_LayerFile(SATtoTBFpath);



                            ISpatialFilter psatBFFilter = new SpatialFilterClass();
                            psatBFFilter.Geometry = subTaskFeature.Shape;
                            psatBFFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelWithin;//空间关系选择条件 选择能够观测到该子任务的缓冲区 （subT在UtoTBF内部，子任务是query ，缓冲区是target）——
                            IFeatureCursor TasktosatBFCursor = SATtoTBFfl.FeatureClass.Search(psatBFFilter, false);
                            IFeature satBFFeature = TasktosatBFCursor.NextFeature();//查询包含子任务的缓冲区

                            ISpatialFilter psatBFFilter2 = new SpatialFilterClass();//在卫星观测区域之内或完全覆盖
                            psatBFFilter2.Geometry = subTaskFeature.Shape;
                            psatBFFilter2.SpatialRel = esriSpatialRelEnum.esriSpatialRelOverlaps;//空间关系选择条件 选择能够观测到该子任务的缓冲区 （subT在UtoTBF内部，子任务是query ，缓冲区是target）
                            IFeatureCursor TasktosatBFCursor2 = SATtoTBFfl.FeatureClass.Search(psatBFFilter2, false);
                            IFeature satBFFeature2 = TasktosatBFCursor2.NextFeature();//查询包含子任务的缓冲区

                            if (satBFFeature != null)
                            {
                                //RTsubTInfo RTFNOinfo = new RTsubTInfo() { RID = (int.Parse(RTinfoList[j].ResouceID) - 1).ToString(), TID = (int.Parse(RTinfoList[j].TaskID) - 1).ToString(), subTID = subTaskFeature.get_Value(0).ToString() };
                                //lstTaskFC.Add(RTFNOinfo);
                                ReSatID.Add(int.Parse(SattoTaskFIDlist[sati].ResouceFID));
                                satBFFeature = TasktosatBFCursor.NextFeature();
                            }
                            else if (satBFFeature2 != null)
                            {
                                ReSatID.Add(int.Parse(SattoTaskFIDlist[sati].ResouceFID));
                                satBFFeature2 = TasktosatBFCursor2.NextFeature();
                            }

                        }
                    }

                    IPolygon subTPolygon = subTaskFeature.Shape as IPolygon;
                    IArea subTarea = subTPolygon as IArea;

                    RTsubTInfo RTFNOinfo = new RTsubTInfo() { TFID = (int.Parse(OriTFID)).ToString(), subTFID = subTaskFeature.get_Value(0).ToString(), UAVFID = ReUAVID, CarFID = ReCarID, ASFID = ReASID, SatFID = ReSatID, CoverL = ReUAVID.Count + ReASID.Count + ReSatID.Count + ReCarID.Count, subTArea = subTarea.Area, subTWeight = subTweight, subTWinS = subTWinS, subTWinE = subTWinE, UAVReturns = 0, ASReturns = 0, SatReturns = 0, CarReturns = 0 };
                    lstTaskFC.Add(RTFNOinfo);

                    pTFeature = OriTaskfeatureCursor.NextFeature();
                }

                subTaskFeature = subTaskfeatureCursor.NextFeature();
            }
            //求元任务集中每一个 元任务的原任务、资源、覆盖级别对应关系--------------------------------------(对应关系结束)------------------------------------------

            #endregion

            LastsubTaskLayer = subTaskLayer;//输出最终元任务集
            lstsubTFC = lstFC;//资源相对任务的观测区域 子任务
            lstEleTFC = lstTaskFC;//输出元任务对应关系
            SatTaskFID = SattoTaskFIDlist;
        }
        #endregion

        #region 卫星子任务冲突判断方法
        /// <summary>
        /// 卫星冲突判断
        /// </summary>        
        public static void SatConflic(ILayer satAtributeLayer, IFeatureLayer satAtributeFL, List<R_TInfo> SattoTaskFIDlist, IFeatureLayer SatFeLayer, out List<RT_FID> SatSubTFIDlist)
        {
            #region 卫星冲突判断
            //卫星冲突判断开始--------------------------------------(sat冲突判断开始)------------------------------------------ 

            int satNo = satAtributeFL.FeatureClass.FeatureCount(null);
            List<RT_FID> satRTFIDlist = new List<RT_FID>();//卫星FID 及此卫星能够观测的元任务集FIDlist ,以及元任务发生冲突的list★★★★★★★★★★★★★★★★ 资源FID：int，元任务FID：list<int>,元任务个数：int  
            for (int i = 0; i < satNo; i++) //卫星FID                      SattoTaskFIDlist
            {//对于卫星 不需判断每个元任务的冲突 因为假定卫星要么观测一个任务的完整条带 要么完全不观测
                List<int> satSubFIdlist = new List<int>();//存储每个资源能够观测的satElemT任务fid列表
                for (int j = 0; j < SattoTaskFIDlist.Count; j++)////SattoTaskFIDlist:卫星资源FID  源任务FID 子任务FID
                {

                    if (i.ToString() == SattoTaskFIDlist[j].ResouceFID)
                    {
                        satSubFIdlist.Add(SattoTaskFIDlist[j].SatEleTFID);//卫星观测任务FID 即SatElementTask中FID 2 3 5 6
                    }
                }
                IFeature SATatributeFeature = satAtributeFL.FeatureClass.GetFeature(i);//当前卫星（获取属性）
                double Vengel = double.Parse(SATatributeFeature.get_Value(10).ToString()); //侧摆角转向速度 度每秒
                double storeV = double.Parse(SATatributeFeature.get_Value(9).ToString()); //星上存储容量 GB
                double intervalT = double.Parse(SATatributeFeature.get_Value(11).ToString()); //开机间隔时间 秒
                double staT = double.Parse(SATatributeFeature.get_Value(12).ToString()); //侧摆之后稳定时间 秒
                List<ConflictTFID> satConFIdlist = new List<ConflictTFID>();//存储每个卫星能够观测的SatElemT中发生冲突的任务FID列表list<(int,int)>
                if (satSubFIdlist.Count > 1)//当前观测资源能够观测到的元任务不为空且大于1，满足两两冲突的基本条件
                {
                    //卫星冲突判断  转角时间约束 和容量约束
                    for (int j = 0; j < satSubFIdlist.Count; j++)
                    {
                        for (int k = j + 1; k < satSubFIdlist.Count; k++)
                        {


                            IFeature firstSATTask = SatFeLayer.FeatureClass.GetFeature(satSubFIdlist[j]);//获取第一个冲突任务要素
                            IFeature secondSATTask = SatFeLayer.FeatureClass.GetFeature(satSubFIdlist[k]);//获取第二个冲突任务要素
                            string firstTaskStime = firstSATTask.get_Value(10).ToString();//获取第一个冲突任务的开始观测时间
                            string firstTaskEtime = firstSATTask.get_Value(11).ToString();//获取第一个冲突任务的结束观测时间
                            string secondTaskStime = secondSATTask.get_Value(10).ToString();//获取第二个冲突任务的开始观测时间
                            string secondTaskEtime = secondSATTask.get_Value(11).ToString();//获取第二个冲突任务的结束观测时间
                            double firstAngel = double.Parse(firstSATTask.get_Value(12).ToString());//获取第一个冲突任务的侧摆角 度
                            double secondAngel = double.Parse(secondSATTask.get_Value(12).ToString());//获取第二个冲突任务的侧摆角 
                            double firstStore = double.Parse(firstSATTask.get_Value(14).ToString());//
                            double secondStore = double.Parse(secondSATTask.get_Value(14).ToString());//获取第二个冲突任务的需要容量 G

                            //确定时间
                            int firstTShour = 0;//第一个冲突任务的开始观测时间 小时
                            double firstTSmin = 0;//第一个冲突任务的开始观测时间 分钟
                            int firstTEhour = 0;//第一个冲突任务的结束观测时间 小时
                            double firstTEmin = 0;//第一个冲突任务的结束观测时间 分钟
                            int secondTShour = 0;//第二个冲突任务的开始观测时间 小时
                            double secondTSmin = 0;//第二个冲突任务的开始观测时间 分钟
                            int secondTEhour = 0;//第二个冲突任务的结束观测时间 小时
                            double secondTEmin = 0;//第二个冲突任务的结束观测时间 分钟
                            #region 确定时间

                            if (firstTaskStime.Contains("."))
                            {
                                string HourAndMin = firstTaskStime.Substring(0, firstTaskStime.IndexOf("."));
                                if (HourAndMin.Length > 3)
                                {
                                    firstTShour = int.Parse(HourAndMin.Substring(0, 2));//第一个任务开始观测时间  小时                 
                                }
                                else
                                {
                                    firstTShour = int.Parse(HourAndMin.Substring(0, 1));//
                                }
                                firstTSmin = double.Parse(HourAndMin.Substring(HourAndMin.Length - 2, 2) + firstTaskStime.Substring(firstTaskStime.IndexOf(".")));//第一个任务开始观测时间  分钟  
                            }
                            else
                            {
                                if (firstTaskStime.Length > 3)
                                {
                                    firstTShour = int.Parse(firstTaskStime.Substring(0, 2));// 
                                }
                                else
                                {
                                    firstTShour = int.Parse(firstTaskStime.Substring(0, 1));//
                                }
                                firstTSmin = int.Parse(firstTaskStime.Substring(firstTaskStime.Length - 2, 2));//
                            }

                            /////////////////

                            if (firstTaskEtime.Contains("."))
                            {
                                string HourAndMin = firstTaskEtime.Substring(0, firstTaskEtime.IndexOf("."));
                                if (HourAndMin.Length > 3)
                                {
                                    firstTEhour = int.Parse(HourAndMin.Substring(0, 2));//第一个任务开始观测时间  小时                 
                                }
                                else
                                {
                                    firstTEhour = int.Parse(HourAndMin.Substring(0, 1));//
                                }
                                firstTEmin = double.Parse(HourAndMin.Substring(HourAndMin.Length - 2, 2) + firstTaskEtime.Substring(firstTaskEtime.IndexOf(".")));//第一个任务开始观测时间  分钟  
                            }
                            else
                            {
                                if (firstTaskEtime.Length > 3)
                                {
                                    firstTEhour = int.Parse(firstTaskEtime.Substring(0, 2));// 
                                }
                                else
                                {
                                    firstTEhour = int.Parse(firstTaskEtime.Substring(0, 1));//
                                }
                                firstTEmin = int.Parse(firstTaskEtime.Substring(firstTaskEtime.Length - 2, 2));//
                            }

                            /////////////////

                            if (secondTaskStime.Contains("."))
                            {
                                string HourAndMin = secondTaskStime.Substring(0, secondTaskStime.IndexOf("."));
                                if (HourAndMin.Length > 3)
                                {
                                    secondTShour = int.Parse(HourAndMin.Substring(0, 2));//第一个任务开始观测时间  小时                 
                                }
                                else
                                {
                                    secondTShour = int.Parse(HourAndMin.Substring(0, 1));//
                                }
                                secondTSmin = double.Parse(HourAndMin.Substring(HourAndMin.Length - 2, 2) + secondTaskStime.Substring(secondTaskStime.IndexOf(".")));//第一个任务开始观测时间  分钟  
                            }
                            else
                            {
                                if (secondTaskStime.Length > 3)
                                {
                                    secondTShour = int.Parse(secondTaskStime.Substring(0, 2));// 
                                }
                                else
                                {
                                    secondTShour = int.Parse(secondTaskStime.Substring(0, 1));//
                                }
                                secondTSmin = int.Parse(secondTaskStime.Substring(secondTaskStime.Length - 2, 2));//
                            }

                            /////////////////

                            if (secondTaskEtime.Contains("."))
                            {
                                string HourAndMin = secondTaskEtime.Substring(0, secondTaskEtime.IndexOf("."));
                                if (HourAndMin.Length > 3)
                                {
                                    secondTEhour = int.Parse(HourAndMin.Substring(0, 2));//第一个任务开始观测时间  小时                 
                                }
                                else
                                {
                                    secondTEhour = int.Parse(HourAndMin.Substring(0, 1));//
                                }
                                secondTEmin = double.Parse(HourAndMin.Substring(HourAndMin.Length - 2, 2) + secondTaskEtime.Substring(secondTaskEtime.IndexOf(".")));//第一个任务开始观测时间  分钟  
                            }
                            else
                            {
                                if (secondTaskEtime.Length > 3)
                                {
                                    secondTEhour = int.Parse(secondTaskEtime.Substring(0, 2));// 
                                }
                                else
                                {
                                    secondTEhour = int.Parse(secondTaskEtime.Substring(0, 1));//
                                }
                                secondTEmin = int.Parse(secondTaskEtime.Substring(secondTaskEtime.Length - 2, 2));//
                            }

                            #endregion


                            if ((firstTShour * 60 + firstTSmin) < (secondTShour * 60 + secondTSmin))
                            {
                                if (firstTEhour * 3600 + firstTEmin * 60 + Math.Abs(firstAngel - secondAngel) / Vengel + intervalT + staT > secondTShour * 3600 + secondTSmin * 60)//化成秒比较
                                {
                                    //冲突
                                    ConflictTFID conflictFidInfo = new ConflictTFID() { firstTFID = satSubFIdlist[j], secondTFID = satSubFIdlist[k] };//存储的是SatElementTask的FID
                                    satConFIdlist.Add(conflictFidInfo);
                                }
                                else if (firstStore + secondStore > storeV)
                                {
                                    ConflictTFID conflictFidInfo = new ConflictTFID() { firstTFID = satSubFIdlist[j], secondTFID = satSubFIdlist[k] };//存储的是SatElementTask的FID
                                    satConFIdlist.Add(conflictFidInfo);
                                }
                            }
                            else
                            {
                                if (secondTEhour * 3600 + secondTEmin * 60 + Math.Abs(firstAngel - secondAngel) / Vengel + intervalT + staT > firstTShour * 3600 + firstTSmin * 60)//化成秒比较
                                {
                                    //冲突
                                    ConflictTFID conflictFidInfo = new ConflictTFID() { firstTFID = satSubFIdlist[j], secondTFID = satSubFIdlist[k] };//存储的是SatElementTask的FID
                                    satConFIdlist.Add(conflictFidInfo);
                                }
                                else if (firstStore + secondStore > storeV)
                                {
                                    ConflictTFID conflictFidInfo = new ConflictTFID() { firstTFID = satSubFIdlist[j], secondTFID = satSubFIdlist[k] };//存储的是SatElementTask的FID
                                    satConFIdlist.Add(conflictFidInfo);
                                }
                            }



                        }//第二个任务 k
                    }//第一个任务 j

                }//(subFIdlist.Count > 1) 当前资源观测的元任务个数大于1

                RT_FID rtFidInfo = new RT_FID() { RFID = i, subTaskFID = satSubFIdlist, ConflictTaskFID = satConFIdlist, taskCount = satSubFIdlist.Count };
                satRTFIDlist.Add(rtFidInfo);
            }
            //卫星冲突判断结束--------------------------------------(sat冲突判断结束)------------------------------------------ 
            #endregion
            SatSubTFIDlist = satRTFIDlist;//卫星FID 及此卫星能够观测的子任务集FIDlist ,以及元任务发生冲突的list
        }
        #endregion

        #region 构建卫星观测子任务与元任务的对应关系
        /// <summary>
        /// 卫星观测子任务与元任务的对应关系
        /// </summary>
        /// <param name="SatFL">卫星观测子任务</param>
        /// <param name="GridTaskFL">元任务</param>
        /// <param name="SatTtoEleT">对应关系</param>
        public static void SatSubTtoEleT(IFeatureLayer SatFL, IFeatureLayer GridTaskFL, out List<Sat_ElementTFID> SatTtoEleT)
        {

            List<Sat_ElementTFID> SatTElementT = new List<Sat_ElementTFID>();//存储每一个卫星观测子任务与能够覆盖的元任务的FID对应关系/////////////////////////////////////////////////////////// 

            //IFeature CurrentFe = SatFeLayer.FeatureClass.GetFeature(subTFID);//SatElementTask中当前子任务要素
            IQueryFilter satpFilter = new QueryFilter();//实例化一个查询条件对象 
            satpFilter.WhereClause = "FID >= 0";//将查询条件赋值     选择所有的子任务
            IFeatureCursor satsubTaskfeatureCursor = SatFL.Search(satpFilter, false);// SatFeLayer为卫星观测子任务
            IFeature satsubTaskFeature = satsubTaskfeatureCursor.NextFeature();//遍历查询结果  子任务

            while (satsubTaskFeature != null)
            {
                List<int> ElementFID = new List<int>();//存储当前卫星观测子任务能够覆盖的元任务list


                ISpatialFilter pContainFilter = new SpatialFilterClass();
                pContainFilter.Geometry = satsubTaskFeature.Shape;//卫星观测的一个子任务
                pContainFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelContains;//空间关系选择条件 用包含选择 卫星观测的一个子任务包含的元任务
                IFeatureCursor OriTaskfeatureCursor = GridTaskFL.FeatureClass.Search(pContainFilter, false);//subTaskLayer是最终的元任务
                IFeature ElementTFeature = OriTaskfeatureCursor.NextFeature();//查询卫星观测的一个子任务包含的元任务
                while (ElementTFeature != null)//卫星观测的一个子任务包含的元任务
                {
                    ElementFID.Add(int.Parse(ElementTFeature.get_Value(0).ToString()));//获取当前卫星观测子任务包含的元任务FID列表

                    ElementTFeature = OriTaskfeatureCursor.NextFeature();//查询卫星观测的一个子任务包含的元任务
                }




                Sat_ElementTFID satTtoElementT = new Sat_ElementTFID() { SatTFID = int.Parse(satsubTaskFeature.get_Value(0).ToString()), ElementTaskFID = ElementFID, SatFID = int.Parse(satsubTaskFeature.get_Value(16).ToString()) };//卫星子任务fid  对应元任务集 卫星fid
                SatTElementT.Add(satTtoElementT);
                satsubTaskFeature = satsubTaskfeatureCursor.NextFeature();//遍历查询结果  子任务
            }
            SatTtoEleT = SatTElementT;
        }
        #endregion

        #region 公共函数
        /// <summary>
        /// 求标准差
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        private static double CalculateStdDev(IEnumerable<double> values)
        {
            double ret = 0;
            if (values.Count() > 0)
            {
                //  计算平均数   
                double avg = values.Average();
                //  计算各数值与平均数的差值的平方，然后求和 
                double sum = values.Sum(d => Math.Pow(d - avg, 2));
                //  除以数量，然后开方
                ret = Math.Sqrt(sum / values.Count());
            }
            return ret;
        }
        /// <summary>
        /// 按照指标将list进行排序 以达到面积优先或权重优先的分配原则
        /// </summary>
        /// <param name="SubTfid">需要排序的list</param>
        /// <param name="SatFeLayer">SatElementTask</param>
        /// <param name="SortIndex">排序指标 根据SatElementTask的属性表 3：面积  6：权重</param>
        /// <param name="SatSubTsort"></param>
        /// ContrastPlan：0：面积  1：权重  2：权重*面积
        public static void SubTsort(List<int> SortTfid, IFeatureLayer SatFeLayer, int SortAreaIndex, int SortWeightIndex, int ContrastPlan, out List<int> SatSubTsort)
        {

            List<Atrrbi_T> flagT = new List<Atrrbi_T>();
            for (int i = 0; i < SortTfid.Count; i++)
            {
                IFeature SatSubTF = SatFeLayer.FeatureClass.GetFeature(SortTfid[i]);
                Atrrbi_T flagA = new Atrrbi_T() { SubTFID = SortTfid[i], Area = (double)SatSubTF.get_Value(SortAreaIndex), Weight = (double)SatSubTF.get_Value(SortWeightIndex) };
                flagT.Add(flagA);
            }
            if (ContrastPlan == 0)//按照面积排序
            {
                flagT.Sort(new Comparison<Atrrbi_T>((Atrrbi_T s1, Atrrbi_T s2) => { return (int)(s2.Area * 100000 - s1.Area * 100000); }));//按照面积降序排列
            }
            else if (ContrastPlan == 1)//按照权重排序
            {
                flagT.Sort(new Comparison<Atrrbi_T>((Atrrbi_T s1, Atrrbi_T s2) => { return (int)(s2.Weight * 100000 - s1.Weight * 100000); }));//权重都是小数 为了double转int 扩大倍数
            }
            else//按照面积*权重排序
            {
                flagT.Sort(new Comparison<Atrrbi_T>(new MyComparator().compare2));//按照面积大小排序（从大到小）
            }


            SatSubTsort = new List<int>(SortTfid);//直接将SortTfid复制到SatSubTsort 包括大小和数值
            //SatSubTsort = new List<int>(new int[SortTfid.Count]);//仅初始化大小 数值都为0
            for (int i = 0; i < flagT.Count; i++)
            {
                SatSubTsort[i] = flagT[i].SubTFID;
            }
        }
        /// <summary>
        /// 判断此卫星是否可以观测当前子任务
        /// </summary>
        /// <param name="SureSub">已确定观测的子任务集合</param>
        /// <param name="interSub">需要判断是否能观测的当前子任务</param>
        /// <param name="ConfliSub">当前卫星的子任务冲突集合</param>
        /// <returns></returns>
        public static bool SattoSubT(List<int> SureSub, int interSub, List<ConflictTFID> ConfliSub)
        {
            if (ConfliSub.Count == 0)//没有冲突
            { return true; }
            else
            {
                for (int i = 0; i < ConfliSub.Count; i++)//遍历冲突子任务
                {
                    ConflictTFID consub = ConfliSub[i];//获取第i个冲突集
                    if (interSub == consub.firstTFID || interSub == consub.secondTFID)
                    {
                        for (int k = 0; k < SureSub.Count; k++)//遍历已经确定观测的子任务集 SatEleT[k]:元任务FID
                        {
                            if (SureSub[k] == consub.firstTFID || SureSub[k] == consub.secondTFID)
                            {
                                return false;//如果包含冲突 则不能插入子任务
                                break;
                            }
                        }
                    }
                }
                return true;//可以观测 将此子任务插入确定观测的子任务集
            }


        }
        /// <summary>
        /// 判断此UAV是否可以观测当前子任务
        /// </summary>
        /// <param name="SureSub">已确定观测的子任务集合</param>
        /// <param name="interSub">需要判断是否能观测的当前子任务</param>
        /// <param name="UavFid">当前无人机fid</param>
        /// <param name="ptaskFeatureLayer">面状任务图层</param>
        public static bool UAVtoSubT(List<int> SureSub, int interSub, int UavFid, IFeatureLayer ptaskFeatureLayer, List<RTsubTInfo> lstTaskFC, List<RTFeatureInfo> lstFC)
        {
            //List<int> StartTimeHour = new List<int>();//开始观测时间 小时
            //List<int> StartTimeMin = new List<int>();//开始观测时间 分钟
            SureSub.Sort();//排序 从小到大
            List<int> OriTFID = new List<int>(SureSub);//每一个元任务的源任务fid 为了获取时间
            double[] eleTArea = new double[SureSub.Count];//每一个元任务的面积 为了获取持续观测时间
            string[] TStartTime = new string[SureSub.Count];//每一个元任务的开始时间
            string[] TEndTime = new string[SureSub.Count];//每一个元任务的开始时间
            string InterTStarTime = "";
            string InterTEndTime = "";
            //List<double> OriTArea = new List<double>();
            int intterOriTfid = 0;//插入元任务的源任务fid
            double intterOriTArea = 0;//插入元任务的面积
            for (int ti = 0; ti < lstTaskFC.Count; ti++)
            {
                for (int j = 0; j < SureSub.Count; j++)
                {
                    if (lstTaskFC[ti].subTFID == SureSub[j].ToString())
                    {
                        OriTFID[j] = int.Parse(lstTaskFC[ti].TFID);
                        eleTArea[j] = lstTaskFC[ti].subTArea;
                        IFeature OriTFeature = ptaskFeatureLayer.FeatureClass.GetFeature(OriTFID[j]);//获取元任务所属源任务要素 为了获取时间窗口
                        TStartTime[j] = OriTFeature.get_Value(4).ToString();//开始时间
                        TEndTime[j] = OriTFeature.get_Value(5).ToString();//结束时间
                    }
                    if (lstTaskFC[ti].subTFID == interSub.ToString())
                    {
                        intterOriTfid = int.Parse(lstTaskFC[ti].TFID);
                        intterOriTArea = lstTaskFC[ti].subTArea;
                        IFeature OriTFeature = ptaskFeatureLayer.FeatureClass.GetFeature(intterOriTfid);//获取元任务所属源任务要素 为了获取时间窗口
                        InterTStarTime = OriTFeature.get_Value(4).ToString();//开始时间
                        InterTEndTime = OriTFeature.get_Value(5).ToString();//结束时间
                    }

                }
            }
            double statT = 0;//获取已经确定元任务和插入元任务的平均开始观测时间 小时
            double endT = 0;//获取已经确定元任务和插入元任务的平均结束观测时间 小时
            #region 确定时间
            for (int i = 0; i < TStartTime.Length; i++)
            {
                int flaghour;
                if (TStartTime[i].Length > 3)
                {
                    flaghour = int.Parse(TStartTime[i].Substring(0, 2));//任务开始时间 小时                 
                }
                else
                {
                    flaghour = int.Parse(TStartTime[i].Substring(0, 1));//任务开始时间 小时
                }
                int flagmin = int.Parse(TStartTime[i].Substring(TStartTime[i].Length - 2, 2));//任务开始时间 分钟 
                double flag = flaghour + (double)flagmin / 60;
                statT = statT + flag;
                //if (flag < statT)
                //{
                //    statT = flag;
                //}
                int eFlagHour;
                if (TEndTime[i].Length > 3)
                {
                    eFlagHour = int.Parse(TEndTime[i].Substring(0, 2));//任务结束时间 小时                 
                }
                else
                {
                    eFlagHour = int.Parse(TEndTime[i].Substring(0, 1));//任务结束时间 小时
                }
                int eflagmin = int.Parse(TEndTime[i].Substring(TEndTime[i].Length - 2, 2));//任务结束时间 分钟 
                double Eflag = eFlagHour + (double)eflagmin / 60;
                endT = endT + Eflag;
                //if (Eflag > endT)
                //{ endT = Eflag; }
            }

            //插入任务时间
            int interTHour;
            int interTMin;
            int interETHour;
            int interETMin;
            if (InterTStarTime.Length > 3)
            {
                interTHour = int.Parse(InterTStarTime.Substring(0, 2));//任务开始时间 小时                 
            }
            else
            {
                interTHour = int.Parse(InterTStarTime.Substring(0, 1));//任务开始时间 小时
            }
            interTMin = int.Parse(InterTStarTime.Substring(InterTStarTime.Length - 2, 2));//任务开始时间 分钟 
            double interflag = interTHour + (double)interTMin / 60;
            statT = statT + interflag;
            statT = statT / (SureSub.Count + 1);//取开始时间的均值
            //if (interflag < statT)
            //{
            //    statT = interflag;
            //}

            if (InterTEndTime.Length > 3)
            {
                interETHour = int.Parse(InterTEndTime.Substring(0, 2));//任务结束时间 小时                 
            }
            else
            {
                interETHour = int.Parse(InterTEndTime.Substring(0, 1));//任务结束时间 小时
            }
            interETMin = int.Parse(InterTEndTime.Substring(InterTEndTime.Length - 2, 2));//任务结束时间 分钟 
            double Einterflag = interETHour + (double)interETMin / 60;
            endT = endT + Einterflag;
            endT = endT / (SureSub.Count + 1);//结束时间的均值
            //if (Einterflag > endT)
            //{ endT = Einterflag; }
            #endregion

            //根据元任务与资源观测任务的面积比值确定元任务持续观测时间
            List<double> ContiTime = new List<double>();//任务持续时间
            double interTConTime = 0;
            for (int Uavi = 0; Uavi < lstFC.Count; Uavi++)
            {
                for (int j = 0; j < OriTFID.Count; j++)
                {
                    if (lstFC[Uavi].UAVFID == UavFid.ToString() && lstFC[Uavi].TFID == OriTFID[j].ToString()) //如果资源和源任务都匹配 那么元任务属于此子任务
                    {
                        ContiTime.Add(eleTArea[j] / lstFC[Uavi].areaT * lstFC[Uavi].RtoTtime);  //任务持续时间 小时 
                        break;
                    }
                }
                if (lstFC[Uavi].UAVFID == UavFid.ToString() && lstFC[Uavi].TFID == intterOriTfid.ToString()) //如果资源和源任务都匹配 那么元任务属于此子任务
                {
                    interTConTime = intterOriTArea / lstFC[Uavi].areaT * lstFC[Uavi].RtoTtime;
                }
            }
            //最终判断
            for (int k = 0; k < ContiTime.Count; k++)
            {
                interTConTime = interTConTime + ContiTime[k];//所有任务持续时间之和
            }
            bool InterBool = (statT + interTConTime) < endT;//观测时间在约束时间之内 可以插入
            return InterBool;
        }

        /// <summary>
        /// 判断此AS是否可以观测当前子任务  默认按照列表顺序观测元任务
        /// </summary>
        /// <param name="SureSub">已确定观测的子任务集合</param>
        /// <param name="interSub">需要判断是否能观测的当前子任务</param>
        /// <param name="UavFid">当前ASfid</param>
        /// <param name="ptaskFeatureLayer">面状任务图层</param>
        public static bool AStoSubT(List<int> SureSub, int interSub, int ASFid, IFeatureLayer ptaskFeatureLayer, List<RTsubTInfo> lstTaskFC, List<RTFeatureInfo> lstFC, IFeatureLayer EleTPointFL, IFeatureLayer ASFeaturelayer)
        {
            SureSub.Sort();//排序 从小到大

            double[] eleTArea = new double[SureSub.Count];//每一个元任务的面积 为了获取持续观测时间
            string TStartTime = "";//第一个元任务的开始时间
            string TEndTime = "";//插入元任务的结束时间
            List<int> OriTFID = new List<int>(SureSub);//每一个元任务的源任务fid 
            //List<double> OriTArea = new List<double>();
            int intterOriTfid = 0;//插入元任务的源任务fid
            double intterOriTArea = 0;//插入元任务的面积
            for (int ti = 0; ti < lstTaskFC.Count; ti++)
            {
                for (int j = 0; j < SureSub.Count; j++)
                {
                    if (lstTaskFC[ti].subTFID == SureSub[j].ToString())
                    {
                        OriTFID[j] = int.Parse(lstTaskFC[ti].TFID);
                        eleTArea[j] = lstTaskFC[ti].subTArea;
                        if (j == 0)//只需获取第一个元任务的开始时间
                        {
                            IFeature OriTFeature = ptaskFeatureLayer.FeatureClass.GetFeature(OriTFID[j]);//获取元任务所属源任务要素 为了获取时间窗口
                            TStartTime = OriTFeature.get_Value(4).ToString();//开始时间 
                        }
                    }
                    if (lstTaskFC[ti].subTFID == interSub.ToString())
                    {
                        intterOriTfid = int.Parse(lstTaskFC[ti].TFID);
                        intterOriTArea = lstTaskFC[ti].subTArea;
                        IFeature OriTFeature = ptaskFeatureLayer.FeatureClass.GetFeature(intterOriTfid);//获取元任务所属源任务要素 为了获取时间窗口
                        TEndTime = OriTFeature.get_Value(5).ToString();//结束时间
                    }
                }
            }
            double statT = 0;//获取第一个元任务的开始观测时间 小时
            double endT = 0;//获取插入任务的结束观测时间 小时
            #region 确定时间
            int flaghour;
            if (TStartTime.Length > 3)
            {
                flaghour = int.Parse(TStartTime.Substring(0, 2));//任务开始时间 小时                 
            }
            else
            {
                flaghour = int.Parse(TStartTime.Substring(0, 1));//任务开始时间 小时
            }
            int flagmin = int.Parse(TStartTime.Substring(TStartTime.Length - 2, 2));//任务开始时间 分钟 
            statT = flaghour + (double)flagmin / 60;

            int interETHour;
            int interETMin;
            if (TEndTime.Length > 3)
            {
                interETHour = int.Parse(TEndTime.Substring(0, 2));//任务结束时间 小时                 
            }
            else
            {
                interETHour = int.Parse(TEndTime.Substring(0, 1));//任务结束时间 小时
            }
            interETMin = int.Parse(TEndTime.Substring(TEndTime.Length - 2, 2));//任务结束时间 分钟 
            endT = interETHour + (double)interETMin / 60;
            #endregion

            //根据元任务与资源观测任务的面积比值确定元任务持续观测时间
            List<double> ContiTime = new List<double>();//任务持续时间
            double interTConTime = 0;//插入任务持续时间
            for (int i = 0; i < lstFC.Count; i++)
            {
                for (int j = 0; j < OriTFID.Count; j++)
                {
                    if (lstFC[i].ASFID == ASFid.ToString() && lstFC[i].TFID == OriTFID[j].ToString()) //如果资源和源任务都匹配 那么元任务属于此子任务
                    {
                        ContiTime.Add(eleTArea[j] / lstFC[i].areaT * lstFC[i].RtoTtime);  //任务持续时间 小时 
                        break;
                    }
                }
                if (lstFC[i].ASFID == ASFid.ToString() && lstFC[i].TFID == intterOriTfid.ToString()) //如果资源和源任务都匹配 那么元任务属于此子任务
                {
                    interTConTime = intterOriTArea / lstFC[i].areaT * lstFC[i].RtoTtime;
                }
            }

            //通过点坐标确定距离
            IFeature ASFea = ASFeaturelayer.FeatureClass.GetFeature(ASFid);//当前飞艇（获取属性）
            double Vas = double.Parse(ASFea.get_Value(5).ToString()); //飞艇速度 km/h
            IPoint AStoPoint = ASFea.Shape as IPoint;//将当前AS转成的点目标
            double Distance = 0;//元任务点之间距离之和
            double InterDis;//最后一个点到插入点的距离
            for (int i = 0; i < SureSub.Count; i++)
            {
                IPoint EleTPoint = EleTPointFL.FeatureClass.GetFeature(SureSub[i]).Shape as IPoint;//获取元任务要素（点目标）
                if (i == 0)
                {
                    Distance = Distance + Math.Sqrt(Math.Pow(EleTPoint.X - AStoPoint.X, 2) + Math.Pow(EleTPoint.Y - AStoPoint.Y, 2));//飞艇起飞点到第一个元任务的质心距离 米
                }
                else
                {
                    IPoint EleFlagTPoint = EleTPointFL.FeatureClass.GetFeature(SureSub[i - 1]).Shape as IPoint;//获取前一个元任务要素（点目标）
                    Distance = Distance + Math.Sqrt(Math.Pow(EleTPoint.X - EleFlagTPoint.X, 2) + Math.Pow(EleTPoint.Y - EleFlagTPoint.Y, 2));
                }
            }
            IPoint LastEleTPoint = EleTPointFL.FeatureClass.GetFeature(SureSub[SureSub.Count - 1]).Shape as IPoint;//获取最后一个元任务要素（点目标）
            IPoint InterEleTPoint = EleTPointFL.FeatureClass.GetFeature(interSub).Shape as IPoint;//插入元任务 点
            InterDis = Math.Sqrt(Math.Pow(LastEleTPoint.X - InterEleTPoint.X, 2) + Math.Pow(LastEleTPoint.Y - InterEleTPoint.Y, 2));
            Distance = Distance + InterDis;
            //最终判断
            for (int k = 0; k < ContiTime.Count; k++)
            {
                interTConTime = interTConTime + ContiTime[k];//所有任务持续时间之和
            }

            double RoadTime = Distance / 1000 / Vas;//路径飞行花费时间 小时
            bool InterBool = (statT + RoadTime + interTConTime) < endT;//观测时间在约束时间之内 可以插入
            return InterBool;

        }
        /// <summary>
        /// 判断此car是否可以观测当前子任务  默认按照列表顺序观测元任务
        /// </summary>
        /// <param name="SureSub">已确定观测的子任务集合</param>
        /// <param name="interSub">需要判断是否能观测的当前子任务</param>
        /// <param name="CarFid">当前carfid</param>
        /// <param name="ptaskFeatureLayer">面状任务图层</param>
        /// <param name="lstTaskFC"></param>
        /// <param name="lstFC"></param>
        /// <param name="EleTPointFL"></param>
        /// <param name="CarFeaturelayer"></param>
        /// <returns></returns>
        public static bool CartoSubT(List<int> SureSub, int interSub, int CarFid, IFeatureLayer ptaskFeatureLayer, List<RTsubTInfo> lstTaskFC, List<RTFeatureInfo> lstFC, IFeatureLayer EleTPointFL, IFeatureLayer CarFeaturelayer)
        {
            SureSub.Sort();//排序 从小到大

            double[] eleTArea = new double[SureSub.Count];//每一个元任务的面积 为了获取持续观测时间
            string TStartTime = "";//第一个元任务的开始时间
            string TEndTime = "";//插入元任务的结束时间
            List<int> OriTFID = new List<int>(SureSub);//每一个元任务的源任务fid 
            //List<double> OriTArea = new List<double>();
            int intterOriTfid = 0;//插入元任务的源任务fid
            double intterOriTArea = 0;//插入元任务的面积
            for (int ti = 0; ti < lstTaskFC.Count; ti++)
            {
                for (int j = 0; j < SureSub.Count; j++)
                {
                    if (lstTaskFC[ti].subTFID == SureSub[j].ToString())
                    {
                        OriTFID[j] = int.Parse(lstTaskFC[ti].TFID);
                        eleTArea[j] = lstTaskFC[ti].subTArea;
                        TStartTime = lstTaskFC[ti].subTWinS;
                        //if (j == 0)//只需获取第一个元任务的开始时间
                        //{
                        //IFeature OriTFeature = ptaskFeatureLayer.FeatureClass.GetFeature(OriTFID[j]);//获取元任务所属源任务要素 为了获取时间窗口
                        //    TStartTime = OriTFeature.get_Value(4).ToString();//开始时间 
                        //}
                    }
                    if (lstTaskFC[ti].subTFID == interSub.ToString())
                    {
                        intterOriTfid = int.Parse(lstTaskFC[ti].TFID);
                        intterOriTArea = lstTaskFC[ti].subTArea;
                        TEndTime = lstTaskFC[ti].subTWinE;
                        //IFeature OriTFeature = ptaskFeatureLayer.FeatureClass.GetFeature(intterOriTfid);//获取元任务所属源任务要素 为了获取时间窗口
                        //TEndTime = OriTFeature.get_Value(5).ToString();//结束时间
                    }
                }
            }
            double statT = 0;//获取第一个元任务的开始观测时间 小时
            double endT = 0;//获取插入任务的结束观测时间 小时
            #region 确定时间
            int flaghour;
            if (TStartTime.Length > 3)
            {
                flaghour = int.Parse(TStartTime.Substring(0, 2));//任务开始时间 小时                 
            }
            else
            {
                flaghour = int.Parse(TStartTime.Substring(0, 1));//任务开始时间 小时
            }
            int flagmin = int.Parse(TStartTime.Substring(TStartTime.Length - 2, 2));//任务开始时间 分钟 
            statT = flaghour + (double)flagmin / 60;

            int interETHour;
            int interETMin;
            if (TEndTime.Length > 3)
            {
                interETHour = int.Parse(TEndTime.Substring(0, 2));//任务结束时间 小时                 
            }
            else
            {
                interETHour = int.Parse(TEndTime.Substring(0, 1));//任务结束时间 小时
            }
            interETMin = int.Parse(TEndTime.Substring(TEndTime.Length - 2, 2));//任务结束时间 分钟 
            endT = interETHour + (double)interETMin / 60;
            #endregion

            //根据元任务与资源观测任务的面积比值确定元任务持续观测时间
            List<double> ContiTime = new List<double>();//任务持续时间
            double interTConTime = 0;//插入任务持续时间
            for (int i = 0; i < lstFC.Count; i++)
            {
                for (int j = 0; j < OriTFID.Count; j++)
                {
                    if (lstFC[i].CarFID == CarFid.ToString() && lstFC[i].TFID == OriTFID[j].ToString()) //如果资源和源任务都匹配 那么元任务属于此子任务
                    {
                        ContiTime.Add(eleTArea[j] / lstFC[i].areaT * lstFC[i].RtoTtime);  //任务持续时间 小时 
                        break;
                    }
                }
                if (lstFC[i].CarFID == CarFid.ToString() && lstFC[i].TFID == intterOriTfid.ToString()) //如果资源和源任务都匹配 那么元任务属于此子任务
                {
                    interTConTime = intterOriTArea / lstFC[i].areaT * lstFC[i].RtoTtime;
                }
            }



            //通过点坐标确定距离
            IFeature CarFea = CarFeaturelayer.FeatureClass.GetFeature(CarFid);//当前car（获取属性）
            double Vcar = double.Parse(CarFea.get_Value(5).ToString()); //飞艇速度 km/h
            double Milecar = double.Parse(CarFea.get_Value(7).ToString()); //飞艇速度 km/h
            IPoint CartoPoint = CarFea.Shape as IPoint;//将当前car转成的点目标
            double Distance = 0;//元任务点之间距离之和
            double InterDis;//最后一个点到插入点的距离
            #region 距离计算
            //IPoint CartoPoint = CarFea.Shape as IPoint;//将当前车转成的点目标
            #region 网络设置
            //几何网络
            IGeometricNetwork mGeometricNetwork;

            //获取给定点最近的Network元素
            IPointToEID mPointToEID = new PointToEIDClass();
            //获取几何网络文件路径
            //注意修改此路径为当前存储路径
            string strPath = System.AppDomain.CurrentDomain.BaseDirectory + "Data\\RoadData.gdb";//+"E:\GIS设计与开发\例子数据\Network\USA_Highway_Network_GDB.mdb";
            //打开工作空间
            IWorkspaceFactory pWorkspaceFactory = new ESRI.ArcGIS.DataSourcesGDB.FileGDBWorkspaceFactory();
            IFeatureWorkspace pFeatureWorkspace = pWorkspaceFactory.OpenFromFile(strPath, 0) as IFeatureWorkspace;
            //获取要素数据集
            //注意名称的设置要与上面创建保持一致
            IFeatureDataset pFeatureDataset = pFeatureWorkspace.OpenFeatureDataset("RaadDataSet");//修改成从xml读取

            //获取network集合
            INetworkCollection pNetWorkCollection = pFeatureDataset as INetworkCollection;
            //获取network的数量,为零时返回
            int intNetworkCount = pNetWorkCollection.GeometricNetworkCount;
            if (intNetworkCount < 1)
            { MessageBox.Show("要素类数量为0！"); }
            //FeatureDataset可能包含多个network，我们获取指定的network
            //注意network的名称的设置要与上面创建保持一致
            mGeometricNetwork = pNetWorkCollection.get_GeometricNetworkByName("RaadDataSet_Net");//修改成从xml读取
            //设置mPointToEID属性
            mPointToEID.SourceMap = Program.myMap.Map;
            mPointToEID.GeometricNetwork = mGeometricNetwork;
            mPointToEID.SnapTolerance = 200000; //捕捉容差 2000m？ 
            #endregion
            #region 已有任务间距离和 米

            for (int i = 0; i < SureSub.Count; i++)
            {
                IPoint EleTPoint = EleTPointFL.FeatureClass.GetFeature(SureSub[i]).Shape as IPoint;//获取元任务要素（点目标）
                if (i == 0)
                {
                    IPointCollection mPointCollection = new MultipointClass();//给定点的集合
                    mPointCollection.AddPoint(CartoPoint);
                    mPointCollection.AddPoint(EleTPoint);

                    //路径计算
                    IEnumNetEID mEnumNetEID_Junctions;//返回路径的节点
                    IEnumNetEID mEnumNetEID_Edges;//返回路径边
                    double mdblPathCost;//返回总代价（边长 距离）
                    CoScheduling.Core.Map.MapHelper MapHelp = new Core.Map.MapHelper();
                    MapHelp.SolvePath("weight", mGeometricNetwork, mPointCollection, mPointToEID, out  mEnumNetEID_Junctions, out  mEnumNetEID_Edges, out   mdblPathCost);
                    IPolyline ResultLine = MapHelp.PathToPolyLine(Program.myMap.Map, mGeometricNetwork, mEnumNetEID_Edges);//将路径结果转为线
                    Distance = Distance + ResultLine.Length;//两冲突任务的质心距离 米 

                    //Distance = Distance + Math.Sqrt(Math.Pow(EleTPoint.X - cartoPoint.X, 2) + Math.Pow(EleTPoint.Y - cartoPoint.Y, 2));//飞艇起飞点到第一个元任务的质心距离 米
                }
                else
                {
                    IPoint EleFlagTPoint = EleTPointFL.FeatureClass.GetFeature(SureSub[i - 1]).Shape as IPoint;//获取前一个元任务要素（点目标）

                    IPointCollection mPointCollection = new MultipointClass();//给定点的集合
                    mPointCollection.AddPoint(EleFlagTPoint);
                    mPointCollection.AddPoint(EleTPoint);

                    //路径计算
                    IEnumNetEID mEnumNetEID_Junctions;//返回路径的节点
                    IEnumNetEID mEnumNetEID_Edges;//返回路径边
                    double mdblPathCost;//返回总代价（边长 距离）
                    CoScheduling.Core.Map.MapHelper MapHelp = new Core.Map.MapHelper();
                    MapHelp.SolvePath("weight", mGeometricNetwork, mPointCollection, mPointToEID, out  mEnumNetEID_Junctions, out  mEnumNetEID_Edges, out   mdblPathCost);
                    IPolyline ResultLine = MapHelp.PathToPolyLine(Program.myMap.Map, mGeometricNetwork, mEnumNetEID_Edges);//将路径结果转为线
                    Distance = Distance + ResultLine.Length;//两冲突任务的质心距离 米 


                    //Distance = Distance + Math.Sqrt(Math.Pow(EleTPoint.X - EleFlagTPoint.X, 2) + Math.Pow(EleTPoint.Y - EleFlagTPoint.Y, 2));
                }
            }




            #endregion


            #endregion


            #region 最后一个点到插入点的距离
            IPoint LastEleTPoint = EleTPointFL.FeatureClass.GetFeature(SureSub[SureSub.Count - 1]).Shape as IPoint;//获取最后一个元任务要素（点目标）
            IPoint InterEleTPoint = EleTPointFL.FeatureClass.GetFeature(interSub).Shape as IPoint;//插入元任务 点

            IPointCollection PointCollection = new MultipointClass();//给定点的集合
            PointCollection.AddPoint(LastEleTPoint);
            PointCollection.AddPoint(InterEleTPoint);
            //路径计算
            IEnumNetEID EnumNetEID_Junctions;//返回路径的节点
            IEnumNetEID EnumNetEID_Edges;//返回路径边
            double dblPathCost;//返回总代价（边长 距离）
            CoScheduling.Core.Map.MapHelper MapHelpclass = new Core.Map.MapHelper();
            MapHelpclass.SolvePath("weight", mGeometricNetwork, PointCollection, mPointToEID, out  EnumNetEID_Junctions, out  EnumNetEID_Edges, out   dblPathCost);
            IPolyline ResultLineL = MapHelpclass.PathToPolyLine(Program.myMap.Map, mGeometricNetwork, EnumNetEID_Edges);//将路径结果转为线
            InterDis = ResultLineL.Length;
            #endregion


            Distance = Distance + InterDis;
            if (Distance > Milecar * 1000)
                return false;//里程约束
            else
            {
                for (int k = 0; k < ContiTime.Count; k++)
                {
                    interTConTime = interTConTime + ContiTime[k];//所有任务持续时间之和
                }

                double RoadTime = Distance / 1000 / Vcar;//路径飞行花费时间 小时
                bool InterBool = (statT + RoadTime + interTConTime) < endT;//观测时间在约束时间之内 可以插入
                return InterBool;
            }
            //最终判断


        }
        /// <summary>
        /// 根据面积多次逼近观测半径 
        /// </summary>
        /// <param name="UavPointFL">单个资源点</param>
        /// <param name="TaskAreaFL">单个任务区域</param>
        /// <param name="TaskArea">面积</param>
        /// <param name="mileage">最大半径*2</param>
        /// <returns></returns>
        public static double AreaToRadius(IFeatureLayer UavPointFL, IFeatureLayer TaskAreaFL, double TaskArea, double maxRad)
        {
            try
            {
                double Radius;//最终的半径
                double Maxd = maxRad;
                double Mind;//无人机位置到任务的最近距离
                double sth = TaskArea * 0.001;//面积阈值 定义？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？

                //IFeatureLayer UavPointFL = OpenFile_LayerFile(UavPointPath);
                IFeatureLayer RadBFfeature;//缓冲区要素图层
                IFeatureLayer InterSelefeature;//交集要素图层
                string BFpath;//缓冲区图层存储路径
                string IntersPath;//交集图层存储路径
                IPolygon InterSelefePolygon;//交集区域转为面
                IArea Uarea;//交集区域转为Iarea
                int k = 1;//迭代次数
                //GPNearTool(UavPointFL, TaskAreaFL);//GP工具求点到面最近距离 生成表中一个字段  多次循环会删除么？？？？？？？？
                ////IFeature UavPfe = UavPointFL.FeatureClass.GetFeature(0);//转成一个要素
                //IFeature UavPfe = UavPointFL.FeatureClass.GetFeature(0);//转成一个要素
                //Mind = double.Parse(UavPfe.get_Value(UavPfe.Fields.FieldCount - 1).ToString());

                Mind = MinDis(UavPointFL, TaskAreaFL);
                if (Mind < 0)
                {
                }
                if (Mind > Maxd)
                {
                    Radius = 0;
                    return Radius;
                }

                BFpath = System.AppDomain.CurrentDomain.BaseDirectory + "Data\\cache\\" + "RadBF.shp";
                IntersPath = System.AppDomain.CurrentDomain.BaseDirectory + "Data\\cache\\" + "interP.shp";
                do
                {

                    Radius = (Maxd + Mind) / 2;

                    GPBufferTool((ILayer)UavPointFL, BFpath, Radius.ToString());
                    RadBFfeature = OpenFile_LayerFile(BFpath);

                    GPIntersectTool(RadBFfeature.FeatureClass, TaskAreaFL.FeatureClass, IntersPath);
                    InterSelefeature = OpenFile_LayerFile(IntersPath);

                    InterSelefePolygon = InterSelefeature.FeatureClass.GetFeature(0).Shape as IPolygon;
                    Uarea = InterSelefePolygon as IArea;
                    if (Uarea.Area > TaskArea)
                    {
                        Maxd = Radius;
                    }
                    else
                    {
                        Mind = Radius;
                    }
                    k++;
                } while ((Uarea.Area > TaskArea + sth || Uarea.Area < TaskArea - sth) && k < 20);

                //Radius = TaskArea;
                return Radius;
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误：" + ex.Message);
                return -1;
            }
        }
        /// <summary>
        /// 最近距离
        /// </summary>
        /// <param name="InputFeature"></param>
        /// <param name="NearFeature"></param>
        /// <returns></returns>
        private static double MinDis(IFeatureLayer InputFeature, IFeatureLayer NearFeature)
        {
            IGeometry InputGeo = InputFeature.FeatureClass.GetFeature(0).Shape;
            IGeometry NearGeo = NearFeature.FeatureClass.GetFeature(0).Shape;
            IProximityOperator pProOperator = InputGeo as IProximityOperator;
            double mindis = pProOperator.ReturnDistance(NearGeo);
            return mindis;
        }



        #endregion

        #endregion

        #region 规划结果显示
        // 分配到子规划中心结果读取 从matlab
        public static void PlanAllocation(string ElemetTPath)
        {

            subPlanAllocation subPlanAlloc = new subPlanAllocation();//存储从CSV中读取的规划方案
            string UAVpath = System.AppDomain.CurrentDomain.BaseDirectory + "Data\\" + "UAVBai.shp";//无人机路径 （为了获取资源个数）
            string ASpath = System.AppDomain.CurrentDomain.BaseDirectory + "Data\\" + "AirShipBai.shp";
            string Carpath = System.AppDomain.CurrentDomain.BaseDirectory + "Data\\" + "CarBai.shp";
            string Satpath = System.AppDomain.CurrentDomain.BaseDirectory + "Data\\" + "SatAttr.shp";
            IFeatureLayer Uavfl = OpenFile_LayerFile(UAVpath);
            IFeatureLayer ASfl = OpenFile_LayerFile(ASpath);
            IFeatureLayer Carfl = OpenFile_LayerFile(Carpath);
            IFeatureLayer Satfl = OpenFile_LayerFile(Satpath);
            int uavNO = Uavfl.FeatureClass.FeatureCount(null);//无人机个数
            int asNO = ASfl.FeatureClass.FeatureCount(null);
            int CarNO = Carfl.FeatureClass.FeatureCount(null);
            int satNO = Satfl.FeatureClass.FeatureCount(null);
            //读取元任务
            string ElementTpath = System.AppDomain.CurrentDomain.BaseDirectory + ElemetTPath;// "Data\\cache\\" + "UToTaUni.shp";
            int EleTNO = 0;
            if (File.Exists(ElementTpath))//判断文件是否存在
            {
                IFeatureLayer ElementTFeatureLayer = OpenFile_LayerFile(ElementTpath);
                EleTNO = ElementTFeatureLayer.FeatureClass.FeatureCount(null);//元任务个数
                //属性表添加字段
                //定义新字段
                IField pField = new FieldClass();
                //字段编辑
                IFieldEdit pFieldEdit = pField as IFieldEdit;
                //新建字段名
                pFieldEdit.Name_2 = "PlanAll";
                pFieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
                ElementTFeatureLayer.FeatureClass.AddField(pField);//添加字段


                OpenFileDialog op = new OpenFileDialog();//实例化打开对画框。  
                if (op.ShowDialog() == DialogResult.OK)//选择的文件名有效  
                {
                    //创建一个文件流  
                    System.IO.FileStream fs = new System.IO.FileStream(op.FileName, FileMode.Open, FileAccess.Read, FileShare.None);
                    //创建读这个流的对象，第一个参数是文件流，第二个参数是编码（其实里面的值是多少对我们这个读没有什么问题）  
                    StreamReader sr = new StreamReader(fs, System.Text.Encoding.GetEncoding(936));
                    #region 输出UAV 和AS观测任务标准差
                    //double[] UavResouce = new double[uavNO];//能观测的元任务面积和 行表示无人机资源序号  
                    //double[] AsResouce = new double[asNO];//能观测的元任务面积和 行表示无人机资源序号 
                    #endregion
                    int FinishT = 0;//完成元任务个数
                    string str = "";
                    int Rno = 1;//计数 第一行：UAV 第二行：AS 第三行：Sat
                    while (str != null)
                    {
                        str = sr.ReadLine();//读取一行  
                        if (str == null) break;//读完了就跳出循环  

                        String[] eachLine = new String[EleTNO];//每一行excel单元格数 
                        eachLine = str.Split(',');//因为.csv文件是以逗号分隔单元格里数据的，所以调用分隔函数split 
                        for (int i = 0; i < EleTNO; i++)
                        {
                            int boolAll;
                            if (eachLine[i] == "1")
                            {
                                boolAll = 1;
                                FinishT = FinishT + 1;
                            }
                            else
                            {
                                boolAll = 0;
                            }
                            //int boolAll = int.Parse(eachLine[i]);//是否分配
                            if (Rno <= uavNO && boolAll == 1)//无人机
                            {

                                IFeature pfeature = ElementTFeatureLayer.FeatureClass.GetFeature(i);//获取当前元任务要素
                                #region 获取每个资源观测元任务的总面积
                                //IPolygon EleT = pfeature.Shape as IPolygon;
                                //IArea Uarea = EleT as IArea;
                                //UavResouce[Rno - 1] = UavResouce[Rno - 1] + Uarea.Area;
                                #endregion
                                pfeature.set_Value(ElementTFeatureLayer.FeatureClass.Fields.FindField("PlanAll"), "Uav" + (Rno - 1).ToString());//设值
                                pfeature.Store();
                            }
                            else if (Rno <= (uavNO + asNO) && boolAll == 1)//AS
                            {
                                IFeature pfeature = ElementTFeatureLayer.FeatureClass.GetFeature(i);//获取当前元任务要素
                                #region 获取每个资源观测元任务的总面积
                                //IPolygon EleT = pfeature.Shape as IPolygon;
                                //IArea Aarea = EleT as IArea;
                                //AsResouce[Rno - uavNO - 1] = AsResouce[Rno - uavNO - 1] + Aarea.Area;
                                #endregion
                                pfeature.set_Value(ElementTFeatureLayer.FeatureClass.Fields.FindField("PlanAll"), "AS" + (Rno - uavNO - 1).ToString());//设值
                                pfeature.Store();
                            }
                            else if (Rno <= (uavNO + asNO+CarNO) && boolAll == 1)//car
                            {
                                IFeature pfeature = ElementTFeatureLayer.FeatureClass.GetFeature(i);//获取当前元任务要素

                                pfeature.set_Value(ElementTFeatureLayer.FeatureClass.Fields.FindField("PlanAll"), "Car" + (Rno - uavNO - asNO - 1).ToString());//设值
                                pfeature.Store();
                            }
                            else if (boolAll == 1)//Sat
                            {
                                IFeature pfeature = ElementTFeatureLayer.FeatureClass.GetFeature(i);//获取当前元任务要素
                                pfeature.set_Value(ElementTFeatureLayer.FeatureClass.Fields.FindField("PlanAll"), "Sat" + (Rno - uavNO - asNO - CarNO - 1).ToString());//设值
                                pfeature.Store();
                            }
                        }

                        Rno++;
                    }
                    sr.Close();
                    fs.Close();
                    //double stdDevUav = CalculateStdDev(UavResouce);
                    //double stdDevAs = CalculateStdDev(AsResouce);
                    //MessageBox.Show("Uav标准差：" + stdDevUav + "\r\n" + "AS标准差：" + stdDevAs + "\r\n" + "平均标准差：" + (stdDevUav + stdDevAs) / 2);
                    MessageBox.Show("完成元任务个数：" + FinishT + "/" + EleTNO);
                }//选择的文件名有效 

            }
            else
            { }



        }

        #endregion

        #endregion

        #region 注释代码 可参考

        ///// <summary>
        ///// 解码——事件类型
        ///// </summary>
        ///// <returns></returns>
        //public static string TransCode(string TypeID)
        //{
        //    string type = "";
        //    //交通事件
        //    if (TypeID == "10001") type = "地震损害";
        //    else if (TypeID == "10002") type = "滑坡";
        //    else if (TypeID == "10003") type = "泥石流";
        //    else if (TypeID == "10004") type = "地面塌陷";
        //    else if (TypeID == "10005") type = "暴雨洪水";
        //    else if (TypeID == "10006") type = "强风";
        //    else if (TypeID == "10007") type = "路面结冰";
        //    else if (TypeID == "10008") type = "落石";
        //    else if (TypeID == "10009") type = "雾霾天气";
        //    else if (TypeID == "10010") type = "沙尘暴";
        //    else if (TypeID == "10011") type = "冰雹";
        //    else if (TypeID == "10012") type = "龙卷风";
        //    else if (TypeID == "10013") type = "水石流";
        //    else if (TypeID == "11001") type = "运输车致命故障";
        //    else if (TypeID == "11002") type = "运输车严重故障";
        //    else if (TypeID == "11003") type = "运输车一般故障";
        //    else if (TypeID == "11004") type = "运输车轻微故障";
        //    else if (TypeID == "12001") type = "轻微交通事故";
        //    else if (TypeID == "12002") type = "一般交通事故";
        //    else if (TypeID == "12003") type = "重大交通事故";
        //    else if (TypeID == "12004") type = "特大交通事故";
        //    else if (TypeID == "12005") type = "交通拥堵";
        //    //无人机监测事件
        //    else if (TypeID == "20001") type = "无人机损坏";
        //    else if (TypeID == "20002") type = "燃料用完";
        //    else if (TypeID == "20003") type = "数据接收器损坏";
        //    else if (TypeID == "20004") type = "软件故障";
        //    else if (TypeID == "20005") type = "测量数据无效";
        //    else if (TypeID == "20006") type = "突然熄火";
        //    else if (TypeID == "20007") type = "相机拍摄故障";
        //    else if (TypeID == "20008") type = "电池电量不足";
        //    //签到
        //    else if (TypeID == "30001") type = "无人机登陆";
        //    else if (TypeID == "30002") type = "到达目的地";
        //    else if (TypeID == "30003") type = "完成任务";

        //    //事故处理
        //    else if (TypeID == "50001") type = "事故处理完成";
        //    return type;
        //}

        ///// <summary>
        ///// 是否已查看交通上报事件
        ///// </summary>
        //public static int isCheckedRoadAcc()
        //{
        //    try
        //    {
        //        Core.DAL.UAVRoadAcc roadAcc = new Core.DAL.UAVRoadAcc();
        //        int isCheckedRoadAcc = roadAcc.isCheckedRoadAcc(CurrentDisaAreaID);
        //        return isCheckedRoadAcc;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("错误：" + ex.Message);
        //        return -1;
        //    }
        //}

        ///// <summary>
        ///// 是否已查看无人机监测事件
        ///// </summary>
        //public static int isCheckedUAVState()
        //{
        //    try
        //    {
        //        Core.DAL.UAVTaskState dal = new Core.DAL.UAVTaskState();
        //        int isCheckedUAVState = dal.isCheckedUAVState();
        //        return isCheckedUAVState;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("错误：" + ex.Message);
        //        return -1;
        //    }
        //}

        ///// <summary>
        ///// 查看无人机签到；0--没有未查看信息；n--n条信息未查看；-1--没有上报信息；
        ///// </summary>
        //public static int isCheckedSign()
        //{
        //    try
        //    {
        //        Core.DAL.UAVSignIn dal = new Core.DAL.UAVSignIn();
        //        List<Core.Model.UAVSignIn> lst = new List<Core.Model.UAVSignIn>();
        //        lst = dal.NotCheckedSignList(CurrentDisaAreaID);
        //        int isCheckedSign = lst.Count;
        //        return isCheckedSign;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("错误：" + ex.Message);
        //        return -1;
        //    }
        //}



        ///// <summary>
        ///// 生成规划
        ///// </summary>
        //public static void Planning()
        //{
        //    try
        //    {
        //        if (IsDisaModified)
        //        {
        //            MessageBox.Show("灾区修改，请先重新调度！", "提示");
        //            return;
        //        }
        //        Core.DAL.ScheduleResult dal_schedule = new Core.DAL.ScheduleResult();
        //        if (!dal_schedule.ExistsResult(CurrentDisaAreaID))
        //        {
        //            MessageBox.Show("请先调度无人机编队！");
        //            return;
        //        }
        //        //选择要保存的目标文件夹
        //        SaveFileDialog saveFileDialog1 = new SaveFileDialog();
        //        saveFileDialog1.Title = "保存为";
        //        saveFileDialog1.Filter = "文本文件(*.docx)|*.docx;";
        //        saveFileDialog1.RestoreDirectory = true;
        //        saveFileDialog1.FileName = "任务规划方案";
        //        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
        //        {
        //            //记录选中的目录  
        //            defaultfilePath = saveFileDialog1.FileName;
        //            if (CurrentDisaAreaID == -1)
        //            {
        //                MessageBox.Show("未选中灾区！", "提示");
        //                return;
        //            }
        //            else
        //                MonitorTask.TaskHelper.LoadTaskAreas(Program.myMap, CurrentDisaAreaID);//加载灾区
        //            Program.SetStatusLabel("开始执行任务规划...");

        //            doPlan();//自由规划

        //            //把PlanString存入数据库
        //            Core.DAL.PlanString dal_pStr = new Core.DAL.PlanString();
        //            Core.Model.PlanString mod_pStr = new Core.Model.PlanString();
        //            mod_pStr.PID = CurrentDisaAreaID;
        //            mod_pStr.PlanedString = PlanString;
        //            if (dal_pStr.ExistsPID(CurrentDisaAreaID))
        //            {
        //                mod_pStr.ID = dal_pStr.GetID(CurrentDisaAreaID);
        //                dal_pStr.Update(mod_pStr);
        //            }
        //            else
        //                dal_pStr.Add(mod_pStr);

        //            Task.WordHelper report = new Task.WordHelper();
        //            report.CreateNewDocument(System.Windows.Forms.Application.StartupPath + "\\Report\\任务规划方案模板.docx"); //模板路径 
        //            //  report.CreateNewDocument("C:/Users/Administrator/Desktop/任务规划方案模板.docx");
        //            string[] Arrstr = PlanString.Split('$');//单个编队和任务区信息
        //            int tableResaultNum = 1;//表格行数计数
        //            Core.DAL.DisaAreaInfo dal = new Core.DAL.DisaAreaInfo();///用于显示信息
        //            Core.Model.DisaAreaInfo model = new Core.Model.DisaAreaInfo();
        //            model = dal.GetModel(CurrentDisaAreaID);
        //            report.InsertText2("type", model.County + model.Name);//灾区名字
        //            int Mint = 0;//合并表格

        //            //把规划信息存入数据库
        //            Core.Model.PlanResult mod_result = new Core.Model.PlanResult();
        //            Core.DAL.PlanResult dal_result = new Core.DAL.PlanResult();
        //            dal_result.DeleteAll(CurrentDisaAreaID);//删除以前的数据
        //            for (int Uaint = 0; Uaint < Arrstr.Length; Uaint++)
        //            {
        //                int PD = 1;//判断字符串
        //                string[] UAVStr = Arrstr[Uaint].Split('|');//无人机编队
        //                string[] Tstrs = UAVStr[1].Split('@');//任务区
        //                int rows = Tstrs.Length;
        //                for (int i = 0; i < rows - 1; i++)
        //                {
        //                    //规划结果存入数据库
        //                    mod_result = new Core.Model.PlanResult();
        //                    mod_result.UAVID = Convert.ToInt32(UAVStr[0].Split(',')[2]);
        //                    mod_result.UAVName = UAVStr[0].Split(',')[0];
        //                    mod_result.TotalCost = UAVStr[0].Split(',')[1];
        //                    mod_result.TID = Convert.ToInt32(Tstrs[i].Split(',')[5]);
        //                    mod_result.TName = Tstrs[i].Split(',')[0];
        //                    mod_result.TLON = Convert.ToDouble(Tstrs[i].Split(',')[1]);
        //                    mod_result.TLAT = Convert.ToDouble(Tstrs[i].Split(',')[2]);
        //                    mod_result.TCost = Tstrs[i].Split(',')[3];
        //                    mod_result.FCost = Tstrs[i].Split(',')[4];
        //                    mod_result.PID = CurrentDisaAreaID;
        //                    //mod_result.GID = Convert.ToInt32(UAVStr[0].Split(',')[3]);
        //                    dal_result.Add(mod_result);

        //                    tableResaultNum++;
        //                    report.AddRow(1, 1);
        //                    string[] resault = new string[6];
        //                    if (PD > 0)
        //                    {
        //                        resault[0] = UAVStr[0].Split(',')[0];//编队名称
        //                        resault[1] = UAVStr[0].Split(',')[1];//执行总时间
        //                        PD = -1;
        //                        Mint = tableResaultNum;
        //                    }
        //                    else
        //                    {
        //                        resault[0] = "";
        //                        resault[1] = "";
        //                    }
        //                    resault[2] = Tstrs[i].Split(',')[0];
        //                    resault[3] = Convert.ToDouble(Tstrs[i].Split(',')[1]).ToString("0.0000") + "\n" + Convert.ToDouble(Tstrs[i].Split(',')[2]).ToString("0.0000");
        //                    resault[4] = Tstrs[i].Split(',')[3];
        //                    resault[5] = Tstrs[i].Split(',')[4];
        //                    report.InsertCell(1, tableResaultNum, 6, resault);

        //                }
        //                if (rows > 2)
        //                {
        //                    report.MergeCellS(1, Mint, 1, tableResaultNum, 1);
        //                    report.MergeCellS(1, Mint, 2, tableResaultNum, 2);
        //                    report.SetTableFormat(1, 0, 0);
        //                }

        //            }

        //            string path = defaultfilePath;
        //            try
        //            {
        //                report.SaveDocument(path);
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show("错误:【任务规划方案】已在其他地方打开，请关闭后重试！", "提示");
        //                return;
        //            }
        //            Main.Map.MapHelper.ClearAllElement();//清除所有的元素
        //            MonitorTask.TaskHelper.LoadTaskAreas(Program.myMap, MainInterface.CurrentDisaAreaID);//重新加载任务区
        //            Main.DisaArea.DisaAreaHelper.PositionDisaArea(Program.myMap, MainInterface.CurrentDisaAreaID);//加载灾区
        //            //Main.DisaArea.DisaAreaHelper.PositionGathetPoint(Program.myMap, MainInterface.CurrentDisaAreaID);

        //            #region 绘制任务区

        //            MessageBox.Show("任务规划方案生成成功！");

        //            for (int i = 0; i < XY_Str.Count; i++)
        //            {
        //                string str = XY_Str[i].Split('|')[1];
        //                string[] xy_str = str.Split(';');

        //                //颜色控制——从数据库中读取
        //                List<Core.Model.Color> lst_color = new List<Core.Model.Color>();
        //                Core.DAL.Color dal_color = new Core.DAL.Color();
        //                lst_color = dal_color.GetList();
        //                string cStr = lst_color[i % 10].TColor.Substring(1);
        //                Color Tcolor = Color.FromArgb(int.Parse(cStr, System.Globalization.NumberStyles.HexNumber));

        //                //生成箭头线
        //                for (int j = 1; j < xy_str.Length - 1; j++)
        //                {
        //                    double x1 = Convert.ToDouble(xy_str[j].Split(',')[0]);
        //                    double y1 = Convert.ToDouble(xy_str[j].Split(',')[1]);
        //                    double x2 = Convert.ToDouble(xy_str[j + 1].Split(',')[0]);
        //                    double y2 = Convert.ToDouble(xy_str[j + 1].Split(',')[1]);

        //                    IPoint pPoint1 = new PointClass();
        //                    IPoint pPoint2 = new PointClass();
        //                    pPoint1.PutCoords(x1, y1);
        //                    pPoint2.PutCoords(x2, y2);
        //                    Main.Map.MapHelper.TrackLine(pPoint1, pPoint2, Tcolor);
        //                }

        //                //任务区颜色修改
        //                List<Core.Model.TaskAreas> select_taskarea = new List<Core.Model.TaskAreas>();
        //                int uav_ID = Convert.ToInt32(XY_Str[i].Split('|')[0].Split(',')[1]);

        //                foreach (Core.Model.TaskAreas tarea in taskarea)
        //                {
        //                    if (tarea.UID == uav_ID)
        //                        select_taskarea.Add(tarea);
        //                }

        //                IActiveView pActiveView = Program.myMap.ActiveView;
        //                IGraphicsContainer pGraphicsContainer = pActiveView.GraphicsContainer;
        //                IElement pElement;

        //                Color color = new Color();
        //                IRgbColor pRgbColor = new RgbColor();
        //                pRgbColor.Red = color.R;
        //                pRgbColor.Green = color.G;
        //                pRgbColor.Blue = color.B;
        //                pGraphicsContainer.Reset();//重置指针
        //                pElement = pGraphicsContainer.Next();
        //                while (pElement != null)
        //                {
        //                    IElementProperties pElmentProperties = pElement as IElementProperties;

        //                    if (pElmentProperties.Name.Split('|')[0] == "TaskArea")
        //                    {
        //                        Boolean value = search(select_taskarea, Convert.ToInt32(pElmentProperties.Name.Split('|')[1]));
        //                        if (value)
        //                        {
        //                            Core.Map.MapHelper map = new Core.Map.MapHelper(Program.myMap);
        //                            ISymbol symbol = map.CreateSimpleFillSymbol(Tcolor, 4, esriSimpleFillStyle.esriSFSBackwardDiagonal);
        //                            IFillShapeElement pFillShapeElement = (IFillShapeElement)pElement;
        //                            pFillShapeElement.Symbol = (IFillSymbol)symbol;
        //                            //pFillShapeElement.Symbol.Color = pRgbColor;
        //                            pGraphicsContainer.UpdateElement(pElement);
        //                        }
        //                    }
        //                    pElement = pGraphicsContainer.Next();
        //                }
        //                pActiveView.Refresh();

        //            }
        //            isFinishPlan = 1;//完成了调度规划，开始监测无人机


        //        }
        //            #endregion


        //    }

        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("错误:" + ex.ToString());
        //    }
        //    Program.SetStatusLabel("就绪！");
        //}



        ///// <summary>
        ///// 判断是否包含
        ///// </summary>
        ///// <param name="select_taskarea"></param>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public static Boolean search(List<Core.Model.TaskAreas> select_taskarea, int id)
        //{
        //    foreach (Core.Model.TaskAreas tarea in select_taskarea)
        //    {
        //        if (tarea.ID == id)
        //            return true;
        //    }
        //    return false;
        //}


        ///// <summary>
        ///// 任务规划函数
        ///// </summary>
        //public static void doPlan()
        //{
        //    taskarea = new List<Core.Model.TaskAreas>();
        //    List<Core.Model.UAVBD> uavBD = new List<Core.Model.UAVBD>();//无人机编队
        //    Core.DAL.TaskAreas dal_taskarea = new Core.DAL.TaskAreas();//无人机任务区
        //    Core.DAL.UAVBD dal_uav = new Core.DAL.UAVBD();
        //    UAV.NetWorkHelper helper = new UAV.NetWorkHelper(Program.myMap);
        //    taskarea = dal_taskarea.GetList(CurrentDisaAreaID);//获取当前任务区
        //    //从调度结果中获取受调度无人机
        //    List<Core.Model.ScheduleResult> lst_schedule = new List<Core.Model.ScheduleResult>();
        //    Core.DAL.ScheduleResult dal_schedule = new Core.DAL.ScheduleResult();
        //    lst_schedule = dal_schedule.GetCheckedList(CurrentDisaAreaID);
        //    for (int i = 0; i < lst_schedule.Count; i++)
        //    {
        //        Core.Model.UAVBD model = new Core.Model.UAVBD();
        //        model = dal_uav.GetModel(lst_schedule[i].UID);//无人机
        //        //model.GID = lst_schedule[i].GID;//集结点（需修改--0909YJ）
        //        uavBD.Add(model);
        //    }

        //    double[,] Utraval_cost = new double[uavBD.Count, taskarea.Count];     //无人机到任务区交通时间
        //    //double[,] Gtraval_cost = new double[G_Point.Count, taskarea.Count];  //集结点到任务区交通时间
        //    double[,] Ttraval_cost = new double[taskarea.Count, taskarea.Count];//任务区到任务区交通时间
        //    double[,] flying_cost = new double[uavBD.Count, taskarea.Count];      //无人机执行各任务区航拍的时间
        //    double[,] total_cost = new double[uavBD.Count, taskarea.Count];


        //    double[,] best_cost = new double[uavBD.Count, taskarea.Count];


        //    //分辨率和灾区内驾车时间影响参数可以设置
        //    double Resolution;
        //    double Coefficient;
        //    Core.Generic.myXML xml = new Core.Generic.myXML(System.Windows.Forms.Application.StartupPath + "\\Setting.xml");
        //    Resolution = Convert.ToDouble(xml.GetElement("PlanPara", "Resolution"));
        //    Coefficient = Convert.ToDouble(xml.GetElement("PlanPara", "Coefficient"));

        //    //获取障碍点
        //    List<Core.Model.Barries> lst_Barries = new List<Core.Model.Barries>();
        //    Core.DAL.Barries dal_Barries = new Core.DAL.Barries();
        //    lst_Barries = dal_Barries.GetList(CurrentDisaAreaID);


        //    double parameter = 0;//时间计算因子

        //    //无人机到任务区交通时间
        //    int count = 0;
        //    int taskcount = taskarea.Count;
        //    try
        //    {
        //        Program.SetStatusLabel("正在计算无人机到任务区交通时间...");
        //        for (int i = 0; i < uavBD.Count; i++)
        //        {
        //            for (int j = 0; j < taskcount; j++)
        //            {
        //                //抵达任务区时间
        //                IPoint pPoint1 = new ESRI.ArcGIS.Geometry.Point();
        //                IPoint pPoint2 = new ESRI.ArcGIS.Geometry.Point();
        //                pPoint1.PutCoords(uavBD[i].X, uavBD[i].Y);
        //                pPoint2.PutCoords(taskarea[j].X, taskarea[j].Y);
        //                try
        //                {
        //                    if (j == 0)
        //                    {
        //                        //通过网络分析计算时间
        //                        INAStreetDirection direction = helper.doNetWorkAnalysisNOstring(pPoint1, pPoint2, lst_Barries);
        //                        if (direction == null)
        //                        {
        //                            return;
        //                        }
        //                        parameter = direction.Length / (direction.Time / 60);
        //                    }
        //                    //用径直距离计算时间，把车速默认为固定值：60Km/h
        //                    double sPointx = pPoint1.X;
        //                    double sPointy = pPoint1.Y;
        //                    double ePointx = pPoint2.X;
        //                    double ePointy = pPoint2.Y;
        //                    double directLength = GetDistance(sPointx, sPointy, ePointx, ePointy);//两点之间的径直距离
        //                    if (parameter != 0)
        //                        Utraval_cost[i, j] = Math.Round(Convert.ToDouble(directLength / parameter) / Coefficient, 4, MidpointRounding.AwayFromZero);//时间

        //                }
        //                catch (Exception ex)//若有错误自动跳过，开始计算下一个任务
        //                {
        //                    taskarea.RemoveAt(j);
        //                    taskcount--;
        //                    j--;
        //                }
        //                count = j;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("第" + count + "个任务区错误", "提示");
        //        return;
        //    }

        //    //任务区到任务区交通时间,为加快计算效率，设定往返时间相同，只需计算一半的值
        //    Program.SetStatusLabel("正在计算任务区到任务区的交通时间...");
        //    for (int i = 0; i < taskarea.Count; i++)
        //    {
        //        for (int j = 0; j < taskarea.Count; j++)
        //        {
        //            if (j < i)
        //            {
        //                IPoint pPoint1 = new ESRI.ArcGIS.Geometry.Point();
        //                IPoint pPoint2 = new ESRI.ArcGIS.Geometry.Point();
        //                pPoint1.PutCoords(taskarea[i].X, taskarea[i].Y);
        //                pPoint2.PutCoords(taskarea[j].X, taskarea[j].Y);

        //                //if (j == 0)
        //                //{
        //                //    //通过网络分析计算时间
        //                //    INAStreetDirection direction = helper.doNetWorkAnalysisNOstring(pPoint1, pPoint2, lst_Barries);
        //                //    if (direction == null)
        //                //    {
        //                //        return;
        //                //    }
        //                //    parameter = direction.Length / (direction.Time / 60);
        //                //}

        //                //用径直距离计算时间，把车速默认为固定值：60Km/h
        //                double sPointx = pPoint1.X;
        //                double sPointy = pPoint1.Y;
        //                double ePointx = pPoint2.X;
        //                double ePointy = pPoint2.Y;
        //                double directLength = GetDistance(sPointx, sPointy, ePointx, ePointy);//两点之间的径直距离
        //                if (parameter != 0)
        //                    Ttraval_cost[i, j] = Math.Round(Convert.ToDouble(directLength / parameter) / Coefficient, 4, MidpointRounding.AwayFromZero);//时间

        //            }
        //            else if (j == i)
        //                Ttraval_cost[i, j] = 0;
        //        }
        //    }
        //    for (int i = 0; i < taskarea.Count; i++)
        //    {
        //        for (int j = i + 1; j < taskarea.Count; j++)
        //        {
        //            Ttraval_cost[i, j] = Ttraval_cost[j, i];
        //        }
        //    }

        //    //无人机执行任务区航拍时间
        //    Program.SetStatusLabel("正在计算各无人机编队航拍时间...");
        //    for (int i = 0; i < uavBD.Count; i++)
        //    {
        //        for (int j = 0; j < taskarea.Count; j++)
        //        {
        //            double time = (taskarea[j].Area / 1000000) / ((Resolution * uavBD[i].Pixel_W * uavBD[i].Sidelap * uavBD[i].Speed) / 1000);
        //            flying_cost[i, j] = Math.Round(Convert.ToDouble(time), 4, MidpointRounding.AwayFromZero);
        //        }
        //    }

        //    if (uavBD.Count >= taskarea.Count)
        //        plan(uavBD, taskarea, Utraval_cost, Ttraval_cost, flying_cost);
        //    else
        //    {
        //        plan(uavBD, taskarea, Utraval_cost, Ttraval_cost, flying_cost);
        //        List<Core.Model.UAVBD> uav_list = new List<Core.Model.UAVBD>();
        //        for (int i = 0; i < uavBD.Count; i++)
        //            uav_list.Add(uavBD[i]);
        //        while (!doAnalysisSecond(uavBD, uav_list, taskarea, Ttraval_cost, flying_cost, Utraval_cost))
        //        {
        //        }
        //    }
        //    ///生成任务描述
        //    PlanString = "";
        //    XY_Str = new List<string>();
        //    for (int i = 0; i < uavBD.Count; i++)
        //    {

        //        string XY_String = uavBD[i].Name + "," + uavBD[i].ID + "|";
        //        //for (int index = 0; index < G_Point.Count; index++)
        //        //    if (uavBD[i].GID == G_Point[index].ID)
        //        //        XY_String += G_Point[index].LON + "," + G_Point[index].LAT;


        //        List<Core.Model.TaskAreas> taskarea_list = new List<Core.Model.TaskAreas>();
        //        foreach (Core.Model.TaskAreas tarea in taskarea)
        //        {
        //            if (tarea.UID == uavBD[i].ID)
        //            {
        //                taskarea_list.Add(tarea);
        //            }
        //            taskarea_list.Sort(ComparerByN1);//问题所在
        //        }

        //        //按照Orders给taskarea_list从小到大排序，结果存在lst_TaskAreasSort中
        //        List<Core.Model.TaskAreas> lst_TaskAreasSort = new List<Core.Model.TaskAreas>();//排序后的taskareas
        //        for (int index = 0; index < taskarea_list.Count; )
        //        {
        //            int sort = taskarea_list[index].Orders;

        //            for (int index2 = 0; index2 < taskarea_list.Count; index2++)
        //            {
        //                if (sort > taskarea_list[index2].Orders)
        //                {
        //                    sort = taskarea_list[index2].Orders;
        //                }

        //            }
        //            for (int index4 = 0; index4 < taskarea_list.Count; index4++)
        //            {
        //                if (sort == taskarea_list[index4].Orders)
        //                {
        //                    lst_TaskAreasSort.Add(taskarea_list[index4]);
        //                    taskarea_list.Remove(taskarea_list[index4]);
        //                }
        //            }
        //        }



        //        //规划字符串格式为：无人机编队名称，执行总时间，编队ID|任务区名称，任务区几何中心经度，任务区几何中心纬度，抵达任务区交通成本，执行任务区航拍成本,任务区ID
        //        if (PlanString == "")
        //            PlanString = uavBD[i].Name + "," + uavBD[i].TotalTime + "," + uavBD[i].ID + "," + uavBD[i].GID + "|";
        //        else
        //            PlanString += "$" + uavBD[i].Name + "," + uavBD[i].TotalTime + "," + uavBD[i].ID + "," + uavBD[i].GID + "|";

        //        foreach (Core.Model.TaskAreas tarea1 in lst_TaskAreasSort)
        //        {
        //            PlanString += tarea1.Name + "," + tarea1.X + "," + tarea1.Y + "," + tarea1.TraTime + "," + tarea1.FlyTime + "," + tarea1.ID + "@";
        //            TaskString += tarea1.Name + "," + tarea1.ID + ",";
        //            XY_String += ";" + tarea1.X + "," + tarea1.Y;
        //        }

        //        XY_Str.Add(XY_String);
        //        Program.SetStatusLabel("生成任务规划方案...");
        //    }
        //}

        ///// <summary>
        ///// 经纬度转换成弧度
        ///// </summary>
        ///// <param name="d"></param>
        ///// <returns></returns>
        //private static double rad(double d)
        //{
        //    return d * Math.PI / 180.0;
        //}

        ///// <summary>
        ///// 通过经纬度计算两点之间的距离（km）
        ///// </summary>
        ///// <param name="lat1"></param>
        ///// <param name="lng1"></param>
        ///// <param name="lat2"></param>
        ///// <param name="lng2"></param>
        ///// <returns></returns>
        //public static double GetDistance(double lat1, double lng1, double lat2, double lng2)
        //{
        //    double a = rad(lat1) - rad(lat2);
        //    double b = rad(lng1) - rad(lng2);

        //    double s = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(a / 2), 2) +
        //     Math.Cos(rad(lat1)) * Math.Cos(rad(lat2)) * Math.Pow(Math.Sin(b / 2), 2)));
        //    s = s * 6378.137;
        //    s = Math.Round(s * 10000) / 10000;
        //    return s;
        //}

        ///// <summary>
        /////  无人机与任务区相等时执行
        ///// </summary>
        ///// <param name="uav">无人机List</param>
        ///// <param name="taskarea">任务区list</param>
        ///// <param name="G_Point">集结点list</param>
        ///// <param name="Utraval_cost">无人机到任务区交通时间</param>
        ///// <param name="Ttraval_cost">任务区到任务区交通时间</param>
        ///// <param name="Gtraval_cost">集结点到任务区交通时间</param>
        ///// <param name="flying_cost">任务区执行航拍费时</param>
        //public static void plan(List<Core.Model.UAVBD> uavBD, List<Core.Model.TaskAreas> taskarea, double[,] Utraval_cost, double[,] Ttraval_cost, double[,] flying_cost)
        //{

        //    while (!doAnalysisFirst(uavBD, taskarea, Utraval_cost))
        //    {
        //    }
        //    for (int i = 0; i < uavBD.Count; i++)
        //    {
        //        //对该任务区指定无人机
        //        taskarea.Find(name =>//拉姆表达式
        //        {
        //            if (name.UID == uavBD[i].ID)
        //            {
        //                //给无人机当前分配的任务需要费时赋给总费时字段
        //                int m = i;
        //                int n = taskarea.IndexOf(name);
        //                uavBD[m].TotalTime = flying_cost[m, n] + Utraval_cost[m, n];
        //                uavBD[m].TaskAreaIndex = n;
        //                taskarea[n].Orders = 1;
        //                //记录当前无人机执行当前任务区时的交通成本和航拍成本 用于成果输出
        //                taskarea[n].TraTime = Utraval_cost[m, n];
        //                taskarea[n].FlyTime = flying_cost[m, n];
        //                return true;
        //            }
        //            return false;
        //        });
        //    }
        //}



        //#region 排序函数
        //public static int ComparerByN(Core.Model.UAVBD c1, Core.Model.UAVBD c2)
        //{
        //    double fenbianl;
        //    Core.Generic.myXML xml = new Core.Generic.myXML(System.Windows.Forms.Application.StartupPath + "\\Setting.xml");
        //    fenbianl = Convert.ToDouble(xml.GetElement("PlanPara", "Resolution"));

        //    return fenbianl * c1.Pixel_W * c1.Sidelap * c1.Speed > fenbianl * c2.Pixel_W * c2.Sidelap * c2.Speed ? 0 : 1;//升序为0：1，降序1：0，看自个的需求吧。 
        //}
        //public static int ComparerByN1(Core.Model.UAVBD c1, Core.Model.UAVBD c2)
        //{
        //    return c1.TotalTime > c2.TotalTime ? 0 : 1;//升序为0：1，降序1：0，看自个的需求吧。 
        //}
        //public static int ComparerByN(Core.Model.TaskAreas c1, Core.Model.TaskAreas c2)
        //{
        //    return c1.Area > c2.Area ? 0 : 1;//升序为0：1，降序1：0，看自个的需求吧。 
        //}
        //public static int ComparerByN1(Core.Model.TaskAreas c1, Core.Model.TaskAreas c2)
        //{
        //    return c1.Orders > c2.Orders ? 0 : 1;//升序为0：1，降序1：0，看自个的需求吧。 
        //}
        ////L.Sort(ComparerByN);//调用方式 
        ////L.Sort((c1, c2) => { return c1.n > c2.n ? 0 : 1; });//简写  
        //#endregion



        ///// <summary>
        ///// 将任务区根据距离远近和各集结点无人机数量分配到各集结点
        ///// </summary>
        ///// <param name="G_Point"></param>
        ///// <param name="taskarea"></param>
        ///// <param name="Utraval_cost"></param>
        ///// <returns></returns>
        //public static bool doAnalysisFirst(List<Core.Model.UAVBD> uavBD, List<Core.Model.TaskAreas> taskarea, double[,] Utraval_cost)
        //{
        //    bool returnvalue = true;
        //    for (int i = 0; i < uavBD.Count; i++)
        //    {
        //        double[] traTime = new double[taskarea.Count];
        //        for (int j = 0; j < taskarea.Count; j++)
        //        {
        //            traTime[j] = Utraval_cost[i, j];
        //        }
        //        Array.Sort(traTime);//排序                
        //        for (int m = 0; m < traTime.Length; m++)
        //        {
        //            int flag = -1;
        //            for (int n = 0; n < taskarea.Count; n++)
        //            {
        //                if (Utraval_cost[i, n] == traTime[m])
        //                {
        //                    if (taskarea[n].UID <= 0)
        //                    {
        //                        taskarea[n].UID = uavBD[i].ID;
        //                        taskarea[n].TraTime = traTime[m];
        //                        flag++;
        //                    }
        //                    //else
        //                    //{
        //                    //    if (taskarea[n].UID != uavBD[i].ID)
        //                    //        if (taskarea[n].TraTime > traTime[m])
        //                    //        {
        //                    //            taskarea[n].UID = uavBD[i].ID;
        //                    //            taskarea[n].TraTime = traTime[m];
        //                    //            returnvalue = false;
        //                    //        }
        //                    //}
        //                    break;
        //                }
        //            }
        //            if (flag != -1)
        //                break;
        //        }
        //    }
        //    return returnvalue;
        //}


        ///// <summary>
        ///// 执行任务规划 当任务区多余无人机时 初次分配后，分配余下的任务区到无人机
        ///// </summary>
        ///// <param name="uav"></param>
        ///// <param name="uav_list"></param>
        ///// <param name="taskarea"></param>
        ///// <param name="Ttraval_cost"></param>
        ///// <param name="flying_cost"></param>
        ///// <param name="Utraval_cost"></param>
        ///// <returns></returns>
        //public static bool doAnalysisSecond(List<Core.Model.UAVBD> uav, List<Core.Model.UAVBD> uav_list, List<Core.Model.TaskAreas> taskarea, double[,] Ttraval_cost, double[,] flying_cost, double[,] Utraval_cost)
        //{
        //    bool returnvalue = true;
        //    uav_list.Sort(ComparerByN1);

        //    List<Core.Model.TaskAreas> taskarea_list = new List<Core.Model.TaskAreas>();
        //    foreach (Core.Model.TaskAreas tareas in taskarea)
        //        if (tareas.UID <= 0)
        //            taskarea_list.Add(tareas);

        //    //如果任务区还没有规划完返回字符串赋值false
        //    if (taskarea_list.Count > 0)
        //        returnvalue = false;
        //    else
        //        return returnvalue;

        //    int m = 0;
        //    int n = 0;
        //    double Ttime = 0;

        //    m = uav.IndexOf(uav_list[0]);

        //    try
        //    {
        //        for (int i = 0; i < taskarea_list.Count; i++)
        //        {
        //            if (i == 0)
        //            {
        //                Ttime = Ttraval_cost[uav_list[0].TaskAreaIndex, taskarea.IndexOf(taskarea_list[i])];
        //                n = taskarea.IndexOf(taskarea_list[i]);
        //            }
        //            else
        //            {
        //                if (Ttime > Ttraval_cost[uav_list[0].TaskAreaIndex, taskarea.IndexOf(taskarea_list[i])])
        //                {
        //                    Ttime = Ttraval_cost[uav_list[0].TaskAreaIndex, taskarea.IndexOf(taskarea_list[i])];
        //                    n = taskarea.IndexOf(taskarea_list[i]);
        //                }
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }


        //    uav[m].TotalTime = uav[m].TotalTime + Ttime + flying_cost[m, n];
        //    taskarea[n].UID = uav[m].ID;
        //    taskarea[n].Orders = taskarea[uav_list[0].TaskAreaIndex].Orders + 1;
        //    //记录当前无人机执行当前任务区时的交通成本和航拍成本 用于成果输出
        //    taskarea[n].TraTime = Ttime;
        //    taskarea[n].FlyTime = flying_cost[m, n];
        //    //赋值放在最后 顺序不能出错
        //    uav[m].TaskAreaIndex = n;


        //    return returnvalue;


        //}

        //#endregion

        //#region 图层管理
        ///// <summary>
        ///// 添加居民地图层
        ///// </summary>
        //public static void AddResidentLayer()
        //{
        //    OpenFileDialog fd = new OpenFileDialog();
        //    fd.Filter = "居民地(*.shp)|*.shp"; //过滤文件类型
        //    fd.ShowReadOnly = true; //设定文件是否只读
        //    DialogResult r = fd.ShowDialog();
        //    if (r == DialogResult.OK)
        //    {
        //        string fileName = fd.FileName;
        //        if (System.IO.File.Exists(fileName))
        //            ResidentLayer = OpenShape(fileName);
        //        Core.Generic.myXML xml = new Core.Generic.myXML(System.Windows.Forms.Application.StartupPath + "\\Setting.xml");
        //        xml.SaveElement("MapData", "Resident", fileName);
        //    }
        //}

        ///// <summary>
        ///// 添加DEM
        ///// </summary>
        //public static void AddDEM()
        //{
        //    OpenFileDialog fd = new OpenFileDialog();
        //    fd.Filter = "DEM(.tif)|*.tif|DEM(.img)|*.img"; //过滤文件类型
        //    fd.ShowReadOnly = true; //设定文件是否只读
        //    DialogResult r = fd.ShowDialog();
        //    if (r == DialogResult.OK)
        //    {
        //        string fileName = fd.FileName;
        //        if (System.IO.File.Exists(fileName))
        //            DEMRasterLayer = LoadDem(fileName);
        //        Core.Generic.myXML xml = new Core.Generic.myXML(System.Windows.Forms.Application.StartupPath + "\\Setting.xml");
        //        xml.SaveElement("MapData", "DEM", fileName);
        //    }
        //}

        ///// <summary>
        ///// 添加水系图层
        ///// </summary>
        //public static void AddLakeLayer()
        //{
        //    OpenFileDialog fd = new OpenFileDialog();
        //    fd.Filter = "水系(*.shp)|*.shp"; //过滤文件类型
        //    fd.ShowReadOnly = true; //设定文件是否只读
        //    DialogResult r = fd.ShowDialog();
        //    if (r == DialogResult.OK)
        //    {
        //        string fileName = fd.FileName;
        //        if (System.IO.File.Exists(fileName))
        //            HydroLayer = OpenShape(fileName);
        //        Core.Generic.myXML xml = new Core.Generic.myXML(System.Windows.Forms.Application.StartupPath + "\\Setting.xml");
        //        xml.SaveElement("MapData", "Hydrographic", fileName);
        //    }
        //}

        ///// <summary>
        ///// 添加道路图层
        ///// </summary>
        //public static void AddRoadLayer()
        //{
        //    OpenFileDialog fd = new OpenFileDialog();
        //    fd.Filter = "道路(*.shp)|*.shp"; //过滤文件类型
        //    fd.ShowReadOnly = true; //设定文件是否只读
        //    DialogResult r = fd.ShowDialog();
        //    if (r == DialogResult.OK)
        //    {
        //        string fileName = fd.FileName;
        //        if (System.IO.File.Exists(fileName))
        //            RoadLayer = OpenShape(fileName);
        //        Core.Generic.myXML xml = new Core.Generic.myXML(System.Windows.Forms.Application.StartupPath + "\\Setting.xml");
        //        xml.SaveElement("MapData", "Road", fileName);
        //    }
        //}

        ///// <summary>
        ///// 加载栅格图层
        ///// </summary>
        ///// <param name="shpFile"></param>
        //public static IRasterLayer LoadDem(string shpFile)
        //{

        //    string strFullPath = shpFile;
        //    if (strFullPath == "") return null;
        //    int Index = strFullPath.LastIndexOf("\\");
        //    string filePath = strFullPath.Substring(0, Index);
        //    string fileName = strFullPath.Substring(Index + 1);
        //    IWorkspaceFactory pWSFact = new RasterWorkspaceFactoryClass();
        //    IWorkspace pWS = pWSFact.OpenFromFile(filePath, 0);
        //    IRasterWorkspace pRasterWorkspace1 = pWS as IRasterWorkspace;
        //    IRasterLayer pRasterLayer = new RasterLayerClass();
        //    try
        //    {
        //        IRasterDataset pRasterDataset = (IRasterDataset)pRasterWorkspace1.OpenRasterDataset(fileName);
        //        pRasterLayer.CreateFromDataset(pRasterDataset);
        //        ILayer pLayer = pRasterLayer as ILayer;
        //        pLayer.Name = pRasterLayer.Name;
        //        Program.myMap.Map.AddLayer(pLayer);
        //        Program.myMap.ActiveView.Refresh();
        //        return pRasterLayer;
        //    }
        //    catch (Exception err)
        //    {
        //        throw (err);

        //    }
        //}
        /// <summary>
        /// 加载SHP文件
        /// </summary>
        /// <param name="shpFile"></param>
        /// <returns></returns>
        public static IFeatureLayer OpenShape(string shpFile)
        {
            IWorkspaceFactory pWorkspaceFactory;

            IFeatureWorkspace pFeatureWorkspace;
            IFeatureLayer pFeatureLayer;
            try
            {
                string strFullPath = shpFile;
                if (strFullPath == "") return null;
                int Index = strFullPath.LastIndexOf("\\");
                string filePath = strFullPath.Substring(0, Index);
                string fileName = strFullPath.Substring(Index + 1);

                //打开工作空间并添加shp文件
                pWorkspaceFactory = (IWorkspaceFactory)(new ShapefileWorkspaceFactory());
                //注意此处的路径是不能带文件名的
                pFeatureWorkspace = pWorkspaceFactory.OpenFromFile(filePath, 0) as IFeatureWorkspace;
                pFeatureLayer = new FeatureLayer();
                //注意这里的文件名是不能带路径的
                fileName = fileName.ToUpper().Replace(".SHP", "");
                pFeatureLayer.FeatureClass = pFeatureWorkspace.OpenFeatureClass(fileName);
                pFeatureLayer.Name = pFeatureLayer.FeatureClass.AliasName;
                Program.myMap.Map.AddLayer(pFeatureLayer);
                Program.myMap.ActiveView.Refresh();
                return pFeatureLayer;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                pWorkspaceFactory = null;
                pFeatureWorkspace = null;
            }
        }
        /// <summary>
        /// 打开shp但不加载
        /// </summary>
        /// <param name="aFileName"></param>
        /// <returns></returns>
        public static IFeatureLayer OpenFile_LayerFile(string aFileName)//打开shapefile文件
        {
            string fullPath;
            string path;//路径
            string fileName;//文件名

            IWorkspaceFactory pWorkspaceFactory = new ShapefileWorkspaceFactory();

            fullPath = aFileName;
            path = System.IO.Path.GetDirectoryName(fullPath);//路径
            fileName = System.IO.Path.GetFileName(fullPath);//文件名

            IWorkspace pWorkspace = pWorkspaceFactory.OpenFromFile(path, 0);
            IFeatureWorkspace pFeatureWorkspace = pWorkspace as IFeatureWorkspace;
            IFeatureClass pFeatureClass = pFeatureWorkspace.OpenFeatureClass(fileName);

            IFeatureLayer pFeatureLayer = new FeatureLayerClass();
            pFeatureLayer.FeatureClass = pFeatureClass;
            pFeatureLayer.Name = pFeatureClass.AliasName;
            return pFeatureLayer;
        }
        //#endregion

        #endregion



    }

    #region 公共类
    /// <summary>
    /// 多个字段排序
    /// </summary>
    ///按照 权重*面积 降序排列
    public class MyComparator
    {
        public int compare(RTsubTInfo s1, RTsubTInfo s2)
        {

            double s1AW = s1.subTWeight * s1.subTArea * 100000;
            double s2AW = s2.subTWeight * s2.subTArea * 100000;
            if (s1AW.CompareTo(s2AW) != 0)//如果权重*面积 不一样
                return -s1AW.CompareTo(s2AW);
            else// 如果权重一样 按面积
                return -(int)(s1.subTArea - s2.subTArea);


        }
        public int compare2(Atrrbi_T s1, Atrrbi_T s2)
        {

            double s1AW = s1.Weight * s1.Area * 100000;
            double s2AW = s2.Weight * s2.Area * 100000;
            if (s1AW.CompareTo(s2AW) != 0)//如果权重*面积 不一样
                return -s1AW.CompareTo(s2AW);
            else// 如果权重一样 按面积
                return -(int)(s1.Area - s2.Area);


        }
    }
    /// <summary>
    /// 资源Fid_元任务FID对应关系 
    /// </summary>
    public class RtoEleT
    {
        public int ResouceFID { get; set; }
        public int TaskFID { get; set; }
    }
    /// <summary>
    /// 附有属性的子任务 
    /// </summary>
    public class Atrrbi_T
    {
        public int SubTFID { get; set; }
        public double Area { get; set; }
        public double Weight { get; set; }
        public double other { get; set; }//其他属性 面积*权重
    }
    /// <summary>
    /// 资源_任务ID对应关系 
    /// </summary>
    public class R_TInfo
    {
        public string ResouceFID { get; set; }
        public string TaskFID { get; set; }
        public int SatEleTFID { get; set; }

    }
    /// <summary>
    /// 存储观测资源相对于任务的实际观测区域 记录资源FID 任务FID 观测区域feature
    /// </summary>
    public class RTFeatureInfo
    {
        public string SATFID { get; set; }
        public string UAVFID { get; set; }
        public string ASFID { get; set; }
        public string CarFID { get; set; }
        public string TFID { get; set; }
        public IFeature RtoTFL { get; set; }
        public double areaT { get; set; }
        public double RtoTtime { get; set; }

    }
    /// <summary>
    /// 存储观测资源相对于任务的实际观测区域 记录资源ID 元任务ID 子任务FID 子任务面积 子任务权重
    /// </summary>
    public class RTsubTInfo
    {
        //public string RID { get; set; }
        public string TFID { get; set; }
        public string subTFID { get; set; }
        public List<int> CarFID { get; set; }
        public List<int> UAVFID { get; set; }
        public List<int> ASFID { get; set; }
        public List<int> SatFID { get; set; }
        public int CoverL { get; set; }
        public double subTArea { get; set; }
        public double subTWeight { get; set; }
        public string subTWinS { get; set; }//当前元任务开始观测时间
        public string subTWinE { get; set; }
        public List<double> UAVTime { get; set; }//无人机观测元任务时间
        public List<double> ASTime { get; set; }
        public List<double> CarTime { get; set; }
        public double UAVReturns { get; set; }//无人机观测当前元任务的收益
        public double ASReturns { get; set; }
        public double SatReturns { get; set; }
        public double CarReturns { get; set; }
        //public List<double> SatTime { get; set; }
    }
    /// <summary>
    /// 一个资源能够观测的subTask集合 FID对应列表
    /// </summary>
    public class RT_FID
    {
        //public string RID { get; set; }
        public int RFID { get; set; }
        public List<int> subTaskFID { get; set; }
        public List<ConflictTFID> ConflictTaskFID { get; set; }//两两冲突的元任务序列 
        public int taskCount { get; set; }//当前资源能够观测的元任务个数
        public List<double> conRate { get; set; }//每一个资源观测每一个元任务的冲突率
        public List<double> conDegree { get; set; }//每一个资源观测每一个元任务的冲突度
        public List<double> leftEn { get; set; }//每一个资源观测每一个元任务的剩余观测能力
        public List<double> Returns { get; set; }//每一个资源观测每一个元任务的收益
        public List<StartTime> EleTstartTime { get; set; }//开始观测时间 
    }

    /// <summary>
    /// 一个资源实际观测的元任务EleTask集合 FID对应列表
    /// </summary>
    public class RtoEleT_FID
    {
        public int RFID { get; set; }

        public List<int> EleTaskFID { get; set; }
    }

    /// <summary>
    /// 相冲突的两个任务的FID
    /// </summary>
    public class ConflictTFID
    {
        //public string RID { get; set; }
        public int firstTFID { get; set; }
        public int secondTFID { get; set; }
    }
    /// <summary>
    /// 当前资源观测当前元任务的开始观测时间 
    /// </summary>
    public class StartTime
    {
        //public string RID { get; set; }
        public int Hour { get; set; }
        public int Min { get; set; }
    }
    /// <summary>
    /// 一个资源观测一个任务所花费时间 
    /// </summary>
    public class R_TFIDtime
    {
        public int RFID { get; set; }
        public int TFID { get; set; }
        public double time { get; set; }
    }
    /// <summary>
    /// 存储卫星观测任务和元任务的FID对应关系
    /// </summary>
    public class Sat_ElementTFID
    {
        public int SatTFID { get; set; }
        public List<int> ElementTaskFID { get; set; }
        public int SatFID { get; set; }
    }

    /// <summary>
    /// 存储分配方案 从CSV中读取  
    /// </summary>
    public class subPlanAllocation
    {
        public List<int> UAVtoElementT { get; set; }
        public List<int> AStoElementT { get; set; }
        public List<int> SATtoElementT { get; set; }
    }
    #endregion
}
