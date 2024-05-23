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
        public Int64 jono { get; set; }
        public frmPrint()
        {
            InitializeComponent();
        }

        private void frmPrint_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsBilling.dtBillingById' table. You can move, or remove it, as needed.
            this.dsVJOMS.EnforceConstraints = false;
            this.spPrintJOTableAdapter.Fill(this.dsVJOMS.spPrintJO, jono);
            this.reportViewer1.RefreshReport();
        }
    }
}
