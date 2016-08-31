//------------------------------------------------------------------------------
// 创建标识: 尹健
// 创建描述: 灾区监测数据访问类
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
	/// 数据访问类 MonitorTask
	/// </summary>
	public class MonitorTask 
	{
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Model.MonitorTask model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("INSERT INTO MonitorTask(");
            strSql.Append("PID,Name,PolygonString,MBR)");
			strSql.Append(" VALUES (");
            strSql.Append("@in_PID,@in_Name"
                        +"geometry::STGeomFromText('LINESTRING(" + model.PolygonString + ")', 4326)"
                        +"@in_MBR)");
            SqlParameter[] cmdParms = new SqlParameter[]{
                new SqlParameter("@in_PID", SqlDbType.Int),
				new SqlParameter("@in_Name", SqlDbType.NVarChar),
                //new SqlParameter("@in_PolygonString", SqlDbType.Binary),
				new SqlParameter("@in_MBR", SqlDbType.NVarChar)};

            cmdParms[0].Value = model.PID;
            cmdParms[1].Value = model.Name;
            //cmdParms[2].Value = model.PolygonString;
            cmdParms[2].Value = model.MBR;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);

		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public int Update(Model.MonitorTask model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("UPDATE MonitorTask SET ");
			strSql.Append("PID=@in_PID,");
			strSql.Append("Name=@in_Name,");
            strSql.Append("PolygonString=geometry::STGeomFromText('LINESTRING(" + model.PolygonString + ")', 4326),");
			strSql.Append("MBR=@in_MBR");
			strSql.Append(" WHERE ID=@in_ID");
            SqlParameter[] cmdParms = new SqlParameter[]{
                new SqlParameter("@in_PID", SqlDbType.Int),
				new SqlParameter("@in_Name", SqlDbType.NVarChar),
                //new SqlParameter("@in_PolygonString", SqlDbType.Binary),
				new SqlParameter("@in_MBR", SqlDbType.NVarChar),
				new SqlParameter("@in_ID", SqlDbType.Int)};
            cmdParms[0].Value = model.PID;
            cmdParms[1].Value = model.Name;
            //cmdParms[2].Value = model.PolygonString;
            cmdParms[2].Value = model.MBR;
            cmdParms[3].Value = model.ID;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public int Delete(int ID)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("DELETE FROM MonitorTask ");
			strSql.Append(" WHERE ID=@in_ID");
            SqlParameter[] cmdParms = {
				new SqlParameter("@in_ID",System.Data.SqlDbType.Int, ID)};
            cmdParms[0].Value = ID;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
		}

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
            return DbHelperSQL.GetMaxID("MonitorTask");
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("SELECT COUNT(1) FROM MonitorTask");
			strSql.Append(" WHERE ID="+ ID.ToString());
            return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.MonitorTask GetModel(int ID)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("SELECT * FROM MonitorTask ");
			strSql.Append(" WHERE ID="+ID.ToString());
			Model.MonitorTask model = null;
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
		public List<Model.MonitorTask> GetList()
		{
			StringBuilder strSql = new StringBuilder("SELECT * FROM MonitorTask");
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
				List<Model.MonitorTask> lst = GetList(dr);
				return lst;
			}
		}

		/// <summary>
		/// 得到数据条数
		/// </summary>
		public int GetCount(string condition)
		{
            return DbHelperSQL.GetCount("MonitorTask", condition);
		}

        /// <summary>
        /// 获取页数
        /// </summary>
        public int GetPageNum(int PageSize, string WhereClause)
        {
            StringBuilder strSql = new StringBuilder("SELECT count(*) FROM MonitorTask");
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
        public List<Model.MonitorTask> GetPageList(int pageSize, int pageIndex, string WhereClause)
        {
            string strSql = "SELECT TOP " + pageSize.ToString() + " * " +
                             "    FROM " +
                                        " ( " +
                                        " SELECT ROW_NUMBER() OVER (ORDER BY BH) AS RowNumber,* FROM MonitorTask "
                                             + (!string.IsNullOrEmpty(WhereClause) ? " where " + WhereClause : "") +
                                         ") A " +
                                 "WHERE RowNumber > " + pageSize.ToString() + "*(" + pageIndex.ToString() + "-1)  ";
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString(), null))
            {
                List<Model.MonitorTask> lst = GetList(dr);
                return lst;
            }
        }

		#region -------- 私有方法，通常情况下无需修改 --------

		/// <summary>
		/// 由一行数据得到一个实体
		/// </summary>
		private Model.MonitorTask GetModel(DbDataReader dr)
		{
			Model.MonitorTask model = new Model.MonitorTask();
            model.ID = DbHelperSQL.GetInt(dr["ID"]);
            model.PID = DbHelperSQL.GetInt(dr["PID"]);
            model.Name = DbHelperSQL.GetString(dr["Name"]);
            model.PolygonString = DbHelperSQL.GetBinary(dr["PolygonString"]);
            model.MBR = DbHelperSQL.GetString(dr["MBR"]);
			return model;
		}

		/// <summary>
		/// 由DbDataReader得到泛型数据列表
		/// </summary>
		private List<Model.MonitorTask> GetList(DbDataReader dr)
		{
			List<Model.MonitorTask> lst = new List<Model.MonitorTask>();
			while (dr.Read())
			{
				lst.Add(GetModel(dr));
			}
			return lst;
		}

		#endregion
	}
}
