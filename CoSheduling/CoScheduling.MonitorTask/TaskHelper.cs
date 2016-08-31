using System;
using System.Collections.Generic;

using System.Text;
using ESRI.ArcGIS.Geometry;
using System.Drawing;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Carto;
using stdole;
using System.Windows.Forms;

namespace CoScheduling.MonitorTask
{
    /// <summary>
    /// 类名：任务助手
    /// 作者：李光强
    /// 时间：2013.11.12.
    /// </summary>
    public class TaskHelper
    {
        static List<MonitorTask.Geometry.Grid> InitGrid, DataGrid;
        static List<IPolygon> TaskAreas;//任务区多边形
        static List<Core.Model.TaskAreas> list_model;
        //public static List<IPoint> pIntersectPoint;//任务区与公路交点集合


        public static bool op = false;//fale--单元格数量创建灾区；true--单元格大小创建灾区


        /// <summary>
        /// 生成任务区域
        /// </summary>
        /// <param name="DID">灾区ID</param>
        /// <param name="GridHeight">单元格高度</param>
        /// <param name="GridWidth">单元格长度</param>
        /// <param name="pMapCtr">地图控件</param>
        public static void GenerateTask(ESRI.ArcGIS.Controls.AxMapControl pMapCtr, int DID,
            double GridWidth, double GridHeight)
        {
            Core.Model.DisaAreaInfo di;
            Core.DAL.DisaAreaInfo dal = new Core.DAL.DisaAreaInfo();
            try
            {
                di = dal.GetModel(DID);
                if (di == null)
                { throw (new Exception("读取灾区数据时出错")); }
                IPoint pnt = new ESRI.ArcGIS.Geometry.Point();
                pnt.X = di.LON;
                pnt.Y = di.LAT;
                Core.Map.MapHelper maphelper = new Core.Map.MapHelper(pMapCtr);
                System.Drawing.Color color = Color.Blue;
                ISymbol symbol = maphelper.CreateSimpleFillSymbol(color, 1, esriSimpleFillStyle.esriSFSHollow);
                double radius = di.AffectedRadius / Core.Generic.SysEnviriment.LengthPerRad;
                MonitorTask.TaskAreaHelper th = new MonitorTask.TaskAreaHelper();
                th.LoadMapData();
                th.SetDisasterArea(di.LON - radius, di.LAT - radius, di.LON + radius, di.LAT + radius);
                th.GenerateTask(GridWidth, GridHeight);

                InitGrid = th.InitGrids;
                DataGrid = th.DataGrids;
                IEnvelope env = new Envelope() as IEnvelope;
                //foreach (MonitorTask.Geometry.Grid grid in InitGrid)
                //{
                //    env = new Envelope() as IEnvelope;
                //    env.XMin = grid.XMin;
                //    env.YMin = grid.YMin;
                //    env.XMax = grid.XMax;
                //    env.YMax = grid.YMax;
                //    maphelper.AddElement(env, symbol, "grid");
                //}
                //color = Color.Brown;
                //symbol = maphelper.CreateSimpleFillSymbol(color, 1, esriSimpleFillStyle.esriSFSDiagonalCross);
                //foreach (MonitorTask.Geometry.Grid grid in DataGrid)
                //{
                //    env = new Envelope() as IEnvelope;
                //    env.XMin = grid.XMin;
                //    env.YMin = grid.YMin;
                //    env.XMax = grid.XMax;
                //    env.YMax = grid.YMax;
                //    maphelper.AddElement(env, symbol, "grid");
                //}
            }
            catch (Exception ex) { throw (ex); }
        }

