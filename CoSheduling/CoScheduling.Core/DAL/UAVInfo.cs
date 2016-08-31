//------------------------------------------------------------------------------
// 创建标识: 尹健
// 创建描述: 无人机监信息数据访问类
// 创建时间:2014.4.2
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
    /// 数据访问类 UAVInfo
    /// </summary>
    public class UAVInfo
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.UAVInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO UAVInfo(");
            strSql.Append("CompanyName,TeamName,model,XLongtitude,YLatitude,UpdateTime)");
            strSql.Append(" VALUES (");
            strSql.Append("@in_CompanyName,@in_TeamName,@in_model,@in_XLongtitude,@in_YLatitude,@in_UpdateTime)");
            SqlParameter[] cmdParms = new SqlParameter[]{
                new SqlParameter("@in_CompanyName", SqlDbType.NVarChar),
				new SqlParameter("@in_TeamName", SqlDbType.NVarChar),
				new SqlParameter("@in_model", SqlDbType.NVarChar),
				new SqlParameter("@in_XLongtitude", SqlDbType.Decimal),
				new SqlParameter("@in_YLatitude", SqlDbType.Decimal),
				new SqlParameter("@in_UpdateTime", SqlDbType.NVarChar)};

            cmdParms[0].Value = model.CompanyName;
            cmdParms[1].Value = model.TeamName;
            cmdParms[2].Value = model.model;
            cmdParms[3].Value = model.XLongtitude;
            cmdParms[4].Value = model.YLatitude;
            cmdParms[5].Value = model.UpdateTime;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Model.UAVInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE UAVInfo SET ");
            strSql.Append("CompanyName=@in_CompanyName,");
            strSql.Append("TeamName=@in_TeamName,");
            strSql.Append("model=@in_model,");
            strSql.Append("XLongtitude=@in_XLongtitude,");
            strSql.Append("YLatitude=@in_YLatitude,");
            strSql.Append("UpdateTime=@in_UpdateTime");
            strSql.Append(" WHERE id=@in_id");
            SqlParameter[] cmdParms = new SqlParameter[]{
                new SqlParameter("@in_CompanyName", SqlDbType.NVarChar),
				new SqlParameter("@in_TeamName", SqlDbType.NVarChar),
				new SqlParameter("@in_model", SqlDbType.NVarChar),
				new SqlParameter("@in_XLongtitude", SqlDbType.Decimal),
				new SqlParameter("@in_YLatitude", SqlDbType.Decimal),
				new SqlParameter("@in_UpdateTime", SqlDbType.NVarChar),
				new SqlParameter("@in_id", SqlDbType.Int)};

            cmdParms[0].Value = model.CompanyName;
            cmdParms[1].Value = model.TeamName;
            cmdParms[2].Value = model.model;
            cmdParms[3].Value = model.XLongtitude;
            cmdParms[4].Value = model.YLatitude;
            cmdParms[5].Value = model.UpdateTime;
            cmdParms[6].Value = model.id;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM UAVInfo ");
            strSql.Append(" WHERE id=" + id);

            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("UAVInfo");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM UAVInfo");
            strSql.Append(" WHERE id=" + id);
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.UAVInfo GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM UAVInfo ");
            strSql.Append(" WHERE ID=" + ID);
            Model.UAVInfo model = null;
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
        public Model.UAVInfo GetLastModel(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT top 1 * FROM UAVInfo ORDER BY UpdateTime DESC");
            strSql.Append(" WHERE "+where );
            Model.UAVInfo model = null;
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
        public List<Model.UAVInfo> GetList(string where)
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM UAVInfo Where " + where + "");
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.UAVInfo> lst = GetList(dr);
                return lst;
            }
        }

        /// <summary>
        /// 得到数据条数
        /// </summary>
        public int GetCount(string condition)
        {
            return DbHelperSQL.GetCount("UAVInfo", condition);
        }

        /// <summary>
        /// 获取页数
        /// </summary>
        public int GetPageNum(int PageSize, string WhereClause)
        {
            StringBuilder strSql = new StringBuilder("SELECT count(*) FROM UAVInfo");
            if (!string.IsNullOrEmpty(WhereClause))
                strSql.Append(" where " + WhereClause);
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString(), null))
            {
                if (dr.Read())
                {
                    int cnt = int.Parse(dr[0].ToString());
                    return (int)Math.Ceiling((double)(Convert.ToDouble(cnt.ToString()) / Convert.ToDouble(PageSize.ToString())));
                }
                else return 0;
            }
        }

        /// <summary>
        /// 分页获取泛型数据列表
        /// </summary>
        public List<Model.UAVInfo> GetPageList(int pageSize, int pageIndex, string WhereClause)
        {
            string strSql = "SELECT TOP " + pageSize.ToString() + " * " +
                             "    FROM " +
                                        " ( " +
                                        " SELECT ROW_NUMBER() OVER (ORDER BY BH) AS RowNumber,* FROM UAVInfo "
                                             + (!string.IsNullOrEmpty(WhereClause) ? " where " + WhereClause : "") +
                                         ") A " +
                                 "WHERE RowNumber > " + pageSize.ToString() + "*(" + pageIndex.ToString() + "-1)  ";
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString(), null))
            {
                List<Model.UAVInfo> lst = GetList(dr);
                return lst;
            }
        }

        #region -------- 私有方法，通常情况下无需修改 --------

        /// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        private Model.UAVInfo GetModel(DbDataReader dr)
        {
            Model.UAVInfo model = new Model.UAVInfo();
            model.id = DbHelperSQL.GetInt(dr["id"]);
            model.CompanyName = DbHelperSQL.GetString(dr["CompanyName"]);
            model.TeamName = DbHelperSQL.GetString(dr["TeamName"]);
            model.model = DbHelperSQL.GetString(dr["model"]);
            model.XLongtitude = DbHelperSQL.GetDouble(dr["XLongtitude"]);
            model.YLatitude = DbHelperSQL.GetDouble(dr["YLatitude"]);
            model.UpdateTime = DbHelperSQL.GetDateTime(dr["UpdateTime"]);
            return model;
        }

        /// <summary>
        /// 由DbDataReader得到泛型数据列表
        /// </summary>
        private List<Model.UAVInfo> GetList(DbDataReader dr)
        {
            List<Model.UAVInfo> lst = new List<Model.UAVInfo>();
            while (dr.Read())
            {
                lst.Add(GetModel(dr));
            }
            return lst;
        }

        #endregion
    }
}
