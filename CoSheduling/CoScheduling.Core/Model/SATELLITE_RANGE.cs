//----------------------------------------------------------------------------
//创建标识：李佳霖
// 创建描述: 卫星平台实体类
// 创建时间:2017.4.6
// 文件版本:1.0
// 功能描述:描述卫星平台的属性信息，包括成员变量和构造函数
// 修改标识: 
// 修改描述: 
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoScheduling.Core.Model
{
    //实体类 SATELLITE_RANGE
    public class SATELLITE_RANGE
    {
        public SATELLITE_RANGE()
        {
            //无参构造函数，可以设置成员变量的默认值
        }
        //有参构造函数
        public SATELLITE_RANGE(decimal PLATFORM_ID, string PLATFORM_NAME, decimal NumberOfSensor,
            DateTime LaunchTime, DateTime EolTime, string OrbitClass, string OrbitType, decimal LongitudeOfGEO,
            decimal Epoch, decimal Period, decimal Apogee, decimal Perigee,
            decimal Inclination, decimal RightAscension, decimal Eccentricity,
            decimal ArgumentOfPericenter, decimal MeanAnomaly, decimal MeanMotion,
            decimal RevolutionNumber, decimal MaxSlewAngle, decimal MinSlewAngle,
            decimal AngularVelocity, decimal AngularAcceleration, decimal MAXGSD,
            decimal MAXSW, string SAT_COSPAR, string SAT_COUNTRY, decimal SAT_CHARTER)
        {
            _PLATFORM_ID=PLATFORM_ID;
            _PLATFORM_NAME=PLATFORM_NAME;
            _NumberOfSensor = NumberOfSensor;
            _LaunchTime = LaunchTime;
            _EolTime = EolTime;
            _OrbitClass = OrbitClass;
            _OrbitType = OrbitType;
            _LongitudeOfGEO = LongitudeOfGEO;
            _Epoch = Epoch;
            _Period = Period;

            _Apogee = Apogee;
            _Perigee = Perigee;
            _Inclination = Inclination;
            _RightAscension = RightAscension;
            _Eccentricity = Eccentricity;
            _ArgumentOfPericenter = ArgumentOfPericenter;
            _MeanAnomaly = MeanAnomaly;
            _MeanMotion = MeanMotion;
            _RevolutionNumber = RevolutionNumber;
            _MaxSlewAngle = MaxSlewAngle;
            _MinSlewAngle = MinSlewAngle;
            _AngularVelocity = AngularVelocity;
            _AngularAcceleration = AngularAcceleration;
            _MAXGSD = MAXGSD;
            _MAXSW = MAXSW;
            _SAT_COSPAR = SAT_COSPAR;
            _SAT_COUNTRY = SAT_COUNTRY;
            _SAT_CHARTER = SAT_CHARTER;
        }

        #region Model
        private decimal _PLATFORM_ID;
        private string _PLATFORM_NAME;
        private decimal _NumberOfSensor;
        private DateTime _LaunchTime;
        private DateTime _EolTime;
        private string _OrbitClass;
        private string _OrbitType;
        private decimal _LongitudeOfGEO;
        private decimal _Epoch;
        private decimal _Period;

        private decimal _Apogee;
        private decimal _Perigee;
        private decimal _Inclination;
        private decimal _RightAscension;
        private decimal _Eccentricity;
        private decimal _ArgumentOfPericenter;
        private decimal _MeanAnomaly;
        private decimal _MeanMotion;
        private decimal _RevolutionNumber;
        private decimal _MaxSlewAngle;
        private decimal _MinSlewAngle;
        private decimal _AngularVelocity;
        private decimal _AngularAcceleration;
        private decimal _MAXGSD;
        private decimal _MAXSW;
        private string _SAT_COSPAR;
        
        private string _SAT_COUNTRY;
        private decimal _SAT_CHARTER;

        public decimal PLATFORM_ID
        {
            set { _PLATFORM_ID = value; }
            get { return _PLATFORM_ID; }
        }
        public string PLATFORM_NAME
        {
            set { _PLATFORM_NAME = value; }
            get { return _PLATFORM_NAME; }
        }
        public decimal NumberOfSensor
        {
            set { _NumberOfSensor = value; }
            get { return _NumberOfSensor; }
        }
        public DateTime LaunchTime
        {
            set { _LaunchTime = value; }
            get { return _LaunchTime; }
        }
        public DateTime EolTime
        {
            set { _EolTime = value; }
            get { return _EolTime; }
        }
        public string OrbitClass
        {
            set { _OrbitClass = value; }
            get { return _OrbitClass; }
        }
        public string OrbitType
        {
            set { _OrbitType = value; }
            get { return _OrbitType; }
        }
        public decimal LongitudeOfGEO
        {
            set { _LongitudeOfGEO = value; }
            get { return _LongitudeOfGEO; }
        }
        public decimal Epoch
        {
            set { _Epoch = value; }
            get { return _Epoch; }
        }
        public decimal Period
        {
            set { _Period = value; }
            get { return _Period; }
        }
        public decimal Apogee
        {
            set { _Apogee = value; }
            get { return _Apogee; }
        }
        public decimal Perigee
        {
            set { _Perigee = value; }
            get { return _Perigee; }
        }
        public decimal Inclination
        {
            set { _Inclination = value; }
            get { return _Inclination; }
        }
        public decimal RightAscension
        {
            set { _RightAscension = value; }
            get { return _RightAscension; }
        }
        public decimal Eccentricity
        {
            set { _Eccentricity = value; }
            get { return _Eccentricity; }
        }
        public decimal ArgumentOfPericenter
        {
            set { _ArgumentOfPericenter = value; }
            get { return _ArgumentOfPericenter; }
        }
        public decimal MeanAnomaly
        {
            set { _MeanAnomaly = value; }
            get { return _MeanAnomaly; }
        }
        public decimal MeanMotion
        {
            set { _MeanMotion = value; }
            get { return _MeanMotion; }
        }

        public decimal RevolutionNumber
        {
            set { _RevolutionNumber = value; }
            get { return _RevolutionNumber; }
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
        public decimal AngularVelocity
        {
            set { _AngularVelocity = value; }
            get { return _AngularVelocity; }
        }
        public decimal AngularAcceleration
        {
            set { _AngularAcceleration = value; }
            get { return _AngularAcceleration; }
        }
        public decimal MAXGSD
        {
            set { _MAXGSD = value; }
            get { return _MAXGSD; }
        }
        public decimal MAXSW
        {
            set { _MAXSW = value; }
            get { return _MAXSW; }
        }
        public string SAT_COSPAR
        {
            set { _SAT_COSPAR = value; }
            get { return _SAT_COSPAR; }
        }
        //public string SAT_COUNTRY
        //{
        //    set { _SAT_COUNTRY = value; }
        //    get { return _SAT_COUNTRY; }
        //}
        public string SAT_COUNTRY
        {
            set { _SAT_COUNTRY = value; }
            get { return _SAT_COUNTRY; }
        }
        public decimal SAT_CHARTER
        {
            set { _SAT_CHARTER = value; }
            get { return _SAT_CHARTER; }
        }
        #endregion Model

    }

}