        /// <summary>
        /// 生成任务区域
        /// </summary>
        /// <param name="DID">灾区ID</param>
        public static void GenerateTask(ESRI.ArcGIS.Controls.AxMapControl pMapCtr, int DID,
            int RowNum, int ColNum)
        {
            Core.Model.DisaAreaInfo di;
            Core.DAL.DisaAreaInfo dal = new Core.DAL.DisaAreaInfo();
            try
            {
                di = dal.GetModel(DID);
                if (di == null)
                { throw (new Exception("读取灾区数据时出错")); }
                IPoint pnt = new ESRI.ArcGIS.Geometry.Point();
                pnt.X = di.LON;
                pnt.Y = di.LAT;
                Core.Map.MapHelper maphelper = new Core.Map.MapHelper(pMapCtr);
                System.Drawing.Color color = Color.Blue;
                ISymbol symbol = maphelper.CreateSimpleFillSymbol(color, 1, esriSimpleFillStyle.esriSFSHollow);
                double radius = di.AffectedRadius / Core.Generic.SysEnviriment.LengthPerRad;
                MonitorTask.TaskAreaHelper th = new MonitorTask.TaskAreaHelper();
                th.LoadMapData();
                th.SetDisasterArea(di.LON - radius, di.LAT - radius, di.LON + radius, di.LAT + radius);
                th.GenerateTask(RowNum, ColNum);
                InitGrid = th.InitGrids;
                DataGrid = th.DataGrids;
                IEnvelope env = new Envelope() as IEnvelope;
                //foreach (MonitorTask.Geometry.Grid grid in InitGrid)
                //{
                //    env = new Envelope() as IEnvelope;
                //    env.XMin = grid.XMin;
                //    env.YMin = grid.YMin;
                //    env.XMax = grid.XMax;
                //    env.YMax = grid.YMax;
                //    maphelper.AddElement(env, symbol, "grid");
                //}
                //color = Color.Brown;
                //symbol = maphelper.CreateSimpleFillSymbol(color, 1, esriSimpleFillStyle.esriSFSDiagonalCross);
                //foreach (MonitorTask.Geometry.Grid grid in DataGrid)
                //{
                //    env = new Envelope() as IEnvelope;
                //    env.XMin = grid.XMin;
                //    env.YMin = grid.YMin;
                //    env.XMax = grid.XMax;
                //    env.YMax = grid.YMax;
                //    maphelper.AddElement(env, symbol, "grid");
                //}

            }
            catch (Exception ex) { throw (ex); }
        }
        private static void SetGridMerged(Geometry.Grid grid)
        {
            foreach (Geometry.Grid g in DataGrid)
            {
                if (g.Equal(grid)) g.isMerged = true;
            }
        }
        /// <summary>
        /// 构建监测任务区
        /// </summary>
        /// <param name="pMapCtr"></param>
        public static void BuildTaskArea(ESRI.ArcGIS.Controls.AxMapControl pMapCtr, int id)
        {
            if (DataGrid == null)
            {
                MessageBox.Show("您可能尚对灾区进行网格剖分，请先进行网格化剖分后再构建任务区！");
                return;
            }
            //throw new Exception("您可能尚对灾区进行网格剖分，请先进行网格化剖分后再构建任务区!");
            if (DataGrid.Count == 0)
            {
                MessageBox.Show("没有监测要素的单元格！");
                return;
            }
            //throw new Exception("没有监测要素的单元格！");

            TaskAreas = new List<IPolygon>();
            IPolygon area;
            Geometry.Grid _grid;
            try
            {
                foreach (Geometry.Grid grid in DataGrid)
                {
                    _grid = grid;
                    if (grid.isMerged) continue;    //如果已经合并过，则跳过
                    if (!ExistsGridInDataGrid(ref _grid)) continue; //如果不有数据单元格中，则跳过
                    area = grid.BuildPolygon();
                    grid.isMerged = true;
                    //SetGridMerged(grid);
                    MergeNN(grid, ref area);
                    TaskAreas.Add(area);
                }

                if (TaskAreas.Count == 0)
                    throw (new Exception("没有成功生成任务区域!"));

                //存储任务区信息
                int i = 1;
                foreach (IPolygon polygon in TaskAreas)
                {
                    Core.Model.TaskAreas model = new Core.Model.TaskAreas();
                    Core.DAL.TaskAreas dal = new Core.DAL.TaskAreas();
                    model.Name = "任务区" + i;
                    model.PID = id;
                    model.PolygonString = CoScheduling.Core.Generic.Convertor.ToString(polygon);
                    dal.Add(model);
                    i++;
                }
                //显示任务区
                LoadTaskAreas(pMapCtr, id);
                //生成交点
                // getIntersect(TaskAreas, map);
            }
            catch (Exception ex) { MessageBox.Show("错误" + ex.Message); }
            finally
            {
                TaskAreas = null;
            }
        }

