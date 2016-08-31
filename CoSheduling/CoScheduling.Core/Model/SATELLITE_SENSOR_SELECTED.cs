//------------------------------------------------------------------------------
// 创建标识: 董毅博
// 创建描述: 卫星选择实体类
// 创建时间:2013.12.18
// 文件版本:1.0
// 功能描述: 
// 修改标识: 
// 修改描述: 
//------------------------------------------------------------------------------

using System;

namespace CoScheduling.Core.Model
{
	/// <summary>
	/// 实体类 SATELLITE_SENSOR_SELECTED
	/// </summary>
	[Serializable]
	public class SATELLITE_SENSOR_SELECTED
	{
		public SATELLITE_SENSOR_SELECTED()
		{ }

		/// <summary>
		/// 构造函数 SATELLITE_SENSOR_SELECTED
		/// </summary>
		/// <param name="sENSOR_ID">SENSOR_ID</param>
		/// <param name="sENSOR_NAME">SENSOR_NAME</param>
		/// <param name="sAT_ID">SAT_ID</param>
		/// <param name="sAT_NAME">SAT_NAME</param>
		/// <param name="sELECTED">SELECTED</param>
		public SATELLITE_SENSOR_SELECTED(decimal sENSOR_ID, string sENSOR_NAME, decimal sAT_ID, string sAT_NAME, decimal sELECTED)
		{
			_sENSOR_ID = sENSOR_ID;
			_sENSOR_NAME = sENSOR_NAME;
			_sAT_ID = sAT_ID;
			_sAT_NAME = sAT_NAME;
			_sELECTED = sELECTED;
		}

		#region Model
		private decimal _sENSOR_ID;
		private string _sENSOR_NAME;
		private decimal _sAT_ID;
		private string _sAT_NAME;
		private decimal _sELECTED;
		/// <summary>
		/// SENSOR_ID
		/// </summary>
		public decimal SENSOR_ID
		{
			set { _sENSOR_ID = value; }
			get { return _sENSOR_ID; }
		}
		/// <summary>
		/// SENSOR_NAME
		/// </summary>
		public string SENSOR_NAME
		{
			set { _sENSOR_NAME = value; }
			get { return _sENSOR_NAME; }
		}
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
		/// SELECTED
		/// </summary>
		public decimal SELECTED
		{
			set { _sELECTED = value; }
			get { return _sELECTED; }
		}
		#endregion Model
	}
}
