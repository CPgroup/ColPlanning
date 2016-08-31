//------------------------------------------------------------------------------
// 创建标识: 董毅博
// 创建描述: 卫星载荷公共资源实体类
// 创建时间:2014.7.20
// 文件版本:2.0
// 功能描述: 
// 修改标识: 
// 修改描述: 
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace CoScheduling.Core.Model
{
    /// <summary>
    /// 实体类 T_PUB_SENSOR
    /// </summary>
    [Serializable]
    public class T_PUB_SENSOR
    {
        public T_PUB_SENSOR()
        { }

        /// <summary>
        /// 构造函数 T_PUB_SENSOR
        /// </summary>
        /// <param name="sENSOR_ID">SENSOR_ID</param>
        /// <param name="sENSOR_NAME">SENSOR_NAME</param>
        /// <param name="sENSOR_STKNAME">SENSOR_STKNAME</param>
        /// <param name="sAT_ID">SAT_ID</param>
        /// <param name="sAT_STKNAME">SAT_STKNAME</param>
        /// <param name="sENSOR_TYPE">SENSOR_TYPE</param>
        /// <param name="sENSOR_PARONE">SENSOR_PARONE</param>
        /// <param name="sENSOR_PARTWO">SENSOR_PARTWO</param>
        /// <param name="sENSOR_PARTHREE">SENSOR_PARTHREE</param>
        /// <param name="sENSOR_PARFOUR">SENSOR_PARFOUR</param>
        /// <param name="tYPEID">TYPEID</param>
        /// <param name="sATTYPE">SATTYPE</param>
        /// <param name="sENSORANGLE">SENSORANGLE</param>
        /// <param name="sENSORANGLEH">SENSORANGLEH</param>
        public T_PUB_SENSOR(decimal sENSOR_ID, string sENSOR_NAME, string sENSOR_STKNAME, decimal sAT_ID, string sAT_STKNAME, string sENSOR_TYPE, decimal sENSOR_PARONE, decimal sENSOR_PARTWO, decimal sENSOR_PARTHREE, decimal sENSOR_PARFOUR, decimal tYPEID, decimal sATTYPE, decimal sENSORANGLE, decimal sENSORANGLEH)
        {
            _sENSOR_ID = sENSOR_ID;
            _sENSOR_NAME = sENSOR_NAME;
            _sENSOR_STKNAME = sENSOR_STKNAME;
            _sAT_ID = sAT_ID;
            _sAT_STKNAME = sAT_STKNAME;
            _sENSOR_TYPE = sENSOR_TYPE;
            _sENSOR_PARONE = sENSOR_PARONE;
            _sENSOR_PARTWO = sENSOR_PARTWO;
            _sENSOR_PARTHREE = sENSOR_PARTHREE;
            _sENSOR_PARFOUR = sENSOR_PARFOUR;
            _tYPEID = tYPEID;
            _sATTYPE = sATTYPE;
            _sENSORANGLE = sENSORANGLE;
            _sENSORANGLEH = sENSORANGLEH;
        }

        #region Model
        private decimal _sENSOR_ID;
        private string _sENSOR_NAME;
        private string _sENSOR_STKNAME;
        private decimal _sAT_ID;
        private string _sAT_STKNAME;
        private string _sENSOR_TYPE;
        private decimal _sENSOR_PARONE;
        private decimal _sENSOR_PARTWO;
        private decimal _sENSOR_PARTHREE;
        private decimal _sENSOR_PARFOUR;
        private decimal _tYPEID;
        private decimal _sATTYPE;
        private decimal _sENSORANGLE;
        private decimal _sENSORANGLEH;
        /// <summary>
        /// SENSOR_ID
        /// </summary>
        public decimal SENSOR_ID
        {
            set { _sENSOR_ID = value; }
            get { return _sENSOR_ID; }
        }
        /// <summary>
        /// SENSOR_NAME
        /// </summary>
        public string SENSOR_NAME
        {
            set { _sENSOR_NAME = value; }
            get { return _sENSOR_NAME; }
        }
        /// <summary>
        /// SENSOR_STKNAME
        /// </summary>
        public string SENSOR_STKNAME
        {
            set { _sENSOR_STKNAME = value; }
            get { return _sENSOR_STKNAME; }
        }
        /// <summary>
        /// SAT_ID
        /// </summary>
        public decimal SAT_ID
        {
            set { _sAT_ID = value; }
            get { return _sAT_ID; }
        }
        /// <summary>
        /// SAT_STKNAME
        /// </summary>
        public string SAT_STKNAME
        {
            set { _sAT_STKNAME = value; }
            get { return _sAT_STKNAME; }
        }
        /// <summary>
        /// SENSOR_TYPE
        /// </summary>
        public string SENSOR_TYPE
        {
            set { _sENSOR_TYPE = value; }
            get { return _sENSOR_TYPE; }
        }
        /// <summary>
        /// SENSOR_PARONE
        /// </summary>
        public decimal SENSOR_PARONE
        {
            set { _sENSOR_PARONE = value; }
            get { return _sENSOR_PARONE; }
        }
        /// <summary>
        /// SENSOR_PARTWO
        /// </summary>
        public decimal SENSOR_PARTWO
        {
            set { _sENSOR_PARTWO = value; }
            get { return _sENSOR_PARTWO; }
        }
        /// <summary>
        /// SENSOR_PARTHREE
        /// </summary>
        public decimal SENSOR_PARTHREE
        {
            set { _sENSOR_PARTHREE = value; }
            get { return _sENSOR_PARTHREE; }
        }
        /// <summary>
        /// SENSOR_PARFOUR
        /// </summary>
        public decimal SENSOR_PARFOUR
        {
            set { _sENSOR_PARFOUR = value; }
            get { return _sENSOR_PARFOUR; }
        }
        /// <summary>
        /// TYPEID
        /// </summary>
        public decimal TYPEID
        {
            set { _tYPEID = value; }
            get { return _tYPEID; }
        }
        /// <summary>
        /// SATTYPE
        /// </summary>
        public decimal SATTYPE
        {
            set { _sATTYPE = value; }
            get { return _sATTYPE; }
        }
        /// <summary>
        /// SENSORANGLE
        /// </summary>
        public decimal SENSORANGLE
        {
            set { _sENSORANGLE = value; }
            get { return _sENSORANGLE; }
        }
        /// <summary>
        /// SENSORANGLEH
        /// </summary>
        public decimal SENSORANGLEH
        {
            set { _sENSORANGLEH = value; }
            get { return _sENSORANGLEH; }
        }
        #endregion Model
    }
}
