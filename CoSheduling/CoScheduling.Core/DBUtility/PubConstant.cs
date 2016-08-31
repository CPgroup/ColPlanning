using System;
using System.Configuration;
using System.Windows.Forms;
using CoScheduling.Core.Generic;
using CoScheduling.Core.DBUtility;
using CoScheduling.Core.DEncrypt;
namespace CoScheduling.Core.DBUtility
{

    public class PubConstant
    {
        private static string _connectionString;
        /// <summary>
        /// ��������ȡ�����ַ���
        /// ���ߣ����ǿ
        /// ʱ�䣺2010.8.28.
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
                    MessageBox.Show("�����ļ������ڣ�","��ʾ");
                    return;
                }
                myXML _XML = new myXML(xmlFile);
                string server = _XML.GetElement("DataBase", "Server");
                string database = _XML.GetElement("DataBase", "DataBase");
                string user, password;
                try
                {
                    user = _XML.GetElement("DataBase", "User");// DEncrypt.DEncrypt.Decrypt(_XML.GetElement("DataBase", "User"));
                    password = _XML.GetElement("DataBase", "Password");// DEncrypt.DEncrypt.Decrypt(_XML.GetElement("DataBase", "Password"));
                }
                catch (Exception ex)
                {
                    user = "";
                    password = "";
                }
                SetConnectionString(server, database, user, password);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public static string GetFilePath(string tag)
        {
            try
            {
                string xmlFile = System.Windows.Forms.Application.StartupPath + "\\Setting.xml";
                if (!System.IO.File.Exists(xmlFile))
                {
                    throw (new Exception("�����ļ�������"));
                }
                myXML _XML = new myXML(xmlFile);
                string filepath ="";


                try
                {
                    filepath = _XML.GetElement("FilePath", tag);
                }
                catch (Exception ex)
                {
                    throw (new Exception("�����ļ���δ���øõ�ַ"));
                }
                return filepath;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// �������ݿ����
        /// </summary>
        public static void SetConnectionString(string Server, string DataBase, string User, string Password)
        {
            //_connectionString = "Data Source=" + Server + ";" + "persist security info=true;" + "user id=" + CoScheduling.Core.DEncrypt.DEncrypt.Decrypt(User) + ";" + "password=" + CoScheduling.Core.DEncrypt.DEncrypt.Decrypt(Password) + ";" + "Initial Catalog=" + DataBase;
            _connectionString = "Data Source=" + Server + ";" + "persist security info=true;" + "user id=" + User + ";" + "password=" + Password + ";" + "Initial Catalog=" + DataBase;
            DbHelperSQL.connectionString = _connectionString;
        }

    }
}