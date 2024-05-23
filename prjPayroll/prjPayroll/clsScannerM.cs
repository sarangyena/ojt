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
    public class clsScannerM
    {
        private SqlConnection con;
        public clsScannerM()
        {
            string strCon = "Data Source = EDRIAN; Initial Catalog = prjPayroll; User ID = sa; Password = 1234";
            con = new SqlConnection(strCon);
        }
        public void GetDetails(clsScanner sc)
        { 
            string s = "SELECT firstName, middleName, lastName, userType FROM tblUserDetails WHERE userUnique = @id";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@id", sc.userId);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                sc.userType = rdr["userType"].ToString();
                string first = rdr["firstName"].ToString();
                string middle = rdr["middleName"].ToString();
                string last = rdr["lastName"].ToString();
                middle = middle.Substring(0, 1);
                sc.name = last + ", " + first + " " + middle + ".";
                sc.dateIn = DateTime.Now;
                sc.timeIn = DateTime.Now.ToString("h:mm:ss tt");
            }
            rdr.Close();
            con.Close();
        }
        public string TimeOut(clsScanner sc)
        {
            string s = "UPDATE tblScanner SET isTimeIn = 0 WHERE userId = @id AND dateIn = (SELECT TOP 1 dateIn FROM tblScanner " +
                       "WHERE userId = @id ORDER BY dateIn DESC, timeIn DESC) AND timeIn = (SELECT TOP 1 timeIn FROM tblScanner " +
                       "WHERE userId = @id AND dateIn = (SELECT TOP 1 dateIn FROM tblScanner WHERE userId = @id ORDER BY dateIn DESC, " +
                       "timeIn DESC) ORDER BY timeIn DESC)";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@id", sc.userId);
            con.Open();
            if(cmd.ExecuteNonQuery() == 1){
                con.Close();
                return "true";
            }
            else
            {
                return "false1";
            }

        }
        public bool userAttendance(clsScanner sc)
        {
            string s = "SELECT TOP 1 isTimeIn FROM tblScanner WHERE userId = @id AND isTimeIn = 1 ORDER BY dateIn DESC, timeIn DESC";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@id", sc.userId);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                if (rdr["isTimeIn"].ToString() == "1")
                {
                    rdr.Close();
                    string b = "UPDATE tblScanner SET isTimeIn = 0 WHERE userId = @id AND dateIn = (SELECT TOP 1 dateIn FROM tblScanner " +
                       "WHERE userId = @id ORDER BY dateIn DESC, timeIn DESC) AND timeIn = (SELECT TOP 1 timeIn FROM tblScanner " +
                       "WHERE userId = @id AND dateIn = (SELECT TOP 1 dateIn FROM tblScanner WHERE userId = @id ORDER BY dateIn DESC, " +
                       "timeIn DESC) ORDER BY timeIn DESC)";
                    SqlCommand cmd2 = new SqlCommand(b, con);
                    cmd2.Parameters.AddWithValue("@id", sc.userId);
                    if (cmd2.ExecuteNonQuery() == 1)
                    {
                        con.Close();
                        return true;
                    }
                    else
                    {
                        con.Close();
                        return false;
                    }
                }
                else
                {
                    con.Close();
                    return false;
                }
            }
            else
            {
                rdr.Close();
                try
                {
                    SqlCommand cmd1 = new SqlCommand("InsertRecord", con);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.AddWithValue("@id", sc.userId);
                    cmd1.Parameters.AddWithValue("@type", sc.userType);
                    cmd1.Parameters.AddWithValue("@name", sc.name);
                    cmd1.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (SqlException ex)
                {
                    return false;
                }

            }
            /*string s = "SELECT COUNT (ISNULL(userId, 0)) FROM tblScanner WHERE userId = @id";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@id", sc.userId);
            con.Open();
            if(Convert.ToInt64(cmd.ExecuteScalar()) >= 1)
            {
                string a = "SELECT TOP 1 isTimeIn FROM tblScanner WHERE userId = @id ORDER BY timeIn DESC";
                SqlCommand cmd1 = new SqlCommand(a, con);
                cmd1.Parameters.AddWithValue("@id", sc.userId);
                SqlDataReader r = cmd1.ExecuteReader();
                if (r.Read())
                {
                    if (r["isTimeIn"].ToString() == "1")
                    {
                        string b = "UPDATE tblScanner SET dateOut = @date, timeOut = @time, isTimeIn = 0 WHERE timeIn IN (SELECT TOP 1 " +
                            "timeIn FROM tblScanner WHERE userId = @id ORDER BY timeIn DESC)";
                        SqlCommand cmd2 = new SqlCommand(b, con);
                        cmd2.Parameters.AddWithValue("@date", DateTime.Now);
                        cmd2.Parameters.AddWithValue("@time", DateTime.Now.ToString("h:mm:ss tt"));
                        cmd2.Parameters.AddWithValue("@id", sc.userId);
                        if (cmd2.ExecuteNonQuery() == 1)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        string c = "INSERT INTO tblScanner (userId, userType, name, dateIn, timeIn, isTimeIn) VALUES (@id, @type, @name, @date, @time, @check)";
                        SqlCommand cmd2 = new SqlCommand(c, con);
                        cmd2.Parameters.AddWithValue("@id", sc.userId);
                        cmd2.Parameters.AddWithValue("@type", sc.userType);
                        cmd2.Parameters.AddWithValue("@name", sc.name);
                        cmd2.Parameters.AddWithValue("@date", DateTime.Now);
                        cmd2.Parameters.AddWithValue("@time", DateTime.Now.ToString("h:mm:ss tt"));
                        cmd2.Parameters.AddWithValue("@check", 1);
                        if (cmd2.ExecuteNonQuery() == 0)
                        {
                            r.Close();
                            con.Close();
                            return false;
                        }
                        else
                        {
                            r.Close();
                            con.Close();
                            return true;
                        }
                    }
                }
                else
                {
                    return false;
                }

            }
            else
            {
                string d = "INSERT INTO tblScanner (userId, userType, name, dateIn, timeIn, isTimeIn) VALUES (@id, @type, @name, @date, @time, @check)";
                SqlCommand cmd2 = new SqlCommand(d, con);
                cmd2.Parameters.AddWithValue("@id", sc.userId);
                cmd2.Parameters.AddWithValue("@type", sc.userType);
                cmd2.Parameters.AddWithValue("@name", sc.name);
                cmd2.Parameters.AddWithValue("@date", DateTime.Now);
                cmd2.Parameters.AddWithValue("@time", DateTime.Now.ToString("h:mm:ss tt"));
                cmd2.Parameters.AddWithValue("@check", 1);
                if (cmd2.ExecuteNonQuery() == 0)
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
            /*if (Convert.ToInt64(cmd.ExecuteScalar()) > 1)
            {
                string a = "UPDATE tblScanner SET dateOut = @date, timeOut = @time WHERE userId = @id";
                SqlCommand cmd1 = new SqlCommand(a, con);
                cmd1.Parameters.AddWithValue("@date", DateTime.Now);
                cmd1.Parameters.AddWithValue("@time", DateTime.Now.ToString("h:mm:ss tt"));
                cmd1.Parameters.AddWithValue("@id", sc.userId);
                if (cmd1.ExecuteNonQuery() == 0)
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
            else if (Convert.ToInt64(cmd.ExecuteScalar()) == 0)
            {
                string b = "INSERT INTO tblScanner (userId, userType, name, dateIn, timeIn) VALUES (@id, @type, @name, @date, @time)";
                SqlCommand cmd2 = new SqlCommand(b, con);
                cmd2.Parameters.AddWithValue("@id", sc.userId);
                cmd2.Parameters.AddWithValue("@type", sc.userType);
                cmd2.Parameters.AddWithValue("@name", sc.name);
                cmd2.Parameters.AddWithValue("@date", DateTime.Now);
                cmd2.Parameters.AddWithValue("@time", DateTime.Now.ToString("h:mm:ss tt"));
                if (cmd2.ExecuteNonQuery() == 0)
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
            else
            {
                return false;
            }*/
        }
        public DataTable GetAttendance()
        {
            string s = "SELECT * FROM tblScanner";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataAdapter ada = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            con.Open();
            ada.Fill(ds, "Attendance");
            con.Close();
            DataTable dt = ds.Tables["Attendance"];
            return dt;
        }
    }
}
