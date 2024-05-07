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
    public partial class frmJOReport : Form
    {
        public string jono { get; set; }
        public frmJOReport()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnParts_Click(object sender, EventArgs e)
        {
            frmPrint frm = new frmPrint();
            frm.jono = jono;
            frm.Show();
        }
    }
}
