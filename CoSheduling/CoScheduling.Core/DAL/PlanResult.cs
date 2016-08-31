//------------------------------------------------------------------------------
// 创建标识: 尹健
// 创建描述: 调度结果数据访问类
// 创建时间:2013.11.11
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
    /// 数据访问类 PlanResult
    /// </summary>
    public class PlanResult
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.PlanResult model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO PlanResult(");
            strSql.Append("UAVID,UAVName,TotalCost,TID,TName,TLAT,TLON,TCost,FCost,PID,GID)");
            strSql.Append(" VALUES (");
            strSql.Append("@in_UAVID,@in_UAVName,@in_TotalCost,@in_TID,@in_TName,@in_TLAT,@in_TLON,@in_TCost,@in_FCost,@in_PID,@in_GID)");
            SqlParameter[] cmdParms = new SqlParameter[]{
                new SqlParameter("@in_UAVID", SqlDbType.Int),
				new SqlParameter("@in_UAVName", SqlDbType.NVarChar),
				new SqlParameter("@in_TotalCost", SqlDbType.NVarChar),
				new SqlParameter("@in_TID", SqlDbType.Int),
				new SqlParameter("@in_TName", SqlDbType.NVarChar),
				new SqlParameter("@in_TLAT", SqlDbType.Decimal),
				new SqlParameter("@in_TLON", SqlDbType.Decimal),
				new SqlParameter("@in_TCost", SqlDbType.NVarChar),
				new SqlParameter("@in_FCost", SqlDbType.NVarChar),
                new SqlParameter("@in_PID", SqlDbType.Int),
                new SqlParameter("@in_GID", SqlDbType.Int)};

            cmdParms[0].Value = model.UAVID;
            cmdParms[1].Value = model.UAVName;
            cmdParms[2].Value = model.TotalCost;
            cmdParms[3].Value = model.TID;
            cmdParms[4].Value = model.TName;
            cmdParms[5].Value = model.TLAT;
            cmdParms[6].Value = model.TLON;
            cmdParms[7].Value = model.TCost;
            cmdParms[8].Value = model.FCost;
            cmdParms[9].Value = model.PID;
            cmdParms[10].Value = model.GID;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Model.PlanResult model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE PlanResult SET ");
            strSql.Append("UAVID=@in_UAVID,");
            strSql.Append("UAVName=@in_UAVName,");
            strSql.Append("TotalCost=@in_TotalCost,");
            strSql.Append("TID=@in_TID,");
            strSql.Append("TName=@in_TName,");
            strSql.Append("TLAT=@in_TLAT,");
            strSql.Append("TLON=@in_TLON,");
            strSql.Append("TCost=@in_TCost,");
            strSql.Append("FCost=@in_FCost,");
            strSql.Append("PID=@in_PID,");
            strSql.Append("GID=@in_GID ");
            strSql.Append(" WHERE ID=@in_ID");
            SqlParameter[] cmdParms = new SqlParameter[]{
                new SqlParameter("@in_UAVID", SqlDbType.Int),
				new SqlParameter("@in_UAVName", SqlDbType.NVarChar),
				new SqlParameter("@in_TotalCost", SqlDbType.NVarChar),
				new SqlParameter("@in_TID", SqlDbType.Int),
				new SqlParameter("@in_TName", SqlDbType.NVarChar),
				new SqlParameter("@in_TLAT", SqlDbType.Decimal),
				new SqlParameter("@in_TLON", SqlDbType.Decimal),
				new SqlParameter("@in_TCost", SqlDbType.NVarChar),
				new SqlParameter("@in_FCost", SqlDbType.NVarChar),
                new SqlParameter("@in_PID", SqlDbType.Int),
                new SqlParameter("@in_GID", SqlDbType.Int),
				new SqlParameter("@in_ID", SqlDbType.Int)};

            cmdParms[0].Value = model.UAVID;
            cmdParms[1].Value = model.UAVName;
            cmdParms[2].Value = model.TotalCost;
            cmdParms[3].Value = model.TID;
            cmdParms[4].Value = model.TName;
            cmdParms[5].Value = model.TLAT;
            cmdParms[6].Value = model.TLON;
            cmdParms[7].Value = model.TCost;
            cmdParms[8].Value = model.FCost;
            cmdParms[9].Value = model.PID;
            cmdParms[10].Value = model.GID;
            cmdParms[11].Value = model.ID;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }


        /// <summary>
        /// 更新任务区状态
        /// </summary>
        public int UpdateTaskState(int TID,int State)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE PlanResult SET ");
            strSql.Append("State=@in_State ");
            strSql.Append(" WHERE TID=@in_TID");
            SqlParameter[] cmdParms = new SqlParameter[]{
                new SqlParameter("@in_State", SqlDbType.Int),
				new SqlParameter("@in_TID", SqlDbType.Int)};

            cmdParms[0].Value = State;
            cmdParms[1].Value = TID;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 根据TID更新一条数据
        /// </summary>
        public int UpdateByTID(Model.PlanResult model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE PlanResult SET ");
            strSql.Append("UAVID=@in_UAVID,");
            strSql.Append("UAVName=@in_UAVName,");
            strSql.Append("TotalCost=@in_TotalCost,");
            strSql.Append("TName=@in_TName,");
            strSql.Append("TLAT=@in_TLAT,");
            strSql.Append("TLON=@in_TLON,");
            strSql.Append("TCost=@in_TCost,");
            strSql.Append("FCost=@in_FCost,");
            strSql.Append("PID=@in_PID,");
            strSql.Append("GID=@in_GID ");
            strSql.Append(" WHERE TID=@in_TID");
            SqlParameter[] cmdParms = new SqlParameter[]{
                new SqlParameter("@in_UAVID", SqlDbType.Int),
				new SqlParameter("@in_UAVName", SqlDbType.NVarChar),
				new SqlParameter("@in_TotalCost", SqlDbType.NVarChar),
				new SqlParameter("@in_TName", SqlDbType.NVarChar),
				new SqlParameter("@in_TLAT", SqlDbType.Decimal),
				new SqlParameter("@in_TLON", SqlDbType.Decimal),
				new SqlParameter("@in_TCost", SqlDbType.NVarChar),
				new SqlParameter("@in_FCost", SqlDbType.NVarChar),
                new SqlParameter("@in_PID", SqlDbType.Int),
                new SqlParameter("@in_GID", SqlDbType.Int),
				new SqlParameter("@in_TID", SqlDbType.Int)};

            cmdParms[0].Value = model.UAVID;
            cmdParms[1].Value = model.UAVName;
            cmdParms[2].Value = model.TotalCost;
            cmdParms[3].Value = model.TName;
            cmdParms[4].Value = model.TLAT;
            cmdParms[5].Value = model.TLON;
            cmdParms[6].Value = model.TCost;
            cmdParms[7].Value = model.FCost;
            cmdParms[8].Value = model.PID;
            cmdParms[9].Value = model.GID;
            cmdParms[10].Value = model.TID;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }
        /// <summary>
        /// 是否发送至无人机
        /// </summary>
        public int UpdateIsSend(int tid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE PlanResult SET ");           
            strSql.Append("isSend=1 ");
            strSql.Append(" WHERE TID="+tid);
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int DeleteAll(int PID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM PlanResult ");
            strSql.Append(" WHERE PID=" + PID);
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM PlanResult ");
            strSql.Append(" WHERE ID=" + ID);
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("UAVPlan");
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public int GetIDbyTID(int TID)
        {
            int id = -1;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM PlanResult");
            strSql.Append(" WHERE TID=" + TID);
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {

                while (dr.Read())
                {
                    id = Convert.ToInt32(dr["ID"]);
                }
                return id;
            }
        }

        /// <summary>
        /// 获取所有受调度的无人机ID
        /// </summary>
        /// <returns></returns>
        public List<int> GetAllUAVIDs(int PID)
        {
            List<int> uavids = new List<int>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT DISTINCT UAVID FROM PlanResult");
            strSql.Append(" WHERE PID=" + PID);
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {

                while (dr.Read())
                {
                    uavids.Add(Convert.ToInt32(dr["UAVID"]));
                }
                return uavids;
            }
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsResult(int PID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM PlanResult");
            strSql.Append(" WHERE PID=" + PID );
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int PID, int TID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM PlanResult");
            strSql.Append(" WHERE PID=" + PID + " AND TID=" + TID);
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.PlanResult GetTopModel(int PID,int UID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TOP 1 * FROM PlanResult ");
            strSql.Append(" WHERE PID=" + PID + " AND UAVID="+UID+" AND isSend<>1 ORDER BY ID asc");
            Model.PlanResult model = null;
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
        /// 得到一个对象实体
        /// </summary>
        public Model.PlanResult GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM PlanResult ");
            strSql.Append(" WHERE ID=" + ID);
            Model.PlanResult model = null;
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
        /// 根据PID获取泛型数据列表
        /// </summary>
        public List<Model.PlanResult> GetListByPID(int PID)
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM PlanResult WHERE PID="+PID);
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.PlanResult> lst = GetList(dr);
                return lst;
            }
        }


        /// <summary>
        /// 获取规划后的无人机ID列表
        /// </summary>
        public List<int> GetUAVIDs(int PID)
        {
            StringBuilder strSql = new StringBuilder("SELECT DISTINCT UAVID FROM PlanResult WHERE  State<>2 AND PID="+PID);
            List<int> uavids = new List<int>();
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (dr.Read())
                {
                    uavids.Add(Convert.ToInt32(dr["UAVID"]));
                }
                return uavids;
            }
        }

        /// <summary>
        /// 获取无人机的任务列表
        /// </summary>
        public List<Model.PlanResult> GetTotalTasks(int uid)
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM PlanResult WHERE UAVID="+uid);
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.PlanResult> lst = GetList(dr);
                return lst;
            }
        }


        /// <summary>
        /// 获取没有完成的任务列表
        /// </summary>
        public List<Model.PlanResult> GetNotFinishedTasks(int PID)
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM PlanResult WHERE State<>2 AND PID="+PID);
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.PlanResult> lst = GetList(dr);
                return lst;
            }
        }

        /// <summary>
        /// 根任务ID获取任务状态
        /// </summary>
        public Model.PlanResult GetTasksStateByTID(int TID)
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM PlanResult WHERE  TID=" + TID);
            Model.PlanResult model = null;
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
        /// 获取无人机已完成的任务列表
        /// </summary>
        public List<Model.PlanResult> GetFinishedTasks(int uid)
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM PlanResult WHERE State=2 AND UAVID=" + uid);
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.PlanResult> lst = GetList(dr);
                return lst;
            }
        }

        /// <summary>
        /// 获取泛型数据列表
        /// </summary>
        public List<Model.PlanResult> GetList()
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM PlanResult");
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.PlanResult> lst = GetList(dr);
                return lst;
            }
        }



        #region -------- 私有方法，通常情况下无需修改 --------

        /// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        private Model.PlanResult GetModel(DbDataReader dr)
        {
            Model.PlanResult model = new Model.PlanResult();
            model.ID = DbHelperSQL.GetInt(dr["ID"]);
            model.UAVID = DbHelperSQL.GetInt(dr["UAVID"]);
            model.UAVName = DbHelperSQL.GetString(dr["UAVName"]);
            model.TotalCost = DbHelperSQL.GetString(dr["TotalCost"]);
            model.TID = DbHelperSQL.GetInt(dr["TID"]);
            model.TName = DbHelperSQL.GetString(dr["TName"]);
            model.TLAT = DbHelperSQL.GetDouble(dr["TLAT"]);
            model.TLON = DbHelperSQL.GetDouble(dr["TLON"]);
            model.TCost = DbHelperSQL.GetString(dr["TCost"]);
            model.FCost = DbHelperSQL.GetString(dr["FCost"]);
            model.PID = DbHelperSQL.GetInt(dr["PID"]);
            model.GID=DbHelperSQL.GetInt(dr["GID"]);
            model.State = DbHelperSQL.GetInt(dr["State"]);
            return model;
        }

        /// <summary>
        /// 由DbDataReader得到泛型数据列表
        /// </summary>
        private List<Model.PlanResult> GetList(DbDataReader dr)
        {
            List<Model.PlanResult> lst = new List<Model.PlanResult>();
            while (dr.Read())
            {
                lst.Add(GetModel(dr));
            }
            return lst;
        }

        #endregion
    }
}
