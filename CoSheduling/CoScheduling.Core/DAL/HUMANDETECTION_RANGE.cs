//------------------------------------------------------------------------------
// 创建标识: 李佳霖
// 创建描述: 地面摄像头平台属性数据库访问类
// 创建时间:2017.4.18
// 文件版本:1.0
// 功能描述: 地面摄像头平台属性数据库访问
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
    public class HUMANDETECTION_RANGE
    {
        //数据库连接字符串(web.config来配置)，可以动态更改connectionString支持多数据库.		
        public static string connectionString;
        public HUMANDETECTION_RANGE()
        {
            connectionString = PubConstant.GetConnectionString("");
        }

        /// <summary>
        /// 志愿者平台添加函数,添加删除和管理的数据库连接还存在问题
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Model.HUMANDETECTION_RANGE model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO HUMANDETECTION_RANGE(");
            strSql.Append("PLATFORM_ID,PLATFORM_Name,NumberOfSensor,");
            strSql.Append("MaxCruisingTime)");
            strSql.Append(" Values(");
            strSql.Append("@in_PLATFORM_ID,@in_PLATFORM_Name,@in_NumberOfSensor,");
            strSql.Append("@in_MaxCruisingTime)");
            SqlParameter[] cmdParms = new SqlParameter[]{
                new SqlParameter("@in_PLATFORM_ID", SqlDbType.Decimal),
                new SqlParameter("@in_PLATFORM_Name", SqlDbType.NVarChar),
                new SqlParameter("@in_NumberOfSensor", SqlDbType.Decimal),
                new SqlParameter("@in_MaxCruisingTime", SqlDbType.Decimal)};

            cmdParms[0].Value = model.PLATFORM_ID;
            cmdParms[1].Value = model.PLATFORM_Name;
            cmdParms[2].Value = model.NumberOfSensor;
            cmdParms[3].Value = model.MaxCruisingTime;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }
        /// <summary>
        /// 根据志愿者平台ID修改数据库中的一条记录
        /// </summary>
        /// <param name="model"></param>志愿者平台实体类的实例
        /// <returns></returns>返回值为修改的记录数
        public int Update(Model.HUMANDETECTION_RANGE model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update HUMANDETECTION_RANGE set ");

            strSql.Append("PLATFORM_Name=@in_PLATFORM_Name,");
            strSql.Append("NumberOfSensor=@in_NumberOfSensor,");
            strSql.Append("MaxCruisingTime=@in_MaxCruisingTime");

            strSql.Append(" where PLATFORM_ID=@in_PLATFORM_ID");

            SqlParameter[] cmdParms = new SqlParameter[]{
                new SqlParameter("@in_PLATFORM_ID", SqlDbType.Decimal),
                new SqlParameter("@in_PLATFORM_Name", SqlDbType.NVarChar),
                new SqlParameter("@in_NumberOfSensor", SqlDbType.Decimal),
                new SqlParameter("@in_MaxCruisingTime", SqlDbType.Decimal)};

            cmdParms[0].Value = model.PLATFORM_ID;
            cmdParms[1].Value = model.PLATFORM_Name;
            cmdParms[2].Value = model.NumberOfSensor;
            cmdParms[3].Value = model.MaxCruisingTime;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 根据志愿者平台编号删除一条记录
        /// </summary>
        /// <param name="SensorID"></param>
        /// <returns></returns>
        public int Delete(decimal PLATFORM_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Delete from HUMANDETECTION_RANGE");
            strSql.Append(" Where PLATFORM_ID=@in_PLATFORM_ID");
            SqlParameter[] cmdParms = new SqlParameter[]{
                new SqlParameter("@in_PLATFORM_ID",SqlDbType.Decimal)
            };
            cmdParms[0].Value = PLATFORM_ID;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 根据志愿者平台ID判断是否存在该记录
        /// </summary>
        /// <param name="SensorID"></param>
        /// <returns></returns>
        public bool Exists(string PLATFORM_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select count(1) from HUMANDETECTION_RANGE ");
            strSql.Append(" Where PLATFORM_ID=" + PLATFORM_ID);
            return DbHelperSQL.Exists(strSql.ToString());
        }
        //该类中需要实现 通过PLATFORM_ID来查找所需的飞艇速度和续航时间
        public Model.HUMANDETECTION_RANGE GetModel(decimal platformid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * From HUMANDETECTION_RANGE ");
            strSql.Append(" Where PLATFORM_ID=" + platformid);
            Model.HUMANDETECTION_RANGE model = null;

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
        public List<Model.HUMANDETECTION_RANGE> GetList(string whereClause)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * From HUMANDETECTION_RANGE ");
            strSql.Append(" Where " + whereClause);

            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<CoScheduling.Core.Model.HUMANDETECTION_RANGE> lst = GetList(dr);
                dr.Close();
                return lst;
            }
        }
        /// <summary>
        /// 获取全部记录
        /// </summary>
        /// <returns></returns>
        public List<CoScheduling.Core.Model.HUMANDETECTION_RANGE> GetList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * From HUMANDETECTION_RANGE order by PLATFORM_ID desc");


            using (DbDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<CoScheduling.Core.Model.HUMANDETECTION_RANGE> lst = GetList(dr);
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
            strSql.Append(" FROM HUMANDETECTION_RANGE ");
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
            strSql.Append(" FROM HUMANDETECTION_RANGE ");
            if (strWhere.Trim() != "")
            {
                strSql.Append("WHERE " + strWhere);
            }
            strSql.Append(" ORDER BY PLATFORM_ID");
            DataSet dsSat = new DataSet();
            SqlDataAdapter odaSat = new SqlDataAdapter(strSql.ToString(), connectionString);
            if (dsSat.Tables["HUMANDETECTION_RANGE"] != null)
            {
                dsSat.Tables["HUMANDETECTION_RANGE"].Clear();
            }

            odaSat.Fill(dsSat, "HUMANDETECTION_RANGE");

            return dsSat;
        }
        #region -------- 私有方法，通常情况下无需修改 --------
        /// <summary>
        /// 由一行数据得到一个实体,还有很多问题，什么时候用try catch,什么时候不用
        /// </summary>
        private Model.HUMANDETECTION_RANGE GetModel(DbDataReader dr)
        {

            CoScheduling.Core.Model.HUMANDETECTION_RANGE model = new CoScheduling.Core.Model.HUMANDETECTION_RANGE();
            model.PLATFORM_ID = Convert.ToDecimal(dr["PLATFORM_ID"]);
            model.PLATFORM_Name = Convert.ToString(dr["PLATFORM_Name"]);
            model.NumberOfSensor = Convert.ToDecimal(dr["NumberOfSensor"]);
            try
            {
                model.MaxCruisingTime = Convert.ToDecimal(dr["MaxCruisingTime"]);
            }
            catch
            {
                model.MaxCruisingTime = Convert.ToDecimal("-1");
            }
            
            return model;
        }
        /// <summary>
        /// 由DbDataReader得到泛型数据列表
        /// </summary>
        private List<Model.HUMANDETECTION_RANGE> GetList(DbDataReader dr)
        {
            List<Model.HUMANDETECTION_RANGE> lst = new List<Model.HUMANDETECTION_RANGE>();
            while (dr.Read())
            {
                lst.Add(GetModel(dr));
            }
            return lst;
        }

        #endregion





    }
}
