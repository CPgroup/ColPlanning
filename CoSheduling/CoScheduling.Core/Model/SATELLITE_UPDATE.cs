using System;
using System.Collections.Generic;
using System.Text;

namespace CoScheduling.Core.Model
{
    /// <summary>
    /// 实体类 SATELLITE_UPDATE
    /// </summary>
    [Serializable]
    public class SATELLITE_UPDATE
    {
        public SATELLITE_UPDATE()
        { }

        /// <summary>
        /// 构造函数 SATELLITE_UPDATE
        /// </summary>
        /// <param name="uPDATE_ID">UPDATE_ID</param>
        /// <param name="uPDATE_TABLE">UPDATE_TABLE</param>
        /// <param name="uPDATE_TIME">UPDATE_TIME</param>
        /// <param name="uPDATE_LOG">UPDATE_LOG</param>
        public SATELLITE_UPDATE(int uPDATE_ID, string uPDATE_TABLE, DateTime uPDATE_TIME, string uPDATE_LOG)
        {
            _uPDATE_ID = uPDATE_ID;
            _uPDATE_TABLE = uPDATE_TABLE;
            _uPDATE_TIME = uPDATE_TIME;
            _uPDATE_LOG = uPDATE_LOG;
        }

        #region Model
        private int _uPDATE_ID;
        private string _uPDATE_TABLE;
        private DateTime _uPDATE_TIME;
        private string _uPDATE_LOG;
        /// <summary>
        /// UPDATE_ID
        /// </summary>
        public int UPDATE_ID
        {
            set { _uPDATE_ID = value; }
            get { return _uPDATE_ID; }
        }
        /// <summary>
        /// UPDATE_TABLE
        /// </summary>
        public string UPDATE_TABLE
        {
            set { _uPDATE_TABLE = value; }
            get { return _uPDATE_TABLE; }
        }
        /// <summary>
        /// UPDATE_TIME
        /// </summary>
        public DateTime UPDATE_TIME
        {
            set { _uPDATE_TIME = value; }
            get { return _uPDATE_TIME; }
        }
        /// <summary>
        /// UPDATE_LOG
        /// </summary>
        public string UPDATE_LOG
        {
            set { _uPDATE_LOG = value; }
            get { return _uPDATE_LOG; }
        }
        #endregion Model
    }
}
