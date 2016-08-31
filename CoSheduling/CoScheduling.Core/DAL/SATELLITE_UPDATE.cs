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
    public class SATELLITE_UPDATE
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.SATELLITE_UPDATE model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO SATELLITE_UPDATE(");
            strSql.Append("UPDATE_TABLE,UPDATE_TIME,UPDATE_LOG)");
            strSql.Append(" VALUES (");
            strSql.Append("@in_UPDATE_TABLE,@in_UPDATE_TIME,@in_UPDATE_LOG)");
            SqlParameter[] cmdParms = new SqlParameter[]{
				new SqlParameter("@in_UPDATE_TABLE",SqlDbType.NVarChar),
				new SqlParameter("@in_UPDATE_TIME", SqlDbType.NVarChar),
				new SqlParameter("@in_UPDATE_LOG", SqlDbType.NVarChar)};

            cmdParms[0].Value = model.UPDATE_TABLE;
            cmdParms[1].Value = model.UPDATE_TIME;
            cmdParms[2].Value = model.UPDATE_LOG;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Model.SATELLITE_UPDATE model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE SATELLITE_UPDATE SET ");
            strSql.Append("UPDATE_TABLE=@in_UPDATE_TABLE,");
            strSql.Append("UPDATE_TIME=@in_UPDATE_TIME,");
            strSql.Append("UPDATE_LOG=@in_UPDATE_LOG");
            strSql.Append(" WHERE UPDATE_ID=@in_UPDATE_ID");
            SqlParameter[] cmdParms = new SqlParameter[]{
				new SqlParameter("@in_UPDATE_ID", SqlDbType.Int),
				new SqlParameter("@in_UPDATE_TABLE",SqlDbType.NVarChar),
				new SqlParameter("@in_UPDATE_TIME", SqlDbType.NVarChar),
				new SqlParameter("@in_UPDATE_LOG", SqlDbType.NVarChar)};
            cmdParms[0].Value = model.UPDATE_ID;
            cmdParms[1].Value = model.UPDATE_TABLE;
            cmdParms[2].Value = model.UPDATE_TIME;
            cmdParms[3].Value = model.UPDATE_LOG;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int UPDATE_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM SATELLITE_UPDATE ");
            strSql.Append(" WHERE UPDATE_ID=@in_UPDATE_ID");
            SqlParameter[] cmdParms = new SqlParameter[]{
				new SqlParameter("@in_UPDATE_ID", SqlDbType.Int)};
            cmdParms[0].Value = UPDATE_ID;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int UPDATE_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM SATELLITE_UPDATE");
            strSql.Append(" WHERE UPDATE_ID=" + UPDATE_ID);
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.SATELLITE_UPDATE GetModel(int UPDATE_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM SATELLITE_UPDATE ");
            strSql.Append(" WHERE UPDATE_ID=" + UPDATE_ID);
            Model.SATELLITE_UPDATE model = null;
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
            return DbHelperSQL.GetCount("SATELLITE_UPDATE", condition);
        }



        #region -------- 私有方法，通常情况下无需修改 --------

        /// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        private Model.SATELLITE_UPDATE GetModel(DbDataReader dr)
        {
            Model.SATELLITE_UPDATE model = new Model.SATELLITE_UPDATE();
            model.UPDATE_ID = Convert.ToInt32(dr["UPDATE_ID"]);
            model.UPDATE_TABLE = Convert.ToString(dr["UPDATE_TABLE"]);
            model.UPDATE_TIME = Convert.ToDateTime(dr["UPDATE_TIME"]);
            model.UPDATE_LOG = Convert.ToString(dr["UPDATE_LOG"]);
            return model;
        }

        /// <summary>
        /// 由DbDataReader得到泛型数据列表
        /// </summary>
        private List<Model.SATELLITE_UPDATE> GetList(DbDataReader dr)
        {
            List<Model.SATELLITE_UPDATE> lst = new List<Model.SATELLITE_UPDATE>();
            while (dr.Read())
            {
                lst.Add(GetModel(dr));
            }
            return lst;
        }

        #endregion
		
    }
}
