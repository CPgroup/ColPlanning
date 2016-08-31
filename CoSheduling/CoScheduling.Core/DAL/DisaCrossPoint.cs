//------------------------------------------------------------------------------
// 创建标识: 尹健
// 创建描述: 灾区交点数据访问类
// 创建时间:2013.12.9
// 文件版本:1.0
// 功能描述: 
// 修改标识: 
// 修改描述: 
//------------------------------------------------------------------------------

using System;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using CoScheduling.Core.DBUtility;

namespace CoScheduling.Core.DAL
{

    /// <summary>
    /// 数据访问类 DisaCrossPoint
    /// </summary>
    public class DisaCrossPoint
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.DisaCrossPoint model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO DisaCrossPoint(");
            strSql.Append("PID,PName,LAT,LON)");
            strSql.Append(" VALUES (");
            strSql.Append("@in_PID,@in_PName,@in_LAT,@in_LON)");
            SqlParameter[] cmdParms = new SqlParameter[]{
                new SqlParameter("@in_PID", SqlDbType.Int),
				new SqlParameter("@in_PName", SqlDbType.NVarChar),
				new SqlParameter("@in_LAT", SqlDbType.Decimal),
				new SqlParameter("@in_LON", SqlDbType.Decimal)};

            cmdParms[0].Value = model.PID;
            cmdParms[1].Value = model.PName;
            cmdParms[2].Value = model.LAT;
            cmdParms[3].Value = model.LON;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Model.DisaCrossPoint model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE DisaCrossPoint SET ");
            strSql.Append("PID=@in_PID,");
            strSql.Append("PName=@in_PName,");
            strSql.Append("LAT=@in_LAT,");
            strSql.Append("LON=@in_LON");
            strSql.Append(" WHERE ID=@in_ID");
            SqlParameter[] cmdParms = new SqlParameter[]{
                new SqlParameter("@in_PID", SqlDbType.Int),
				new SqlParameter("@in_PName", SqlDbType.NVarChar),
				new SqlParameter("@in_LAT", SqlDbType.Decimal),
				new SqlParameter("@in_LON", SqlDbType.Decimal),
				new SqlParameter("@in_ID", SqlDbType.Int)};

            cmdParms[0].Value = model.PID;
            cmdParms[1].Value = model.PName;
            cmdParms[2].Value = model.LAT;
            cmdParms[3].Value = model.LON;
            cmdParms[4].Value = model.ID;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM DisaCrossPoint ");
            strSql.Append(" WHERE ID=@in_ID");
            SqlParameter[] cmdParms = {
				new SqlParameter("@in_ID",System.Data.SqlDbType.Int, ID)};
            cmdParms[0].Value = ID;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 根据灾区ID删除数据
        /// </summary>
        public int Deletes(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM DisaCrossPoint ");
            strSql.Append(" WHERE PID=@in_ID");
            SqlParameter[] cmdParms = {
				new SqlParameter("@in_ID",System.Data.SqlDbType.Int, ID)};
            cmdParms[0].Value = ID;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("DisaCrossPoint");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM DisaCrossPoint");
            strSql.Append(" WHERE ID=" + ID.ToString());
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 判断是否已经生成过交点
        /// </summary>
        public bool Exist(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM DisaCrossPoint");
            strSql.Append(" WHERE PID=" + ID.ToString());
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.DisaCrossPoint GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM DisaCrossPoint ");
            strSql.Append(" WHERE ID=" + ID.ToString());
            Model.DisaCrossPoint model = null;
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
        /// 获取泛型数据列表
        /// </summary>
        public List<Model.DisaCrossPoint> GetList()
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM DisaCrossPoint");
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.DisaCrossPoint> lst = GetList(dr);
                return lst;
            }
        }

        /// <summary>
        /// 获取泛型数据列表通过任务区ID获取
        /// </summary>
        public List<Model.DisaCrossPoint> GetList(int PID)
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM DisaCrossPoint where PID=" + PID);
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.DisaCrossPoint> lst = GetList(dr);
                return lst;
            }
        }

        /// <summary>
        /// 获取泛型数据列表 通过灾区ID与任务区ID获取
        /// </summary>
        //public List<Model.DisaCrossPoint> GetList(int pid, int ppid)
        //{
        //    StringBuilder strSql = new StringBuilder("SELECT * FROM DisaCrossPoint where PID=" + pid + " and PPID=" + ppid);
        //    using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
        //    {
        //        List<Model.DisaCrossPoint> lst = GetList(dr);
        //        return lst;
        //    }
        //}



        /// <summary>
        /// 得到数据条数
        /// </summary>
        public int GetCount(string condition)
        {
            return DbHelperSQL.GetCount("DisaCrossPoint", condition);
        }


        /// <summary>
        /// 获取页数
        /// </summary>
        public int GetPageNum(int PageSize, string WhereClause)
        {
            StringBuilder strSql = new StringBuilder("SELECT count(*) FROM DisaCrossPoint");
            if (!string.IsNullOrEmpty(WhereClause))
                strSql.Append(" where " + WhereClause);
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString(), null))
            {
                if (dr.Read())
                {
                    int cnt = int.Parse(dr[0].ToString());
                    return (int)Math.Ceiling((double)(Convert.ToDouble(cnt.ToString()) / Convert.ToDouble(PageSize.ToString())));
                }
                else return 0;
            }
        }

        /// <summary>
        /// 分页获取泛型数据列表
        /// </summary>
        public List<Model.DisaCrossPoint> GetPageList(int pageSize, int pageIndex, string WhereClause)
        {

            string strSql = "SELECT TOP " + pageSize.ToString() + " * " +
                             "    FROM " +
                                        " ( " +
                                        " SELECT ROW_NUMBER() OVER (ORDER BY BH) AS RowNumber,* FROM DisaCrossPoint "
                                             + (!string.IsNullOrEmpty(WhereClause) ? " where " + WhereClause : "") +
                                         ") A " +
                                 "WHERE RowNumber > " + pageSize.ToString() + "*(" + pageIndex.ToString() + "-1)  ";
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString(), null))
            {
                List<Model.DisaCrossPoint> lst = GetList(dr);
                return lst;
            }
        }

        #region -------- 私有方法，通常情况下无需修改 --------

        /// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        private Model.DisaCrossPoint GetModel(DbDataReader dr)
        {
            Model.DisaCrossPoint model = new Model.DisaCrossPoint();
            model.ID = DbHelperSQL.GetInt(dr["ID"]);
            model.PID = DbHelperSQL.GetInt(dr["PID"]);
            model.PName = DbHelperSQL.GetString(dr["PName"]);
            model.LAT = DbHelperSQL.GetDouble(dr["LAT"]);
            model.LON = DbHelperSQL.GetDouble(dr["LON"]);
            return model;
        }

        /// <summary>
        /// 由DbDataReader得到泛型数据列表
        /// </summary>
        private List<Model.DisaCrossPoint> GetList(DbDataReader dr)
        {
            List<Model.DisaCrossPoint> lst = new List<Model.DisaCrossPoint>();
            while (dr.Read())
            {
                lst.Add(GetModel(dr));
            }
            return lst;
        }

        #endregion
    }
}
