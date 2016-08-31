//------------------------------------------------------------------------------
// 创建标识: 尹健
// 创建描述: 志愿者上报的灾情信息 数据访问类
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
	/// 数据访问类 VolDisaInfo
	/// </summary>
	public class VolDisaInfo 
	{
        ///// <summary>
        ///// 增加一条数据
        ///// </summary>
        //public int Add(Model.VolDisaInfo model)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("INSERT INTO VolDisaInfo(");
        //    strSql.Append("TelNum,Name,DisaType,Describe,Photo,LAT,LON,Location)");
        //    strSql.Append(" VALUES (");
        //    strSql.Append("@in_TelNum,@in_Name,@in_DisaType,@in_Describe,@in_Photo,@in_LAT,@in_LON,@in_Location)");
        //    DbParameter[] cmdParms = {
        //        CoSchedulingHelper.CreateInDbParameter("@in_TelNum", DbType.Int32, model.TelNum),
        //        CoSchedulingHelper.CreateInDbParameter("@in_Name", DbType.String, model.Name),
        //        CoSchedulingHelper.CreateInDbParameter("@in_DisaType", DbType.String, model.DisaType),
        //        CoSchedulingHelper.CreateInDbParameter("@in_Describe", DbType.String, model.Describe),
        //        CoSchedulingHelper.CreateInDbParameter("@in_Photo", DbType.String, model.Photo),
        //        CoSchedulingHelper.CreateInDbParameter("@in_LAT", DbType.Double, model.LAT),
        //        CoSchedulingHelper.CreateInDbParameter("@in_LON", DbType.Double, model.LON),
        //        CoSchedulingHelper.CreateInDbParameter("@in_Location", DbType.String, model.Location)};

        //    return CoSchedulingHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), cmdParms);
        //}

        ///// <summary>
        ///// 更新一条数据
        ///// </summary>
        //public int Update(Model.VolDisaInfo model)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("UPDATE VolDisaInfo SET ");
        //    strSql.Append("TelNum=@in_TelNum,");
        //    strSql.Append("Name=@in_Name,");
        //    strSql.Append("DisaType=@in_DisaType,");
        //    strSql.Append("Describe=@in_Describe,");
        //    strSql.Append("Photo=@in_Photo,");
        //    strSql.Append("LAT=@in_LAT,");
        //    strSql.Append("LON=@in_LON,");
        //    strSql.Append("Location=@in_Location");
        //    strSql.Append(" WHERE ID=@in_ID");
        //    DbParameter[] cmdParms = {
        //        CoSchedulingHelper.CreateInDbParameter("@in_TelNum", DbType.Int32, model.TelNum),
        //        CoSchedulingHelper.CreateInDbParameter("@in_Name", DbType.String, model.Name),
        //        CoSchedulingHelper.CreateInDbParameter("@in_DisaType", DbType.String, model.DisaType),
        //        CoSchedulingHelper.CreateInDbParameter("@in_Describe", DbType.String, model.Describe),
        //        CoSchedulingHelper.CreateInDbParameter("@in_Photo", DbType.String, model.Photo),
        //        CoSchedulingHelper.CreateInDbParameter("@in_LAT", DbType.Double, model.LAT),
        //        CoSchedulingHelper.CreateInDbParameter("@in_LON", DbType.Double, model.LON),
        //        CoSchedulingHelper.CreateInDbParameter("@in_Location", DbType.String, model.Location),
        //        CoSchedulingHelper.CreateInDbParameter("@in_ID", DbType.Int32, model.ID)};
        //    return CoSchedulingHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), cmdParms);
        //}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public int Delete(int ID)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("DELETE FROM VolDisaInfo ");
			strSql.Append(" WHERE ID="+ID);
            return DbHelperSQL.ExecuteSql(strSql.ToString());
		}

		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.VolDisaInfo GetModel(int ID)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("SELECT * FROM VolDisaInfo ");
			strSql.Append(" WHERE ID="+ID);
			Model.VolDisaInfo model = null;
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
		public List<Model.VolDisaInfo> GetList()
		{
			StringBuilder strSql = new StringBuilder("SELECT * FROM VolDisaInfo");
            using (DbDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
			{
				List<Model.VolDisaInfo> lst = GetList(dr);
				return lst;
			}
		}


		#region -------- 私有方法，通常情况下无需修改 --------

		/// <summary>
		/// 由一行数据得到一个实体
		/// </summary>
		private Model.VolDisaInfo GetModel(DbDataReader dr)
		{
			Model.VolDisaInfo model = new Model.VolDisaInfo();
            model.ID = DbHelperSQL.GetInt(dr["ID"]);
            model.TelNum = DbHelperSQL.GetString(dr["TelNum"]);
            model.VolName = DbHelperSQL.GetString(dr["VolName"]);
            model.Time = DbHelperSQL.GetDateTime(dr["Time"]);
            model.DisaType = DbHelperSQL.GetString(dr["DisaType"]);
            model.Describe = DbHelperSQL.GetString(dr["Describe"]);
            model.Photo = DbHelperSQL.GetString(dr["Photo"]);
            model.LAT = DbHelperSQL.GetDouble(dr["LAT"]);
            model.LON = DbHelperSQL.GetDouble(dr["LON"]);
            model.Location = DbHelperSQL.GetString(dr["Location"]);
			return model;
		}

		/// <summary>
		/// 由DbDataReader得到泛型数据列表
		/// </summary>
		private List<Model.VolDisaInfo> GetList(DbDataReader dr)
		{
			List<Model.VolDisaInfo> lst = new List<Model.VolDisaInfo>();
			while (dr.Read())
			{
				lst.Add(GetModel(dr));
			}
			return lst;
		}

		#endregion
	}
}
