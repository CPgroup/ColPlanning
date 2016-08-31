//------------------------------------------------------------------------------
// 创建标识: 尹健
// 创建描述: 灾区基本信息数据访问类
// 创建时间:2013.11.11
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
    /// 数据访问类 DisaAreaInfo
    /// </summary>
    public class DisaAreaInfo
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.DisaAreaInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO DisaAreaInfo(");
            strSql.Append("Name,StartTime,LON,LAT,Province,County,Descripe,Seismic,Angle,MBR,PolygonString,GenerateWay)");
            strSql.Append(" VALUES (");
            strSql.Append("@in_Name,@in_StartTime,@in_LON,@in_LAT,@in_Province,@in_County,@in_Descripe,@in_Seismic,@in_Angle,@in_MBR,@in_PolygonString,@in_GenerateWay)");
            SqlParameter[] cmdParms = new SqlParameter[]{
                new SqlParameter("@in_Name", SqlDbType.NVarChar),
				new SqlParameter("@in_StartTime", SqlDbType.NVarChar),
				new SqlParameter("@in_LON", SqlDbType.Decimal),
				new SqlParameter("@in_LAT", SqlDbType.Decimal ),
				new SqlParameter("@in_Province", SqlDbType.NVarChar),
				new SqlParameter("@in_County", SqlDbType.NVarChar),
                new SqlParameter("@in_Descripe", SqlDbType.Decimal),
				new SqlParameter("@in_Seismic", SqlDbType.Decimal),
				new SqlParameter("@in_Angle", SqlDbType.Decimal),
                new SqlParameter("@in_MBR", SqlDbType.NVarChar),
                new SqlParameter("@in_PolygonString", SqlDbType.NVarChar),
                new SqlParameter("@in_GenerateWay", SqlDbType.NVarChar),};

            cmdParms[0].Value = model.Name;
            cmdParms[1].Value = model.StartTime;
            cmdParms[2].Value = model.LON;
            cmdParms[3].Value = model.LAT;
            cmdParms[4].Value = model.Province;
            cmdParms[5].Value = model.County;
            cmdParms[6].Value = model.Descripe;
            cmdParms[7].Value = model.Seismic;
            cmdParms[8].Value = model.Angle;
            cmdParms[9].Value = model.MBR;
            cmdParms[10].Value = model.PolygonString;
            cmdParms[11].Value = model.GenerateWay;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Model.DisaAreaInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE DisaAreaInfo SET ");
            strSql.Append("Name=@in_Name,");
            strSql.Append("StartTime=@in_StartTime,");
            strSql.Append("LON=@in_LON,");
            strSql.Append("LAT=@in_LAT,");
            strSql.Append("Province=@in_Province,");
            strSql.Append("County=@in_County,"); ;
            strSql.Append("Descripe=@in_Descripe,");
            strSql.Append("Seismic=@in_Seismic,");
            strSql.Append("Angle=@in_Angle,");
            strSql.Append("MBR=@in_MBR,");
            strSql.Append("PolygonString=@in_PolygonString");
            strSql.Append(" WHERE ID=@in_ID");
            SqlParameter[] cmdParms = new SqlParameter[]{
                new SqlParameter("@in_Name", SqlDbType.NVarChar),
				new SqlParameter("@in_StartTime", SqlDbType.NVarChar),
				new SqlParameter("@in_LON", SqlDbType.Decimal),
				new SqlParameter("@in_LAT", SqlDbType.Decimal ),
				new SqlParameter("@in_Province", SqlDbType.NVarChar),
				new SqlParameter("@in_County", SqlDbType.NVarChar),
                new SqlParameter("@in_Descripe", SqlDbType.Decimal),
				new SqlParameter("@in_Seismic", SqlDbType.Decimal),
				new SqlParameter("@in_Angle", SqlDbType.Decimal),
                new SqlParameter("@in_MBR", SqlDbType.NVarChar),
                new SqlParameter("@in_PolygonString", SqlDbType.NVarChar),
				new SqlParameter("@in_ID", SqlDbType.Int)};

            cmdParms[0].Value = model.Name;
            cmdParms[1].Value = model.StartTime;
            cmdParms[2].Value = model.LON;
            cmdParms[3].Value = model.LAT;
            cmdParms[4].Value = model.Province;
            cmdParms[5].Value = model.County;
            cmdParms[6].Value = model.Descripe;
            cmdParms[7].Value = model.Seismic;
            cmdParms[8].Value = model.Angle;
            cmdParms[9].Value = model.MBR;
            cmdParms[10].Value = model.PolygonString;
            cmdParms[11].Value = model.ID;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM DisaAreaInfo ");
            strSql.Append(" WHERE ID=@in_ID");
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
            return DbHelperSQL.GetMaxID("DisaAreaInfo");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM DisaAreaInfo");
            strSql.Append(" WHERE ID=" + ID.ToString());
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.DisaAreaInfo GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM DisaAreaInfo ");
            strSql.Append(" WHERE ID=" + ID);
            Model.DisaAreaInfo model = null;
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
        /// 得到最新的一个对象实体
        /// </summary>
        public Model.DisaAreaInfo GetSelectedModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  * FROM DisaAreaInfo Where ID="+ID);
            Model.DisaAreaInfo model = null;
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
        /// 得到最新的一个对象实体
        /// </summary>
        public Model.DisaAreaInfo GetTopModel()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT Top 1 * FROM DisaAreaInfo ORDER BY ID desc");
            Model.DisaAreaInfo model = null;
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
        /// 得到一个对象实体
        /// </summary>
        public string GetCounty(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT County FROM DisaAreaInfo Where ID="+ID);
            Model.DisaAreaInfo model = null;
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                string county = "";
                while (dr.Read())
                {
                   county = dr["County"].ToString();
                }
                return county;
            }
        }
        
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.DisaAreaInfo GetLastModel()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT top 1 * FROM DisaAreaInfo ORDER BY ID DESC");
            Model.DisaAreaInfo model = null;
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
        public List<Model.DisaAreaInfo> GetList()
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM DisaAreaInfo ORDER BY ID DESC");
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.DisaAreaInfo> lst = GetList(dr);
                return lst;
            }
        }

        /// <summary>
        /// 获取泛型数据列表
        /// </summary>
        public List<Model.DisaAreaInfo> GetList(string WhereClause)
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM DisaAreaInfo");
            if (!string.IsNullOrEmpty(WhereClause))
                strSql.Append(" WHERE " + WhereClause);
            strSql.Append(" ORDER BY province");

            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.DisaAreaInfo> lst = GetList(dr);
                return lst;
            }
        }

        /// <summary>
        /// 得到数据条数
        /// </summary>
        public int GetCount(string condition)
        {
            return DbHelperSQL.GetCount("DisaAreaInfo", condition);
        }

        /// <summary>
        /// 获取页数
        /// </summary>
        public int GetPageNum(int PageSize, string WhereClause)
        {
            StringBuilder strSql = new StringBuilder("SELECT count(*) FROM DisaAreaInfo");
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
        public List<Model.DisaAreaInfo> GetPageList(int pageSize, int pageIndex, string WhereClause)
        {
            string strSql = "SELECT TOP " + pageSize.ToString() + " * " +
                             "    FROM " +
                                        " ( " +
                                        " SELECT ROW_NUMBER() OVER (ORDER BY BH) AS RowNumber,* FROM DisaAreaInfo "
                                             + (!string.IsNullOrEmpty(WhereClause) ? " where " + WhereClause : "") +
                                         ") A " +
                                 "WHERE RowNumber > " + pageSize.ToString() + "*(" + pageIndex.ToString() + "-1)  ";
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString(), null))
            {
                List<Model.DisaAreaInfo> lst = GetList(dr);
                return lst;
            }
        }

        #region -------- 私有方法，通常情况下无需修改 --------

        /// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        private Model.DisaAreaInfo GetModel(DbDataReader dr)
        {
            Model.DisaAreaInfo model = new Model.DisaAreaInfo();
            model.ID = DbHelperSQL.GetInt(dr["ID"]);
            model.Name = DbHelperSQL.GetString(dr["Name"]);
            model.StartTime = DbHelperSQL.GetDateTime(dr["StartTime"]);
            model.LON = DbHelperSQL.GetDouble(dr["LON"]);
            model.LAT = DbHelperSQL.GetDouble(dr["LAT"]);
            model.Province = DbHelperSQL.GetString(dr["Province"]);
            model.County = DbHelperSQL.GetString(dr["County"]);
            model.Descripe = DbHelperSQL.GetDouble(dr["Descripe"]);
            model.Seismic = DbHelperSQL.GetDouble(dr["Seismic"]);
            model.Angle = DbHelperSQL.GetDouble(dr["Angle"]);
            model.MBR = DbHelperSQL.GetString(dr["MBR"]);
            model.PolygonString = DbHelperSQL.GetString(dr["PolygonString"]);
            model.GenerateWay = DbHelperSQL.GetString(dr["GenerateWay"]);
            return model;
        }

        /// <summary>
        /// 由DbDataReader得到泛型数据列表
        /// </summary>
        private List<Model.DisaAreaInfo> GetList(DbDataReader dr)
        {
            List<Model.DisaAreaInfo> lst = new List<Model.DisaAreaInfo>();
            while (dr.Read())
            {
                lst.Add(GetModel(dr));
            }
            return lst;
        }

        #endregion
    }
}
