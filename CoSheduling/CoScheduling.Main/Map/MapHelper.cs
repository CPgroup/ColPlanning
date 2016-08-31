using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesFile;

namespace CoScheduling.Main.Map
{
    /// <summary>
    /// 类名：地图助手类
    /// 作者：李光强
    /// 时间：2013.11.12.
    /// 版本：V1.0
    /// </summary>
    public class MapHelper
    {
        public static  ESRI.ArcGIS.Controls.AxMapControl  mapControl;
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
            mapControl = pMapCtrl;
        }

        /// <summary>
        /// 带箭头的线段
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="fillColor"></param>
        public static void TrackLine(IPoint start, IPoint end, Color fillColor)
        {
            //将线段打断生成两条线段 以实现线段中间箭头显示
            IPoint middle = new PointClass();
            middle.PutCoords((end.X + start.X) / 2, (end.Y + start.Y) / 2);

            IActiveView pActiveView = Program.myMap.ActiveView;
            IGraphicsContainer pGraphicsContainer = pActiveView.GraphicsContainer;

            IPolyline pLine = new PolylineClass();
            IPolyline pLine1 = new PolylineClass();
            pLine.FromPoint = start;
            pLine.ToPoint = middle;
            pLine1.FromPoint = middle;
            pLine1.ToPoint = end;
            pLine.Project(pActiveView.FocusMap.SpatialReference);
            pLine1.Project(pActiveView.FocusMap.SpatialReference);

            ICartographicLineSymbol pCartoLineSymbol = new CartographicLineSymbol();
            pCartoLineSymbol.Cap = esriLineCapStyle.esriLCSRound;

            ILineProperties pLineProp = pCartoLineSymbol as ILineProperties;
            pLineProp.DecorationOnTop = true;

            ILineDecoration pLineDecoration = new LineDecoration();
            ISimpleLineDecorationElement pSimpleLineDecoElem = new SimpleLineDecorationElement();
            pSimpleLineDecoElem.AddPosition(1);
            IArrowMarkerSymbol pArrowMarkerSym = new ArrowMarkerSymbol();
            pArrowMarkerSym.Size = 12;
            pArrowMarkerSym.Color = GetColor(fillColor.R, fillColor.G, fillColor.B);
            pSimpleLineDecoElem.MarkerSymbol = pArrowMarkerSym as IMarkerSymbol;
            pLineDecoration.AddElement(pSimpleLineDecoElem as ILineDecorationElement);
            pLineProp.LineDecoration = pLineDecoration;

            ILineSymbol pLineSymbol = pCartoLineSymbol as ILineSymbol;
            pLineSymbol.Color = GetColor(fillColor.R, fillColor.G, fillColor.B); ;
            pLineSymbol.Width = 2;

            ILineElement pLineElem = new LineElementClass();
            ILineElement pLineElem1 = new LineElementClass();
            pLineElem.Symbol = pLineSymbol;
            pLineElem1.Symbol = pLineSymbol;

            IElement pElem = pLineElem as IElement;
            IElement pElem1 = pLineElem1 as IElement;

            pElem.Geometry = pLine;
            pElem1.Geometry = pLine1;

            pGraphicsContainer.AddElement(pElem, 0);
            pGraphicsContainer.AddElement(pElem1, 0);
            pActiveView.Refresh();

        }

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
                mapControl.Extent = env;
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
                mapControl.AddLayer(pRestLayer as ILayer);
                mapControl.Refresh();
            }
            catch (Exception ex)
            {
                throw (ex);
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
                for (int i = 0; i < shpCount; i++)
                {
                    shpFile = xml.GetElement("Shape", "Shp" + i);
                    if (shpFile.StartsWith("."))
                        shpFile = System.Windows.Forms.Application.StartupPath + shpFile.Substring(1);
                    LoadShape(shpFile);
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
        public static IColor GetColor(int R, int G, int B)
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
        public static  ISymbol  CreateSimpleSymbol(Color color, int size, esriSimpleMarkerStyle style)
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
            pSimpleFillSymbol.Outline = (ILineSymbol)CreateSimpleLineSymbol(fillColor, 1, esriSimpleLineStyle.esriSLSDash);
            return (ISymbol)pSimpleFillSymbol;

        }


        /// <summary>
        /// 添加图元
        /// </summary>
        /// <param name="pGeometry"></param>
        /// <param name="pActiveView"></param>
        /// <param name="pSymbol"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public  IElement  AddElement(IGeometry pGeometry, ISymbol pSymbol, string key)
        {
            try
            {
                IActiveView pActiveView = Program.myMap.ActiveView;
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
        /// 清除所有图元素
        /// </summary>
        public static void ClearAllElement()
        {
            IActiveView pActiveView = Main.Program.myMap.ActiveView;
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
            IGraphicsContainer pGraphicsContainer = (ESRI.ArcGIS.Carto.IGraphicsContainer)mapControl.Map;

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
            }

            mapControl.Refresh();
            return geoBuffer as IPolygon;

        }

    }
}
