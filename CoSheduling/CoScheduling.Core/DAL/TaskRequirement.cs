//------------------------------------------------------------------------------
// 创建标识: 李佳霖
// 创建描述: 任务需求数据库访问类
// 创建时间:2017.2.28
// 文件版本:1.0
// 功能描述: 任务需求数据库的管理核心代码
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
    public class TaskRequirement
    {
        //数据库连接字符串(web.config来配置)，可以动态更改connectionString支持多数据库.		
        public static string connectionString;
        public TaskRequirement()
        {
            connectionString = PubConstant.GetConnectionString("");
            //connectionString = @"server=HYCSIM51DM4IL8B;database=CoMonitoring; integrated security=SSPI ";//建立的时候就确定了，连接数据库的路径
        }
        /// <summary>
        /// 任务需求记录添加函数
        /// </summary>
        /// <param name="model"></param>参数为任务需求实体类的一个实例
        /// <returns></returns>返回值为影响的数据库中的行数
        public int AddRecord(Model.TaskRequirement model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO TaskRequirements_general(");
            strSql.Append("TaskID,TaskName,SubmissionTime,TaskPriority,DisasterType,TaskStage,StartTime,EndTime,RespondingTime,SensorNeeded,ObservationFrequency,Weather,Windlevel,MinTemperature,MaxTemperature,RoadAccessability,SpaceResolution,Datavolume,OccurTime)");
            strSql.Append(" VALUES (");
            strSql.Append("@in_TaskID,@in_TaskName,@in_SubmissionTime,@in_TaskPriority,@in_DisasterType,@in_TaskStage,@in_StartTime,@in_EndTime,@in_RespondingTime,@in_SensorNeeded,@in_ObservationFrequency,@in_Weather,@in_Windlevel,@in_MinTemperature,@in_MaxTemperature,@in_RoadAccessability,@in_SpaceResolution,@in_Datavolume,@in_OccurTime)");
            SqlParameter[] cmdParms = new SqlParameter[]{
				new SqlParameter("@in_TaskID", SqlDbType.Decimal),
                new SqlParameter("@in_TaskName", SqlDbType.NVarChar),
				new SqlParameter("@in_SubmissionTime", SqlDbType.DateTime),
				new SqlParameter("@in_TaskPriority", SqlDbType.Decimal),
				new SqlParameter("@in_DisasterType", SqlDbType.NVarChar),
				new SqlParameter("@in_TaskStage", SqlDbType.NVarChar),
				new SqlParameter("@in_StartTime", SqlDbType.DateTime),
				new SqlParameter("@in_EndTime", SqlDbType.DateTime),
				new SqlParameter("@in_RespondingTime", SqlDbType.Decimal),
                new SqlParameter("@in_SensorNeeded", SqlDbType.NVarChar),
				new SqlParameter("@in_ObservationFrequency", SqlDbType.Decimal),
				new SqlParameter("@in_Weather", SqlDbType.NVarChar),
				new SqlParameter("@in_Windlevel", SqlDbType.Decimal),
				new SqlParameter("@in_MinTemperature", SqlDbType.Decimal),
				new SqlParameter("@in_MaxTemperature", SqlDbType.Decimal),
				new SqlParameter("@in_RoadAccessability", SqlDbType.Bit),
				new SqlParameter("@in_SpaceResolution", SqlDbType.Decimal),
				new SqlParameter("@in_Datavolume", SqlDbType.Decimal),
				new SqlParameter("@in_OccurTime", SqlDbType.DateTime)};
            
            cmdParms[0].Value = model.TaskID;
            cmdParms[1].Value = model.TaskName;
            cmdParms[2].Value = model.SubmissionTime;
            cmdParms[3].Value = model.TaskPriority;
            cmdParms[4].Value = model.DisasterType;
            cmdParms[5].Value = model.TaskStage;
            cmdParms[6].Value = model.StartTime;
            cmdParms[7].Value = model.EndTime;
            cmdParms[8].Value = model.RespondingTime;
            cmdParms[9].Value = model.SensorNeeded;
            cmdParms[10].Value = model.ObservationFrequency;
            cmdParms[11].Value = model.Weather;
            cmdParms[12].Value = model.Windlevel;
            cmdParms[13].Value = model.MinTemperature;
            cmdParms[14].Value = model.MaxTemperature;
            cmdParms[15].Value = model.RoadAccessability;
            cmdParms[16].Value = model.SpaceResolution;
            cmdParms[17].Value = model.Datavolume;
            cmdParms[18].Value = model.OccurTime;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);//使用更改过的执行语句
        }
        /// <summary>
        /// 根据ID修改数据库中的一条记录,增加的属性还未修改
        /// </summary>
        /// <param name="model"></param>任务需求实体类的实例
        /// <returns></returns>返回值为修改的记录数
        public int Update(Model.TaskRequirement model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE TaskRequirements_general SET ");

            strSql.Append("TaskName=@in_TaskName,");
            strSql.Append("SubmissionTime=@in_SubmissionTime,");
            strSql.Append("TaskPriority=@in_TaskPriority,");
            strSql.Append("DisasterType=@in_DisasterType,");
            strSql.Append("TaskStage=@in_TaskStage,");
            strSql.Append("StartTime=@in_StartTime,");
            strSql.Append("EndTime=@in_EndTime,");
            strSql.Append("RespondingTime=@in_RespondingTime,");
            strSql.Append("SensorNeeded=@in_SensorNeeded,");
            strSql.Append("ObservationFrequency=@in_ObservationFrequency,");
            strSql.Append("Weather=@in_Weather,");
            strSql.Append("Windlevel=@in_Windlevel,");
            strSql.Append("MinTemperature=@in_MinTemperature,");
            strSql.Append("MaxTemperature=@in_MaxTemperature,");
            strSql.Append("RoadAccessability=@in_RoadAccessability,");
            strSql.Append("SpaceResolution=@in_SpaceResolution,");
            strSql.Append("Datavolume=@in_Datavolume,");
            strSql.Append("OccurTime=@in_OccurTime");
            strSql.Append(" WHERE TaskID=@in_TaskID");
            SqlParameter[] cmdParms = new SqlParameter[]{
				new SqlParameter("@in_TaskID", SqlDbType.Decimal),
                new SqlParameter("@in_TaskName", SqlDbType.NVarChar),
				new SqlParameter("@in_SubmissionTime", SqlDbType.DateTime),
				new SqlParameter("@in_TaskPriority", SqlDbType.Decimal),
				new SqlParameter("@in_DisasterType", SqlDbType.NVarChar),
				new SqlParameter("@in_TaskStage", SqlDbType.NVarChar),
				new SqlParameter("@in_StartTime", SqlDbType.DateTime),
				new SqlParameter("@in_EndTime", SqlDbType.DateTime),
				new SqlParameter("@in_RespondingTime", SqlDbType.Decimal),
                new SqlParameter("@in_SensorNeeded", SqlDbType.NVarChar),
				new SqlParameter("@in_ObservationFrequency", SqlDbType.Decimal),
				new SqlParameter("@in_Weather", SqlDbType.NVarChar),
				new SqlParameter("@in_Windlevel", SqlDbType.Decimal),
				new SqlParameter("@in_MinTemperature", SqlDbType.Decimal),
				new SqlParameter("@in_MaxTemperature", SqlDbType.Decimal),
				new SqlParameter("@in_RoadAccessability", SqlDbType.Bit),
				new SqlParameter("@in_SpaceResolution", SqlDbType.Decimal),
				new SqlParameter("@in_Datavolume", SqlDbType.Decimal),
				new SqlParameter("@in_OccurTime", SqlDbType.DateTime)};

            cmdParms[0].Value = model.TaskID;
            cmdParms[1].Value = model.TaskName;
            cmdParms[2].Value = model.SubmissionTime;
            cmdParms[3].Value = model.TaskPriority;
            cmdParms[4].Value = model.DisasterType;
            cmdParms[5].Value = model.TaskStage;
            cmdParms[6].Value = model.StartTime;
            cmdParms[7].Value = model.EndTime;
            cmdParms[8].Value = model.RespondingTime;
            cmdParms[9].Value = model.SensorNeeded;
            cmdParms[10].Value = model.ObservationFrequency;
            cmdParms[11].Value = model.Weather;
            cmdParms[12].Value = model.Windlevel;
            cmdParms[13].Value = model.MinTemperature;
            cmdParms[14].Value = model.MaxTemperature;
            cmdParms[15].Value = model.RoadAccessability;
            cmdParms[16].Value = model.SpaceResolution;
            cmdParms[18].Value = model.OccurTime;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }
        /// <summary>
        /// 根据任务编号删除一条任务记录
        /// </summary>
        /// <param name="TaskID"></param>
        /// <returns></returns>
        public int Delete(decimal TaskID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM TaskRequirements_general");
            strSql.Append(" WHERE TaskID=@in_TaskID");
            SqlParameter[] cmdParms = new SqlParameter[]{
				new SqlParameter("@in_TaskID", SqlDbType.Decimal)};
            cmdParms[0].Value = TaskID;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string TaskID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM TaskRequirements_general");
            strSql.Append(" WHERE TaskID=" + TaskID);
            return DbHelperSQL.Exists(strSql.ToString());
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.TaskRequirement GetModel(decimal TaskID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM TaskRequirements_general ");
            strSql.Append(" WHERE TaskID=" + TaskID);
            Model.TaskRequirement model = null;
            using (DbDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (dr.Read())
                {
                    model = GetModel(dr);//本类中的
                }
                return model;
            }
        }
        /// <summary>
        /// 获取泛型数据列表
        /// </summary>
        public List<Model.TaskRequirement> GetList(string whereclause)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM TaskRequirements_general ");
            strSql.Append(" WHERE " + whereclause); ;
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.TaskRequirement> lst = GetList(dr);
                return lst;
            }
        }
        /// <summary>
        /// 获取全部记录
        /// </summary>
        /// <returns></returns>
        public List<CoScheduling.Core.Model.TaskRequirement> GetList()
        {
            StringBuilder StrSql = new StringBuilder();
            StrSql.Append("SELECT * FROM TaskRequirements_general order by TaskID desc");

            using (DbDataReader dr = DbHelperSQL.ExecuteReader(StrSql.ToString()))
            {
                List<CoScheduling.Core.Model.TaskRequirement> lst = GetList(dr);
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
            strSql.Append(" FROM TaskRequirements_general ");
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
            strSql.Append(" FROM TaskRequirements_general ");
            if (strWhere.Trim() != "")
            {
                strSql.Append("WHERE " + strWhere);
            }
            strSql.Append(" ORDER BY TaskID");
            DataSet dsSat = new DataSet();
            SqlDataAdapter odaSat = new SqlDataAdapter(strSql.ToString(), connectionString);
            if (dsSat.Tables["TaskRequirements_general"] != null)
            {
                dsSat.Tables["TaskRequirements_general"].Clear();
            }

            odaSat.Fill(dsSat, "TaskRequirements_general");

            return dsSat;
        }

        #region -------- 私有方法，通常情况下无需修改 --------

        /// <summary>
        /// 由一行数据得到一个实体,还有很多问题，什么时候用try catch,什么时候不用
        /// </summary>
        private Model.TaskRequirement  GetModel(DbDataReader dr)
        {

            CoScheduling.Core.Model.TaskRequirement model = new CoScheduling.Core.Model.TaskRequirement();
            model.TaskID = Convert.ToDecimal(dr["TaskID"]);
            model.SubmissionTime = Convert.ToDateTime(dr["SubmissionTime"]);
            model.TaskPriority = Convert.ToDecimal(dr["TaskPriority"]);
            try
            {
                model.DisasterType = Convert.ToString(dr["DisasterType"]);
            }
            catch
            {
                model.DisasterType = Convert.ToString("N/A");
            }

            try
            {
                model.TaskStage = Convert.ToString(dr["TaskStage"]);
            }
            catch
            {
                model.TaskStage = Convert.ToString("N/A");
            }
            try
            {
                model.StartTime = Convert.ToDateTime(dr["StartTime"]);
            }
            catch
            {
                model.StartTime = Convert.ToDateTime("N/A");
            }
            try
            {
                model.EndTime = Convert.ToDateTime(dr["EndTime"]);
            }
            catch
            {
                model.EndTime = Convert.ToDateTime("N/A");
            }
            try
            {
                model.RespondingTime = Convert.ToDecimal(dr["RespondingTime"]);
            }
            catch
            {
                model.RespondingTime = Convert.ToDecimal("-1");
            }
            try
            {
                model.ObservationFrequency = Convert.ToDecimal(dr["ObservationFrequency"]);
            }
            catch
            {
                model.ObservationFrequency = Convert.ToDecimal("N/A");
            }
            try
            {
                model.Weather = Convert.ToString(dr["Weather"]);
            }
            catch
            {
                model.Weather = Convert.ToString("N/A");
            }
            try
            {
                model.Windlevel = Convert.ToDecimal(dr["Windlevel"]);
            }
            catch (Exception es)
            {
                model.Windlevel = Convert.ToDecimal("-1");
            }
            try
            {
                model.MinTemperature = Convert.ToDecimal(dr["MinTemperature"]);
            }
            catch
            {
                model.MinTemperature = Convert.ToDecimal("-1");
            }
            try
            {
                model.MaxTemperature = Convert.ToDecimal(dr["MaxTemperature"]);
            }
            catch
            {
                model.MaxTemperature = Convert.ToDecimal("-1");
            }
            try
            {
                model.RoadAccessability = Convert.ToBoolean(dr["RoadAccessability"]);
            }
            catch
            {
                //model.RoadAccessability = Convert.ToBoolean("-1");
            }
            try
            {
                model.SpaceResolution = Convert.ToDecimal(dr["SpaceResolution"]);
            }
            catch
            {
                model.SpaceResolution = Convert.ToDecimal("-1");
            }
            try
            {
                model.Datavolume = Convert.ToDecimal(dr["Datavolume"]);
            }
            catch
            {
                model.Datavolume = Convert.ToDecimal("-1");
            }
            try
            {
                model.OccurTime = Convert.ToDateTime(dr["OccurTime"]);
            }
            catch
            {
                model.OccurTime = Convert.ToDateTime("2013-01-01");
            }

            try
            {
                model.SensorNeeded = Convert.ToString(dr["SensorNeeded"]);
            }
            catch
            {
                model.SensorNeeded = "可见光";
            }
            return model;
        }

        /// <summary>
        /// 由DbDataReader得到泛型数据列表
        /// </summary>
        private List<Model.TaskRequirement> GetList(DbDataReader dr)
        {
            List<Model.TaskRequirement> lst = new List<Model.TaskRequirement>();
            while (dr.Read())
            {
                lst.Add(GetModel(dr));
            }
            return lst;
        }

        #endregion

    }
}
