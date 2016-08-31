//------------------------------------------------------------------------------
// 创建标识: 尹健
// 创建描述: 单位实体类
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
	/// 实体类 Company
	/// </summary>
	[Serializable]
    public class Company
    {
        public Company()
        { }

        /// <summary>
        /// 构造函数 Company
        /// </summary>
        /// <param name="iD">ID</param>
        /// <param name="name">单位名称</param>
        /// <param name="location">单位地址</param>
        /// <param name="lAT">经度</param>
        /// <param name="lON">纬度</param>
        /// <param name="uAVNum">无人机数量</param>
        /// <param name="linkPhone">联系电话</param>
        /// <param name="linker">联系人</param>
        /// <param name="webSite">单位网站</param>
        /// <param name="buffer">缓冲区</param>
        public Company(int iD, string name, string location, double lAT, double lON, int uAVNum, string linkPhone, string linker, string webSite, string buffer)
        {
            _iD = iD;
            _name = name;
            _location = location;
            _lAT = lAT;
            _lON = lON;
            _uAVNum = uAVNum;
            _linkPhone = linkPhone;
            _linker = linker;
            _webSite = webSite;
            _buffer = buffer;
        }

        #region Model
        private int _iD;
        private string _name;
        private string _location;
        private double _lAT;
        private double _lON;
        private int _uAVNum;
        private string _linkPhone;
        private string _linker;
        private string _webSite;
        private string _buffer;
        /// <summary>
        /// ID
        /// </summary>
        public int ID
        {
            set { _iD = value; }
            get { return _iD; }
        }
        /// <summary>
        /// 单位名称
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// Location
        /// </summary>
        public string Location
        {
            set { _location = value; }
            get { return _location; }
        }
        /// <summary>
        /// 经度
        /// </summary>
        public double LAT
        {
            set { _lAT = value; }
            get { return _lAT; }
        }
        /// <summary>
        /// 纬度
        /// </summary>
        public double LON
        {
            set { _lON = value; }
            get { return _lON; }
        }
        /// <summary>
        /// 无人机数量
        /// </summary>
        public int UAVNum
        {
            set { _uAVNum = value; }
            get { return _uAVNum; }
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string LinkPhone
        {
            set { _linkPhone = value; }
            get { return _linkPhone; }
        }
        /// <summary>
        /// 联系人
        /// </summary>
        public string Linker
        {
            set { _linker = value; }
            get { return _linker; }
        }
        /// <summary>
        /// WebSite
        /// </summary>
        public string WebSite
        {
            set { _webSite = value; }
            get { return _webSite; }
        }
        /// <summary>
        /// Buffer
        /// </summary>
        public string Buffer
        {
            set { _buffer = value; }
            get { return _buffer; }
        }
        #endregion Model
    }
}
