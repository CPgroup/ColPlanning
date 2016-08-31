using System;
using System.Collections.Generic;
using System.Text;

namespace CoScheduling.Core.Model
{
    public class IMG_LAYOUT_RESULT
    {
        public IMG_LAYOUT_RESULT()
        { }

        /// <summary>
        /// 构造函数 IMG_LAYOUT_RESULT
        /// </summary>
        /// <param name="mPPERIODID">MPPERIODID</param>
        /// <param name="tASKID">TASKID</param>
        /// <param name="sUBTASKID">SUBTASKID</param>
        /// <param name="sATID">SATID</param>
        /// <param name="zCSTARTTIME">ZCSTARTTIME</param>
        /// <param name="zCENDTIME">ZCENDTIME</param>
        /// <param name="sLEWANGLE">SLEWANGLE</param>
        /// <param name="dLTYPE">DLTYPE</param>
        /// <param name="dLWINDOWID">DLWINDOWID</param>
        /// <param name="cOMPOSEDNUMBER">COMPOSEDNUMBER</param>
        /// <param name="rESOLUTION">RESOLUTION</param>
        /// <param name="qUANTITY">QUANTITY</param>
        /// <param name="sENSORID">SENSORID</param>
        /// <param name="gROUNDID">GROUNDID</param>
        /// <param name="dOWNSTART">DOWNSTART</param>
        /// <param name="dOWNEND">DOWNEND</param>
        /// <param name="tASK_TYPE">TASK_TYPE</param>
        /// <param name="pRIORITY">PRIORITY</param>
        /// <param name="iMAGEREGION">IMAGEREGION</param>
        /// <param name="sIMTASK_STATE">SIMTASK_STATE</param>
        /// <param name="iS_ABLE">IS_ABLE</param>
        /// <param name="dATACAP">DATACAP</param>
        /// <param name="sATSTKNAME">SATSTKNAME</param>
        /// <param name="iSCONTINUEDSPY">ISCONTINUEDSPY</param>
        /// <param name="tASKENDTIME">TASKENDTIME</param>
        /// <param name="iF_SEND">IF_SEND</param>
        /// <param name="lSTR_SEQID">LSTR_SEQID</param>
        /// <param name="pRECISION">PRECISION</param>
        /// <param name="tARGET_ID">TARGET_ID</param>
        /// <param name="sCHEMEID">SCHEMEID</param>
        /// <param name="tASKSTARTTIME">TASKSTARTTIME</param>
        public IMG_LAYOUT_RESULT(decimal mPPERIODID, decimal tASKID, string sUBTASKID, decimal sATID, DateTime zCSTARTTIME, DateTime zCENDTIME, double sLEWANGLE, decimal dLTYPE, decimal dLWINDOWID, string cOMPOSEDNUMBER, double rESOLUTION, double qUANTITY, decimal sENSORID, string gROUNDID, DateTime dOWNSTART, DateTime dOWNEND, decimal tASK_TYPE, decimal pRIORITY, string iMAGEREGION, decimal sIMTASK_STATE, decimal iS_ABLE, decimal dATACAP, string sATSTKNAME, string sENSORSTKNAME, decimal iSCONTINUEDSPY, DateTime tASKENDTIME, decimal iF_SEND, decimal lSTR_SEQID, decimal pRECISION, decimal tARGET_ID, decimal sCHEMEID, DateTime tASKSTARTTIME)
        {
            _mPPERIODID = mPPERIODID;
            _tASKID = tASKID;
            _sUBTASKID = sUBTASKID;
            _sATID = sATID;
            _zCSTARTTIME = zCSTARTTIME;
            _zCENDTIME = zCENDTIME;
            _sLEWANGLE = sLEWANGLE;
            _dLTYPE = dLTYPE;
            _dLWINDOWID = dLWINDOWID;
            _cOMPOSEDNUMBER = cOMPOSEDNUMBER;
            _rESOLUTION = rESOLUTION;
            _qUANTITY = qUANTITY;
            _sENSORID = sENSORID;
            _gROUNDID = gROUNDID;
            _dOWNSTART = dOWNSTART;
            _dOWNEND = dOWNEND;
            _tASK_TYPE = tASK_TYPE;
            _pRIORITY = pRIORITY;
            _iMAGEREGION = iMAGEREGION;
            _sIMTASK_STATE = sIMTASK_STATE;
            _iS_ABLE = iS_ABLE;
            _dATACAP = dATACAP;
            _sATSTKNAME = sATSTKNAME;
            _sENSORSTKNAME = sENSORSTKNAME;
            _iSCONTINUEDSPY = iSCONTINUEDSPY;
            _tASKENDTIME = tASKENDTIME;
            _iF_SEND = iF_SEND;
            _lSTR_SEQID = lSTR_SEQID;
            _pRECISION = pRECISION;
            _tARGET_ID = tARGET_ID;
            _sCHEMEID = sCHEMEID;
            _tASKSTARTTIME = tASKSTARTTIME;
        }

