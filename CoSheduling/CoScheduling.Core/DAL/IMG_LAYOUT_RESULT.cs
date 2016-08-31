//------------------------------------------------------------------------------
// 创建标识: 董毅博
// 创建描述: 规划最终结果访问类
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
    public class IMG_LAYOUT_RESULT
    {
        public static string connectionString;
        public IMG_LAYOUT_RESULT()
        { connectionString = PubConstant.GetConnectionString(""); }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.IMG_LAYOUT_RESULT model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO LHF.IMG_LAYOUT_RESULT(");
            strSql.Append("MPPERIODID,TASKID,SUBTASKID,SATID,ZCSTARTTIME,ZCENDTIME,SLEWANGLE,DLTYPE,DLWINDOWID,COMPOSEDNUMBER,RESOLUTION,QUANTITY,SENSORID,GROUNDID,DOWNSTART,DOWNEND,TASK_TYPE,PRIORITY,IMAGEREGION,SIMTASK_STATE,IS_ABLE,DATACAP,SATSTKNAME,ISCONTINUEDSPY,TASKENDTIME,IF_SEND,LSTR_SEQID,PRECISION,TARGET_ID,SCHEMEID,TASKSTARTTIME,SENSORSTKNAME)");
            strSql.Append(" VALUES (");
            strSql.Append("@in_MPPERIODID,@in_TASKID,@in_SUBTASKID,@in_SATID,@in_ZCSTARTTIME,@in_ZCENDTIME,@in_SLEWANGLE,@in_DLTYPE,@in_DLWINDOWID,@in_COMPOSEDNUMBER,@in_RESOLUTION,@in_QUANTITY,@in_SENSORID,@in_GROUNDID,@in_DOWNSTART,@in_DOWNEND,@in_TASK_TYPE,@in_PRIORITY,@in_IMAGEREGION,@in_SIMTASK_STATE,@in_IS_ABLE,@in_DATACAP,@in_SATSTKNAME,@in_ISCONTINUEDSPY,@in_TASKENDTIME,@in_IF_SEND,@in_LSTR_SEQID,@in_PRECISION,@in_TARGET_ID,@in_SCHEMEID,@in_TASKSTARTTIME,@in_SENSORSTKNAME)");
            SqlParameter[] cmdParms = new SqlParameter[] {
				new SqlParameter("@in_MPPERIODID", SqlDbType.Decimal),
				new SqlParameter("@in_TASKID", SqlDbType.Decimal),
				new SqlParameter("@in_SUBTASKID", SqlDbType.NVarChar),
				new SqlParameter("@in_SATID", SqlDbType.Decimal),
				new SqlParameter("@in_ZCSTARTTIME", SqlDbType.DateTime),
				new SqlParameter("@in_ZCENDTIME", SqlDbType.DateTime),
				new SqlParameter("@in_SLEWANGLE", DbType.Double),
				new SqlParameter("@in_DLTYPE", SqlDbType.Decimal),
				new SqlParameter("@in_DLWINDOWID", SqlDbType.Decimal),
				new SqlParameter("@in_COMPOSEDNUMBER", SqlDbType.NVarChar),
				new SqlParameter("@in_RESOLUTION", DbType.Double),
				new SqlParameter("@in_QUANTITY", DbType.Double),
				new SqlParameter("@in_SENSORID", SqlDbType.Decimal),
				new SqlParameter("@in_GROUNDID", SqlDbType.NVarChar),
				new SqlParameter("@in_DOWNSTART", SqlDbType.DateTime),
				new SqlParameter("@in_DOWNEND", SqlDbType.DateTime),
				new SqlParameter("@in_TASK_TYPE", SqlDbType.Decimal),
				new SqlParameter("@in_PRIORITY", SqlDbType.Decimal),
				new SqlParameter("@in_IMAGEREGION", SqlDbType.NVarChar),
				new SqlParameter("@in_SIMTASK_STATE", SqlDbType.Decimal),
				new SqlParameter("@in_IS_ABLE", SqlDbType.Decimal),
				new SqlParameter("@in_DATACAP", SqlDbType.Decimal),
				new SqlParameter("@in_SATSTKNAME", SqlDbType.NVarChar),
				new SqlParameter("@in_ISCONTINUEDSPY", SqlDbType.Decimal),
				new SqlParameter("@in_TASKENDTIME", SqlDbType.DateTime),
				new SqlParameter("@in_IF_SEND", SqlDbType.Decimal),
				new SqlParameter("@in_LSTR_SEQID", SqlDbType.Decimal),
				new SqlParameter("@in_PRECISION", SqlDbType.Decimal),
				new SqlParameter("@in_TARGET_ID", SqlDbType.Decimal),
				new SqlParameter("@in_SCHEMEID", SqlDbType.Decimal),
				new SqlParameter("@in_TASKSTARTTIME", SqlDbType.DateTime),
                new SqlParameter("@in_SENSORSTKNAME", SqlDbType.NVarChar)};
            cmdParms[0].Value = model.MPPERIODID;
            cmdParms[1].Value = model.TASKID;
            cmdParms[2].Value = model.SUBTASKID;
            cmdParms[3].Value = model.SATID;
            cmdParms[4].Value = model.ZCSTARTTIME;
            cmdParms[5].Value = model.ZCENDTIME;
            cmdParms[6].Value = model.SLEWANGLE;
            cmdParms[7].Value = model.DLTYPE;
            cmdParms[8].Value = model.DLWINDOWID;
            cmdParms[9].Value = model.COMPOSEDNUMBER;
            cmdParms[10].Value = model.RESOLUTION;
            cmdParms[11].Value = model.QUANTITY;
            cmdParms[12].Value = model.SENSORID;
            cmdParms[13].Value = model.GROUNDID;
            cmdParms[14].Value = model.DOWNSTART;
            cmdParms[15].Value = model.DOWNEND;
            cmdParms[16].Value = model.TASK_TYPE;
            cmdParms[17].Value = model.PRIORITY;
            cmdParms[18].Value = model.IMAGEREGION;
            cmdParms[19].Value = model.SIMTASK_STATE;
            cmdParms[20].Value = model.IS_ABLE;
            cmdParms[21].Value = model.DATACAP;
            cmdParms[22].Value = model.SATSTKNAME;
            cmdParms[23].Value = model.ISCONTINUEDSPY;
            cmdParms[24].Value = model.TASKENDTIME;
            cmdParms[25].Value = model.IF_SEND;
            cmdParms[26].Value = model.LSTR_SEQID;
            cmdParms[27].Value = model.PRECISION;
            cmdParms[28].Value = model.TARGET_ID;
            cmdParms[29].Value = model.SCHEMEID;
            cmdParms[30].Value = model.TASKSTARTTIME;
            cmdParms[31].Value = model.SENSORSTKNAME;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Model.IMG_LAYOUT_RESULT model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE LHF.IMG_LAYOUT_RESULT SET ");
            strSql.Append("TASKID=@in_TASKID,");
            strSql.Append("SUBTASKID=@in_SUBTASKID,");
            strSql.Append("SATID=@in_SATID,");
            strSql.Append("ZCSTARTTIME=@in_ZCSTARTTIME,");
            strSql.Append("ZCENDTIME=@in_ZCENDTIME,");
            strSql.Append("SLEWANGLE=@in_SLEWANGLE,");
            strSql.Append("DLTYPE=@in_DLTYPE,");
            strSql.Append("DLWINDOWID=@in_DLWINDOWID,");
            strSql.Append("COMPOSEDNUMBER=@in_COMPOSEDNUMBER,");
            strSql.Append("RESOLUTION=@in_RESOLUTION,");
            strSql.Append("QUANTITY=@in_QUANTITY,");
            strSql.Append("SENSORID=@in_SENSORID,");
            strSql.Append("GROUNDID=@in_GROUNDID,");
            strSql.Append("DOWNSTART=@in_DOWNSTART,");
            strSql.Append("DOWNEND=@in_DOWNEND,");
            strSql.Append("TASK_TYPE=@in_TASK_TYPE,");
            strSql.Append("PRIORITY=@in_PRIORITY,");
            strSql.Append("IMAGEREGION=@in_IMAGEREGION,");
            strSql.Append("SIMTASK_STATE=@in_SIMTASK_STATE,");
            strSql.Append("IS_ABLE=@in_IS_ABLE,");
            strSql.Append("DATACAP=@in_DATACAP,");
            strSql.Append("SATSTKNAME=@in_SATSTKNAME,");
            strSql.Append("ISCONTINUEDSPY=@in_ISCONTINUEDSPY,");
            strSql.Append("TASKENDTIME=@in_TASKENDTIME,");
            strSql.Append("IF_SEND=@in_IF_SEND,");
            strSql.Append("MPPERIODID=@in_MPPERIODID,");
            strSql.Append("PRECISION=@in_PRECISION,");
            strSql.Append("TARGET_ID=@in_TARGET_ID,");
            strSql.Append("SCHEMEID=@in_SCHEMEID,");
            strSql.Append("TASKSTARTTIME=@in_TASKSTARTTIME");
            strSql.Append("SENSORSTKNAME=@in_SENSORSTKNAME");
            strSql.Append(" WHERE LSTR_SEQID=@in_LSTR_SEQID");
            SqlParameter[] cmdParms = new SqlParameter[] {
				new SqlParameter("@in_MPPERIODID", SqlDbType.Decimal),
				new SqlParameter("@in_TASKID", SqlDbType.Decimal),
				new SqlParameter("@in_SUBTASKID", SqlDbType.NVarChar),
				new SqlParameter("@in_SATID", SqlDbType.Decimal),
				new SqlParameter("@in_ZCSTARTTIME", SqlDbType.DateTime),
				new SqlParameter("@in_ZCENDTIME", SqlDbType.DateTime),
				new SqlParameter("@in_SLEWANGLE", DbType.Double),
				new SqlParameter("@in_DLTYPE", SqlDbType.Decimal),
				new SqlParameter("@in_DLWINDOWID", SqlDbType.Decimal),
				new SqlParameter("@in_COMPOSEDNUMBER", SqlDbType.NVarChar),
				new SqlParameter("@in_RESOLUTION", DbType.Double),
				new SqlParameter("@in_QUANTITY", DbType.Double),
				new SqlParameter("@in_SENSORID", SqlDbType.Decimal),
				new SqlParameter("@in_GROUNDID", SqlDbType.NVarChar),
				new SqlParameter("@in_DOWNSTART", SqlDbType.DateTime),
				new SqlParameter("@in_DOWNEND", SqlDbType.DateTime),
				new SqlParameter("@in_TASK_TYPE", SqlDbType.Decimal),
				new SqlParameter("@in_PRIORITY", SqlDbType.Decimal),
				new SqlParameter("@in_IMAGEREGION", SqlDbType.NVarChar),
				new SqlParameter("@in_SIMTASK_STATE", SqlDbType.Decimal),
				new SqlParameter("@in_IS_ABLE", SqlDbType.Decimal),
				new SqlParameter("@in_DATACAP", SqlDbType.Decimal),
				new SqlParameter("@in_SATSTKNAME", SqlDbType.NVarChar),
				new SqlParameter("@in_ISCONTINUEDSPY", SqlDbType.Decimal),
				new SqlParameter("@in_TASKENDTIME", SqlDbType.DateTime),
				new SqlParameter("@in_IF_SEND", SqlDbType.Decimal),
				new SqlParameter("@in_LSTR_SEQID", SqlDbType.Decimal),
				new SqlParameter("@in_PRECISION", SqlDbType.Decimal),
				new SqlParameter("@in_TARGET_ID", SqlDbType.Decimal),
				new SqlParameter("@in_SCHEMEID", SqlDbType.Decimal),
				new SqlParameter("@in_TASKSTARTTIME", SqlDbType.DateTime),
                new SqlParameter("@in_SENSORSTKNAME", SqlDbType.NVarChar)};
            cmdParms[0].Value = model.MPPERIODID;
            cmdParms[1].Value = model.TASKID;
            cmdParms[2].Value = model.SUBTASKID;
            cmdParms[3].Value = model.SATID;
            cmdParms[4].Value = model.ZCSTARTTIME;
            cmdParms[5].Value = model.ZCENDTIME;
            cmdParms[6].Value = model.SLEWANGLE;
            cmdParms[7].Value = model.DLTYPE;
            cmdParms[8].Value = model.DLWINDOWID;
            cmdParms[9].Value = model.COMPOSEDNUMBER;
            cmdParms[10].Value = model.RESOLUTION;
            cmdParms[11].Value = model.QUANTITY;
            cmdParms[12].Value = model.SENSORID;
            cmdParms[13].Value = model.GROUNDID;
            cmdParms[14].Value = model.DOWNSTART;
            cmdParms[15].Value = model.DOWNEND;
            cmdParms[16].Value = model.TASK_TYPE;
            cmdParms[17].Value = model.PRIORITY;
            cmdParms[18].Value = model.IMAGEREGION;
            cmdParms[19].Value = model.SIMTASK_STATE;
            cmdParms[20].Value = model.IS_ABLE;
            cmdParms[21].Value = model.DATACAP;
            cmdParms[22].Value = model.SATSTKNAME;
            cmdParms[23].Value = model.ISCONTINUEDSPY;
            cmdParms[24].Value = model.TASKENDTIME;
            cmdParms[25].Value = model.IF_SEND;
            cmdParms[26].Value = model.LSTR_SEQID;
            cmdParms[27].Value = model.PRECISION;
            cmdParms[28].Value = model.TARGET_ID;
            cmdParms[29].Value = model.SCHEMEID;
            cmdParms[30].Value = model.TASKSTARTTIME;
            cmdParms[31].Value = model.SENSORSTKNAME;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int LSTR_SEQID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM LHF.IMG_LAYOUT_RESULT ");
            strSql.Append(" WHERE LSTR_SEQID=" + LSTR_SEQID);

            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 根据条件删除数据
        /// </summary>
        public int DeleteByCondition(string condition)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM LHF.IMG_LAYOUT_RESULT ");
            strSql.Append(" WHERE " + condition);

            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int LSTR_SEQID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM LHF.IMG_LAYOUT_RESULT");
            strSql.Append(" WHERE LSTR_SEQID=" + LSTR_SEQID);
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.IMG_LAYOUT_RESULT GetModel(int LSTR_SEQID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM LHF.IMG_LAYOUT_RESULT ");
            strSql.Append(" WHERE LSTR_SEQID=" + LSTR_SEQID);
            Model.IMG_LAYOUT_RESULT model = null;
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
        public List<Model.IMG_LAYOUT_RESULT> GetList()
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM LHF.IMG_LAYOUT_RESULT");
            using (DbDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.IMG_LAYOUT_RESULT> lst = GetList(dr);
                return lst;
            }
        }


        /// <summary>
        /// 获取泛型数据列表
        /// </summary>
        public List<Model.IMG_LAYOUT_RESULT> GetList(string condition)
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM LHF.IMG_LAYOUT_RESULT");
            if (condition.Trim() != "")
            {
                strSql.Append(" WHERE " + condition);
            }
            strSql.Append(" ORDER BY TASKID,ZCSTARTTIME");
            using (DbDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.IMG_LAYOUT_RESULT> lst = GetList(dr);
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
            strSql.Append(" FROM LHF.IMG_LAYOUT_RESULT ");
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
        private Model.IMG_LAYOUT_RESULT GetModel(DbDataReader dr)
        {
            Model.IMG_LAYOUT_RESULT model = new Model.IMG_LAYOUT_RESULT();
            model.MPPERIODID = Convert.ToDecimal(dr["MPPERIODID"]);
            model.TASKID = Convert.ToDecimal(dr["TASKID"]);
            model.SUBTASKID = Convert.ToString(dr["SUBTASKID"]);
            model.SATID = Convert.ToDecimal(dr["SATID"]);
            model.ZCSTARTTIME = Convert.ToDateTime(dr["ZCSTARTTIME"]);
            model.ZCENDTIME = Convert.ToDateTime(dr["ZCENDTIME"]);
            model.SLEWANGLE = Convert.ToDouble(dr["SLEWANGLE"]);
            try
            {
                model.DLTYPE = Convert.ToDecimal(dr["DLTYPE"]);
            }
            catch (System.Exception ex)
            {
                model.DLTYPE = 0;
            }
            try
            {
                model.DLWINDOWID = Convert.ToDecimal(dr["DLWINDOWID"]);
            }
            catch (System.Exception ex)
            {
                model.DLWINDOWID = 0;
            }           
            model.COMPOSEDNUMBER = Convert.ToString(dr["COMPOSEDNUMBER"]);
            model.RESOLUTION = Convert.ToDouble(dr["RESOLUTION"]);
            model.QUANTITY = Convert.ToDouble(dr["QUANTITY"]);
            model.SENSORID = Convert.ToDecimal(dr["SENSORID"]);
            model.GROUNDID = Convert.ToString(dr["GROUNDID"]);
            model.DOWNSTART = Convert.ToDateTime(dr["DOWNSTART"]);
            model.DOWNEND = Convert.ToDateTime(dr["DOWNEND"]);
            model.TASK_TYPE = Convert.ToDecimal(dr["TASK_TYPE"]);
            model.PRIORITY = Convert.ToDecimal(dr["PRIORITY"]);
            model.IMAGEREGION = Convert.ToString(dr["IMAGEREGION"]);
            model.SIMTASK_STATE = Convert.ToDecimal(dr["SIMTASK_STATE"]);
            model.IS_ABLE = Convert.ToDecimal(dr["IS_ABLE"]);
            model.DATACAP = Convert.ToDecimal(dr["DATACAP"]);
            model.SATSTKNAME = Convert.ToString(dr["SATSTKNAME"]);
            model.ISCONTINUEDSPY = Convert.ToDecimal(dr["ISCONTINUEDSPY"]);
            model.TASKENDTIME = Convert.ToDateTime(dr["TASKENDTIME"]);
            model.IF_SEND = Convert.ToDecimal(dr["IF_SEND"]);
            model.LSTR_SEQID = Convert.ToDecimal(dr["LSTR_SEQID"]);
            model.PRECISION = Convert.ToDecimal(dr["PRECISION"]);
            model.TARGET_ID = Convert.ToDecimal(dr["TARGET_ID"]);
            model.SCHEMEID = Convert.ToDecimal(dr["SCHEMEID"]);
            model.TASKSTARTTIME = Convert.ToDateTime(dr["TASKSTARTTIME"]);
            model.SENSORSTKNAME = Convert.ToString(dr["SENSORSTKNAME"]);
            return model;
        }

        /// <summary>
        /// 由DbDataReader得到泛型数据列表
        /// </summary>
        private List<Model.IMG_LAYOUT_RESULT> GetList(DbDataReader dr)
        {
            List<Model.IMG_LAYOUT_RESULT> lst = new List<Model.IMG_LAYOUT_RESULT>();
            while (dr.Read())
            {
                lst.Add(GetModel(dr));
            }
            return lst;
        }

        #endregion
    }
}
