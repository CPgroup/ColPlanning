//------------------------------------------------------------------------------
// 创建标识: 尹健
// 创建描述: 无人机集结点实体类
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
	/// 实体类 AssemblyPoint
	/// </summary>
	[Serializable]
	public class AssemblyPoint
	{
		public AssemblyPoint()
		{ }

		/// <summary>
		/// 构造函数 AssemblyPoint
		/// </summary>
		/// <param name="iD">ID</param>
		/// <param name="name">集结点名称</param>
		/// <param name="tID">任务ID</param>
		/// <param name="lON">经度</param>
		/// <param name="lAT">纬度</param>
		/// <param name="roadType">道路类型</param>
		/// <param name="roadID">道路ID</param>
		/// <param name="roadName">道路名称</param>
		public AssemblyPoint(int iD, string name, int tID, double lON, double lAT, string roadType, int roadID, string roadName)
		{
			_iD = iD;
			_name = name;
			_tID = tID;
			_lON = lON;
			_lAT = lAT;
			_roadType = roadType;
			_roadID = roadID;
			_roadName = roadName;
		}

		#region Model
		private int _iD;
		private string _name;
		private int _tID;
		private double _lON;
		private double _lAT;
		private string _roadType;
		private int _roadID;
		private string _roadName;
		/// <summary>
		/// ID
		/// </summary>
		public int ID
		{
			set { _iD = value; }
			get { return _iD; }
		}
		/// <summary>
		/// 集结点名称
		/// </summary>
		public string Name
		{
			set { _name = value; }
			get { return _name; }
		}
		/// <summary>
		/// 任务ID
		/// </summary>
		public int TID
		{
			set { _tID = value; }
			get { return _tID; }
		}
		/// <summary>
		/// 经度
		/// </summary>
		public double LON
		{
			set { _lON = value; }
			get { return _lON; }
		}
		/// <summary>
		/// 纬度
		/// </summary>
		public double LAT
		{
			set { _lAT = value; }
			get { return _lAT; }
		}
		/// <summary>
		/// 道路类型
		/// </summary>
		public string RoadType
		{
			set { _roadType = value; }
			get { return _roadType; }
		}
		/// <summary>
		/// 道路ID
		/// </summary>
		public int RoadID
		{
			set { _roadID = value; }
			get { return _roadID; }
		}
		/// <summary>
		/// 道路名称
		/// </summary>
		public string RoadName
		{
			set { _roadName = value; }
			get { return _roadName; }
		}
		#endregion Model
	}
}