        #region Model
        private decimal _mPPERIODID;
        private decimal _tASKID;
        private string _sUBTASKID;
        private decimal _sATID;
        private DateTime _zCSTARTTIME;
        private DateTime _zCENDTIME;
        private double _sLEWANGLE;
        private decimal _dLTYPE;
        private decimal _dLWINDOWID;
        private string _cOMPOSEDNUMBER;
        private double _rESOLUTION;
        private double _qUANTITY;
        private decimal _sENSORID;
        private string _gROUNDID;
        private DateTime _dOWNSTART;
        private DateTime _dOWNEND;
        private decimal _tASK_TYPE;
        private decimal _pRIORITY;
        private string _iMAGEREGION;
        private decimal _sIMTASK_STATE;
        private decimal _iS_ABLE;
        private decimal _dATACAP;
        private string _sATSTKNAME;
        private string _sENSORSTKNAME;

        
        private decimal _iSCONTINUEDSPY;
        private DateTime _tASKENDTIME;
        private decimal _iF_SEND;
        private decimal _lSTR_SEQID;
        private decimal _pRECISION;
        private decimal _tARGET_ID;
        private decimal _sCHEMEID;
        private DateTime _tASKSTARTTIME;
        /// <summary>
        /// MPPERIODID
        /// </summary>
        public decimal MPPERIODID
        {
            set { _mPPERIODID = value; }
            get { return _mPPERIODID; }
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
        /// SUBTASKID
        /// </summary>
        public string SUBTASKID
        {
            set { _sUBTASKID = value; }
            get { return _sUBTASKID; }
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
        /// ZCSTARTTIME
        /// </summary>
        public DateTime ZCSTARTTIME
        {
            set { _zCSTARTTIME = value; }
            get { return _zCSTARTTIME; }
        }
        /// <summary>
        /// ZCENDTIME
        /// </summary>
        public DateTime ZCENDTIME
        {
            set { _zCENDTIME = value; }
            get { return _zCENDTIME; }
        }
        /// <summary>
        /// SLEWANGLE
        /// </summary>
        public double SLEWANGLE
        {
            set { _sLEWANGLE = value; }
            get { return _sLEWANGLE; }
        }
        /// <summary>
        /// DLTYPE
        /// </summary>
        public decimal DLTYPE
        {
            set { _dLTYPE = value; }
            get { return _dLTYPE; }
        }
        /// <summary>
        /// DLWINDOWID
        /// </summary>
        public decimal DLWINDOWID
        {
            set { _dLWINDOWID = value; }
            get { return _dLWINDOWID; }
        }
        /// <summary>
        /// COMPOSEDNUMBER
        /// </summary>
        public string COMPOSEDNUMBER
        {
            set { _cOMPOSEDNUMBER = value; }
            get { return _cOMPOSEDNUMBER; }
        }
        /// <summary>
        /// RESOLUTION
        /// </summary>
        public double RESOLUTION
        {
            set { _rESOLUTION = value; }
            get { return _rESOLUTION; }
        }
        /// <summary>
        /// QUANTITY
        /// </summary>
        public double QUANTITY
        {
            set { _qUANTITY = value; }
            get { return _qUANTITY; }
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
        /// GROUNDID
        /// </summary>
        public string GROUNDID
        {
            set { _gROUNDID = value; }
            get { return _gROUNDID; }
        }
        /// <summary>
        /// DOWNSTART
        /// </summary>
        public DateTime DOWNSTART
        {
            set { _dOWNSTART = value; }
            get { return _dOWNSTART; }
        }
        /// <summary>
        /// DOWNEND
        /// </summary>
        public DateTime DOWNEND
        {
            set { _dOWNEND = value; }
            get { return _dOWNEND; }
        }
        /// <summary>
        /// TASK_TYPE
        /// </summary>
        public decimal TASK_TYPE
        {
            set { _tASK_TYPE = value; }
            get { return _tASK_TYPE; }
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
        /// IMAGEREGION
        /// </summary>
        public string IMAGEREGION
        {
            set { _iMAGEREGION = value; }
            get { return _iMAGEREGION; }
        }
        /// <summary>
        /// SIMTASK_STATE
        /// </summary>
        public decimal SIMTASK_STATE
        {
            set { _sIMTASK_STATE = value; }
            get { return _sIMTASK_STATE; }
        }
        /// <summary>
        /// IS_ABLE
        /// </summary>
        public decimal IS_ABLE
        {
            set { _iS_ABLE = value; }
            get { return _iS_ABLE; }
        }
        /// <summary>
        /// DATACAP
        /// </summary>
        public decimal DATACAP
        {
            set { _dATACAP = value; }
            get { return _dATACAP; }
        }
        /// <summary>
        /// SATSTKNAME
        /// </summary>
        public string SATSTKNAME
        {
            set { _sATSTKNAME = value; }
            get { return _sATSTKNAME; }
        }
        /// <summary>
        /// ISCONTINUEDSPY
        /// </summary>
        public decimal ISCONTINUEDSPY
        {
            set { _iSCONTINUEDSPY = value; }
            get { return _iSCONTINUEDSPY; }
        }
        /// <summary>
        /// TASKENDTIME
        /// </summary>
        public DateTime TASKENDTIME
        {
            set { _tASKENDTIME = value; }
            get { return _tASKENDTIME; }
        }
        /// <summary>
        /// IF_SEND
        /// </summary>
        public decimal IF_SEND
        {
            set { _iF_SEND = value; }
            get { return _iF_SEND; }
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
        /// PRECISION
        /// </summary>
        public decimal PRECISION
        {
            set { _pRECISION = value; }
            get { return _pRECISION; }
        }
        /// <summary>
        /// TARGET_ID
        /// </summary>
        public decimal TARGET_ID
        {
            set { _tARGET_ID = value; }
            get { return _tARGET_ID; }
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
        /// TASKSTARTTIME
        /// </summary>
        public DateTime TASKSTARTTIME
        {
            set { _tASKSTARTTIME = value; }
            get { return _tASKSTARTTIME; }
        }
        /// <summary>
        /// SENSORSTKNAME
        /// </summary>
        public string SENSORSTKNAME
        {
            get { return _sENSORSTKNAME; }
            set { _sENSORSTKNAME = value; }
        }
        #endregion Model
    }
}
