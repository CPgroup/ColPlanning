using System;
using System.Collections.Generic;
using System.Text;

namespace CoScheduling.Core.Model
{
    public class STKTarget
    {
        public STKTarget()
		{ }
        /// <summary>
        /// 构造函数 STKTarget
        /// </summary>
        /// <param name="tARGET_TYPE">TARGET_TYPE</param>
        /// <param name="tARGET_TYPE">TARGET_ID</param>
        /// <param name="tARGET_NAME">TARGET_NAME</param>
        public STKTarget(string tARGET_TYPE, int tARGET_ID,string tARGET_NAME)
        {
            _tARGET_TYPE = tARGET_TYPE;
            _tARGET_ID = tARGET_ID;
            _tARGET_NAME = tARGET_NAME;
        }
        #region Model

        private string _tARGET_TYPE;
        private int _tARGET_ID;

        
        private string _tARGET_NAME;
        /// <summary>
        /// 目标类型
        /// </summary>
        public string TARGET_TYPE
        {
            get { return _tARGET_TYPE; }
            set { _tARGET_TYPE = value; }
        }
        /// <summary>
        /// 目标ID
        /// </summary>
        public int TARGET_ID
        {
            get { return _tARGET_ID; }
            set { _tARGET_ID = value; }
        }
        /// <summary>
        /// 目标名称
        /// </summary>
        public string TARGET_NAME
        {
            get { return _tARGET_NAME; }
            set { _tARGET_NAME = value; }
        }
        

        #endregion Model
    }
}
