//------------------------------------------------------------------------------
// 创建标识: 李佳霖
// 创建描述:传感器匹配结果的数据库访问类
// 创建时间:2017.3.29
// 文件版本:1.0
// 功能描述: 传感器匹配结果数据库的管理核心代码
// 修改标识: 
// 修改描述: 
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using CoScheduling.Core.DBUtility;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

namespace CoScheduling.Core.DAL
{
    public class SensorsMatched
    {
        //数据库连接字符串(web.config来配置)，可以动态更改connectionString支持多数据库.		
        public static string connectionString;
        public SensorsMatched()
        {
            connectionString = PubConstant.GetConnectionString("");
            //connectionString = @"server=HYCSIM51DM4IL8B;database=CoMonitoring; integrated security=SSPI ";//建立的时候就确定了，连接数据库的路径
        }
        /// <summary>
        /// 传感器匹配结果添加函数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Model.SensorsMatched model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Insert into SensorsMatched(");
            strSql.Append("TaskID,SensorID,PLATFORM_ID,MatchingTime)");
            strSql.Append(" Value(");
            strSql.Append("@in_TaskID,@in_SensorID,@in_PLATFORM_ID,@in_MatchingTime)");
            SqlParameter[] cmdParms = new SqlParameter[]{
                new SqlParameter("@in_TaskID",SqlDbType.Decimal),
                new SqlParameter("@in_SensorID",SqlDbType.Decimal),
                new SqlParameter("@in_PLATFORM_ID",SqlDbType.Decimal),
                new SqlParameter("@in_MatchingTime",SqlDbType.DateTime)};

            cmdParms[0].Value = model.TaskID;
            cmdParms[1].Value = model.SensorID;
            cmdParms[2].Value = model.PLATFORM_ID;
            cmdParms[3].Value = model.MatchingTime;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);//执行Sql语句
        }
        /// <summary>
        /// 根据任务ID修改传感器匹配结果数据表中的一条记录
        /// </summary>
        /// <param name="model"></param>传感器匹配结果实体类的实例
        /// <returns></returns>返回值为修改的记录数
        public int Update(Model.SensorsMatched model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update SensorsMatched set ");

            strSql.Append("SensorID=@in_SensorID,");
            strSql.Append("PLATFORM_ID=@in_PLATFORM_ID,");
            strSql.Append("MatchingTime=@in_MatchingTime,");
            strSql.Append(" where TaskID=@in_TaskID");

            SqlParameter[] cmdParms = new SqlParameter[]{
                new SqlParameter("@in_TaskID",SqlDbType.Decimal),
                new SqlParameter("@in_SensorID",SqlDbType.Decimal),
                new SqlParameter("@in_PLATFORM_ID",SqlDbType.Decimal),
                new SqlParameter("@in_MatchingTime",SqlDbType.DateTime)};

            cmdParms[0].Value = model.TaskID;
            cmdParms[1].Value = model.SensorID;
            cmdParms[2].Value = model.PLATFORM_ID;
            cmdParms[3].Value = model.MatchingTime;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }
        /// <summary>
        /// 根据任务编号删除匹配结果记录
        /// </summary>
        /// <param name="TaskID"></param>
        /// <returns></returns>
        public int Delete(decimal TaskID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Delete from SensorsMatched");
            strSql.Append(" Where TaskID=@in_TaskID");
            SqlParameter[] cmdParms = new SqlParameter[]{
                new SqlParameter("@in_SensorID",SqlDbType.Decimal)
            };
            cmdParms[0].Value = TaskID;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }
        /// <summary>
        /// 根据任务ID判断是否存在该记录
        /// </summary>
        /// <param name="TaskID"></param>
        /// <returns></returns>
        public bool Exists(string TaskID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select count(1) from SensorsMatched ");
            strSql.Append(" Where TaskID=" + TaskID);
            return DbHelperSQL.Exists(strSql.ToString());
        }
        /// <summary>
        /// 得到一个对象实体,存在问题TaskID不是唯一标识符
        /// </summary>
        //public Model.SensorsMatched GetModel(decimal TaskID)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("SELECT * FROM TaskRequirements_general ");
        //    strSql.Append(" WHERE TaskID=" + TaskID);
        //    Model.TaskRequirement model = null;
        //    using (DbDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
        //    {
        //        while (dr.Read())
        //        {
        //            model = GetModel(dr);//本类中的
        //        }
        //        return model;
        //    }
        //}

        /// <summary>
        /// 获取泛型数据列表
        /// </summary>
        public List<Model.SensorsMatched> GetList(string whereclause)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM SensorsMatched ");
            strSql.Append(" WHERE " + whereclause); ;
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.SensorsMatched> lst = GetList(dr);
                return lst;
            }
        }
        /// <summary>
        /// 获取全部记录
        /// </summary>
        /// <returns></returns>
        public List<CoScheduling.Core.Model.SensorsMatched> GetList()
        {
            StringBuilder StrSql = new StringBuilder();
            StrSql.Append("SELECT * FROM SensorsMatched order by TaskID desc");

            using (DbDataReader dr = DbHelperSQL.ExecuteReader(StrSql.ToString()))
            {
                List<CoScheduling.Core.Model.SensorsMatched> lst = GetList(dr);
                dr.Close();
                return lst;
            }
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetListTable(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * ");
            strSql.Append(" FROM SensorsMatched ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ORDER BY TaskID");
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
            strSql.Append(" FROM SensorsMatched ");
            if (strWhere.Trim() != "")
            {
                strSql.Append("WHERE " + strWhere);
            }
            strSql.Append(" ORDER BY TaskID");
            DataSet dsSat = new DataSet();
            SqlDataAdapter odaSat = new SqlDataAdapter(strSql.ToString(), connectionString);
            if (dsSat.Tables["SensorsMatched"] != null)
            {
                dsSat.Tables["SensorsMatched"].Clear();
            }

            odaSat.Fill(dsSat, "SensorsMatched");

            return dsSat;
        }
        #region -------- 私有方法，通常情况下无需修改 --------
        /// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private Model.SensorsMatched GetModel(DbDataReader dr)
        {
            CoScheduling.Core.Model.SensorsMatched model = new CoScheduling.Core.Model.SensorsMatched();
            model.TaskID=Convert.ToDecimal(dr["TaskID"]);
            model.SensorID = Convert.ToDecimal(dr["SensorID"]);
            model.PLATFORM_ID = Convert.ToDecimal(dr["PLATFORM_ID"]);
            model.MatchingTime = Convert.ToDateTime(dr["MatchingTime"]);
            
            return model;
        }
        private List<Model.SensorsMatched> GetList(DbDataReader dr)
        {
            List<Model.SensorsMatched> lst = new List<Model.SensorsMatched>();
            while (dr.Read())
            {
                lst.Add(GetModel(dr));
            }
            return lst;
        }
        #endregion




    }
}