        /// <summary>
        /// 批量加载任务区 根据任务区所属的灾情id加载
        /// </summary>
        /// <param name="pMapCtr"></param>
        /// <param name="id"></param>
        public static void LoadTaskAreas(ESRI.ArcGIS.Controls.AxMapControl pMapCtr, int id)
        {
            //读取并图上显示任务区任务区信息
            Core.Map.MapHelper map = new Core.Map.MapHelper(pMapCtr);
            map.ClearAllElement();
            //灾区
            Core.DAL.TaskAreas t_dal = new Core.DAL.TaskAreas();
            list_model = new List<Core.Model.TaskAreas>();
            //交点
            Core.DAL.DisaCrossPoint dal = new Core.DAL.DisaCrossPoint();
            List<Core.Model.DisaCrossPoint> models = new List<Core.Model.DisaCrossPoint>();
            //集结点
            Core.DAL.DisaGatherPoint g_dal = new Core.DAL.DisaGatherPoint();
            List<Core.Model.DisaGatherPoint> g_models = new List<Core.Model.DisaGatherPoint>();

            IEnvelope envelope = null;
            try
            {
                list_model = t_dal.GetList(id);
                if (list_model.Count == 0)
                {
                    MessageBox.Show("该灾区尚未生成任务区！");
                    return;
                }
                //加载
                foreach (Core.Model.TaskAreas t_model in list_model)
                {
                    LoadTaskArea(map, t_model);
                    IPolygon pPolygon = Core.Generic.Convertor.ToPolygon(t_model.PolygonString);
                    //获取多个Polygon的Envelope外包矩形
                    if (envelope == null)
                    {
                        envelope = pPolygon.Envelope;
                    }
                    else
                        envelope.Union(pPolygon.Envelope);

                    //models = dal.GetList(t_model.ID, id);
                    //foreach (Core.Model.DisaCrossPoint model in models)
                    //{
                    //    LoadCrossPoint(map, model);
                    //}

                    //g_models = g_dal.GetList(t_model.ID, id);
                    //foreach (Core.Model.DisaGatherPoint model in g_models)
                    //{
                    //    LoadGatherPoint(map, model);
                    //}


                }

                if (!envelope.IsEmpty)
                    envelope.Expand(1.1, 1.1, true);
                pMapCtr.Extent = envelope;
                pMapCtr.ActiveView.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误：" + ex);
            }
        }

        /// <summary>
        /// 加载单个任务区 根据任务区实体类加载
        /// </summary>
        /// <param name="map"></param>
        /// <param name="model"></param>
        public static void LoadTaskArea(Core.Map.MapHelper map, Core.Model.TaskAreas model)
        {
            ISymbol symbol = map.CreateSimpleFillSymbol(Color.Red, 4, esriSimpleFillStyle.esriSFSHollow);
            IPolygon pPolygon = Core.Generic.Convertor.ToPolygon(model.PolygonString);
            TaskAreas = new List<IPolygon>();
            TaskAreas.Add(pPolygon);
            //添加任务区多边形
            map.AddElement(pPolygon, symbol, "TaskArea");
            map.AddTextElement(pPolygon, getTextElement(model.Name), "TaskAreaMark");
        }

        /// <summary>
        /// 加载任务区与路网交点
        /// </summary>
        /// <param name="map"></param>
        /// <param name="model"></param>
        public static void LoadCrossPoint(Core.Map.MapHelper map, Core.Model.DisaCrossPoint model)
        {
            ISymbol symbol = map.CreateSimpleSymbol(Color.Red, 8, ESRI.ArcGIS.Display.esriSimpleMarkerStyle.esriSMSCircle);
            IPoint pPoint = new PointClass();
            pPoint.PutCoords(model.LON, model.LAT);
            map.AddElement(pPoint, symbol, "Intersect|" + model.PID);
        }

