using System;
using System.Collections.Generic;
using System.Text;

namespace CoScheduling.Core.Model
{
    /// <summary>
    /// 辅助实体类
    /// </summary>
   public class UAVGroup
    {
        public UAVGroup() { }
        /// <summary>
        ///
        /// </summary>
        private int _ID;
       /// <summary>
       /// ID
       /// </summary>
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private int _CompanyID;
       /// <summary>
       /// 公司ID
       /// </summary>
        public int CompanyID
        {
            get { return _CompanyID; }
            set { _CompanyID = value; }
        }
        private string _UAVCompany;
       /// <summary>
       /// 无人机公司
       /// </summary>
        public string UAVCompany
        {
            get { return _UAVCompany; }
            set { _UAVCompany = value; }
        }
        private int _UAVID;
       /// <summary>
       /// 无人机ID
       /// </summary>
        public int UAVID
        {
            get { return _UAVID; }
            set { _UAVID = value; }
        }
        private string _GName;
       /// <summary>
       /// 集结点名字
       /// </summary>
        public string GName
        {
            get { return _GName; }
            set { _GName = value; }
        }
        private int _GID;
       /// <summary>
       /// 集结点ID
       /// </summary>
        public int GID
        {
            get { return _GID; }
            set { _GID = value; }
        }
        private string _Time;
       /// <summary>
       /// 耗时
       /// </summary>
        public string Time
        {
            get { return _Time; }
            set { _Time = value; }
        }
        private double _Length;
       /// <summary>
       /// 路线长度
       /// </summary>
        public double Length
        {
            get { return _Length; }
            set { _Length = value; }
        }


        

    }
}
