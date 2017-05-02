//------------------------------------------------------------------------------
// 创建标识: 刘宝举
// 创建描述: 地面测量车实体类 规划相关信息
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
   public class ILLUSTRATEDCAR
    {
         public ILLUSTRATEDCAR()
        {
            //无参构造函数，可以设置成员变量的默认值
        }
        //有参构造函数
        /// <summary>
		/// 构造函数 
		/// </summary>
        /// <param name="PLATFORM_ID">唯一标识</param>
        /// <param name="CruisingVelocity">巡航速度</param>
        /// <param name="Longitude">经度</param>
        ///  /// <param name="Latitude">纬度</param>
        ///   /// <param name="SwathWidth">幅宽</param>
        ///   voyage 续航里程
         ///   ObserveVelocity 观测任务时的速度
         public ILLUSTRATEDCAR(decimal PLATFORM_ID, decimal CruisingVelocity, decimal Longitude, decimal Latitude, decimal SwathWidth, decimal Voyage, decimal ObserveVelocity)
		{
            _PLATFORM_ID = PLATFORM_ID;                    
            _CruisingVelocity = CruisingVelocity;
            _Longitude = Longitude;
            _Latitude = Latitude;
            _SwathWidth = SwathWidth;
            _Voyage = Voyage;
            _ObserveVelocity = ObserveVelocity;
		}

        
		#region Model
        private decimal _PLATFORM_ID;
        private decimal _CruisingVelocity;
        private decimal _Longitude;
        private decimal _Latitude;
        private decimal _SwathWidth;
        private decimal _Voyage;
        private decimal _ObserveVelocity;
	
		/// <summary>
		/// ID
		/// </summary>
        public decimal PLATFORM_ID
        {
            set { _PLATFORM_ID = value; }
            get { return _PLATFORM_ID; }
        }
        public decimal Voyage
        {
            set { _Voyage = value; }
            get { return _Voyage; }
        }
        public decimal ObserveVelocity
        {
            set { _ObserveVelocity = value; }
            get { return _ObserveVelocity; }
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
