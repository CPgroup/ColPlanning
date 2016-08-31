//------------------------------------------------------------------------------
// 创建标识: 尹健
// 创建描述: 灾区交点实体类
// 创建时间:2013.11.11
// 文件版本:1.0
// 功能描述: 
// 修改标识: 
// 修改描述: 
//------------------------------------------------------------------------------
using System;

namespace CoScheduling.Core.Model
{
    /// <summary>
    /// 实体类 DisaGatherPoint
    /// </summary>
    [Serializable]
    public class DisaGatherPoint
    {
        public DisaGatherPoint()
        { }

        /// <summary>
        /// 构造函数 DisaGatherPoint
        /// </summary>
        /// <param name="iD">ID</param>
        /// <param name="pID">灾区ID</param>
        /// <param name="pName">灾区名称</param>
        /// <param name="lAT">纬度</param>
        /// <param name="lON">经度</param>
        public DisaGatherPoint(int iD, int pID, string pName, double lAT, double lON,int UCount)
        {
            _iD = iD;
            _pID = pID;
            _pName = pName;
            _lAT = lAT;
            _lON = lON;
            _UCount = UCount;
        }

        #region Model
        private int _iD;
        private int _pID;
        private string _pName;
        private double _lAT;
        private double _lON;
        private int _UCount;
        /// <summary>
        /// ID
        /// </summary>
        public int ID
        {
            set { _iD = value; }
            get { return _iD; }
        }
        /// <summary>
        /// 任务区ID
        /// </summary>
        public int PID
        {
            set { _pID = value; }
            get { return _pID; }
        }
        /// <summary>
        /// 集结点名称
        /// </summary>
        public string PName
        {
            set { _pName = value; }
            get { return _pName; }
        }
        /// <summary>
        /// 纬度
        /// </summary>
        public double LAT
        {
            set { _lAT = value; }
            get { return _lAT; }
        }
        /// <summary>
        /// 经度
        /// </summary>
        public double LON
        {
            set { _lON = value; }
            get { return _lON; }
        }
        /// <summary>
        /// 集结点无人机数量
        /// </summary>
        public int UCount
        {
            set { _UCount = value; }
            get { return _UCount; }
        }
        #endregion Model
    }
}
