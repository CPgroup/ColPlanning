//------------------------------------------------------------------------------
// 创建标识: 董毅博
// 创建描述: 卫星任务方案设置访问类
// 创建时间:2013.6.10
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
	/// 数据访问类 TASK_SCHEME_LIST
	/// </summary>
	public class TASK_SCHEME_LIST
	{
		
        //数据库连接字符串(web.config来配置)，可以动态更改connectionString支持多数据库.		
        public static string connectionString;
        public TASK_SCHEME_LIST()
        { connectionString = PubConstant.GetConnectionString(""); }
        
        /// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Model.TASK_SCHEME_LIST model)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO LHF.TASK_SCHEME_LIST(");
            strSql.Append("SCHEMENAME,SCHEMEBTIME,SCHEMEETIME,DISAID)");
            strSql.Append(" VALUES (");
            strSql.Append("@in_SCHEMENAME,@in_SCHEMEBTIME,@in_SCHEMEETIME,@in_DISAID)");
            SqlParameter[] cmdParms = new SqlParameter[]{
				new SqlParameter("@in_SCHEMENAME", SqlDbType.NVarChar),
				new SqlParameter("@in_SCHEMEBTIME", SqlDbType.DateTime),
				new SqlParameter("@in_SCHEMEETIME", SqlDbType.DateTime),
                new SqlParameter("@in_DISAID", SqlDbType.Int)};
            cmdParms[0].Value = model.SCHEMENAME;
            cmdParms[1].Value = model.SCHEMEBTIME;
            cmdParms[2].Value = model.SCHEMEETIME;
            cmdParms[3].Value = model.DISAID;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public int Update(Model.TASK_SCHEME_LIST model)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE LHF.TASK_SCHEME_LIST SET ");
            strSql.Append("SCHEMENAME=@in_SCHEMENAME,");
            strSql.Append("SCHEMEBTIME=@in_SCHEMEBTIME,");
            strSql.Append("SCHEMEETIME=@in_SCHEMEETIME");
            strSql.Append("DISAID=@in_DISAID");
            strSql.Append(" WHERE SCHEMEID=@in_SCHEMEID");
            SqlParameter[] cmdParms = new SqlParameter[]{
                new SqlParameter("@in_SCHEMEID", SqlDbType.Int),
                new SqlParameter("@in_SCHEMENAME", SqlDbType.NVarChar),
				new SqlParameter("@in_SCHEMEBTIME", SqlDbType.DateTime),
				new SqlParameter("@in_SCHEMEETIME", SqlDbType.DateTime),
                new SqlParameter("@in_DISAID", SqlDbType.Int)};
            cmdParms[0].Value = model.SCHEMEID;
            cmdParms[1].Value = model.SCHEMENAME;
            cmdParms[2].Value = model.SCHEMEBTIME;
            cmdParms[3].Value = model.SCHEMEETIME;
            cmdParms[4].Value = model.DISAID;

            return DbHelperSQL.ExecuteSql(strSql.ToString());
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public int Delete(decimal SCHEMEID)
		{
			StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM LHF.TASK_SCHEME_LIST ");
			strSql.Append(" WHERE SCHEMEID="+SCHEMEID);

            return DbHelperSQL.ExecuteSql(strSql.ToString());
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal SCHEMEID)
		{
			StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM LHF.TASK_SCHEME_LIST");
			strSql.Append(" WHERE SCHEMEID="+SCHEMEID);


            return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.TASK_SCHEME_LIST GetModel(int SCHEMEID)
		{
			StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM LHF.TASK_SCHEME_LIST ");
            strSql.Append(" WHERE SCHEMEID=" + SCHEMEID);
            CoScheduling.Core.Model.TASK_SCHEME_LIST model = new CoScheduling.Core.Model.TASK_SCHEME_LIST();
            using (DbDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                
                if (dr.Read())
                {
                    model = GetModel(dr);
                }
                dr.Close();
                return model;
            }
			
		}

        /// <summary>
        /// 根据条件获取DataSet数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetListDataSet()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * ");
            strSql.Append(" FROM LHF.TASK_SCHEME_LIST ");
            strSql.Append(" ORDER BY SCHEMEID");
            DataSet ds = new DataSet();
            SqlDataAdapter odaSat = new SqlDataAdapter(strSql.ToString(), connectionString);
            if (ds.Tables["TASK_SCHEME_LIST"] != null)
            {
                ds.Tables["TASK_SCHEME_LIST"].Clear();
            }
            odaSat.Fill(ds, "TASK_SCHEME_LIST");
            return ds;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetListDataTable()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * ");
            strSql.Append(" FROM LHF.TASK_SCHEME_LIST ");
            strSql.Append(" ORDER BY SCHEMEID");
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }
        /// <summary>
        /// 根据条件获得数据列表
        /// </summary>
        public DataTable GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * ");
            strSql.Append(" FROM LHF.TASK_SCHEME_LIST ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ORDER BY SCHEMEID");
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }

		/// <summary>
		/// 获取泛型数据列表
		/// </summary>
		public List<Model.TASK_SCHEME_LIST> GetList()
		{
            StringBuilder strSql = new StringBuilder("SELECT * FROM LHF.TASK_SCHEME_LIST ORDER BY SCHEMEID");
			using (DbDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
			{
				List<Model.TASK_SCHEME_LIST> lst = GetList(dr);
				return lst;
			}
		}

		/// <summary>
		/// 得到数据条数
		/// </summary>
        public int GetCount(string strWhere)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT (*) ");
            strSql.Append(" FROM LHF.TASK_SCHEME_LIST ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
		}
        /// <summary>
        /// 得到最新schemeid
        /// </summary>
        public int GetLatestSchemeid()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT MAX(SCHEMEID) ");
            strSql.Append(" FROM LHF.TASK_SCHEME_LIST ");
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }

        #region 根据schemeid对其他表的操作
        /// <summary>
        /// 根据schemeid删除方案卫星
        /// </summary>
        /// <param name="schemeid"></param>
        /// <returns></returns>
        public int ClearSatScheme(int schemeid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM LHF.TASKSCHEME_PRIVATE_SATELLITE ");
            strSql.Append(" WHERE SCHEMEID=" + schemeid);
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 根据schemeid删除方案载荷
        /// </summary>
        /// <param name="schemeid"></param>
        /// <returns></returns>
        public int ClearSensorScheme(int schemeid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM LHF.TASKSCHEME_PRIVATE_SENSOR ");
            strSql.Append(" WHERE SCHEMEID=" + schemeid);
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 根据schemeid删除卫星轨道数据
        /// </summary>
        /// <param name="schemeid"></param>
        /// <returns></returns>
        public int ClearOrbitScheme(int schemeid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM LHF.TASKSCHEME_PRIVATE_ORBIT ");
            strSql.Append(" WHERE SCHEMEID=" + schemeid);
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 根据schemeid添加方案卫星
        /// </summary>
        /// <param name="schemeid"></param>
        /// <returns></returns>
        public int AddSatScheme(int schemeid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO LHF.TASKSCHEME_PRIVATE_SATELLITE(");
            strSql.Append("SAT_ID,SAT_NAME,SAT_STKNAME,SAT_TYPE,SAT_ROPAGATOR,SAT_STEP,SAT_COORD,SEMIMAJORAXIS,ECCENTRICITY,INCLINATION,AOP,RAAN,MEANANOMALY,TRUEANOMALY,SCHEMEID)");
            strSql.Append(" SELECT SAT_ID,SAT_NAME,SAT_STKNAME,SAT_TYPE,SAT_ROPAGATOR,SAT_STEP,SAT_COORD,SEMIMAJORAXIS,ECCENTRICITY,INCLINATION,AOP,RAAN,MEANANOMALY,TRUEANOMALY,"+schemeid+" FROM LHF.T_PUB_SATELLITE WHERE SAT_ID IN (");
            strSql.Append(" SELECT DISTINCT SAT_ID FROM LHF.SATELLITE_SENSOR_SELECTED WHERE SELECTED=1)");
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 根据schemeid添加方案载荷
        /// </summary>
        /// <param name="schemeid"></param>
        /// <returns></returns>
        public int AddSensorScheme(int schemeid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO LHF.TASKSCHEME_PRIVATE_SENSOR(");
            strSql.Append("SENSOR_ID,SENSOR_NAME,SENSOR_STKNAME,SAT_ID,SAT_STKNAME,SENSOR_TYPE,SENSOR_PARONE,SENSOR_PARTWO,SENSOR_PARTHREE,SENSOR_PARFOUR,TYPEID,SATTYPE,SCHEMEID,SENSORANGLEH,SENSORANGLE)");
            strSql.Append(" SELECT SENSOR_ID,SENSOR_NAME,SENSOR_STKNAME,SAT_ID,SAT_STKNAME,SENSOR_TYPE,SENSOR_PARONE,SENSOR_PARTWO,SENSOR_PARTHREE,SENSOR_PARFOUR,TYPEID,SATTYPE," + schemeid + ",SENSORANGLEH,SENSORANGLE FROM LHF.T_PUB_SENSOR WHERE SENSOR_ID IN (");
            strSql.Append(" SELECT DISTINCT SENSOR_ID FROM LHF.SATELLITE_SENSOR_SELECTED WHERE SELECTED=1)");
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 根据schemeid添加方案卫星轨道数据
        /// </summary>
        /// <param name="schemeid"></param>
        /// <returns></returns>
        public int AddOrbitScheme(int schemeid,DateTime endTime,int satid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO LHF.TASKSCHEME_PRIVATE_ORBIT(");
            strSql.Append("SAT_ID,SAT_ORBITEPOCH,SAT_MEANMOTION,SAT_ECCENTRICITY,SAT_INCLINATION,SAT_ARGOFPERIGEE,SAT_RAAN,SAT_MEANANOMALY,SAT_MEANMOTIONDOT,SAT_MEANMOTIONDOTDOT,SAT_BSTAR,SAT_TLE1,SAT_TLE2,SCHEMEID)");
            strSql.Append(" SELECT TOP 1 SAT_ID,SAT_ORBITEPOCH,SAT_MEANMOTION,SAT_ECCENTRICITY,SAT_INCLINATION,SAT_ARGOFPERIGEE,SAT_RAAN,SAT_MEANANOMALY,SAT_MEANMOTIONDOT,SAT_MEANMOTIONDOTDOT,SAT_BSTAR,SAT_TLE1,SAT_TLE2,"+schemeid+" AS SCHEMEID FROM LHF.T_PUB_SATELLITEORBIT");
            strSql.Append("  WHERE SAT_ID=" + satid + " AND SAT_ORBITDATE<=@in_ENDTIME");
            strSql.Append("  ORDER BY SAT_ORBITDATE DESC");
            SqlParameter[] cmdParms = new SqlParameter[] {
				new SqlParameter("@in_ENDTIME", SqlDbType.DateTime)};
            cmdParms[0].Value = endTime;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }
        /// <summary>
        /// 根据schemeid添加方案卫星轨道数据
        /// </summary>
        /// <param name="schemeid"></param>
        /// <returns></returns>
        public int AddOrbitScheme(int schemeid, int satid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO LHF.TASKSCHEME_PRIVATE_ORBIT(");
            strSql.Append("SAT_ID,SAT_ORBITEPOCH,SAT_MEANMOTION,SAT_ECCENTRICITY,SAT_INCLINATION,SAT_ARGOFPERIGEE,SAT_RAAN,SAT_MEANANOMALY,SAT_MEANMOTIONDOT,SAT_MEANMOTIONDOTDOT,SAT_BSTAR,SAT_TLE1,SAT_TLE2,SCHEMEID)");
            strSql.Append(" SELECT SAT_ID,SAT_ORBITEPOCH,SAT_MEANMOTION,SAT_ECCENTRICITY,SAT_INCLINATION,SAT_ARGOFPERIGEE,SAT_RAAN,SAT_MEANANOMALY,SAT_MEANMOTIONDOT,SAT_MEANMOTIONDOTDOT,SAT_BSTAR,SAT_TLE1,SAT_TLE2,"+schemeid+" AS SCHEMEID FROM LHF.T_PUB_NEWORBIT");
            strSql.Append("  WHERE SAT_ID=" + satid );
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        #endregion

        #region -------- 私有方法，通常情况下无需修改 --------

        /// <summary>
		/// 由一行数据得到一个实体
		/// </summary>
		private Model.TASK_SCHEME_LIST GetModel(DbDataReader dr)
		{
			Model.TASK_SCHEME_LIST model = new Model.TASK_SCHEME_LIST();
            model.SCHEMEID = Convert.ToInt32(dr["SCHEMEID"]);
            model.SCHEMENAME = Convert.ToString(dr["SCHEMENAME"]);
			model.SCHEMEBTIME = Convert.ToDateTime(dr["SCHEMEBTIME"]);
            model.SCHEMEETIME = Convert.ToDateTime(dr["SCHEMEETIME"]);
            model.DISAID = Convert.ToInt32(dr["DISAID"]);
			return model;
		}

		/// <summary>
		/// 由DbDataReader得到泛型数据列表
		/// </summary>
		private List<Model.TASK_SCHEME_LIST> GetList(DbDataReader dr)
		{
			List<Model.TASK_SCHEME_LIST> lst = new List<Model.TASK_SCHEME_LIST>();
			while (dr.Read())
			{
				lst.Add(GetModel(dr));
			}
			return lst;
		}

		#endregion
	}
}
