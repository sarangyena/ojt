using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjBilling
{
    public class clsCustomerDV
    {
        private SqlConnection con;

        public clsCustomerDV()
        {
            string strCon = "Data Source=sgcserver, 16900; Initial Catalog=dbSGC; User ID = redbaron; Password=m@gi3";
            con = new SqlConnection(strCon);
            //con = new SqlConnection(ConfigurationManager.ConnectionStrings["clsBillingDV.Properties.Settings.BillingConnection"].ConnectionString);
        }
        public DataTable GetCustomerID()
        {
            string s = "SELECT customerid, customername FROM tblCustomer WHERE customername != '' ORDER BY customername";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataAdapter ada = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            con.Open();
            ada.Fill(ds, "Billing");
            con.Close();
            DataTable dt = ds.Tables["Billing"];
            return dt;

        }
        public void GetCustomerAddress(clsCustomer t)
        {
            string s = "SELECT customeraddress FROM tblCustomer WHERE customerid = @customerid";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@customerid", t.customerid);
            con.Open();
            SqlDataReader dtr = cmd.ExecuteReader();
            if (dtr.Read())
            {
                t.customeraddress = dtr["customeraddress"].ToString();
                if(t.customeraddress == "")
                {
                    t.customeraddress = "N/A";
                }
            }
            con.Close();
        }
    }
}
