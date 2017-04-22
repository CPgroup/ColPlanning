using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoScheduling.Core.Model
{
    /// <summary>
    /// 实体类 BIGAREA_TARGET
    /// </summary>
    public class BIGAREA_TARGET
    {
        public BIGAREA_TARGET()
        { }

        /// <summary>
        /// 构造函数 BIGAREA_TARGET
        /// </summary>
        /// <param name="tARGETID">TARGETID</param>
        /// <param name="tARGETNAME">TARGETNAME</param>
        /// <param name="tARGETLAT">TARGETLAT</param>
        /// <param name="tARGETLON">TARGETLON</param>
        /// <param name="sCHEMEID">SCHEMEID</param>
        public BIGAREA_TARGET(decimal tARGETID, string tARGETNAME, decimal tARGETLAT, decimal tARGETLON, decimal sCHEMEID)
        {
            _tARGETID = tARGETID;
            _tARGETNAME = tARGETNAME;
            _tARGETLAT = tARGETLAT;
            _tARGETLON = tARGETLON;
            _sCHEMEID = sCHEMEID;
        }

        #region Model
        private decimal _tARGETID;
        private string _tARGETNAME;
        private decimal _tARGETLAT;
        private decimal _tARGETLON;
        private decimal _sCHEMEID;
        /// <summary>
        /// TARGETID
        /// </summary>
        public decimal TARGETID
        {
            set { _tARGETID = value; }
            get { return _tARGETID; }
        }
        /// <summary>
        /// TARGETNAME
        /// </summary>
        public string TARGETNAME
        {
            set { _tARGETNAME = value; }
            get { return _tARGETNAME; }
        }
        /// <summary>
        /// TARGETLAT
        /// </summary>
        public decimal TARGETLAT
        {
            set { _tARGETLAT = value; }
            get { return _tARGETLAT; }
        }
        /// <summary>
        /// TARGETLON
        /// </summary>
        public decimal TARGETLON
        {
            set { _tARGETLON = value; }
            get { return _tARGETLON; }
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
