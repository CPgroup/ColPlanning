using System;
using System.Collections.Generic;
using System.Text;

namespace CoScheduling.Core.Model
{
    /// <summary>
    /// 实体类 SATELLITE_DATA
    /// </summary>
    [Serializable]
    public class SATELLITE_DATA
    {
        public SATELLITE_DATA()
        { }

        /// <summary>
        /// 构造函数 SATELLITE_DATA
        /// </summary>
        /// <param name="sATELLITE_ID">SATELLITE_ID</param>
        /// <param name="sATELLITE_NAME">SATELLITE_NAME</param>
        /// <param name="sATELLITE_UPDATETIME">SATELLITE_UPDATETIME</param>
        /// <param name="sATELLITE_CHOOSE">SATELLITE_CHOOSE</param>
        public SATELLITE_DATA(decimal sAT_ID, string sAT_STKNAME, decimal sENSOR_ID, string sENSOR_STKNAME, string sENSOR_NAME, DateTime tIMEWINDOW_TIME, Decimal tIMEWINDOW_SIDEANGLE,Decimal tIMEWINDOW_GSD)
        {
            _sAT_ID = sAT_ID;
            _sAT_STKNAME = sAT_STKNAME;
            _sENSOR_ID = sENSOR_ID;
            _sENSOR_STKNAME = sENSOR_STKNAME;
            _sENSOR_NAME = sENSOR_NAME;
            _tIMEWINDOW_TIME = tIMEWINDOW_TIME;
            _tIMEWINDOW_SIDEANGLE = tIMEWINDOW_SIDEANGLE;
            _tIMEWINDOW_GSD = tIMEWINDOW_GSD;
        }

        #region Model
        private decimal _sAT_ID;
        private string _sAT_STKNAME;
        private decimal _sENSOR_ID;

        
        private string _sENSOR_STKNAME;


        private string _sENSOR_NAME;

        
        private DateTime _tIMEWINDOW_TIME;


        private decimal _tIMEWINDOW_SIDEANGLE;

        
        private decimal _tIMEWINDOW_GSD;

        
        /// <summary>
        /// SATELLITE_ID
        /// </summary>
        public decimal SAT_ID
        {
            set { _sAT_ID = value; }
            get { return _sAT_ID; }
        }
        /// <summary>
        /// SATELLITE_NAME
        /// </summary>
        public string SAT_STKNAME
        {
            get { return _sAT_STKNAME; }
            set { _sAT_STKNAME = value; }
        }

        public decimal SENSOR_ID
        {
            get { return _sENSOR_ID; }
            set { _sENSOR_ID = value; }
        }

        public string SENSOR_STKNAME
        {
            get { return _sENSOR_STKNAME; }
            set { _sENSOR_STKNAME = value; }
        }

        public string SENSOR_NAME
        {
            get { return _sENSOR_NAME; }
            set { _sENSOR_NAME = value; }
        }

        public DateTime TIMEWINDOW_TIME
        {
            get { return _tIMEWINDOW_TIME; }
            set { _tIMEWINDOW_TIME = value; }
        }
        public decimal TIMEWINDOW_SIDEANGLE
        {
            get { return _tIMEWINDOW_SIDEANGLE; }
            set { _tIMEWINDOW_SIDEANGLE = value; }
        }

        public decimal TIMEWINDOW_GSD
        {
            get { return _tIMEWINDOW_GSD; }
            set { _tIMEWINDOW_GSD = value; }
        }
#endregion Model
    }


    [Serializable]
    public class SATELLITE_SQEDATA
    {
        public SATELLITE_SQEDATA()
        { }

        public SATELLITE_SQEDATA( DateTime tIMEWINDOW_TIME,String sQESTR)
        {
            _tIMEWINDOW_TIME = tIMEWINDOW_TIME;
            _sQESTR = sQESTR;
        }
        private DateTime _tIMEWINDOW_TIME;

        public DateTime TIMEWINDOW_TIME
        {
            get { return _tIMEWINDOW_TIME; }
            set { _tIMEWINDOW_TIME = value; }
        }
        private string _sQESTR;

        public string SQESTR
        {
            get { return _sQESTR; }
            set { _sQESTR = value; }
        }
 
    }
}
