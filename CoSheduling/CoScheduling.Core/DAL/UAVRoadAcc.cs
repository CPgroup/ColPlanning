//------------------------------------------------------------------------------
// 创建标识: 尹健
// 创建描述: 无人机监测——道路状况
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
    /// 数据访问类 UAVRoadAcc
    /// </summary>
    public class UAVRoadAcc
    {

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE UAVRoadAcc SET isChecked=1 ");
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
            strSql.Append("UPDATE UAVRoadAcc SET isHandled=1 ");
            strSql.Append(" WHERE ID=" + ID);
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM UAVRoadAcc");
            strSql.Append(" WHERE ID=" + ID);
            return DbHelperSQL.Exists(strSql.ToString());

        }

        /// <summary>
        /// 根据UID获取编队任务名称
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
        /// 根据GID获取编队集结点名称
        /// </summary>
        public string GetGIDName(int GID)
        {
            string uavName = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select PName from DisaGatherPoint ");
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
        /// ***当前灾区***是否已经上报该道路事件
        /// </summary>
        public int isCheckedRoadAcc(int DID)
        {
            int isChecked = -1;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 isChecked from [V_UAVRoadAcc] WHERE DID=" + DID + " order by UAVTime DESC");
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
        /// 得到最新的一个对象
        /// </summary>
        public Model.UAVRoadAcc GetTopModel(int DID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TOP 1 * FROM [V_UAVRoadAcc] WHERE DID=" + DID + " ORDER BY UAVTime DESC  ");
            Model.UAVRoadAcc model = null;
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
        public Model.UAVRoadAcc GetModelByCond(string whereClause)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM UAVRoadAcc ");
            strSql.Append(" WHERE "+whereClause+"");
            Model.UAVRoadAcc model = null;
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
        public Model.UAVRoadAcc GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM UAVRoadAcc ");
            strSql.Append(" WHERE ID=" + ID);
            Model.UAVRoadAcc model = null;
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
        /// 获取无人机抵达集结点前的所有的障碍点
        /// </summary>
        public List<Model.UAVRoadAcc> GetBarries(int UID, string Destination)
        {
            StringBuilder strSql = new StringBuilder("select * from [dbo].[UAVRoadAcc] where UAVTime>(select TOP 1 SUBSTRING( UAVTime,0,10 )FROM [dbo].[UAVRoadAcc] order by UAVTime desc ) and uid=" + UID);
            strSql.Append(" and TID='" + Destination + "'");
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.UAVRoadAcc> lst = GetList(dr);
                return lst;
            }
        }

        /// <summary>
        /// 获取未查看的无人机签到信息
        /// </summary>
        public List<Model.UAVRoadAcc> NotCheckedRoadAccList(int PID)
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM  V_UAVRoadAcc WHERE isChecked=0 AND PID=" + PID);
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.UAVRoadAcc> lst = new List<Model.UAVRoadAcc>();
                while (dr.Read())
                {
                    Model.UAVRoadAcc model = new Model.UAVRoadAcc();
                    model.ID = DbHelperSQL.GetInt(dr["ID"]);
                    model.UID = DbHelperSQL.GetInt(dr["UID"]);
                    model.UAVTel = DbHelperSQL.GetString(dr["UAVTel"]);
                    model.TypeID = DbHelperSQL.GetString(dr["TypeID"]);
                    model.UAVRepair = DbHelperSQL.GetString(dr["UAVRepair"]);
                    model.UAVDescribe = DbHelperSQL.GetString(dr["UAVDescribe"]);
                    model.UAVTime = DbHelperSQL.GetString(dr["UAVTime"]);
                    model.isChecked = DbHelperSQL.GetBool(dr["isChecked"]);
                    model.LAT = DbHelperSQL.GetDouble(dr["Latitude"]);
                    model.LON = DbHelperSQL.GetDouble(dr["Longitude"]);
                    model.UAVName = DbHelperSQL.GetString(dr["UAVName"]);
                    model.Destination = DbHelperSQL.GetString(dr["TID"]);
                    model.Time = DbHelperSQL.GetString(dr["Time"]);
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
        public List<Model.UAVRoadAcc> GetList(int PID)
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM V_UAVRoadAcc WHERE PID="+PID);
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.UAVRoadAcc> lst = new List<Model.UAVRoadAcc>();
                while (dr.Read())
                {
                    Model.UAVRoadAcc model = new Model.UAVRoadAcc();
                    model.ID = DbHelperSQL.GetInt(dr["ID"]);
                    model.UID = DbHelperSQL.GetInt(dr["UID"]);
                    model.UAVTel = DbHelperSQL.GetString(dr["UAVTel"]);
                    model.TypeID = DbHelperSQL.GetString(dr["TypeID"]);
                    model.UAVRepair = DbHelperSQL.GetString(dr["UAVRepair"]);
                    model.UAVDescribe = DbHelperSQL.GetString(dr["UAVDescribe"]);
                    model.UAVTime = DbHelperSQL.GetString(dr["UAVTime"]);
                    model.isChecked = DbHelperSQL.GetBool(dr["isChecked"]);
                    model.LAT = DbHelperSQL.GetDouble(dr["Latitude"]);
                    model.LON = DbHelperSQL.GetDouble(dr["Longitude"]);
                    model.UAVName = DbHelperSQL.GetString(dr["UAVName"]);
                    model.Destination = DbHelperSQL.GetString(dr["TID"]);
                    model.Time = DbHelperSQL.GetString(dr["Time"]);
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
        public List<Model.UAVRoadAcc> GetList()
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM V_UAVRoadAcc");
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.UAVRoadAcc> lst = new List<Model.UAVRoadAcc>();
                while (dr.Read())
                {
                    Model.UAVRoadAcc model = new Model.UAVRoadAcc();
                    model.ID = DbHelperSQL.GetInt(dr["ID"]);
                    model.UID = DbHelperSQL.GetInt(dr["UID"]);
                    model.UAVTel = DbHelperSQL.GetString(dr["UAVTel"]);
                    model.TypeID = DbHelperSQL.GetString(dr["TypeID"]);
                    model.UAVRepair = DbHelperSQL.GetString(dr["UAVRepair"]);
                    model.UAVDescribe = DbHelperSQL.GetString(dr["UAVDescribe"]);
                    model.UAVTime = DbHelperSQL.GetString(dr["UAVTime"]);
                    model.isChecked = DbHelperSQL.GetBool(dr["isChecked"]);
                    model.LAT = DbHelperSQL.GetDouble(dr["Latitude"]);
                    model.LON = DbHelperSQL.GetDouble(dr["Longitude"]);
                    model.UAVName = DbHelperSQL.GetString(dr["UAVName"]);
                    model.Destination = DbHelperSQL.GetString(dr["TID"]);
                    model.Time = DbHelperSQL.GetString(dr["Time"]);
                    model.PID = DbHelperSQL.GetInt(dr["PID"]);
                    model.isHandled = DbHelperSQL.GetBool(dr["isHandled"]);
                    lst.Add(model);
                }
                return lst;
            }
        }

        /// <summary>
        /// 获取最近两条数据
        /// </summary>
        public List<Model.UAVRoadAcc> GetTopList(int uid)
        {
            StringBuilder strSql = new StringBuilder("select top 1 [TID] from [dbo].[UAVRoadAcc]  where UID=" + uid + " order by UAVTime desc");
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.UAVRoadAcc> lst = new List<Model.UAVRoadAcc>();
                while (dr.Read())
                {
                    Model.UAVRoadAcc model = new Model.UAVRoadAcc();
                    model.Destination = DbHelperSQL.GetString(dr["TID"]);
                    lst.Add(model);
                }
                return lst;
            }
        }


        #region -------- 私有方法，通常情况下无需修改 --------

        /// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        private Model.UAVRoadAcc GetModel(DbDataReader dr)
        {
            Model.UAVRoadAcc model = new Model.UAVRoadAcc();
            model.ID = DbHelperSQL.GetInt(dr["ID"]);
            model.UID = DbHelperSQL.GetInt(dr["UID"]);
            model.UAVTel = DbHelperSQL.GetString(dr["UAVTel"]);
            model.TypeID = DbHelperSQL.GetString(dr["TypeID"]);
            model.UAVRepair = DbHelperSQL.GetString(dr["UAVRepair"]);
            model.UAVDescribe = DbHelperSQL.GetString(dr["UAVDescribe"]);
            model.UAVTime = DbHelperSQL.GetString(dr["UAVTime"]);
            model.isChecked = DbHelperSQL.GetBool(dr["isChecked"]);
            model.LAT = DbHelperSQL.GetDouble(dr["Latitude"]);
            model.LON = DbHelperSQL.GetDouble(dr["Longitude"]);
            model.Destination = DbHelperSQL.GetString(dr["TID"]);
            model.Time = DbHelperSQL.GetString(dr["Time"]);
            model.PID = DbHelperSQL.GetInt(dr["PID"]);
            model.isHandled = DbHelperSQL.GetBool(dr["isHandled"]);
            return model;
        }

        /// <summary>
        /// 由DbDataReader得到泛型数据列表
        /// </summary>
        private List<Model.UAVRoadAcc> GetList(DbDataReader dr)
        {
            List<Model.UAVRoadAcc> lst = new List<Model.UAVRoadAcc>();
            while (dr.Read())
            {
                lst.Add(GetModel(dr));
            }
            return lst;
        }

        #endregion
    }
}
