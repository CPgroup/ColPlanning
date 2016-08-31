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
	/// 实体类 V_VolLifeLine
	/// </summary>
	[Serializable]
	public class V_VolLifeLine
	{
		public V_VolLifeLine()
		{ }

		/// <summary>
		/// 构造函数 V_VolLifeLine
		/// </summary>
		/// <param name="iD">ID</param>
		/// <param name="tel">Tel</param>
		/// <param name="startStr">StartStr</param>
		/// <param name="endStr">EndStr</param>
		/// <param name="describe">Describe</param>
		/// <param name="roadPoint">RoadPoint</param>
		/// <param name="isChecked">IsChecked</param>
		/// <param name="type">Type</param>
		/// <param name="realName">RealName</param>
		public V_VolLifeLine(int iD, string tel, string startStr, string endStr, string describe, string roadPoint, string isChecked, string type, string realName,string time)
		{
			_iD = iD;
			_tel = tel;
			_startStr = startStr;
			_endStr = endStr;
			_describe = describe;
			_roadPoint = roadPoint;
			_isChecked = isChecked;
			_type = type;
			_realName = realName;
            _time = time;
		}

		#region Model
		private int _iD;
		private string _tel;
		private string _startStr;
		private string _endStr;
		private string _describe;
		private string _roadPoint;
		private string _isChecked;
		private string _type;
		private string _realName;
        private string _time;
		/// <summary>
		/// ID
		/// </summary>
		public int ID
		{
			set { _iD = value; }
			get { return _iD; }
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
		/// StartStr
		/// </summary>
		public string StartStr
		{
			set { _startStr = value; }
			get { return _startStr; }
		}
		/// <summary>
		/// EndStr
		/// </summary>
		public string EndStr
		{
			set { _endStr = value; }
			get { return _endStr; }
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
		/// RoadPoint
		/// </summary>
		public string RoadPoint
		{
			set { _roadPoint = value; }
			get { return _roadPoint; }
		}
		/// <summary>
		/// IsChecked
		/// </summary>
		public string IsChecked
		{
			set { _isChecked = value; }
			get { return _isChecked; }
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
		/// RealName
		/// </summary>
		public string RealName
		{
			set { _realName = value; }
			get { return _realName; }
		}
        /// <summary>
        /// 时间
        /// </summary>
        public string Time
        {
            set { _time = value; }
            get { return _time; }
        }
		#endregion Model
	}
}
