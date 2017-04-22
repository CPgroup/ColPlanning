//----------------------------------------------------------------------------
//创建标识：李佳霖
// 创建描述: 地面测量车管理窗体类
// 创建时间:2017.4.19
// 文件版本:1.0
// 功能描述: 对数据库中的地面测量车数据进行管理
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

namespace CoScheduling.Main.ILLUSTRATEDCAR
{
    //地面测量车观测资源的管理窗口
    public partial class ILLUSTRATEDCARManage : Form
    {
        public ILLUSTRATEDCARManage()
        {
            InitializeComponent();
        }
        //地面测量车相关类的实例化
        CoScheduling.Core.DAL.ILLUSTRATEDCAR_RANGE dal_illustratedcar_range = new Core.DAL.ILLUSTRATEDCAR_RANGE();
        CoScheduling.Core.DAL.Sensor_1 dal_sensor_1 = new Core.DAL.Sensor_1();
        CoScheduling.Core.DAL.Sensor_Band_Mode dal_sensor_band_mode = new Core.DAL.Sensor_Band_Mode();
        /// <summary>
        /// 获取地面测量车信息列表DataSet
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetILLUSTRACARRangeDataSet(string strWhere)
        {
            DataSet ds = new DataSet();
            ds = dal_illustratedcar_range.GetListDataSet(strWhere);
            return ds;
        }
        /// <summary>
        /// 获取第1类传感器（SENSOR_1）列表DataSet
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
        /// 给dataGridViewILLUSTRATEDCAR绑定地面测量车信息数据
        /// </summary>
        /// <param name="strWhere">条件</param>
        public void bindILLUSTRACARInfo(string strWhere)
        {
            dataGridViewILLCAR.AutoGenerateColumns = false;
            this.dataGridViewILLCAR.DataSource = GetILLUSTRACARRangeDataSet(strWhere).Tables["ILLUSTRATEDCAR_RANGE"];
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

        private void ILLUSTRATEDCARManage_Load(object sender, EventArgs e)
        {
            bindILLUSTRACARInfo("PLATFORM_ID is not null");
            bindSensor1("SensorID is not null");
        }

        #region 地面测量车信息按钮操作
        private void ButtonILLCARAdd_Click(object sender, EventArgs e)
        {
            ILLUSTRATEDCAR.ILLUSTRATEDCARAdd newform = new ILLUSTRATEDCAR.ILLUSTRATEDCARAdd();
            newform.StartPosition = FormStartPosition.CenterScreen;
            //子窗体关闭，刷新卫星列表
            if (newform.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                bindILLUSTRACARInfo("");
            }
            newform.Dispose(); 
        }

        private void ButtonILLCARModify_Click(object sender, EventArgs e)
        {
            string illustratedcar_id = this.dataGridViewILLCAR.CurrentRow.Cells[0].Value.ToString();
            ILLUSTRATEDCAR.ILLUSTRATEDCARModify newform = new ILLUSTRATEDCAR.ILLUSTRATEDCARModify(illustratedcar_id);
            newform.StartPosition = FormStartPosition.CenterScreen;
            //子窗体关闭，刷新卫星列表
            if (newform.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                bindILLUSTRACARInfo("");
            }
            newform.Dispose();
        }

        private void ButtonILLCARDelete_Click(object sender, EventArgs e)
        {
            string platform_id = this.dataGridViewILLCAR.CurrentRow.Cells[0].Value.ToString();
            if (MessageBox.Show("确定删除任务记录?此删除不可恢复！", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    dal_illustratedcar_range.Delete(Convert.ToDecimal(platform_id));
                    dal_sensor_1.DeleteByPLATFORMID(platform_id);
                    dal_sensor_band_mode.DeleteByPLATFORMID(platform_id);

                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("删除失败！失败原因：" + ex.ToString());
                }
            }
            bindILLUSTRACARInfo("");
        }

        #endregion 地面测量车信息按钮操作
        #region 载荷按钮操作
        private void ButtonSensorAdd_Click(object sender, EventArgs e)
        {
            string platform_id = this.dataGridViewILLCAR.CurrentRow.Cells[0].Value.ToString();
            //string sensor_id = this.dataGridViewSensor.CurrentRow.Cells[0].Value.ToString();
            ILLUSTRATEDCAR.Sensor1Add newform = new ILLUSTRATEDCAR.Sensor1Add(platform_id);
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
            string platform_id = this.dataGridViewILLCAR.CurrentRow.Cells[0].Value.ToString();
            string sensor_id = this.dataGridViewSensor.CurrentRow.Cells[0].Value.ToString();
            ILLUSTRATEDCAR.Sensor1Modify newform = new ILLUSTRATEDCAR.Sensor1Modify(sensor_id);
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
            string platform_id = this.dataGridViewILLCAR.CurrentRow.Cells[0].Value.ToString();
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
        private void ButtonBandAdd_Click(object sender, EventArgs e)
        {
            string sensor_id = "";
            string platform_id = "";
            try
            {
                sensor_id = this.dataGridViewSensor.CurrentRow.Cells[0].Value.ToString();
                platform_id = this.dataGridViewILLCAR.CurrentRow.Cells[0].Value.ToString();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("请在选中对应的载荷之后，再进行添加波段操作！");
                return;
            }
            //生成窗体进行添加
            ILLUSTRATEDCAR.BandAdd newform = new ILLUSTRATEDCAR.BandAdd(sensor_id);
            newform.StartPosition = FormStartPosition.CenterScreen;
            //子窗体关闭，刷新卫星列表
            if (newform.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                bindBand("SensorID=" + sensor_id);
                bindSensor1("PLATFORM_ID=" + platform_id);
            }
            newform.Dispose();
        }

        private void ButtonBandModify_Click(object sender, EventArgs e)
        {
            string band_id = this.dataGridViewBand.CurrentRow.Cells[0].Value.ToString();
            string platform_id = this.dataGridViewBand.CurrentRow.Cells[4].Value.ToString();
            string sensor_id = this.dataGridViewBand.CurrentRow.Cells[3].Value.ToString();
            string currentSensor_id = this.dataGridViewSensor.CurrentRow.Cells[0].Value.ToString();
            ILLUSTRATEDCAR.BandModify newform = new ILLUSTRATEDCAR.BandModify(band_id, platform_id, sensor_id);
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
        private void dataGridViewILLCAR_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string platform_id;
            platform_id = this.dataGridViewILLCAR.CurrentRow.Cells[0].Value.ToString();
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
        #endregion









    }
}
