using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Threading;
using System.IO;
using System.Web;
using System.Net;


namespace SatOrbit
{
    public partial class SatOrbit : Form
    {
        public SatOrbit()
        {
            InitializeComponent();
        }
        /// <summary>
        /// space-track密码
        /// </summary>
        string code = "";

        string quaryStr = "";

        #region 窗体控件操作
        /// <summary>
        /// 自动添加默认用户名和密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SatOrbit_Load(object sender, EventArgs e)
        {
            this.textName.Text = "aljesdong";
            this.textCode.Text = "19897788aljes";
            code = "19897788aljes";
        }
        /// <summary>
        /// 日期检查按钮事件
        /// 查询数据库中已有的日期
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCheckDate_Click(object sender, EventArgs e)
        {
            List<DateTime> list = new List<DateTime>();

            CoScheduling.Core.DAL.SatelliteOrbit dal_satelliteOrbit = new CoScheduling.Core.DAL.SatelliteOrbit();
            list = dal_satelliteOrbit.GetDate();
            foreach (DateTime dt in list)
            {
                this.textCon.Text += "\r\n" + dt.ToLongDateString() + "存在！";
            }
        }
        /// <summary>
        /// 
        /// 清空提示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClear_Click(object sender, EventArgs e)
        {
            this.textCon.Text = "";
        }
        /// <summary>
        /// 测试是否有Internet网络
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonTestInt_Click(object sender, EventArgs e)
        {
            this.textCon.Text = "";
            Ping p = new Ping();//创建Ping对象p
            try
            {
                PingReply pr = p.Send("www.baidu.com");//向指定IP或者主机名的计算机发送ICMP协议的ping数据包
                if (pr.Status == IPStatus.Success)//如果ping成功
                {
                    this.textCon.Text += "网络连接成功, 执行下面任务...";
                }
                else
                {
                    int times = 0;//重新连接次数;
                    do
                    {
                        if (times >= 12)
                        {
                            this.textCon.Text += "重新尝试连接超过12次,连接失败程序结束";
                            return;
                        }

                        Thread.Sleep(1000);//等待十分钟(方便测试的话，你可以改为1000)
                        pr = p.Send("www.baidu.com");

                        this.textCon.Text += pr.Status;

                        times++;

                    }
                    while (pr.Status != IPStatus.Success);

                    this.textCon.Text += "连接成功";
                    times = 0;//连接成功，重新连接次数清为0;
                }
            }
            catch (System.Exception ex)
            {
                this.textCon.Text += "网络异常！";
            }                  
        }
        /// <summary>
        /// 生成Space-Track查询语句
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonTLE_Click(object sender, EventArgs e)
        {

            code = this.textCode.Text;
            SpaceTrack spacetrack = new SpaceTrack();
            if (this.checkDate.Checked)
            {
                DateTime end = this.dateTimePicker1.Value;
                DateTime start = this.dateTimePicker1.Value.AddDays(-1);
                quaryStr = spacetrack.GetSpaceTrack(getNorad(), start, end, this.textName.Text, code);
                this.textCon.Text = "查询结果：" + "\r\n" + quaryStr;
            }
            else
            {
                quaryStr = spacetrack.GetSpaceTrack(getNorad(), this.textName.Text, code);
                this.textCon.Text = "查询结果：" + "\r\n" + quaryStr;
            }          
        }
        /// <summary>
        /// 更改用户名、密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textName_TextChanged(object sender, EventArgs e)
        {
            this.textCode.Text = "";
            code = "";
        }
        /// <summary>
        /// 单次查询下载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDownload_Click(object sender, EventArgs e)
        {
            //保存在数据库中            
            try
            {
                if (this.checkDate.Checked)
                {
                    List<CoScheduling.Core.Model.SatelliteOrbit> list = new List<CoScheduling.Core.Model.SatelliteOrbit>();
                    CoScheduling.Core.DAL.SatelliteOrbit dal_satelliteOrbit = new CoScheduling.Core.DAL.SatelliteOrbit();
                    list = LoadTle(quaryStr);
                    //检查T_PUB_SATELLITEORBIT是否已经存在该日期的星历，如果存在就不执行了
                    DateTime tleDate = this.dateTimePicker1.Value.Date;
                    if (dal_satelliteOrbit.Exists(tleDate))
                    {
                        MessageBox.Show(tleDate + "卫星轨道数据已存在，无需重新下载！");
                        return;
                    }
                    //赋予每条数据所选日期并插入数据库
                    foreach (CoScheduling.Core.Model.SatelliteOrbit orbit in list)
                    {
                        orbit.SAT_ORBITDATE = tleDate;
                        dal_satelliteOrbit.Add(orbit);
                    }
                    //写入更新日志
                    CoScheduling.Core.Model.SATELLITE_UPDATE satelliteUpdate = new CoScheduling.Core.Model.SATELLITE_UPDATE();
                    CoScheduling.Core.DAL.SATELLITE_UPDATE dal_satelliteUpdate = new CoScheduling.Core.DAL.SATELLITE_UPDATE();
                    satelliteUpdate.UPDATE_TABLE = "T_PUB_SATELLITE";
                    satelliteUpdate.UPDATE_LOG = tleDate + "卫星轨道数据下载成功！";
                    satelliteUpdate.UPDATE_TIME = System.DateTime.Now;
                    dal_satelliteUpdate.Add(satelliteUpdate);
                    MessageBox.Show(tleDate + "卫星轨道数据下载成功！");

                }
                else
                {
                    List<CoScheduling.Core.Model.T_PUB_NEWORBIT> list = new List<CoScheduling.Core.Model.T_PUB_NEWORBIT>();
                    CoScheduling.Core.DAL.T_PUB_NEWORBIT dal_satelliteOrbit = new CoScheduling.Core.DAL.T_PUB_NEWORBIT();
                    list = LoadTleNew(quaryStr);
                    //清空轨道数据
                    dal_satelliteOrbit.Delete();
                    DateTime tleDate = System.DateTime.Now.AddDays(-1);
                    //插入私有轨道数据
                    foreach (CoScheduling.Core.Model.T_PUB_NEWORBIT orbit in list)
                    {
                        orbit.SAT_ORBITDATE = tleDate;
                        dal_satelliteOrbit.Add(orbit);
                    }
                    MessageBox.Show("卫星轨道资源配置成功！");
                }
                this.textCon.Text = "";
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("请先进行查询在，在右侧显示查询结果后再点击下载！");
                this.textCon.Text = "";
            }
        }
        /// <summary>
        /// 批量查询并下载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDays_Click(object sender, EventArgs e)
        {
            this.textCon.Text += "\r\n";
            code = this.textCode.Text;
            CoScheduling.Core.DAL.SatelliteOrbit dal_satelliteOrbit = new CoScheduling.Core.DAL.SatelliteOrbit();
            SpaceTrack spacetrack = new SpaceTrack();
            DateTime startDay = dateTimePicker3.Value;
            DateTime endDay = dateTimePicker2.Value;
            double days = (endDay - startDay).TotalDays;
            int daynum = Convert.ToInt32(days);
            this.progressBarBat.Refresh();
            this.progressBarBat.Visible = true;
            this.progressBarBat.Minimum = 0;
            this.progressBarBat.Maximum = daynum;
            progressBarBat.Step = 1;
            for (int i = 0; i <= daynum; i++)
            {
                progressBarBat.PerformStep();
                if (dal_satelliteOrbit.Exists(startDay.AddDays(i)))
                {
                    return;
                }
                quaryStr = spacetrack.GetSpaceTrack(getNorad(), startDay.AddDays(i), startDay.AddDays(i + 1), this.textName.Text, code);
                try
                {
                    if (!String.IsNullOrEmpty(quaryStr))
                    {
                        List<CoScheduling.Core.Model.SatelliteOrbit> list = new List<CoScheduling.Core.Model.SatelliteOrbit>();
                        list = LoadTle(quaryStr);
                        DateTime tleDate = startDay.AddDays(i).Date;
                        foreach (CoScheduling.Core.Model.SatelliteOrbit orbit in list)
                        {
                            orbit.SAT_ORBITDATE = tleDate;
                            dal_satelliteOrbit.Add(orbit);
                        }
                        this.textCon.Text += startDay.AddDays(i).ToShortDateString() + "：保存成功！\r\n";
                    }
                    else
                    {
                        MessageBox.Show("请先执行查询生成！");
                        this.textCon.Text += startDay.AddDays(i).ToShortDateString() + "：下载失败，网络故障！\r\n";
                        continue;
                    }

                }
                catch (System.Exception ex)
                {
                    this.textCon.Text += startDay.AddDays(i).ToShortDateString() + "：查询错误，具体原因：\r\n" + ex.ToString() + "\r\n";
                }
            }
            this.progressBarBat.Visible = false;
            //写入更新日志
            CoScheduling.Core.Model.SATELLITE_UPDATE satelliteUpdate = new CoScheduling.Core.Model.SATELLITE_UPDATE();
            CoScheduling.Core.DAL.SATELLITE_UPDATE dal_satelliteUpdate = new CoScheduling.Core.DAL.SATELLITE_UPDATE();
            satelliteUpdate.UPDATE_TABLE = "T_PUB_SATELLITE";
            satelliteUpdate.UPDATE_LOG = this.textCon.Text;
            satelliteUpdate.UPDATE_TIME = System.DateTime.Now;
            dal_satelliteUpdate.Add(satelliteUpdate);
            MessageBox.Show("批量下载任务完成！");
        }
        /// <summary>
        /// 新发射卫星检查
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCheck_Click(object sender, EventArgs e)
        {
            this.textCon.Text = "30天内新发射天体：\r\n卫星编号 卫星名称";
            List<CoScheduling.Core.Model.SATELLITE_TEMP> list = new List<CoScheduling.Core.Model.SATELLITE_TEMP>();
            CoScheduling.Core.DAL.SATELLITE_TEMP dal_satelliteTemp = new CoScheduling.Core.DAL.SATELLITE_TEMP();
            string uriBase = "http://www.celestrak.com/NORAD/elements/";
            string requestContent = "tle-new.txt";
            string request = uriBase + requestContent;
            quaryStr = GetWebContent(request);
            list = LoadSatellite(quaryStr);
            dal_satelliteTemp.Delete();
            foreach (CoScheduling.Core.Model.SATELLITE_TEMP satellite in list)
            {
                dal_satelliteTemp.Add(satellite);
                this.textCon.Text += "\r\n" + satellite.SATELLITE_ID + " " + satellite.SATELLITE_NAME;
                if (satellite.SATELLITE_CHOOSE == 1)
                {
                    this.textCon.Text += " 已录入";
                }
            }
        }

