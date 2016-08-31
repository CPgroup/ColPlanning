//------------------------------------------------------------------------------
// 创建标识: 尹健
// 创建描述: 无人机监测——无人机任务申请
// 创建时间:2014.6.29
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
	/// 数据访问类 UAVTaskApply
	/// </summary>
	public class UAVTaskApply 
	{
		/// <summary>
		/// 增加一条数据
		/// </summary>
        //public int Add(Model.UAVTaskApply model)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("INSERT INTO UAVTaskApply(");
        //    strSql.Append("UID,TID,PID,Describe,TypeID)");
        //    strSql.Append(" VALUES (");
        //    strSql.Append("@in_UID,@in_TID,@in_PID,@in_Describe,@in_TypeID)");
        //    DbParameter[] cmdParms = {
        //        CoSchedulingHelper.CreateInDbParameter("@in_UID", DbType.Int32, model.UID),
        //        CoSchedulingHelper.CreateInDbParameter("@in_TID", DbType.Int32, model.TID),
        //        CoSchedulingHelper.CreateInDbParameter("@in_PID", DbType.Int32, model.PID),
        //        CoSchedulingHelper.CreateInDbParameter("@in_Describe", DbType.String, model.Describe),
        //        CoSchedulingHelper.CreateInDbParameter("@in_TypeID", DbType.StringFixedLength, model.TypeID)};

        //    return CoSchedulingHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), cmdParms);
        //}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        //public int Update(Model.UAVTaskApply model)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("UPDATE UAVTaskApply SET ");
        //    strSql.Append("UID=@in_UID,");
        //    strSql.Append("TID=@in_TID,");
        //    strSql.Append("PID=@in_PID,");
        //    strSql.Append("Describe=@in_Describe,");
        //    strSql.Append("TypeID=@in_TypeID");
        //    strSql.Append(" WHERE ID=@in_ID");
        //    DbParameter[] cmdParms = {
        //        CoSchedulingHelper.CreateInDbParameter("@in_UID", DbType.Int32, model.UID),
        //        CoSchedulingHelper.CreateInDbParameter("@in_TID", DbType.Int32, model.TID),
        //        CoSchedulingHelper.CreateInDbParameter("@in_PID", DbType.Int32, model.PID),
        //        CoSchedulingHelper.CreateInDbParameter("@in_Describe", DbType.String, model.Describe),
        //        CoSchedulingHelper.CreateInDbParameter("@in_TypeID", DbType.StringFixedLength, model.TypeID),
        //        CoSchedulingHelper.CreateInDbParameter("@in_ID", DbType.Int32, model.ID)};
        //    return CoSchedulingHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), cmdParms);
        //}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public int Delete(int ID)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("DELETE FROM UAVTaskApply ");
			strSql.Append(" WHERE ID="+ID);
            return DbHelperSQL.ExecuteSql(strSql.ToString());
		}


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE UAVTaskApply SET isChecked=1 ");
            strSql.Append(" WHERE ID=" + ID);
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.UAVTaskApply GetModel(int ID)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("SELECT * FROM UAVTaskApply ");
			strSql.Append(" WHERE ID="+ID);
			Model.UAVTaskApply model = null;
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
        public List<Model.UAVTaskApply> GetList(int pid)
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM UAVTaskApply  Where PID="+pid);
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.UAVTaskApply> lst = GetList(dr);
                return lst;
            }
        }


		/// <summary>
		/// 获取泛型数据列表
		/// </summary>
		public List<Model.UAVTaskApply> GetList()
		{
			StringBuilder strSql = new StringBuilder("SELECT * FROM UAVTaskApply");
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
				List<Model.UAVTaskApply> lst = GetList(dr);
				return lst;
			}
		}

        /// <summary>
        /// 更新isHandled，0--事件未处理；1--事件已处理
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int UpdateisHandled(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE UAVTaskApply SET isHandled=1 ");
            strSql.Append(" WHERE ID=" + ID);
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 根据UID获取编队名称
        /// </summary>
        public string GetUAVName(int UID)
        {
            string uavName = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Name from [dbo].[UAVBD] ");
            strSql.Append(" where id=" + UID);
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (dr.Read())
                {
                    uavName = Convert.ToString(dr["Name"]);
                }
                return uavName;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.UAVTaskApply GetModelByCond(string whereClause)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM UAVTaskApply ");
            strSql.Append(" WHERE " + whereClause + "");
            Model.UAVTaskApply model = null;
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
        /// 获取未查看的无人机签到信息
        /// </summary>
        public List<Model.UAVTaskApply> NotCheckedApply(int DID)
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM  UAVTaskApply WHERE isChecked=0 AND PID=" + DID);
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.UAVTaskApply> lst = GetList(dr);
                return lst;
            }
        }
        

		#region -------- 私有方法，通常情况下无需修改 --------

		/// <summary>
		/// 由一行数据得到一个实体
		/// </summary>
		private Model.UAVTaskApply GetModel(DbDataReader dr)
		{
			Model.UAVTaskApply model = new Model.UAVTaskApply();
            model.ID = DbHelperSQL.GetInt(dr["ID"]);
            model.UID = DbHelperSQL.GetInt(dr["UID"]);
            model.TID = DbHelperSQL.GetInt(dr["TID"]);
            model.PID = DbHelperSQL.GetInt(dr["PID"]);
            model.Describe = DbHelperSQL.GetString(dr["Describe"]);
            model.TypeID = DbHelperSQL.GetString(dr["TypeID"]);
            model.isHandled = DbHelperSQL.GetBool(dr["isHandled"]);
            model.UAVTime = DbHelperSQL.GetString(dr["UAVTime"]);
			return model;
		}

		/// <summary>
		/// 由DbDataReader得到泛型数据列表
		/// </summary>
		private List<Model.UAVTaskApply> GetList(DbDataReader dr)
		{
			List<Model.UAVTaskApply> lst = new List<Model.UAVTaskApply>();
			while (dr.Read())
			{
				lst.Add(GetModel(dr));
			}
			return lst;
		}

		#endregion
	}
}
