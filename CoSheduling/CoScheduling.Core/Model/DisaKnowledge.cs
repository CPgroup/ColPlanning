//----------------------------------------------------------------------------
//创建标识：李佳霖
// 创建描述: 灾害遥感应用知识实体类
// 创建时间:2017.3.21
// 文件版本:1.0
// 功能描述:灾害遥感应用知识的实体类，描述各类灾害所需的遥感数据空间分辨率和传感器类型
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
    /// 实体类 DisaKnowledge
    /// </summary>
    public class DisaKnowledge
    {
        public DisaKnowledge()
        { }
        public DisaKnowledge(decimal Disaster_ID,string Disaster_Name,
            decimal Max_SpatialResolution,bool UV_Needed,bool LasFlu_Needed,
            bool VISNIR_Needed,bool SIR_Needed,bool MIR_Needed,bool TIR_Needed,
            bool SAR_X_Needed,bool SAR_C_Needed,bool SAR_S_Needed,bool SAR_L_Needed,
            bool HypSpe_Needed,bool CamSpy_Needed)
        {
            _Disaster_ID = Disaster_ID;
            _Disaster_Name = Disaster_Name;
            _Max_SpatialResolution = Max_SpatialResolution;
            _UV_Needed = UV_Needed;
            _LasFlu_Needed = LasFlu_Needed;
            _VISNIR_Needed = VISNIR_Needed;
            _SIR_Needed = SIR_Needed;
            _MIR_Needed = MIR_Needed;
            _TIR_Needed = TIR_Needed;
            _SAR_X_Needed = SAR_X_Needed;
            _SAR_C_Needed = SAR_C_Needed;
            _SAR_S_Needed = SAR_S_Needed;
            _SAR_L_Needed = SAR_L_Needed;
            _HypSpe_Needed = HypSpe_Needed;
            _CamSpy_Needed = CamSpy_Needed;
        }


        #region Model
        private decimal _Disaster_ID;
        private string _Disaster_Name;
        private decimal _Max_SpatialResolution;
        private bool _UV_Needed;
        private bool _LasFlu_Needed;
        private bool _VISNIR_Needed;
        private bool _SIR_Needed;
        private bool _MIR_Needed;
        private bool _TIR_Needed;
        private bool _SAR_X_Needed;
        private bool _SAR_C_Needed;
        private bool _SAR_S_Needed;
        private bool _SAR_L_Needed;
        private bool _HypSpe_Needed;
        private bool _CamSpy_Needed;

        //定义各成员变量的赋值和获取值的函数
        public decimal Disaster_ID
        {
            set { _Disaster_ID = value; }
            get { return _Disaster_ID; }
        }
        public string Disaster_Name
        {
            set { _Disaster_Name = value; }
            get { return _Disaster_Name; }
        }
        public decimal Max_SpatialResolution
        {
            set { _Max_SpatialResolution = value; }
            get { return _Max_SpatialResolution; }
        }
        public bool UV_Needed
        {
            set { _UV_Needed = value; }
            get { return _UV_Needed; }
        }
        public bool LasFlu_Needed
        {
            set { _LasFlu_Needed = value; }
            get { return _LasFlu_Needed; }
        }
        public bool VISNIR_Needed
        {
            set { _VISNIR_Needed = value; }
            get { return _VISNIR_Needed; }
        }
        public bool SIR_Needed
        {
            set { _SIR_Needed = value; }
            get { return _SIR_Needed; }
        }
        public bool MIR_Needed
        {
            set { _MIR_Needed = value; }
            get { return _MIR_Needed; }
        }
        public bool TIR_Needed
        {
            set { _TIR_Needed = value; }
            get { return _TIR_Needed; }
        }
        public bool SAR_X_Needed
        {
            set { _SAR_X_Needed = value; }
            get { return _SAR_X_Needed; }
        }
        public bool SAR_C_Needed
        {
            set { _SAR_C_Needed = value; }
            get { return _SAR_C_Needed; }
        }
        public bool SAR_S_Needed
        {
            set { _SAR_S_Needed = value; }
            get { return _SAR_S_Needed; }
        }
        public bool SAR_L_Needed
        {
            set { _SAR_L_Needed = value; }
            get { return _SAR_L_Needed; }
        }
        public bool HypSpe_Needed
        {
            set { _HypSpe_Needed = value; }
            get { return _HypSpe_Needed; }
        }
        public bool CamSpy_Needed
        {
            set { _CamSpy_Needed = value; }
            get { return _CamSpy_Needed; }
        }
        #endregion Model







    }
}
