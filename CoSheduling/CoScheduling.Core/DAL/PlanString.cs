//------------------------------------------------------------------------------
// 创建标识: 尹健
// 创建描述: 规划结果字符串数据访问类
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
	/// 数据访问类 PlanString
	/// </summary>
	public class PlanString 
	{
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Model.PlanString model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("INSERT INTO PlanString(");
            strSql.Append("PlanString,PID)");
			strSql.Append(" VALUES (");
            strSql.Append("@in_PlanString,@in_PID)");
            SqlParameter[] cmdParms = new SqlParameter[]{
                new SqlParameter("@in_PlanString", SqlDbType.NVarChar),
				new SqlParameter("@in_PID", SqlDbType.Int)};

            cmdParms[0].Value = model.PlanedString;
            cmdParms[1].Value = model.PID;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public int Update(Model.PlanString model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("UPDATE PlanString SET ");
			strSql.Append("PlanString=@in_PlanString,");
			strSql.Append("PID=@in_PID");
			strSql.Append(" WHERE ID=@in_ID");
            SqlParameter[] cmdParms = new SqlParameter[]{
                new SqlParameter("@in_PlanString", SqlDbType.NVarChar),
				new SqlParameter("@in_PID", SqlDbType.Int),
				new SqlParameter("@in_ID", SqlDbType.Int)};
            cmdParms[0].Value = model.PlanedString;
            cmdParms[1].Value = model.PID;
            cmdParms[2].Value = model.ID;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public int Delete(int ID)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("DELETE FROM PlanString ");
			strSql.Append(" WHERE ID="+ID);
            return DbHelperSQL.ExecuteSql(strSql.ToString());
		}


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool ExistsPID(int ID)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("SELECT COUNT(1) FROM PlanString");
			strSql.Append(" WHERE PID="+ID);
            return DbHelperSQL.Exists(strSql.ToString());
		}

        /// <summary>
        /// 得到PlanString
        /// </summary>
        public string GetPlanString(int PID)
        {
            string pStr = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT PlanString FROM PlanString ");
            strSql.Append(" WHERE PID=" + PID);
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (dr.Read())
                {
                    pStr = Convert.ToString(dr["PlanString"]);
                }
                return pStr;
            }
        }

        /// <summary>
        /// 得到ID
        /// </summary>
        public int GetID(int PID)
        {
            int id = -1; 
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ID FROM PlanString ");
            strSql.Append(" WHERE PID=" + PID);
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (dr.Read())
                {
                    id =Convert.ToInt32( dr["ID"]);
                }
                return id;
            }
        }

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.PlanString GetModel(int ID)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("SELECT * FROM PlanString ");
			strSql.Append(" WHERE ID="+ID);
			Model.PlanString model = null;
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
		public List<Model.PlanString> GetList()
		{
			StringBuilder strSql = new StringBuilder("SELECT * FROM PlanString");
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
				List<Model.PlanString> lst = GetList(dr);
				return lst;
			}
		}



		#region -------- 私有方法，通常情况下无需修改 --------

		/// <summary>
		/// 由一行数据得到一个实体
		/// </summary>
		private Model.PlanString GetModel(DbDataReader dr)
		{
			Model.PlanString model = new Model.PlanString();
			model.ID = DbHelperSQL.GetInt(dr["ID"]);
            model.PlanedString = DbHelperSQL.GetString(dr["PlanString"]);
            model.PID = DbHelperSQL.GetInt(dr["PID"]);
			return model;
		}

		/// <summary>
		/// 由DbDataReader得到泛型数据列表
		/// </summary>
		private List<Model.PlanString> GetList(DbDataReader dr)
		{
			List<Model.PlanString> lst = new List<Model.PlanString>();
			while (dr.Read())
			{
				lst.Add(GetModel(dr));
			}
			return lst;
		}

		#endregion
	}
}
