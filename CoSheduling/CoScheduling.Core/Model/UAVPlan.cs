//------------------------------------------------------------------------------
// 创建标识: 尹健
// 创建描述: 无人机监测方案实体类
// 创建时间:2013.11.11
// 文件版本:1.0
// 功能描述: 
// 修改标识: 
// 修改描述: 
//------------------------------------------------------------------------------

using System;

namespace CoScheduling.Core.Model
{
	/// <summary>
	/// 实体类 UAVPlan
	/// </summary>
	[Serializable]
	public class UAVPlan
	{
		public UAVPlan()
		{ }

		/// <summary>
		/// 构造函数 UAVPlan
		/// </summary>
		/// <param name="iD">ID</param>
		/// <param name="cID">所属单位ID</param>
		/// <param name="compName">单位名称</param>
		/// <param name="pID">集结点ID</param>
		/// <param name="expTime">预计时间</param>
		/// <param name="geneTime">生成时间</param>
		/// <param name="isSelected">是否使用</param>
		public UAVPlan(int iD, int cID, string compName, int pID, double expTime, DateTime geneTime, int isSelected)
		{
			_iD = iD;
			_cID = cID;
			_compName = compName;
			_pID = pID;
			_expTime = expTime;
			_geneTime = geneTime;
			_isSelected = isSelected;
		}

		#region Model
		private int _iD;
		private int _cID;
		private string _compName;
		private int _pID;
		private double _expTime;
		private DateTime _geneTime;
		private int _isSelected;
		/// <summary>
		/// ID
		/// </summary>
		public int ID
		{
			set { _iD = value; }
			get { return _iD; }
		}
		/// <summary>
		/// 所属单位ID
		/// </summary>
		public int CID
		{
			set { _cID = value; }
			get { return _cID; }
		}
		/// <summary>
		/// 单位名称
		/// </summary>
		public string CompName
		{
			set { _compName = value; }
			get { return _compName; }
		}
		/// <summary>
		/// 集结点ID
		/// </summary>
		public int PID
		{
			set { _pID = value; }
			get { return _pID; }
		}
		/// <summary>
		/// 预计时间
		/// </summary>
		public double ExpTime
		{
			set { _expTime = value; }
			get { return _expTime; }
		}
		/// <summary>
		/// 生成时间
		/// </summary>
		public DateTime GeneTime
		{
			set { _geneTime = value; }
			get { return _geneTime; }
		}
		/// <summary>
		/// 是否使用
		/// </summary>
		public int isSelected
		{
			set { _isSelected = value; }
			get { return _isSelected; }
		}
		#endregion Model
	}
}
