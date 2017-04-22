//----------------------------------------------------------------------------
//创建标识：李佳霖
// 创建描述: 传感器匹配结果实体类
// 创建时间:2017.3.29
// 文件版本:1.0
// 功能描述:传感器匹配结果的实体类，主要成员变量为任务ID，传感器ID和平台ID
// 修改标识: 
// 修改描述: 
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoScheduling.Core.Model
{
    //实体类 SensorsMatched
    public class SensorsMatched
    {
        public SensorsMatched()
        {
            //无参构造函数，可以设置成员变量的默认值
            _MatchingTime = DateTime.Now;
        }
        //有参构造函数
        public SensorsMatched(decimal TaskID,decimal SensorID,decimal PLATFORM_ID,DateTime MatchingTime)
        {
            _TaskID = TaskID;
            _SensorID = SensorID;
            _PLATFORM_ID = PLATFORM_ID;
            _MatchingTime = MatchingTime;
        }

        #region Model
        private decimal _TaskID;
        private decimal _SensorID;
        private decimal _PLATFORM_ID;
        private DateTime _MatchingTime;

        //定义各成员变量的赋值和获取值的函数
        public decimal TaskID
        {
            set { _TaskID = value; }
            get { return _TaskID; }
        }
        public decimal SensorID
        {
            set { _SensorID = value; }
            get { return _SensorID; }
        }
        public decimal PLATFORM_ID
        {
            set { _PLATFORM_ID = value; }
            get { return _PLATFORM_ID; }
        }
        public DateTime MatchingTime
        {
            set { _MatchingTime = value; }
            get {return _MatchingTime; }
        }
        #endregion Model
    }
    
}
