using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.LookAndFeel;

namespace CP.FrameWork
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
       {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.OfficeSkins.Register();
            DevExpress.UserSkins.BonusSkins.Register();
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
            //gFormSplash = new FormSplash(); //���ڼ�����ͼ����ʾ
            //gFormSplash.Show();
            //gFormSplash.Refresh();

            _formMain = new FormMain();
            Application.Run(_formMain);//��������غ���
        }

        private static FormMain _formMain;
        public static FormSplash gFormSplash;

        public static void SetMainTipText(string tip)
        {

        }

        #region �������еĹ����ؼ�
        /// <summary>
        /// ������״̬����ʾ���
        /// </summary>
        internal static System.Windows.Forms.ToolStripStatusLabel gStatusLabel;
        /// <summary>
        /// ������״̬��������
        /// </summary>
        internal static System.Windows.Forms.ToolStripProgressBar gProgressBar;
        /// <summary>
        /// �����ڸ������
        /// </summary>
        internal static CP.WinFormsUI.Docking.DockPanel gDockPane;
        /// <summary>
        /// ������
        /// </summary>
        internal static System.Windows.Forms.Form gMainForm;
        /// <summary>
        /// ������״̬��
        /// </summary>
        internal static System.Windows.Forms.StatusStrip gStatusStrip;
        /// <summary>
        /// �������е�������
        /// </summary>
        internal static System.Windows.Forms.ToolStripStatusLabel gLabelCoor;
        /// <summary>
        /// ����״̬����ʾ��
        /// </summary>
        /// <param name="tip"></param>
        internal static void SetStatusLabel(string tip)
        {
            gStatusLabel.Text = tip;
            gStatusStrip.Refresh();
        }

        /// <summary>
        /// �������ֵ
        /// </summary>
        /// <param name="val"></param>
        internal static void SetProgreeMax(int val)
        {
            gProgressBar.Maximum = val;
        }

        /// <summary>
        /// ���������ڵĹ��״̬
        /// </summary>
        /// <param name="pCursor"></param>
        internal static void SetFormCursor(System.Windows.Forms.Cursor pCursor)
        {
            gMainForm.Cursor = pCursor;
        }

        /// <summary>
        /// ����������ʾ��Ϣ
        /// </summary>
        /// <param name="val"></param>
        internal static void SetCoorText(string val)
        {
            gLabelCoor.Text = val;
        }
        #endregion
    }
}