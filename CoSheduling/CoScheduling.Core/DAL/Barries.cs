//------------------------------------------------------------------------------
// 创建标识: 尹健
// 创建描述: 障碍点数据访问类
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
	/// 数据访问类 Barries
	/// </summary>
	public class Barries 
	{
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Model.Barries model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("INSERT INTO Barries(");
            strSql.Append("LON,LAT,PID,BarriesName,UID)");
			strSql.Append(" VALUES (");
            strSql.Append("@in_LON,@in_LAT,@in_PID,@in_BarriesName,@in_UID)");
			SqlParameter[] cmdParms = new SqlParameter[]{
                new SqlParameter("@in_LON", SqlDbType.Decimal),
				new SqlParameter("@in_LAT", SqlDbType.Decimal),
				new SqlParameter("@in_PID", SqlDbType.Int),
				new SqlParameter("@in_BarriesName", SqlDbType.NVarChar),
                new SqlParameter("@in_UID", SqlDbType.Int)};

            cmdParms[0].Value = model.LON;
            cmdParms[1].Value = model.LAT;
            cmdParms[2].Value = model.PID;
            cmdParms[3].Value = model.Name;
            cmdParms[4].Value = -1;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public int Update(Model.Barries model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("UPDATE Barries SET ");
			strSql.Append("LON=@in_LON,");
			strSql.Append("LAT=@in_LAT,");
			strSql.Append("PID=@in_PID,");
            strSql.Append("BarriesName=@in_BarriesName");
			strSql.Append(" WHERE ID=@in_ID");
            SqlParameter[] cmdParms = new SqlParameter[]{
                new SqlParameter("@in_LON", SqlDbType.Decimal),
				new SqlParameter("@in_LAT", SqlDbType.Decimal),
				new SqlParameter("@in_PID", SqlDbType.Int),
				new SqlParameter("@in_BarriesName", SqlDbType.NVarChar),
				new SqlParameter("@in_ID", SqlDbType.Int)};
            cmdParms[0].Value = model.LON;
            cmdParms[1].Value = model.LAT;
            cmdParms[2].Value = model.PID;
            cmdParms[3].Value = model.Name;
            cmdParms[4].Value = model.ID;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public int Delete(int ID)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("DELETE FROM Barries ");
			strSql.Append(" WHERE ID="+ID);

			return DbHelperSQL.ExecuteSql(strSql.ToString());
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.Barries GetModel(int ID)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("SELECT * FROM Barries ");
			strSql.Append(" WHERE ID="+ID);
			Model.Barries model = null;
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
        public List<Model.Barries> GetList()
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM Barries ");
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.Barries> lst = GetList(dr);
                return lst;
            }
        }

		/// <summary>
		/// 获取泛型数据列表
		/// </summary>
		public List<Model.Barries> GetList(int PID)
		{
			StringBuilder strSql = new StringBuilder("SELECT * FROM Barries WHERE PID="+PID);
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
				List<Model.Barries> lst = GetList(dr);
				return lst;
			}
		}


		#region -------- 私有方法，通常情况下无需修改 --------

		/// <summary>
		/// 由一行数据得到一个实体
		/// </summary>
		private Model.Barries GetModel(DbDataReader dr)
		{
			Model.Barries model = new Model.Barries();
            model.ID = DbHelperSQL.GetInt(dr["ID"]);
            model.LON = DbHelperSQL.GetDouble(dr["LON"]);
            model.LAT = DbHelperSQL.GetDouble(dr["LAT"]);
            model.PID = DbHelperSQL.GetInt(dr["PID"]);
            model.Name = DbHelperSQL.GetString(dr["BarriesName"]);
            model.UID = DbHelperSQL.GetInt(dr["UID"]);
			return model;
		}

		/// <summary>
		/// 由DbDataReader得到泛型数据列表
		/// </summary>
		private List<Model.Barries> GetList(DbDataReader dr)
		{
			List<Model.Barries> lst = new List<Model.Barries>();
			while (dr.Read())
			{
				lst.Add(GetModel(dr));
			}
			return lst;
		}

		#endregion
	}
}
