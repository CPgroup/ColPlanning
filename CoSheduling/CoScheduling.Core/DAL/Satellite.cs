//------------------------------------------------------------------------------
// 创建标识: 董毅博
// 创建描述: 卫星信息访问类
// 创建时间:2014.6.9
// 文件版本:2.0
// 功能描述: 
// 修改标识: 
// 修改描述: 
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using CoScheduling.Core.DBUtility;
using System.Data;
using System.Data.Common;

namespace CoScheduling.Core.DAL
{

    public class Satellite
    {

        //数据库连接字符串(web.config来配置)，可以动态更改connectionString支持多数据库.		
        public static string connectionString;
        public Satellite()
        {
            connectionString = PubConstant.GetConnectionString("");
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.Satellite model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO LHF.SATELLITE_INFO(");
            strSql.Append("SAT_ID,SAT_COSPAR,SAT_SHORTNAME,SAT_LONGNAME,SAT_FULLNAME,SAT_ORBITCLASS,SAT_ORBITTYPE,SAT_LONGITUDEOFGEO,SAT_APPLICATION,SAT_COUNTRY,SAT_USES,SAT_AGENCIES,SAT_DESCRIPTION,SAT_DESCRIPTION2,SAT_LAUNCHTIME,SAT_EOLTIME,SAT_REPEATCYCLE,SAT_DATAACCESS,SAT_CHARTER,MAXGSD,MAXSW)");
            strSql.Append(" VALUES (");
            strSql.Append("@in_SAT_ID,@in_SAT_COSPAR,@in_SAT_SHORTNAME,@in_SAT_LONGNAME,@in_SAT_FULLNAME,@in_SAT_ORBITCLASS,@in_SAT_ORBITTYPE,@in_SAT_LONGITUDEOFGEO,@in_SAT_APPLICATION,@in_SAT_COUNTRY,@in_SAT_USES,@in_SAT_AGENCIES,@in_SAT_DESCRIPTION,@in_SAT_DESCRIPTION2,@in_SAT_LAUNCHTIME,@in_SAT_EOLTIME,@in_SAT_REPEATCYCLE,@in_SAT_DATAACCESS,@in_SAT_CHARTER,@in_MAXGSD,@in_MAXSW)");
            SqlParameter[] cmdParms = new SqlParameter[]{
				new SqlParameter("@in_SAT_ID", SqlDbType.Decimal),
				new SqlParameter("@in_SAT_COSPAR", SqlDbType.NVarChar),
				new SqlParameter("@in_SAT_SHORTNAME", SqlDbType.NVarChar),
				new SqlParameter("@in_SAT_LONGNAME", SqlDbType.NVarChar),
				new SqlParameter("@in_SAT_FULLNAME", SqlDbType.NVarChar),
				new SqlParameter("@in_SAT_ORBITCLASS", SqlDbType.NVarChar),
				new SqlParameter("@in_SAT_ORBITTYPE", SqlDbType.NVarChar),
				new SqlParameter("@in_SAT_LONGITUDEOFGEO", SqlDbType.Decimal),
				new SqlParameter("@in_SAT_APPLICATION", SqlDbType.NVarChar),
				new SqlParameter("@in_SAT_COUNTRY", SqlDbType.NVarChar),
				new SqlParameter("@in_SAT_USES", SqlDbType.NVarChar),
				new SqlParameter("@in_SAT_AGENCIES", SqlDbType.NVarChar),
				new SqlParameter("@in_SAT_DESCRIPTION", SqlDbType.NVarChar),
				new SqlParameter("@in_SAT_DESCRIPTION2", SqlDbType.NVarChar),
				new SqlParameter("@in_SAT_LAUNCHTIME", SqlDbType.DateTime),
				new SqlParameter("@in_SAT_EOLTIME", SqlDbType.DateTime),
				new SqlParameter("@in_SAT_REPEATCYCLE", SqlDbType.Decimal),
				new SqlParameter("@in_SAT_DATAACCESS", SqlDbType.NVarChar),
				new SqlParameter("@in_SAT_CHARTER", SqlDbType.Decimal),
				new SqlParameter("@in_MAXGSD", SqlDbType.Decimal),
				new SqlParameter("@in_MAXSW", SqlDbType.Decimal)};

            cmdParms[0].Value = model.SAT_ID;
            cmdParms[1].Value = model.SAT_COSPAR;
            cmdParms[2].Value = model.SAT_SHORTNAME;
            cmdParms[3].Value = model.SAT_LONGNAME;
            cmdParms[4].Value = model.SAT_FULLNAME;
            cmdParms[5].Value = model.SAT_ORBITCLASS;
            cmdParms[6].Value = model.SAT_ORBITTYPE;
            cmdParms[7].Value = model.SAT_LONGITUDEOFGEO;
            cmdParms[8].Value = model.SAT_APPLICATION;
            cmdParms[9].Value = model.SAT_COUNTRY;
            cmdParms[10].Value = model.SAT_USES;
            cmdParms[11].Value = model.SAT_AGENCIES;
            cmdParms[12].Value = model.SAT_DESCRIPTION;
            cmdParms[13].Value = model.SAT_DESCRIPTION2;
            cmdParms[14].Value = model.SAT_LAUNCHTIME;
            cmdParms[15].Value = model.SAT_EOLTIME;
            cmdParms[16].Value = model.SAT_REPEATCYCLE;
            cmdParms[17].Value = model.SAT_DATAACCESS;
            cmdParms[18].Value = model.SAT_CHARTER;
            cmdParms[19].Value = model.MAXGSD;
            cmdParms[20].Value = model.MAXSW;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Model.Satellite model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE LHF.SATELLITE_INFO SET ");
            strSql.Append("SAT_COSPAR=@in_SAT_COSPAR,");
            strSql.Append("SAT_SHORTNAME=@in_SAT_SHORTNAME,");
            strSql.Append("SAT_LONGNAME=@in_SAT_LONGNAME,");
            strSql.Append("SAT_FULLNAME=@in_SAT_FULLNAME,");
            strSql.Append("SAT_ORBITCLASS=@in_SAT_ORBITCLASS,");
            strSql.Append("SAT_ORBITTYPE=@in_SAT_ORBITTYPE,");
            strSql.Append("SAT_LONGITUDEOFGEO=@in_SAT_LONGITUDEOFGEO,");
            strSql.Append("SAT_APPLICATION=@in_SAT_APPLICATION,");
            strSql.Append("SAT_COUNTRY=@in_SAT_COUNTRY,");
            strSql.Append("SAT_USES=@in_SAT_USES,");
            strSql.Append("SAT_AGENCIES=@in_SAT_AGENCIES,");
            strSql.Append("SAT_DESCRIPTION=@in_SAT_DESCRIPTION,");
            strSql.Append("SAT_DESCRIPTION2=@in_SAT_DESCRIPTION2,");
            strSql.Append("SAT_LAUNCHTIME=@in_SAT_LAUNCHTIME,");
            strSql.Append("SAT_EOLTIME=@in_SAT_EOLTIME,");
            strSql.Append("SAT_REPEATCYCLE=@in_SAT_REPEATCYCLE,");
            strSql.Append("SAT_DATAACCESS=@in_SAT_DATAACCESS,");
            strSql.Append("SAT_CHARTER=@in_SAT_CHARTER,");
            strSql.Append("MAXGSD=@in_MAXGSD,");
            strSql.Append("MAXSW=@in_MAXSW");
            strSql.Append(" WHERE SAT_ID=@in_SAT_ID");
            SqlParameter[] cmdParms = new SqlParameter[]{
				new SqlParameter("@in_SAT_ID", SqlDbType.Decimal),
				new SqlParameter("@in_SAT_COSPAR", SqlDbType.NVarChar),
				new SqlParameter("@in_SAT_SHORTNAME", SqlDbType.NVarChar),
				new SqlParameter("@in_SAT_LONGNAME", SqlDbType.NVarChar),
				new SqlParameter("@in_SAT_FULLNAME", SqlDbType.NVarChar),
				new SqlParameter("@in_SAT_ORBITCLASS", SqlDbType.NVarChar),
				new SqlParameter("@in_SAT_ORBITTYPE", SqlDbType.NVarChar),
				new SqlParameter("@in_SAT_LONGITUDEOFGEO", SqlDbType.Decimal),
				new SqlParameter("@in_SAT_APPLICATION", SqlDbType.NVarChar),
				new SqlParameter("@in_SAT_COUNTRY", SqlDbType.NVarChar),
				new SqlParameter("@in_SAT_USES", SqlDbType.NVarChar),
				new SqlParameter("@in_SAT_AGENCIES", SqlDbType.NVarChar),
				new SqlParameter("@in_SAT_DESCRIPTION", SqlDbType.NVarChar),
				new SqlParameter("@in_SAT_DESCRIPTION2", SqlDbType.NVarChar),
				new SqlParameter("@in_SAT_LAUNCHTIME", SqlDbType.DateTime),
				new SqlParameter("@in_SAT_EOLTIME", SqlDbType.DateTime),
				new SqlParameter("@in_SAT_REPEATCYCLE", SqlDbType.Decimal),
				new SqlParameter("@in_SAT_DATAACCESS", SqlDbType.NVarChar),
				new SqlParameter("@in_SAT_CHARTER", SqlDbType.Decimal),
				new SqlParameter("@in_MAXGSD", SqlDbType.Decimal),
				new SqlParameter("@in_MAXSW", SqlDbType.Decimal)};

            cmdParms[0].Value = model.SAT_ID;
            cmdParms[1].Value = model.SAT_COSPAR;
            cmdParms[2].Value = model.SAT_SHORTNAME;
            cmdParms[3].Value = model.SAT_LONGNAME;
            cmdParms[4].Value = model.SAT_FULLNAME;
            cmdParms[5].Value = model.SAT_ORBITCLASS;
            cmdParms[6].Value = model.SAT_ORBITTYPE;
            cmdParms[7].Value = model.SAT_LONGITUDEOFGEO;
            cmdParms[8].Value = model.SAT_APPLICATION;
            cmdParms[9].Value = model.SAT_COUNTRY;
            cmdParms[10].Value = model.SAT_USES;
            cmdParms[11].Value = model.SAT_AGENCIES;
            cmdParms[12].Value = model.SAT_DESCRIPTION;
            cmdParms[13].Value = model.SAT_DESCRIPTION2;
            cmdParms[14].Value = model.SAT_LAUNCHTIME;
            cmdParms[15].Value = model.SAT_EOLTIME;
            cmdParms[16].Value = model.SAT_REPEATCYCLE;
            cmdParms[17].Value = model.SAT_DATAACCESS;
            cmdParms[18].Value = model.SAT_CHARTER;
            cmdParms[19].Value = model.MAXGSD;
            cmdParms[20].Value = model.MAXSW;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(decimal SAT_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM LHF.SATELLITE_INFO ");
            strSql.Append(" WHERE SAT_ID=@in_SAT_ID");
            SqlParameter[] cmdParms = new SqlParameter[]{
				new SqlParameter("@in_SAT_ID", SqlDbType.Decimal)};
            cmdParms[0].Value = SAT_ID;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string SAT_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM LHF.SATELLITE_INFO");
            strSql.Append(" WHERE SAT_ID=" + SAT_ID);
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.Satellite GetModel(decimal SAT_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM LHF.SATELLITE_INFO ");
            strSql.Append(" WHERE SAT_ID="+SAT_ID);
            Model.Satellite model = null;
            using (DbDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (dr.Read())
                {
                    model = GetModel(dr);
                }
                return model;
            }
        }

        /// <summary>
        /// 获取泛型数据列表
        /// </summary>
        public List<Model.Satellite> GetList(string whereclause)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM LHF.SATELLITE_INFO ");
            strSql.Append(" WHERE " + whereclause); ;
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.Satellite> lst = GetList(dr);
                return lst;
            }
        }
        /// <summary>
        /// 获取全部记录
        /// </summary>
        /// <returns></returns>
        public List<CoScheduling.Core.Model.Satellite> GetList()
        {
            StringBuilder StrSql = new StringBuilder();
            StrSql.Append("SELECT * FROM LHF.SATELLITE_INFO order by SAT_ID desc");

            using (DbDataReader dr = DbHelperSQL.ExecuteReader(StrSql.ToString()))
            {
                List<CoScheduling.Core.Model.Satellite> lst = GetList(dr);
                dr.Close();
                return lst;
            }
        }

        /// <summary>
        /// 更新卫星参数
        /// </summary>
        public int UpdateCanshu(string sat_id, string maxgsd, string maxsw)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE LHF.SATELLITE_INFO SET ");
            strSql.Append("MAXGSD=" + maxgsd + ",");
            strSql.Append("MAXSW=" + maxsw);
            strSql.Append(" WHERE SAT_ID=" + sat_id);
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }




