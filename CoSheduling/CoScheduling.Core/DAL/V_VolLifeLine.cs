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
	/// 数据访问类 V_VolLifeLine
	/// </summary>
	public class V_VolLifeLine 
	{
		
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public int Delete(int ID)
		{
			StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM VRoadInfo ");//从VRoadInfo删除（视图不能删除）
			strSql.Append(" WHERE ID="+ID);
			return DbHelperSQL.ExecuteSql(strSql.ToString());
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.V_VolLifeLine GetModel(int ID)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("SELECT * FROM V_VolLifeLine ");
			strSql.Append(" WHERE ID="+ID);
			Model.V_VolLifeLine model = null;
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
		public List<Model.V_VolLifeLine> GetList()
		{
			StringBuilder strSql = new StringBuilder("SELECT * FROM V_VolLifeLine");
            using (DbDataReader dr = DbHelperSQL.ExecuteReader( strSql.ToString()))
			{
				List<Model.V_VolLifeLine> lst = GetList(dr);
				return lst;
			}
		}

        /// <summary>
        /// 获取泛型数据列表
        /// </summary>
        public List<Model.V_VolLifeLine> GetList(string whereclause)
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM V_VolLifeLine WHERE Address LIKE '%" + whereclause + "%'");
            using (DbDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.V_VolLifeLine> lst = GetList(dr);
                return lst;
            }
        }


		#region -------- 私有方法，通常情况下无需修改 --------

		/// <summary>
		/// 由一行数据得到一个实体
		/// </summary>
		private Model.V_VolLifeLine GetModel(DbDataReader dr)
		{
			Model.V_VolLifeLine model = new Model.V_VolLifeLine();
            model.ID = DbHelperSQL.GetInt(dr["ID"]);
            model.Tel = DbHelperSQL.GetString(dr["Tel"]);
            model.StartStr = DbHelperSQL.GetString(dr["StartStr"]);
            model.EndStr = DbHelperSQL.GetString(dr["EndStr"]);
            model.Describe = DbHelperSQL.GetString(dr["Describe"]);
            model.RoadPoint = DbHelperSQL.GetString(dr["RoadPoint"]);
            model.IsChecked = DbHelperSQL.GetString(dr["IsChecked"]);
            model.Type = DbHelperSQL.GetString(dr["Type"]);
            model.RealName = DbHelperSQL.GetString(dr["RealName"]);
            model.Time =DbHelperSQL.GetString(dr["Time"]);
			return model;
		}

		/// <summary>
		/// 由DbDataReader得到泛型数据列表
		/// </summary>
		private List<Model.V_VolLifeLine> GetList(DbDataReader dr)
		{
			List<Model.V_VolLifeLine> lst = new List<Model.V_VolLifeLine>();
			while (dr.Read())
			{
				lst.Add(GetModel(dr));
			}
			return lst;
		}

		#endregion
	}
}
