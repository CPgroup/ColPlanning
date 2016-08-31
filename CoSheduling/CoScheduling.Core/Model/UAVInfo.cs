//------------------------------------------------------------------------------
// 创建标识: 尹健
// 创建描述: 无人机信息
// 创建时间:2014.4.2
// 文件版本:1.0
// 功能描述: 
// 修改标识: 
// 修改描述: 
//------------------------------------------------------------------------------

using System;

namespace CoScheduling.Core.Model
{
	/// <summary>
	/// 实体类 UAVInfo
	/// </summary>
	[Serializable]
	public class UAVInfo
	{
		public UAVInfo()
		{ }

		/// <summary>
		/// 构造函数 UAVInfo
		/// </summary>
		/// <param name="id">id</param>
		/// <param name="companyName">CompanyName</param>
		/// <param name="teamName">TeamName</param>
		/// <param name="model">model</param>
		/// <param name="xLongtitude">XLongtitude</param>
		/// <param name="yLatitude">YLatitude</param>
		/// <param name="updateTime">UpdateTime</param>
		public UAVInfo(int id, string companyName, string teamName, string model, double xLongtitude, double yLatitude, DateTime updateTime)
		{
			_id = id;
			_companyName = companyName;
			_teamName = teamName;
			_model = model;
			_xLongtitude = xLongtitude;
			_yLatitude = yLatitude;
			_updateTime = updateTime;
		}

		#region Model
		private int _id;
		private string _companyName;
		private string _teamName;
		private string _model;
		private double _xLongtitude;
		private double _yLatitude;
		private DateTime _updateTime;
		/// <summary>
		/// id
		/// </summary>
		public int id
		{
			set { _id = value; }
			get { return _id; }
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
		/// model
		/// </summary>
		public string model
		{
			set { _model = value; }
			get { return _model; }
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
		#endregion Model
	}
}
