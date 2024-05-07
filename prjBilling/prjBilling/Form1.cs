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
    public partial class Form1 : Form
    {
        SqlConnection con;
        string conString;
        Int32 vcount;
        private string username;

        public long UserId { get; private set; }

        public int Vcount
        {
            get
            {
                return vcount;
            }

            set
            {
                vcount = value;
            }
        }

        public Form1()
        {
            // To connect to Database
            InitializeComponent();
            conString = "Data Source=sgcserver, 16900;Initial Catalog=usersdb;User Id=redbaron;Password=m@gi3";
            con = new SqlConnection(conString);
        }



        private void btnok_Click_1(object sender, EventArgs e)
        {
            // To check the username and password if its correct.
            string s = "SELECT user_table.userid, user_table.username, user_table.usertypeid " +
               "FROM user_table INNER JOIN user_type ON user_table.usertypeid = user_type.usertypeid " +
               "WHERE(user_table.username = @username) AND(user_table.userpassword = @password) ";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@username", textuser.Text);
            cmd.Parameters.AddWithValue("@password", textpassword.Text);
            con.Open();

            // Sends the CommandText to the Connection and builds a SqlDataReader.
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                BillingLogin frm2 = new BillingLogin();
                frm2.username = rdr["username"].ToString();
                frm2.UserId = Convert.ToInt64(rdr["userid"].ToString());
                frm2.Usertypeid = Convert.ToInt64(rdr["usertypeid"].ToString());
                Menu frm = new Menu();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
            else
            {
                MessageBox.Show("You do not have access.", "My App", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textuser.Clear();
                textpassword.Clear();
                textuser.Focus();
                con.Close();
            }
            con.Close();
        

    }

        // To closed the form or windows that contains the button.  
        private void btnclose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnlogoff_Click_1(object sender, EventArgs e)
        {
            textuser.Clear();
            textpassword.Clear();
            textuser.Enabled = true;
            textpassword.Enabled = true;
            textuser.Focus();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                string s = "SELECT user_table.userid, user_table.username, user_table.usertypeid " +
               "FROM user_table INNER JOIN user_type ON user_table.usertypeid = user_type.usertypeid " +
               "WHERE(user_table.username = @username) AND(user_table.userpassword = @password) ";
                SqlCommand cmd = new SqlCommand(s, con);
                cmd.Parameters.AddWithValue("@username", textuser.Text);
                cmd.Parameters.AddWithValue("@password", textpassword.Text);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    BillingLogin frm2 = new BillingLogin();
                    frm2.username = rdr["username"].ToString();
                    frm2.UserId = Convert.ToInt64(rdr["userid"].ToString());
                    frm2.Usertypeid = Convert.ToInt64(rdr["usertypeid"].ToString());
                    Menu frm = new Menu();
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.WindowState = FormWindowState.Maximized;
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("You do not have access.", "My App", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textuser.Clear();
                    textpassword.Clear();
                    textuser.Focus();
                    con.Close();
                }
                con.Close();
            }
        }
    }
}
