using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjBilling
{
    public class clsDetailsDV
    {
        private SqlConnection con;
        private bool temp;
        public clsDetailsDV()
        {
            string strCon = "Data Source=sgcserver, 16900; Initial Catalog=dbSGC; User ID = redbaron; Password=m@gi3";
            con = new SqlConnection(strCon);
        }

        public bool AddDetails(clsDetails d)
        {
            string s = "INSERT INTO tblBillingDetails (billingId, particulars, quantity, amount) VALUES (@billingid, @particulars, @qty, @amount)";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@billingid", d.billingId);
            cmd.Parameters.AddWithValue("@particulars", d.particulars);
            cmd.Parameters.AddWithValue("@qty", d.quantity);
            cmd.Parameters.AddWithValue("@amount", d.amount);
            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
                temp = true;

            }
            catch (SqlException err)
            {
                MessageBox.Show(err.Message, "Billing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                temp = false;

            }
            con.Close();
            return temp;
        }
        public DataTable GetDetails(Int64 e)
        {
            string s = "SELECT tblBillingDetails.detailsId, tblBillingDetails.billingId, tblBillingDetails.particulars, " + 
                "tblBillingDetails.quantity, tblBillingDetails.amount, tblBillingDetails.lineTotalAmount FROM BillingCustomer " + 
                "INNER JOIN tblBillingDetails ON BillingCustomer.BillingId = tblBillingDetails.billingId WHERE tblBillingDetails.billingId = @billingid";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@billingid", e);
            SqlDataAdapter ada = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            con.Open();
            ada.Fill(ds, "Details");
            con.Close();
            DataTable dt = ds.Tables["Details"];
            return dt;
        }
        public void GetDetailsById(clsDetails d)
        {
            string s = "SELECT particulars, quantity, amount FROM tblBillingDetails WHERE detailsId = @detailsId";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@detailsid", d.detailsId);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                d.particulars = rdr["particulars"].ToString();
                d.quantity = Convert.ToInt64(rdr["quantity"].ToString());
                d.amount = Convert.ToInt64(rdr["amount"].ToString());
            }
            con.Close();

        }
        public bool UpdateRecord(clsDetails d)
        {
            string s = "UPDATE tblBillingDetails SET particulars = @particulars, quantity = @qty, amount = @amount WHERE detailsId = @detailsid";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@particulars", d.particulars);
            cmd.Parameters.AddWithValue("@qty", d.quantity);
            cmd.Parameters.AddWithValue("@amount", d.amount);
            cmd.Parameters.AddWithValue("@detailsid", d.detailsId);
            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
                temp = true;
            }
            catch (SqlException err)
            {
                MessageBox.Show(err.Message, "Billing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                temp = false;
            }
            con.Close();
            return temp;
        }
    }
}
