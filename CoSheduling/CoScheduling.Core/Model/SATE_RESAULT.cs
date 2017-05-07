//----------------------------------------------------------------------------
//创建标识：刘宝举      
// 创建描述: 卫星覆盖任务实体类
// 创建时间:2017.5.7
// 文件版本:1.0
// 功能描述:卫星覆盖任务的实体类，描述卫星覆盖任务的各项属性，包括成员变量和构造函数
// 修改标识: 
// 修改描述: 
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoScheduling.Core.Model
{
   public class SATE_RESAULT
    {
       public SATE_RESAULT()
        {
            //成员变量默认值
           _AngularVelocity = 35/180;//度每秒
           
        }
       /// <summary>
       /// 
       /// </summary>
       /// <param name="LSTR_SEQID"></param>
       /// <param name="SCHEMEID">规划id</param>
       /// <param name="TASKID">任务id</param>
       /// <param name="POLYGONSTRING">覆盖范围</param>
       /// <param name="STARTTIME">开始时间</param>
       /// <param name="ENDTIME">结束时间</param>
       /// <param name="SATID">卫星id</param>
       /// <param name="SAT_STKNAME">卫星名称</param>
       /// <param name="SENSOR_ID">传感器id</param>
       /// <param name="SENSOR_STKNAME">传感器名称</param>
       /// <param name="SLEW_ANGLE">侧摆角</param>
       /// <param name="AngularVelocity">侧摆速度</param>
       public SATE_RESAULT(decimal LSTR_SEQID, decimal SCHEMEID, decimal TASKID, string POLYGONSTRING, DateTime STARTTIME, DateTime ENDTIME, decimal SATID, string SAT_STKNAME, decimal SENSOR_ID, string SENSOR_STKNAME, decimal SLEW_ANGLE,decimal AngularVelocity)
        {
            _LSTR_SEQID = LSTR_SEQID;
            _SCHEMEID = SCHEMEID;
            _TASKID = TASKID;
            _POLYGONSTRING = POLYGONSTRING;
            _STARTTIME = STARTTIME;
            _ENDTIME = ENDTIME;
            _SATID = SATID;
            _SAT_STKNAME = SAT_STKNAME;
            _SENSOR_ID = SENSOR_ID;
            _SENSOR_STKNAME = SENSOR_STKNAME;
            _SLEW_ANGLE = SLEW_ANGLE;
            _AngularVelocity = AngularVelocity;
        }

        #region Model
       private decimal _LSTR_SEQID;
       
        private decimal _SCHEMEID;
      
        private DateTime _STARTTIME;
        private DateTime _ENDTIME;
        private decimal _TASKID;
        private string _POLYGONSTRING;
        private decimal _SATID;
        private string _SAT_STKNAME;
        private decimal _SENSOR_ID;
        private decimal _SLEW_ANGLE;
        private decimal _AngularVelocity;
        private string _SENSOR_STKNAME;
        
        
        //定义各成员变量的赋值和获取值的函数
        public decimal LSTR_SEQID
        {
            set { _LSTR_SEQID = value; }
            get { return _LSTR_SEQID; }
        }
        public decimal SCHEMEID
        {
            set { _SCHEMEID = value; }
            get { return _SCHEMEID; }
        }
        public DateTime STARTTIME
        {
            set { _STARTTIME = value; }
            get { return _STARTTIME; }
        }
        public DateTime ENDTIME
        {
            set { _ENDTIME = value; }
            get { return _ENDTIME; }
        }
        public decimal TASKID
        {
            set { _TASKID = value; }
            get { return _TASKID; }
        }
        public string POLYGONSTRING
        {
            set { _POLYGONSTRING = value; }
            get { return _POLYGONSTRING; }
        }
        public decimal SATID
        {
            set { _SATID = value; }
            get { return _SATID; }
        }

        public decimal SENSOR_ID
        {
            set { _SENSOR_ID = value; }
            get { return _SENSOR_ID; }
        }
        public string SAT_STKNAME
        {
            set { _SAT_STKNAME = value; }
            get { return _SAT_STKNAME; }
        }
        public decimal SLEW_ANGLE
        {
            set { _SLEW_ANGLE = value; }
            get { return _SLEW_ANGLE; }
        }
        public string SENSOR_STKNAME
        {
            set { _SENSOR_STKNAME = value; }
            get { return _SENSOR_STKNAME; }
        }
        public decimal AngularVelocity
        {
            set { _AngularVelocity = value; }
            get { return _AngularVelocity; }
        }
      
        #endregion Model

    }
}
