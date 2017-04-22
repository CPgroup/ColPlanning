//----------------------------------------------------------------------------
//创建标识：李佳霖
// 创建描述: 志愿者设备管理窗体类
// 创建时间:2017.4.19
// 文件版本:1.0
// 功能描述: 对数据库中的志愿者设备数据进行管理
// 修改标识: 
// 修改描述: 
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CoScheduling.Main.HUMANDETECTION
{
    public partial class HUMANDETECTIONManage : Form
    {
        public HUMANDETECTIONManage()
        {
            InitializeComponent();
        }

        //志愿者设备相关类的实例化
        CoScheduling.Core.DAL.HUMANDETECTION_RANGE dal_humdet_range = new Core.DAL.HUMANDETECTION_RANGE();
        CoScheduling.Core.DAL.SENSOR_2 dal_sensor_2 = new Core.DAL.SENSOR_2();
        CoScheduling.Core.DAL.Sensor_Band_Mode dal_sensor_band_mode = new Core.DAL.Sensor_Band_Mode();

        /// <summary>
        /// 获取志愿者设备信息列表DataSet
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetHUMDETRangeDataSet(string strWhere)
        {
            DataSet ds = new DataSet();
            ds = dal_humdet_range.GetListDataSet(strWhere);
            return ds;
        }
        /// <summary>
        /// 获取第二类传感器（Sensor_2）列表DataSet
        /// </summary>
        /// <param name="strWhere">条件</param>
        public DataSet GetSensor2DataSet(string strWhere)
        {
            DataSet ds = dal_sensor_2.GetListDataSet(strWhere);
            return ds;
        }
        /// <summary>
        /// 获取载荷波段DataSet
        /// </summary>
        /// <param name="strWhere">条件</param>
        public DataSet GetBandDataSet(string strWhere)
        {
            DataSet ds = dal_sensor_band_mode.GetListDataSet(strWhere);
            return ds;
        }

        /// <summary>
        /// 给dataGridViewHUMDET绑定无人机信息数据
        /// </summary>
        /// <param name="strWhere">条件</param>
        public void bindHUMDETInfo(string strWhere)
        {
            dataGridViewHUMDET.AutoGenerateColumns = false;
            this.dataGridViewHUMDET.DataSource = GetHUMDETRangeDataSet(strWhere).Tables["HUMANDETECTION_RANGE"];
        }
        /// <summary>
        /// 给dataGridViewSensor绑定载荷数据
        /// </summary>
        /// <param name="strWhere">条件</param>
        public void bindSensor2(string strWhere)
        {
            dataGridViewSensor.AutoGenerateColumns = false;
            this.dataGridViewSensor.DataSource = GetSensor2DataSet(strWhere).Tables["SENSOR_2"];
        }
        /// <summary>
        /// 给dataGridViewBand绑定波段数据
        /// </summary>
        /// <param name="strWhere">条件</param>
        public void bindBand(string strWhere)
        {
            dataGridViewBand.AutoGenerateColumns = false;
            this.dataGridViewBand.DataSource = GetBandDataSet(strWhere).Tables["SENSOR_BAND_MODE"];
        }

        private void HUMANDETECTIONManage_Load(object sender, EventArgs e)
        {
            bindHUMDETInfo("PLATFORM_ID is not null");
            bindSensor2("SensorID is not null");
        }
        #region 志愿者设备按钮操作
        private void ButtonHUMDETAdd_Click(object sender, EventArgs e)
        {
            HUMANDETECTION.HUMDETAdd newform = new HUMANDETECTION.HUMDETAdd();
            newform.StartPosition = FormStartPosition.CenterScreen;
            //子窗体关闭，刷新卫星列表
            if (newform.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                bindHUMDETInfo("");
            }
            newform.Dispose(); 
        }

        private void ButtonHUMDETModify_Click(object sender, EventArgs e)
        {
            string humdet_id = this.dataGridViewHUMDET.CurrentRow.Cells[0].Value.ToString();
            HUMANDETECTION.HUMDETModify newform = new HUMANDETECTION.HUMDETModify(humdet_id);
            newform.StartPosition = FormStartPosition.CenterScreen;
            //子窗体关闭，刷新摄像头列表
            if (newform.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                bindHUMDETInfo("");
            }
            newform.Dispose();
        }
        //载荷删除
        private void ButtonHUMDETDelete_Click(object sender, EventArgs e)
        {
            string platform_id = this.dataGridViewHUMDET.CurrentRow.Cells[0].Value.ToString();
            if (MessageBox.Show("确定删除任务记录?此删除不可恢复！", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    dal_humdet_range.Delete(Convert.ToDecimal(platform_id));
                    dal_sensor_2.DeleteByPLATFORMID(platform_id);
                    dal_sensor_band_mode.DeleteByPLATFORMID(platform_id);

                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("删除失败！失败原因：" + ex.ToString());
                }
            }
            bindHUMDETInfo("");
        }
        #endregion 飞艇信息按钮操作

        #region 载荷按钮操作
        private void ButtonSensorAdd_Click(object sender, EventArgs e)
        {
            string platform_id = this.dataGridViewHUMDET.CurrentRow.Cells[0].Value.ToString();
            //string sensor_id = this.dataGridViewSensor.CurrentRow.Cells[0].Value.ToString();
            HUMANDETECTION.SENSOR2Add newform = new HUMANDETECTION.SENSOR2Add(platform_id);
            newform.StartPosition = FormStartPosition.CenterScreen;
            //子窗体关闭，刷新卫星列表
            if (newform.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                bindSensor2("PLATFORM_ID=" + platform_id);
            }
            newform.Dispose();
        }

        private void ButtonSensorModify_Click(object sender, EventArgs e)
        {
            string platform_id = this.dataGridViewHUMDET.CurrentRow.Cells[0].Value.ToString();
            string sensor_id = this.dataGridViewSensor.CurrentRow.Cells[0].Value.ToString();
            HUMANDETECTION.SENSOR2Modify newform = new HUMANDETECTION.SENSOR2Modify(sensor_id);
            newform.StartPosition = FormStartPosition.CenterScreen;
            //子窗体关闭，刷新卫星列表
            if (newform.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                bindSensor2("PLATFORM_ID=" + platform_id);
            }
            newform.Dispose();
        }
        //载荷删除
        private void ButtonSensorDelete_Click(object sender, EventArgs e)
        {
            string sensor_id = this.dataGridViewSensor.CurrentRow.Cells[0].Value.ToString();
            string platform_id = this.dataGridViewHUMDET.CurrentRow.Cells[0].Value.ToString();
            if (MessageBox.Show("确定删除载荷及波段信息?此删除不可恢复！", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    dal_sensor_2.Delete(Convert.ToDecimal(sensor_id));
                    dal_sensor_band_mode.DeleteBySensorID(sensor_id);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("删除失败！失败原因：" + ex.ToString());
                }
                bindSensor2("PLATFORM_ID=" + platform_id);
            }
        }
        #endregion 载荷按钮操作

        #region 波段按钮操作
        //波段添加
        private void ButtonBandAdd_Click(object sender, EventArgs e)
        {
            string sensor_id = "";
            string platform_id = "";
            try
            {
                sensor_id = this.dataGridViewSensor.CurrentRow.Cells[0].Value.ToString();
                platform_id = this.dataGridViewHUMDET.CurrentRow.Cells[0].Value.ToString();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("请在选中对应的载荷之后，再进行添加波段操作！");
                return;
            }
            //生成窗体进行添加
            HUMANDETECTION.BandAdd newform = new HUMANDETECTION.BandAdd(sensor_id);
            newform.StartPosition = FormStartPosition.CenterScreen;
            //子窗体关闭，刷新卫星列表
            if (newform.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                bindBand("SensorID=" + sensor_id);
                bindSensor2("PLATFORM_ID=" + platform_id);
            }
            newform.Dispose();
        }

        private void ButtonBandModify_Click(object sender, EventArgs e)
        {
            string band_id = this.dataGridViewBand.CurrentRow.Cells[0].Value.ToString();
            string platform_id = this.dataGridViewBand.CurrentRow.Cells[4].Value.ToString();
            string sensor_id = this.dataGridViewBand.CurrentRow.Cells[3].Value.ToString();
            string currentSensor_id = this.dataGridViewSensor.CurrentRow.Cells[0].Value.ToString();
            HUMANDETECTION.BandModify newform = new HUMANDETECTION.BandModify(band_id, platform_id, sensor_id);
            newform.StartPosition = FormStartPosition.CenterScreen;
            //子窗体关闭，刷新卫星列表
            if (newform.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                bindBand("SensorID=" + currentSensor_id);
                bindSensor2("PLATFORM_ID=" + platform_id);
            }
            newform.Dispose();
        }

        private void ButtonBandDelete_Click(object sender, EventArgs e)
        {
            string band_id = this.dataGridViewBand.CurrentRow.Cells[0].Value.ToString();
            string platform_id = this.dataGridViewBand.CurrentRow.Cells[4].Value.ToString();
            string sensor_id = this.dataGridViewBand.CurrentRow.Cells[3].Value.ToString();
            string currentSensor_id = this.dataGridViewSensor.CurrentRow.Cells[0].Value.ToString();

            if (MessageBox.Show("确定删除载荷及波段信息?此删除不可恢复！", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    dal_sensor_band_mode.Delete(band_id, platform_id, sensor_id);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("删除失败！失败原因：" + ex.ToString());
                }
            }
            bindBand("SensorID=" + currentSensor_id);
            bindSensor2("PLATFORM_ID=" + platform_id);
        }
        #endregion 波段按钮操作

        #region 表格单元点击操作
        private void dataGridViewHUMDET_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string platform_id;
            platform_id = this.dataGridViewHUMDET.CurrentRow.Cells[0].Value.ToString();
            //显示志愿者载荷信息，根据平台ID
            bindSensor2("PLATFORM_ID=" + platform_id);
        }

        private void dataGridViewSensor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string sensor_id;
            try
            {
                sensor_id = this.dataGridViewSensor.CurrentRow.Cells[0].Value.ToString();
                bindBand("SensorID=" + sensor_id);
                this.ButtonSensorModify.Enabled = true;
                this.ButtonSensorModify.Enabled = true;
                this.ButtonBandAdd.Enabled = true;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion 表格单元点击操作

    }
}
