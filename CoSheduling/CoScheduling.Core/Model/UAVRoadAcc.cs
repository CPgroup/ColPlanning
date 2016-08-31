//------------------------------------------------------------------------------
// 创建标识: 尹健
// 创建描述: 无人机监测——道路状况
// 创建时间:2014.6.28
// 文件版本:1.0
// 功能描述: 
// 修改标识: 
// 修改描述: 
//------------------------------------------------------------------------------

using System;

namespace CoScheduling.Core.Model
{
	/// <summary>
	/// 实体类 UAVRoadAcc
	/// </summary>
	[Serializable]
	public class UAVRoadAcc
	{
		public UAVRoadAcc()
		{ }

		/// <summary>
		/// 构造函数 UAVRoadAcc
		/// </summary>
		/// <param name="iD">ID</param>
		/// <param name="uID">无人机ID</param>
		/// <param name="uAVTel">编队电话</param>
		/// <param name="typeID">事件ID</param>
		/// <param name="uAVRepair">是否能修复</param>
		/// <param name="uAVDescribe">状况描述</param>
		/// <param name="uAVTime">时间</param>
        /// <param name="isChecked">是否已经上报</param>
        /// <param name="Destination">目的地</param>
        public UAVRoadAcc(int iD, int uID, string uAVTel, string typeID, string uAVRepair, string uAVDescribe, string uAVTime, bool isChecked, double lON, double lAT, string uAVName, string destination, string time, int pID, bool isHandled)
		{
			_iD = iD;
			_uID = uID;
			_uAVTel = uAVTel;
			_typeID = typeID;
			_uAVRepair = uAVRepair;
			_uAVDescribe = uAVDescribe;
			_uAVTime = uAVTime;
            _isChecked = isChecked;
            _lON = lON;
            _lAT = lAT;
            _uAVName = uAVName;
            _destination = destination;
            _time = time;
            _pID = pID;
		}

		#region Model
		private int _iD;
		private int _uID;
		private string _uAVTel;
		private string _typeID;
		private string _uAVRepair;
		private string _uAVDescribe;
		private string _uAVTime;
        private bool _isChecked;
        private double _lON;
        private double _lAT;
        private string _uAVName;
        private string _destination;
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
		/// UAVDescribe
		/// </summary>
		public string UAVDescribe
		{
			set { _uAVDescribe = value; }
			get { return _uAVDescribe; }
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
        /// isReport
        /// </summary>
        public bool isChecked
        {
            set { _isChecked = value; }
            get { return _isChecked; }
        }
        /// <summary>
        /// LON
        /// </summary>
        public double LON
        {
            set { _lON = value; }
            get { return _lON; }
        }
        /// <summary>
        /// LAT
        /// </summary>
        public double LAT
        {
            set { _lAT = value; }
            get { return _lAT; }
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
        /// Destination
        /// </summary>
        public string Destination
        {
            set { _destination = value; }
            get { return _destination; }
        }

        /// <summary>
        /// Time
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
