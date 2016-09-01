using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraBars.Ribbon;


namespace CP.FrameWork
{
    public partial class FormMain : RibbonForm
    {
        public FormMain()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// 主窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            //向接口DLL中传递当前窗口控件
            CP.Interface.Globe.SetFrameworkControl(this,
                                                    Program.gFormSplash,
                                                    this.statusStrip1,
                                                    this.tslMain,
                                                    this.tslProgress,
                                                    this.DockPanel,
                                                    this.tslCoor);

            this.ribbonControl.SelectedPage.Name = "resourceManage";//设置主页

            //加载控件
            CP.Interface.Subsys1.MainInterface.AddFrameworkControl();      //此函数加载初始化地图等     

        }
        
        private static int op = 1;//当前控件；1-resourceManage，2-OptimalAllocation，3-taskManage，4-CoScheduling
        /// <summary>
        /// 当切换页面时加载控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ribbonControl_SelectedPageChanged(object sender, EventArgs e)
        {            
            //为观测资源管理页面时，加载相应控件
            if (this.ribbonControl.SelectedPage.Name == "resourceManage" && op != 1)
            {
                CP.Interface.Subsys1.MainInterface.AddFrameworkControl();//根据管理内容修改控件
                op = 1;
            }
            //加载观测资源优化配置控件
            else if (this.ribbonControl.SelectedPage.Name == "OptimalAllocation")
            {
                CP.Interface.Subsys2.MainInterface.AddFrameworkControl2();//根据管理内容修改控件
                op = 2;
            }
            //加载任务管理控件
            else if (this.ribbonControl.SelectedPage.Name == "taskManage")
            {
                CP.Interface.Subsys3.MainInterface.AddFrameworkControl3();//根据管理内容修改控件
                op = 3;
            }
            //加载任务规划与调度控件
            else if (this.ribbonControl.SelectedPage.Name == "CoScheduling")
            {
                CP.Interface.Subsys4.MainInterface.AddFrameworkControl4();//根据管理内容修改控件
                op = 4;
            }
            
        }

        #region 观测资源管理模块

        #region  无人机管理

        /// <summary>
        /// 无人机列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UAVlist_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CP.Interface.Subsys1.MainInterface.UAVlist();

        }

        //按照以上格式通过CP.Interface接口在CoScheduling.Main中完成核心程序

        #endregion

        #region  卫星资源管理

      


        #endregion

        #region  地面监控资源管理




        #endregion

      

        #endregion

        #region  观测资源优化配置

        #region  历史事件分析




        #endregion

        #region  观测资源优化配置




        #endregion


        #endregion


        #region  任务管理

        #region  应急事件管理




        #endregion

        #region  任务分析




        #endregion


        #endregion

        #region  任务规划与调度

        #region  任务规划




        #endregion

        #region  动态资源规划




        #endregion

        #region  综合管理




        #endregion

        #endregion



    }
}