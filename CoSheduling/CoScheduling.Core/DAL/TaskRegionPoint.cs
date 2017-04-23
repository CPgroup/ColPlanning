//------------------------------------------------------------------------------
// 创建标识: 李佳霖
// 创建描述: 任务区域边界点访问类
// 创建时间:2014.7.20
// 文件版本:1.0
// 功能描述: 
// 修改标识: 
// 修改描述: 
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using CoScheduling.Core.DBUtility;
using System.Data;
using System.Data.Common;

namespace CoScheduling.Core.DAL
{
    public class TaskRegionPoint
    {
        //数据库连接字符串(web.config来配置)，可以动态更改connectionString支持多数据库.		
        public static string connectionString;
        public TaskRegionPoint()
        { 
            //connectionString = PubConstant.GetConnectionString("");
            connectionString = @"server=HYCSIM51DM4IL8B;database=CoMonitoring; integrated security=SSPI ";//建立的时候就确定了，连接数据库的路径
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.TaskRegionPoint model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO TaskRequirements_ObservationRegion(");
            strSql.Append("TaskID,PointID,Point_Lon,Point_Lat)");
            strSql.Append(" VALUES (");
            strSql.Append("@in_TaskID,@in_PointID,@in_Point_Lon,@in_Point_Lat)");
            SqlParameter[] cmdParms = new SqlParameter[]{
				new SqlParameter("@in_TaskID", SqlDbType.Decimal),
				new SqlParameter("@in_PointID", SqlDbType.Decimal),
				new SqlParameter("@in_Point_Lon", SqlDbType.Decimal),
				new SqlParameter("@in_Point_Lat", SqlDbType.Decimal)};
            cmdParms[0].Value = model.TaskID;
            cmdParms[1].Value = model.PointID;
            cmdParms[2].Value = model.Point_Lon;
            cmdParms[3].Value = model.Point_Lat;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Model.TaskRegionPoint model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE TaskRequirements_ObservationRegion SET ");
            strSql.Append("PointID=@in_PointID,");
            strSql.Append("Point_Lon=@in_Point_Lon,");
            strSql.Append("Point_Lat=@in_Point_Lat");
            strSql.Append(" WHERE TaskID=@in_TaskID");
            SqlParameter[] cmdParms = new SqlParameter[]{
				new SqlParameter("@in_TaskID", SqlDbType.Decimal),
				new SqlParameter("@in_PointID", SqlDbType.Decimal),
				new SqlParameter("@in_Point_Lon", SqlDbType.Decimal),
				new SqlParameter("@in_Point_Lat", SqlDbType.Decimal)};
            cmdParms[0].Value = model.TaskID;
            cmdParms[1].Value = model.PointID;
            cmdParms[2].Value = model.Point_Lon;
            cmdParms[3].Value = model.Point_Lat;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(decimal TaskID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM TaskRequirements_ObservationRegion ");
            strSql.Append(" WHERE TaskID=@in_TaskID");
            SqlParameter[] cmdParms = new SqlParameter[]{
				new SqlParameter("@in_TaskID", SqlDbType.Decimal)};
            cmdParms[0].Value = TaskID;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        #region 数据库查询操作
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(decimal TaskID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM TaskRequirements_ObservationRegion");
            strSql.Append(" WHERE TaskID=@in_TaskID");
            SqlParameter[] cmdParms = new SqlParameter[]{
				new SqlParameter("@in_TaskID", SqlDbType.Decimal)};
            cmdParms[0].Value = TaskID;
            return DbHelperSQL.Exists(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.TaskRegionPoint GetModel(decimal TaskID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM TaskRequirements_ObservationRegion ");
            strSql.Append(" WHERE TaskID=" + TaskID);

            Model.TaskRegionPoint model = null;
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
        public List<Model.TaskRegionPoint> GetList()
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM TaskRequirements_ObservationRegion");
            using (DbDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.TaskRegionPoint> lst = GetList(dr);
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
            strSql.Append(" FROM TaskRequirements_ObservationRegion ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }
        #endregion
        #region -------- 私有方法，通常情况下无需修改 --------

        /// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        private Model.TaskRegionPoint GetModel(DbDataReader dr)
        {
            Model.TaskRegionPoint model = new Model.TaskRegionPoint();
            model.TaskID = Convert.ToDecimal(dr["TaskID"]);
            model.PointID = Convert.ToDecimal(dr["PointID"]);
            model.Point_Lon = Convert.ToDecimal(dr["Point_Lon"]);
            model.Point_Lat = Convert.ToDecimal(dr["Point_Lat"]);
            return model;
        }

        /// <summary>
        /// 由DbDataReader得到泛型数据列表
        /// </summary>
        private List<Model.TaskRegionPoint> GetList(DbDataReader dr)
        {
            List<Model.TaskRegionPoint> lst = new List<Model.TaskRegionPoint>();
            while (dr.Read())
            {
                lst.Add(GetModel(dr));
            }
            return lst;
        }

        #endregion

    }
}
