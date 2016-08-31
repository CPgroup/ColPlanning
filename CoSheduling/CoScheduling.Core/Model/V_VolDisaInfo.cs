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
	/// 实体类 V_VolDisaInfo
	/// </summary>
	[Serializable]
	public class V_VolDisaInfo
	{
		public V_VolDisaInfo()
		{ }

		/// <summary>
		/// 构造函数 V_VolDisaInfo
		/// </summary>
		/// <param name="realName">RealName</param>
		/// <param name="tel">Tel</param>
		/// <param name="type">Type</param>
		/// <param name="path">Path</param>
		/// <param name="time">Time</param>
		/// <param name="lAT">LAT</param>
		/// <param name="lON">LON</param>
		/// <param name="describe">Describe</param>
		/// <param name="disaType">DisaType</param>
		public V_VolDisaInfo(string realName, string tel, string type, string path, string time, double lAT, double lON, string describe, string disaType,int iD)
		{
			_realName = realName;
			_tel = tel;
			_type = type;
			_path = path;
			_time = time;
			_lAT = lAT;
			_lON = lON;
			_describe = describe;
			_disaType = disaType;
            _iD = iD;
		}

		#region Model
		private string _realName;
		private string _tel;
		private string _type;
		private string _path;
		private string _time;
		private double _lAT;
		private double _lON;
		private string _describe;
		private string _disaType;
        private int _iD;
        /// <summary>
        /// ID
        /// </summary>
        public int ID
        {
            set { _iD = value; }
            get { return _iD; }
        }
		/// <summary>
		/// RealName
		/// </summary>
		public string RealName
		{
			set { _realName = value; }
			get { return _realName; }
		}
		/// <summary>
		/// Tel
		/// </summary>
		public string Tel
		{
			set { _tel = value; }
			get { return _tel; }
		}
		/// <summary>
		/// Type
		/// </summary>
		public string Type
		{
			set { _type = value; }
			get { return _type; }
		}
		/// <summary>
		/// Path
		/// </summary>
		public string Path
		{
			set { _path = value; }
			get { return _path; }
		}
		/// <summary>
		/// Time
		/// </summary>
		public string Time
		{
			set { _time = value; }
			get { return _time; }
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
		/// LON
		/// </summary>
		public double LON
		{
			set { _lON = value; }
			get { return _lON; }
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
		/// DisaType
		/// </summary>
		public string DisaType
		{
			set { _disaType = value; }
			get { return _disaType; }
		}
		#endregion Model
	}
}
