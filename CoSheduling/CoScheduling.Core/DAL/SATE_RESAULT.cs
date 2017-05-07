//------------------------------------------------------------------------------
// 创建标识: 刘宝举
// 创建描述: 卫星覆盖任务数据库访问类
// 创建时间:2017.5.7
// 文件版本:1.0
// 功能描述: 卫星覆盖任务数据库的管理核心代码
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
   public class SATE_RESAULT
    {
        //数据库连接字符串(web.config来配置)，可以动态更改connectionString支持多数据库.		
        public static string connectionString;
       
       public SATE_RESAULT()
        {
            connectionString = PubConstant.GetConnectionString("");
        }

       /// <summary>
       /// 获取泛型数据列表
       /// </summary>
       public List<Model.SATE_RESAULT> GetList(string whereclause)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("SELECT * FROM SATE_RESAULT ");
           strSql.Append(" WHERE " + whereclause); ;
           using (SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
           {
               List<Model.SATE_RESAULT> lst = GetList(dr);
               return lst;
           }
       }
       /// <summary>
       /// 获取全部记录
       /// </summary>
       /// <returns></returns>
       public static List<CoScheduling.Core.Model.SATE_RESAULT> GetList()
       {
           StringBuilder StrSql = new StringBuilder();
           StrSql.Append("SELECT * FROM SATE_RESAULT");

           using (DbDataReader dr = DbHelperSQL.ExecuteReader(StrSql.ToString()))
           {
               List<CoScheduling.Core.Model.SATE_RESAULT> lst = GetList(dr);
               dr.Close();
               return lst;
           }
       }

       #region -------- 私有方法，通常情况下无需修改 --------

       /// <summary>
       /// 由一行数据得到一个实体,还有很多问题，什么时候用try catch,什么时候不用
       /// </summary>
       private static Model.SATE_RESAULT GetModel(DbDataReader dr)
       {

           CoScheduling.Core.Model.SATE_RESAULT model = new CoScheduling.Core.Model.SATE_RESAULT();
           model.LSTR_SEQID = Convert.ToDecimal(dr["LSTR_SEQID"]);
           model.SCHEMEID = Convert.ToDecimal(dr["SCHEMEID"]);
           model.TASKID = Convert.ToDecimal(dr["TASKID"]);
           try
           {
               model.POLYGONSTRING = Convert.ToString(dr["POLYGONSTRING"]);
           }
           catch
           {
               model.POLYGONSTRING = Convert.ToString("N/A");
           }

          
           try
           {
               model.STARTTIME = Convert.ToDateTime(dr["STARTTIME"]);
           }
           catch
           {
               model.STARTTIME = Convert.ToDateTime("N/A");
           }
           try
           {
               model.ENDTIME = Convert.ToDateTime(dr["ENDTIME"]);
           }
           catch
           {
               model.ENDTIME = Convert.ToDateTime("N/A");
           }
           try
           {
               model.SATID = Convert.ToDecimal(dr["SATID"]);
           }
           catch
           {
               model.SATID = Convert.ToDecimal("-1");
           }
           try
           {
               model.SENSOR_ID = Convert.ToDecimal(dr["SENSOR_ID"]);
           }
           catch
           {
               model.SENSOR_ID = Convert.ToDecimal("-1");
           }
           try
           {
               model.SENSOR_STKNAME = Convert.ToString(dr["SENSOR_STKNAME"]);
           }
           catch
           {
               model.SENSOR_STKNAME = Convert.ToString("N/A");
           }
           try
           {
               model.SAT_STKNAME = Convert.ToString(dr["SAT_STKNAME"]);
           }
           catch
           {
               model.SAT_STKNAME = Convert.ToString("N/A");
           }
           try
           {
               model.SLEW_ANGLE = Convert.ToDecimal(dr["SLEW_ANGLE"]);
           }
           catch (Exception es)
           {
               model.SLEW_ANGLE = Convert.ToDecimal("-1");
           }
           try
           {
               model.AngularVelocity = Convert.ToDecimal(dr["AngularVelocity"]);
           }
           catch
           {
               model.AngularVelocity = Convert.ToDecimal("-1");
           }
         
           
           return model;
       }

       /// <summary>
       /// 由DbDataReader得到泛型数据列表
       /// </summary>
       private static List<Model.SATE_RESAULT> GetList(DbDataReader dr)
       {
           List<Model.SATE_RESAULT> lst = new List<Model.SATE_RESAULT>();
           while (dr.Read())
           {
               lst.Add(GetModel(dr));
           }
           return lst;
       }

       #endregion

    }
}
