//------------------------------------------------------------------------------
// 创建标识: 李佳霖
// 创建描述: 第二类传感器实体类（地面摄像头、志愿者）
// 创建时间:2017.3.28
// 文件版本:1.0
// 功能描述: 第二类传感器de管理核心代码
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
    public class SENSOR_2
    {
        //数据库连接字符串(web.config来配置)，可以动态更改connectionString支持多数据库.		
        public static string connectionString;
        public SENSOR_2()
        {
            connectionString = PubConstant.GetConnectionString("");
        }

        /// <summary>
        /// 第二类传感器添加函数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Model.SENSOR_2 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO SENSOR_2(");
            strSql.Append("SensorID,SensorName,PLATFORM_ID,SensorType,Application,");
            strSql.Append("Pixel,Resolution,HorizontalResolution,MinIllumination,");
            strSql.Append("LookAngle,SquintAngle,MaxDistance,Aperture,FocalLength,MAXGSD)");
            strSql.Append(" Values(");
            strSql.Append("@in_SensorID,@in_SensorName,@in_PLATFORM_ID,@in_SensorType,");
            strSql.Append("@in_Application,@in_Pixel,@in_Resolution,@in_HorizontalResolution,@in_MinIllumination,@in_LookAngle,");
            strSql.Append("@in_SquintAngle,@in_MaxDistance,@in_Aperture,@in_FocalLength,@in_MAXGSD)");
            SqlParameter[] cmdParms = new SqlParameter[]{
                new SqlParameter("@in_SensorID", SqlDbType.Decimal),
                new SqlParameter("@in_SensorName", SqlDbType.NVarChar),
                new SqlParameter("@in_PLATFORM_ID", SqlDbType.Decimal),
                new SqlParameter("@in_SensorType", SqlDbType.NVarChar),
                new SqlParameter("@in_Application", SqlDbType.NVarChar),
                new SqlParameter("@in_Pixel", SqlDbType.Decimal),
                new SqlParameter("@in_Resolution", SqlDbType.Decimal),
                new SqlParameter("@in_HorizontalResolution", SqlDbType.Decimal),
                new SqlParameter("@in_MinIllumination", SqlDbType.Decimal),
                new SqlParameter("@in_LookAngle", SqlDbType.Decimal),

                new SqlParameter("@in_SquintAngle", SqlDbType.Decimal),
                new SqlParameter("@in_MaxDistance", SqlDbType.Decimal),
                new SqlParameter("@in_Aperture", SqlDbType.Decimal),
                new SqlParameter("@in_FocalLength", SqlDbType.Decimal),
                new SqlParameter("@in_MAXGSD", SqlDbType.Decimal)};

            cmdParms[0].Value = model.SensorID;
            cmdParms[1].Value = model.SensorName;
            cmdParms[2].Value = model.PLATFORM_ID;
            cmdParms[3].Value = model.SensorType;
            
            cmdParms[4].Value = model.Application;
            cmdParms[5].Value = model.Pixel;
            cmdParms[6].Value = model.Resolution;
            cmdParms[7].Value = model.HorizontalResolution;
            cmdParms[8].Value = model.MinIllumination;
            cmdParms[9].Value = model.LookAngle;
            cmdParms[10].Value = model.SquintAngle;
            cmdParms[11].Value=model.MaxDistance;
            cmdParms[12].Value = model.Aperture;
            cmdParms[13].Value = model.FocalLength;
            cmdParms[14].Value = model.MAXGSD;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);//执行SQL语句，还需修改数据库连接的问题
        }
        /// <summary>
        /// 根据传感器ID修改数据库中的一条记录
        /// </summary>
        /// <param name="model"></param>第一类传感器实体类的实例
        /// <returns></returns>返回值为修改的记录数
        public int Update(Model.SENSOR_2 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update SENSOR_2 set ");

            strSql.Append("SensorName=@in_SensorName,");
            strSql.Append("PLATFORM_ID=@in_PLATFORM_ID,");
            strSql.Append("SensorType=@in_SensorType,");
            strSql.Append("Application=@in_Application,");
            strSql.Append("Pixel=@in_Pixel,");
            strSql.Append("Resolution=@in_Resolution,");
            strSql.Append("HorizontalResolution=@in_HorizontalResolution,");
            strSql.Append("MinIllumination=@in_MinIllumination,");
            strSql.Append("LookAngle=@in_LookAngle,");
            strSql.Append("SquintAngle=@in_SquintAngle,");
            strSql.Append("MaxDistance=@in_MaxDistance,");
            strSql.Append("Aperture=@in_Aperture,");
            strSql.Append("FocalLength=@in_FocalLength,");
            strSql.Append("MAXGSD=@in_MAXGSD");

            strSql.Append(" where SensorID=@in_SensorID");

            SqlParameter[] cmdParms = new SqlParameter[]{
                new SqlParameter("@in_SensorID", SqlDbType.Decimal),
                new SqlParameter("@in_SensorName", SqlDbType.NVarChar),
                new SqlParameter("@in_PLATFORM_ID", SqlDbType.Decimal),
                new SqlParameter("@in_SensorType", SqlDbType.NVarChar),
                new SqlParameter("@in_Application", SqlDbType.NVarChar),
                new SqlParameter("@in_Pixel", SqlDbType.Decimal),
                new SqlParameter("@in_Resolution", SqlDbType.Decimal),
                new SqlParameter("@in_HorizontalResolution", SqlDbType.Decimal),
                new SqlParameter("@in_MinIllumination", SqlDbType.Decimal),
                new SqlParameter("@in_LookAngle", SqlDbType.Decimal),

                new SqlParameter("@in_SquintAngle", SqlDbType.Decimal),
                new SqlParameter("@in_MaxDistance", SqlDbType.Decimal),
                new SqlParameter("@in_Aperture", SqlDbType.Decimal),
                new SqlParameter("@in_FocalLength", SqlDbType.Decimal),
                new SqlParameter("@in_MAXGSD", SqlDbType.Decimal)};

            cmdParms[0].Value = model.SensorID;
            cmdParms[1].Value = model.SensorName;
            cmdParms[2].Value = model.PLATFORM_ID;
            cmdParms[3].Value = model.SensorType;

            cmdParms[4].Value = model.Application;
            cmdParms[5].Value = model.Pixel;
            cmdParms[6].Value = model.Resolution;
            cmdParms[7].Value = model.HorizontalResolution;
            cmdParms[8].Value = model.MinIllumination;
            cmdParms[9].Value = model.LookAngle;
            cmdParms[10].Value = model.SquintAngle;
            cmdParms[11].Value = model.MaxDistance;
            cmdParms[12].Value = model.Aperture;
            cmdParms[13].Value = model.FocalLength;
            cmdParms[14].Value = model.MAXGSD;
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
            strSql.Append("Delete from SENSOR_2");
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
            strSql.Append("Select count(1) from SENSOR_2 ");
            strSql.Append(" Where SensorID=" + SensorID);
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="SensorID"></param>
        /// <returns></returns>
        public Model.SENSOR_2 GetModel(decimal SensorID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from SENSOR_2 ");
            strSql.Append(" Where SensorID=" + SensorID);
            Model.SENSOR_2 model = null;

            using (DbDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
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
        public List<Model.SENSOR_2> GetList(string whereClause)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * From SENSOR_2 ");
            strSql.Append(" Where " + whereClause);

            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<CoScheduling.Core.Model.SENSOR_2> lst = GetList(dr);
                dr.Close();
                return lst;
            }
        }
        /// <summary>
        /// 获取全部记录
        /// </summary>
        /// <returns></returns>
        public List<CoScheduling.Core.Model.SENSOR_2> GetList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * From SENSOR_2 order by SensorID desc");

            using (DbDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<CoScheduling.Core.Model.SENSOR_2> lst = GetList(dr);
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
            strSql.Append(" FROM SENSOR_2 ");
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
            strSql.Append(" FROM SENSOR_2 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append("WHERE " + strWhere);
            }
            strSql.Append(" ORDER BY SensorID");
            DataSet dsSat = new DataSet();
            SqlDataAdapter odaSat = new SqlDataAdapter(strSql.ToString(), connectionString);
            if (dsSat.Tables["SENSOR_2"] != null)
            {
                dsSat.Tables["SENSOR_2"].Clear();
            }

            odaSat.Fill(dsSat, "SENSOR_2");

            return dsSat;
        }
        /// <summary>
        /// 根据PLATFORM_ID删除数据
        /// </summary>
        public void DeleteByPLATFORMID(string PLATFORM_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SENSOR_2 ");
            strSql.Append(" where PLATFORM_ID=" + PLATFORM_ID);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 根据PLATFORM_ID获取最新载荷ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public decimal GetSensorID(string platform_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select max(SensorID) from SENSOR_2 ");
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
        private Model.SENSOR_2 GetModel(DbDataReader dr)
        {
            CoScheduling.Core.Model.SENSOR_2 model = new CoScheduling.Core.Model.SENSOR_2();
            model.SensorID = Convert.ToDecimal(dr["SensorID"]);
            try
            {
                model.SensorName = Convert.ToString(dr["SensorName"]);
            }
            catch
            {
                model.SensorName = Convert.ToString("N/A");
            }
            model.PLATFORM_ID = Convert.ToDecimal(dr["PLATFORM_ID"]);
            model.SensorType = Convert.ToString(dr["SensorType"]);
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
                model.Pixel = Convert.ToDecimal(dr["Pixel"]);
            }
            catch
            {
                model.Pixel = Convert.ToDecimal("-1");
            }
            try
            {
                model.Resolution = Convert.ToDecimal(dr["Resolution"]);
            }
            catch
            {
                model.Resolution = Convert.ToDecimal("-1");
            }
            try
            {
                model.HorizontalResolution = Convert.ToDecimal(dr["HorizontalResolution"]);
            }
            catch
            {
                model.HorizontalResolution = Convert.ToDecimal("-1");
            }
            try
            {
                model.MinIllumination = Convert.ToDecimal(dr["SquintAngle"]);
            }
            catch
            {
                model.MinIllumination = Convert.ToDecimal("-1");
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
                model.SquintAngle = Convert.ToDecimal(dr["SquintAngle"]);
            }
            catch
            {
                model.SquintAngle = Convert.ToDecimal("-1");
            }
            try
            {
                model.MaxDistance = Convert.ToDecimal(dr["MaxDistance"]);
            }
            catch
            {
                model.MaxDistance = Convert.ToDecimal("-1");
            }
            try
            {
                model.Aperture = Convert.ToDecimal(dr["Aperture"]);
            }
            catch
            {
                model.Aperture = Convert.ToDecimal("-1");
            }
            try
            {
                model.FocalLength = Convert.ToDecimal(dr["FocalLength"]);
            }
            catch
            {
                model.FocalLength = Convert.ToDecimal("-1");
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
        private List<Model.SENSOR_2> GetList(DbDataReader dr)
        {
            List<Model.SENSOR_2> lst = new List<Model.SENSOR_2>();
            while (dr.Read())
            {
                lst.Add(GetModel(dr));
            }
            return lst;
        }
        #endregion


    }
}
