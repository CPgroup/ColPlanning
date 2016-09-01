using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraBars.Ribbon;


namespace CP.FrameWork
{
    public partial class FormMain : RibbonForm
    {
        public FormMain()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// ���������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            //��ӿ�DLL�д��ݵ�ǰ���ڿؼ�
            CP.Interface.Globe.SetFrameworkControl(this,
                                                    Program.gFormSplash,
                                                    this.statusStrip1,
                                                    this.tslMain,
                                                    this.tslProgress,
                                                    this.DockPanel,
                                                    this.tslCoor);

            this.ribbonControl.SelectedPage.Name = "resourceManage";//������ҳ

            //���ؿؼ�
            CP.Interface.Subsys1.MainInterface.AddFrameworkControl();      //�˺������س�ʼ����ͼ��     

        }
        
        private static int op = 1;//��ǰ�ؼ���1-resourceManage��2-OptimalAllocation��3-taskManage��4-CoScheduling
        /// <summary>
        /// ���л�ҳ��ʱ���ؿؼ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ribbonControl_SelectedPageChanged(object sender, EventArgs e)
        {            
            //Ϊ�۲���Դ����ҳ��ʱ��������Ӧ�ؼ�
            if (this.ribbonControl.SelectedPage.Name == "resourceManage" && op != 1)
            {
                CP.Interface.Subsys1.MainInterface.AddFrameworkControl();//���ݹ��������޸Ŀؼ�
                op = 1;
            }
            //���ع۲���Դ�Ż����ÿؼ�
            else if (this.ribbonControl.SelectedPage.Name == "OptimalAllocation")
            {
                CP.Interface.Subsys2.MainInterface.AddFrameworkControl2();//���ݹ��������޸Ŀؼ�
                op = 2;
            }
            //�����������ؼ�
            else if (this.ribbonControl.SelectedPage.Name == "taskManage")
            {
                CP.Interface.Subsys3.MainInterface.AddFrameworkControl3();//���ݹ��������޸Ŀؼ�
                op = 3;
            }
            //��������滮����ȿؼ�
            else if (this.ribbonControl.SelectedPage.Name == "CoScheduling")
            {
                CP.Interface.Subsys4.MainInterface.AddFrameworkControl4();//���ݹ��������޸Ŀؼ�
                op = 4;
            }
            
        }

        #region �۲���Դ����ģ��

        #region  ���˻�����

        /// <summary>
        /// ���˻��б�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UAVlist_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CP.Interface.Subsys1.MainInterface.UAVlist();

        }

        //�������ϸ�ʽͨ��CP.Interface�ӿ���CoScheduling.Main����ɺ��ĳ���

        #endregion

        #region  ������Դ����

      


        #endregion

        #region  ��������Դ����




        #endregion

      

        #endregion

        #region  �۲���Դ�Ż�����

        #region  ��ʷ�¼�����




        #endregion

        #region  �۲���Դ�Ż�����




        #endregion


        #endregion


        #region  �������

        #region  Ӧ���¼�����




        #endregion

        #region  �������




        #endregion


        #endregion

        #region  ����滮�����

        #region  ����滮




        #endregion

        #region  ��̬��Դ�滮




        #endregion

        #region  �ۺϹ���




        #endregion

        #endregion



    }
}