        /// <summary>
        /// 加载集结点
        /// </summary>
        /// <param name="map"></param>
        /// <param name="model"></param>
        public static void LoadGatherPoint(Core.Map.MapHelper map, Core.Model.DisaGatherPoint model)
        {
            ISymbol symbol = map.CreateSimpleSymbol(Color.Blue, 8, ESRI.ArcGIS.Display.esriSimpleMarkerStyle.esriSMSCircle);
            IPoint pPoint = new PointClass();
            pPoint.PutCoords(model.LON, model.LAT);
            map.AddElement(pPoint, symbol, "GatherPoint|" + model.PID);
        }


        /// <summary>
        /// 合并单元格近邻
        /// </summary>
        /// <param name="grid"></param>
        public static void MergeNN(Geometry.Grid grid, ref IPolygon area)
        {
            System.Diagnostics.Debug.Print("Merge: row=" + grid.Row.ToString() + ",col=" + grid.Col.ToString());
            if (!grid.isMerged)
            {
                IPolygon polygon = grid.BuildPolygon();
                area = MergePolygon(area, polygon);
                grid.isMerged = true;
                //SetGridMerged(grid);
            }
            //计算近邻
            Geometry.Grid GridUp, GridLeft, GridRight, GridDown;
            GridUp = grid.GetNeighbor(Geometry.GridNeighborTypes.UP);
            GridLeft = grid.GetNeighbor(Geometry.GridNeighborTypes.LEFT);
            GridRight = grid.GetNeighbor(Geometry.GridNeighborTypes.RIGHT);
            GridDown = grid.GetNeighbor(Geometry.GridNeighborTypes.DOWN);

            if (ExistsGridInDataGrid(ref GridUp))
                if (!GridUp.isMerged)
                    MergeNN(GridUp, ref area);
            if (GridLeft != null)
                if (ExistsGridInDataGrid(ref GridLeft))
                    if (!GridLeft.isMerged)
                        MergeNN(GridLeft, ref area);
            if (ExistsGridInDataGrid(ref GridRight))
                if (!GridRight.isMerged)
                    MergeNN(GridRight, ref area);
            if (GridDown != null)
            {
                if (ExistsGridInDataGrid(ref GridDown))
                    if (!GridDown.isMerged)
                        MergeNN(GridDown, ref area);
            }
            return;
        }

        /// <summary>
        /// 合并两个面
        /// </summary>
        /// <param name="a1"></param>
        /// <param name="a2"></param>
        /// <returns></returns>
        private static IPolygon MergePolygon(IPolygon a1, IPolygon a2)
        {
            ITopologicalOperator pTopoOp;
            pTopoOp = a1 as ITopologicalOperator;
            pTopoOp.Simplify();
            ITopologicalOperator pTopoOp2 = a2 as ITopologicalOperator;
            pTopoOp2.Simplify();
            IGeometry a3 = pTopoOp.Union(a2 as IGeometry);
            pTopoOp = a3 as ITopologicalOperator;
            pTopoOp.Simplify();
            return a3 as IPolygon;
        }

        /// <summary>
        /// 在数据单元格中是否存在
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        private static bool ExistsGridInDataGrid(ref Geometry.Grid grid)
        {
            foreach (Geometry.Grid g in DataGrid)
            {
                if (g.Equal(grid)) { grid = g; return true; }
            }
            return false;
        }

        /// <summary>
        /// 定义任务区多边形名称注记
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static ITextElement getTextElement(string name)
        {
            //定义任务区名称符号格式
            IRgbColor pColor = new RgbColorClass()
            {
                Red = 0,
                Blue = 255,
                Green = 0
            };
            IFontDisp pFont = new StdFont()
            {
                Name = "宋体",
                Bold = true
            } as IFontDisp;
            ITextSymbol pTextSymbol = new TextSymbolClass()
            {
                Color = pColor,
                Font = pFont,
                Size = 10
            };
            ITextElement pTextElement = new TextElementClass()
            {
                Symbol = pTextSymbol,
                ScaleText = true,
                Text = name
            };

            return pTextElement;
        }

