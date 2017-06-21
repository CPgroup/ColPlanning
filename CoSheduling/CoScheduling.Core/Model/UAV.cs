//------------------------------------------------------------------------------
// 创建标识: 尹健
// 创建描述: 无人机实体类
// 创建时间:2013.11.15
// 文件版本:1.0
// 功能描述: 
// 修改标识: 
// 修改描述: 
//------------------------------------------------------------------------------

using System;

namespace CoScheduling.Core.Model
{
	/// <summary>
	/// 实体类 UAV
	/// </summary>
	[Serializable]
	public class UAV
	{
		public UAV()
		{ }

		/// <summary>
		/// 构造函数 UAV
		/// </summary>
		/// <param name="iD">ID</param>
		/// <param name="model">型号</param>
		/// <param name="size">尺寸</param>
		/// <param name="loads">荷载</param>
		/// <param name="windResistance">抗风能力</param>
		/// <param name="rainResistance">抗雨能力</param>
		/// <param name="radius">控制半径</param>
		/// <param name="endurance">续航时间</param>
		/// <param name="speed">飞行速度</param>
		/// <param name="height">最高高度</param>
		/// <param name="voyage">航程</param>
		/// <param name="takeoffMode">起飞模式</param>
		/// <param name="recycleMode">回收模式</param>
		/// <param name="UnfoldTime">展开时间</param>
		/// <param name="FoldTime">撤回时间</param>
		/// <param name="isUnload">是否装卸</param>
		/// <param name="refulTime">加油时间</param>
		/// <param name="camera">相机型号</param>
		/// <param name="isUse">是否使用</param>
		/// <param name="company">所属公司</param>
		/// <param name="type">无人机类型</param>
        ///         /// <param name="Longitude">出发位置经度</param>
        ///  /// <param name="Latitude">出发纬度</param>
        ///  <param name="SwathWidth">幅宽</param>
        public UAV(int iD, string model, double size, string loads, string windResistance, string rainResistance, double radius, double endurance, double speed, double height, double voyage, string takeoffMode, string recycleMode, double UnfoldTime, double FoldTime, string isUnload, double refulTime, string camera, Boolean isUse, string company, string type, decimal Longitude, decimal Latitude, decimal SwathWidth)
		{
			_iD = iD;
			_model = model;
			_size = size;
			_loads = loads;
			_windResistance = windResistance;
			_rainResistance = rainResistance;
			_radius = radius;
			_endurance = endurance;
			_speed = speed;
			_height = height;
			_voyage = voyage;
			_takeoffMode = takeoffMode;
			_recycleMode = recycleMode;
			_UnfoldTime = UnfoldTime;
			_FoldTime = FoldTime;
			_isUnload = isUnload;
			_refulTime = refulTime;
			_camera = camera;
			_isUse = isUse;
			_company = company;
			_type = type;
             _Longitude = Longitude;
            _Latitude = Latitude;
            _SwathWidth = SwathWidth;
		}

		#region Model
		private int _iD;
		private string _model;
		private double _size;
		private string _loads;
		private string _windResistance;
		private string _rainResistance;
		private double _radius;
		private double _endurance;
		private double _speed;
		private double _height;
		private double _voyage;
		private string _takeoffMode;
		private string _recycleMode;
		private double _UnfoldTime;
		private double _FoldTime;
		private string _isUnload;
		private double _refulTime;
		private string _camera;
		private Boolean _isUse;
		private string _company;
		private string _type;
         private decimal _Longitude;
        private decimal _Latitude;
        private decimal _SwathWidth;
		/// <summary>
		/// ID
		/// </summary>
		public int ID
		{
			set { _iD = value; }
			get { return _iD; }
		}
		/// <summary>
		/// 型号
		/// </summary>
		public string Model
		{
			set { _model = value; }
			get { return _model; }
		}
		/// <summary>
		/// 尺寸
		/// </summary>
		public double Size
		{
			set { _size = value; }
			get { return _size; }
		}
		/// <summary>
		/// 荷载
		/// </summary>
		public string Loads
		{
			set { _loads = value; }
			get { return _loads; }
		}
		/// <summary>
		/// 抗风能力
		/// </summary>
		public string WindResistance
		{
			set { _windResistance = value; }
			get { return _windResistance; }
		}
		/// <summary>
		/// 抗雨能力
		/// </summary>
		public string RainResistance
		{
			set { _rainResistance = value; }
			get { return _rainResistance; }
		}
		/// <summary>
		/// 控制半径
		/// </summary>
		public double Radius
		{
			set { _radius = value; }
			get { return _radius; }
		}
		/// <summary>
		/// 续航时间
		/// </summary>
		public double Endurance
		{
			set { _endurance = value; }
			get { return _endurance; }
		}
		/// <summary>
		/// 飞行速度
		/// </summary>
		public double Speed
		{
			set { _speed = value; }
			get { return _speed; }
		}
		/// <summary>
		/// 最高高度
		/// </summary>
		public double Height
		{
			set { _height = value; }
			get { return _height; }
		}
		/// <summary>
		/// 航程
		/// </summary>
		public double Voyage
		{
			set { _voyage = value; }
			get { return _voyage; }
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
		/// 回收模式
		/// </summary>
		public string RecycleMode
		{
			set { _recycleMode = value; }
			get { return _recycleMode; }
		}
		/// <summary>
		/// 展开时间
		/// </summary>
		public double UnfoldTime
		{
			set { _UnfoldTime = value; }
			get { return _UnfoldTime; }
		}
		/// <summary>
		/// 撤回时间
		/// </summary>
		public double FoldTime
		{
			set { _FoldTime = value; }
			get { return _FoldTime; }
		}
		/// <summary>
		/// 是否装卸
		/// </summary>
		public string isUnload
		{
			set { _isUnload = value; }
			get { return _isUnload; }
		}
		/// <summary>
		/// 加油时间
		/// </summary>
		public double RefulTime
		{
			set { _refulTime = value; }
			get { return _refulTime; }
		}
		/// <summary>
		/// 相机型号
		/// </summary>
		public string Camera
		{
			set { _camera = value; }
			get { return _camera; }
		}
		/// <summary>
		/// 是否使用
		/// </summary>
        public Boolean isUse
		{
			set { _isUse = value; }
			get { return _isUse; }
		}
		/// <summary>
		/// 所属公司
		/// </summary>
		public string Company
		{
			set { _company = value; }
			get { return _company; }
		}
		/// <summary>
		/// 无人机类型
		/// </summary>
		public string Type
		{
			set { _type = value; }
			get { return _type; }
		}
         public decimal Longitude
        {
            set { _Longitude = value; }
            get { return _Longitude; }
        }
        public decimal Latitude
        {
            set { _Latitude = value; }
            get { return _Latitude; }
        }
        public decimal SwathWidth
        {
            set { _SwathWidth = value; }
            get { return _SwathWidth; }
        }
		#endregion Model
	}
}
