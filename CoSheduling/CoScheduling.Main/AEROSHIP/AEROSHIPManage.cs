//----------------------------------------------------------------------------
//创建标识：李佳霖
// 创建描述: 飞艇管理窗体类
// 创建时间:2017.4.19
// 文件版本:1.0
// 功能描述: 对数据库中的飞艇数据进行管理
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

namespace CoScheduling.Main.AEROSHIP
{
    //飞艇观测资源的管理窗口
    public partial class AEROSHIPManage : Form
    {
        public AEROSHIPManage()
        {
            InitializeComponent();
        }
        //飞艇相关类的实例化
        CoScheduling.Core.DAL.AEROSHIP_RANGE dal_aeroship_range = new Core.DAL.AEROSHIP_RANGE();
        CoScheduling.Core.DAL.Sensor_1 dal_sensor_1 = new Core.DAL.Sensor_1();
        CoScheduling.Core.DAL.Sensor_Band_Mode dal_sensor_band_mode = new Core.DAL.Sensor_Band_Mode();
        /// <summary>
        /// 获取飞艇信息列表DataSet
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetAEROSHIPRangeDataSet(string strWhere)
        {
            DataSet ds = new DataSet();
            ds = dal_aeroship_range.GetListDataSet(strWhere);
            return ds;
        }
        /// <summary>
        /// 获取第一类传感器（Sensor_1）列表DataSet
        /// </summary>
        /// <param name="strWhere">条件</param>
        public DataSet GetSensor1DataSet(string strWhere)
        {
            DataSet ds = dal_sensor_1.GetListDataSet(strWhere);
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
        /// 给dataGridViewAEROSHIP绑定无人机信息数据
        /// </summary>
        /// <param name="strWhere">条件</param>
        public void bindAEROSHIPInfo(string strWhere)
        {
            dataGridViewAEROSHIP.AutoGenerateColumns = false;
            this.dataGridViewAEROSHIP.DataSource = GetAEROSHIPRangeDataSet(strWhere).Tables["AEROSHIP_RANGE"];
        }
        /// <summary>
        /// 给dataGridViewSensor绑定载荷数据
        /// </summary>
        /// <param name="strWhere">条件</param>
        public void bindSensor1(string strWhere)
        {
            dataGridViewSensor.AutoGenerateColumns = false;
            this.dataGridViewSensor.DataSource = GetSensor1DataSet(strWhere).Tables["SENSOR_1"];
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

        private void AEROSHIPManage_Load(object sender, EventArgs e)
        {
            bindAEROSHIPInfo("PLATFORM_ID is not null");
            bindSensor1("SensorID is not null");
        }
        #region 飞艇信息按钮操作
        private void ButtonAEROSHIPAdd_Click(object sender, EventArgs e)
        {
            AEROSHIP.AEROSHIPAdd newform = new AEROSHIP.AEROSHIPAdd();
            newform.StartPosition = FormStartPosition.CenterScreen;
            //子窗体关闭，刷新卫星列表
            if (newform.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                bindAEROSHIPInfo("");
            }
            newform.Dispose(); 
        }

        private void ButtonAEROSHIPModify_Click(object sender, EventArgs e)
        {
            string aeroship_id = this.dataGridViewAEROSHIP.CurrentRow.Cells[0].Value.ToString();
            AEROSHIP.AEROSHIPModify newform = new AEROSHIP.AEROSHIPModify(aeroship_id);
            newform.StartPosition = FormStartPosition.CenterScreen;
            //子窗体关闭，刷新卫星列表
            if (newform.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                bindAEROSHIPInfo("");
            }
            newform.Dispose();
        }

        private void ButtonAEROSHIPDelete_Click(object sender, EventArgs e)
        {
            string platform_id = this.dataGridViewAEROSHIP.CurrentRow.Cells[0].Value.ToString();
            if (MessageBox.Show("确定删除任务记录?此删除不可恢复！", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    dal_aeroship_range.Delete(Convert.ToDecimal(platform_id));
                    dal_sensor_1.DeleteByPLATFORMID(platform_id);
                    dal_sensor_band_mode.DeleteByPLATFORMID(platform_id);

                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("删除失败！失败原因：" + ex.ToString());
                }
            }
            bindAEROSHIPInfo("");
        }
        #endregion 飞艇信息按钮操作
        #region 载荷按钮操作
        private void ButtonSensorAdd_Click(object sender, EventArgs e)
        {
            string platform_id = this.dataGridViewAEROSHIP.CurrentRow.Cells[0].Value.ToString();
            //string sensor_id = this.dataGridViewSensor.CurrentRow.Cells[0].Value.ToString();
            AEROSHIP.Sensor1Add newform = new AEROSHIP.Sensor1Add(platform_id);
            newform.StartPosition = FormStartPosition.CenterScreen;
            //子窗体关闭，刷新卫星列表
            if (newform.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                bindSensor1("PLATFORM_ID=" + platform_id);
            }
            newform.Dispose();
        }

        private void ButtonSensorModify_Click(object sender, EventArgs e)
        {
            string platform_id = this.dataGridViewAEROSHIP.CurrentRow.Cells[0].Value.ToString();
            string sensor_id = this.dataGridViewSensor.CurrentRow.Cells[0].Value.ToString();
            AEROSHIP.Sensor1Modify newform = new AEROSHIP.Sensor1Modify(sensor_id);
            newform.StartPosition = FormStartPosition.CenterScreen;
            //子窗体关闭，刷新卫星列表
            if (newform.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                bindSensor1("PLATFORM_ID=" + platform_id);
            }
            newform.Dispose();
        }
        //载荷删除
        private void ButtonSensorDelete_Click(object sender, EventArgs e)
        {
            string sensor_id = this.dataGridViewSensor.CurrentRow.Cells[0].Value.ToString();
            string platform_id = this.dataGridViewAEROSHIP.CurrentRow.Cells[0].Value.ToString();
            if (MessageBox.Show("确定删除载荷及波段信息?此删除不可恢复！", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    dal_sensor_1.Delete(Convert.ToDecimal(sensor_id));
                    dal_sensor_band_mode.DeleteBySensorID(sensor_id);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("删除失败！失败原因：" + ex.ToString());
                }
                bindSensor1("PLATFORM_ID=" + platform_id);
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
                platform_id = this.dataGridViewAEROSHIP.CurrentRow.Cells[0].Value.ToString();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("请在选中对应的载荷之后，再进行添加波段操作！");
                return;
            }
            //生成窗体进行添加
            AEROSHIP.BandAdd newform = new AEROSHIP.BandAdd(sensor_id);
            newform.StartPosition = FormStartPosition.CenterScreen;
            //子窗体关闭，刷新卫星列表
            if (newform.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                bindBand("SensorID=" + sensor_id);
                bindSensor1("PLATFORM_ID=" + platform_id);
            }
            newform.Dispose();
        }
        //波段修改
        private void ButtonBandModify_Click(object sender, EventArgs e)
        {
            string band_id = this.dataGridViewBand.CurrentRow.Cells[0].Value.ToString();
            string platform_id = this.dataGridViewBand.CurrentRow.Cells[4].Value.ToString();
            string sensor_id = this.dataGridViewBand.CurrentRow.Cells[3].Value.ToString();
            string currentSensor_id = this.dataGridViewSensor.CurrentRow.Cells[0].Value.ToString();
            AEROSHIP.BandModify newform = new AEROSHIP.BandModify(band_id, platform_id, sensor_id);
            newform.StartPosition = FormStartPosition.CenterScreen;
            //子窗体关闭，刷新卫星列表
            if (newform.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                bindBand("SensorID=" + currentSensor_id);
                bindSensor1("PLATFORM_ID=" + platform_id);
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
            bindSensor1("PLATFORM_ID=" + platform_id);
        }
        #endregion 波段按钮操作

        #region 表格单元点击操作
        private void dataGridViewAEROSHIP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string platform_id;
            platform_id = this.dataGridViewAEROSHIP.CurrentRow.Cells[0].Value.ToString();
            //显示无人机载荷信息，根据无人机ID
            bindSensor1("PLATFORM_ID=" + platform_id);
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