        #endregion 窗体控件操作

        #region 相关函数
        /// <summary>
        /// 获取更新卫星星历的ID
        /// </summary>
        /// <returns></returns>
        private string[] getNorad()
        {
            CoScheduling.Core.DAL.SATELLITE_RANGE dal_satellite_range = new CoScheduling.Core.DAL.SATELLITE_RANGE();
            DataSet ds = new DataSet();
            ds = dal_satellite_range.GetListDataSet("");
            int satNum = 0;
            satNum = ds.Tables["SATELLITE_RANGE"].Rows.Count;
            string[] norad = new string[satNum];
            for (int i = 0; i < satNum; i++)
            {
                norad[i] = ds.Tables["SATELLITE_RANGE"].Rows[i]["PLATFORM_ID"].ToString();
            }
            return norad;
        }

        /// <summary>
        /// 获取卫星轨道列表
        /// </summary>
        /// <param name="tleStrFile"></param>
        /// <returns></returns>
        private List<CoScheduling.Core.Model.SatelliteOrbit> LoadTle(string tleStrFile)
        {
            if (!String.IsNullOrEmpty(tleStrFile))
            {
                List<CoScheduling.Core.Model.SatelliteOrbit> list = new List<CoScheduling.Core.Model.SatelliteOrbit>();
                char[] split = { '\r', '\n' };
                string[] tleStr = quaryStr.Split(split, System.StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < tleStr.Length; i++)
                {
                    CoScheduling.Core.Model.SatelliteOrbit satelliteOrbit = new CoScheduling.Core.Model.SatelliteOrbit();
                    satelliteOrbit.SAT_TLE1 = tleStr[i];
                    //对第一行处理
                    satelliteOrbit.SAT_ID = Convert.ToDecimal(tleStr[i].Substring(2, 5));
                    satelliteOrbit.SAT_ORBITEPOCH = tleStr[i].Substring(18, 14);
                    satelliteOrbit.SAT_MEANMOTIONDOT = Convert.ToDecimal(tleStr[i].Substring(33, 10)).ToString();

                    string bDotNum = tleStr[i].Substring(45, 1);
                    string eDotNum = tleStr[i].Substring(46, 4);
                    int endNumber = Convert.ToInt32(tleStr[i].Substring(51, 1)) + 1;
                    satelliteOrbit.SAT_MEANMOTIONDOTDOT = bDotNum + "." + eDotNum + "e-" + endNumber;

                    string sign = tleStr[i].Substring(53, 1);
                    string bOnePlusNumber = tleStr[i].Substring(54, 1);
                    string bTwoPlusNumber = tleStr[i].Substring(55, 4);
                    string symbol = tleStr[i].Substring(59, 1);
                    int eplusInt = Convert.ToInt32(tleStr[i].Substring(60, 1));
                    if (symbol == "-")
                    {
                        eplusInt = eplusInt + 1;
                    }
                    else
                    {
                        eplusInt = eplusInt - 1;
                        symbol = "";
                    }
                    if (sign == "-")
                    {
                        satelliteOrbit.SAT_BSTAR = sign + bOnePlusNumber + "." + bTwoPlusNumber + "e" + symbol + eplusInt;
                    }
                    else
                    {
                        satelliteOrbit.SAT_BSTAR = bOnePlusNumber + "." + bTwoPlusNumber + "e" + symbol + eplusInt;
                    }
                    i++;
                    //对第二行处理
                    satelliteOrbit.SAT_TLE2 = tleStr[i];
                    satelliteOrbit.SAT_INCLINATION = Convert.ToDouble(tleStr[i].Substring(8, 8)).ToString();
                    satelliteOrbit.SAT_RAAN = Convert.ToDouble(tleStr[i].Substring(17, 8)).ToString();
                    satelliteOrbit.SAT_ECCENTRICITY = "0." + tleStr[i].Substring(26, 7);
                    satelliteOrbit.SAT_ARGOFPERIGEE = Convert.ToDouble(tleStr[i].Substring(34, 8)).ToString();
                    satelliteOrbit.SAT_MEANANOMALY = Convert.ToDouble(tleStr[i].Substring(43, 8)).ToString();
                    satelliteOrbit.SAT_MEANMOTION = Convert.ToDouble(tleStr[i].Substring(52, 11)).ToString();
                    list.Add(satelliteOrbit);
                }
                return list;
            }
            else
            {
                MessageBox.Show("请先执行查询生成！");
                return null;
            }
        }

