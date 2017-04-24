//----------------------------------------------------------------------------
//创建标识：李佳霖
// 创建描述: 无人机实体类
// 创建时间:2017.3.31
// 文件版本:1.0
// 功能描述:描述无人机平台的属性信息，包括成员变量和构造函数
// 修改标识: 
// 修改描述: 
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoScheduling.Core.Model
{

    //实体类 UAV_RANGE
    public class UAV_RANGE
    {
        public UAV_RANGE()
        {
            //无参构造函数，可以设置成员变量的默认值
        }

        //有参构造函数
        public UAV_RANGE(decimal PLATFORM_ID,string PLATFORM_Name,decimal NumberOfSensor,
            decimal CruisingVelocity,decimal RollVelocity,decimal PitchVelocity,
            decimal MaxVelocity,decimal MinVelocity,decimal Acceleration,decimal CruisingTime,
            decimal MaxSlewAngle,decimal MinSlewAngle,decimal CruisingAltitude,
            decimal MaxAltitude,decimal MaxDistance,decimal MinTurningRaduis,
            decimal PayLoad,decimal MaxLoad,decimal Base_ID)
        {
            _PLATFORM_ID = PLATFORM_ID;
            _PLATFORM_Name = PLATFORM_Name;
            _NumberOfSensor = NumberOfSensor;
            _CruisingVelocity = CruisingVelocity;
            _RollVelocity = RollVelocity;
            _PitchVelocity = PitchVelocity;
            _MaxVelocity = MaxVelocity;
            _MinVelocity = MinVelocity;
            _Acceleration = Acceleration;
            _CruisingTime = CruisingTime;

            _MaxSlewAngle = MaxSlewAngle;
            _MinSlewAngle = MinSlewAngle;
            _CruisingAltitude = CruisingAltitude;
            _MaxAltitude = MaxAltitude;
            _MaxDistance = MaxDistance;
            _MinTurningRadius = MinTurningRadius;
            _PayLoad = PayLoad;
            _MaxLoad = MaxLoad;
            _Base_ID = Base_ID;
        }

        #region Model
        private decimal _PLATFORM_ID;
        private string _PLATFORM_Name;
        private decimal _NumberOfSensor;
        private decimal _CruisingVelocity;
        private decimal _RollVelocity;
        private decimal _PitchVelocity;
        private decimal _MaxVelocity;
        private decimal _MinVelocity;
        private decimal _Acceleration;
        private decimal _CruisingTime;
        private decimal _MaxSlewAngle;
        private decimal _MinSlewAngle;
        private decimal _CruisingAltitude;
        private decimal _MaxAltitude;
        private decimal _MaxDistance;
        private decimal _MinTurningRadius;
        private decimal _PayLoad;
        private decimal _MaxLoad;
        private decimal _Base_ID;

        //定义各个成员变量的赋值和获取值的函数
        public decimal PLATFORM_ID
        {
            set { _PLATFORM_ID = value; }
            get { return _PLATFORM_ID; }
        }
        public string PLATFORM_Name
        {
            set { _PLATFORM_Name = value; }
            get { return _PLATFORM_Name; }
        }

        
        public decimal NumberOfSensor
        {
            set { _NumberOfSensor = value; }
            get { return _NumberOfSensor; }
        }
        public decimal CruisingVelocity
        {
            set { _CruisingVelocity = value; }
            get { return _CruisingVelocity; }
        }
        public decimal RollVelocity
        {
            set { _RollVelocity = value; }
            get { return _RollVelocity; }
        }
        public decimal PitchVelocity
        {
            set { _PitchVelocity = value; }
            get { return _PitchVelocity; }
        }
        public decimal MaxVelocity
        {
            set { _MaxVelocity = value; }
            get { return _MaxVelocity; }
        }
        public decimal MinVelocity
        {
            set { _MinVelocity = value; }
            get { return _MinVelocity; }
        }
        public decimal Acceleration
        {
            set { _Acceleration = value; }
            get { return _Acceleration; }
        }
        public decimal CruisingTime
        {
            set { _CruisingTime = value; }
            get { return _CruisingTime; }
        }
        public decimal MaxSlewAngle
        {
            set { _MaxSlewAngle = value; }
            get { return _MaxSlewAngle; }
        }
        public decimal MinSlewAngle
        {
            set { _MinSlewAngle = value; }
            get { return _MinSlewAngle; }
        }
        public decimal CruisingAltitude
        {
            set { _CruisingAltitude = value; }
            get { return _CruisingAltitude; }
        }
        public decimal MaxAltitude
        {
            set { _MaxAltitude = value; }
            get { return _MaxAltitude; }
        }
        public decimal MaxDistance
        {
            set { _MaxDistance = value; }
            get { return _MaxDistance; }
        }
        public decimal MinTurningRadius
        {
            set { _MinTurningRadius = value; }
            get { return _MinTurningRadius; }
        }
        public decimal PayLoad
        {
            set { _PayLoad = value; }
            get { return _PayLoad; }
        }
        public decimal MaxLoad
        {
            set { _MaxLoad = value; }
            get { return _MaxLoad; }
        }
        public decimal Base_ID
        {
            set { _Base_ID = value; }
            get { return _Base_ID; }
        }
        #endregion Model







    }
}
