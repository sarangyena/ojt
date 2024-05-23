using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace prjPayroll
{
    public partial class frmEmployee : Form
    {
        private bool check;
        public frmEmployee()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            foreach (Control c in splitPanel1.Controls)
            {
                if (c is TextBox)
                {
                    TextBox txtbox = c as TextBox;
                    if (txtbox.Text == string.Empty)
                    {

                        check = true;
                    }
                }
            }
            foreach (Control c in splitPanel2.Controls)
            {
                if (c is TextBox)
                {
                    TextBox txtbox = c as TextBox;
                    if (txtbox.Text == string.Empty)
                    {
                        check = true;
                    }
                }
            }
            foreach (Control c in splitPanel3.Controls)
            {
                if (c is TextBox)
                {
                    TextBox txtbox = c as TextBox;
                    if (txtbox.Text == string.Empty)
                    {
                        check = true;
                    }
                }
            }
            if (check == true)
            {
                MessageBox.Show("Please input data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                clsEmployee em = new clsEmployee();
                if(rdbEmp.Checked == true)
                {
                    em.userType = rdbEmp.Text;
                }
                else
                {
                    em.userType = rdbOn.Text;
                }
                em.uniqueId = txtID.Text;
                em.lastName = txtLast.Text;
                em.firstName = txtFirst.Text;
                em.middleName = txtMiddle.Text;
                em.pagIbig = txtIbig.Text;
                em.eName = txtEName.Text;
                em.email = txtEmail.Text;
                em.address = txtAddress.Text;
                em.eAddress = txtEAdd.Text;
                em.ePhone = txtEPhone.Text;
                em.philHealth = txtPhil.Text;
                em.phone = Convert.ToInt64(txtPhone.Text);
                em.rate = Convert.ToInt64(txtRate.Text);
                em.sss = txtSSS.Text;
                em.status = cbxStatus.SelectedItem.ToString();
                em.position = cbxPosition.SelectedItem.ToString();
                MemoryStream ms = new MemoryStream();
                pbPhoto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg); // or any other image format
                em.imageBytes = ms.ToArray();
                clsEmployeeM m = new clsEmployeeM();
                if (m.AddEmployee(em) == true)
                {
                    MessageBox.Show("Successfully Added.", "Add Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtID.Clear();
                    txtLast.Clear();
                    txtFirst.Clear();
                    txtMiddle.Clear();
                    txtIbig.Clear();
                    txtEName.Clear();
                    txtEmail.Clear();
                    txtAddress.Clear();
                    txtEAdd.Clear();
                    txtEPhone.Clear();
                    txtPhil.Clear();
                    txtPhone.Clear();
                    txtRate.Clear();
                    txtSSS.Clear();
                    cbxPosition.ResetText();
                    cbxStatus.ResetText();
                    clsEmployeeM x = new clsEmployeeM();
                    grdDetails.DataSource = x.GetDetails().AsDataView();
                }
                else
                {
                    MessageBox.Show("Error. Try Again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtID.Clear();
            txtLast.Clear();
            txtFirst.Clear();
            txtMiddle.Clear();
            txtIbig.Clear();
            txtEName.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            txtEAdd.Clear();
            txtEPhone.Clear();
            txtPhil.Clear();
            txtPhone.Clear();
            txtRate.Clear();
            txtSSS.Clear();
            cbxStatus.Items.Clear();
            cbxPosition.Items.Clear();
        }

        private void radButton4_Click(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            frm.Show();
            this.Hide();
        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            LoadDetails();
        }
        private void LoadDetails()
        {
            try
            {
                clsEmployeeM m = new clsEmployeeM();
                grdDetails.DataSource = m.GetDetails().AsDataView();
            }
            catch(SqlException err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void radButton3_Click(object sender, EventArgs e)
        {
            frmPayroll frm = new frmPayroll();
            frm.Show();
            this.Hide();
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Currently in Employee Tab.", "Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            frmDash frm = new frmDash();
            frm.Show();
            this.Hide();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                pbPhoto.Image = new Bitmap(opnfd.FileName);
            }

        }

        private void radButton1_Click_1(object sender, EventArgs e)
        {
            clsEmployeeM m = new clsEmployeeM();
            string temp = m.GetUniqueId().ToString();
            MessageBox.Show(temp);
        }

        private void rdbEmp_CheckedChanged(object sender, EventArgs e)
        {
            clsEmployeeM m = new clsEmployeeM();
            m.role = rdbEmp.Text;
            txtID.Text = m.GetUniqueId();
        }

        private void rdbOn_CheckedChanged(object sender, EventArgs e)
        {
            clsEmployeeM m = new clsEmployeeM();
            m.role = rdbOn.Text;
            txtID.Text = m.GetUniqueId();
        }
    }
}
