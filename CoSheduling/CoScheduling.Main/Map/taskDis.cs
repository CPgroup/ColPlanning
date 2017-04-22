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
using System.IO;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;
using VSAllocation;
using MLApp;

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

            comboBox12.Items.Add("面积优先");
            comboBox12.Items.Add("权重优先");
            comboBox12.Items.Add("面积权重");
            comboBox12.SelectedIndex = 0;
            #endregion

        }
        //四类资源图层序号
        int satNO = 11;
        int UAVNO = 1;
        int ASNO = 5;
        int CarNO = 3;
        int TaskNO = 13;
        int satLine = 8;
        //int CarToTaskLineNo = 6;
        /// <summary>
        /// 任务分解开始执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TaskDisOkbuttoon_Click(object sender, EventArgs e)
        {
            #region c#调用matlab 尝试 （已注释）
            //MLApp.MLApp matlab = null;
            //Type matlabAppType = System.Type.GetTypeFromProgID("Matlab.Application");
            //matlab = System.Activator.CreateInstance(matlabAppType) as MLApp.MLApp;
            //VSAllocation.Class1 PlanAll = new Class1();

            //string path_project = System.AppDomain.CurrentDomain.BaseDirectory;   //工程文件的路径，如bin  
            //string path_matlab = "cd('" + path_project + "')";     //自定义matlab工作路径    
            //matlab.Execute(path_matlab);
            //matlab.Execute("clear all");//<span style="color:#ff6666;">//这条语句也很重要，先注释掉，下面讲解</span> 

            //MWNumericArray ReturnMat = new MWNumericArray(MWArrayComplexity.Real, 3, 3);//收益矩阵 行：资源  列：元任务 double[,] dbx = new double[2, 2] { { 1, 2 }, { 3, 4 } };
            //double[,] dbx = new double[2, 4] { { 1, 2, 2, 1 }, { 1, 1, 2, 0 } };
            //MWNumericArray OritoEleMat = dbx;//卫星子任务与元任务对应关系矩阵
            //double[,] dbxx = new double[2, 5] { { 2,0, 2,0,0 }, { 4,0, 2, 0,1 } };
            //MWNumericArray ConfliMat = dbxx;//元任务冲突关系矩阵
            //MWArray ReturnMwa = ReturnMat;
            //MWArray OritoEleMwa = OritoEleMat;
            //MWArray ConfliMwa = ConfliMat;
            //MWNumericArray UavNoMwa = 1;
            //MWNumericArray ASNoMwa = 1;
            //object resultOb = new object();
            //MWArray[] aa = new MWArray[1];
            //try
            //{
            //    ////string cmdMa = @""+resultOb+"=VSAllocation(" + ReturnMat + "," + OritoEleMat + "," + ConfliMat + "," + UavNoMwa + "," + ASNoMwa + ")";
            //    ////string cmdMa = @"[a,b]=VSAllocation(" + ReturnMat + "," + OritoEleMat + "," + ConfliMat + "," + UavNoMwa + "," + ASNoMwa + ")";
            //    //double[] av = { 1, 2, 3, 4, 5, 6 };//输入参数1
            //    //MWNumericArray ma = new MWNumericArray(3, 2, av);//转换成matlab需求的格式
            //    //MWArray[] agrsIn = new MWArray[] { ma};
            //    //string cmdMa = "a=size(" + agrsIn + "):";
            //    ////string cmdMa =  "a=[1,2,4;2,3,6]";
            //    //matlab.Execute(cmdMa);
            //    MWArray[] agrsIn = new MWArray[] { ReturnMat, OritoEleMat, ConfliMat, UavNoMwa, ASNoMwa };
            //    MWArray[] agrsOut = new MWArray[2];//两个输出参数，一定要写数量
            //    PlanAll.VSAllocation(2, ref agrsOut, agrsIn);
            //    MWNumericArray x1 = agrsOut[0] as MWNumericArray;
            //    MWNumericArray x2 = agrsOut[1] as MWNumericArray;
            //    double[,]  c = (double[,])x1.ToArray();
            //     double[,] d = (double[,])x2.ToArray();
            //    //object resultObj = PlanAll.VSAllocation(2, ReturnMwa, OritoEleMwa, ConfliMwa, UavNoMwa, ASNoMwa);// 2 表示返回的结果数量，要小于等于matlab对应函数实际的返回值数量
            //    object result = matlab.GetVariable("a", "base");
            //    double mm = (double)resultOb;
            //    object[] resultObjs = (object[])resultOb;

            //    double[,] AllocationPlan = (double[,])resultObjs[0];
            //    double[,] MaxR = (double[,])resultObjs[1];
            //}
            //catch (Exception)
            //{

            //    throw;
            //} 
            #endregion


            CoScheduling.Main.MainInterface.taskDis(comboBox1.SelectedIndex, comboBox11.SelectedIndex, comboBox2.SelectedIndex, comboBox3.SelectedIndex, comboBox4.SelectedIndex, comboBox10.SelectedIndex);
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
        /// <summary>
        /// 按照网格分解
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GirdDisButton_Click(object sender, EventArgs e)
        {
            CoScheduling.Main.MainInterface.GridTaskDis(comboBox1.SelectedIndex, comboBox11.SelectedIndex, comboBox2.SelectedIndex, comboBox3.SelectedIndex, comboBox4.SelectedIndex, comboBox10.SelectedIndex, progressBar1);

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
        /// <summary>
        /// 规划结果显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlanAllocationButton_Click(object sender, EventArgs e)
        {
            CoScheduling.Main.MainInterface.PlanAllocation("Data\\cache\\" + "UToTaUni.shp");//"Data\\CacheGrid\\" + "GirdTask.shp");//"Data\\cache\\" + "UToTaUni.shp";
        }
        /// <summary>
        /// q其他方法对比 通过comboBox12选定面积优先 权重优先等
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)//优先
        {
            CoScheduling.Main.MainInterface.AreaFirst(comboBox1.SelectedIndex, comboBox11.SelectedIndex, comboBox2.SelectedIndex, comboBox3.SelectedIndex, comboBox4.SelectedIndex, comboBox10.SelectedIndex, comboBox12.SelectedIndex, textBox1);
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
