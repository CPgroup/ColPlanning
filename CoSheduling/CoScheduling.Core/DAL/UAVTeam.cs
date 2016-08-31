//------------------------------------------------------------------------------
// 创建标识: 尹健
// 创建描述: 无人机监测方案数据访问类
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
	/// 数据访问类 UAVTeam
	/// </summary>
	public class UAVTeam 
	{
        ///// <summary>
        ///// 增加一条数据
        ///// </summary>
        //public int Add(Model.UAVTeam model)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("INSERT INTO UAVTeam(");
        //    strSql.Append("ManagerName,CompanyName,TeamName,CountNumber,UAVModel,XLongtitude,YLatitude,MobileNumber)");
        //    strSql.Append(" VALUES (");
        //    strSql.Append("@in_ManagerName,@in_CompanyName,@in_TeamName,@in_CountNumber,@in_UAVModel,@in_XLongtitude,@in_YLatitude,@in_MobileNumber)");
        //    DbParameter[] cmdParms = {
        //        CoSchedulingHelper.CreateInDbParameter("@in_ManagerName", DbType.String, model.ManagerName),
        //        CoSchedulingHelper.CreateInDbParameter("@in_CompanyName", DbType.String, model.CompanyName),
        //        CoSchedulingHelper.CreateInDbParameter("@in_TeamName", DbType.String, model.TeamName),
        //        CoSchedulingHelper.CreateInDbParameter("@in_CountNumber", DbType.Int32, model.CountNumber),
        //        CoSchedulingHelper.CreateInDbParameter("@in_UAVModel", DbType.String, model.UAVModel),
        //        CoSchedulingHelper.CreateInDbParameter("@in_XLongtitude", DbType.Double, model.XLongtitude),
        //        CoSchedulingHelper.CreateInDbParameter("@in_YLatitude", DbType.Double, model.YLatitude),
        //        CoSchedulingHelper.CreateInDbParameter("@in_MobileNumber", DbType.String, model.MobileNumber)};

        //    return CoSchedulingHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), cmdParms);
        //}

        ///// <summary>
        ///// 更新一条数据
        ///// </summary>
        //public int Update(Model.UAVTeam model)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("UPDATE UAVTeam SET ");
        //    strSql.Append("ManagerName=@in_ManagerName,");
        //    strSql.Append("CompanyName=@in_CompanyName,");
        //    strSql.Append("TeamName=@in_TeamName,");
        //    strSql.Append("CountNumber=@in_CountNumber,");
        //    strSql.Append("UAVModel=@in_UAVModel,");
        //    strSql.Append("XLongtitude=@in_XLongtitude,");
        //    strSql.Append("YLatitude=@in_YLatitude,");
        //    strSql.Append("UpdateTime=@in_UpdateTime,");
        //    strSql.Append("MobileNumber=@in_MobileNumber");
        //    strSql.Append(" WHERE ID=@in_ID");
        //    DbParameter[] cmdParms = {
        //        CoSchedulingHelper.CreateInDbParameter("@in_ManagerName", DbType.String, model.ManagerName),
        //        CoSchedulingHelper.CreateInDbParameter("@in_CompanyName", DbType.String, model.CompanyName),
        //        CoSchedulingHelper.CreateInDbParameter("@in_TeamName", DbType.String, model.TeamName),
        //        CoSchedulingHelper.CreateInDbParameter("@in_CountNumber", DbType.Int32, model.CountNumber),
        //        CoSchedulingHelper.CreateInDbParameter("@in_UAVModel", DbType.String, model.UAVModel),
        //        CoSchedulingHelper.CreateInDbParameter("@in_XLongtitude", DbType.Double, model.XLongtitude),
        //        CoSchedulingHelper.CreateInDbParameter("@in_YLatitude", DbType.Double, model.YLatitude),
        //        CoSchedulingHelper.CreateInDbParameter("@in_UpdateTime", DbType.String, model.UpdateTime),
        //        CoSchedulingHelper.CreateInDbParameter("@in_MobileNumber", DbType.String, model.MobileNumber),
        //        CoSchedulingHelper.CreateInDbParameter("@in_ID", DbType.Int32, model.ID)};
        //    return CoSchedulingHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), cmdParms);
        //}

        ///// <summary>
        ///// 删除一条数据
        ///// </summary>
        //public int Delete(int ID)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("DELETE FROM UAVTeam ");
        //    strSql.Append(" WHERE ID=@in_ID");
        //    DbParameter[] cmdParms = {
        //        CoSchedulingHelper.CreateInDbParameter("@in_ID", DbType.Int32, ID)};

        //    return CoSchedulingHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), cmdParms);
        //}

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
            return DbHelperSQL.GetMaxID("UAVTeam");
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("SELECT COUNT(1) FROM UAVTeam");
			strSql.Append(" WHERE ID="+ID);
            return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.UAVTeam GetModel(int ID)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM UAVTeam ");
            strSql.Append(" WHERE ID=" + ID);
            Model.UAVTeam model = null;
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
		public List<Model.UAVTeam> GetList()
		{
            StringBuilder strSql = new StringBuilder("SELECT * FROM UAVTeam");
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.UAVTeam> lst = GetList(dr);
                return lst;
            }
		}

		/// <summary>
		/// 得到数据条数
		/// </summary>
		public int GetCount(string condition)
		{
            return DbHelperSQL.GetCount("UAVTeam", condition);
		}

        /// <summary>
        /// 获取页数
        /// </summary>
        public int GetPageNum(int PageSize, string WhereClause)
        {
            StringBuilder strSql = new StringBuilder("SELECT count(*) FROM UAVTeam");
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
        public List<Model.UAVTeam> GetPageList(int pageSize, int pageIndex, string WhereClause)
        {
            string strSql = "SELECT TOP " + pageSize.ToString() + " * " +
                             "    FROM " +
                                        " ( " +
                                        " SELECT ROW_NUMBER() OVER (ORDER BY BH) AS RowNumber,* FROM UAVTeam "
                                             + (!string.IsNullOrEmpty(WhereClause) ? " where " + WhereClause : "") +
                                         ") A " +
                                 "WHERE RowNumber > " + pageSize.ToString() + "*(" + pageIndex.ToString() + "-1)  ";
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString(), null))
            {
                List<Model.UAVTeam> lst = GetList(dr);
                return lst;
            }
        }

		#region -------- 私有方法，通常情况下无需修改 --------

		/// <summary>
		/// 由一行数据得到一个实体
		/// </summary>
		private Model.UAVTeam GetModel(DbDataReader dr)
		{
			Model.UAVTeam model = new Model.UAVTeam();
            model.ID = DbHelperSQL.GetInt(dr["ID"]);
            model.ManagerName = DbHelperSQL.GetString(dr["ManagerName"]);
            model.CompanyName = DbHelperSQL.GetString(dr["CompanyName"]);
            model.TeamName = DbHelperSQL.GetString(dr["TeamName"]);
            model.CountNumber = DbHelperSQL.GetInt(dr["CountNumber"]);
            model.UAVModel = DbHelperSQL.GetString(dr["UAVModel"]);
            model.XLongtitude = DbHelperSQL.GetDouble(dr["XLongtitude"]);
            model.YLatitude = DbHelperSQL.GetDouble(dr["YLatitude"]);
            model.UpdateTime = DbHelperSQL.GetDateTime(dr["UpdateTime"]);
            model.MobileNumber = DbHelperSQL.GetString(dr["MobileNumber"]);
			return model;
		}

		/// <summary>
		/// 由DbDataReader得到泛型数据列表
		/// </summary>
		private List<Model.UAVTeam> GetList(DbDataReader dr)
		{
			List<Model.UAVTeam> lst = new List<Model.UAVTeam>();
			while (dr.Read())
			{
				lst.Add(GetModel(dr));
			}
			return lst;
		}

		#endregion
	}
}
