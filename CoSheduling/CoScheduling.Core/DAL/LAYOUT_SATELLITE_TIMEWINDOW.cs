//------------------------------------------------------------------------------
// 创建标识: 董毅博
// 创建描述: 规划最初时间窗口访问类
// 创建时间:2014.6.15
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
    public class LAYOUT_SATELLITE_TIMEWINDOW
    {
        public static string connectionString;
        public LAYOUT_SATELLITE_TIMEWINDOW()
        { connectionString = PubConstant.GetConnectionString(""); }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.LAYOUT_SATELLITE_TIMEWINDOW model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO LHF.LAYOUT_SATELLITE_TIMEWINDOW(");
            strSql.Append("SAT_STKNAME,SENSOR_STKNAME,TARGET_STKNAME,STARTTIME,ENDTIME,SANGLE,GSD,CIRCLE,TIMELONG,MAXSANGLE,MINSANGLE,IMAGEREGION,SCHEMEID,SATID,SENSORID,TASKID)");
            strSql.Append(" VALUES (");
            strSql.Append("@in_SAT_STKNAME,@in_SENSOR_STKNAME,@in_TARGET_STKNAME,@in_STARTTIME,@in_ENDTIME,@in_SANGLE,@in_GSD,@in_CIRCLE,@in_TIMELONG,@in_MAXSANGLE,@in_MINSANGLE,@in_IMAGEREGION,@in_SCHEMEID,@in_SATID,@in_SENSORID,@in_TASKID)");
            SqlParameter[] cmdParms = new SqlParameter[] {
				new SqlParameter("@in_TW_SEQID", SqlDbType.Decimal),
				new SqlParameter("@in_SAT_STKNAME", SqlDbType.NVarChar),
				new SqlParameter("@in_SENSOR_STKNAME", SqlDbType.NVarChar),
				new SqlParameter("@in_TARGET_STKNAME", SqlDbType.NVarChar),
				new SqlParameter("@in_STARTTIME", SqlDbType.DateTime),
				new SqlParameter("@in_ENDTIME", SqlDbType.DateTime),
				new SqlParameter("@in_SANGLE", SqlDbType.Decimal),
				new SqlParameter("@in_GSD", SqlDbType.Decimal),
				new SqlParameter("@in_CIRCLE", SqlDbType.Decimal),
				new SqlParameter("@in_TIMELONG", SqlDbType.Decimal),
				new SqlParameter("@in_MAXSANGLE", SqlDbType.Decimal),
				new SqlParameter("@in_MINSANGLE", SqlDbType.Decimal),
				new SqlParameter("@in_IMAGEREGION", SqlDbType.NVarChar),
				new SqlParameter("@in_SCHEMEID", SqlDbType.Decimal),
				new SqlParameter("@in_SATID", SqlDbType.Decimal),
				new SqlParameter("@in_SENSORID", SqlDbType.Decimal),
				new SqlParameter("@in_TASKID", SqlDbType.Decimal)};
            cmdParms[0].Value = model.TW_SEQID;
            cmdParms[1].Value = model.SAT_STKNAME;
            cmdParms[2].Value = model.SENSOR_STKNAME;
            cmdParms[3].Value = model.TARGET_STKNAME;
            cmdParms[4].Value = model.STARTTIME;
            cmdParms[5].Value = model.ENDTIME;
            cmdParms[6].Value = model.SANGLE;
            cmdParms[7].Value = model.GSD;
            cmdParms[8].Value = model.CIRCLE;
            cmdParms[9].Value = model.TIMELONG;
            cmdParms[10].Value = model.MAXSANGLE;
            cmdParms[11].Value = model.MINSANGLE;
            cmdParms[12].Value = model.IMAGEREGION;
            cmdParms[13].Value = model.SCHEMEID;
            cmdParms[14].Value = model.SATID;
            cmdParms[15].Value = model.SENSORID;
            cmdParms[16].Value = model.TASKID;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Model.LAYOUT_SATELLITE_TIMEWINDOW model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE LHF.LAYOUT_SATELLITE_TIMEWINDOW SET ");
            strSql.Append("SAT_STKNAME=@in_SAT_STKNAME,");
            strSql.Append("SENSOR_STKNAME=@in_SENSOR_STKNAME,");
            strSql.Append("TARGET_STKNAME=@in_TARGET_STKNAME,");
            strSql.Append("STARTTIME=@in_STARTTIME,");
            strSql.Append("ENDTIME=@in_ENDTIME,");
            strSql.Append("SANGLE=@in_SANGLE,");
            strSql.Append("GSD=@in_GSD,");
            strSql.Append("CIRCLE=@in_CIRCLE,");
            strSql.Append("TIMELONG=@in_TIMELONG,");
            strSql.Append("MAXSANGLE=@in_MAXSANGLE,");
            strSql.Append("MINSANGLE=@in_MINSANGLE,");
            strSql.Append("IMAGEREGION=@in_IMAGEREGION,");
            strSql.Append("SCHEMEID=@in_SCHEMEID,");
            strSql.Append("SATID=@in_SATID,");
            strSql.Append("SENSORID=@in_SENSORID,");
            strSql.Append("TASKID=@in_TASKID");
            strSql.Append(" WHERE TW_SEQID=@in_TW_SEQID");
            SqlParameter[] cmdParms = new SqlParameter[] {
				new SqlParameter("@in_TW_SEQID", SqlDbType.Decimal),
				new SqlParameter("@in_SAT_STKNAME", SqlDbType.NVarChar),
				new SqlParameter("@in_SENSOR_STKNAME", SqlDbType.NVarChar),
				new SqlParameter("@in_TARGET_STKNAME", SqlDbType.NVarChar),
				new SqlParameter("@in_STARTTIME", SqlDbType.DateTime),
				new SqlParameter("@in_ENDTIME", SqlDbType.DateTime),
				new SqlParameter("@in_SANGLE", SqlDbType.Decimal),
				new SqlParameter("@in_GSD", SqlDbType.Decimal),
				new SqlParameter("@in_CIRCLE", SqlDbType.Decimal),
				new SqlParameter("@in_TIMELONG", SqlDbType.Decimal),
				new SqlParameter("@in_MAXSANGLE", SqlDbType.Decimal),
				new SqlParameter("@in_MINSANGLE", SqlDbType.Decimal),
				new SqlParameter("@in_IMAGEREGION", SqlDbType.NVarChar),
				new SqlParameter("@in_SCHEMEID", SqlDbType.Decimal),
				new SqlParameter("@in_SATID", SqlDbType.Decimal),
				new SqlParameter("@in_SENSORID", SqlDbType.Decimal),
				new SqlParameter("@in_TASKID", SqlDbType.Decimal)};
            cmdParms[0].Value = model.TW_SEQID;
            cmdParms[1].Value = model.SAT_STKNAME;
            cmdParms[2].Value = model.SENSOR_STKNAME;
            cmdParms[3].Value = model.TARGET_STKNAME;
            cmdParms[4].Value = model.STARTTIME;
            cmdParms[5].Value = model.ENDTIME;
            cmdParms[6].Value = model.SANGLE;
            cmdParms[7].Value = model.GSD;
            cmdParms[8].Value = model.CIRCLE;
            cmdParms[9].Value = model.TIMELONG;
            cmdParms[10].Value = model.MAXSANGLE;
            cmdParms[11].Value = model.MINSANGLE;
            cmdParms[12].Value = model.IMAGEREGION;
            cmdParms[13].Value = model.SCHEMEID;
            cmdParms[14].Value = model.SATID;
            cmdParms[15].Value = model.SENSORID;
            cmdParms[16].Value = model.TASKID;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(decimal TW_SEQID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM LHF.LAYOUT_SATELLITE_TIMEWINDOW ");
            strSql.Append(" WHERE TW_SEQID="+TW_SEQID);

            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(decimal TW_SEQID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM LHF.LAYOUT_SATELLITE_TIMEWINDOW");
            strSql.Append(" WHERE TW_SEQID="+TW_SEQID);
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.LAYOUT_SATELLITE_TIMEWINDOW GetModel(decimal TW_SEQID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM LHF.LAYOUT_SATELLITE_TIMEWINDOW ");
            strSql.Append(" WHERE TW_SEQID="+TW_SEQID);
            
            Model.LAYOUT_SATELLITE_TIMEWINDOW model = null;
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
        public List<Model.LAYOUT_SATELLITE_TIMEWINDOW> GetList()
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM LHF.LAYOUT_SATELLITE_TIMEWINDOW");
            using (DbDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.LAYOUT_SATELLITE_TIMEWINDOW> lst = GetList(dr);
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
            strSql.Append(" FROM LHF.LAYOUT_SATELLITE_TIMEWINDOW ");
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
        private Model.LAYOUT_SATELLITE_TIMEWINDOW GetModel(DbDataReader dr)
        {
            Model.LAYOUT_SATELLITE_TIMEWINDOW model = new Model.LAYOUT_SATELLITE_TIMEWINDOW();
            model.TW_SEQID = Convert.ToDecimal(dr["TW_SEQID"]);
            model.SAT_STKNAME = Convert.ToString(dr["SAT_STKNAME"]);
            model.SENSOR_STKNAME = Convert.ToString(dr["SENSOR_STKNAME"]);
            model.TARGET_STKNAME = Convert.ToString(dr["TARGET_STKNAME"]);
            model.STARTTIME = Convert.ToDateTime(dr["STARTTIME"]);
            model.ENDTIME = Convert.ToDateTime(dr["ENDTIME"]);
            model.SANGLE = Convert.ToDecimal(dr["SANGLE"]);
            model.GSD = Convert.ToDecimal(dr["GSD"]);
            model.CIRCLE = Convert.ToDecimal(dr["CIRCLE"]);
            model.TIMELONG = Convert.ToDecimal(dr["TIMELONG"]);
            model.MAXSANGLE = Convert.ToDecimal(dr["MAXSANGLE"]);
            model.MINSANGLE = Convert.ToDecimal(dr["MINSANGLE"]);
            model.IMAGEREGION = Convert.ToString(dr["IMAGEREGION"]);
            model.SCHEMEID = Convert.ToDecimal(dr["SCHEMEID"]);
            model.SATID = Convert.ToDecimal(dr["SATID"]);
            model.SENSORID = Convert.ToDecimal(dr["SENSORID"]);
            model.TASKID = Convert.ToDecimal(dr["TASKID"]);
            return model;
        }

        /// <summary>
        /// 由DbDataReader得到泛型数据列表
        /// </summary>
        private List<Model.LAYOUT_SATELLITE_TIMEWINDOW> GetList(DbDataReader dr)
        {
            List<Model.LAYOUT_SATELLITE_TIMEWINDOW> lst = new List<Model.LAYOUT_SATELLITE_TIMEWINDOW>();
            while (dr.Read())
            {
                lst.Add(GetModel(dr));
            }
            return lst;
        }

        #endregion
    }
}
