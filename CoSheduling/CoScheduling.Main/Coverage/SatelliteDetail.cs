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
    public partial class SatelliteDetail : Form
    {
        string sat_id = "";
        public SatelliteDetail(string satid)
        {
            sat_id = satid;
            InitializeComponent();
        }

        CoScheduling.Core.Model.Satellite satellite = new CoScheduling.Core.Model.Satellite();
        CoScheduling.Core.Model.SatelliteSensor satelliteSensor = new CoScheduling.Core.Model.SatelliteSensor();
        /// <summary>
        /// Satellite全局数据访问对象
        /// </summary>
        CoScheduling.Core.DAL.Satellite dal_satellite = new CoScheduling.Core.DAL.Satellite();
        /// <summary>
        /// SatelliteSensor全局数据访问对象
        /// </summary>
        CoScheduling.Core.DAL.SatelliteSensor dal_satelliteSensor = new CoScheduling.Core.DAL.SatelliteSensor();
        /// <summary>
        /// SatelliteBand全局数据访问对象
        /// </summary>
        CoScheduling.Core.DAL.SatelliteBand dal_satelliteBand = new CoScheduling.Core.DAL.SatelliteBand();
        public SatelliteDetail()
        {
            InitializeComponent();
        }
        #region 卫星操作
        /// <summary>
        /// 根据sat_id获取卫星实体
        /// </summary>
        public void GetSatInfo()
        {
            satellite = dal_satellite.GetModel(Convert.ToDecimal(sat_id));
        }
        /// <summary>
        /// 对页面label等绑定卫星信息
        /// </summary>
        public void bindSatInfo()
        {
            this.labelShortName.Text = satellite.SAT_SHORTNAME.ToString();
            this.labelFullName.Text = satellite.SAT_FULLNAME.ToString();
            if (satellite.SAT_ORBITTYPE.ToString() == "GEO")
            {
                this.labelOrbitType.Text = satellite.SAT_ORBITTYPE.ToString() + ":" + satellite.SAT_LONGITUDEOFGEO.ToString() + "度";
            }
            else
            {
                this.labelOrbitType.Text = satellite.SAT_ORBITTYPE.ToString();
            }
            if (satellite.SAT_REPEATCYCLE.ToString() != "-1")
            {
                this.labelRepeatCycle.Text = satellite.SAT_REPEATCYCLE.ToString();
            }
            this.labelCountry.Text = satellite.SAT_COUNTRY.ToString();
            this.labelAgency.Text = satellite.SAT_AGENCIES.ToString();
            this.labelApplication.Text = satellite.SAT_APPLICATION.ToString();
            this.label1LaunchTime.Text = satellite.SAT_LAUNCHTIME.ToShortDateString();
            if (satellite.SAT_DESCRIPTION.ToString() != "TBD")
            {
                this.satDescription.Text = satellite.SAT_DESCRIPTION.ToString();
            }
            if (satellite.SAT_DESCRIPTION2.ToString() != "TBD")
            {
                this.satDescription.Text += satellite.SAT_DESCRIPTION2.ToString();
            }
        }

        /// <summary>
        /// 获取载荷列表DataSet
        /// </summary>
        /// <param name="strWhere">条件</param>
        public DataSet GetSatSensorDataSet(string strWhere)
        {
            DataSet ds = dal_satelliteSensor.GetListDataSet(strWhere);
            return ds;
        }
        /// <summary>
        /// 获取载荷波段DataSet
        /// </summary>
        /// <param name="strWhere">条件</param>
        public DataSet GetSatBandDataSet(string strWhere)
        {
            DataSet ds = dal_satelliteBand.GetListDataSet(strWhere);
            return ds;
        }

        /// <summary>
        /// 给dataGridViewSatSensor绑定卫星载荷数据
        /// </summary>
        /// <param name="strWhere">条件</param>
        public void bindSatSensor(string strWhere)
        {
            dataGridViewSensor.AutoGenerateColumns = false;
            this.dataGridViewSensor.DataSource = null;
            this.dataGridViewSensor.DataSource = GetSatSensorDataSet(strWhere);
            this.dataGridViewSensor.DataMember = "SATELLITE_SENSOR";
        }

        /// <summary>
        /// 给dataGridViewBand绑定卫星波段数据
        /// </summary>
        /// <param name="strWhere">条件</param>
        public void bindSatBand(string strWhere)
        {
            dataGridViewBand.AutoGenerateColumns = false;
            this.dataGridViewBand.DataSource = GetSatBandDataSet(strWhere);
            this.dataGridViewBand.DataMember = "SATELLITE_SENSOR_BAND_MODE";
        }

        #endregion 卫星操作


        #region 窗体事件
        /// <summary>
        /// FormLoad事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SatelliteDetail_Load(object sender, EventArgs e)
        {
            //获取父窗体选中卫星信息
            GetSatInfo();
            //设置标题
            this.Text = satellite.SAT_LONGNAME.ToString() + "详情";
            //绑定当前页面选中卫星信息
            bindSatInfo();
            //绑定选中卫星载荷信息
            bindSatSensor("SAT_ID=" + sat_id);
            //绑定波段为第一个载荷信息，因为波段随载荷联动设置为载荷表的cellClick事件，如果不这么做的话，初始化不会显示波段信息，比较不人性化
            decimal sensorid = Convert.ToDecimal(this.dataGridViewSensor.CurrentRow.Cells[0].Value);
            satelliteSensor = dal_satelliteSensor.GetModel(sensorid.ToString());
            this.sensorDescription.Text = satelliteSensor.INSTRUMENTDESCRIPTION.ToString();
            bindSatBand("SENSOR_ID=" + sensorid.ToString());
        }
        /// <summary>
        /// 设定二级联动，单击载荷表，显示相应的波段信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewSensor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            decimal sensorid = Convert.ToDecimal(this.dataGridViewSensor.CurrentRow.Cells[0].Value);
            satelliteSensor = dal_satelliteSensor.GetModel(sensorid.ToString());
            this.sensorDescription.Text = satelliteSensor.INSTRUMENTDESCRIPTION.ToString();
            bindSatBand("SENSOR_ID=" + sensorid.ToString());
        }
        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 格式化表格内容，更加人性化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewSensor_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e == null || e.Value == null || !(sender is DataGridView))
                return;
            DataGridView view = (DataGridView)sender;
            try
            {
                if (view.Columns[e.ColumnIndex].DataPropertyName == "REVISITTIME")
                {
                    string val = "";
                    if (e.Value != null)
                    {
                        val = e.Value.ToString();
                    }
                    if (val == "-1")
                    {
                        e.Value = "TBD";
                    }
                }
            }
            catch (System.Exception ex)
            {
                e.FormattingApplied = false;
                MessageBox.Show(ex.ToString());
            }
        }

        private void dataGridViewBand_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e == null || e.Value == null || !(sender is DataGridView))
                return;
            DataGridView view = (DataGridView)sender;
            try
            {
                if (view.Columns[e.ColumnIndex].DataPropertyName == "SWATHWIDTH")
                {
                    string val = "";
                    if (e.Value != null)
                    {
                        val = e.Value.ToString();
                    }
                    switch (val)
                    {
                        case "-1":
                            e.Value = "TBD";
                            break;
                        default:
                            e.Value = e.Value;
                            break;
                    }
                }
                if (view.Columns[e.ColumnIndex].DataPropertyName == "SPECTRALRANGEMIN")
                {

                    if (e.Value != null)
                    {
                        e.Value = Math.Abs(Convert.ToDecimal(e.Value));
                    }
                }
                if (view.Columns[e.ColumnIndex].DataPropertyName == "SPECTRALRANGEMAX")
                {

                    if (e.Value != null)
                    {
                        e.Value = Math.Abs(Convert.ToDecimal(e.Value));
                    }
                }
                if (view.Columns[e.ColumnIndex].DataPropertyName == "SPECTRALCENTER")
                {

                    if (e.Value != null)
                    {
                        e.Value = Math.Abs(Convert.ToDecimal(e.Value));
                        if (Convert.ToDecimal(e.Value) == 0)
                        {
                            e.Value = "";
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                e.FormattingApplied = false;
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion
    }
}
