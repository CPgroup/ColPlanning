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
    public class BIGAREA_SENSOR
    {
        //数据库连接字符串(web.config来配置)，可以动态更改connectionString支持多数据库.		
        public static string connectionString;
        public BIGAREA_SENSOR()
        { connectionString = PubConstant.GetConnectionString(""); }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CoScheduling.Core.Model.BIGAREA_SENSOR model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO BIGAREA_SENSOR(");
            strSql.Append("SENSORID,SATID,SCHEMEID)");
            strSql.Append(" VALUES (");
            strSql.Append("@in_SENSORID,@in_SATID,@in_SCHEMEID)");
            SqlParameter[] cmdParms = new SqlParameter[]{
				new SqlParameter("@in_SENSORID", SqlDbType.Decimal),
				new SqlParameter("@in_SATID", SqlDbType.Decimal),
				new SqlParameter("@in_SCHEMEID", SqlDbType.Decimal)};
            cmdParms[0].Value = model.SENSORID;
            cmdParms[1].Value = model.SATID;
            cmdParms[2].Value = model.SCHEMEID;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(CoScheduling.Core.Model.BIGAREA_SENSOR model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE BIGAREA_SENSOR SET ");
            strSql.Append("SENSORID=@in_SENSORID,");
            strSql.Append("SATID=@in_SATID,");
            strSql.Append("SCHEMEID=@in_SCHEMEID");
            strSql.Append(" WHERE SATSENSORID=@in_SATSENSORID");
            SqlParameter[] cmdParms = new SqlParameter[]{
				new SqlParameter("@in_SENSORID", SqlDbType.Decimal),
				new SqlParameter("@in_SATID", SqlDbType.Decimal),
				new SqlParameter("@in_SCHEMEID",SqlDbType.Decimal),
				new SqlParameter("@in_SATSENSORID",SqlDbType.Decimal)};
            cmdParms[0].Value = model.SENSORID;
            cmdParms[1].Value = model.SATID;
            cmdParms[2].Value = model.SCHEMEID;
            cmdParms[3].Value = model.SATSENSORID;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(decimal SATSENSORID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM BIGAREA_SENSOR ");
            strSql.Append(" WHERE SATSENSORID=@in_SATSENSORID");
            SqlParameter[] cmdParms = new SqlParameter[]{
				new SqlParameter("@in_SATSENSORID", SqlDbType.Decimal)};
            cmdParms[0].Value = SATSENSORID;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(decimal SATSENSORID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM BIGAREA_SENSOR");
            strSql.Append(" WHERE SATSENSORID=@in_SATSENSORID");
            SqlParameter[] cmdParms = new SqlParameter[]{
				new SqlParameter("@in_SATSENSORID", SqlDbType.Decimal)};
            cmdParms[0].Value = SATSENSORID;
            return DbHelperSQL.Exists(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CoScheduling.Core.Model.BIGAREA_SENSOR GetModel(decimal SATSENSORID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM BIGAREA_SENSOR ");
            strSql.Append(" WHERE SATSENSORID=" + SATSENSORID);
            CoScheduling.Core.Model.BIGAREA_SENSOR model = new CoScheduling.Core.Model.BIGAREA_SENSOR();
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
        public List<CoScheduling.Core.Model.BIGAREA_SENSOR> GetList()
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM BIGAREA_SENSOR");
            using (DbDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<CoScheduling.Core.Model.BIGAREA_SENSOR> lst = GetList(dr);
                return lst;
            }
        }
        public List<CoScheduling.Core.Model.BIGAREA_SENSOR> GetList(string condition)
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM BIGAREA_SENSOR");
            if (condition.Trim() != "")
            {
                strSql.Append(" where " + condition);
            }
            using (DbDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<CoScheduling.Core.Model.BIGAREA_SENSOR> lst = GetList(dr);
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
            strSql.Append(" FROM BIGAREA_SENSOR ");
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
            strSql.Append("DELETE FROM BIGAREA_SENSOR ");
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
        private CoScheduling.Core.Model.BIGAREA_SENSOR GetModel(DbDataReader dr)
        {
            CoScheduling.Core.Model.BIGAREA_SENSOR model = new CoScheduling.Core.Model.BIGAREA_SENSOR();
            model.SATSENSORID = Convert.ToDecimal(dr["SATSENSORID"]);
            model.SENSORID = Convert.ToDecimal(dr["SENSORID"]);
            model.SATID = Convert.ToDecimal(dr["SATID"]);
            model.SCHEMEID = Convert.ToDecimal(dr["SCHEMEID"]);
            return model;
        }

        /// <summary>
        /// 由DbDataReader得到泛型数据列表
        /// </summary>
        private List<CoScheduling.Core.Model.BIGAREA_SENSOR> GetList(DbDataReader dr)
        {
            List<CoScheduling.Core.Model.BIGAREA_SENSOR> lst = new List<CoScheduling.Core.Model.BIGAREA_SENSOR>();
            while (dr.Read())
            {
                lst.Add(GetModel(dr));
            }
            return lst;
        }

        #endregion

    }
}
