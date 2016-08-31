using System;
using System.Collections.Generic;

using System.Text;
using ESRI.ArcGIS.Geometry;

namespace CoScheduling.MonitorTask.Geometry
{
    /// <summary>
    /// 类名：单元格
    /// 作者：李光强
    /// 时间：2013.11.8
    /// </summary>
    public class Grid
    {
        private double _XMin;
        private double _YMin;
        private double _XMax;
        private double _YMax;
        private int _Row, _Col;

        /// <summary>
        /// 构造函数
        /// </summary>
        public Grid()
        {            
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public Grid(double x1,double y1,double x2,double y2)
        {
            _XMin = x1;
            _XMax = x2;
            _YMin = y1;
            _YMax = y2;
        }

        public double XMin
        {
            get
            {
                return _XMin;
            }
            set
            {
                _XMin = value;
            }
        }

        public double YMin
        {
            get
            {
                return _YMin;
            }
            set
            {
                _YMin = value;
            }
        }

        public double XMax
        {
            get
            {
                return _XMax;
            }
            set
            {
                _XMax = value;
            }
        }

        public double YMax
        {
            get
            {
                return _YMax;
            }
            set
            {
                _YMax = value;
            }
        }

        /// <summary>
        /// 行号
        /// </summary>
        public int Row { get { return _Row; } set { _Row = value; } }
        /// <summary>
        /// 列号
        /// </summary>
        public int Col { get { return _Col; } set { _Col = value; } }

        /// <summary>
        /// 是否已合并
        /// </summary>
        public bool isMerged { get; set; }

        /// <summary>
        /// 是否相等
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public bool Equal(Grid grid)
        {
            return (this.Row == grid.Row && this.Col == grid.Col);
        }

        /// <summary>
        /// 获取单元格邻居
        /// </summary>
        /// <param name="NeighborType"></param>
        /// <returns></returns>
        public Grid GetNeighbor(GridNeighborTypes NeighborType)
        {
            Grid grid = new Grid() ;
            if (NeighborType == GridNeighborTypes.UP)
            {
                grid.Row = this.Row + 1;
                grid.Col = this.Col;
                grid.XMin = this.XMin;
                grid.XMax = this.XMax;
                grid.YMin = this.YMax;
                grid.YMax = this.YMax + this.YMax - this.YMin;
            }
            else if(NeighborType== GridNeighborTypes.LEFT)
            {
                grid.Row = this.Row;
                grid.Col = this.Col-1;
                grid.XMin = this.XMin-(this.XMax-this.XMin);
                grid.XMax = this.XMin;
                grid.YMin = this.YMin;
                grid.YMax = this.YMax;
                if (grid.Col < 0) grid = null;
            }
            else if(NeighborType== GridNeighborTypes.RIGHT)
            {
                grid.Row = this.Row;
                grid.Col = this.Col+1;
                grid.XMin = this.XMax;
                grid.XMax = this.XMax+this.XMax-this.XMin;
                grid.YMin = this.YMin;
                grid.YMax = this.YMax;
            }
             else if(NeighborType== GridNeighborTypes.DOWN)
            {
                grid.Row = this.Row-1;
                grid.Col = this.Col;
                grid.XMin = this.XMin;
                grid.XMax = this.XMax;
                grid.YMax = this.YMin;
                grid.YMin = this.YMin - (this.YMax - this.YMin);
                if (grid.Row < 0) grid = null;
            }
            return grid;
        }

        /// <summary>
        /// 将网格构造成多边形
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public IPolygon BuildPolygon()
        {
            IPolygon polygon = (IPolygon)new Polygon();
            IPointCollection pnts = polygon as IPointCollection;
            IPoint pnt;
            pnt = new ESRI.ArcGIS.Geometry.Point();
            pnt.X = this.XMin; pnt.Y = this.YMin;
            pnts.AddPoint(pnt);
            pnt = new ESRI.ArcGIS.Geometry.Point();
            pnt.X = this.XMax; pnt.Y = this.YMin;
            pnts.AddPoint(pnt);
            pnt = new ESRI.ArcGIS.Geometry.Point();
            pnt.X = this.XMax; pnt.Y = this.YMax;
            pnts.AddPoint(pnt);
            pnt = new ESRI.ArcGIS.Geometry.Point();
            pnt.X = this.XMin; pnt.Y = this.YMax;
            pnts.AddPoint(pnt);
            pnt = new ESRI.ArcGIS.Geometry.Point();
            pnt.X = this.XMin; pnt.Y = this.YMin;
            pnts.AddPoint(pnt);
            return polygon;
        }
    }
}
