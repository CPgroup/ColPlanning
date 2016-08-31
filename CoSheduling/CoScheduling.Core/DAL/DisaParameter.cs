//------------------------------------------------------------------------------
// 创建标识: 尹健
// 创建描述: 灾区范围参数数据访问类
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
	/// 数据访问类 DisaParameter
	/// </summary>
	public class DisaParameter 
	{
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public int Update(Model.DisaParameter model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("UPDATE DisaParameter SET ");
			strSql.Append("A=@in_A,");
			strSql.Append("B=@in_B,");
			strSql.Append("C=@in_C,");
			strSql.Append("D=@in_D ");
			strSql.Append(" WHERE ID=@in_ID");
            SqlParameter[] cmdParms = new SqlParameter[]{
                new SqlParameter("@in_A", SqlDbType.Decimal),
				new SqlParameter("@in_B", SqlDbType.Decimal),
				new SqlParameter("@in_C", SqlDbType.Decimal),
				new SqlParameter("@in_D", SqlDbType.Decimal),
				new SqlParameter("@in_ID", SqlDbType.Int)};

            cmdParms[0].Value = model.A;
            cmdParms[1].Value = model.B;
            cmdParms[2].Value = model.C;
            cmdParms[3].Value = model.D;
            cmdParms[4].Value = model.ID;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
		}

		

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.DisaParameter GetModel(int ID)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("SELECT * FROM DisaParameter ");
			strSql.Append(" WHERE ID="+ID);
			Model.DisaParameter model = null;
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
		public List<Model.DisaParameter> GetList()
		{
			StringBuilder strSql = new StringBuilder("SELECT * FROM DisaParameter");
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
				List<Model.DisaParameter> lst = GetList(dr);
				return lst;
			}
		}


		#region -------- 私有方法，通常情况下无需修改 --------

		/// <summary>
		/// 由一行数据得到一个实体
		/// </summary>
		private Model.DisaParameter GetModel(DbDataReader dr)
		{
			Model.DisaParameter model = new Model.DisaParameter();
            model.ID = DbHelperSQL.GetInt(dr["ID"]);
            model.A = DbHelperSQL.GetDouble(dr["A"]);
            model.B = DbHelperSQL.GetDouble(dr["B"]);
            model.C = DbHelperSQL.GetDouble(dr["C"]);
            model.D = DbHelperSQL.GetDouble(dr["D"]);
            model.isMajorAxis = DbHelperSQL.GetBool(dr["isMajorAxis"]);
			return model;
		}

		/// <summary>
		/// 由DbDataReader得到泛型数据列表
		/// </summary>
		private List<Model.DisaParameter> GetList(DbDataReader dr)
		{
			List<Model.DisaParameter> lst = new List<Model.DisaParameter>();
			while (dr.Read())
			{
				lst.Add(GetModel(dr));
			}
			return lst;
		}

		#endregion
	}
}
