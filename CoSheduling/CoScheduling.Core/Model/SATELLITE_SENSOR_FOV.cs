//------------------------------------------------------------------------------
// 创建标识: 董毅博
// 创建描述: 卫星视场角幅宽转化实体类
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
    /// 实体类 SATELLITE_SENSOR_FOV
    /// </summary>
    [Serializable]
    public class SATELLITE_SENSOR_FOV
    {
        public SATELLITE_SENSOR_FOV()
        { }

        /// <summary>
        /// 构造函数 SATELLITE_SENSOR_FOV
        /// </summary>
        /// <param name="sENSOR_ID">SENSOR_ID</param>
        /// <param name="sENSOR_NAME">SENSOR_NAME</param>
        /// <param name="sAT_ID">SAT_ID</param>
        /// <param name="sAT_NAME">SAT_NAME</param>
        /// <param name="sWATHWIDTH">SWATHWIDTH</param>
        /// <param name="aVGH">AVGH</param>
        /// <param name="tANVALUE">TANVALUE</param>
        /// <param name="aTANVALUE">ATANVALUE</param>
        public SATELLITE_SENSOR_FOV(decimal sENSOR_ID, string sENSOR_NAME, decimal sAT_ID, string sAT_NAME, decimal sWATHWIDTH, decimal aVGH, decimal tANVALUE, decimal aTANVALUE)
        {
            _sENSOR_ID = sENSOR_ID;
            _sENSOR_NAME = sENSOR_NAME;
            _sAT_ID = sAT_ID;
            _sAT_NAME = sAT_NAME;
            _sWATHWIDTH = sWATHWIDTH;
            _aVGH = aVGH;
            _tANVALUE = tANVALUE;
            _aTANVALUE = aTANVALUE;
        }

        #region Model
        private decimal _sENSOR_ID;
        private string _sENSOR_NAME;
        private decimal _sAT_ID;
        private string _sAT_NAME;
        private decimal _sWATHWIDTH;
        private decimal _aVGH;
        private decimal _tANVALUE;
        private decimal _aTANVALUE;
        /// <summary>
        /// SENSOR_ID
        /// </summary>
        public decimal SENSOR_ID
        {
            set { _sENSOR_ID = value; }
            get { return _sENSOR_ID; }
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
        /// AVGH
        /// </summary>
        public decimal AVGH
        {
            set { _aVGH = value; }
            get { return _aVGH; }
        }
        /// <summary>
        /// TANVALUE
        /// </summary>
        public decimal TANVALUE
        {
            set { _tANVALUE = value; }
            get { return _tANVALUE; }
        }
        /// <summary>
        /// ATANVALUE
        /// </summary>
        public decimal ATANVALUE
        {
            set { _aTANVALUE = value; }
            get { return _aTANVALUE; }
        }
        #endregion Model
    }
}
