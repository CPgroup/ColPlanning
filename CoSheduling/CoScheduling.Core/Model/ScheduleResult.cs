//------------------------------------------------------------------------------
// 创建标识: 尹健
// 创建描述: 调度结果实体类
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
	/// 实体类 ScheduleResult
	/// </summary>
	[Serializable]
	public class ScheduleResult
	{
		public ScheduleResult()
		{ }

		/// <summary>
		/// 构造函数 ScheduleResult
		/// </summary>
		/// <param name="iD">ID</param>
		/// <param name="startPoint">StartPoint</param>
		/// <param name="endPoint">EndPoint</param>
		/// <param name="tranCost">TranCost</param>
		/// <param name="route">Route</param>
		/// <param name="isChecked">isChecked</param>
		public ScheduleResult(int iD, string startPoint, string endPoint, string tranCost, string route, bool isChecked,int uID,int gID,int pID)
		{
			_iD = iD;
			_startPoint = startPoint;
			_endPoint = endPoint;
			_tranCost = tranCost;
			_route = route;
			_isChecked = isChecked;
            _uID = uID;
            _gID = gID;
            _pID = pID;
		}

		#region Model
		private int _iD;
		private string _startPoint;
		private string _endPoint;
		private string _tranCost;
		private string _route;
		private bool _isChecked;
        private int _uID;
        private int _gID;
        private int _pID;

        /// <summary>
        /// 无人机ID
        /// </summary>
        public int UID
        {
            set { _uID = value; }
            get { return _uID; }
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
		/// 起始点
		/// </summary>
		public string StartPoint
		{
			set { _startPoint = value; }
			get { return _startPoint; }
		}
		/// <summary>
		/// 终点
		/// </summary>
		public string EndPoint
		{
			set { _endPoint = value; }
			get { return _endPoint; }
		}
		/// <summary>
		/// 交通花费
		/// </summary>
		public string TranCost
		{
			set { _tranCost = value; }
			get { return _tranCost; }
		}
		/// <summary>
		/// 交通路线
		/// </summary>
		public string Route
		{
			set { _route = value; }
			get { return _route; }
		}
		/// <summary>
		/// 是否选取
		/// </summary>
		public bool isChecked
		{
			set { _isChecked = value; }
			get { return _isChecked; }
		}

        /// <summary>
        /// 是否选取
        /// </summary>
        public int PID
        {
            set { _pID = value; }
            get { return _pID; }
        }

		#endregion Model
	}
}
