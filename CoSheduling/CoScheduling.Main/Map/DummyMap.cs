using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;

namespace CoScheduling.Main.Map
{
    public partial class DummyMap : CP.WinFormsUI.Docking.DockContent
    {
        #region 自定义控件和成员变量
        Core.Map.MapHelper pMapHelper;    //地图助手
        TreeNode SelectedNodeDisa;       //灾区目录的选中结点
        int CurrentDisaAreaID = -1;      //当前显示的灾区ID 

        /// <summary>
        /// 地图控件
        /// </summary>
        public ESRI.ArcGIS.Controls.AxMapControl MapControl
        {
            get { return this.myMap; }
        }
        #endregion

        public DummyMap()
        {
            InitializeComponent();

        }

        private void FormMap_Load(object sender, EventArgs e)
        {
            Main.Program.SetStatusLabel(" 正在加载数据...");
            try
            {
                pMapHelper = new Core.Map.MapHelper(this.myMap);

                //加载配置文件中的地图服务列表
                pMapHelper.LoadMapService();

                //加载配置文件中的SHP文件列表
                pMapHelper.LoadShape();
                //利用配置文件中的InitExten信息初始化地图范围    
                pMapHelper.InitExtent();
                //加载DEM
                //pMapHelper.LoadDEM();
                //将地图控件传到Program
                Main.Program.myMap = this.myMap;
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误:" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Main.Program.SetStatusLabel("就绪！");
                Program.gProgressBar.Visible = false;
            }

        }

