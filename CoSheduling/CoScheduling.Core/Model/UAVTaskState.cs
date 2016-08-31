//------------------------------------------------------------------------------
// 创建标识: 尹健
// 创建描述: 无人机监测——无人机作业
// 创建时间:2014.6.29
// 文件版本:1.0
// 功能描述: 
// 修改标识: 
// 修改描述: 
//------------------------------------------------------------------------------

using System;

namespace CoScheduling.Core.Model
{
	/// <summary>
	/// 实体类 UAVTaskState
	/// </summary>
	[Serializable]
	public class UAVTaskState
	{
		public UAVTaskState()
		{ }

		/// <summary>
		/// 构造函数 UAVTaskState
		/// </summary>
		/// <param name="iD">ID</param>
		/// <param name="uID">UID</param>
		/// <param name="uAVTel">UAVTel</param>
		/// <param name="uAVTask">UAVTask</param>
		/// <param name="typeID">TypeID</param>
		/// <param name="uAVRepair">UAVRepair</param>
		/// <param name="uAVAdd">UAVAdd</param>
		/// <param name="uAVTime">UAVTime</param>
		/// <param name="latitude">Latitude</param>
		/// <param name="longitude">Longitude</param>
		/// <param name="isChecked">isChecked</param>
        /// <param name="TID">任务ID</param>
        /// <param name="Time">预计花费时间</param>
        public UAVTaskState(int iD, int uID, string uAVTel, string uAVTask, string typeID, string uAVRepair, string uAVAdd, string uAVTime, double latitude, double longitude, bool isChecked, string uAVName, string tID, string time, int pID,bool isHandled)
		{
			_iD = iD;
			_uID = uID;
			_uAVTel = uAVTel;
			_uAVTask = uAVTask;
			_typeID = typeID;
			_uAVRepair = uAVRepair;
			_uAVAdd = uAVAdd;
			_uAVTime = uAVTime;
			_latitude = latitude;
			_longitude = longitude;
			_isChecked = isChecked;
            _uAVName = uAVName;
            _tID = tID;
            _time = time;
            _pID = pID;
            _isHandled=isHandled;
		}

		#region Model
		private int _iD;
		private int _uID;
		private string _uAVTel;
		private string _uAVTask;
		private string _typeID;
		private string _uAVRepair;
		private string _uAVAdd;
		private string _uAVTime;
        private double _latitude;
        private double _longitude;
		private bool _isChecked;
        private string _uAVName;
        private string _tID;
        private string _time;
        private int _pID;
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
		/// ID
		/// </summary>
		public int ID
		{
			set { _iD = value; }
			get { return _iD; }
		}
		/// <summary>
		/// UID
		/// </summary>
		public int UID
		{
			set { _uID = value; }
			get { return _uID; }
		}
		/// <summary>
		/// UAVTel
		/// </summary>
		public string UAVTel
		{
			set { _uAVTel = value; }
			get { return _uAVTel; }
		}
		/// <summary>
		/// UAVTask
		/// </summary>
		public string UAVTask
		{
			set { _uAVTask = value; }
			get { return _uAVTask; }
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
		/// UAVRepair
		/// </summary>
		public string UAVRepair
		{
			set { _uAVRepair = value; }
			get { return _uAVRepair; }
		}
		/// <summary>
		/// UAVAdd
		/// </summary>
		public string UAVAdd
		{
			set { _uAVAdd = value; }
			get { return _uAVAdd; }
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
		/// Latitude
		/// </summary>
        public double Latitude
		{
			set { _latitude = value; }
			get { return _latitude; }
		}
		/// <summary>
		/// Longitude
		/// </summary>
        public double Longitude
		{
			set { _longitude = value; }
			get { return _longitude; }
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
        /// UAVName
        /// </summary>
        public string UAVName
        {
            set { _uAVName = value; }
            get { return _uAVName; }
        }
        /// <summary>
        /// TID
        /// </summary>
        public string TID
        {
            set { _tID = value; }
            get { return _tID; }
        }

        /// <summary>
        /// 预计时间
        /// </summary>
        public string Time
        {
            set { _time = value; }
            get { return _time; }
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
