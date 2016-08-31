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
    /// 数据访问类 灾区任务区
    /// </summary>
    public class TaskAreas
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.TaskAreas model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO TaskAreas(");
            strSql.Append("PID,Name,PolygonString,Grade,Area,X,Y)");
            strSql.Append(" VALUES (");
            strSql.Append("@in_PID,@in_Name,@in_PolygonString,@in_Grade,@in_Area,@in_X,@in_Y)");
            SqlParameter[] cmdParms = new SqlParameter[]{
				new SqlParameter("@in_PID", SqlDbType.Int),
				new SqlParameter("@in_Name", SqlDbType.NVarChar),
				new SqlParameter("@in_PolygonString", SqlDbType.NVarChar),
                new SqlParameter("@in_Grade", SqlDbType.Int),
                new SqlParameter("@in_Area", SqlDbType.Float),
                new SqlParameter("@in_X", SqlDbType.Float),
                new SqlParameter("@in_Y", SqlDbType.Float)
            };

            cmdParms[0].Value = model.PID;
            cmdParms[1].Value = model.Name;
            cmdParms[2].Value = model.PolygonString;
            cmdParms[3].Value = model.Grade;
            cmdParms[4].Value = model.Area;
            cmdParms[5].Value = model.X;
            cmdParms[6].Value = model.Y;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Model.TaskAreas model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE TaskAreas SET ");
            strSql.Append("PID=@in_PID,");
            strSql.Append("Name=@in_Name,");
            strSql.Append("PolygonString=@in_PolygonString,");
            strSql.Append("Grade=@in_Grade,");
            strSql.Append("Area=@in_Area,");
            strSql.Append("X=@in_X,");
            strSql.Append("Y=@in_Y");
            strSql.Append(" WHERE ID=@in_ID");
            SqlParameter[] cmdParms = new SqlParameter[]{
                new SqlParameter("@in_ID", SqlDbType.Int ),
				new SqlParameter("@in_PID", SqlDbType.Int),
				new SqlParameter("@in_Name", SqlDbType.NVarChar),
				new SqlParameter("@in_PolygonString", SqlDbType.NVarChar),
                new SqlParameter("@in_Grade", SqlDbType.Int),
                new SqlParameter("@in_Area", SqlDbType.Float),
                new SqlParameter("@in_X", SqlDbType.Float),
                new SqlParameter("@in_Y", SqlDbType.Float)
            };
            cmdParms[0].Value = model.ID;
            cmdParms[1].Value = model.PID;
            cmdParms[2].Value = model.Name;
            cmdParms[3].Value = model.PolygonString;
            cmdParms[4].Value = model.Grade;
            cmdParms[5].Value = model.Area;
            cmdParms[6].Value = model.X;
            cmdParms[7].Value = model.Y;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 更新UID
        /// </summary>
        public int UpdateUID(int id, int uid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE TaskAreas SET ");
            strSql.Append("UID=" + uid);
            strSql.Append(" WHERE ID=" + id);
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 更新任务区名称和等级
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Updates(Model.TaskAreas model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE TaskAreas SET ");
            strSql.Append("Name=@in_Name,");
            strSql.Append("Grade=@in_Grade");
            strSql.Append(" WHERE ID=@in_ID");
            SqlParameter[] cmdParms = new SqlParameter[]{
                new SqlParameter("@in_ID", SqlDbType.Int ),
				new SqlParameter("@in_Name", SqlDbType.NVarChar),
                new SqlParameter("@in_Grade", SqlDbType.Int)};
            cmdParms[0].Value = model.ID;
            cmdParms[1].Value = model.Name;
            cmdParms[2].Value = model.Grade;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }



        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM TaskAreas ");
            strSql.Append(" WHERE ID=@in_ID");
            SqlParameter[] cmdParms = {
				new SqlParameter("@in_ID",System.Data.SqlDbType.Int, ID)};
            cmdParms[0].Value = ID;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 删除一条数据 根据灾区ID
        /// </summary>
        public int Delete1(int PID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM TaskAreas ");
            strSql.Append(" WHERE PID=@in_PID");
            SqlParameter[] cmdParms = {
				new SqlParameter("@in_PID",System.Data.SqlDbType.Int, PID)};
            cmdParms[0].Value = PID;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("TaskAreas");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM TaskAreas");
            strSql.Append(" WHERE  ID =" + ID);
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string Name, int ID, int PID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM TaskAreas");
            strSql.Append(" WHERE Name='" + Name + "'AND PID=" + PID + " AND ID <>" + ID.ToString());
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 是否存在该任务区
        /// </summary>
        public bool ExistsCompany(string WhereClause)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM TaskAreas");
            strSql.Append(" WHERE " + WhereClause);
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.TaskAreas GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM TaskAreas ");
            strSql.Append(" WHERE ID=" + ID);
            Model.TaskAreas model = null;
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
        /// 根据UID获取编队名称
        /// </summary>
        public string GetTaskName(int TID)
        {
            string uavName = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Name from [dbo].[TaskAreas] ");
            strSql.Append(" where id=" + TID);
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
        /// 获取泛型数据列表
        /// </summary>
        public List<Model.TaskAreas> GetList()
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM TaskAreas");
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.TaskAreas> lst = GetList(dr);
                return lst;
            }
        }

        /// <summary>
        /// 获取没有完成的灾区列表
        /// </summary>
        public List<Model.TaskAreas> GetRemainList(string whereclause)
        {
            List<int> taskID = new List<int>();
            StringBuilder strSql = new StringBuilder("SELECT ID FROM TaskAreas");
            strSql.Append(" WHERE " + whereclause + "");
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (dr.Read())
                    taskID.Add(Convert.ToInt32(dr["ID"]));
            }
            List<Model.TaskAreas> taskArea = new List<Model.TaskAreas>();
            Core.Model.TaskAreas model;
            for (int i = 0; i < taskID.Count; i++)
            {
                model = new Model.TaskAreas();
                model = GetModel(taskID[i]);
                if (model != null)
                    taskArea.Add(model);
            }
            return taskArea;
        }

        /// <summary>
        /// 获取泛型数据列表
        /// </summary>
        public List<Model.TaskAreas> GetList(int pid)
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM TaskAreas where PID=" + pid);
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.TaskAreas> lst = GetList(dr);
                return lst;
            }
        }

        /// <summary>
        /// 获取任务区字符串
        /// </summary>
        public string GetTaskString(int id)
        {
            StringBuilder strSql = new StringBuilder("SELECT PolygonString FROM TaskAreas where ID=" + id);
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                string str="";
                while (dr.Read())
                {
                    str = Convert.ToString(dr["PolygonString"]);                    
                }
                return str;
            }
        }

        /// <summary>
        /// 得到数据条数
        /// </summary>
        public int GetCount(string condition)
        {
            return DbHelperSQL.GetCount("TaskAreas", condition);
        }



        /// <summary>
        /// 获取页数
        /// </summary>
        public int GetPageNum(int PageSize, string WhereClause)
        {
            StringBuilder strSql = new StringBuilder("SELECT count(*) FROM TaskAreas");
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
        public List<Model.TaskAreas> GetPageList(int pageSize, int pageIndex, string WhereClause)
        {
            string strSql = "SELECT TOP " + pageSize.ToString() + " * " +
                             "    FROM " +
                                        " ( " +
                                        " SELECT ROW_NUMBER() OVER (ORDER BY Name) AS RowNumber,* FROM TaskAreas "
                                             + (!string.IsNullOrEmpty(WhereClause) ? " where " + WhereClause : "") +
                                         ") A " +
                                 "WHERE RowNumber > " + pageSize.ToString() + "*(" + pageIndex.ToString() + "-1)  ";
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString(), null))
            {
                List<Model.TaskAreas> lst = GetList(dr);
                return lst;
            }
        }

        #region -------- 私有方法，通常情况下无需修改 --------

        /// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        private Model.TaskAreas GetModel(DbDataReader dr)
        {
            Model.TaskAreas model = new Model.TaskAreas();
            model.ID = DbHelperSQL.GetInt(dr["ID"]);
            model.PID = DbHelperSQL.GetInt(dr["PID"]);
            model.Name = DbHelperSQL.GetString(dr["Name"]);
            model.PolygonString = DbHelperSQL.GetString(dr["PolygonString"]);
            model.Grade = DbHelperSQL.GetInt(dr["Grade"]);
            model.Area = DbHelperSQL.GetDouble(dr["Area"]);
            model.X = DbHelperSQL.GetDouble(dr["X"]);
            model.Y = DbHelperSQL.GetDouble(dr["Y"]);
            model.GID = DbHelperSQL.GetInt(dr["GID"]);
            model.UID = DbHelperSQL.GetInt(dr["UID"]);
            model.TraTime = DbHelperSQL.GetDouble(dr["TraTime"]);
            model.Orders = DbHelperSQL.GetInt(dr["Orders"]);
            model.FlyTime = DbHelperSQL.GetDouble(dr["FlyTime"]);
            return model;
        }

        /// <summary>
        /// 由DbDataReader得到泛型数据列表
        /// </summary>
        private List<Model.TaskAreas> GetList(DbDataReader dr)
        {
            List<Model.TaskAreas> lst = new List<Model.TaskAreas>();
            while (dr.Read())
            {
                lst.Add(GetModel(dr));
            }
            return lst;
        }

        #endregion
    }
}