        /// <summary>
        /// 根据注册时间获取
        /// </summary>
        /// <param name="begin">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <returns></returns>
        //public List<CoScheduling.Core.Model.Satellite> GetList(string begin, string end)
        //{
        //    StringBuilder StrSql = new StringBuilder();
        //    StrSql.Append("SELECT * FROM SYS_USERS ");
        //    StrSql.Append("WHERE REGISTERTIME between SAT_LAUNCHTIME  AND SAT_EOLTIME  order by SAT_LAUNCHTIME desc");
        //    SqlParameter[] parameters = new SqlParameter[]{
        //            new OracleParameter("SAT_LAUNCHTIME", OracleType.DateTime),
        //            new OracleParameter("REGISTERTIME2", OracleType.DateTime)};
        //    parameters[0].Value = Convert.ToDateTime(begin);
        //    parameters[1].Value = Convert.ToDateTime(end);
        //    using (DbDataReader dr = DbHelperSQL.ExecuteReader(StrSql.ToString(), parameters))
        //    {
        //        List<CoScheduling.Core.Model.Satellite> lst = GetList(dr);
        //        dr.Close(); DbHelperSQL.CloseConnection();
        //        return lst;
        //    }
        //}



        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetListTable(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * ");
            strSql.Append(" FROM LHF.SATELLITE_INFO ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ORDER BY SAT_ID");
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }

