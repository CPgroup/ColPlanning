using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;


/// <summary>
/// 模块三：任务管理模块
/// </summary>

namespace CP.Interface.Subsys3
{
    public class MainInterface
    {
        /// <summary>
        /// 加载任务管理主要控件
        /// </summary>
        public static void AddFrameworkControl3() 
        {
            CoScheduling.Main.MainInterface.SetFrameworkControl(Globe.m_MainForm,
                                                               Globe.m_SplashForm,
                                                                Globe.m_StatusStrip,
                                                                Globe.m_StatusLabel,
                                                                Globe.m_ProgressBar,
                                                                Globe.m_DockPane,
                                                                Globe.m_LabelCoor);          


        }


        #region  应急事件管理




        #endregion

        #region  任务分析




        #endregion

     

    }
}
