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
    public partial class SelectBigAreaScheme : Form
    {
        public SelectBigAreaScheme()
        {
            InitializeComponent();
        }
        private int schemeid;

        public int Schemeid
        {
            get { return schemeid; }
            set { schemeid = value; }
        }
        private void SelectBigAreaScheme_Load(object sender, EventArgs e)
        {
            CoScheduling.Core.DAL.BIGAREA_SCHEME dal_taskScheme = new CoScheduling.Core.DAL.BIGAREA_SCHEME();
            this.checkedListBox1.DataSource = dal_taskScheme.GetList();
            this.checkedListBox1.DisplayMember = "SCHEMENAME";
            this.checkedListBox1.ValueMember = "SCHEMEID";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            schemeid = Convert.ToInt32(this.checkedListBox1.SelectedValue);
        }
        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (this.checkedListBox1.CheckedItems.Count > 0)
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (i != e.Index)
                    {
                        this.checkedListBox1.SetItemCheckState(i, System.Windows.Forms.CheckState.Unchecked);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}
