//------------------------------------------------------------------------------
// 创建标识: 李佳霖
// 创建描述: 飞艇平台属性数据库访问类
// 创建时间:2017.4.18
// 文件版本:1.0
// 功能描述: 飞艇平台属性数据库访问
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
    public class AEROSHIP_RANGE
    {
        //数据库连接字符串(web.config来配置)，可以动态更改connectionString支持多数据库.		
        public static string connectionString;
        //构造数据库的连接语句
        public AEROSHIP_RANGE()
        {
            connectionString = PubConstant.GetConnectionString("");
        }

        /// <summary>
        /// 无人机添加函数,添加删除和管理的数据库连接还存在问题
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Model.AEROSHIP_RANGE model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO AEROSHIP_RANGE(");
            strSql.Append("PLATFORM_ID,PLATFORM_Name,NumberOfSensor,CruisingVelocity,PitchVelocity,MaxVelocity,MinVelocity,Acceleration,CruisingTime,");
            strSql.Append("CruisingAltitude,MaxAltitude,MaxDistance,PayLoad,");
            strSql.Append("MaxLoad)");
            strSql.Append(" Values(");
            strSql.Append("@in_PLATFORM_ID,@in_PLATFORM_Name,@in_NumberOfSensor,@in_CruisingVelocity,@in_PitchVelocity,@in_MaxVelocity,");
            strSql.Append("@in_MinVelocity,@in_Acceleration,@in_CruisingTime,");
            strSql.Append("@in_CruisingAltitude,@in_MaxAltitude,@in_MaxDistance,");
            strSql.Append("@in_PayLoad,@in_MaxLoad)");
            SqlParameter[] cmdParms = new SqlParameter[]{
                new SqlParameter("@in_PLATFORM_ID", SqlDbType.Decimal),
                new SqlParameter("@in_PLATFORM_Name", SqlDbType.NVarChar),
                new SqlParameter("@in_NumberOfSensor", SqlDbType.Decimal),
                new SqlParameter("@in_CruisingVelocity", SqlDbType.Decimal),
                new SqlParameter("@in_PitchVelocity", SqlDbType.Decimal),
                new SqlParameter("@in_MaxVelocity", SqlDbType.Decimal),
                new SqlParameter("@in_MinVelocity", SqlDbType.Decimal),
                new SqlParameter("@in_Acceleration", SqlDbType.Decimal),
                new SqlParameter("@in_CruisingTime", SqlDbType.Decimal),
                new SqlParameter("@in_CruisingAltitude", SqlDbType.Decimal),

                new SqlParameter("@in_MaxAltitude", SqlDbType.Decimal),
                new SqlParameter("@in_MaxDistance", SqlDbType.Decimal),
                new SqlParameter("@in_PayLoad", SqlDbType.Decimal),
                new SqlParameter("@in_MaxLoad", SqlDbType.Decimal)};

            cmdParms[0].Value = model.PLATFORM_ID;
            cmdParms[1].Value = model.PLATFORM_Name;
            cmdParms[2].Value = model.NumberOfSensor;
            cmdParms[3].Value = model.CruisingVelocity;
            cmdParms[4].Value = model.PitchVelocity;
            cmdParms[5].Value = model.MaxVelocity;
            cmdParms[6].Value = model.MinVelocity;
            cmdParms[7].Value = model.Acceleration;
            cmdParms[8].Value = model.CruisingTime;
            cmdParms[9].Value = model.CruisingAltitude;

            cmdParms[10].Value = model.MaxAltitude;
            cmdParms[11].Value = model.MaxDistance;
            cmdParms[12].Value = model.PayLoad;
            cmdParms[13].Value = model.MaxLoad;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 根据无人机ID修改数据库中的一条记录
        /// </summary>
        /// <param name="model"></param>无人机平台实体类的实例
        /// <returns></returns>返回值为修改的记录数
        public int Update(Model.AEROSHIP_RANGE model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update AEROSHIP_RANGE set ");

            strSql.Append("PLATFORM_Name=@in_PLATFORM_Name,");
            strSql.Append("NumberOfSensor=@in_NumberOfSensor,");
            strSql.Append("CruisingVelocity=@in_CruisingVelocity,");
            strSql.Append("PitchVelocity=@in_PitchVelocity,");
            strSql.Append("MaxVelocity=@in_MaxVelocity,");
            strSql.Append("MinVelocity=@in_MinVelocity,");
            strSql.Append("Acceleration=@in_Acceleration,");
            strSql.Append("CruisingTime=@in_CruisingTime,");
            strSql.Append("CruisingAltitude=@in_CruisingAltitude,");
            strSql.Append("MaxAltitude=@in_MaxAltitude,");

            strSql.Append("MaxDistance=@in_MaxDistance,");
            strSql.Append("PayLoad=@in_PayLoad,");
            strSql.Append("MaxLoad=@in_MaxLoad");

            strSql.Append(" where PLATFORM_ID=@in_PLATFORM_ID");


            SqlParameter[] cmdParms = new SqlParameter[]{
                new SqlParameter("@in_PLATFORM_ID", SqlDbType.Decimal),
                new SqlParameter("@in_PLATFORM_Name", SqlDbType.NVarChar),
                new SqlParameter("@in_NumberOfSensor", SqlDbType.Decimal),
                new SqlParameter("@in_CruisingVelocity", SqlDbType.Decimal),
                new SqlParameter("@in_PitchVelocity", SqlDbType.Decimal),
                new SqlParameter("@in_MaxVelocity", SqlDbType.Decimal),
                new SqlParameter("@in_MinVelocity", SqlDbType.Decimal),
                new SqlParameter("@in_Acceleration", SqlDbType.Decimal),
                new SqlParameter("@in_CruisingTime", SqlDbType.Decimal),
                new SqlParameter("@in_CruisingAltitude", SqlDbType.Decimal),

                new SqlParameter("@in_MaxAltitude", SqlDbType.Decimal),
                new SqlParameter("@in_MaxDistance", SqlDbType.Decimal),
                new SqlParameter("@in_PayLoad", SqlDbType.Decimal),
                new SqlParameter("@in_MaxLoad", SqlDbType.Decimal)};

            cmdParms[0].Value = model.PLATFORM_ID;
            cmdParms[1].Value = model.PLATFORM_Name;
            cmdParms[2].Value = model.NumberOfSensor;
            cmdParms[3].Value = model.CruisingVelocity;
            cmdParms[4].Value = model.PitchVelocity;
            cmdParms[5].Value = model.MaxVelocity;
            cmdParms[6].Value = model.MinVelocity;
            cmdParms[7].Value = model.Acceleration;
            cmdParms[8].Value = model.CruisingTime;
            cmdParms[9].Value = model.CruisingAltitude;

            cmdParms[10].Value = model.MaxAltitude;
            cmdParms[11].Value = model.MaxDistance;
            cmdParms[12].Value = model.PayLoad;
            cmdParms[13].Value = model.MaxLoad;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }
        /// <summary>
        /// 根据飞艇平台编号删除一条记录
        /// </summary>
        /// <param name="SensorID"></param>
        /// <returns></returns>
        public int Delete(decimal PLATFORM_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Delete from AEROSHIP_RANGE");
            strSql.Append(" Where PLATFORM_ID=@in_PLATFORM_ID");
            SqlParameter[] cmdParms = new SqlParameter[]{
                new SqlParameter("@in_PLATFORM_ID",SqlDbType.Decimal)
            };
            cmdParms[0].Value = PLATFORM_ID;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }
        /// <summary>
        /// 根据飞艇平台ID判断是否存在该记录
        /// </summary>
        /// <param name="SensorID"></param>
        /// <returns></returns>
        public bool Exists(string PLATFORM_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select count(1) from AEROSHIP_RANGE ");
            strSql.Append(" Where PLATFORM_ID=" + PLATFORM_ID);
            return DbHelperSQL.Exists(strSql.ToString());
        }

        //该类中需要实现 通过PLATFORM_ID来查找所需的飞艇速度和续航时间
        public Model.AEROSHIP_RANGE GetModel(decimal platformid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * From AEROSHIP_RANGE ");
            strSql.Append(" Where PLATFORM_ID=" + platformid);
            Model.AEROSHIP_RANGE model = null;

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
        public List<Model.AEROSHIP_RANGE> GetList(string whereClause)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * From AEROSHIP_RANGE ");
            strSql.Append(" Where " + whereClause);

            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<CoScheduling.Core.Model.AEROSHIP_RANGE> lst = GetList(dr);
                dr.Close();
                return lst;
            }
        }
        /// <summary>
        /// 获取全部记录
        /// </summary>
        /// <returns></returns>
        public List<CoScheduling.Core.Model.AEROSHIP_RANGE> GetList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * From AEROSHIP_RANGE order by PLATFORM_ID desc");


            using (DbDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<CoScheduling.Core.Model.AEROSHIP_RANGE> lst = GetList(dr);
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
            strSql.Append(" FROM AEROSHIP_RANGE ");
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
            strSql.Append(" FROM AEROSHIP_RANGE ");
            if (strWhere.Trim() != "")
            {
                strSql.Append("WHERE " + strWhere);
            }
            strSql.Append(" ORDER BY PLATFORM_ID");
            DataSet dsSat = new DataSet();
            SqlDataAdapter odaSat = new SqlDataAdapter(strSql.ToString(), connectionString);
            if (dsSat.Tables["AEROSHIP_RANGE"] != null)
            {
                dsSat.Tables["AEROSHIP_RANGE"].Clear();
            }

            odaSat.Fill(dsSat, "AEROSHIP_RANGE");

            return dsSat;
        }

        #region -------- 私有方法，通常情况下无需修改 --------
        /// <summary>
        /// 由一行数据得到一个实体,还有很多问题，什么时候用try catch,什么时候不用
        /// </summary>
        private Model.AEROSHIP_RANGE GetModel(DbDataReader dr)
        {

            CoScheduling.Core.Model.AEROSHIP_RANGE model = new CoScheduling.Core.Model.AEROSHIP_RANGE();
            model.PLATFORM_ID = Convert.ToDecimal(dr["PLATFORM_ID"]);
            model.PLATFORM_Name = Convert.ToString(dr["PLATFORM_Name"]);
            model.NumberOfSensor = Convert.ToDecimal(dr["NumberOfSensor"]);
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
                model.PitchVelocity = Convert.ToDecimal(dr["PitchVelocity"]);
            }
            catch
            {
                model.PitchVelocity = Convert.ToDecimal("-1");
            }
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
                model.MinVelocity = Convert.ToDecimal(dr["MinVelocity"]);
            }
            catch
            {
                model.MinVelocity = Convert.ToDecimal("-1");
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
                model.CruisingTime = Convert.ToDecimal(dr["CruisingTime"]);
            }
            catch
            {
                model.CruisingTime = Convert.ToDecimal("-1");
            }
            try
            {
                model.CruisingAltitude = Convert.ToDecimal(dr["CruisingAltitude"]);
            }
            catch
            {
                model.CruisingAltitude = Convert.ToDecimal("-1");
            }
            try
            {
                model.MaxAltitude = Convert.ToDecimal(dr["MaxAltitude"]);
            }
            catch
            {
                model.MaxAltitude = Convert.ToDecimal("-1");
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
                model.PayLoad = Convert.ToDecimal(dr["PayLoad"]);
            }
            catch
            {
                model.PayLoad = Convert.ToDecimal("-1");
            }
            try
            {
                model.MaxLoad = Convert.ToDecimal(dr["MaxLoad"]);
            }
            catch
            {
                model.MaxLoad = Convert.ToDecimal("-1");
            }
            
            return model;
        }
        /// <summary>
        /// 由DbDataReader得到泛型数据列表
        /// </summary>
        private List<Model.AEROSHIP_RANGE> GetList(DbDataReader dr)
        {
            List<Model.AEROSHIP_RANGE> lst = new List<Model.AEROSHIP_RANGE>();
            while (dr.Read())
            {
                lst.Add(GetModel(dr));
            }
            return lst;
        }

        #endregion
    }
}
