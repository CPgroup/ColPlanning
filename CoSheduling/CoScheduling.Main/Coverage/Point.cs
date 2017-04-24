using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoScheduling.Main.Coverage
{
    public class TargetPoint
    {
        public TargetPoint()
        {
        }
        public TargetPoint(int _pointID, decimal _pointX, decimal _pointY)
        {
            pointID = _pointID;
            pointX = _pointX;
            pointY = _pointY;
        }
        private int pointID;

        public int PointID
        {
            get { return pointID; }
            set { pointID = value; }
        }
        /// <summary>
        /// point横坐标（Lon）
        /// </summary>
        private decimal pointX;

        public decimal PointX
        {
            get { return pointX; }
            set { pointX = value; }
        }
        /// <summary>
        /// point纵坐标（Lat）
        /// </summary>
        private decimal pointY;

        public decimal PointY
        {
            get { return pointY; }
            set { pointY = value; }
        }
    }
}
