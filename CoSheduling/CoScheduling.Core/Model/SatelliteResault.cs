//------------------------------------------------------------------------------
// 创建标识: 董毅博
// 创建描述: 卫星结果实体类
// 创建时间:2014.03.22
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
    /// 实体类 SatelliteResault
    /// </summary>
    [Serializable]
    public class SatelliteResault
    {
        public SatelliteResault()
        { }

        /// <summary>
        /// 构造函数 SatelliteResault
        /// </summary>
        /// <param name="lSTR_SEQID">LSTR_SEQID</param>
        /// <param name="sCHEMEID">SCHEMEID</param>
        /// <param name="tASKID">TASKID</param>
        /// <param name="pID">PID</param>
        /// <param name="pOLYGONSTRING">POLYGONSTRING</param>
        public SatelliteResault(int lSTR_SEQID, int sCHEMEID, int tASKID, int pID, string pOLYGONSTRING,DateTime sTARTTIME,DateTime eNDTIME,decimal cOVERAGE,decimal aCCUCOVERAGE)
        {
            _lSTR_SEQID = lSTR_SEQID;
            _sCHEMEID = sCHEMEID;
            _tASKID = tASKID;
            _pID = pID;
            _pOLYGONSTRING = pOLYGONSTRING;
            _sTARTTIME = sTARTTIME;
            _eNDTIME = eNDTIME;
            _cOVERAGE = cOVERAGE;
            _aCCUCOVERAGE = aCCUCOVERAGE;
        }

        #region Model
        private int _lSTR_SEQID;
        private int _sCHEMEID;
        private int _tASKID;
        private int _pID;
        private string _pOLYGONSTRING;
        private DateTime _sTARTTIME;
        private DateTime _eNDTIME;
        private decimal _cOVERAGE;
        private decimal _aCCUCOVERAGE;

        

        
       
        /// <summary>
        /// LSTR_SEQID
        /// </summary>
        public int LSTR_SEQID
        {
            set { _lSTR_SEQID = value; }
            get { return _lSTR_SEQID; }
        }
        /// <summary>
        /// SCHEMEID
        /// </summary>
        public int SCHEMEID
        {
            set { _sCHEMEID = value; }
            get { return _sCHEMEID; }
        }
        /// <summary>
        /// TASKID
        /// </summary>
        public int TASKID
        {
            set { _tASKID = value; }
            get { return _tASKID; }
        }
        /// <summary>
        /// PID
        /// </summary>
        public int PID
        {
            set { _pID = value; }
            get { return _pID; }
        }
        /// <summary>
        /// POLYGONSTRING
        /// </summary>
        public string POLYGONSTRING
        {
            set { _pOLYGONSTRING = value; }
            get { return _pOLYGONSTRING; }
        }
        /// <summary>
        /// STARTTIME
        /// </summary>
        public DateTime STARTTIME
        {
            get { return _sTARTTIME; }
            set { _sTARTTIME = value; }
        }
        /// <summary>
        /// ENDTIME
        /// </summary>
        public DateTime ENDTIME
        {
            get { return _eNDTIME; }
            set { _eNDTIME = value; }
        }
        /// <summary>
        /// COVERAGE
        /// </summary>
        public decimal COVERAGE
        {
            get { return _cOVERAGE; }
            set { _cOVERAGE = value; }
        }
        /// <summary>
        /// ACCUCOVERAGE
        /// </summary>
        public decimal ACCUCOVERAGE
        {
            get { return _aCCUCOVERAGE; }
            set { _aCCUCOVERAGE = value; }
        }
        #endregion Model
    }
}
