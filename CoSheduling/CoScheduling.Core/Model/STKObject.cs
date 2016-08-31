using System;
using System.Collections.Generic;
using System.Text;

namespace CoScheduling.Core.Model
{
    public class STKObject
    {
        public STKObject()
		{ }
        /// <summary>
        /// 构造函数 STKObject
        /// </summary>
        /// <param name="sAT_STKNAME">SAT_STKNAME</param>
        /// <param name="sENSOR_STKNAME">SENSOR_STKNAME</param>
        public STKObject(string sAT_STKNAME, string sENSOR_STKNAME)
        {
            _sAT_STKNAME = sAT_STKNAME;
            _sENSOR_STKNAME = sENSOR_STKNAME;
        }
        #region Model

        private string _sAT_STKNAME;        
        private string _sENSOR_STKNAME;
        /// <summary>
        /// SAT_STKNAME
        /// </summary>
        public string SAT_STKNAME
        {
            get { return _sAT_STKNAME; }
            set { _sAT_STKNAME = value; }
        }
        /// <summary>
        /// SENSOR_STKNAME
        /// </summary>
        public string SENSOR_STKNAME
        {
            get { return _sENSOR_STKNAME; }
            set { _sENSOR_STKNAME = value; }
        }

        #endregion Model
    }
}
