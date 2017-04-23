//------------------------------------------------------------------------------
// 创建标识: 李佳霖
// 创建描述: 传感器波段实体类（精细到可见光、近红外）
// 创建时间:2017.4.4
// 文件版本:1.0
// 功能描述: 传感器波段的实体类，描述传感器波段的各项属性，包括成员变量和构造函数
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
    public class Sensor_Band_Mode
    {
        //数据库连接字符串(web.config来配置)，可以动态更改connectionString支持多数据库.		
        public static string connectionString;
        public Sensor_Band_Mode()
        {
            connectionString =  @"server=(local);database=CoMonitoring; User=sa; Password=lhf2017 ";//建立的时候就确定了，连接数据库的路径
        }
        /// <summary>
        /// 传感器波段添加函数,添加删除和管理的数据库连接还存在问题
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Model.Sensor_Band_Mode model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Insert into SENSOR_BAND_MODE(");
            strSql.Append("BandID,BAND_MODE_NAME,BandType,SensorID,SensorName,");
            strSql.Append("PLATFORM_ID,PLATFORM_NAME,SwathWidth,BandWidth,BandCenter,");
            strSql.Append("SpectralRangeMin,SpectralRangeMax,PolarizationMode,SNRRatio,");
            strSql.Append("PixelPerLine,GeometryResolution,AzimuthDirectionResolution,DistanceResolution)");
            strSql.Append(" Values(");
            strSql.Append("@in_BandID,@in_BAND_MODE_NAME,@in_BandType,@in_SensorID,@in_SensorName,@in_PLATFORM_ID,@in_PLATFORM_NAME,@in_SwathWidth,@in_BandWidth,@in_BandCenter,");
            strSql.Append("@in_SpectralRangeMin,@in_SpectralRangeMax,@in_PolarizationMode,@in_SNRRatio,@in_PixelPerLine,@in_GeometryResolution,@in_AzimuthDirectionResolution,@in_DistanceResolution)");
            SqlParameter[] cmdParms = new SqlParameter[]{
                new SqlParameter("@in_BandID", SqlDbType.Decimal),
                new SqlParameter("@in_BAND_MODE_NAME", SqlDbType.NVarChar),
                new SqlParameter("@in_BandType", SqlDbType.NVarChar),
                new SqlParameter("@in_SensorID", SqlDbType.Decimal),
                new SqlParameter("@in_SensorName", SqlDbType.NVarChar),
                new SqlParameter("@in_PLATFORM_ID", SqlDbType.Decimal),
                new SqlParameter("@in_PLATFORM_NAME", SqlDbType.NVarChar),
                new SqlParameter("@in_SwathWidth", SqlDbType.Decimal),
                new SqlParameter("@in_BandWidth", SqlDbType.Decimal),
                new SqlParameter("@in_BandCenter", SqlDbType.Decimal),
                new SqlParameter("@in_SpectralRangeMin", SqlDbType.Decimal),
                new SqlParameter("@in_SpectralRangeMax", SqlDbType.Decimal),
                new SqlParameter("@in_PolarizationMode", SqlDbType.NVarChar),
                new SqlParameter("@in_SNRRatio", SqlDbType.Decimal),
                new SqlParameter("@in_PixelPerLine", SqlDbType.Decimal),
                new SqlParameter("@in_GeometryResolution", SqlDbType.Decimal),
                new SqlParameter("@in_AzimuthDirectionResolution", SqlDbType.Decimal),
                new SqlParameter("@in_DistanceResolution", SqlDbType.Decimal) };

            cmdParms[0].Value = model.BandID;
            cmdParms[1].Value = model.BAND_MODE_NAME;
            cmdParms[2].Value = model.BandType;
            cmdParms[3].Value = model.SensorID;
            cmdParms[4].Value = model.SensorName;
            cmdParms[5].Value = model.PLATFORM_ID;
            cmdParms[6].Value = model.PLATFORM_NAME;
            cmdParms[7].Value = model.SwathWidth;
            cmdParms[8].Value = model.BandWidth;
            cmdParms[9].Value = model.BandCenter;

            cmdParms[10].Value = model.SpectralRangeMin;
            cmdParms[11].Value = model.SpectralRangeMax;
            cmdParms[12].Value = model.PolarizationMode;
            cmdParms[13].Value = model.SNRRatio;
            cmdParms[14].Value = model.PixelPerLine;
            cmdParms[15].Value = model.GeometryResolution;
            cmdParms[16].Value = model.AzimuthDirectionResolution;
            cmdParms[17].Value = model.DistanceResolution;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);//执行SQL语句，还需修改数据库连接的问题
        }

        /// <summary>
        /// 根据波段ID修改数据库中的一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Update(Model.Sensor_Band_Mode model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update SENSOR_BAND_MODE SET ");

            strSql.Append("BAND_MODE_NAME=@in_BAND_MODE_NAME,");
            strSql.Append("BandType=@in_BandType,");
            strSql.Append("SensorID=@in_SensorID,");
            strSql.Append("SensorName=@in_SensorName,");
            strSql.Append("PLATFORM_ID=@in_PLATFORM_ID,");
            strSql.Append("PLATFORM_NAME=@in_PLATFORM_NAME,");
            strSql.Append("SwathWidth=@in_SwathWidth,");
            strSql.Append("BandWidth=@in_BandWidth,");
            strSql.Append("BandCenter=@in_BandCenter,");

            strSql.Append("SpectralRangeMin=@in_SpectralRangeMin,");
            strSql.Append("SpectralRangeMax=@in_SpectralRangeMax,");
            strSql.Append("PolarizationMode=@in_PolarizationMode,");
            strSql.Append("SNRRatio=@in_SNRRatio,");
            strSql.Append("PixelPerLine=@in_PixelPerLine,");
            strSql.Append("GeometryResolution=@in_GeometryResolution,");
            strSql.Append("AzimuthDirectionResolution=@in_AzimuthDirectionResolution,");
            strSql.Append("DistanceResolution=@in_DistanceResolution");
            
            strSql.Append(" where BandID=@in_BandID");

            SqlParameter[] cmdParms = new SqlParameter[]{
                new SqlParameter("@in_BandID", SqlDbType.Decimal),
                new SqlParameter("@in_BAND_MODE_NAME", SqlDbType.NVarChar),
                new SqlParameter("@in_BandType", SqlDbType.NVarChar),
                new SqlParameter("@in_SensorID", SqlDbType.Decimal),
                new SqlParameter("@in_SensorName", SqlDbType.NVarChar),
                new SqlParameter("@in_PLATFORM_ID", SqlDbType.Decimal),
                new SqlParameter("@in_PLATFORM_NAME", SqlDbType.NVarChar),
                new SqlParameter("@in_SwathWidth", SqlDbType.Decimal),
                new SqlParameter("@in_BandWidth", SqlDbType.Decimal),
                new SqlParameter("@in_BandCenter", SqlDbType.Decimal),
                new SqlParameter("@in_SpectralRangeMin", SqlDbType.Decimal),
                new SqlParameter("@in_SpectralRangeMax", SqlDbType.Decimal),
                new SqlParameter("@in_PolarizationMode", SqlDbType.NVarChar),
                new SqlParameter("@in_SNRRatio", SqlDbType.Decimal),
                new SqlParameter("@in_PixelPerLine", SqlDbType.Decimal),
                new SqlParameter("@in_GeometryResolution", SqlDbType.Decimal),
                new SqlParameter("@in_AzimuthDirectionResolution", SqlDbType.Decimal),
                new SqlParameter("@in_DistanceResolution", SqlDbType.Decimal) };

            cmdParms[0].Value = model.BandID;
            cmdParms[1].Value = model.BAND_MODE_NAME;
            cmdParms[2].Value = model.BandType;
            cmdParms[3].Value = model.SensorID;
            cmdParms[4].Value = model.SensorName;
            cmdParms[5].Value = model.PLATFORM_ID;
            cmdParms[6].Value = model.PLATFORM_NAME;
            cmdParms[7].Value = model.SwathWidth;
            cmdParms[8].Value = model.BandWidth;
            cmdParms[9].Value = model.BandCenter;
            cmdParms[10].Value = model.SpectralRangeMin;
            cmdParms[11].Value = model.SpectralRangeMax;
            cmdParms[12].Value = model.PolarizationMode;
            cmdParms[13].Value = model.SNRRatio;
            cmdParms[14].Value = model.PixelPerLine;
            cmdParms[15].Value = model.GeometryResolution;
            cmdParms[16].Value = model.AzimuthDirectionResolution;
            cmdParms[17].Value = model.DistanceResolution;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }
        /// <summary>
        /// 根据传感器波段编号删除一条记录
        /// </summary>
        /// <param name="SensorID"></param>
        /// <returns></returns>
        public void Delete(string BandID,string PLATFORM_ID,string SENSOR_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Delete from SENSOR_BAND_MODE");
            strSql.Append(" Where PLATFORM_ID="+PLATFORM_ID);
            strSql.Append(" and SensorID=" + SENSOR_ID);
            strSql.Append(" and BandID=" + BandID);

            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 根据传感器波段ID判断是否存在该记录
        /// </summary>
        /// <param name="SensorID"></param>
        /// <returns></returns>
        public bool Exists(string BandID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select count(1) from SENSOR_BAND_MODE ");
            strSql.Append(" Where BandID=" + BandID);
            return DbHelperSQL.Exists(strSql.ToString());
        }
        /// <summary>
        /// 根据传感器波段编号获得一个对象实体
        /// </summary>
        /// <param name="SensorID"></param>
        /// <returns></returns>
        public Model.Sensor_Band_Mode GetModel(string platformid,string sensorid,string bandid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from SENSOR_BAND_MODE ");
            strSql.Append(" Where PLATFORM_ID=" + platformid);
            strSql.Append(" and SensorID=" + sensorid);
            strSql.Append(" and BandID=" + bandid);
            Model.Sensor_Band_Mode model = null;

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
        /// 获取泛类型数据列表
        /// </summary>
        /// <param name="whereClause"></param>
        /// <returns></returns>
        public List<Model.Sensor_Band_Mode> GetList(string whereClause)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * From SENSOR_BAND_MODE ");
            strSql.Append(" Where " + whereClause);
            //数据库连接
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(strSql.ToString(), connection);

            connection.Open();
            SqlDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            using (DbDataReader dr = myReader)
            {
                List<CoScheduling.Core.Model.Sensor_Band_Mode> lst = GetList(dr);
                dr.Close();
                return lst;
            }
        }
        /// <summary>
        /// 获取全部记录
        /// </summary>
        /// <returns></returns>
        public List<CoScheduling.Core.Model.Sensor_Band_Mode> GetList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * From SENSOR_BAND_MODE order by BandID desc");
            //数据库连接
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(strSql.ToString(), connection);

            connection.Open();
            SqlDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            using (DbDataReader dr = myReader)
            {
                List<CoScheduling.Core.Model.Sensor_Band_Mode> lst = GetList(dr);
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
            strSql.Append(" FROM SENSOR_BAND_MODE ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ORDER BY BandID");
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
            strSql.Append(" FROM SENSOR_BAND_MODE ");
            if (strWhere.Trim() != "")
            {
                strSql.Append("WHERE " + strWhere);
            }
            strSql.Append(" ORDER BY BandID");
            DataSet dsSat = new DataSet();
            SqlDataAdapter odaSat = new SqlDataAdapter(strSql.ToString(), connectionString);
            if (dsSat.Tables["SENSOR_BAND_MODE"] != null)
            {
                dsSat.Tables["SENSOR_BAND_MODE"].Clear();
            }

            odaSat.Fill(dsSat, "SENSOR_BAND_MODE");

            return dsSat;
        }

        /// <summary>
        /// 根据SensorID删除数据
        /// </summary>
        public void DeleteBySensorID(string SENSORID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete SENSOR_BAND_MODE");
            strSql.Append(" where SensorID=" + SENSORID);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 根据PLATFORM_ID删除数据
        /// </summary>
        public void DeleteByPLATFORMID(string PLATFORM_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete SENSOR_BAND_MODE");
            strSql.Append(" where PLATFORM_ID=" + PLATFORM_ID);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        #region-------- 私有方法，通常情况下无需修改 --------
        /// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private Model.Sensor_Band_Mode GetModel(DbDataReader dr)
        {
            CoScheduling.Core.Model.Sensor_Band_Mode model = new CoScheduling.Core.Model.Sensor_Band_Mode();
            model.BandID = Convert.ToDecimal(dr["BandID"]);
            model.BAND_MODE_NAME = Convert.ToString(dr["BAND_MODE_NAME"]);
            try
            {
                model.BandType = Convert.ToString(dr["BandType"]);
            }
            catch
            {
                model.BandType = Convert.ToString(dr["N/A"]);
            }
            
            model.SensorID = Convert.ToDecimal(dr["SensorID"]);
            model.SensorName = Convert.ToString(dr["SensorName"]);
            model.PLATFORM_ID = Convert.ToDecimal(dr["PLATFORM_ID"]);
            model.PLATFORM_NAME = Convert.ToString(dr["PLATFORM_NAME"]);
            model.SwathWidth = Convert.ToDecimal(dr["SwathWidth"]);
            try
            {
                model.BandWidth = Convert.ToDecimal(dr["BandWidth"]);
            }
            catch
            {
                model.BandWidth = Convert.ToDecimal("-1");
            }
            try
            {
                model.BandCenter = Convert.ToDecimal(dr["BandCenter"]);
            }
            catch
            {
                model.BandCenter = Convert.ToDecimal("-1");
            }
            
            model.SpectralRangeMin = Convert.ToDecimal(dr["SpectralRangeMin"]);
            model.SpectralRangeMax = Convert.ToDecimal(dr["SpectralRangeMax"]);
            try
            {
                model.PolarizationMode = Convert.ToString(dr["PolarizationMode"]);
            }
            catch
            {
                model.PolarizationMode = Convert.ToString("-1");
            }

            try
            {
                model.SNRRatio = Convert.ToDecimal(dr["SNRRatio"]);
            }
            catch
            {
                model.SNRRatio = Convert.ToDecimal("-1");
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
                model.GeometryResolution = Convert.ToDecimal(dr["GeometryResolution"]);
            }
            catch
            {
                model.GeometryResolution = Convert.ToDecimal("-1");
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
            return model;

        }
        private List<Model.Sensor_Band_Mode> GetList(DbDataReader dr)
        {
            List<Model.Sensor_Band_Mode> lst = new List<Model.Sensor_Band_Mode>();
            while (dr.Read())
            {
                lst.Add(GetModel(dr));
            }
            return lst;
        }
        #endregion

    }
}
