using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Carto;
using CoScheduling.Core;
using System.Reflection;
using Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;


namespace CoScheduling.Main.Coverage
{
    public partial class SatelliteTaskResault : Form
    {
        #region 公共成员变量
        string schemeid = "";
        int schemeidInt;               //当前页面的方案ID
        string defaultfilePath = "";   //保存默认存储路径
        string strwhere = "";
        //实体对象对应的数据访问对象
        CoScheduling.Core.DAL.ImgLayoutTempTimewindow dal_imgLayoutTempTimewindow = new CoScheduling.Core.DAL.ImgLayoutTempTimewindow();
        CoScheduling.Core.DAL.SatelliteResault dal_satelliteResault = new CoScheduling.Core.DAL.SatelliteResault();
        CoScheduling.Core.DAL.TASK_SCHEME_LIST dal_taskScheme = new CoScheduling.Core.DAL.TASK_SCHEME_LIST();

        DateTime resaultStartTime;
        DateTime resaultEndTime;

        #endregion 公共成员变量
        #region 构造函数
        public SatelliteTaskResault(string scheme_id)
        {
            schemeid = scheme_id;
            schemeidInt = Convert.ToInt32(schemeid);
            InitializeComponent();
        }
        public SatelliteTaskResault()
        {
            InitializeComponent();
           
        }
        #endregion 
        #region 窗体控件事件
        /// <summary>
        /// FormLoad事件，绑定datagridview，绑定combobox
        /// strwhere = "schemeid=" + schemeid;
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SatelliteTaskResault_Load(object sender, EventArgs e)
        {
            dataGridViewTimewindow.AutoGenerateColumns = false;
            dataGridViewTimewindow.AutoGenerateColumns = false;
            tempProgressBar.Visible = false;
            if (schemeid == "")
            {
                schemeid = dal_taskScheme.GetLatestSchemeid().ToString();
                schemeidInt = Convert.ToInt32(schemeid);
            }
            Core.Model.TASK_SCHEME_LIST taskScheme = new Core.Model.TASK_SCHEME_LIST();
            taskScheme = dal_taskScheme.GetModel(schemeidInt);
            resaultStartTime = taskScheme.SCHEMEBTIME;
            resaultEndTime = taskScheme.SCHEMEETIME;
            //增加时间窗口选择
            addDateTimePicker(resaultStartTime, resaultEndTime, resaultStartTime);
            addDateTimePicker(resaultStartTime, resaultEndTime, resaultEndTime);
            //设置初始化的结果列表筛选条件为：指定方案的全部记录
            strwhere = "schemeid=" + schemeid;
            System.Data.DataTable dt = dal_imgLayoutTempTimewindow.GetListFull(strwhere);
            if (dt == null)
            {
                MessageBox.Show("任务规划尚未完成！");
                toolStripLabel1.Enabled = false;
                toolStripLabel3.Enabled = false;
                toolStripLabel4.Enabled = false;
                toolStripLabel8.Enabled = false;
                tsb_GenMap.Enabled = false;
                tsb_GenOrder.Enabled = false;
                tsb_GenExcel.Enabled = false;
            }
            else
            {

                dataGridViewTimewindow.DataSource = dt;
                for (int i = 0; i < dataGridViewTimewindow.Rows.Count; i++)
                {
                    ((DataGridViewCheckBoxCell)dataGridViewTimewindow.Rows[i].Cells[15]).Value = true;
                    //dt.Rows[i]["STARTTIME"] = Convert.ToDateTime(dt.Rows[i]["STARTTIME"]).AddHours(8); //循环修改列传值
                    //dt.Rows[i]["ENDTIME"] = Convert.ToDateTime(dt.Rows[i]["ENDTIME"]).AddHours(8); //循环修改列传值
                }
            }
            //绑定筛选条件
            //显示卫星国家
            toolStripComboBoxCountry.Items.Add("全部");
            this.toolStripComboBoxCountry.SelectedIndex = 0;
            bindComboBoxCountry();
            ////显示宪章成员
            toolStripComboBoxCharter.Items.Add("全部");
            toolStripComboBoxCharter.Items.Add("是");
            toolStripComboBoxCharter.Items.Add("否");
            this.toolStripComboBoxCharter.SelectedIndex = 0;
            ////显示载荷类型
            toolStripComboBoxSensor.Items.Add("全部");
            toolStripComboBoxSensor.Items.Add("光学");
            toolStripComboBoxSensor.Items.Add("雷达");
            this.toolStripComboBoxSensor.SelectedIndex = 0;
            //显示任务列表
            toolStripComboBoxTask.Items.Add("全部");
            bindComboBoxTask();
            this.toolStripComboBoxSensor.SelectedIndex = 0;
        }

