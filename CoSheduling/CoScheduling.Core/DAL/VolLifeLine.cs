//------------------------------------------------------------------------------
// 创建标识: 尹健
// 创建描述: 志愿者上报的生命线 数据访问类
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
	/// 数据访问类 VolLifeLine
	/// </summary>
	public class VolLifeLine
	{
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public int Delete(int ID)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("DELETE FROM VolLifeLine ");
			strSql.Append(" WHERE ID="+ID);
			return DbHelperSQL.ExecuteSql(strSql.ToString());
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.VolLifeLine GetModel(int ID)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("SELECT * FROM VolLifeLine ");
			strSql.Append(" WHERE ID="+ID);
			Model.VolLifeLine model = null;
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
		public List<Model.VolLifeLine> GetList()
		{
			StringBuilder strSql = new StringBuilder("SELECT * FROM VolLifeLine");
            using (DbDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
			{
				List<Model.VolLifeLine> lst = GetList(dr);
				return lst;
			}
		}

		#region -------- 私有方法，通常情况下无需修改 --------

		/// <summary>
		/// 由一行数据得到一个实体
		/// </summary>
		private Model.VolLifeLine GetModel(DbDataReader dr)
		{
			Model.VolLifeLine model = new Model.VolLifeLine();
            model.ID = DbHelperSQL.GetInt(dr["ID"]);
            model.TelNum = DbHelperSQL.GetString(dr["TelNum"]);
            model.VolName = DbHelperSQL.GetString(dr["VolName"]);
            model.Time = DbHelperSQL.GetDateTime(dr["Time"]);
            model.Road = DbHelperSQL.GetString(dr["Road"]);
            model.GPSString = DbHelperSQL.GetString(dr["GPSString"]);
            model.Describe = DbHelperSQL.GetString(dr["Describe"]);
			return model;
		}

		/// <summary>
		/// 由DbDataReader得到泛型数据列表
		/// </summary>
		private List<Model.VolLifeLine> GetList(DbDataReader dr)
		{
			List<Model.VolLifeLine> lst = new List<Model.VolLifeLine>();
			while (dr.Read())
			{
				lst.Add(GetModel(dr));
			}
			return lst;
		}

		#endregion
	}
}
