//------------------------------------------------------------------------------
// 创建标识: 尹健
// 创建描述: 无人机故障完全实体类
// 创建时间:2013.11.15
// 文件版本:1.0
// 功能描述: 
// 修改标识: 
// 修改描述: 
//------------------------------------------------------------------------------

using System;

namespace CoScheduling.Core.Model
{
	/// <summary>
	/// 实体类 UAVFinishEvents
	/// </summary>
	[Serializable]
	public class UAVFinishEvents
	{
		public UAVFinishEvents()
		{ }

		/// <summary>
		/// 构造函数 UAVFinishEvents
		/// </summary>
		/// <param name="iD">ID</param>
		/// <param name="pID">PID</param>
		/// <param name="tID">TID</param>
		/// <param name="typeID">TypeID</param>
		/// <param name="describe">Describe</param>
		/// <param name="eventID">完成</param>
		/// <param name="uID">UID</param>
		public UAVFinishEvents(int iD, int pID, int tID, string typeID, string describe, string eventID, int uID,bool isChecked,string uAVTime,bool isHandled)
		{
			_iD = iD;
			_pID = pID;
			_tID = tID;
			_typeID = typeID;
			_describe = describe;
			_eventID = eventID;
			_uID = uID;
            _isChecked = isChecked;
            _uAVTime = uAVTime;
            _isHandled = isHandled;
		}

		#region Model
		private int _iD;
		private int _pID;
		private int _tID;
		private string _typeID;
		private string _describe;
		private string _eventID;
		private int _uID;
        private bool _isChecked;
        private string _uAVTime;
        private bool _isHandled;

        /// <summary>
        /// 是否处理事件
        /// </summary>
        public bool isHandled
        {
            set { _isHandled = value; }
            get { return _isHandled; }
        }

        /// <summary>
        /// UAVTime
        /// </summary>
        public string UAVTime
        {
            set { _uAVTime = value; }
            get { return _uAVTime; }
        }

        /// <summary>
        /// isChecked
        /// </summary>
        public bool isChecked
        {
            set { _isChecked = value; }
            get { return _isChecked; }
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
		/// PID
		/// </summary>
		public int PID
		{
			set { _pID = value; }
			get { return _pID; }
		}
		/// <summary>
		/// TID
		/// </summary>
		public int TID
		{
			set { _tID = value; }
			get { return _tID; }
		}
		/// <summary>
		/// TypeID
		/// </summary>
		public string TypeID
		{
			set { _typeID = value; }
			get { return _typeID; }
		}
		/// <summary>
		/// Describe
		/// </summary>
		public string Describe
		{
			set { _describe = value; }
			get { return _describe; }
		}
		/// <summary>
		/// 完成
		/// </summary>
		public string EventID
		{
			set { _eventID = value; }
			get { return _eventID; }
		}
		/// <summary>
		/// UID
		/// </summary>
		public int UID
		{
			set { _uID = value; }
			get { return _uID; }
		}
		#endregion Model
	}
}
