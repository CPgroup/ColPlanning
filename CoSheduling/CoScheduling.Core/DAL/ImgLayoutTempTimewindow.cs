//------------------------------------------------------------------------------
// 创建标识: 董毅博
// 创建描述: 规划结果访问类
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
    public class ImgLayoutTempTimewindow
    {
        public static string connectionString;
        public ImgLayoutTempTimewindow()
        { connectionString = PubConstant.GetConnectionString(""); }


        /// <summary>
        /// 更新占用标识符
        /// </summary>
        /// <param name="LSTR_SEQID"></param>
        /// <param name="IS_OCCUPY"></param>
        /// <returns></returns>
        public int UpdateOccupy(decimal LSTR_SEQID, decimal IS_OCCUPY)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE LHF.IMG_LAYOUT_TEMPTIMEWINDOW SET ");
            strSql.Append("IS_OCCUPY=@in_IS_OCCUPY");
            strSql.Append(" WHERE LSTR_SEQID=@in_LSTR_SEQID");
            SqlParameter[] cmdParms = new SqlParameter[] {
				new SqlParameter("@in_LSTR_SEQID", SqlDbType.Decimal),
                new SqlParameter("@in_IS_OCCUPY", SqlDbType.Decimal)};
            cmdParms[0].Value = LSTR_SEQID;
            cmdParms[1].Value = IS_OCCUPY;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }
        /// <summary>
        /// 更新影响标识符,依据开始时间
        /// </summary>
        /// <param name="LSTR_SEQID"></param>
        /// <param name="IS_OCCUPY"></param>
        /// <returns></returns>
        public int UpdateOtherAffS(decimal LSTR_SEQID, decimal satid, decimal schemeid, DateTime starttime, DateTime endtime, decimal IS_AFFECT)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE LHF.IMG_LAYOUT_TEMPTIMEWINDOW SET ");
            strSql.Append("IS_AFFECT=@in_IS_AFFECT,");
            strSql.Append("AFF_OCUSTR=AFF_OCUSTR +'@in_LSTR_SEQID,'");
            strSql.Append(" WHERE SCHEMEID=@in_SCHEMEID");
            strSql.Append(" AND IS_OCCUPY=0");
            strSql.Append(" AND SATID=@in_SATID");
            strSql.Append(" AND STARTTIME>@in_STARTTIME");
            strSql.Append(" AND STARTTIME<@in_ENDTIME");
            SqlParameter[] cmdParms = new SqlParameter[] {
				new SqlParameter("@in_IS_AFFECT", SqlDbType.Decimal),
                new SqlParameter("@in_LSTR_SEQID", SqlDbType.Decimal),
                new SqlParameter("@in_SCHEMEID", SqlDbType.Decimal),
                new SqlParameter("@in_SATID", SqlDbType.Decimal),
                new SqlParameter("@in_STARTTIME", SqlDbType.DateTime),
                new SqlParameter("@in_ENDTIME", SqlDbType.DateTime)};
            cmdParms[0].Value = IS_AFFECT;
            cmdParms[1].Value = LSTR_SEQID;
            cmdParms[2].Value = schemeid;
            cmdParms[3].Value = satid;
            cmdParms[4].Value = starttime;
            cmdParms[5].Value = endtime;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }
        /// <summary>
        /// 更新影响标识符,依据结束时间
        /// </summary>
        /// <param name="LSTR_SEQID"></param>
        /// <param name="IS_OCCUPY"></param>
        /// <returns></returns>
        public int UpdateOtherAffE(decimal LSTR_SEQID, decimal satid, decimal schemeid, DateTime starttime, DateTime endtime, decimal IS_AFFECT)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE LHF.IMG_LAYOUT_TEMPTIMEWINDOW SET ");
            strSql.Append("IS_AFFECT=@in_IS_AFFECT,");
            strSql.Append("AFF_OCUSTR=AFF_OCUSTR +'@in_LSTR_SEQID,'");
            strSql.Append(" WHERE SCHEMEID=@in_SCHEMEID");
            strSql.Append(" AND IS_OCCUPY=0");
            strSql.Append(" AND SATID=@in_SATID");
            strSql.Append(" AND ENDTIME>@in_STARTTIME");
            strSql.Append(" AND ENDTIME<@in_ENDTIME");
            SqlParameter[] cmdParms = new SqlParameter[] {
				new SqlParameter("@in_IS_AFFECT", SqlDbType.Decimal),
                new SqlParameter("@in_LSTR_SEQID", SqlDbType.Decimal),
                new SqlParameter("@in_SCHEMEID", SqlDbType.Decimal),
                new SqlParameter("@in_SATID", SqlDbType.Decimal),
                new SqlParameter("@in_STARTTIME", SqlDbType.DateTime),
                new SqlParameter("@in_ENDTIME", SqlDbType.DateTime)};
            cmdParms[0].Value = IS_AFFECT;
            cmdParms[1].Value = LSTR_SEQID;
            cmdParms[2].Value = schemeid;
            cmdParms[3].Value = satid;
            cmdParms[4].Value = starttime;
            cmdParms[5].Value = endtime;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }
        /// <summary>
        /// 更新影响标识符,依据结束时间
        /// </summary>
        /// <param name="LSTR_SEQID"></param>
        /// <param name="IS_OCCUPY"></param>
        /// <returns></returns>
        public int UpdateOtherAff(decimal LSTR_SEQID, decimal satid, decimal schemeid, decimal circle, decimal IS_AFFECT)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE LHF.IMG_LAYOUT_TEMPTIMEWINDOW SET ");
            strSql.Append("IS_AFFECT=@in_IS_AFFECT,");
            strSql.Append("AFF_OCUSTR=AFF_OCUSTR +'@in_LSTR_SEQID,'");
            strSql.Append(" WHERE SCHEMEID=@in_SCHEMEID");
            strSql.Append(" AND IS_OCCUPY=0");
            strSql.Append(" AND SATID=@in_SATID");
            strSql.Append(" AND CIRCLE=@in_CIRCLE");
            SqlParameter[] cmdParms = new SqlParameter[] {
				new SqlParameter("@in_IS_AFFECT", SqlDbType.Decimal),
                new SqlParameter("@in_LSTR_SEQID", SqlDbType.Decimal),
                new SqlParameter("@in_SCHEMEID", SqlDbType.Decimal),
                new SqlParameter("@in_SATID", SqlDbType.Decimal),
                new SqlParameter("@in_CIRCLE", SqlDbType.Decimal)};
            cmdParms[0].Value = IS_AFFECT;
            cmdParms[1].Value = LSTR_SEQID;
            cmdParms[2].Value = schemeid;
            cmdParms[3].Value = satid;
            cmdParms[4].Value = circle;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }
        /// <summary>
        /// 根据LSTR_SEQID批量更新
        /// </summary>
        /// <param name="LSTR_SEQID"></param>
        /// <param name="AffrecordStr"></param>
        /// <returns></returns>
        public int UpdateByLSTR_SEQID(decimal LSTR_SEQID, string AffrecordStr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE LHF.IMG_LAYOUT_TEMPTIMEWINDOW SET ");
            strSql.Append("IS_AFFECT=1,IS_OCCUPY=0,");
            strSql.Append("AFF_OCUSTR=AFF_OCUSTR +'" + LSTR_SEQID + ",'");
            strSql.Append(" WHERE LSTR_SEQID IN (" + AffrecordStr + ")");
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 根据LSTR_SEQID获取卫星观测结果实体类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CoScheduling.Core.Model.ImgLayoutTempTimewindow GetModel(string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from LHF.IMG_LAYOUT_TEMPTIMEWINDOW ");
            strSql.Append(" where LSTR_SEQID=" + id);
            using (DbDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                CoScheduling.Core.Model.ImgLayoutTempTimewindow model = new CoScheduling.Core.Model.ImgLayoutTempTimewindow();
                if (dr.Read())
                {
                    model = GetModel(dr);
                }
                dr.Close();
                return model;
            }
        }

        /// <summary>
        /// 删除四个结果表的数据
        /// </summary>
        public void DeleteFour(string schemeid)
        {
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            StringBuilder strSql3 = new StringBuilder();
            strSql1.Append("delete from LHF.LAYOUT_SATELLITE_TIMEWINDOW");
            strSql1.Append(" where SCHEMEID=" + schemeid);
            strSql2.Append("delete from LHF.IMG_LAYOUT_TEMPTIMEWINDOW");
            strSql2.Append(" where SCHEMEID=" + schemeid);
            strSql3.Append("delete from LHF.IMG_LAYOUT_RESULT");
            strSql3.Append(" where SCHEMEID=" + schemeid);
            DbHelperSQL.ExecuteSql(strSql1.ToString());
            DbHelperSQL.ExecuteSql(strSql2.ToString());
            DbHelperSQL.ExecuteSql(strSql3.ToString());

            StringBuilder strSql4 = new StringBuilder();
            strSql4.Append("DELETE FROM SAT_RESAULT ");
            strSql4.Append(" WHERE SCHEMEID=" + schemeid);
            DbHelperSQL.ExecuteSql(strSql4.ToString());
        }
        /// <summary>
        /// 复制时间窗口LAYOUT_SATELLITE_TIMEWINDOW到临时表IMG_LAYOUT_TEMPTIMEWINDOW
        /// </summary>
        /// <param name="schemeid"></param>
        public void CopyFromLayoutSatelliteTimewindow(string schemeid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into LHF.IMG_LAYOUT_TEMPTIMEWINDOW(LSTR_SEQID,SATID,TASKID,SAT_STKNAME,SENSOR_ID,SENSOR_STKNAME,GSD,SANGLE,STARTTIME,ENDTIME,CIRCLE,TIMELONG,MAXSANGLE,MINSANGLE,IMAGEREGION,SCHEMEID) ");
            strSql.Append("SELECT TW_SEQID,SATID,TASKID,SAT_STKNAME,SENSORID,SENSOR_STKNAME,GSD,SANGLE,STARTTIME,ENDTIME,CIRCLE,TIMELONG,MAXSANGLE,MINSANGLE,IMAGEREGION,SCHEMEID FROM LHF.LAYOUT_SATELLITE_TIMEWINDOW ");
            strSql.Append("WHERE SCHEMEID=" + schemeid);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 删除不满足分辨率要求的记录
        /// </summary>
        /// <param name="schemeid"></param>
        /// <param name="taskid"></param>
        /// <param name="imgGSD"></param>
        public void DeleteByGSD(int schemeid, int taskid, decimal imgGSD)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM LHF.IMG_LAYOUT_TEMPTIMEWINDOW ");
            strSql.Append(" WHERE SCHEMEID=" + schemeid);
            strSql.Append(" AND TASKID=" + taskid);
            strSql.Append(" AND GSD>" + imgGSD);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 删除任务结束后的记录
        /// </summary>
        /// <param name="schemeid"></param>
        /// <param name="taskid"></param>
        /// <param name="endTime"></param>
        public void DeleteAfterEnd(int schemeid, int taskid, DateTime endTime)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM LHF.IMG_LAYOUT_TEMPTIMEWINDOW ");
            strSql.Append(" WHERE SCHEMEID=" + schemeid);
            strSql.Append(" AND TASKID=" + taskid);
            strSql.Append(" AND STARTTIME>'" + endTime.ToString("MM dd yyyy HH:mm:ss") + "'");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 删除任务开始前的记录
        /// </summary>
        /// <param name="schemeid"></param>
        /// <param name="taskid"></param>
        /// <param name="startTime"></param>
        public void DeleteBeforeStart(int schemeid, int taskid, DateTime startTime)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM LHF.IMG_LAYOUT_TEMPTIMEWINDOW ");
            strSql.Append(" WHERE SCHEMEID=" + schemeid);
            strSql.Append(" AND TASKID=" + taskid);
            strSql.Append(" AND ENDTIME<'" + startTime.ToString("MM dd yyyy HH:mm:ss") + "'");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 更新跨越任务开始时刻的时间窗口的起始时间
        /// </summary>
        /// <param name="schemeid"></param>
        /// <param name="taskid"></param>
        /// <param name="startTime"></param>
        public void UpdateBeforeStart(int schemeid, int taskid, DateTime startTime)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE LHF.IMG_LAYOUT_TEMPTIMEWINDOW ");
            strSql.Append(" SET STARTTIME = '" + startTime.ToString("MM/dd/yyyy HH:mm:ss") + "'");
            strSql.Append(" WHERE SCHEMEID=" + schemeid);
            strSql.Append(" AND TASKID=" + taskid);
            strSql.Append(" AND STARTTIME<'" + startTime.ToString("MM dd yyyy HH:mm:ss") + "'");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 更新跨越任务结束时刻的时间窗口的结束时间
        /// </summary>
        /// <param name="schemeid"></param>
        /// <param name="taskid"></param>
        /// <param name="endTime"></param>
        public void UpdateAfterEnd(int schemeid, int taskid, DateTime endTime)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE LHF.IMG_LAYOUT_TEMPTIMEWINDOW ");
            strSql.Append(" SET ENDTIME = '" + endTime.ToString("MM/dd/yyyy HH:mm:ss") + "'");
            strSql.Append(" WHERE SCHEMEID=" + schemeid);
            strSql.Append(" AND TASKID=" + taskid);
            strSql.Append(" AND ENDTIME>'" + endTime.ToString("MM dd yyyy HH:mm:ss") + "'");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * ");
            strSql.Append(" FROM  LHF.IMG_LAYOUT_TEMPTIMEWINDOW ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ORDER BY LSTR_SEQID");
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }

        /// <summary>
        /// 获取泛型数据列表
        /// </summary>
        public List<Model.ImgLayoutTempTimewindow> GetList()
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM LHF.IMG_LAYOUT_TEMPTIMEWINDOW");
            strSql.Append(" ORDER BY LSTR_SEQID");
            using (DbDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.ImgLayoutTempTimewindow> lst = GetList(dr);
                return lst;
            }
        }

        /// <summary>
        /// 根据条件获取泛型数据列表
        /// </summary>
        public List<Model.ImgLayoutTempTimewindow> GetListByCondition(string strWhere)
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM LHF.IMG_LAYOUT_TEMPTIMEWINDOW");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ORDER BY LSTR_SEQID");
            using (DbDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.ImgLayoutTempTimewindow> lst = GetList(dr);
                return lst;
            }
        }

        /// <summary>
        /// 根据SCHEMEID获取泛型数据列表
        /// </summary>
        public List<Model.ImgLayoutTempTimewindow> GetListBySchemeID(string strWhere)
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM LHF.IMG_LAYOUT_TEMPTIMEWINDOW");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE SCHEMEID=" + strWhere);
            }
            strSql.Append(" ORDER BY LSTR_SEQID");
            using (DbDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.ImgLayoutTempTimewindow> lst = GetList(dr);
                return lst;
            }
        }



        /// <summary>
        /// 根据TASKID获取泛型数据列表
        /// </summary>
        public List<Model.ImgLayoutTempTimewindow> GetListByTaskID(int taskid)
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM LHF.IMG_LAYOUT_TEMPTIMEWINDOW");
            strSql.Append(" WHERE TASKID=" + taskid);           
            strSql.Append(" ORDER BY STARTTIME");
            using (DbDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.ImgLayoutTempTimewindow> lst = GetList(dr);
                return lst;
            }
        }

        /// <summary>
        /// 根据TASKID获取指定条件下的泛型数据列表
        /// </summary>
        /// 
        public List<Model.ImgLayoutTempTimewindow> GetListByTaskID(int taskid, string strWhere)
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM LHF.IMG_LAYOUT_TEMPTIMEWINDOW");
            strSql.Append(" WHERE TASKID=" + taskid);
            strSql.Append(" AND " + strWhere);
            strSql.Append(" ORDER BY STARTTIME");
            using (DbDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.ImgLayoutTempTimewindow> lst = GetList(dr);
                return lst;
            }
        }
        public List<Model.ImgLayoutTempTimewindow> GetListByTaskID(int taskid,string strWhere,string order)
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM LHF.IMG_LAYOUT_TEMPTIMEWINDOW");
            strSql.Append(" WHERE TASKID=" + taskid);
            strSql.Append(" AND " + strWhere);
            strSql.Append(" ORDER BY "+order);
            using (DbDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.ImgLayoutTempTimewindow> lst = GetList(dr);
                return lst;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetListFull(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT a.sat_name,b.sensor_name,c.*,d.COVERAGE,d.ACCUCOVERAGE,e.TASKNAME ");
            strSql.Append(" FROM LHF.T_PUB_SATELLITE a,LHF.T_PUB_SENSOR b,LHF.IMG_LAYOUT_TEMPTIMEWINDOW c,SAT_RESAULT d,LHF.TASK_LAYOUT_LIST e ");
            if (strWhere.Trim() != "")
            {
                strSql.Append("WHERE c." + strWhere + " and a.sat_id= c.satid and b.sensor_id= c.sensor_id and c.LSTR_SEQID=d.LSTR_SEQID and c.taskid=e.taskid ");
            }
            strSql.Append(" ORDER BY taskid,starttime");
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
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
            strSql.Append(" FROM LHF.IMG_LAYOUT_TEMPTIMEWINDOW ");
            if (strWhere.Trim() != "")
            {
                strSql.Append("WHERE " + strWhere);
            }
            strSql.Append(" ORDER BY STARTTIME");
            DataSet dsTimeWindow = new DataSet();
            SqlDataAdapter odaTimeWindow = new SqlDataAdapter(strSql.ToString(), connectionString);
            if (dsTimeWindow.Tables["IMG_LAYOUT_TEMPTIMEWINDOW"] != null)
            {
                dsTimeWindow.Tables["IMG_LAYOUT_TEMPTIMEWINDOW"].Clear();
            }
            odaTimeWindow.Fill(dsTimeWindow, "IMG_LAYOUT_TEMPTIMEWINDOW");
            return dsTimeWindow;
        }

        /// <summary>
        /// 根据条件获取DataSet数据列表,包括卫星名和载荷名
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetListDataSetFull(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT a.sat_name,b.sensor_name,c.* ");
            strSql.Append(" FROM LHF.T_PUB_SATELLITE a,LHF.T_PUB_SENSOR b,LHF.IMG_LAYOUT_TEMPTIMEWINDOW c ");
            if (strWhere.Trim() != "")
            {
                strSql.Append("WHERE " + strWhere + "and a.sat_id= c.satid and b.sensor_id= c.sensor_id ");
            }
            strSql.Append(" ORDER BY starttime");
            DataSet dsTimeWindow = new DataSet();
            SqlDataAdapter odaTimeWindow = new SqlDataAdapter(strSql.ToString(), connectionString);
            if (dsTimeWindow.Tables["IMG_LAYOUT_TIMEWINDOW"] != null)
            {
                dsTimeWindow.Tables["IMG_LAYOUT_TIMEWINDOW"].Clear();
            }
            odaTimeWindow.Fill(dsTimeWindow, "IMG_LAYOUT_TIMEWINDOW");
            return dsTimeWindow;
        }

        /// <summary>
        /// 得到数据条数
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(*) ");
            strSql.Append(" FROM LHF.IMG_LAYOUT_TEMPTIMEWINDOW ");
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
        private Model.ImgLayoutTempTimewindow GetModel(DbDataReader dr)
        {
            Model.ImgLayoutTempTimewindow model = new Model.ImgLayoutTempTimewindow();
            model.LSTR_SEQID = Convert.ToDecimal(dr["LSTR_SEQID"]);
            model.SATID = Convert.ToDecimal(dr["SATID"]);
            model.TASKID = Convert.ToDecimal(dr["TASKID"]);
            model.SAT_STKNAME = Convert.ToString(dr["SAT_STKNAME"]);
            model.SENSOR_ID = Convert.ToDecimal(dr["SENSOR_ID"]);
            model.SENSOR_STKNAME = Convert.ToString(dr["SENSOR_STKNAME"]);
            try
            {
                model.PRIORITY = Convert.ToDecimal(dr["PRIORITY"]);
            }
            catch (System.Exception ex)
            {
                model.PRIORITY = 0;
            }            
            model.GSD = Convert.ToDecimal(dr["GSD"]);
            model.SANGLE = Convert.ToDecimal(dr["SANGLE"]);
            model.STARTTIME = Convert.ToDateTime(dr["STARTTIME"]);
            model.ENDTIME = Convert.ToDateTime(dr["ENDTIME"]);
            model.CIRCLE = Convert.ToDecimal(dr["CIRCLE"]);
            model.TIMELONG = Convert.ToDecimal(dr["TIMELONG"]);
            model.IS_AFFECT = Convert.ToDecimal(dr["IS_AFFECT"]);
            model.IS_OCCUPY = Convert.ToDecimal(dr["IS_OCCUPY"]);
            try
            {
                model.AFFECT_SEQID = Convert.ToDecimal(dr["AFFECT_SEQID"]);
            }
            catch (System.Exception ex)
            {
                model.AFFECT_SEQID = 0;
            }
            try
            {
                model.MAXSANGLE = Convert.ToDecimal(dr["MAXSANGLE"]);
            }
            catch (System.Exception ex)
            {
                model.MAXSANGLE = 0;
            }
            try
            {
                model.MINSANGLE = Convert.ToDecimal(dr["MINSANGLE"]);
            }
            catch (System.Exception ex)
            {
                model.MINSANGLE = 0;
            }
            
            model.IMAGEREGION = Convert.ToString(dr["IMAGEREGION"]);
            try
            {
                model.AFF_OCUSTR = Convert.ToString(dr["AFF_OCUSTR"]);
            }
            catch (System.Exception ex)
            {
                model.AFF_OCUSTR = "";
            }            
            model.SCHEMEID = Convert.ToDecimal(dr["SCHEMEID"]);
            return model;
        }

        /// <summary>
        /// 由DbDataReader得到泛型数据列表
        /// </summary>
        private List<Model.ImgLayoutTempTimewindow> GetList(DbDataReader dr)
        {
            List<Model.ImgLayoutTempTimewindow> lst = new List<Model.ImgLayoutTempTimewindow>();
            while (dr.Read())
            {
                lst.Add(GetModel(dr));
            }
            return lst;
        }

        #endregion
    }
}
