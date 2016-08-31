//------------------------------------------------------------------------------
// 创建标识: 尹健
// 创建描述: 无人机GPS位置信息实体类
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
	/// 实体类 V_UAVGPSInfor
	/// </summary>
	[Serializable]
	public class UAVGPSInfor
	{
		public UAVGPSInfor()
		{ }

		/// <summary>
		/// 构造函数 V_UAVGPSInfor
		/// </summary>
		/// <param name="iD">ID</param>
		/// <param name="uID">无人机ID</param>
		/// <param name="gPSTel">联系电话</param>
		/// <param name="gPSLatitude">纬度</param>
		/// <param name="gPSLongitude">经度</param>
		/// <param name="gPSTime">上传事件</param>
		/// <param name="name">无人机名字</param>
        public UAVGPSInfor(int iD, int uID, string gPSTel, string gPSLatitude, string gPSLongitude, string gPSTime, string name,bool isChecked)
		{
			_iD = iD;
			_uID = uID;
			_gPSTel = gPSTel;
			_gPSLatitude = gPSLatitude;
			_gPSLongitude = gPSLongitude;
			_gPSTime = gPSTime;
			_name = name;
            _isChecked = isChecked;
		}

		#region Model
		private int _iD;
		private int _uID;
		private string _gPSTel;
		private string _gPSLatitude;
		private string _gPSLongitude;
		private string _gPSTime;
		private string _name;
        private bool _isChecked;
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
		/// GPSTel
		/// </summary>
		public string GPSTel
		{
			set { _gPSTel = value; }
			get { return _gPSTel; }
		}
		/// <summary>
		/// GPSLatitude
		/// </summary>
		public string GPSLatitude
		{
			set { _gPSLatitude = value; }
			get { return _gPSLatitude; }
		}
		/// <summary>
		/// GPSLongitude
		/// </summary>
		public string GPSLongitude
		{
			set { _gPSLongitude = value; }
			get { return _gPSLongitude; }
		}
		/// <summary>
		/// GPSTime
		/// </summary>
		public string GPSTime
		{
			set { _gPSTime = value; }
			get { return _gPSTime; }
		}
		/// <summary>
		/// Name
		/// </summary>
		public string Name
		{
			set { _name = value; }
			get { return _name; }
		}
        /// <summary>
        /// isChecked
        /// </summary>
        public bool isChecked
        {
            set { _isChecked = value; }
            get { return _isChecked; }
        }
		#endregion Model
	}
}
