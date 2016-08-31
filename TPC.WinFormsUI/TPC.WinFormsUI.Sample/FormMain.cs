using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TPC.WinFormsUI.Sample
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show(this.dockPanel1, Docking.DockState.DockLeft);
 Form1 frm2 = new Form1();
            frm2.Show(this.dockPanel1, Docking.DockState.Document);
        }
    }
}
