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
    public class T_PUB_SATELLITEPARA
    {
        //数据库连接字符串(web.config来配置)，可以动态更改connectionString支持多数据库.		
        public static string connectionString;
        public T_PUB_SATELLITEPARA()
        { connectionString = PubConstant.GetConnectionString(""); }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.T_PUB_SATELLITEPARA model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO LHF.T_PUB_SATELLITEPARA(");
            strSql.Append("SAT_ID,SAT_STKNAME,MAXGSD,OPENCLOSETIME,WORKLASTTIME,SATANGLE,SATANGLEH,SENSOR_ID,SENSOR_STKNAME)");
            strSql.Append(" VALUES (");
            strSql.Append("@in_SAT_ID,@in_SAT_STKNAME,@in_MAXGSD,@in_OPENCLOSETIME,@in_WORKLASTTIME,@in_SATANGLE,@in_SATANGLEH,@in_SENSOR_ID,@in_SENSOR_STKNAME)");
            SqlParameter[] cmdParms = new SqlParameter[]{
				new SqlParameter("@in_SAT_ID", SqlDbType.Decimal),
				new SqlParameter("@in_SAT_STKNAME", SqlDbType.NVarChar),
				new SqlParameter("@in_MAXGSD", SqlDbType.Decimal),
				new SqlParameter("@in_OPENCLOSETIME", SqlDbType.Decimal),
				new SqlParameter("@in_WORKLASTTIME", SqlDbType.Decimal),
				new SqlParameter("@in_SATANGLE", SqlDbType.Decimal),
				new SqlParameter("@in_SATANGLEH", SqlDbType.Decimal),
				new SqlParameter("@in_SENSOR_ID", SqlDbType.Decimal),
				new SqlParameter("@in_SENSOR_STKNAME", SqlDbType.NVarChar)};
            cmdParms[0].Value = model.SAT_ID;
            cmdParms[1].Value = model.SAT_STKNAME;
            cmdParms[2].Value = model.MAXGSD;
            cmdParms[3].Value = model.OPENCLOSETIME;
            cmdParms[4].Value = model.WORKLASTTIME;
            cmdParms[5].Value = model.SATANGLE;
            cmdParms[6].Value = model.SATANGLEH;
            cmdParms[7].Value = model.SENSOR_ID;
            cmdParms[8].Value = model.SENSOR_STKNAME;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Model.T_PUB_SATELLITEPARA model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE LHF.T_PUB_SATELLITEPARA SET ");
            strSql.Append("SAT_STKNAME=@in_SAT_STKNAME,");
            strSql.Append("MAXGSD=@in_MAXGSD,");
            strSql.Append("OPENCLOSETIME=@in_OPENCLOSETIME,");
            strSql.Append("WORKLASTTIME=@in_WORKLASTTIME,");
            strSql.Append("SATANGLE=@in_SATANGLE,");
            strSql.Append("SATANGLEH=@in_SATANGLEH,");
            strSql.Append("SENSOR_ID=@in_SENSOR_ID,");
            strSql.Append("SENSOR_STKNAME=@in_SENSOR_STKNAME");
            strSql.Append(" WHERE SAT_ID=@in_SAT_ID");
            SqlParameter[] cmdParms = new SqlParameter[]{
				new SqlParameter("@in_SAT_ID", SqlDbType.Decimal),
				new SqlParameter("@in_SAT_STKNAME", SqlDbType.NVarChar),
				new SqlParameter("@in_MAXGSD", SqlDbType.Decimal),
				new SqlParameter("@in_OPENCLOSETIME", SqlDbType.Decimal),
				new SqlParameter("@in_WORKLASTTIME", SqlDbType.Decimal),
				new SqlParameter("@in_SATANGLE", SqlDbType.Decimal),
				new SqlParameter("@in_SATANGLEH", SqlDbType.Decimal),
				new SqlParameter("@in_SENSOR_ID", SqlDbType.Decimal),
				new SqlParameter("@in_SENSOR_STKNAME", SqlDbType.NVarChar)};
            cmdParms[0].Value = model.SAT_ID;
            cmdParms[1].Value = model.SAT_STKNAME;
            cmdParms[2].Value = model.MAXGSD;
            cmdParms[3].Value = model.OPENCLOSETIME;
            cmdParms[4].Value = model.WORKLASTTIME;
            cmdParms[5].Value = model.SATANGLE;
            cmdParms[6].Value = model.SATANGLEH;
            cmdParms[7].Value = model.SENSOR_ID;
            cmdParms[8].Value = model.SENSOR_STKNAME;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(decimal SAT_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM LHF.T_PUB_SATELLITEPARA ");
            strSql.Append(" WHERE SAT_ID"+SAT_ID);

            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 删除所有数据
        /// </summary>
        public int Clear()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM LHF.T_PUB_SATELLITEPARA ");

            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 删除所有数据
        /// </summary>
        public int Reset()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO LHF.T_PUB_SATELLITEPARA(SENSOR_ID,SENSOR_STKNAME,SAT_ID,SAT_STKNAME,MAXGSD,OPENCLOSETIME,WORKLASTTIME,SATANGLE,SATANGLEH) ");
            strSql.Append("SELECT  A.SENSOR_ID,A.SENSOR_NAME,A.SAT_ID,A.SAT_NAME,A.MAXGSD,30,30,B.ATANVALUE,B.AVGH FROM LHF.SATELLITE_SENSOR A,LHF.SATELLITE_SENSOR_FOV B WHERE A.SENSOR_ID=B.SENSOR_ID");
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(decimal SAT_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM LHF.T_PUB_SATELLITEPARA");
            strSql.Append(" WHERE SAT_ID="+SAT_ID);

            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.T_PUB_SATELLITEPARA GetModel(decimal SENSOR_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM LHF.T_PUB_SATELLITEPARA ");
            strSql.Append(" WHERE SENSOR_ID=" + SENSOR_ID);
            Model.T_PUB_SATELLITEPARA model = null;
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
        public List<Model.T_PUB_SATELLITEPARA> GetList()
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM LHF.T_PUB_SATELLITEPARA");
            using (DbDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.T_PUB_SATELLITEPARA> lst = GetList(dr);
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
            strSql.Append(" FROM LHF.T_PUB_SATELLITEPARA ");
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
        private Model.T_PUB_SATELLITEPARA GetModel(DbDataReader dr)
        {
            Model.T_PUB_SATELLITEPARA model = new Model.T_PUB_SATELLITEPARA();
            model.SAT_ID = Convert.ToDecimal(dr["SAT_ID"]);
            model.SAT_STKNAME = Convert.ToString(dr["SAT_STKNAME"]);
            model.MAXGSD = Convert.ToDecimal(dr["MAXGSD"]);
            model.OPENCLOSETIME = Convert.ToDecimal(dr["OPENCLOSETIME"]);
            model.WORKLASTTIME = Convert.ToDecimal(dr["WORKLASTTIME"]);
            model.SATANGLE = Convert.ToDecimal(dr["SATANGLE"]);
            model.SATANGLEH = Convert.ToDecimal(dr["SATANGLEH"]);
            model.SENSOR_ID = Convert.ToDecimal(dr["SENSOR_ID"]);
            model.SENSOR_STKNAME = Convert.ToString(dr["SENSOR_STKNAME"]);
            return model;
        }

        /// <summary>
        /// 由DbDataReader得到泛型数据列表
        /// </summary>
        private List<Model.T_PUB_SATELLITEPARA> GetList(DbDataReader dr)
        {
            List<Model.T_PUB_SATELLITEPARA> lst = new List<Model.T_PUB_SATELLITEPARA>();
            while (dr.Read())
            {
                lst.Add(GetModel(dr));
            }
            return lst;
        }

        #endregion
    }
}
