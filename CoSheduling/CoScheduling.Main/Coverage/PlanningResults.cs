using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace CoScheduling.Main.Coverage
{
    public partial class PlanningResults : CP.WinFormsUI.Docking.DockContent
    {
        public PlanningResults()
        {
            InitializeComponent();
        }

        private AGI.STKObjects.AgStkObjectRoot root;
        private AGI.STKObjects.AgStkObjectRoot stkRoot
        {
            get
            {
                if (root == null)
                {
                    root = new AGI.STKObjects.AgStkObjectRoot();
                }
                return root;
            }
        }

        internal static CoverageMain formCOV;
        private void tabControl1_DoubleClick(object sender, EventArgs e)
        {
            string timeStr = this.dataGridViewTimewindow.CurrentRow.Cells[7].Value.ToString();
            //把东八区时间设置为UTC时间
            DateTime currentTime = Convert.ToDateTime(timeStr).AddHours(-8);
            if (stkRoot.CurrentScenario != null)
            {

                //string setTime = String.Format("{0:r}", currentTime);
                string setTime = "SetAnimation * CurrentTime \"" + currentTime.ToString("dd MMM yyyy HH:mm:ss") + "\"";
                stkRoot.ExecuteCommand(setTime);
                //root.ExecuteCommand("SetAnimation * CurrentTime \"16 Sep 1992 01:00:00.000\"");

            }
        }
    }
}
