using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace prjBilling
{
    public class clsBranchDV
    {
        private SqlConnection con;

        public clsBranchDV()
        {
            string strCon = "Data Source=sgcserver, 16900; Initial Catalog=dbSGC; User ID = redbaron; Password=m@gi3";
            con = new SqlConnection(strCon);
        }
        public DataTable GetBranch()
        {
            string s = "SELECT id, companyname FROM tbllocation ORDER BY companyname";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataAdapter ada = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            con.Open();
            ada.Fill(ds, "Billing");
            con.Close();
            DataTable dt = ds.Tables["Billing"];
            return dt;
        }
    }
}
