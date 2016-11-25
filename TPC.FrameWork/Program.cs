using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.LookAndFeel;

namespace CP.FrameWork
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
       {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.OfficeSkins.Register();
            DevExpress.UserSkins.BonusSkins.Register();
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
            //gFormSplash = new FormSplash(); //正在加载中图标显示
            //gFormSplash.Show();
            //gFormSplash.Refresh();

            _formMain = new FormMain();
            Application.Run(_formMain);//主窗体加载函数
        }

        private static FormMain _formMain;
        public static FormSplash gFormSplash;

        public static void SetMainTipText(string tip)
        {

        }

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
    }
}