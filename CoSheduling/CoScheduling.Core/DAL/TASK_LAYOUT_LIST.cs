//------------------------------------------------------------------------------
// 创建标识: 董毅博
// 创建描述: 观测任务设置访问类
// 创建时间:2014.6.10
// 文件版本:2.0
// 功能描述: 
// 修改标识: 
// 修改描述: 
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using CoScheduling.Core.DBUtility;
using System.Data;
using System.Data.Common;

namespace CoScheduling.Core.DAL
{
	/// <summary>
	/// 数据访问类 TASK_LAYOUT_LIST
	/// </summary>
	public class TASK_LAYOUT_LIST
	{
        //数据库连接字符串(web.config来配置)，可以动态更改connectionString支持多数据库.		
        public static string connectionString;
        public TASK_LAYOUT_LIST()
        {
            connectionString = PubConstant.GetConnectionString("");
        }
        /// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Model.TASK_LAYOUT_LIST model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("INSERT INTO LHF.TASK_LAYOUT_LIST(");
            strSql.Append("TASKNAME,TASKTYPE,PRIORITY,IMAGETYPE,MAXGSD,STARTTIME,ENDTIME,SCHEMEID,TARGET_ID,ISCONTINUEDSPY,LON,LAT,AREASTRING)");
			strSql.Append(" VALUES (");
            strSql.Append("@in_TASKNAME,@in_TASKTYPE,@in_PRIORITY,@in_IMAGETYPE,@in_MAXGSD,@in_STARTTIME,@in_ENDTIME,@in_SCHEMEID,@in_TARGET_ID,@in_ISCONTINUEDSPY,@in_LON,@in_LAT,@in_AREASTRING)");
            SqlParameter[] cmdParms = new SqlParameter[]{
				new SqlParameter("@in_TASKNAME", SqlDbType.NVarChar),
				new SqlParameter("@in_TASKTYPE", SqlDbType.Decimal),
				new SqlParameter("@in_PRIORITY", SqlDbType.Decimal),
				new SqlParameter("@in_IMAGETYPE", SqlDbType.NVarChar),
				new SqlParameter("@in_MAXGSD", SqlDbType.Decimal),
				new SqlParameter("@in_STARTTIME", SqlDbType.DateTime),
				new SqlParameter("@in_ENDTIME", SqlDbType.DateTime),
				new SqlParameter("@in_SCHEMEID", SqlDbType.Decimal),
				new SqlParameter("@in_TARGET_ID", SqlDbType.Decimal),
				new SqlParameter("@in_ISCONTINUEDSPY", SqlDbType.Decimal),
				new SqlParameter("@in_LON", SqlDbType.Decimal),
				new SqlParameter("@in_LAT", SqlDbType.Decimal),
				new SqlParameter("@in_AREASTRING", SqlDbType.NVarChar)};
            cmdParms[0].Value = model.TASKNAME;
            cmdParms[1].Value = model.TASKTYPE;
            cmdParms[2].Value = model.PRIORITY;
            cmdParms[3].Value = model.IMAGETYPE;
            cmdParms[4].Value = model.MAXGSD;
            cmdParms[5].Value = model.STARTTIME;
            cmdParms[6].Value = model.ENDTIME;
            cmdParms[7].Value = model.SCHEMEID;
            cmdParms[8].Value = model.TARGET_ID;
            cmdParms[9].Value = model.ISCONTINUEDSPY;
            cmdParms[10].Value = model.LON;
            cmdParms[11].Value = model.LAT;
            cmdParms[12].Value = model.AREASTRING;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public int Update(Model.TASK_LAYOUT_LIST model)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE LHF.TASK_LAYOUT_LIST SET ");
            strSql.Append("TASKNAME=@in_TASKNAME,");
            strSql.Append("TASKTYPE=@in_TASKTYPE,");
            strSql.Append("PRIORITY=@in_PRIORITY,");
            strSql.Append("IMAGETYPE=@in_IMAGETYPE,");
            strSql.Append("MAXGSD=@in_MAXGSD,");
            strSql.Append("STARTTIME=@in_STARTTIME,");
            strSql.Append("ENDTIME=@in_ENDTIME,");
            strSql.Append("SCHEMEID=@in_SCHEMEID,");
            strSql.Append("TARGET_ID=@in_TARGET_ID,");
            strSql.Append("ISCONTINUEDSPY=@in_ISCONTINUEDSPY,");
            strSql.Append("LON=@in_LON,");
            strSql.Append("LAT=@in_LAT,");
            strSql.Append("AREASTRING=@in_AREASTRING");
            strSql.Append(" WHERE TASKID=@in_TASKID");
            SqlParameter[] cmdParms = new SqlParameter[]{
				new SqlParameter("@in_TASKID", SqlDbType.Decimal),
				new SqlParameter("@in_TASKNAME", SqlDbType.NVarChar),
				new SqlParameter("@in_TASKTYPE", SqlDbType.Decimal),
				new SqlParameter("@in_PRIORITY", SqlDbType.Decimal),
				new SqlParameter("@in_IMAGETYPE", SqlDbType.NVarChar),
				new SqlParameter("@in_MAXGSD", SqlDbType.Decimal),
				new SqlParameter("@in_STARTTIME", SqlDbType.DateTime),
				new SqlParameter("@in_ENDTIME", SqlDbType.DateTime),
				new SqlParameter("@in_SCHEMEID", SqlDbType.Decimal),
				new SqlParameter("@in_TARGET_ID", SqlDbType.Decimal),
				new SqlParameter("@in_ISCONTINUEDSPY", SqlDbType.Decimal),
				new SqlParameter("@in_LON", SqlDbType.Decimal),
				new SqlParameter("@in_LAT", SqlDbType.Decimal),
				new SqlParameter("@in_AREASTRING", SqlDbType.NVarChar)};
            cmdParms[0].Value = model.TASKID;
            cmdParms[1].Value = model.TASKNAME;
            cmdParms[2].Value = model.TASKTYPE;
            cmdParms[3].Value = model.PRIORITY;
            cmdParms[4].Value = model.IMAGETYPE;
            cmdParms[5].Value = model.MAXGSD;
            cmdParms[6].Value = model.STARTTIME;
            cmdParms[7].Value = model.ENDTIME;
            cmdParms[8].Value = model.SCHEMEID;
            cmdParms[9].Value = model.TARGET_ID;
            cmdParms[10].Value = model.ISCONTINUEDSPY;
            cmdParms[11].Value = model.LON;
            cmdParms[12].Value = model.LAT;
            cmdParms[13].Value = model.AREASTRING;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public int Delete(decimal TASKID)
		{
			StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM LHF.TASK_LAYOUT_LIST ");
            strSql.Append(" WHERE TASKID=" + TASKID);

            return DbHelperSQL.ExecuteSql(strSql.ToString());
		}

