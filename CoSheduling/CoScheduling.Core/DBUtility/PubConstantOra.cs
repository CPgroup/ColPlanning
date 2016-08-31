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
        /// ��������ȡOracle�����ַ���
        /// ���ߣ����㲩
        /// ʱ�䣺2013.12.4.
        /// ˵��������PubConstant�޸�
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
        /// �õ�web.config������������ݿ������ַ�����
        /// </summary>
        /// <param name="configName"></param>
        /// <returns></returns>
        public static string GetConnectionString(string configName)
        {
            return _connectionString;
        }
        /// <summary>
        /// ��Setting.xml�õ����ݿ������ַ���
        /// </summary>
        public static string GetConnectionString()
        {
            SetConnectionString();
            return _connectionString;
        }

        /// <summary>
        /// �������ݿ����
        /// </summary>
        public static void SetConnectionString()
        {
            try
            {
                string xmlFile = System.Windows.Forms.Application.StartupPath + "\\Setting.xml";
                if (!System.IO.File.Exists(xmlFile))
                {
                    throw(new Exception("�����ļ�������"));
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
        /// �������ݿ����
        /// </summary>
        public static void SetConnectionString(string Server,string User,string Password)
        {
            _connectionString = "Data Source=" + Server + ";" +  "user id=" + User + ";" + "password=" + Password;
            DbHelperOra.connectionStringOra = _connectionString;
        }
    }
}