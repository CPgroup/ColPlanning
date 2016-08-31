//------------------------------------------------------------------------------
// 创建标识: 董毅博
// 创建描述: 任务方案私有卫星访问类
// 创建时间:2013.6.13
// 文件版本:1.0
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
    public class TASKSCHEME_PRIVATE_SATELLITE
    {
        //数据库连接字符串(web.config来配置)，可以动态更改connectionString支持多数据库.		
        public static string connectionString;
        public TASKSCHEME_PRIVATE_SATELLITE()
        { connectionString = PubConstant.GetConnectionString(""); }
        
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.TASKSCHEME_PRIVATE_SATELLITE model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO LHF.TASKSCHEME_PRIVATE_SATELLITE(");
            strSql.Append("SAT_ID,SAT_NAME,SAT_STKNAME,SAT_TYPE,SAT_ROPAGATOR,SAT_STEP,SAT_COORD,SEMIMAJORAXIS,ECCENTRICITY,INCLINATION,AOP,RAAN,MEANANOMALY,TRUEANOMALY,SCHEMEID)");
            strSql.Append(" VALUES (");
            strSql.Append("@in_SAT_ID,@in_SAT_NAME,@in_SAT_STKNAME,@in_SAT_TYPE,@in_SAT_ROPAGATOR,@in_SAT_STEP,@in_SAT_COORD,@in_SEMIMAJORAXIS,@in_ECCENTRICITY,@in_INCLINATION,@in_AOP,@in_RAAN,@in_MEANANOMALY,@in_TRUEANOMALY,@in_SCHEMEID)");
            SqlParameter[] cmdParms = new SqlParameter[]{
				new SqlParameter("@in_SAT_ID", SqlDbType.Decimal),
				new SqlParameter("@in_SAT_NAME", SqlDbType.NVarChar),
				new SqlParameter("@in_SAT_STKNAME", SqlDbType.NVarChar),
				new SqlParameter("@in_SAT_TYPE", SqlDbType.Decimal),
				new SqlParameter("@in_SAT_ROPAGATOR", SqlDbType.NVarChar),
				new SqlParameter("@in_SAT_STEP", SqlDbType.Decimal),
				new SqlParameter("@in_SAT_COORD", SqlDbType.NVarChar),
				new SqlParameter("@in_SEMIMAJORAXIS", SqlDbType.Decimal),
				new SqlParameter("@in_ECCENTRICITY", SqlDbType.Decimal),
				new SqlParameter("@in_INCLINATION", SqlDbType.Decimal),
				new SqlParameter("@in_AOP", SqlDbType.Decimal),
				new SqlParameter("@in_RAAN", SqlDbType.Decimal),
				new SqlParameter("@in_MEANANOMALY", SqlDbType.Decimal),
				new SqlParameter("@in_TRUEANOMALY", SqlDbType.Decimal),
				new SqlParameter("@in_SCHEMEID", SqlDbType.Decimal)};
            cmdParms[0].Value = model.SAT_ID;
            cmdParms[1].Value = model.SAT_NAME;
            cmdParms[2].Value = model.SAT_STKNAME;
            cmdParms[3].Value = model.SAT_TYPE;
            cmdParms[4].Value = model.SAT_ROPAGATOR;
            cmdParms[5].Value = model.SAT_STEP;
            cmdParms[6].Value = model.SAT_COORD;
            cmdParms[7].Value = model.SEMIMAJORAXIS;
            cmdParms[8].Value = model.ECCENTRICITY;
            cmdParms[9].Value = model.INCLINATION;
            cmdParms[10].Value = model.AOP;
            cmdParms[11].Value = model.RAAN;
            cmdParms[12].Value = model.MEANANOMALY;
            cmdParms[13].Value = model.TRUEANOMALY;
            cmdParms[14].Value = model.SCHEMEID;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Model.TASKSCHEME_PRIVATE_SATELLITE model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE LHF.TASKSCHEME_PRIVATE_SATELLITE SET ");
            strSql.Append("SAT_NAME=@in_SAT_NAME,");
            strSql.Append("SAT_STKNAME=@in_SAT_STKNAME,");
            strSql.Append("SAT_TYPE=@in_SAT_TYPE,");
            strSql.Append("SAT_ROPAGATOR=@in_SAT_ROPAGATOR,");
            strSql.Append("SAT_STEP=@in_SAT_STEP,");
            strSql.Append("SAT_COORD=@in_SAT_COORD,");
            strSql.Append("SEMIMAJORAXIS=@in_SEMIMAJORAXIS,");
            strSql.Append("ECCENTRICITY=@in_ECCENTRICITY,");
            strSql.Append("INCLINATION=@in_INCLINATION,");
            strSql.Append("AOP=@in_AOP,");
            strSql.Append("RAAN=@in_RAAN,");
            strSql.Append("MEANANOMALY=@in_MEANANOMALY,");
            strSql.Append("TRUEANOMALY=@in_TRUEANOMALY,");
            strSql.Append("SCHEMEID=@in_SCHEMEID");
            strSql.Append(" WHERE SAT_ID=@in_SAT_ID");
            SqlParameter[] cmdParms = new SqlParameter[]{
				new SqlParameter("@in_SAT_ID", SqlDbType.Decimal),
				new SqlParameter("@in_SAT_NAME", SqlDbType.NVarChar),
				new SqlParameter("@in_SAT_STKNAME", SqlDbType.NVarChar),
				new SqlParameter("@in_SAT_TYPE", SqlDbType.Decimal),
				new SqlParameter("@in_SAT_ROPAGATOR", SqlDbType.NVarChar),
				new SqlParameter("@in_SAT_STEP", SqlDbType.Decimal),
				new SqlParameter("@in_SAT_COORD", SqlDbType.NVarChar),
				new SqlParameter("@in_SEMIMAJORAXIS", SqlDbType.Decimal),
				new SqlParameter("@in_ECCENTRICITY", SqlDbType.Decimal),
				new SqlParameter("@in_INCLINATION", SqlDbType.Decimal),
				new SqlParameter("@in_AOP", SqlDbType.Decimal),
				new SqlParameter("@in_RAAN", SqlDbType.Decimal),
				new SqlParameter("@in_MEANANOMALY", SqlDbType.Decimal),
				new SqlParameter("@in_TRUEANOMALY", SqlDbType.Decimal),
				new SqlParameter("@in_SCHEMEID", SqlDbType.Decimal)};
            cmdParms[0].Value = model.SAT_ID;
            cmdParms[1].Value = model.SAT_NAME;
            cmdParms[2].Value = model.SAT_STKNAME;
            cmdParms[3].Value = model.SAT_TYPE;
            cmdParms[4].Value = model.SAT_ROPAGATOR;
            cmdParms[5].Value = model.SAT_STEP;
            cmdParms[6].Value = model.SAT_COORD;
            cmdParms[7].Value = model.SEMIMAJORAXIS;
            cmdParms[8].Value = model.ECCENTRICITY;
            cmdParms[9].Value = model.INCLINATION;
            cmdParms[10].Value = model.AOP;
            cmdParms[11].Value = model.RAAN;
            cmdParms[12].Value = model.MEANANOMALY;
            cmdParms[13].Value = model.TRUEANOMALY;
            cmdParms[14].Value = model.SCHEMEID;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(decimal SAT_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM LHF.TASKSCHEME_PRIVATE_SATELLITE ");
            strSql.Append(" WHERE SAT_ID=@in_SAT_ID");
            SqlParameter[] cmdParms = new SqlParameter[]{
				new SqlParameter("@in_SAT_ID", SqlDbType.Decimal)};

            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(decimal SAT_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM LHF.TASKSCHEME_PRIVATE_SATELLITE");
            strSql.Append(" WHERE SAT_ID="+SAT_ID);

            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.TASKSCHEME_PRIVATE_SATELLITE GetModel(decimal SAT_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM LHF.TASKSCHEME_PRIVATE_SATELLITE ");
            strSql.Append(" WHERE SAT_ID="+SAT_ID);
            Model.TASKSCHEME_PRIVATE_SATELLITE model = null;
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
        public List<Model.TASKSCHEME_PRIVATE_SATELLITE> GetList()
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM LHF.TASKSCHEME_PRIVATE_SATELLITE");           
            using (DbDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.TASKSCHEME_PRIVATE_SATELLITE> lst = GetList(dr);
                return lst;
            }
        }

        /// <summary>
        /// 根据schemeid获取泛型数据列表
        /// </summary>
        public List<Model.TASKSCHEME_PRIVATE_SATELLITE> GetList(decimal schemeid)
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM LHF.TASKSCHEME_PRIVATE_SATELLITE");
            strSql.Append(" WHERE SCHEMEID=" + schemeid);
            using (DbDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.TASKSCHEME_PRIVATE_SATELLITE> lst = GetList(dr);
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
            strSql.Append(" FROM LHF.TASKSCHEME_PRIVATE_SATELLITE ");
            if (condition.Trim() != "")
            {
                strSql.Append(" where " + condition);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }


        #region -------- 私有方法，通常情况下无需修改 --------

        /// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        private Model.TASKSCHEME_PRIVATE_SATELLITE GetModel(DbDataReader dr)
        {
            Model.TASKSCHEME_PRIVATE_SATELLITE model = new Model.TASKSCHEME_PRIVATE_SATELLITE();
            model.SAT_ID = Convert.ToDecimal(dr["SAT_ID"]);
            model.SAT_NAME = Convert.ToString(dr["SAT_NAME"]);
            model.SAT_STKNAME = Convert.ToString(dr["SAT_STKNAME"]);
            model.SAT_TYPE = Convert.ToDecimal(dr["SAT_TYPE"]);
            model.SAT_ROPAGATOR = Convert.ToString(dr["SAT_ROPAGATOR"]);
            model.SAT_STEP = Convert.ToDecimal(dr["SAT_STEP"]);
            model.SAT_COORD = Convert.ToString(dr["SAT_COORD"]);
            model.SEMIMAJORAXIS = Convert.ToDecimal(dr["SEMIMAJORAXIS"]);
            model.ECCENTRICITY = Convert.ToDecimal(dr["ECCENTRICITY"]);
            model.INCLINATION = Convert.ToDecimal(dr["INCLINATION"]);
            model.AOP = Convert.ToDecimal(dr["AOP"]);
            model.RAAN = Convert.ToDecimal(dr["RAAN"]);
            model.MEANANOMALY = Convert.ToDecimal(dr["MEANANOMALY"]);
            model.TRUEANOMALY = Convert.ToDecimal(dr["TRUEANOMALY"]);
            model.SCHEMEID = Convert.ToDecimal(dr["SCHEMEID"]);
            return model;
        }

        /// <summary>
        /// 由DbDataReader得到泛型数据列表
        /// </summary>
        private List<Model.TASKSCHEME_PRIVATE_SATELLITE> GetList(DbDataReader dr)
        {
            List<Model.TASKSCHEME_PRIVATE_SATELLITE> lst = new List<Model.TASKSCHEME_PRIVATE_SATELLITE>();
            while (dr.Read())
            {
                lst.Add(GetModel(dr));
            }
            return lst;
        }

        #endregion
    }
}
