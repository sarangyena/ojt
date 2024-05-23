using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjPayroll
{
    public partial class frmPayroll : Form
    {
        private Int64 payId;
        public frmPayroll()
        {
            InitializeComponent();
        }

        private void frmPayroll_Load(object sender, EventArgs e)
        {
            LoadPayroll();
        }
        private void LoadPayroll()
        {
            try
            {
                clsPayrollM m = new clsPayrollM();
                grdPayroll.DataSource = m.GetPayroll().AsDataView();
            }
            catch (SqlException err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void btnEmp_Click(object sender, EventArgs e)
        {
            frmEmployee frm = new frmEmployee();
            frm.Show();
        }

        private void btnPayroll_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Currently in Payroll Tab.", "Payroll", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin frm = new frmLogin();
            frm.Show();
        }

        private void MasterTemplate_CellEndEdit(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            payId = Convert.ToInt64(grdPayroll.SelectedRows[0].Cells["id"].Value.ToString());
            Int64 holiday = Convert.ToInt64(grdPayroll.SelectedRows[0].Cells["holiday"].Value.ToString());
            Int64 philhealth = Convert.ToInt64(grdPayroll.SelectedRows[0].Cells["philhealth"].Value.ToString());
            Int64 sss = Convert.ToInt64(grdPayroll.SelectedRows[0].Cells["sss"].Value.ToString());
            Int64 advance = Convert.ToInt64(grdPayroll.SelectedRows[0].Cells["advance"].Value.ToString());
            Int64 total = Convert.ToInt64(grdPayroll.SelectedRows[0].Cells["total"].Value.ToString());

            MessageBox.Show(total.ToString());
        }
    }
}
