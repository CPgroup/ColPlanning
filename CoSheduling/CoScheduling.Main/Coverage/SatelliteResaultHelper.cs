using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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


namespace CoScheduling.Main.Coverage
{
    public class SatelliteResaultHelper
    {
        static List<IPolygon> SatelliteResaultAreas;//卫星观测区多边形
        static List<Core.Model.SatelliteResault> list_model;

        #region 树列表操作
        /// <summary>
        /// 向树目录中加载显示卫星观测结果列表
        /// </summary>
        /// <param name="tv"></param>
        public static void LoadSatelliteSchemeList(TreeView tv)
        {
            List<Core.Model.TASK_SCHEME_LIST> tsl;
            Core.DAL.TASK_SCHEME_LIST dal = new Core.DAL.TASK_SCHEME_LIST();
            try
            {
                tsl = dal.GetList();
                tv.Nodes.Clear();
                TreeNode node, node1, node2;
                foreach (Core.Model.TASK_SCHEME_LIST di in tsl)
                {
                    //观测方案信息
                    node = new TreeNode();
                    node.Text = di.SCHEMENAME;
                    node.Tag = "S0|" + di.SCHEMEID;    //S--表示观测方案，对应一次灾害，0--表示未加载观测方案列表,后面跟记录ID
                    node.ImageIndex = 0;
                    node.SelectedImageIndex = 1;
                    tv.Nodes.Add(node);

                    //观测任务信息
                    node1 = new TreeNode();
                    node1.Text = "无观测任务";
                    node1.Tag = "T0|" + di.SCHEMEID;            //S--表示观测任务，一次观测方案有一或多个观测任务，0表示未加载观测任务列表
                    node1.ImageIndex = 2;
                    node1.SelectedImageIndex = 3;
                    node.Nodes.Add(node1);

                    //观测区域信息
                    node2 = new TreeNode();
                    node2.Text = "无观测区域";
                    node2.Tag = "I0";             //I--表示观测结果，0表示未加载观测结果列表
                    node2.ImageIndex = 4;
                    node2.SelectedImageIndex = 5;
                    node1.Nodes.Add(node2);

                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                tsl = null;
                dal = null;
            }
        }

        /// <summary>
        /// 加载观测任务列表
        /// </summary>
        /// <param name="pnode"></param>
        public static void LoadSatelliteTaskList(ESRI.ArcGIS.Controls.AxMapControl pMapCtr, TreeNode pnode, bool timeChecked)
        {
            int id;
            int.TryParse(pnode.Tag.ToString().Substring(3), out id);
            Core.DAL.TASK_LAYOUT_LIST dal = new Core.DAL.TASK_LAYOUT_LIST();
            List<Core.Model.TASK_LAYOUT_LIST> list_model = new List<Core.Model.TASK_LAYOUT_LIST>();
            TreeNode node;
            try
            {
                list_model = dal.GetList(id);
                if (list_model.Count != 0)
                    pnode.Nodes.Clear();
                //Core.Map.MapHelper map = new Core.Map.MapHelper(pMapCtr);
                //map.ClearAllElement();
                foreach (Core.Model.TASK_LAYOUT_LIST model in list_model)
                {
                    node = new TreeNode();
                    node.Text = model.TASKNAME;
                    node.Tag = "T1|" + model.TASKID;//T--表示观测任务，model.TASKID--表示为任务ID
                    node.ImageIndex = 2;
                    node.SelectedImageIndex = 3;
                    pnode.Nodes.Add(node);
                    LoadSatelliteResaultList(pMapCtr, node, timeChecked);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                list_model = null;
                dal = null;
            }
        }

        /// <summary>
        /// 加载观测区域列表
        /// </summary>
        /// <param name="pnode"></param>
        public static void LoadSatelliteResaultList(ESRI.ArcGIS.Controls.AxMapControl pMapCtr, TreeNode pnode, bool timeChecked)
        {
            int pid;
            int.TryParse(pnode.Tag.ToString().Substring(3), out pid);

            Core.DAL.SatelliteResault dal = new Core.DAL.SatelliteResault();
            List<Core.Model.SatelliteResault> list_model = new List<Core.Model.SatelliteResault>();
            TreeNode node;
            try
            {
                if (timeChecked)
                {
                    list_model = dal.GetListByTaskIDTime(pid);
                }
                else
                {
                    list_model = dal.GetListByTaskID(pid);
                }

                if (list_model.Count != 0)
                    pnode.Nodes.Clear();
                foreach (Core.Model.SatelliteResault model in list_model)
                {
                    Core.Model.ImgLayoutTempTimewindow imgLayoutTempTimewindow = new Core.Model.ImgLayoutTempTimewindow();
                    Core.DAL.ImgLayoutTempTimewindow dal_imgLayoutTempTimewindow = new Core.DAL.ImgLayoutTempTimewindow();
                    imgLayoutTempTimewindow = dal_imgLayoutTempTimewindow.GetModel(model.LSTR_SEQID.ToString());
                    node = new TreeNode();
                    node.Text = imgLayoutTempTimewindow.STARTTIME.ToString("yyyy-MM-dd HH:mm:ss") + "\\" + imgLayoutTempTimewindow.SAT_STKNAME + "\\" + imgLayoutTempTimewindow.SENSOR_STKNAME;
                    node.Tag = "I1|" + model.LSTR_SEQID;//I--表示观测结果，model.LSTR_SEQID--表示为观测结果ID
                    node.ImageIndex = 4;
                    node.SelectedImageIndex = 5;
                    pnode.Nodes.Add(node);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                list_model = null;
                dal = null;
            }
        }


        #endregion 树列表操作

        #region 载入地图操作
        /// <summary>
        /// 批量加载卫星观测区 根据卫星观测区所属的方案id加载
        /// </summary>
        /// <param name="pMapCtr"></param>
        /// <param name="id"></param>
        public static void LoadSatelliteResaultAreas(ESRI.ArcGIS.Controls.AxMapControl pMapCtr, int id, DateTime begin, DateTime end)
        {
            //读取并图上显示卫星观测区信息
            Core.Map.MapHelper map = new Core.Map.MapHelper(pMapCtr);
            map.ClearAllElement();
            //卫星观测区域
            Core.DAL.SatelliteResault dal_satelliteResault = new Core.DAL.SatelliteResault();
            list_model = new List<Core.Model.SatelliteResault>();

            IEnvelope envelope = null;
            try
            {
                list_model = dal_satelliteResault.GetListBySchemeID(id, begin, end);
                if (list_model.Count == 0)
                {
                    MessageBox.Show("该灾区尚未生成任务区！");
                    return;
                }
                //加载
                foreach (Core.Model.SatelliteResault t_model in list_model)
                {
                    try
                    {
                        LoadSatelliteResaultArea(map, t_model);
                        IPolygon pPolygon = Core.Generic.Convertor.ToPolygon(t_model.POLYGONSTRING);
                        //获取多个Polygon的Envelope外包矩形
                        if (envelope == null)
                        {
                            envelope = pPolygon.Envelope;
                        }
                        else
                            envelope.Union(pPolygon.Envelope);
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
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
        /// 批量加载卫星观测区 根据卫星观测区所属的任务id加载
        /// </summary>
        /// <param name="pMapCtr"></param>
        /// <param name="id"></param>
        public static void LoadSatelliteResaultAreasByTaskID(ESRI.ArcGIS.Controls.AxMapControl pMapCtr, int id, DateTime begin, DateTime end)
        {
            //读取并图上显示卫星观测区信息
            Core.Map.MapHelper map = new Core.Map.MapHelper(pMapCtr);
            map.ClearAllElement();
            //卫星观测区域
            Core.DAL.SatelliteResault dal_satelliteResault = new Core.DAL.SatelliteResault();
            list_model = new List<Core.Model.SatelliteResault>();

            IEnvelope envelope = null;
            try
            {
                list_model = dal_satelliteResault.GetListByTaskID(id, begin, end);
                if (list_model.Count == 0)
                {
                    MessageBox.Show("该灾区尚未生成任务区！");
                    return;
                }
                //加载
                foreach (Core.Model.SatelliteResault t_model in list_model)
                {
                    try
                    {
                        LoadSatelliteResaultArea(map, t_model);
                        IPolygon pPolygon = Core.Generic.Convertor.ToPolygon(t_model.POLYGONSTRING);
                        //获取多个Polygon的Envelope外包矩形
                        if (envelope == null)
                        {
                            envelope = pPolygon.Envelope;
                        }
                        else
                            envelope.Union(pPolygon.Envelope);
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
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
        public static void LoadSatelliteResaultArea(Core.Map.MapHelper map, Core.Model.SatelliteResault model)
        {
            CoScheduling.Core.Model.ImgLayoutTempTimewindow img = new CoScheduling.Core.Model.ImgLayoutTempTimewindow();
            CoScheduling.Core.DAL.ImgLayoutTempTimewindow dal_img = new CoScheduling.Core.DAL.ImgLayoutTempTimewindow();
            img = dal_img.GetModel(model.LSTR_SEQID.ToString());
            ISymbol symbol = map.CreateSimpleFillSymbol(Color.Blue, 1, esriSimpleFillStyle.esriSFSHollow);
            IPolygon pPolygon = Core.Generic.Convertor.ToPolygon(model.POLYGONSTRING);
            SatelliteResaultAreas = new List<IPolygon>();
            SatelliteResaultAreas.Add(pPolygon);
            //添加任务区多边形
            map.AddElement(pPolygon, symbol, "TaskArea");
            map.AddElement(pPolygon, symbol, "SatResaultInfo|" + img.LSTR_SEQID);
            //map.AddTextElement(pPolygon, getTextElement(img.SAT_STKNAME+"/"+img.SENSOR_STKNAME), "TaskAreaMark");
        }

        /// <summary>
        /// 字符串生成面，并拓扑简化
        /// </summary>
        /// <param name="polygonString"></param>
        /// <returns></returns>
        public static IPolygon StringToPolygon(string polygonString)
        {
            IPolygon pPolygon = Core.Generic.Convertor.ToPolygon(polygonString);
            ITopologicalOperator topo = pPolygon as ITopologicalOperator;
            topo.Simplify();
            return pPolygon;
        }

        /// <summary>
        /// 求面的面积
        /// </summary>
        /// <param name="pPolygon"></param>
        /// <returns></returns>
        public static double getPolygonArea(IPolygon pPolygon)
        {
            if (pPolygon != null)
            {
                //加投影
                ISpatialReferenceFactory3 pSRF = new SpatialReferenceEnvironmentClass();
                ISpatialReference pSR = pSRF.CreateProjectedCoordinateSystem((int)esriSRProjCS4Type.esriSRProjCS_Beijing1954_3_Degree_GK_CM_114E);
                pPolygon.SpatialReference = pSR;
                //任务区面积
                IArea pArea = pPolygon as IArea;
                double areas = pArea.Area;
                if (areas < 0)
                {
                    ICurve curve = pPolygon as ICurve;

                    curve.ReverseOrientation();
                    areas = pArea.Area;
                }
                return areas;
            }
            else
            {
                return 0;
            }

        }

        /// <summary>
        /// 求面的交
        /// </summary>
        /// <param name="taskLayout"></param>
        /// <param name="satelliteResault"></param>
        /// <returns></returns>
        public static IPolygon IntersectPolygon(IPolygon polygonOne, IPolygon polygonTwo)
        {
            try
            {

                ITopologicalOperator2 pTopologicalOperator = polygonOne as ITopologicalOperator2;
                IGeometry pGeometry =
                                   pTopologicalOperator.Intersect(polygonTwo, esriGeometryDimension.esriGeometry2Dimension) as
                                   IGeometry;
                if (!pGeometry.IsEmpty)
                {
                    IPolygon intersectPolygon = pGeometry as IPolygon;
                    return intersectPolygon;
                }
                else
                {
                    return null;
                }
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 求面的并
        /// </summary>
        /// <param name="taskLayout"></param>
        /// <param name="satelliteResault"></param>
        /// <returns></returns>
        public static IPolygon UnionPolygon(IPolygon polygonOne, IPolygon polygonTwo)
        {
            try
            {
                if (polygonOne == null && polygonTwo != null)
                {
                    return polygonTwo;
                }
                else if (polygonOne != null && polygonTwo == null)
                {
                    return polygonOne;
                }
                else
                {
                    ITopologicalOperator2 pTopologicalOperator = polygonOne as ITopologicalOperator2;
                    IGeometry pGeometry =
                                       pTopologicalOperator.Union(polygonTwo) as IGeometry;
                    if (!pGeometry.IsEmpty)
                    {
                        IPolygon unionPolygon = pGeometry as IPolygon;
                        return unionPolygon;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
        #endregion 载入地图操作

        #region 载入卫星任务区操作
        /// <summary>
        /// 加载单个任务区 根据任务区实体类加载
        /// </summary>
        /// <param name="map"></param>
        /// <param name="model"></param>
        public static void LoadSatelliteTaskArea(Core.Map.MapHelper map, Core.Model.TASK_LAYOUT_LIST model)
        {

            if (model.TASKTYPE == 0)
            {
                ISymbol symbol = map.CreateSimpleSymbol(Color.OrangeRed, 4, esriSimpleMarkerStyle.esriSMSCross);
                IPoint pPoint = new PointClass();
                pPoint.PutCoords(Convert.ToDouble(model.LON), Convert.ToDouble(model.LAT));
                //SatelliteResaultAreas = new List<IPolygon>();
                //SatelliteResaultAreas.Add(pPolygon);
                //添加任务区点
                map.AddElement(pPoint, symbol, "TaskArea");
                map.AddTextElement(pPoint, getTextElement(model.TASKNAME), "TaskAreaMark");
            }
            else
            {
                ISymbol symbol = map.CreateSimpleFillSymbol(Color.OrangeRed, 4, esriSimpleFillStyle.esriSFSHollow);
                string[] points = model.AREASTRING.Split(' ');
                string polygon = "";
                for (int i = 0; i < points.Length - 1; i += 2)
                {
                    polygon += points[i + 1] + "," + points[i] + ";";
                }

                IPolygon pPolygon = Core.Generic.Convertor.ToPolygon(polygon);
                SatelliteResaultAreas = new List<IPolygon>();
                SatelliteResaultAreas.Add(pPolygon);
                //添加任务区多边形
                map.AddElement(pPolygon, symbol, "TaskArea");
                map.AddTextElement(pPolygon, getTextElement(model.TASKNAME), "TaskAreaMark");
            }

        }
        #endregion 载入卫星任务区操作
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

        #region 定位地图操作
        /// <summary>
        /// 根据观测方案定位观测区域
        /// </summary>
        /// <param name="pMapCtr"></param>
        /// <param name="DID"></param>
        public static void PositionResaultAreasBySchemeID(ESRI.ArcGIS.Controls.AxMapControl pMapCtr, int DID)
        {

            Core.DAL.SatelliteResault dal = new Core.DAL.SatelliteResault();
            List<Core.Model.SatelliteResault> list_model = new List<Core.Model.SatelliteResault>();
            try
            {
                list_model = dal.GetListBySchemeID(DID);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                list_model = null;
                dal = null;
            }
        }
        /// <summary>
        /// 根据观测方案定位观测区域
        /// </summary>
        /// <param name="pMapCtr"></param>
        /// <param name="DID"></param>
        public static void PositionResaultAreasByTaskID(ESRI.ArcGIS.Controls.AxMapControl pMapCtr, int DID)
        {

            Core.DAL.SatelliteResault dal = new Core.DAL.SatelliteResault();
            List<Core.Model.SatelliteResault> list_model = new List<Core.Model.SatelliteResault>();
            try
            {
                list_model = dal.GetListBySchemeID(DID);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                list_model = null;
                dal = null;
            }
        }
        /// <summary>
        /// 定位观测区
        /// </summary>
        /// <param name="pMapCtr"></param>
        /// <param name="id"></param>
        public static void PositionResaultArea(ESRI.ArcGIS.Controls.AxMapControl pMapCtr, int id)
        {
            Core.Model.SatelliteResault model = new Core.Model.SatelliteResault();
            Core.DAL.SatelliteResault dal = new Core.DAL.SatelliteResault();
            try
            {
                model = dal.GetModel(id);
                IPolygon taskarea = Core.Generic.Convertor.ToPolygon(model.POLYGONSTRING);

                IEnvelope envelope;
                envelope = taskarea.Envelope;
                if (!envelope.IsEmpty)
                    envelope.Expand(2, 2, true);
                pMapCtr.Extent = envelope;
                pMapCtr.ActiveView.Refresh();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                model = null;
                dal = null;
            }
        }

        /// <summary>
        /// 定位任务区
        /// </summary>
        /// <param name="pMapCtr"></param>
        /// <param name="id"></param>
        public static void PositionTaskArea(ESRI.ArcGIS.Controls.AxMapControl pMapCtr, int id)
        {
            Core.Model.TASK_LAYOUT_LIST model = new Core.Model.TASK_LAYOUT_LIST();
            Core.DAL.TASK_LAYOUT_LIST dal = new Core.DAL.TASK_LAYOUT_LIST();
            try
            {
                model = dal.GetModel(id);
                IEnvelope envelope;
                if (model.TASKTYPE == 0)
                {
                    IPoint taskPoint = new PointClass();
                    taskPoint.PutCoords(Convert.ToDouble(model.LON), Convert.ToDouble(model.LAT));
                    envelope = taskPoint.Envelope;
                }
                else
                {
                    string[] points = model.AREASTRING.Split(' ');
                    string polygon = "";
                    for (int i = 0; i < points.Length - 1; i += 2)
                    {
                        polygon += points[i + 1] + "," + points[i] + ";";
                    }
                    IPolygon taskarea = Core.Generic.Convertor.ToPolygon(polygon);
                    envelope = taskarea.Envelope;
                }

                if (!envelope.IsEmpty)
                    envelope.Expand(2, 2, true);
                pMapCtr.Extent = envelope;
                pMapCtr.ActiveView.Refresh();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                model = null;
                dal = null;
            }
        }
        #endregion 定位地图操作
    }
}
