using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;


/// <summary>
/// 课题四：任务规划与调度模块
/// </summary>

namespace CP.Interface.Subsys4
{
    public class MainInterface
    {
        /// <summary>
        /// 加载任务规划主要控件
        /// </summary>
        public static void AddFrameworkControl4()
        {
            CoScheduling.Main.MainInterface.SetFrameworkControl(Globe.m_MainForm,
                                                                Globe.m_SplashForm,
                                                                 Globe.m_StatusStrip,
                                                                 Globe.m_StatusLabel,
                                                                 Globe.m_ProgressBar,
                                                                 Globe.m_DockPane,
                                                                 Globe.m_LabelCoor); 
       

        }

      

        #region  任务规划
        //在CoScheduling.Main\Map\taskDis.cs中，右侧小窗口的任务分解面板实现

        #endregion

        #region  动态资源规划




        #endregion

        #region  综合管理




        #endregion



    }
}
