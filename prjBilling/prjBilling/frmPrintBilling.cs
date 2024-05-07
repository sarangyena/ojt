using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjBilling
{
    public partial class frmPrintBilling : Form
    {
        public Int64 billingId { get; set; }
        public frmPrintBilling()
        {
            InitializeComponent();
            billingId = 97;
        }

        private void frmPrintBilling_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsBilling.dtBillingById' table. You can move, or remove it, as needed.
            this.dsBilling.EnforceConstraints = false;
            this.dtBillingByIdTableAdapter.Fill(this.dsBilling.dtBillingById, billingId);

            this.reportViewer1.RefreshReport();
        }
    }
}
