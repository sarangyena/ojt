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
    public class clsPayrollM
    {
        private SqlConnection con;
        public Int64 holiday { get; set; }
        public Int64 philhealth { get; set; }
        public Int64 sss { get; set; }
        public Int64 advance { get; set; }
        public Int64 total { get; set; }
        public clsPayrollM()
        {
            string strCon = "Data Source = EDRIAN; Initial Catalog = prjPayroll; User ID = sa; Password = 1234";
            con = new SqlConnection(strCon);
        }
        public DataTable GetPayroll()
        {
            string s = "SELECT * FROM tblPayroll";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataAdapter ada = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            con.Open();
            ada.Fill(ds, "Payroll");
            con.Close();
            DataTable dt = ds.Tables["Payroll"];
            return dt;
        } 
        public string GetWeek()
        {
            DateTime currentDate = DateTime.Today;

            // Get the start of the week (Monday)
            DateTime startOfWeek = currentDate.AddDays(
                -(int)currentDate.DayOfWeek + (int)DayOfWeek.Monday
            );

            // Get the end of the week (Friday)
            DateTime endOfWeek = startOfWeek.AddDays(4);

            string week = startOfWeek.ToString("yyyy-MM-dd") + " to " + endOfWeek.ToString("yyyy-MM-dd");

            return week;
        }
        public void GetName(clsPayroll p)
        {
            string s = "SELECT CONCAT (lastName, ', ', firstName, ' ', SUBSTRING(middleName,1,1), '.') AS Name FROM tblUserDetails WHERE userUnique = @id";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@id", p.userId);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
               p.name = rdr["Name"].ToString();
            }
            rdr.Close();
            con.Close();
        }

        public bool AddPayroll(clsPayroll p)
        {
            string s = "INSERT INTO tblPayroll (userId, week, name, position, rate) VALUES (@id, @week, @name, @job, @rate)";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@id", p.userId);
            cmd.Parameters.AddWithValue("@week", p.week);
            cmd.Parameters.AddWithValue("@name", p.name);
            cmd.Parameters.AddWithValue("@job", p.position);
            cmd.Parameters.AddWithValue("@rate", p.rate);
            con.Open();
            if(cmd.ExecuteNonQuery() == 0)
            {
                con.Close();
                return false;
            }
            else
            {
                con.Close();
                return true;
            }
        }

        public void UpdatePayroll()
        {
            string s = "INSERT INTO (holiday, philhealth, sss, advance, total) VALUES (@holiday, @phil, @sss, @advance, @total)";
            SqlCommand cmd = new SqlCommand(s, con);
        }
    }
}
