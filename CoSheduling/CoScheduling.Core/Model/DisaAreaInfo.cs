//------------------------------------------------------------------------------
// 创建标识: 尹健
// 创建描述: 灾区基本信息实体类
// 创建时间:2013.11.11
// 文件版本:1.0
// 功能描述: 
// 修改标识: 
// 修改描述: 
//------------------------------------------------------------------------------

using System;

namespace CoScheduling.Core.Model
{
    /// <summary>
    /// 实体类 DisaAreaInfo
    /// </summary>
    [Serializable]
    public class DisaAreaInfo
    {
        public DisaAreaInfo()
        { }

        /// <summary>
        /// 构造函数 DisaAreaInfo
        /// </summary>
        /// <param name="iD">ID</param>
        /// <param name="name">灾区名</param>
        /// <param name="startTime">发生时间</param>
        /// <param name="lON">经度</param>
        /// <param name="lAT">纬度</param>
        /// <param name="province">所属省份</param>
        /// <param name="county">县市</param>
        /// <param name="descripe">地震等级</param>
        /// <param name="Seismic">地震烈度</param>
        /// <param name="Angle">椭球走向</param>
        /// <param name="MBR">椭球MBR</param>
        /// <param name="PolygonString">烈度字符串</param>
        public DisaAreaInfo(int iD, string name, DateTime startTime, double lON, double lAT, string province, string county, double descripe, double seismic, double angle, string mBR, string polygonString, string generateWay)
        {
            _iD = iD;
            _name = name;
            _startTime = startTime;
            _lON = lON;
            _lAT = lAT;
            _province = province;
            _county = county;
            _descripe = descripe;
            _seismic = seismic;
            _angle = angle;
            _mBR = mBR;
            _polygonString = polygonString;
            _generateWay = generateWay;
        }

        #region Model
        private int _iD;
        private string _name;
        private DateTime _startTime;
        private double _lON;
        private double _lAT;
        private string _province;
        private string _county;
        private double _descripe;
        private double _seismic;
        private double _angle;
        private string _mBR;
        private string _polygonString;
        private string _generateWay;
        /// <summary>
        /// ID
        /// </summary>
        public int ID
        {
            set { _iD = value; }
            get { return _iD; }
        }
        /// <summary>
        /// 灾区名
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }

        /// <summary>
        /// 发生时间
        /// </summary>
        public DateTime StartTime
        {
            set { _startTime = value; }
            get { return _startTime; }
        }

        /// <summary>
        /// 地震烈度
        /// </summary>
        public double Seismic
        {
            set { _seismic = value; }
            get { return _seismic; }
        }

        /// <summary>
        /// 经度
        /// </summary>
        public double LON
        {
            set { _lON = value; }
            get { return _lON; }
        }
        /// <summary>
        /// 纬度
        /// </summary>
        public double LAT
        {
            set { _lAT = value; }
            get { return _lAT; }
        }
        /// <summary>
        /// 所属省份
        /// </summary>
        public string Province
        {
            set { _province = value; }
            get { return _province; }
        }
        /// <summary>
        /// 县市
        /// </summary>
        public string County
        {
            set { _county = value; }
            get { return _county; }
        }

        /// <summary>
        /// 转向角
        /// </summary>
        public double Angle
        {
            set { _angle = value; }
            get { return _angle; }
        }
        /// <summary>
        /// 地震等级
        /// </summary>
        public double Descripe
        {
            set { _descripe = value; }
            get { return _descripe; }
        }

        /// <summary>
        /// 椭圆外包矩形
        /// </summary>
        public string MBR
        {
            set { _mBR = value; }
            get { return _mBR; }
        }

        /// <summary>
        /// PolygonString
        /// </summary>
        public string PolygonString
        {
            set { _polygonString = value; }
            get { return _polygonString; }
        }

        /// <summary>
        /// GenerateWay
        /// </summary>
        public string GenerateWay
        {
            set { _generateWay = value; }
            get { return _generateWay; }
        }

        #endregion Model
    }
}
