using System;
using System.Collections.Generic;
using System.Text;

namespace CoScheduling.Core.Model
{
    /// <summary>
    /// 实体类 SATELLITE_ALL
    /// </summary>
    [Serializable]
    public class SATELLITE_TEMP
    {
        public SATELLITE_TEMP()
        { }

        /// <summary>
        /// 构造函数 SATELLITE_ALL
        /// </summary>
        /// <param name="sATELLITE_ID">SATELLITE_ID</param>
        /// <param name="sATELLITE_NAME">SATELLITE_NAME</param>
        /// <param name="sATELLITE_UPDATETIME">SATELLITE_UPDATETIME</param>
        /// <param name="sATELLITE_CHOOSE">SATELLITE_CHOOSE</param>
        public SATELLITE_TEMP(decimal sATELLITE_ID,string sATELLITE_NAME, DateTime sATELLITE_UPDATETIME, int sATELLITE_CHOOSE)
        {
            _sATELLITE_ID = sATELLITE_ID;
            _sATELLITE_NAME = sATELLITE_NAME;
            _sATELLITE_UPDATETIME = sATELLITE_UPDATETIME;
            _sATELLITE_CHOOSE = sATELLITE_CHOOSE;
        }

        #region Model
        private decimal _sATELLITE_ID;
        private string _sATELLITE_NAME;  
        private DateTime _sATELLITE_UPDATETIME;
        private int _sATELLITE_CHOOSE;
        /// <summary>
        /// SATELLITE_ID
        /// </summary>
        public decimal SATELLITE_ID
        {
            set { _sATELLITE_ID = value; }
            get { return _sATELLITE_ID; }
        }
        /// <summary>
        /// SATELLITE_NAME
        /// </summary>
        public string SATELLITE_NAME
        {
            get { return _sATELLITE_NAME; }
            set { _sATELLITE_NAME = value; }
        }
        /// <summary>
        /// SATELLITE_UPDATETIME
        /// </summary>
        public DateTime SATELLITE_UPDATETIME
        {
            set { _sATELLITE_UPDATETIME = value; }
            get { return _sATELLITE_UPDATETIME; }
        }
        /// <summary>
        /// SATELLITE_CHOOSE
        /// </summary>
        public int SATELLITE_CHOOSE
        {
            set { _sATELLITE_CHOOSE = value; }
            get { return _sATELLITE_CHOOSE; }
        }
        #endregion Model
    }
}
