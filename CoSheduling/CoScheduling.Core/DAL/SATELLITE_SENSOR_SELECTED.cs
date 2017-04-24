//------------------------------------------------------------------------------
// 创建标识: 董毅博
// 创建描述: 卫星信息访问类
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
	/// 数据访问类 SATELLITE_SENSOR_SELECTED
	/// </summary>
	public class SATELLITE_SENSOR_SELECTED
	{
        //数据库连接字符串(web.config来配置)，可以动态更改connectionString支持多数据库.		
        public static string connectionString;
        public SATELLITE_SENSOR_SELECTED()
        {
            connectionString = PubConstant.GetConnectionString("");
        }
        /// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Model.SATELLITE_SENSOR_SELECTED model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("INSERT INTO LHF.SATELLITE_SENSOR_SELECTED(");
            strSql.Append("SENSOR_ID,SENSOR_NAME,SAT_ID,SAT_NAME,SELECTED)");
			strSql.Append(" VALUES (");
            strSql.Append("@in_SENSOR_ID,@in_SENSOR_NAME,@in_SAT_ID,@in_SAT_NAME,@in_SELECTED)");
            SqlParameter[] cmdParms = new SqlParameter[]{
				new SqlParameter("@in_SENSOR_ID", SqlDbType.Decimal),
				new SqlParameter("@in_SENSOR_NAME", SqlDbType.NVarChar),
				new SqlParameter("@in_SAT_ID",SqlDbType.Decimal),
				new SqlParameter("@in_SAT_NAME", SqlDbType.NVarChar),
				new SqlParameter("@in_SELECTED", SqlDbType.Decimal)};
            cmdParms[0].Value = model.SENSOR_ID;
            cmdParms[1].Value = model.SENSOR_NAME;
            cmdParms[2].Value = model.SAT_ID;
            cmdParms[3].Value = model.SAT_NAME;
            cmdParms[4].Value = model.SELECTED;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public int Update(Model.SATELLITE_SENSOR_SELECTED model)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE LHF.SATELLITE_SENSOR_SELECTED SET ");
            strSql.Append("SENSOR_NAME=@in_SENSOR_NAME,");
            strSql.Append("SAT_ID=@in_SAT_ID,");
            strSql.Append("SAT_NAME=@in_SAT_NAME,");
            strSql.Append("SELECTED=@in_SELECTED");
            strSql.Append(" WHERE SENSOR_ID=@in_SENSOR_ID");
            SqlParameter[] cmdParms = new SqlParameter[]{
				new SqlParameter("@in_SENSOR_ID", SqlDbType.Decimal),
				new SqlParameter("@in_SENSOR_NAME", SqlDbType.NVarChar),
				new SqlParameter("@in_SAT_ID",SqlDbType.Decimal),
				new SqlParameter("@in_SAT_NAME", SqlDbType.NVarChar),
				new SqlParameter("@in_SELECTED", SqlDbType.Decimal)};
            cmdParms[0].Value = model.SENSOR_ID;
            cmdParms[1].Value = model.SENSOR_NAME;
            cmdParms[2].Value = model.SAT_ID;
            cmdParms[3].Value = model.SAT_NAME;
            cmdParms[4].Value = model.SELECTED;
            return DbHelperSQL.ExecuteSql(strSql.ToString());
		}
        public int UpdateFlase(Model.SATELLITE_SENSOR_SELECTED model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE LHF.SATELLITE_SENSOR_SELECTED SET ");
            strSql.Append("SELECTED=0");
            strSql.Append(" WHERE SENSOR_ID=" + model.SENSOR_ID);
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        public int UpdateFlase(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE LHF.SATELLITE_SENSOR_SELECTED SET ");
            strSql.Append("SELECTED=0 ");
            strSql.Append(strWhere);
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        public int UpdateTrue(string satCondition, string sensorCondition)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE LHF.SATELLITE_SENSOR_SELECTED SET ");
            strSql.Append("SELECTED=1");
            strSql.Append(" WHERE SENSOR_ID IN " + sensorCondition);
            strSql.Append(" AND SAT_ID IN " + satCondition);
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public int Delete(decimal SENSOR_ID)
		{
			StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM LHF.SATELLITE_SENSOR_SELECTED ");
            strSql.Append(" WHERE SENSOR_ID=" + SENSOR_ID);

            return DbHelperSQL.ExecuteSql(strSql.ToString());
		}
        /// <summary>
        /// 删除所有数据
        /// </summary>
        public int Clear()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM LHF.SATELLITE_SENSOR_SELECTED ");

            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 重置所有数据
        /// </summary>
        /// <returns></returns>
        public int Reset()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO LHF.SATELLITE_SENSOR_SELECTED ");
            strSql.Append("SELECT SENSOR_ID,SENSOR_NAME,SAT_ID,SAT_NAME,0 FROM LHF.SATELLITE_SENSOR");
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int DeleteBySatID(decimal SAT_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM LHF.SATELLITE_SENSOR_SELECTED ");
            strSql.Append(" WHERE SAT_ID=" + SAT_ID);

            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal SENSOR_ID)
		{
			StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM LHF.SATELLITE_SENSOR_SELECTED");
            strSql.Append(" WHERE SENSOR_ID=" + SENSOR_ID);

            return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.SATELLITE_SENSOR_SELECTED GetModel(decimal SENSOR_ID)
		{
			StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM LHF.SATELLITE_SENSOR_SELECTED ");
            strSql.Append(" WHERE SENSOR_ID=SENSOR_ID");

            using (DbDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                CoScheduling.Core.Model.SATELLITE_SENSOR_SELECTED model = new CoScheduling.Core.Model.SATELLITE_SENSOR_SELECTED();
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
            strSql.Append(" FROM LHF.SATELLITE_SENSOR_SELECTED ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ORDER BY SENSOR_ID");
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.SATELLITE_SENSOR_SELECTED> GetCheckedList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * ");
            strSql.Append(" FROM LHF.SATELLITE_SENSOR_SELECTED ");
            strSql.Append(" WHERE SELECTED=1");
            strSql.Append(" ORDER BY SENSOR_ID");
            using (DbDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.SATELLITE_SENSOR_SELECTED> lst = GetList(dr);
                return lst;
            }
        }

        public List<Model.SATELLITE_SENSOR_SELECTED> GetCheckedList2()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT SENSOR_ID,SAT_NAME+\'~\'+SENSOR_NAME AS SENSOR_NAME,SAT_ID,SAT_NAME,SELECTED ");
            strSql.Append(" FROM LHF.SATELLITE_SENSOR_SELECTED ");
            strSql.Append(" WHERE SELECTED=1");
            strSql.Append(" ORDER BY SENSOR_ID");
            using (DbDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.SATELLITE_SENSOR_SELECTED> lst = GetList(dr);
                return lst;
            }
        }



		/// <summary>
		/// 获取泛型数据列表
		/// </summary>
		public List<Model.SATELLITE_SENSOR_SELECTED> GetList()
		{
            StringBuilder strSql = new StringBuilder("SELECT * FROM LHF.SATELLITE_SENSOR_SELECTED");
            using (DbDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString(), null))
            {
                List<Model.SATELLITE_SENSOR_SELECTED> lst = GetList(dr);
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
            strSql.Append(" FROM LHF.SATELLITE_SENSOR_SELECTED ");
            if (strWhere.Trim() != "")
            {
                strSql.Append("WHERE " + strWhere);
            }
            strSql.Append(" ORDER BY SENSOR_ID");
            DataSet ds = new DataSet();
            SqlDataAdapter odaSat = new SqlDataAdapter(strSql.ToString(), connectionString);
            if (ds.Tables["SATELLITE_SENSOR_SELECTED"] != null)
            {
                ds.Tables["SATELLITE_SENSOR_SELECTED"].Clear();
            }
            odaSat.Fill(ds, "SATELLITE_SENSOR_SELECTED");
            return ds;
        }

		/// <summary>
		/// 得到数据条数
		/// </summary>
        public int GetCount(string strWhere)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT (*) ");
            strSql.Append(" FROM LHF.SATELLITE_SENSOR_SELECTED ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
		}

        /// <summary>
        /// 得到卫星数量
        /// </summary>
        public int GetSatCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT (DISTINCT SAT_ID) ");
            strSql.Append(" FROM LHF.SATELLITE_SENSOR_SELECTED ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }

        /// <summary>
        /// 得到卫星id列表
        /// </summary>
        public List<int> GetCheckedSatID(bool check)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT DISTINCT SAT_ID ");
            strSql.Append(" FROM LHF.SATELLITE_SENSOR_SELECTED ");
            if (check)
            {
                strSql.Append(" WHERE SELECTED=1");
            }
            else
            {
                strSql.Append(" WHERE SELECTED=0");
            }
            List<int> lst = new List<int>();
            using (DbDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (dr.Read())
                {
                    lst.Add(Convert.ToInt32(dr["SAT_ID"]));
                }
                return lst;
            }
        }
        


		#region -------- 私有方法，通常情况下无需修改 --------

		/// <summary>
		/// 由一行数据得到一个实体
		/// </summary>
		private Model.SATELLITE_SENSOR_SELECTED GetModel(DbDataReader dr)
		{
			Model.SATELLITE_SENSOR_SELECTED model = new Model.SATELLITE_SENSOR_SELECTED();
            model.SENSOR_ID = Convert.ToDecimal(dr["SENSOR_ID"]);
            model.SENSOR_NAME = Convert.ToString(dr["SENSOR_NAME"]);
            model.SAT_ID = Convert.ToDecimal(dr["SAT_ID"]);
            model.SAT_NAME = Convert.ToString(dr["SAT_NAME"]);
            model.SELECTED = Convert.ToDecimal(dr["SELECTED"]);
			return model;
		}

		/// <summary>
		/// 由DbDataReader得到泛型数据列表
		/// </summary>
		private List<Model.SATELLITE_SENSOR_SELECTED> GetList(DbDataReader dr)
		{
			List<Model.SATELLITE_SENSOR_SELECTED> lst = new List<Model.SATELLITE_SENSOR_SELECTED>();
			while (dr.Read())
			{
				lst.Add(GetModel(dr));
			}
			return lst;
		}

		#endregion
	}
}
