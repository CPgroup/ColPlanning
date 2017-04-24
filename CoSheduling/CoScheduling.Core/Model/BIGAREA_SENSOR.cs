using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoScheduling.Core.Model
{
    [Serializable]
    public class BIGAREA_SENSOR
    {
        public BIGAREA_SENSOR()
        { }

        /// <summary>
        /// 构造函数 BIGAREA_SENSOR
        /// </summary>
        /// <param name="sATSENSORID">SATSENSORID</param>
        /// <param name="sENSORID">SENSORID</param>
        /// <param name="sATID">SATID</param>
        /// <param name="sCHEMEID">SCHEMEID</param>
        public BIGAREA_SENSOR(decimal sATSENSORID, decimal sENSORID, decimal sATID, decimal sCHEMEID)
        {
            _sATSENSORID = sATSENSORID;
            _sENSORID = sENSORID;
            _sATID = sATID;
            _sCHEMEID = sCHEMEID;
        }

        #region Model
        private decimal _sATSENSORID;
        private decimal _sENSORID;
        private decimal _sATID;
        private decimal _sCHEMEID;
        /// <summary>
        /// SATSENSORID
        /// </summary>
        public decimal SATSENSORID
        {
            set { _sATSENSORID = value; }
            get { return _sATSENSORID; }
        }
        /// <summary>
        /// SENSORID
        /// </summary>
        public decimal SENSORID
        {
            set { _sENSORID = value; }
            get { return _sENSORID; }
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
