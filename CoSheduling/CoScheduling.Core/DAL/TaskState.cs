//------------------------------------------------------------------------------
// 创建标识: 尹健
// 创建描述: 无人机访问类
// 创建时间:2013.11.15
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
	/// 数据访问类 V_TaskState
	/// </summary>
	public class V_TaskState
	{
        ///// <summary>
        ///// 增加一条数据
        ///// </summary>
        //public int Add(Model.V_TaskState model)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("INSERT INTO V_TaskState(");
        //    strSql.Append("TName,UAVName,TID,UAVID,UAVTime)");
        //    strSql.Append(" VALUES (");
        //    strSql.Append("@in_TName,@in_UAVName,@in_TID,@in_UAVID,@in_UAVTime)");
        //    DbParameter[] cmdParms = {
        //        CoSchedulingHelper.CreateInDbParameter("@in_TName", DbType.String, model.TName),
        //        CoSchedulingHelper.CreateInDbParameter("@in_UAVName", DbType.String, model.UAVName),
        //        CoSchedulingHelper.CreateInDbParameter("@in_TID", DbType.Int32, model.TID),
        //        CoSchedulingHelper.CreateInDbParameter("@in_UAVID", DbType.Int32, model.UAVID),
        //        CoSchedulingHelper.CreateInDbParameter("@in_UAVTime", DbType.String, model.UAVTime)};

        //    return CoSchedulingHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), cmdParms);
        //}

        ///// <summary>
        ///// 更新一条数据
        ///// </summary>
        //public int Update(Model.V_TaskState model)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("UPDATE V_TaskState SET ");
        //    strSql.Append("UAVName=@in_UAVName,");
        //    strSql.Append("TID=@in_TID,");
        //    strSql.Append("UAVID=@in_UAVID,");
        //    strSql.Append("UAVTime=@in_UAVTime");
        //    strSql.Append(" WHERE TName=@in_TName");
        //    DbParameter[] cmdParms = {
        //        CoSchedulingHelper.CreateInDbParameter("@in_UAVName", DbType.String, model.UAVName),
        //        CoSchedulingHelper.CreateInDbParameter("@in_TID", DbType.Int32, model.TID),
        //        CoSchedulingHelper.CreateInDbParameter("@in_UAVID", DbType.Int32, model.UAVID),
        //        CoSchedulingHelper.CreateInDbParameter("@in_UAVTime", DbType.String, model.UAVTime),
        //        CoSchedulingHelper.CreateInDbParameter("@in_TName", DbType.String, model.TName)};
        //    return CoSchedulingHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), cmdParms);
        //}

        ///// <summary>
        ///// 删除一条数据
        ///// </summary>
        //public int Delete(string TName)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("DELETE FROM V_TaskState ");
        //    strSql.Append(" WHERE TName=@in_TName");
        //    DbParameter[] cmdParms = {
        //        CoSchedulingHelper.CreateInDbParameter("@in_TName", DbType.String, TName)};

        //    return CoSchedulingHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), cmdParms);
        //}

        ///// <summary>
        ///// 是否存在该记录
        ///// </summary>
        //public bool Exists(string TName)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("SELECT COUNT(1) FROM V_TaskState");
        //    strSql.Append(" WHERE TName=@in_TName");
        //    DbParameter[] cmdParms = {
        //        CoSchedulingHelper.CreateInDbParameter("@in_TName", DbType.String, TName)};

        //    object obj = CoSchedulingHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), cmdParms);
        //    return CoSchedulingHelper.GetInt(obj) > 0;
        //}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.V_TaskState GetModel(string TName)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("SELECT * FROM V_TaskState ");
			strSql.Append(" WHERE TName='"+TName+"'");
			Model.V_TaskState model = null;
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
        /// 根据PID获取泛型数据列表
        /// </summary>
        public List<Model.V_TaskState> GetListByPID(int PID)
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM V_TaskState WHERE PID="+PID);
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.V_TaskState> lst = GetList(dr);
                return lst;
            }
        }

		/// <summary>
		/// 获取泛型数据列表
		/// </summary>
		public List<Model.V_TaskState> GetList()
		{
			StringBuilder strSql = new StringBuilder("SELECT * FROM V_TaskState");
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
				List<Model.V_TaskState> lst = GetList(dr);
				return lst;
			}
		}

		

		#region -------- 私有方法，通常情况下无需修改 --------

		/// <summary>
		/// 由一行数据得到一个实体
		/// </summary>
		private Model.V_TaskState GetModel(DbDataReader dr)
		{
			Model.V_TaskState model = new Model.V_TaskState();
            model.TName = DbHelperSQL.GetString(dr["TName"]);
            model.UAVName = DbHelperSQL.GetString(dr["UAVName"]);
            model.TID = DbHelperSQL.GetInt(dr["TID"]);
            model.UAVID = DbHelperSQL.GetInt(dr["UAVID"]);
            model.UAVTime = DbHelperSQL.GetString(dr["UAVTime"]);
			return model;
		}

		/// <summary>
		/// 由DbDataReader得到泛型数据列表
		/// </summary>
		private List<Model.V_TaskState> GetList(DbDataReader dr)
		{
			List<Model.V_TaskState> lst = new List<Model.V_TaskState>();
			while (dr.Read())
			{
				lst.Add(GetModel(dr));
			}
			return lst;
		}

		#endregion
	}
}
