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
    public class BIGAREA_SCHEME
    {
        //数据库连接字符串(web.config来配置)，可以动态更改connectionString支持多数据库.		
        public static string connectionString;
        public BIGAREA_SCHEME()
        { connectionString = PubConstant.GetConnectionString(""); }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CoScheduling.Core.Model.BIGAREA_SCHEME model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO BIGAREA_SCHEME(");
            strSql.Append("SCHEMENAME,SCHEMEBTIME,SCHEMEETIME)");
            strSql.Append(" VALUES (");
            strSql.Append("@in_SCHEMENAME,@in_SCHEMEBTIME,@in_SCHEMEETIME)");
            SqlParameter[] cmdParms = new SqlParameter[]{
				new SqlParameter("@in_SCHEMENAME", SqlDbType.NVarChar),
				new SqlParameter("@in_SCHEMEBTIME", SqlDbType.DateTime),
				new SqlParameter("@in_SCHEMEETIME", SqlDbType.DateTime)};
            cmdParms[0].Value = model.SCHEMENAME;
            cmdParms[1].Value = model.SCHEMEBTIME;
            cmdParms[2].Value = model.SCHEMEETIME;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(CoScheduling.Core.Model.BIGAREA_SCHEME model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE BIGAREA_SCHEME SET ");
            strSql.Append("SCHEMENAME=@in_SCHEMENAME,");
            strSql.Append("SCHEMEBTIME=@in_SCHEMEBTIME,");
            strSql.Append("SCHEMEETIME=@in_SCHEMEETIME");
            strSql.Append(" WHERE SCHEMEID=@in_SCHEMEID");
            SqlParameter[] cmdParms = new SqlParameter[]{
				new SqlParameter("@in_SCHEMENAME", SqlDbType.NVarChar),
				new SqlParameter("@in_SCHEMEBTIME", SqlDbType.DateTime),
				new SqlParameter("@in_SCHEMEETIME", SqlDbType.DateTime),
				new SqlParameter("@in_SCHEMEID", SqlDbType.Decimal)};
            cmdParms[0].Value = model.SCHEMENAME;
            cmdParms[1].Value = model.SCHEMEBTIME;
            cmdParms[2].Value = model.SCHEMEETIME;
            cmdParms[3].Value = model.SCHEMEID;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(decimal SCHEMEID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM BIGAREA_SCHEME ");
            strSql.Append(" WHERE SCHEMEID=@in_SCHEMEID");
            SqlParameter[] cmdParms = new SqlParameter[] {
				new SqlParameter("@in_SCHEMEID", SqlDbType.Decimal)};
            cmdParms[0].Value = SCHEMEID;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(decimal SCHEMEID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM BIGAREA_SCHEME");
            strSql.Append(" WHERE SCHEMEID=@in_SCHEMEID");
            SqlParameter[] cmdParms = new SqlParameter[] {
				new SqlParameter("@in_SCHEMEID", SqlDbType.Decimal)};
            cmdParms[0].Value = SCHEMEID;
            return DbHelperSQL.Exists(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CoScheduling.Core.Model.BIGAREA_SCHEME GetModel(decimal SCHEMEID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM BIGAREA_SCHEME ");
            strSql.Append(" WHERE SCHEMEID=" + SCHEMEID);
            CoScheduling.Core.Model.BIGAREA_SCHEME model = new CoScheduling.Core.Model.BIGAREA_SCHEME();
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
        public List<CoScheduling.Core.Model.BIGAREA_SCHEME> GetList()
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM BIGAREA_SCHEME");
            using (DbDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<CoScheduling.Core.Model.BIGAREA_SCHEME> lst = GetList(dr);
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
            strSql.Append(" FROM BIGAREA_SCHEME ");
            if (condition.Trim() != "")
            {
                strSql.Append(" where " + condition);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }

        /// <summary>
        /// 得到最新schemeid
        /// </summary>
        public int GetLatestSchemeid()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT MAX(SCHEMEID) ");
            strSql.Append(" FROM BIGAREA_SCHEME ");
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }
        #region -------- 私有方法，通常情况下无需修改 --------

        /// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        private CoScheduling.Core.Model.BIGAREA_SCHEME GetModel(DbDataReader dr)
        {
            CoScheduling.Core.Model.BIGAREA_SCHEME model = new CoScheduling.Core.Model.BIGAREA_SCHEME();
            model.SCHEMEID = Convert.ToInt32(dr["SCHEMEID"]);
            model.SCHEMENAME = Convert.ToString(dr["SCHEMENAME"]);
            model.SCHEMEBTIME = Convert.ToDateTime(dr["SCHEMEBTIME"]);
            model.SCHEMEETIME = Convert.ToDateTime(dr["SCHEMEETIME"]);
            return model;
        }

        /// <summary>
        /// 由DbDataReader得到泛型数据列表
        /// </summary>
        private List<CoScheduling.Core.Model.BIGAREA_SCHEME> GetList(DbDataReader dr)
        {
            List<CoScheduling.Core.Model.BIGAREA_SCHEME> lst = new List<CoScheduling.Core.Model.BIGAREA_SCHEME>();
            while (dr.Read())
            {
                lst.Add(GetModel(dr));
            }
            return lst;
        }

        #endregion
    }
}
