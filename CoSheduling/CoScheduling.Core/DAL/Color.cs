//------------------------------------------------------------------------------
// 创建标识: 尹健
// 创建描述: 任务区颜色数据访问类
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
	/// 数据访问类 Color
	/// </summary>
	public class Color 
	{
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Model.Color model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("INSERT INTO Color(");
            strSql.Append("Color)");
			strSql.Append(" VALUES (");
            strSql.Append("@in_Color)");
			 SqlParameter[] cmdParms = new SqlParameter[]{
                new SqlParameter("@in_Color", SqlDbType.NVarChar)};

             cmdParms[0].Value = model.TColor;

             return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public int Update(Model.Color model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("UPDATE Color SET ");
			strSql.Append("Color=@in_Color");
			strSql.Append(" WHERE ID=@in_ID");
            SqlParameter[] cmdParms = new SqlParameter[]{
                new SqlParameter("@in_Color", SqlDbType.NVarChar),
				 new SqlParameter("@in_ID", SqlDbType.Int)};
            cmdParms[0].Value = model.TColor;
            cmdParms[1].Value = model.ID;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
		}

		/// <summary>
		/// 删除所有数据
		/// </summary>
		public int DeleteAll()
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("DELETE  FROM Color ");
            return DbHelperSQL.ExecuteSql(strSql.ToString());
		}

		/// <summary>
		/// 获取泛型数据列表
		/// </summary>
		public List<Model.Color> GetList()
		{
			StringBuilder strSql = new StringBuilder("SELECT * FROM Color");
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
				List<Model.Color> lst = GetList(dr);
				return lst;
			}
		}

		#region -------- 私有方法，通常情况下无需修改 --------

		/// <summary>
		/// 由一行数据得到一个实体
		/// </summary>
		private Model.Color GetModel(DbDataReader dr)
		{
			Model.Color model = new Model.Color();
			model.ID = DbHelperSQL.GetInt(dr["ID"]);
			model.TColor = DbHelperSQL.GetString(dr["Color"]);
			return model;
		}

		/// <summary>
		/// 由DbDataReader得到泛型数据列表
		/// </summary>
		private List<Model.Color> GetList(DbDataReader dr)
		{
			List<Model.Color> lst = new List<Model.Color>();
			while (dr.Read())
			{
				lst.Add(GetModel(dr));
			}
			return lst;
		}

		#endregion
	}
}
