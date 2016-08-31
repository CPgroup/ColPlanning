//------------------------------------------------------------------------------
// 创建标识: 尹健
// 创建描述: 无人机访问类
// 创建时间:2013.11.15
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
    /// 数据访问类 UAV
    /// </summary>
    public class UAVBD
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.UAVBD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO UAVBD(");
            strSql.Append("CID,Speed,Focus,Chip_L,Chip_W,Pixel_L,Pixel_W,Sidelap,Routelap,X,Y,Name,Province,GID)");
            strSql.Append(" VALUES (");
            strSql.Append("@in_CID,@in_Speed,@in_Focus,@in_Chip_L,@in_Chip_W,@in_Pixel_L,@in_Pixel_W,@in_Sidelap,@in_Routelap,@in_X,@in_Y,@in_Name,@in_Province,@in_GID)");
            SqlParameter[] cmdParms = new SqlParameter[]{
                new SqlParameter("@in_CID", SqlDbType.Int),
                new SqlParameter("@in_Speed", SqlDbType.Float),
				new SqlParameter("@in_Focus", SqlDbType.Float),
				new SqlParameter("@in_Chip_L", SqlDbType.Float),
				new SqlParameter("@in_Chip_W", SqlDbType.Float),
				new SqlParameter("@in_Pixel_L", SqlDbType.Float),
				new SqlParameter("@in_Pixel_W", SqlDbType.Float),
				new SqlParameter("@in_Sidelap", SqlDbType.Float),
				new SqlParameter("@in_Routelap", SqlDbType.Float),
				new SqlParameter("@in_X", SqlDbType.Float),
				new SqlParameter("@in_Y", SqlDbType.Float),
                new SqlParameter("@in_Name", SqlDbType.NVarChar),
                new SqlParameter("@in_Province", SqlDbType.NVarChar),
                new SqlParameter("@in_GID", SqlDbType.Int)};
            cmdParms[0].Value = model.CID;
            cmdParms[1].Value = model.Speed;
            cmdParms[2].Value = model.Focus;
            cmdParms[3].Value = model.Chip_L;
            cmdParms[4].Value = model.Chip_W;
            cmdParms[5].Value = model.Pixel_L;
            cmdParms[6].Value = model.Pixel_W;
            cmdParms[7].Value = model.Sidelap;
            cmdParms[8].Value = model.Routelap;
            cmdParms[9].Value = model.X;
            cmdParms[10].Value = model.Y;
            cmdParms[11].Value = model.Name;
            cmdParms[12].Value = model.Province;
            cmdParms[13].Value = model.GID;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int UpdateAll(Model.UAVBD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE UAVBD SET ");
            strSql.Append("CID=@in_CID,");            
            strSql.Append("Speed=@in_Speed,");
            strSql.Append("Focus=@in_Focus,");
            strSql.Append("Chip_L=@in_Chip_L,");
            strSql.Append("Chip_W=@in_Chip_W,");
            strSql.Append("Pixel_L=@in_Pixel_L,");
            strSql.Append("Pixel_W=@in_Pixel_W,");
            strSql.Append("Sidelap=@in_Sidelap,");
            strSql.Append("Routelap=@in_Routelap,");
            strSql.Append("X=@in_X,");
            strSql.Append("Y=@in_Y,");
            strSql.Append("Name=@in_Name,");
            strSql.Append("Province=@in_Province,");
            strSql.Append("GID=@in_GID");
            strSql.Append(" WHERE ID=@in_ID");
            SqlParameter[] cmdParms = new SqlParameter[]{
                new SqlParameter("@in_CID", SqlDbType.Int),
                new SqlParameter("@in_Speed", SqlDbType.Float),
				new SqlParameter("@in_Focus", SqlDbType.Float),
				new SqlParameter("@in_Chip_L", SqlDbType.Float),
				new SqlParameter("@in_Chip_W", SqlDbType.Float),
				new SqlParameter("@in_Pixel_L", SqlDbType.Float),
				new SqlParameter("@in_Pixel_W", SqlDbType.Float),
				new SqlParameter("@in_Sidelap", SqlDbType.Float),
				new SqlParameter("@in_Routelap", SqlDbType.Float),
				new SqlParameter("@in_X", SqlDbType.Float),
				new SqlParameter("@in_Y", SqlDbType.Float),
                new SqlParameter("@in_Name", SqlDbType.NVarChar),
                new SqlParameter("@in_Province", SqlDbType.NVarChar),
                new SqlParameter("@in_GID", SqlDbType.Int),
				new SqlParameter("@in_ID", SqlDbType.Int)};

            cmdParms[0].Value = model.CID;
            cmdParms[1].Value = model.Speed;
            cmdParms[2].Value = model.Focus;
            cmdParms[3].Value = model.Chip_L;
            cmdParms[4].Value = model.Chip_W;
            cmdParms[5].Value = model.Pixel_L;
            cmdParms[6].Value = model.Pixel_W;
            cmdParms[7].Value = model.Sidelap;
            cmdParms[8].Value = model.Routelap;
            cmdParms[9].Value = model.X;
            cmdParms[10].Value = model.Y;
            cmdParms[11].Value = model.Name;
            cmdParms[12].Value = model.Province;
            cmdParms[13].Value = model.GID;
            cmdParms[14].Value = model.ID;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Model.UAVBD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE UAVBD SET ");
            strSql.Append("GID=@in_GID");
            strSql.Append(" WHERE Name=@in_PName");
            SqlParameter[] cmdParms = new SqlParameter[]{
				 new SqlParameter("@in_GID", SqlDbType.Int),
				 new SqlParameter("@in_PName", SqlDbType.NVarChar)};
            cmdParms[0].Value = model.GID;
            cmdParms[1].Value = model.Name;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 根据UID获取编队名称
        /// </summary>
        public string GetUAVName(int UID)
        {
            string uavName = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Name from [dbo].[UAVBD] ");
            strSql.Append(" where id=" + UID);
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (dr.Read())
                {
                    uavName = Convert.ToString(dr["Name"]);
                }
                return uavName;
            }
        }

        /// <summary>
        /// 获取某单位的无人机编队数量
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public int getUAVNum(int cid)
        {
            int COUNT=0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) AS COUNT from [dbo].[UAVBD] ");
            strSql.Append(" WHERE CID=" + cid);
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (dr.Read())
                {
                    COUNT = Convert.ToInt32(dr["COUNT"]);
                }
                return COUNT;
            }
        }

        /// <summary>
        /// 更新集结点和任务ID
        /// </summary>
        public int UpdateGID(int GID, int UAVID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE UAVBD SET ");
            strSql.Append(" GID=" + GID + ",");
            strSql.Append(" isChoosed=0");
            strSql.Append(" WHERE ID=" + UAVID);
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 更新灾区ID
        /// </summary>
        public int UpdateTID(int DID, int UAVID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE UAVBD SET ");
            strSql.Append(" DID=" + DID + ",");
            strSql.Append(" isChoosed=1");
            strSql.Append(" WHERE ID=" + UAVID);
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        public int DeleteAll()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM UAVBD ");
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM UAVBD ");
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
            return DbHelperSQL.GetMaxID("UAV");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM UAVBD");
            strSql.Append(" WHERE ID=" + ID.ToString());
            return DbHelperSQL.Exists(strSql.ToString());
        }
        /// <summary>
        /// 是否存在该记录名称
        /// </summary>
        public bool ExistsName(string name)
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM UAVBD WHERE Name Like '%" + name + "%'");
            //StringBuilder strSql = new StringBuilder();
            //strSql.Append("SELECT COUNT(1) FROM UAVBD");
            //strSql.Append(" WHERE Name=" + name);
            return DbHelperSQL.Exists(strSql.ToString());
        }
        public bool ExistsName2(Core.Model.UAVBD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM UAVBD");
            strSql.Append(" WHERE Name='" + model.Name);
            return DbHelperSQL.Exists(strSql.ToString());
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.UAVBD GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM UAVBD ");
            strSql.Append(" WHERE ID=" + ID + ""); ;

            Model.UAVBD model = null;
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
        /// 根据条件得到一个对象实体
        /// </summary>
        public Model.UAVBD GetModel(string whereclause)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM UAVBD ");
            strSql.Append(" WHERE " + whereclause); ;
            Model.UAVBD model = null;
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
        /// 获得集结点ID
        /// </summary>
        public int GetGID(int ID)
        {
            int i = -1;
            StringBuilder strSql = new StringBuilder("SELECT GID FROM UAVBD WHERE ID="+ID);
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (dr.Read())
                {
                    i = Convert.ToInt32(dr["GID"]);
                }
                return i;
            }
        }

        /// <summary>
        /// 获取泛型数据列表
        /// </summary>
        public List<Model.UAVBD> GetList()
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM UAVBD");
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.UAVBD> lst = GetList(dr);
                return lst;
            }
        }

        /// <summary>
        /// 根据条件获取泛型数据列表
        /// </summary>
        public List<Model.UAVBD> GetUAVList(string whereclause)
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM UAVBD WHERE " + whereclause);
            Model.UAVBD model;
            List<Model.UAVBD> lst = new List<Model.UAVBD>();
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (dr.Read())
                {
                    model = new Model.UAVBD();
                    model.ID = DbHelperSQL.GetInt(dr["ID"]);
                    model.GID = DbHelperSQL.GetInt(dr["GID"]);
                    model.Name = DbHelperSQL.GetString(dr["Name"]);
                    lst.Add(model);
                }
                return lst;
            }
        }


        /// <summary>
        /// 根据条件获取泛型数据列表
        /// </summary>
        public List<Model.UAVBD> GetList(string whereclause)
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM UAVBD WHERE " + whereclause);
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.UAVBD> lst = GetList(dr);
                return lst;
            }
        }

        /// <summary>
        /// 获取页数
        /// </summary>
        public int GetPageNum(int PageSize, string WhereClause)
        {
            StringBuilder strSql = new StringBuilder("SELECT count(*) FROM UAVBD");
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
        public List<Model.UAVBD> GetPageList(int pageSize, int pageIndex, string WhereClause)
        {
            string strSql = "SELECT TOP " + pageSize.ToString() + " * " +
                             "    FROM " +
                                        " ( " +
                                        " SELECT ROW_NUMBER() OVER (ORDER BY BH) AS RowNumber,* FROM UAVBD "
                                             + (!string.IsNullOrEmpty(WhereClause) ? " where " + WhereClause : "") +
                                         ") A " +
                                 "WHERE RowNumber > " + pageSize.ToString() + "*(" + pageIndex.ToString() + "-1)  ";
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString(), null))
            {
                List<Model.UAVBD> lst = GetList(dr);
                return lst;
            }
        }

        #region -------- 私有方法，通常情况下无需修改 --------

        /// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        private Model.UAVBD GetModel(DbDataReader dr)
        {
            Model.UAVBD model = new Model.UAVBD();
            model.ID = DbHelperSQL.GetInt(dr["ID"]);
            model.CID = DbHelperSQL.GetInt(dr["CID"]);
            model.Name = DbHelperSQL.GetString(dr["Name"]);
            model.Speed = DbHelperSQL.GetDouble(dr["Speed"]);
            model.Focus = DbHelperSQL.GetDouble(dr["Focus"]);
            model.Chip_L = DbHelperSQL.GetDouble(dr["Chip_L"]);
            model.Chip_W = DbHelperSQL.GetDouble(dr["Chip_W"]);
            model.Pixel_L = DbHelperSQL.GetDouble(dr["Pixel_L"]);
            model.Pixel_W = DbHelperSQL.GetDouble(dr["Pixel_W"]);
            model.Sidelap = DbHelperSQL.GetDouble(dr["Sidelap"]);
            model.Routelap = DbHelperSQL.GetDouble(dr["Routelap"]);
            model.X = DbHelperSQL.GetDouble(dr["X"]);
            model.Y = DbHelperSQL.GetDouble(dr["Y"]);
            model.GID = DbHelperSQL.GetInt(dr["GID"]);
            model.TotalTime = DbHelperSQL.GetDouble(dr["TotalTime"]);
            model.TaskAreaIndex = DbHelperSQL.GetInt(dr["TaskAreaIndex"]);
            model.Province = DbHelperSQL.GetString(dr["Province"]);
            return model;
        }

        /// <summary>
        /// 由DbDataReader得到泛型数据列表
        /// </summary>
        private List<Model.UAVBD> GetList(DbDataReader dr)
        {
            List<Model.UAVBD> lst = new List<Model.UAVBD>();
            while (dr.Read())
            {
                lst.Add(GetModel(dr));
            }
            return lst;
        }

        #endregion
    }
}
