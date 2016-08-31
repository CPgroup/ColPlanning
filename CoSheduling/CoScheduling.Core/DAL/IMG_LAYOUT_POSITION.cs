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
    public class IMG_LAYOUT_POSITION
    {
        public static string connectionString;
        public IMG_LAYOUT_POSITION()
        { connectionString = PubConstant.GetConnectionString(""); }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.IMG_LAYOUT_POSITION model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO IMG_LAYOUT_POSITION(");
            strSql.Append("LSTR_SEQID,SCHEMEID,TASKID,SAT_ID,SAT_STKNAME,TIME,LON,LAT,ALTITUDE,IMAGENATION)");
            strSql.Append(" VALUES (");
            strSql.Append("@in_LSTR_SEQID,@in_SCHEMEID,@in_TASKID,@in_SAT_ID,@in_SAT_STKNAME,@in_TIME,@in_LON,@in_LAT,@in_ALTITUDE,@in_IMAGENATION)");
            SqlParameter[] cmdParms = new SqlParameter[] {
				new SqlParameter("@in_LSTR_SEQID", SqlDbType.Decimal),
				new SqlParameter("@in_SCHEMEID", SqlDbType.Decimal),
				new SqlParameter("@in_TASKID", SqlDbType.Decimal),
				new SqlParameter("@in_SAT_ID", SqlDbType.Decimal),
				new SqlParameter("@in_SAT_STKNAME", SqlDbType.NVarChar),
				new SqlParameter("@in_TIME", SqlDbType.DateTime),
				new SqlParameter("@in_LON", SqlDbType.Decimal),
				new SqlParameter("@in_LAT", SqlDbType.Decimal),
				new SqlParameter("@in_ALTITUDE", SqlDbType.Decimal),
                new SqlParameter("@in_IMAGENATION", SqlDbType.NVarChar)};
            cmdParms[0].Value = model.LSTR_SEQID;
            cmdParms[1].Value = model.SCHEMEID;
            cmdParms[2].Value = model.TASKID;
            cmdParms[3].Value = model.SAT_ID;
            cmdParms[4].Value = model.SAT_STKNAME;
            cmdParms[5].Value = model.TIME;
            cmdParms[6].Value = model.LON;
            cmdParms[7].Value = model.LAT;
            cmdParms[8].Value = model.ALTITUDE;
            cmdParms[9].Value = model.IMAGENATION;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Model.IMG_LAYOUT_POSITION model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE IMG_LAYOUT_POSITION SET ");
            strSql.Append("LSTR_SEQID=@in_LSTR_SEQID,");
            strSql.Append("SCHEMEID=@in_SCHEMEID,");
            strSql.Append("TASKID=@in_TASKID,");
            strSql.Append("SAT_ID=@in_SAT_ID,");
            strSql.Append("SAT_STKNAME=@in_SAT_STKNAME,");
            strSql.Append("TIME=@in_TIME,");
            strSql.Append("LON=@in_LON,");
            strSql.Append("LAT=@in_LAT,");
            strSql.Append("ALTITUDE=@in_ALTITUDE,");
            strSql.Append("IMAGENATION=@in_IMAGENATION");
            strSql.Append(" WHERE POSITIONID=@in_POSITIONID");
            SqlParameter[] cmdParms = new SqlParameter[] {
				new SqlParameter("@in_LSTR_SEQID", SqlDbType.Decimal),
				new SqlParameter("@in_SCHEMEID", SqlDbType.Decimal),
				new SqlParameter("@in_TASKID", SqlDbType.Decimal),
				new SqlParameter("@in_SAT_ID", SqlDbType.Decimal),
				new SqlParameter("@in_SAT_STKNAME", SqlDbType.NVarChar),
				new SqlParameter("@in_TIME", SqlDbType.DateTime),
				new SqlParameter("@in_LON", SqlDbType.Decimal),
				new SqlParameter("@in_LAT", SqlDbType.Decimal),
				new SqlParameter("@in_ALTITUDE", SqlDbType.Decimal),
                new SqlParameter("@in_ALTITUDE", SqlDbType.Decimal),
                new SqlParameter("@in_IMAGENATION", SqlDbType.NVarChar)};
            cmdParms[0].Value = model.LSTR_SEQID;
            cmdParms[1].Value = model.SCHEMEID;
            cmdParms[2].Value = model.TASKID;
            cmdParms[3].Value = model.SAT_ID;
            cmdParms[4].Value = model.SAT_STKNAME;
            cmdParms[5].Value = model.TIME;
            cmdParms[6].Value = model.LON;
            cmdParms[7].Value = model.LAT;
            cmdParms[8].Value = model.ALTITUDE;
            cmdParms[8].Value = model.POSITIONID;
            cmdParms[9].Value = model.IMAGENATION;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 根据LSTR_SEQID得到数据
        /// </summary>
        public List<Model.IMG_LAYOUT_POSITION> GetAniData(decimal LSTR_SEQID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM IMG_LAYOUT_POSITION ");
            strSql.Append(" WHERE LSTR_SEQID="+LSTR_SEQID);
            strSql.Append(" ORDER BY POSITIONID");
            //SqlParameter[] cmdParms = new SqlParameter[] {
            //    new SqlParameter("@in_SEQID", SqlDbType.Decimal)};
            //cmdParms[0].Value = LSTR_SEQID;
            using (DbDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.IMG_LAYOUT_POSITION> lst = GetList(dr);
                return lst;
            }
        }

        public List<Model.IMG_LAYOUT_POSITION> GetAniDataByTime(DateTime currentTime,int scheme_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM IMG_LAYOUT_POSITION ");
            strSql.Append(" WHERE TIME >='"+currentTime+"'");
            strSql.Append(" AND SCHEMEID =" + scheme_id);
            strSql.Append(" ORDER BY TIME");
            //SqlParameter[] cmdParms = new SqlParameter[] {
            //    new SqlParameter("@currentTime",SqlDbType.DateTime)};
            //cmdParms[0].Value = currentTime;
            using (DbDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.IMG_LAYOUT_POSITION> lst = GetList(dr);
                return lst;
            }
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(decimal POSITIONID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM IMG_LAYOUT_POSITION ");
            strSql.Append(" WHERE POSITIONID=@in_POSITIONID");
            SqlParameter[] cmdParms = new SqlParameter[] {
				new SqlParameter("@in_POSITIONID", SqlDbType.Decimal)};
            cmdParms[0].Value = POSITIONID;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        public int DeleteBySchemeid(decimal scheme_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM IMG_LAYOUT_POSITION ");
            strSql.Append(" WHERE SCHEMEID="+scheme_id);
            //SqlParameter[] cmdParms = new SqlParameter[] {
            //    new SqlParameter("@in_SCHEMEID", SqlDbType.Decimal)};
            //cmdParms[0].Value = scheme_id;
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(decimal POSITIONID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM IMG_LAYOUT_POSITION");
            strSql.Append(" WHERE POSITIONID=" + POSITIONID);
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.IMG_LAYOUT_POSITION GetModel(decimal POSITIONID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM IMG_LAYOUT_POSITION ");
            strSql.Append(" WHERE POSITIONID=" + POSITIONID);
            //SqlParameter[] cmdParms = new SqlParameter[] {
            //    new SqlParameter("@in_POSITIONID", SqlDbType.Decimal)};
            //cmdParms[0].Value = POSITIONID;
            Model.IMG_LAYOUT_POSITION model = null;
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
        public List<Model.IMG_LAYOUT_POSITION> GetList()
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM IMG_LAYOUT_POSITION");
            using (DbDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.IMG_LAYOUT_POSITION> lst = GetList(dr);
                return lst;
            }
        }

        /// <summary>
        /// 得到数据条数
        /// </summary>
        public int GetCount(string condition)
        {
            return DbHelperSQL.GetCount("IMG_LAYOUT_POSITION", condition);
        }


        #region -------- 私有方法，通常情况下无需修改 --------

        /// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        private Model.IMG_LAYOUT_POSITION GetModel(DbDataReader dr)
        {
            Model.IMG_LAYOUT_POSITION model = new Model.IMG_LAYOUT_POSITION();
            model.POSITIONID = Convert.ToDecimal(dr["POSITIONID"]);
            model.LSTR_SEQID = Convert.ToDecimal(dr["LSTR_SEQID"]);
            model.SCHEMEID = Convert.ToDecimal(dr["SCHEMEID"]);
            model.TASKID = Convert.ToDecimal(dr["TASKID"]);
            model.SAT_ID = Convert.ToDecimal(dr["SAT_ID"]);
            model.SAT_STKNAME =  Convert.ToString(dr["SAT_STKNAME"]);
            model.TIME = Convert.ToDateTime(dr["TIME"]);
            model.LON = Convert.ToDecimal(dr["LON"]);
            model.LAT = Convert.ToDecimal(dr["LAT"]);
            model.ALTITUDE = Convert.ToDecimal(dr["ALTITUDE"]);
            model.IMAGENATION = Convert.ToString(dr["IMAGENATION"]);
            return model;
        }

        /// <summary>
        /// 由DbDataReader得到泛型数据列表
        /// </summary>
        private List<Model.IMG_LAYOUT_POSITION> GetList(DbDataReader dr)
        {
            List<Model.IMG_LAYOUT_POSITION> lst = new List<Model.IMG_LAYOUT_POSITION>();
            while (dr.Read())
            {
                lst.Add(GetModel(dr));
            }
            return lst;
        }

        #endregion
    }
}
