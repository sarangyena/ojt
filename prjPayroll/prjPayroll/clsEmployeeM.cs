using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjPayroll
{
    public class clsEmployeeM
    {
        private SqlConnection con;
        public bool check { get; set; }
        public string role { get; set; }
        private string rows;

        public clsEmployeeM()
        {
            string strCon = "Data Source = EDRIAN; Initial Catalog = prjPayroll; User ID = sa; Password = 1234";
            con = new SqlConnection(strCon);
        }

        public string GetUniqueId()
        {
            if (role == "ON-CALL")
            {
                string s = "SELECT COUNT(*) FROM tblUserDetails WHERE userType = 'ON-CALL'";
                SqlCommand cmd = new SqlCommand(s, con);
                con.Open();
                rows = Convert.ToInt64(cmd.ExecuteScalar()).ToString();
                if(rows == "0")
                {
                    con.Close();
                    return "O-001";
                }
                else
                {
                    rows = (Convert.ToInt64(rows) + 1).ToString();
                    switch (rows.Length)
                    {
                        case 1:
                            con.Close();
                            return "O-00" + rows;
                        case 2:
                            con.Close();
                            return "O-0" + rows;
                        default:
                            con.Close();
                            return "O-" + rows;
                    }
                }
            }
            else if (role == "EMPLOYEE")
            {
                string s = "SELECT COUNT(*) FROM tblUserDetails WHERE userType = 'EMPLOYEE'";
                SqlCommand cmd = new SqlCommand(s, con);
                con.Open();
                rows = Convert.ToInt64(cmd.ExecuteScalar()).ToString();
                if (rows == "0")
                {
                    con.Close();
                    return "E-001";
                }
                else
                {
                    rows = (Convert.ToInt64(rows)+1).ToString();

                    switch (rows.Length)
                    {
                        case 1:
                            con.Close();
                            return "E-00" + rows;
                        case 2:
                            con.Close();
                            return "E-0" + rows;
                        default:
                            con.Close();
                            return "E-" + rows;
                    }
                }
            }
            else
            {
                string s = "SELECT COUNT(*) FROM tblUserDetails WHERE userType = 'ADMIN'";
                SqlCommand cmd = new SqlCommand(s, con);
                con.Open();
                rows = Convert.ToInt64(cmd.ExecuteScalar()).ToString();
                if (rows == "0")
                {
                    con.Close();
                    return "A-001";
                }
                else
                {
                    rows = (Convert.ToInt64(rows) + 1).ToString();
                    switch (rows.Length)
                    {
                        case 1:
                            con.Close();
                            return "A-00" + rows;
                        case 2:
                            con.Close();
                            return "A-0" + rows;
                        default:
                            con.Close();
                            return "A-" + rows;
                    }
                }
            }
        }

        public bool AddEmployee(clsEmployee e)
        {
            string s = "INSERT INTO [dbo].[tblUserDetails]([userType], [userUnique], [firstName], [middleName], [lastName], [status], [email], " +
                "[phone], [position], [sss], [philhealth], [pagIbig], [rate], [address], [eName], [ePhone], [eAddress], [image]) VALUES (@userType, " +
                "@userUnique, @firstName, @middleName, @lastName, @status, @email, @phone, @position, @sss, @philhealth, @pagIbig, @rate, @address, @eName, @ePhone, " +
                "@eAddress, @image)";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@userType", e.userType);
            cmd.Parameters.AddWithValue("@userUnique", e.uniqueId);
            cmd.Parameters.AddWithValue("@firstName", e.firstName);
            cmd.Parameters.AddWithValue("@middleName", e.middleName);
            cmd.Parameters.AddWithValue("@lastName", e.lastName);
            cmd.Parameters.AddWithValue("@status", e.status);
            cmd.Parameters.AddWithValue("@email", e.email);
            cmd.Parameters.AddWithValue("@phone", e.phone);
            cmd.Parameters.AddWithValue("@position", e.position);
            cmd.Parameters.AddWithValue("@sss", e.sss);
            cmd.Parameters.AddWithValue("@philhealth", e.philHealth);
            cmd.Parameters.AddWithValue("@pagIbig", e.pagIbig);
            cmd.Parameters.AddWithValue("@rate", e.rate);
            cmd.Parameters.AddWithValue("@address", e.address);
            cmd.Parameters.AddWithValue("@eName", e.eName);
            cmd.Parameters.AddWithValue("@ePhone", e.ePhone);
            cmd.Parameters.AddWithValue("@eAddress", e.eAddress);
            cmd.Parameters.AddWithValue("@image", e.imageBytes);
            con.Open();
            if(cmd.ExecuteNonQuery() == 0)
            {
                return false;
            }
            else
            {
                con.Close();
                clsPayroll p = new clsPayroll();
                p.userId = e.uniqueId;
                clsPayrollM m = new clsPayrollM();
                m.GetName(p);
                p.week = m.GetWeek();
                p.position = e.position;
                p.rate = e.rate;
                if(m.AddPayroll(p) == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }
        public DataTable GetDetails()
        {
            string s = "SELECT * FROM tblUserDetails";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataAdapter ada = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            con.Open();
            ada.Fill(ds, "Details");
            con.Close();
            DataTable dt = ds.Tables["Details"];
            return dt;
        }

    }
}
