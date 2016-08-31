//------------------------------------------------------------------------------
// 创建标识: 董毅博
// 创建描述: 卫星观测任务设置实体类
// 创建时间: 2013.12.5
// 文件版本: 1.0
// 功能描述: 
// 修改标识: 
// 修改描述: 
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

namespace CoScheduling.Core.Model
{
	/// <summary>
	/// 实体类 TASK_SCHEME_LIST
	/// </summary>
	[Serializable]
	public class TASK_SCHEME_LIST
	{
		public TASK_SCHEME_LIST()
		{ }

		/// <summary>
		/// 构造函数 TASK_SCHEME_LIST
		/// </summary>
		/// <param name="sCHEMEID">SCHEMEID</param>
		/// <param name="sCHEMENAME">SCHEMENAME</param>
		/// <param name="sCHEMEBTIME">SCHEMEBTIME</param>
		/// <param name="sCHEMEETIME">SCHEMEETIME</param>
		public TASK_SCHEME_LIST(int sCHEMEID, string sCHEMENAME, DateTime sCHEMEBTIME, DateTime sCHEMEETIME,int dISAID)
		{
			_sCHEMEID = sCHEMEID;
			_sCHEMENAME = sCHEMENAME;
			_sCHEMEBTIME = sCHEMEBTIME;
			_sCHEMEETIME = sCHEMEETIME;
            _dISAID = dISAID;
		}

		#region Model
        private int _sCHEMEID;
		private string _sCHEMENAME;
		private DateTime _sCHEMEBTIME;
		private DateTime _sCHEMEETIME;
        private int _dISAID;

        
		/// <summary>
		/// SCHEMEID
		/// </summary>
        public int SCHEMEID
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
        /// <summary>
        /// DISAID
        /// </summary>
        public int DISAID
        {
            get { return _dISAID; }
            set { _dISAID = value; }
        }
		#endregion Model
	}
}