        /// <summary>
        /// 获取交点
        /// </summary>
        /// <param name="pMapCtr"></param>
        /// <param name="id"></param>
        public static void getIntersect(ESRI.ArcGIS.Controls.AxMapControl pMapCtr, int id)
        {
            Core.Map.MapHelper map = new Core.Map.MapHelper(pMapCtr);
            Core.Generic.myXML xml = new Core.Generic.myXML(System.Windows.Forms.Application.StartupPath + "\\Setting.xml");
            try
            {
                IFeatureClass pFeatureClass = null;
                Core.Model.DisaAreaInfo model = new Core.Model.DisaAreaInfo();
                Core.DAL.DisaAreaInfo dal0 = new Core.DAL.DisaAreaInfo();


                Core.Model.DisaCrossPoint gatherPoint = new Core.Model.DisaCrossPoint();
                Core.DAL.DisaCrossPoint dal = new Core.DAL.DisaCrossPoint();
                //删除以前生成的交点
                dal.Deletes(id);

                map.getNetWorkData(ref pFeatureClass);

                //pIntersectPoint = new List<IPoint>();
                string Roadtype = xml.GetElement("FilterPara", "RoadType");
                string[] typeArray = Roadtype.Split(',');
                string whereclause = "";
                if (Roadtype != null)
                    for (int i = 0; i < typeArray.Length; i++)
                    {
                        if (i != (typeArray.Length - 1))
                            whereclause += "Type=" + typeArray[i] + " or ";
                        else
                            whereclause += "Type=" + typeArray[i];
                    }

                //生成灾区影响范围Geometry
                model = dal0.GetModel(id);
                IPoint pPoint = new PointClass();
                pPoint.PutCoords(model.LON, model.LAT);

                ITopologicalOperator pTopoOp = default(ITopologicalOperator);
                IGeometry geoBuffer = null;
                pTopoOp = pPoint as ITopologicalOperator;
                geoBuffer = pTopoOp.Buffer(model.AffectedRadius / Core.Generic.SysEnviriment.LengthPerRad);

                ISpatialFilter pSpatialfilter = new SpatialFilterClass();
                pSpatialfilter.Geometry = geoBuffer;
                pSpatialfilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelCrosses;
                pSpatialfilter.WhereClause = whereclause;
                pSpatialfilter.GeometryField = "Shape";

                IFeatureCursor FeatureCursor = pFeatureClass.Search(pSpatialfilter, false);
                IFeature pFeature = FeatureCursor.NextFeature();

                int count = 1;
                while (pFeature != null)
                {
                    IPolyline pPolyline = pFeature.ShapeCopy as IPolyline;

                    ITopologicalOperator pTopologicalOperator = pPolyline as ITopologicalOperator;
                    IGeometry pGeometry1 =
                           pTopologicalOperator.Intersect(geoBuffer as IPolygon, esriGeometryDimension.esriGeometry0Dimension) as
                           IGeometry;

                    if (!pGeometry1.IsEmpty)
                    {
                        IPointCollection Pc = pGeometry1 as IPointCollection;
                        ISymbol symbol = map.CreateSimpleSymbol(Color.Red, 8, ESRI.ArcGIS.Display.esriSimpleMarkerStyle.esriSMSCircle);
                        for (int i = 0; i < Pc.PointCount; i++)
                        {
                            //将交点显示在地图上
                            IPoint point = Pc.get_Point(i);

                            map.AddElement(Pc.get_Point(i), symbol, "Intersect|" + id);

                            //将交点存储到数据库中
                            gatherPoint.LON = point.X;
                            gatherPoint.LAT = point.Y;
                            gatherPoint.PID = id;
                            gatherPoint.PName = "交点(" + count++ + ")";
                            dal.Add(gatherPoint);
                            //pIntersectPoint.Add(Pc.get_Point(i));
                        }
                    }
                    pFeature = FeatureCursor.NextFeature();
                }
                pMapCtr.ActiveView.Refresh();
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                TaskAreas = null;
            }
        }
        /// <summary>
        /// 获取交点
        /// </summary>
        /// <param name="TaskAreas"></param>
        /// <param name="map"></param>
        public static void getIntersect(ESRI.ArcGIS.Controls.AxMapControl pMapCtr)
        {
            Core.Map.MapHelper map = new Core.Map.MapHelper(pMapCtr);
            Core.Generic.myXML xml = new Core.Generic.myXML(System.Windows.Forms.Application.StartupPath + "\\Setting.xml");
            try
            {
                IFeatureClass pFeatureClass = null;
                Core.Model.DisaCrossPoint gatherPoint = new Core.Model.DisaCrossPoint();
                Core.DAL.DisaCrossPoint dal = new Core.DAL.DisaCrossPoint();
                //删除以前生成的交点
                dal.Deletes(list_model[0].PID);

                map.getNetWorkData(ref pFeatureClass);
                if (list_model.Count == 0)
                {
                    MessageBox.Show("该灾区尚未生成任务区！");
                    return;
                }
                //pIntersectPoint = new List<IPoint>();
                string Roadtype = xml.GetElement("FilterPara", "RoadType");
                string[] typeArray = Roadtype.Split(',');
                string whereclause = "";
                if (Roadtype != null)
                    for (int i = 0; i < typeArray.Length; i++)
                    {
                        if (i != (typeArray.Length - 1))
                            whereclause += "Type=" + typeArray[i] + " or ";
                        else
                            whereclause += "Type=" + typeArray[i];
                    }
                foreach (Core.Model.TaskAreas taskarea in list_model)
                {
                    IPolygon pPolygon = CoScheduling.Core.Generic.Convertor.ToPolygon(taskarea.PolygonString);
                    //过滤道路网
                    IGeometry pGeometry = pPolygon as IGeometry;
                    ISpatialFilter pSpatialfilter = new SpatialFilterClass();
                    pSpatialfilter.Geometry = pGeometry;
                    pSpatialfilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
                    pSpatialfilter.WhereClause = whereclause;
                    pSpatialfilter.GeometryField = "Shape";

                    IFeatureCursor FeatureCursor = pFeatureClass.Search(pSpatialfilter, false);
                    IFeature pFeature = FeatureCursor.NextFeature();

                    int count = 1;
                    while (pFeature != null)
                    {
                        IPolyline pPolyline = pFeature.ShapeCopy as IPolyline;

                        ITopologicalOperator pTopologicalOperator = pPolyline as ITopologicalOperator;
                        IGeometry pGeometry1 =
                               pTopologicalOperator.Intersect(pPolygon, esriGeometryDimension.esriGeometry0Dimension) as
                               IGeometry;

                        if (!pGeometry1.IsEmpty)
                        {
                            IPointCollection Pc = pGeometry1 as IPointCollection;
                            ISymbol symbol = map.CreateSimpleSymbol(Color.Red, 8, ESRI.ArcGIS.Display.esriSimpleMarkerStyle.esriSMSCircle);
                            for (int i = 0; i < Pc.PointCount; i++)
                            {
                                //将交点显示在地图上
                                IPoint point = Pc.get_Point(i);

                                map.AddElement(Pc.get_Point(i), symbol, "Intersect|" + taskarea.ID + "|" + taskarea.PID);

                                //将交点存储到数据库中
                                gatherPoint.LON = point.X;
                                gatherPoint.LAT = point.Y;
                                gatherPoint.PID = taskarea.ID;
                                gatherPoint.PName = "交点(" + count++ + ")";
                                dal.Add(gatherPoint);
                                //pIntersectPoint.Add(Pc.get_Point(i));
                            }
                        }
                        pFeature = FeatureCursor.NextFeature();
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                TaskAreas = null;
            }
        }
    }
}
