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

        /// <summary>
        /// 任务分解 子任务生成
        /// 输入为卫星、无人机、飞艇、车的图层序号
        /// </summary>
        public static void taskDis(int satLayNO, int UAVLayNO, int ASLayNO, int CarLayNO, int PolygonTaskNO)
        {
            string tStart = "0700";//开始观测时间 格式4位数 前两位小时 后两位分钟
            double conRadixi = 0.7;//半径折损系数 与数据属性表中半径属性一致
            IMapLayers mapLayers = Program.myMap.Map as IMapLayers;//IFeatureLayer pFeatureLayer;
            ILayer layer;
            IList<R_TInfo> RTinfoList = new List<R_TInfo>();
            DeleteFolder(System.AppDomain.CurrentDomain.BaseDirectory + "Data\\cache");//删除cache下所有文件  
            //卫星 无人机 飞艇 测量车覆盖面路径（缓冲区路径）
            layer = mapLayers.get_Layer(UAVLayNO);
            IFeatureLayer UAVFeatureLayer = (IFeatureLayer)layer;
            string BufferPath = System.AppDomain.CurrentDomain.BaseDirectory + "Data\\cache\\" + layer.Name + "BF.shp";


            string distan = UAVFeatureLayer.FeatureClass.Fields.get_Field(6).Name.ToString();//获取续航半径字段 第6个字段
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
                    R_TInfo Rinfo = new R_TInfo() { ResouceID = Feature.get_Value(2).ToString(), TaskID = pFeature.get_Value(2).ToString() };
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
            string Mileage;//无人机续航里程
            string Vuav;//无人机续航速度 km/h
            string TsakWinS;//任务时间窗口开始时间 格式4位数 前两位小时 后两位分钟
            string TaskWinE;//任务时间窗口结束时间 格式4位数 前两位小时 后两位分钟
            int TWEhour;//任务时间窗口结束时间 小时
            int TWEmin;//任务时间窗口结束时间 分钟
            int SThour;//开始观测时间 小时
            int STmin;//开始观测时间 分钟
            double urad;//每一个UAV相对于每一个任务的观测半径           
            List<IFeatureLayer> lstFC = new List<IFeatureLayer>();//存储每个无人机相对于每个任务的时间观测区域要素图层
            for (int i = 0; i < RTinfoList.Count; i++)
            {


                //IFeature Uavf = UAVlayer.FeatureClass.GetFeature(int.Parse(RTinfoList[i].ResouceID) - 1);
                seleceUavPath = System.AppDomain.CurrentDomain.BaseDirectory + "Data\\cache\\" + i + UAVlayer.Name + "sl.shp";
                GPselectTool(UAVlayer, seleceUavPath, int.Parse(RTinfoList[i].ResouceID));//选出单个无人机 以便根据具体任务区构建缓冲区
                selTaskPath = System.AppDomain.CurrentDomain.BaseDirectory + "Data\\cache\\" + i + ptaskFeatureLayer.Name + "sl.shp";
                GPselectTool(ptaskFeatureLayer, selTaskPath, int.Parse(RTinfoList[i].TaskID));//选出单个无人机 以便根据具体任务区构建缓冲区
                UavEveryLayer = OpenFile_LayerFile(seleceUavPath);// mapLayers.get_Layer(0) as FeatureLayer;
                TaskEveryLayer = OpenFile_LayerFile(selTaskPath);


                UavToTaskpath = System.AppDomain.CurrentDomain.BaseDirectory + "Data\\cache\\" + UavEveryLayer.Name + "BF.shp";
                //计算在当前无人机和当前任务时间约束下的 无人机半径
                //string Mileage=UAVlayer.FeatureClass.Fields.get_Field(int.Parse(RTinfoList[i].ResouceID);
                //通过Ifeature获取属性值 http://blog.163.com/song_zhuyue/blog/static/17343278720101074524281/  http://blog.sina.com.cn/s/blog_84f7fbbb0101975m.html                 
                //pFeatureCursor = UavEveryLayer.FeatureClass.Search(null, false);
                //pFeature= pFeatureCursor.NextFeature();
                UavEveryFeature = UavEveryLayer.FeatureClass.GetFeature(0);
                TaskEveryFeature = TaskEveryLayer.FeatureClass.GetFeature(0);
                Mileage = UavEveryFeature.get_Value(7).ToString();
                Vuav = UavEveryFeature.get_Value(5).ToString();
                TsakWinS = TaskEveryFeature.get_Value(4).ToString();
                TaskWinE = TaskEveryFeature.get_Value(5).ToString();
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
                double SinMaxT = int.Parse(Mileage) / (2 * int.Parse(Vuav) * 0.2777778) / 60; //最远单程飞行时间 分钟
                if (int.Parse(tStart) < int.Parse(TaskWinE))//保证开始观测时间（无人机出发时间）小于任务结束时间
                {
                    if (TWEhour * 60 + TWEmin - SinMaxT - (SThour * 60 + STmin) > 0)
                    {
                        urad = double.Parse(Mileage);
                    }
                    else
                        urad = (TWEhour * 60 + TWEmin - (SThour * 60 + STmin)) * 60 * double.Parse(Vuav) * 3.6;
                }
                else
                { urad = 0; }
                //-----------------------------------------------以上是可覆盖半径 实际观测半径如下（折损系数）----------------------------------------------------------------------------------------
                urad = urad / 2 * conRadixi;//实际观测半径
                //根据当前无人机和当前任务时间约束下的 无人机半径 构建缓冲区
                GPBufferTool((ILayer)UavEveryLayer, UavToTaskpath, urad.ToString());
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
                lstFC.Add(UavToTTrueObe);
            }
            //将无人机观测到任务的实际区域交叉分割 形成最终的子任务   每一次叠加操作 都要更新每个任务的观测资源集
            string UavToTasdfkUnionPath ;
            IFeatureLayer replaceLayer = lstFC[0];
            List<IFeatureLayer> lstTWOFC = new List<IFeatureLayer>();//Union工具只能输入两个图层 以后可修改
            for (int i =1; i < lstFC.Count; i++)
            {
                UavToTasdfkUnionPath = System.AppDomain.CurrentDomain.BaseDirectory + "Data\\cache\\"+i.ToString() + "UToTaUni.shp";
                lstTWOFC.Add(replaceLayer);
                lstTWOFC.Add(lstFC[i]);
                GPUnionTool(lstTWOFC, UavToTasdfkUnionPath);
                replaceLayer = OpenFile_LayerFile(UavToTasdfkUnionPath);
                lstTWOFC.Clear();
                if (i == lstFC.Count - 1)
                {
                    Program.myMap.AddLayer(replaceLayer as ILayer, 0);
                    //OpenShape(UavToTasdfkUnionPath);//如果在图层上显示 PolygonTaskNO等图层NO要+1 //////////////////////////////////////////////////////////////////////////////////////////
                }
            }

           

           // OpenShape(UavToTasdfkUnionPath);//如果在图层上显示 PolygonTaskNO等图层NO要+1 //////////////////////////////////////////////////////////////////////////////////////////
            Program.myMap.Refresh();
            //地图缩放到阿克苏地区
            ILayer akesulayer = PRV_GetLayersByName("AkesuCity");
            IFeatureLayer ss = akesulayer as FeatureLayer;
            IFeature Akesu = ss.FeatureClass.GetFeature(0) as IFeature;
            Program.myMap.Extent = Akesu.Shape.Envelope;// Program.myMap.FullExtent;
            Program.myMap.Refresh();
            Program.myMap.Update();

            //IEnumFeature pEnumFeature = UAVbuFeatureLayer as IEnumFeature;
            //IEnumFeature pEnumFeature = Program.myMap.Map.FeatureSelection as IEnumFeature;
            //IEnumFeatureSetup pEnumFeatureSetup = pEnumFeature as IEnumFeatureSetup;
            //pEnumFeatureSetup.AllFields = true;
            //IFeature Feature = pEnumFeature.Next();







            //int ss = pFeatureLayer.FeatureClass.Indexes;
            //for (int Ti = 1; Ti < pFeatureLayer.FeatureClass.FeatureCount; Ti++)
            //    pFeatureLayerDefinition.DefinitionExpression = "Id=" + i;//"FID<10";
            //pActiveView.Refresh();
            //IQueryFilter pQueryFilter = new QueryFilterClass();
            //pQueryFilter.WhereClause = "AREA<10";
            //IFeatureSelection pFeatureSelection = (IFeatureSelection)pFeatureLayer;
            //pFeatureSelection.SelectFeatures(pQueryFilter, esriSelectionResultEnum.esriSelectionResultNew, false);
            //pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphicSelection, null, null);
            //IFeatureLayer pNew = pFeatureLayerDefinition.CreateSelectionLayer("new", true, null, null);
            //pFeatureSelection.Clear();
            //pMap.AddLayer(pNew);
            //MessageBox.Show(Convert.ToString(pMap.LayerCount));








            // layer = mapLayers.get_Layer(satLayNO);
            //GPBufferTool(PRV_GetLayersByName(layer.Name), BufferPath, 5000);
            //layer = mapLayers.get_Layer(UAVLayNO + 1);
            //BufferPath = System.AppDomain.CurrentDomain.BaseDirectory + "Data\\cache\\" + layer.Name + "BF.shp";
            //GPBufferTool(PRV_GetLayersByName(layer.Name), BufferPath, 5000);
            //layer = mapLayers.get_Layer(ASLayNO + 2);
            //BufferPath = System.AppDomain.CurrentDomain.BaseDirectory + "Data\\cache\\" + layer.Name + "BF.shp";
            //GPBufferTool(PRV_GetLayersByName(layer.Name), BufferPath, 5000);
            //layer = mapLayers.get_Layer(CarLayNO +3);
            //BufferPath = System.AppDomain.CurrentDomain.BaseDirectory + "Data\\cache\\" + mapLayers.get_Layer(CarLayNO+3).Name + "BF.shp";
            //GPBufferTool(PRV_GetLayersByName(layer.Name), BufferPath, 5000);


        }

        /// <summary>
        /// 测试 可删
        /// </summary>
        /// <param name="satLayNO"></param>
        /// <param name="UAVLayNO"></param>
        /// <param name="ASLayNO"></param>
        /// <param name="CarLayNO"></param>
        /// <param name="PolygonTaskNO"></param>
        public static void delete(int satLayNO, int UAVLayNO, int ASLayNO, int CarLayNO, int PolygonTaskNO)
        {
            IMapLayers mapLayers = Program.myMap.Map as IMapLayers;//IFeatureLayer pFeatureLayer;
            ILayer layer;
            ILayer la2;
            //IWorkspaceFactory pWorkspaceFactory;
            //IFeatureWorkspace pFeatureWorkspace;
            //pWorkspaceFactory = (IWorkspaceFactory)(new ShapefileWorkspaceFactory());
            ////注意此处的路径是不能带文件名的
            //string datapath = System.AppDomain.CurrentDomain.BaseDirectory + "Data";
            //string sWorkPath;
            //pFeatureWorkspace = pWorkspaceFactory.OpenFromFile(datapath, 0) as IFeatureWorkspace;


            //IWorkspace sWordkPath = pFeatureWorkspace as IWorkspace;
            //sWorkPath = sWordkPath.PathName;


            DeleteFolder(System.AppDomain.CurrentDomain.BaseDirectory + "Data\\cache");//删除cache下所有文件  
            //卫星 无人机 飞艇 测量车覆盖面路径（缓冲区路径）
            layer = mapLayers.get_Layer(8);
            la2 = mapLayers.get_Layer(12);
            IFeatureLayer UAVFeatureLayer = (IFeatureLayer)layer;
            IFeatureLayer FeatureLayer = (IFeatureLayer)la2;
            string BufferPath = System.AppDomain.CurrentDomain.BaseDirectory + "Data\\cache\\" + layer.Name + "BF.shp";

            GPIntersectTool(UAVFeatureLayer.FeatureClass, FeatureLayer.FeatureClass, BufferPath);
            OpenShape(BufferPath);//如果在图层上显示 PolygonTaskNO等图层NO要+1 //////////////////////////////////////////////////////////////////////////////////////////
            Program.myMap.Refresh();
        }
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    IMap pMap = axMapControl1.ActiveView.FocusMap;
        //    IActiveView pActiveView = axMapControl1.ActiveView;
        //    IFeatureLayer pFeatureLayer = (IFeatureLayer)pMap.get_Layer(0);
        //    IFeatureLayerDefinition pFeatureLayerDefinition = (IFeatureLayerDefinition)pFeatureLayer;
        //    pFeatureLayerDefinition.DefinitionExpression = "FID<10";
        //    pActiveView.Refresh();
        //    IQueryFilter pQueryFilter = new QueryFilterClass();
        //    pQueryFilter.WhereClause = "AREA<10";
        //    IFeatureSelection pFeatureSelection = (IFeatureSelection)pFeatureLayer;
        //    pFeatureSelection.SelectFeatures(pQueryFilter, esriSelectionResultEnum.esriSelectionResultNew, false);
        //    pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphicSelection, null, null);
        //    IFeatureLayer pNew = pFeatureLayerDefinition.CreateSelectionLayer("new", true, null, null);
        //    pFeatureSelection.Clear();
        //    pMap.AddLayer(pNew);
        //    MessageBox.Show(Convert.ToString(pMap.LayerCount));
        //}

        private static void GPBufferTool(ILayer in_features, string out_features, string distance)
        {


            try
            {
                // Initialize the Geoprocessor 
                Geoprocessor GP = new Geoprocessor();

                // Initialize the MakeFeatureLayer tool
                ESRI.ArcGIS.AnalysisTools.Buffer buffertool = new ESRI.ArcGIS.AnalysisTools.Buffer();

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

        private static void GPselectTool(IFeatureLayer in_features, string out_features, int idvalue)
        {


            try
            {
                // Initialize the Geoprocessor 
                Geoprocessor GP = new Geoprocessor();

                // Initialize the MakeFeatureLayer tool
                ESRI.ArcGIS.AnalysisTools.Select selecetool = new ESRI.ArcGIS.AnalysisTools.Select();

                selecetool.in_features = in_features; //根据图层名称获取图层 System.AppDomain.CurrentDomain.BaseDirectory + "Data\\Car.shp"; //
                selecetool.out_feature_class = out_features; //@"E\test.gdb\road_bf30"; //
                selecetool.where_clause = "id=" + idvalue;
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
        private static void ReturnMessages(Geoprocessor gp)
        {
            if (gp.MessageCount > 0)
            {
                for (int Count = 0; Count <= gp.MessageCount - 1; Count++)
                {
                    Console.WriteLine(gp.GetMessage(Count));
                }
            }

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
    /// 资源_任务ID对应关系 
    /// </summary>
    public class R_TInfo
    {
        public string ResouceID { get; set; }
        public string TaskID { get; set; }

    }
    #endregion
}
