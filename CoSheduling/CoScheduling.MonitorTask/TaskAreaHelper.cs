using System;
using System.Collections.Generic;

using System.Text;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.DataSourcesRaster;
using System.Windows.Forms;

namespace CoScheduling.MonitorTask
{
    /// <summary>
    /// 类名：任务区助手类
    /// 作者：李光强=
    /// 时间：2013.11.12
    /// </summary>
    public class TaskAreaHelper
    {
        /// <summary>
        /// 居民地图层
        /// </summary>
        private IFeatureLayer _ResidentLayer;
        /// <summary>
        /// 道路图层
        /// </summary>
        private IFeatureLayer _RoadLayer;
        /// <summary>
        /// 水系图层
        /// </summary>
        private IFeatureLayer _HydroLayer;
        /// <summary>
        /// 地名图层
        /// </summary>
        private IFeatureLayer _AreaNameLayer;
        //------------9/15----WYK
        /// <summary>
        /// DEM图层
        /// </summary>
        private IRasterLayer _DEMRasterLayer;
        /// <summary>
        /// DEM图层
        /// </summary>
        public IRasterLayer DEMRasterLayer { get { return _DEMRasterLayer; } set { _DEMRasterLayer = value; } }
        /// <summary>
        /// 居民地图层
        /// </summary>
        public IFeatureLayer ResidentLayer { get { return _ResidentLayer; } set { _ResidentLayer = value; } }
        /// <summary>
        /// 道路图层
        /// </summary>
        public IFeatureLayer RoadLayer { get { return _RoadLayer; } set { _RoadLayer = value; } }
        /// <summary>
        /// 水系图层
        /// </summary>
        public IFeatureLayer HydroLayer { get { return _HydroLayer; } set { _HydroLayer = value; } }
        /// <summary>
        /// 地名图层
        /// </summary>
        public IFeatureLayer AreaNameLayer { get { return _AreaNameLayer; } set { _AreaNameLayer = value; } }
        #region 图层加载
        /// <summary>
        /// 打开居民地图层SHP文件
        /// </summary>
        /// <param name="shpFile"></param>
        private void OpenResidentLayer(string shpFile)
        {
            this._ResidentLayer = this.OpenShape(shpFile);
        }
        /// <summary>
        /// 打开居民地图层SHP文件
        /// </summary>
        /// <param name="shpFile"></param>
        private void OpenAreaNameLayer(string shpFile)
        {
            this._AreaNameLayer = this.OpenShape(shpFile);
        }

        /// <summary>
        /// 打开居民地图层SHP文件
        /// </summary>
        /// <param name="shpFile"></param>
        private void OpenDEMLayer(string shpFile)
        {
            this._DEMRasterLayer = LoadDem(shpFile);
        }
        /// <summary>
        /// 打开水系地图层SHP文件
        /// </summary>
        /// <param name="shpFile"></param>
        private void OpenHydroLayer(string shpFile)
        {
            this._HydroLayer = this.OpenShape(shpFile);
        }
        /// <summary>
        /// 打开水系地图层SHP文件
        /// </summary>
        /// <param name="shpFile"></param>
        private void OpenRoadLayer(string shpFile)
        {
            this._RoadLayer = this.OpenShape(shpFile);
        }
        /// <summary>
        /// 加载栅格图层
        /// </summary>
        /// <param name="shpFile"></param>
        public IRasterLayer LoadDem(string shpFile)
        {

            string strFullPath = shpFile;
            if (strFullPath == "") return null;
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
                return pRasterLayer;
            }
            catch (Exception err)
            {
                throw (err);

            }
        }
        /// <summary>
        /// 加载SHP文件
        /// </summary>
        /// <param name="shpFile"></param>
        /// <returns></returns>
        public IFeatureLayer OpenShape(string shpFile)
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
        #endregion 加载图层

        #region 生成任务区域
        List<Geometry.Grid> _InitGrids, _DataGrids;    //原始单元格和有数据单元
        /// <summary>
        /// 原始划分单元格
        /// </summary>
        public List<Geometry.Grid> InitGrids { get { return _InitGrids; } }
        /// <summary>
        /// 包含数据单元格
        /// </summary>
        public List<Geometry.Grid> DataGrids { get { return _DataGrids; } }

