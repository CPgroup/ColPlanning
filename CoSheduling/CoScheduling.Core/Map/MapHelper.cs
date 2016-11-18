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
