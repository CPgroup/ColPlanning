//----------------------------------------------------------------------------
//创建标识：李佳霖
// 创建描述: 传感器波段实体类（精细到可见光、近红外）
// 创建时间:2017.4.4
// 文件版本:1.0
// 功能描述:传感器波段的实体类，描述传感器波段的各项属性，包括成员变量和构造函数
// 修改标识: 
// 修改描述: 
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoScheduling.Core.Model
{

    public class Sensor_Band_Mode
    {
        public Sensor_Band_Mode()
        {
            //无参构造函数，可以设置成员变量的默认值
        }
        //有参构造函数
        public Sensor_Band_Mode(decimal BandID,string BAND_MODE_NAME,string BandType,
            decimal SensorID, string SensorName, decimal PLATFORM_ID, string PLATFORM_NAME,
            decimal SwathWidth, decimal BandWidth, decimal BandCenter, decimal SpectralRangeMin,
            decimal SpectralRangeMax, string PolarizationMode, decimal SNRRatio,
            decimal PixelPerLine)
        {

            _BandID = BandID;
            _BAND_MODE_NAME = BAND_MODE_NAME;
            _BandType = BandType;
            _SensorID = SensorID;
            _SensorName = SensorName;
            _PLATFORM_ID = PLATFORM_ID;
            _PLATFORM_NAME = PLATFORM_NAME;

            _SwathWidth = SwathWidth;
            _BandWidth = BandWidth;
            _BandCenter = BandCenter;
            _SpectralRangeMin = SpectralRangeMin;
            _SpectralRangeMax = SpectralRangeMax;
            _PolarizationMode = PolarizationMode;
            _SNRRatio = SNRRatio;
            _PixelPerLine = PixelPerLine;

        }

        #region Model
        private decimal _BandID;
        private string _BAND_MODE_NAME;
        private string _BandType;
        private decimal _SensorID;
        private string _SensorName;
        private decimal _PLATFORM_ID;
        private string _PLATFORM_NAME;

        private decimal _SwathWidth;
        private decimal _BandWidth;
        private decimal _BandCenter;
        private decimal _SpectralRangeMin;
        private decimal _SpectralRangeMax;
        private string _PolarizationMode;
        private decimal _SNRRatio;
        private decimal _PixelPerLine;


        //定义各成员变量的赋值和获取值的函数
        public decimal BandID
        {
            set { _BandID = value; }
            get { return _BandID; }
        }
        public string BAND_MODE_NAME
        {
            set { _BAND_MODE_NAME = value; }
            get { return _BAND_MODE_NAME; }
        }
        public string BandType
        {
            set { _BandType = value; }
            get { return _BandType; }
        }
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
        public string PLATFORM_NAME
        {
            set { _PLATFORM_NAME = value; }
            get { return _PLATFORM_NAME; }
        }
        public decimal SwathWidth
        {
            set { _SwathWidth = value; }
            get { return _SwathWidth; }
        }
        public decimal BandWidth
        {
            set { _BandWidth = value; }
            get { return _BandWidth; }
        }
        public decimal BandCenter
        {
            set { _BandCenter = value; }
            get { return _BandCenter; }
        }
        public decimal SpectralRangeMin
        {
            set { _SpectralRangeMin = value; }
            get { return _SpectralRangeMin; }
        }
        public decimal SpectralRangeMax
        {
            set { _SpectralRangeMax = value; }
            get { return _SpectralRangeMax; }
        }
        public string PolarizationMode
        {
            set { _PolarizationMode = value; }
            get { return _PolarizationMode; }
        }
        public decimal SNRRatio
        {
            set { _SNRRatio = value; }
            get { return _SNRRatio; }
        }
        public decimal PixelPerLine
        {
            set { _PixelPerLine = value; }
            get { return _PixelPerLine; }
        }

        #endregion Model


    }
}
