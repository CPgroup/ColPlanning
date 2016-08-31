//------------------------------------------------------------------------------
// 创建标识: 董毅博
// 创建描述: 卫星载荷公共资源访问类
// 创建时间:2014.7.20
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
    public class T_PUB_SENSOR
    {
        //数据库连接字符串(web.config来配置)，可以动态更改connectionString支持多数据库.		
        public static string connectionString;
        public T_PUB_SENSOR()
        {
            connectionString = PubConstant.GetConnectionString("");
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.T_PUB_SENSOR model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO LHF.T_PUB_SENSOR(");
            strSql.Append("SENSOR_ID,SENSOR_NAME,SENSOR_STKNAME,SAT_ID,SAT_STKNAME,SENSOR_TYPE,SENSOR_PARONE,SENSOR_PARTWO,SENSOR_PARTHREE,SENSOR_PARFOUR,TYPEID,SATTYPE,SENSORANGLE,SENSORANGLEH)");
            strSql.Append(" VALUES (");
            strSql.Append("@in_SENSOR_ID,@in_SENSOR_NAME,@in_SENSOR_STKNAME,@in_SAT_ID,@in_SAT_STKNAME,@in_SENSOR_TYPE,@in_SENSOR_PARONE,@in_SENSOR_PARTWO,@in_SENSOR_PARTHREE,@in_SENSOR_PARFOUR,@in_TYPEID,@in_SATTYPE,@in_SENSORANGLE,@in_SENSORANGLEH)");
            SqlParameter[] cmdParms = new SqlParameter[] {
				new SqlParameter("@in_SENSOR_ID", DbType.Decimal),
				new SqlParameter("@in_SENSOR_NAME", DbType.AnsiString),
				new SqlParameter("@in_SENSOR_STKNAME", DbType.AnsiString),
				new SqlParameter("@in_SAT_ID", DbType.Decimal),
				new SqlParameter("@in_SAT_STKNAME", DbType.AnsiString),
				new SqlParameter("@in_SENSOR_TYPE", DbType.AnsiString),
				new SqlParameter("@in_SENSOR_PARONE", DbType.Decimal),
				new SqlParameter("@in_SENSOR_PARTWO", DbType.Decimal),
				new SqlParameter("@in_SENSOR_PARTHREE", DbType.Decimal),
				new SqlParameter("@in_SENSOR_PARFOUR", DbType.Decimal),
				new SqlParameter("@in_TYPEID", DbType.Decimal),
				new SqlParameter("@in_SATTYPE", DbType.Decimal),
				new SqlParameter("@in_SENSORANGLE", DbType.Decimal),
				new SqlParameter("@in_SENSORANGLEH", DbType.Decimal)};
            cmdParms[0].Value = model.SENSOR_ID;
            cmdParms[1].Value = model.SENSOR_NAME;
            cmdParms[2].Value = model.SENSOR_STKNAME;
            cmdParms[3].Value = model.SAT_ID;
            cmdParms[4].Value = model.SAT_STKNAME;
            cmdParms[5].Value = model.SENSOR_TYPE;
            cmdParms[6].Value = model.SENSOR_PARONE;
            cmdParms[7].Value = model.SENSOR_PARTWO;
            cmdParms[8].Value = model.SENSOR_PARTHREE;
            cmdParms[9].Value = model.SENSOR_PARFOUR;
            cmdParms[10].Value = model.TYPEID;
            cmdParms[11].Value = model.SATTYPE;
            cmdParms[12].Value = model.SENSORANGLE;
            cmdParms[13].Value = model.SENSORANGLEH;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Model.T_PUB_SENSOR model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE LHF.T_PUB_SENSOR SET ");
            strSql.Append("SENSOR_NAME=@in_SENSOR_NAME,");
            strSql.Append("SENSOR_STKNAME=@in_SENSOR_STKNAME,");
            strSql.Append("SAT_ID=@in_SAT_ID,");
            strSql.Append("SAT_STKNAME=@in_SAT_STKNAME,");
            strSql.Append("SENSOR_TYPE=@in_SENSOR_TYPE,");
            strSql.Append("SENSOR_PARONE=@in_SENSOR_PARONE,");
            strSql.Append("SENSOR_PARTWO=@in_SENSOR_PARTWO,");
            strSql.Append("SENSOR_PARTHREE=@in_SENSOR_PARTHREE,");
            strSql.Append("SENSOR_PARFOUR=@in_SENSOR_PARFOUR,");
            strSql.Append("TYPEID=@in_TYPEID,");
            strSql.Append("SATTYPE=@in_SATTYPE,");
            strSql.Append("SENSORANGLE=@in_SENSORANGLE,");
            strSql.Append("SENSORANGLEH=@in_SENSORANGLEH");
            strSql.Append(" WHERE SENSOR_ID=@in_SENSOR_ID");
            SqlParameter[] cmdParms = new SqlParameter[] {
				new SqlParameter("@in_SENSOR_ID", DbType.Decimal),
				new SqlParameter("@in_SENSOR_NAME", DbType.AnsiString),
				new SqlParameter("@in_SENSOR_STKNAME", DbType.AnsiString),
				new SqlParameter("@in_SAT_ID", DbType.Decimal),
				new SqlParameter("@in_SAT_STKNAME", DbType.AnsiString),
				new SqlParameter("@in_SENSOR_TYPE", DbType.AnsiString),
				new SqlParameter("@in_SENSOR_PARONE", DbType.Decimal),
				new SqlParameter("@in_SENSOR_PARTWO", DbType.Decimal),
				new SqlParameter("@in_SENSOR_PARTHREE", DbType.Decimal),
				new SqlParameter("@in_SENSOR_PARFOUR", DbType.Decimal),
				new SqlParameter("@in_TYPEID", DbType.Decimal),
				new SqlParameter("@in_SATTYPE", DbType.Decimal),
				new SqlParameter("@in_SENSORANGLE", DbType.Decimal),
				new SqlParameter("@in_SENSORANGLEH", DbType.Decimal)};
            cmdParms[0].Value = model.SENSOR_ID;
            cmdParms[1].Value = model.SENSOR_NAME;
            cmdParms[2].Value = model.SENSOR_STKNAME;
            cmdParms[3].Value = model.SAT_ID;
            cmdParms[4].Value = model.SAT_STKNAME;
            cmdParms[5].Value = model.SENSOR_TYPE;
            cmdParms[6].Value = model.SENSOR_PARONE;
            cmdParms[7].Value = model.SENSOR_PARTWO;
            cmdParms[8].Value = model.SENSOR_PARTHREE;
            cmdParms[9].Value = model.SENSOR_PARFOUR;
            cmdParms[10].Value = model.TYPEID;
            cmdParms[11].Value = model.SATTYPE;
            cmdParms[12].Value = model.SENSORANGLE;
            cmdParms[13].Value = model.SENSORANGLEH;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(decimal SENSOR_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM LHF.T_PUB_SENSOR ");
            strSql.Append(" WHERE SENSOR_ID="+SENSOR_ID);
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Clear()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM LHF.T_PUB_SENSOR ");

            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Reset()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO LHF.T_PUB_SENSOR(SENSOR_ID,SENSOR_NAME,SENSOR_STKNAME,SAT_ID,SAT_STKNAME,SENSOR_TYPE,SENSOR_PARONE,SENSOR_PARTWO,SENSOR_PARTHREE,SENSOR_PARFOUR,TYPEID,SATTYPE,SENSORANGLE,SENSORANGLEH) ");
            strSql.Append("SELECT A.SENSOR_ID,A.SENSOR_NAME,A.SENSOR_NAME,A.SAT_ID,A.SAT_NAME,'Rectangular',A.FOV+A.ACROSSPOINTINGRANGE+A.INCLINATION,A.FOV,A.ACROSSPOINTINGRANGE,A.ACROSSPOINTINGRANGE+A.INCLINATION,2,A.SENSOR_TYPE,B.ATANVALUE,B.AVGH FROM LHF.SATELLITE_SENSOR A, LHF.SATELLITE_SENSOR_FOV B WHERE A.SENSOR_ID=B.SENSOR_ID ");
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(decimal SENSOR_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM LHF.T_PUB_SENSOR");
            strSql.Append(" WHERE SENSOR_ID=@in_SENSOR_ID");
            SqlParameter[] cmdParms = new SqlParameter[] {
				new SqlParameter("@in_SENSOR_ID", DbType.Decimal)};
            cmdParms[0].Value = SENSOR_ID;
            return DbHelperSQL.Exists(strSql.ToString(),cmdParms);

        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.T_PUB_SENSOR GetModel(decimal SENSOR_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM LHF.T_PUB_SENSOR ");
            strSql.Append(" WHERE SENSOR_ID=@in_SENSOR_ID");
            SqlParameter[] cmdParms = new SqlParameter[] {
				new SqlParameter("@in_SENSOR_ID", DbType.Decimal)};
            cmdParms[0].Value = SENSOR_ID;
            Model.T_PUB_SENSOR model = null;
            using (DbDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString(), cmdParms))
            {
                while (dr.Read())
                {
                    model = GetModel(dr);
                }
                return model;
            }
        }


        /// <summary>
        /// 得到数据条数
        /// </summary>
        public int GetCount(string condition)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT (*) ");
            strSql.Append(" FROM LHF.T_PUB_SENSOR ");
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
        private Model.T_PUB_SENSOR GetModel(DbDataReader dr)
        {
            Model.T_PUB_SENSOR model = new Model.T_PUB_SENSOR();
            model.SENSOR_ID = Convert.ToDecimal(dr["SENSOR_ID"]);
            model.SENSOR_NAME = Convert.ToString(dr["SENSOR_NAME"]);
            model.SENSOR_STKNAME = Convert.ToString(dr["SENSOR_STKNAME"]);
            model.SAT_ID = Convert.ToDecimal(dr["SAT_ID"]);
            model.SAT_STKNAME = Convert.ToString(dr["SAT_STKNAME"]);
            model.SENSOR_TYPE = Convert.ToString(dr["SENSOR_TYPE"]);
            model.SENSOR_PARONE = Convert.ToDecimal(dr["SENSOR_PARONE"]);
            model.SENSOR_PARTWO = Convert.ToDecimal(dr["SENSOR_PARTWO"]);
            model.SENSOR_PARTHREE = Convert.ToDecimal(dr["SENSOR_PARTHREE"]);
            model.SENSOR_PARFOUR = Convert.ToDecimal(dr["SENSOR_PARFOUR"]);
            model.TYPEID = Convert.ToDecimal(dr["TYPEID"]);
            model.SATTYPE = Convert.ToDecimal(dr["SATTYPE"]);
            model.SENSORANGLE = Convert.ToDecimal(dr["SENSORANGLE"]);
            model.SENSORANGLEH = Convert.ToDecimal(dr["SENSORANGLEH"]);
            return model;
        }

        /// <summary>
        /// 由DbDataReader得到泛型数据列表
        /// </summary>
        private List<Model.T_PUB_SENSOR> GetList(DbDataReader dr)
        {
            List<Model.T_PUB_SENSOR> lst = new List<Model.T_PUB_SENSOR>();
            while (dr.Read())
            {
                lst.Add(GetModel(dr));
            }
            return lst;
        }

        #endregion
    }
}
