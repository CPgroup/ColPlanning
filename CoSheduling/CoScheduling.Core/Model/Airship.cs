//------------------------------------------------------------------------------
// 创建标识: 刘宝举
// 创建描述: 飞艇实体类 规划相关信息
// 创建时间:2017.4.24
// 文件版本:1.0
// 功能描述: 
// 修改标识: 
// 修改描述: 
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoScheduling.Core.Model
{
    /// <summary>
    /// 实体类 AS
    /// </summary>
   public class Airship
    {
        public Airship()
        {
            //无参构造函数，可以设置成员变量的默认值
        }
        //有参构造函数
        /// <summary>
		/// 构造函数 UAV
		/// </summary>
        /// <param name="PLATFORM_ID">唯一标识</param>
        /// <param name="CruisingVelocity">巡航速度</param>
        /// <param name="Longitude">经度</param>
        ///  /// <param name="Latitude">纬度</param>
        ///   /// <param name="SwathWidth">幅宽</param>
        public Airship(decimal PLATFORM_ID, decimal CruisingVelocity, decimal Longitude, decimal Latitude, decimal SwathWidth)
		{
            _PLATFORM_ID = PLATFORM_ID;                    
            _CruisingVelocity = CruisingVelocity;
            _Longitude = Longitude;
            _Latitude = Latitude;
            _SwathWidth = SwathWidth;
		}

		#region Model
        private decimal _PLATFORM_ID;
        private decimal _CruisingVelocity;
        private decimal _Longitude;
        private decimal _Latitude;
        private decimal _SwathWidth;
	
		/// <summary>
		/// ID
		/// </summary>
        public decimal PLATFORM_ID
        {
            set { _PLATFORM_ID = value; }
            get { return _PLATFORM_ID; }
        }

        public decimal CruisingVelocity
        {
            set { _CruisingVelocity = value; }
            get { return _CruisingVelocity; }
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
        public decimal SwathWidth
        {
            set { _SwathWidth = value; }
            get { return _SwathWidth; }
        }
		#endregion Model
    }
}
