using System;
using System.Collections.Generic;
using System.Text;

namespace CP.Interface
{
    public class Globe
    {
        /// <summary>
        /// 主窗口
        /// </summary>
        internal static System.Windows.Forms.Form m_MainForm;
        internal static System.Windows.Forms.Form m_SplashForm;
        /// <summary>
        /// 主窗口状态栏
        /// </summary>
        internal static System.Windows.Forms.StatusStrip m_StatusStrip;
        /// <summary>
        /// 主窗口状态栏提示面板
        /// </summary>
        internal static System.Windows.Forms.ToolStripStatusLabel m_StatusLabel;
        /// <summary>
        /// 主窗口状态栏进度条
        /// </summary>
        internal static System.Windows.Forms.ToolStripProgressBar m_ProgressBar;

        /// <summary>
        /// 主窗口浮动面板
        /// </summary>
        internal static CP.WinFormsUI.Docking.DockPanel m_DockPane;
        
        /// <summary>
        /// 主窗口中的坐标栏
        /// </summary>
        internal static System.Windows.Forms.ToolStripStatusLabel m_LabelCoor;

        /// <summary>
        /// 获取主窗口中的控件
        /// </summary>
        /// <param name="pLabel">提示框</param>
        /// <param name="pProgress">进度条</param>
        /// <param name="pPanel">浮动面板</param>
        /// <param name="pPictureBox">主窗口中的图片</param>
        /// <param name="pForm">主窗口</param>
        /// <param name="pStatus">主窗口状态栏</param>
        public static void SetFrameworkControl( System.Windows.Forms.Form pForm,
                                                System.Windows.Forms.Form pSplashForm,
                                                System.Windows.Forms.StatusStrip pStatus,
                                                System.Windows.Forms.ToolStripStatusLabel pLabel,
                                                System.Windows.Forms.ToolStripProgressBar pProgress,
                                                CP.WinFormsUI.Docking.DockPanel pPanel,
                                                System.Windows.Forms.ToolStripStatusLabel pCoor)
        {
            Globe.m_StatusLabel = pLabel;
            Globe.m_ProgressBar = pProgress;
            Globe.m_DockPane = pPanel;
            Globe.m_StatusStrip = pStatus;
            Globe.m_MainForm = pForm;
            Globe.m_SplashForm = pSplashForm;
            m_LabelCoor = pCoor;
        }
    }
}
