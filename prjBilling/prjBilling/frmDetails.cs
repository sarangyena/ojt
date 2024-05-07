using System;
using System.Configuration;
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
    public partial class frmDetails : Form
    {
        private SqlConnection con;
        public bool addDetails { get; set; }
        public Int64 billingId { get; set; }
        public Int64 detailsId { get; set; }
        
        public frmDetails()
        {
            InitializeComponent();
            string strCon = "Data Source=sgcserver, 16900; Initial Catalog=dbSGC; User ID = redbaron; Password=m@gi3";
            con = new SqlConnection(strCon);

        }
        private void GetDetailsById()
        {
            try
            {
                clsDetails d = new clsDetails();
                d.detailsId = detailsId;
                clsDetailsDV dv = new clsDetailsDV();
                dv.GetDetailsById(d);
                txtAmount.Text = d.amount.ToString();
                txtParticulars.Text = d.particulars.ToString();
                txtQuantity.Text = d.quantity.ToString();
            }
            catch (SqlException err)
            {
                MessageBox.Show(err.Message, "Billing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            if(addDetails == true)
            {
                clsDetails de = new clsDetails();
                de.particulars = txtParticulars.Text;
                de.quantity = Convert.ToInt64(txtQuantity.Text);
                de.amount = Convert.ToInt64(txtAmount.Text);
                de.billingId = billingId;
                clsDetailsDV dv = new clsDetailsDV();
                if (dv.AddDetails(de) == true)
                {
                    MessageBox.Show("Successfully added.", "Add Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (MessageBox.Show("Insert another particular?", "Add Another", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        txtParticulars.Clear();
                        txtQuantity.Clear();
                        txtAmount.Clear();
                    }
                    else
                    {
                        this.Hide();
                    }
                }
            }
            else
            {
                clsDetails de = new clsDetails();
                de.detailsId = detailsId;
                de.particulars = txtParticulars.Text;
                de.quantity = Convert.ToInt64(txtQuantity.Text);
                de.amount = Convert.ToInt64(txtAmount.Text);
                de.billingId = billingId;
                clsDetailsDV dv = new clsDetailsDV();
                if (dv.UpdateRecord(de) == true)
                {
                    MessageBox.Show("Successfully edited.", "Edit Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Error.", "Edit Details", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private void frmDetails_Load(object sender, EventArgs e)
        {
            if(addDetails == false)
            {
                GetDetailsById();
            }
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
