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

namespace prjBilling
{
    public partial class frmBillingList : Form
    {
        private Int64 branchId;
        private Int64 billingId;

        public frmBillingList()
        {
            InitializeComponent();
            branchId = 0;
            billingId = 0;
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MasterTemplate_Click(object sender, EventArgs e)
        {

        }

        private void frmBillingList_Load(object sender, EventArgs e)
        {
            //LoadBillingList();
            LoadBranch();
        }


        private void LoadBillingList()
        {
            try
            {
                clsBillingDV dv = new clsBillingDV();
                grdList.DataSource = dv.GetAllBillings().AsDataView();
            }
            catch(SqlException err)
            {
                MessageBox.Show(err.Message, "Billing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBranch()
        {
            try
            {
                clsBranchDV dv = new clsBranchDV();
                grdBranch.DataSource = dv.GetBranch().AsDataView();
            }
            catch (SqlException err)
            {
                MessageBox.Show(err.Message, "Billing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void addRecord_Click(object sender, EventArgs e)
        {
            try
            {
                if(branchId == 0)
                {
                    MessageBox.Show("Please select a branch.");
                }
                else
                {
                    frmAddRecord addRecord = new frmAddRecord();
                    addRecord.branchId = branchId;
                    addRecord.addTransaction = true;
                    addRecord.ShowDialog();
                }
                

            }
            catch (SqlException err)
            {
                MessageBox.Show(err.Message, "Billing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdBranch_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                branchId = Convert.ToInt64(grdBranch.SelectedRows[0].Cells["id"].Value.ToString());
                clsBilling b = new clsBilling();
                b.BranchId = branchId;
                clsBillingDV dv = new clsBillingDV();
                grdList.DataSource = dv.GetAllBillingsBranch(b);
            }
            catch (SqlException err)
            {
                MessageBox.Show(err.Message, "Billing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (branchId == 0)
                {
                    MessageBox.Show("Please select a branch.");
                }
                else
                {
                    billingId = Convert.ToInt64(grdList.SelectedRows[0].Cells["billingId"].Value.ToString());

                    frmAddRecord frm = new frmAddRecord();
                    frm.billingId = billingId;
                    frm.addTransaction = false;
                    frm.ShowDialog();
                }
                


            }
            catch (SqlException err)
            {
                MessageBox.Show(err.Message, "Billing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void grdList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (branchId == 0)
                {
                    MessageBox.Show("Please select a branch.");
                }
                else
                {
                    billingId = Convert.ToInt64(grdList.SelectedRows[0].Cells["billingId"].Value.ToString());

                    frmAddRecord frm = new frmAddRecord();
                    frm.billingId = billingId;
                    frm.addTransaction = false;
                    frm.ShowDialog();
                }



            }
            catch (SqlException err)
            {
                MessageBox.Show(err.Message, "Billing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                branchId = Convert.ToInt64(grdBranch.SelectedRows[0].Cells["id"].Value.ToString());
                clsBilling b = new clsBilling();
                b.BranchId = branchId;
                clsBillingDV dv = new clsBillingDV();
                grdList.DataSource = dv.GetAllBillingsBranch(b);



            }
            catch (SqlException err)
            {
                MessageBox.Show(err.Message, "Billing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            frmPrintBilling frm = new frmPrintBilling();
            frm.billingId = Convert.ToInt64(grdList.SelectedRows[0].Cells["billingId"].Value.ToString());
            frm.ShowDialog();
        }
    }
}
