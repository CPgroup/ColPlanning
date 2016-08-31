//------------------------------------------------------------------------------
// 创建标识: 董毅博
// 创建描述: 卫星载荷波段访问类
// 创建时间:2014.6.9
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
    public class SatelliteBand
    {
        //数据库连接字符串(web.config来配置)，可以动态更改connectionString支持多数据库.		
        public static string connectionString;
        public SatelliteBand()
        { connectionString = PubConstant.GetConnectionString(""); }


        /// <summary>
        /// 根据条件获取DataSet数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetListDataSet(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * ");
            strSql.Append(" FROM LHF.SATELLITE_SENSOR_BAND_MODE ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ORDER BY SENSOR_ID");
            DataSet ds = new DataSet();
            SqlDataAdapter oda = new SqlDataAdapter(strSql.ToString(), connectionString);
            if (ds.Tables["SATELLITE_SENSOR_BAND_MODE"] != null)
            {
                ds.Tables["SATELLITE_SENSOR_BAND_MODE"].Clear();
            }
            oda.Fill(ds, "SATELLITE_SENSOR_BAND_MODE");
            return ds;
        }


        /// <summary>
        /// 根据SENSOR_ID,SAT_ID,SENSOR_BAND_NAME获取卫星波段
        /// </summary>
        /// <param name="satid"></param>
        /// <param name="sensorid"></param>
        /// <param name="sensorBandName"></param>
        /// <returns></returns>
        public CoScheduling.Core.Model.SatelliteBand GetModel(string satid, string sensorid, string sensorBandName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from LHF.SATELLITE_SENSOR_BAND_MODE ");
            strSql.Append(" where SAT_ID=" + satid);
            strSql.Append(" and SENSOR_ID=" + sensorid);
            strSql.Append(" and BAND_MODE_NAME='" + sensorBandName + "'");
            using (DbDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                CoScheduling.Core.Model.SatelliteBand model = new CoScheduling.Core.Model.SatelliteBand();
                if (dr.Read())
                {
                    model = GetModel(dr);
                }
                dr.Close();
                return model;
            }
        }

        /// <summary>
        /// 获取卫星最优分辨率
        /// </summary>
        /// <param name="sat_id"></param>
        /// <returns></returns>
        public string GetMaxGsdBySatID(string sat_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT MIN(ACROSSRESOLUTION) FROM LHF.SATELLITE_SENSOR_BAND_MODE ");
            strSql.Append(" where SAT_ID=" + sat_id);
            return Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
        }
        /// <summary>
        /// 获取载荷最优分辨率
        /// </summary>
        /// <param name="sensor_id"></param>
        /// <returns></returns>
        public string GetMaxGsdBySensorID(string sensor_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT MIN(ACROSSRESOLUTION) FROM LHF.SATELLITE_SENSOR_BAND_MODE ");
            strSql.Append(" where SENSOR_ID=" + sensor_id);
            return Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
        }
        /// <summary>
        /// 获取卫星最大幅宽
        /// </summary>
        /// <param name="sat_id"></param>
        /// <returns></returns>
        public string GetMaxSwBySatID(string sat_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT MAX(SWATHWIDTH) FROM LHF.SATELLITE_SENSOR_BAND_MODE ");
            strSql.Append(" where SAT_ID=" + sat_id);
            return Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
        }

        /// <summary>
        /// 获取载荷最大幅宽
        /// </summary>
        /// <param name="sat_id"></param>
        /// <returns></returns>
        public string GetMaxSwBySensorID(string sensor_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT MAX(SWATHWIDTH) FROM LHF.SATELLITE_SENSOR_BAND_MODE ");
            strSql.Append(" where SENSOR_ID=" + sensor_id);
            return Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.SatelliteBand model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO LHF.SATELLITE_SENSOR_BAND_MODE(");
            strSql.Append("BAND_MODE_NAME,SENSOR_NAME,SAT_ID,SAT_NAME,SWATHWIDTH,INCLINATION,BAND_TYPE,SPECTRALRANGEMIN,SPECTRALRANGEMAX,POLARIZATION_MODE,SPECTRALCENTER,BANDWIDTH,SPECTRALRESOLUTION,ACROSSRESOLUTION,ALONGRESOLUTION,VERTICALRESOLUTION,SNRRATIO,SENSOR_ID)");
            strSql.Append(" VALUES (");
            strSql.Append("'" + model.BAND_MODE_NAME + "','" + model.SENSOR_NAME + "'," + model.SAT_ID + ",'" + model.SAT_NAME + "'," + model.SWATHWIDTH + ",'" + model.INCLINATION + "','" + model.BAND_TYPE + "'," + model.SPECTRALRANGEMIN + "," + model.SPECTRALRANGEMAX + ",'" + model.POLARIZATION_MODE + "','" + model.SPECTRALCENTER + "','" + model.BANDWIDTH + "','" + model.SPECTRALRESOLUTION + "'," + model.ACROSSRESOLUTION + "," + model.ALONGRESOLUTION + ",'" + model.VERTICALRESOLUTION + "','" + model.SNRRATIO + "'," + model.SENSOR_ID + ")");

            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Model.SatelliteBand model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE LHF.SATELLITE_SENSOR_BAND_MODE SET ");
            strSql.Append("SENSOR_NAME='" + model.SENSOR_NAME + "',");
            strSql.Append("SAT_NAME='" + model.SAT_NAME + "',");
            strSql.Append("SWATHWIDTH=" + model.SWATHWIDTH + ",");
            strSql.Append("INCLINATION='" + model.INCLINATION + "',");
            strSql.Append("BAND_TYPE='" + model.BAND_TYPE + "',");
            strSql.Append("SPECTRALRANGEMIN=" + model.SPECTRALRANGEMIN + ",");
            strSql.Append("SPECTRALRANGEMAX=" + model.SPECTRALRANGEMAX + ",");
            strSql.Append("POLARIZATION_MODE='" + model.POLARIZATION_MODE + "',");
            strSql.Append("SPECTRALCENTER='" + model.SPECTRALCENTER + "',");
            strSql.Append("BANDWIDTH='" + model.BANDWIDTH + "',");
            strSql.Append("SPECTRALRESOLUTION='" + model.SPECTRALRESOLUTION + "',");
            strSql.Append("ACROSSRESOLUTION=" + model.ACROSSRESOLUTION + ",");
            strSql.Append("ALONGRESOLUTION=" + model.ALONGRESOLUTION + ",");
            strSql.Append("VERTICALRESOLUTION='" + model.VERTICALRESOLUTION + "',");
            strSql.Append("SNRRATIO='" + model.SNRRATIO + "',");
            strSql.Append("SENSOR_ID=" + model.SENSOR_ID);
            strSql.Append(" WHERE BAND_MODE_NAME='" + model.BAND_MODE_NAME + "'");
            strSql.Append(" AND SENSOR_ID=" + model.SENSOR_ID);
            strSql.Append(" AND SAT_ID=" + model.SAT_ID);
            
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string BAND_NAME,string SAT_ID,string SENSOR_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete LHF.SATELLITE_SENSOR_BAND_MODE");
            strSql.Append(" where SAT_ID=" + SAT_ID);
            strSql.Append(" and SENSOR_ID=" + SENSOR_ID);
            strSql.Append(" and BAND_MODE_NAME='" + BAND_NAME+"'");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 根据SENSOR_ID删除数据
        /// </summary>
        public void DeleteBySensorID(string SENSOR_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete LHF.SATELLITE_SENSOR_BAND_MODE");
            strSql.Append(" where SENSOR_ID=" + SENSOR_ID);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 根据SAT_ID删除数据
        /// </summary>
        public void DeleteBySatID(string SAT_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete LHF.SATELLITE_SENSOR_BAND_MODE");
            strSql.Append(" where SAT_ID=" + SAT_ID);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        #region -------- 私有方法，通常情况下无需修改 --------

        /// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        private Model.SatelliteBand GetModel(DbDataReader dr)
        {
            Model.SatelliteBand model = new Model.SatelliteBand();
            model.BAND_MODE_NAME = Convert.ToString(dr["BAND_MODE_NAME"]);
            model.SENSOR_NAME = Convert.ToString(dr["SENSOR_NAME"]);
            model.SAT_ID = Convert.ToDecimal(dr["SAT_ID"]);
            model.SAT_NAME = Convert.ToString(dr["SAT_NAME"]);
            model.SWATHWIDTH = Convert.ToDecimal(dr["SWATHWIDTH"]);
            model.INCLINATION = Convert.ToString(dr["INCLINATION"]);
            model.BAND_TYPE = Convert.ToString(dr["BAND_TYPE"]);
            model.SPECTRALRANGEMIN = Convert.ToDecimal(dr["SPECTRALRANGEMIN"]);
            model.SPECTRALRANGEMAX = Convert.ToDecimal(dr["SPECTRALRANGEMAX"]);
            model.POLARIZATION_MODE = Convert.ToString(dr["POLARIZATION_MODE"]);
            model.SPECTRALCENTER = Convert.ToString(dr["SPECTRALCENTER"]);
            model.BANDWIDTH = Convert.ToString(dr["BANDWIDTH"]);
            model.SPECTRALRESOLUTION = Convert.ToString(dr["SPECTRALRESOLUTION"]);
            model.ACROSSRESOLUTION = Convert.ToDecimal(dr["ACROSSRESOLUTION"]);
            model.ALONGRESOLUTION = Convert.ToDecimal(dr["ALONGRESOLUTION"]);
            model.VERTICALRESOLUTION = Convert.ToString(dr["VERTICALRESOLUTION"]);
            model.SNRRATIO = Convert.ToString(dr["SNRRATIO"]);
            model.SENSOR_ID = Convert.ToDecimal(dr["SENSOR_ID"]);
            return model;
        }

        /// <summary>
        /// 由DbDataReader得到泛型数据列表
        /// </summary>
        private List<Model.SatelliteBand> GetList(DbDataReader dr)
        {
            List<Model.SatelliteBand> lst = new List<Model.SatelliteBand>();
            while (dr.Read())
            {
                lst.Add(GetModel(dr));
            }
            return lst;
        }

        #endregion

    }
}
