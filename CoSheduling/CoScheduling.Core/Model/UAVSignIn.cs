// 创建标识: 尹健
// 创建描述: 无人机监测——无人机签到
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
	/// 实体类 UAVSignIn
	/// </summary>
	[Serializable]
	public class UAVSignIn
	{
		public UAVSignIn()
		{ }

		/// <summary>
		/// 构造函数 UAVSignIn
		/// </summary>
		/// <param name="iD">ID</param>
		/// <param name="uID">UID</param>
		/// <param name="uAVTel">UAVTel</param>
		/// <param name="typeID">TypeID</param>
		/// <param name="uAVTime">UAVTime</param>
		/// <param name="isChecked">isChecked</param>
		/// <param name="latitude">Latitude</param>
		/// <param name="longitude">Longitude</param>
        /// <param name="TID">任务区ID</param>
        /// <param name="PID">灾区ID</param>
        public UAVSignIn(int iD, int uID, string uAVTel, string typeID, string uAVTime, bool isChecked, double latitude, double longitude, string uAVName, string tID, int pID,bool isHandled)
		{
			_iD = iD;
			_uID = uID;
			_uAVTel = uAVTel;
			_typeID = typeID;
			_uAVTime = uAVTime;
			_isChecked = isChecked;
			_latitude = latitude;
			_longitude = longitude;
            _uUAVName = uAVName;
            _tID = tID;
            _pID = pID;
            _isHandled = isHandled;
		}

		#region Model
		private int _iD;
		private int _uID;
		private string _uAVTel;
		private string _typeID;
		private string _uAVTime;
		private bool _isChecked;
        private double _latitude;
        private double _longitude;
        private string _uUAVName;
        private string _tID;
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
		/// TypeID
		/// </summary>
		public string TypeID
		{
			set { _typeID = value; }
			get { return _typeID; }
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
        /// UAVName
        /// </summary>
        public string UAVName
        {
            set { _uUAVName = value; }
            get { return _uUAVName; }
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
        /// PID
        /// </summary>
        public int PID
        {
            set { _pID = value; }
            get { return _pID; }
        }
		#endregion Model
	}
}
