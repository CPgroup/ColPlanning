//------------------------------------------------------------------------------
// 创建标识: 董毅博
// 创建描述: 任务方案私有载荷访问类
// 创建时间:2013.6.13
// 文件版本:1.0
// 功能描述: 
// 修改标识: 
// 修改描述: 
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using CoScheduling.Core.DBUtility;
using System.Data;
using System.Data.Common;

namespace CoScheduling.Core.DAL
{
    public class TASKSCHEME_PRIVATE_SENSOR
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.TASKSCHEME_PRIVATE_SENSOR model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO LHF.TASKSCHEME_PRIVATE_SENSOR(");
            strSql.Append("SENSOR_ID,SENSOR_NAME,SENSOR_STKNAME,SAT_ID,SAT_STKNAME,SENSOR_TYPE,SENSOR_PARONE,SENSOR_PARTWO,SENSOR_PARTHREE,SENSOR_PARFOUR,TYPEID,SATTYPE,SCHEMEID,SENSORANGLEH,SEMSORANGLE)");
            strSql.Append(" VALUES (");
            strSql.Append("@in_SENSOR_ID,@in_SENSOR_NAME,@in_SENSOR_STKNAME,@in_SAT_ID,@in_SAT_STKNAME,@in_SENSOR_TYPE,@in_SENSOR_PARONE,@in_SENSOR_PARTWO,@in_SENSOR_PARTHREE,@in_SENSOR_PARFOUR,@in_TYPEID,@in_SATTYPE,@in_SCHEMEID,@in_SENSORANGLEH,@in_SENSORANGLE)");
            SqlParameter[] cmdParms = new SqlParameter[]{
				new SqlParameter("@in_SENSOR_ID", SqlDbType.Decimal),
				new SqlParameter("@in_SENSOR_NAME", SqlDbType.NVarChar),
				new SqlParameter("@in_SENSOR_STKNAME", SqlDbType.NVarChar),
				new SqlParameter("@in_SAT_ID", SqlDbType.Decimal),
				new SqlParameter("@in_SAT_STKNAME", SqlDbType.NVarChar),
				new SqlParameter("@in_SENSOR_TYPE", SqlDbType.NVarChar),
				new SqlParameter("@in_SENSOR_PARONE", SqlDbType.Decimal),
				new SqlParameter("@in_SENSOR_PARTWO", SqlDbType.Decimal),
				new SqlParameter("@in_SENSOR_PARTHREE", SqlDbType.Decimal),
				new SqlParameter("@in_SENSOR_PARFOUR", SqlDbType.Decimal),
				new SqlParameter("@in_TYPEID", SqlDbType.Decimal),
				new SqlParameter("@in_SATTYPE", SqlDbType.Decimal),
				new SqlParameter("@in_SCHEMEID", SqlDbType.Decimal),
				new SqlParameter("@in_SENSORANGLEH", SqlDbType.Decimal),
                new SqlParameter("@in_SENSORANGLE", SqlDbType.Decimal)};
            cmdParms[0].Value = model.SENSOR_ID;
            cmdParms[1].Value = model.SENSOR_NAME;
            cmdParms[2].Value = model.SENSOR_STKNAME;
            cmdParms[3].Value = model.SAT_ID;
            cmdParms[4].Value = model.SAT_STKNAME;
            cmdParms[5].Value = model.SENSOR_TYPE;
            cmdParms[6].Value = model.SENSOR_PARONE;
            cmdParms[7].Value = model.SENSOR_PARTWO;
            cmdParms[8].Value = model.SENSOR_PARTHREE;
            cmdParms[9].Value = model.SENSOR_PARFOUR;
            cmdParms[10].Value = model.TYPEID;
            cmdParms[11].Value = model.SATTYPE;
            cmdParms[12].Value = model.SCHEMEID;
            cmdParms[13].Value = model.SENSORANGLEH;
            cmdParms[14].Value = model.SENSORANGLE;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Model.TASKSCHEME_PRIVATE_SENSOR model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE LHF.TASKSCHEME_PRIVATE_SENSOR SET ");
            strSql.Append("SENSOR_NAME=@in_SENSOR_NAME,");
            strSql.Append("SENSOR_STKNAME=@in_SENSOR_STKNAME,");
            strSql.Append("SAT_ID=@in_SAT_ID,");
            strSql.Append("SAT_STKNAME=@in_SAT_STKNAME,");
            strSql.Append("SENSOR_TYPE=@in_SENSOR_TYPE,");
            strSql.Append("SENSOR_PARONE=@in_SENSOR_PARONE,");
            strSql.Append("SENSOR_PARTWO=@in_SENSOR_PARTWO,");
            strSql.Append("SENSOR_PARTHREE=@in_SENSOR_PARTHREE,");
            strSql.Append("SENSOR_PARFOUR=@in_SENSOR_PARFOUR,");
            strSql.Append("TYPEID=@in_TYPEID,");
            strSql.Append("SATTYPE=@in_SATTYPE,");
            strSql.Append("SCHEMEID=@in_SCHEMEID,");
            strSql.Append("SENSORANGLEH=@in_SENSORANGLEH,");
            strSql.Append("SENSORANGLE=@in_SENSORANGLE");
            strSql.Append(" WHERE SENSOR_ID=@in_SENSOR_ID");
            SqlParameter[] cmdParms = new SqlParameter[]{
				new SqlParameter("@in_SENSOR_ID", SqlDbType.Decimal),
				new SqlParameter("@in_SENSOR_NAME", SqlDbType.NVarChar),
				new SqlParameter("@in_SENSOR_STKNAME", SqlDbType.NVarChar),
				new SqlParameter("@in_SAT_ID", SqlDbType.Decimal),
				new SqlParameter("@in_SAT_STKNAME", SqlDbType.NVarChar),
				new SqlParameter("@in_SENSOR_TYPE", SqlDbType.NVarChar),
				new SqlParameter("@in_SENSOR_PARONE", SqlDbType.Decimal),
				new SqlParameter("@in_SENSOR_PARTWO", SqlDbType.Decimal),
				new SqlParameter("@in_SENSOR_PARTHREE", SqlDbType.Decimal),
				new SqlParameter("@in_SENSOR_PARFOUR", SqlDbType.Decimal),
				new SqlParameter("@in_TYPEID", SqlDbType.Decimal),
				new SqlParameter("@in_SATTYPE", SqlDbType.Decimal),
				new SqlParameter("@in_SCHEMEID", SqlDbType.Decimal),
				new SqlParameter("@in_SENSORANGLEH", SqlDbType.Decimal),
                new SqlParameter("@in_SENSORANGLE", SqlDbType.Decimal)};
            cmdParms[0].Value = model.SENSOR_ID;
            cmdParms[1].Value = model.SENSOR_NAME;
            cmdParms[2].Value = model.SENSOR_STKNAME;
            cmdParms[3].Value = model.SAT_ID;
            cmdParms[4].Value = model.SAT_STKNAME;
            cmdParms[5].Value = model.SENSOR_TYPE;
            cmdParms[6].Value = model.SENSOR_PARONE;
            cmdParms[7].Value = model.SENSOR_PARTWO;
            cmdParms[8].Value = model.SENSOR_PARTHREE;
            cmdParms[9].Value = model.SENSOR_PARFOUR;
            cmdParms[10].Value = model.TYPEID;
            cmdParms[11].Value = model.SATTYPE;
            cmdParms[12].Value = model.SCHEMEID;
            cmdParms[13].Value = model.SENSORANGLEH;
            cmdParms[14].Value = model.SENSORANGLE;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), cmdParms);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(decimal SENSOR_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM LHF.TASKSCHEME_PRIVATE_SENSOR ");
            strSql.Append(" WHERE SENSOR_ID="+SENSOR_ID);

            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(decimal SENSOR_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM LHF.TASKSCHEME_PRIVATE_SENSOR");
            strSql.Append(" WHERE SENSOR_ID="+SENSOR_ID);

            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.TASKSCHEME_PRIVATE_SENSOR GetModel(decimal SENSOR_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM LHF.TASKSCHEME_PRIVATE_SENSOR ");
            strSql.Append(" WHERE SENSOR_ID="+SENSOR_ID);
            Model.TASKSCHEME_PRIVATE_SENSOR model = null;
            using (DbDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (dr.Read())
                {
                    model = GetModel(dr);
                }
                return model;
            }
        }

        /// <summary>
        /// 根据stk名称得到一个对象实体
        /// </summary>
        /// <param name="sat_name"></param>
        /// <param name="sensor_name"></param>
        /// <returns></returns>
        public Model.TASKSCHEME_PRIVATE_SENSOR GetModel(string sat_stkname,string sensor_stkname,decimal schemeid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM LHF.TASKSCHEME_PRIVATE_SENSOR ");
            strSql.Append(" WHERE SAT_STKNAME='" + sat_stkname+"'");
            strSql.Append(" AND SENSOR_STKNAME='" + sensor_stkname + "'");
            strSql.Append(" AND SCHEMEID=" + schemeid);
            Model.TASKSCHEME_PRIVATE_SENSOR model = null;
            using (DbDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (dr.Read())
                {
                    model = GetModel(dr);
                }
                return model;
            }
        }
        /// <summary>
        /// 获取泛型数据列表
        /// </summary>
        public List<Model.TASKSCHEME_PRIVATE_SENSOR> GetList()
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM LHF.TASKSCHEME_PRIVATE_SENSOR");
            using (DbDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.TASKSCHEME_PRIVATE_SENSOR> lst = GetList(dr);
                return lst;
            }
        }
        /// <summary>
        /// 根据schemeid获取泛型数据列表
        /// </summary>
        public List<Model.TASKSCHEME_PRIVATE_SENSOR> GetList(decimal schemeid)
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM LHF.TASKSCHEME_PRIVATE_SENSOR");
            strSql.Append(" WHERE SCHEMEID=" + schemeid);
            using (DbDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.TASKSCHEME_PRIVATE_SENSOR> lst = GetList(dr);
                return lst;
            }
        }

        public List<Model.TASKSCHEME_PRIVATE_SENSOR> GetList(string condition)
        {
            StringBuilder strSql = new StringBuilder("SELECT * FROM LHF.TASKSCHEME_PRIVATE_SENSOR");
            if (condition.Trim() != "")
            {
                strSql.Append(" WHERE " + condition);
            }
            strSql.Append(" ORDER BY SENSOR_ID");
            using (DbDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                List<Model.TASKSCHEME_PRIVATE_SENSOR> lst = GetList(dr);
                return lst;
            }
        }
        /// <summary>
        /// 得到数据条数
        /// </summary>
        public int GetCount(string condition)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT (*) ");
            strSql.Append(" FROM LHF.TASKSCHEME_PRIVATE_SENSOR ");
            if (condition.Trim() != "")
            {
                strSql.Append(" where " + condition);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }


        #region -------- 私有方法，通常情况下无需修改 --------

        /// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        private Model.TASKSCHEME_PRIVATE_SENSOR GetModel(DbDataReader dr)
        {
            Model.TASKSCHEME_PRIVATE_SENSOR model = new Model.TASKSCHEME_PRIVATE_SENSOR();
            model.SENSOR_ID = Convert.ToDecimal(dr["SENSOR_ID"]);
            model.SENSOR_NAME = Convert.ToString(dr["SENSOR_NAME"]);
            model.SENSOR_STKNAME = Convert.ToString(dr["SENSOR_STKNAME"]);
            model.SAT_ID = Convert.ToDecimal(dr["SAT_ID"]);
            model.SAT_STKNAME = Convert.ToString(dr["SAT_STKNAME"]);
            model.SENSOR_TYPE = Convert.ToString(dr["SENSOR_TYPE"]);
            model.SENSOR_PARONE = Convert.ToDecimal(dr["SENSOR_PARONE"]);
            model.SENSOR_PARTWO = Convert.ToDecimal(dr["SENSOR_PARTWO"]);
            model.SENSOR_PARTHREE = Convert.ToDecimal(dr["SENSOR_PARTHREE"]);
            model.SENSOR_PARFOUR = Convert.ToDecimal(dr["SENSOR_PARFOUR"]);
            model.TYPEID = Convert.ToDecimal(dr["TYPEID"]);
            model.SATTYPE = Convert.ToDecimal(dr["SATTYPE"]);
            model.SCHEMEID = Convert.ToDecimal(dr["SCHEMEID"]);
            model.SENSORANGLEH = Convert.ToDecimal(dr["SENSORANGLEH"]);
            model.SENSORANGLE = Convert.ToDecimal(dr["SENSORANGLE"]);
            return model;
        }

        /// <summary>
        /// 由DbDataReader得到泛型数据列表
        /// </summary>
        private List<Model.TASKSCHEME_PRIVATE_SENSOR> GetList(DbDataReader dr)
        {
            List<Model.TASKSCHEME_PRIVATE_SENSOR> lst = new List<Model.TASKSCHEME_PRIVATE_SENSOR>();
            while (dr.Read())
            {
                lst.Add(GetModel(dr));
            }
            return lst;
        }

        #endregion
    }
}
