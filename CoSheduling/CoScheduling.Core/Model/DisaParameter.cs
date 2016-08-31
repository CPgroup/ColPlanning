//------------------------------------------------------------------------------
// 创建标识: 尹健
// 创建描述: 灾区参数实体类
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
	/// 实体类 DisaParameter
	/// </summary>
	[Serializable]
	public class DisaParameter
	{
		public DisaParameter()
		{ }

		/// <summary>
		/// 构造函数 DisaParameter
		/// </summary>
		/// <param name="iD">ID</param>
		/// <param name="a">参数A</param>
		/// <param name="b">参数B</param>
		/// <param name="c">参数C</param>
		/// <param name="d">参数D</param>
		/// <param name="isMajorAxis">是否为长轴</param>
		public DisaParameter(int iD, double a, double b, double c, double d, bool isMajorAxis)
		{
			_iD = iD;
			_a = a;
			_b = b;
			_c = c;
			_d = d;
			_isMajorAxis = isMajorAxis;
		}

		#region Model
		private int _iD;
		private double _a;
		private double _b;
		private double _c;
		private double _d;
        private bool _isMajorAxis;
		/// <summary>
		/// ID
		/// </summary>
		public int ID
		{
			set { _iD = value; }
			get { return _iD; }
		}
		/// <summary>
		/// A
		/// </summary>
		public double A
		{
			set { _a = value; }
			get { return _a; }
		}
		/// <summary>
		/// B
		/// </summary>
		public double B
		{
			set { _b = value; }
			get { return _b; }
		}
		/// <summary>
		/// C
		/// </summary>
		public double C
		{
			set { _c = value; }
			get { return _c; }
		}
		/// <summary>
		/// D
		/// </summary>
		public double D
		{
			set { _d = value; }
			get { return _d; }
		}
		/// <summary>
		/// isMajorAxis
		/// </summary>
        public bool isMajorAxis
		{
			set { _isMajorAxis = value; }
			get { return _isMajorAxis; }
		}
		#endregion Model
	}
}
