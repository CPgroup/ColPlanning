using System;
using System.Collections.Generic;

using System.Net;
using System.Text;

namespace CoScheduling.Core.Generic
{
    /// <summary>
    /// 类名：系统变量类
    /// 作者：李光强
    /// 时间：2013.7.4
    /// 版本：V1.0
    /// </summary>
    public class SysEnviriment
    {
        public static string SysAuthor { get { return "中南大学"; } }
        public static string SysDate { get { return "2016"; } }
        public static string ExpDate { get { return "2016"; } }
        /// <summary>
        /// km/Rad
        /// </summary>
        public static double LengthPerRad { get { return 111.319496154785; } }

        public static string getLocalIP()
        {
            try
            {
                IPAddress ip;
                string HostName = Dns.GetHostName();
                System.Net.IPHostEntry HostIP = Dns.GetHostByName(HostName);
                ip = HostIP.AddressList[0];
                return ip.ToString();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
