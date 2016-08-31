//------------------------------------------------------------------------------
// 创建标识: 尹健
// 创建描述: 规划结果实体类
// 创建时间:2014.6.26
// 文件版本:1.0
// 功能描述: 
// 修改标识: 
// 修改描述: 
//------------------------------------------------------------------------------

using System;

namespace CoScheduling.Core.Model
{
	/// <summary>
	/// 实体类 PlanResult
	/// </summary>
	[Serializable]
	public class PlanResult
	{
		public PlanResult()
		{ }

		/// <summary>
		/// 构造函数 PlanResult
		/// </summary>
		/// <param name="iD">ID</param>
		/// <param name="uAVID">无人机ID</param>
		/// <param name="uAVName">无人机名称</param>
		/// <param name="totalCost">总花费</param>
		/// <param name="tID">任务区ID</param>
		/// <param name="tName">任务名称</param>
		/// <param name="tLAT">任务纬度</param>
		/// <param name="tLON">任务经度</param>
		/// <param name="tCost">交通成本</param>
		/// <param name="fCost">航拍成本</param>
        /// <param name="PID">灾区ID</param>
        /// <param name="GID">集结点ID</param>
        public PlanResult(int iD, int uAVID, string uAVName, string totalCost, int tID, string tName, double tLAT, double tLON, string tCost, string fCost, int pID,int gID,int state)
		{
			_iD = iD;
			_uAVID = uAVID;
			_uAVName = uAVName;
			_totalCost = totalCost;
			_tID = tID;
			_tName = tName;
			_tLAT = tLAT;
			_tLON = tLON;
			_tCost = tCost;
			_fCost = fCost;
            _pID = pID;
            _gID = gID;
            _state = state;
		}

		#region Model
		private int _iD;
		private int _uAVID;
		private string _uAVName;
		private string _totalCost;
		private int _tID;
		private string _tName;
		private double _tLAT;
		private double _tLON;
		private string _tCost;
		private string _fCost;
        private int _pID;
        private int _gID;
        private int _state;

        /// <summary>
        /// 任务区状态，0--未执行，1--正在执行，2--已完成
        /// </summary>
        public int State
        {
            set { _state = value; }
            get { return _state; }
        }

        /// <summary>
        /// 集结点ID
        /// </summary>
        public int GID
        {
            set { _gID = value; }
            get { return _gID; }
        }
		/// <summary>
		/// ID
		/// </summary>
		public int ID
		{
			set { _iD = value; }
			get { return _iD; }
		}
		/// <summary>
		/// 无人机ID
		/// </summary>
		public int UAVID
		{
			set { _uAVID = value; }
			get { return _uAVID; }
		}
		/// <summary>
		/// 无人机名称
		/// </summary>
		public string UAVName
		{
			set { _uAVName = value; }
			get { return _uAVName; }
		}
		/// <summary>
		/// 总花费
		/// </summary>
		public string TotalCost
		{
			set { _totalCost = value; }
			get { return _totalCost; }
		}
		/// <summary>
		/// 任务区ID
		/// </summary>
		public int TID
		{
			set { _tID = value; }
			get { return _tID; }
		}
		/// <summary>
		/// 任务名称
		/// </summary>
		public string TName
		{
			set { _tName = value; }
			get { return _tName; }
		}
		/// <summary>
		/// 任务纬度
		/// </summary>
		public double TLAT
		{
			set { _tLAT = value; }
			get { return _tLAT; }
		}
		/// <summary>
		/// 任务经度
		/// </summary>
		public double TLON
		{
			set { _tLON = value; }
			get { return _tLON; }
		}
		/// <summary>
		/// 交通成本
		/// </summary>
		public string TCost
		{
			set { _tCost = value; }
			get { return _tCost; }
		}
		/// <summary>
		/// 航拍成本
		/// </summary>
		public string FCost
		{
			set { _fCost = value; }
			get { return _fCost; }
		}
        /// <summary>
        /// 灾区ID
        /// </summary>
        public int PID
        {
            set { _pID = value; }
            get { return _pID; }
        }
		#endregion Model
	}
}
