//------------------------------------------------------------------------------
// 创建标识: 尹健
// 创建描述: 灾区监测实体类
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
	/// 实体类 MonitorTask
	/// </summary>
	[Serializable]
	public class MonitorTask
	{
		public MonitorTask()
		{ }

		/// <summary>
		/// 构造函数 MonitorTask
		/// </summary>
		/// <param name="iD">ID</param>
		/// <param name="pID">PID</param>
		/// <param name="name">监测任务名</param>
		/// <param name="polygonString">任务区域</param>
		/// <param name="mBR">外包矩形</param>
		public MonitorTask(int iD, int pID, string name, byte[] polygonString, string mBR)
		{
			_iD = iD;
			_pID = pID;
			_name = name;
			_polygonString = polygonString;
			_mBR = mBR;
		}

		#region Model
		private int _iD;
		private int _pID;
		private string _name;
		private byte[] _polygonString;
		private string _mBR;
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
		/// 监测任务名
		/// </summary>
		public string Name
		{
			set { _name = value; }
			get { return _name; }
		}
		/// <summary>
		/// 任务区域
		/// </summary>
		public byte[] PolygonString
		{
			set { _polygonString = value; }
			get { return _polygonString; }
		}
		/// <summary>
		/// 外包矩形
		/// </summary>
		public string MBR
		{
			set { _mBR = value; }
			get { return _mBR; }
		}
		#endregion Model
	}
}
