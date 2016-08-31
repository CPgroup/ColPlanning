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
    public class UAV
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.UAV model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO UAV(");
            strSql.Append("Model,Size,Loads,WindResistance,RainResistance,Radius,Endurance,Speed,Height,Voyage,TakeoffMode,RecycleMode,UnfoldTime,FoldTime,isUnload,RefulTime,Camera,isUse,Company,Type)");
            strSql.Append(" VALUES (");
            strSql.Append("@in_Model,@in_Size,@in_Loads,@in_WindResistance,@in_RainResistance,@in_Radius,@in_Endurance,@in_Speed,@in_Height,@in_Voyage,@in_TakeoffMode,@in_RecycleMode,@in_UnfoldTime,@in_FoldTime,@in_isUnload,@in_RefulTime,@in_Camera,@in_isUse,@in_Company,@in_Type)");
            SqlParameter[] cmdParms = new SqlParameter[]{
                new SqlParameter("@in_Model", SqlDbType.NVarChar),
				new SqlParameter("@in_Size", SqlDbType.Decimal),
				new SqlParameter("@in_Loads", SqlDbType.NVarChar),
				new SqlParameter("@in_WindResistance", SqlDbType.NVarChar),
				new SqlParameter("@in_RainResistance", SqlDbType.NVarChar),
				new SqlParameter("@in_Radius", SqlDbType.Decimal),
				new SqlParameter("@in_Endurance", SqlDbType.Decimal),
				new SqlParameter("@in_Speed", SqlDbType.Decimal),
				new SqlParameter("@in_Height", SqlDbType.Decimal),
				new SqlParameter("@in_Voyage", SqlDbType.Decimal),
				new SqlParameter("@in_TakeoffMode", SqlDbType.NVarChar),
				new SqlParameter("@in_RecycleMode", SqlDbType.NVarChar),
				new SqlParameter("@in_UnfoldTime", SqlDbType.Decimal),
				new SqlParameter("@in_FoldTime", SqlDbType.Decimal),
				new SqlParameter("@in_isUnload", SqlDbType.NVarChar),
				new SqlParameter("@in_RefulTime", SqlDbType.Decimal),
				new SqlParameter("@in_Camera", SqlDbType.NVarChar),
				new SqlParameter("@in_isUse", SqlDbType.Bit),
				new SqlParameter("@in_Company", SqlDbType.NVarChar),
				new SqlParameter("@in_Type", SqlDbType.NVarChar)};

            cmdParms[0].Value = model.Model;
            cmdParms[1].Value = model.Size;
            cmdParms[2].Value = model.Loads;
            cmdParms[3].Value = model.WindResistance;
            cmdParms[4].Value = model.RainResistance;
            cmdParms[5].Value = model.Radius;
            cmdParms[6].Value = model.Endurance;
            cmdParms[7].Value = model.Speed;
            cmdParms[8].Value = model.Height;
            cmdParms[9].Value = model.Voyage;
            cmdParms[10].Value = model.TakeoffMode;
            cmdParms[11].Value = model.RecycleMode;
            cmdParms[12].Value = model.UnfoldTime;
            cmdParms[13].Value = model.FoldTime;
            cmdParms[14].Value = model.isUnload;
            cmdParms[15].Value = model.RefulTime;
            cmdParms[16].Value = model.Camera;
            cmdParms[17].Value = model.isUse;
            cmdParms[18].Value = model.Company;
            cmdParms[19].Value = model.Type;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Model.UAV model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE UAV SET ");
            strSql.Append("Model=@in_Model,");
            strSql.Append("Size=@in_Size,");
            strSql.Append("Loads=@in_Loads,");
            strSql.Append("WindResistance=@in_WindResistance,");
            strSql.Append("RainResistance=@in_RainResistance,");
            strSql.Append("Radius=@in_Radius,");
            strSql.Append("Endurance=@in_Endurance,");
            strSql.Append("Speed=@in_Speed,");
            strSql.Append("Height=@in_Height,");
            strSql.Append("Voyage=@in_Voyage,");
            strSql.Append("TakeoffMode=@in_TakeoffMode,");
            strSql.Append("RecycleMode=@in_RecycleMode,");
            strSql.Append("UnfoldTime=@in_UnfoldTime,");
            strSql.Append("FoldTime=@in_FoldTime,");
            strSql.Append("isUnload=@in_isUnload,");
            strSql.Append("RefulTime=@in_RefulTime,");
            strSql.Append("Camera=@in_Camera,");
            strSql.Append("isUse=@in_isUse,");
            strSql.Append("Company=@in_Company,");
            strSql.Append("Type=@in_Type");
            strSql.Append(" WHERE ID=@in_ID");
            SqlParameter[] cmdParms = new SqlParameter[]{
                new SqlParameter("@in_Model", SqlDbType.NVarChar),
				new SqlParameter("@in_Size", SqlDbType.Decimal),
				new SqlParameter("@in_Loads", SqlDbType.NVarChar),
				new SqlParameter("@in_WindResistance", SqlDbType.NVarChar),
				new SqlParameter("@in_RainResistance", SqlDbType.NVarChar),
				new SqlParameter("@in_Radius", SqlDbType.Decimal),
				new SqlParameter("@in_Endurance", SqlDbType.Decimal),
				new SqlParameter("@in_Speed", SqlDbType.Decimal),
				new SqlParameter("@in_Height", SqlDbType.Decimal),
				new SqlParameter("@in_Voyage", SqlDbType.Decimal),
				new SqlParameter("@in_TakeoffMode", SqlDbType.NVarChar),
				new SqlParameter("@in_RecycleMode", SqlDbType.NVarChar),
				new SqlParameter("@in_UnfoldTime", SqlDbType.Decimal),
				new SqlParameter("@in_FoldTime", SqlDbType.Decimal),
				new SqlParameter("@in_isUnload", SqlDbType.NVarChar),
				new SqlParameter("@in_RefulTime", SqlDbType.Decimal),
				new SqlParameter("@in_Camera", SqlDbType.NVarChar),
				new SqlParameter("@in_isUse", SqlDbType.Bit),
				new SqlParameter("@in_Company", SqlDbType.NVarChar),
				new SqlParameter("@in_Type", SqlDbType.NVarChar),
				new SqlParameter("@in_ID", SqlDbType.Int)};

            cmdParms[0].Value = model.Model;
            cmdParms[1].Value = model.Size;
            cmdParms[2].Value = model.Loads;
            cmdParms[3].Value = model.WindResistance;
            cmdParms[4].Value = model.RainResistance;
            cmdParms[5].Value = model.Radius;
            cmdParms[6].Value = model.Endurance;
            cmdParms[7].Value = model.Speed;
            cmdParms[8].Value = model.Height;
            cmdParms[9].Value = model.Voyage;
            cmdParms[10].Value = model.TakeoffMode;
            cmdParms[11].Value = model.RecycleMode;
            cmdParms[12].Value = model.UnfoldTime;
            cmdParms[13].Value = model.FoldTime;
            cmdParms[14].Value = model.isUnload;
            cmdParms[15].Value = model.RefulTime;
            cmdParms[16].Value = model.Camera;
            cmdParms[17].Value = model.isUse;
            cmdParms[18].Value = model.Company;
            cmdParms[19].Value = model.Type;
            cmdParms[20].Value = model.ID;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM UAV ");
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
            strSql.Append("SELECT COUNT(1) FROM UAV");
            strSql.Append(" WHERE ID=" + ID.ToString());
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.UAV GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM UAV ");
            strSql.Append(" WHERE ID=" + ID); ;
            Model.UAV model = null;
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
        public Model.UAV GetModel(string whereclause)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM UAV ");
            strSql.Append(" WHERE " + whereclause); ;
            Model.UAV model = null;
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
        public List<Model.UAV> GetList()
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM UAV");
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.UAV> lst = GetList(dr);
                return lst;
            }
        }

        /// <summary>
        /// 获取单位数据列表
        /// </summary>
        public List<Model.UAV> GetCompany()
        {
            StringBuilder strSql = new StringBuilder("SELECT DISTINCT [Company] FROM UAV");
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.UAV> lst = new List<Model.UAV>();
                while (dr.Read())
                {
                    Model.UAV model = new Model.UAV();
                    model.Company = DbHelperSQL.GetString(dr["Company"]);
                    lst.Add(model);
                }
                return lst;
            }
        }

        /// <summary>
        /// 获取无人机类型数据表
        /// </summary>
        public List<Model.UAV> GetUAVType(string whereclause)
        {
            StringBuilder strSql = new StringBuilder("SELECT DISTINCT * FROM UAV");
            strSql.Append(" WHERE " + whereclause);
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.UAV> lst = new List<Model.UAV>();
                while (dr.Read())
                {
                    Model.UAV model = new Model.UAV();
                    model.ID = Convert.ToInt32(DbHelperSQL.GetString(dr["ID"]));
                    model.Company = DbHelperSQL.GetString(dr["Company"]);
                    model.Type = DbHelperSQL.GetString(dr["Type"]);
                    lst.Add(model);
                }
                return lst;
            }
        }

        /// <summary>
        /// 根据条件获取泛型数据列表
        /// </summary>
        public List<Model.UAV> GetList(string whereclause)
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM UAV WHERE " + whereclause);
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.UAV> lst = GetList(dr);
                return lst;
            }
        }

        /// <summary>
        /// 获取页数
        /// </summary>
        public int GetPageNum(int PageSize, string WhereClause)
        {
            StringBuilder strSql = new StringBuilder("SELECT count(*) FROM UAV");
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
        public List<Model.UAV> GetPageList(int pageSize, int pageIndex, string WhereClause)
        {
            string strSql = "SELECT TOP " + pageSize.ToString() + " * " +
                             "    FROM " +
                                        " ( " +
                                        " SELECT ROW_NUMBER() OVER (ORDER BY BH) AS RowNumber,* FROM UAV "
                                             + (!string.IsNullOrEmpty(WhereClause) ? " where " + WhereClause : "") +
                                         ") A " +
                                 "WHERE RowNumber > " + pageSize.ToString() + "*(" + pageIndex.ToString() + "-1)  ";
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString(), null))
            {
                List<Model.UAV> lst = GetList(dr);
                return lst;
            }
        }

        #region -------- 私有方法，通常情况下无需修改 --------

        /// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        private Model.UAV GetModel(DbDataReader dr)
        {
            Model.UAV model = new Model.UAV();
            model.ID = DbHelperSQL.GetInt(dr["ID"]);
            model.Model = DbHelperSQL.GetString(dr["Model"]);
            model.Size = DbHelperSQL.GetDouble(dr["Size"]);
            model.Loads = DbHelperSQL.GetString(dr["Loads"]);
            model.WindResistance = DbHelperSQL.GetString(dr["WindResistance"]);
            model.RainResistance = DbHelperSQL.GetString(dr["RainResistance"]);
            model.Radius = DbHelperSQL.GetDouble(dr["Radius"]);
            model.Endurance = DbHelperSQL.GetDouble(dr["Endurance"]);
            model.Speed = DbHelperSQL.GetDouble(dr["Speed"]);
            model.Height = DbHelperSQL.GetDouble(dr["Height"]);
            model.Voyage = DbHelperSQL.GetDouble(dr["Voyage"]);
            model.TakeoffMode = DbHelperSQL.GetString(dr["TakeoffMode"]);
            model.RecycleMode = DbHelperSQL.GetString(dr["RecycleMode"]);
            model.UnfoldTime = DbHelperSQL.GetDouble(dr["UnfoldTime"]);
            model.FoldTime = DbHelperSQL.GetDouble(dr["FoldTime"]);
            model.isUnload = DbHelperSQL.GetString(dr["isUnload"]);
            model.RefulTime = DbHelperSQL.GetDouble(dr["RefulTime"]);
            model.Camera = DbHelperSQL.GetString(dr["Camera"]);
            model.isUse = DbHelperSQL.GetBool(dr["isUse"]);
            model.Company = DbHelperSQL.GetString(dr["Company"]);
            model.Type = DbHelperSQL.GetString(dr["Type"]);
            return model;
        }

        /// <summary>
        /// 由DbDataReader得到泛型数据列表
        /// </summary>
        private List<Model.UAV> GetList(DbDataReader dr)
        {
            List<Model.UAV> lst = new List<Model.UAV>();
            while (dr.Read())
            {
                lst.Add(GetModel(dr));
            }
            return lst;
        }

        #endregion
    }
}