        Geometry.DisasterArea disasterArea;             //灾区范围
        /// <summary>
        /// 设置灾区范围
        /// </summary>
        /// <param name="Xmin"></param>
        /// <param name="Ymin"></param>
        /// <param name="Xmax"></param>
        /// <param name="Ymax"></param>
        public void SetDisasterArea(double Xmin, double Ymin, double Xmax, double Ymax)
        {
            disasterArea = new Geometry.DisasterArea(Xmin, Ymin, Xmax, Ymax);
        }
        /// <summary>
        /// 加载数据(绝对路径——YJ1008)
        /// </summary>
        public void LoadMapData()
        {
            Core.Generic.myXML xml = new Core.Generic.myXML(System.Windows.Forms.Application.StartupPath + "\\Setting.xml");
            try
            {
                string shpFile;
                shpFile = xml.GetElement("MapData", "Resident");
                if (!string.IsNullOrEmpty(shpFile))
                {
                    //if (shpFile.StartsWith("."))
                    //    shpFile = System.Windows.Forms.Application.StartupPath + shpFile.Substring(1);
                    if (System.IO.File.Exists(shpFile))
                        OpenResidentLayer(shpFile);
                }
                shpFile = xml.GetElement("MapData", "Road");
                if (!string.IsNullOrEmpty(shpFile))
                {
                    //if (shpFile.StartsWith("."))
                    //    shpFile = System.Windows.Forms.Application.StartupPath + shpFile.Substring(1);
                    if (System.IO.File.Exists(shpFile))
                        OpenRoadLayer(shpFile);
                }
                shpFile = xml.GetElement("MapData", "Hydrographic");
                if (!string.IsNullOrEmpty(shpFile))
                {
                    //if (shpFile.StartsWith("."))
                    //    shpFile = System.Windows.Forms.Application.StartupPath + shpFile.Substring(1);
                    if (System.IO.File.Exists(shpFile))
                        OpenHydroLayer(shpFile);
                }

                shpFile = xml.GetElement("MapData", "GeographicaNames");
                if (!string.IsNullOrEmpty(shpFile))
                {
                    if (shpFile.StartsWith("."))
                        shpFile = System.Windows.Forms.Application.StartupPath + shpFile.Substring(1);
                    if (System.IO.File.Exists(shpFile))
                        OpenAreaNameLayer(shpFile);
                }
                shpFile = xml.GetElement("MapData", "DEM");
                if (!string.IsNullOrEmpty(shpFile))
                {
                    //if (shpFile.StartsWith("."))
                    //    shpFile = System.Windows.Forms.Application.StartupPath + shpFile.Substring(1);
                    if (System.IO.File.Exists(shpFile))
                        OpenDEMLayer(shpFile);
                }
            }
            catch (Exception ex) { throw (ex); }
        }
        /// <summary>
        /// 根据单元格数据生成区域
        /// </summary>
        /// <param name="RowNum"></param>
        /// <param name="ColNum"></param>
        public void GenerateTask(int RowNum, int ColNum)
        {
            PartitionArea(RowNum, ColNum);
            if (_ResidentLayer != null) CheckGrid(0);
            if (_RoadLayer != null) CheckGrid(1);
            if (_HydroLayer != null) CheckGrid(2);
        }

        /// <summary>
        /// 根据单元格数据生成区域
        /// </summary>
        /// <param name="RowNum"></param>
        /// <param name="ColNum"></param>
        public void GenerateTask(double GridWidth, double GridHeight)
        {
            PartitionArea(GridWidth, GridHeight);
            if (_ResidentLayer != null) CheckGrid(0);
            if (_RoadLayer != null) CheckGrid(1);
            if (_HydroLayer != null) CheckGrid(2);
        }
        /// <summary>
        /// 按单元格数量分割区域
        /// </summary>
        /// <param name="RowNum"></param>
        /// <param name="ColNum"></param>
        private void PartitionArea(int RowNum, int ColNum)
        {
            Geometry.Grid grid;
            double w = disasterArea.Width / ColNum;
            double h = disasterArea.Height / RowNum;
            if (_InitGrids == null) _InitGrids = new List<Geometry.Grid>();
            else _InitGrids.Clear();

            for (int i = 0; i < ColNum; i++)
            {
                for (int j = 0; j < RowNum; j++)
                {
                    grid = new Geometry.Grid();
                    grid.Row = j; grid.Col = i;
                    grid.XMin = disasterArea.XMin + w * (double)i;
                    grid.YMin = disasterArea.YMin + h * (double)j;
                    grid.XMax = grid.XMin + w;
                    grid.YMax = grid.YMin + h;
                    _InitGrids.Add(grid);
                }
            }
        }

