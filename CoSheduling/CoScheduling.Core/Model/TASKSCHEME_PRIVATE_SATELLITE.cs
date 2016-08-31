using System;
using System.Collections.Generic;
using System.Text;

namespace CoScheduling.Core.Model
{
    public class TASKSCHEME_PRIVATE_SATELLITE
    {
        public TASKSCHEME_PRIVATE_SATELLITE()
        { }

        /// <summary>
        /// 构造函数 TASKSCHEME_PRIVATE_SATELLITE
        /// </summary>
        /// <param name="sAT_ID">SAT_ID</param>
        /// <param name="sAT_NAME">SAT_NAME</param>
        /// <param name="sAT_STKNAME">SAT_STKNAME</param>
        /// <param name="sAT_TYPE">SAT_TYPE</param>
        /// <param name="sAT_ROPAGATOR">SAT_ROPAGATOR</param>
        /// <param name="sAT_STEP">SAT_STEP</param>
        /// <param name="sAT_COORD">SAT_COORD</param>
        /// <param name="sEMIMAJORAXIS">SEMIMAJORAXIS</param>
        /// <param name="eCCENTRICITY">ECCENTRICITY</param>
        /// <param name="iNCLINATION">INCLINATION</param>
        /// <param name="aOP">AOP</param>
        /// <param name="rAAN">RAAN</param>
        /// <param name="mEANANOMALY">MEANANOMALY</param>
        /// <param name="tRUEANOMALY">TRUEANOMALY</param>
        /// <param name="sCHEMEID">SCHEMEID</param>
        public TASKSCHEME_PRIVATE_SATELLITE(decimal sAT_ID, string sAT_NAME, string sAT_STKNAME, decimal sAT_TYPE, string sAT_ROPAGATOR, decimal sAT_STEP, string sAT_COORD, decimal sEMIMAJORAXIS, decimal eCCENTRICITY, decimal iNCLINATION, decimal aOP, decimal rAAN, decimal mEANANOMALY, decimal tRUEANOMALY, decimal sCHEMEID)
        {
            _sAT_ID = sAT_ID;
            _sAT_NAME = sAT_NAME;
            _sAT_STKNAME = sAT_STKNAME;
            _sAT_TYPE = sAT_TYPE;
            _sAT_ROPAGATOR = sAT_ROPAGATOR;
            _sAT_STEP = sAT_STEP;
            _sAT_COORD = sAT_COORD;
            _sEMIMAJORAXIS = sEMIMAJORAXIS;
            _eCCENTRICITY = eCCENTRICITY;
            _iNCLINATION = iNCLINATION;
            _aOP = aOP;
            _rAAN = rAAN;
            _mEANANOMALY = mEANANOMALY;
            _tRUEANOMALY = tRUEANOMALY;
            _sCHEMEID = sCHEMEID;
        }

        #region Model
        private decimal _sAT_ID;
        private string _sAT_NAME;
        private string _sAT_STKNAME;
        private decimal _sAT_TYPE;
        private string _sAT_ROPAGATOR;
        private decimal _sAT_STEP;
        private string _sAT_COORD;
        private decimal _sEMIMAJORAXIS;
        private decimal _eCCENTRICITY;
        private decimal _iNCLINATION;
        private decimal _aOP;
        private decimal _rAAN;
        private decimal _mEANANOMALY;
        private decimal _tRUEANOMALY;
        private decimal _sCHEMEID;
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
        /// SAT_STKNAME
        /// </summary>
        public string SAT_STKNAME
        {
            set { _sAT_STKNAME = value; }
            get { return _sAT_STKNAME; }
        }
        /// <summary>
        /// SAT_TYPE
        /// </summary>
        public decimal SAT_TYPE
        {
            set { _sAT_TYPE = value; }
            get { return _sAT_TYPE; }
        }
        /// <summary>
        /// SAT_ROPAGATOR
        /// </summary>
        public string SAT_ROPAGATOR
        {
            set { _sAT_ROPAGATOR = value; }
            get { return _sAT_ROPAGATOR; }
        }
        /// <summary>
        /// SAT_STEP
        /// </summary>
        public decimal SAT_STEP
        {
            set { _sAT_STEP = value; }
            get { return _sAT_STEP; }
        }
        /// <summary>
        /// SAT_COORD
        /// </summary>
        public string SAT_COORD
        {
            set { _sAT_COORD = value; }
            get { return _sAT_COORD; }
        }
        /// <summary>
        /// SEMIMAJORAXIS
        /// </summary>
        public decimal SEMIMAJORAXIS
        {
            set { _sEMIMAJORAXIS = value; }
            get { return _sEMIMAJORAXIS; }
        }
        /// <summary>
        /// ECCENTRICITY
        /// </summary>
        public decimal ECCENTRICITY
        {
            set { _eCCENTRICITY = value; }
            get { return _eCCENTRICITY; }
        }
        /// <summary>
        /// INCLINATION
        /// </summary>
        public decimal INCLINATION
        {
            set { _iNCLINATION = value; }
            get { return _iNCLINATION; }
        }
        /// <summary>
        /// AOP
        /// </summary>
        public decimal AOP
        {
            set { _aOP = value; }
            get { return _aOP; }
        }
        /// <summary>
        /// RAAN
        /// </summary>
        public decimal RAAN
        {
            set { _rAAN = value; }
            get { return _rAAN; }
        }
        /// <summary>
        /// MEANANOMALY
        /// </summary>
        public decimal MEANANOMALY
        {
            set { _mEANANOMALY = value; }
            get { return _mEANANOMALY; }
        }
        /// <summary>
        /// TRUEANOMALY
        /// </summary>
        public decimal TRUEANOMALY
        {
            set { _tRUEANOMALY = value; }
            get { return _tRUEANOMALY; }
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
