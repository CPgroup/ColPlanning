//----------------------------------------------------------------------------
//创建标识：李佳霖
// 创建描述: 地面摄像头平台实体类
// 创建时间:2017.4.18
// 文件版本:1.0
// 功能描述:描述地面摄像头平台的属性信息，包括成员变量和构造函数
// 修改标识: 
// 修改描述: 
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoScheduling.Core.Model
{
    //实体类 SPYCAM_RANGE
    public class SPYCAM_RANGE
    {
        public SPYCAM_RANGE()
        {
            //无参构造函数，可以设置成员变量的默认值
        }
        public SPYCAM_RANGE(decimal PLATFORM_ID, string PLATFORM_Name, decimal NumberOfSensor,
            decimal HorizontalRotationAngle, decimal VerticalRotationAngle)
        {
            _PLATFORM_ID = PLATFORM_ID;
            _PLATFORM_Name = PLATFORM_Name;
            _NumberOfSensor = NumberOfSensor;
            _HorizontalRotationAngle = HorizontalRotationAngle;
            _VerticalRotationAngle = VerticalRotationAngle;
        }

        #region Model
        private decimal _PLATFORM_ID;
        private string _PLATFORM_Name;
        private decimal _NumberOfSensor;
        private decimal _HorizontalRotationAngle;
        private decimal _VerticalRotationAngle;

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
        public decimal HorizontalRotationAngle
        {
            set { _HorizontalRotationAngle = value; }
            get { return _HorizontalRotationAngle; }
        }
        public decimal VerticalRotationAngle
        {
            set { _VerticalRotationAngle = value; }
            get { return _VerticalRotationAngle; }
        }
        #endregion


    }
}
