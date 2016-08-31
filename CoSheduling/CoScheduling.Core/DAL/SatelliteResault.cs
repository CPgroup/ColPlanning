//------------------------------------------------------------------------------
// 创建标识: 董毅博
// 创建描述: 观测结果访问类
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
    public class SatelliteResault
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.SatelliteResault model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO SAT_RESAULT(");
            strSql.Append("LSTR_SEQID,SCHEMEID,TASKID,PID,POLYGONSTRING,STARTTIME,ENDTIME,COVERAGE,ACCUCOVERAGE)");
            strSql.Append(" VALUES (");
            strSql.Append("@in_LSTR_SEQID,@in_SCHEMEID,@in_TASKID,@in_PID,@in_POLYGONSTRING,@in_STARTTIME,@in_ENDTIME,@in_COVERAGE,@in_ACCUCOVERAGE)");
            SqlParameter[] cmdParms = new SqlParameter[]{
				new SqlParameter("@in_LSTR_SEQID", SqlDbType.Int),
				new SqlParameter("@in_SCHEMEID", SqlDbType.Int),
				new SqlParameter("@in_TASKID", SqlDbType.Int),
				new SqlParameter("@in_PID", SqlDbType.Int),
				new SqlParameter("@in_POLYGONSTRING", SqlDbType.NVarChar),
                new SqlParameter("@in_STARTTIME", SqlDbType.DateTime),
                new SqlParameter("@in_ENDTIME", SqlDbType.DateTime),
                new SqlParameter("@in_COVERAGE", SqlDbType.Decimal),
                new SqlParameter("@in_ACCUCOVERAGE", SqlDbType.Decimal)};
            cmdParms[0].Value = model.LSTR_SEQID;
            cmdParms[1].Value = model.SCHEMEID;
            cmdParms[2].Value = model.TASKID;
            cmdParms[3].Value = model.PID;
            cmdParms[4].Value = model.POLYGONSTRING;
            cmdParms[5].Value = model.STARTTIME;
            cmdParms[6].Value = model.ENDTIME;
            cmdParms[7].Value = model.COVERAGE;
            cmdParms[8].Value = model.ACCUCOVERAGE;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Model.SatelliteResault model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE SAT_RESAULT SET ");
            strSql.Append("SCHEMEID=@in_SCHEMEID,");
            strSql.Append("TASKID=@in_TASKID,");
            strSql.Append("PID=@in_PID,");
            strSql.Append("POLYGONSTRING=@in_POLYGONSTRING,");
            strSql.Append("STARTTIME=@in_STARTTIME,");
            strSql.Append("ENDTIME=@in_ENDTIME,");
            strSql.Append("COVERAGE=@in_COVERAGE,");
            strSql.Append("ACCUCOVERAGE=@in_ACCUCOVERAGE");
            strSql.Append(" WHERE LSTR_SEQID=@in_LSTR_SEQID");
            SqlParameter[] cmdParms = new SqlParameter[]{
				new SqlParameter("@in_LSTR_SEQID", SqlDbType.Int),
				new SqlParameter("@in_SCHEMEID", SqlDbType.Int),
				new SqlParameter("@in_TASKID", SqlDbType.Int),
				new SqlParameter("@in_PID", SqlDbType.Int),
				new SqlParameter("@in_POLYGONSTRING", SqlDbType.NVarChar),
                new SqlParameter("@in_STARTTIME", SqlDbType.DateTime),
                new SqlParameter("@in_ENDTIME", SqlDbType.DateTime),
                new SqlParameter("@in_COVERAGE", SqlDbType.Decimal),
                new SqlParameter("@in_ACCUCOVERAGE", SqlDbType.Decimal)};
            cmdParms[0].Value = model.LSTR_SEQID;
            cmdParms[1].Value = model.SCHEMEID;
            cmdParms[2].Value = model.TASKID;
            cmdParms[3].Value = model.PID;
            cmdParms[4].Value = model.POLYGONSTRING;
            cmdParms[5].Value = model.STARTTIME;
            cmdParms[6].Value = model.ENDTIME;
            cmdParms[7].Value = model.COVERAGE;
            cmdParms[8].Value = model.ACCUCOVERAGE;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int LSTR_SEQID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM SAT_RESAULT ");
            strSql.Append(" WHERE LSTR_SEQID=@in_LSTR_SEQID");
            SqlParameter[] cmdParms = {
				new SqlParameter("@in_LSTR_SEQID", SqlDbType.Int, LSTR_SEQID)};

            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }
        /// <summary>
        /// 根据SCHEMEID删除数据
        /// </summary>
        public int DeleteBySchemeID(int SCHEMEID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM SAT_RESAULT ");
            strSql.Append(" WHERE SCHEMEID=" + SCHEMEID);
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Refresh(int SCHEMEID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE SAT_RESAULT ");
            strSql.Append(" SET ACCUCOVERAGE=NULL");
            
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        ///// <summary>
        ///// 得到最大ID
        ///// </summary>
        //public int GetMaxId()
        //{
        //    return DbHelperSQL.GetMaxID("LSTR_SEQID");
        //}

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int LSTR_SEQID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM SAT_RESAULT");
            strSql.Append(" WHERE LSTR_SEQID=@in_LSTR_SEQID");
            SqlParameter[] cmdParms = {
				new SqlParameter("@in_LSTR_SEQID", SqlDbType.Int, LSTR_SEQID)};
            return DbHelperSQL.Exists(strSql.ToString());
        }
        /// <summary>
        /// 是否存在观测结果
        /// </summary>
        public bool ExistsResault(int SCHEME_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM SAT_RESAULT");
            strSql.Append(" WHERE SCHEMEID=" + SCHEME_ID.ToString());
            SqlParameter[] cmdParms = {
				new SqlParameter("@in_SCHEME_ID", SqlDbType.Int, SCHEME_ID)};
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.SatelliteResault GetModel(int LSTR_SEQID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM SAT_RESAULT ");
            strSql.Append(" WHERE LSTR_SEQID="+LSTR_SEQID.ToString());
            Model.SatelliteResault model = null;
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
        /// 根据taskid获得所属的schemeid
        /// </summary>
        /// <param name="taskid"></param>
        /// <returns></returns>
        public int getSchemeidByTaskid(int taskid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TOP 1 SCHEMEID FROM SAT_RESAULT ");
            strSql.Append(" WHERE TASKID=" + taskid);
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return int.Parse(obj.ToString());
            };
        }
        /// <summary>
        /// 根据lstr_seqid获得所属的schemeid
        /// </summary>
        /// <param name="lstr_seqid"></param>
        /// <returns></returns>
        public int getSchemeidByLstrseqid(int lstr_seqid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TOP 1 SCHEMEID FROM SAT_RESAULT ");
            strSql.Append(" WHERE LSTR_SEQID=" + lstr_seqid);
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return int.Parse(obj.ToString());
            };
        }

        /// <summary>
        /// 得到数据条数
        /// </summary>
        public int GetCount(string condition)
        {
            return DbHelperSQL.GetCount("SAT_RESAULT", condition);
        }

        /// <summary>
        /// 分页获取泛型数据列表
        /// </summary>
        public List<Model.SatelliteResault> GetPageList(int pageSize, int pageIndex, string WhereClause)
        {
            string strSql = "SELECT TOP " + pageSize.ToString() + " * " +
                             "    FROM " +
                                        " ( " +
                                        " SELECT ROW_NUMBER() OVER (ORDER BY BH) AS RowNumber,* FROM SAT_RESAULT "
                                             + (!string.IsNullOrEmpty(WhereClause) ? " where " + WhereClause : "") +
                                         ") A " +
                                 "WHERE RowNumber > " + pageSize.ToString() + "*(" + pageIndex.ToString() + "-1)  ";
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString(), null))
            {
                List<Model.SatelliteResault> lst = GetList(dr);
                return lst;
            }
        }

        #region -------- 与其他实体类的操作 --------
        /// <summary>
        /// 获取泛型数据列表
        /// </summary>
        public List<Model.SatelliteResault> GetList()
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM SAT_RESAULT ");
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.SatelliteResault> lst = GetList(dr);
                return lst;
            }
        }

        public List<Model.SatelliteResault> GetList(string where)
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM SAT_RESAULT ");
            strSql.Append("WHERE "+where);
            strSql.Append(" order by taskid,starttime");
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.SatelliteResault> lst = GetList(dr);
                return lst;
            }
        }
        /// <summary>
        /// 根据TASKID获取泛型数据列表
        /// </summary>
        public List<Model.SatelliteResault> GetListByTaskID(int id)
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM SAT_RESAULT ");
            strSql.Append(" WHERE TASKID=" + id.ToString());
            strSql.Append(" ORDER BY LSTR_SEQID");
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.SatelliteResault> lst = GetList(dr);
                return lst;
            }
        }
        public List<Model.SatelliteResault> GetListByTaskID(int id, DateTime begin, DateTime end)
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM SAT_RESAULT ");
            strSql.Append(" WHERE TASKID="+id.ToString());
            strSql.Append(" AND STARTTIME>='" + begin + "'");
            strSql.Append(" AND ENDTIME<='" + end + "'");
            strSql.Append(" ORDER BY LSTR_SEQID");
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.SatelliteResault> lst = GetList(dr);
                return lst;
            }
        }
        public List<Model.SatelliteResault> GetListByTaskIDTime(int id)
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM SAT_RESAULT ");
            strSql.Append(" WHERE TASKID=" + id.ToString());
            strSql.Append(" ORDER BY STARTTIME");
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.SatelliteResault> lst = GetList(dr);
                return lst;
            }
        }

        /// <summary>
        /// 根据SCHEMEID获取泛型数据列表
        /// </summary>
        public List<Model.SatelliteResault> GetListBySchemeID(int id)
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM SAT_RESAULT ");
            strSql.Append(" WHERE SCHEMEID=" + id.ToString());
            strSql.Append(" ORDER BY LSTR_SEQID");
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.SatelliteResault> lst = GetList(dr);
                return lst;
            }
        }
        public List<Model.SatelliteResault> GetListBySchemeID(int id,DateTime begin,DateTime end)
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM SAT_RESAULT ");
            strSql.Append(" WHERE SCHEMEID=" + id.ToString());
            strSql.Append(" AND STARTTIME>='" + begin + "'");
            strSql.Append(" AND ENDTIME<='" + end + "'");
            strSql.Append(" ORDER BY LSTR_SEQID");
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.SatelliteResault> lst = GetList(dr);
                return lst;
            }
        }

        
        #endregion

        #region -------- 私有方法，通常情况下无需修改 --------

        /// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        private Model.SatelliteResault GetModel(DbDataReader dr)
        {
            Model.SatelliteResault model = new Model.SatelliteResault();
            model.LSTR_SEQID = DbHelperSQL.GetInt(dr["LSTR_SEQID"]);
            model.SCHEMEID = DbHelperSQL.GetInt(dr["SCHEMEID"]);
            model.TASKID = DbHelperSQL.GetInt(dr["TASKID"]);
            model.PID = DbHelperSQL.GetInt(dr["PID"]);
            model.POLYGONSTRING = DbHelperSQL.GetString(dr["POLYGONSTRING"]);
            model.STARTTIME = Convert.ToDateTime(dr["STARTTIME"]);
            model.ENDTIME = Convert.ToDateTime(dr["ENDTIME"]);
            try
            {
                model.COVERAGE = Convert.ToDecimal(dr["COVERAGE"]);
            }
            catch (System.Exception ex)
            {
                model.COVERAGE = 0;
            }
            try
            {
                model.ACCUCOVERAGE = Convert.ToDecimal(dr["ACCUCOVERAGE"]);
            }
            catch (System.Exception ex)
            {
                model.ACCUCOVERAGE = 0;
            }
            return model;
        }

        /// <summary>
        /// 由DbDataReader得到泛型数据列表
        /// </summary>
        private List<Model.SatelliteResault> GetList(DbDataReader dr)
        {
            List<Model.SatelliteResault> lst = new List<Model.SatelliteResault>();
            while (dr.Read())
            {
                lst.Add(GetModel(dr));
            }
            return lst;
        }

        #endregion
    }
}
