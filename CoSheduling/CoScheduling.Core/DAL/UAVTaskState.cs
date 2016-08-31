//------------------------------------------------------------------------------
// 创建标识: 尹健
// 创建描述: 无人机监测——作业
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
	/// 数据访问类 UAVTaskState
	/// </summary>
	public class UAVTaskState 
	{


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE UAVTaskState SET isChecked=1 ");
            strSql.Append(" WHERE ID=" + ID);
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }


        /// <summary>
        /// 更新isHandled，0--事件未处理；1--事件已处理
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int UpdateisHandled(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE UAVTaskState SET isHandled=1 ");
            strSql.Append(" WHERE ID=" + ID);
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("SELECT COUNT(1) FROM UAVTaskState");
			strSql.Append(" WHERE ID="+ID);
            return DbHelperSQL.Exists(strSql.ToString());
		}

        /// <summary>
        /// 根据条件得到一个对象实体
        /// </summary>
        public Model.UAVTaskState GetModelByCond(string whereClause)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM UAVTaskState ");
            strSql.Append(" WHERE " + whereClause + "");
            Model.UAVTaskState model = null;
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
		public Model.UAVTaskState GetModel(int ID)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("SELECT * FROM UAVTaskState ");
			strSql.Append(" WHERE ID="+ID);
			Model.UAVTaskState model = null;
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
        /// 根据UID获取编队名称
        /// </summary>
        public string GetUAVName(int UID)
        {
            string uavName = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Name from [dbo].[UAVBD] ");
            strSql.Append(" where id=" + UID);
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (dr.Read())
                {
                    uavName = Convert.ToString(dr["Name"]);
                }
                return uavName;
            }
        }

        /// <summary>
        /// 根据UID获取编队名称
        /// </summary>
        public string GetTaskName(int TID)
        {
            string uavName = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Name from TaskAreas ");
            strSql.Append(" where id=" + TID);
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (dr.Read())
                {
                    uavName = Convert.ToString(dr["Name"]);
                }
                return uavName;
            }
        }

        /// <summary>
        /// 得到最新的一个对象
        /// </summary>
        public Model.UAVTaskState GetTopModel()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TOP 1 * FROM UAVTaskState ORDER BY UAVTime DESC  ");
            Model.UAVTaskState model = null;
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
        /// 是否已经上报该无人机作业事件
        /// </summary>
        public int isCheckedUAVState()
        {
            int isChecked = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 isChecked from UAVTaskState order by UAVTime DESC");
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (dr.Read())
                {
                    isChecked = Convert.ToInt32(dr["isChecked"]);
                }
                return isChecked;
            }
        }

        /// <summary>
        /// 获取未查看的无人机签到信息
        /// </summary>
        public List<Model.UAVTaskState> NotCheckedStateList(int PID)
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM  V_UAVTaskState WHERE isChecked=0 AND PID=" + PID);
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.UAVTaskState> lst = new List<Model.UAVTaskState>();
                while (dr.Read())
                {
                    Model.UAVTaskState model = new Model.UAVTaskState();
                    model.ID = DbHelperSQL.GetInt(dr["ID"]);
                    model.UID = DbHelperSQL.GetInt(dr["UID"]);
                    model.UAVTel = DbHelperSQL.GetString(dr["UAVTel"]);
                    model.TypeID = DbHelperSQL.GetString(dr["TypeID"]);
                    model.UAVTime = DbHelperSQL.GetString(dr["UAVTime"]);
                    model.isChecked = DbHelperSQL.GetBool(dr["isChecked"]);
                    model.Latitude = DbHelperSQL.GetDouble(dr["Latitude"]);
                    model.Longitude = DbHelperSQL.GetDouble(dr["Longitude"]);
                    model.UAVName = DbHelperSQL.GetString(dr["UAVName"]);
                    model.Time = DbHelperSQL.GetString(dr["Time"]);
                    model.TID = DbHelperSQL.GetString(dr["TID"]);
                    model.PID = DbHelperSQL.GetInt(dr["PID"]);
                    model.UAVRepair = DbHelperSQL.GetString(dr["UAVRepair"]);
                    model.UAVAdd = DbHelperSQL.GetString(dr["UAVAdd"]);
                    model.isHandled = DbHelperSQL.GetBool(dr["isHandled"]);
                    lst.Add(model);
                }
                return lst;
            }
        }

        /// <summary>
        /// 获取泛型数据列表
        /// </summary>
        public List<Model.UAVTaskState> GetList(int PID)
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM V_UAVTaskState WHERE PID=" + PID);
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.UAVTaskState> lst = new List<Model.UAVTaskState>();
                while (dr.Read())
                {
                    Model.UAVTaskState model = new Model.UAVTaskState();
                    model.ID = DbHelperSQL.GetInt(dr["ID"]);
                    model.UID = DbHelperSQL.GetInt(dr["UID"]);
                    model.UAVTel = DbHelperSQL.GetString(dr["UAVTel"]);
                    model.TypeID = DbHelperSQL.GetString(dr["TypeID"]);
                    model.UAVTime = DbHelperSQL.GetString(dr["UAVTime"]);
                    model.isChecked = DbHelperSQL.GetBool(dr["isChecked"]);
                    model.Latitude = DbHelperSQL.GetDouble(dr["Latitude"]);
                    model.Longitude = DbHelperSQL.GetDouble(dr["Longitude"]);
                    model.UAVName = DbHelperSQL.GetString(dr["UAVName"]);
                    model.Time = DbHelperSQL.GetString(dr["Time"]);
                    model.TID = DbHelperSQL.GetString(dr["TID"]);
                    model.PID = DbHelperSQL.GetInt(dr["PID"]);
                    model.isHandled = DbHelperSQL.GetBool(dr["isHandled"]);
                    model.UAVRepair = DbHelperSQL.GetString(dr["UAVRepair"]);
                    lst.Add(model);
                }
                return lst;
            }
        }

		/// <summary>
		/// 获取泛型数据列表
		/// </summary>
		public List<Model.UAVTaskState> GetList()
		{
			StringBuilder strSql = new StringBuilder("SELECT * FROM V_UAVTaskState");
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
			{
				List<Model.UAVTaskState> lst =new List<Model.UAVTaskState>();
                while (dr.Read())
                {
                    Model.UAVTaskState model = new Model.UAVTaskState();
                    model.ID = DbHelperSQL.GetInt(dr["ID"]);
                    model.UID = DbHelperSQL.GetInt(dr["UID"]);
                    model.UAVTel = DbHelperSQL.GetString(dr["UAVTel"]);
                    model.TypeID = DbHelperSQL.GetString(dr["TypeID"]);
                    model.UAVTime = DbHelperSQL.GetString(dr["UAVTime"]);
                    model.isChecked = DbHelperSQL.GetBool(dr["isChecked"]);
                    model.Latitude = DbHelperSQL.GetDouble(dr["Latitude"]);
                    model.Longitude = DbHelperSQL.GetDouble(dr["Longitude"]);
                    model.UAVName = DbHelperSQL.GetString(dr["UAVName"]);
                    model.Time = DbHelperSQL.GetString(dr["Time"]);
                    model.TID = DbHelperSQL.GetString(dr["TID"]);
                    model.PID = DbHelperSQL.GetInt(dr["PID"]);
                    model.isHandled = DbHelperSQL.GetBool(dr["isHandled"]);
                    lst.Add(model);
                }
				return lst;
			}
		}


		#region -------- 私有方法，通常情况下无需修改 --------

		/// <summary>
		/// 由一行数据得到一个实体
		/// </summary>
		private Model.UAVTaskState GetModel(DbDataReader dr)
		{
			Model.UAVTaskState model = new Model.UAVTaskState();
            model.ID = DbHelperSQL.GetInt(dr["ID"]);
            model.UID = DbHelperSQL.GetInt(dr["UID"]);
            model.UAVTel = DbHelperSQL.GetString(dr["UAVTel"]);
            model.UAVTask = DbHelperSQL.GetString(dr["UAVTask"]);
            model.TypeID = DbHelperSQL.GetString(dr["TypeID"]);
            model.UAVRepair = DbHelperSQL.GetString(dr["UAVRepair"]);
            model.UAVAdd = DbHelperSQL.GetString(dr["UAVAdd"]);
            model.UAVTime = DbHelperSQL.GetString(dr["UAVTime"]);
            model.Latitude = DbHelperSQL.GetDouble(dr["Latitude"]);
            model.Longitude = DbHelperSQL.GetDouble(dr["Longitude"]);
            model.isChecked = DbHelperSQL.GetBool(dr["isChecked"]);
            model.Time = DbHelperSQL.GetString(dr["Time"]);
            model.TID = DbHelperSQL.GetString(dr["TID"]);
            model.PID = DbHelperSQL.GetInt(dr["PID"]);
            model.isHandled = DbHelperSQL.GetBool(dr["isHandled"]);
			return model;
		}

		/// <summary>
		/// 由DbDataReader得到泛型数据列表
		/// </summary>
		private List<Model.UAVTaskState> GetList(DbDataReader dr)
		{
			List<Model.UAVTaskState> lst = new List<Model.UAVTaskState>();
			while (dr.Read())
			{
				lst.Add(GetModel(dr));
			}
			return lst;
		}

		#endregion
	}
}
