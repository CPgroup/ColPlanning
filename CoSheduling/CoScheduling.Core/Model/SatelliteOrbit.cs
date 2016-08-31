//------------------------------------------------------------------------------
// 创建标识: 董毅博
// 创建描述: 卫星轨道实体类
// 创建时间:2014.6.9
// 文件版本:2.0
// 功能描述: 
// 修改标识: 
// 修改描述: 
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace CoScheduling.Core.Model
{
    public class SatelliteOrbit
    {
        public SatelliteOrbit()
		{ }

		/// <summary>
		/// 构造函数 T_PUB_SATELLITEORBIT
		/// </summary>
		/// <param name="sAT_ID">SAT_ID</param>
		/// <param name="sAT_ORBITEPOCH">SAT_ORBITEPOCH</param>
		/// <param name="sAT_MEANMOTION">SAT_MEANMOTION</param>
		/// <param name="sAT_ECCENTRICITY">SAT_ECCENTRICITY</param>
		/// <param name="sAT_INCLINATION">SAT_INCLINATION</param>
		/// <param name="sAT_ARGOFPERIGEE">SAT_ARGOFPERIGEE</param>
		/// <param name="sAT_RAAN">SAT_RAAN</param>
		/// <param name="sAT_MEANANOMALY">SAT_MEANANOMALY</param>
		/// <param name="sAT_MEANMOTIONDOT">SAT_MEANMOTIONDOT</param>
		/// <param name="sAT_MEANMOTIONDOTDOT">SAT_MEANMOTIONDOTDOT</param>
		/// <param name="sAT_BSTAR">SAT_BSTAR</param>
		/// <param name="sAT_ORBITDATE">SAT_ORBITDATE</param>
        public SatelliteOrbit(decimal sAT_ID, string sAT_ORBITEPOCH, string sAT_MEANMOTION, string sAT_ECCENTRICITY, string sAT_INCLINATION, string sAT_ARGOFPERIGEE, string sAT_RAAN, string sAT_MEANANOMALY, string sAT_MEANMOTIONDOT, string sAT_MEANMOTIONDOTDOT, string sAT_BSTAR, DateTime sAT_ORBITDATE,string sAT_TLE1,string sAT_TLE2)
		{
			_sAT_ID = sAT_ID;
			_sAT_ORBITEPOCH = sAT_ORBITEPOCH;
			_sAT_MEANMOTION = sAT_MEANMOTION;
			_sAT_ECCENTRICITY = sAT_ECCENTRICITY;
			_sAT_INCLINATION = sAT_INCLINATION;
			_sAT_ARGOFPERIGEE = sAT_ARGOFPERIGEE;
			_sAT_RAAN = sAT_RAAN;
			_sAT_MEANANOMALY = sAT_MEANANOMALY;
			_sAT_MEANMOTIONDOT = sAT_MEANMOTIONDOT;
			_sAT_MEANMOTIONDOTDOT = sAT_MEANMOTIONDOTDOT;
			_sAT_BSTAR = sAT_BSTAR;
			_sAT_ORBITDATE = sAT_ORBITDATE;
            _sAT_TLE1 = sAT_TLE1;
            _sAT_TLE2=sAT_TLE2;
		}

		#region Model
		private decimal _sAT_ID;
		private string _sAT_ORBITEPOCH;
		private string _sAT_MEANMOTION;
		private string _sAT_ECCENTRICITY;
		private string _sAT_INCLINATION;
		private string _sAT_ARGOFPERIGEE;
		private string _sAT_RAAN;
		private string _sAT_MEANANOMALY;
		private string _sAT_MEANMOTIONDOT;
		private string _sAT_MEANMOTIONDOTDOT;
		private string _sAT_BSTAR;
		private DateTime _sAT_ORBITDATE;
        private string _sAT_TLE1;
        private string _sAT_TLE2;

        
		/// <summary>
		/// SAT_ID
		/// </summary>
		public decimal SAT_ID
		{
			set { _sAT_ID = value; }
			get { return _sAT_ID; }
		}
		/// <summary>
		/// SAT_ORBITEPOCH
		/// </summary>
		public string SAT_ORBITEPOCH
		{
			set { _sAT_ORBITEPOCH = value; }
			get { return _sAT_ORBITEPOCH; }
		}
		/// <summary>
		/// SAT_MEANMOTION
		/// </summary>
		public string SAT_MEANMOTION
		{
			set { _sAT_MEANMOTION = value; }
			get { return _sAT_MEANMOTION; }
		}
		/// <summary>
		/// SAT_ECCENTRICITY
		/// </summary>
		public string SAT_ECCENTRICITY
		{
			set { _sAT_ECCENTRICITY = value; }
			get { return _sAT_ECCENTRICITY; }
		}
		/// <summary>
		/// SAT_INCLINATION
		/// </summary>
		public string SAT_INCLINATION
		{
			set { _sAT_INCLINATION = value; }
			get { return _sAT_INCLINATION; }
		}
		/// <summary>
		/// SAT_ARGOFPERIGEE
		/// </summary>
		public string SAT_ARGOFPERIGEE
		{
			set { _sAT_ARGOFPERIGEE = value; }
			get { return _sAT_ARGOFPERIGEE; }
		}
		/// <summary>
		/// SAT_RAAN
		/// </summary>
		public string SAT_RAAN
		{
			set { _sAT_RAAN = value; }
			get { return _sAT_RAAN; }
		}
		/// <summary>
		/// SAT_MEANANOMALY
		/// </summary>
		public string SAT_MEANANOMALY
		{
			set { _sAT_MEANANOMALY = value; }
			get { return _sAT_MEANANOMALY; }
		}
		/// <summary>
		/// SAT_MEANMOTIONDOT
		/// </summary>
		public string SAT_MEANMOTIONDOT
		{
			set { _sAT_MEANMOTIONDOT = value; }
			get { return _sAT_MEANMOTIONDOT; }
		}
		/// <summary>
		/// SAT_MEANMOTIONDOTDOT
		/// </summary>
		public string SAT_MEANMOTIONDOTDOT
		{
			set { _sAT_MEANMOTIONDOTDOT = value; }
			get { return _sAT_MEANMOTIONDOTDOT; }
		}
		/// <summary>
		/// SAT_BSTAR
		/// </summary>
		public string SAT_BSTAR
		{
			set { _sAT_BSTAR = value; }
			get { return _sAT_BSTAR; }
		}
		/// <summary>
		/// SAT_ORBITDATE
		/// </summary>
		public DateTime SAT_ORBITDATE
		{
			set { _sAT_ORBITDATE = value; }
			get { return _sAT_ORBITDATE; }
		}
        /// <summary>
        /// 完整两行星历第一行
        /// </summary>
		public string SAT_TLE1
        {
            get { return _sAT_TLE1; }
            set { _sAT_TLE1 = value; }
        }
        
        /// <summary>
        /// 完整两行星历第二行
        /// </summary>
        public string SAT_TLE2
        {
            get { return _sAT_TLE2; }
            set { _sAT_TLE2 = value; }
        }
        #endregion

    }
}
    