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
using CoScheduling.Main;
using ESRI.ArcGIS.esriSystem;

namespace CP.FrameWork
{
    public partial class FormMain : RibbonForm
    {
        public FormMain()
        {
            //IAoInitialize m_AoInitialize = new AoInitializeClass();
            //esriLicenseStatus licenseStatus = esriLicenseStatus.esriLicenseUnavailable;

            //licenseStatus = m_AoInitialize.Initialize(esriLicenseProductCode.esriLicenseProductCodeAdvanced);//�����esriLicenseProductCode����Ĳ�Ʒ�����Լ�ѡ��
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
            else if (this.ribbonControl.SelectedPage.Name == "PlanCoScheduling")
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
        internal static CoScheduling.Main.Map.taskDis formTaskDis;
        #region  ����滮
        /// <summary>
        /// ����ֽ� ������������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void taskDisButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {            
            //taskDisPanel.Visible = true;//�򿪿������
           // CoScheduling.Main.Map.taskDis taskdisBut = new CoScheduling.Main.Map.taskDis();
            if (formTaskDis == null) formTaskDis = new CoScheduling.Main.Map.taskDis();
            else if (formTaskDis.IsDisposed) formTaskDis = new CoScheduling.Main.Map.taskDis();         
           formTaskDis.Show(this.DockPanel,WinFormsUI.Docking.DockState.DockRight);  
            formTaskDis.IsHidden = false;
            formTaskDis.Text = "����ֽ�";
            

        }

       
        #endregion
     
    

     

        #region  ��̬��Դ�滮




        #endregion

        #region  �ۺϹ���
        /// <summary>
        /// ʵ��panel�϶�
        /// </summary>
        //Point pt;
        //private void taskDisPanel_MouseDown(object sender, MouseEventArgs e)
        //{
        //    pt = Cursor.Position;
        //}

        //private void taskDisPanel_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Left)
        //    {
        //        int px = Cursor.Position.X - pt.X;
        //        int py = Cursor.Position.Y - pt.Y;
        //        //taskDisPanel.Location = new Point(taskDisPanel.Location.X + px, taskDisPanel.Location.Y + py);


        //        pt = Cursor.Position;
        //    }
        //}



        #endregion

        #endregion



    }
}