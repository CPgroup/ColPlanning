using System;
using System.Collections.Generic;
using System.Text;

namespace CoScheduling.Core.Model
{
    public class LAYOUT_SATELLITE_TIMEWINDOW
    {
        public LAYOUT_SATELLITE_TIMEWINDOW()
        { }

        /// <summary>
        /// 构造函数 LAYOUT_SATELLITE_TIMEWINDOW
        /// </summary>
        /// <param name="tW_SEQID">TW_SEQID</param>
        /// <param name="sAT_STKNAME">SAT_STKNAME</param>
        /// <param name="sENSOR_STKNAME">SENSOR_STKNAME</param>
        /// <param name="tARGET_STKNAME">TARGET_STKNAME</param>
        /// <param name="sTARTTIME">STARTTIME</param>
        /// <param name="eNDTIME">ENDTIME</param>
        /// <param name="sANGLE">SANGLE</param>
        /// <param name="gSD">GSD</param>
        /// <param name="cIRCLE">CIRCLE</param>
        /// <param name="tIMELONG">TIMELONG</param>
        /// <param name="mAXSANGLE">MAXSANGLE</param>
        /// <param name="mINSANGLE">MINSANGLE</param>
        /// <param name="iMAGEREGION">IMAGEREGION</param>
        /// <param name="sCHEMEID">SCHEMEID</param>
        /// <param name="sATID">SATID</param>
        /// <param name="sENSORID">SENSORID</param>
        /// <param name="tASKID">TASKID</param>
        public LAYOUT_SATELLITE_TIMEWINDOW(decimal tW_SEQID, string sAT_STKNAME, string sENSOR_STKNAME, string tARGET_STKNAME, DateTime sTARTTIME, DateTime eNDTIME, decimal sANGLE, decimal gSD, decimal cIRCLE, decimal tIMELONG, decimal mAXSANGLE, decimal mINSANGLE, string iMAGEREGION, decimal sCHEMEID, decimal sATID, decimal sENSORID, decimal tASKID)
        {
            _tW_SEQID = tW_SEQID;
            _sAT_STKNAME = sAT_STKNAME;
            _sENSOR_STKNAME = sENSOR_STKNAME;
            _tARGET_STKNAME = tARGET_STKNAME;
            _sTARTTIME = sTARTTIME;
            _eNDTIME = eNDTIME;
            _sANGLE = sANGLE;
            _gSD = gSD;
            _cIRCLE = cIRCLE;
            _tIMELONG = tIMELONG;
            _mAXSANGLE = mAXSANGLE;
            _mINSANGLE = mINSANGLE;
            _iMAGEREGION = iMAGEREGION;
            _sCHEMEID = sCHEMEID;
            _sATID = sATID;
            _sENSORID = sENSORID;
            _tASKID = tASKID;
        }

        #region Model
        private decimal _tW_SEQID;
        private string _sAT_STKNAME;
        private string _sENSOR_STKNAME;
        private string _tARGET_STKNAME;
        private DateTime _sTARTTIME;
        private DateTime _eNDTIME;
        private decimal _sANGLE;
        private decimal _gSD;
        private decimal _cIRCLE;
        private decimal _tIMELONG;
        private decimal _mAXSANGLE;
        private decimal _mINSANGLE;
        private string _iMAGEREGION;
        private decimal _sCHEMEID;
        private decimal _sATID;
        private decimal _sENSORID;
        private decimal _tASKID;
        /// <summary>
        /// TW_SEQID
        /// </summary>
        public decimal TW_SEQID
        {
            set { _tW_SEQID = value; }
            get { return _tW_SEQID; }
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
        /// SENSOR_STKNAME
        /// </summary>
        public string SENSOR_STKNAME
        {
            set { _sENSOR_STKNAME = value; }
            get { return _sENSOR_STKNAME; }
        }
        /// <summary>
        /// TARGET_STKNAME
        /// </summary>
        public string TARGET_STKNAME
        {
            set { _tARGET_STKNAME = value; }
            get { return _tARGET_STKNAME; }
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
        /// SANGLE
        /// </summary>
        public decimal SANGLE
        {
            set { _sANGLE = value; }
            get { return _sANGLE; }
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
        /// SCHEMEID
        /// </summary>
        public decimal SCHEMEID
        {
            set { _sCHEMEID = value; }
            get { return _sCHEMEID; }
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
        /// SENSORID
        /// </summary>
        public decimal SENSORID
        {
            set { _sENSORID = value; }
            get { return _sENSORID; }
        }
        /// <summary>
        /// TASKID
        /// </summary>
        public decimal TASKID
        {
            set { _tASKID = value; }
            get { return _tASKID; }
        }
        #endregion Model
    }
}
