//------------------------------------------------------------------------------
// 创建标识: 董毅博
// 创建描述: 卫星载荷访问类
// 创建时间:2013.12.4
// 文件版本:1.0
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

    public class SatelliteSensor
    {
        //数据库连接字符串(web.config来配置)，可以动态更改connectionString支持多数据库.		
        public static string connectionString;
        public SatelliteSensor()
        { connectionString = PubConstant.GetConnectionString(""); }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.SatelliteSensor model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO LHF.SATELLITE_SENSOR(");
            strSql.Append("SENSOR_ID,SENSOR_NAME,SAT_ID,SAT_NAME,SENSOR_TYPE,APPLICATION,FOV,SWATHWIDTH,ACROSSPOINTINGRANGE,ALONGPOINTINGRANGE,LOCATIONACCURACY,NUMOFBANDS,BANDCATEGORIES,ACCURACY,REVISITTIME,INSTRUMENTDESCRIPTION,DATA_ACCESS,DATA_FORMAT,MAXGSD,INCLINATION)");
            strSql.Append(" VALUES (");
            strSql.Append(model.SENSOR_ID + ",'" + model.SENSOR_NAME + "'," + model.SAT_ID + ",'" + model.SAT_NAME + "'," + model.SENSOR_TYPE + ",'" + model.APPLICATION + "'," + model.FOV + "," + model.SWATHWIDTH + "," + model.ACROSSPOINTINGRANGE + "," + model.ALONGPOINTINGRANGE + "," + model.LOCATIONACCURACY + "," + model.NUMOFBANDS + ",'" + model.BANDCATEGORIES + "','" + model.ACCURACY + "'," + model.REVISITTIME + ",'" + model.INSTRUMENTDESCRIPTION + "','" + model.DATA_ACCESS + "' , '" + model.DATA_FORMAT + "',-1," + model.INCLINATION + ")");
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Model.SatelliteSensor model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE LHF.SATELLITE_SENSOR SET ");
            strSql.Append("SAT_ID=" + model.SAT_ID + ",");
            strSql.Append("SAT_NAME='" + model.SAT_NAME + "',");
            strSql.Append("SENSOR_TYPE="+model.SENSOR_TYPE+",");
            strSql.Append("APPLICATION='"+model.APPLICATION+"',");
            strSql.Append("FOV="+model.FOV+",");
            strSql.Append("SWATHWIDTH="+model.SWATHWIDTH+",");
            strSql.Append("ACROSSPOINTINGRANGE=" + model.ACROSSPOINTINGRANGE + ",");
            strSql.Append("ALONGPOINTINGRANGE=" + model.ALONGPOINTINGRANGE + ",");
            strSql.Append("LOCATIONACCURACY=" + model.LOCATIONACCURACY + ",");
            strSql.Append("NUMOFBANDS=" + model.NUMOFBANDS + ",");
            strSql.Append("BANDCATEGORIES='" + model.BANDCATEGORIES + "',");
            strSql.Append("ACCURACY='" + model.ACCURACY + "',");
            strSql.Append("REVISITTIME=" + model.REVISITTIME + ",");
            strSql.Append("INSTRUMENTDESCRIPTION='" + model.INSTRUMENTDESCRIPTION + "',");
            strSql.Append("DATA_ACCESS='" + model.DATA_ACCESS + "',");
            strSql.Append("DATA_FORMAT='" + model.DATA_FORMAT + "',");
            strSql.Append("INCLINATION=" + model.INCLINATION);
            strSql.Append(" WHERE SENSOR_ID="+model.SENSOR_ID);

            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 更新载荷参数
        /// </summary>
        public int UpdateCanshu(string sensor_id, string maxgsd, string maxsw,string fov)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE LHF.SATELLITE_SENSOR SET ");
            strSql.Append("SWATHWIDTH=" + maxsw + ",");
            strSql.Append("FOV=" + fov + ",");
            strSql.Append("MAXGSD=" + maxgsd);
            strSql.Append(" WHERE SENSOR_ID=" + sensor_id);
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 获取全部记录
        /// </summary>
        /// <returns></returns>
        public List<CoScheduling.Core.Model.SatelliteSensor> GetList()
        {
            StringBuilder StrSql = new StringBuilder();
            StrSql.Append("SELECT * FROM LHF.SATELLITE_SENSOR order by SAT_ID desc");

            using (DbDataReader dr = DbHelperSQL.ExecuteReader(StrSql.ToString()))
            {
                List<CoScheduling.Core.Model.SatelliteSensor> lst = GetList(dr);
                dr.Close();
                return lst;
            }
        }

        /// <summary>
        /// 根据SAT_ID获取记录
        /// </summary>
        /// <returns></returns>
        public List<CoScheduling.Core.Model.SatelliteSensor> GetList(string id)
        {
            StringBuilder StrSql = new StringBuilder();
            StrSql.Append("SELECT * FROM LHF.SATELLITE_SENSOR");
            StrSql.Append(" where SAT_ID="+id);
            using (DbDataReader dr = DbHelperSQL.ExecuteReader(StrSql.ToString()))
            {
                List<CoScheduling.Core.Model.SatelliteSensor> lst = GetList(dr);
                dr.Close();
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
            strSql.Append(" FROM LHF.SATELLITE_SENSOR ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ORDER BY SENSOR_ID");
            DataSet ds = new DataSet();
            SqlDataAdapter oda = new SqlDataAdapter(strSql.ToString(), connectionString);
            if (ds.Tables["SATELLITE_SENSOR"] != null)
            {
                ds.Tables["SATELLITE_SENSOR"].Clear();
            }
            oda.Fill(ds, "SATELLITE_SENSOR");
            return ds;
        }
        /// <summary>
        /// 根据SENSOR_ID获取卫星载荷
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CoScheduling.Core.Model.SatelliteSensor GetModel(string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from LHF.SATELLITE_SENSOR ");
            strSql.Append(" where SENSOR_ID=" + id);
            using (DbDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                CoScheduling.Core.Model.SatelliteSensor model = new CoScheduling.Core.Model.SatelliteSensor();
                if (dr.Read())
                {
                    model = GetModel(dr);
                }
                dr.Close();
                return model;
            }
        }

        /// <summary>
        /// 根据SAT_ID获取最新载荷ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public decimal GetSensorID(string sat_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select max(SENSOR_ID) from LHF.SATELLITE_SENSOR ");
            strSql.Append(" where SAT_ID=" + sat_id);
            if (DbHelperSQL.GetSingle(strSql.ToString())==null)
            {
                return Convert.ToDecimal(sat_id.ToString() + "01");
            } 
            else
            {
                return Convert.ToDecimal(DbHelperSQL.GetSingle(strSql.ToString())) + 1;
            }            
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string SENSOR_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from LHF.SATELLITE_SENSOR");
            strSql.Append(" where SENSOR_ID=" + SENSOR_ID);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 根据SAT_ID删除数据
        /// </summary>
        public void DeleteBySatID(string SAT_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from LHF.SATELLITE_SENSOR");
            strSql.Append(" where SAT_ID=" + SAT_ID);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        #region -------- 私有方法，通常情况下无需修改 --------

        /// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        private CoScheduling.Core.Model.SatelliteSensor GetModel(DbDataReader dr)
        {
            CoScheduling.Core.Model.SatelliteSensor model = new CoScheduling.Core.Model.SatelliteSensor();
            model.SAT_ID = Convert.ToDecimal(dr["SAT_ID"]);
            model.SAT_NAME = Convert.ToString(dr["SAT_NAME"]);
            model.SENSOR_NAME = Convert.ToString(dr["SENSOR_NAME"]);
            model.SENSOR_ID = Convert.ToDecimal(dr["SENSOR_ID"]);
            try
            {
                model.SENSOR_TYPE = Convert.ToDecimal(dr["SENSOR_TYPE"]);
            }
            catch
            {
                model.SENSOR_TYPE = Convert.ToDecimal("-1");
            }

            try
            {
                model.APPLICATION = Convert.ToString(dr["APPLICATION"]);
            }
            catch
            {
                model.APPLICATION = Convert.ToString("N/A");
            }

            try
            {
                model.FOV = Convert.ToDecimal(dr["FOV"]);
            }
            catch
            {
                model.FOV = Convert.ToDecimal("-1");
            }
            try
            {
                model.SWATHWIDTH = Convert.ToDecimal(dr["SWATHWIDTH"]);
            }
            catch
            {
                model.SWATHWIDTH = Convert.ToDecimal("-1");
            }
            try
            {
                model.ACROSSPOINTINGRANGE = Convert.ToDecimal(dr["ACROSSPOINTINGRANGE"]);
            }
            catch
            {
                model.ACROSSPOINTINGRANGE = Convert.ToDecimal("-1");
            }
            try
            {
                model.ALONGPOINTINGRANGE = Convert.ToDecimal(dr["ALONGPOINTINGRANGE"]);
            }
            catch
            {
                model.ALONGPOINTINGRANGE = Convert.ToDecimal("-1");
            }
            try
            {
                model.LOCATIONACCURACY = Convert.ToDecimal(dr["LOCATIONACCURACY"]);
            }
            catch
            {
                model.LOCATIONACCURACY = Convert.ToDecimal("-1");
            }
            try
            {
                model.NUMOFBANDS = Convert.ToDecimal(dr["NUMOFBANDS"]);
            }
            catch
            {
                model.NUMOFBANDS = Convert.ToDecimal("-1");
            }
            try
            {
                model.BANDCATEGORIES = Convert.ToString(dr["BANDCATEGORIES"]);
            }
            catch
            {
                model.BANDCATEGORIES = Convert.ToString("N/A");
            }
            try
            {
                model.ACCURACY = Convert.ToString(dr["ACCURACY"]);
            }
            catch
            {
                model.ACCURACY = Convert.ToString("N/A");
            }
            try
            {
                model.REVISITTIME = Convert.ToDecimal(dr["REVISITTIME"]);
            }
            catch
            {
                model.REVISITTIME = Convert.ToDecimal("-1");
            }
            try
            {
                model.INSTRUMENTDESCRIPTION = Convert.ToString(dr["INSTRUMENTDESCRIPTION"]);
            }
            catch
            {
                model.INSTRUMENTDESCRIPTION = Convert.ToString("N/A");
            }
            try
            {
                model.DATA_ACCESS = Convert.ToString(dr["DATA_ACCESS"]);
            }
            catch
            {
                model.DATA_ACCESS = Convert.ToString("N/A");
            }
            try
            {
                model.DATA_FORMAT = Convert.ToString(dr["DATA_FORMAT"]);
            }
            catch
            {
                model.DATA_FORMAT = Convert.ToString("N/A");
            }
            try
            {
                model.INCLINATION = Convert.ToDecimal(dr["INCLINATION"]);
            }
            catch
            {
                model.INCLINATION = Convert.ToDecimal("0");
            }

            return model;
        }

        /// <summary>
        /// 由DbDataReader得到泛型数据列表
        /// </summary>
        private List<CoScheduling.Core.Model.SatelliteSensor> GetList(DbDataReader dr)
        {
            List<CoScheduling.Core.Model.SatelliteSensor> lst = new List<CoScheduling.Core.Model.SatelliteSensor>();
            while (dr.Read())
            {
                lst.Add(GetModel(dr));
            }
            return lst;
        }

        #endregion
    }
}
