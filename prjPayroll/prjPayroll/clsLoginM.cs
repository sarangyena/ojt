using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjPayroll
{
    public class clsLoginM
    {
        private SqlConnection con;
        public bool check { get; set; }
        public clsLoginM()
        {
            string strCon = "Data Source = EDRIAN; Initial Catalog = prjPayroll; User ID = sa; Password = 1234";
            con = new SqlConnection(strCon);
        }

        public bool GetUser(clsLogin l)
        {
            string s = "SELECT COUNT (ISNULL(userId,0)) FROM tblUsers WHERE userName = @user AND userPass = @pass AND userType = @type";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@user", l.userName);
            cmd.Parameters.AddWithValue("@pass", l.userPass);
            cmd.Parameters.AddWithValue("@type", l.userType);
            con.Open();
            if(Convert.ToInt64(cmd.ExecuteScalar()) == 1)
            {
                check = true;
            }
            else
            {
                check = false;
            }
            con.Close();
            return check;
        }
    }
}
