using System;
using System.Collections.Generic;
using System.Text;

namespace CoScheduling.Core.Model
{
    public class ImgLayoutTempTimewindow
    {
        public ImgLayoutTempTimewindow()
		{ }

		/// <summary>
		/// 构造函数 IMG_LAYOUT_TEMPTIMEWINDOW
		/// </summary>
		/// <param name="lSTR_SEQID">LSTR_SEQID</param>
		/// <param name="sATID">SATID</param>
		/// <param name="tASKID">TASKID</param>
		/// <param name="sAT_STKNAME">SAT_STKNAME</param>
		/// <param name="sENSOR_ID">SENSOR_ID</param>
        /// <param name="sENSOR_STKNAME">SENSOR_STKNAME</param>
		/// <param name="pRIORITY">PRIORITY</param>
		/// <param name="gSD">GSD</param>
		/// <param name="sANGLE">SANGLE</param>
		/// <param name="sTARTTIME">STARTTIME</param>
		/// <param name="eNDTIME">ENDTIME</param>
		/// <param name="cIRCLE">CIRCLE</param>
		/// <param name="tIMELONG">TIMELONG</param>
		/// <param name="iS_AFFECT">IS_AFFECT</param>
		/// <param name="iS_OCCUPY">IS_OCCUPY</param>
		/// <param name="aFFECT_SEQID">AFFECT_SEQID</param>
		/// <param name="mAXSANGLE">MAXSANGLE</param>
		/// <param name="mINSANGLE">MINSANGLE</param>
		/// <param name="iMAGEREGION">IMAGEREGION</param>
		/// <param name="aFF_OCUSTR">AFF_OCUSTR</param>
		/// <param name="sCHEMEID">SCHEMEID</param>
        public ImgLayoutTempTimewindow(decimal lSTR_SEQID, decimal sATID, decimal tASKID, string sAT_STKNAME, decimal sENSOR_ID, string sENSOR_STKNAME, decimal pRIORITY, decimal gSD, decimal sANGLE, DateTime sTARTTIME, DateTime eNDTIME, decimal cIRCLE, decimal tIMELONG, decimal iS_AFFECT, decimal iS_OCCUPY, decimal aFFECT_SEQID, decimal mAXSANGLE, decimal mINSANGLE, string iMAGEREGION, string aFF_OCUSTR, decimal sCHEMEID)
		{
			_lSTR_SEQID = lSTR_SEQID;
			_sATID = sATID;
			_tASKID = tASKID;
			_sAT_STKNAME = sAT_STKNAME;
			_sENSOR_ID = sENSOR_ID;
            _sENSOR_STKNAME = sENSOR_STKNAME;
			_pRIORITY = pRIORITY;
			_gSD = gSD;
			_sANGLE = sANGLE;
			_sTARTTIME = sTARTTIME;
			_eNDTIME = eNDTIME;
			_cIRCLE = cIRCLE;
			_tIMELONG = tIMELONG;
			_iS_AFFECT = iS_AFFECT;
			_iS_OCCUPY = iS_OCCUPY;
			_aFFECT_SEQID = aFFECT_SEQID;
			_mAXSANGLE = mAXSANGLE;
			_mINSANGLE = mINSANGLE;
			_iMAGEREGION = iMAGEREGION;
			_aFF_OCUSTR = aFF_OCUSTR;
			_sCHEMEID = sCHEMEID;
		}

