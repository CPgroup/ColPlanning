//------------------------------------------------------------------------------
// 创建标识: 尹健
// 创建描述: 单位无人机实体类
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
	/// 实体类 CompanyUAV
	/// </summary>
	[Serializable]
	public class CompanyUAV
	{
		public CompanyUAV()
		{ }

		/// <summary>
		/// 构造函数 CompanyUAV
		/// </summary>
		/// <param name="iD">ID</param>
		/// <param name="length">机身长度</param>
		/// <param name="wingspan">翼展</param>
		/// <param name="weight">重量</param>
		/// <param name="driveMode">驱动模式</param>
		/// <param name="takeoffMode">起飞模式</param>
		/// <param name="landingMode">着陆方式</param>
		/// <param name="flightAltitude">飞行高度</param>
		/// <param name="radius">巡航半径</param>
		/// <param name="averageSpeed">平均速度</param>
		/// <param name="endurance">续航能力</param>
		/// <param name="windResistance">抗风能力</param>
		/// <param name="stallSpeed">失速速度</param>
		/// <param name="controlDistance">控制距离</param>
		/// <param name="camera">搭载相机</param>
		/// <param name="cID">所属单位ID</param>
		public CompanyUAV(int iD, double length, double wingspan, double weight, string driveMode, string takeoffMode, string landingMode, double flightAltitude, double radius, double averageSpeed, double endurance, double windResistance, double stallSpeed, double controlDistance, string camera, int cID)
		{
			_iD = iD;
			_length = length;
			_wingspan = wingspan;
			_weight = weight;
			_driveMode = driveMode;
			_takeoffMode = takeoffMode;
			_landingMode = landingMode;
			_flightAltitude = flightAltitude;
			_radius = radius;
			_averageSpeed = averageSpeed;
			_endurance = endurance;
			_windResistance = windResistance;
			_stallSpeed = stallSpeed;
			_controlDistance = controlDistance;
			_camera = camera;
			_cID = cID;
		}

		#region Model
		private int _iD;
		private double _length;
		private double _wingspan;
		private double _weight;
		private string _driveMode;
		private string _takeoffMode;
		private string _landingMode;
		private double _flightAltitude;
		private double _radius;
		private double _averageSpeed;
		private double _endurance;
		private double _windResistance;
		private double _stallSpeed;
		private double _controlDistance;
		private string _camera;
		private int _cID;
		/// <summary>
		/// ID
		/// </summary>
		public int ID
		{
			set { _iD = value; }
			get { return _iD; }
		}
		/// <summary>
		/// 机身长度
		/// </summary>
		public double Length
		{
			set { _length = value; }
			get { return _length; }
		}
		/// <summary>
		/// 翼展
		/// </summary>
		public double Wingspan
		{
			set { _wingspan = value; }
			get { return _wingspan; }
		}
		/// <summary>
		/// 重量
		/// </summary>
		public double Weight
		{
			set { _weight = value; }
			get { return _weight; }
		}
		/// <summary>
		/// 驱动模式
		/// </summary>
		public string DriveMode
		{
			set { _driveMode = value; }
			get { return _driveMode; }
		}
		/// <summary>
		/// 起飞模式
		/// </summary>
		public string TakeoffMode
		{
			set { _takeoffMode = value; }
			get { return _takeoffMode; }
		}
		/// <summary>
		/// 着陆方式
		/// </summary>
		public string LandingMode
		{
			set { _landingMode = value; }
			get { return _landingMode; }
		}
		/// <summary>
		/// 飞行高度
		/// </summary>
		public double FlightAltitude
		{
			set { _flightAltitude = value; }
			get { return _flightAltitude; }
		}
		/// <summary>
		/// 巡航半径
		/// </summary>
		public double Radius
		{
			set { _radius = value; }
			get { return _radius; }
		}
		/// <summary>
		/// 平均速度
		/// </summary>
		public double AverageSpeed
		{
			set { _averageSpeed = value; }
			get { return _averageSpeed; }
		}
		/// <summary>
		/// 续航能力
		/// </summary>
		public double Endurance
		{
			set { _endurance = value; }
			get { return _endurance; }
		}
		/// <summary>
		/// 抗风能力
		/// </summary>
		public double WindResistance
		{
			set { _windResistance = value; }
			get { return _windResistance; }
		}
		/// <summary>
		/// 失速速度
		/// </summary>
		public double StallSpeed
		{
			set { _stallSpeed = value; }
			get { return _stallSpeed; }
		}
		/// <summary>
		/// 控制距离
		/// </summary>
		public double ControlDistance
		{
			set { _controlDistance = value; }
			get { return _controlDistance; }
		}
		/// <summary>
		/// 搭载相机
		/// </summary>
		public string Camera
		{
			set { _camera = value; }
			get { return _camera; }
		}
		/// <summary>
		/// 所属单位ID
		/// </summary>
		public int CID
		{
			set { _cID = value; }
			get { return _cID; }
		}
		#endregion Model
	}
}
