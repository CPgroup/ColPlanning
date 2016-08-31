using System;
using System.Collections.Generic;
using System.Text;

namespace CoScheduling.Core.Model
{
    public class IMG_LAYOUT_POSITION
    {
        public IMG_LAYOUT_POSITION()
        { }

        /// <summary>
        /// 构造函数 IMG_LAYOUT_POSITION
        /// </summary>
        /// <param name="pOSITIONID">POSITIONID</param>
        /// <param name="lSTR_SEQID">LSTR_SEQID</param>
        /// <param name="sCHEMEID">SCHEMEID</param>
        /// <param name="tASKID">TASKID</param>
        /// <param name="sAT_ID">SAT_ID</param>
        /// <param name="sAT_STKNAME">SAT_STKNAME</param>
        /// <param name="tIME">TIME</param>
        /// <param name="lON">LON</param>
        /// <param name="lAT">LAT</param>
        /// <param name="aLTITUDE">ALTITUDE</param>
        /// <param name="iMAGENATION">IMAGENATION</param>
        public IMG_LAYOUT_POSITION(decimal pOSITIONID, decimal lSTR_SEQID, decimal sCHEMEID, decimal tASKID, decimal sAT_ID, string sAT_STKNAME, DateTime tIME, decimal lON, decimal lAT, decimal aLTITUDE,string iMAGENATION)
        {
            _pOSITIONID = pOSITIONID;
            _lSTR_SEQID = lSTR_SEQID;
            _sCHEMEID = sCHEMEID;
            _tASKID = tASKID;
            _sAT_ID = sAT_ID;
            _sAT_STKNAME = sAT_STKNAME;
            _tIME = tIME;
            _lON = lON;
            _lAT = lAT;
            _aLTITUDE = aLTITUDE;
            _iMAGENATION = iMAGENATION;
        }

        #region Model
        private decimal _pOSITIONID;
        private decimal _lSTR_SEQID;
        private decimal _sCHEMEID;
        private decimal _tASKID;
        private decimal _sAT_ID;
        private string _sAT_STKNAME;
        private DateTime _tIME;
        private decimal _lON;
        private decimal _lAT;
        private decimal _aLTITUDE;
        private string _iMAGENATION;

        
        /// <summary>
        /// POSITIONID
        /// </summary>
        public decimal POSITIONID
        {
            set { _pOSITIONID = value; }
            get { return _pOSITIONID; }
        }
        /// <summary>
        /// LSTR_SEQID
        /// </summary>
        public decimal LSTR_SEQID
        {
            set { _lSTR_SEQID = value; }
            get { return _lSTR_SEQID; }
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
        /// TASKID
        /// </summary>
        public decimal TASKID
        {
            set { _tASKID = value; }
            get { return _tASKID; }
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
        /// SAT_STKNAME
        /// </summary>
        public string SAT_STKNAME
        {
            set { _sAT_STKNAME = value; }
            get { return _sAT_STKNAME; }
        }
        /// <summary>
        /// TIME
        /// </summary>
        public DateTime TIME
        {
            set { _tIME = value; }
            get { return _tIME; }
        }
        /// <summary>
        /// LON
        /// </summary>
        public decimal LON
        {
            set { _lON = value; }
            get { return _lON; }
        }
        /// <summary>
        /// LAT
        /// </summary>
        public decimal LAT
        {
            set { _lAT = value; }
            get { return _lAT; }
        }
        /// <summary>
        /// ALTITUDE
        /// </summary>
        public decimal ALTITUDE
        {
            set { _aLTITUDE = value; }
            get { return _aLTITUDE; }
        }
        /// <summary>
        /// IMAGENATION
        /// </summary>
        public string IMAGENATION
        {
            get { return _iMAGENATION; }
            set { _iMAGENATION = value; }
        }
        #endregion Model
    }
}
