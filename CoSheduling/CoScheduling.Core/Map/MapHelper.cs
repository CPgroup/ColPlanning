using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.DataSourcesRaster;
using System.Drawing;
using ESRI.ArcGIS.NetworkAnalyst;
using ESRI.ArcGIS.NetworkAnalysis;
using ESRI.ArcGIS.DataSourcesGDB;

namespace CoScheduling.Core.Map
{
    /// <summary>
    /// 类名：地图助手类
    /// 作者：李光强
    /// 时间：2013.11.12.
    /// 版本：V1.0
    /// </summary>
    public class MapHelper
    {
        ESRI.ArcGIS.Controls.AxMapControl mapControl;
        /// <summary>
        /// 地图控件
        /// </summary>
        public ESRI.ArcGIS.Controls.AxMapControl MapControl
        {
            get { return mapControl; }
            set { mapControl = value; }
        }

        public MapHelper() { }

        public MapHelper(ESRI.ArcGIS.Controls.AxMapControl pMapCtrl)
        {
            this.mapControl = pMapCtrl;
        }

        #region 全局变量
        IMapDocument pMapDcument;
        IMapDocument pDcument;
        #endregion

        /// <summary>
        /// 设置地图初始化范围
        /// </summary>
        public void InitExtent()
        {
            Core.Generic.myXML xml = new Core.Generic.myXML(System.Windows.Forms.Application.StartupPath + "\\Setting.xml");
            try
            {
                float xmin, ymin, xmax, ymax;
                float.TryParse(xml.GetElement("InitExtent", "Xmin"), out xmin);
                float.TryParse(xml.GetElement("InitExtent", "Ymin"), out ymin);
                float.TryParse(xml.GetElement("InitExtent", "Xmax"), out xmax);
                float.TryParse(xml.GetElement("InitExtent", "Ymax"), out ymax);
                IEnvelope env = new Envelope() as IEnvelope;
                env.XMin = xmin;
                env.YMin = ymin;
                env.XMax = xmax;
                env.YMax = ymax;
                //mapControl.Extent = mapControl.FullExtent;
                this.mapControl.Extent = env;
                this.mapControl.Refresh();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                xml = null;
            }
        }

        /// <summary>
        /// 加载地图服务
        /// </summary>
        public void LoadMapService()
        {
            Core.Generic.myXML xml = new Core.Generic.myXML(System.Windows.Forms.Application.StartupPath + "\\Setting.xml");
            try
            {
                int serviceCount;
                int.TryParse(xml.GetElement("MapServices", "Count"), out serviceCount);
                string url;
                for (int i = 0; i < serviceCount; i++)
                {
                    url = xml.GetElement("MapServices", "URL" + i);
                    LoadMapService(url);
                }
                this.mapControl.Refresh();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                xml = null;
            }
        }

