using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
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

        #region 任务规划调度

        #region 任务规划

        /// <summary>
        /// 任务分解 子任务生成
        /// 输入为卫星、无人机、飞艇、车的图层序号
        /// </summary>
        public static void taskDis(int satLayNO, int satAttribute, int UAVLayNO, int ASLayNO, int CarLayNO, int PolygonTaskNO)
        {
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
            ILayer satLayer = mapLayers.get_Layer(satLayNO);//SatElementTask 图层
            ILayer satAtributeLayer = mapLayers.get_Layer(satAttribute);//主要使用卫星的各种属性 后期可从sql数据库中获取 SateliteLine图层

            #region 任务分解 确定每一资源观测区域

            #region 无人机观测区域确定
            //无人机及实际观测范围--------------------------------------(无人机开始)------------------------------------------
            IFeatureLayer UAVFeatureLayer = (IFeatureLayer)layer;
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
            IFeatureLayer ptaskFeatureLayer = (IFeatureLayer)mapLayers.get_Layer(PolygonTaskNO + 1);
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
            List<RTFeatureInfo> lstFC = new List<RTFeatureInfo>();//存储每个无人机相对于每个任务的时间观测区域要素图层
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
                if (TaskWinE.Length > 3)
                {
                    TWEhour = int.Parse(TaskWinE.Substring(0, 2));//任务结束时间 小时                 
                }
                else
                {
                    TWEhour = int.Parse(TaskWinE.Substring(0, 1));//任务结束时间 小时
                }
                TWEmin = int.Parse(TaskWinE.Substring(TaskWinE.Length - 2, 2));//任务结束时间 分钟 

                //double SinMaxT = (Mileage) / (2 * (Vuav) * 0.2777778) / 60; //最远单程飞行时间 分钟


                if (int.Parse(tStart) < int.Parse(TaskWinE))//保证开始观测时间（无人机出发时间）小于任务结束时间
                {
                    if (K_Ober == 1) //飞行一次即可完成的任务
                    {
                        if (TWEhour * 60 + TWEmin - (SThour * 60 + STmin) - dcen / 1000 / Vuav * 60 - tu_one * 60 > 0)
                        {
                            ober_urad = Mileage / 2;//满足时间约束 半径等于续航里程/2
                            UtoTtime = (dcen / 1000 / Vuav) * 2 + tu_one;

                        }
                        else  //不满足时间窗口约束 则确定在时间窗口约束下能够完成的面积
                        {
                            Scstr = (TWEhour * 60 + TWEmin - (SThour * 60 + STmin) - dcen / 1000 / Vuav * 60) / 60 * Vuav * 1000 * UavWidth;
                            //根据Scstr确定半径ober_urad 
                            if (Scstr > 0)
                            {
                                ///////////////////////////////////////////算法A///////////////////////////////////////////////////////////////////
                                ober_urad = AreaToRadius(UavEveryLayer, TaskEveryLayer, Scstr, Mileage / 2);

                                UtoTtime = (TWEhour * 60 + TWEmin - (SThour * 60 + STmin) + dcen / 1000 / Vuav * 60) / 60;

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

                        if (TWEhour * 60 + TWEmin - (SThour * 60 + STmin) - tk * 60 > 0)
                        {
                            ober_urad = Mileage / 2;//满足时间约束 半径等于续航里程/2
                            UtoTtime = K_Ober * Tdut + 0.25 * K_Ober * Tdut;//充电时间 一定值 这里与上文一致 0.2/0.8

                        }
                        else //不满足时间窗口约束 则首先确定满足时间窗口的最大观测面积Scstr
                        {
                            if (TWEhour * 60 + TWEmin - (SThour * 60 + STmin) - dcen / 1000 / Vuav * 60 - tu_one * 60 < 0)
                            {//一次都不满足情况 
                                Scstr = (TWEhour * 60 + TWEmin - (SThour * 60 + STmin) - dcen / 1000 / Vuav * 60) / 60 * Vuav * 1000 * UavWidth;
                                //根据Scstr确定半径ober_urad  
                                if (Scstr > 0)
                                {
                                    /////////////////////////（算法A）循环逼近半径/////////////////////////////////////////
                                    ober_urad = AreaToRadius(UavEveryLayer, TaskEveryLayer, Scstr, Mileage / 2);
                                    UtoTtime = (TWEhour * 60 + TWEmin - (SThour * 60 + STmin) + dcen / 1000 / Vuav * 60) / 60;

                                }

                            }
                            else//能够满足至少一次观测情况
                            {
                                double kk;//第j次观测完成所花费时间 小时
                                for (int j = 2; j <= K_Ober; j++)
                                {
                                    kk = (j - 1) * Tdut + (j - 1) * (Tdut * consumRate / chageRate) + dcen / 1000 / Vuav + tu_one;
                                    if (TWEhour * 60 + TWEmin - (SThour * 60 + STmin) - kk * 60 < 0)
                                    {
                                        double jt = TWEhour * 60 + TWEmin - (SThour * 60 + STmin) - ((j - 1) * Tdut + (j - 1) * (Tdut * consumRate / chageRate)) * 60 - dcen / 1000 / Vuav * 60;    //第j次能够观测的时间（可能能够完成部分）
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
                                            UtoTtime = (TWEhour * 60 + TWEmin - (SThour * 60 + STmin) + dcen / 1000 / Vuav * 60) / 60;

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
                    RTFeatureInfo RTFinfo = new RTFeatureInfo() { UAVFID = RTinfoList[i].ResouceFID, ASFID = "-1", SATFID = "-1", TFID = RTinfoList[i].TaskFID, RtoTFL = UavToTTrueObe, areaT = uavTarea.Area, RtoTtime = UtoTtime };
                    lstFC.Add(RTFinfo);//每个无人机相对于每个任务的最终观测区域 和无人机ID和面状任务区ID对应关系，表明无人机最终观测到此任务区

                }

            }
            //无人机及实际观测范围--------------------------------------(无人机结束)------------------------------------------

            #endregion

            #region 飞艇观测区域确定

            //飞艇及实际观测范围--------------------------------------(飞艇开始)------------------------------------------
            IFeatureLayer ASfeatureLayer = ASlayer as IFeatureLayer;

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
                    TsakWinS = taskPointFeature.get_Value(4).ToString();//任务开始时间
                    TaskWinE = taskPointFeature.get_Value(5).ToString();//任务结束时间
                    //确定时间
                    if (TaskWinE.Length > 3)
                    {
                        TWEhour = int.Parse(TaskWinE.Substring(0, 2));//任务结束时间 小时                 
                    }
                    else
                    {
                        TWEhour = int.Parse(TaskWinE.Substring(0, 1));//任务结束时间 小时
                    }
                    TWEmin = int.Parse(TaskWinE.Substring(TaskWinE.Length - 2, 2));//任务结束时间 分钟 
                    if (tStart.Length > 3)
                    {
                        SThour = int.Parse(tStart.Substring(0, 2));//开始观测时间 小时        
                    }
                    else
                    {
                        SThour = int.Parse(tStart.Substring(0, 1));//开始观测时间 小时
                    }
                    STmin = int.Parse(tStart.Substring(tStart.Length - 2, 2));//开始观测时间 分钟
                    if ((TWEhour * 60 + TWEmin - SThour * 60 - STmin - (ASdcen / ASv / 1000) * 60) < ASconT * 60)
                    {
                        Tas = (TWEhour * 60 + TWEmin - SThour * 60 - STmin - (ASdcen / ASv / 1000) * 60) / 60;//有效观测时间 小时
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
                        TmaxAS = (TWEhour * 60 + TWEmin - SThour * 60 - STmin) / 60;
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


                            RTFeatureInfo RTFinfo = new RTFeatureInfo() { ASFID = ASFeature.get_Value(0).ToString(), UAVFID = "-1", SATFID = "-1", TFID = taskPointFeature.get_Value(0).ToString(), RtoTFL = ASToTTrueObe, RtoTtime = Tas, areaT = areaAS };
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
            List<R_TInfo> SattoTaskFIDlist = new List<R_TInfo>();//sat相对于任务的FID 以便为条带命名
            IFeatureLayer SatFeLayer = satLayer as IFeatureLayer;
            IQueryFilter pSatFilter = new QueryFilter();//实例化一个查询条件对象 
            pSatFilter.WhereClause = "FID >= 0";//将查询条件赋值     遍历每一个
            IFeatureCursor SatfeatureCursor = SatFeLayer.Search(pSatFilter, false);
            IFeature SatFeature = SatfeatureCursor.NextFeature();//遍历查询结果  每一个卫星条带
            //获取每一个卫星条带
            while (SatFeature != null)
            {
                R_TInfo satinfo = new R_TInfo() { ResouceFID = SatFeature.get_Value(16).ToString(), TaskFID = SatFeature.get_Value(15).ToString(), SatEleTFID = int.Parse(SatFeature.get_Value(0).ToString()) };
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

                RTFeatureInfo sRTFinfo = new RTFeatureInfo() { SATFID = SatFeature.get_Value(16).ToString(), UAVFID = "-1", ASFID = "-1", TFID = SatFeature.get_Value(15).ToString(), RtoTFL = ASToTTrueObe };
                lstFC.Add(sRTFinfo);//每个飞艇相对于每个任务的最终观测区域 和飞艇ID和面状任务区ID对应关系，表明飞艇最终观测到此任务区


                SatFeature = SatfeatureCursor.NextFeature();
            }


            //卫星及实际观测范围--------------------------------------(卫星结束)------------------------------------------

            #endregion

            #endregion

            #region 任务分解 交集求元任务

            //通过交集求最终的元任务集并显示--------------------------------------(交集求元任务开始)------------------------------------------
            //将资源观测到任务的实际区域交叉分割 形成最终的子任务   每一次叠加操作 都要更新每个任务的观测资源集
            string UavToTasdfkUnionPath;
            IFeatureLayer replaceLayer = lstFC[0].RtoTFL;
            List<IFeatureLayer> lstTWOFC = new List<IFeatureLayer>();//Union工具只能输入两个图层 以后可修改
            for (int i = 1; i < lstFC.Count; i++)
            {
                UavToTasdfkUnionPath = System.AppDomain.CurrentDomain.BaseDirectory + "Data\\cache\\" + i.ToString() + "UToTaUni.shp";
                lstTWOFC.Add(replaceLayer);
                lstTWOFC.Add(lstFC[i].RtoTFL);
                GPUnionTool(lstTWOFC, UavToTasdfkUnionPath);
                replaceLayer = OpenFile_LayerFile(UavToTasdfkUnionPath);
                lstTWOFC.Clear();
            }
            //以上不包括无人机无法到达观测的子任务  以上结果和TaskArea再进行一次Union可解决
            lstTWOFC.Clear();
            lstTWOFC.Add(replaceLayer);//能够观测到的区域分割结果
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
            IFeatureCursor subTaskfeatureCursor = subTaskLayer.Search(pFilter, false);
            IFeature subTaskFeature = subTaskfeatureCursor.NextFeature();//遍历查询结果  子任务
            string OriTFID = "-1";//原任务FID
            while (subTaskFeature != null)
            {
                ISpatialFilter pContainFilter = new SpatialFilterClass();
                pContainFilter.Geometry = subTaskFeature.Shape;
                pContainFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;//空间关系选择条件 用相交选择该子任务的原始任务
                IFeatureCursor OriTaskfeatureCursor = ptaskFeatureLayer.FeatureClass.Search(pContainFilter, false);
                IFeature pTFeature = OriTaskfeatureCursor.NextFeature();//查询与子任务相交的原任务区
                while (pTFeature != null)//有且仅有一个与子任务相交的原任务区
                {

                    OriTFID = pTFeature.get_Value(0).ToString();//当前子任务所属原任务的FID  
                    double subTweight = double.Parse(pTFeature.get_Value(9).ToString());//当前子任务所属原任务的权重
                    string subTWinS = pTFeature.get_Value(4).ToString();//当前子任务所属原任务的开始时间
                    string subTWinE = pTFeature.get_Value(5).ToString();//当前子任务所属原任务的结束时间
                    int coverNO = 0;
                    List<int> ReUAVID = new List<int>();//每一个子任务的无人机资源FID 列表                    
                    //确定所属资源FID   无人机//////////////////////////////////////明日任务///////////////////////////////////////////////////////
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

                    RTsubTInfo RTFNOinfo = new RTsubTInfo() { TFID = (int.Parse(OriTFID)).ToString(), subTFID = subTaskFeature.get_Value(0).ToString(), UAVFID = ReUAVID, ASFID = ReASID, SatFID = ReSatID, CoverL = ReUAVID.Count + ReASID.Count + ReSatID.Count, subTArea = subTarea.Area, subTWeight = subTweight, subTWinS = subTWinS, subTWinE = subTWinE };
                    lstTaskFC.Add(RTFNOinfo);

                    pTFeature = OriTaskfeatureCursor.NextFeature();
                }

                subTaskFeature = subTaskfeatureCursor.NextFeature();
            }
            //求元任务集中每一个 元任务的原任务、资源、覆盖级别对应关系--------------------------------------(对应关系结束)------------------------------------------

            #endregion

            // OpenShape(UavToTasdfkUnionPath);//如果在图层上显示 PolygonTaskNO等图层NO要+1 //////////////////////////////////////////////////////////////////////////////////////////
            Program.myMap.Refresh();
            //地图缩放到阿克苏地区
            ILayer akesulayer = PRV_GetLayersByName("AkesuCity");
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
                lstTaskFC[i].UAVTime = UavTime;
                lstTaskFC[i].ASTime = ASTime;
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
                if (subFIdlist.Count > 1)//当前观测资源能够观测到的元任务不为空且大于1，满足两两冲突的基本条件
                {
                    //无人机冲突判断 UAV假设全部观测完一个任务后再观测其他任务  因此冲突判断条件为：任务i开始时间+任务i执行时间+任务u执行时间大于任务u结束时间
                    for (int j = 0; j < subFIdlist.Count; j++)
                    {
                        for (int k = j + 1; k < subFIdlist.Count; k++)
                        {
                            //IFeature firstSubFeature = subTaskLayer.FeatureClass.GetFeature(subFIdlist[j]);//获取第一个冲突元任务要素
                            //IFeature secondSubFeature = subTaskLayer.FeatureClass.GetFeature(subFIdlist[k]);//获取第一个冲突元任务要素
                            //根据元任务fid获取其时间窗口  （获取源任务再得到时间）
                            int fisttTFID = 0;//源任务FID
                            int secondTFID = 0;
                            double firstsubTarea = 0;//元任务面积
                            double secondsubTarea = 0;
                            int firstThour;
                            int firstTmin;
                            int secondThour;
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
                            if ((firstThour * 60 + firstTmin) < (secondThour * 60 + secondTmin))//第二个任务后执行  SThour;//开始观测时间 小时 STmin;//开始观测时间 分钟
                            {
                                if ((SThour + (double)STmin / 60 + firstsubTtime + secondsubTtime) > (secondThour + (double)secondTmin / 60)) //无人机判断冲突  任务开始时间是：（开始观测时间）和（任务窗口开始时间）的最大值-----------？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？---------从lsttaskfc可获得----
                                {
                                    ConflictTFID conflictFidInfo = new ConflictTFID() { firstTFID = subFIdlist[j], secondTFID = subFIdlist[k] };
                                    conFIdlist.Add(conflictFidInfo);
                                }

                            }
                            else
                            {
                                if ((SThour + (double)STmin / 60 + firstsubTtime + secondsubTtime) > (firstThour + (double)firstTmin / 60)) //无人机判断冲突  
                                {
                                    ConflictTFID conflictFidInfo = new ConflictTFID() { firstTFID = subFIdlist[j], secondTFID = subFIdlist[k] };
                                    conFIdlist.Add(conflictFidInfo);
                                }
                            }

                        }//第二个任务 k
                    }//第一个任务 j

                }//(subFIdlist.Count > 1) 当前资源观测的元任务个数大于1

                RT_FID rtFidInfo = new RT_FID() { RFID = i, subTaskFID = subFIdlist, ConflictTaskFID = conFIdlist, taskCount = subFIdlist.Count };
                UavRTFIDlist.Add(rtFidInfo);
            }//无人机资源结束 
            //UAV冲突判断结束--------------------------------------(uav冲突判断结束)------------------------------------------ 
            #endregion

            #region 卫星冲突判断
            //卫星冲突判断开始--------------------------------------(sat冲突判断开始)------------------------------------------ 
            IFeatureLayer satAtributeFL = satAtributeLayer as IFeatureLayer; //SateliteLine 
            int satNo = satAtributeFL.FeatureClass.FeatureCount(null);
            List<RT_FID> satRTFIDlist = new List<RT_FID>();//卫星FID 及此卫星能够观测的元任务集FIDlist ,以及元任务发生冲突的list★★★★★★★★★★★★★★★★ 资源FID：int，元任务FID：list<int>,元任务个数：int  
            for (int i = 0; i < satNo; i++) //卫星FID                      SattoTaskFIDlist
            {//对于卫星 不需判断每个元任务的冲突 因为假定卫星要么观测一个任务的完整条带 要么完全不观测
                List<int> satSubFIdlist = new List<int>();//存储每个资源能够观测的satElemT任务fid列表
                for (int j = 0; j < SattoTaskFIDlist.Count; j++)
                {

                    if (i.ToString() == SattoTaskFIDlist[j].ResouceFID)
                    {
                        satSubFIdlist.Add(SattoTaskFIDlist[j].SatEleTFID);//卫星观测任务FID 即SatElementTask中FID 2 3 5 6
                    }
                }

                List<ConflictTFID> satConFIdlist = new List<ConflictTFID>();//存储每个卫星能够观测的SatElemT中发生冲突的任务FID列表list<(int,int)>
                if (satSubFIdlist.Count > 1)//当前观测资源能够观测到的元任务不为空且大于1，满足两两冲突的基本条件
                {
                    //卫星冲突判断  转角时间约束 和容量约束
                    for (int j = 0; j < satSubFIdlist.Count; j++)
                    {
                        for (int k = j + 1; k < satSubFIdlist.Count; k++)
                        {
                            IFeature SATatributeFeature = satAtributeFL.FeatureClass.GetFeature(i);//当前卫星（获取属性）
                            double Vengel = double.Parse(SATatributeFeature.get_Value(10).ToString()); //侧摆角转向速度 度每秒
                            double storeV = double.Parse(SATatributeFeature.get_Value(9).ToString()); //星上存储容量 GB
                            double intervalT = double.Parse(SATatributeFeature.get_Value(11).ToString()); //开机间隔时间 秒
                            double staT = double.Parse(SATatributeFeature.get_Value(12).ToString()); //侧摆之后稳定时间 秒

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
                            }
                            /////////////////
                            if (firstTaskEtime.Contains("."))
                            {
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
                                    firstTSmin = double.Parse(HourAndMin.Substring(HourAndMin.Length - 2, 2) + firstTaskEtime.Substring(firstTaskEtime.IndexOf(".")));//第一个任务开始观测时间  分钟  
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
                            }
                            /////////////////
                            if (secondTaskStime.Contains("."))
                            {
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
                                    firstTSmin = double.Parse(HourAndMin.Substring(HourAndMin.Length - 2, 2) + secondTaskStime.Substring(secondTaskStime.IndexOf(".")));//第一个任务开始观测时间  分钟  
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
                            }
                            /////////////////
                            if (secondTaskEtime.Contains("."))
                            {
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
                                    firstTSmin = double.Parse(HourAndMin.Substring(HourAndMin.Length - 2, 2) + secondTaskEtime.Substring(secondTaskEtime.IndexOf(".")));//第一个任务开始观测时间  分钟  
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
                if (subFIdlist.Count > 1)//当前观测资源能够观测到的元任务不为空且大于1，满足两两冲突的基本条件
                {
                    //飞艇冲突判断 AS假设全部观测完一个任务后再观测其他任务  因此冲突判断条件为：开始时间+执行任务两个任务的时间+航行到两个地点飞行时间 大于 第二个任务结束时间 则冲突
                    for (int j = 0; j < subFIdlist.Count; j++)
                    {
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
                            double AStoTDis;//AS到第一个任务的距离
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

                            #endregion

                            //判断任务先后顺序  冲突判断
                            IPoint ASPoint = ASFea.Shape as IPoint;//将AS当作point求当前飞艇到任务的距离

                            if ((firstThour * 60 + firstTmin) < (secondThour * 60 + secondTmin))//第二个任务后执行  SThour;//开始观测时间 小时 STmin;//开始观测时间 分钟
                            {
                                AStoTDis = Math.Sqrt(Math.Pow(firstPoint.X - ASPoint.X, 2) + Math.Pow(firstPoint.Y - ASPoint.Y, 2));
                                if ((SThour + (double)STmin / 60 + firstsubTtime + secondsubTtime + (AStoTDis + TaskDis) / 1000 / Vas) > (secondThour + (double)secondTmin / 60)) //AS判断冲突  小时
                                {
                                    ConflictTFID conflictFidInfo = new ConflictTFID() { firstTFID = subFIdlist[j], secondTFID = subFIdlist[k] };
                                    ASconFIdlist.Add(conflictFidInfo);
                                }

                            }
                            else
                            {
                                AStoTDis = Math.Sqrt(Math.Pow(secondPoint.X - ASPoint.X, 2) + Math.Pow(secondPoint.Y - ASPoint.Y, 2));
                                if ((SThour + (double)STmin / 60 + firstsubTtime + secondsubTtime + (AStoTDis + TaskDis) / 1000 / Vas) > (firstThour + (double)firstTmin / 60)) //AS判断冲突  
                                {
                                    ConflictTFID conflictFidInfo = new ConflictTFID() { firstTFID = subFIdlist[j], secondTFID = subFIdlist[k] };
                                    ASconFIdlist.Add(conflictFidInfo);
                                }
                            }

                        }//第二个任务 k
                    }//第一个任务 j

                }//(subFIdlist.Count > 1) 当前资源观测的元任务个数大于1

                RT_FID rtFidInfo = new RT_FID() { RFID = i, subTaskFID = subFIdlist, ConflictTaskFID = ASconFIdlist, taskCount = subFIdlist.Count };
                ASRTFIDlist.Add(rtFidInfo);
            }//飞艇资源结束 
            //AS冲突判断结束--------------------------------------(AS冲突判断结束)------------------------------------------ 
            #endregion

            //冲突判断部分结束--------------------------------------(冲突判断结束)------------------------------------------

            #endregion

            #region 启发式准则模型构建

            //先以每个资源为视角计算资源观测到任务的收益 最后在统一到各个子规划中心上 
            #region 无人机子规划中心启发式准则模型
            //无人机子规划中心模型.
            double UAVPlanCenGain = 0;//无人机子规划中心总体收益 元任务不一定分配给此规划中心 要在算法上计算 
            for (int i = 0; i < UavRTFIDlist.Count; i++)
            {
                int UAVFID = UavRTFIDlist[i].RFID;//资源FID‘
                List<int> subFIDList = UavRTFIDlist[i].subTaskFID;//当前资源能够观测到的元任务list集合
                List<ConflictTFID> ConTFID = UavRTFIDlist[i].ConflictTaskFID;//当前资源能够观测的元任务的冲突集合
                List<double> ConRatelist = new List<double>(new double[subFIDList.Count]);//元任务冲突率 每一个资源相对于每一个元任务 list长度为观测元任务个数
                List<double> ConDgreelist = new List<double>(new double[subFIDList.Count]);//元任务冲突率
                List<double> ConLeftElist = new List<double>(new double[subFIDList.Count]);//元任务冲突剩余能力 存储冲突之后能够观测的当前任务的面积s之和 （所有冲突之后的面积之和S1+S2+...+Sjm） （不是概率p）
                for (int j = 0; j < subFIDList.Count; j++)
                {
                    int subTFID = subFIDList[j];//获取当前资源观测的一个元任务FID 当前元任务
                    List<int> ConflictsubTfid = new List<int>();//与当前元任务冲突的元任务FID集合
                    double subTtime = 0;//当前元任务的观测时长
                    double ConflisubTtime = 0;//与当前任务冲突的元任务的观测时长
                    string subTwinE = "0";//当前元任务的结束观测时间
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
                        conIndSum = conIndSum + conTWeight / (conTWeight + lstTaskFC[subTFID].subTWeight) + conTArea / (conTArea + lstTaskFC[subTFID].subTArea) + (1 - conTLevel / (conTLevel + (double)lstTaskFC[subTFID].CoverL));
                    }
                    ConDgreelist[j] = conIndSum / ((double)3 * ConflictsubTfid.Count);//冲突度 -------------------------------------------------------------------------------------
                    double subTleftArea = 0;//当前元任务所有冲突剩余面积之和
                    //根据剩余观测时间估计完成面积 参考冲突判断部分
                    for (int l = 0; l < ConflictsubTfid.Count; l++)
                    {
                        int ConsubTFID = ConflictsubTfid[l];//与当前元任务冲突的元任务FID                   

                        int subThour;//当前元任务结束时间 小时
                        int subTmin;//当前元任务结束时间 分钟
                        int consubThour;//冲突元任务结束时间 小时
                        int consubTmin;//冲突元任务结束时间 分钟
                        //时间确定 
                        #region 时间确定

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
                            }
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

                        if (subTwinE.Length > 3)
                        {
                            subThour = int.Parse(subTwinE.Substring(0, 2));//任务结束时间 小时                 
                        }
                        else
                        {
                            subThour = int.Parse(subTwinE.Substring(0, 1));//任务结束时间 小时
                        }
                        subTmin = int.Parse(subTwinE.Substring(subTwinE.Length - 2, 2));//任务结束时间 分钟 

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

                        if ((subThour * 60 + subTmin) < (consubThour * 60 + consubTmin))//当前任务先执行 冲突任务后执行  SThour;//开始观测时间 小时 STmin;//开始观测时间 分钟
                        {
                            double AreaRate = (consubThour + (double)consubTmin / 60 - (SThour + (double)STmin / 60) - ConflisubTtime) / subTtime;//任务开始时间是：（开始观测时间）和（任务窗口开始时间）的最大值-----------？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？---------从lsttaskfc可获得----
                            if (AreaRate > 0)
                            {
                                subTleftArea = subTleftArea + AreaRate * lstTaskFC[subTFID].subTArea;
                            }
                            else
                            { }
                        }
                        else//冲突任务先执行 当前任务后执行
                        {
                            double AreaRate = (subThour + (double)subTmin / 60 - (SThour + (double)STmin / 60) - ConflisubTtime) / subTtime;//任务开始时间是：（开始观测时间）和（任务窗口开始时间）的最大值-----------？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？---------从lsttaskfc可获得----
                            if (AreaRate > 0)
                            {
                                subTleftArea = subTleftArea + AreaRate * lstTaskFC[subTFID].subTArea;
                            }
                            else
                            { }
                        }


                    }
                    ConLeftElist[j] = subTleftArea;

                }
                UavRTFIDlist[i].conRate = ConRatelist;
                UavRTFIDlist[i].conDegree = ConDgreelist;
                UavRTFIDlist[i].leftEn = ConLeftElist;
            }

            #endregion

            #region 飞艇子规划中心启发式准则模型
            //飞艇子规划中心模型.
            double ASPlanCenGain = 0;//飞艇子规划中心总体收益 元任务不一定分配给此规划中心 要在算法上计算 
            for (int i = 0; i < ASRTFIDlist.Count; i++)
            {
                int ASRFID = ASRTFIDlist[i].RFID;//资源FID‘
                IFeature ASFea = ASfeatureLayer.FeatureClass.GetFeature(ASRFID);//当前飞艇（获取属性）
                double Vas = double.Parse(ASFea.get_Value(5).ToString()); //飞艇速度 km/h
                List<int> subFIDList = ASRTFIDlist[i].subTaskFID;//当前资源能够观测到的元任务list集合
                List<ConflictTFID> ConTFID = ASRTFIDlist[i].ConflictTaskFID;//当前资源能够观测的元任务的冲突集合
                List<double> ConRatelist = new List<double>(new double[subFIDList.Count]);//元任务冲突率 每一个资源相对于每一个元任务 list长度为观测元任务个数
                List<double> ConDgreelist = new List<double>(new double[subFIDList.Count]);//元任务冲突率
                List<double> ConLeftElist = new List<double>(new double[subFIDList.Count]);//元任务冲突剩余能力 存储冲突之后能够观测的当前任务的面积s之和 （所有冲突之后的面积之和S1+S2+...+Sjm） （不是概率p）
                for (int j = 0; j < subFIDList.Count; j++)//遍历当前资源能够观测到的元任务
                {
                    int subTFID = subFIDList[j];//获取当前资源观测的一个元任务FID 当前元任务
                    List<int> ConflictsubTfid = new List<int>();//与当前元任务冲突的元任务FID集合
                    double subTtime = 0;//当前元任务的观测时长
                    double ConflisubTtime = 0;//与当前任务冲突的元任务的观测时长
                    string subTwinE = "0";//当前元任务的结束观测时间
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
                        conIndSum = conIndSum + conTWeight / (conTWeight + lstTaskFC[subTFID].subTWeight) + conTArea / (conTArea + lstTaskFC[subTFID].subTArea) + (1 - conTLevel / (conTLevel + (double)lstTaskFC[subTFID].CoverL));
                    }
                    ConDgreelist[j] = conIndSum / ((double)3 * ConflictsubTfid.Count);//冲突度 -------------------------------------------------------------------------------------
                    double subTleftArea = 0;//当前元任务所有冲突剩余面积之和
                    //根据剩余观测时间估计完成面积 参考冲突判断部分
                    for (int l = 0; l < ConflictsubTfid.Count; l++)
                    {
                        int ConsubTFID = ConflictsubTfid[l];//与当前元任务冲突的元任务FID
                        int subThour;//当前元任务结束时间 小时
                        int subTmin;//当前元任务结束时间 分钟
                        int consubThour;//冲突元任务结束时间 小时
                        int consubTmin;//冲突元任务结束时间 分钟
                        //时间确定 
                        #region 结束时间确定
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
                            }
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

                        if (subTwinE.Length > 3)
                        {
                            subThour = int.Parse(subTwinE.Substring(0, 2));//任务结束时间 小时                 
                        }
                        else
                        {
                            subThour = int.Parse(subTwinE.Substring(0, 1));//任务结束时间 小时
                        }
                        subTmin = int.Parse(subTwinE.Substring(subTwinE.Length - 2, 2));//任务结束时间 分钟 

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
                        double AStosubTDis;//飞艇到元任务距离
                        if ((subThour * 60 + subTmin) < (consubThour * 60 + consubTmin))//当前任务先执行 冲突任务后执行  SThour;//开始观测时间 小时 STmin;//开始观测时间 分钟
                        {
                            AStosubTDis = Math.Sqrt(Math.Pow(subTPoint.X - ASPoint.X, 2) + Math.Pow(subTPoint.Y - ASPoint.Y, 2));
                            double AreaRate = (consubThour + (double)consubTmin / 60 - (SThour + (double)STmin / 60) - ConflisubTtime - (AStosubTDis + TaskDis) / Vas / 1000) / subTtime;//任务开始时间是：（开始观测时间）和（任务窗口开始时间）的最大值-----------？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？---------从lsttaskfc可获得----
                            if (AreaRate > 0)
                            {
                                subTleftArea = subTleftArea + AreaRate * lstTaskFC[subTFID].subTArea;
                            }
                            else
                            { }
                        }
                        else//冲突任务先执行 当前任务后执行
                        {
                            AStosubTDis = Math.Sqrt(Math.Pow(conTPoint.X - ASPoint.X, 2) + Math.Pow(conTPoint.Y - ASPoint.Y, 2));
                            double AreaRate = (subThour + (double)subTmin / 60 - (SThour + (double)STmin / 60) - ConflisubTtime - (AStosubTDis + TaskDis) / Vas / 1000) / subTtime;//任务开始时间是：（开始观测时间）和（任务窗口开始时间）的最大值-----------？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？---------从lsttaskfc可获得----
                            if (AreaRate > 0)
                            {
                                subTleftArea = subTleftArea + AreaRate * lstTaskFC[subTFID].subTArea;
                            }
                            else
                            { }
                        }


                    }
                    ConLeftElist[j] = subTleftArea;

                }
                ASRTFIDlist[i].conRate = ConRatelist;
                ASRTFIDlist[i].conDegree = ConDgreelist;
                ASRTFIDlist[i].leftEn = ConLeftElist;
            }

            #endregion

            #region 卫星子规划中心启发式准则模型
            //卫星子规划中心模型.
            //卫星不观测元任务 只考虑卫星观测的子任务不进行划分
            double SatPlanCenGain = 0;//卫星子规划中心总体收益 元任务不一定分配给此规划中心 要在算法上计算 
            for (int i = 0; i < satRTFIDlist.Count; i++)
            {
                int SatRFID = satRTFIDlist[i].RFID;//资源FID‘
                IFeature SatFea = satAtributeFL.FeatureClass.GetFeature(SatRFID);//当前卫星（获取属性）SatelinteLine图层

                double Vengel = double.Parse(SatFea.get_Value(10).ToString()); //侧摆角转向速度 度每秒
                double storeV = double.Parse(SatFea.get_Value(9).ToString()); //星上存储容量 GB
                double intervalT = double.Parse(SatFea.get_Value(11).ToString()); //开机间隔时间 秒
                double staT = double.Parse(SatFea.get_Value(12).ToString()); //侧摆之后稳定时间 秒


                List<int> subFIDList = satRTFIDlist[i].subTaskFID;//当前资源能够观测到的元任务list集合
                List<ConflictTFID> ConTFID = satRTFIDlist[i].ConflictTaskFID;//当前资源能够观测的元任务的冲突集合
                List<double> ConRatelist = new List<double>(new double[subFIDList.Count]);//元任务冲突率 每一个资源相对于每一个元任务 list长度为观测元任务个数
                List<double> ConDgreelist = new List<double>(new double[subFIDList.Count]);//元任务冲突率
                List<double> ConLeftElist = new List<double>(new double[subFIDList.Count]);//元任务冲突剩余能力 存储冲突之后能够观测的当前任务的面积s之和 （所有冲突之后的面积之和S1+S2+...+Sjm） （不是概率p）
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
                        conIndSum = conIndSum + conTWeight / (conTWeight + lstTaskFC[subTFID].subTWeight) + conTArea / (conTArea + lstTaskFC[subTFID].subTArea) + (1 - conTLevel / (conTLevel + (double)lstTaskFC[subTFID].CoverL));
                    }
                    ConDgreelist[j] = conIndSum / ((double)3 * ConflictsubTfid.Count);//冲突度 -------------------------------------------------------------------------------------
                    double subTleftArea = 0;//当前元任务所有冲突剩余面积之和
                    //卫星一旦冲突即不观测冲突任务，所以剩余能力为0
                    #region 卫星一旦冲突即不观测 冲突任务 
                    //for (int l = 0; l < ConflictsubTfid.Count; l++)
                    //{
                    //    int ConsubTFID = ConflictsubTfid[l];//与当前元任务冲突的元任务FID

                    //    IFeature subTSATTask = SatFeLayer.FeatureClass.GetFeature(subTFID);//获取当前元任务要素
                    //    IFeature conTSATTask = SatFeLayer.FeatureClass.GetFeature(ConsubTFID);//获取冲突任务要素
                    //    string subTTaskStime = subTSATTask.get_Value(10).ToString();//获取当前元任务的开始观测时间
                    //    string subTTaskEtime = subTSATTask.get_Value(11).ToString();//获取当前元任务的结束观测时间
                    //    string conTaskStime = conTSATTask.get_Value(10).ToString();//获取冲突任务的开始观测时间
                    //    string conTaskEtime = conTSATTask.get_Value(11).ToString();//获取冲突任务的结束观测时间
                    //    double subAngel = double.Parse(subTSATTask.get_Value(12).ToString());//获取当前元任务的侧摆角 度
                    //    double conAngel = double.Parse(conTSATTask.get_Value(12).ToString());//获取冲突任务的侧摆角 
                    //    double subStore = double.Parse(subTSATTask.get_Value(14).ToString());//
                    //    double conStore = double.Parse(conTSATTask.get_Value(14).ToString());//获取冲突任务的需要容量 G

                    //    //确定时间
                    //    int firstTShour = 0;//当前元任务的开始观测时间 小时
                    //    double firstTSmin = 0;//当前元任务的开始观测时间 分钟
                    //    int firstTEhour = 0;//当前元任务的结束观测时间 小时
                    //    double firstTEmin = 0;//当前元任务的结束观测时间 分钟
                    //    int secondTShour = 0;//冲突任务的开始观测时间 小时
                    //    double secondTSmin = 0;//冲突任务的开始观测时间 分钟
                    //    int secondTEhour = 0;//冲突任务的结束观测时间 小时
                    //    double secondTEmin = 0;//冲突任务的结束观测时间 分钟
                    //    //时间确定 
                    //    #region 确定时间
                    //    if (subTTaskStime.Contains("."))
                    //    {
                    //        if (subTTaskStime.Contains("."))
                    //        {
                    //            string HourAndMin = subTTaskStime.Substring(0, subTTaskStime.IndexOf("."));
                    //            if (HourAndMin.Length > 3)
                    //            {
                    //                firstTShour = int.Parse(HourAndMin.Substring(0, 2));//第一个任务开始观测时间  小时                 
                    //            }
                    //            else
                    //            {
                    //                firstTShour = int.Parse(HourAndMin.Substring(0, 1));//
                    //            }
                    //            firstTSmin = double.Parse(HourAndMin.Substring(HourAndMin.Length - 2, 2) + subTTaskStime.Substring(subTTaskStime.IndexOf(".")));//第一个任务开始观测时间  分钟  
                    //        }
                    //        else
                    //        {
                    //            if (subTTaskStime.Length > 3)
                    //            {
                    //                firstTShour = int.Parse(subTTaskStime.Substring(0, 2));// 
                    //            }
                    //            else
                    //            {
                    //                firstTShour = int.Parse(subTTaskStime.Substring(0, 1));//
                    //            }
                    //            firstTSmin = int.Parse(subTTaskStime.Substring(subTTaskStime.Length - 2, 2));//
                    //        }
                    //    }
                    //    /////////////////
                    //    if (subTTaskEtime.Contains("."))
                    //    {
                    //        if (subTTaskEtime.Contains("."))
                    //        {
                    //            string HourAndMin = subTTaskEtime.Substring(0, subTTaskEtime.IndexOf("."));
                    //            if (HourAndMin.Length > 3)
                    //            {
                    //                firstTEhour = int.Parse(HourAndMin.Substring(0, 2));//第一个任务开始观测时间  小时                 
                    //            }
                    //            else
                    //            {
                    //                firstTEhour = int.Parse(HourAndMin.Substring(0, 1));//
                    //            }
                    //            firstTSmin = double.Parse(HourAndMin.Substring(HourAndMin.Length - 2, 2) + subTTaskEtime.Substring(subTTaskEtime.IndexOf(".")));//第一个任务开始观测时间  分钟  
                    //        }
                    //        else
                    //        {
                    //            if (subTTaskEtime.Length > 3)
                    //            {
                    //                firstTEhour = int.Parse(subTTaskEtime.Substring(0, 2));// 
                    //            }
                    //            else
                    //            {
                    //                firstTEhour = int.Parse(subTTaskEtime.Substring(0, 1));//
                    //            }
                    //            firstTEmin = int.Parse(subTTaskEtime.Substring(subTTaskEtime.Length - 2, 2));//
                    //        }
                    //    }
                    //    /////////////////
                    //    if (conTaskStime.Contains("."))
                    //    {
                    //        if (conTaskStime.Contains("."))
                    //        {
                    //            string HourAndMin = conTaskStime.Substring(0, conTaskStime.IndexOf("."));
                    //            if (HourAndMin.Length > 3)
                    //            {
                    //                secondTShour = int.Parse(HourAndMin.Substring(0, 2));//第一个任务开始观测时间  小时                 
                    //            }
                    //            else
                    //            {
                    //                secondTShour = int.Parse(HourAndMin.Substring(0, 1));//
                    //            }
                    //            firstTSmin = double.Parse(HourAndMin.Substring(HourAndMin.Length - 2, 2) + conTaskStime.Substring(conTaskStime.IndexOf(".")));//第一个任务开始观测时间  分钟  
                    //        }
                    //        else
                    //        {
                    //            if (conTaskStime.Length > 3)
                    //            {
                    //                secondTShour = int.Parse(conTaskStime.Substring(0, 2));// 
                    //            }
                    //            else
                    //            {
                    //                secondTShour = int.Parse(conTaskStime.Substring(0, 1));//
                    //            }
                    //            secondTSmin = int.Parse(conTaskStime.Substring(conTaskStime.Length - 2, 2));//
                    //        }
                    //    }
                    //    /////////////////
                    //    if (conTaskEtime.Contains("."))
                    //    {
                    //        if (conTaskEtime.Contains("."))
                    //        {
                    //            string HourAndMin = conTaskEtime.Substring(0, conTaskEtime.IndexOf("."));
                    //            if (HourAndMin.Length > 3)
                    //            {
                    //                secondTEhour = int.Parse(HourAndMin.Substring(0, 2));//第一个任务开始观测时间  小时                 
                    //            }
                    //            else
                    //            {
                    //                secondTEhour = int.Parse(HourAndMin.Substring(0, 1));//
                    //            }
                    //            firstTSmin = double.Parse(HourAndMin.Substring(HourAndMin.Length - 2, 2) + conTaskEtime.Substring(conTaskEtime.IndexOf(".")));//第一个任务开始观测时间  分钟  
                    //        }
                    //        else
                    //        {
                    //            if (conTaskEtime.Length > 3)
                    //            {
                    //                secondTEhour = int.Parse(conTaskEtime.Substring(0, 2));// 
                    //            }
                    //            else
                    //            {
                    //                secondTEhour = int.Parse(conTaskEtime.Substring(0, 1));//
                    //            }
                    //            secondTEmin = int.Parse(conTaskEtime.Substring(conTaskEtime.Length - 2, 2));//
                    //        }
                    //    }
                    //    #endregion


                    //    if ((firstTShour * 60 + firstTSmin) < (secondTShour * 60 + secondTSmin))//当前任务先执行 冲突任务后执行  SThour;//开始观测时间 小时 STmin;//开始观测时间 分钟
                    //    {
                    //        double subTendTime = secondTShour * 3600 + secondTSmin * 60 - (Math.Abs(subAngel - conAngel) / Vengel + intervalT + staT); //冲突发生后当前任务的结束观测时间  秒 不是时间点
                    //        //用STK判断在冲突之后的时间窗口内能观察的 当前元任务的面积 ，这里假设根据剩余时间推算
                    //        double subTleftTime = subTendTime - (firstTEhour * 3600 + firstTEmin * 60);//当前任务剩余观测时间




                    //        if (AreaRate > 0)
                    //        {
                    //            subTleftArea = subTleftArea + AreaRate * lstTaskFC[subTFID].subTArea;
                    //        }
                    //        else
                    //        { }
                    //    }
                    //    else//冲突任务先执行 当前任务后执行
                    //    {

                    //    }


                    //} 
                    #endregion

                    ConLeftElist[j] = subTleftArea;

                }
                satRTFIDlist[i].conRate = ConRatelist;
                satRTFIDlist[i].conDegree = ConDgreelist;
                satRTFIDlist[i].leftEn = ConLeftElist;
            }

            #endregion
            #endregion

        }







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
        #endregion


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
        #region 公共函数
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
                double sth = TaskArea * 0.01;//面积阈值 定义？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？

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
                } while ((Uarea.Area > TaskArea + sth || Uarea.Area < TaskArea - sth) && k < 10);

                //Radius = TaskArea;
                return Radius;
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误：" + ex.Message);
                return -1;
            }
        }

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
        public string TFID { get; set; }
        public IFeatureLayer RtoTFL { get; set; }
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
    /// 一个资源观测一个任务所花费时间 
    /// </summary>
    public class R_TFIDtime
    {
        public int RFID { get; set; }
        public int TFID { get; set; }
        public double time { get; set; }
    }
    #endregion
}
