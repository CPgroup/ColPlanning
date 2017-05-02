using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OracleClient;
using CoScheduling.Core.Model;
using CoScheduling.Core.DAL;
//ESRI的命名空间
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.NetworkAnalyst;
using ESRI.ArcGIS.Geoprocessor;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.AnalysisTools;

namespace CoScheduling.Main.TaskRequirement
{
    public partial class TaskResMatch : Form
    {
        public TaskResMatch()
        {
            InitializeComponent();
        }

        //任务需求相关类实例化
        CoScheduling.Core.Model.TaskRequirement taskrequirement = new Core.Model.TaskRequirement();
        CoScheduling.Core.DAL.TaskRequirement dal_taskrequirement = new CoScheduling.Core.DAL.TaskRequirement();

        //CoScheduling.Core.Model.TaskObsRegion taskobsregion = new Core.Model.TaskObsRegion();
        //CoScheduling.Core.DAL.TaskObsRegion dal_taskobsregion = new Core.DAL.TaskObsRegion();
        //观测资源传感器相关类实例化
        CoScheduling.Core.Model.Sensor_1 sensor1 = new Core.Model.Sensor_1();//第一类传感器
        CoScheduling.Core.DAL.Sensor_1 dal_sensor1 = new Core.DAL.Sensor_1();
        CoScheduling.Core.Model.Sensor_Band_Mode sensorbandmode = new Core.Model.Sensor_Band_Mode();//传感器波段
        CoScheduling.Core.DAL.Sensor_Band_Mode dal_sensorbandmode = new Core.DAL.Sensor_Band_Mode();

        CoScheduling.Core.Model.SensorsMatched sensorsmatched = new Core.Model.SensorsMatched();
        CoScheduling.Core.DAL.SensorsMatched dal_sensorsmatched = new Core.DAL.SensorsMatched();
        //无人机相关类的实例化
        CoScheduling.Core.Model.UAV_RANGE uav_range = new Core.Model.UAV_RANGE();//无人机实体类
        CoScheduling.Core.DAL.UAV_RANGE dal_uav_range = new Core.DAL.UAV_RANGE();
        CoScheduling.Core.Model.UAV_Base uav_base = new Core.Model.UAV_Base();//无人机基站实体类
        CoScheduling.Core.DAL.UAV_Base dal_uav_base = new Core.DAL.UAV_Base();
        //观测资源平台相关类的实例化
        CoScheduling.Core.Model.STATE state = new Core.Model.STATE();
        CoScheduling.Core.DAL.STATE dal_state = new Core.DAL.STATE();

        /// <summary>
        /// 获取任务信息列表DataSet
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetSensor1InfoDataSet(string strWhere)
        {
            DataSet ds = new DataSet();
            ds = dal_sensor1.GetListDataSet(strWhere);
            return ds;
        }
        public DataSet GetTaskInfoDataSet(string strWhere)
        {
            DataSet ds = new DataSet();
            ds = dal_taskrequirement.GetListDataSet(strWhere);
            return ds;
        }

        public void bindTaskInfo(string strWhere)
        {
            dataGridViewTask.AutoGenerateColumns = false;
            this.dataGridViewTask.DataSource = GetTaskInfoDataSet(strWhere).Tables["TaskRequirements_general"];//Table函数的意义？
        }

        private void TaskResMatch_Load(object sender, EventArgs e)
        {
            bindTaskInfo("TaskID is not null");
        }
        //根据字符串列表判断所需的传感器类型SensorType的编号（0 雷达传感器 1 光学传感器 2代表）
        private int GetSensorTypeID(string [] strlist)
        {
            //用于存储是否需要雷达和光学传感器
            bool IS_SAR=false;
            bool IS_OPT=false;
            foreach(string str in strlist)
            {
                if (str!="")
                {
                    if (str == "可见光" || str == "近红外" || str == "短红外" || str == "中红外" || str == "热红外" || str == "紫外" || str == "激光荧光")
                    {
                        IS_OPT=true;
                    }
                    if (str=="SAR_X"||str=="SAR_C"||str=="SAR_S"||str=="SAR_L")
                    {
                        IS_SAR = true;
                    }
                }
            }
            if (IS_SAR == true && IS_OPT == false)
                return 0;
            else if (IS_SAR == false && IS_OPT == true)
                return 1;
            else if (IS_SAR == true && IS_OPT == true)
                return 2;
            else
                return -1;
        }

