//------------------------------------------------------------------------------
// 创建标识: 尹健
// 创建描述: 无人机最新任务访问类
// 创建时间:2013.11.15
// 文件版本:1.0
// 功能描述: 
// 修改标识: 
// 修改描述: 
//------------------------------------------------------------------------------

using System;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using CoScheduling.Core.DBUtility;

namespace CoScheduling.Core.DAL
{
    /// <summary>
    /// 数据访问类 UAVCurrentTask
    /// </summary>
    public class UAVCurrentTask
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.UAVCurrentTask model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO UAVCurrentTask(");
            strSql.Append("PID,LON,LAT,TaskString,UID,TID)");
            strSql.Append(" VALUES (");
            strSql.Append("@in_PID,@in_LON,@in_LAT,@in_TaskString,@in_UID,@in_TID)");
            SqlParameter[] cmdParms = new SqlParameter[]{
                 new SqlParameter("@in_PID", SqlDbType.Int),
				 new SqlParameter("@in_LON", SqlDbType.Decimal),
				 new SqlParameter("@in_LAT", SqlDbType.Decimal),
				 new SqlParameter("@in_TaskString", SqlDbType.NVarChar),
				 new SqlParameter("@in_UID", SqlDbType.Int),
                 new SqlParameter("@in_TID", SqlDbType.Int)};

            cmdParms[0].Value = model.PID;
            cmdParms[1].Value = model.LON;
            cmdParms[2].Value = model.LAT;
            cmdParms[3].Value = model.TaskString;
            cmdParms[4].Value = model.UID;
            cmdParms[5].Value = model.TID;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Model.UAVCurrentTask model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE UAVCurrentTask SET ");
            strSql.Append("PID=@in_PID,");
            strSql.Append("LON=@in_LON,");
            strSql.Append("LAT=@in_LAT,");
            strSql.Append("TaskString=@in_TaskString,");
            strSql.Append("UID=@in_UID,");
            strSql.Append("TID=@in_TID");
            strSql.Append(" WHERE ID=@in_ID");
            SqlParameter[] cmdParms = new SqlParameter[]{
                 new SqlParameter("@in_PID", SqlDbType.Int),
				 new SqlParameter("@in_LON", SqlDbType.Decimal),
				 new SqlParameter("@in_LAT", SqlDbType.Decimal),
				 new SqlParameter("@in_TaskString", SqlDbType.NVarChar),
				 new SqlParameter("@in_UID", SqlDbType.Int),
                  new SqlParameter("@in_TID", SqlDbType.Int),
				 new SqlParameter("@in_ID", SqlDbType.Int)};

            cmdParms[0].Value = model.PID;
            cmdParms[1].Value = model.LON;
            cmdParms[2].Value = model.LAT;
            cmdParms[3].Value = model.TaskString;
            cmdParms[4].Value = model.UID;
            cmdParms[5].Value = model.TID;
            cmdParms[6].Value = model.ID;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }


        /// <summary>
        /// 根据UID更新一条数据
        /// </summary>
        public int UpdateByUID(Model.UAVCurrentTask model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE UAVCurrentTask SET ");
            strSql.Append("PID=@in_PID,");
            strSql.Append("LON=@in_LON,");
            strSql.Append("LAT=@in_LAT,");
            strSql.Append("TaskString=@in_TaskString,");
            strSql.Append("TID=@in_TID");
            strSql.Append(" WHERE UID=@in_UID");
            SqlParameter[] cmdParms = new SqlParameter[]{
                 new SqlParameter("@in_PID", SqlDbType.Int),
				 new SqlParameter("@in_LON", SqlDbType.Decimal),
				 new SqlParameter("@in_LAT", SqlDbType.Decimal),
				 new SqlParameter("@in_TaskString", SqlDbType.NVarChar),
                  new SqlParameter("@in_TID", SqlDbType.Int),
				 new SqlParameter("@in_UID", SqlDbType.Int)};

            cmdParms[0].Value = model.PID;
            cmdParms[1].Value = model.LON;
            cmdParms[2].Value = model.LAT;
            cmdParms[3].Value = model.TaskString;            
            cmdParms[4].Value = model.TID;
            cmdParms[5].Value = model.UID;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM UAVCurrentTask ");
            strSql.Append(" WHERE UID=" + ID);
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM UAVCurrentTask");
            strSql.Append(" WHERE ID=" + ID);
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.UAVCurrentTask GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM UAVCurrentTask ");
            strSql.Append(" WHERE ID=" + ID);
            Model.UAVCurrentTask model = null;
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
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
        public List<Model.UAVCurrentTask> GetList()
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM UAVCurrentTask");
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.UAVCurrentTask> lst = GetList(dr);
                return lst;
            }
        }



        #region -------- 私有方法，通常情况下无需修改 --------

        /// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        private Model.UAVCurrentTask GetModel(DbDataReader dr)
        {
            Model.UAVCurrentTask model = new Model.UAVCurrentTask();
            model.ID = DbHelperSQL.GetInt(dr["ID"]);
            model.PID = DbHelperSQL.GetInt(dr["PID"]);
            model.LON = DbHelperSQL.GetDouble(dr["LON"]);
            model.LAT = DbHelperSQL.GetDouble(dr["LAT"]);
            model.TaskString = DbHelperSQL.GetString(dr["TaskString"]);
            model.UID = DbHelperSQL.GetInt(dr["UID"]);
            model.TID=DbHelperSQL.GetInt(dr["TID"]);
            return model;
        }

        /// <summary>
        /// 由DbDataReader得到泛型数据列表
        /// </summary>
        private List<Model.UAVCurrentTask> GetList(DbDataReader dr)
        {
            List<Model.UAVCurrentTask> lst = new List<Model.UAVCurrentTask>();
            while (dr.Read())
            {
                lst.Add(GetModel(dr));
            }
            return lst;
        }

        #endregion
    }
}
