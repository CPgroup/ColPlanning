using System;
using System.Collections.Generic;
using System.Text;
using CoScheduling.Core.Generic;
using CoScheduling.Core.DBUtility;
using CoScheduling.Core.DBUtility;

namespace CoScheduling.Core.DBUtility
{
    public class ImageServer
    {
        public static string _connectionString;

        public  void ConServer()
        { 
            _connectionString = GetConnectionString(); 
        }

        public string GetConnectionString()
        {
            _connectionString = SetConnectionString();
            return _connectionString;
        }

        public string SetConnectionString()
        {
            try
            {
                string xmlFile = System.Windows.Forms.Application.StartupPath + "\\Setting.xml";
                if (!System.IO.File.Exists(xmlFile))
                {
                    throw (new Exception("配置文件不存在"));
                }
                myXML _XML = new myXML(xmlFile);
                string ServiceURL = _XML.GetElement("ImageServices", "IP");
                ServiceURL += " ";
                ServiceURL += _XML.GetElement("ImageServices", "serverName");

                return ServiceURL;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