        #endregion
        #region 工具栏事件
        internal static Coverage.SatelliteTaskResault SateTR;
        /// <summary>
        /// 增加时间窗口
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public static void addDateTimePicker(DateTime start, DateTime end, DateTime current)
        {
            //工具栏时间
            //在工具栏中加入时间
            DateTimePicker dtp = new DateTimePicker();
            dtp.Format = DateTimePickerFormat.Custom;//自定义格式
            dtp.CustomFormat = "yyyy-MM-dd HH:mm:ss";//自定义格式
            dtp.Width = 160;
            dtp.MinDate = start;
            dtp.MaxDate = end;
            dtp.Value = current;
            SateTR.toolStrip2.Items.Insert(SateTR.toolStrip2.Items.Count - 3, new ToolStripControlHost(dtp));
        }
        /// <summary>
        /// 根据条件刷新数据表
        /// </summary>
        public void dataRefresh()
        {
            string satCondition = "";
            string sensorCondition = "";

            DateTime start = resaultStartTime;
            DateTime end = resaultEndTime;
            //卫星信息条件
            //国家信息
            if ((!string.IsNullOrEmpty(this.toolStripComboBoxCountry.SelectedText) || this.toolStripComboBoxCountry.SelectedItem.ToString() != "全部") && this.toolStripComboBoxCountry.SelectedText != "全部")
            {
                satCondition += " SAT_COUNTRY LIKE '%" + this.toolStripComboBoxCountry.SelectedItem.ToString() + "%'";
            }
            else
            {
                satCondition += "SAT_COUNTRY IS NOT NULL";
            }
            //宪章信息
            if (!string.IsNullOrEmpty(this.toolStripComboBoxCharter.SelectedItem.ToString()) && this.toolStripComboBoxCharter.SelectedItem.ToString() == "是")
            {
                satCondition += " AND SAT_CHARTER=" + 1;
            }
            else if (this.toolStripComboBoxCharter.SelectedItem.ToString() == "否")
            {
                satCondition += " AND SAT_CHARTER=" + 0;
            }
            else
            {
                satCondition += " AND SAT_CHARTER IS NOT NULL";
            }
            //载荷信息条件
            //载荷类型
            if (!string.IsNullOrEmpty(this.toolStripComboBoxSensor.SelectedItem.ToString()) && this.toolStripComboBoxSensor.SelectedItem.ToString() == "光学")
            {
                sensorCondition += " SENSOR_TYPE=" + 1;
            }
            else if (this.toolStripComboBoxSensor.SelectedItem.ToString() == "雷达")
            {
                sensorCondition += " SENSOR_TYPE=" + 0;
            }
            else
            {
                sensorCondition += " SENSOR_TYPE IS NOT NULL";
            }
            //窗口时间
            try
            {
                start = Convert.ToDateTime(this.toolStrip2.Items[this.toolStrip2.Items.Count - 5].Text);
                end = Convert.ToDateTime(this.toolStrip2.Items[this.toolStrip2.Items.Count - 4].Text);
            }
            catch (System.Exception ex)
            {

            }

            string timeCondition = " AND c.STARTTIME>'" + start + "' AND c.STARTTIME<'" + end + "'";
            string strcondition = "c.SATID IN (SELECT SAT_ID FROM LHF.SATELLITE_INFO WHERE " + satCondition + ")" + " AND c.SATID IN (SELECT SAT_ID FROM LHF.SATELLITE_SENSOR WHERE " + sensorCondition + ") " + timeCondition;
            try
            {
                if (schemeid == "")
                {
                    schemeid = dal_taskScheme.GetLatestSchemeid().ToString();
                }
                strwhere = "schemeid=" + schemeid + " and " + strcondition;
                System.Data.DataTable dt = dal_imgLayoutTempTimewindow.GetListFull(strwhere);
                if (dt == null)
                {
                    MessageBox.Show("任务规划尚未完成！");
                }
                else
                {

                    dataGridViewTimewindow.DataSource = dt;
                    for (int i = 0; i < dataGridViewTimewindow.Rows.Count; i++)
                    {
                        ((DataGridViewCheckBoxCell)dataGridViewTimewindow.Rows[i].Cells[15]).Value = true;
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("请输入正确的参数！");
            }
        }
        #endregion
        #region 功能函数
        /// <summary>
        /// 给comboBoxCountry绑定国家数据
        /// </summary>
        public static void bindComboBoxCountry()
        {
            DataSet ds = new DataSet();
            ds = GetSatInfoDataSet("");
            string strItem = "";
            for (int i = 0; i < ds.Tables["SATELLITE_INFO"].Rows.Count; i++)
            {
                strItem = ds.Tables["SATELLITE_INFO"].Rows[i]["SAT_COUNTRY"].ToString();
                //去除重複項目
                if (!SateTR.toolStripComboBoxCountry.Items.Contains(strItem))
                {
                    SateTR.toolStripComboBoxCountry.Items.Add(strItem);
                }
            }
        }
        /// <summary>
        /// 绑定任务
        /// </summary>
        public static void bindComboBoxTask()
        {
            CoScheduling.Core.DAL.TASK_LAYOUT_LIST dal_taskLayout = new CoScheduling.Core.DAL.TASK_LAYOUT_LIST();
            DataSet ds = new DataSet();
            ds = dal_taskLayout.GetListDataSet("SCHEMEID=" + SateTR.schemeidInt);
            string strItem = "";
            for (int i = 0; i < ds.Tables["TASK_LAYOUT_LIST"].Rows.Count; i++)
            {
                strItem = ds.Tables["TASK_LAYOUT_LIST"].Rows[i]["TASKNAME"].ToString();
                SateTR.toolStripComboBoxCountry.Items.Add(strItem);
            }
        }
        /// <summary>
        /// 获取卫星信息列表DataSet
        /// </summary>
        /// <param name="strWhere">条件</param>
        public static DataSet GetSatInfoDataSet(string strWhere)
        {
            CoScheduling.Core.DAL.Satellite dal_satellite = new CoScheduling.Core.DAL.Satellite();
            DataSet ds = new DataSet();
            ds = dal_satellite.GetListDataSet(strWhere);
            return ds;
        }
        /// <summary>
        /// 生成word文档订单
        /// </summary>
        /// <param name="path"></param>
        public void genOrder(string path)
        {
            try
            {
                Core.Model.TASK_SCHEME_LIST taskSchemeList = new Core.Model.TASK_SCHEME_LIST();
                List<Core.Model.TASK_LAYOUT_LIST> taskLayoutList = new List<Core.Model.TASK_LAYOUT_LIST>();
                List<Core.Model.ImgLayoutTempTimewindow> resaultList = new List<Core.Model.ImgLayoutTempTimewindow>();
                List<Core.Model.Satellite> satelliteList = new List<Core.Model.Satellite>();

                Core.DAL.TASK_SCHEME_LIST dal_taskSchemeList = new Core.DAL.TASK_SCHEME_LIST();
                Core.DAL.TASK_LAYOUT_LIST dal_taskLayoutList = new Core.DAL.TASK_LAYOUT_LIST();
                Core.DAL.ImgLayoutTempTimewindow dal_imgLayoutTempTimewindow = new Core.DAL.ImgLayoutTempTimewindow();
                Core.DAL.Satellite dal_satellite = new Core.DAL.Satellite();
                Core.DAL.SatelliteSensor dal_satelliteSensor = new Core.DAL.SatelliteSensor();
                taskSchemeList = dal_taskSchemeList.GetModel(Convert.ToInt32(schemeid));
                taskLayoutList = dal_taskLayoutList.GetList(Convert.ToInt32(schemeid));

                string satSchemeName = taskSchemeList.SCHEMENAME;
                string satSchemeStart = taskSchemeList.SCHEMEBTIME.ToString("yyyy年MM月dd日 HH时mm分ss秒");
                string satSchemeEnd = taskSchemeList.SCHEMEETIME.ToString("yyyy年MM月dd日 HH时mm分ss秒");
                string taskNum = taskLayoutList.Count.ToString();

                string countryText = "";
                string timeText = "";
                int taskCount = 1;
                //1.载入模板
                Task.WordHelper report = new Task.WordHelper();
                report.CreateNewDocument(System.Windows.Forms.Application.StartupPath + @"\\卫星订单模板.doc"); //模板路径

                //2.在卫星观测方案处插入值
                report.InsertValue("SatScheme", satSchemeName, 11, WdColor.wdColorBlack, 5, WdParagraphAlignment.wdAlignParagraphLeft);//在书签“SatScheme”处插入值
                report.InsertValue("SatSchemeStart", satSchemeStart, 11, WdColor.wdColorBlack, 5, WdParagraphAlignment.wdAlignParagraphLeft);//在书签“SatScheme”处插入值
                report.InsertValue("SatSchemeEnd", satSchemeEnd, 11, WdColor.wdColorBlack, 5, WdParagraphAlignment.wdAlignParagraphLeft);//在书签“SatScheme”处插入值
                report.InsertValue("SatSchemeDetail", taskNum, 11, WdColor.wdColorBlack, 5, WdParagraphAlignment.wdAlignParagraphLeft);
                //3.在卫星观测任务处插入值，首先创建一个表格
                int tableNum = 1;
                report.InsertValue("SatTask", "表" + tableNum + " 卫星观测任务详情", 11, WdColor.wdColorBlack, 5, WdParagraphAlignment.wdAlignParagraphCenter);//在书签“SatTask”处插入值
                Microsoft.Office.Interop.Word.Table tableTask = report.InsertTable("SatTask", 2, 4, 0); //在书签“Bookmark_table”处插入2行4列行宽最大的表

                //合并单元格
                report.MergeCell(tableTask, 1, 1, 1, 4); //表名,开始行号,开始列号,结束行号,结束列号
                //在单元格中插入值
                report.InsertCell(tableTask, 1, 1, satSchemeName);//表名,行号,列号,值
                //给表格插入一行数据
                string[] values = { "任务名称", "开始时间", "结束时间", "目标类型" };
                report.InsertCell(1, 2, 4, values); //给模板中第一个表格的第二行的4列分别插入数据
                int rowNum = 3;
                //设置进度条    
                tempProgressBar.Refresh();
                tempProgressBar.Visible = true;
                tempProgressBar.Minimum = 1;
                tempProgressBar.Maximum = (dataGridViewTimewindow.RowCount * taskLayoutList.Count * 2);
                tempProgressBar.Step = 1;
                foreach (Core.Model.TASK_LAYOUT_LIST tll in taskLayoutList)
                {
                    string[] tasks = new string[4];
                    tasks[0] = tll.TASKNAME;
                    tasks[1] = tll.STARTTIME.ToString("yyyy-MM-dd HH:mm:ss");
                    tasks[2] = tll.ENDTIME.ToString("yyyy-MM-dd HH:mm:ss");
                    tasks[3] = tll.TASKTYPE == 1 ? "区域目标" : "点目标：（" + tll.LON + "," + tll.LAT + "）";
                    report.AddRow(tableTask); //表名
                    report.InsertCell(1, rowNum, 4, tasks); //给模板中第一个表格的第三行的4列分别插入数据
                    rowNum++;

                    //4.在卫星观测结果处插入值
                    #region 插入统计信息
                    #region 获取按国家排序的统计信息
                    //子标题
                    countryText += "(" + taskCount + ") " + tll.TASKNAME + "\r\n";
                    //查询卫星条件
                    strwhere = "SAT_ID IN (0,";
                    //查询当前任务id
                    string taskid = "";

                    //遍历dataGridView，获取选中数据的卫星id，存入查询卫星条件
                    for (int row = 0; row <= dataGridViewTimewindow.RowCount - 1; row++)
                    {
                        tempProgressBar.PerformStep();
                        taskid = dataGridViewTimewindow.Rows[row].Cells["TASK_ID"].Value.ToString().Trim();
                        if (((DataGridViewCheckBoxCell)dataGridViewTimewindow.Rows[row].Cells[15]).Value != null && (bool)((DataGridViewCheckBoxCell)dataGridViewTimewindow.Rows[row].Cells[15]).Value && taskid == tll.TASKID.ToString())
                        {
                            strwhere += dataGridViewTimewindow.Rows[row].Cells["SATID"].Value.ToString().Trim() + ",";
                        }
                    }
                    strwhere = strwhere.Substring(0, strwhere.Length - 1);
                    strwhere += ")";
                    strwhere += " ORDER BY SAT_COUNTRY,SAT_SHORTNAME";

                    //获取卫星列表
                    satelliteList = dal_satellite.GetList(strwhere);
                    //临时国家标记，用于标记顺序遍历时国家是否变化
                    string countryName = "";
                    //遍历卫星列表，给插入值赋值
                    foreach (Core.Model.Satellite satellite in satelliteList)
                    {
                        if (countryName != satellite.SAT_COUNTRY)
                        {
                            countryName = satellite.SAT_COUNTRY;
                            countryText += countryName + ":\r\n";
                        }
                        countryText += "    " + satellite.SAT_SHORTNAME + "\r\n";
                    }
                    #endregion 获取按国家排序的统计信息

                    #region 获取按时间的统计信息
                    timeText += "(" + taskCount + ")" + tll.TASKNAME + "\r\n";
                    strwhere = "LSTR_SEQID IN (0,";

                    //遍历dataGridView，获取选中数据的卫星id，存入查询卫星条件
                    for (int row = 0; row <= dataGridViewTimewindow.RowCount - 1; row++)
                    {
                        tempProgressBar.PerformStep();
                        if (((DataGridViewCheckBoxCell)dataGridViewTimewindow.Rows[row].Cells[15]).Value != null && (bool)((DataGridViewCheckBoxCell)dataGridViewTimewindow.Rows[row].Cells[15]).Value)
                        {
                            strwhere += dataGridViewTimewindow.Rows[row].Cells[0].Value.ToString().Trim() + ",";
                        }
                    }
                    strwhere = strwhere.Substring(0, strwhere.Length - 1);
                    strwhere += ")";
                    //获取时间窗口列表
                    resaultList = dal_imgLayoutTempTimewindow.GetListByTaskID(tll.TASKID, strwhere, "STARTTIME, SAT_STKNAME");

                    //临时国家标记，用于标记顺序遍历时国家是否变化
                    string timeDate = "";
                    //遍历卫星列表，给插入值赋值
                    foreach (Core.Model.ImgLayoutTempTimewindow resault in resaultList)
                    {
                        if (timeDate != resault.STARTTIME.ToShortDateString())
                        {
                            timeDate = resault.STARTTIME.ToShortDateString();
                            timeText += timeDate + ":\r\n";
                        }
                        timeText += "    " + resault.SAT_STKNAME + "\r\n";
                    }

                    #endregion 获取按时间的统计信息

                    taskCount++;
                    #endregion 插入统计信息


                    #region 插入卫星任务规划表格
                    /***
                    //按照卫星名称分类
                    tableNum++;//表格计数加一
                    report.InsertValue("SatResault" + (tableNum - 1).ToString(), "\r\n", 11, WdColor.wdColorBlack, 5, WdParagraphAlignment.wdAlignParagraphCenter);
                    report.InsertValue("SatResault" + (tableNum - 1).ToString(), "表" + tableNum + " " + tll.TASKNAME + "（按卫星名称排序）", 11, WdColor.wdColorBlack, 5, WdParagraphAlignment.wdAlignParagraphCenter);//在书签“SatResault”处插入值
                    Table tableResault = report.InsertTable("SatResault" + (tableNum - 1).ToString(), 1, 9, 0); //在书签“SatResault”处插入1行9列行宽最大的表
                    
                    //给表格插入一行数据
                    string[] resaultValues = { "序号","卫星名称", "载荷名称", "开始时间", "结束时间", "时长（秒）", "倾斜角度（度）", "分辨率（米）", "灾后时间" };
                    report.InsertCell(tableNum, 1, 9, resaultValues); //给模板中第一个表格的第二行的4列分别插入数据
                    int tableResaultNum = 1;//表格行数计数
                    //获取卫星观测结果列表
                    resaultList = dal_imgLayoutTempTimewindow.GetListByTaskID(Convert.ToInt32(tll.TASKID), strwhere, "SAT_STKNAME,STARTTIME");


                    //给观测结果表格填充内容
                    foreach (Core.Model.ImgLayoutTempTimewindow iltt in resaultList)
                    {
                        tempProgressBar.PerformStep();
                        report.AddRow(tableNum, 1);                       
                        string[] resault = new string[9];
                        resault[0] = tableResaultNum.ToString();
                        resault[1] = dal_satellite.GetModel(iltt.SATID).SAT_SHORTNAME;
                        resault[2] = dal_satelliteSensor.GetModel(iltt.SENSOR_ID.ToString()).SENSOR_NAME;
                        resault[3] = iltt.STARTTIME.ToString();
                        resault[4] = iltt.ENDTIME.ToString();
                        resault[5] = iltt.TIMELONG.ToString();
                        resault[6] = iltt.SANGLE.ToString();
                        resault[7] = iltt.GSD.ToString();
                        resault[8] = Convert.ToString(iltt.STARTTIME - tll.STARTTIME);
                        tableResaultNum++;
                        report.InsertCell(tableNum, tableResaultNum, 9, resault);
                    }
                    //按照时间顺序分类
                    tableNum++;//表格计数加一
                    report.InsertValue("SatResault" + (tableNum - 1).ToString(), "\r\n", 11, WdColor.wdColorBlack, 5, WdParagraphAlignment.wdAlignParagraphCenter);
                    report.InsertValue("SatResault" + (tableNum - 1).ToString(), "表" + tableNum + " " + tll.TASKNAME + "（按时间排序）", 11, WdColor.wdColorBlack, 5, WdParagraphAlignment.wdAlignParagraphCenter);//在书签“SatResault”处插入值
                    Table tableResault2 = report.InsertTable("SatResault" + (tableNum - 1).ToString(), 1, 9, 0); //在书签“SatResault”处插入1行8列行宽最大的表

                    //给表格插入一行数据
                    string[] resaultValues2 = { "序号", "卫星名称", "载荷名称", "开始时间", "结束时间", "时长（秒）", "倾斜角度（度）", "分辨率（米）", "灾后时间" };
                    report.InsertCell(tableNum, 1, 9, resaultValues); //给模板中第一个表格的第二行的4列分别插入数据
                    int tableResaultNum2 = 1;//表格行数计数
                    //获取卫星观测结果列表
                    resaultList = dal_imgLayoutTempTimewindow.GetListByTaskID(Convert.ToInt32(tll.TASKID), strwhere,"STARTTIME");
                    //给观测结果表格填充内容
                    foreach (Core.Model.ImgLayoutTempTimewindow iltt in resaultList)
                    {
                        tempProgressBar.PerformStep();
                        report.AddRow(tableNum, 1);
                        string[] resault = new string[9];
                        resault[0] = tableResaultNum2.ToString();
                        resault[1] = dal_satellite.GetModel(iltt.SATID).SAT_SHORTNAME;
                        resault[2] = dal_satelliteSensor.GetModel(iltt.SENSOR_ID.ToString()).SENSOR_NAME;
                        resault[3] = iltt.STARTTIME.ToString();
                        resault[4] = iltt.ENDTIME.ToString();
                        resault[5] = iltt.TIMELONG.ToString();
                        resault[6] = iltt.SANGLE.ToString();
                        resault[7] = iltt.GSD.ToString();
                        resault[8] = Convert.ToString(iltt.STARTTIME - tll.STARTTIME);
                        tableResaultNum2++;
                        report.InsertCell(tableNum, tableResaultNum2, 9, resault);
                    }
                    ***/
                    #endregion 插入卫星任务规划表格


                }
                report.InsertValue("SatResaultCountry", countryText, 11, WdColor.wdColorBlack, 1, WdParagraphAlignment.wdAlignParagraphLeft);//在书签“SatResaultCountry”处插入值
                report.InsertValue("SatResaultTime", timeText, 11, WdColor.wdColorBlack, 1, WdParagraphAlignment.wdAlignParagraphLeft);//在书签“SatResaultCountry”处插入值

                //隐藏进度条    
                tempProgressBar.Visible = false;
                //5.最后保存文档
                //string path = Server.MapPath(p_SavePath) + "\\Testing_" + DateTime.Now.ToShortDateString() + ".doc"; 
                path += "\\" + satSchemeName + "规划结果" + DateTime.Now.ToString("yyyy年MM月dd日 HH时mm分ss秒") + ".doc";
                report.SaveDocument(path);
                MessageBox.Show("订单生成成功！");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("订单生成失败！失败原因：" + ex.ToString());

            }

        }
        /// <summary>
        /// 导出数据，生成Excel表格
        /// </summary>
        /// <param name="path"></param>
        public void genExcel(string path)
        {
            Core.Model.TASK_SCHEME_LIST taskSchemeList = new Core.Model.TASK_SCHEME_LIST();

            Core.DAL.TASK_SCHEME_LIST dal_taskSchemeList = new Core.DAL.TASK_SCHEME_LIST();

            taskSchemeList = dal_taskSchemeList.GetModel(Convert.ToInt32(schemeid));

            string satSchemeName = taskSchemeList.SCHEMENAME;
            #region 可操作性验证
            //定义表格内数据的行数和列数    
            int rowscount = this.dataGridViewTimewindow.Rows.Count;
            int colscount = dataGridViewTimewindow.Columns.Count;
            //行数必须大于0    
            if (rowscount <= 0)
            {
                MessageBox.Show("没有数据可供保存 ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //列数必须大于0    
            if (colscount <= 0)
            {
                MessageBox.Show("没有数据可供保存 ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //行数不可以大于65536    
            if (rowscount > 65536)
            {
                MessageBox.Show("数据记录数太多(最多不能超过65536条)，不能保存 ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //列数不可以大于255    
            if (colscount > 255)
            {
                MessageBox.Show("数据记录行数太多，不能保存 ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            path += "\\" + satSchemeName + "规划结果" + DateTime.Now.ToString("yyyy年MM月dd日 HH时mm分ss秒") + ".xls";
            #endregion
            Excel.Application objExcel = null;
            Excel.Workbook objWorkbook = null;
            Excel.Worksheet objsheet = null;

            try
            {
                //申明对象    
                objExcel = new Microsoft.Office.Interop.Excel.Application();
                objWorkbook = objExcel.Workbooks.Add(Missing.Value);
                objsheet = (Excel.Worksheet)objWorkbook.ActiveSheet;
                //设置EXCEL不可见    
                objExcel.Visible = false;

                //向Excel中写入表格的表头    
                int displayColumnsCount = 1;
                for (int i = 0; i < dataGridViewTimewindow.ColumnCount - 1; i++)
                {
                    if (dataGridViewTimewindow.Columns[i].Visible == true)
                    {
                        objExcel.Cells[1, displayColumnsCount] = dataGridViewTimewindow.Columns[i].HeaderText.Trim();
                        displayColumnsCount++;
                    }
                }
                //设置进度条    
                tempProgressBar.Refresh();
                tempProgressBar.Visible = true;
                tempProgressBar.Minimum = 1;
                tempProgressBar.Maximum = dataGridViewTimewindow.RowCount;
                tempProgressBar.Step = 1;
                int excelRow = 0;
                //向Excel中逐行逐列写入表格中的数据    
                for (int row = 0; row <= dataGridViewTimewindow.RowCount - 1; row++)
                {
                    tempProgressBar.PerformStep();
                    if (((DataGridViewCheckBoxCell)dataGridViewTimewindow.Rows[row].Cells[15]).Value != null && (bool)((DataGridViewCheckBoxCell)dataGridViewTimewindow.Rows[row].Cells[15]).Value)
                    {
                        displayColumnsCount = 1;
                        for (int col = 0; col < colscount - 1; col++)
                        {
                            if (dataGridViewTimewindow.Columns[col].Visible == true)
                            {
                                try
                                {
                                    objExcel.Cells[excelRow + 2, displayColumnsCount] = dataGridViewTimewindow.Rows[row].Cells[col].Value.ToString().Trim();
                                    displayColumnsCount++;
                                }
                                catch (Exception)
                                {

                                }

                            }
                        }
                        excelRow++;
                    }

                }
                //隐藏进度条    
                tempProgressBar.Visible = false;
                //保存文件    
                objWorkbook.SaveAs(path, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                        Missing.Value, Excel.XlSaveAsAccessMode.xlShared, Missing.Value, Missing.Value, Missing.Value,
                        Missing.Value, Missing.Value);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "警告 ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            finally
            {
                //关闭Excel应用    
                if (objWorkbook != null) objWorkbook.Close(Missing.Value, Missing.Value, Missing.Value);
                if (objExcel.Workbooks != null) objExcel.Workbooks.Close();
                if (objExcel != null) objExcel.Quit();

                objsheet = null;
                objWorkbook = null;
                objExcel = null;
            }
            MessageBox.Show(path + "\n\n导出完毕! ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion
        #region 点击功能

        private void tsb_GenMap_Click(object sender, EventArgs e)
        {
            CoScheduling.Core.Model.SatelliteResault satelliteResault = new CoScheduling.Core.Model.SatelliteResault();
            CoScheduling.Core.Model.ImgLayoutTempTimewindow imgLayoutTempTimewindow = new CoScheduling.Core.Model.ImgLayoutTempTimewindow();
            CoScheduling.Core.DAL.DisaAreaInfo dal_disAreaInfo = new CoScheduling.Core.DAL.DisaAreaInfo();


            List<CoScheduling.Core.Model.ImgLayoutTempTimewindow> list = dal_imgLayoutTempTimewindow.GetListByCondition(strwhere);
            if (dal_satelliteResault.ExistsResault(schemeidInt))//先判断是已经存在，如果结果已经存在就不需要再做了
            {
                dal_satelliteResault.DeleteBySchemeID(schemeidInt);
            }

            //转存到SQL Server中
            for (int i = 0; i < list.Count; i++)
            {
                imgLayoutTempTimewindow = list[i];
                satelliteResault.LSTR_SEQID = Convert.ToInt32(imgLayoutTempTimewindow.LSTR_SEQID);
                satelliteResault.SCHEMEID = Convert.ToInt32(imgLayoutTempTimewindow.SCHEMEID);
                satelliteResault.TASKID = Convert.ToInt32(imgLayoutTempTimewindow.TASKID);
                satelliteResault.PID = dal_disAreaInfo.GetMaxId();
                satelliteResault.POLYGONSTRING = imgLayoutTempTimewindow.IMAGEREGION;
                satelliteResault.STARTTIME = imgLayoutTempTimewindow.STARTTIME;
                satelliteResault.ENDTIME = imgLayoutTempTimewindow.ENDTIME;
                #region c++程序问题处理

                #endregion
                dal_satelliteResault.Add(satelliteResault);
            }
            Main.Program.ShowFormSatelliteResault();        //加载卫星观测结果列表
            MessageBox.Show("地图生成成功!在左侧卫星规划结果选择查看");
            dataRefresh();
        }

        private void tsb_GenOrder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog saveFolder = new FolderBrowserDialog();
            saveFolder.Description = "选择要保存文件的目录";
            if (defaultfilePath != "")
            {
                //设置此次默认目录为上一次选中目录  
                saveFolder.SelectedPath = defaultfilePath;
            }

            if (saveFolder.ShowDialog() == DialogResult.OK)
            {
                //记录选中的目录  
                defaultfilePath = saveFolder.SelectedPath;
                genOrder(defaultfilePath);
            }
        }
        private void tsb_ShowMap_Click(object sender, EventArgs e)
        {
            Main.Program.ShowFormSatelliteResault();        //加载卫星观测结果列表
        }

        private void tsb_GenExcel_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog saveFolder = new FolderBrowserDialog();
            saveFolder.Description = "选择要保存文件的目录";
            if (defaultfilePath != "")
            {
                //设置此次默认目录为上一次选中目录  
                saveFolder.SelectedPath = defaultfilePath;
            }

            if (saveFolder.ShowDialog() == DialogResult.OK)
            {
                //记录选中的目录  
                defaultfilePath = saveFolder.SelectedPath;
                genExcel(defaultfilePath);
            }
        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            //获取当前分析方案的id
            if (schemeid == "")
            {
                schemeid = dal_taskScheme.GetLatestSchemeid().ToString();
                schemeidInt = Convert.ToInt32(schemeid);
            }
            List<CoScheduling.Core.Model.TASK_LAYOUT_LIST> taskLayoutList = new List<CoScheduling.Core.Model.TASK_LAYOUT_LIST>();
            CoScheduling.Core.DAL.TASK_LAYOUT_LIST dal_taskLayout = new CoScheduling.Core.DAL.TASK_LAYOUT_LIST();
            //方案相关任务
            taskLayoutList = dal_taskLayout.GetList(schemeidInt);
            List<CoScheduling.Core.Model.SatelliteResault> satelliteResaultList = new List<CoScheduling.Core.Model.SatelliteResault>();
            //遍历任务，分别分析
            foreach (CoScheduling.Core.Model.TASK_LAYOUT_LIST taskLayout in taskLayoutList)
            {
                if (taskLayout.TASKTYPE == 0)
                {
                    continue;
                }
                //获取任务相关观测结果
                satelliteResaultList = dal_satelliteResault.GetListByTaskID(taskLayout.TASKID);

                //设置进度条    
                tempProgressBar.Refresh();
                tempProgressBar.Visible = true;
                tempProgressBar.Minimum = 1;
                tempProgressBar.Maximum = satelliteResaultList.Count;
                tempProgressBar.Step = 1;

                //任务区域字符串
                string taskString = "";
                string[] xyStr = taskLayout.AREASTRING.Split(' ');
                for (int i = 0; i < xyStr.Length; i += 2)
                {
                    if (string.IsNullOrEmpty(xyStr[i]))
                        continue;
                    double lat = Convert.ToDouble(xyStr[i]);
                    double lon = Convert.ToDouble(xyStr[i + 1]);
                    taskString += lon + "," + lat + ";";
                }
                taskString += xyStr[1] + "," + xyStr[0];
                //生成任务区域Polygon
                IPolygon taskPolygon = SatelliteResaultHelper.StringToPolygon(taskString);
                double taskArea = SatelliteResaultHelper.getPolygonArea(taskPolygon);
                //遍历观测结果，逐个分析
                foreach (CoScheduling.Core.Model.SatelliteResault satelliteResault in satelliteResaultList)
                {
                    tempProgressBar.PerformStep();
                    //调用AE分析覆盖面积与任务面积比
                    //结果面字符串
                    string[] satResaultStr = satelliteResault.POLYGONSTRING.Split(';');
                    string resaultStr = satelliteResault.POLYGONSTRING + satResaultStr[0];
                    IPolygon resaultPolygon = SatelliteResaultHelper.StringToPolygon(resaultStr);
                    IPolygon intersectPolygon = SatelliteResaultHelper.IntersectPolygon(taskPolygon, resaultPolygon);
                    double intersectArea;
                    if (intersectPolygon != null)
                    {
                        intersectArea = SatelliteResaultHelper.getPolygonArea(intersectPolygon);
                    }
                    else
                    {
                        intersectArea = 0;
                    }

                    double ratio = (intersectArea / taskArea > 1) ? 1 : (intersectArea / taskArea);
                    satelliteResault.COVERAGE = Convert.ToDecimal(ratio);
                    //更新观测结果
                    dal_satelliteResault.Update(satelliteResault);
                }

                //隐藏进度条    
                tempProgressBar.Visible = false;
            }
            //刷新表格
            dataRefresh();
            MessageBox.Show("分析完成！");
        }

        private void toolStripLabel9_Click(object sender, EventArgs e)
        {
            //设置进度条    
            tempProgressBar.Refresh();
            tempProgressBar.Visible = true;
            tempProgressBar.Minimum = 1;
            tempProgressBar.Maximum = dataGridViewTimewindow.RowCount;
            tempProgressBar.Step = 1;
            //重置累加覆盖率
            dal_satelliteResault.Refresh(schemeidInt);
 
            //遍历数据表记录选中的id 
            string resaultIDs = "";
            for (int row = 0; row <= dataGridViewTimewindow.RowCount - 1; row++)
            {
                
                if (((DataGridViewCheckBoxCell)dataGridViewTimewindow.Rows[row].Cells[15]).Value != null && (bool)((DataGridViewCheckBoxCell)dataGridViewTimewindow.Rows[row].Cells[15]).Value)
                {
                    
                    resaultIDs += dataGridViewTimewindow.Rows[row].Cells[0].Value.ToString() + ",";
                }
            }
            resaultIDs = resaultIDs.Substring(0, resaultIDs.Length - 1);
            if(string.IsNullOrEmpty(resaultIDs))
            {
                MessageBox.Show("未选中任何项！");
                tempProgressBar.Visible = false;  
                return;
            }
            List<CoScheduling.Core.Model.TASK_LAYOUT_LIST> taskLayoutList = new List<CoScheduling.Core.Model.TASK_LAYOUT_LIST>();
            CoScheduling.Core.DAL.TASK_LAYOUT_LIST dal_taskLayout = new CoScheduling.Core.DAL.TASK_LAYOUT_LIST();
            //方案相关任务
            taskLayoutList = dal_taskLayout.GetList(schemeidInt);

            List<CoScheduling.Core.Model.SatelliteResault> resaultList = new List<CoScheduling.Core.Model.SatelliteResault>();
            foreach (CoScheduling.Core.Model.TASK_LAYOUT_LIST taskLayout in taskLayoutList)
            {
                //如果是点目标，就不需要分析覆盖率的问题
                if (taskLayout.TASKTYPE == 0)
                {
                    continue;
                }
                //任务区域字符串
                string taskString = "";
                string[] xyStr = taskLayout.AREASTRING.Split(' ');
                for (int i = 0; i < xyStr.Length; i += 2)
                {
                    if (string.IsNullOrEmpty(xyStr[i]))
                        continue;
                    double lat = Convert.ToDouble(xyStr[i]);
                    double lon = Convert.ToDouble(xyStr[i + 1]);
                    taskString += lon + "," + lat + ";";
                }
                taskString += xyStr[1] + "," + xyStr[0];
                //生成任务区域Polygon
                IPolygon taskPolygon = SatelliteResaultHelper.StringToPolygon(taskString);
                double taskArea = SatelliteResaultHelper.getPolygonArea(taskPolygon);
                //获取观测结果列表
                resaultList = dal_satelliteResault.GetList("taskid=" + taskLayout.TASKID + " and lstr_seqid in(" + resaultIDs + ")");
                IPolygon unionPolygon=SatelliteResaultHelper.UnionPolygon(null, null);
                double accuArea = 0;
                //遍历列表计算累加覆盖率
                foreach (CoScheduling.Core.Model.SatelliteResault satelliteResault in resaultList)
                {
                    tempProgressBar.PerformStep();
                    if (accuArea>=taskArea)
                    {
                        satelliteResault.ACCUCOVERAGE = 1;
                    } 
                    else
                    {
                        //结果面字符串
                        string[] satResaultStr = satelliteResault.POLYGONSTRING.Split(';');
                        string resaultStr = satelliteResault.POLYGONSTRING + satResaultStr[0];
                        IPolygon resaultPolygon = SatelliteResaultHelper.StringToPolygon(resaultStr);

                        unionPolygon = SatelliteResaultHelper.UnionPolygon(unionPolygon, resaultPolygon);
                        IPolygon intersectPolygon = SatelliteResaultHelper.IntersectPolygon(taskPolygon, unionPolygon);
                        accuArea = SatelliteResaultHelper.getPolygonArea(intersectPolygon);
                        double ratio = accuArea / taskArea;
                        if (ratio>1)
                        {
                            satelliteResault.ACCUCOVERAGE = 1;
                        } 
                        else
                        {
                            satelliteResault.ACCUCOVERAGE = Convert.ToDecimal(ratio);
                        }
                    }
                    dal_satelliteResault.Update(satelliteResault);
                }
            }
            MessageBox.Show("累加分析统计完成！");
            //隐藏进度条    
            tempProgressBar.Visible = false;
            dataRefresh();
        
        }

        private void dataGridViewTimewindow_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)dataGridViewTimewindow.Rows[e.RowIndex].Cells[15];
                Boolean flag = Convert.ToBoolean(checkCell.Value);
                if (flag == true)     //查找被选择的数据行 
                {
                    checkCell.Value = false;
                }
                else
                {
                    checkCell.Value = true;
                }
            }
        }

        private void dataGridViewTimewindow_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            for (int i = 0; i < dataGridViewTimewindow.Rows.Count; i++)
            {
                ((DataGridViewCheckBoxCell)dataGridViewTimewindow.Rows[i].Cells[15]).Value = true;
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            dataRefresh();
        }

        #endregion
    }
}
