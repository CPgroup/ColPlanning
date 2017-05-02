//------------------------------------------------------------------------------
// 创建标识: 李佳霖
// 创建描述: 地面测量车平台属性数据库访问类
// 创建时间:2017.4.18
// 文件版本:1.0
// 功能描述: 地面测量车平台属性数据库访问
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
    public class ILLUSTRATEDCAR_RANGE
    {
        //数据库连接字符串(web.config来配置)，可以动态更改connectionString支持多数据库.		
        public static string connectionString;
        //构造数据库的连接语句
        public ILLUSTRATEDCAR_RANGE()
        {
            connectionString = PubConstant.GetConnectionString("");
        }
        /// <summary>
        /// 地面测量车添加函数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Model.ILLUSTRATEDCAR_RANGE model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO ILLUSTRATEDCAR_RANGE(");
            strSql.Append("PLATFORM_ID,PLATFORM_Name,NumberOfSensor,MaxVelocity,Acceleration,");
            strSql.Append("MaxDistance,ApproachAngle,DepartureAngle,MinimumGroundClearance,WheelBase,");
            strSql.Append("AzimuthAngle,AzimuthAngleVelocity,AzimuthAngleAcceleration,PitchAngle,PitchAngleVelocity,");
            strSql.Append("PitchAngleAcceleration,PolarizationAngle,PolarizationAngleVelocity,PolarizationAngleAcceleration)");
            strSql.Append(" Values( ");
            strSql.Append("@in_PLATFORM_ID,@in_PLATFORM_Name,@in_NumberOfSensor,@in_MaxVelocity,@in_Acceleration,");
            strSql.Append("@in_MaxDistance,@in_ApproachAngle,@in_DepartureAngle,@in_MinimumGroundClearance,@in_WheelBase,");
            strSql.Append("@in_AzimuthAngle,@in_AzimuthAngleVelocity,@in_AzimuthAngleAcceleration,@in_PitchAngle,@in_PitchAngleVelocity,");
            strSql.Append("@in_PitchAngleAcceleration,@in_PolarizationAngle,@in_PolarizationAngleVelocity,@in_PolarizationAngleAcceleration)");

            SqlParameter[] cmdParms = new SqlParameter[]{
                new SqlParameter("@in_PLATFORM_ID", SqlDbType.Decimal),
                new SqlParameter("@in_PLATFORM_Name", SqlDbType.NVarChar),
                new SqlParameter("@in_NumberOfSensor", SqlDbType.Decimal),
                new SqlParameter("@in_MaxVelocity", SqlDbType.Decimal),
                new SqlParameter("@in_Acceleration", SqlDbType.Decimal),
                new SqlParameter("@in_MaxDistance", SqlDbType.Decimal),
                new SqlParameter("@in_ApproachAngle", SqlDbType.Decimal),
                new SqlParameter("@in_DepartureAngle", SqlDbType.Decimal),
                new SqlParameter("@in_MinimumGroundClearance", SqlDbType.Decimal),
                new SqlParameter("@in_WheelBase", SqlDbType.Decimal),

                new SqlParameter("@in_AzimuthAngle", SqlDbType.Decimal),
                new SqlParameter("@in_AzimuthAngleVelocity", SqlDbType.Decimal),
                new SqlParameter("@in_AzimuthAngleAcceleration", SqlDbType.Decimal),
                new SqlParameter("@in_PitchAngle", SqlDbType.Decimal),
                new SqlParameter("@in_PitchAngleVelocity", SqlDbType.Decimal),
                new SqlParameter("@in_PitchAngleAcceleration", SqlDbType.Decimal),
                new SqlParameter("@in_PolarizationAngle", SqlDbType.Decimal),
                new SqlParameter("@in_PolarizationAngleVelocity", SqlDbType.Decimal),
                new SqlParameter("@in_PolarizationAngleAcceleration", SqlDbType.Decimal)};

            cmdParms[0].Value = model.PLATFORM_ID;
            cmdParms[1].Value = model.PLATFORM_Name;
            cmdParms[2].Value = model.NumberOfSensor;
            cmdParms[3].Value = model.MaxVelocity;
            cmdParms[4].Value = model.Acceleration;
            cmdParms[5].Value = model.MaxDistance;
            cmdParms[6].Value = model.ApproachAngle;
            cmdParms[7].Value = model.DepartureAngle;
            cmdParms[8].Value = model.MinimumGroundClearance;
            cmdParms[9].Value = model.WheelBase;

            cmdParms[10].Value = model.AzimuthAngle;
            cmdParms[11].Value = model.AzimuthAngleVelocity;
            cmdParms[12].Value = model.AzimuthAngleAcceleration;
            cmdParms[13].Value = model.PitchAngle;
            cmdParms[14].Value = model.PitchAngleVelocity;
            cmdParms[15].Value = model.PitchAngleAcceleration;
            cmdParms[16].Value = model.PolarizationAngle;
            cmdParms[17].Value = model.PolarizationAngleVelocity;
            cmdParms[18].Value = model.PolarizationAngleAcceleration;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 根据地面测量车平台ID修改数据库中的一条记录
        /// </summary>
        /// <param name="model"></param>地面测量车平台实体类的实例
        /// <returns></returns>返回值为修改的记录数
        public int Update(Model.ILLUSTRATEDCAR_RANGE model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update ILLUSTRATEDCAR_RANGE set ");

            strSql.Append("PLATFORM_Name=@in_PLATFORM_Name,");
            strSql.Append("NumberOfSensor=@in_NumberOfSensor,");
            strSql.Append("MaxVelocity=@in_MaxVelocity,");
            strSql.Append("Acceleration=@in_Acceleration,");
            strSql.Append("MaxDistance=@in_MaxDistance,");
            strSql.Append("ApproachAngle=@in_ApproachAngle,");
            strSql.Append("DepartureAngle=@in_DepartureAngle,");
            strSql.Append("MinimumGroundClearance=@in_MinimumGroundClearance,");
            strSql.Append("WheelBase=@in_WheelBase,");

            strSql.Append("AzimuthAngle=@in_AzimuthAngle,");
            strSql.Append("AzimuthAngleVelocity=@in_AzimuthAngleVelocity,");
            strSql.Append("AzimuthAngleAcceleration=@in_AzimuthAngleAcceleration,");
            strSql.Append("PitchAngle=@in_PitchAngle,");
            strSql.Append("PitchAngleVelocity=@in_PitchAngleVelocity,");
            strSql.Append("PitchAngleAcceleration=@in_PitchAngleAcceleration,");
            strSql.Append("PolarizationAngle=@in_PolarizationAngle,");
            strSql.Append("PolarizationAngleVelocity=@in_PolarizationAngleVelocity,");
            strSql.Append("PolarizationAngleAcceleration=@in_PolarizationAngleAcceleration");

            strSql.Append(" where PLATFORM_ID=@in_PLATFORM_ID");


            SqlParameter[] cmdParms = new SqlParameter[]{
                new SqlParameter("@in_PLATFORM_ID", SqlDbType.Decimal),
                new SqlParameter("@in_PLATFORM_Name", SqlDbType.NVarChar),
                new SqlParameter("@in_NumberOfSensor", SqlDbType.Decimal),
                new SqlParameter("@in_MaxVelocity", SqlDbType.Decimal),
                new SqlParameter("@in_Acceleration", SqlDbType.Decimal),
                new SqlParameter("@in_MaxDistance", SqlDbType.Decimal),
                new SqlParameter("@in_ApproachAngle", SqlDbType.Decimal),
                new SqlParameter("@in_DepartureAngle", SqlDbType.Decimal),
                new SqlParameter("@in_MinimumGroundClearance", SqlDbType.Decimal),
                new SqlParameter("@in_WheelBase", SqlDbType.Decimal),

                new SqlParameter("@in_AzimuthAngle", SqlDbType.Decimal),
                new SqlParameter("@in_AzimuthAngleVelocity", SqlDbType.Decimal),
                new SqlParameter("@in_AzimuthAngleAcceleration", SqlDbType.Decimal),
                new SqlParameter("@in_PitchAngle", SqlDbType.Decimal),
                new SqlParameter("@in_PitchAngleVelocity", SqlDbType.Decimal),
                new SqlParameter("@in_PitchAngleAcceleration", SqlDbType.Decimal),
                new SqlParameter("@in_PolarizationAngle", SqlDbType.Decimal),
                new SqlParameter("@in_PolarizationAngleVelocity", SqlDbType.Decimal),
                new SqlParameter("@in_PolarizationAngleAcceleration", SqlDbType.Decimal)};

            cmdParms[0].Value = model.PLATFORM_ID;
            cmdParms[1].Value = model.PLATFORM_Name;
            cmdParms[2].Value = model.NumberOfSensor;
            cmdParms[3].Value = model.MaxVelocity;
            cmdParms[4].Value = model.Acceleration;
            cmdParms[5].Value = model.MaxDistance;
            cmdParms[6].Value = model.ApproachAngle;
            cmdParms[7].Value = model.DepartureAngle;
            cmdParms[8].Value = model.MinimumGroundClearance;
            cmdParms[9].Value = model.WheelBase;

            cmdParms[10].Value = model.AzimuthAngle;
            cmdParms[11].Value = model.AzimuthAngleVelocity;
            cmdParms[12].Value = model.AzimuthAngleAcceleration;
            cmdParms[13].Value = model.PitchAngle;
            cmdParms[14].Value = model.PitchAngleVelocity;
            cmdParms[15].Value = model.PitchAngleAcceleration;
            cmdParms[16].Value = model.PolarizationAngle;
            cmdParms[17].Value = model.PolarizationAngleVelocity;
            cmdParms[18].Value = model.PolarizationAngleAcceleration;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }
        /// <summary>
        /// 根据地面测量车平台编号删除一条记录
        /// </summary>
        /// <param name="SensorID"></param>
        /// <returns></returns>
        public int Delete(decimal PLATFORM_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Delete from ILLUSTRATEDCAR_RANGE");
            strSql.Append(" Where PLATFORM_ID=@in_PLATFORM_ID");
            SqlParameter[] cmdParms = new SqlParameter[]{
                new SqlParameter("@in_PLATFORM_ID",SqlDbType.Decimal)
            };
            cmdParms[0].Value = PLATFORM_ID;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }
        /// <summary>
        /// 根据地面测量车平台ID判断是否存在该记录
        /// </summary>
        /// <param name="SensorID"></param>
        /// <returns></returns>
        public bool Exists(string PLATFORM_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select count(1) from ILLUSTRATEDCAR_RANGE ");
            strSql.Append(" Where PLATFORM_ID=" + PLATFORM_ID);
            return DbHelperSQL.Exists(strSql.ToString());
        }
        //该类中需要实现 通过PLATFORM_ID来查找所需的飞艇速度和续航时间
        public Model.ILLUSTRATEDCAR_RANGE GetModel(decimal platformid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * From ILLUSTRATEDCAR_RANGE ");
            strSql.Append(" Where PLATFORM_ID=" + platformid);
            Model.ILLUSTRATEDCAR_RANGE model = null;

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
        public List<Model.ILLUSTRATEDCAR_RANGE> GetList(string whereClause)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * From ILLUSTRATEDCAR_RANGE ");
            strSql.Append(" Where " + whereClause);

            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<CoScheduling.Core.Model.ILLUSTRATEDCAR_RANGE> lst = GetList(dr);
                dr.Close();
                return lst;
            }
        }
        /// <summary>
        /// 获取全部记录
        /// </summary>
        /// <returns></returns>
        public static List<CoScheduling.Core.Model.ILLUSTRATEDCAR_RANGE> GetList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * From ILLUSTRATEDCAR_RANGE order by PLATFORM_ID desc");


            using (DbDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<CoScheduling.Core.Model.ILLUSTRATEDCAR_RANGE> lst = GetList(dr);
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
            strSql.Append(" FROM ILLUSTRATEDCAR_RANGE ");
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
            strSql.Append(" FROM ILLUSTRATEDCAR_RANGE ");
            if (strWhere.Trim() != "")
            {
                strSql.Append("WHERE " + strWhere);
            }
            strSql.Append(" ORDER BY PLATFORM_ID");
            DataSet dsSat = new DataSet();
            SqlDataAdapter odaSat = new SqlDataAdapter(strSql.ToString(), connectionString);
            if (dsSat.Tables["ILLUSTRATEDCAR_RANGE"] != null)
            {
                dsSat.Tables["ILLUSTRATEDCAR_RANGE"].Clear();
            }

            odaSat.Fill(dsSat, "ILLUSTRATEDCAR_RANGE");

            return dsSat;
        }

        #region -------- 私有方法，通常情况下无需修改 --------
        /// <summary>
        /// 由一行数据得到一个实体,还有很多问题，什么时候用try catch,什么时候不用
        /// </summary>
        private static Model.ILLUSTRATEDCAR_RANGE GetModel(DbDataReader dr)
        {

            CoScheduling.Core.Model.ILLUSTRATEDCAR_RANGE model = new CoScheduling.Core.Model.ILLUSTRATEDCAR_RANGE();
            model.PLATFORM_ID = Convert.ToDecimal(dr["PLATFORM_ID"]);
            model.PLATFORM_Name = Convert.ToString(dr["PLATFORM_Name"]);
            model.NumberOfSensor = Convert.ToDecimal(dr["NumberOfSensor"]);
            try
            {
                model.MaxVelocity = Convert.ToDecimal(dr["MaxVelocity"]);
            }
            catch
            {
                model.MaxVelocity = Convert.ToDecimal("-1");
            }
            try
            {
                model.Acceleration = Convert.ToDecimal(dr["Acceleration"]);
            }
            catch
            {
                model.Acceleration = Convert.ToDecimal("-1");
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
                model.ApproachAngle = Convert.ToDecimal(dr["ApproachAngle"]);
            }
            catch
            {
                model.ApproachAngle = Convert.ToDecimal("-1");
            }
            try
            {
                model.DepartureAngle = Convert.ToDecimal(dr["DepartureAngle"]);
            }
            catch
            {
                model.DepartureAngle = Convert.ToDecimal("-1");
            }
            try
            {
                model.MinimumGroundClearance = Convert.ToDecimal(dr["MinimumGroundClearance"]);
            }
            catch
            {
                model.MinimumGroundClearance = Convert.ToDecimal("-1");
            }
            try
            {
                model.WheelBase = Convert.ToDecimal(dr["WheelBase"]);
            }
            catch
            {
                model.WheelBase = Convert.ToDecimal("-1");
            }
            try
            {
                model.AzimuthAngle = Convert.ToDecimal(dr["AzimuthAngle"]);
            }
            catch
            {
                model.AzimuthAngle = Convert.ToDecimal("-1");
            }
            
            try
            {
                model.AzimuthAngleVelocity = Convert.ToDecimal(dr["AzimuthAngleVelocity"]);
            }
            catch
            {
                model.AzimuthAngleVelocity = Convert.ToDecimal("-1");
            }
            try
            {
                model.AzimuthAngleAcceleration = Convert.ToDecimal(dr["AzimuthAngleAcceleration"]);
            }
            catch
            {
                model.AzimuthAngleAcceleration = Convert.ToDecimal("-1");
            }
            try
            {
                model.CruisingVelocity = Convert.ToDecimal(dr["CruisingVelocity"]);
            }
            catch
            {
                model.CruisingVelocity = Convert.ToDecimal("-1");
            }
            try
            {
                model.ObserveVelocity = Convert.ToDecimal(dr["ObserveVelocity"]);
            }
            catch
            {
                model.ObserveVelocity = Convert.ToDecimal("-1");
            }

            try
            {
                model.PitchAngle = Convert.ToDecimal(dr["PitchAngle"]);
            }
            catch
            {
                model.PitchAngle = Convert.ToDecimal("-1");
            }
            try
            {
                model.PitchAngleVelocity = Convert.ToDecimal(dr["PitchAngleVelocity"]);
            }
            catch
            {
                model.PitchAngleVelocity = Convert.ToDecimal("-1");
            }
            try
            {
                model.PitchAngleAcceleration = Convert.ToDecimal(dr["PitchAngleAcceleration"]);
            }
            catch
            {
                model.PitchAngleAcceleration = Convert.ToDecimal("-1");
            }
            try
            {
                model.PolarizationAngle = Convert.ToDecimal(dr["PolarizationAngle"]);
            }
            catch
            {
                model.PolarizationAngle = Convert.ToDecimal("-1");
            }
            try
            {
                model.PolarizationAngleVelocity = Convert.ToDecimal(dr["PolarizationAngleVelocity"]);
            }
            catch
            {
                model.PolarizationAngleVelocity = Convert.ToDecimal("-1");
            }
            try
            {
                model.PolarizationAngleAcceleration = Convert.ToDecimal(dr["PolarizationAngleAcceleration"]);
            }
            catch
            {
                model.PolarizationAngleAcceleration = Convert.ToDecimal("-1");
            }


            return model;
        }
        /// <summary>
        /// 由DbDataReader得到泛型数据列表
        /// </summary>
        private static List<Model.ILLUSTRATEDCAR_RANGE> GetList(DbDataReader dr)
        {
            List<Model.ILLUSTRATEDCAR_RANGE> lst = new List<Model.ILLUSTRATEDCAR_RANGE>();
            while (dr.Read())
            {
                lst.Add(GetModel(dr));
            }
            return lst;
        }

        #endregion



    }
}
