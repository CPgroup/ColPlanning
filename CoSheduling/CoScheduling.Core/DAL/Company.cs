//------------------------------------------------------------------------------
// 创建标识: 尹健
// 创建描述: 单位数据访问类
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
    /// 数据访问类 Company
    /// </summary>
    public class Company
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.Company model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO Company(");
            strSql.Append("Name,Location,LAT,LON,UAVNum,LinkPhone,Linker,WebSite)");
            strSql.Append(" VALUES (");
            strSql.Append("@in_Name,@in_Location,@in_LAT,@in_LON,@in_UAVNum,@in_LinkPhone,@in_Linker,@in_WebSite)");
            // ,Buffer+ "geometry::STGeomFromText('POLYGON ((" + model.Buffer + "))', 4326))"
            SqlParameter[] cmdParms = new SqlParameter[]{
                new SqlParameter("@in_Name", SqlDbType.NVarChar ),
                new SqlParameter("@in_Location", SqlDbType.NVarChar ),
				new SqlParameter("@in_LON", SqlDbType.Decimal),
				new SqlParameter("@in_LAT", SqlDbType.Decimal),
				new SqlParameter("@in_UAVNum", SqlDbType.Int),
				new SqlParameter("@in_LinkPhone", SqlDbType.NVarChar ),
				new SqlParameter("@in_Linker", SqlDbType.NVarChar),
                new SqlParameter("@in_WebSite", SqlDbType.NVarChar)};

            cmdParms[0].Value = model.Name;
            cmdParms[1].Value = model.Location;
            cmdParms[2].Value = model.LON;
            cmdParms[3].Value = model.LAT;
            cmdParms[4].Value = model.UAVNum;
            cmdParms[5].Value = model.LinkPhone;
            cmdParms[6].Value = model.Linker;
            cmdParms[7].Value = model.WebSite;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);


        }

        /// <summary>
        /// 更新一无人机数量
        /// </summary>
        public int UpdateNum(int CID,int NUM)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Company SET ");
            strSql.Append("UAVNum=" + NUM );
            strSql.Append(" WHERE ID="+CID);
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 更新一无人机数量
        /// </summary>
        public int DownNum(int CID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Company SET ");
            strSql.Append("UAVNum=UAVNum-1");
            strSql.Append(" WHERE ID=" + CID);
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Model.Company model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Company SET ");
            strSql.Append("Name=@in_Name,");
            strSql.Append("Location=@in_Location,");
            strSql.Append("LAT=@in_LAT,");
            strSql.Append("LON=@in_LON,");
            strSql.Append("UAVNum=@in_UAVNum,");
            strSql.Append("LinkPhone=@in_LinkPhone,");
            strSql.Append("Linker=@in_Linker,");
            strSql.Append("WebSite=@in_WebSite");
            //strSql.Append(",Buffer=geometry::STGeomFromText('POLYGON ((" + model.Buffer + "))', 4326))");
            strSql.Append(" WHERE ID=@in_ID");
            SqlParameter[] cmdParms = new SqlParameter[]{
                new SqlParameter("@in_Name", SqlDbType.NVarChar ),
                new SqlParameter("@in_Location", SqlDbType.NVarChar ),
				new SqlParameter("@in_LON", SqlDbType.Decimal),
				new SqlParameter("@in_LAT", SqlDbType.Decimal),
				new SqlParameter("@in_UAVNum", SqlDbType.Int),
				new SqlParameter("@in_LinkPhone", SqlDbType.NVarChar ),
				new SqlParameter("@in_Linker", SqlDbType.NVarChar),
                new SqlParameter("@in_WebSite", SqlDbType.NVarChar),
				new SqlParameter("@in_ID", SqlDbType.Int)};
            cmdParms[0].Value = model.Name;
            cmdParms[1].Value = model.Location;
            cmdParms[2].Value = model.LON;
            cmdParms[3].Value = model.LAT;
            cmdParms[4].Value = model.UAVNum;
            cmdParms[5].Value = model.LinkPhone;
            cmdParms[6].Value = model.Linker;
            cmdParms[7].Value = model.WebSite;
            cmdParms[8].Value = model.ID;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM Company ");
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
            return DbHelperSQL.GetMaxID("Company");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM Company");
            strSql.Append(" WHERE ID=" + ID.ToString());
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 是否存在该公司
        /// </summary>
        public bool ExistsCompany(string WhereClause)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM Company");
            strSql.Append(" WHERE " + WhereClause);
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.Company GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM Company ");
            strSql.Append(" WHERE ID=" + ID);
            Model.Company model = null;
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
        public List<Model.Company> GetList()
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM Company");
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.Company> lst = GetList(dr);
                return lst;
            }
        }


        /// <summary>
        /// 根据条件获取泛型数据列表
        /// </summary>
        public List<Model.Company> GetListByCond(string where)
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM Company WHERE Name Like '%"+where+"%'");
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.Company> lst = GetList(dr);
                return lst;
            }
        }


        /// <summary>
        /// 得到数据条数
        /// </summary>
        public int GetCount(string condition)
        {
            return DbHelperSQL.GetCount("Company", condition);
        }



        /// <summary>
        /// 获取页数
        /// </summary>
        public int GetPageNum(int PageSize, string WhereClause)
        {
            StringBuilder strSql = new StringBuilder("SELECT count(*) FROM Company");
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
        public List<Model.Company> GetPageList(int pageSize, int pageIndex, string WhereClause)
        {
            string strSql = "SELECT TOP " + pageSize.ToString() + " * " +
                             "    FROM " +
                                        " ( " +
                                        " SELECT ROW_NUMBER() OVER (ORDER BY BH) AS RowNumber,* FROM Company "
                                             + (!string.IsNullOrEmpty(WhereClause) ? " where " + WhereClause : "") +
                                         ") A " +
                                 "WHERE RowNumber > " + pageSize.ToString() + "*(" + pageIndex.ToString() + "-1)  ";
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString(), null))
            {
                List<Model.Company> lst = GetList(dr);
                return lst;
            }
        }

        #region -------- 私有方法，通常情况下无需修改 --------

        /// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        private Model.Company GetModel(DbDataReader dr)
        {
            Model.Company model = new Model.Company();
            model.ID = DbHelperSQL.GetInt(dr["ID"]);
            model.Name = DbHelperSQL.GetString(dr["Name"]);
            model.Location = DbHelperSQL.GetString(dr["Location"]);
            model.LON = DbHelperSQL.GetDouble(dr["LON"]);
            model.LAT = DbHelperSQL.GetDouble(dr["LAT"]);
            model.UAVNum = DbHelperSQL.GetInt(dr["UAVNum"]);
            model.LinkPhone = DbHelperSQL.GetString(dr["LinkPhone"]);
            model.Linker = DbHelperSQL.GetString(dr["Linker"]);
            model.WebSite = DbHelperSQL.GetString(dr["WebSite"]);
            model.Buffer = DbHelperSQL.GetString(dr["Buffer"]);
            return model;
        }

        /// <summary>
        /// 由DbDataReader得到泛型数据列表
        /// </summary>
        private List<Model.Company> GetList(DbDataReader dr)
        {
            List<Model.Company> lst = new List<Model.Company>();
            while (dr.Read())
            {
                lst.Add(GetModel(dr));
            }
            return lst;
        }

        #endregion
    }
}
