//------------------------------------------------------------------------------
// 创建标识: 尹健
// 创建描述: 单位无人机数据访问类
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
	/// 数据访问类 CompanyUAV
	/// </summary>
	public class CompanyUAV 
	{
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Model.CompanyUAV model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("INSERT INTO CompanyUAV(");
            strSql.Append("Length,Wingspan,Weight,DriveMode,TakeoffMode,LandingMode,FlightAltitude,Radius,AverageSpeed,Endurance,WindResistance,StallSpeed,ControlDistance,Camera,CID)");
			strSql.Append(" VALUES (");
            strSql.Append("@in_Length,@in_Wingspan,@in_Weight,@in_DriveMode,@in_TakeoffMode,@in_LandingMode,@in_FlightAltitude,@in_Radius,@in_AverageSpeed,@in_Endurance,@in_WindResistance,@in_StallSpeed,@in_ControlDistance,@in_Camera,@in_CID)");
            SqlParameter[] cmdParms = new SqlParameter[]{
                new SqlParameter("@in_Length", SqlDbType.Decimal),
				new SqlParameter("@in_Wingspan", SqlDbType.Decimal),
				new SqlParameter("@in_Weight", SqlDbType.Decimal),
				new SqlParameter("@in_DriveMode", SqlDbType.NVarChar),
				new SqlParameter("@in_TakeoffMode", SqlDbType.NVarChar),
				new SqlParameter("@in_LandingMode", SqlDbType.NVarChar),
				new SqlParameter("@in_FlightAltitude", SqlDbType.Decimal),
				new SqlParameter("@in_Radius", SqlDbType.Decimal),
				new SqlParameter("@in_AverageSpeed", SqlDbType.Decimal),
				new SqlParameter("@in_Endurance", SqlDbType.Decimal),
				new SqlParameter("@in_WindResistance", SqlDbType.Decimal),
				new SqlParameter("@in_StallSpeed", SqlDbType.Decimal),
				new SqlParameter("@in_ControlDistance", SqlDbType.Decimal),
				new SqlParameter("@in_Camera", SqlDbType.NVarChar),
				new SqlParameter("@in_CID", SqlDbType.Int)};

            cmdParms[0].Value = model.Length;
            cmdParms[1].Value = model.Wingspan;
            cmdParms[2].Value = model.Weight;
            cmdParms[3].Value = model.DriveMode;
            cmdParms[4].Value = model.TakeoffMode;
            cmdParms[5].Value = model.LandingMode;
            cmdParms[6].Value = model.FlightAltitude;
            cmdParms[7].Value = model.Radius;
            cmdParms[8].Value = model.AverageSpeed;
            cmdParms[9].Value = model.Endurance;
            cmdParms[10].Value = model.WindResistance;
            cmdParms[11].Value = model.StallSpeed;
            cmdParms[12].Value = model.ControlDistance;
            cmdParms[13].Value = model.Camera;
            cmdParms[14].Value = model.CID;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public int Update(Model.CompanyUAV model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("UPDATE CompanyUAV SET ");
			strSql.Append("Length=@in_Length,");
			strSql.Append("Wingspan=@in_Wingspan,");
			strSql.Append("Weight=@in_Weight,");
			strSql.Append("DriveMode=@in_DriveMode,");
			strSql.Append("TakeoffMode=@in_TakeoffMode,");
			strSql.Append("LandingMode=@in_LandingMode,");
			strSql.Append("FlightAltitude=@in_FlightAltitude,");
			strSql.Append("Radius=@in_Radius,");
			strSql.Append("AverageSpeed=@in_AverageSpeed,");
			strSql.Append("Endurance=@in_Endurance,");
			strSql.Append("WindResistance=@in_WindResistance,");
			strSql.Append("StallSpeed=@in_StallSpeed,");
			strSql.Append("ControlDistance=@in_ControlDistance,");
			strSql.Append("Camera=@in_Camera,");
			strSql.Append("CID=@in_CID");
			strSql.Append(" WHERE ID=@in_ID");
            SqlParameter[] cmdParms = new SqlParameter[]{
                new SqlParameter("@in_Length", SqlDbType.Decimal),
				new SqlParameter("@in_Wingspan", SqlDbType.Decimal),
				new SqlParameter("@in_Weight", SqlDbType.Decimal),
				new SqlParameter("@in_DriveMode", SqlDbType.NVarChar),
				new SqlParameter("@in_TakeoffMode", SqlDbType.NVarChar),
				new SqlParameter("@in_LandingMode", SqlDbType.NVarChar),
				new SqlParameter("@in_FlightAltitude", SqlDbType.Decimal),
				new SqlParameter("@in_Radius", SqlDbType.Decimal),
				new SqlParameter("@in_AverageSpeed", SqlDbType.Decimal),
				new SqlParameter("@in_Endurance", SqlDbType.Decimal),
				new SqlParameter("@in_WindResistance", SqlDbType.Decimal),
				new SqlParameter("@in_StallSpeed", SqlDbType.Decimal),
				new SqlParameter("@in_ControlDistance", SqlDbType.Decimal),
				new SqlParameter("@in_Camera", SqlDbType.NVarChar),
				new SqlParameter("@in_CID", SqlDbType.Int),
				new SqlParameter("@in_ID", SqlDbType.Int)};
            cmdParms[0].Value = model.Length;
            cmdParms[1].Value = model.Wingspan;
            cmdParms[2].Value = model.Weight;
            cmdParms[3].Value = model.DriveMode;
            cmdParms[4].Value = model.TakeoffMode;
            cmdParms[5].Value = model.LandingMode;
            cmdParms[6].Value = model.FlightAltitude;
            cmdParms[7].Value = model.Radius;
            cmdParms[8].Value = model.AverageSpeed;
            cmdParms[9].Value = model.Endurance;
            cmdParms[10].Value = model.WindResistance;
            cmdParms[11].Value = model.StallSpeed;
            cmdParms[12].Value = model.ControlDistance;
            cmdParms[13].Value = model.Camera;
            cmdParms[14].Value = model.CID;
            cmdParms[15].Value = model.ID;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public int Delete(int ID)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("DELETE FROM CompanyUAV ");
			strSql.Append(" WHERE ID=" + ID.ToString());
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
            return DbHelperSQL.GetMaxID("CompanyUAV");
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("SELECT COUNT(1) FROM CompanyUAV");
			strSql.Append(" WHERE ID="+ID.ToString());
            return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.CompanyUAV GetModel(int ID)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("SELECT * FROM CompanyUAV ");
			strSql.Append(" WHERE ID=@in_ID");
			Model.CompanyUAV model = null;
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
		public List<Model.CompanyUAV> GetList()
		{
			StringBuilder strSql = new StringBuilder("SELECT * FROM CompanyUAV");
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
				List<Model.CompanyUAV> lst = GetList(dr);
				return lst;
			}
		}

		/// <summary>
		/// 得到数据条数
		/// </summary>
		public int GetCount(string condition)
		{
            return DbHelperSQL.GetCount("CompanyUAV", condition);
		}

        /// <summary>
        /// 获取页数
        /// </summary>
        public int GetPageNum(int PageSize, string WhereClause)
        {
            StringBuilder strSql = new StringBuilder("SELECT count(*) FROM CompanyUAV");
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
        public List<Model.CompanyUAV> GetPageList(int pageSize, int pageIndex, string WhereClause)
        {
            string strSql = "SELECT TOP " + pageSize.ToString() + " * " +
                             "    FROM " +
                                        " ( " +
                                        " SELECT ROW_NUMBER() OVER (ORDER BY BH) AS RowNumber,* FROM CompanyUAV "
                                             + (!string.IsNullOrEmpty(WhereClause) ? " where " + WhereClause : "") +
                                         ") A " +
                                 "WHERE RowNumber > " + pageSize.ToString() + "*(" + pageIndex.ToString() + "-1)  ";
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString(), null))
            {
                List<Model.CompanyUAV> lst = GetList(dr);
                return lst;
            }
        }

		#region -------- 私有方法，通常情况下无需修改 --------

		/// <summary>
		/// 由一行数据得到一个实体
		/// </summary>
		private Model.CompanyUAV GetModel(DbDataReader dr)
		{
			Model.CompanyUAV model = new Model.CompanyUAV();
            model.ID = DbHelperSQL.GetInt(dr["ID"]);
            model.Length = DbHelperSQL.GetDouble(dr["Length"]);
            model.Wingspan = DbHelperSQL.GetDouble(dr["Wingspan"]);
            model.Weight = DbHelperSQL.GetDouble(dr["Weight"]);
            model.DriveMode = DbHelperSQL.GetString(dr["DriveMode"]);
            model.TakeoffMode = DbHelperSQL.GetString(dr["TakeoffMode"]);
            model.LandingMode = DbHelperSQL.GetString(dr["LandingMode"]);
            model.FlightAltitude = DbHelperSQL.GetDouble(dr["FlightAltitude"]);
            model.Radius = DbHelperSQL.GetDouble(dr["Radius"]);
            model.AverageSpeed = DbHelperSQL.GetDouble(dr["AverageSpeed"]);
            model.Endurance = DbHelperSQL.GetDouble(dr["Endurance"]);
            model.WindResistance = DbHelperSQL.GetDouble(dr["WindResistance"]);
            model.StallSpeed = DbHelperSQL.GetDouble(dr["StallSpeed"]);
            model.ControlDistance = DbHelperSQL.GetDouble(dr["ControlDistance"]);
            model.Camera = DbHelperSQL.GetString(dr["Camera"]);
            model.CID = DbHelperSQL.GetInt(dr["CID"]);
			return model;
		}

		/// <summary>
		/// 由DbDataReader得到泛型数据列表
		/// </summary>
		private List<Model.CompanyUAV> GetList(DbDataReader dr)
		{
			List<Model.CompanyUAV> lst = new List<Model.CompanyUAV>();
			while (dr.Read())
			{
				lst.Add(GetModel(dr));
			}
			return lst;
		}

		#endregion
	}
}
