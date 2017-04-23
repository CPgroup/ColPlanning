﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.esriSystem;

namespace CoScheduling.Main.Map
{
    public partial class DummyTOC : CP.WinFormsUI.Docking.DockContent
    {
        #region 自定义属性
        /// <summary>
        /// 图层控件
        /// </summary>
        public ESRI.ArcGIS.Controls.AxTOCControl AxTOCControl
        {
            get { return this.axTOCControl1; }
        }
        #endregion

        public DummyTOC()
        {
            InitializeComponent();
            //ESRI.ArcGIS.RuntimeManager.Bind(ESRI.ArcGIS.ProductCode.Desktop);
            //IAoInitialize pAoInitialize = new AoInitializeClass();
            //esriLicenseStatus licenseStatus = esriLicenseStatus.esriLicenseUnavailable;
            //licenseStatus = pAoInitialize.Initialize(esriLicenseProductCode.esriLicenseProductCodeAdvanced);
            ////licenseStatus = pAoInitialize.CheckOutExtension(esriLicenseExtensionCode.esriLicenseExtensionCodeRuntimeAdvanced);
            //if (licenseStatus == esriLicenseStatus.esriLicenseNotInitialized)
            //{
            //    MessageBox.Show("没有info许可");
            //}
        }
    }
}
