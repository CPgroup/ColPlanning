//------------------------------------------------------------------------------
// 创建标识: 董毅博
// 创建描述: 卫星载荷波段实体类
// 创建时间:2013.12.4
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

    [Serializable]
    public class SatelliteBand
    {
        public SatelliteBand() { }

        /// <summary>
		/// 构造函数 SATELLITE_SENSOR_BAND_MODE
		/// </summary>
		/// <param name="bAND_MODE_NAME">BAND_MODE_NAME</param>
		/// <param name="sENSOR_NAME">SENSOR_NAME</param>
		/// <param name="sAT_ID">SAT_ID</param>
		/// <param name="sAT_NAME">SAT_NAME</param>
		/// <param name="sWATHWIDTH">SWATHWIDTH</param>
		/// <param name="iNCLINATION">INCLINATION</param>
		/// <param name="bAND_TYPE">BAND_TYPE</param>
		/// <param name="sPECTRALRANGEMIN">SPECTRALRANGEMIN</param>
		/// <param name="sPECTRALRANGEMAX">SPECTRALRANGEMAX</param>
		/// <param name="pOLARIZATION_MODE">POLARIZATION_MODE</param>
		/// <param name="sPECTRALCENTER">SPECTRALCENTER</param>
		/// <param name="bANDWIDTH">BANDWIDTH</param>
		/// <param name="sPECTRALRESOLUTION">SPECTRALRESOLUTION</param>
		/// <param name="aCROSSRESOLUTION">ACROSSRESOLUTION</param>
		/// <param name="aLONGRESOLUTION">ALONGRESOLUTION</param>
		/// <param name="vERTICALRESOLUTION">VERTICALRESOLUTION</param>
		/// <param name="sNRRATIO">SNRRATIO</param>
		/// <param name="sENSOR_ID">SENSOR_ID</param>
        public SatelliteBand(string bAND_MODE_NAME, string sENSOR_NAME, decimal sAT_ID, string sAT_NAME, decimal sWATHWIDTH, string iNCLINATION, string bAND_TYPE, decimal sPECTRALRANGEMIN, decimal sPECTRALRANGEMAX, string pOLARIZATION_MODE, string sPECTRALCENTER, string bANDWIDTH, string sPECTRALRESOLUTION, decimal aCROSSRESOLUTION, decimal aLONGRESOLUTION, string vERTICALRESOLUTION, string sNRRATIO, decimal sENSOR_ID)
		{
			_bAND_MODE_NAME = bAND_MODE_NAME;
			_sENSOR_NAME = sENSOR_NAME;
			_sAT_ID = sAT_ID;
			_sAT_NAME = sAT_NAME;
			_sWATHWIDTH = sWATHWIDTH;
			_iNCLINATION = iNCLINATION;
			_bAND_TYPE = bAND_TYPE;
			_sPECTRALRANGEMIN = sPECTRALRANGEMIN;
			_sPECTRALRANGEMAX = sPECTRALRANGEMAX;
			_pOLARIZATION_MODE = pOLARIZATION_MODE;
			_sPECTRALCENTER = sPECTRALCENTER;
			_bANDWIDTH = bANDWIDTH;
			_sPECTRALRESOLUTION = sPECTRALRESOLUTION;
			_aCROSSRESOLUTION = aCROSSRESOLUTION;
			_aLONGRESOLUTION = aLONGRESOLUTION;
			_vERTICALRESOLUTION = vERTICALRESOLUTION;
			_sNRRATIO = sNRRATIO;
			_sENSOR_ID = sENSOR_ID;
		}

		#region Model
		private string _bAND_MODE_NAME;
		private string _sENSOR_NAME;
		private decimal _sAT_ID;
		private string _sAT_NAME;
		private decimal _sWATHWIDTH;
		private string _iNCLINATION;
		private string _bAND_TYPE;
		private decimal _sPECTRALRANGEMIN;
		private decimal _sPECTRALRANGEMAX;
		private string _pOLARIZATION_MODE;
		private string _sPECTRALCENTER;
		private string _bANDWIDTH;
		private string _sPECTRALRESOLUTION;
		private decimal _aCROSSRESOLUTION;
		private decimal _aLONGRESOLUTION;
		private string _vERTICALRESOLUTION;
		private string _sNRRATIO;
		private decimal _sENSOR_ID;
		/// <summary>
		/// BAND_MODE_NAME
		/// </summary>
		public string BAND_MODE_NAME
		{
			set { _bAND_MODE_NAME = value; }
			get { return _bAND_MODE_NAME; }
		}
		/// <summary>
		/// SENSOR_NAME
		/// </summary>
		public string SENSOR_NAME
		{
			set { _sENSOR_NAME = value; }
			get { return _sENSOR_NAME; }
		}
		/// <summary>
		/// SAT_ID
		/// </summary>
		public decimal SAT_ID
		{
			set { _sAT_ID = value; }
			get { return _sAT_ID; }
		}
		/// <summary>
		/// SAT_NAME
		/// </summary>
		public string SAT_NAME
		{
			set { _sAT_NAME = value; }
			get { return _sAT_NAME; }
		}
		/// <summary>
		/// SWATHWIDTH
		/// </summary>
		public decimal SWATHWIDTH
		{
			set { _sWATHWIDTH = value; }
			get { return _sWATHWIDTH; }
		}
		/// <summary>
		/// INCLINATION
		/// </summary>
		public string INCLINATION
		{
			set { _iNCLINATION = value; }
			get { return _iNCLINATION; }
		}
		/// <summary>
		/// BAND_TYPE
		/// </summary>
		public string BAND_TYPE
		{
			set { _bAND_TYPE = value; }
			get { return _bAND_TYPE; }
		}
		/// <summary>
		/// SPECTRALRANGEMIN
		/// </summary>
		public decimal SPECTRALRANGEMIN
		{
			set { _sPECTRALRANGEMIN = value; }
			get { return _sPECTRALRANGEMIN; }
		}
		/// <summary>
		/// SPECTRALRANGEMAX
		/// </summary>
		public decimal SPECTRALRANGEMAX
		{
			set { _sPECTRALRANGEMAX = value; }
			get { return _sPECTRALRANGEMAX; }
		}
		/// <summary>
		/// POLARIZATION_MODE
		/// </summary>
		public string POLARIZATION_MODE
		{
			set { _pOLARIZATION_MODE = value; }
			get { return _pOLARIZATION_MODE; }
		}
		/// <summary>
		/// SPECTRALCENTER
		/// </summary>
		public string SPECTRALCENTER
		{
			set { _sPECTRALCENTER = value; }
			get { return _sPECTRALCENTER; }
		}
		/// <summary>
		/// BANDWIDTH
		/// </summary>
		public string BANDWIDTH
		{
			set { _bANDWIDTH = value; }
			get { return _bANDWIDTH; }
		}
		/// <summary>
		/// SPECTRALRESOLUTION
		/// </summary>
		public string SPECTRALRESOLUTION
		{
			set { _sPECTRALRESOLUTION = value; }
			get { return _sPECTRALRESOLUTION; }
		}
		/// <summary>
		/// ACROSSRESOLUTION
		/// </summary>
		public decimal ACROSSRESOLUTION
		{
			set { _aCROSSRESOLUTION = value; }
			get { return _aCROSSRESOLUTION; }
		}
		/// <summary>
		/// ALONGRESOLUTION
		/// </summary>
		public decimal ALONGRESOLUTION
		{
			set { _aLONGRESOLUTION = value; }
			get { return _aLONGRESOLUTION; }
		}
		/// <summary>
		/// VERTICALRESOLUTION
		/// </summary>
		public string VERTICALRESOLUTION
		{
			set { _vERTICALRESOLUTION = value; }
			get { return _vERTICALRESOLUTION; }
		}
		/// <summary>
		/// SNRRATIO
		/// </summary>
		public string SNRRATIO
		{
			set { _sNRRATIO = value; }
			get { return _sNRRATIO; }
		}
		/// <summary>
		/// SENSOR_ID
		/// </summary>
		public decimal SENSOR_ID
		{
			set { _sENSOR_ID = value; }
			get { return _sENSOR_ID; }
		}
		#endregion Model
	}
}