        /// <summary>
        /// 根据条件获取DataSet数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetListDataSet(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * ");
            strSql.Append(" FROM LHF.SATELLITE_INFO ");
            if (strWhere.Trim() != "")
            {
                strSql.Append("WHERE " + strWhere);
            }
            strSql.Append(" ORDER BY SAT_ID");
            DataSet dsSat = new DataSet();
            SqlDataAdapter odaSat = new SqlDataAdapter(strSql.ToString(), connectionString);
            if (dsSat.Tables["SATELLITE_INFO"] != null)
            {
                dsSat.Tables["SATELLITE_INFO"].Clear();
            }

            odaSat.Fill(dsSat, "SATELLITE_INFO");

            return dsSat;
        }

        /// <summary>
        /// 得到数据条数
        /// </summary>
        public int GetCount(string condition)
        {
            return DbHelperSQL.GetCount("SATELLITE_INFO", condition);
        }


        #region -------- 私有方法，通常情况下无需修改 --------

        /// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        private Model.Satellite GetModel(DbDataReader dr)
        {

            CoScheduling.Core.Model.Satellite model = new CoScheduling.Core.Model.Satellite();
            model.SAT_ID = Convert.ToDecimal(dr["SAT_ID"]);
            model.SAT_COSPAR = Convert.ToString(dr["SAT_COSPAR"]);
            model.SAT_SHORTNAME = Convert.ToString(dr["SAT_SHORTNAME"]);
            try
            {
                model.SAT_LONGNAME = Convert.ToString(dr["SAT_LONGNAME"]);
            }
            catch
            {
                model.SAT_LONGNAME = Convert.ToString("N/A");
            }

            try
            {
                model.SAT_FULLNAME = Convert.ToString(dr["SAT_FULLNAME"]);
            }
            catch
            {
                model.SAT_FULLNAME = Convert.ToString("N/A");
            }
            try
            {
                model.SAT_ORBITCLASS = Convert.ToString(dr["SAT_ORBITCLASS"]);
            }
            catch
            {
                model.SAT_ORBITCLASS = Convert.ToString("N/A");
            }
            try
            {
                model.SAT_ORBITTYPE = Convert.ToString(dr["SAT_ORBITTYPE"]);
            }
            catch
            {
                model.SAT_ORBITTYPE = Convert.ToString("N/A");
            }
            try
            {
                model.SAT_LONGITUDEOFGEO = Convert.ToDecimal(dr["SAT_LONGITUDEOFGEO"]);
            }
            catch
            {
                model.SAT_LONGITUDEOFGEO = Convert.ToDecimal("-1");
            }
            try
            {
                model.SAT_APPLICATION = Convert.ToString(dr["SAT_APPLICATION"]);
            }
            catch
            {
                model.SAT_APPLICATION = Convert.ToString("N/A");
            }
            try
            {
                model.SAT_COUNTRY = Convert.ToString(dr["SAT_COUNTRY"]);
            }
            catch
            {
                model.SAT_COUNTRY = Convert.ToString("N/A");
            }
            try
            {
                model.SAT_USES = Convert.ToString(dr["SAT_USES"]);
            }
            catch
            {
                model.SAT_USES = Convert.ToString("N/A");
            }
            try
            {
                model.SAT_AGENCIES = Convert.ToString(dr["SAT_AGENCIES"]);
            }
            catch
            {
                model.SAT_AGENCIES = Convert.ToString("N/A");
            }
            try
            {
                model.SAT_DESCRIPTION = Convert.ToString(dr["SAT_DESCRIPTION"]);
            }
            catch
            {
                model.SAT_DESCRIPTION = Convert.ToString("N/A");
            }
            try
            {
                model.SAT_DESCRIPTION2 = Convert.ToString(dr["SAT_DESCRIPTION2"]);
            }
            catch
            {
                model.SAT_DESCRIPTION2 = Convert.ToString("N/A");
            }
            try
            {
                model.SAT_REPEATCYCLE = Convert.ToDecimal(dr["SAT_REPEATCYCLE"]);
            }
            catch
            {
                model.SAT_REPEATCYCLE = Convert.ToDecimal("-1");
            }
            try
            {
                model.SAT_DATAACCESS = Convert.ToString(dr["SAT_DATAACCESS"]);
            }
            catch
            {
                model.SAT_DATAACCESS = Convert.ToString("N/A");
            }
            try
            {
                model.SAT_LAUNCHTIME = Convert.ToDateTime(dr["SAT_LAUNCHTIME"]);
            }
            catch
            {
                model.SAT_LAUNCHTIME = Convert.ToDateTime("2013-01-01");
            }
            try
            {
                model.SAT_EOLTIME = Convert.ToDateTime(dr["SAT_EOLTIME"]);
            }
            catch
            {
                model.SAT_EOLTIME = Convert.ToDateTime("2013-01-01");
            }
            try
            {
                model.SAT_CHARTER = Convert.ToDecimal(dr["SAT_CHARTER"]);
            }
            catch
            {
                model.SAT_CHARTER = Convert.ToDecimal("0");
            }
            model.MAXGSD = Convert.ToDecimal(dr["MAXGSD"]);
            model.MAXSW = Convert.ToDecimal(dr["MAXSW"]);
            return model;
        }

        /// <summary>
        /// 由DbDataReader得到泛型数据列表
        /// </summary>
        private List<Model.Satellite> GetList(DbDataReader dr)
        {
            List<Model.Satellite> lst = new List<Model.Satellite>();
            while (dr.Read())
            {
                lst.Add(GetModel(dr));
            }
            return lst;
        }

        #endregion



    }
}
