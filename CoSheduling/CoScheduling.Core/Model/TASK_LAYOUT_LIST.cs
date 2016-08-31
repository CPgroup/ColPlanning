//------------------------------------------------------------------------------
// 创建标识: 董毅博
// 创建描述: 卫星任务方案设置实体类
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
	/// 实体类 TASK_LAYOUT_LIST
	/// </summary>
	[Serializable]
	public class TASK_LAYOUT_LIST
	{
		public TASK_LAYOUT_LIST()
		{ }

		/// <summary>
		/// 构造函数 TASK_LAYOUT_LIST
		/// </summary>
		/// <param name="tASKID">TASKID</param>
		/// <param name="tASKNAME">TASKNAME</param>
		/// <param name="tASKTYPE">TASKTYPE</param>
		/// <param name="pRIORITY">PRIORITY</param>
		/// <param name="iMAGETYPE">IMAGETYPE</param>
		/// <param name="mAXGSD">MAXGSD</param>
		/// <param name="sTARTTIME">STARTTIME</param>
		/// <param name="eNDTIME">ENDTIME</param>
		/// <param name="sCHEMEID">SCHEMEID</param>
		/// <param name="tARGET_ID">TARGET_ID</param>
		/// <param name="iSCONTINUEDSPY">ISCONTINUEDSPY</param>
		/// <param name="lON1">LON1</param>
		/// <param name="lAT1">LAT1</param>
        /// <param name="AREASTRING">AREASTRING</param>
        public TASK_LAYOUT_LIST(int tASKID, string tASKNAME, int tASKTYPE, int pRIORITY, string iMAGETYPE, decimal mAXGSD, DateTime sTARTTIME, DateTime eNDTIME, int sCHEMEID, int tARGET_ID, int iSCONTINUEDSPY, decimal lON, decimal lAT, string aREASTRING)
		{
			_tASKID = tASKID;
			_tASKNAME = tASKNAME;
			_tASKTYPE = tASKTYPE;
			_pRIORITY = pRIORITY;
			_iMAGETYPE = iMAGETYPE;
			_mAXGSD = mAXGSD;
			_sTARTTIME = sTARTTIME;
			_eNDTIME = eNDTIME;
			_sCHEMEID = sCHEMEID;
			_tARGET_ID = tARGET_ID;
			_iSCONTINUEDSPY = iSCONTINUEDSPY;
			_lON = lON;
			_lAT = lAT;
            _aREASTRING = aREASTRING;
		}

		#region Model
		private int _tASKID;
		private string _tASKNAME;
		private int _tASKTYPE;
		private int _pRIORITY;
		private string _iMAGETYPE;
		private decimal _mAXGSD;
		private DateTime _sTARTTIME;
		private DateTime _eNDTIME;
		private int _sCHEMEID;
		private int _tARGET_ID;
		private int _iSCONTINUEDSPY;
		private decimal _lON;
		private decimal _lAT;
        private string _aREASTRING;
		/// <summary>
		/// TASKID
		/// </summary>
		public int TASKID
		{
			set { _tASKID = value; }
			get { return _tASKID; }
		}
		/// <summary>
		/// TASKNAME
		/// </summary>
		public string TASKNAME
		{
			set { _tASKNAME = value; }
			get { return _tASKNAME; }
		}
		/// <summary>
		/// TASKTYPE
		/// </summary>
		public int TASKTYPE
		{
			set { _tASKTYPE = value; }
			get { return _tASKTYPE; }
		}
		/// <summary>
		/// PRIORITY
		/// </summary>
        public int PRIORITY
		{
			set { _pRIORITY = value; }
			get { return _pRIORITY; }
		}
		/// <summary>
		/// IMAGETYPE
		/// </summary>
		public string IMAGETYPE
		{
			set { _iMAGETYPE = value; }
			get { return _iMAGETYPE; }
		}
		/// <summary>
		/// MAXGSD
		/// </summary>
		public decimal MAXGSD
		{
			set { _mAXGSD = value; }
			get { return _mAXGSD; }
		}
		/// <summary>
		/// STARTTIME
		/// </summary>
		public DateTime STARTTIME
		{
			set { _sTARTTIME = value; }
			get { return _sTARTTIME; }
		}
		/// <summary>
		/// ENDTIME
		/// </summary>
		public DateTime ENDTIME
		{
			set { _eNDTIME = value; }
			get { return _eNDTIME; }
		}
		/// <summary>
		/// SCHEMEID
		/// </summary>
        public int SCHEMEID
		{
			set { _sCHEMEID = value; }
			get { return _sCHEMEID; }
		}
		/// <summary>
		/// TARGET_ID
		/// </summary>
        public int TARGET_ID
		{
			set { _tARGET_ID = value; }
			get { return _tARGET_ID; }
		}
		/// <summary>
		/// ISCONTINUEDSPY
		/// </summary>
        public int ISCONTINUEDSPY
		{
			set { _iSCONTINUEDSPY = value; }
			get { return _iSCONTINUEDSPY; }
		}
		/// <summary>
		/// LON
		/// </summary>
		public decimal LON
		{
			set { _lON = value; }
			get { return _lON; }
		}

		/// <summary>
		/// LAT
		/// </summary>
		public decimal LAT
		{
			set { _lAT = value; }
			get { return _lAT; }
		}

        /// <summary>
        /// AREASTRING
        /// </summary>
        public string AREASTRING
        {
            set { _aREASTRING = value; }
            get { return _aREASTRING; }
        }

		#endregion Model
	}
}
