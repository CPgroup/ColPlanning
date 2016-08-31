//------------------------------------------------------------------------------
// 创建标识: 董毅博
// 创建描述: 卫星信息实体类
// 创建时间:2014.6.9
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
    /// 实体类 Satellite
    /// </summary>
    [Serializable]
    public class Satellite
    {
        public Satellite()
        { }

        /// <summary>
        /// 构造函数 Satellite
        /// </summary>
        /// <param name="sAT_ID">SAT_ID</param>
        /// <param name="sAT_COSPAR">SAT_COSPAR</param>
        /// <param name="sAT_SHORTNAME">SAT_SHORTNAME</param>
        /// <param name="sAT_LONGNAME">SAT_LONGNAME</param>
        /// <param name="sAT_FULLNAME">SAT_FULLNAME</param>
        /// <param name="sAT_ORBITCLASS">SAT_ORBITCLASS</param>
        /// <param name="sAT_ORBITTYPE">SAT_ORBITTYPE</param>
        /// <param name="sAT_LONGITUDEOFGEO">SAT_LONGITUDEOFGEO</param>
        /// <param name="sAT_APPLICATION">SAT_APPLICATION</param>
        /// <param name="sAT_COUNTRY">SAT_COUNTRY</param>
        /// <param name="sAT_USES">SAT_USES</param>
        /// <param name="sAT_AGENCIES">SAT_AGENCIES</param>
        /// <param name="sAT_DESCRIPTION">SAT_DESCRIPTION</param>
        /// <param name="sAT_DESCRIPTION2">SAT_DESCRIPTION2</param>
        /// <param name="sAT_LAUNCHTIME">SAT_LAUNCHTIME</param>
        /// <param name="sAT_EOLTIME">SAT_EOLTIME</param>
        /// <param name="sAT_REPEATCYCLE">SAT_REPEATCYCLE</param>
        /// <param name="sAT_DATAACCESS">SAT_DATAACCESS</param>
        /// <param name="sAT_CHARTER">SAT_CHARTER</param>
        /// <param name="mAXGSD">MAXGSD</param>
        /// <param name="mAXSW">MAXSW</param>
        public Satellite(decimal sAT_ID, string sAT_COSPAR, string sAT_SHORTNAME, string sAT_LONGNAME, string sAT_FULLNAME, string sAT_ORBITCLASS, string sAT_ORBITTYPE, decimal sAT_LONGITUDEOFGEO, string sAT_APPLICATION, string sAT_COUNTRY, string sAT_USES, string sAT_AGENCIES, string sAT_DESCRIPTION, string sAT_DESCRIPTION2, DateTime sAT_LAUNCHTIME, DateTime sAT_EOLTIME, decimal sAT_REPEATCYCLE, string sAT_DATAACCESS, decimal sAT_CHARTER, decimal mAXGSD, decimal mAXSW)
        {
            _sAT_ID = sAT_ID;
            _sAT_COSPAR = sAT_COSPAR;
            _sAT_SHORTNAME = sAT_SHORTNAME;
            _sAT_LONGNAME = sAT_LONGNAME;
            _sAT_FULLNAME = sAT_FULLNAME;
            _sAT_ORBITCLASS = sAT_ORBITCLASS;
            _sAT_ORBITTYPE = sAT_ORBITTYPE;
            _sAT_LONGITUDEOFGEO = sAT_LONGITUDEOFGEO;
            _sAT_APPLICATION = sAT_APPLICATION;
            _sAT_COUNTRY = sAT_COUNTRY;
            _sAT_USES = sAT_USES;
            _sAT_AGENCIES = sAT_AGENCIES;
            _sAT_DESCRIPTION = sAT_DESCRIPTION;
            _sAT_DESCRIPTION2 = sAT_DESCRIPTION2;
            _sAT_LAUNCHTIME = sAT_LAUNCHTIME;
            _sAT_EOLTIME = sAT_EOLTIME;
            _sAT_REPEATCYCLE = sAT_REPEATCYCLE;
            _sAT_DATAACCESS = sAT_DATAACCESS;
            _sAT_CHARTER = sAT_CHARTER;
            _mAXGSD = mAXGSD;
            _mAXSW = mAXSW;
        }

        #region Model
        private decimal _sAT_ID;
        private string _sAT_COSPAR;
        private string _sAT_SHORTNAME;
        private string _sAT_LONGNAME;
        private string _sAT_FULLNAME;
        private string _sAT_ORBITCLASS;
        private string _sAT_ORBITTYPE;
        private decimal _sAT_LONGITUDEOFGEO;
        private string _sAT_APPLICATION;
        private string _sAT_COUNTRY;
        private string _sAT_USES;
        private string _sAT_AGENCIES;
        private string _sAT_DESCRIPTION;
        private string _sAT_DESCRIPTION2;
        private DateTime _sAT_LAUNCHTIME;
        private DateTime _sAT_EOLTIME;
        private decimal _sAT_REPEATCYCLE;
        private string _sAT_DATAACCESS;
        private decimal _sAT_CHARTER;
        private decimal _mAXGSD;
        private decimal _mAXSW;
        /// <summary>
        /// SAT_ID
        /// </summary>
        public decimal SAT_ID
        {
            set { _sAT_ID = value; }
            get { return _sAT_ID; }
        }
        /// <summary>
        /// SAT_COSPAR
        /// </summary>
        public string SAT_COSPAR
        {
            set { _sAT_COSPAR = value; }
            get { return _sAT_COSPAR; }
        }
        /// <summary>
        /// SAT_SHORTNAME
        /// </summary>
        public string SAT_SHORTNAME
        {
            set { _sAT_SHORTNAME = value; }
            get { return _sAT_SHORTNAME; }
        }
        /// <summary>
        /// SAT_LONGNAME
        /// </summary>
        public string SAT_LONGNAME
        {
            set { _sAT_LONGNAME = value; }
            get { return _sAT_LONGNAME; }
        }
        /// <summary>
        /// SAT_FULLNAME
        /// </summary>
        public string SAT_FULLNAME
        {
            set { _sAT_FULLNAME = value; }
            get { return _sAT_FULLNAME; }
        }
        /// <summary>
        /// SAT_ORBITCLASS
        /// </summary>
        public string SAT_ORBITCLASS
        {
            set { _sAT_ORBITCLASS = value; }
            get { return _sAT_ORBITCLASS; }
        }
        /// <summary>
        /// SAT_ORBITTYPE
        /// </summary>
        public string SAT_ORBITTYPE
        {
            set { _sAT_ORBITTYPE = value; }
            get { return _sAT_ORBITTYPE; }
        }
        /// <summary>
        /// SAT_LONGITUDEOFGEO
        /// </summary>
        public decimal SAT_LONGITUDEOFGEO
        {
            set { _sAT_LONGITUDEOFGEO = value; }
            get { return _sAT_LONGITUDEOFGEO; }
        }
        /// <summary>
        /// SAT_APPLICATION
        /// </summary>
        public string SAT_APPLICATION
        {
            set { _sAT_APPLICATION = value; }
            get { return _sAT_APPLICATION; }
        }
        /// <summary>
        /// SAT_COUNTRY
        /// </summary>
        public string SAT_COUNTRY
        {
            set { _sAT_COUNTRY = value; }
            get { return _sAT_COUNTRY; }
        }
        /// <summary>
        /// SAT_USES
        /// </summary>
        public string SAT_USES
        {
            set { _sAT_USES = value; }
            get { return _sAT_USES; }
        }
        /// <summary>
        /// SAT_AGENCIES
        /// </summary>
        public string SAT_AGENCIES
        {
            set { _sAT_AGENCIES = value; }
            get { return _sAT_AGENCIES; }
        }
        /// <summary>
        /// SAT_DESCRIPTION
        /// </summary>
        public string SAT_DESCRIPTION
        {
            set { _sAT_DESCRIPTION = value; }
            get { return _sAT_DESCRIPTION; }
        }
        /// <summary>
        /// SAT_DESCRIPTION2
        /// </summary>
        public string SAT_DESCRIPTION2
        {
            set { _sAT_DESCRIPTION2 = value; }
            get { return _sAT_DESCRIPTION2; }
        }
        /// <summary>
        /// SAT_LAUNCHTIME
        /// </summary>
        public DateTime SAT_LAUNCHTIME
        {
            set { _sAT_LAUNCHTIME = value; }
            get { return _sAT_LAUNCHTIME; }
        }
        /// <summary>
        /// SAT_EOLTIME
        /// </summary>
        public DateTime SAT_EOLTIME
        {
            set { _sAT_EOLTIME = value; }
            get { return _sAT_EOLTIME; }
        }
        /// <summary>
        /// SAT_REPEATCYCLE
        /// </summary>
        public decimal SAT_REPEATCYCLE
        {
            set { _sAT_REPEATCYCLE = value; }
            get { return _sAT_REPEATCYCLE; }
        }
        /// <summary>
        /// SAT_DATAACCESS
        /// </summary>
        public string SAT_DATAACCESS
        {
            set { _sAT_DATAACCESS = value; }
            get { return _sAT_DATAACCESS; }
        }
        /// <summary>
        /// SAT_CHARTER
        /// </summary>
        public decimal SAT_CHARTER
        {
            set { _sAT_CHARTER = value; }
            get { return _sAT_CHARTER; }
        }
        /// <summary>
        /// MAXGSD
        /// </summary>
        public decimal MAXGSD
        {
            set { _mAXGSD = value; }
            get { return _mAXGSD; }
        }
        /// <summary>
        /// MAXSW
        /// </summary>
        public decimal MAXSW
        {
            set { _mAXSW = value; }
            get { return _mAXSW; }
        }
        #endregion Model
        

    }
}
