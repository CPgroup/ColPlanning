using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CoScheduling.Main.SPYCAM_RANGE
{
    public partial class BandAdd : Form
    {
        string sensor_id = "";
        string platform_id = "";
        CoScheduling.Core.Model.SPYCAM_RANGE spycam_range = new CoScheduling.Core.Model.SPYCAM_RANGE();
        CoScheduling.Core.DAL.SPYCAM_RANGE dal_spycam_range = new CoScheduling.Core.DAL.SPYCAM_RANGE();
        CoScheduling.Core.Model.SENSOR_2 sensor2 = new Core.Model.SENSOR_2();
        CoScheduling.Core.DAL.SENSOR_2 dal_sensor2 = new Core.DAL.SENSOR_2();
        public BandAdd()
        {
            InitializeComponent();
        }
        public BandAdd(string sensorid)
        {
            sensor_id = sensorid;
            platform_id = sensor_id.Substring(0, 6);
            InitializeComponent();
        }

        private void BandAdd_Load(object sender, EventArgs e)
        {
            sensor2 = dal_sensor2.GetModel(Convert.ToDecimal(sensor_id));
            this.txtSPYCAMID.Text += sensor2.PLATFORM_ID;
            this.txtSensorID.Text += sensor2.SensorID;

            List<ListItem> items = new List<ListItem>();
            if (sensor2.SensorType == "1")
            {
                label4.Text += "(μm)";
                this.comboBoxPolar.Visible = false;
                this.comboBoxPolar.SelectedItem = "TBD";
                label6.Text += "(nm)";
                items.Add(new ListItem("1", "PAN"));
                items.Add(new ListItem("2", "VIS"));
                items.Add(new ListItem("3", "NIR"));
                items.Add(new ListItem("4", "SWIR"));
                items.Add(new ListItem("5", "MWIR"));
                items.Add(new ListItem("6", "TIR"));
                items.Add(new ListItem("7", "FIR"));
                items.Add(new ListItem("8", "UV"));

                items.Add(new ListItem("9", "UV - VIS"));
                items.Add(new ListItem("10", "UV - NIR"));
                items.Add(new ListItem("11", "UV - MWIR"));
                items.Add(new ListItem("12", "UV - FIR"));

                items.Add(new ListItem("13", "VIS - NIR"));
                items.Add(new ListItem("14", "VIS - MWIR"));
                items.Add(new ListItem("15", "VIS - TIR"));
                items.Add(new ListItem("16", "VIS - FIR"));


                items.Add(new ListItem("17", "NIR - SWIR"));

                items.Add(new ListItem("18", "MWIR - FIR"));
                items.Add(new ListItem("19", "MWIR - TIR"));

                items.Add(new ListItem("20", "TIR - FIR"));
            }
            else
            {
                label4.Text += "(GHz)";
                label6.Text += "(MHz)";
                this.txtSpeMin.ReadOnly = true;
                this.txtSpeMax.ReadOnly = true;

                items.Add(new ListItem("1", "L"));
                items.Add(new ListItem("2", "S"));
                items.Add(new ListItem("3", "C"));
                items.Add(new ListItem("4", "X"));
                items.Add(new ListItem("5", "Ku"));
                items.Add(new ListItem("6", "K"));
                items.Add(new ListItem("7", "Ka"));
                items.Add(new ListItem("8", "V"));
                items.Add(new ListItem("9", "W"));
                items.Add(new ListItem("10", "mm"));
                items.Add(new ListItem("11", "MW"));
            }
            items.Add(new ListItem("21", "TBD"));
            comboBoxBandType.DisplayMember = "Text";
            comboBoxBandType.ValueMember = "Value";
            comboBoxBandType.DataSource = items;  
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            CoScheduling.Core.Model.Sensor_Band_Mode sensor_band_mode = new Core.Model.Sensor_Band_Mode();
            CoScheduling.Core.DAL.Sensor_Band_Mode dal_sensor_band_mode = new Core.DAL.Sensor_Band_Mode();
            //给sensor_band_mode实体赋值
            try
            {
                sensor_band_mode.BandID = Convert.ToDecimal(sensor_id.ToString() + this.txtBandID.Text.PadLeft(2, '0'));
                sensor_band_mode.SensorID = Convert.ToDecimal(sensor_id);
                sensor_band_mode.PLATFORM_ID = Convert.ToDecimal(platform_id);
                sensor_band_mode.SwathWidth = Convert.ToDecimal(this.txtBandSwathWidth.Text);
                sensor_band_mode.BandType = Convert.ToString(this.comboBoxBandType.SelectedItem);
                sensor_band_mode.SpectralRangeMin = Convert.ToDecimal(this.txtSpeMin.Text);
                sensor_band_mode.SpectralRangeMax = Convert.ToDecimal(this.txtSpeMax.Text);
                sensor_band_mode.BandCenter = Convert.ToDecimal(this.txtBandCenter.Text);
                sensor_band_mode.BandWidth = Convert.ToDecimal(this.txtBandWidth.Text);
                sensor_band_mode.PolarizationMode = Convert.ToString(this.comboBoxPolar.SelectedItem);
                sensor_band_mode.GeometryResolution = Convert.ToDecimal(this.txtGeometryResolution.Text);
                sensor_band_mode.AzimuthDirectionResolution = Convert.ToDecimal(this.txtAzimuResolution.Text);
                sensor_band_mode.DistanceResolution = Convert.ToDecimal(this.txtDistanceResolution.Text);
                sensor_band_mode.SNRRatio = Convert.ToDecimal(this.txtSNR.Text);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("请输入合法参数！");
                return;
            }
            try
            {
                //检查是否为空
                if (string.IsNullOrEmpty(this.txtBandID.Text) ||
                    string.IsNullOrEmpty(this.comboBoxBandType.SelectedItem.ToString()))
                {
                    MessageBox.Show("输入信息不完整！");
                    return;
                }
                //添加
                dal_sensor_band_mode.Add(sensor_band_mode);
                MessageBox.Show("飞艇波段添加成功！");
                //更新各个表中的属性没有写
                //回传给父窗体消息
                DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();

            }
            catch (Exception es)
            {
                MessageBox.Show(es.ToString());
            }
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            this.txtBandID.Text = "1";
            this.txtBandSwathWidth.Text = "5";
            this.comboBoxBandType.SelectedItem = "TBD";
            this.txtSpeMin.Text = "0.1";
            this.txtSpeMax.Text = "0.2";
            this.txtBandCenter.Text = "0.15";
            this.txtBandWidth.Text = "0.1";
            this.comboBoxPolar.SelectedItem = "TBD";
            this.txtAzimuResolution.Text = "0.1";
            this.txtDistanceResolution.Text = "0.1";
            this.txtGeometryResolution.Text = "0.1";
            this.txtSNR.Text = "1.5";
        }











    }
}
