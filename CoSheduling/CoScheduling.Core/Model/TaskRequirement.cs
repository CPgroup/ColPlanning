//----------------------------------------------------------------------------
//创建标识：李佳霖
// 创建描述: 观测任务需求实体类
// 创建时间:2017.2.28
// 文件版本:1.0
// 功能描述:观测任务的实体类，描述观测任务的各项属性，包括成员变量和构造函数
// 修改标识: 
// 修改描述: 
//------------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CoScheduling.Core.Model
{
    /// <summary>
    /// 实体类 TaskRequirement
    /// </summary>
    public class TaskRequirement
    {
        public TaskRequirement()
        {
            //成员变量默认值
            _TaskPriority = 1;
            _RespondingTime = 2;
            _TaskStage = "观测阶段";
            _ObservationFrequency = 1;
            _Weather = "晴";
            _Windlevel = 1;
            _MinTemperature = 10;
            _MaxTemperature = 20;
            _RoadAccessability = true;
        }
        
        public TaskRequirement(decimal TaskID,string TaskName,DateTime SubmissionTime,decimal TaskPriority,string DisasterType,string TaskStage,
            DateTime StartTime,DateTime EndTime,decimal RespondingTime,string SensorNeeded,decimal ObservationFrequency,string Weather,decimal Windlevel,
            decimal MinTemperature,decimal MaxTemperature,bool RoadAccessability,decimal SpaceResolution,decimal Datavolume,DateTime OccurTime)
        {
            _TaskID = TaskID;
            _TaskName = TaskName;
            _SubmissionTime = SubmissionTime;
            _TaskPriority = TaskPriority;
            _DisasterType = DisasterType;
            _TaskStage = TaskStage;
            _StartTime = StartTime;
            _EndTime = EndTime;
            _RespondingTime = RespondingTime;
            _SensorNeeded = SensorNeeded;
            _ObservationFrequency = ObservationFrequency;
            _Weather = Weather;
            _Windlevel = Windlevel;
            _MinTemperature = MinTemperature;
            _MaxTemperature = MaxTemperature;
            _RoadAccessability = RoadAccessability;
            _SpaceResolution = SpaceResolution;
            _Datavolume = Datavolume;
            _OccurTime = OccurTime;
        }

        #region Model
        private decimal _TaskID;
        private string _TaskName;
        private DateTime _SubmissionTime;
        private decimal _TaskPriority;
        private string _DisasterType;
        private string _TaskStage;
        private DateTime _StartTime;
        private DateTime _EndTime;
        private decimal _RespondingTime;
        private string _SensorNeeded;
        private decimal _ObservationFrequency;
        private string _Weather;
        private decimal _Windlevel;
        private decimal _MinTemperature;
        private decimal _MaxTemperature;
        private bool _RoadAccessability;
        private decimal _SpaceResolution;
        private decimal _Datavolume;
        private DateTime _OccurTime;
        
        //定义各成员变量的赋值和获取值的函数
        public decimal TaskID
        {
            set { _TaskID = value; }
            get { return _TaskID; }
        }
        public string TaskName
        {
            set { _TaskName = value; }
            get { return _TaskName; }
        }
        public DateTime SubmissionTime
        {
            set { _SubmissionTime = value; }
            get { return _SubmissionTime; }
        }
        public decimal TaskPriority
        {
            set { _TaskPriority = value; }
            get { return _TaskPriority; }
        }
        public string DisasterType
        {
            set { _DisasterType = value; }
            get { return _DisasterType; }
        }
        public string TaskStage
        {
            set { _TaskStage = value; }
            get { return _TaskStage; }
        }
        public DateTime StartTime
        {
            set { _StartTime = value; }
            get { return _StartTime; }
        }
        public DateTime EndTime
        {
            set { _EndTime = value; }
            get { return _EndTime; }
        }
        public decimal RespondingTime
        {
            set { _RespondingTime = value; }
            get { return _RespondingTime; }
        }
        public string SensorNeeded
        {
            set { _SensorNeeded = value; }
            get { return _SensorNeeded; }
        }
        public decimal ObservationFrequency
        {
            set { _ObservationFrequency = value; }
            get { return _ObservationFrequency; }
        }
        public string Weather
        {
            set { _Weather = value; }
            get { return _Weather; }
        }
        public decimal Windlevel
        {
            set { _Windlevel = value; }
            get { return _Windlevel; }
        }
        public decimal MinTemperature
        {
            set { _MinTemperature = value; }
            get { return _MinTemperature; }
        }
        public decimal MaxTemperature
        {
            set { _MaxTemperature = value; }
            get { return _MaxTemperature; }
        }
        public bool RoadAccessability
        {
            set { _RoadAccessability = value; }
            get { return _RoadAccessability; }
        }
        public decimal SpaceResolution
        {
            set { _SpaceResolution = value; }
            get { return _SpaceResolution; }
        }
        public decimal Datavolume
        {
            set { _Datavolume = value; }
            get { return _Datavolume; }
        }
        public DateTime OccurTime
        {
            set { _OccurTime = value; }
            get { return _OccurTime; }
        }
        #endregion Model


    }
}
