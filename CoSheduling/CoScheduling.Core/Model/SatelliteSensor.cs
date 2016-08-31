//------------------------------------------------------------------------------
// 创建标识: 董毅博
// 创建描述: 卫星载荷实体类
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

    /// <summary>
    /// 实体类 SatelliteSensor
    /// </summary>
    [Serializable]
    public class SatelliteSensor
    {
        public SatelliteSensor()
        { }

        /// <summary>
        /// 构造函数 SatelliteSensor
        /// </summary>
        /// <param name="sENSOR_NAME">SENSOR_NAME</param>
        /// <param name="sAT_ID">SAT_ID</param>
        /// <param name="sAT_NAME">SAT_NAME</param>
        /// <param name="sENSOR_TYPE">SENSOR_TYPE</param>
        /// <param name="aPPLICATION">APPLICATION</param>
        /// <param name="fOV">FOV</param>
        /// <param name="sWATHWIDTH">SWATHWIDTH</param>
        /// <param name="aCROSSPOINTINGRANGE">ACROSSPOINTINGRANGE</param>
        /// <param name="aLONGPOINTINGRANGE">ALONGPOINTINGRANGE</param>
        /// <param name="lOCATIONACCURACY">LOCATIONACCURACY</param>
        /// <param name="nUMOFBANDS">NUMOFBANDS</param>
        /// <param name="bANDCATEGORIES">BANDCATEGORIES</param>
        /// <param name="aCCURACY">ACCURACY</param>
        /// <param name="rEVISITTIME">REVISITTIME</param>
        /// <param name="iNSTRUMENTDESCRIPTION">INSTRUMENTDESCRIPTION</param>
        /// <param name="dATA_ACCESS">DATA_ACCESS</param>
        /// <param name="dATA_FORMAT">DATA_FORMAT</param>

        /// <param name="sENSOR_ID">SENSOR_ID</param>
        /// <param name="mAXGSD">MAXGSD</param>

        /// <param name="iNCLINATION">INCLINATION</param>
        public SatelliteSensor(string sENSOR_NAME, decimal sAT_ID, string sAT_NAME, decimal sENSOR_TYPE, string aPPLICATION, decimal fOV, decimal sWATHWIDTH, decimal aCROSSPOINTINGRANGE, decimal aLONGPOINTINGRANGE, decimal lOCATIONACCURACY, decimal nUMOFBANDS, string bANDCATEGORIES, string aCCURACY, decimal rEVISITTIME, string iNSTRUMENTDESCRIPTION, string dATA_ACCESS, string dATA_FORMAT, decimal sENSOR_ID, decimal mAXGSD, decimal iNCLINATION)
        {
            _sENSOR_NAME = sENSOR_NAME;
            _sAT_ID = sAT_ID;
            _sAT_NAME = sAT_NAME;
            _sENSOR_TYPE = sENSOR_TYPE;
            _aPPLICATION = aPPLICATION;
            _fOV = fOV;
            _sWATHWIDTH = sWATHWIDTH;
            _aCROSSPOINTINGRANGE = aCROSSPOINTINGRANGE;
            _aLONGPOINTINGRANGE = aLONGPOINTINGRANGE;
            _lOCATIONACCURACY = lOCATIONACCURACY;
            _nUMOFBANDS = nUMOFBANDS;
            _bANDCATEGORIES = bANDCATEGORIES;
            _aCCURACY = aCCURACY;
            _rEVISITTIME = rEVISITTIME;
            _iNSTRUMENTDESCRIPTION = iNSTRUMENTDESCRIPTION;
            _dATA_ACCESS = dATA_ACCESS;
            _dATA_FORMAT = dATA_FORMAT;

            _sENSOR_ID = sENSOR_ID;
            _mAXGSD = mAXGSD;

            _iNCLINATION = iNCLINATION;
        }

        #region Model
        private string _sENSOR_NAME;
        private decimal _sAT_ID;
        private string _sAT_NAME;
        private decimal _sENSOR_TYPE;
        private string _aPPLICATION;
        private decimal _fOV;
        private decimal _sWATHWIDTH;
        private decimal _aCROSSPOINTINGRANGE;
        private decimal _aLONGPOINTINGRANGE;
        private decimal _lOCATIONACCURACY;
        private decimal _nUMOFBANDS;
        private string _bANDCATEGORIES;
        private string _aCCURACY;
        private decimal _rEVISITTIME;
        private string _iNSTRUMENTDESCRIPTION;
        private string _dATA_ACCESS;
        private string _dATA_FORMAT;

        private decimal _sENSOR_ID;
        private decimal _mAXGSD;

        private decimal _iNCLINATION;
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
        /// SENSOR_TYPE
        /// </summary>
        public decimal SENSOR_TYPE
        {
            set { _sENSOR_TYPE = value; }
            get { return _sENSOR_TYPE; }
        }
        /// <summary>
        /// APPLICATION
        /// </summary>
        public string APPLICATION
        {
            set { _aPPLICATION = value; }
            get { return _aPPLICATION; }
        }
        /// <summary>
        /// FOV
        /// </summary>
        public decimal FOV
        {
            set { _fOV = value; }
            get { return _fOV; }
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
        /// ACROSSPOINTINGRANGE
        /// </summary>
        public decimal ACROSSPOINTINGRANGE
        {
            set { _aCROSSPOINTINGRANGE = value; }
            get { return _aCROSSPOINTINGRANGE; }
        }
        /// <summary>
        /// ALONGPOINTINGRANGE
        /// </summary>
        public decimal ALONGPOINTINGRANGE
        {
            set { _aLONGPOINTINGRANGE = value; }
            get { return _aLONGPOINTINGRANGE; }
        }
        /// <summary>
        /// LOCATIONACCURACY
        /// </summary>
        public decimal LOCATIONACCURACY
        {
            set { _lOCATIONACCURACY = value; }
            get { return _lOCATIONACCURACY; }
        }
        /// <summary>
        /// NUMOFBANDS
        /// </summary>
        public decimal NUMOFBANDS
        {
            set { _nUMOFBANDS = value; }
            get { return _nUMOFBANDS; }
        }
        /// <summary>
        /// BANDCATEGORIES
        /// </summary>
        public string BANDCATEGORIES
        {
            set { _bANDCATEGORIES = value; }
            get { return _bANDCATEGORIES; }
        }
        /// <summary>
        /// ACCURACY
        /// </summary>
        public string ACCURACY
        {
            set { _aCCURACY = value; }
            get { return _aCCURACY; }
        }
        /// <summary>
        /// REVISITTIME
        /// </summary>
        public decimal REVISITTIME
        {
            set { _rEVISITTIME = value; }
            get { return _rEVISITTIME; }
        }
        /// <summary>
        /// INSTRUMENTDESCRIPTION
        /// </summary>
        public string INSTRUMENTDESCRIPTION
        {
            set { _iNSTRUMENTDESCRIPTION = value; }
            get { return _iNSTRUMENTDESCRIPTION; }
        }
        /// <summary>
        /// DATA_ACCESS
        /// </summary>
        public string DATA_ACCESS
        {
            set { _dATA_ACCESS = value; }
            get { return _dATA_ACCESS; }
        }
        /// <summary>
        /// DATA_FORMAT
        /// </summary>
        public string DATA_FORMAT
        {
            set { _dATA_FORMAT = value; }
            get { return _dATA_FORMAT; }
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
        /// MAXGSD
        /// </summary>
        public decimal MAXGSD
        {
            set { _mAXGSD = value; }
            get { return _mAXGSD; }
        }

        /// <summary>
        /// INCLINATION
        /// </summary>
        public decimal INCLINATION
        {
            set { _iNCLINATION = value; }
            get { return _iNCLINATION; }
        }
        #endregion Model
    }
}