        /// <summary>
        /// 获取卫星轨道列表
        /// </summary>
        /// <param name="tleStrFile"></param>
        /// <returns></returns>
        private List<CoScheduling.Core.Model.T_PUB_NEWORBIT> LoadTleNew(string tleStrFile)
        {
            if (!String.IsNullOrEmpty(tleStrFile))
            {
                List<CoScheduling.Core.Model.T_PUB_NEWORBIT> list = new List<CoScheduling.Core.Model.T_PUB_NEWORBIT>();
                char[] split = { '\r', '\n' };
                string[] tleStr = quaryStr.Split(split, System.StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < tleStr.Length; i++)
                {
                    CoScheduling.Core.Model.T_PUB_NEWORBIT satelliteOrbit = new CoScheduling.Core.Model.T_PUB_NEWORBIT();
                    //对第一行处理
                    satelliteOrbit.SAT_TLE1 = tleStr[i];
                    satelliteOrbit.SAT_ID = Convert.ToDecimal(tleStr[i].Substring(2, 5));
                    satelliteOrbit.SAT_ORBITEPOCH = tleStr[i].Substring(18, 14);
                    satelliteOrbit.SAT_MEANMOTIONDOT = Convert.ToDecimal(tleStr[i].Substring(33, 10)).ToString();

                    string bDotNum = tleStr[i].Substring(45, 1);
                    string eDotNum = tleStr[i].Substring(46, 4);
                    int endNumber = Convert.ToInt32(tleStr[i].Substring(51, 1)) + 1;
                    satelliteOrbit.SAT_MEANMOTIONDOTDOT = bDotNum + "." + eDotNum + "e-" + endNumber;

                    string sign = tleStr[i].Substring(53, 1);
                    string bOnePlusNumber = tleStr[i].Substring(54, 1);
                    string bTwoPlusNumber = tleStr[i].Substring(55, 4);
                    string symbol = tleStr[i].Substring(59, 1);
                    int eplusInt = Convert.ToInt32(tleStr[i].Substring(60, 1));
                    if (symbol == "-")
                    {
                        eplusInt = eplusInt + 1;
                    }
                    else
                    {
                        eplusInt = eplusInt - 1;
                        symbol = "";
                    }
                    if (sign == "-")
                    {
                        satelliteOrbit.SAT_BSTAR = sign + bOnePlusNumber + "." + bTwoPlusNumber + "e" + symbol + eplusInt;
                    }
                    else
                    {
                        satelliteOrbit.SAT_BSTAR = bOnePlusNumber + "." + bTwoPlusNumber + "e" + symbol + eplusInt;
                    }
                    i++;
                    //对第二行处理
                    satelliteOrbit.SAT_TLE2 = tleStr[i];
                    satelliteOrbit.SAT_INCLINATION = Convert.ToDouble(tleStr[i].Substring(8, 8)).ToString();
                    satelliteOrbit.SAT_RAAN = Convert.ToDouble(tleStr[i].Substring(17, 8)).ToString();
                    satelliteOrbit.SAT_ECCENTRICITY = "0." + tleStr[i].Substring(26, 7);
                    satelliteOrbit.SAT_ARGOFPERIGEE = Convert.ToDouble(tleStr[i].Substring(34, 8)).ToString();
                    satelliteOrbit.SAT_MEANANOMALY = Convert.ToDouble(tleStr[i].Substring(43, 8)).ToString();
                    satelliteOrbit.SAT_MEANMOTION = Convert.ToDouble(tleStr[i].Substring(52, 11)).ToString();
                    list.Add(satelliteOrbit);
                }
                return list;
            }
            else
            {
                MessageBox.Show("请先执行查询生成！");
                return null;
            }
        }

