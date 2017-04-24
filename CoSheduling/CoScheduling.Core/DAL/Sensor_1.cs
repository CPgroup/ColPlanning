//------------------------------------------------------------------------------
// 创建标识: 李佳霖
// 创建描述: 第一类传感器的数据库访问类（卫星，无人机，飞艇，地面测量车）
// 创建时间:2017.3.28
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
    public class Sensor_1
    {
        //数据库连接字符串(web.config来配置)，可以动态更改connectionString支持多数据库.		
        public static string connectionString;
        public Sensor_1()
        {
            connectionString =  @"server=(local);database=CoMonitoring; User=sa; Password=123 ";//建立的时候就确定了，连接数据库的路径
        }
        /// <summary>
        /// 第一类传感器添加函数,添加删除和管理的数据库连接还存在问题
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Model.Sensor_1 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO SENSOR_1(");
            strSql.Append("SensorID,SensorName,SensorType,BandNumber,BandCenter,LookAngle,SwathVelocity,SwathWidth,GeometryResolution,PLATFORM_ID,");
            strSql.Append("Application,Inclination,PixelPerLine,SquintAngle,AzimuthDirectionResolution,DistanceResolution,MaxSlewTimesPerCircle,");
            strSql.Append("MaxPowerOnTimesPerDay,MinImagingTimeNonInterupt,DuringSwitch,MaxObvDur,MinObvDur,MAXGSD)");
            strSql.Append(" Values(");
            strSql.Append("@in_SensorID,@in_SensorName,@in_SensorType,@in_BandNumber,@in_BandCenter,@in_LookAngle,@in_SwathVelocity,@in_SwathWidth,@in_GeometryResolution,@in_PLATFORM_ID,");
            strSql.Append("@in_Application,@in_Inclination,@in_PixelPerLine,@in_SquintAngle,@in_AzimuthDirectionResolution,@in_DistanceResolution,");
            strSql.Append("@in_MaxSlewTimesPerCircle,@in_MaxPowerOnTimesPerDay,@in_MinImagingTimeNonInterupt,@in_DuringSwitch,@in_MaxObvDur,@in_MinObvDur,@in_MAXGSD)");
            SqlParameter[] cmdParms = new SqlParameter[]{
                new SqlParameter("@in_SensorID", SqlDbType.Decimal),
                new SqlParameter("@in_SensorName", SqlDbType.NVarChar),
                new SqlParameter("@in_SensorType", SqlDbType.NVarChar),
                new SqlParameter("@in_BandNumber", SqlDbType.Decimal),
                new SqlParameter("@in_BandCenter", SqlDbType.Decimal),
                new SqlParameter("@in_LookAngle", SqlDbType.Decimal),
                new SqlParameter("@in_SwathVelocity", SqlDbType.Decimal),
                new SqlParameter("@in_SwathWidth", SqlDbType.Decimal),
                new SqlParameter("@in_GeometryResolution", SqlDbType.Decimal),
                new SqlParameter("@in_PLATFORM_ID", SqlDbType.Decimal),

                new SqlParameter("@in_Application", SqlDbType.NVarChar),
                new SqlParameter("@in_Inclination", SqlDbType.Decimal),
                new SqlParameter("@in_PixelPerLine", SqlDbType.Decimal),
                new SqlParameter("@in_SquintAngle", SqlDbType.Decimal),
                new SqlParameter("@in_AzimuthDirectionResolution", SqlDbType.Decimal),
                new SqlParameter("@in_DistanceResolution", SqlDbType.Decimal),
                new SqlParameter("@in_MaxSlewTimesPerCircle", SqlDbType.Decimal),
                new SqlParameter("@in_MaxPowerOnTimesPerDay", SqlDbType.Decimal),
                new SqlParameter("@in_MinImagingTimeNonInterupt", SqlDbType.Decimal),
                new SqlParameter("@in_DuringSwitch", SqlDbType.Decimal),
                new SqlParameter("@in_MaxObvDur", SqlDbType.Decimal),
                new SqlParameter("@in_MinObvDur", SqlDbType.Decimal),
                new SqlParameter("@in_MAXGSD", SqlDbType.Decimal)};

            cmdParms[0].Value = model.SensorID;
            cmdParms[1].Value = model.SensorName;
            cmdParms[2].Value = model.SensorType;
            cmdParms[3].Value = model.BandNumber;
            cmdParms[4].Value = model.BandCenter;
            cmdParms[5].Value = model.LookAngle;
            cmdParms[6].Value = model.SwathVelocity;
            cmdParms[7].Value = model.SwathWidth;
            cmdParms[8].Value = model.GeometryResolution;
            cmdParms[9].Value = model.PLATFORM_ID;

            cmdParms[10].Value = model.Application;
            cmdParms[11].Value = model.Inclination;
            cmdParms[12].Value = model.PixelPerLine;
            cmdParms[13].Value = model.SquintAngle;
            cmdParms[14].Value = model.AzimuthDirectionResolution;
            cmdParms[15].Value = model.DistanceResolution;
            cmdParms[16].Value = model.MaxSlewTimesPerCircle;
            cmdParms[17].Value = model.MaxPowerOnTimesPerDay;
            cmdParms[18].Value = model.MinImagingTimeNonInterupt;
            cmdParms[19].Value = model.DuringSwitch;
            cmdParms[20].Value = model.MaxObvDur;
            cmdParms[21].Value = model.MinObvDur;
            cmdParms[22].Value = model.MAXGSD;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);//执行SQL语句，还需修改数据库连接的问题
        }
        /// <summary>
        /// 根据传感器ID修改数据库中的一条记录
        /// </summary>
        /// <param name="model"></param>第一类传感器实体类的实例
        /// <returns></returns>返回值为修改的记录数
        public int Update(Model.Sensor_1 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update SENSOR_1 set ");

            strSql.Append("SensorName=@in_SensorName,");
            strSql.Append("SensorType=@in_SensorType,");
            strSql.Append("BandNumber=@in_BandNumber,");
            strSql.Append("BandCenter=@in_BandCenter,");
            strSql.Append("LookAngle=@in_LookAngle,");
            strSql.Append("SwathVelocity=@in_SwathVelocity,");
            strSql.Append("SwathWidth=@in_SwathWidth,");
            strSql.Append("GeometryResolution=@in_GeometryResolution,");
            strSql.Append("PLATFORM_ID=@in_PLATFORM_ID,");

            strSql.Append("Application=@in_Application,");
            strSql.Append("Inclination=@in_Inclination,");
            strSql.Append("PixelPerLine=@in_PixelPerLine,");
            strSql.Append("SquintAngle=@in_SquintAngle,");
            strSql.Append("AzimuthDirectionResolution=@in_AzimuthDirectionResolution,");
            strSql.Append("DistanceResolution=@in_DistanceResolution,");
            strSql.Append("MaxSlewTimesPerCircle=@in_MaxSlewTimesPerCircle,");
            strSql.Append("MaxPowerOnTimesPerDay=@in_MaxPowerOnTimesPerDay,");
            strSql.Append("MinImagingTimeNonInterupt=@in_MinImagingTimeNonInterupt,");
            strSql.Append("DuringSwitch=@in_DuringSwitch,");
            strSql.Append("MaxObvDur=@in_MaxObvDur,");
            strSql.Append("MinObvDur=@in_MinObvDur,");
            strSql.Append("MAXGSD=@in_MAXGSD");
            strSql.Append(" where SensorID=@in_SensorID");

            SqlParameter[] cmdParms = new SqlParameter[]{
                new SqlParameter("@in_SensorID", SqlDbType.Decimal),
                new SqlParameter("@in_SensorName", SqlDbType.NVarChar),
                new SqlParameter("@in_SensorType", SqlDbType.NVarChar),
                new SqlParameter("@in_BandNumber", SqlDbType.Decimal),
                new SqlParameter("@in_BandCenter", SqlDbType.Decimal),
                new SqlParameter("@in_LookAngle", SqlDbType.Decimal),
                new SqlParameter("@in_SwathVelocity", SqlDbType.Decimal),
                new SqlParameter("@in_SwathWidth", SqlDbType.Decimal),
                new SqlParameter("@in_GeometryResolution", SqlDbType.Decimal),
                new SqlParameter("@in_PLATFORM_ID", SqlDbType.Decimal),

                new SqlParameter("@in_Application", SqlDbType.NVarChar),
                new SqlParameter("@in_Inclination", SqlDbType.Decimal),
                new SqlParameter("@in_PixelPerLine", SqlDbType.Decimal),
                new SqlParameter("@in_SquintAngle", SqlDbType.Decimal),
                new SqlParameter("@in_AzimuthDirectionResolution", SqlDbType.Decimal),
                new SqlParameter("@in_DistanceResolution", SqlDbType.Decimal),
                new SqlParameter("@in_MaxSlewTimesPerCircle", SqlDbType.Decimal),
                new SqlParameter("@in_MaxPowerOnTimesPerDay", SqlDbType.Decimal),
                new SqlParameter("@in_MinImagingTimeNonInterupt", SqlDbType.Decimal),
                new SqlParameter("@in_DuringSwitch", SqlDbType.Decimal),
                new SqlParameter("@in_MaxObvDur", SqlDbType.Decimal),
                new SqlParameter("@in_MinObvDur", SqlDbType.Decimal),
                new SqlParameter("@in_MAXGSD", SqlDbType.Decimal)
            };

            cmdParms[0].Value = model.SensorID;
            cmdParms[1].Value = model.SensorName;
            cmdParms[2].Value = model.SensorType;
            cmdParms[3].Value = model.BandNumber;
            cmdParms[4].Value = model.BandCenter;
            cmdParms[5].Value = model.LookAngle;
            cmdParms[6].Value = model.SwathVelocity;
            cmdParms[7].Value = model.SwathWidth;
            cmdParms[8].Value = model.GeometryResolution;
            cmdParms[9].Value = model.PLATFORM_ID;

            cmdParms[10].Value = model.Application;
            cmdParms[11].Value = model.Inclination;
            cmdParms[12].Value = model.PixelPerLine;
            cmdParms[13].Value = model.SquintAngle;
            cmdParms[14].Value = model.AzimuthDirectionResolution;
            cmdParms[15].Value = model.DistanceResolution;
            cmdParms[16].Value = model.MaxSlewTimesPerCircle;
            cmdParms[17].Value = model.MaxPowerOnTimesPerDay;
            cmdParms[18].Value = model.MinImagingTimeNonInterupt;
            cmdParms[19].Value = model.DuringSwitch;
            cmdParms[20].Value = model.MaxObvDur;
            cmdParms[21].Value = model.MinObvDur;
            cmdParms[22].Value = model.MAXGSD;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }
        /// <summary>
        /// 根据传感器编号删除一条传感器记录
        /// </summary>
        /// <param name="SensorID"></param>
        /// <returns></returns>
        public int Delete(decimal SensorID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Delete from SENSOR_1");
            strSql.Append(" Where SensorID=@in_SensorID");
            SqlParameter[] cmdParms = new SqlParameter[]{
                new SqlParameter("@in_SensorID",SqlDbType.Decimal)
            };
            cmdParms[0].Value = SensorID;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }
        /// <summary>
        /// 根据传感器ID判断是否存在该记录
        /// </summary>
        /// <param name="SensorID"></param>
        /// <returns></returns>
        public bool Exists(string SensorID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select count(1) from SENSOR_1 ");
            strSql.Append(" Where SensorID=" + SensorID);
            return DbHelperSQL.Exists(strSql.ToString());
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="SensorID"></param>
        /// <returns></returns>
        public Model.Sensor_1 GetModel(decimal SensorID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from SENSOR_1 ");
            strSql.Append(" Where SensorID=" + SensorID);
            Model.Sensor_1 model = null;
            
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
        public List<Model.Sensor_1> GetList(string whereClause)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * From SENSOR_1 ");
            strSql.Append(" Where " + whereClause);
            //数据库连接
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(strSql.ToString(), connection);

            connection.Open();
            SqlDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            
            using(DbDataReader dr=myReader)
            {
                List<CoScheduling.Core.Model.Sensor_1> lst = GetList(dr);
                dr.Close();
                return lst;
            }
        }
        /// <summary>
        /// 获取全部记录
        /// </summary>
        /// <returns></returns>
        public List<CoScheduling.Core.Model.Sensor_1> GetList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * From SENSOR_1 order by SensorID desc");
            //数据库连接
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(strSql.ToString(), connection);

            connection.Open();
            SqlDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            
            using (DbDataReader dr=myReader)
            {
                List<CoScheduling.Core.Model.Sensor_1> lst = GetList(dr);
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
            strSql.Append(" FROM SENSOR_1 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ORDER BY SensorID");
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
            strSql.Append(" FROM Sensor_1 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append("WHERE " + strWhere);
            }
            strSql.Append(" ORDER BY SensorID");
            DataSet dsSat = new DataSet();
            SqlDataAdapter odaSat = new SqlDataAdapter(strSql.ToString(), connectionString);
            if (dsSat.Tables["SENSOR_1"] != null)
            {
                dsSat.Tables["SENSOR_1"].Clear();
            }

            odaSat.Fill(dsSat, "SENSOR_1");

            return dsSat;
        }
        /// <summary>
        /// 根据PLATFORM_ID删除数据
        /// </summary>
        public void DeleteByPLATFORMID(string PLATFORM_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SENSOR_1 ");
            strSql.Append(" where PLATFORM_ID=" + PLATFORM_ID);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 根据SAT_ID获取最新载荷ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public decimal GetSensorID(string platform_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select max(SensorID) from SENSOR_1 ");
            strSql.Append(" where PLATFORM_ID=" + platform_id);
            if (DbHelperSQL.GetSingle(strSql.ToString()) == null)
            {
                return Convert.ToDecimal(platform_id.ToString() + "01");
            }
            else
            {
                return Convert.ToDecimal(DbHelperSQL.GetSingle(strSql.ToString())) + 1;
            }
        }


        #region-------- 私有方法，通常情况下无需修改 --------
        /// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private Model.Sensor_1 GetModel(DbDataReader dr)
        {
            CoScheduling.Core.Model.Sensor_1 model = new CoScheduling.Core.Model.Sensor_1();
            model.SensorID = Convert.ToDecimal(dr["SensorID"]);
            try
            {
                model.SensorName = Convert.ToString(dr["SensorName"]);
            }
            catch
            {
                model.SensorName = Convert.ToString("N/A");
            }
            model.SensorType = Convert.ToString(dr["SensorType"]);
            try
            {
                model.BandNumber = Convert.ToDecimal(dr["BandNumber"]);
            }
            catch
            {
                model.BandNumber = Convert.ToDecimal("-1");
            }
            try
            {
                model.BandCenter = Convert.ToDecimal(dr["BandCenter"]);
            }
            catch
            {
                model.BandCenter = Convert.ToDecimal("-1");
            }
            try
            {
                model.LookAngle = Convert.ToDecimal(dr["LookAngle"]);
            }
            catch
            {
                model.LookAngle = Convert.ToDecimal("-1");
            }
            try
            {
                model.SwathVelocity = Convert.ToDecimal(dr["SwathVelocity"]);
            }
            catch
            {
                model.SwathVelocity = Convert.ToDecimal("-1");
            }
            try
            {
                model.SwathWidth = Convert.ToDecimal(dr["SwathWidth"]);
            }
            catch
            {
                model.SwathWidth = Convert.ToDecimal("-1");
            }
            try
            {
                model.GeometryResolution = Convert.ToDecimal(dr["GeometryResolution"]);
            }
            catch
            {
                model.GeometryResolution = Convert.ToDecimal("-1");
            }
            model.PLATFORM_ID = Convert.ToDecimal(dr["PLATFORM_ID"]);
            try
            {
                model.Application = Convert.ToString(dr["Application"]);
            }
            catch
            {
                model.Application = Convert.ToString("N/A");
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
                model.PixelPerLine = Convert.ToDecimal(dr["PixelPerLine"]);
            }
            catch
            {
                model.PixelPerLine = Convert.ToDecimal("-1");
            }
            try
            {
                model.SquintAngle = Convert.ToDecimal(dr["SquintAngle"]);
            }
            catch
            {
                model.SquintAngle = Convert.ToDecimal("-1");
            }
            try
            {
                model.AzimuthDirectionResolution = Convert.ToDecimal(dr["AzimuthDirectionResolution"]);
            }
            catch
            {
                model.AzimuthDirectionResolution = Convert.ToDecimal("-1");
            }
            try
            {
                model.DistanceResolution = Convert.ToDecimal(dr["DistanceResolution"]);
            }
            catch
            {
                model.DistanceResolution = Convert.ToDecimal("-1");
            }
            try
            {
                model.MaxSlewTimesPerCircle = Convert.ToDecimal(dr["MaxSlewTimesPerCircle"]);
            }
            catch
            {
                model.MaxSlewTimesPerCircle = Convert.ToDecimal("-1");
            }
            try
            {
                model.MaxPowerOnTimesPerDay = Convert.ToDecimal(dr["MaxPowerOnTimesPerDay"]);
            }
            catch
            {
                model.MaxPowerOnTimesPerDay = Convert.ToDecimal("-1");
            }
            try
            {
                model.MinImagingTimeNonInterupt = Convert.ToDecimal(dr["MinImagingTimeNonInterupt"]);
            }
            catch
            {
                model.MinImagingTimeNonInterupt = Convert.ToDecimal("-1");
            }
            try
            {
                model.DuringSwitch = Convert.ToDecimal(dr["DuringSwith"]);
            }
            catch
            {
                model.DuringSwitch = Convert.ToDecimal("-1");
            }
            try
            {
                model.MaxObvDur = Convert.ToDecimal(dr["MaxObvDur"]);
            }
            catch
            {
                model.MaxObvDur = Convert.ToDecimal("-1");
            }
            try
            {
                model.MinObvDur = Convert.ToDecimal(dr["MinObvDur"]);
            }
            catch
            {
                model.MinObvDur = Convert.ToDecimal("-1");
            }
            try
            {
                model.MAXGSD = Convert.ToDecimal(dr["MAXGSD"]);
            }
            catch
            {
                model.MAXGSD = Convert.ToDecimal("-1");
            }
            return model;

        }
        private List<Model.Sensor_1> GetList(DbDataReader dr)
        {
            List<Model.Sensor_1> lst = new List<Model.Sensor_1>();
            while (dr.Read())
            {
                lst.Add(GetModel(dr));
            }
            return lst;
        }
        #endregion
    }
}
