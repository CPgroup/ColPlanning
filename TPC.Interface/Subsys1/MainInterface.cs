using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

/// <summary>
/// 模块一：观测资源管理接口
/// </summary>

namespace CP.Interface.Subsys1
{
    public class MainInterface
    {
        #region 成员变量

        #endregion

        /// <summary>
        /// 加载资源管理主要控件
        /// </summary>
        public static void AddFrameworkControl() //CoScheduling.Main文件中函数SetFrameworkControl设置初始框架
        {            
            CoScheduling.Main.MainInterface.SetFrameworkControl(Globe.m_MainForm,
                                                                Globe.m_SplashForm,
                                                                 Globe.m_StatusStrip,
                                                                 Globe.m_StatusLabel,
                                                                 Globe.m_ProgressBar,
                                                                 Globe.m_DockPane,
                                                                 Globe.m_LabelCoor);          

        }


        #region  无人机管理

        /// <summary>
        /// 无人机列表
        /// </summary>
        public static void UAVlist()
        {
            CoScheduling.Main.MainInterface.UAVlist();
        }
        
        public static void UAVManage()
        {
            CoScheduling.Main.MainInterface.UAVManage();
        }
        public static void UAVQuery()
        {
            CoScheduling.Main.MainInterface.UAVQuery();
        }
        public static void Sensor1Query()
        {
            CoScheduling.Main.MainInterface.Sensor1Query();
        }
        public static void BandQuery()
        {
            CoScheduling.Main.MainInterface.BandQuery();
        }


        public static void SatelliteManage()
        {
            CoScheduling.Main.MainInterface.SatelliteManage();
        }
        public static void SatQuery()
        {
            CoScheduling.Main.MainInterface.SatQuery();
        }

        
        public static void AEROSHIPManage()
        {
            CoScheduling.Main.MainInterface.AEROSHIPManage();
        }
        
        public static void AEROSHIPQuery()
        {
            CoScheduling.Main.MainInterface.AEROSHIPQuery();
        }
        
        public static void ILLUSTRATEDCARManage()
        {
            CoScheduling.Main.MainInterface.ILLUSTRATEDCARManage();
        }

        public static void ILLUSTRATEDCARQuery()
        {
            CoScheduling.Main.MainInterface.ILLUSTRATEDCARQuery();
        }

        public static void SPYCAMManage()
        {
            CoScheduling.Main.MainInterface.SPYCAMManage();
        }

        public static void SPYCAMQuery()
        {
            CoScheduling.Main.MainInterface.SPYCAMQuery();
        }

        public static void HUMDETManage()
        {
            CoScheduling.Main.MainInterface.HUMDETManage();
        }

        public static void HUMDETQuery()
        {
            CoScheduling.Main.MainInterface.HUMDETQuery();
        }
        #endregion


      
        #region  卫星资源管理
        public static void SatOrbit()
        {
            CoScheduling.Main.MainInterface.SatOrbit();
        }



        #endregion

        #region  地面监控资源管理




        #endregion

    }
}
