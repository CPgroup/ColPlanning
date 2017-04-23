//----------------------------------------------------------------------------
//创建标识：李佳霖
// 创建描述: 飞艇平台实体类
// 创建时间:2017.4.18
// 文件版本:1.0
// 功能描述:描述飞艇平台的属性信息，包括成员变量和构造函数
// 修改标识: 
// 修改描述: 
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoScheduling.Core.Model
{
    //实体类 AEROSHIP_RANGE
    public class AEROSHIP_RANGE
    {
        public AEROSHIP_RANGE()
        {
            //无参构造函数，可以设置成员变量的默认值
        }
        //有参构造函数
        public AEROSHIP_RANGE(decimal PLATFORM_ID, string PLATFORM_Name, decimal NumberOfSensor,
            decimal CruisingVelocity, decimal PitchVelocity,decimal MaxVelocity, 
            decimal MinVelocity, decimal Acceleration, decimal CruisingTime,
            decimal CruisingAltitude,decimal MaxAltitude, decimal MaxDistance,
            decimal PayLoad, decimal MaxLoad)
        {
            _PLATFORM_ID = PLATFORM_ID;
            _PLATFORM_Name = PLATFORM_Name;
            _NumberOfSensor = NumberOfSensor;
            _CruisingVelocity = CruisingVelocity;
            _PitchVelocity = PitchVelocity;
            _MaxVelocity = MaxVelocity;
            _MinVelocity = MinVelocity;
            _Acceleration = Acceleration;
            _CruisingTime = CruisingTime;
            _CruisingAltitude = CruisingAltitude;

            _MaxAltitude = MaxAltitude;
            _MaxDistance = MaxDistance;
            _PayLoad = PayLoad;
            _MaxLoad = MaxLoad;
        }




        #region Model
        private decimal _PLATFORM_ID;
        private string _PLATFORM_Name;
        private decimal _NumberOfSensor;
        private decimal _CruisingVelocity;
        private decimal _PitchVelocity;
        private decimal _MaxVelocity;
        private decimal _MinVelocity;
        private decimal _Acceleration;
        private decimal _CruisingTime;
        private decimal _CruisingAltitude;
        private decimal _MaxAltitude;
        private decimal _MaxDistance;
        private decimal _PayLoad;
        private decimal _MaxLoad;

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

        #endregion Model

    }
}
