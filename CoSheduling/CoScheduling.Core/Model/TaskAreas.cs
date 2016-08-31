using System;
using System.Collections.Generic;
using System.Text;

namespace CoScheduling.Core.Model
{
    /// <summary>
    /// 实体类 任务区
    /// </summary>
    [Serializable]
    public class TaskAreas
    {
        public TaskAreas()
        { }
        private int _id, _pid, _grade, _gid, _uid,_orders, _uCount;
        private string _name, _polygonstring;
        private double _Area, _X, _Y, _TraTime, _FlyTime;

        /// <summary>
        /// 任务区的无人机数量（类似于集结点），便于重新规划
        /// </summary>
        public int UCount
        {
            set { _uCount = value; }
            get { return _uCount; }
        }

        /// <summary>
        /// ID
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 灾区表ID
        /// </summary>
        public int PID
        {
            set { _pid = value; }
            get { return _pid; }
        }
        /// <summary>
        /// 灾区等级
        /// </summary>
        public int Grade
        {
            set { _grade = value; }
            get { return _grade; }
        }
        /// <summary>
        /// 集结点ID 计算辅助字段
        /// </summary>
        public int GID
        {
            set { _gid = value; }
            get { return _gid; }
        }
        /// <summary>
        /// 无人机ID 计算辅助字段
        /// </summary>
        public int UID
        {
            set { _uid = value; }
            get { return _uid; }
        }

        /// <summary>
        /// 执行顺序 计算辅助字段
        /// </summary>
        public int Orders
        {
            set { _orders = value; }
            get { return _orders; }
        }

        /// <summary>
        /// 任务区名称
        /// </summary>
        public String Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 多边形坐标串
        /// </summary>
        public String PolygonString
        {
            set { _polygonstring = value; }
            get { return _polygonstring; }
        }
        /// <summary>
        /// 面积
        /// </summary>
        public double Area
        {
            set { _Area = value; }
            get { return _Area; }
        }
        /// <summary>
        /// X坐标
        /// </summary>
        public double X
        {
            set { _X = value; }
            get { return _X; }
        }
        /// <summary>
        /// Y坐标
        /// </summary>
        public double Y
        {
            set { _Y = value; }
            get { return _Y; }
        }
        /// <summary>
        /// 交通时间 规划辅助字段
        /// </summary>
        public double TraTime
        {
            set { _TraTime = value; }
            get { return _TraTime; }
        }
        /// <summary>
        /// 航拍时间 规划辅助字段
        /// </summary>
        public double FlyTime
        {
            set { _FlyTime = value; }
            get { return _FlyTime; }
        }
    }
}
