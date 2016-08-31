//------------------------------------------------------------------------------
// 创建标识: 尹健
// 创建描述: 无人机实体类
// 创建时间:2013.11.15
// 文件版本:1.0
// 功能描述: 
// 修改标识: 
// 修改描述: 
//------------------------------------------------------------------------------

using System;

namespace CoScheduling.Core.Model
{
    /// <summary>
    /// 实体类 UAV
    /// </summary>
    [Serializable]
    public class UAVBD
    {
        public UAVBD()
        { }

        /// <summary>
        /// 构造函数 UAV
        /// </summary>
        public UAVBD(int id, int CID, string Name, double Speed, double Focus, double Chip_L, double Chip_W, double Pixel_L, double Pixel_W, double Sidelap, double Routelap, double X, double Y, int gid, double TotalTime, int TaskAreaIndex, string Provience)
        {
            _id = id;
            _Name = Name;
            _Speed = Speed;
            _Focus = Focus;
            _Chip_L = Chip_L;
            _Chip_W = Chip_W;
            _Pixel_L = Pixel_L;
            _Pixel_W = Pixel_W;
            _Sidelap = Sidelap;
            _Routelap = Routelap;
            _X = X;
            _Y = Y;
            _GID = gid;
            _TotalTime = TotalTime;
            _TaskAreaIndex = TaskAreaIndex;
            _CID = CID;
            _provience = Provience;
        }

        #region Model
        private int _id;
        private int _CID;
        private string _Name;
        private double _Speed;
        private double _Focus;
        private double _Chip_L;
        private double _Chip_W;
        private double _Pixel_L;
        private double _Pixel_W;
        private double _Sidelap;
        private double _Routelap;
        private double _X;
        private double _Y;
        private int _GID;
        private double _TotalTime;
        private int _TaskAreaIndex;
        private string _provience;

        /// <summary>
        /// Provience
        /// </summary>
        public string Province
        {
            set { _provience = value; }
            get { return _provience; }
        }

        /// <summary>
        /// ID
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 所属单位
        /// </summary>
        public int CID
        {
            set { _CID = value; }
            get { return _CID; }
        }
        /// <summary>
        /// 无人机编队名称
        /// </summary>
        public string Name
        {
            set { _Name = value; }
            get { return _Name; }
        }
        /// <summary>
        /// 巡航速度
        /// </summary>
        public double Speed
        {
            set { _Speed = value; }
            get { return _Speed; }
        }
        /// <summary>
        /// 焦距
        /// </summary>
        public double Focus
        {
            set { _Focus = value; }
            get { return _Focus; }
        }
        /// <summary>
        /// 芯片长
        /// </summary>
        public double Chip_L
        {
            set { _Chip_L = value; }
            get { return _Chip_L; }
        }
        /// <summary>
        /// 芯片宽
        /// </summary>
        public double Chip_W
        {
            set { _Chip_W = value; }
            get { return _Chip_W; }
        }
        /// <summary>
        /// 底片纵向像素
        /// </summary>
        public double Pixel_L
        {
            set { _Pixel_L = value; }
            get { return _Pixel_L; }
        }
        /// <summary>
        /// 底片横向像素
        /// </summary>
        public double Pixel_W
        {
            set { _Pixel_W = value; }
            get { return _Pixel_W; }
        }
        /// <summary>
        /// 旁向重叠
        /// </summary>
        public double Sidelap
        {
            set { _Sidelap = value; }
            get { return _Sidelap; }
        }
        /// <summary>
        /// 航向重叠
        /// </summary>
        public double Routelap
        {
            set { _Routelap = value; }
            get { return _Routelap; }
        }
        /// <summary>
        /// X坐标
        /// </summary>
        public double X
        {
            set { _X = value; }
            get { return _X; }
        }
        /// <summary>
        /// Y坐标
        /// </summary>
        public double Y
        {
            set { _Y = value; }
            get { return _Y; }
        }
        /// <summary>
        /// 集结点ID
        /// </summary>
        public int GID
        {
            set { _GID = value; }
            get { return _GID; }
        }

        /// <summary>
        /// 总任务计时
        /// </summary>
        public double TotalTime
        {
            set { _TotalTime = value; }
            get { return _TotalTime; }
        }

        /// <summary>
        /// 当前所在的任务区索引
        /// </summary>
        public int TaskAreaIndex
        {
            set { _TaskAreaIndex = value; }
            get { return _TaskAreaIndex; }
        }
        #endregion Model
    }
}
