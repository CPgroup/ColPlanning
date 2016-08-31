//------------------------------------------------------------------------------
// 创建标识: 尹健
// 创建描述: 任务区状态实体类
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
	/// 实体类 V_TaskState
	/// </summary>
	[Serializable]
	public class V_TaskState
	{
		public V_TaskState()
		{ }

		/// <summary>
		/// 构造函数 V_TaskState
		/// </summary>
		/// <param name="tName">TName</param>
		/// <param name="uAVName">UAVName</param>
		/// <param name="tID">TID</param>
		/// <param name="uAVID">UAVID</param>
		/// <param name="uAVTime">UAVTime</param>
		public V_TaskState(string tName, string uAVName, int tID, int uAVID, string uAVTime)
		{
			_tName = tName;
			_uAVName = uAVName;
			_tID = tID;
			_uAVID = uAVID;
			_uAVTime = uAVTime;
		}

		#region Model
		private string _tName;
		private string _uAVName;
		private int _tID;
		private int _uAVID;
		private string _uAVTime;
		/// <summary>
		/// TName
		/// </summary>
		public string TName
		{
			set { _tName = value; }
			get { return _tName; }
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
		public int TID
		{
			set { _tID = value; }
			get { return _tID; }
		}
		/// <summary>
		/// UAVID
		/// </summary>
		public int UAVID
		{
			set { _uAVID = value; }
			get { return _uAVID; }
		}
		/// <summary>
		/// UAVTime
		/// </summary>
		public string UAVTime
		{
			set { _uAVTime = value; }
			get { return _uAVTime; }
		}
		#endregion Model
	}
}
