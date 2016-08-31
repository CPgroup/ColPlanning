namespace CoScheduling.Core.Generic
{
    //
    //功能：对系统配置XML文件进行读写操作
    //作者：李光强
    //时间：2009.11.18.
    //版本：V1.0

    public class myXML
    {

        System.Xml.XmlDocument mXmlDoc = new System.Xml.XmlDocument ( );
        string _xmlFile;

        /// <summary>
        /// 配置文件XML路径
        /// </summary>
        /// <remarks></remarks>
        public string XmlFile
        {
            get { return _xmlFile; }
            set { _xmlFile = value; }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public myXML ( )
        {

        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="File">xml文件路径</param>
        /// <remarks></remarks>
        public myXML ( string File )
        {
            _xmlFile = File;
            //加载配置文件
            mXmlDoc.Load ( _xmlFile );
        }

        /// <summary>
        /// 加载XML文件
        /// </summary>
        /// <returns></returns>
        public bool LoadXML()
        {
            try
            {
                mXmlDoc.Load(_xmlFile);
                return true;
            }
            catch { return false; }
        }

        /// <summary>
        /// 读取元素值
        /// </summary>
        /// <param name="node">节点</param>
        /// <param name="element">元素名</param>
        /// <returns></returns>
        /// <remarks>返回：元素值字符型,其中$--表示出错误</remarks>
        public string GetElement ( string node, string element )
        {
            try
            {
                System.Xml.XmlNode mXmlNode = mXmlDoc.SelectSingleNode ( "//" + node );

                //读数据
                System.Xml.XmlNode xmlNode = mXmlNode.SelectSingleNode ( element );
                return xmlNode.InnerText.ToString ( );
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 保存元素值
        /// </summary>
        /// <param name="node">节点名称</param>
        /// <param name="element">元素名</param>
        /// <param name="val">值</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool SaveElement ( string node, string element, string val )
        {
            try
            {
                System.Xml.XmlNode mXmlNode = mXmlDoc.SelectSingleNode ( "//" + node );
                System.Xml.XmlNode xmlNodeNew = default ( System.Xml.XmlNode );

                xmlNodeNew = mXmlNode.SelectSingleNode ( element );
                xmlNodeNew.InnerText = val;
                mXmlDoc.Save ( XmlFile );
                return true;
            }
            catch { return false; }
        }


    }

}