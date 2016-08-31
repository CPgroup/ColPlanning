namespace CoScheduling.Core.Generic
{
    //
    //���ܣ���ϵͳ����XML�ļ����ж�д����
    //���ߣ����ǿ
    //ʱ�䣺2009.11.18.
    //�汾��V1.0

    public class myXML
    {

        System.Xml.XmlDocument mXmlDoc = new System.Xml.XmlDocument ( );
        string _xmlFile;

        /// <summary>
        /// �����ļ�XML·��
        /// </summary>
        /// <remarks></remarks>
        public string XmlFile
        {
            get { return _xmlFile; }
            set { _xmlFile = value; }
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        public myXML ( )
        {

        }
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="File">xml�ļ�·��</param>
        /// <remarks></remarks>
        public myXML ( string File )
        {
            _xmlFile = File;
            //���������ļ�
            mXmlDoc.Load ( _xmlFile );
        }

        /// <summary>
        /// ����XML�ļ�
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
        /// ��ȡԪ��ֵ
        /// </summary>
        /// <param name="node">�ڵ�</param>
        /// <param name="element">Ԫ����</param>
        /// <returns></returns>
        /// <remarks>���أ�Ԫ��ֵ�ַ���,����$--��ʾ������</remarks>
        public string GetElement ( string node, string element )
        {
            try
            {
                System.Xml.XmlNode mXmlNode = mXmlDoc.SelectSingleNode ( "//" + node );

                //������
                System.Xml.XmlNode xmlNode = mXmlNode.SelectSingleNode ( element );
                return xmlNode.InnerText.ToString ( );
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// ����Ԫ��ֵ
        /// </summary>
        /// <param name="node">�ڵ�����</param>
        /// <param name="element">Ԫ����</param>
        /// <param name="val">ֵ</param>
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