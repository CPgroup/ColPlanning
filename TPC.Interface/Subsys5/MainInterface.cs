using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// 课题五：覆盖分析模块
/// </summary>

namespace CP.Interface.Subsys5
{
    public class MainInterface
    {
        /// <summary>
        /// 加载覆盖分析主要控件
        /// </summary>

        public static void AddFrameworkControl5()
        {
            CoScheduling.Main.MainInterfaceCOV.SetFrameworkControl(Globe.m_MainForm,
                                                                Globe.m_SplashForm,
                                                                 Globe.m_StatusStrip,
                                                                 Globe.m_StatusLabel,
                                                                 Globe.m_ProgressBar,
                                                                 Globe.m_DockPane,
                                                                 Globe.m_LabelCoor); 
       

        }


        public static void ShowScen11()
        {
            CoScheduling.Main.MainInterfaceCOV.ShowScen();
        }
        public static void GainScen()
        {
            CoScheduling.Main.MainInterfaceCOV.GainScen();
        }
    }
}
