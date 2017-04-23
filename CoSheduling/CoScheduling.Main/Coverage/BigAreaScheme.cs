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
    public partial class BigAreaScheme : Form
    {
        public BigAreaScheme()
        {
            InitializeComponent();
        }
        private int schemeid;

        public int Schemeid
        {
            get { return schemeid; }
            set { schemeid = value; }
        }

        private void button1BigAreaSchemeOK_Click(object sender, EventArgs e)
        {
            CoScheduling.Core.Model.BIGAREA_SCHEME model = new CoScheduling.Core.Model.BIGAREA_SCHEME();
            CoScheduling.Core.DAL.BIGAREA_SCHEME dal = new CoScheduling.Core.DAL.BIGAREA_SCHEME();
            if (!String.IsNullOrEmpty(this.textBoxBigAreaSchemeName.Text) && (this.dateTimePickerBigAreaSchemeEndTime.Value > this.dateTimePickerBigAreaSchemeStartTime.Value))
            {
                model.SCHEMENAME = this.textBoxBigAreaSchemeName.Text;
                model.SCHEMEBTIME = this.dateTimePickerBigAreaSchemeStartTime.Value;
                model.SCHEMEETIME = this.dateTimePickerBigAreaSchemeEndTime.Value;
                try
                {
                    dal.Add(model);
                    schemeid = dal.GetLatestSchemeid();
                    this.DialogResult = DialogResult.OK;
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("方案添加失败，请检查数据连接！");
                }
            }
            else
            {
                MessageBox.Show("请填写有效信息！");
            }
        }

        private void buttonBigAreaSchemeClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}
