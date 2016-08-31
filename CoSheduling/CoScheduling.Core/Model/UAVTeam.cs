//------------------------------------------------------------------------------
// 创建标识: 尹健
// 创建描述: 无人机监测方案实体类
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
	/// 实体类 UAVTeam
	/// </summary>
	[Serializable]
	public class UAVTeam
	{
		public UAVTeam()
		{ }

		/// <summary>
		/// 构造函数 UAVTeam
		/// </summary>
		/// <param name="iD">ID</param>
		/// <param name="managerName">ManagerName</param>
		/// <param name="companyName">CompanyName</param>
		/// <param name="teamName">TeamName</param>
		/// <param name="countNumber">CountNumber</param>
		/// <param name="uAVModel">UAVModel</param>
		/// <param name="xLongtitude">XLongtitude</param>
		/// <param name="yLatitude">YLatitude</param>
		/// <param name="updateTime">UpdateTime</param>
		/// <param name="mobileNumber">MobileNumber</param>
		public UAVTeam(int iD, string managerName, string companyName, string teamName, int countNumber, string uAVModel, double xLongtitude, double yLatitude, DateTime updateTime, string mobileNumber)
		{
			_iD = iD;
			_managerName = managerName;
			_companyName = companyName;
			_teamName = teamName;
			_countNumber = countNumber;
			_uAVModel = uAVModel;
			_xLongtitude = xLongtitude;
			_yLatitude = yLatitude;
			_updateTime = updateTime;
			_mobileNumber = mobileNumber;
		}

		#region Model
		private int _iD;
		private string _managerName;
		private string _companyName;
		private string _teamName;
		private int _countNumber;
		private string _uAVModel;
		private double _xLongtitude;
		private double _yLatitude;
		private DateTime _updateTime;
		private string _mobileNumber;
		/// <summary>
		/// ID
		/// </summary>
		public int ID
		{
			set { _iD = value; }
			get { return _iD; }
		}
		/// <summary>
		/// ManagerName
		/// </summary>
		public string ManagerName
		{
			set { _managerName = value; }
			get { return _managerName; }
		}
		/// <summary>
		/// CompanyName
		/// </summary>
		public string CompanyName
		{
			set { _companyName = value; }
			get { return _companyName; }
		}
		/// <summary>
		/// TeamName
		/// </summary>
		public string TeamName
		{
			set { _teamName = value; }
			get { return _teamName; }
		}
		/// <summary>
		/// CountNumber
		/// </summary>
		public int CountNumber
		{
			set { _countNumber = value; }
			get { return _countNumber; }
		}
		/// <summary>
		/// UAVModel
		/// </summary>
		public string UAVModel
		{
			set { _uAVModel = value; }
			get { return _uAVModel; }
		}
		/// <summary>
		/// XLongtitude
		/// </summary>
		public double XLongtitude
		{
			set { _xLongtitude = value; }
			get { return _xLongtitude; }
		}
		/// <summary>
		/// YLatitude
		/// </summary>
		public double YLatitude
		{
			set { _yLatitude = value; }
			get { return _yLatitude; }
		}
		/// <summary>
		/// UpdateTime
		/// </summary>
		public DateTime UpdateTime
		{
			set { _updateTime = value; }
			get { return _updateTime; }
		}
		/// <summary>
		/// MobileNumber
		/// </summary>
		public string MobileNumber
		{
			set { _mobileNumber = value; }
			get { return _mobileNumber; }
		}
		#endregion Model
	}
}
