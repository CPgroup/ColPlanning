//----------------------------------------------------------------------------
//创建标识：李佳霖
// 创建描述: 观测平台状态访问类
// 创建时间:2017.4.6
// 文件版本:1.0
// 功能描述:观测平台状态数据表的管理，查询
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
    //平台状态访问类
    public class STATE
    {
        //数据库连接字符串(web.config来配置)，可以动态更改connectionString支持多数据库.		
        public static string connectionString;
        public STATE()
        {
            connectionString =  @"server=(local);database=CoMonitoring; User=sa; Password=lhf2017 ";//建立的时候就确定了，连接数据库的路径
        }

        /// <summary>
        /// 平台状态添加函数,添加、删除和管理的数据库连接还存在问题
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Model.STATE model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO STATE(");
            strSql.Append("PLATFORM_ID,TimeReference,SpaceReference,Longitude,Latitude,Elevation,SlewAngle,PLATFORM_TIME,CloudCover,WeatherModelName,");
            strSql.Append("PrecipitationRate,WindSpeed,AmbientTemperature,MisDisOfRoad,MTBF,ObservingTime,UsingState,");
            strSql.Append("FalutState,ResourceConsuming,CurrentMemory)");
            strSql.Append(" Values(");
            strSql.Append("@in_PLATFORM_ID,@in_TimeReference,@in_SpaceReference,@in_Longitude,@in_Latitude,@in_Elevation,@in_SlewAngle,@in_PLATFORM_TIME,@in_CloudCover,@in_WeatherModelName,");
            strSql.Append("@in_PrecipitationRate,@in_WindSpeed,@in_AmbientTemperature,@in_MisDisOfRoad,@in_MTBF,@in_ObservingTime,");
            strSql.Append("@in_UsingState,@in_FalutState,@in_ResourceConsuming,@in_CurrentMemory)");
            SqlParameter[] cmdParms = new SqlParameter[]{
                new SqlParameter("@in_PLATFORM_ID", SqlDbType.Decimal),
                new SqlParameter("@in_TimeReference", SqlDbType.NVarChar),
                new SqlParameter("@in_SpaceReference", SqlDbType.NVarChar),
                new SqlParameter("@in_Longitude", SqlDbType.Decimal),
                new SqlParameter("@in_Latitude", SqlDbType.Decimal),
                new SqlParameter("@in_Elevation", SqlDbType.Decimal),
                new SqlParameter("@in_SlewAngle", SqlDbType.Decimal),
                new SqlParameter("@in_PLATFORM_TIME", SqlDbType.Decimal),
                new SqlParameter("@in_CloudCover", SqlDbType.Decimal),
                new SqlParameter("@in_WeatherModelName", SqlDbType.Decimal),

                new SqlParameter("@in_PrecipitationRate", SqlDbType.NVarChar),
                new SqlParameter("@in_WindSpeed", SqlDbType.Decimal),
                new SqlParameter("@in_AmbientTemperature", SqlDbType.Decimal),
                new SqlParameter("@in_MisDisOfRoad", SqlDbType.Decimal),
                new SqlParameter("@in_MTBF", SqlDbType.Decimal),
                new SqlParameter("@in_ObservingTime", SqlDbType.Decimal),
                new SqlParameter("@in_UsingState", SqlDbType.Decimal),
                new SqlParameter("@in_FalutState", SqlDbType.Decimal),
                new SqlParameter("@in_ResourceConsuming", SqlDbType.Decimal),
                new SqlParameter("@in_CurrentMemory", SqlDbType.Decimal)};

            cmdParms[0].Value = model.PLATFORM_ID;
            cmdParms[1].Value = model.TimeReference;
            cmdParms[2].Value = model.SpaceReference;
            cmdParms[3].Value = model.Longitude;
            cmdParms[4].Value = model.Latitude;
            cmdParms[5].Value = model.Elevation;
            cmdParms[6].Value = model.SlewAngle;
            cmdParms[7].Value = model.PLATFORM_TIME;
            cmdParms[8].Value = model.CloudCover;
            cmdParms[9].Value = model.WeatherModelName;

            cmdParms[10].Value = model.PrecipitationRate;
            cmdParms[11].Value = model.WindSpeed;
            cmdParms[12].Value = model.AmbientTemperature;
            cmdParms[13].Value = model.MisDisOfRoad;
            cmdParms[14].Value = model.MTBF;
            cmdParms[15].Value = model.ObservingTime;
            cmdParms[16].Value = model.UsingState;
            cmdParms[17].Value = model.FalutState;
            cmdParms[18].Value = model.ResourceConsuming;
            cmdParms[19].Value = model.CurrentMemory;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);//执行SQL语句，还需修改数据库连接的问题
        }
        /// <summary>
        /// 根据平台ID修改数据库中的一条记录
        /// </summary>
        /// <param name="model"></param>观测平台状态实体类的实例
        /// <returns></returns>返回值为修改的记录数
        public int Update(Model.STATE model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update STATE set ");

            strSql.Append("SpaceReference=@in_SpaceReference,");
            strSql.Append("Longitude=@in_Longitude,");
            strSql.Append("Latitude=@in_Latitude,");
            strSql.Append("Elevation=@in_Elevation,");
            strSql.Append("SlewAngle=@in_SlewAngle,");
            strSql.Append("PLATFORM_TIME=@in_PLATFORM_TIME,");
            strSql.Append("CloudCover=@in_CloudCover,");
            strSql.Append("WeatherModelName=@in_WeatherModelName,");

            strSql.Append("PrecipitationRate=@in_PrecipitationRate,");
            strSql.Append("WindSpeed=@in_WindSpeed,");
            strSql.Append("AmbientTemperature=@in_AmbientTemperature,");
            strSql.Append("MisDisOfRoad=@in_MisDisOfRoad,");
            strSql.Append("MTBF=@in_MTBF,");
            strSql.Append("ObservingTime=@in_ObservingTime,");
            strSql.Append("UsingState=@in_UsingState,");
            strSql.Append("FalutState=@in_FalutState,");
            strSql.Append("ResourceConsuming=@in_ResourceConsuming,");
            strSql.Append("CurrentMemory=@in_CurrentMemory,");

            strSql.Append(" where PLATFORM_ID=@in_PLATFORM_ID");

            SqlParameter[] cmdParms = new SqlParameter[]{
                new SqlParameter("@in_PLATFORM_ID", SqlDbType.Decimal),
                new SqlParameter("@in_TimeReference", SqlDbType.NVarChar),
                new SqlParameter("@in_SpaceReference", SqlDbType.NVarChar),
                new SqlParameter("@in_Longitude", SqlDbType.Decimal),
                new SqlParameter("@in_Latitude", SqlDbType.Decimal),
                new SqlParameter("@in_Elevation", SqlDbType.Decimal),
                new SqlParameter("@in_SlewAngle", SqlDbType.Decimal),
                new SqlParameter("@in_PLATFORM_TIME", SqlDbType.DateTime),
                new SqlParameter("@in_CloudCover", SqlDbType.Decimal),
                new SqlParameter("@in_WeatherModelName", SqlDbType.NVarChar),

                new SqlParameter("@in_PrecipitationRate", SqlDbType.Decimal),
                new SqlParameter("@in_WindSpeed", SqlDbType.Decimal),
                new SqlParameter("@in_AmbientTemperature", SqlDbType.Decimal),
                new SqlParameter("@in_MisDisOfRoad", SqlDbType.Decimal),
                new SqlParameter("@in_MTBF", SqlDbType.Decimal),
                new SqlParameter("@in_ObservingTime", SqlDbType.Decimal),
                new SqlParameter("@in_UsingState", SqlDbType.Bit),
                new SqlParameter("@in_FalutState", SqlDbType.Bit),
                new SqlParameter("@in_ResourceConsuming", SqlDbType.Decimal),
                new SqlParameter("@in_CurrentMemory", SqlDbType.Decimal)
            };

            cmdParms[0].Value = model.PLATFORM_ID;
            cmdParms[1].Value = model.TimeReference;
            cmdParms[2].Value = model.SpaceReference;
            cmdParms[3].Value = model.Longitude;
            cmdParms[4].Value = model.Latitude;
            cmdParms[5].Value = model.Elevation;
            cmdParms[6].Value = model.SlewAngle;
            cmdParms[7].Value = model.PLATFORM_TIME;
            cmdParms[8].Value = model.CloudCover;
            cmdParms[9].Value = model.WeatherModelName;

            cmdParms[10].Value = model.PrecipitationRate;
            cmdParms[11].Value = model.WindSpeed;
            cmdParms[12].Value = model.AmbientTemperature;
            cmdParms[13].Value = model.MisDisOfRoad;
            cmdParms[14].Value = model.MTBF;
            cmdParms[15].Value = model.ObservingTime;
            cmdParms[16].Value = model.UsingState;
            cmdParms[17].Value = model.FalutState;
            cmdParms[18].Value = model.ResourceConsuming;
            cmdParms[19].Value = model.CurrentMemory;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }
        /// <summary>
        /// 根据平台编号删除一条传感器记录
        /// </summary>
        /// <param name="SensorID"></param>
        /// <returns></returns>
        public int Delete(decimal PLATFORM_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Delete from STATE");
            strSql.Append(" Where PLATFORM_ID=@in_PLATFORM_ID");
            SqlParameter[] cmdParms = new SqlParameter[]{
                new SqlParameter("@in_PLATFORM_ID",SqlDbType.Decimal)
            };
            cmdParms[0].Value = PLATFORM_ID;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }
        /// <summary>
        /// 根据平台ID判断是否存在该记录
        /// </summary>
        /// <param name="SensorID"></param>
        /// <returns></returns>
        public bool Exists(string PLATFORM_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select count(1) from STATE ");
            strSql.Append(" Where PLATFORM_ID=" + PLATFORM_ID);
            return DbHelperSQL.Exists(strSql.ToString());
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="SensorID"></param>
        /// <returns></returns>
        public Model.STATE GetModel(decimal PLATFORM_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from STATE ");
            strSql.Append(" Where PLATFORM_ID=" + PLATFORM_ID);
            Model.STATE model = null;
            
            //数据库连接
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(strSql.ToString(), connection);

            connection.Open();
            SqlDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            using(DbDataReader dr=myReader)
            {
                while (dr.Read())
                {
                    model = GetModel(dr);//本类中的重载函数
                }
                return model;
            }
        }
        /// <summary>
        /// 获取泛型数据列表
        /// </summary>
        /// <param name="whereClause"></param>
        /// <returns></returns>
        public List<Model.STATE> GetList(string whereClause)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * From STATE ");
            strSql.Append(" Where " + whereClause);
            //数据库连接
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(strSql.ToString(), connection);

            connection.Open();
            SqlDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            
            using(DbDataReader dr=myReader)
            {
                List<CoScheduling.Core.Model.STATE> lst = GetList(dr);
                dr.Close();
                return lst;
            }
        }
        /// <summary>
        /// 获取全部记录
        /// </summary>
        /// <returns></returns>
        public List<CoScheduling.Core.Model.STATE> GetList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * From STATE order by PLATFORM_ID desc");
            //数据库连接
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(strSql.ToString(), connection);

            connection.Open();
            SqlDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            
            using (DbDataReader dr=myReader)
            {

                List<CoScheduling.Core.Model.STATE> lst = GetList(dr);
                dr.Close();
                return lst;
            }
        }
        /// <summary>
        /// 获得数据列表，sql执行语句需要修改
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetListTable(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * ");
            strSql.Append(" FROM STATE ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ORDER BY PLATFORM_ID");
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }
        /// <summary>
        /// 根据条件获取DataSet数据列表,sql执行语句需要修改
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetListDataSet(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * ");
            strSql.Append(" FROM STATE ");
            if (strWhere.Trim() != "")
            {
                strSql.Append("WHERE " + strWhere);
            }
            strSql.Append(" ORDER BY PLATFORM_ID");
            DataSet dsSat = new DataSet();
            SqlDataAdapter odaSat = new SqlDataAdapter(strSql.ToString(), connectionString);
            if (dsSat.Tables["STATE"] != null)
            {
                dsSat.Tables["STATE"].Clear();
            }

            odaSat.Fill(dsSat, "STATE");

            return dsSat;
        }

        #region-------- 私有方法，通常情况下无需修改 --------
        /// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private Model.STATE GetModel(DbDataReader dr)
        {
            CoScheduling.Core.Model.STATE model = new CoScheduling.Core.Model.STATE();
            model.PLATFORM_ID = Convert.ToDecimal(dr["PLATFORM_ID"]);
            model.TimeReference = Convert.ToString(dr["TimeReference"]);
            model.SpaceReference = Convert.ToString(dr["SpaceReference"]);
            model.Longitude = Convert.ToDecimal(dr["Longitude"]);
            model.Latitude = Convert.ToDecimal(dr["Latitude"]);
            model.Elevation = Convert.ToDecimal(dr["Elevation"]);
            model.SlewAngle = Convert.ToDecimal(dr["SlewAngle"]);
            model.PLATFORM_TIME = Convert.ToDateTime(dr["PLATFORM_TIME"]);
            model.CloudCover = Convert.ToDecimal(dr["CloudCover"]);
            model.WeatherModelName = Convert.ToString(dr["WeatherModelName"]);

            model.PrecipitationRate = Convert.ToDecimal(dr["PrecipitationRate"]);
            model.WindSpeed = Convert.ToDecimal(dr["WindSpeed"]);
            model.AmbientTemperature = Convert.ToDecimal(dr["AmbientTemperature"]);
            model.MisDisOfRoad = Convert.ToDecimal(dr["MisDisOfRoad"]);
            model.MTBF = Convert.ToDecimal(dr["MTBF"]);
            model.ObservingTime = Convert.ToDecimal(dr["ObservingTime"]);
            model.UsingState = Convert.ToBoolean(dr["UsingState"]);
            model.FalutState = Convert.ToBoolean(dr["FalutState"]);
            model.ResourceConsuming = Convert.ToDecimal(dr["ResourceConsuming"]);
            model.CurrentMemory = Convert.ToDecimal(dr["CurrentMemory"]);

            return model;

        }
        private List<Model.STATE> GetList(DbDataReader dr)
        {
            List<Model.STATE> lst = new List<Model.STATE>();
            while (dr.Read())
            {
                lst.Add(GetModel(dr));
            }
            return lst;
        }
        #endregion



    }
}
