using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VJOMS
{
    public partial class frmPrint : Form
    {
        public string jono { get; set; }
        public frmPrint()
        {
            InitializeComponent();
        }

        private void frmPrint_Load(object sender, EventArgs e)
        {
            this.dsVJOMS.EnforceConstraints = false;
            this.dtVJOMSTableAdapter.Fill(this.dsVJOMS.dtVJOMS, jono);
            this.reportViewer1.RefreshReport();
        }
    }
}
