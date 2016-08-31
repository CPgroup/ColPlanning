using System;
using System.Collections.Generic;
using System.Text;

namespace CoScheduling.Core
{
    /// <summary>
    /// 类名：Program
    /// 作者：李光强
    /// 时间：2014.3.9
    /// </summary>
    public static class Program
    {
        #region 主窗体中的公共控件
        /// <summary>
        /// 主窗口状态栏提示面板
        /// </summary>
        private static System.Windows.Forms.ToolStripStatusLabel gStatusLabel;
        /// <summary>
        /// 主窗口状态栏进度条
        /// </summary>
        private static System.Windows.Forms.ToolStripProgressBar gProgressBar;
        /// <summary>
        /// 主窗口浮动面板
        /// </summary>
        private static CP.WinFormsUI.Docking.DockPanel gDockPane;
        /// <summary>
        /// 主窗口
        /// </summary>
        private static System.Windows.Forms.Form gMainForm;
        /// <summary>
        /// 主窗口状态栏
        /// </summary>
        private static System.Windows.Forms.StatusStrip gStatusStrip;

        /// <summary>
        /// 主窗口中的坐标栏
        /// </summary>
        private static System.Windows.Forms.ToolStripStatusLabel gLabelCoor;

        /// <summary>
        /// 设置进度条值
        /// </summary>
        /// <param name="val"></param>
        internal static void SetProgressVal(int val)
        {
            gProgressBar.Value = val;
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

        /// <summary>
        /// 获取主窗口中的控件
        /// </summary>
        /// <param name="pLabel">提示框</param>
        /// <param name="pProgress">进度条</param>
        /// <param name="pPanel">浮动面板</param>
        /// <param name="pPictureBox">主窗口中的图片</param>
        /// <param name="pForm">主窗口</param>
        /// <param name="pStatus">主窗口状态栏</param>
        public static void SetFrameworkControl(System.Windows.Forms.Form pForm,
                                                System.Windows.Forms.StatusStrip pStatus,
                                                System.Windows.Forms.ToolStripStatusLabel pLabel,
                                                System.Windows.Forms.ToolStripProgressBar pProgress,
                                                CP.WinFormsUI.Docking.DockPanel pPanel,
                                                System.Windows.Forms.ToolStripStatusLabel pCoor)
        {
            Program.gDockPane = pPanel;
            Program.gStatusLabel = pLabel;
            Program.gProgressBar = pProgress;
            Program.gMainForm = pForm;
            Program.gStatusStrip = pStatus;
            Program.gLabelCoor = pCoor;
        }
        /// <summary>
        /// 设置状态栏提示框
        /// </summary>
        /// <param name="tip"></param>
        internal static void SetStatusLabel(string tip)
        {
            gStatusLabel.Text = tip;
            gStatusStrip.Refresh();
        }
    }
}
