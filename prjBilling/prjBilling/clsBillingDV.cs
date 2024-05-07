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
    public class clsBillingDV
    {
        private SqlConnection con;
        private string numchar;
        private string lastid;
        public clsBillingDV()
        {
            string strCon = "Data Source=sgcserver, 16900; Initial Catalog=dbSGC; User ID = redbaron; Password=m@gi3";
            con = new SqlConnection(strCon);
            //con = new SqlConnection(ConfigurationManager.ConnectionStrings["clsBillingDV.Properties.Settings.BillingConnection"].ConnectionString);
        }
        public DataTable GetAllBillings()
        {
            string s = "SELECT BillingCustomer.BillingId, BillingCustomer.BillingNumChar, BillingCustomer.BillingNumber, " +
                "BillingCustomer.BillingRefNum, tblCustomer.customername, tblCustomer.customeraddress, BillingCustomer.BilledTo, " +
                "BillingCustomer.BillingDate FROM tblCustomer INNER JOIN BillingCustomer ON " +
                "tblCustomer.customerid = BillingCustomer.CustomerId";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataAdapter ada = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            con.Open();
            ada.Fill(ds, "Billing");
            con.Close();
            DataTable dt = ds.Tables["Billing"];
            return dt;
        }
        public DataTable GetAllBillingsBranch(clsBilling d)
        {
            string s = "SELECT BillingCustomer.BillingId, BillingCustomer.BillingNumChar, BillingCustomer.BillingNumber, " +
                "BillingCustomer.BillingRefNum, tblCustomer.customername, tblCustomer.customeraddress, BillingCustomer.BilledTo, " +
                "BillingCustomer.BillingDate FROM tblCustomer INNER JOIN BillingCustomer ON " +
                "tblCustomer.customerid = BillingCustomer.CustomerId WHERE BranchId = @branchid";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@branchid", d.BranchId);
            SqlDataAdapter ada = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            con.Open();
            ada.Fill(ds, "Billing");
            con.Close();
            DataTable dt = ds.Tables["Billing"];
            return dt;
        }
        public DataTable GetDatabase()
        {
            string s = "SELECT * FROM BillingCustomer ORDER BY BillingId";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataAdapter ada = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            con.Open();
            ada.Fill(ds, "Billing");
            con.Close();
            DataTable dt = ds.Tables["Billing"];
            return dt;
        }

        private Int64 GetBillNumber(Int64 BranchId)
        {
            string s = "SELECT ISNULL(BillNumber,0) + 1 FROM tblSystemNumber WHERE BranchId = @branchid";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@branchid", BranchId);
            con.Open();
            Int64 bnum = Convert.ToInt64(cmd.ExecuteScalar());
            con.Close();
            return bnum;

        }
        private void UpdateBillNumber(Int64 BranchId, Int64 BilledNumber)
        {
            string s = "UPDATE tblSystemNumber SET BillNumber = @billnumber WHERE BranchId = @branchid";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@billnumber", BilledNumber);
            cmd.Parameters.AddWithValue("@branchid", BranchId);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public string GetBillNumChar()
        {
            return numchar;
        }

        public void AddRecord (clsBilling b)
        {
            Int64 billno = GetBillNumber(b.BranchId);
            string sbillno = Convert.ToString(billno);
            switch (sbillno.Length)
            {
                case 4:
                    numchar = "B-" + billno;
                    break;
                case 3:
                    numchar = "B-0" + billno;
                    break;
                case 2:
                    numchar = "B-00" + billno;
                    break;
                case 1:
                    numchar = "B-000" + billno;
                    break;
                default:
                    numchar = "B-" + billno;
                    break;

            }
            string s = "INSERT INTO BillingCustomer (CustomerId, BranchId, BillingNumber, BillingNumChar, BillingRefNum, BilledTo, TIN, BillingDate, Terms, BusinessStyle) VALUES (@customerid, @branchid, @billingnumber, @billingnumchar, @billingref, @billedto, @tin, @billingdate, @terms, @style); " +
                "SELECT SCOPE_IDENTITY();";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@customerid",b.CustomerId);
            cmd.Parameters.AddWithValue("@branchid", b.BranchId);
            cmd.Parameters.AddWithValue("@billingnumber", billno);
            cmd.Parameters.AddWithValue("@billingnumchar", numchar);
            cmd.Parameters.AddWithValue("@billingref", b.BillingRefNum);
            cmd.Parameters.AddWithValue("@billedto", b.BilledTo);
            cmd.Parameters.AddWithValue("@tin", b.TIN);
            cmd.Parameters.AddWithValue("@billingdate", b.BillingDate);
            cmd.Parameters.AddWithValue("@terms", b.Terms);
            cmd.Parameters.AddWithValue("@style", b.BusinessStyle);

            con.Open();
            b.BillingId = Convert.ToInt64(cmd.ExecuteScalar());
            con.Close();
            UpdateBillNumber(b.BranchId, billno);
            GetBillNumChar();

        }
        public void GetBillingById(clsBilling b)
        {
            string s = "SELECT * FROM BillingCustomer WHERE BillingId = @billingid";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@billingid", b.BillingId);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                b.BillingId = Convert.ToInt64(rdr["BillingId"].ToString());
                b.BilledTo = rdr["BilledTo"].ToString();
                b.CustomerId = Convert.ToInt64(rdr["CustomerId"].ToString());
                b.BranchId = Convert.ToInt64(rdr["BranchId"].ToString());
                b.TIN = rdr["TIN"].ToString();
                b.BillingDate = Convert.ToDateTime(rdr["BillingDate"].ToString());
                b.Terms = rdr["Terms"].ToString();
                b.BusinessStyle = rdr["BusinessStyle"].ToString();  
            }
            con.Close();
        }

        public void UpdateRecord(clsBilling b)
        {
            string s = "UPDATE [dbo].[BillingCustomer] SET[CustomerId] = @CustomerId, [BilledTo] = @BilledTo, [TIN] = @TIN, " +
                        "[BillingDate] = @BillingDate, [Terms] = @Terms, [BusinessStyle] = @BusinessStyle WHERE BillingId = @BillingId";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@customerid", b.CustomerId);
            cmd.Parameters.AddWithValue("@billedto", b.BilledTo);
            cmd.Parameters.AddWithValue("@tin", b.TIN);
            cmd.Parameters.AddWithValue("@billingdate", b.BillingDate);
            cmd.Parameters.AddWithValue("@terms", b.Terms);
            cmd.Parameters.AddWithValue("@businessstyle", b.BusinessStyle);
            cmd.Parameters.AddWithValue("@billingid", b.BillingId);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }


    }
}