        /// <summary>
        /// 加载地图服务
        /// </summary>
        /// <param name="RestURL"></param>
        public void LoadMapService(string RestURL)
        {
            try
            {
                IMapServerRESTLayer pRestLayer;
                pRestLayer = new MapServerRESTLayer();
                pRestLayer.Connect(RestURL);
                this.mapControl.AddLayer(pRestLayer as ILayer);
                IMap pMap = this.mapControl.ActiveView.FocusMap;
                this.mapControl.Refresh();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// 加载网络数据集
        /// </summary>
        public void LoadNetWorkDataSet()
        {
            Core.Generic.myXML xml = new Core.Generic.myXML(System.Windows.Forms.Application.StartupPath + "\\Setting.xml");
            pMapDcument = new MapDocumentClass();
            try
            {
                string NetWorkData = xml.GetElement("MapDocument", "RoadNetData");
                //将数据载入pMapDocument并与map控件联系起来
                NetWorkData = System.Windows.Forms.Application.StartupPath + NetWorkData;
                pMapDcument.Open(NetWorkData, "");

                int i;
                for (i = 0; i <= pMapDcument.MapCount - 1; i++)
                {
                    //一个IMapDocument对象中可能有多个Map对象，遍历每个map对象
                    mapControl.Map = pMapDcument.get_Map(i);

                }
                mapControl.Refresh();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                xml = null;
            }
        }

        /// <summary>
        /// 获取网络数据集
        /// </summary>
        /// <param name="pFeatureClass"></param>
        public void getNetWorkData(ref IFeatureClass pFeatureClass)
        {
            Core.Generic.myXML xml = new Core.Generic.myXML(System.Windows.Forms.Application.StartupPath + "\\Setting.xml");
            pMapDcument = new MapDocumentClass();
            IFeatureLayer pFeatureLayer;
            try
            {
                string NetWorkData = xml.GetElement("MapDocument", "RoadNetData");
                //将数据载入pMapDocument并与map控件联系起来
                NetWorkData = System.Windows.Forms.Application.StartupPath + NetWorkData;
                pMapDcument.Open(NetWorkData, "");

                for (int index = 0; index < pMapDcument.get_Map(0).LayerCount; index++)
                {
                    if (pMapDcument.get_Map(0).get_Layer(index).Name == "实验区路网数据")
                    {
                        pFeatureLayer = pMapDcument.get_Map(0).get_Layer(index) as IFeatureLayer;
                        pFeatureClass = pFeatureLayer.FeatureClass;
                    }
                    else
                        continue;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                xml = null;
            }
        }


        /// <summary>
        /// 最短路径分析
        /// </summary>
        /// <param name="StrGDB"> 数据库的存储路径</param>
        /// <param name="DatasetName">数据集名称</param>
        /// <param name="NetSetIndex"></param>
        public void miniDis(string StrGDB, string DatasetName, int pCount, IMap pMap, IPoint pEdgePoint)
        {
            //第一步：打开几何网络数据集。IWorkspaceFactory

            //IWorkspaceFactory pWF = new FileGDBWorkspaceFactoryClass(); // = new filegd// FileGDBWorkspaceFactoryClass();
            //IWorkspace pW = pWF.OpenFromFile(StrGDB, 0);
            //IFeatureDataset pFeaDataset = (pW as IFeatureWorkspace).OpenFeatureDataset(DatasetName);//RoadDataset数据集名称
            //INetworkCollection pNetColl = pFeaDataset as INetworkCollection; //获取数据库中的网络数据集
            //IGeometricNetwork pGeometricNet = pNetColl.get_GeometricNetwork(0);//由于数据集中只有一个网络数据集，因此获取第一个
            ////第二步：建立节点的旗帜            
            //int intJunctionUserClassID;
            //int intJunctionUserID;
            //int intJunctionUserSubID;
            //int intJunctionID;
            //IPoint pFoundJunctionPoint;
            ////ITraceFlowSolverGEN这个接口是几何网络分析中的重要接口，大部分的功能都是由此接口完成，现在需要获取逻辑网络，对逻辑网络进行设置。
            //ITraceFlowSolverGEN pTraceFlowSolverG = new TraceFlowSolverClass() as ITraceFlowSolverGEN;
            //INetSolver pNetSolver = pTraceFlowSolverG as INetSolver;
            //INetwork pNetWork = pGeometricNet.Network;
            //pNetSolver.SourceNetwork = pNetWork;
            //INetElements pNetElements = pNetWork as INetElements;
            ////int pCount = pCollection.PointCount;//获取输入点的个数，来建立旗帜的数组
            //IJunctionFlag[] pJunctionFlag = new JunctionFlagClass[pCount];
            //IPointToEID pPointToEID = new PointToEIDClass();
            //pPointToEID.SourceMap = pMap;
            //pPointToEID.GeometricNetwork = pGeometricNet;
            //pPointToEID.SnapTolerance = 0.01;//容差
            ////第三  获取节点的旗帜

            //for (int i = 0; i < pCount; i++)
            //{

            //    INetFlag pNetFlag = new JunctionFlagClass() as INetFlag;

            //    //IPoint pEdgePoint = _pPoints.get_Point(i); //查找输入点的最近的节点
            //    IPoint pFoundEdgePoint;//距离输入点最近的连接点的位置
            //    int intEdgeID;//距离输入点最近的连接点的id
            //    pPointToEID.GetNearestJunction(pEdgePoint, out intEdgeID, out pFoundEdgePoint);
            //    int intEdgeUserClassID, intEdgeUserID, intEdgeUserSubID;
            //    pNetElements.QueryIDs(intEdgeID, esriElementType.esriETJunction, out intEdgeUserClassID, out intEdgeUserID, out intEdgeUserSubID);

            //    pNetFlag.UserClassID = intEdgeUserClassID;
            //    pNetFlag.UserID = intEdgeUserID;
            //    pNetFlag.UserSubID = intEdgeUserSubID;

            //    IJunctionFlag pJuncF = (IJunctionFlag)(pNetFlag as IJunctionFlag);
            //    pJunctionFlag[i] = pJuncF;
            //}

            //pTraceFlowSolverG.PutJunctionOrigins(ref pJunctionFlag);//设置开始节点

            ////第四 设置边线权重，也可以设置点的权重
            //INetSchema pNetSchema = pNetWork as INetSchema;
            //INetWeight pNetWeight = pNetSchema.get_WeightByName("Shape_Length");
            //INetSolverWeightsGEN pNetSolverWeightsG = pTraceFlowSolverG as INetSolverWeightsGEN;
            //pNetSolverWeightsG.FromToEdgeWeight = pNetWeight;//开始边线的权重   
            //pNetSolverWeightsG.ToFromEdgeWeight = pNetWeight;//终止边线的权重

            ////第五 获取边线和交汇点的集合
            //IEnumNetEID pEnumNetEID_Junctions;
            //IEnumNetEID pEnumNetEID_Edges;
            ////int EdgeCount;//边的条数 =pCount-1
            //object[] segmentCosts = new object[pCount - 1];
            //pTraceFlowSolverG.FindPath(esriFlowMethod.esriFMConnected, esriShortestPathObjFn.esriSPObjFnMinSum, out pEnumNetEID_Junctions, out pEnumNetEID_Edges, pCount - 1, ref segmentCosts);//pRes用来获取每条记录的权重数组
            ////第六 获取最短线路
            //Polyline pPolyline;
            //IGeometryCollection pGeometryCollection = pPolyline as IGeometryCollection;
            //ISpatialReference pSpatialReference = pMap.SpatialReference;
            //IEIDHelper pEIDHelper = new EIDHelperClass();

            //IGeometricNetwork _pGeometricNetwork;
            //pNetWork = _pGeometricNetwork.Network;

            //pEIDHelper.GeometricNetwork = _pGeometricNetwork;
            //pEIDHelper.OutputSpatialReference = pSpatialReference;
            //pEIDHelper.ReturnGeometries = true;
            //IEnumEIDInfo pEnumEIDInfo = pEIDHelper.CreateEnumEIDInfo(pEnumNetEID_Edges);
            //int Count = pEnumEIDInfo.Count;
            //pEnumEIDInfo.Reset();
            //for (int i = 0; i < Count; i++)
            //{
            //    IEIDInfo pEIDInfo = pEnumEIDInfo.Next();
            //    IGeometry pGeometry = pEIDInfo.Geometry;
            //    pGeometryCollection.AddGeometryCollection(pGeometry as IGeometryCollection);
            //}
        }

        ////几何网络
        //private IGeometricNetwork mGeometricNetwork;
        ////给定点的集合
        //private IPointCollection mPointCollection;
        ////获取给定点最近的Network元素
        //private IPointToEID mPointToEID;

        ////返回结果变量
        //private IEnumNetEID mEnumNetEID_Junctions;
        //private IEnumNetEID mEnumNetEID_Edges;
        //private double mdblPathCost;



        /// <summary>
        /// 实现路径分析 
        /// </summary>
        /// <param name="weightName">路径权重字段</param>
        public void SolvePath(string weightName, IGeometricNetwork mGeometricNetwork, IPointCollection mPointCollection, IPointToEID mPointToEID, out IEnumNetEID mEnumNetEID_Junctions, out IEnumNetEID mEnumNetEID_Edges, out double mdblPathCost)
        {
            //创建ITraceFlowSolverGEN
            ITraceFlowSolverGEN pTraceFlowSolverGEN = new TraceFlowSolverClass();
            INetSolver pNetSolver = pTraceFlowSolverGEN as INetSolver;
            //初始化用于路径计算的Network
            INetwork pNetWork = mGeometricNetwork.Network;
            pNetSolver.SourceNetwork = pNetWork;

            //获取分析经过的点的个数
            int intCount = mPointCollection.PointCount;
            if (intCount < 1)
            { MessageBox.Show("未获取到车辆点或目标点！"); }


            INetFlag pNetFlag;
            //用于存储路径计算得到的边
            IEdgeFlag[] pEdgeFlags = new IEdgeFlag[intCount];


            IPoint pEdgePoint = new PointClass();
            int intEdgeEID;
            IPoint pFoundEdgePoint;
            double dblEdgePercent;

            //用于获取几何网络元素的UserID, UserClassID,UserSubID
            INetElements pNetElements = pNetWork as INetElements;
            int intEdgeUserClassID;
            int intEdgeUserID;
            int intEdgeUserSubID;
            for (int i = 0; i < intCount; i++)
            {
                pNetFlag = new EdgeFlagClass();
                //获取用户点击点
                pEdgePoint = mPointCollection.get_Point(i);
                //获取距离用户点击点最近的边
                mPointToEID.GetNearestEdge(pEdgePoint, out intEdgeEID, out pFoundEdgePoint, out dblEdgePercent);
                if (intEdgeEID <= 0)
                    continue;
                //根据得到的边查询对应的几何网络中的元素UserID, UserClassID,UserSubID
                pNetElements.QueryIDs(intEdgeEID, esriElementType.esriETEdge,
                    out intEdgeUserClassID, out intEdgeUserID, out intEdgeUserSubID);
                if (intEdgeUserClassID <= 0 || intEdgeUserID <= 0)
                    continue;

                pNetFlag.UserClassID = intEdgeUserClassID;
                pNetFlag.UserID = intEdgeUserID;
                pNetFlag.UserSubID = intEdgeUserSubID;
                pEdgeFlags[i] = pNetFlag as IEdgeFlag;
            }
            //设置路径求解的边
            pTraceFlowSolverGEN.PutEdgeOrigins(ref pEdgeFlags);

            //路径计算权重
            INetSchema pNetSchema = pNetWork as INetSchema;
            INetWeight pNetWeight = pNetSchema.get_WeightByName(weightName);
            if (pNetWeight == null)
            { MessageBox.Show("权重设置有误！"); }

            //设置权重，这里双向的权重设为一致
            INetSolverWeights pNetSolverWeights = pTraceFlowSolverGEN as INetSolverWeights;
            pNetSolverWeights.ToFromEdgeWeight = pNetWeight;
            pNetSolverWeights.FromToEdgeWeight = pNetWeight;

            object[] arrResults = new object[intCount - 1];
            //执行路径计算
            pTraceFlowSolverGEN.FindPath(esriFlowMethod.esriFMConnected, esriShortestPathObjFn.esriSPObjFnMinSum,
                out mEnumNetEID_Junctions, out mEnumNetEID_Edges, intCount - 1, ref arrResults);

            //获取路径计算总代价（cost）
            mdblPathCost = 0;
            for (int i = 0; i < intCount - 1; i++)
                mdblPathCost += (double)arrResults[i];
        }



        /// <summary>
        /// 路径分析结果到几何要素的转换
        /// </summary>
        /// <param name="pMap">当前地图 获取空间参考</param>
        /// <returns></returns>
        public IPolyline PathToPolyLine(IMap pMap, IGeometricNetwork mGeometricNetwork, IEnumNetEID mEnumNetEID_Edges)
        {
            IPolyline pPolyLine = new PolylineClass();
            IGeometryCollection pNewGeometryCollection = pPolyLine as IGeometryCollection;
            if (mEnumNetEID_Edges == null)
                return null;

            IEIDHelper pEIDHelper = new EIDHelperClass();
            //获取几何网络
            pEIDHelper.GeometricNetwork = mGeometricNetwork;
            //获取地图空间参考
            ISpatialReference pSpatialReference = pMap.SpatialReference;
            pEIDHelper.OutputSpatialReference = pSpatialReference;
            pEIDHelper.ReturnGeometries = true;
            //根据边的ID获取边的信息
            IEnumEIDInfo pEnumEIDInfo = pEIDHelper.CreateEnumEIDInfo(mEnumNetEID_Edges);
            int intCount = pEnumEIDInfo.Count;
            pEnumEIDInfo.Reset();

            IEIDInfo pEIDInfo;
            IGeometry pGeometry;
            for (int i = 0; i < intCount; i++)
            {
                pEIDInfo = pEnumEIDInfo.Next();
                //获取边的几何要素
                pGeometry = pEIDInfo.Geometry;
                pNewGeometryCollection.AddGeometryCollection((IGeometryCollection)pGeometry);
            }
            return pPolyLine;
        }

        
        
        

        /// <summary>
        /// 打开mxd地图文档
        /// </summary>
        public void LoadMapDocument()
        {
            Core.Generic.myXML xml = new Core.Generic.myXML(System.Windows.Forms.Application.StartupPath + "\\Setting.xml");
            pDcument = new MapDocumentClass();
            try
            {
                string mxdData = xml.GetElement("MapDocument", "mxd");
                //将数据载入pDocument并与map控件联系起来
                mxdData = System.Windows.Forms.Application.StartupPath + mxdData;
                pDcument.Open(mxdData, "");
                //Load the same pre-authored map document into the MapControl.
                mapControl.LoadMxFile(mxdData, null, null);
                //Set the extent of the MapControl to the full extent of the data.
                mapControl.Extent = mapControl.FullExtent;

                //int i;
                //for (i = 0; i <= pDcument.MapCount - 1; i++)
                //{
                //    //一个IMapDocument对象中可能有多个Map对象，遍历每个map对象
                //    mapControl.Map = pDcument.get_Map(i);

                //}
                mapControl.Refresh();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                xml = null;
            }
        }

        /// <summary>
        /// 加载配置文件设置的DME文件
        /// </summary>
        public void LoadDEM()
        {
            Core.Generic.myXML xml = new Core.Generic.myXML(System.Windows.Forms.Application.StartupPath + "\\Setting.xml");
            try
            {
                int DEMCount;
                int.TryParse(xml.GetElement("RDEM", "Count"), out DEMCount);
                string shpFile;

                Program.SetProgressVal(0);
                Program.SetProgreeMax(DEMCount);

                for (int i = 0; i < DEMCount; i++)
                {
                    shpFile = xml.GetElement("RDEM", "Dem" + i);
                    if (shpFile.StartsWith("."))
                        shpFile = System.Windows.Forms.Application.StartupPath + shpFile.Substring(1);
                    if (System.IO.File.Exists(shpFile))
                    {
                        LoadDem(shpFile);
                    }
                    Program.SetProgressVal(i);
                }
                this.mapControl.Refresh();
                Program.SetProgressVal(DEMCount);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                xml = null;
            }
        }

        public void LoadDem(string shpFile)
        {

            string strFullPath = shpFile;
            if (strFullPath == "") return;
            int Index = strFullPath.LastIndexOf("\\");
            string filePath = strFullPath.Substring(0, Index);
            string fileName = strFullPath.Substring(Index + 1);
            IWorkspaceFactory pWSFact = new RasterWorkspaceFactoryClass();
            IWorkspace pWS = pWSFact.OpenFromFile(filePath, 0);
            IRasterWorkspace pRasterWorkspace1 = pWS as IRasterWorkspace;
            IRasterLayer pRasterLayer = new RasterLayerClass();
            try
            {
                IRasterDataset pRasterDataset = (IRasterDataset)pRasterWorkspace1.OpenRasterDataset(fileName);
                pRasterLayer.CreateFromDataset(pRasterDataset);
                ILayer pLayer = pRasterLayer as ILayer;
                pLayer.Name = pRasterLayer.Name;
                mapControl.Map.AddLayer(pLayer);
                mapControl.ActiveView.Refresh();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);

            }
        }

        /// <summary>
        /// 加载配置文件设置的SHP文件
        /// </summary>
        public void LoadShape()
        {
            Core.Generic.myXML xml = new Core.Generic.myXML(System.Windows.Forms.Application.StartupPath + "\\Setting.xml");
            try
            {
                int shpCount;
                int.TryParse(xml.GetElement("Shape", "Count"), out shpCount);
                string shpFile;

                Program.SetProgressVal(0);
                Program.SetProgreeMax(shpCount);

                for (int i = 0; i < shpCount; i++)
                {
                    shpFile = xml.GetElement("Shape", "Shp" + i);
                    if (shpFile.StartsWith("."))
                        shpFile = System.Windows.Forms.Application.StartupPath + shpFile.Substring(1);
                    if (System.IO.File.Exists(shpFile))
                    {
                        LoadShape(shpFile);
                    }
                    Program.SetProgressVal(i);
                }
                this.mapControl.Refresh();
                Program.SetProgressVal(shpCount);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                xml = null;
            }
        }

        public void LoadShape(string shpFile)
        {
            IWorkspaceFactory pWorkspaceFactory;
            IFeatureWorkspace pFeatureWorkspace;
            IFeatureLayer pFeatureLayer;

            try
            {
                string strFullPath = shpFile;
                if (strFullPath == "") return;
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
                mapControl.Map.AddLayer(pFeatureLayer);
                mapControl.ActiveView.Refresh();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                pWorkspaceFactory = null;
                pFeatureWorkspace = null;
                pFeatureLayer = null;
            }
        }

        /// <summary>
        /// 绘制图片
        /// </summary>
        /// <param name="ImagePath">图片路径</param>
        /// <param name="pEnv">绘制位置</param>
        public void DrawMarkerCircle(string ImagePath, IEnvelope pEnv)
        {
            object missing = Type.Missing;
            IActiveView pActiveView = mapControl.ActiveView as IActiveView;

            IElement pElement = GetPicture(ImagePath);
            IPictureElement pPictureElement;
            if (pElement is IPictureElement)
            {
                pPictureElement = pElement as IPictureElement;
                pPictureElement.MaintainAspectRatio = false;
                pPictureElement.SavePictureInDocument = true;
            }

            //图片的大小和显示位置可以通过修改pEnv的坐标来自己决定
            pElement.Geometry = pEnv as IGeometry;
            mapControl.ActiveView.GraphicsContainer.AddElement(pElement, 0);
            mapControl.Refresh(esriViewDrawPhase.esriViewBackground, missing, missing);
        }

        /// <summary>
        /// 读取图片并返回Element
        /// </summary>
        /// <param name="sPath"></param>
        /// <returns></returns>
        private IElement GetPicture(string sPath)
        {
            IRasterPicture pRasterPicture = new RasterPicture();
            IOlePictureElement pOlePicture = new BmpPictureElement() as IOlePictureElement;
            pOlePicture.ImportPicture(pRasterPicture.LoadPicture(sPath) as stdole.IPictureDisp);
            return pOlePicture as IElement;
        }

        /// <summary>
        /// 生成颜色
        /// </summary>
        /// <param name="R"></param>
        /// <param name="G"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public IColor GetColor(int R, int G, int B)
        {
            IRgbColor pRgbColor = new RgbColor();
            pRgbColor.Red = R;
            pRgbColor.Green = G;
            pRgbColor.Blue = B;
            return pRgbColor as IColor;
        }
        /// <summary>
        /// 生成点符号
        /// </summary>
        /// <param name="color"></param>
        /// <param name="width"></param>
        /// <param name="style"></param>
        /// <returns></returns>
        public ISymbol CreateSimpleSymbol(Color color, int size, esriSimpleMarkerStyle style)
        {
            ISimpleMarkerSymbol pMarkerSymbol = new SimpleMarkerSymbol(); ;
            IRgbColor pRgbColor = GetColor(color.R, color.G, color.B) as IRgbColor;
            pMarkerSymbol.Size = size;
            pMarkerSymbol.Color = pRgbColor;
            pMarkerSymbol.Style = style;
            return pMarkerSymbol as ISymbol;
        }
        /// <summary>
        /// 生成线符号
        /// </summary>
        /// <param name="color"></param>
        /// <param name="width"></param>
        /// <param name="style"></param>
        /// <returns></returns>
        public ISymbol CreateSimpleLineSymbol(Color color, int width, esriSimpleLineStyle style)
        {
            ISimpleLineSymbol pSimpleLineSymbol;
            pSimpleLineSymbol = new SimpleLineSymbol();
            pSimpleLineSymbol.Width = width;
            pSimpleLineSymbol.Color = GetColor(color.R, color.G, color.B);
            pSimpleLineSymbol.Style = style;
            return (ISymbol)pSimpleLineSymbol;

        }

        /// <summary>
        /// 生成面符号
        /// </summary>
        /// <param name="fillColor"></param>
        /// <param name="oLineWidth"></param>
        /// <param name="fillStyle"></param>
        /// <returns></returns>
        public ISymbol CreateSimpleFillSymbol(Color fillColor, int oLineWidth, esriSimpleFillStyle fillStyle)
        {
            ISimpleFillSymbol pSimpleFillSymbol;
            pSimpleFillSymbol = new SimpleFillSymbol();
            pSimpleFillSymbol.Style = fillStyle;
            pSimpleFillSymbol.Color = GetColor(fillColor.R, fillColor.G, fillColor.B);
            pSimpleFillSymbol.Outline = (ILineSymbol)CreateSimpleLineSymbol(fillColor, oLineWidth, esriSimpleLineStyle.esriSLSSolid);
            return (ISymbol)pSimpleFillSymbol;

        }

        /// <summary>
        /// 给多边形添加注记
        /// </summary>
        /// <param name="pGeometry"></param>
        /// <param name="pTextSymbol"></param>
        /// <param name="key"></param>
        public void AddTextElement(IGeometry pGeometry, ITextElement pTextElement, string key)
        {
            IActiveView pActiveView = mapControl.ActiveView;
            IGraphicsContainer pGraphicsContainer = pActiveView.GraphicsContainer;
            IEnvelope envelope = new EnvelopeClass();
            envelope = pGeometry.Envelope;
            IPoint pPoint = new PointClass();
            pPoint.PutCoords(envelope.XMin + envelope.Width * 0.5, envelope.YMin + envelope.Height * 0.5);
            IElement pElement = pTextElement as IElement;
            pElement.Geometry = pPoint;
            IElementProperties pElmentProperties = pElement as IElementProperties;
            pElmentProperties.Name = key;
            pGraphicsContainer.AddElement(pElement, 0);
        }

        /// <summary>
        /// 添加图元
        /// </summary>
        /// <param name="pGeometry"></param>
        /// <param name="pActiveView"></param>
        /// <param name="pSymbol"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public IElement AddElement(IGeometry pGeometry, ISymbol pSymbol, string key)
        {
            try
            {
                IActiveView pActiveView = mapControl.ActiveView;
                IGraphicsContainer pGraphicsContainer = pActiveView.GraphicsContainer;
                IElement pElement = null;
                ILineElement pLineElement = null;
                IFillShapeElement pFillShapeElement = null;
                IMarkerElement pMarkerElement = null;
                ICircleElement pCircleElement = null;
                IElementProperties pElmentProperties = null;
                switch (pGeometry.GeometryType)
                {

                    case esriGeometryType.esriGeometryEnvelope:
                        {
                            pElement = new RectangleElement();
                            pElement.Geometry = pGeometry;
                            pFillShapeElement = (IFillShapeElement)pElement;
                            pFillShapeElement.Symbol = (IFillSymbol)pSymbol;
                            break;
                        }
                    case esriGeometryType.esriGeometryPolyline:
                        {
                            pElement = new LineElement();
                            pElement.Geometry = pGeometry;
                            pLineElement = (ILineElement)pElement;
                            pLineElement.Symbol = (ILineSymbol)pSymbol;
                            break;
                        }
                    case esriGeometryType.esriGeometryLine:
                        {
                            pElement = new LineElement();
                            pElement.Geometry = pGeometry;

                            pLineElement = (ILineElement)pElement;
                            pLineElement.Symbol = (ILineSymbol)pSymbol;
                            break;
                        }
                    case esriGeometryType.esriGeometryPolygon:
                        {
                            pElement = new PolygonElement();
                            pElement.Geometry = pGeometry;
                            pFillShapeElement = (IFillShapeElement)pElement;

                            pFillShapeElement.Symbol = (IFillSymbol)pSymbol;
                            break;
                        }
                    case esriGeometryType.esriGeometryMultipoint:
                    case esriGeometryType.esriGeometryPoint:
                        {
                            pElement = new MarkerElement();
                            pElement.Geometry = pGeometry;

                            pMarkerElement = (IMarkerElement)pElement;

                            pMarkerElement.Symbol = (IMarkerSymbol)pSymbol;
                            break;
                        }
                    case esriGeometryType.esriGeometryCircularArc:
                        {
                            pElement = new CircleElement();
                            pElement.Geometry = pGeometry;

                            pCircleElement = (ICircleElement)pElement;
                            break;
                        }
                    default:
                        pElement = null;
                        break;
                }

                if (pElement != null)
                {
                    pElmentProperties = pElement as IElementProperties;
                    pElmentProperties.Name = key;
                    pGraphicsContainer.AddElement(pElement, 0);
                    pActiveView.PartialRefresh(esriViewDrawPhase.esriViewBackground, null, pGeometry.Envelope);
                    return pElement;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// 删除添加的图层
        /// </summary>
        public void ClearAddLayers()
        {
            ILayer layer;
            if (mapControl.LayerCount > 2)//2是初始化的图层个数
            {
                for (int i = 0; i < mapControl.LayerCount; i++)
                {
                    if (mapControl.get_Layer(i).Name != "" || mapControl.get_Layer(i).Name != "")
                    {
                        mapControl.DeleteLayer(i);
                    }
                }

            }

        }
        /// <summary>
        /// 清除所有图元素
        /// </summary>
        public void ClearAllElement()
        {
            IActiveView pActiveView = mapControl.ActiveView;
            IGraphicsContainer pGraphicsContainer = pActiveView.GraphicsContainer;
            pGraphicsContainer.DeleteAllElements();
        }

        /// <summary>
        /// 生成缓冲区
        /// </summary>
        /// <param name="pGeometry"></param>
        /// <returns></returns>
        public IPolygon GenerateBuffer(IGeometry pGeometry, float Radius)
        {
            IGraphicsContainer pGraphicsContainer = (ESRI.ArcGIS.Carto.IGraphicsContainer)this.mapControl.Map;

            ITopologicalOperator pTopoOp = default(ITopologicalOperator);
            //拓扑接口，用来根据选择的对象和输入的距离产生缓冲区
            IElement pElement = default(IElement);
            IGeometry geoBuffer = null;

            if ((pGeometry != null))
            {
                pTopoOp = pGeometry as ITopologicalOperator;
                IPolygonElement pPolygonElement = new PolygonElement() as IPolygonElement;
                //PolygonElement
                pElement = pPolygonElement as IElement;
                //Generate Buffer
                geoBuffer = pTopoOp.Buffer((double)Radius) as IGeometry;
                pElement.Geometry = geoBuffer;

                //Get the IRGBColor interface
                IRgbColor pColor = default(IRgbColor);
                pColor = new RgbColor();
                //Set the color properties
                pColor.RGB = 255;
                pColor.Transparency = 255;

                //Get the ILine symbol interface
                ILineSymbol pOutline = default(ILineSymbol);
                pOutline = new SimpleLineSymbol();
                //Set the line symbol properties
                pOutline.Width = 2;
                pOutline.Color = pColor;

                //Set the color properties
                pColor = new RgbColor();
                pColor.RGB = 255;
                pColor.Transparency = 0;

                //Get the IFillSymbol properties
                IFillSymbol pFillSymbol = new SimpleFillSymbol();
                //Set the fill symbol properties
                pFillSymbol.Color = pColor;
                pFillSymbol.Outline = pOutline;

                //QI for IFillShapeElement interface through the IElement interface
                IFillShapeElement pFillShapeElement = pElement as IFillShapeElement;
                //Set the symbol property
                pFillShapeElement.Symbol = pFillSymbol;
                object obj = pFillSymbol as object;
                //this.axMapControl1.DrawShape(pElement.Geometry,ref obj );
                pGraphicsContainer.AddElement(pFillShapeElement as IElement, 0);

                IEnvelope envelope;
                envelope = geoBuffer.Envelope;
                if (!envelope.IsEmpty)
                    envelope.Expand(1, 1, true);
                mapControl.Extent = envelope;
            }

            this.mapControl.Refresh();
            return geoBuffer as IPolygon;

        }

        /// <summary>
        /// 生成椭圆
        /// </summary>
        public IEllipticArc GenerateEllipticArc(IPoint pCenterPoint, double rotationAngle, double Descripe, double Seismic)
        {
            Core.DAL.DisaParameter disapara = new DAL.DisaParameter();
            List<Core.Model.DisaParameter> listdisapara = new List<Model.DisaParameter>();
            listdisapara = disapara.GetList();//读取灾区范围参数
            double MajorAxis = 0;
            double MinorAxis = 0;
            for (int i = 0; i < listdisapara.Count; i++)
            {
                if (listdisapara[i].isMajorAxis)
                    //根据地震等级和烈度计算出长短轴
                    MajorAxis = System.Math.Pow(10, (listdisapara[i].A + listdisapara[i].B * Convert.ToDouble(Descripe) - Seismic) / listdisapara[i].C) - listdisapara[i].D;//长半轴
                else
                    MinorAxis = System.Math.Pow(10, (listdisapara[i].A+ listdisapara[i].B * Convert.ToDouble(Descripe) - Seismic) / listdisapara[i].C) - listdisapara[i].D;//短半轴
            }

            if (MajorAxis <= 0 || MinorAxis <= 0)
            {
                MessageBox.Show("输入烈度过大！");
                return null;
            }

            double ratio;
            if (MajorAxis > MinorAxis)
                ratio = MinorAxis / MajorAxis;
            else
                ratio = MajorAxis / MinorAxis;

            IEllipticArc ellipticArc = new EllipticArcClass();

            //ellipticArc.PutCoordsByAngle(基准，中心点，起点角度，椭圆圆心角，旋转角度，长轴，长短轴之比)；轴长单位为米，角度单位为弧度
            ellipticArc.PutCoordsByAngle(false, pCenterPoint, 0, 2 * Math.PI, rotationAngle * Math.PI / 180, (double)MajorAxis / Core.Generic.SysEnviriment.LengthPerRad * 2, ratio);

            ISegment segment = ellipticArc as ISegment;
            ISegmentCollection polygon = new Polygon() as ISegmentCollection;
            object Missing = Type.Missing;
            polygon.AddSegment(segment, ref Missing, ref Missing);          
            

            //图上显示
            Color color = Color.Red;
            ISymbol symbol = CreateSimpleFillSymbol(color, 1, esriSimpleFillStyle.esriSFSHollow);
            AddElement(polygon as IGeometry, symbol, "result");
            IEnvelope envelope;
            envelope = ellipticArc.Envelope;
            if (!envelope.IsEmpty)
                envelope.Expand(1, 1, true);
            mapControl.Extent = envelope;
            this.mapControl.Refresh();

            return ellipticArc;
        }

    }
}
