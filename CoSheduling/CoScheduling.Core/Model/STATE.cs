//----------------------------------------------------------------------------
//创建标识：李佳霖
// 创建描述: 观测平台状态实体类
// 创建时间:2017.4.6
// 文件版本:1.0
// 功能描述:描述观测平台状态的属性信息，包括成员变量和构造函数
// 修改标识: 
// 修改描述: 
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoScheduling.Core.Model
{
    //实体类 STATE
    public class STATE
    {
        public STATE()
        {
            //无参构造函数，可以设置成员变量的默认值
        }
        //有参构造函数
        public STATE(decimal PLATFORM_ID, string TimeReference, string SpaceReference,
            decimal Longitude, decimal Latitude, decimal Elevation, decimal SlewAngle,
            DateTime PLATFORM_TIME, decimal CloudCover, string WeatherModelName,
            decimal PrecipitationRate, decimal WindSpeed, decimal AmbientTemperature,
            decimal MisDisOfRoad, decimal MTBF, decimal ObservingTime, bool UsingState,
            bool FalutState, decimal ResourceConsuming, decimal CurrentMemory)
        {
            _PLATFORM_ID = PLATFORM_ID;
            _TimeReference = TimeReference;
            _SpaceReference = SpaceReference;
            _Longitude = Longitude;
            _Latitude = Latitude;
            _Elevation = Elevation;
            _SlewAngle = SlewAngle;
            _PLATFORM_TIME = PLATFORM_TIME;
            _CloudCover = CloudCover;
            _WeatherModelName = WeatherModelName;

            _PrecipitationRate=PrecipitationRate;
            _WindSpeed = WindSpeed;
            _AmbientTemperature = AmbientTemperature;
            _MisDisOfRoad = MisDisOfRoad;
            _MTBF = MTBF;
            _ObservingTime = ObservingTime;
            _UsingState = UsingState;
            _FalutState = FalutState;
            _ResourceConsuming = ResourceConsuming;
            _CurrentMemory = CurrentMemory;
        }

        #region Model
        private decimal _PLATFORM_ID;
        private string _TimeReference;
        private string _SpaceReference;
        private decimal _Longitude;
        private decimal _Latitude;
        private decimal _Elevation;
        private decimal _SlewAngle;
        private DateTime _PLATFORM_TIME;
        private decimal _CloudCover;
        private string _WeatherModelName;

        private decimal _PrecipitationRate;
        private decimal _WindSpeed;
        private decimal _AmbientTemperature;
        private decimal _MisDisOfRoad;
        private decimal _MTBF;
        private decimal _ObservingTime;
        private bool _UsingState;
        private bool _FalutState;
        private decimal _ResourceConsuming;
        private decimal _CurrentMemory;

        public decimal PLATFORM_ID
        {
            set { _PLATFORM_ID = value; }
            get { return _PLATFORM_ID; }
        }
        public string TimeReference
        {
            set { _TimeReference = value; }
            get { return _TimeReference; }
        }
        public string SpaceReference
        {
            set { _SpaceReference = value; }
            get { return _SpaceReference; }
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
        public decimal Elevation
        {
            set { _Elevation = value; }
            get { return _Elevation; }
        }
        public decimal SlewAngle
        {
            set { _SlewAngle = value; }
            get { return _SlewAngle; }
        }
        public DateTime PLATFORM_TIME
        {
            set { _PLATFORM_TIME = value; }
            get { return _PLATFORM_TIME; }
        }
        public decimal CloudCover
        {
            set { _CloudCover = value; }
            get { return _CloudCover; }
        }
        public string WeatherModelName
        {
            set { _WeatherModelName = value; }
            get { return _WeatherModelName; }
        }
        public decimal PrecipitationRate
        {
            set { _PrecipitationRate = value; }
            get { return _PrecipitationRate; }
        }
        public decimal WindSpeed
        {
            set { _WindSpeed = value; }
            get { return _WindSpeed; }
        }
        public decimal AmbientTemperature
        {
            set { _AmbientTemperature = value; }
            get { return _AmbientTemperature; }
        }
        public decimal MisDisOfRoad
        {
            set { _MisDisOfRoad = value; }
            get { return _MisDisOfRoad; }
        }
        public decimal MTBF
        {
            set { _MTBF = value; }
            get { return _MTBF; }
        }
        public decimal ObservingTime
        {
            set { _ObservingTime = value; }
            get { return _ObservingTime; }
        }
        public bool UsingState
        {
            set { _UsingState = value; }
            get { return _UsingState; }
        }
        public bool FalutState
        {
            set { _FalutState = value; }
            get { return _FalutState; }
        }
        public decimal ResourceConsuming
        {
            set { _ResourceConsuming = value; }
            get { return _ResourceConsuming; }
        }
        public decimal CurrentMemory
        {
            set { _CurrentMemory = value; }
            get { return _CurrentMemory; }
        }
        #endregion Model


    }
}
