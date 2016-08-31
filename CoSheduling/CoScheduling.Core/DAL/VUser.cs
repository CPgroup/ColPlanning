//------------------------------------------------------------------------------
// 创建标识: 尹健
// 创建描述: 志愿者信息 数据访问类
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
	/// 数据访问类 VUser
	/// </summary>
	public class VUser 
	{
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.VUser GetModel(int ID)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("SELECT * FROM VUser ");
			strSql.Append(" WHERE ID="+ID);
			Model.VUser model = null;
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
        public List<Model.VUser> GetList(string WhereClause)
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM  VUser Where " + WhereClause + "");
            using (DbDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.VUser> lst = GetList(dr);
                return lst;
            }
        }

		/// <summary>
		/// 获取泛型数据列表
		/// </summary>
		public List<Model.VUser> GetList()
		{
            StringBuilder strSql = new StringBuilder("SELECT * FROM VUser ");
            using (DbDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
			{
				List<Model.VUser> lst = GetList(dr);
				return lst;
			}
		}

        /// <summary>
        /// 获取在线的泛型数据列表
        /// </summary>
        public List<Model.VUser> GetOnlineList()
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM VUser WHERE Flag=1");
            using (DbDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.VUser> lst = GetList(dr);
                return lst;
            }
        }


		#region -------- 私有方法，通常情况下无需修改 --------

		/// <summary>
		/// 由一行数据得到一个实体
		/// </summary>
		private Model.VUser GetModel(DbDataReader dr)
		{
			Model.VUser model = new Model.VUser();
            model.ID = DbHelperSQL.GetInt(dr["ID"]);
            model.LoginName = DbHelperSQL.GetString(dr["LoginName"]);
            model.Pass = DbHelperSQL.GetString(dr["Pass"]);
            model.RealName = DbHelperSQL.GetString(dr["RealName"]);
            model.Sex = DbHelperSQL.GetString(dr["Sex"]);
            model.Age = DbHelperSQL.GetString(dr["Age"]);
            model.Address = DbHelperSQL.GetString(dr["Address"]);
            model.Degree = DbHelperSQL.GetString(dr["Degree"]);
            model.Occupation = DbHelperSQL.GetString(dr["Occupation"]);
            model.Tel = DbHelperSQL.GetString(dr["Tel"]);
            model.LAT = DbHelperSQL.GetDouble(dr["LAT"]);
            model.LON = DbHelperSQL.GetDouble(dr["LON"]);
            model.Flag = DbHelperSQL.GetBool(dr["Flag"]);
			return model;
		}

		/// <summary>
		/// 由DbDataReader得到泛型数据列表
		/// </summary>
		private List<Model.VUser> GetList(DbDataReader dr)
		{
			List<Model.VUser> lst = new List<Model.VUser>();
			while (dr.Read())
			{
				lst.Add(GetModel(dr));
			}
			return lst;
		}

		#endregion
	}
}
