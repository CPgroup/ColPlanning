using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoScheduling.Core.Model
{
    public class BIGAREA_SCHEME
    {
        public BIGAREA_SCHEME()
        { }

        /// <summary>
        /// 构造函数 BIGAREA_SCHEME
        /// </summary>
        /// <param name="sCHEMEID">SCHEMEID</param>
        /// <param name="sCHEMENAME">SCHEMENAME</param>
        /// <param name="sCHEMEBTIME">SCHEMEBTIME</param>
        /// <param name="sCHEMEETIME">SCHEMEETIME</param>
        public BIGAREA_SCHEME(decimal sCHEMEID, string sCHEMENAME, DateTime sCHEMEBTIME, DateTime sCHEMEETIME)
        {
            _sCHEMEID = sCHEMEID;
            _sCHEMENAME = sCHEMENAME;
            _sCHEMEBTIME = sCHEMEBTIME;
            _sCHEMEETIME = sCHEMEETIME;
        }

        #region Model
        private decimal _sCHEMEID;
        private string _sCHEMENAME;
        private DateTime _sCHEMEBTIME;
        private DateTime _sCHEMEETIME;
        /// <summary>
        /// SCHEMEID
        /// </summary>
        public decimal SCHEMEID
        {
            set { _sCHEMEID = value; }
            get { return _sCHEMEID; }
        }
        /// <summary>
        /// SCHEMENAME
        /// </summary>
        public string SCHEMENAME
        {
            set { _sCHEMENAME = value; }
            get { return _sCHEMENAME; }
        }
        /// <summary>
        /// SCHEMEBTIME
        /// </summary>
        public DateTime SCHEMEBTIME
        {
            set { _sCHEMEBTIME = value; }
            get { return _sCHEMEBTIME; }
        }
        /// <summary>
        /// SCHEMEETIME
        /// </summary>
        public DateTime SCHEMEETIME
        {
            set { _sCHEMEETIME = value; }
            get { return _sCHEMEETIME; }
        }
        #endregion Model
    }
}
