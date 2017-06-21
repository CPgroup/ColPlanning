//------------------------------------------------------------------------------
// 创建标识: 董毅博
// 创建描述: 卫星轨道访问类
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
    public class SatelliteOrbit
    {

        //数据库连接字符串(web.config来配置)，可以动态更改connectionString支持多数据库.		
        public static string connectionString;
        public SatelliteOrbit()
        { connectionString = PubConstant.GetConnectionString(""); }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.SatelliteOrbit model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO T_PUB_SATELLITEORBIT(");
            strSql.Append("SAT_ID,SAT_ORBITEPOCH,SAT_MEANMOTION,SAT_ECCENTRICITY,SAT_INCLINATION,SAT_ARGOFPERIGEE,SAT_RAAN,SAT_MEANANOMALY,SAT_MEANMOTIONDOT,SAT_MEANMOTIONDOTDOT,SAT_BSTAR,SAT_ORBITDATE,SAT_TLE1,SAT_TLE2)");
            strSql.Append(" VALUES (");
            strSql.Append("@in_SAT_ID,@in_SAT_ORBITEPOCH,@in_SAT_MEANMOTION,@in_SAT_ECCENTRICITY,@in_SAT_INCLINATION,@in_SAT_ARGOFPERIGEE,@in_SAT_RAAN,@in_SAT_MEANANOMALY,@in_SAT_MEANMOTIONDOT,@in_SAT_MEANMOTIONDOTDOT,@in_SAT_BSTAR,@in_SAT_ORBITDATE,@in_SAT_TLE1,@in_SAT_TLE2)");
            SqlParameter[] cmdParms = new SqlParameter[]{
				new SqlParameter("@in_SAT_ID", SqlDbType.Decimal),
				new SqlParameter("@in_SAT_ORBITEPOCH", SqlDbType.NVarChar),
				new SqlParameter("@in_SAT_MEANMOTION", SqlDbType.NVarChar),
				new SqlParameter("@in_SAT_ECCENTRICITY", SqlDbType.NVarChar),
				new SqlParameter("@in_SAT_INCLINATION", SqlDbType.NVarChar),
				new SqlParameter("@in_SAT_ARGOFPERIGEE", SqlDbType.NVarChar),
				new SqlParameter("@in_SAT_RAAN", SqlDbType.NVarChar),
				new SqlParameter("@in_SAT_MEANANOMALY", SqlDbType.NVarChar),
				new SqlParameter("@in_SAT_MEANMOTIONDOT", SqlDbType.NVarChar),
				new SqlParameter("@in_SAT_MEANMOTIONDOTDOT", SqlDbType.NVarChar),
				new SqlParameter("@in_SAT_BSTAR", SqlDbType.NVarChar),
				new SqlParameter("@in_SAT_ORBITDATE", SqlDbType.DateTime),
                new SqlParameter("@in_SAT_TLE1", SqlDbType.NVarChar),
                new SqlParameter("@in_SAT_TLE2", SqlDbType.NVarChar)
                };
            cmdParms[0].Value = model.SAT_ID;
            cmdParms[1].Value = model.SAT_ORBITEPOCH;
            cmdParms[2].Value = model.SAT_MEANMOTION;
            cmdParms[3].Value = model.SAT_ECCENTRICITY;
            cmdParms[4].Value = model.SAT_INCLINATION;
            cmdParms[5].Value = model.SAT_ARGOFPERIGEE;
            cmdParms[6].Value = model.SAT_RAAN;
            cmdParms[7].Value = model.SAT_MEANANOMALY;
            cmdParms[8].Value = model.SAT_MEANMOTIONDOT;
            cmdParms[9].Value = model.SAT_MEANMOTIONDOTDOT;
            cmdParms[10].Value = model.SAT_BSTAR;
            cmdParms[11].Value = model.SAT_ORBITDATE;
            cmdParms[12].Value = model.SAT_TLE1;
            cmdParms[13].Value = model.SAT_TLE2;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Model.SatelliteOrbit model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE T_PUB_SATELLITEORBIT SET ");
            strSql.Append("SAT_ORBITEPOCH=@in_SAT_ORBITEPOCH,");
            strSql.Append("SAT_MEANMOTION=@in_SAT_MEANMOTION,");
            strSql.Append("SAT_ECCENTRICITY=@in_SAT_ECCENTRICITY,");
            strSql.Append("SAT_INCLINATION=@in_SAT_INCLINATION,");
            strSql.Append("SAT_ARGOFPERIGEE=@in_SAT_ARGOFPERIGEE,");
            strSql.Append("SAT_RAAN=@in_SAT_RAAN,");
            strSql.Append("SAT_MEANANOMALY=@in_SAT_MEANANOMALY,");
            strSql.Append("SAT_MEANMOTIONDOT=@in_SAT_MEANMOTIONDOT,");
            strSql.Append("SAT_MEANMOTIONDOTDOT=@in_SAT_MEANMOTIONDOTDOT,");
            strSql.Append("SAT_BSTAR=@in_SAT_BSTAR,");
            strSql.Append("SAT_ORBITDATE=@in_SAT_ORBITDATE,");
            strSql.Append("SAT_TLE1=@in_SAT_TLE1,");
            strSql.Append("SAT_TLE2=@in_SAT_TLE2");
            strSql.Append(" WHERE SAT_ID=@in_SAT_ID");
            SqlParameter[] cmdParms = new SqlParameter[]{
				new SqlParameter("@in_SAT_ID", SqlDbType.Decimal),
				new SqlParameter("@in_SAT_ORBITEPOCH", SqlDbType.NVarChar),
				new SqlParameter("@in_SAT_MEANMOTION", SqlDbType.NVarChar),
				new SqlParameter("@in_SAT_ECCENTRICITY", SqlDbType.NVarChar),
				new SqlParameter("@in_SAT_INCLINATION", SqlDbType.NVarChar),
				new SqlParameter("@in_SAT_ARGOFPERIGEE", SqlDbType.NVarChar),
				new SqlParameter("@in_SAT_RAAN", SqlDbType.NVarChar),
				new SqlParameter("@in_SAT_MEANANOMALY", SqlDbType.NVarChar),
				new SqlParameter("@in_SAT_MEANMOTIONDOT", SqlDbType.NVarChar),
				new SqlParameter("@in_SAT_MEANMOTIONDOTDOT", SqlDbType.NVarChar),
				new SqlParameter("@in_SAT_BSTAR", SqlDbType.NVarChar),
				new SqlParameter("@in_SAT_ORBITDATE", SqlDbType.DateTime),
                new SqlParameter("@in_SAT_TLE1", SqlDbType.NVarChar),
                new SqlParameter("@in_SAT_TLE2", SqlDbType.NVarChar)};
            cmdParms[0].Value = model.SAT_ID;
            cmdParms[1].Value = model.SAT_ORBITEPOCH;
            cmdParms[2].Value = model.SAT_MEANMOTION;
            cmdParms[3].Value = model.SAT_ECCENTRICITY;
            cmdParms[4].Value = model.SAT_INCLINATION;
            cmdParms[5].Value = model.SAT_ARGOFPERIGEE;
            cmdParms[6].Value = model.SAT_RAAN;
            cmdParms[7].Value = model.SAT_MEANANOMALY;
            cmdParms[8].Value = model.SAT_MEANMOTIONDOT;
            cmdParms[9].Value = model.SAT_MEANMOTIONDOTDOT;
            cmdParms[10].Value = model.SAT_BSTAR;
            cmdParms[11].Value = model.SAT_ORBITDATE;
            cmdParms[12].Value = model.SAT_TLE1;
            cmdParms[13].Value = model.SAT_TLE2;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(decimal SAT_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM T_PUB_SATELLITEORBIT ");
            strSql.Append(" WHERE SAT_ID=@in_SAT_ID");
            SqlParameter[] cmdParms = new SqlParameter[]{
				new SqlParameter("@in_SAT_ID", SqlDbType.Decimal)};
            cmdParms[0].Value = SAT_ID;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(decimal SAT_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM T_PUB_SATELLITEORBIT");
            strSql.Append(" WHERE SAT_ID="+SAT_ID);
            return DbHelperSQL.Exists(strSql.ToString());
        }
        /// <summary>
        /// 是否存在某一日期的星历
        /// </summary>
        /// <param name="orbitDate"></param>
        /// <returns></returns>
        public bool Exists(DateTime orbitDate)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM T_PUB_SATELLITEORBIT");
            strSql.Append(" WHERE SAT_ORBITDATE='"+orbitDate+"'");
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.SatelliteOrbit GetModel(decimal SAT_ID, DateTime time)
        {
            /*
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM LHF.T_PUB_SATELLITEORBIT ");
            strSql.Append(" WHERE SAT_ID="+SAT_ID);
            Model.SatelliteOrbit model = null;
            using (DbDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (dr.Read())
                {
                    model = GetModel(dr);
                }
                return model;
            }*/

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TOP 1 * FROM T_PUB_SATELLITEORBIT ");
            strSql.Append(" WHERE SAT_ID=" + SAT_ID);
            strSql.Append(" AND SAT_ORBITDATE<='" + time.ToString("yyyy-MM-dd HH:mm:ss") + "'");
            strSql.Append(" ORDER BY SAT_ORBITDATE DESC");
            Model.SatelliteOrbit model = new Model.SatelliteOrbit();
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
        public List<Model.SatelliteOrbit> GetList()
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM T_PUB_SATELLITEORBIT");
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.SatelliteOrbit> lst = GetList(dr);
                return lst;
            }
        }

        /// <summary>
        /// 获取所有日期
        /// 
        /// </summary>
        /// <returns></returns>
        public List<DateTime> GetDate()
        {
            StringBuilder strSql = new StringBuilder("SELECT DISTINCT SAT_ORBITDATE FROM T_PUB_SATELLITEORBIT");
            strSql.Append(" ORDER BY SAT_ORBITDATE DESC");
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<DateTime> lst=new List<DateTime>();
                while (dr.Read())
                {
                    DateTime dt = Convert.ToDateTime(dr["SAT_ORBITDATE"]);
                    lst.Add(dt);
                }
                return lst;
            }
        }

        /// <summary>
        /// 获取最接近的日期
        /// </summary>
        /// <returns></returns>
        public DateTime GetNearestDate(DateTime date)
        {
            StringBuilder strSql = new StringBuilder("SELECT MAX(SAT_ORBITDATE) FROM T_PUB_SATELLITEORBIT");
            strSql.Append(" WHERE SAT_ORBITDATE<=@in_SAT_ORBITDATE");
            SqlParameter[] cmdParms = new SqlParameter[]{
				new SqlParameter("@in_SAT_ORBITDATE", SqlDbType.DateTime)};
            cmdParms[0].Value = date;
            return Convert.ToDateTime(DbHelperSQL.GetSingle(strSql.ToString(), cmdParms));
        }
        /// <summary>
        /// 得到数据条数
        /// </summary>
        public int GetCount(string condition)
        {
            return DbHelperSQL.GetCount("T_PUB_SATELLITEORBIT", condition);
        }
        #region 对相关其他表操作
        /// <summary>
        /// 清空轨道私有表
        /// </summary>
        /// <returns></returns>
        public int ClearPrivateOrbit()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM T_PUB_NEWORBIT ");
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int AddtoPrivate(Model.SatelliteOrbit model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO T_PUB_NEWORBIT(");
            strSql.Append("SAT_ID,SAT_ORBITEPOCH,SAT_MEANMOTION,SAT_ECCENTRICITY,SAT_INCLINATION,SAT_ARGOFPERIGEE,SAT_RAAN,SAT_MEANANOMALY,SAT_MEANMOTIONDOT,SAT_MEANMOTIONDOTDOT,SAT_BSTAR)");
            strSql.Append(" VALUES (");
            strSql.Append("@in_SAT_ID,@in_SAT_ORBITEPOCH,@in_SAT_MEANMOTION,@in_SAT_ECCENTRICITY,@in_SAT_INCLINATION,@in_SAT_ARGOFPERIGEE,@in_SAT_RAAN,@in_SAT_MEANANOMALY,@in_SAT_MEANMOTIONDOT,@in_SAT_MEANMOTIONDOTDOT,@in_SAT_BSTAR)");
            SqlParameter[] cmdParms = new SqlParameter[]{
                new SqlParameter("@in_SAT_ID", SqlDbType.Decimal),
                new SqlParameter("@in_SAT_ORBITEPOCH", SqlDbType.NVarChar),
                new SqlParameter("@in_SAT_MEANMOTION", SqlDbType.NVarChar),
                new SqlParameter("@in_SAT_ECCENTRICITY", SqlDbType.NVarChar),
                new SqlParameter("@in_SAT_INCLINATION", SqlDbType.NVarChar),
                new SqlParameter("@in_SAT_ARGOFPERIGEE", SqlDbType.NVarChar),
                new SqlParameter("@in_SAT_RAAN", SqlDbType.NVarChar),
                new SqlParameter("@in_SAT_MEANANOMALY", SqlDbType.NVarChar),
                new SqlParameter("@in_SAT_MEANMOTIONDOT", SqlDbType.NVarChar),
                new SqlParameter("@in_SAT_MEANMOTIONDOTDOT", SqlDbType.NVarChar),
                new SqlParameter("@in_SAT_BSTAR", SqlDbType.NVarChar)};
            cmdParms[0].Value = model.SAT_ID;
            cmdParms[1].Value = model.SAT_ORBITEPOCH;
            cmdParms[2].Value = model.SAT_MEANMOTION;
            cmdParms[3].Value = model.SAT_ECCENTRICITY;
            cmdParms[4].Value = model.SAT_INCLINATION;
            cmdParms[5].Value = model.SAT_ARGOFPERIGEE;
            cmdParms[6].Value = model.SAT_RAAN;
            cmdParms[7].Value = model.SAT_MEANANOMALY;
            cmdParms[8].Value = model.SAT_MEANMOTIONDOT;
            cmdParms[9].Value = model.SAT_MEANMOTIONDOTDOT;
            cmdParms[10].Value = model.SAT_BSTAR;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }
        #endregion

        #region -------- 私有方法，通常情况下无需修改 --------

        /// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        private Model.SatelliteOrbit GetModel(DbDataReader dr)
        {
            Model.SatelliteOrbit model = new Model.SatelliteOrbit();
            model.SAT_ID = Convert.ToDecimal(dr["SAT_ID"]);
            model.SAT_ORBITEPOCH = Convert.ToString(dr["SAT_ORBITEPOCH"]);
            model.SAT_MEANMOTION = Convert.ToString(dr["SAT_MEANMOTION"]);
            model.SAT_ECCENTRICITY = Convert.ToString(dr["SAT_ECCENTRICITY"]);
            model.SAT_INCLINATION = Convert.ToString(dr["SAT_INCLINATION"]);
            model.SAT_ARGOFPERIGEE = Convert.ToString(dr["SAT_ARGOFPERIGEE"]);
            model.SAT_RAAN = Convert.ToString(dr["SAT_RAAN"]);
            model.SAT_MEANANOMALY = Convert.ToString(dr["SAT_MEANANOMALY"]);
            model.SAT_MEANMOTIONDOT = Convert.ToString(dr["SAT_MEANMOTIONDOT"]);
            model.SAT_MEANMOTIONDOTDOT = Convert.ToString(dr["SAT_MEANMOTIONDOTDOT"]);
            model.SAT_BSTAR = Convert.ToString(dr["SAT_BSTAR"]);
            model.SAT_ORBITDATE = Convert.ToDateTime(dr["SAT_ORBITDATE"]);
            try
            {
                model.SAT_TLE1 = Convert.ToString(dr["SAT_TLE1"]);
            }
            catch (Exception e)
            {
                model.SAT_TLE1 = "";
            }
            try
            {
                model.SAT_TLE2 = Convert.ToString(dr["SAT_TLE2"]);
            }
            catch (Exception e)
            {
                model.SAT_TLE2 = "";
            }
            return model;
        }

        /// <summary>
        /// 由DbDataReader得到泛型数据列表
        /// </summary>
        private List<Model.SatelliteOrbit> GetList(DbDataReader dr)
        {
            List<Model.SatelliteOrbit> lst = new List<Model.SatelliteOrbit>();
            while (dr.Read())
            {
                lst.Add(GetModel(dr));
            }
            return lst;
        }

        #endregion
    }
}