        private void ButtonMatch_Click(object sender, EventArgs e)
        {
            //获取需要匹配的任务需求，所需传感器类型、最大空间分辨率和范围
            string task_id = this.dataGridViewTask.CurrentRow.Cells[0].Value.ToString();
            taskrequirement = dal_taskrequirement.GetModel(Convert.ToDecimal(task_id));
            //taskobsregion = dal_taskobsregion.GetModel(Convert.ToDecimal(task_id));
            
            decimal MaxSpaceResolution = taskrequirement.SpaceResolution;
            string SensorsNeeded = taskrequirement.SensorNeeded;
            string[] SensorsNeeded_split = SensorsNeeded.Split(' ');
            
            //存储结果的数据集
            DataSet DSSensor1QueryResult = new DataSet();
            //首先要就传感器类型和空间分辨率指标查询观测资源传感器
            string SensorQueryCondition = ""; 
            SensorQueryCondition += " GeometryResolution<=" + MaxSpaceResolution;
            SensorQueryCondition += " And ( ";

            //根据传感器类型string判断数据库中SensorType中0或1的对应关系，0代表雷达，1代表光学
            int SensorTypeID = GetSensorTypeID(SensorsNeeded_split);
            if (SensorTypeID==0||SensorTypeID==1)
            {
                SensorQueryCondition += "SensorType='" + SensorTypeID.ToString()+"'";
            }
            else if(SensorTypeID==2)
            {
                SensorQueryCondition += "SensorType='" + "1' " + " or " + "SensorType='" + "0' ";
            }
            SensorQueryCondition += " )";
          
            //查询
            try
            {
                DSSensor1QueryResult = GetSensor1InfoDataSet(SensorQueryCondition);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("请输入正确的参数！");
            }
            DataTable DTSensor1=DSSensor1QueryResult.Tables["SENSOR_1"];

            string whereClause_Band = "";
            bool BandTypeConstraint = false;
            string BandTypeNeeded = "";
            //针对经过空间分辨率和SensorTypeID查出来的传感器列表进行BandType波段类型的查询
            for (int i = DTSensor1.Rows.Count - 1; i >= 0; i--)
            {
                //获取这一条记录的传感器ID
                decimal sensorid = Convert.ToDecimal(DTSensor1.Rows[i]["SensorID"].ToString());
                whereClause_Band = "SensorID=" + sensorid;
                //根据获取的传感器ID，SensorID来获取Sensor_Band_Mode表中所有对应的Band实体
                List<CoScheduling.Core.Model.Sensor_Band_Mode> SensorBandList = dal_sensorbandmode.GetList(whereClause_Band);
                BandTypeConstraint = false;//针对每个传感器都要从默认的false开始判断

                //对每一个观测任务中所需的传感器波段类型，判断已经筛选出的传感器的波段是否能够满足
                for (int j = 0; j < SensorsNeeded_split.Count()-1;j++ )
                {
                    //将观测任务中所需传感器类型的中文表达转换成英文表达
                    BandTypeNeeded = BandTypeTask2Resource(SensorsNeeded_split[j]);


                    //先判断提供的波段类型是否与当前需求的是否一致
                    //如果满足，不用再进行下一个需求波段的判断
                    for(int k=0;k<SensorBandList.Count;k++)
                    {
                        if (SensorBandList[k].BandType == "PAN" && (BandTypeNeeded.Contains("IS") || BandTypeNeeded.Contains("IR")))
                        {
                            BandTypeConstraint = true;
                            break;
                        }
                        //如果传感器提供的波段类型与任务需求的一个相符，条件满足
                        else if (SensorBandList[k].BandType.Contains(BandTypeNeeded))
                        {
                            BandTypeConstraint = true;
                            break;
                        }
                    }
                    if(BandTypeConstraint==true)
                    {
                        break;
                    }
                }
                //对应传感器，如果不满足波段类型条件，在DataTable中移除
                if (BandTypeConstraint == false)
                {
                    DTSensor1.Rows[i].Delete();
                }
                    
            }
            DTSensor1.AcceptChanges();




            //空间范围约束条件
            string[] pointcoord = taskrequirement.PolygonString.Split(';');
            List<IPoint> lstPoint = new List<IPoint>(pointcoord.Length);
            bool ObvRegConstraint = false;
            //将taskobsregion中的经纬度范围转化为矩形四个边界点
            int pointcount = pointcoord.Length;
            for (int i = 0; i < pointcount - 1;i++ )
            {
                lstPoint.Add(GetFlatCoordinate(Convert.ToDouble(pointcoord[i].Split(',')[0]), Convert.ToDouble(pointcoord[i].Split(',')[1])));
            }
            //将边界点转化成IGeometry的多边形
            IPointCollection PCollection_ObvReg = new Multipoint();
            for (int i = 0; i < lstPoint.Count;i++ )
            {
                PCollection_ObvReg.AddPoint(lstPoint[i]);
            }
            IGeometry Polygon_ObvReg = getGeometry(PCollection_ObvReg);
                
            //对于传感器观测条件进行查询
            for (int i = DTSensor1.Rows.Count - 1; i >= 0; i--)
            {
                decimal platformid =Convert.ToDecimal( DTSensor1.Rows[i]["PLATFORM_ID"].ToString());
                if (platformid.ToString().Length==5 || (platformid.ToString().Length==6 && platformid.ToString()[0]=='1'))//卫星
                { 
                    ObvRegConstraint = ISMatchSTCondition(lstPoint, platformid, taskrequirement.StartTime, taskrequirement.EndTime); 
                }
                else if (platformid.ToString().Length == 6 && (platformid.ToString()[0] == '3' || platformid.ToString()[0] == '2'))//飞艇无人机
                {
                    //计算无人机的覆盖距离
                    uav_range = dal_uav_range.GetModel(platformid);
                    decimal cruisingvelocity = uav_range.CruisingVelocity;
                    decimal cruisingtime = uav_range.CruisingTime;
                    decimal coverdistance = cruisingvelocity *1000 * (cruisingtime / 60);
                    //无人机当前所在地的坐标（State表）
                    state = dal_state.GetModel(platformid);
                    decimal state_lon = state.Longitude;
                    decimal state_lat = state.Latitude;
                    IPoint pointpostition = GetFlatCoordinate(Convert.ToDouble(state_lon), Convert.ToDouble(state_lat));//基站点的平面坐标
                    decimal distance_basepoint2region = Convert.ToDecimal(GetTwoGeometryDistance(pointpostition as IGeometry, Polygon_ObvReg));//点到面的距离
                    if (coverdistance>=distance_basepoint2region)
                    {
                        ObvRegConstraint = true;
                    }
                }
                //如果不满足条件，将这一条记录在Sensor1表中删除
                if (ObvRegConstraint==false)
                {
                    DTSensor1.Rows[i].Delete();
                }
            }
            DTSensor1.AcceptChanges();

            //筛选结果的显示
            dataGridViewSensor.AutoGenerateColumns = false;
            this.dataGridViewSensor.DataSource = DTSensor1;

            getSensorNum();
        }
        /// <summary>
        /// 计算两个几何对象之间的距离
        /// </summary>
        /// <param name="pGeometryA"></param>
        /// <param name="pGeometryB"></param>
        /// <returns></returns>
        private double GetTwoGeometryDistance(IGeometry pGeometryA, IGeometry pGeometryB)
        {
            IProximityOperator pProOperator = pGeometryA as IProximityOperator;
            if (pGeometryA != null || pGeometryB != null)
            {
                double distance = pProOperator.ReturnDistance(pGeometryB);
                return distance;
            }
            else
            {
                return 0;
            }
        }
        //由点集生成面（环形Polygon）
        private IGeometry getGeometry(IPointCollection Points)
        {
            Ring ring = new RingClass();
            object missing = Type.Missing;

            ring.AddPointCollection(Points);

            IGeometryCollection pointPolygon = new PolygonClass();
            pointPolygon.AddGeometry(ring as IGeometry, ref missing, ref missing);
            IPolygon polyGonGeo = pointPolygon as IPolygon;
            //polyGonGeo.Close();
            polyGonGeo.SimplifyPreserveFromTo();
            return polyGonGeo as IGeometry;
        }
        // 将经纬度点转换为平面坐标
        private IPoint GetFlatCoordinate(double x, double y)
        {
            //投影坐标系转换，经纬度到平面坐标
            ISpatialReferenceFactory SRFactory = new SpatialReferenceEnvironment();
            IProjectedCoordinateSystem flatref = SRFactory.CreateProjectedCoordinateSystem(2369);//54坐标，需要改成80坐标
            IGeographicCoordinateSystem earthref = SRFactory.CreateGeographicCoordinateSystem((int)esriSRGeoCSType.esriSRGeoCS_NAD1983);

            IPoint pt = new PointClass();
            pt.PutCoords(x, y);
            IGeometry geo = (IGeometry)pt;
            geo.SpatialReference = earthref;
            geo.Project(flatref);
            return pt;
        }
        /// <summary>
        /// 将任务描述中中文的所需传感器的描述转换成观测资源英文缩写波段类型的描述
        /// </summary>
        /// <param name="strBandTypeTask"></param>
        /// <returns></returns>
        private string BandTypeTask2Resource(string strBandTypeTask)
        {
            string BandTypeResource = "";
            if (strBandTypeTask == "紫外")
            {
                BandTypeResource = "UV";
            }
            else if (strBandTypeTask == "激光荧光")
            {
                BandTypeResource = "LasFlu";
            }
            else if (strBandTypeTask == "可见光")
            {
                BandTypeResource = "VIS";
            }
            else if (strBandTypeTask == "近红外")
            {
                BandTypeResource = "NIR";
            }
            else if (strBandTypeTask == "短红外")
            {
                BandTypeResource = "SWIR";
            }
            else if (strBandTypeTask=="中红外")
            {
                BandTypeResource = "MWIR";
            }
            else if (strBandTypeTask=="热红外")
            {
                BandTypeResource = "TIR";
            }
            else if (strBandTypeTask=="SAR_X")
            {
                BandTypeResource = "X";
            }
            else if (strBandTypeTask == "SAR_C")
            {
                BandTypeResource = "C";
            }
            else if (strBandTypeTask == "SAR_S")
            {
                BandTypeResource = "S";
            }
            else if (strBandTypeTask == "SAR_L")
            {
                BandTypeResource = "L";
            }
            else if (strBandTypeTask == "SAR_X")
            {
                BandTypeResource = "X";
            }
            else if (strBandTypeTask == "高光谱")
            {
                BandTypeResource = "HypSpe";
            }
            else
            {
                MessageBox.Show("所需波段类型不正确！");
            }
            return BandTypeResource;
        }


        /// <summary>
        /// 判断时空观测条件是否满足，调用韦君STK接口来实现
        /// </summary>
        /// <param name="obsreg"></param>观测区域边界点list
        /// <param name="platformid"></param>平台ID
        /// <param name="starttime"></param>观测要求开始的时间
        /// <param name="endtime"></param>观测要求结束的时间
        /// <returns></returns>
        private bool ISMatchSTCondition(List<IPoint> obsreg, decimal platformid, DateTime starttime,DateTime endtime)
        {
            return true;
        }
        /// <summary>
        /// 获取查询出来的传感器数量
        /// </summary>
        private void getSensorNum()
        {
            int SensorCount = Convert.ToInt16(dataGridViewSensor.Rows.Count.ToString());
            this.txtSensorCount.Text = SensorCount.ToString();
        }




    }
}
