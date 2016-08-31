//------------------------------------------------------------------------------
// 创建标识: 董毅博
// 创建描述: 卫星高度访问类
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
    public class SatelliteAltitude
    {
        //数据库连接字符串(web.config来配置)，可以动态更改connectionString支持多数据库.		
        public static string connectionString;
        public SatelliteAltitude()
        { connectionString = PubConstant.GetConnectionString(""); }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.SatelliteAltitude model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO LHF.SATELLITE_ALTITUDE(");
            strSql.Append("SAT_ID,PERIGEE,APOGEE,MEAN)");
            strSql.Append(" VALUES (");
            strSql.Append("@in_SAT_ID,@in_PERIGEE,@in_APOGEE,@in_MEAN)");
            SqlParameter[] cmdParms = new SqlParameter[]{
				new SqlParameter("@in_SAT_ID", SqlDbType.Decimal),
				new SqlParameter("@in_PERIGEE", SqlDbType.Decimal),
				new SqlParameter("@in_APOGEE", SqlDbType.Decimal),
				new SqlParameter("@in_MEAN", SqlDbType.Decimal)};
            cmdParms[0].Value = model.SAT_ID;
            cmdParms[1].Value = model.PERIGEE;
            cmdParms[2].Value = model.APOGEE;
            cmdParms[3].Value = model.MEAN;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Model.SatelliteAltitude model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE LHF.SATELLITE_ALTITUDE SET ");
            strSql.Append("PERIGEE=@in_PERIGEE,");
            strSql.Append("APOGEE=@in_APOGEE,");
            strSql.Append("MEAN=@in_MEAN");
            strSql.Append(" WHERE SAT_ID=@in_SAT_ID");
            SqlParameter[] cmdParms = new SqlParameter[]{
				new SqlParameter("@in_SAT_ID", SqlDbType.Decimal),
				new SqlParameter("@in_PERIGEE", SqlDbType.Decimal),
				new SqlParameter("@in_APOGEE", SqlDbType.Decimal),
				new SqlParameter("@in_MEAN", SqlDbType.Decimal)};
            cmdParms[0].Value = model.SAT_ID;
            cmdParms[1].Value = model.PERIGEE;
            cmdParms[2].Value = model.APOGEE;
            cmdParms[3].Value = model.MEAN;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(decimal SAT_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM LHF.SATELLITE_ALTITUDE ");
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
            strSql.Append("SELECT COUNT(1) FROM LHF.SATELLITE_ALTITUDE");
            strSql.Append(" WHERE SAT_ID=@in_SAT_ID");
            SqlParameter[] cmdParms = new SqlParameter[]{
				new SqlParameter("@in_SAT_ID", SqlDbType.Decimal)};
            cmdParms[0].Value = SAT_ID;
            return DbHelperSQL.Exists(strSql.ToString(),cmdParms);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.SatelliteAltitude GetModel(decimal SAT_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM LHF.SATELLITE_ALTITUDE ");
            strSql.Append(" WHERE SAT_ID="+SAT_ID);

            Model.SatelliteAltitude model = null;
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
        public List<Model.SatelliteAltitude> GetList()
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM LHF.SATELLITE_ALTITUDE");
            using (DbDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.SatelliteAltitude> lst = GetList(dr);
                return lst;
            }
        }

        /// <summary>
        /// 得到数据条数
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT (*) ");
            strSql.Append(" FROM LHF.SATELLITE_ALTITUDE ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }


        #region -------- 私有方法，通常情况下无需修改 --------

        /// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        private Model.SatelliteAltitude GetModel(DbDataReader dr)
        {
            Model.SatelliteAltitude model = new Model.SatelliteAltitude();
            model.SAT_ID = Convert.ToDecimal(dr["SAT_ID"]);
            model.PERIGEE = Convert.ToDecimal(dr["PERIGEE"]);
            model.APOGEE = Convert.ToDecimal(dr["APOGEE"]);
            model.MEAN = Convert.ToDecimal(dr["MEAN"]);
            return model;
        }

        /// <summary>
        /// 由DbDataReader得到泛型数据列表
        /// </summary>
        private List<Model.SatelliteAltitude> GetList(DbDataReader dr)
        {
            List<Model.SatelliteAltitude> lst = new List<Model.SatelliteAltitude>();
            while (dr.Read())
            {
                lst.Add(GetModel(dr));
            }
            return lst;
        }

        #endregion
    }
}
