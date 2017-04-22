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
            else if (this.ribbonControl.SelectedPage.Name == "PlanCoScheduling")
            {
                CP.Interface.Subsys4.MainInterface.AddFrameworkControl4();//���ݹ��������޸Ŀؼ�
                op = 4;
            }
            else if (this.ribbonControl.SelectedPage.Name == "ribbonPage1")
            {
                CP.Interface.Subsys5.MainInterface.AddFrameworkControl5();//���ݹ��������޸Ŀؼ�
                op = 5;
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

        private void barButtonItem62_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CP.Interface.Subsys5.MainInterface.ShowScen11();
        }

        private void buttonPosition_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CP.Interface.Subsys5.MainInterface.GainScen();
        }

        private void barButtonItem70_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form f = new CoScheduling.Main.Coverage.SatelliteCompute();
            f.Show();
            this.Visible = false;
        }

        private void barButtonManageTask_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CP.Interface.Subsys3.MainInterface.TaskManage();
        }

        private void barButtonQueryTask_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CP.Interface.Subsys3.MainInterface.TaskQuery();
        }

        private void barButtonGenerateTask_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CP.Interface.Subsys3.MainInterface.TaskGenerate();
        }

        private void barButtonTaskResMatch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CP.Interface.Subsys3.MainInterface.TaskResMatch();
        }

        private void barButtonUAVManage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CP.Interface.Subsys1.MainInterface.UAVManage();
        }

        private void barButtonUAVQuery_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CP.Interface.Subsys1.MainInterface.UAVQuery();
        }

        private void barButtonSensor1Query_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CP.Interface.Subsys1.MainInterface.Sensor1Query();
        }

        private void barButtonBandQuery_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CP.Interface.Subsys1.MainInterface.BandQuery();
        }

        private void barButtonSatManage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CP.Interface.Subsys1.MainInterface.SatelliteManage();
        }

        private void barButtonSatQuery_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CP.Interface.Subsys1.MainInterface.SatQuery();
        }

        private void barButtonAEROSHIPManage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CP.Interface.Subsys1.MainInterface.AEROSHIPManage();
        }

        private void barButtonAEROSHIPQuery_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CP.Interface.Subsys1.MainInterface.AEROSHIPQuery();
        }

        private void barButtonILLCARManage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CP.Interface.Subsys1.MainInterface.ILLUSTRATEDCARManage();
        }

        private void barButtonILLCARQuery_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CP.Interface.Subsys1.MainInterface.ILLUSTRATEDCARQuery();
        }

        private void barButtonSPYCAMManage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CP.Interface.Subsys1.MainInterface.SPYCAMManage();
        }

        private void barButtonSPYCAMQuery_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CP.Interface.Subsys1.MainInterface.SPYCAMQuery();
        }

        private void barButtonHUMDETManage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CP.Interface.Subsys1.MainInterface.HUMDETManage();
        }

        private void barButtonHUMDETQuery_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CP.Interface.Subsys1.MainInterface.HUMDETQuery();
        }

        
     
    

     

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