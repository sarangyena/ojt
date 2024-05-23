using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjPayroll
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            clsLogin l = new clsLogin();
            l.userName = txtUser.Text;
            l.userPass = txtPass.Text;
            if (rdbAdmin.IsChecked)
            {
                l.userType = rdbAdmin.Text;
                clsLoginM m = new clsLoginM();
                if (m.GetUser(l) == true)
                {
                    frmEmployee frm = new frmEmployee();
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Incorrect Username or Password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if(rdbEmp.IsChecked)
            {
                l.userType = rdbEmp.Text;
                clsLoginM m = new clsLoginM();
                if (m.GetUser(l) == true)
                {
                    frmEEmployee frm = new frmEEmployee();
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Incorrect Username or Password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if(rdbQR.IsChecked)
            {
                l.userType = rdbQR.Text;
                clsLoginM m = new clsLoginM();
                if (m.GetUser(l) == true)
                {
                    frmScanner frm = new frmScanner();
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Incorrect Username or Password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            txtPass.Clear();
            txtUser.Clear();
        }

        private void btnScanner_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmScanner frm = new frmScanner();
            frm.Show();
        }
    }
}
