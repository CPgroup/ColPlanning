//------------------------------------------------------------------------------
// 创建标识: 李佳霖
// 创建描述: 无人机基站属性数据库访问类
// 创建时间:2017.3.31
// 文件版本:1.0
// 功能描述: 无人机基站属性数据库访问
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
    public class UAV_Base
    {
        //数据库连接字符串(web.config来配置)，可以动态更改connectionString支持多数据库.		
        public static string connectionString;
        //构造数据库的连接语句
        public UAV_Base()
        {
            connectionString = @"server=(local);database=CoMonitoring; User=sa; Password=123 ";//建立的时候就确定了，连接数据库的路径
        }

        //该类中需要实现 通过PLATFORM_ID来查找所需的无人机速度和续航时间
        public Model.UAV_Base GetModel(decimal baseid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * From UAV_Base ");
            strSql.Append(" Where Base_ID=" + baseid);
            Model.UAV_Base model = null;

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

        #region -------- 私有方法，通常情况下无需修改 --------
        /// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        private Model.UAV_Base GetModel(DbDataReader dr)
        {

            CoScheduling.Core.Model.UAV_Base model = new CoScheduling.Core.Model.UAV_Base();
            model.Base_ID = Convert.ToDecimal(dr["Base_ID"]);
            model.Base_Name = Convert.ToString(dr["Base_Name"]);
            model.NumberOfUAV = Convert.ToDecimal(dr["NumberOfUAV"]);
            model.BaseLongitude = Convert.ToDecimal(dr["BaseLongitude"]);
            model.BaseLatitude = Convert.ToDecimal(dr["BaseLatitude"]);
            model.MTOL = Convert.ToDecimal(dr["MTOL"]);
            model.MTOW = Convert.ToDecimal(dr["MTOW"]);
            model.Slope = Convert.ToDecimal(dr["Slope"]);
            model.PavementType = Convert.ToString(dr["PavementType"]);
            
            return model;
        }
        /// <summary>
        /// 由DbDataReader得到泛型数据列表
        /// </summary>
        private List<Model.UAV_Base> GetList(DbDataReader dr)
        {

            List<Model.UAV_Base> lst = new List<Model.UAV_Base>();
            while (dr.Read())
            {
                lst.Add(GetModel(dr));
            }
            return lst;
        }

        #endregion

    }
}
