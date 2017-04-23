using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace CoScheduling.Main.Coverage
{
    public partial class BigAreaTarget : Form
    {
        public BigAreaTarget(int id)
        {
            InitializeComponent();
            schemeid = id;
        }
        private int schemeid;

        private string targetFile;

        public string TargetFile
        {
            get { return targetFile; }
            set { targetFile = value; }
        }

        private void buttonBigAreaTargetSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = "c:\\";
            dialog.Filter = "文本文件|*.txt|所有文件|*.*";
            dialog.RestoreDirectory = true;
            dialog.FilterIndex = 1;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.textBoxFile.Text = dialog.FileName;
            }
        }

        private void buttonBigAreaTargetOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.textBoxFile.Text))
            {
                MessageBox.Show("请选择有效文件后确定！");
            }
            else
            {
                targetFile = this.textBoxFile.Text;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void buttonBigAreaTargetCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
