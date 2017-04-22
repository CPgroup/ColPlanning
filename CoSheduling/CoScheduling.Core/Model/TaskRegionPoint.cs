//------------------------------------------------------------------------------
// 创建标识: 李佳霖
// 创建描述: 任务区域边界点实体类
// 创建时间: 2017.3.1
// 文件版本:1.0
// 功能描述: 
// 修改标识: 
// 修改描述: 
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CoScheduling.Core.Model
{
    /// <summary>
    /// 用于表示任务区域边界点的实体类
    /// </summary>
    [Serializable]
    public class TaskRegionPoint
    {
        public TaskRegionPoint()
        { }

        public TaskRegionPoint(decimal TaskID,decimal PointID,decimal Point_Lon,decimal Point_Lat)
        {
            _TaskID = TaskID;
            _PointID = PointID;
            _Point_Lon = Point_Lon;
            _Point_Lat = Point_Lat;
        }

        private decimal _TaskID;
        private decimal _PointID;
        private decimal _Point_Lon;
        private decimal _Point_Lat;
        /// <summary>
        /// 任务ID
        /// </summary>
        public decimal TaskID
        {
            set { _TaskID = value; }
            get { return _TaskID; }
        }
        /// <summary>
        /// 边界点ID
        /// </summary>
        public decimal PointID
        {
            set { _PointID = value; }
            get { return _PointID; }
        }
        /// <summary>
        /// 边界点经度
        /// </summary>
        public decimal Point_Lon
        {
            set { _Point_Lon = value; }
            get { return _Point_Lon; }
        }
        /// <summary>
        /// 边界点纬度
        /// </summary>
        public decimal Point_Lat
        {
            set { _Point_Lat = value; }
            get { return _Point_Lat; }
        }




    }
}