        /// <summary>
        /// 根据SCHEMEID删除数据
        /// </summary>
        public int DeleteBySchemeID(decimal SCHEMEID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM LHF.TASK_LAYOUT_LIST ");
            strSql.Append(" WHERE SCHEMEID=" + SCHEMEID);

            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal TASKID)
		{
			StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM LHF.TASK_LAYOUT_LIST");
			strSql.Append(" WHERE TASKID="+TASKID);
            return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.TASK_LAYOUT_LIST GetModel(int TASKID)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM LHF.TASK_LAYOUT_LIST ");
			strSql.Append(" WHERE TASKID="+TASKID);

            using (DbDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                CoScheduling.Core.Model.TASK_LAYOUT_LIST model = new CoScheduling.Core.Model.TASK_LAYOUT_LIST();
                if (dr.Read())
                {
                    model = GetModel(dr);
                }
                dr.Close();
                return model;
            }
		}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * ");
            strSql.Append(" FROM LHF.TASK_LAYOUT_LIST ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ORDER BY TASKID");
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }

		/// <summary>
		/// 获取泛型数据列表
		/// </summary>
		public List<Model.TASK_LAYOUT_LIST> GetList()
		{
            StringBuilder strSql = new StringBuilder("SELECT * FROM LHF.TASK_LAYOUT_LIST");
            using (DbDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString(), null))
			{
				List<Model.TASK_LAYOUT_LIST> lst = GetList(dr);
				return lst;
			}
		}

        /// <summary>
        /// 根据观测方案ID——SCHEMEID获取泛型数据列表
        /// </summary>
        public List<Model.TASK_LAYOUT_LIST> GetList(int scheme_id)
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM LHF.TASK_LAYOUT_LIST");
            strSql.Append(" WHERE SCHEMEID=" + scheme_id.ToString());
            strSql.Append(" ORDER BY TASKID");
            using (DbDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.TASK_LAYOUT_LIST> lst = GetList(dr);
                return lst;
            }
        }
        /// <summary>
        /// 根据条件获取DataSet数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetListDataSet(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * ");
            strSql.Append(" FROM LHF.TASK_LAYOUT_LIST ");
            if (strWhere.Trim() != "")
            {
                strSql.Append("WHERE " + strWhere);
            }
            strSql.Append(" ORDER BY TASKID");
            DataSet ds = new DataSet();
            SqlDataAdapter odaSat = new SqlDataAdapter(strSql.ToString(), connectionString);
            if (ds.Tables["TASK_LAYOUT_LIST"] != null)
            {
                ds.Tables["TASK_LAYOUT_LIST"].Clear();
            }
            odaSat.Fill(ds, "TASK_LAYOUT_LIST");
            return ds;
        }

		/// <summary>
		/// 得到数据条数
		/// </summary>
        public int GetCount(string strWhere)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT (*) ");
            strSql.Append(" FROM LHF.TASK_LAYOUT_LIST ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
		}

        


		#region -------- 私有方法，通常情况下无需修改 --------

		/// <summary>
		/// 由一行数据得到一个实体
		/// </summary>
		private Model.TASK_LAYOUT_LIST GetModel(DbDataReader dr)
		{
			Model.TASK_LAYOUT_LIST model = new Model.TASK_LAYOUT_LIST();
            model.TASKID = Convert.ToInt32(dr["TASKID"]);
            model.TASKNAME = Convert.ToString(dr["TASKNAME"]);
            model.TASKTYPE = Convert.ToInt32(dr["TASKTYPE"]);
            model.PRIORITY = Convert.ToInt32(dr["PRIORITY"]);
            model.IMAGETYPE = Convert.ToString(dr["IMAGETYPE"]);
            model.MAXGSD = Convert.ToDecimal(dr["MAXGSD"]);
            model.STARTTIME = Convert.ToDateTime(dr["STARTTIME"]);
            model.ENDTIME = Convert.ToDateTime(dr["ENDTIME"]);
            model.SCHEMEID = Convert.ToInt32(dr["SCHEMEID"]);
            model.TARGET_ID = Convert.ToInt32(dr["TARGET_ID"]);
            model.ISCONTINUEDSPY = Convert.ToInt32(dr["ISCONTINUEDSPY"]);
            model.LON = Convert.ToDecimal(dr["LON"]);
            model.LAT = Convert.ToDecimal(dr["LAT"]);
            model.AREASTRING = Convert.ToString(dr["AREASTRING"]);
			return model;
		}

		/// <summary>
		/// 由DbDataReader得到泛型数据列表
		/// </summary>
		private List<Model.TASK_LAYOUT_LIST> GetList(DbDataReader dr)
		{
			List<Model.TASK_LAYOUT_LIST> lst = new List<Model.TASK_LAYOUT_LIST>();
			while (dr.Read())
			{
				lst.Add(GetModel(dr));
			}
			return lst;
		}

		#endregion
	}
}
