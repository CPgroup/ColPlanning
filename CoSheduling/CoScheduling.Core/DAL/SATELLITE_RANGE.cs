//----------------------------------------------------------------------------
//创建标识：李佳霖
// 创建描述: 卫星平台访问类
// 创建时间:2017.4.6
// 文件版本:1.0
// 功能描述:卫星平台数据表的管理，查询
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
    //卫星平台访问类
    public class SATELLITE_RANGE
    {
        //数据库连接字符串(web.config来配置)，可以动态更改connectionString支持多数据库.		
        public static string connectionString;
        public SATELLITE_RANGE()
        {
            connectionString =  @"server=(local);database=CoMonitoring; User=sa; Password=lhf2017 ";//建立的时候就确定了，连接数据库的路径
        }
        /// <summary>
        /// 卫星平台数据添加函数,添加删除和管理的数据库连接还存在问题
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Model.SATELLITE_RANGE model)
        {
        
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO SATELLITE_RANGE(");
            strSql.Append("PLATFORM_ID,PLATFORM_NAME,NumberOfSensor,LaunchTime,EolTime,OrbitClass,OrbitType,LongitudeOfGEO,Epoch,Period,");
            strSql.Append("Apogee,Perigee,Inclination,RightAscension,Eccentricity,ArgumentOfPericenter,MeanAnomaly,");
            strSql.Append("MeanMotion,RevolutionNumber,MaxSlewAngle,MinSlewAngle,AngularVelocity,AngularAcceleration,MAXGSD,");
            strSql.Append(" MAXSW,SAT_COSPAR,SAT_COUNTRY,SAT_CHARTER)");
            strSql.Append(" Values(");
            strSql.Append("@in_PLATFORM_ID,@in_PLATFORM_NAME,@in_NumberOfSensor,@in_LaunchTime,@in_EolTime,@in_OrbitClass,@in_OrbitType,@in_LongitudeOfGEO,@in_Epoch,@in_Period,");
            strSql.Append("@in_Apogee,@in_Perigee,@in_Inclination,@in_RightAscension,@in_Eccentricity,@in_ArgumentOfPericenter,");
            strSql.Append("@in_MeanAnomaly,@in_MeanMotion,@in_RevolutionNumber,@in_MaxSlewAngle,@in_MinSlewAngle,@in_AngularVelocity,@in_AngularAcceleration, ");
            strSql.Append("@in_MAXGSD,@in_MAXSW,@in_SAT_COSPAR,@in_SAT_COUNTRY,@in_SAT_CHARTER)");
            SqlParameter[] cmdParms = new SqlParameter[]{
                new SqlParameter("@in_PLATFORM_ID", SqlDbType.Decimal),
                new SqlParameter("@in_PLATFORM_NAME", SqlDbType.NVarChar),
                new SqlParameter("@in_NumberOfSensor", SqlDbType.Decimal),
                new SqlParameter("@in_LaunchTime", SqlDbType.DateTime),
                new SqlParameter("@in_EolTime", SqlDbType.Date),
                new SqlParameter("@in_OrbitClass", SqlDbType.NVarChar),
                new SqlParameter("@in_OrbitType", SqlDbType.NVarChar),
                new SqlParameter("@in_LongitudeOfGEO", SqlDbType.Decimal),
                new SqlParameter("@in_Epoch", SqlDbType.Decimal),
                new SqlParameter("@in_Period", SqlDbType.Decimal),
                new SqlParameter("@in_Apogee", SqlDbType.Decimal),
                new SqlParameter("@in_Perigee", SqlDbType.Decimal),
                new SqlParameter("@in_Inclination", SqlDbType.Decimal),
                new SqlParameter("@in_RightAscension", SqlDbType.Decimal),
                new SqlParameter("@in_Eccentricity", SqlDbType.Decimal),
                new SqlParameter("@in_ArgumentOfPericenter", SqlDbType.Decimal),
                new SqlParameter("@in_MeanAnomaly", SqlDbType.Decimal),
                new SqlParameter("@in_MeanMotion", SqlDbType.Decimal),
                new SqlParameter("@in_RevolutionNumber", SqlDbType.Decimal),
                new SqlParameter("@in_MaxSlewAngle", SqlDbType.Decimal),
                new SqlParameter("@in_MinSlewAngle", SqlDbType.Decimal),
                new SqlParameter("@in_AngularVelocity", SqlDbType.Decimal),
                new SqlParameter("@in_AngularAcceleration", SqlDbType.Decimal),
                new SqlParameter("@in_MAXGSD", SqlDbType.Decimal),
                new SqlParameter("@in_MAXSW", SqlDbType.Decimal),
                new SqlParameter("@in_SAT_COSPAR", SqlDbType.Decimal),
                new SqlParameter("@in_SAT_COUNTRY", SqlDbType.NVarChar),
                new SqlParameter("@in_SAT_CHARTER", SqlDbType.Decimal)};

            cmdParms[0].Value = model.PLATFORM_ID;
            cmdParms[1].Value = model.PLATFORM_NAME;
            cmdParms[2].Value = model.NumberOfSensor;
            cmdParms[3].Value = model.LaunchTime;
            cmdParms[4].Value = model.EolTime;
            cmdParms[5].Value = model.OrbitClass;
            cmdParms[6].Value = model.OrbitType;
            cmdParms[7].Value = model.LongitudeOfGEO;
            cmdParms[8].Value = model.Epoch;
            cmdParms[9].Value = model.Period;
            cmdParms[10].Value = model.Apogee;
            cmdParms[11].Value = model.Perigee;
            cmdParms[12].Value = model.Inclination;
            cmdParms[13].Value = model.RightAscension;
            cmdParms[14].Value = model.Eccentricity;
            cmdParms[15].Value = model.ArgumentOfPericenter;
            cmdParms[16].Value = model.MeanAnomaly;
            cmdParms[17].Value = model.MeanMotion;
            cmdParms[18].Value = model.RevolutionNumber;
            cmdParms[19].Value = model.MaxSlewAngle;
            cmdParms[20].Value = model.MinSlewAngle;
            cmdParms[21].Value = model.AngularVelocity;
            cmdParms[22].Value = model.AngularAcceleration;
            cmdParms[23].Value = model.MAXGSD;
            cmdParms[24].Value = model.MAXSW;
            cmdParms[25].Value = model.SAT_COSPAR;
            cmdParms[26].Value = model.SAT_COUNTRY;
            cmdParms[27].Value = model.SAT_CHARTER;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);//执行SQL语句，还需修改数据库连接的问题
        }

        /// <summary>
        /// 根据传感器ID修改数据库中的一条记录
        /// </summary>
        /// <param name="model"></param>第一类传感器实体类的实例
        /// <returns></returns>返回值为修改的记录数
        public int Update(Model.SATELLITE_RANGE model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update SATELLITE_RANGE set ");

            strSql.Append("PLATFORM_NAME=@in_PLATFORM_NAME,");
            strSql.Append("NumberOfSensor=@in_NumberOfSensor,");
            strSql.Append("LaunchTime=@in_LaunchTime,");
            strSql.Append("EolTime=@in_EolTime,");
            strSql.Append("OrbitClass=@in_OrbitClass,");
            strSql.Append("OrbitType=@in_OrbitType,");
            strSql.Append("LongitudeOfGEO=@in_LongitudeOfGEO,");
            strSql.Append("Epoch=@in_Epoch,");
            strSql.Append("Period=@in_Period,");

            strSql.Append("Apogee=@in_Apogee,");
            strSql.Append("Perigee=@in_Perigee,");
            strSql.Append("Inclination=@in_Inclination,");
            strSql.Append("RightAscension=@in_RightAscension,");
            strSql.Append("Eccentricity=@in_Eccentricity,");
            strSql.Append("ArgumentOfPericenter=@in_ArgumentOfPericenter,");
            strSql.Append("MeanAnomaly=@in_MeanAnomaly,");
            strSql.Append("MeanMotion=@in_MeanMotion,");
            strSql.Append("RevolutionNumber=@in_RevolutionNumber,");
            strSql.Append("MaxSlewAngle=@in_MaxSlewAngle,");
            strSql.Append("MinSlewAngle=@in_MinSlewAngle,");
            strSql.Append("AngularVelocity=@in_AngularVelocity,");
            strSql.Append("AngularAcceleration=@in_AngularAcceleration,");
            strSql.Append("MAXGSD=@in_MAXGSD,");
            strSql.Append("MAXSW=@in_MAXSW,");
            strSql.Append("SAT_COSPAR=@in_SAT_COSPAR,");
            strSql.Append("SAT_COUNTRY=@in_SAT_COUNTRY,");
            strSql.Append("SAT_CHARTER=@in_SAT_CHARTER");
            strSql.Append(" where PLATFORM_ID=@in_PLATFORM_ID");

            SqlParameter[] cmdParms = new SqlParameter[]{
                new SqlParameter("@in_PLATFORM_ID", SqlDbType.Decimal),
                new SqlParameter("@in_PLATFORM_NAME", SqlDbType.NVarChar),
                new SqlParameter("@in_NumberOfSensor", SqlDbType.Decimal),
                new SqlParameter("@in_LaunchTime", SqlDbType.DateTime),
                new SqlParameter("@in_EolTime", SqlDbType.Date),
                new SqlParameter("@in_OrbitClass", SqlDbType.NVarChar),
                new SqlParameter("@in_OrbitType", SqlDbType.NVarChar),
                new SqlParameter("@in_LongitudeOfGEO", SqlDbType.Decimal),
                new SqlParameter("@in_Epoch", SqlDbType.Decimal),
                new SqlParameter("@in_Period", SqlDbType.Decimal),
                new SqlParameter("@in_Apogee", SqlDbType.Decimal),
                new SqlParameter("@in_Perigee", SqlDbType.Decimal),
                new SqlParameter("@in_Inclination", SqlDbType.Decimal),
                new SqlParameter("@in_RightAscension", SqlDbType.Decimal),
                new SqlParameter("@in_Eccentricity", SqlDbType.Decimal),
                new SqlParameter("@in_ArgumentOfPericenter", SqlDbType.Decimal),
                new SqlParameter("@in_MeanAnomaly", SqlDbType.Decimal),
                new SqlParameter("@in_MeanMotion", SqlDbType.Decimal),
                new SqlParameter("@in_RevolutionNumber", SqlDbType.Decimal),
                new SqlParameter("@in_MaxSlewAngle", SqlDbType.Decimal),
                new SqlParameter("@in_MinSlewAngle", SqlDbType.Decimal),
                new SqlParameter("@in_AngularVelocity", SqlDbType.Decimal),
                new SqlParameter("@in_AngularAcceleration", SqlDbType.Decimal),
                new SqlParameter("@in_MAXGSD", SqlDbType.Decimal),
                new SqlParameter("@in_MAXSW", SqlDbType.Decimal),
                new SqlParameter("@in_SAT_COSPAR", SqlDbType.Decimal),
                new SqlParameter("@in_SAT_COUNTRY", SqlDbType.NVarChar),
                new SqlParameter("@in_SAT_CHARTER", SqlDbType.Decimal)};

            cmdParms[0].Value = model.PLATFORM_ID;
            cmdParms[1].Value = model.PLATFORM_NAME;
            cmdParms[2].Value = model.NumberOfSensor;
            cmdParms[3].Value = model.LaunchTime;
            cmdParms[4].Value = model.EolTime;
            cmdParms[5].Value = model.OrbitClass;
            cmdParms[6].Value = model.OrbitType;
            cmdParms[7].Value = model.LongitudeOfGEO;
            cmdParms[8].Value = model.Epoch;
            cmdParms[9].Value = model.Period;
            cmdParms[10].Value = model.Apogee;
            cmdParms[11].Value = model.Perigee;
            cmdParms[12].Value = model.Inclination;
            cmdParms[13].Value = model.RightAscension;
            cmdParms[14].Value = model.Eccentricity;
            cmdParms[15].Value = model.ArgumentOfPericenter;
            cmdParms[16].Value = model.MeanAnomaly;
            cmdParms[17].Value = model.MeanMotion;
            cmdParms[18].Value = model.RevolutionNumber;
            cmdParms[19].Value = model.MaxSlewAngle;
            cmdParms[20].Value = model.MinSlewAngle;
            cmdParms[21].Value = model.AngularVelocity;
            cmdParms[22].Value = model.AngularAcceleration;
            cmdParms[23].Value = model.MAXGSD;
            cmdParms[24].Value = model.MAXSW;
            cmdParms[25].Value = model.SAT_COSPAR;
            cmdParms[26].Value = model.SAT_COUNTRY;
            cmdParms[27].Value = model.SAT_CHARTER;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }
        /// <summary>
        /// 根据卫星平台编号删除一条卫星记录
        /// </summary>
        /// <param name="SensorID"></param>
        /// <returns></returns>
        public int Delete(decimal PLATFORM_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Delete from SATELLITE_RANGE");
            strSql.Append(" Where PLATFORM_ID=@in_PLATFORM_ID");
            SqlParameter[] cmdParms = new SqlParameter[]{
                new SqlParameter("@in_PLATFORM_ID",SqlDbType.Decimal)
            };
            cmdParms[0].Value = PLATFORM_ID;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }
        /// <summary>
        /// 根据卫星平台ID判断是否存在该记录
        /// </summary>
        /// <param name="SensorID"></param>
        /// <returns></returns>
        public bool Exists(string PLATFORM_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select count(1) from SATELLITE_RANGE ");
            strSql.Append(" Where PLATFORM_ID=" + PLATFORM_ID);
            return DbHelperSQL.Exists(strSql.ToString());
        }
        /// <summary>
        /// 根据平台ID，得到一个对象实体
        /// </summary>
        /// <param name="SensorID"></param>
        /// <returns></returns>
        public Model.SATELLITE_RANGE GetModel(decimal PLATFORM_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from SATELLITE_RANGE ");
            strSql.Append(" Where PLATFORM_ID=" + PLATFORM_ID);
            Model.SATELLITE_RANGE model = null;

            //数据库连接
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(strSql.ToString(), connection);

            connection.Open();
            SqlDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            using (DbDataReader dr = myReader)
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
        public List<Model.SATELLITE_RANGE> GetList(string whereClause)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * From SATELLITE_RANGE ");
            strSql.Append(" Where " + whereClause);
            //数据库连接
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(strSql.ToString(), connection);

            connection.Open();
            SqlDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            using (DbDataReader dr = myReader)
            {
                List<CoScheduling.Core.Model.SATELLITE_RANGE> lst = GetList(dr);
                dr.Close();
                return lst;
            }
        }
        /// <summary>
        /// 获取全部记录
        /// </summary>
        /// <returns></returns>
        public List<CoScheduling.Core.Model.SATELLITE_RANGE> GetList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * From SATELLITE_RANGE order by PLATFORM_ID desc");
            //数据库连接
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(strSql.ToString(), connection);

            connection.Open();
            SqlDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            using (DbDataReader dr = myReader)
            {
                List<CoScheduling.Core.Model.SATELLITE_RANGE> lst = GetList(dr);
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
            strSql.Append(" FROM SATELLITE_RANGE ");
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
            strSql.Append(" FROM SATELLITE_RANGE ");
            if (strWhere.Trim() != "")
            {
                strSql.Append("WHERE " + strWhere);
            }
            strSql.Append(" ORDER BY PLATFORM_ID");
            DataSet dsSat = new DataSet();
            SqlDataAdapter odaSat = new SqlDataAdapter(strSql.ToString(), connectionString);
            if (dsSat.Tables["SATELLITE_RANGE"] != null)
            {
                dsSat.Tables["SATELLITE_RANGE"].Clear();
            }

            odaSat.Fill(dsSat, "SATELLITE_RANGE");

            return dsSat;
        }
        /// <summary>
        /// 得到数据条数
        /// </summary>
        public int GetCount(string condition)
        {
            return DbHelperSQL.GetCount("SATELLITE_RANGE", condition);
        }

        #region-------- 私有方法，通常情况下无需修改 --------
        /// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private Model.SATELLITE_RANGE GetModel(DbDataReader dr)
        {
            CoScheduling.Core.Model.SATELLITE_RANGE model = new CoScheduling.Core.Model.SATELLITE_RANGE();
            model.PLATFORM_ID = Convert.ToDecimal(dr["PLATFORM_ID"]);
            model.PLATFORM_NAME = Convert.ToString(dr["PLATFORM_NAME"]);
            model.NumberOfSensor = Convert.ToDecimal(dr["NumberOfSensor"]);
            model.LaunchTime = Convert.ToDateTime(dr["LaunchTime"]);
            model.EolTime = Convert.ToDateTime(dr["EolTime"]);
            model.OrbitClass = Convert.ToString(dr["OrbitClass"]);
            model.OrbitType = Convert.ToString(dr["OrbitType"]);
            model.LongitudeOfGEO = Convert.ToDecimal(dr["LongitudeOfGEO"]);
            try
            {
                model.Epoch = Convert.ToDecimal(dr["Epoch"]);
            }
            catch
            {
                model.Epoch = Convert.ToDecimal("-1");
            }
            try
            {
                model.Period = Convert.ToDecimal(dr["Period"]);
            }
            catch
            {
                model.Period = Convert.ToDecimal("-1");
            }
            try
            {
                model.Apogee = Convert.ToDecimal(dr["Apogee"]);
            }
            catch
            {
                model.Apogee = Convert.ToDecimal("-1");
            }
            try
            {
                model.Perigee = Convert.ToDecimal(dr["Perigee"]);
            }
            catch
            {
                model.Perigee = Convert.ToDecimal("-1");
            }
            try
            {
                model.Inclination = Convert.ToDecimal(dr["Inclination"]);
            }
            catch
            {
                model.Inclination = Convert.ToDecimal("-1");
            }
            try
            {
                model.RightAscension = Convert.ToDecimal(dr["RightAscension"]);
            }
            catch
            {
                model.RightAscension = Convert.ToDecimal("-1");
            }
            try
            {
                model.Eccentricity = Convert.ToDecimal(dr["Eccentricity"]);
            }
            catch
            {
                model.Eccentricity = Convert.ToDecimal("-1");
            }
            try
            {
                model.ArgumentOfPericenter = Convert.ToDecimal(dr["ArgumentOfPericenter"]);
            }
            catch
            {
                model.ArgumentOfPericenter = Convert.ToDecimal("-1");
            }
            try
            {
                model.MeanAnomaly = Convert.ToDecimal(dr["MeanAnomaly"]);
            }
            catch
            {
                model.MeanAnomaly = Convert.ToDecimal("-1");
            }
            try
            {
                model.MeanMotion = Convert.ToDecimal(dr["MeanMotion"]);
            }
            catch
            {
                model.MeanMotion = Convert.ToDecimal("-1");
            }
            try
            {
                model.RevolutionNumber = Convert.ToDecimal(dr["RevolutionNumber"]);
            }
            catch
            {
                model.RevolutionNumber = Convert.ToDecimal("-1");
            }
            try
            {
                model.MaxSlewAngle = Convert.ToDecimal(dr["MaxSlewAngle"]);
            }
            catch
            {
                model.MaxSlewAngle = Convert.ToDecimal("-1");
            }

            try
            {
                model.MinSlewAngle = Convert.ToDecimal(dr["MinSlewAngle"]);
            }
            catch
            {
                model.MinSlewAngle = Convert.ToDecimal("-1");
            }
            try
            {
                model.AngularVelocity = Convert.ToDecimal(dr["AngularVelocity"]);
            }
            catch
            {
                model.AngularVelocity = Convert.ToDecimal("-1");
            }
            try
            {
                model.AngularAcceleration = Convert.ToDecimal(dr["AngularAcceleration"]);
            }
            catch
            {
                model.AngularAcceleration = Convert.ToDecimal("-1");
            }
            try
            {
                model.MAXGSD = Convert.ToDecimal(dr["MAXGSD"]);
            }
            catch
            {
                model.MAXGSD = Convert.ToDecimal("-1");
            }
            try
            {
                model.MAXSW = Convert.ToDecimal(dr["MAXSW"]);
            }
            catch
            {
                model.MAXSW = Convert.ToDecimal("-1");
            }
            model.SAT_COSPAR = Convert.ToString(dr["SAT_COSPAR"]);
            model.SAT_COUNTRY = Convert.ToString(dr["SAT_COUNTRY"]);
            model.SAT_CHARTER = Convert.ToDecimal(dr["SAT_CHARTER"]);
            
            return model;
        }
        private List<Model.SATELLITE_RANGE> GetList(DbDataReader dr)
        {
            List<Model.SATELLITE_RANGE> lst = new List<Model.SATELLITE_RANGE>();
            while (dr.Read())
            {
                lst.Add(GetModel(dr));
            }
            return lst;
        }
        #endregion




    }
}
