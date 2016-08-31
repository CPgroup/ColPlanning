//------------------------------------------------------------------------------
// 创建标识: 尹健
// 创建描述: 障碍点实体类
// 创建时间:2014.8.23
// 文件版本:1.0
// 功能描述: 
// 修改标识: 
// 修改描述: 
//------------------------------------------------------------------------------

using System;

namespace CoScheduling.Core.Model
{
	/// <summary>
	/// 实体类 Barries
	/// </summary>
	[Serializable]
	public class Barries
	{
		public Barries()
		{ }

		/// <summary>
		/// 构造函数 Barries
		/// </summary>
		/// <param name="iD">ID</param>
		/// <param name="lON">经度</param>
		/// <param name="lAT">纬度</param>
		/// <param name="pID">所属灾区ID</param>
		/// <param name="name">障碍点名称</param>
        public Barries(int iD, double lON, double lAT, int pID, string name,int uID)
		{
			_iD = iD;
			_lON = lON;
			_lAT = lAT;
			_pID = pID;
			_name = name;
            _uID = uID;
		}

		#region Model
		private int _iD;
		private double _lON;
		private double _lAT;
        private int _pID;
		private string _name;
        private int _uID;

        /// <summary>
        /// UID
        /// </summary>
        public int UID
        {
            set { _uID = value; }
            get { return _uID; }
        }

		/// <summary>
		/// ID
		/// </summary>
		public int ID
		{
			set { _iD = value; }
			get { return _iD; }
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
		/// 所属灾区ID
		/// </summary>
        public int PID
		{
			set { _pID = value; }
			get { return _pID; }
		}
		/// <summary>
		/// 障碍点名称
		/// </summary>
		public string Name
		{
			set { _name = value; }
			get { return _name; }
		}
		#endregion Model
	}
}
