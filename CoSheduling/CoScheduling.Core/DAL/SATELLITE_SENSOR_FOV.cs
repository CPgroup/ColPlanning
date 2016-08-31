//------------------------------------------------------------------------------
// 创建标识: 董毅博
// 创建描述: 卫星载荷视场角访问类
// 创建时间:2014.7.20
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
    /// <summary>
    /// 访问类 SATELLITE_SENSOR_FOV
    /// </summary>
    public class SATELLITE_SENSOR_FOV
    {

        //数据库连接字符串(web.config来配置)，可以动态更改connectionString支持多数据库.		
        public static string connectionString;
        public SATELLITE_SENSOR_FOV()
        {
            connectionString = PubConstant.GetConnectionString("");
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.SATELLITE_SENSOR_FOV model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO LHF.SATELLITE_SENSOR_FOV(");
            strSql.Append("SENSOR_ID,SENSOR_NAME,SAT_ID,SAT_NAME,SWATHWIDTH,AVGH,TANVALUE,ATANVALUE)");
            strSql.Append(" VALUES (");
            strSql.Append("@in_SENSOR_ID,@in_SENSOR_NAME,@in_SAT_ID,@in_SAT_NAME,@in_SWATHWIDTH,@in_AVGH,@in_TANVALUE,@in_ATANVALUE)");
            SqlParameter[] cmdParms = new SqlParameter[]{
				new SqlParameter("@in_SENSOR_ID", SqlDbType.Decimal),
				new SqlParameter("@in_SENSOR_NAME", SqlDbType.NVarChar),
				new SqlParameter("@in_SAT_ID", SqlDbType.Decimal),
				new SqlParameter("@in_SAT_NAME", SqlDbType.NVarChar),
				new SqlParameter("@in_SWATHWIDTH", SqlDbType.Decimal),
				new SqlParameter("@in_AVGH", SqlDbType.Decimal),
				new SqlParameter("@in_TANVALUE", SqlDbType.Decimal),
				new SqlParameter("@in_ATANVALUE", SqlDbType.Decimal)};
            cmdParms[0].Value = model.SENSOR_ID;
            cmdParms[1].Value = model.SENSOR_NAME;
            cmdParms[2].Value = model.SAT_ID;
            cmdParms[3].Value = model.SAT_NAME;
            cmdParms[4].Value = model.SWATHWIDTH;
            cmdParms[5].Value = model.AVGH;
            cmdParms[6].Value = model.TANVALUE;
            cmdParms[7].Value = model.ATANVALUE;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Model.SATELLITE_SENSOR_FOV model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE LHF.SATELLITE_SENSOR_FOV SET ");
            strSql.Append("SENSOR_NAME=@in_SENSOR_NAME,");
            strSql.Append("SAT_ID=@in_SAT_ID,");
            strSql.Append("SAT_NAME=@in_SAT_NAME,");
            strSql.Append("SWATHWIDTH=@in_SWATHWIDTH,");
            strSql.Append("AVGH=@in_AVGH,");
            strSql.Append("TANVALUE=@in_TANVALUE,");
            strSql.Append("ATANVALUE=@in_ATANVALUE");
            strSql.Append(" WHERE SENSOR_ID=@in_SENSOR_ID");
            SqlParameter[] cmdParms = new SqlParameter[]{
				new SqlParameter("@in_SENSOR_ID", SqlDbType.Decimal),
				new SqlParameter("@in_SENSOR_NAME", SqlDbType.NVarChar),
				new SqlParameter("@in_SAT_ID", SqlDbType.Decimal),
				new SqlParameter("@in_SAT_NAME", SqlDbType.NVarChar),
				new SqlParameter("@in_SWATHWIDTH", SqlDbType.Decimal),
				new SqlParameter("@in_AVGH", SqlDbType.Decimal),
				new SqlParameter("@in_TANVALUE", SqlDbType.Decimal),
				new SqlParameter("@in_ATANVALUE", SqlDbType.Decimal)};
            cmdParms[0].Value = model.SENSOR_ID;
            cmdParms[1].Value = model.SENSOR_NAME;
            cmdParms[2].Value = model.SAT_ID;
            cmdParms[3].Value = model.SAT_NAME;
            cmdParms[4].Value = model.SWATHWIDTH;
            cmdParms[5].Value = model.AVGH;
            cmdParms[6].Value = model.TANVALUE;
            cmdParms[7].Value = model.ATANVALUE;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(decimal SENSOR_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM LHF.SATELLITE_SENSOR_FOV ");
            strSql.Append(" WHERE SENSOR_ID=@in_SENSOR_ID");
            SqlParameter[] cmdParms = new SqlParameter[]{
				new SqlParameter("@in_SENSOR_ID", SqlDbType.Decimal)};
            cmdParms[0].Value = SENSOR_ID;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int DeleteBySatID(decimal sat_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM LHF.SATELLITE_SENSOR_FOV ");
            strSql.Append(" WHERE SAT_ID=@in_SAT_ID");
            SqlParameter[] cmdParms = new SqlParameter[]{
				new SqlParameter("@in_SAT_ID", SqlDbType.Decimal)};
            cmdParms[0].Value = sat_id;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(decimal SENSOR_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM LHF.SATELLITE_SENSOR_FOV");
            strSql.Append(" WHERE SENSOR_ID=@in_SENSOR_ID");
            SqlParameter[] cmdParms = new SqlParameter[]{
				new SqlParameter("@in_SENSOR_ID", SqlDbType.Decimal)};
            cmdParms[0].Value = SENSOR_ID;
            return DbHelperSQL.Exists(strSql.ToString(),cmdParms);

        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.SATELLITE_SENSOR_FOV GetModel(decimal SENSOR_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM LHF.SATELLITE_SENSOR_FOV ");
            strSql.Append(" WHERE SENSOR_ID="+SENSOR_ID);

            Model.SATELLITE_SENSOR_FOV model = null;
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
        /// 得到数据条数
        /// </summary>
        public int GetCount(string condition)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT (*) ");
            strSql.Append(" FROM LHF.SATELLITE_SENSOR_FOV ");
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
        private Model.SATELLITE_SENSOR_FOV GetModel(DbDataReader dr)
        {
            Model.SATELLITE_SENSOR_FOV model = new Model.SATELLITE_SENSOR_FOV();
            model.SENSOR_ID = Convert.ToDecimal(dr["SENSOR_ID"]);
            model.SENSOR_NAME = Convert.ToString(dr["SENSOR_NAME"]);
            model.SAT_ID = Convert.ToDecimal(dr["SAT_ID"]);
            model.SAT_NAME = Convert.ToString(dr["SAT_NAME"]);
            model.SWATHWIDTH = Convert.ToDecimal(dr["SWATHWIDTH"]);
            model.AVGH = Convert.ToDecimal(dr["AVGH"]);
            model.TANVALUE = Convert.ToDecimal(dr["TANVALUE"]);
            model.ATANVALUE = Convert.ToDecimal(dr["ATANVALUE"]);
            return model;
        }

        /// <summary>
        /// 由DbDataReader得到泛型数据列表
        /// </summary>
        private List<Model.SATELLITE_SENSOR_FOV> GetList(DbDataReader dr)
        {
            List<Model.SATELLITE_SENSOR_FOV> lst = new List<Model.SATELLITE_SENSOR_FOV>();
            while (dr.Read())
            {
                lst.Add(GetModel(dr));
            }
            return lst;
        }

        #endregion
    }
}
