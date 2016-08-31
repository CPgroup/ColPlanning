//------------------------------------------------------------------------------
// 创建标识: 尹健
// 创建描述: 无人机集结点数据访问类
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
	/// 数据访问类 AssemblyPoint
	/// </summary>
	public class AssemblyPoint 
	{
		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(CoScheduling.Core.Model.AssemblyPoint model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("INSERT INTO AssemblyPoint(");
            strSql.Append("Name,TID,LON,LAT,RoadType,RoadID,RoadName)");
			strSql.Append(" VALUES (");
            strSql.Append("@in_Name,@in_TID,@in_LON,@in_LAT,@in_RoadType,@in_RoadID,@in_RoadName)");
            SqlParameter[] cmdParms = new SqlParameter[]{
                new SqlParameter("@in_Name", SqlDbType.NVarChar),
				new SqlParameter("@in_TID", SqlDbType.Int),
				new SqlParameter("@in_LON", SqlDbType.Decimal),
				new SqlParameter("@in_LAT", SqlDbType.Decimal),
				new SqlParameter("@in_RoadType", SqlDbType.NVarChar),
				new SqlParameter("@in_RoadID", SqlDbType.Int),
				new SqlParameter("@in_RoadName", SqlDbType.NVarChar)};

            cmdParms[0].Value = model.Name;
            cmdParms[1].Value = model.TID;
            cmdParms[2].Value = model.LON;
            cmdParms[3].Value = model.LAT;
            cmdParms[4].Value = model.RoadType;
            cmdParms[5].Value = model.RoadID;
            cmdParms[6].Value = model.RoadName;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public int Update(CoScheduling.Core.Model.AssemblyPoint model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("UPDATE AssemblyPoint SET ");
			strSql.Append("Name=@in_Name,");
			strSql.Append("TID=@in_TID,");
			strSql.Append("LON=@in_LON,");
			strSql.Append("LAT=@in_LAT,");
			strSql.Append("RoadType=@in_RoadType,");
			strSql.Append("RoadID=@in_RoadID,");
			strSql.Append("RoadName=@in_RoadName");
			strSql.Append(" WHERE ID=@in_ID");
            SqlParameter[] cmdParms = new SqlParameter[]{
                new SqlParameter("@in_Name", SqlDbType.NVarChar),
				new SqlParameter("@in_TID", SqlDbType.Int),
				new SqlParameter("@in_LON", SqlDbType.Decimal),
				new SqlParameter("@in_LAT", SqlDbType.Decimal),
				new SqlParameter("@in_RoadType", SqlDbType.NVarChar),
				new SqlParameter("@in_RoadID", SqlDbType.Int),
				new SqlParameter("@in_RoadName", SqlDbType.NVarChar),
				new SqlParameter("@in_ID", SqlDbType.Int)};

            cmdParms[0].Value = model.Name;
            cmdParms[1].Value = model.TID;
            cmdParms[2].Value = model.LON;
            cmdParms[3].Value = model.LAT;
            cmdParms[4].Value = model.RoadType;
            cmdParms[5].Value = model.RoadID;
            cmdParms[6].Value = model.RoadName;
            cmdParms[7].Value = model.ID;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public int Delete(int ID)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("DELETE FROM AssemblyPoint ");
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
            return DbHelperSQL.GetMaxID("AssemblyPoint");
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM AssemblyPoint");
            strSql.Append(" WHERE ID=" + ID.ToString());
            return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.AssemblyPoint GetModel(int ID)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("SELECT * FROM AssemblyPoint ");
			strSql.Append(" WHERE ID="+ID.ToString());
			
			Model.AssemblyPoint model = null;
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
		public List<Model.AssemblyPoint> GetList()
		{
			StringBuilder strSql = new StringBuilder("SELECT * FROM AssemblyPoint");
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
			{
				List<Model.AssemblyPoint> lst = GetList(dr);
				return lst;
			}
		}

		/// <summary>
		/// 得到数据条数
		/// </summary>
		public int GetCount(string condition)
		{
            return DbHelperSQL.GetCount("AssemblyPoint", condition);
		}


        /// <summary>
        /// 获取页数
        /// </summary>
        public int GetPageNum(int PageSize, string WhereClause)
        {
            StringBuilder strSql = new StringBuilder("SELECT count(*) FROM AssemblyPoint");
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
        public List<Model.AssemblyPoint> GetPageList(int pageSize, int pageIndex, string WhereClause)
		{
            string strSql = "SELECT TOP " + pageSize.ToString() + " * " +
                             "    FROM " +
                                        " ( " +
                                        " SELECT ROW_NUMBER() OVER (ORDER BY BH) AS RowNumber,* FROM AssemblyPoint "
                                             + (!string.IsNullOrEmpty(WhereClause) ? " where " + WhereClause : "") +
                                         ") A " +
                                 "WHERE RowNumber > " + pageSize.ToString() + "*(" + pageIndex.ToString() + "-1)  ";
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString(), null))
            {
                List<Model.AssemblyPoint> lst = GetList(dr);
                return lst;
            }
		}

		#region -------- 私有方法，通常情况下无需修改 --------

		/// <summary>
		/// 由一行数据得到一个实体
		/// </summary>
		private Model.AssemblyPoint GetModel(DbDataReader dr)
		{
			Model.AssemblyPoint model = new Model.AssemblyPoint();
            model.ID = DbHelperSQL.GetInt(dr["ID"]);
            model.Name = DbHelperSQL.GetString(dr["Name"]);
            model.TID = DbHelperSQL.GetInt(dr["TID"]);
            model.LON = DbHelperSQL.GetDouble(dr["LON"]);
            model.LAT = DbHelperSQL.GetDouble(dr["LAT"]);
            model.RoadType = DbHelperSQL.GetString(dr["RoadType"]);
            model.RoadID = DbHelperSQL.GetInt(dr["RoadID"]);
            model.RoadName = DbHelperSQL.GetString(dr["RoadName"]);
			return model;
		}

		/// <summary>
		/// 由DbDataReader得到泛型数据列表
		/// </summary>
		private List<Model.AssemblyPoint> GetList(DbDataReader dr)
		{
			List<Model.AssemblyPoint> lst = new List<Model.AssemblyPoint>();
			while (dr.Read())
			{
				lst.Add(GetModel(dr));
			}
			return lst;
		}

		#endregion
	}
}
