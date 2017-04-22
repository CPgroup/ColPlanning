using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoScheduling.Core.Model
{
    [Serializable]
    public class BIGAREA_SATELLITE
    {
        public BIGAREA_SATELLITE()
        { }

        /// <summary>
        /// 构造函数 BIGAREA_SATELLITE
        /// </summary>
        /// <param name="sATELLITEID">SATELLITEID</param>
        /// <param name="sATID">SATID</param>
        /// <param name="sCHEMEID">SCHEMEID</param>
        public BIGAREA_SATELLITE(decimal sATELLITEID, decimal sATID, decimal sCHEMEID)
        {
            _sATELLITEID = sATELLITEID;
            _sATID = sATID;
            _sCHEMEID = sCHEMEID;
        }

        #region Model
        private decimal _sATELLITEID;
        private decimal _sATID;
        private decimal _sCHEMEID;
        /// <summary>
        /// SATELLITEID
        /// </summary>
        public decimal SATELLITEID
        {
            set { _sATELLITEID = value; }
            get { return _sATELLITEID; }
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
        /// SCHEMEID
        /// </summary>
        public decimal SCHEMEID
        {
            set { _sCHEMEID = value; }
            get { return _sCHEMEID; }
        }
        #endregion Model
    }
}
