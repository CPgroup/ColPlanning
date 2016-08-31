using System;
using System.Collections.Generic;
using System.Text;

namespace CoScheduling.Core.Model
{
    public class T_PUB_SATELLITEPARA
    {
        public T_PUB_SATELLITEPARA()
        { }

        /// <summary>
        /// 构造函数 T_PUB_SATELLITEPARA
        /// </summary>
        /// <param name="sAT_ID">SAT_ID</param>
        /// <param name="sAT_STKNAME">SAT_STKNAME</param>
        /// <param name="mAXGSD">MAXGSD</param>
        /// <param name="oPENCLOSETIME">OPENCLOSETIME</param>
        /// <param name="wORKLASTTIME">WORKLASTTIME</param>
        /// <param name="sATANGLE">SATANGLE</param>
        /// <param name="sATANGLEH">SATANGLEH</param>
        /// <param name="sENSOR_ID">SENSOR_ID</param>
        /// <param name="sENSOR_STKNAME">SENSOR_STKNAME</param>
        public T_PUB_SATELLITEPARA(decimal sAT_ID, string sAT_STKNAME, decimal mAXGSD, decimal oPENCLOSETIME, decimal wORKLASTTIME, decimal sATANGLE, decimal sATANGLEH, decimal sENSOR_ID, string sENSOR_STKNAME)
        {
            _sAT_ID = sAT_ID;
            _sAT_STKNAME = sAT_STKNAME;
            _mAXGSD = mAXGSD;
            _oPENCLOSETIME = oPENCLOSETIME;
            _wORKLASTTIME = wORKLASTTIME;
            _sATANGLE = sATANGLE;
            _sATANGLEH = sATANGLEH;
            _sENSOR_ID = sENSOR_ID;
            _sENSOR_STKNAME = sENSOR_STKNAME;
        }

        #region Model
        private decimal _sAT_ID;
        private string _sAT_STKNAME;
        private decimal _mAXGSD;
        private decimal _oPENCLOSETIME;
        private decimal _wORKLASTTIME;
        private decimal _sATANGLE;
        private decimal _sATANGLEH;
        private decimal _sENSOR_ID;
        private string _sENSOR_STKNAME;
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
        /// MAXGSD
        /// </summary>
        public decimal MAXGSD
        {
            set { _mAXGSD = value; }
            get { return _mAXGSD; }
        }
        /// <summary>
        /// OPENCLOSETIME
        /// </summary>
        public decimal OPENCLOSETIME
        {
            set { _oPENCLOSETIME = value; }
            get { return _oPENCLOSETIME; }
        }
        /// <summary>
        /// WORKLASTTIME
        /// </summary>
        public decimal WORKLASTTIME
        {
            set { _wORKLASTTIME = value; }
            get { return _wORKLASTTIME; }
        }
        /// <summary>
        /// SATANGLE
        /// </summary>
        public decimal SATANGLE
        {
            set { _sATANGLE = value; }
            get { return _sATANGLE; }
        }
        /// <summary>
        /// SATANGLEH
        /// </summary>
        public decimal SATANGLEH
        {
            set { _sATANGLEH = value; }
            get { return _sATANGLEH; }
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
            set { _sENSOR_STKNAME = value; }
            get { return _sENSOR_STKNAME; }
        }
        #endregion Model
    }
}
