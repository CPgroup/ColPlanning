//------------------------------------------------------------------------------
// 创建标识: 李佳霖
// 创建描述: 灾害遥感应用知识数据库访问类
// 创建时间:2017.3.21
// 文件版本:1.0
// 功能描述: 实现灾害遥感应用知识数据库访问
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
    public class DisaKnowledge
    {
        //数据库连接字符串(web.config来配置)，可以动态更改connectionString支持多数据库.		
        public static string connectionString;
        //构造数据库的连接语句
        public DisaKnowledge()
        {
            connectionString = @"server=(local);database=disas_knowledge; User=sa; Password=lhf2017 ";//建立的时候就确定了，连接数据库的路径
        }
        //public decimal taskid = "";

        //该类中需要实现 通过DisasterType来查找所需的空间分辨率和传感器类型
        public Model.DisaKnowledge GetModel(decimal DisasterID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * From Disas_Knowledge ");
            strSql.Append(" Where Disaster_ID=" + DisasterID);
            Model.DisaKnowledge model = null;

            //数据库连接
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(strSql.ToString(), connection);

            connection.Open();
            SqlDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            
            using(DbDataReader dr = myReader)
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
        /// 由一行数据得到一个实体,还有很多问题，什么时候用try catch,什么时候不用
        /// </summary>
        private Model.DisaKnowledge GetModel(DbDataReader dr)
        {

            CoScheduling.Core.Model.DisaKnowledge model = new CoScheduling.Core.Model.DisaKnowledge();
            model.Disaster_ID = Convert.ToDecimal(dr["Disaster_ID"]);
            model.Disaster_Name = Convert.ToString(dr["Disaster_Name"]);
            model.Max_SpatialResolution = Convert.ToDecimal(dr["Max_spatialresolution"]);

            model.UV_Needed = Convert.ToBoolean(dr["UV_needed"]);
            model.LasFlu_Needed = Convert.ToBoolean(dr["LasFlu_needed"]);
            model.VISNIR_Needed = Convert.ToBoolean(dr["VISNIR_needed"]);
            model.SIR_Needed = Convert.ToBoolean(dr["SIR_needed"]);
            model.MIR_Needed = Convert.ToBoolean(dr["MIR_needed"]);
            model.TIR_Needed = Convert.ToBoolean(dr["TIR_needed"]);
            model.SAR_X_Needed = Convert.ToBoolean(dr["SAR_X_needed"]);
            model.SAR_C_Needed = Convert.ToBoolean(dr["SAR_C_needed"]);
            model.SAR_S_Needed = Convert.ToBoolean(dr["SAR_S_needed"]);
            model.SAR_L_Needed = Convert.ToBoolean(dr["SAR_L_needed"]);
            model.HypSpe_Needed = Convert.ToBoolean(dr["HypSpe_needed"]);
            model.CamSpy_Needed = Convert.ToBoolean(dr["CamSpy_needed"]);
            return model;
        }

        /// <summary>
        /// 由DbDataReader得到泛型数据列表
        /// </summary>
        private List<Model.DisaKnowledge> GetList(DbDataReader dr)
        {
            List<Model.DisaKnowledge> lst = new List<Model.DisaKnowledge>();
            while (dr.Read())
            {
                lst.Add(GetModel(dr));
            }
            return lst;
        }

        #endregion


    }
}