        /// <summary>
        /// 获取卫星轨道列表
        /// </summary>
        /// <param name="tleStrFile"></param>
        /// <returns></returns>
        private List<CoScheduling.Core.Model.SATELLITE_TEMP> LoadSatellite(string tleStrFile)
        {
            if (!String.IsNullOrEmpty(tleStrFile))
            {
                List<CoScheduling.Core.Model.SATELLITE_TEMP> list = new List<CoScheduling.Core.Model.SATELLITE_TEMP>();
                char[] split = { '\r', '\n' };
                string[] tleStr = quaryStr.Split(split, System.StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < tleStr.Length; i++)
                {
                    CoScheduling.Core.Model.SATELLITE_TEMP satelliteOrbit = new CoScheduling.Core.Model.SATELLITE_TEMP();
                    //对第一行处理
                    satelliteOrbit.SATELLITE_NAME = Convert.ToString(tleStr[i]);
                    i++;
                    //对第二行处理
                    satelliteOrbit.SATELLITE_ID = Convert.ToDecimal(tleStr[i].Substring(2, 5));
                    i++;
                    //对第三行处理

                    //检查是否已更新
                    if (checkSatellite(satelliteOrbit.SATELLITE_ID.ToString()))
                    {
                        satelliteOrbit.SATELLITE_CHOOSE = 1;
                    }
                    else
                    {
                        satelliteOrbit.SATELLITE_CHOOSE = 0;
                    }
                    //检查时间
                    satelliteOrbit.SATELLITE_UPDATETIME = System.DateTime.Now;
                    list.Add(satelliteOrbit);
                }
                return list;
            }
            else
            {
                MessageBox.Show("请先执行查询生成！");
                return null;
            }
        }

