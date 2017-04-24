//----------------------------------------------------------------------------
//创建标识：李佳霖
// 创建描述: 志愿者平台实体类
// 创建时间:2017.4.18
// 文件版本:1.0
// 功能描述:描述志愿者平台的属性信息，包括成员变量和构造函数
// 修改标识: 
// 修改描述: 
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoScheduling.Core.Model
{
    //实体类 HUMANDETECTION_RANGE
    public class HUMANDETECTION_RANGE
    {
        public HUMANDETECTION_RANGE()
        {
            //无参构造函数，可以设置成员变量的默认值
        }

        public HUMANDETECTION_RANGE(decimal PLATFORM_ID, string PLATFORM_Name, 
            decimal NumberOfSensor,decimal MaxCruisingTime)
        {
            _PLATFORM_ID = PLATFORM_ID;
            _PLATFORM_Name = PLATFORM_Name;
            _NumberOfSensor = NumberOfSensor;
            _MaxCruisingTime = MaxCruisingTime;
        }

        #region Model
        private decimal _PLATFORM_ID;
        private string _PLATFORM_Name;
        private decimal _NumberOfSensor;
        private decimal _MaxCruisingTime;

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
        public decimal MaxCruisingTime
        {
            set { _MaxCruisingTime = value; }
            get { return _MaxCruisingTime; }
        }
        #endregion
    }
}
