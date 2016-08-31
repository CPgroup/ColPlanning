//------------------------------------------------------------------------------
// 创建标识: 尹健
// 创建描述: 无人机GPS信息访问类
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
    /// 数据访问类 V_UAVGPSInfor
    /// </summary>
    public class UAVGPSInfor
    {
        /// <summary>
        /// 更新IsChecked
        /// </summary>
        public int UpdateIsChecked(int check, int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE UAVGPSInfo SET ");
            strSql.Append("isChecked=" + check);
            strSql.Append(" WHERE ID=" + id);
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM V_UAVGPSInfor");
            strSql.Append(" WHERE ID=" + ID);
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 根据条件得到一个最新的一个对象实体
        /// </summary>
        public Model.UAVGPSInfor GetTopModel(int uid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TOP 1 * FROM V_UAVGPSInfor WHERE uid="+uid+" order by GPSTime desc");
            Model.UAVGPSInfor model = null;
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
        /// 得到一个最新的一个对象实体
        /// </summary>
        public Model.UAVGPSInfor GetTopModel()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TOP 1 * FROM V_UAVGPSInfor order by GPSTime desc");
            Model.UAVGPSInfor model = null;
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
        public Model.UAVGPSInfor GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM V_UAVGPSInfor ");
            strSql.Append(" WHERE ID=" + ID);
            Model.UAVGPSInfor model = null;
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
        public List<Model.UAVGPSInfor> GetList()
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM V_UAVGPSInfor");
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.UAVGPSInfor> lst = GetList(dr);
                return lst;
            }
        }


        #region -------- 私有方法，通常情况下无需修改 --------

        /// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        private Model.UAVGPSInfor GetModel(DbDataReader dr)
        {
            Model.UAVGPSInfor model = new Model.UAVGPSInfor();
            model.ID = DbHelperSQL.GetInt(dr["ID"]);
            model.UID = DbHelperSQL.GetInt(dr["UID"]);
            model.GPSTel = DbHelperSQL.GetString(dr["GPSTel"]);
            model.GPSLatitude = DbHelperSQL.GetString(dr["GPSLatitude"]);
            model.GPSLongitude = DbHelperSQL.GetString(dr["GPSLongitude"]);
            model.GPSTime = DbHelperSQL.GetString(dr["GPSTime"]);
            model.Name = DbHelperSQL.GetString(dr["Name"]);
            //model.isChecked = DbHelperSQL.GetBool(dr["isChecked"]);
            return model;
        }

        /// <summary>
        /// 由DbDataReader得到泛型数据列表
        /// </summary>
        private List<Model.UAVGPSInfor> GetList(DbDataReader dr)
        {
            List<Model.UAVGPSInfor> lst = new List<Model.UAVGPSInfor>();
            while (dr.Read())
            {
                lst.Add(GetModel(dr));
            }
            return lst;
        }

        #endregion
    }
}
