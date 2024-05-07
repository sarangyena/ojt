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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void projecctListToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmBillingList pl = new frmBillingList();
            pl.StartPosition = FormStartPosition.CenterScreen;
            pl.WindowState = FormWindowState.Maximized;
            pl.Show();
        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
