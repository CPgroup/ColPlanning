//----------------------------------------------------------------------------
//创建标识：李佳霖
// 创建描述: 第二类传感器实体类（地面摄像头、志愿者）
// 创建时间:2017.4.18
// 文件版本:1.0
// 功能描述:第二类传感器的实体类，描述传感器的各项属性，包括成员变量和构造函数
// 修改标识: 
// 修改描述: 
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoScheduling.Core.Model
{
    //实体类 SENSOR_2

    public class SENSOR_2
    {
        public SENSOR_2()
        {
            //无参构造函数，可以设置成员变量的默认值
        }
        //有参构造函数
        public SENSOR_2(decimal SensorID, string SensorName,decimal PLATFORM_ID,
            string SensorType,string Application,decimal Pixel,decimal Resolution,
            decimal HorizontalResolution,decimal MinIllumination, decimal LookAngle,
            decimal SquintAngle,decimal MaxDistance,decimal Aperture,decimal FocalLength,
            decimal MAXGSD)
         {
             _SensorID = SensorID;
             _SensorName = SensorName;
             _PLATFORM_ID = PLATFORM_ID;
             _SensorType = SensorType;
             _Application = Application;
             _Pixel = Pixel;
             _Resolution = Resolution;
             _HorizontalResolution = HorizontalResolution;
             _MinIllumination = MinIllumination;
             _LookAngle = LookAngle;
             _SquintAngle = SquintAngle;
             _MaxDistance = MaxDistance;
             _Aperture = Aperture;
             _FocalLength = FocalLength;
             _MAXGSD = MAXGSD;
         }


        #region Model
        
        private decimal _SensorID;
        private string _SensorName;
        private decimal _PLATFORM_ID;
        private string _SensorType;
        private string _Application;
        private decimal _Pixel;
        private decimal _Resolution;
        private decimal _HorizontalResolution;
        private decimal _MinIllumination;
        private decimal _LookAngle;
        private decimal _SquintAngle;
        private decimal _MaxDistance;
        private decimal _Aperture;
        private decimal _FocalLength;
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
        public decimal PLATFORM_ID
        {
            set { _PLATFORM_ID = value; }
            get { return _PLATFORM_ID; }
        }
        public string SensorType
        {
            set { _SensorType = value; }
            get { return _SensorType; }
        }
        public string Application
        {
            set { _Application = value; }
            get { return _Application; }
        }
        public decimal Pixel
        {
            set { _Pixel = value; }
            get { return _Pixel; }
        }
        public decimal Resolution
        {
            set { _Resolution = value; }
            get { return _Resolution; }
        }
        public decimal HorizontalResolution
        {
            set { _HorizontalResolution = value; }
            get { return _HorizontalResolution; }
        }
        public decimal MinIllumination
        {
            set { _MinIllumination = value; }
            get { return _MinIllumination; }
        }
        public decimal LookAngle
        {
            set { _LookAngle = value; }
            get { return _LookAngle; }
        }
        public decimal SquintAngle
        {
            set { _SquintAngle = value; }
            get { return _SquintAngle; }
        }
        public decimal MaxDistance
        {
            set { _MaxDistance = value; }
            get { return _MaxDistance; }
        }
        public decimal Aperture
        {
            set { _Aperture = value; }
            get { return _Aperture; }
        }
        public decimal FocalLength
        {
            set { _FocalLength = value; }
            get { return _FocalLength; }
        }
        public decimal MAXGSD
        {
            set { _MAXGSD = value; }
            get { return _MAXGSD; }
        }
        #endregion

    }
}
