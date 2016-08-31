//------------------------------------------------------------------------------
// 创建标识: 尹健
// 创建描述: 志愿者上报的灾情信息实体类
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
	/// 实体类 VolDisaInfo
	/// </summary>
	[Serializable]
	public class VolDisaInfo
	{
		public VolDisaInfo()
		{ }

		/// <summary>
		/// 构造函数 VolDisaInfo
		/// </summary>
		/// <param name="iD">ID</param>
		/// <param name="telNum">电话号码</param>
		/// <param name="name">志愿者姓名</param>
		/// <param name="disaType">灾情类别</param>
		/// <param name="describe">描述</param>
		/// <param name="photo">照片（url）</param>
		/// <param name="lAT">上传纬度</param>
		/// <param name="lON">上传经度</param>
		/// <param name="location">地名</param>
        public VolDisaInfo(int iD, string telNum, string volName, string disaType, string describe, string photo, double lAT, double lON, string location, DateTime time)
		{
			_iD = iD;
			_telNum = telNum;
            _volName = volName;
			_disaType = disaType;
			_describe = describe;
			_photo = photo;
			_lAT = lAT;
			_lON = lON;
			_location = location;
            _time = time;
		}

		#region Model
		private int _iD;
        private string _telNum;
        private string _volName;
		private string _disaType;
		private string _describe;
		private string _photo;
		private double _lAT;
		private double _lON;
		private string _location;
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
		/// 电话号码
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
		/// 灾情类别
		/// </summary>
		public string DisaType
		{
			set { _disaType = value; }
			get { return _disaType; }
		}
		/// <summary>
		/// 描述
		/// </summary>
		public string Describe
		{
			set { _describe = value; }
			get { return _describe; }
		}
		/// <summary>
		/// 照片（url）
		/// </summary>
		public string Photo
		{
			set { _photo = value; }
			get { return _photo; }
		}
		/// <summary>
		/// 上传纬度
		/// </summary>
		public double LAT
		{
			set { _lAT = value; }
			get { return _lAT; }
		}
		/// <summary>
		/// 上传经度
		/// </summary>
		public double LON
		{
			set { _lON = value; }
			get { return _lON; }
		}
		/// <summary>
		/// 地名
		/// </summary>
		public string Location
		{
			set { _location = value; }
			get { return _location; }
		}
		#endregion Model
	}
}
