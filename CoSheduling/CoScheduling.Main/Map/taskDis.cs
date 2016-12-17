using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;

namespace CoScheduling.Main.Map
{
    public partial class taskDis : CP.WinFormsUI.Docking.DockContent
    {
        public taskDis()
        {
            InitializeComponent();

            #region 绑定控件

            bindCboxLayer(comboBox1);
            comboBox1.SelectedIndex = satNO;//卫星 图层序号
            bindCboxLayer(comboBox2);
            comboBox2.SelectedIndex = UAVNO;//无人机 
            bindCboxLayer(comboBox3);
            comboBox3.SelectedIndex = ASNO;//飞艇
            bindCboxLayer(comboBox4);
            comboBox4.SelectedIndex = CarNO;//车
            bindCboxLayer(comboBox10);
            comboBox10.SelectedIndex = TaskNO;//车
            bindCboxLayer(comboBox11);
            comboBox11.SelectedIndex = satLine;//车

            bindCboxTable(comboBox8, comboBox1.SelectedIndex);
            bindCboxTable(comboBox7, comboBox2.SelectedIndex);
            bindCboxTable(comboBox9, comboBox2.SelectedIndex);
            bindCboxTable(comboBox6, comboBox3.SelectedIndex);
            bindCboxTable(comboBox5, comboBox4.SelectedIndex);
            comboBox8.SelectedIndex = 1;//卫星
            #endregion

        }
        //四类资源图层序号
        int satNO = 10;
        int UAVNO = 0;
        int ASNO = 4;
        int CarNO = 2;
        int TaskNO = 12;
        int satLine = 7;
        /// <summary>
        /// 任务分解开始执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TaskDisOkbuttoon_Click(object sender, EventArgs e)
        {
            CoScheduling.Main.MainInterface.taskDis(comboBox1.SelectedIndex,comboBox11.SelectedIndex, comboBox2.SelectedIndex, comboBox3.SelectedIndex, comboBox4.SelectedIndex, comboBox10.SelectedIndex);
            //CoScheduling.Main.MainInterface.delete(comboBox1.SelectedIndex, comboBox2.SelectedIndex, comboBox3.SelectedIndex, comboBox4.SelectedIndex, comboBox10.SelectedIndex);
        }
        /// <summary>
        /// 窗口信息重置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void resetbutton_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = satNO;//卫星 图层序号
            comboBox2.SelectedIndex = UAVNO;//无人机 
            comboBox3.SelectedIndex = ASNO;//飞艇
            comboBox4.SelectedIndex = CarNO;//车
            comboBox10.SelectedIndex = TaskNO;//车
            comboBox11.SelectedIndex = satLine;//车
        }


        #region 公共函数
        /// <summary>
        /// combobox控件绑定数据
        /// </summary>
        private void bindCboxLayer(ComboBox comb)
        {
            IMapLayers mapLayers = Program.myMap.Map as IMapLayers;
            ILayer layer;
            //UID uid = new UIDClass();
            IList<Info> infoList = new List<Info>();
            //uid.Value = "{40A9E885-5533-11d0-98BE-00805F7CED21}"; // 代表只获取矢量图层
            //IEnumLayer layers = mapLayers.get_Layers(uid, true);
            //layer=mapLayers.get_Layer();
            //for (int i = 0; i <= 10;i++ )
            int i = 0;

            while (i < mapLayers.LayerCount)
            {
                layer = mapLayers.get_Layer(i);
                Info infoLayer = new Info() { CBId = i.ToString(), CBName = layer.Name };
                infoList.Add(infoLayer);
                i++;

            }
            comb.DataSource = infoList;
            comb.ValueMember = "CBId";
            comb.DisplayMember = "CBName";

            //Info info1 = new Info() { CBId = "1", CBName = "张三" };
            //Info info2 = new Info() { CBId = "2", CBName = "李四" };
            //Info info3 = new Info() { CBId = "3", CBName = "王五" };
            //infoList.Add(info1);
            //infoList.Add(info2);
            //infoList.Add(info3);
            //comboBox1.DataSource = infoList;
            //comboBox1.ValueMember = "Id";
            //comboBox1.DisplayMember = "Name";
        }

        private void bindCboxTable(ComboBox comb, int LayerNO)
        {
            IMapLayers mapLayers = Program.myMap.Map as IMapLayers;
            IFeatureLayer pFeatureLayer;
            ILayer layer;

            //IList<Info> infoList = new List<Info>();


            layer = mapLayers.get_Layer(LayerNO);

            pFeatureLayer = layer as IFeatureLayer;


            //ITable table = pFeatureLayer.FeatureClass as ITable;
            int num = pFeatureLayer.FeatureClass.Fields.FieldCount;
            List<string> lstName = new List<string>();

            for (int j = 0; j < num; j++)
            {
                string name = pFeatureLayer.FeatureClass.Fields.get_Field(j).Name;
                lstName.Add(name);
            }

            //Info infoLayer = new Info() { CBId = i.ToString(), CBName = layer.Name };
            //infoList.Add(infoLayer);
            //i++;


            comb.DataSource = lstName;
            //comb.ValueMember = "CBId";
            //comb.DisplayMember = "CBName";
        }
        #endregion

        #region 当空间绑定图层更改时 重新绑定数据
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindCboxTable(comboBox8, comboBox1.SelectedIndex);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindCboxTable(comboBox7, comboBox2.SelectedIndex);
            bindCboxTable(comboBox9, comboBox2.SelectedIndex);

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindCboxTable(comboBox6, comboBox3.SelectedIndex);

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindCboxTable(comboBox5, comboBox4.SelectedIndex);
        } 
        #endregion

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            //bindCboxTable(comboBox8, comboBox11.SelectedIndex);
        }

    }

    #region 公共类
    /// <summary>
    /// combobox绑定
    /// </summary>
    public class Info
    {
        public string CBId { get; set; }
        public string CBName { get; set; }

    }

    #endregion
}
