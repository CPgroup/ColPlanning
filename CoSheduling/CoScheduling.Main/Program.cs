using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ESRI.ArcGIS.esriSystem;
using CP.WinFormsUI.Docking;

namespace CoScheduling.Main
{
    /// <summary>
    /// 类名：Program
    /// 作者：系统自动生成
    /// 修改：李光强
    /// 时间：2014.3.9
    /// </summary>
    /// <remarks>注意：此类中所有公共函数和成员均使用internal访问约束，
    /// 仅供项目内部使用，隐藏外部项目调用</remarks>
    public static class Program
    {
        #region 主窗体中的公共控件
        /// <summary>
        /// 主窗口状态栏提示面板
        /// </summary>
        internal static System.Windows.Forms.ToolStripStatusLabel gStatusLabel;
        /// <summary>
        /// 主窗口状态栏进度条
        /// </summary>
        internal static System.Windows.Forms.ToolStripProgressBar gProgressBar;
        /// <summary>
        /// 主窗口浮动面板
        /// </summary>
        internal static CP.WinFormsUI.Docking.DockPanel gDockPane;
        /// <summary>
        /// 主窗口
        /// </summary>
        internal static System.Windows.Forms.Form gMainForm;
        internal static System.Windows.Forms.Form gSplashForm;
        /// <summary>
        /// 主窗口状态栏
        /// </summary>
        internal static System.Windows.Forms.StatusStrip gStatusStrip;
        /// <summary>
        /// 主窗口中的坐标栏
        /// </summary>
        internal static System.Windows.Forms.ToolStripStatusLabel gLabelCoor;
        /// <summary>
        /// 设置状态栏提示框
        /// </summary>
        /// <param name="tip"></param>
        internal static void SetStatusLabel(string tip)
        {
            if (Program.gSplashForm != null)
                if (!Program.gSplashForm.IsDisposed)
                    Program.gSplashForm.Dispose();

            gStatusLabel.Text = tip;
            gStatusStrip.Refresh();
        }

        /// <summary>
        /// 设置最大值
        /// </summary>
        /// <param name="val"></param>
        internal static void SetProgreeMax(int val)
        {
            gProgressBar.Maximum = val;
        }

        /// <summary>
        /// 设置主窗口的光标状态
        /// </summary>
        /// <param name="pCursor"></param>
        internal static void SetFormCursor(System.Windows.Forms.Cursor pCursor)
        {
            gMainForm.Cursor = pCursor;
        }

        /// <summary>
        /// 设置坐标显示信息
        /// </summary>
        /// <param name="val"></param>
        internal static void SetCoorText(string val)
        {
            gLabelCoor.Text = val;
        }
        #endregion

        #region 地图控件与初始化
        /// <summary>
        /// 图层目录控件
        /// </summary>
        internal static ESRI.ArcGIS.Controls.AxTOCControl myTOC;

        /// <summary>
        /// 地图控件
        /// </summary>
        internal static ESRI.ArcGIS.Controls.AxMapControl myMap;

        /// <summary>
        /// 地图控件是否已初始化
        /// </summary>
        private static bool IsInitedMap;

        /// <summary>
        /// 初始化地图
        /// </summary>
        internal static void InitMap()
        {
            if (IsInitedMap) return;    //如果已初化则返回
            //绑定arcgis运行时
            if (!ESRI.ArcGIS.RuntimeManager.Bind(ESRI.ArcGIS.ProductCode.Engine))
            {
                if (!ESRI.ArcGIS.RuntimeManager.Bind(ESRI.ArcGIS.ProductCode.Desktop))
                {
                    System.Windows.Forms.MessageBox.Show("This application could not load the correct version of ArcGIS.");
                    return;
                }
            }
            //获取engine网络分析权限
            Map.LicenseInitializer aoLicenseInitializer = new Map.LicenseInitializer();
            if (!aoLicenseInitializer.InitializeApplication(new esriLicenseProductCode[] { esriLicenseProductCode.esriLicenseProductCodeEngine, esriLicenseProductCode.esriLicenseProductCodeBasic, esriLicenseProductCode.esriLicenseProductCodeStandard, esriLicenseProductCode.esriLicenseProductCodeAdvanced },
            new esriLicenseExtensionCode[] { esriLicenseExtensionCode.esriLicenseExtensionCodeNetwork, esriLicenseExtensionCode.esriLicenseExtensionCodeSpatialAnalyst }))
            {
                System.Windows.Forms.MessageBox.Show("This application could not initialize with the correct ArcGIS license and will shutdown. LicenseMessage: " + aoLicenseInitializer.LicenseMessage());
                aoLicenseInitializer.ShutdownApplication();
                return;
            }
            IsInitedMap = true;
        }

        #endregion

        #region 加载地图窗口
        /// <summary>
        /// 地图窗口
        /// </summary>
        internal static Map.DummyMap formMap;
        /// <summary>
        /// 图层列表
        /// </summary>
        internal static Map.DummyTOC formTOC;
        /// <summary>
        /// 显示地图控件
        /// </summary>
        internal static void ShowMapControl()
        {
            InitMap();
            if (formTOC == null) formTOC = new Map.DummyTOC();
            else if (formTOC.IsDisposed) formTOC = new Map.DummyTOC();
            formTOC.Show(gDockPane, DockState.DockLeft);

            if (formMap == null) formMap = new Map.DummyMap();
            else if (formMap.IsDisposed) formMap = new Map.DummyMap();
            formMap.Show(gDockPane, DockState.Document);
            formTOC.AxTOCControl.SetBuddyControl(formMap.MapControl);
        }
        #endregion
        
      
    }
}