        /// <summary>
        /// 鼠标点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void myMap_OnMouseDown(object sender, ESRI.ArcGIS.Controls.IMapControlEvents2_OnMouseDownEvent e)
        {
            //try
            //{
            //    if (e.button == 4)
            //        myMap.Pan();

            //    IActiveView pActiveView = myMap.ActiveView;
            //    IGraphicsContainer pGraphicsContainer = pActiveView.GraphicsContainer;
            //    IPoint Click_Point = new PointClass();
            //    IEnumElement pEnumEle;
            //    IElement pElement;
            //    Click_Point.PutCoords(e.mapX, e.mapY);

            //    //无人机单位添加--获取图上经纬度
            //    if (e.button == 1 && MainInterface.company != null && MainInterface.company.Text != "")
            //    {
            //        IPoint pnt = this.myMap.ToMapPoint(e.x, e.y);
            //        if (MainInterface.company == null) return;
            //        MainInterface.company.lat = pnt.Y.ToString();
            //        MainInterface.company.lon = pnt.X.ToString();
            //        MainInterface.company.ShowConpanyInfor();
            //        if (MainInterface.company.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //        {
            //            Main.Program.ShowUAVComp();
            //            Main.MainInterface.refQueryResults();
            //            MainInterface.company = null;
            //        }
            //    }

            //    //无人机单位编辑--获取图上经纬度
            //    if (e.button == 1 && MainInterface.modComp != null && MainInterface.modComp.Text != "")
            //    {
            //        IPoint pnt = this.myMap.ToMapPoint(e.x, e.y);
            //        if (MainInterface.modComp == null) return;
            //        MainInterface.modComp.lat = pnt.Y.ToString();
            //        MainInterface.modComp.lon = pnt.X.ToString();
            //        MainInterface.modComp.ShowConpanyInfor();
            //        if (MainInterface.modComp.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //        {
            //            Main.Program.ShowUAVComp();
            //            Main.MainInterface.refQueryResults();
            //            MainInterface.modComp = null;
            //        }
            //    }

            //    //灾区添加--获取图上经纬度
            //    else if (e.button == 1 && MainInterface.addForm != null && MainInterface.addForm.Text != "")
            //    {
            //        IPoint pnt = this.myMap.ToMapPoint(e.x, e.y);
            //        if (MainInterface.addForm == null) return;
            //        MainInterface.addForm.lat = pnt.Y.ToString();
            //        MainInterface.addForm.lon = pnt.X.ToString();
            //        MainInterface.addForm.ShowConpanyInfor();
            //        if (MainInterface.addForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //        {
            //            MainInterface.treeRefresh();
            //            MainInterface.addForm = null;
            //        }
            //    }

            //    //灾区编辑--获取图上经纬度
            //    else if (e.button == 1 && MainInterface.modForm != null && MainInterface.modForm.Text != "")
            //    {
            //        IPoint pnt = this.myMap.ToMapPoint(e.x, e.y);
            //        if (MainInterface.modForm == null) return;
            //        MainInterface.modForm.lat = pnt.Y.ToString();
            //        MainInterface.modForm.lon = pnt.X.ToString();
            //        MainInterface.modForm.ShowConpanyInfor();
            //        if (MainInterface.modForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //        {
            //            MainInterface.treeRefresh();
            //            MainInterface.modForm = null;
            //        }
            //    }

            //    //障碍点添加--获取图上经纬度
            //    else if (e.button == 1 && Task.BarriesManager.frmBarriesAdd != null && Task.BarriesManager.frmBarriesAdd.Text != "")
            //    {
            //        IPoint pnt = this.myMap.ToMapPoint(e.x, e.y);
            //        if (Task.BarriesManager.frmBarriesAdd == null) return;
            //        Task.BarriesManager.frmBarriesAdd.lat = pnt.Y.ToString();
            //        Task.BarriesManager.frmBarriesAdd.lon = pnt.X.ToString();
            //        Task.BarriesManager.frmBarriesAdd.ShowConpanyInfor();
            //        if (Task.BarriesManager.frmBarriesAdd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //        {
            //            Main.Program.ShowBarries();
            //            Task.BarriesManager.Refesh();
            //            Task.BarriesManager.frmBarriesAdd = null;
            //        }
            //    }

            //    //依据点击位置获取元素
            //    pEnumEle = pGraphicsContainer.LocateElements(Click_Point, 0);
            //    if (pEnumEle != null)
            //    {
            //        pElement = pEnumEle.Next();
            //        if (pElement.Geometry.GeometryType == esriGeometryType.esriGeometryPoint)
            //        {
            //            IPoint pPoint1 = pElement.Geometry as IPoint;
            //            IElementProperties pElmentProperties = pElement as IElementProperties;
            //            if (pElmentProperties.Name.Split('|')[0] == "Intersect")
            //            {
            //                ISymbol symbol = MapHelper.CreateSimpleSymbol(Color.Blue, 8, ESRI.ArcGIS.Display.esriSimpleMarkerStyle.esriSMSCircle);
            //                AddElement(pPoint1, symbol, "GatherPoint|" + pElmentProperties.Name.Substring(10));
            //            }
            //            else if (pElmentProperties.Name.Split('|')[0] == "GatherPoint")
            //            {
            //                pGraphicsContainer.DeleteElement(pElement);
            //            }

            //            else if (pElmentProperties.Name.Split('|')[0] == "UAVInfor")
            //            {
            //                int uavID = Convert.ToInt32(pElmentProperties.Name.Split('|')[1]);
            //                Core.Model.UAVBD UAVModel = new Core.Model.UAVBD();
            //                Core.DAL.UAVBD UAVDAL = new Core.DAL.UAVBD();
            //                UAVModel = UAVDAL.GetModel(uavID);
            //                IPoint pnt = new ESRI.ArcGIS.Geometry.Point();
            //                pnt.X = UAVModel.X;
            //                pnt.Y = UAVModel.Y;
            //                CoScheduling.Main.DisaArea.DisaAreaHelper.CreateTextElment(pnt, UAVModel.Name);
            //            }
            //            else if (pElmentProperties.Name == "UAVCallout")
            //            {
            //                pGraphicsContainer.DeleteElement(pElement);
            //            }

            //            else if (pElmentProperties.Name.Split('|')[0] == "VolInfo") //志愿者信息
            //            {
            //                int VolID = Convert.ToInt32(pElmentProperties.Name.Split('|')[1]);
            //                Volunteer.VUserInfo frm = new Volunteer.VUserInfo();
            //                frm.ID = VolID;
            //                frm.Show();
            //            }

                       

            //            pActiveView.Refresh();
            //        }
            //        else if (pElement.Geometry.GeometryType == esriGeometryType.esriGeometryPolygon)
            //        {
            //            IPolygon pPolygon = pElement.Geometry as IPolygon;
            //            IElementProperties pElmentProperties = pElement as IElementProperties;
            //            if (pElmentProperties.Name.Split('|')[0] == "TaskState")//任务执行状态
            //            {
            //                int uid = Convert.ToInt32(pElmentProperties.Name.Split('|')[1].Split(',')[1]);
            //                Main.UAV.FrmUAVMessage uavInfo = new UAV.FrmUAVMessage();
            //                uavInfo.StartPosition = FormStartPosition.CenterParent;
            //                uavInfo.UID = uid;
            //                uavInfo.Show();
            //            }
            //            else if (pElmentProperties.Name.Split('|')[0] == "SatResaultInfo") //卫星规划结果信息
            //            {
            //                //获取规划结果id
            //                int imgID = Convert.ToInt32(pElmentProperties.Name.Split('|')[1]);
            //                CoScheduling.Core.Model.SatelliteResault model = new CoScheduling.Core.Model.SatelliteResault();
            //                CoScheduling.Core.DAL.SatelliteResault dal_model = new CoScheduling.Core.DAL.SatelliteResault();
            //                //根据id获取规划结果实体类
            //                model = dal_model.GetModel(imgID);
            //                //重新绘制图形
            //                Core.Map.MapHelper map = new Core.Map.MapHelper(Program.myMap);
            //                ISymbol pSymbol = map.CreateSimpleFillSymbol(Color.Blue, 4, esriSimpleFillStyle.esriSFSCross);
            //                IPolygon satPolygon = Core.Generic.Convertor.ToPolygon(model.POLYGONSTRING);
            //                Program.myMap.FlashShape(satPolygon, 10, 100, pSymbol);

            //                //关闭已打开详细信息窗口
            //                foreach (Form form in Application.OpenForms)
            //                {
            //                    if (form.Name == "SatelliteResaultDetail")
            //                    {
            //                        form.Close();
            //                        break;
            //                    }
            //                }
            //                //弹出详细信息窗口
            //                Satellite.SatelliteResaultDetail newform = new Satellite.SatelliteResaultDetail(imgID);
            //                newform.StartPosition = FormStartPosition.CenterScreen;
            //                newform.Show();

            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("错误：" + ex.Message);
            //}
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
                IActiveView pActiveView = MapControl.ActiveView;
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

        private void myMap_OnMouseMove(object sender, ESRI.ArcGIS.Controls.IMapControlEvents2_OnMouseMoveEvent e)
        {
            Main.Program.SetCoorText(e.mapX.ToString("F4") + "," + e.mapY.ToString("F4"));
        }
    }
}
