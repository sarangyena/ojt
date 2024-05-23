using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VJOMS
{
    public class clsDetailsM
    {
        private SqlConnection con;
        public clsDetailsM()
        {
            string strCon = @"Data Source=sgcserver, 16900; Initial Catalog=VJOR; User ID = redbaron; Password = m@gi3";
            con = new SqlConnection(strCon);
        }
        public void addDetails(clsDetails d)
        {
            string s = "INSERT INTO JODetails (JONo, PlateNo, BreakDownName, BreakDownDetails, EstimatedAmount, EstimatedTotal," +
                "Accomplishment)VALUES(@jono, @plate, @name, @details, @amount, @total, @accom)";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@jono", d.JONo);
            cmd.Parameters.AddWithValue("@plate", d.plate);
            cmd.Parameters.AddWithValue("@name", d.name);
            cmd.Parameters.AddWithValue("@details", d.details);
            cmd.Parameters.AddWithValue("@amount", d.amount);
            cmd.Parameters.AddWithValue("@total", d.total);
            cmd.Parameters.AddWithValue("@accom", d.accomplishment);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void addPrev(clsDetails d)
        {
            string s = "INSERT INTO tblVPrevAmount (JONo, JOPlate, JODetails, JOEstiAmount, JOTotalEstiAmount)" + 
                "VALUES(@jono, @plate, @details, @amount, @total)";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@jono", d.JONo);
            cmd.Parameters.AddWithValue("@plate", d.plate);
            cmd.Parameters.AddWithValue("@details", d.details);
            cmd.Parameters.AddWithValue("@amount", d.amount);
            cmd.Parameters.AddWithValue("@total", d.total);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public void addJO(clsDetails d)
        {
            DateTime currentDate = DateTime.Today;
            string formattedDate = currentDate.ToString("M/d/yyyy");
            string s = "INSERT INTO JOLIST (JONO, JODATE, JOPLATE, JOMODEL, JOYEAR, JOCOMPANY, JOBRAND, JOUSER," + 
                "JOTOTALESTI, JOSUBTOTAL, LESSDISCOUNT, MAXID)" +
                "VALUES(@jono, @date, @plate, @model, @year, @company, @brand, @user, @total, @sub," +
                "@less, @max)";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@jono", d.JONo);
            cmd.Parameters.AddWithValue("@date", formattedDate);
            cmd.Parameters.AddWithValue("@plate", d.plate);
            cmd.Parameters.AddWithValue("@model", d.model);
            cmd.Parameters.AddWithValue("@year", d.year);
            cmd.Parameters.AddWithValue("@company", d.company);
            cmd.Parameters.AddWithValue("@brand", d.brand);
            cmd.Parameters.AddWithValue("@user", d.user);
            cmd.Parameters.AddWithValue("@total", d.total);
            cmd.Parameters.AddWithValue("@sub", d.sub);
            cmd.Parameters.AddWithValue("@less", d.less);
            cmd.Parameters.AddWithValue("@max", d.max);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }



    }
}