        /// <summary>
        /// 检查数据库中是否已存在该卫星
        /// </summary>
        /// <param name="sat_id"></param>
        /// <returns></returns>
        private bool checkSatellite(string sat_id)
        {
            CoScheduling.Core.DAL.Satellite dal_satellite = new CoScheduling.Core.DAL.Satellite();
            return dal_satellite.Exists(sat_id);
        }
        private string checkFile(string path)
        {
            string filepath = path;
            string newFileContent = "";
            //打开txt文件，读取开始
            FileStream aFile = new FileStream(filepath, FileMode.Open);
            StreamReader sr = new StreamReader(aFile);
            string strLine = sr.ReadLine();
            while (strLine != null)
            {
                string temp1 = strLine.Remove(20, 1);
                string temp2 = temp1.Insert(20, "0");
                newFileContent += temp2;
                newFileContent += "\r\n";
                strLine = sr.ReadLine();
                newFileContent += strLine;
                newFileContent += "\r\n";
                strLine = sr.ReadLine();
            }
            sr.Close();
            return newFileContent;

        }

        /// <summary>
        /// 更具url获取网页内容
        /// </summary>
        /// <param name="Url"></param>
        /// <returns></returns>
        private string GetWebContent(string Url)
        {
            string strResult = "";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
                //声明一个HttpWebRequest请求 
                request.Timeout = 30000;
                //设置连接超时时间 
                request.Headers.Set("Pragma", "no-cache");
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream streamReceive = response.GetResponseStream();
                Encoding encoding = Encoding.GetEncoding("UTF-8");
                StreamReader streamReader = new StreamReader(streamReceive, encoding);
                strResult = streamReader.ReadToEnd();
            }
            catch (Exception e)
            {
                //MessageBox.Show("出错"+e.ToString());
            }
            return strResult;
        }
        #endregion 相关函数

    }
}
