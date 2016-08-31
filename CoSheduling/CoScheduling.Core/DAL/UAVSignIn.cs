//------------------------------------------------------------------------------
// 创建标识: 尹健
// 创建描述: 无人机监测——无人机签到
// 创建时间:2014.6.29
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
    /// 数据访问类 UAVSignIn
    /// </summary>
    public class UAVSignIn
    {
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE UAVSignIn SET isChecked=1 ");
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
            strSql.Append("UPDATE UAVSignIn SET isHandled=1 ");
            strSql.Append(" WHERE ID=" + ID);
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM UAVSignIn");
            strSql.Append(" WHERE ID=" + ID);
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 得到最新的一个对象实体
        /// </summary>
        public Model.UAVSignIn GetModel(int UID, int pid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT Top 1 * FROM UAVSignIn ");
            strSql.Append(" WHERE UID=" + UID + " AND PID=" + pid + " order by  UAVTime desc");
            Model.UAVSignIn model = null;
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
        /// 根据条件得到一个对象实体
        /// </summary>
        public Model.UAVSignIn GetModelByCond(string whereClause)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM UAVSignIn ");
            strSql.Append(" WHERE "+whereClause+"");
            Model.UAVSignIn model = null;
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
        /// 得到最新的一个对象实体
        /// </summary>
        public Model.UAVSignIn GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM UAVSignIn ");
            strSql.Append(" WHERE ID=" +id);
            Model.UAVSignIn model = null;
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
        /// 根据时间得到最新的一个对象实体
        /// </summary>
        public Model.UAVSignIn GetModel(int UID, int pid, string time)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT Top 1 * FROM UAVSignIn ");
            strSql.Append(" WHERE UID=" + UID + " AND PID=" + pid + " AND UAVTime<='" + time + "' order by  UAVTime desc");
            Model.UAVSignIn model = null;
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
        /// 根据时间得到最新的一个对象实体
        /// </summary>
        public Model.UAVSignIn GetNewModel(int UID, int pid, string time)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT Top 1 * FROM UAVSignIn ");
            strSql.Append(" WHERE UID=" + UID + " AND PID=" + pid + " AND UAVTime>'" + time + "' order by  UAVTime desc");
            Model.UAVSignIn model = null;
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
        /// 根据任务名称
        /// </summary>
        public string GetGatherPointName(int GID)
        {
            string uavName = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select PName from [dbo].[DisaGatherPoint] ");
            strSql.Append(" where id=" + GID);
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (dr.Read())
                {
                    uavName = Convert.ToString(dr["PName"]);
                }
                return uavName;
            }
        }

        /// <summary>
        /// 根据任务名称
        /// </summary>
        public string GetTaskName(int TID)
        {
            string uavName = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Name from [dbo].[TaskAreas] ");
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
        /// 得到最新的一个对象
        /// </summary>
        public Model.UAVSignIn GetTopModel(int uid, string time)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TOP 1 * FROM [dbo].[UAVSignIn] WHERE [UAVTime]<'" + time + "' AND UID=" + uid + " ORDER BY [UAVTime] DESC ");
            Model.UAVSignIn model = null;
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
        /// 得到最新的一个对象
        /// </summary>
        public Model.UAVSignIn GetTopModel()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TOP 1 * FROM UAVSignIn ORDER BY UAVTime DESC  ");
            Model.UAVSignIn model = null;
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
        /// 获取未查看的无人机签到信息
        /// </summary>
        public List<Model.UAVSignIn> NotCheckedSignList(int DID)
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM  V_UAVSignIn WHERE isChecked=0 AND PID="+DID);
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.UAVSignIn> lst = new List<Model.UAVSignIn>();
                while (dr.Read())
                {
                    Model.UAVSignIn model = new Model.UAVSignIn();
                    model.ID = DbHelperSQL.GetInt(dr["ID"]);
                    model.UID = DbHelperSQL.GetInt(dr["UID"]);
                    model.UAVTel = DbHelperSQL.GetString(dr["UAVTel"]);
                    model.TypeID = DbHelperSQL.GetString(dr["TypeID"]);
                    model.UAVTime = DbHelperSQL.GetString(dr["UAVTime"]);
                    model.isChecked = DbHelperSQL.GetBool(dr["isChecked"]);
                    model.Latitude = DbHelperSQL.GetDouble(dr["Latitude"]);
                    model.Longitude = DbHelperSQL.GetDouble(dr["Longitude"]);
                    model.UAVName = DbHelperSQL.GetString(dr["UAVName"]);
                    model.TID = DbHelperSQL.GetString(dr["TID"]);
                    model.PID = DbHelperSQL.GetInt(dr["PID"]);
                    model.isHandled = DbHelperSQL.GetBool(dr["isHandled"]);
                    lst.Add(model);
                }
                return lst;
            }
        }

        /// <summary>
        /// 无人机签到信息
        /// </summary>
        public string UAVSignInfor()
        {
            string str = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 isChecked from UAVSignIn order by UAVTime DESC");
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (dr.Read())
                {
                    str = Convert.ToString(dr["TypeID"]);
                }
                if (str == "30001")
                    return "ArrGathPoint";//到达集结点
                else if (str == "30002")
                    return "ArrTaskArea";//到达任务区
                else
                    return "FinishTask";//完成任务
            }
        }


        /// <summary>
        /// 是否已经上报该无人机签到事件
        /// </summary>
        public int isCheckedSign(int DID)
        {
            int isChecked = -1;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 isChecked from V_UAVSignIn where DID=" + DID + " order by UAVTime DESC");
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
        /// 得到一个对象实体
        /// </summary>
        public string GetTopTypeID(int UID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM V_UAVSignIn ");
            strSql.Append(" WHERE UID=" + UID + "  order by UAVTime DESC");
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                string TypeID = "";
                while (dr.Read())
                {
                    TypeID = Convert.ToString(dr["TypeID"]);
                }
                return TypeID;
            }
        }


        /// <summary>
        /// 获取泛型数据列表
        /// </summary>
        public List<Model.UAVSignIn> GetList()
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM  V_UAVSignIn");
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.UAVSignIn> lst = new List<Model.UAVSignIn>();
                while (dr.Read())
                {
                    Model.UAVSignIn model = new Model.UAVSignIn();
                    model.ID = DbHelperSQL.GetInt(dr["ID"]);
                    model.UID = DbHelperSQL.GetInt(dr["UID"]);
                    model.UAVTel = DbHelperSQL.GetString(dr["UAVTel"]);
                    model.TypeID = DbHelperSQL.GetString(dr["TypeID"]);
                    model.UAVTime = DbHelperSQL.GetString(dr["UAVTime"]);
                    model.isChecked = DbHelperSQL.GetBool(dr["isChecked"]);
                    model.Latitude = DbHelperSQL.GetDouble(dr["Latitude"]);
                    model.Longitude = DbHelperSQL.GetDouble(dr["Longitude"]);
                    model.UAVName = DbHelperSQL.GetString(dr["UAVName"]);
                    model.TID = DbHelperSQL.GetString(dr["TID"]);
                    model.PID = DbHelperSQL.GetInt(dr["PID"]);
                    model.isHandled = DbHelperSQL.GetBool(dr["isHandled"]);
                    lst.Add(model);
                }
                return lst;
            }
        }

        /// <summary>
        /// 根据TID获取完成任务的列表
        /// </summary>
        public List<Model.UAVSignIn> GetMonitoringListByTID(int TID)
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM V_UAVSignIn WHERE TID='" + TID + "' AND TypeID=30002");
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.UAVSignIn> lst = new List<Model.UAVSignIn>();
                while (dr.Read())
                {
                    Model.UAVSignIn model = new Model.UAVSignIn();
                    model.ID = DbHelperSQL.GetInt(dr["ID"]);
                    model.UID = DbHelperSQL.GetInt(dr["UID"]);
                    model.UAVTel = DbHelperSQL.GetString(dr["UAVTel"]);
                    model.TypeID = DbHelperSQL.GetString(dr["TypeID"]);
                    model.UAVTime = DbHelperSQL.GetString(dr["UAVTime"]);
                    model.isChecked = DbHelperSQL.GetBool(dr["isChecked"]);
                    model.Latitude = DbHelperSQL.GetDouble(dr["Latitude"]);
                    model.Longitude = DbHelperSQL.GetDouble(dr["Longitude"]);
                    model.UAVName = DbHelperSQL.GetString(dr["UAVName"]);
                    model.TID = DbHelperSQL.GetString(dr["TID"]);
                    model.PID = DbHelperSQL.GetInt(dr["PID"]);
                    model.isHandled = DbHelperSQL.GetBool(dr["isHandled"]);
                    lst.Add(model);
                }
                return lst;
            }
        }

        /// <summary>
        /// 根据TID获取完成任务的列表
        /// </summary>
        public List<Model.UAVSignIn> GetFinishedListByTID(int TID)
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM V_UAVSignIn WHERE TID='" + TID + "' AND TypeID=30003");
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.UAVSignIn> lst = new List<Model.UAVSignIn>();
                while (dr.Read())
                {
                    Model.UAVSignIn model = new Model.UAVSignIn();
                    model.ID = DbHelperSQL.GetInt(dr["ID"]);
                    model.UID = DbHelperSQL.GetInt(dr["UID"]);
                    model.UAVTel = DbHelperSQL.GetString(dr["UAVTel"]);
                    model.TypeID = DbHelperSQL.GetString(dr["TypeID"]);
                    model.UAVTime = DbHelperSQL.GetString(dr["UAVTime"]);
                    model.isChecked = DbHelperSQL.GetBool(dr["isChecked"]);
                    model.Latitude = DbHelperSQL.GetDouble(dr["Latitude"]);
                    model.Longitude = DbHelperSQL.GetDouble(dr["Longitude"]);
                    model.UAVName = DbHelperSQL.GetString(dr["UAVName"]);
                    model.TID = DbHelperSQL.GetString(dr["TID"]);
                    model.PID = DbHelperSQL.GetInt(dr["PID"]);
                    model.isHandled = DbHelperSQL.GetBool(dr["isHandled"]);
                    lst.Add(model);
                }
                return lst;
            }
        }


        /// <summary>
        /// 获取泛型数据列表
        /// </summary>
        public List<Model.UAVSignIn> GetListByTID(int TID)
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM V_UAVSignIn WHERE TID='" + TID + "' order by uavtime desc");
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.UAVSignIn> lst = new List<Model.UAVSignIn>();
                while (dr.Read())
                {
                    Model.UAVSignIn model = new Model.UAVSignIn();
                    model.ID = DbHelperSQL.GetInt(dr["ID"]);
                    model.UID = DbHelperSQL.GetInt(dr["UID"]);
                    model.UAVTel = DbHelperSQL.GetString(dr["UAVTel"]);
                    model.TypeID = DbHelperSQL.GetString(dr["TypeID"]);
                    model.UAVTime = DbHelperSQL.GetString(dr["UAVTime"]);
                    model.isChecked = DbHelperSQL.GetBool(dr["isChecked"]);
                    model.Latitude = DbHelperSQL.GetDouble(dr["Latitude"]);
                    model.Longitude = DbHelperSQL.GetDouble(dr["Longitude"]);
                    model.UAVName = DbHelperSQL.GetString(dr["UAVName"]);
                    model.TID = DbHelperSQL.GetString(dr["TID"]);
                    model.PID = DbHelperSQL.GetInt(dr["PID"]);
                    model.isHandled = DbHelperSQL.GetBool(dr["isHandled"]);
                    lst.Add(model);
                }
                return lst;
            }
        }


        /// <summary>
        /// 获取泛型数据列表
        /// </summary>
        public List<Model.UAVSignIn> GetList(int UID, int TID)
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM V_UAVSignIn WHERE TID='" +TID + "' AND UID=" + UID + " order by uavtime desc");
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.UAVSignIn> lst = new List<Model.UAVSignIn>();
                while (dr.Read())
                {
                    Model.UAVSignIn model = new Model.UAVSignIn();
                    model.ID = DbHelperSQL.GetInt(dr["ID"]);
                    model.UID = DbHelperSQL.GetInt(dr["UID"]);
                    model.UAVTel = DbHelperSQL.GetString(dr["UAVTel"]);
                    model.TypeID = DbHelperSQL.GetString(dr["TypeID"]);
                    model.UAVTime = DbHelperSQL.GetString(dr["UAVTime"]);
                    model.isChecked = DbHelperSQL.GetBool(dr["isChecked"]);
                    model.Latitude = DbHelperSQL.GetDouble(dr["Latitude"]);
                    model.Longitude = DbHelperSQL.GetDouble(dr["Longitude"]);
                    model.UAVName = DbHelperSQL.GetString(dr["UAVName"]);
                    model.TID = DbHelperSQL.GetString(dr["TID"]);
                    model.PID = DbHelperSQL.GetInt(dr["PID"]);
                    model.isHandled = DbHelperSQL.GetBool(dr["isHandled"]);
                    lst.Add(model);
                }
                return lst;
            }
        }
        /// <summary>
        /// 获取泛型数据列表
        /// </summary>
        public List<Model.UAVSignIn> GetList(int PID)
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM V_UAVSignIn WHERE PID=" + PID);
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.UAVSignIn> lst = new List<Model.UAVSignIn>();
                while (dr.Read())
                {
                    Model.UAVSignIn model = new Model.UAVSignIn();
                    model.ID = DbHelperSQL.GetInt(dr["ID"]);
                    model.UID = DbHelperSQL.GetInt(dr["UID"]);
                    model.UAVTel = DbHelperSQL.GetString(dr["UAVTel"]);
                    model.TypeID = DbHelperSQL.GetString(dr["TypeID"]);
                    model.UAVTime = DbHelperSQL.GetString(dr["UAVTime"]);
                    model.isChecked = DbHelperSQL.GetBool(dr["isChecked"]);
                    model.Latitude = DbHelperSQL.GetDouble(dr["Latitude"]);
                    model.Longitude = DbHelperSQL.GetDouble(dr["Longitude"]);
                    model.UAVName = DbHelperSQL.GetString(dr["UAVName"]);
                    model.TID = DbHelperSQL.GetString(dr["TID"]);
                    model.PID = DbHelperSQL.GetInt(dr["PID"]);
                    model.isHandled = DbHelperSQL.GetBool(dr["isHandled"]);
                    lst.Add(model);
                }
                return lst;
            }
        }

        /// <summary>
        /// 获取无人机完成了的任务列表
        /// </summary>
        public List<Model.UAVSignIn> GetFinishTaskList(int uavid,int pid)
        {
            StringBuilder strSql = new StringBuilder("SELECT  * FROM UAVSignIn WHERE UID=" + uavid + " AND PID="+pid+" AND TypeID='30003' order by UAVTime desc");
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.UAVSignIn> lst = new List<Model.UAVSignIn>();
                while (dr.Read())
                {
                    Model.UAVSignIn model = new Model.UAVSignIn();
                    model.UID = DbHelperSQL.GetInt(dr["UID"]);
                    model.TID = DbHelperSQL.GetString(dr["TID"]);
                    lst.Add(model);
                }
                return lst;
            }
        }

        /// <summary>
        /// 获取无人机完成了的任务列表
        /// </summary>
        public List<Model.UAVSignIn> GetFinishTaskList(int pid)
        {
            StringBuilder strSql = new StringBuilder("SELECT DISTINCT  * FROM UAVSignIn WHERE  PID=" + pid + " AND TypeID='30003'  order by UAVTime desc");
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.UAVSignIn> lst = new List<Model.UAVSignIn>();
                while (dr.Read())
                {
                    Model.UAVSignIn model = new Model.UAVSignIn();
                    model.UID = DbHelperSQL.GetInt(dr["UID"]);
                    model.TID = DbHelperSQL.GetString(dr["TID"]);
                    lst.Add(model);
                }
                return lst;
            }
        }

        /// <summary>
        /// 获取无人机完成了的任务列表
        /// </summary>
        public List<Model.UAVSignIn> GetFinishUID(int pid)
        {
            StringBuilder strSql = new StringBuilder("SELECT DISTINCT  * FROM UAVSignIn WHERE  PID=" + pid + "  order by UAVTime desc");
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.UAVSignIn> lst = new List<Model.UAVSignIn>();
                while (dr.Read())
                {
                    Model.UAVSignIn model = new Model.UAVSignIn();
                    model.UID = DbHelperSQL.GetInt(dr["UID"]);
                    lst.Add(model);
                }
                return lst;
            }
        }

        /// <summary>
        /// 获取最新的任务ID
        /// </summary>
        public List<Model.UAVSignIn> GetTopList(int uid)
        {
            StringBuilder strSql = new StringBuilder("SELECT top 1 * FROM UAVSignIn WHERE uid=" + uid + " order by UAVTime desc");
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.UAVSignIn> lst = new List<Model.UAVSignIn>();
                while (dr.Read())
                {
                    Model.UAVSignIn model = new Model.UAVSignIn();
                    model.TID = DbHelperSQL.GetString(dr["TID"]);
                    lst.Add(model);
                }
                return lst;
            }
        }


        #region -------- 私有方法，通常情况下无需修改 --------

        /// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        private Model.UAVSignIn GetModel(DbDataReader dr)
        {
            Model.UAVSignIn model = new Model.UAVSignIn();
            model.ID = DbHelperSQL.GetInt(dr["ID"]);
            model.UID = DbHelperSQL.GetInt(dr["UID"]);
            model.UAVTel = DbHelperSQL.GetString(dr["UAVTel"]);
            model.TypeID = DbHelperSQL.GetString(dr["TypeID"]);
            model.UAVTime = DbHelperSQL.GetString(dr["UAVTime"]);
            model.isChecked = DbHelperSQL.GetBool(dr["isChecked"]);
            model.Latitude = DbHelperSQL.GetDouble(dr["Latitude"]);
            model.Longitude = DbHelperSQL.GetDouble(dr["Longitude"]);
            model.TID = DbHelperSQL.GetString(dr["TID"]);
            model.PID = DbHelperSQL.GetInt(dr["PID"]);
            model.isHandled = DbHelperSQL.GetBool(dr["isHandled"]);
            return model;
        }

        /// <summary>
        /// 由DbDataReader得到泛型数据列表
        /// </summary>
        private List<Model.UAVSignIn> GetList(DbDataReader dr)
        {
            List<Model.UAVSignIn> lst = new List<Model.UAVSignIn>();
            while (dr.Read())
            {
                lst.Add(GetModel(dr));
            }
            return lst;
        }

        #endregion
    }
}
