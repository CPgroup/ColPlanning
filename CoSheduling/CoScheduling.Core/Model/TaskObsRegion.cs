using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoScheduling.Core.Model
{
    /// <summary>
    /// 用于表示观测任务的位置点或者矩形区域的实体类
    /// </summary>
    [Serializable]
    public class TaskObsRegion
    {
        public TaskObsRegion()
        { }
        public TaskObsRegion(decimal TaskID,decimal MinLon,decimal MaxLon,decimal MinLat,decimal MaxLat)
        {
            _TaskID = TaskID;
            _MinLon = MinLon;
            _MaxLon = MaxLon;
            _MinLat = MinLat;
            _MaxLat = MaxLat;
        }
        //实体类的成员变量
        private decimal _TaskID;
        private decimal _MinLon;
        private decimal _MaxLon;
        private decimal _MinLat;
        private decimal _MaxLat;
        /// <summary>
        /// 任务ID
        /// </summary>
        public decimal TaskID
        {
            set { _TaskID = value; }
            get { return _TaskID; }
        }
        public decimal MinLon
        {
            set { _MinLon = value; }
            get { return _MinLon; }
        }
        public decimal MaxLon
        {
            set { _MaxLon = value; }
            get { return _MaxLon; }
        }
        public decimal MinLat
        {
            set { _MinLat = value; }
            get { return _MinLat; }
        }
        public decimal MaxLat
        {
            set { _MaxLat = value; }
            get { return _MaxLat; }
        }

        #region

        #endregion
    }
}
