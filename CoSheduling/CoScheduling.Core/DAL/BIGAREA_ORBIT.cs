using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    public class BIGAREA_ORBIT
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CoScheduling.Core.Model.BIGAREA_ORBIT model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO BIGAREA_ORBIT(");
            strSql.Append("SATID,SAT_ORBITEPOCH,SAT_MEANMOTION,SAT_ECCENTRICITY,SAT_INCLINATION,SAT_ARGOFPERIGEE,SAT_RAAN,SAT_MEANANOMALY,SAT_MEANMOTIONDOT,SAT_MEANMOTIONDOTDOT,SAT_BSTAR,SAT_TLE1,SAT_TLE2,SCHEMEID)");
            strSql.Append(" VALUES (");
            strSql.Append("@in_SATID,@in_SAT_ORBITEPOCH,@in_SAT_MEANMOTION,@in_SAT_ECCENTRICITY,@in_SAT_INCLINATION,@in_SAT_ARGOFPERIGEE,@in_SAT_RAAN,@in_SAT_MEANANOMALY,@in_SAT_MEANMOTIONDOT,@in_SAT_MEANMOTIONDOTDOT,@in_SAT_BSTAR,@in_SAT_TLE1,@in_SAT_TLE2,@in_SCHEMEID)");
            SqlParameter[] cmdParms = new SqlParameter[]{
				new SqlParameter("@in_SATID", SqlDbType.Decimal),
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
                new SqlParameter("@in_SAT_TLE1", SqlDbType.NVarChar),
                new SqlParameter("@in_SAT_TLE2", SqlDbType.NVarChar),
				new SqlParameter("@in_SCHEMEID", SqlDbType.Decimal)};
            cmdParms[0].Value = model.SATID;
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
            cmdParms[11].Value = model.SAT_TLE1;
            cmdParms[12].Value = model.SAT_TLE2;
            cmdParms[13].Value = model.SCHEMEID;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(CoScheduling.Core.Model.BIGAREA_ORBIT model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE BIGAREA_ORBIT SET ");
            strSql.Append("SATID=@in_SATID,");
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
            strSql.Append("SAT_TLE1=@in_SAT_TLE1,");
            strSql.Append("SAT_TLE2=@in_SAT_TLE2,");
            strSql.Append("SCHEMEID=@in_SCHEMEID");
            strSql.Append(" WHERE ORBITID=@in_ORBITID");
            SqlParameter[] cmdParms = new SqlParameter[]{
				new SqlParameter("@in_ORBITID", SqlDbType.Decimal),
				new SqlParameter("@in_SATID", SqlDbType.Decimal),
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
                new SqlParameter("@in_SAT_TLE1", SqlDbType.NVarChar),
                new SqlParameter("@in_SAT_TLE2", SqlDbType.NVarChar),
				new SqlParameter("@in_SCHEMEID", SqlDbType.Decimal)};
            cmdParms[0].Value = model.ORBITID;
            cmdParms[1].Value = model.SATID;
            cmdParms[2].Value = model.SAT_ORBITEPOCH;
            cmdParms[3].Value = model.SAT_MEANMOTION;
            cmdParms[4].Value = model.SAT_ECCENTRICITY;
            cmdParms[5].Value = model.SAT_INCLINATION;
            cmdParms[6].Value = model.SAT_ARGOFPERIGEE;
            cmdParms[7].Value = model.SAT_RAAN;
            cmdParms[8].Value = model.SAT_MEANANOMALY;
            cmdParms[9].Value = model.SAT_MEANMOTIONDOT;
            cmdParms[10].Value = model.SAT_MEANMOTIONDOTDOT;
            cmdParms[11].Value = model.SAT_BSTAR;
            cmdParms[12].Value = model.SAT_TLE1;
            cmdParms[13].Value = model.SAT_TLE2;
            cmdParms[14].Value = model.SCHEMEID;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(decimal ORBITID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM BIGAREA_ORBIT ");
            strSql.Append(" WHERE ORBITID=@in_ORBITID");
            SqlParameter[] cmdParms = new SqlParameter[]{
				new SqlParameter("@in_ORBITID", SqlDbType.Decimal)};
            cmdParms[0].Value = ORBITID;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(decimal ORBITID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM BIGAREA_ORBIT");
            strSql.Append(" WHERE ORBITID=@in_ORBITID");
            SqlParameter[] cmdParms = new SqlParameter[]{
				new SqlParameter("@in_ORBITID", SqlDbType.Decimal)};
            cmdParms[0].Value = ORBITID;
            return DbHelperSQL.Exists(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CoScheduling.Core.Model.BIGAREA_ORBIT GetModel(decimal ORBITID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM BIGAREA_ORBIT ");
            strSql.Append(" WHERE ORBITID=" + ORBITID);
            CoScheduling.Core.Model.BIGAREA_ORBIT model = new CoScheduling.Core.Model.BIGAREA_ORBIT();
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
        /// 得到一个对象实体
        /// </summary>
        public CoScheduling.Core.Model.BIGAREA_ORBIT GetModel(decimal SATID, decimal SCHEMEID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM BIGAREA_ORBIT ");
            strSql.Append(" WHERE SATID=" + SATID);
            strSql.Append(" AND SCHEMEID=" + SCHEMEID);
            CoScheduling.Core.Model.BIGAREA_ORBIT model = new CoScheduling.Core.Model.BIGAREA_ORBIT();
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
        public List<CoScheduling.Core.Model.BIGAREA_ORBIT> GetList()
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM BIGAREA_ORBIT");
            using (DbDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<CoScheduling.Core.Model.BIGAREA_ORBIT> lst = GetList(dr);
                return lst;
            }
        }

        /// <summary>
        /// 得到数据条数
        /// </summary>
        public int GetCount(string condition)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT (*) ");
            strSql.Append(" FROM BIGAREA_ORBIT ");
            if (condition.Trim() != "")
            {
                strSql.Append(" where " + condition);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int DeleteScheme(decimal SCHEMEID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM BIGAREA_ORBIT ");
            strSql.Append(" WHERE SCHEMEID=@in_SCHEMEID");
            SqlParameter[] cmdParms = new SqlParameter[]{
				new SqlParameter("@in_SCHEMEID", SqlDbType.Decimal)};
            cmdParms[0].Value = SCHEMEID;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }
        #region -------- 私有方法，通常情况下无需修改 --------

        /// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        private CoScheduling.Core.Model.BIGAREA_ORBIT GetModel(DbDataReader dr)
        {
            CoScheduling.Core.Model.BIGAREA_ORBIT model = new CoScheduling.Core.Model.BIGAREA_ORBIT();
            model.ORBITID = Convert.ToDecimal(dr["ORBITID"]);
            model.SATID = Convert.ToDecimal(dr["SATID"]);
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
            model.SAT_TLE1 = Convert.ToString(dr["SAT_TLE1"]);
            model.SAT_TLE2 = Convert.ToString(dr["SAT_TLE2"]);
            model.SCHEMEID = Convert.ToDecimal(dr["SCHEMEID"]);
            return model;
        }

        /// <summary>
        /// 由DbDataReader得到泛型数据列表
        /// </summary>
        private List<CoScheduling.Core.Model.BIGAREA_ORBIT> GetList(DbDataReader dr)
        {
            List<CoScheduling.Core.Model.BIGAREA_ORBIT> lst = new List<CoScheduling.Core.Model.BIGAREA_ORBIT>();
            while (dr.Read())
            {
                lst.Add(GetModel(dr));
            }
            return lst;
        }

        #endregion
    }
}
