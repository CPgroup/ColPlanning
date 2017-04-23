using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CoScheduling.Main.Coverage
{
    public partial class SatelliteResaultDetail : Form
    {
        public int resaultid;
        Core.Model.Satellite satellite = new Core.Model.Satellite();
        Core.Model.SatelliteSensor sensor = new Core.Model.SatelliteSensor();
        Core.Model.ImgLayoutTempTimewindow imgTimewindow = new Core.Model.ImgLayoutTempTimewindow();

        Core.DAL.Satellite dal_satellite = new Core.DAL.Satellite();
        Core.DAL.SatelliteSensor dal_sensor = new Core.DAL.SatelliteSensor();
        Core.DAL.ImgLayoutTempTimewindow dal_imgTimewindow = new Core.DAL.ImgLayoutTempTimewindow();
        public SatelliteResaultDetail(int id)
        {
            resaultid = id;
            InitializeComponent();
        }
        private void SatelliteResaultDetail_Load(object sender, EventArgs e)
        {
            try
            {
                imgTimewindow = dal_imgTimewindow.GetModel(resaultid.ToString());
                satellite = dal_satellite.GetModel(imgTimewindow.SATID);
                sensor = dal_sensor.GetModel(imgTimewindow.SENSOR_ID.ToString());
                this.txtSatName.Text = satellite.SAT_SHORTNAME + "[" + satellite.SAT_FULLNAME + "]";
                this.txtSensorName.Text = sensor.SENSOR_NAME;
                this.txtStartTime.Text = imgTimewindow.STARTTIME.ToString();
                this.txtEndTime.Text = imgTimewindow.ENDTIME.ToString();
                this.txtTimeLong.Text = imgTimewindow.TIMELONG.ToString() + "秒";
                this.txtAngle.Text = imgTimewindow.SANGLE.ToString() + "度";
                this.txtResolution.Text = imgTimewindow.GSD.ToString() + "米";
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("错误：" + ex.ToString());
            }

        }

        private void txtSatName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string sat_id = satellite.SAT_ID.ToString();
            Coverage.SatelliteDetail newform = new Coverage.SatelliteDetail(sat_id);
            newform.StartPosition = FormStartPosition.CenterScreen;
            newform.Show();
        }
    }
}
