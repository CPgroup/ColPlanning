using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Common;
using System.Collections.Generic;
using System.IO;
using System.Drawing;

namespace CoScheduling.Core.DAL
{
    /// <summary>
    /// 数据访问类 BIGAREA_TARGET
    /// </summary>
    public class BIGAREA_TARGET
    {
        //数据库连接字符串(web.config来配置)，可以动态更改connectionString支持多数据库.		
        public static string connectionString;
        public BIGAREA_TARGET()
        { connectionString = CoScheduling.Core.DBUtility.PubConstant.GetConnectionString(""); }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CoScheduling.Core.Model.BIGAREA_TARGET model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO BIGAREA_TARGET(");
            strSql.Append("TARGETNAME,TARGETLAT,TARGETLON,SCHEMEID)");
            strSql.Append(" VALUES (");
            strSql.Append("@in_TARGETNAME,@in_TARGETLAT,@in_TARGETLON,@in_SCHEMEID)");
            SqlParameter[] cmdParms = new SqlParameter[]{
				new SqlParameter("@in_TARGETNAME", SqlDbType.NVarChar),
				new SqlParameter("@in_TARGETLAT", SqlDbType.Decimal),
				new SqlParameter("@in_TARGETLON", SqlDbType.Decimal),
				new SqlParameter("@in_SCHEMEID", SqlDbType.Decimal)};
            cmdParms[0].Value = model.TARGETNAME;
            cmdParms[1].Value = model.TARGETLAT;
            cmdParms[2].Value = model.TARGETLON;
            cmdParms[3].Value = model.SCHEMEID;
            return CoScheduling.Core.DBUtility.DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(CoScheduling.Core.Model.BIGAREA_TARGET model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE BIGAREA_TARGET SET ");
            strSql.Append("TARGETNAME=@in_TARGETNAME,");
            strSql.Append("TARGETLAT=@in_TARGETLAT,");
            strSql.Append("TARGETLON=@in_TARGETLON,");
            strSql.Append("SCHEMEID=@in_SCHEMEID");
            strSql.Append(" WHERE TARGETID=@in_TARGETID");
            SqlParameter[] cmdParms = new SqlParameter[]{
				new SqlParameter("@in_TARGETNAME", SqlDbType.NVarChar),
				new SqlParameter("@in_TARGETLAT", SqlDbType.Decimal),
				new SqlParameter("@in_TARGETLON", SqlDbType.Decimal),
				new SqlParameter("@in_SCHEMEID", SqlDbType.Decimal),
				new SqlParameter("@in_TARGETID", SqlDbType.Decimal)};
            cmdParms[0].Value = model.TARGETNAME;
            cmdParms[1].Value = model.TARGETLAT;
            cmdParms[2].Value = model.TARGETLON;
            cmdParms[3].Value = model.SCHEMEID;
            cmdParms[4].Value = model.TARGETID;
            return CoScheduling.Core.DBUtility.DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(decimal TARGETID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM BIGAREA_TARGET ");
            strSql.Append(" WHERE TARGETID=@in_TARGETID");
            SqlParameter[] cmdParms = new SqlParameter[]{
				new SqlParameter("@in_TARGETID",SqlDbType.Decimal)};
            cmdParms[0].Value = TARGETID;
            //return CoScheduling.Core.DBUtility.DbHelperSQL
            return CoScheduling.Core.DBUtility.DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int DeleteScheme(decimal SCHEMEID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM BIGAREA_TARGET ");
            strSql.Append(" WHERE SCHEMEID=@in_SCHEMEID");
            SqlParameter[] cmdParms = new SqlParameter[]{
				new SqlParameter("@in_SCHEMEID",SqlDbType.Decimal)};
            cmdParms[0].Value = SCHEMEID;
            return CoScheduling.Core.DBUtility.DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(decimal TARGETID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM BIGAREA_TARGET");
            strSql.Append(" WHERE TARGETID=@in_TARGETID");
            SqlParameter[] cmdParms = new SqlParameter[]{
				new SqlParameter("@in_TARGETID",SqlDbType.Decimal)};
            cmdParms[0].Value = TARGETID;
            return CoScheduling.Core.DBUtility.DbHelperSQL.Exists(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CoScheduling.Core.Model.BIGAREA_TARGET GetModel(decimal TARGETID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM BIGAREA_TARGET ");
            strSql.Append(" WHERE TARGETID=" + TARGETID);
            CoScheduling.Core.Model.BIGAREA_TARGET model = new CoScheduling.Core.Model.BIGAREA_TARGET();
            using (DbDataReader dr = CoScheduling.Core.DBUtility.DbHelperSQL.ExecuteReader(strSql.ToString()))
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
        public List<CoScheduling.Core.Model.BIGAREA_TARGET> GetList()
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM BIGAREA_TARGET");
            using (DbDataReader dr = CoScheduling.Core.DBUtility.DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<CoScheduling.Core.Model.BIGAREA_TARGET> lst = GetList(dr);
                return lst;
            }
        }
        public List<CoScheduling.Core.Model.BIGAREA_TARGET> GetList(string condition)
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM BIGAREA_TARGET");
            if (condition.Trim() != "")
            {
                strSql.Append(" where " + condition);
            }
            using (DbDataReader dr = CoScheduling.Core.DBUtility.DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<CoScheduling.Core.Model.BIGAREA_TARGET> lst = GetList(dr);
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
            strSql.Append(" FROM BIGAREA_TARGET ");
            if (condition.Trim() != "")
            {
                strSql.Append(" where " + condition);
            }
            return Convert.ToInt32(CoScheduling.Core.DBUtility.DbHelperSQL.GetSingle(strSql.ToString()));
        }


        #region -------- 私有方法，通常情况下无需修改 --------

        /// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        private CoScheduling.Core.Model.BIGAREA_TARGET GetModel(DbDataReader dr)
        {
            CoScheduling.Core.Model.BIGAREA_TARGET model = new CoScheduling.Core.Model.BIGAREA_TARGET();
            model.TARGETID = Convert.ToInt32(dr["TARGETID"]);
            model.TARGETNAME = Convert.ToString(dr["TARGETNAME"]);
            model.TARGETLAT = Convert.ToDecimal(dr["TARGETLAT"]);
            model.TARGETLON = Convert.ToDecimal(dr["TARGETLON"]);
            model.SCHEMEID = Convert.ToInt32(dr["SCHEMEID"]);
            return model;
        }

        /// <summary>
        /// 由DbDataReader得到泛型数据列表
        /// </summary>
        private List<CoScheduling.Core.Model.BIGAREA_TARGET> GetList(DbDataReader dr)
        {
            List<CoScheduling.Core.Model.BIGAREA_TARGET> lst = new List<CoScheduling.Core.Model.BIGAREA_TARGET>();
            while (dr.Read())
            {
                lst.Add(GetModel(dr));
            }
            return lst;
        }

        #endregion
    
    }
}
