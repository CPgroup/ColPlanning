// 创建标识: 尹健
// 创建描述: 无人机监测——无人机任务申请
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
	/// 实体类 UAVTaskApply
	/// </summary>
	[Serializable]
	public class UAVTaskApply
	{
		public UAVTaskApply()
		{ }

		/// <summary>
		/// 构造函数 UAVTaskApply
		/// </summary>
		/// <param name="iD">ID</param>
		/// <param name="uID">UID</param>
		/// <param name="tID">TID</param>
		/// <param name="pID">PID</param>
		/// <param name="describe">Describe</param>
		/// <param name="typeID">TypeID</param>
		public UAVTaskApply(int iD, int uID, int tID, int pID, string describe, string typeID,bool isHandled,string uAVTime)
		{
			_iD = iD;
			_uID = uID;
			_tID = tID;
			_pID = pID;
			_describe = describe;
			_typeID = typeID;
            _isHandled = isHandled;
            _uAVTime = uAVTime;
		}

		#region Model
		private int _iD;
		private int _uID;
		private int _tID;
		private int _pID;
		private string _describe;
		private string _typeID;
        private bool _isHandled;
        private string _uAVTime;

        /// <summary>
        /// 上传时间
        /// </summary>
        public string  UAVTime
        {
            set { _uAVTime = value; }
            get { return _uAVTime; }
        }


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
		/// TID
		/// </summary>
		public int TID
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
		/// <summary>
		/// Describe
		/// </summary>
		public string Describe
		{
			set { _describe = value; }
			get { return _describe; }
		}
		/// <summary>
		/// TypeID
		/// </summary>
		public string TypeID
		{
			set { _typeID = value; }
			get { return _typeID; }
		}
		#endregion Model
	}
}
