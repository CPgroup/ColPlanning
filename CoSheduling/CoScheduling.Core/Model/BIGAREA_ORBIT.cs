using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoScheduling.Core.Model
{
    [Serializable]
    public class BIGAREA_ORBIT
    {
        public BIGAREA_ORBIT()
        { }

        /// <summary>
        /// 构造函数 BIGAREA_ORBIT
        /// </summary>
        /// <param name="oRBITID">ORBITID</param>
        /// <param name="sATID">SATID</param>
        /// <param name="sAT_ORBITEPOCH">SAT_ORBITEPOCH</param>
        /// <param name="sAT_MEANMOTION">SAT_MEANMOTION</param>
        /// <param name="sAT_ECCENTRICITY">SAT_ECCENTRICITY</param>
        /// <param name="sAT_INCLINATION">SAT_INCLINATION</param>
        /// <param name="sAT_ARGOFPERIGEE">SAT_ARGOFPERIGEE</param>
        /// <param name="sAT_RAAN">SAT_RAAN</param>
        /// <param name="sAT_MEANANOMALY">SAT_MEANANOMALY</param>
        /// <param name="sAT_MEANMOTIONDOT">SAT_MEANMOTIONDOT</param>
        /// <param name="sAT_MEANMOTIONDOTDOT">SAT_MEANMOTIONDOTDOT</param>
        /// <param name="sAT_BSTAR">SAT_BSTAR</param>
        /// <param name="sAT_TLE1">SAT_TLE1</param>
        /// <param name="sAT_TLE2">SAT_TLE2</param>
        /// <param name="sCHEMEID">SCHEMEID</param>
        public BIGAREA_ORBIT(decimal oRBITID, decimal sATID, string sAT_ORBITEPOCH, string sAT_MEANMOTION, string sAT_ECCENTRICITY, string sAT_INCLINATION, string sAT_ARGOFPERIGEE, string sAT_RAAN, string sAT_MEANANOMALY, string sAT_MEANMOTIONDOT, string sAT_MEANMOTIONDOTDOT, string sAT_BSTAR, string sAT_TLE1, string sAT_TLE2, decimal sCHEMEID)
        {
            _oRBITID = oRBITID;
            _sATID = sATID;
            _sAT_ORBITEPOCH = sAT_ORBITEPOCH;
            _sAT_MEANMOTION = sAT_MEANMOTION;
            _sAT_ECCENTRICITY = sAT_ECCENTRICITY;
            _sAT_INCLINATION = sAT_INCLINATION;
            _sAT_ARGOFPERIGEE = sAT_ARGOFPERIGEE;
            _sAT_RAAN = sAT_RAAN;
            _sAT_MEANANOMALY = sAT_MEANANOMALY;
            _sAT_MEANMOTIONDOT = sAT_MEANMOTIONDOT;
            _sAT_MEANMOTIONDOTDOT = sAT_MEANMOTIONDOTDOT;
            _sAT_BSTAR = sAT_BSTAR;
            _sAT_TLE1 = sAT_TLE1;
            _sAT_TLE2 = sAT_TLE2;
            _sCHEMEID = sCHEMEID;
        }

        #region Model
        private decimal _oRBITID;
        private decimal _sATID;
        private string _sAT_ORBITEPOCH;
        private string _sAT_MEANMOTION;
        private string _sAT_ECCENTRICITY;
        private string _sAT_INCLINATION;
        private string _sAT_ARGOFPERIGEE;
        private string _sAT_RAAN;
        private string _sAT_MEANANOMALY;
        private string _sAT_MEANMOTIONDOT;
        private string _sAT_MEANMOTIONDOTDOT;
        private string _sAT_BSTAR;
        private string _sAT_TLE1;
        private string _sAT_TLE2;
        private decimal _sCHEMEID;
        /// <summary>
        /// ORBITID
        /// </summary>
        public decimal ORBITID
        {
            set { _oRBITID = value; }
            get { return _oRBITID; }
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
        /// SAT_ORBITEPOCH
        /// </summary>
        public string SAT_ORBITEPOCH
        {
            set { _sAT_ORBITEPOCH = value; }
            get { return _sAT_ORBITEPOCH; }
        }
        /// <summary>
        /// SAT_MEANMOTION
        /// </summary>
        public string SAT_MEANMOTION
        {
            set { _sAT_MEANMOTION = value; }
            get { return _sAT_MEANMOTION; }
        }
        /// <summary>
        /// SAT_ECCENTRICITY
        /// </summary>
        public string SAT_ECCENTRICITY
        {
            set { _sAT_ECCENTRICITY = value; }
            get { return _sAT_ECCENTRICITY; }
        }
        /// <summary>
        /// SAT_INCLINATION
        /// </summary>
        public string SAT_INCLINATION
        {
            set { _sAT_INCLINATION = value; }
            get { return _sAT_INCLINATION; }
        }
        /// <summary>
        /// SAT_ARGOFPERIGEE
        /// </summary>
        public string SAT_ARGOFPERIGEE
        {
            set { _sAT_ARGOFPERIGEE = value; }
            get { return _sAT_ARGOFPERIGEE; }
        }
        /// <summary>
        /// SAT_RAAN
        /// </summary>
        public string SAT_RAAN
        {
            set { _sAT_RAAN = value; }
            get { return _sAT_RAAN; }
        }
        /// <summary>
        /// SAT_MEANANOMALY
        /// </summary>
        public string SAT_MEANANOMALY
        {
            set { _sAT_MEANANOMALY = value; }
            get { return _sAT_MEANANOMALY; }
        }
        /// <summary>
        /// SAT_MEANMOTIONDOT
        /// </summary>
        public string SAT_MEANMOTIONDOT
        {
            set { _sAT_MEANMOTIONDOT = value; }
            get { return _sAT_MEANMOTIONDOT; }
        }
        /// <summary>
        /// SAT_MEANMOTIONDOTDOT
        /// </summary>
        public string SAT_MEANMOTIONDOTDOT
        {
            set { _sAT_MEANMOTIONDOTDOT = value; }
            get { return _sAT_MEANMOTIONDOTDOT; }
        }
        /// <summary>
        /// SAT_BSTAR
        /// </summary>
        public string SAT_BSTAR
        {
            set { _sAT_BSTAR = value; }
            get { return _sAT_BSTAR; }
        }
        /// <summary>
        /// SAT_TLE1
        /// </summary>
        public string SAT_TLE1
        {
            set { _sAT_TLE1 = value; }
            get { return _sAT_TLE1; }
        }
        /// <summary>
        /// SAT_TLE2
        /// </summary>
        public string SAT_TLE2
        {
            set { _sAT_TLE2 = value; }
            get { return _sAT_TLE2; }
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
