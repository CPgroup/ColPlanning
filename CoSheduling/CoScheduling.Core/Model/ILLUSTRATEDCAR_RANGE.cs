//----------------------------------------------------------------------------
//创建标识：李佳霖
// 创建描述: 地面测量车平台实体类
// 创建时间:2017.4.18
// 文件版本:1.0
// 功能描述:描述地面测量车平台的属性信息，包括成员变量和构造函数
// 修改标识: 
// 修改描述: 
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoScheduling.Core.Model
{
    //实体类 ILLUSTRATEDCAR_RANGE
    public class ILLUSTRATEDCAR_RANGE
    {
        public ILLUSTRATEDCAR_RANGE()
        {
            //无参构造函数，可以设置成员变量的默认值
        }
        public ILLUSTRATEDCAR_RANGE(decimal PLATFORM_ID, string PLATFORM_Name, decimal NumberOfSensor,
            decimal MaxVelocity, decimal Acceleration, decimal MaxDistance, decimal ApproachAngle,
            decimal DepartureAngle, decimal MinimumGroundClearance, decimal WheelBase,
            decimal AzimuthAngle, decimal AzimuthAngleVelocity, decimal AzimuthAngleAcceleration,
            decimal PitchAngle, decimal PitchAngleVelocity, decimal PitchAngleAcceleration,
            decimal PolarizationAngle, decimal PolarizationAngleVelocity,
            decimal PolarizationAngleAcceleration)
        {
            _PLATFORM_ID = PLATFORM_ID;
            _PLATFORM_Name = PLATFORM_Name;
            _NumberOfSensor = NumberOfSensor;
            _MaxVelocity = MaxVelocity;
            _Acceleration = Acceleration;
            _MaxDistance = MaxDistance;
            _ApproachAngle = ApproachAngle;
            _DepartureAngle = DepartureAngle;
            _MinimumGroundClearance = MinimumGroundClearance;
            _WheelBase = WheelBase;

            _AzimuthAngle = AzimuthAngle;
            _AzimuthAngleVelocity = AzimuthAngleVelocity;
            _AzimuthAngleAcceleration = AzimuthAngleAcceleration;
            _PitchAngle = PitchAngle;
            _PitchAngleVelocity = PitchAngleVelocity;
            _PitchAngleAcceleration = PitchAngleAcceleration;
            _PolarizationAngle = PolarizationAngle;
            _PolarizationAngleVelocity = PolarizationAngleVelocity;
            _PolarizationAngleAcceleration = PolarizationAngleAcceleration;
        }



        #region Model
        private decimal _PLATFORM_ID;
        private string _PLATFORM_Name;
        private decimal _NumberOfSensor;
        private decimal _MaxVelocity;
        private decimal _Acceleration;
        private decimal _MaxDistance;
        private decimal _ApproachAngle;
        private decimal _DepartureAngle;
        private decimal _MinimumGroundClearance;
        private decimal _WheelBase;

        private decimal _AzimuthAngle;
        private decimal _AzimuthAngleVelocity;
        private decimal _AzimuthAngleAcceleration;
        private decimal _PitchAngle;
        private decimal _PitchAngleVelocity;
        private decimal _PitchAngleAcceleration;
        private decimal _PolarizationAngle;
        private decimal _PolarizationAngleVelocity;
        private decimal _PolarizationAngleAcceleration;


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
        public decimal MaxVelocity
        {
            set { _MaxVelocity = value; }
            get { return _MaxVelocity; }
        }
        public decimal Acceleration
        {
            set { _Acceleration = value; }
            get { return _Acceleration; }
        }
        public decimal MaxDistance
        {
            set { _MaxDistance = value; }
            get { return _MaxDistance; }
        }
        public decimal ApproachAngle
        {
            set { _ApproachAngle = value; }
            get { return _ApproachAngle; }
        }
        public decimal DepartureAngle
        {
            set { _DepartureAngle = value; }
            get { return _DepartureAngle; }
        }
        public decimal MinimumGroundClearance
        {
            set { _MinimumGroundClearance = value; }
            get { return _MinimumGroundClearance; }
        }
        public decimal WheelBase
        {
            set { _WheelBase = value; }
            get { return _WheelBase; }
        }
        public decimal AzimuthAngle
        {
            set { _AzimuthAngle = value; }
            get { return _AzimuthAngle; }
        }
        public decimal AzimuthAngleVelocity
        {
            set { _AzimuthAngleVelocity = value; }
            get { return _AzimuthAngleVelocity; }
        }
        public decimal AzimuthAngleAcceleration
        {
            set { _AzimuthAngleAcceleration = value; }
            get { return _AzimuthAngleAcceleration; }
        }
        public decimal PitchAngle
        {
            set { _PitchAngle = value; }
            get { return _PitchAngle; }
        }
        public decimal PitchAngleVelocity
        {
            set { _PitchAngleVelocity = value; }
            get { return _PitchAngleVelocity; }
        }
        public decimal PitchAngleAcceleration
        {
            set { _PitchAngleAcceleration = value; }
            get { return _PitchAngleAcceleration; }
        }
        public decimal PolarizationAngle
        {
            set { _PolarizationAngle = value; }
            get { return _PolarizationAngle; }
        }
        public decimal PolarizationAngleVelocity
        {
            set { _PolarizationAngleVelocity = value; }
            get { return _PolarizationAngleVelocity; }
        }
        public decimal PolarizationAngleAcceleration
        {
            set { _PolarizationAngleAcceleration = value; }
            get { return _PolarizationAngleAcceleration; }
        }
        #endregion

    }
}
