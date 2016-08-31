using System;
using System.Collections.Generic;

using System.Text;

namespace CoScheduling.MonitorTask.Geometry
{
    /// <summary>
    /// 类名：灾区范围
    /// 作者：李光强
    /// 时间：2013.11.12
    /// </summary>
    public class DisasterArea
    {      
        private double xmin, ymin, xmax, ymax;

        public double XMin { get { return xmin; } }
        public double YMin { get { return ymin; } }
        public double XMax { get { return xmax; } }
        public double YMax { get { return ymax; } }

        public double Width { get { return xmax - xmin; } }
        public double Height { get { return ymax - ymin; } }
        
        /// <summary>
        /// 构建函数
        /// </summary>
        /// <param name="Center">中心点</param>
        /// <param name="Radius">半径</param>
        public DisasterArea(Point Center, double Radius)
        {
            xmin = Center.X - Radius;
            ymin = Center.Y - Radius;
            xmax = Center.X + Radius;
            ymax = Center.Y + Radius;
        }

        public DisasterArea(double Xmin, double Ymin, double Xmax, double Ymax)
        {
            xmin = Xmin;
            ymin = Ymin;
            xmax = Xmax;
            ymax = Ymax;
        }


    }
}