		#region Model
		private decimal _lSTR_SEQID;
		private decimal _sATID;
		private decimal _tASKID;
		private string _sAT_STKNAME;
		private decimal _sENSOR_ID;
        private string _sENSOR_STKNAME;       
		private decimal _pRIORITY;
		private decimal _gSD;
		private decimal _sANGLE;
        private DateTime _sTARTTIME;
        private DateTime _eNDTIME;
		private decimal _cIRCLE;
		private decimal _tIMELONG;
		private decimal _iS_AFFECT;
		private decimal _iS_OCCUPY;
		private decimal _aFFECT_SEQID;
		private decimal _mAXSANGLE;
		private decimal _mINSANGLE;
		private string _iMAGEREGION;
		private string _aFF_OCUSTR;
		private decimal _sCHEMEID;
		/// <summary>
		/// LSTR_SEQID
		/// </summary>
		public decimal LSTR_SEQID
		{
			set { _lSTR_SEQID = value; }
			get { return _lSTR_SEQID; }
		}
		/// <summary>
		/// SATID
		/// </summary>
		public decimal SATID
		{
			set { _sATID = value; }
			get { return _sATID; }
		}
		/// <summary>
		/// TASKID
		/// </summary>
		public decimal TASKID
		{
			set { _tASKID = value; }
			get { return _tASKID; }
		}
		/// <summary>
		/// SAT_STKNAME
		/// </summary>
		public string SAT_STKNAME
		{
			set { _sAT_STKNAME = value; }
			get { return _sAT_STKNAME; }
		}
		/// <summary>
		/// SENSOR_ID
		/// </summary>
		public decimal SENSOR_ID
		{
			set { _sENSOR_ID = value; }
			get { return _sENSOR_ID; }
		}
        /// <summary>
        /// SENSOR_STKNAME
        /// </summary>
        public string SENSOR_STKNAME
        {
            get { return _sENSOR_STKNAME; }
            set { _sENSOR_STKNAME = value; }
        }
		/// <summary>
		/// PRIORITY
		/// </summary>
		public decimal PRIORITY
		{
			set { _pRIORITY = value; }
			get { return _pRIORITY; }
		}
		/// <summary>
		/// GSD
		/// </summary>
		public decimal GSD
		{
			set { _gSD = value; }
			get { return _gSD; }
		}
		/// <summary>
		/// SANGLE
		/// </summary>
		public decimal SANGLE
		{
			set { _sANGLE = value; }
			get { return _sANGLE; }
		}
		/// <summary>
		/// STARTTIME
		/// </summary>
        public DateTime STARTTIME
		{
			set { _sTARTTIME = value; }
			get { return _sTARTTIME; }
		}
		/// <summary>
		/// ENDTIME
		/// </summary>
        public DateTime ENDTIME
		{
			set { _eNDTIME = value; }
			get { return _eNDTIME; }
		}
		/// <summary>
		/// CIRCLE
		/// </summary>
		public decimal CIRCLE
		{
			set { _cIRCLE = value; }
			get { return _cIRCLE; }
		}
		/// <summary>
		/// TIMELONG
		/// </summary>
		public decimal TIMELONG
		{
			set { _tIMELONG = value; }
			get { return _tIMELONG; }
		}
		/// <summary>
		/// IS_AFFECT
		/// </summary>
		public decimal IS_AFFECT
		{
			set { _iS_AFFECT = value; }
			get { return _iS_AFFECT; }
		}
		/// <summary>
		/// IS_OCCUPY
		/// </summary>
		public decimal IS_OCCUPY
		{
			set { _iS_OCCUPY = value; }
			get { return _iS_OCCUPY; }
		}
		/// <summary>
		/// AFFECT_SEQID
		/// </summary>
		public decimal AFFECT_SEQID
		{
			set { _aFFECT_SEQID = value; }
			get { return _aFFECT_SEQID; }
		}
		/// <summary>
		/// MAXSANGLE
		/// </summary>
		public decimal MAXSANGLE
		{
			set { _mAXSANGLE = value; }
			get { return _mAXSANGLE; }
		}
		/// <summary>
		/// MINSANGLE
		/// </summary>
		public decimal MINSANGLE
		{
			set { _mINSANGLE = value; }
			get { return _mINSANGLE; }
		}
		/// <summary>
		/// IMAGEREGION
		/// </summary>
		public string IMAGEREGION
		{
			set { _iMAGEREGION = value; }
			get { return _iMAGEREGION; }
		}
		/// <summary>
		/// AFF_OCUSTR
		/// </summary>
		public string AFF_OCUSTR
		{
			set { _aFF_OCUSTR = value; }
			get { return _aFF_OCUSTR; }
		}
		/// <summary>
		/// SCHEMEID
		/// </summary>
		public decimal SCHEMEID
		{
			set { _sCHEMEID = value; }
			get { return _sCHEMEID; }
		}
		#endregion Model
    }
}
