using System;
using System.Configuration;
using System.Windows.Forms;
using CoScheduling.Core.Generic;
namespace CoScheduling.Core.DBUtility
{

    public class PubConstantOra
    {
        private static string _connectionString;
        /// <summary>
        /// 类名：获取Oracle连接字符串
        /// 作者：董毅博
        /// 时间：2013.12.4.
        /// 说明：基于PubConstant修改
        /// </summary>
        public static string ConnectionString
        {
            get
            {
                return _connectionString;
            }
            set
            {
                _connectionString = value;
            }
        }

        /// <summary>
        /// 得到web.config里配置项的数据库连接字符串。
        /// </summary>
        /// <param name="configName"></param>
        /// <returns></returns>
        public static string GetConnectionString(string configName)
        {
            return _connectionString;
        }
        /// <summary>
        /// 从Setting.xml得到数据库链接字符串
        /// </summary>
        public static string GetConnectionString()
        {
            SetConnectionString();
            return _connectionString;
        }

        /// <summary>
        /// 设置数据库参数
        /// </summary>
        public static void SetConnectionString()
        {
            try
            {
                string xmlFile = System.Windows.Forms.Application.StartupPath + "\\Setting.xml";
                if (!System.IO.File.Exists(xmlFile))
                {
                    throw(new Exception("配置文件不存在"));
                }
                myXML _XML = new myXML(xmlFile);
                string server = _XML.GetElement("DataBaseOra", "Server");
                //string database = _XML.GetElement("DataBaseOra", "DataBase");
                string user=_XML.GetElement("DataBaseOra","User");
                string password=_XML.GetElement("DataBaseOra","Password");

                //try
                //{
                //    user = DEncrypt.DEncrypt.Decrypt(_XML.GetElement("DataBaseOra", "User"));
                //    password = DEncrypt.DEncrypt.Decrypt(_XML.GetElement("DataBaseOra", "Password"));
                //}
                //catch (Exception ex)
                //{
                //    user = "";
                //    password = "";
                //}
                SetConnectionString(server, user, password);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// 设置数据库参数
        /// </summary>
        public static void SetConnectionString(string Server,string User,string Password)
        {
            _connectionString = "Data Source=" + Server + ";" +  "user id=" + User + ";" + "password=" + Password;
            DbHelperOra.connectionStringOra = _connectionString;
        }
    }
}