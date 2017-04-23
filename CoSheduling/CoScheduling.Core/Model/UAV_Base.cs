//----------------------------------------------------------------------------
//创建标识：李佳霖
// 创建描述: 无人机基站实体类
// 创建时间:2017.3.31
// 文件版本:1.0
// 功能描述:描述无人机基站的属性信息，包括成员变量和构造函数
// 修改标识: 
// 修改描述: 
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoScheduling.Core.Model
{
    //实体类 UAV_Base
    public class UAV_Base
    {

        public UAV_Base()
        {
            //无参构造函数，可以设置成员变量的默认值
        }

        //有参构造函数
        public UAV_Base(decimal Base_ID, string Base_Name, decimal NumberOfUAV,
            decimal BaseLongitude, decimal BaseLatitude, decimal MTOL,
            decimal MTOW, decimal Slope, string PavementType)
        {
            _Base_ID = Base_ID;
            _Base_Name = Base_Name;
            _NumberOfUAV = NumberOfUAV;
            _BaseLongitude = BaseLongitude;
            _BaseLatitude = BaseLatitude;
            _MTOL = MTOL;
            _MTOW = MTOW;
            _Slope = Slope;
            _PavementType = PavementType;
        }

        #region Model
        private decimal _Base_ID;
        private string _Base_Name;
        private decimal _NumberOfUAV;
        private decimal _BaseLongitude;
        private decimal _BaseLatitude;
        private decimal _MTOL;
        private decimal _MTOW;
        private decimal _Slope;
        private string _PavementType;

        //定义各个成员变量的赋值和获取值的函数
        public decimal Base_ID
        {
            set { _Base_ID = value; }
            get { return _Base_ID; }
        }
        public string Base_Name
        {
            set { _Base_Name = value; }
            get { return _Base_Name; }
        }
        public decimal NumberOfUAV
        {
            set { _NumberOfUAV = value; }
            get { return _NumberOfUAV; }
        }
        public decimal BaseLongitude
        {
            set { _BaseLongitude = value; }
            get { return _BaseLongitude; }
        }
        public decimal BaseLatitude
        {
            set { _BaseLatitude = value; }
            get { return _BaseLatitude; }
        }
        public decimal MTOL
        {
            set { _MTOL = value; }
            get { return _MTOL; }
        }
        public decimal MTOW
        {
            set { _MTOW = value; }
            get { return _MTOW; }
        }
        public decimal Slope
        {
            set { _Slope = value; }
            get { return _Slope; }
        }
        public string PavementType
        {
            set { _PavementType = value; }
            get { return _PavementType; }
        }
        #endregion Model


    }
}
