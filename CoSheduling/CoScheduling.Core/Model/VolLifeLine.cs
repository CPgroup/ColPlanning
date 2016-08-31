//------------------------------------------------------------------------------
// 创建标识: 尹健
// 创建描述: 志愿者上报的生命线实体类
// 创建时间:2014.10.29
// 文件版本:1.0
// 功能描述: 
// 修改标识: 
// 修改描述: 
//------------------------------------------------------------------------------


using System;

namespace CoScheduling.Core.Model
{
	/// <summary>
	/// 实体类 VolLifeLine
	/// </summary>
	[Serializable]
	public class VolLifeLine
	{
		public VolLifeLine()
		{ }

		/// <summary>
		/// 构造函数 VolLifeLine
		/// </summary>
		/// <param name="iD">ID</param>
		/// <param name="telNum">上传人手机号</param>
		/// <param name="name">志愿者姓名</param>
		/// <param name="road">生命线道路名称</param>
		/// <param name="gPSString">gps字符串</param>
        public VolLifeLine(int iD, string telNum, string volName, string road, string gPSString, string describe, DateTime time)
		{
			_iD = iD;
			_telNum = telNum;
            _volName = volName;
			_road = road;
			_gPSString = gPSString;
            _describe = describe;
            _time = time;
		}

		#region Model
		private int _iD;
        private string _telNum;
        private string _volName;
		private string _road;
		private string _gPSString;
        private string _describe;
        private DateTime _time;
		/// <summary>
		/// ID
		/// </summary>
		public int ID
		{
			set { _iD = value; }
			get { return _iD; }
		}
		/// <summary>
		/// 上传人手机号
		/// </summary>
        public string TelNum
		{
			set { _telNum = value; }
			get { return _telNum; }
		}
		/// <summary>
		/// 志愿者姓名
		/// </summary>
        public string VolName
		{
            set { _volName = value; }
            get { return _volName; }
		}
        /// <summary>
        /// 上传时间
        /// </summary>
        public DateTime Time
        {
            set { _time = value; }
            get { return _time; }
        }
		/// <summary>
		/// 生命线道路名称
		/// </summary>
		public string Road
		{
			set { _road = value; }
			get { return _road; }
		}
		/// <summary>
		/// gps字符串
		/// </summary>
		public string GPSString
		{
			set { _gPSString = value; }
			get { return _gPSString; }
		}
        /// <summary>
        /// 描述
        /// </summary>
        public string Describe
        {
            set { _describe = value; }
            get { return _describe; }
        }
		#endregion Model
	}
}
