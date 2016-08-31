//------------------------------------------------------------------------------
// 创建标识: 尹健
// 创建描述: 规划结果字符串实体类
// 创建时间:2014.6.26
// 文件版本:1.0
// 功能描述: 
// 修改标识: 
// 修改描述: 
//------------------------------------------------------------------------------

using System;

namespace CoScheduling.Core.Model
{
	/// <summary>
	/// 实体类 PlanString
	/// </summary>
	[Serializable]
	public class PlanString
	{
		public PlanString()
		{ }

		/// <summary>
		/// 构造函数 PlanString
		/// </summary>
		/// <param name="iD">ID</param>
		/// <param name="planString">最后得到的规划字符串</param>
		/// <param name="pID">任务区ID</param>
		public PlanString(int iD, string planString, int pID)
		{
			_iD = iD;
			_planString = planString;
			_pID = pID;
		}

		#region Model
		private int _iD;
		private string _planString;
		private int _pID;
		/// <summary>
		/// ID
		/// </summary>
		public int ID
		{
			set { _iD = value; }
			get { return _iD; }
		}
		/// <summary>
		/// 最后得到的规划字符串
		/// </summary>
		public string PlanedString
		{
			set { _planString = value; }
			get { return _planString; }
		}
		/// <summary>
		/// 任务区ID
		/// </summary>
		public int PID
		{
			set { _pID = value; }
			get { return _pID; }
		}
		#endregion Model
	}
}
