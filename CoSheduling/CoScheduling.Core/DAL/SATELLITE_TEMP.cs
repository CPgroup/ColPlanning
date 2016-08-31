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
    public class SATELLITE_TEMP
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.SATELLITE_TEMP model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO SATELLITE_TEMP(");
            strSql.Append("SATELLITE_ID,SATELLITE_NAME,SATELLITE_UPDATETIME,SATELLITE_CHOOSE)");
            strSql.Append(" VALUES (");
            strSql.Append("@in_SATELLITE_ID,@in_SATELLITE_NAME,@in_SATELLITE_UPDATETIME,@in_SATELLITE_CHOOSE)");
            SqlParameter[] cmdParms = new SqlParameter[]{
				new SqlParameter("@in_SATELLITE_ID", SqlDbType.Decimal),
                new SqlParameter("@in_SATELLITE_NAME", SqlDbType.NVarChar),
				new SqlParameter("@in_SATELLITE_UPDATETIME", SqlDbType.NVarChar),
				new SqlParameter("@in_SATELLITE_CHOOSE", SqlDbType.Int)};
            cmdParms[0].Value = model.SATELLITE_ID;
            cmdParms[1].Value = model.SATELLITE_NAME;
            cmdParms[2].Value = model.SATELLITE_UPDATETIME;
            cmdParms[3].Value = model.SATELLITE_CHOOSE;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Model.SATELLITE_TEMP model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE SATELLITE_TEMP SET ");
            strSql.Append("SATELLITE_NAME=@in_SATELLITE_NAME,");
            strSql.Append("SATELLITE_UPDATETIME=@in_SATELLITE_UPDATETIME,");
            strSql.Append("SATELLITE_CHOOSE=@in_SATELLITE_CHOOSE");
            strSql.Append(" WHERE SATELLITE_ID=@in_SATELLITE_ID");
            SqlParameter[] cmdParms = new SqlParameter[]{
				new SqlParameter("@in_SATELLITE_ID", SqlDbType.Decimal),
                new SqlParameter("@in_SATELLITE_NAME", SqlDbType.NVarChar),
				new SqlParameter("@in_SATELLITE_UPDATETIME", SqlDbType.NVarChar),
				new SqlParameter("@in_SATELLITE_CHOOSE", SqlDbType.Int)};
            cmdParms[0].Value = model.SATELLITE_ID;
            cmdParms[1].Value = model.SATELLITE_NAME;
            cmdParms[2].Value = model.SATELLITE_UPDATETIME;
            cmdParms[3].Value = model.SATELLITE_CHOOSE;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(decimal SATELLITE_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM SATELLITE_TEMP ");
            strSql.Append(" WHERE SATELLITE_ID=@in_SATELLITE_ID");
            SqlParameter[] cmdParms = new SqlParameter[]{
				new SqlParameter("@in_SATELLITE_ID", SqlDbType.Decimal)};
            cmdParms[0].Value = SATELLITE_ID;


            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 删除全部数据
        /// </summary>
        public int Delete()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM SATELLITE_TEMP ");

            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(decimal SATELLITE_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM SATELLITE_TEMP");
            strSql.Append(" WHERE SATELLITE_ID=" + SATELLITE_ID);
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.SATELLITE_TEMP GetModel(decimal SATELLITE_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM SATELLITE_TEMP ");
            strSql.Append(" WHERE SATELLITE_ID=" + SATELLITE_ID);
            Model.SATELLITE_TEMP model = null;
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
        public List<Model.SATELLITE_TEMP> GetList()
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM SATELLITE_TEMP");
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.SATELLITE_TEMP> lst = GetList(dr);
                return lst;
            }
        }

        /// <summary>
        /// 得到数据条数
        /// </summary>
        public int GetCount(string condition)
        {
            return DbHelperSQL.GetCount("SATELLITE_TEMP", condition);
        }



        #region -------- 私有方法，通常情况下无需修改 --------

        /// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        private Model.SATELLITE_TEMP GetModel(DbDataReader dr)
        {
            Model.SATELLITE_TEMP model = new Model.SATELLITE_TEMP();
            model.SATELLITE_ID = Convert.ToDecimal(dr["SATELLITE_ID"]);
            model.SATELLITE_NAME = Convert.ToString(dr["SATELLITE_NAME"]);
            model.SATELLITE_UPDATETIME = Convert.ToDateTime(dr["SATELLITE_UPDATETIME"]);
            model.SATELLITE_CHOOSE = Convert.ToInt32(dr["SATELLITE_CHOOSE"]);
            return model;
        }

        /// <summary>
        /// 由DbDataReader得到泛型数据列表
        /// </summary>
        private List<Model.SATELLITE_TEMP> GetList(DbDataReader dr)
        {
            List<Model.SATELLITE_TEMP> lst = new List<Model.SATELLITE_TEMP>();
            while (dr.Read())
            {
                lst.Add(GetModel(dr));
            }
            return lst;
        }

        #endregion
    }
}
