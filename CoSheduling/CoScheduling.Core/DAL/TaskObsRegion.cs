//------------------------------------------------------------------------------
// 创建标识: 李佳霖
// 创建描述: 观测任务的位置点或者矩形区域的访问类
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
    public class TaskObsRegion
    {
        //数据库连接字符串(web.config来配置)，可以动态更改connectionString支持多数据库.		
        public static string connectionString;
        public TaskObsRegion()
        { 
            connectionString = PubConstant.GetConnectionString("");
            //connectionString = @"server=HYCSIM51DM4IL8B;database=CoMonitoring; integrated security=SSPI ";//建立的时候就确定了，连接数据库的路径
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.TaskObsRegion model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO TaskRequirements_ObsRegion(");
            strSql.Append("TaskID,MinLon,MaxLon,MinLat,MaxLat)");
            strSql.Append(" VALUES (");
            strSql.Append("@in_TaskID,@in_MinLon,@in_MaxLon,@in_MinLat,@in_MaxLat)");
            SqlParameter[] cmdParms = new SqlParameter[]{
				new SqlParameter("@in_TaskID", SqlDbType.Decimal),
				new SqlParameter("@in_MinLon", SqlDbType.Decimal),
				new SqlParameter("@in_MaxLon", SqlDbType.Decimal),
				new SqlParameter("@in_MinLat", SqlDbType.Decimal),
                new SqlParameter("@in_MaxLat", SqlDbType.Decimal)};
            cmdParms[0].Value = model.TaskID;
            cmdParms[1].Value = model.MinLon;
            cmdParms[2].Value = model.MaxLon;
            cmdParms[3].Value = model.MinLat;
            cmdParms[4].Value = model.MaxLat;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Model.TaskObsRegion model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE TaskRequirements_ObsRegion SET ");
            strSql.Append("MinLon=@in_Minlon,");
            strSql.Append("MaxLon=@in_MaxLon,");
            strSql.Append("MinLat=@in_MinLat,");
            strSql.Append("MaxLat=@in_MaxLat");
            strSql.Append(" WHERE TaskID=@in_TaskID");
            SqlParameter[] cmdParms = new SqlParameter[]{
				new SqlParameter("@in_TaskID", SqlDbType.Decimal),
				new SqlParameter("@in_MinLon", SqlDbType.Decimal),
				new SqlParameter("@in_MaxLon", SqlDbType.Decimal),
                new SqlParameter("@in_MinLat", SqlDbType.Decimal),
				new SqlParameter("@in_MaxLat", SqlDbType.Decimal)};
            cmdParms[0].Value = model.TaskID;
            cmdParms[1].Value = model.MinLon;
            cmdParms[2].Value = model.MaxLon;
            cmdParms[3].Value = model.MinLat;
            cmdParms[4].Value = model.MaxLat;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(decimal TaskID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM TaskRequirements_ObsRegion ");
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
            strSql.Append("SELECT COUNT(1) FROM TaskRequirements_ObsRegion");
            strSql.Append(" WHERE TaskID=@in_TaskID");
            SqlParameter[] cmdParms = new SqlParameter[]{
				new SqlParameter("@in_TaskID", SqlDbType.Decimal)};
            cmdParms[0].Value = TaskID;
            return DbHelperSQL.Exists(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.TaskObsRegion GetModel(decimal TaskID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM TaskRequirements_ObsRegion ");
            strSql.Append(" WHERE TaskID=" + TaskID);

            Model.TaskObsRegion model = null;
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
        public List<Model.TaskObsRegion> GetList(string whereclause)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM TaskRequirements_ObsRegion ");
            strSql.Append(" WHERE " + whereclause); ;
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.TaskObsRegion> lst = GetList(dr);
                return lst;
            }
        }
        /// <summary>
        /// 获取全部记录
        /// </summary>
        /// <returns></returns>
        public List<Model.TaskObsRegion> GetList()
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM TaskRequirements_ObsRegion");
            using (DbDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.TaskObsRegion> lst = GetList(dr);
                dr.Close();
                return lst;
            }
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetListTable(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * ");
            strSql.Append(" FROM TaskRequirements_ObsRegion ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ORDER BY TaskID");
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }

        /// <summary>
        /// 根据条件获取DataSet数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetListDataSet(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * ");
            strSql.Append(" FROM TaskRequirements_ObsRegion ");
            if (strWhere.Trim() != "")
            {
                strSql.Append("WHERE " + strWhere);
            }
            strSql.Append(" ORDER BY TaskID");
            DataSet dsSat = new DataSet();
            SqlDataAdapter odaSat = new SqlDataAdapter(strSql.ToString(), connectionString);
            if (dsSat.Tables["TaskRequirements_ObsRegion"] != null)
            {
                dsSat.Tables["TaskRequirements_ObsRegion"].Clear();
            }

            odaSat.Fill(dsSat, "TaskRequirements_ObsRegion");

            return dsSat;
        }

        /// <summary>
        /// 得到数据条数
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT (*) ");
            strSql.Append(" FROM TaskRequirements_ObsRegion ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }
        #endregion

        #region -------- 私有方法，通常情况下无需修改 --------

        /// <summary>
        /// 由一行数据得到一个实体,还有很多问题，什么时候用try catch,什么时候不用
        /// </summary>
        private Model.TaskObsRegion GetModel(DbDataReader dr)
        {

            CoScheduling.Core.Model.TaskObsRegion model = new CoScheduling.Core.Model.TaskObsRegion();
            model.TaskID = Convert.ToDecimal(dr["TaskID"]);
            try
            {
                model.MinLon = Convert.ToDecimal(dr["MinLon"]);
            }
            catch
            {
                model.MinLon = Convert.ToDecimal("-1");
            }

            try
            {
                model.MaxLon = Convert.ToDecimal(dr["MaxLon"]);
            }
            catch
            {
                model.MaxLon = Convert.ToDecimal("-1");
            }
            try
            {
                model.MinLat = Convert.ToDecimal(dr["MinLat"]);
            }
            catch
            {
                model.MinLat = Convert.ToDecimal("-1");
            }
            try
            {
                model.MaxLat = Convert.ToDecimal(dr["MaxLat"]);
            }
            catch
            {
                model.MaxLat = Convert.ToDecimal("-1");
            }
            return model;
        }
        /// <summary>
        /// 由DbDataReader得到泛型数据列表
        /// </summary>
        private List<Model.TaskObsRegion> GetList(DbDataReader dr)
        {
            List<Model.TaskObsRegion> lst = new List<Model.TaskObsRegion>();
            while (dr.Read())
            {
                lst.Add(GetModel(dr));
            }
            return lst;
        }

        #endregion





    }
}
