//------------------------------------------------------------------------------
// 创建标识: 尹健
// 创建描述: 无人机当前任务实体类
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
	/// 实体类 UAVCurrentTask
	/// </summary>
	[Serializable]
	public class UAVCurrentTask
	{
		public UAVCurrentTask()
		{ }

		/// <summary>
		/// 构造函数 UAVCurrentTask
		/// </summary>
		/// <param name="iD">ID</param>
		/// <param name="pID">PID</param>
		/// <param name="lON">LON</param>
		/// <param name="lAT">LAT</param>
		/// <param name="taskString">TaskString</param>
		/// <param name="uID">UID</param>
		public UAVCurrentTask(int iD, int pID, double lON, double lAT, string taskString, int uID,int tID)
		{
			_iD = iD;
			_pID = pID;
			_lON = lON;
			_lAT = lAT;
			_taskString = taskString;
			_uID = uID;
            _tID = tID;
		}

		#region Model
		private int _iD;
		private int _pID;
		private double _lON;
		private double _lAT;
		private string _taskString;
		private int _uID;
        private int _tID;
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
		/// TaskString
		/// </summary>
		public string TaskString
		{
			set { _taskString = value; }
			get { return _taskString; }
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
		#endregion Model
	}
}
