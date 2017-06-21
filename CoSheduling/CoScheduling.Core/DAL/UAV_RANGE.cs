//------------------------------------------------------------------------------
// 创建标识: 李佳霖
// 创建描述: 无人机平台属性数据库访问类
// 创建时间:2017.3.31
// 文件版本:1.0
// 功能描述: 无人机平台属性数据库访问
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
    public class UAV_RANGE
    {
        //数据库连接字符串(web.config来配置)，可以动态更改connectionString支持多数据库.		
        public static string connectionString;
        //构造数据库的连接语句
        public UAV_RANGE()
        {
            connectionString = @"server=(local);database=CoMonitoring; User=sa; Password=123 ";//建立的时候就确定了，连接数据库的路径
        }
        
        /// <summary>
        /// 无人机添加函数,添加删除和管理的数据库连接还存在问题
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Model.UAV_RANGE model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO UAV_RANGE(");
            strSql.Append("PLATFORM_ID,PLATFORM_Name,NumberOfSensor,CruisingVelocity,RollVelocity,PitchVelocity,MaxVelocity,MinVelocity,Acceleration,CruisingTime,");
            strSql.Append("MaxSlewAngle,MinSlewAngle,CruisingAltitude,MaxAltitude,MaxDistance,MinTurningRadius,PayLoad,");
            strSql.Append("MaxLoad,Base_ID)");
            strSql.Append(" Values(");
            strSql.Append("@in_PLATFORM_ID,@in_PLATFORM_Name,@in_NumberOfSensor,@in_CruisingVelocity,@in_RollVelocity,@in_PitchVelocity,@in_MaxVelocity,");
            strSql.Append("@in_MinVelocity,@in_Acceleration,@in_CruisingTime,");
            strSql.Append("@in_MaxSlewAngle,@in_MinSlewAngle,@in_CruisingAltitude,@in_MaxAltitude,@in_MaxDistance,@in_MinTurningRadius,");
            strSql.Append("@in_PayLoad,@in_MaxLoad,@in_Base_ID)");
            SqlParameter[] cmdParms = new SqlParameter[]{
                new SqlParameter("@in_PLATFORM_ID", SqlDbType.Decimal),
                new SqlParameter("@in_PLATFORM_Name", SqlDbType.NVarChar),
                new SqlParameter("@in_NumberOfSensor", SqlDbType.Decimal),
                new SqlParameter("@in_CruisingVelocity", SqlDbType.Decimal),
                new SqlParameter("@in_RollVelocity", SqlDbType.Decimal),
                new SqlParameter("@in_PitchVelocity", SqlDbType.Decimal),
                new SqlParameter("@in_MaxVelocity", SqlDbType.Decimal),
                new SqlParameter("@in_MinVelocity", SqlDbType.Decimal),
                new SqlParameter("@in_Acceleration", SqlDbType.Decimal),
                new SqlParameter("@in_CruisingTime", SqlDbType.Decimal),

                new SqlParameter("@in_MaxSlewAngle", SqlDbType.Decimal),
                new SqlParameter("@in_MinSlewAngle", SqlDbType.Decimal),
                new SqlParameter("@in_CruisingAltitude", SqlDbType.Decimal),
                new SqlParameter("@in_MaxAltitude", SqlDbType.Decimal),
                new SqlParameter("@in_MaxDistance", SqlDbType.Decimal),
                new SqlParameter("@in_MinTurningRadius", SqlDbType.Decimal),
                new SqlParameter("@in_PayLoad", SqlDbType.Decimal),
                new SqlParameter("@in_MaxLoad", SqlDbType.Decimal),
                new SqlParameter("@in_Base_ID", SqlDbType.Decimal)};

            cmdParms[0].Value = model.PLATFORM_ID;
            cmdParms[1].Value = model.PLATFORM_Name;
            cmdParms[2].Value = model.NumberOfSensor;
            cmdParms[3].Value = model.CruisingVelocity;
            cmdParms[4].Value = model.RollVelocity;
            cmdParms[5].Value = model.PitchVelocity;
            cmdParms[6].Value = model.MaxVelocity;
            cmdParms[7].Value = model.MinVelocity;
            cmdParms[8].Value = model.Acceleration;
            cmdParms[9].Value = model.CruisingTime;

            cmdParms[10].Value = model.MaxSlewAngle;
            cmdParms[11].Value = model.MinSlewAngle;
            cmdParms[12].Value = model.CruisingAltitude;
            cmdParms[13].Value = model.MaxAltitude;
            cmdParms[14].Value = model.MaxDistance;
            cmdParms[15].Value = model.MinTurningRadius;
            cmdParms[16].Value = model.PayLoad;
            cmdParms[17].Value = model.MaxLoad;
            cmdParms[18].Value = model.Base_ID;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);//执行SQL语句，还需修改数据库连接的问题
        }

        /// <summary>
        /// 根据无人机ID修改数据库中的一条记录
        /// </summary>
        /// <param name="model"></param>无人机平台实体类的实例
        /// <returns></returns>返回值为修改的记录数
        public int Update(Model.UAV_RANGE model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update UAV_RANGE set ");

            strSql.Append("PLATFORM_Name=@in_PLATFORM_Name,");
            strSql.Append("NumberOfSensor=@in_NumberOfSensor,");
            strSql.Append("CruisingVelocity=@in_CruisingVelocity,");
            strSql.Append("RollVelocity=@in_RollVelocity,");
            strSql.Append("PitchVelocity=@in_PitchVelocity,");
            strSql.Append("MaxVelocity=@in_MaxVelocity,");
            strSql.Append("MinVelocity=@in_MinVelocity,");
            strSql.Append("Acceleration=@in_Acceleration,");
            strSql.Append("CruisingTime=@in_CruisingTime,");

            strSql.Append("MaxSlewAngle=@in_MaxSlewAngle,");
            strSql.Append("MinSlewAngle=@in_MinSlewAngle,");
            strSql.Append("CruisingAltitude=@in_CruisingAltitude,");
            strSql.Append("MaxAltitude=@in_MaxAltitude,");
            strSql.Append("MaxDistance=@in_MaxDistance,");
            strSql.Append("MinTurningRadius=@in_MinTurningRadius,");
            strSql.Append("PayLoad=@in_PayLoad,");
            strSql.Append("MaxLoad=@in_MaxLoad,");
            strSql.Append("Base_ID=@in_Base_ID,");

            strSql.Append(" where PLATFORM_ID=@in_PLATFORM_ID");

            SqlParameter[] cmdParms = new SqlParameter[]{
                new SqlParameter("@in_PLATFORM_ID", SqlDbType.Decimal),
                new SqlParameter("@in_PLATFORM_Name", SqlDbType.NVarChar),
                new SqlParameter("@in_NumberOfSensor", SqlDbType.Decimal),
                new SqlParameter("@in_CruisingVelocity", SqlDbType.Decimal),
                new SqlParameter("@in_RollVelocity", SqlDbType.Decimal),
                new SqlParameter("@in_PitchVelocity", SqlDbType.Decimal),
                new SqlParameter("@in_MaxVelocity", SqlDbType.Decimal),
                new SqlParameter("@in_MinVelocity", SqlDbType.Decimal),
                new SqlParameter("@in_Acceleration", SqlDbType.Decimal),
                new SqlParameter("@in_CruisingTime", SqlDbType.Decimal),

                new SqlParameter("@in_MaxSlewAngle", SqlDbType.Decimal),
                new SqlParameter("@in_MinSlewAngle", SqlDbType.Decimal),
                new SqlParameter("@in_CruisingAltitude", SqlDbType.Decimal),
                new SqlParameter("@in_MaxAltitude", SqlDbType.Decimal),
                new SqlParameter("@in_MaxDistance", SqlDbType.Decimal),
                new SqlParameter("@in_MinTurningRadius", SqlDbType.Decimal),
                new SqlParameter("@in_PayLoad", SqlDbType.Decimal),
                new SqlParameter("@in_MaxLoad", SqlDbType.Decimal),
                new SqlParameter("@in_Base_ID", SqlDbType.Decimal)};

            cmdParms[0].Value = model.PLATFORM_ID;
            cmdParms[1].Value = model.PLATFORM_Name;
            cmdParms[2].Value = model.NumberOfSensor;
            cmdParms[3].Value = model.CruisingVelocity;
            cmdParms[4].Value = model.RollVelocity;
            cmdParms[5].Value = model.PitchVelocity;
            cmdParms[6].Value = model.MaxVelocity;
            cmdParms[7].Value = model.MinVelocity;
            cmdParms[8].Value = model.Acceleration;
            cmdParms[9].Value = model.CruisingTime;

            cmdParms[10].Value = model.MaxSlewAngle;
            cmdParms[11].Value = model.MinSlewAngle;
            cmdParms[12].Value = model.CruisingAltitude;
            cmdParms[13].Value = model.MaxAltitude;
            cmdParms[14].Value = model.MaxDistance;
            cmdParms[15].Value = model.MinTurningRadius;
            cmdParms[16].Value = model.PayLoad;
            cmdParms[17].Value = model.MaxLoad;
            cmdParms[18].Value = model.Base_ID;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 根据UAV平台编号删除一条传感器记录
        /// </summary>
        /// <param name="SensorID"></param>
        /// <returns></returns>
        public int Delete(decimal PLATFORM_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Delete from UAV_RANGE");
            strSql.Append(" Where PLATFORM_ID=@in_PLATFORM_ID");
            SqlParameter[] cmdParms = new SqlParameter[]{
                new SqlParameter("@in_PLATFORM_ID",SqlDbType.Decimal)
            };
            cmdParms[0].Value = PLATFORM_ID;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }
        /// <summary>
        /// 根据无人机平台ID判断是否存在该记录
        /// </summary>
        /// <param name="SensorID"></param>
        /// <returns></returns>
        public bool Exists(string PLATFORM_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select count(1) from UAV_RANGE ");
            strSql.Append(" Where PLATFORM_ID=" + PLATFORM_ID);
            return DbHelperSQL.Exists(strSql.ToString());
        }
        //该类中需要实现 通过PLATFORM_ID来查找所需的无人机速度和续航时间
        public Model.UAV_RANGE GetModel(decimal platformid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * From UAV_RANGE ");
            strSql.Append(" Where PLATFORM_ID=" + platformid);
            Model.UAV_RANGE model = null;

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
        public List<Model.UAV_RANGE> GetList(string whereClause)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * From UAV_RANGE ");
            strSql.Append(" Where " + whereClause);
            //数据库连接
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(strSql.ToString(), connection);

            connection.Open();
            SqlDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            using (DbDataReader dr = myReader)
            {
                List<CoScheduling.Core.Model.UAV_RANGE> lst = GetList(dr);
                dr.Close();
                return lst;
            }
        }
        /// <summary>
        /// 获取全部记录
        /// </summary>
        /// <returns></returns>
        public static List<CoScheduling.Core.Model.UAV_RANGE> GetList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * From UAV_RANGE order by PLATFORM_ID desc");
            //数据库连接
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(strSql.ToString(), connection);

            connection.Open();
            SqlDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            using (DbDataReader dr = myReader)
            {
                List<CoScheduling.Core.Model.UAV_RANGE> lst = GetList(dr);
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
            strSql.Append(" FROM UAV_RANGE ");
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
            strSql.Append(" FROM UAV_RANGE ");
            if (strWhere.Trim() != "")
            {
                strSql.Append("WHERE " + strWhere);
            }
            strSql.Append(" ORDER BY PLATFORM_ID");
            DataSet dsSat = new DataSet();
            SqlDataAdapter odaSat = new SqlDataAdapter(strSql.ToString(), connectionString);
            if (dsSat.Tables["UAV_RANGE"] != null)
            {
                dsSat.Tables["UAV_RANGE"].Clear();
            }

            odaSat.Fill(dsSat, "UAV_RANGE");

            return dsSat;
        }
        #region -------- 私有方法，通常情况下无需修改 --------
        /// <summary>
        /// 由一行数据得到一个实体,还有很多问题，什么时候用try catch,什么时候不用
        /// </summary>
        private static Model.UAV_RANGE GetModel(DbDataReader dr)
        {

            CoScheduling.Core.Model.UAV_RANGE model = new CoScheduling.Core.Model.UAV_RANGE();
            model.PLATFORM_ID = Convert.ToDecimal(dr["PLATFORM_ID"]);
            model.PLATFORM_Name = Convert.ToString(dr["PLATFORM_Name"]);
            model.NumberOfSensor = Convert.ToDecimal(dr["NumberOfSensor"]);
            model.CruisingVelocity = Convert.ToDecimal(dr["CruisingVelocity"]);
            model.RollVelocity = Convert.ToDecimal(dr["RollVelocity"]);
            model.PitchVelocity = Convert.ToDecimal(dr["PitchVelocity"]);
            model.MaxVelocity = Convert.ToDecimal(dr["MaxVelocity"]);
            model.MinVelocity = Convert.ToDecimal(dr["MinVelocity"]);
            model.Acceleration = Convert.ToDecimal(dr["Acceleration"]);
            model.CruisingTime = Convert.ToDecimal(dr["CruisingTime"]);

            model.MaxSlewAngle = Convert.ToDecimal(dr["MaxSlewAngle"]);
            model.MinSlewAngle = Convert.ToDecimal(dr["MinSlewAngle"]);
            model.CruisingAltitude = Convert.ToDecimal(dr["CruisingAltitude"]);
            model.MaxAltitude = Convert.ToDecimal(dr["MaxAltitude"]);
            model.MaxDistance = Convert.ToDecimal(dr["MaxDistance"]);
            model.MinTurningRadius = Convert.ToDecimal(dr["MinTurningRadius"]);
            model.PayLoad = Convert.ToDecimal(dr["PayLoad"]);
            model.MaxLoad = Convert.ToDecimal(dr["MaxLoad"]);
            model.Base_ID = Convert.ToDecimal(dr["Base_ID"]);
            return model;
        }
        /// <summary>
        /// 由DbDataReader得到泛型数据列表
        /// </summary>
        private static List<Model.UAV_RANGE> GetList(DbDataReader dr)
        {
            List<Model.UAV_RANGE> lst = new List<Model.UAV_RANGE>();
            while (dr.Read())
            {
                lst.Add(GetModel(dr));
            }
            return lst;
        }

        #endregion

    }
}