        /// <summary>
        /// 按单元大小分割区域
        /// </summary>
        private void PartitionArea(double size)
        {
            Geometry.Grid grid;
            int cn = (int)Math.Ceiling(disasterArea.Width / size);
            int rn = (int)Math.Ceiling(disasterArea.Height / size);
            if (_InitGrids == null) _InitGrids = new List<Geometry.Grid>();
            else _InitGrids.Clear();

            for (int i = 0; i < cn; i++)
            {
                for (int j = 0; j < rn; j++)
                {
                    grid = new Geometry.Grid();
                    grid.Row = j; grid.Col = i;
                    grid.XMin = disasterArea.XMin + size * (double)i;
                    grid.YMin = disasterArea.YMin + size * (double)j;
                    //当单元为最右、最上面的时候，则为边界值
                    if (i == cn - 1) grid.XMax = disasterArea.XMax;
                    else grid.XMax = grid.XMin + size;
                    if (j == rn) grid.YMax = disasterArea.YMax;
                    else grid.YMax = grid.YMin + size;
                    _InitGrids.Add(grid);
                }
            }
        }

        /// <summary>
        /// 按单元大小分割区域
        /// </summary>
        private void PartitionArea(double width, double height)
        {
            Geometry.Grid grid;
            int cn = (int)Math.Ceiling(disasterArea.Width / width);
            int rn = (int)Math.Ceiling(disasterArea.Height / height);
            if (_InitGrids == null) _InitGrids = new List<Geometry.Grid>();
            else _InitGrids.Clear();

            for (int i = 0; i < cn; i++)
            {
                for (int j = 0; j < rn; j++)
                {
                    grid = new Geometry.Grid();
                    grid.Row = j; grid.Col = i;
                    grid.XMin = disasterArea.XMin + width * (double)i;
                    grid.YMin = disasterArea.YMin + height * (double)j;
                    //当单元为最右、最上面的时候，则为边界值
                    if (i == cn - 1) grid.XMax = disasterArea.XMax;
                    else grid.XMax = grid.XMin + width;
                    if (j == rn) grid.YMax = disasterArea.YMax;
                    else grid.YMax = grid.YMin + height;
                    _InitGrids.Add(grid);
                }
            }
        }

        /// <summary>
        /// 检查包括数据的单元格
        /// </summary>
        /// <param name="type">类型 0-居民地,1-道路,2-水系</param>
        private void CheckGrid(int type)
        {

            IPolygon grid;

            if (_DataGrids != null) _DataGrids.Clear();
            else _DataGrids = new List<Geometry.Grid>();

            foreach (Geometry.Grid g in _InitGrids)
            {
                IFeatureCursor featureCursor = null;
                ISpatialFilter spatialFilter = new SpatialFilter();
                if (isContainedInDataGrids(g)) continue;    //如果已包含在数据单元格中了，则跳过
                grid = g.BuildPolygon();
                spatialFilter.Geometry = grid as IGeometry;
                spatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
                if (type == 0) featureCursor = ResidentLayer.Search(spatialFilter, false);
                else if (type == 1) featureCursor = RoadLayer.Search(spatialFilter, false);
                else if (type == 2) featureCursor = HydroLayer.Search(spatialFilter, false);
                //System.Diagnostics.Debug.Print("row=" + g.Row.ToString() + ",col=" + g.Col.ToString());
                if (featureCursor.NextFeature() != null)
                {
                    _DataGrids.Add(g);
                }
                featureCursor.Flush();
                featureCursor = null;
            }
        }

        /// <summary>
        /// 是否已存在于数据单元格集中
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        private bool isContainedInDataGrids(Geometry.Grid grid)
        {
            if (_DataGrids == null) return false;
            else
            {
                foreach (Geometry.Grid g in _DataGrids)
                {
                    if (grid.Equal(g)) return true;
                }
                return false;
            }

        }
        #endregion 生成任务区域

    }


}
