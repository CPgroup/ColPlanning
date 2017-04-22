//----------------------------------------------------------------------------
//创建标识：李佳霖
// 创建描述: 第一类传感器实体类（卫星，无人机，飞艇，地面测量车）
// 创建时间:2017.3.28
// 文件版本:1.0
// 功能描述:第一类传感器的实体类，描述传感器的各项属性，包括成员变量和构造函数
// 修改标识: 
// 修改描述: 
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoScheduling.Core.Model
{
    //实体类 Sensor_1
    public class Sensor_1
    {
        public Sensor_1()
        {
            //无参构造函数，可以设置成员变量的默认值

        }

        //有参构造函数
        public Sensor_1(decimal SensorID,string SensorName,string SensorType,
            decimal BandNumber,decimal BandCenter,decimal LookAngle,decimal SwathVelocity,
            decimal SwathWidth,decimal GeometryResolution,decimal PLATFORM_ID,
            string Application,decimal Inclination,decimal PixelPerLine,
            decimal SquintAngle,decimal AzimuthDirectionResolution,decimal DistanceResolution,
            decimal MaxSlewTimesPerCircle,decimal MaxPowerOnTimesPerDay,
            decimal MinImagingTimeNonInterupt,decimal DuringSwitch,decimal MaxObvDur,
            decimal MinObvDur,decimal MAXGSD)
        {
            
            //数据库中的必填属性
            _SensorID = SensorID;
            _SensorName = SensorName;
            _SensorType = SensorType;
            _BandNumber = BandNumber;
            _BandCenter = BandCenter;
            _LookAngle = LookAngle;
            _SwathVelocity = SwathVelocity;
            _SwathWidth = SwathWidth;
            _GeometryResolution = GeometryResolution;
            _PLATFORM_ID = PLATFORM_ID;
            //数据库中的非必填属性
            _Application = Application;
            _Inclination = Inclination;
            _PixelPerLine = PixelPerLine;
            _SquintAngle=SquintAngle;
            _AzimuthDirectionResolution = AzimuthDirectionResolution;
            _DistanceResolution = DistanceResolution;
            _MaxSlewTimesPerCircle = MaxSlewTimesPerCircle;
            _MaxPowerOnTimesPerDay = MaxPowerOnTimesPerDay;
            _MinImagingTimeNonInterupt = MinImagingTimeNonInterupt;
            _DuringSwitch = DuringSwitch;

            _MaxObvDur = MaxObvDur;
            _MinObvDur = MinObvDur;
            _MAXGSD = MAXGSD;
        }

        #region Model
        //数据库中的必填属性
        private decimal _SensorID;
        private string _SensorName;
        private string _SensorType;
        private decimal _BandNumber;
        private decimal _BandCenter;
        private decimal _LookAngle;
        private decimal _SwathVelocity;
        private decimal _SwathWidth;
        private decimal _GeometryResolution;
        private decimal _PLATFORM_ID;
        //数据库中的非必填属性
        private string _Application;
        private decimal _Inclination;
        private decimal _PixelPerLine;
        private decimal _SquintAngle;
        private decimal _AzimuthDirectionResolution;
        private decimal _DistanceResolution;
        private decimal _MaxSlewTimesPerCircle;
        private decimal _MaxPowerOnTimesPerDay;
        private decimal _MinImagingTimeNonInterupt;
        private decimal _DuringSwitch;

        private decimal _MaxObvDur;
        private decimal _MinObvDur;
        private decimal _MAXGSD;

        //定义各成员变量的赋值和获取值的函数
        public decimal SensorID
        {
            set { _SensorID = value; }
            get { return _SensorID; }
        }
        
        public string SensorName
        {
            set { _SensorName = value; }
            get { return _SensorName; }
        }
        public string SensorType
        {
            set { _SensorType = value; }
            get { return _SensorType; }
        }
        public decimal BandNumber
        {
            set { _BandNumber = value; }
            get { return _BandNumber; }
        }
        public decimal BandCenter
        {
            set { _BandCenter = value; }
            get { return _BandCenter; }
        }
        public decimal LookAngle
        {
            set { _LookAngle = value; }
            get { return _LookAngle; }
        }
        public decimal SwathVelocity
        {
            set { _SwathVelocity = value; }
            get { return _SwathVelocity; }
        }
        public decimal SwathWidth
        {
            set { _SwathWidth = value; }
            get { return _SwathWidth; }
        }
        public decimal GeometryResolution
        {
            set { _GeometryResolution = value; }
            get { return _GeometryResolution; }
        }
        public decimal PLATFORM_ID
        {
            set { _PLATFORM_ID = value; }
            get { return _PLATFORM_ID; }
        }
        public string Application
        {
            set { _Application = value; }
            get { return _Application; }
        }
        public decimal Inclination
        {
            set { _Inclination = value; }
            get { return _Inclination; }
        }
        public decimal PixelPerLine
        {
            set { _PixelPerLine = value; }
            get { return _PixelPerLine; }
        }
        public decimal SquintAngle
        {
            set { _SquintAngle = value; }
            get { return _SquintAngle; }
        }
        public decimal AzimuthDirectionResolution
        {
            set { _AzimuthDirectionResolution = value; }
            get { return _AzimuthDirectionResolution; }
        }
        public decimal DistanceResolution
        {
            set { _DistanceResolution = value; }
            get { return _DistanceResolution; }
        }
        public decimal MaxSlewTimesPerCircle
        {
            set { _MaxSlewTimesPerCircle = value; }
            get { return _MaxSlewTimesPerCircle; }
        }
        public decimal MaxPowerOnTimesPerDay
        {
            set { _MaxPowerOnTimesPerDay = value; }
            get { return _MaxPowerOnTimesPerDay; }
        }
        public decimal MinImagingTimeNonInterupt
        {
            set { _MinImagingTimeNonInterupt = value; }
            get { return _MinImagingTimeNonInterupt; }
        }
        public decimal DuringSwitch
        {
            set { _DuringSwitch = value; }
            get { return _DuringSwitch; }
        }
        public decimal MaxObvDur
        {
            set { _MaxObvDur = value; }
            get { return _MaxObvDur; }
        }
        public decimal MinObvDur
        {
            set { _MinObvDur = value; }
            get { return _MinObvDur; }
        }
        public decimal MAXGSD
        {
            set { _MAXGSD = value; }
            get { return _MAXGSD; }
        }
        #endregion Model




    }
}
