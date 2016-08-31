//------------------------------------------------------------------------------
// 创建标识: 尹健
// 创建描述: 任务区颜色实体类
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
	/// 实体类 Color
	/// </summary>
	[Serializable]
	public class Color
	{
		public Color()
		{ }

		/// <summary>
		/// 构造函数 Color
		/// </summary>
		/// <param name="iD">ID</param>
		/// <param name="color">Color</param>
		public Color(int iD, string color)
		{
			_iD = iD;
			_color = color;
		}

		#region Model
		private int _iD;
		private string _color;
		/// <summary>
		/// ID
		/// </summary>
		public int ID
		{
			set { _iD = value; }
			get { return _iD; }
		}
		/// <summary>
		/// Color
		/// </summary>
		public string TColor
		{
			set { _color = value; }
			get { return _color; }
		}
		#endregion Model
	}
}
