//------------------------------------------------------------------------------
// 创建标识: 尹健
// 创建描述: 志愿者信息实体类
// 创建时间:2014.10.29
// 文件版本:1.0
// 功能描述: 
// 修改标识: 
// 修改描述: 
//------------------------------------------------------------------------------


using System;

namespace CoScheduling.Core.Model
{
	/// <summary>
	/// 实体类 VUser
	/// </summary>
	[Serializable]
	public class VUser
	{
		public VUser()
		{ }

		/// <summary>
		/// 构造函数 VUser
		/// </summary>
		/// <param name="iD">ID</param>
		/// <param name="loginName">LoginName</param>
		/// <param name="pass">Pass</param>
		/// <param name="realName">RealName</param>
		/// <param name="sex">Sex</param>
		/// <param name="age">Age</param>
		/// <param name="address">Address</param>
		/// <param name="degree">Degree</param>
		/// <param name="occupation">Occupation</param>
		/// <param name="tel">Tel</param>
		/// <param name="lAT">LAT</param>
		/// <param name="lON">LON</param>
		/// <param name="flag">Flag</param>
		public VUser(int iD, string loginName, string pass, string realName, string sex, string age, string address, string degree, string occupation, string tel, double lAT, double lON, bool flag)
		{
			_iD = iD;
			_loginName = loginName;
			_pass = pass;
			_realName = realName;
			_sex = sex;
			_age = age;
			_address = address;
			_degree = degree;
			_occupation = occupation;
			_tel = tel;
			_lAT = lAT;
			_lON = lON;
			_flag = flag;
		}

		#region Model
		private int _iD;
		private string _loginName;
		private string _pass;
		private string _realName;
		private string _sex;
		private string _age;
		private string _address;
		private string _degree;
		private string _occupation;
		private string _tel;
		private double _lAT;
		private double _lON;
		private bool _flag;
		/// <summary>
		/// ID
		/// </summary>
		public int ID
		{
			set { _iD = value; }
			get { return _iD; }
		}
		/// <summary>
		/// LoginName
		/// </summary>
		public string LoginName
		{
			set { _loginName = value; }
			get { return _loginName; }
		}
		/// <summary>
		/// Pass
		/// </summary>
		public string Pass
		{
			set { _pass = value; }
			get { return _pass; }
		}
		/// <summary>
		/// RealName
		/// </summary>
		public string RealName
		{
			set { _realName = value; }
			get { return _realName; }
		}
		/// <summary>
		/// Sex
		/// </summary>
		public string Sex
		{
			set { _sex = value; }
			get { return _sex; }
		}
		/// <summary>
		/// Age
		/// </summary>
		public string Age
		{
			set { _age = value; }
			get { return _age; }
		}
		/// <summary>
		/// Address
		/// </summary>
		public string Address
		{
			set { _address = value; }
			get { return _address; }
		}
		/// <summary>
		/// Degree
		/// </summary>
		public string Degree
		{
			set { _degree = value; }
			get { return _degree; }
		}
		/// <summary>
		/// Occupation
		/// </summary>
		public string Occupation
		{
			set { _occupation = value; }
			get { return _occupation; }
		}
		/// <summary>
		/// Tel
		/// </summary>
		public string Tel
		{
			set { _tel = value; }
			get { return _tel; }
		}
		/// <summary>
		/// LAT
		/// </summary>
		public double LAT
		{
			set { _lAT = value; }
			get { return _lAT; }
		}
		/// <summary>
		/// LON
		/// </summary>
		public double LON
		{
			set { _lON = value; }
			get { return _lON; }
		}
		/// <summary>
		/// Flag
		/// </summary>
		public bool Flag
		{
			set { _flag = value; }
			get { return _flag; }
		}
		#endregion Model
	}
}
