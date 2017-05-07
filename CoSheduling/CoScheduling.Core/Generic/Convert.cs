using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geometry;

namespace CoScheduling.Core.Generic
{
    /// <summary>
    /// 类名：通用转换类
    /// 作者：李光强
    /// 时间：2011.10.13
    /// </summary>
    public static class Convertor
    {
        /// <summary>
        /// 是否为整型数据
        /// </summary>
        /// <param name="pStr"></param>
        /// <returns></returns>
        public static bool isInteger(string pStr)
        {
            try
            {
                int i = int.Parse(pStr);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 是否为数字形式
        /// </summary>
        /// <param name="pStr"></param>
        /// <returns></returns>
        public static bool isNumberic(string pStr)
        {
            try
            {
                Single s = Single.Parse(pStr);
                return true;
            }
            catch { return false; }
        }

        /// <summary>
        /// 坐标串转换为多段线
        /// </summary>
        /// <param name="xyString"></param>
        /// <returns></returns>
        public static IPolyline ToPolyline(string xyString)
        {
            string[] xyStr = xyString.Split(';');
            IPoint pPoint = new PointClass();
            IPointCollection pPointCollection = new PolygonClass();
            object _missing = Type.Missing;
            double Lat, Lon;
            for (int i = 0; i < xyStr.Length; i++)
            {
                if (string.IsNullOrEmpty(xyStr[i]))
                    continue;
                Lon = Convert.ToDouble(xyStr[i].Split(',')[0]);
                Lat = Convert.ToDouble(xyStr[i].Split(',')[1]);
                pPoint = new PointClass();
                pPoint.X = Lon;
                pPoint.Y = Lat;
                pPoint.PutCoords(Lon, Lat);
                pPointCollection.AddPoint(pPoint, ref _missing, ref _missing);
            }
            ILine pLine ;
            object o = Type.Missing;
            ISegmentCollection pPath = new PathClass();
            for (int j = 0; j < pPointCollection.PointCount-1; j++)
            {
                pLine = new LineClass();
                pLine.PutCoords(pPointCollection.Point[j], pPointCollection.Point[j+1]);
                pPath.AddSegment((ISegment)pLine, ref o, ref o);
            }
            IGeometryCollection pPolyline = new PolylineClass();
            pPolyline.AddGeometry((IGeometry)pPath, ref o, ref o);
            return pPolyline as IPolyline;

        }

        /// <summary>
        /// 坐标串转换为多段线
        /// </summary>
        /// <param name="xyString"></param>
        /// <returns></returns>
        public static IPolyline ToPolyline2(string xyString)
        {
            string[] xyStr = xyString.Split(';');
            IPoint pPoint = new PointClass();
            IPointCollection pPointCollection = new PolygonClass();
            object _missing = Type.Missing;
            double Lat, Lon;
            for (int i = 0; i < xyStr.Length; i++)
            {
                if (string.IsNullOrEmpty(xyStr[i]))
                    continue;
                Lon = Convert.ToDouble(xyStr[i].Split(',')[1]);
                Lat = Convert.ToDouble(xyStr[i].Split(',')[0]);
                pPoint = new PointClass();
                pPoint.X = Lon;
                pPoint.Y = Lat;
                pPoint.PutCoords(Lon, Lat);
                pPointCollection.AddPoint(pPoint, ref _missing, ref _missing);
            }
            ILine pLine;
            object o = Type.Missing;
            ISegmentCollection pPath = new PathClass();
            for (int j = 0; j < pPointCollection.PointCount - 1; j++)
            {
                pLine = new LineClass();
                pLine.PutCoords(pPointCollection.Point[j], pPointCollection.Point[j + 1]);
                pPath.AddSegment((ISegment)pLine, ref o, ref o);
            }
            IGeometryCollection pPolyline = new PolylineClass();
            pPolyline.AddGeometry((IGeometry)pPath, ref o, ref o);
            return pPolyline as IPolyline;

        }

        /// <summary>
        /// 坐标串转换为多边形
        /// </summary>
        /// <param name="xyString"></param>
        /// <returns></returns>
        public static IPolygon ToPolygon(string xyString)
        {
            string[] xyStr = xyString.Split(';');
            IPoint pPoint = new PointClass();
            //IPolygon pPolygon1 = new PolygonClass();
            IPointCollection pPointCollection = new PolygonClass();

            object _missing = Type.Missing;
            double Lat, Lon;
            for (int i = 0; i < xyStr.Length; i++)
            {
                if (string.IsNullOrEmpty(xyStr[i]))
                    continue;
                Lon = Convert.ToDouble(xyStr[i].Split(',')[0]);
                Lat = Convert.ToDouble(xyStr[i].Split(',')[1]);
                pPoint = new PointClass();
                pPoint.X = Lon;
                pPoint.Y = Lat;
                pPoint.PutCoords(Lon, Lat);
                pPointCollection.AddPoint(pPoint, ref _missing, ref _missing);
            }
            IPolygon pPolygon = new PolygonClass();
            pPolygon = (IPolygon)pPointCollection;
            return pPolygon;
        }

        /// <summary>
        /// 经纬度坐标串转换为投影坐标多边形
        /// </summary>
        /// <param name="xyString">经纬度坐标串</param>
        /// <returns></returns>
        public static IPolygon GeoCorPointToProPolygon(string xyString)
        {
            string[] xyStr = xyString.Split(';');
            IPoint pPoint = new PointClass();
            //IPolygon pPolygon1 = new PolygonClass();
            IPointCollection pPointCollection = new PolygonClass();
            //string[] flagStr;
            //if (xyStr[xyStr.Length - 1] == "")
            //{
            //     flagStr = new string[xyStr.Length - 1];
            //     List<string > list = xyStr.ToList();//把数组转换成泛型类
            //     list.RemoveAt(xyStr.Length - 1);//利用泛型类remove掉元素
            //     flagStr = list.ToArray();//再由泛型类转换成数组
                
            //}
            //else {  flagStr = xyStr; }
            object _missing = Type.Missing;
            double Lat, Lon;
            for (int i = 0; i < xyStr.Length; i++)
            {
                if (string.IsNullOrEmpty(xyStr[i]))
                    continue;
                Lon = Convert.ToDouble(xyStr[i].Split(',')[0]);
                Lat = Convert.ToDouble(xyStr[i].Split(',')[1]);
                pPoint = new PointClass();
                //pPoint.X = Lon;
                //pPoint.Y = Lat;
                pPoint = GetProCoordinate(Lon, Lat);  //经纬度-投影坐标 转换
                //pPoint.PutCoords(Lon, Lat);
                pPointCollection.AddPoint(pPoint, ref _missing, ref _missing);
            }
            IPolygon pPolygon = new PolygonClass();
            pPolygon = (IPolygon)pPointCollection;
            return pPolygon;
        }
        // 将经纬度点转换为平面坐标
        private static IPoint GetProCoordinate(double x, double y)
        {
            //投影坐标系转换，经纬度到平面坐标
            ISpatialReferenceFactory SRFactory = new SpatialReferenceEnvironment();
            IProjectedCoordinateSystem flatref = SRFactory.CreateProjectedCoordinateSystem(2372);//80坐标
            IGeographicCoordinateSystem earthref = SRFactory.CreateGeographicCoordinateSystem((int)esriSRGeoCSType.esriSRGeoCS_WGS1984);//输入坐标

            IPoint pt = new PointClass();
            pt.PutCoords(x, y);
            IGeometry geo = (IGeometry)pt;
            geo.SpatialReference = earthref;
            geo.Project(flatref);
            return pt;
        }

        /// <summary>
        /// 多边形转换为坐标串
        /// </summary>
        /// <param name="pPolygon"></param>
        /// <returns></returns>
        public static String ToString(IPolygon pPolygon)
        {
            IPointCollection pPointCollection = pPolygon as IPointCollection;
            String xyString = "";
            for (int i = 0; i < pPointCollection.PointCount; i++)
            {
                IPoint pPoint = pPointCollection.get_Point(i);
                if (xyString == "")
                    xyString = pPoint.X + "," + pPoint.Y;
                else
                    xyString += ";" + pPoint.X + "," + pPoint.Y;
            }
            return xyString;
        }

        public static IPoint GetPoint(IPolygon pPolygon)
        {
            IPoint pPoint = new PointClass();
            IPointCollection pPointCollection = pPolygon as IPointCollection;
            double X = 0, Y = 0;
            int count = pPointCollection.PointCount - 1;
            for (int i = 0; i < count; i++)
            {
                IPoint pPoint1 = pPointCollection.get_Point(i);
                X += pPoint1.X;
                Y += pPoint1.Y;
            }
            pPoint.PutCoords(X / count, Y / count);
            return pPoint;
        }
    }
}
