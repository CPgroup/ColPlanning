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
    /// 数据访问类 ScheduleResult
    /// </summary>
    public class ScheduleResult
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.ScheduleResult model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO ScheduleResult(");
            strSql.Append("StartPoint,EndPoint,TranCost,Route,isChecked,UID,GID,PID)");
            strSql.Append(" VALUES (");
            strSql.Append("@in_StartPoint,@in_EndPoint,@in_TranCost,@in_Route,@in_isChecked,@in_UID,@in_GID,@in_PID)");
            SqlParameter[] cmdParms = new SqlParameter[]{
                new SqlParameter("@in_StartPoint", SqlDbType.NVarChar),
				new SqlParameter("@in_EndPoint", SqlDbType.NVarChar),
				new SqlParameter("@in_TranCost", SqlDbType.NVarChar),
				new SqlParameter("@in_Route", SqlDbType.NVarChar),
				new SqlParameter("@in_isChecked", SqlDbType.Bit),
                new SqlParameter("@in_UID", SqlDbType.Int),
                new SqlParameter("@in_GID", SqlDbType.Int),
                new SqlParameter("@in_PID", SqlDbType.Int)};

            cmdParms[0].Value = model.StartPoint;
            cmdParms[1].Value = model.EndPoint;
            cmdParms[2].Value = model.TranCost;
            cmdParms[3].Value = model.Route;
            cmdParms[4].Value = 0;
            cmdParms[5].Value = model.UID;
            cmdParms[6].Value = model.GID;
            cmdParms[7].Value = model.PID;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Model.ScheduleResult model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE ScheduleResult SET ");
            strSql.Append("StartPoint=@in_StartPoint,");
            strSql.Append("EndPoint=@in_EndPoint,");
            strSql.Append("TranCost=@in_TranCost,");
            strSql.Append("Route=@in_Route,");
            strSql.Append("isChecked=@in_isChecked,");
            strSql.Append("UID=@in_UID,");
            strSql.Append("GID=@in_GID,");
            strSql.Append("PID=@in_PID");
            strSql.Append(" WHERE ID=@in_ID");
            SqlParameter[] cmdParms = new SqlParameter[]{
                new SqlParameter("@in_StartPoint", SqlDbType.NVarChar),
				new SqlParameter("@in_EndPoint", SqlDbType.NVarChar),
				new SqlParameter("@in_TranCost", SqlDbType.NVarChar),
				new SqlParameter("@in_Route", SqlDbType.NVarChar),
				new SqlParameter("@in_isChecked", SqlDbType.Bit),
                new SqlParameter("@in_UID", SqlDbType.Int),
                new SqlParameter("@in_GID", SqlDbType.Int),
                new SqlParameter("@in_PID", SqlDbType.Int),
				new SqlParameter("@in_ID", SqlDbType.Int)};
            cmdParms[0].Value = model.StartPoint;
            cmdParms[1].Value = model.EndPoint;
            cmdParms[2].Value = model.TranCost;
            cmdParms[3].Value = model.Route;
            cmdParms[4].Value = 0;
            cmdParms[5].Value = model.UID;
            cmdParms[6].Value = model.GID;
            cmdParms[7].Value = model.PID;
            cmdParms[8].Value = model.ID;


            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }


        /// <summary>
        /// 更新IsChecked
        /// </summary>
        public int UpdateIsChecked(int UID, int PID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE ScheduleResult SET ");
            strSql.Append("isChecked=1");
            strSql.Append(" WHERE UID=" + UID + " AND PID=" + PID + "");
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 删除已有的调度结果
        /// </summary>
        public int DeleteAll(int PID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM ScheduleResult ");
            strSql.Append(" WHERE PID=" + PID);
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM ScheduleResult ");
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
        public bool ExistsResult(int PID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM ScheduleResult");
            strSql.Append(" WHERE PID=" + PID);
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int UID, int GID, int PID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM ScheduleResult");
            strSql.Append(" WHERE UID=" + UID + " AND GID=" + GID + " AND PID=" + PID + "");
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.ScheduleResult GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ScheduleResult ");
            strSql.Append(" WHERE ID=" + ID);
            Model.ScheduleResult model = null;
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
        /// 获取ID
        /// </summary>
        public int GetID(int UID, int GID, int PID)
        {
            int ID = -1;
            StringBuilder strSql = new StringBuilder("SELECT ID FROM ScheduleResult");
            strSql.Append(" WHERE UID=" + UID + " AND GID=" + GID + " AND PID=" + PID + "");
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (dr.Read())
                {
                    ID = Convert.ToInt32(dr["ID"]);
                }
                return ID;
            }
        }


        /// <summary>
        /// 获取当前灾区的数据列表
        /// </summary>
        public List<Model.ScheduleResult> GetListbyDisa(int DID)
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM ScheduleResult WHERE PID=" + DID);
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.ScheduleResult> lst = GetList(dr);
                return lst;
            }
        }
                

        /// <summary>
        /// 获取泛型数据列表
        /// </summary>
        public List<Model.ScheduleResult> GetCheckedList(int PID)
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM ScheduleResult WHERE isChecked=1 AND PID="+PID);
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.ScheduleResult> lst = GetList(dr);
                return lst;
            }
        }

        /// <summary>
        /// 获取泛型数据列表
        /// </summary>
        public List<Model.ScheduleResult> GetList()
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM ScheduleResult ");
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.ScheduleResult> lst = GetList(dr);
                return lst;
            }
        }


        #region -------- 私有方法，通常情况下无需修改 --------

        /// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        private Model.ScheduleResult GetModel(DbDataReader dr)
        {
            Model.ScheduleResult model = new Model.ScheduleResult();
            model.ID = DbHelperSQL.GetInt(dr["ID"]);
            model.StartPoint = DbHelperSQL.GetString(dr["StartPoint"]);
            model.EndPoint = DbHelperSQL.GetString(dr["EndPoint"]);
            model.TranCost = DbHelperSQL.GetString(dr["TranCost"]);
            model.Route = DbHelperSQL.GetString(dr["Route"]);
            model.isChecked = DbHelperSQL.GetBool(dr["isChecked"]);
            model.UID = DbHelperSQL.GetInt(dr["UID"]);
            model.GID = DbHelperSQL.GetInt(dr["GID"]);
            model.PID = DbHelperSQL.GetInt(dr["PID"]);
            return model;
        }

        /// <summary>
        /// 由DbDataReader得到泛型数据列表
        /// </summary>
        private List<Model.ScheduleResult> GetList(DbDataReader dr)
        {
            List<Model.ScheduleResult> lst = new List<Model.ScheduleResult>();
            while (dr.Read())
            {
                lst.Add(GetModel(dr));
            }
            return lst;
        }

        #endregion
    }
}
