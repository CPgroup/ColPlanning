//------------------------------------------------------------------------------
// 创建标识: 董毅博
// 创建描述: 卫星高度实体类
// 创建时间:2014.7.20
// 文件版本:1.0
// 功能描述: 
// 修改标识: 
// 修改描述: 
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace CoScheduling.Core.Model
{
    /// <summary>
    /// 实体类 SatelliteAltitude
    /// </summary>
    [Serializable]
    public class SatelliteAltitude
    {
        public SatelliteAltitude()
		{ }

		/// <summary>
		/// 构造函数 SATELLITE_ALTITUDE
		/// </summary>
		/// <param name="sAT_ID">SAT_ID</param>
		/// <param name="pERIGEE">PERIGEE</param>
		/// <param name="aPOGEE">APOGEE</param>
		/// <param name="mEAN">MEAN</param>
        public SatelliteAltitude(decimal sAT_ID, decimal pERIGEE, decimal aPOGEE, decimal mEAN)
		{
			_sAT_ID = sAT_ID;
			_pERIGEE = pERIGEE;
			_aPOGEE = aPOGEE;
			_mEAN = mEAN;
		}

		#region Model
		private decimal _sAT_ID;
		private decimal _pERIGEE;
		private decimal _aPOGEE;
		private decimal _mEAN;
		/// <summary>
		/// SAT_ID
		/// </summary>
		public decimal SAT_ID
		{
			set { _sAT_ID = value; }
			get { return _sAT_ID; }
		}
		/// <summary>
		/// PERIGEE
		/// </summary>
		public decimal PERIGEE
		{
			set { _pERIGEE = value; }
			get { return _pERIGEE; }
		}
		/// <summary>
		/// APOGEE
		/// </summary>
		public decimal APOGEE
		{
			set { _aPOGEE = value; }
			get { return _aPOGEE; }
		}
		/// <summary>
		/// MEAN
		/// </summary>
		public decimal MEAN
		{
			set { _mEAN = value; }
			get { return _mEAN; }
		}
		#endregion Model
    }
}
