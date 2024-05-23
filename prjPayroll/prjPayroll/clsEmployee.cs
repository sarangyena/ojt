using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjPayroll
{
    public class clsEmployee
    {
        public Int64 userId { get; set; }
        public string userType { get; set; }
        public string uniqueId { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string status { get; set; }
        public string email { get; set; }
        public Int64 phone { get; set; }
        public string position { get; set; }
        public string sss { get; set; }
        public string philHealth { get; set; }
        public string pagIbig { get; set; }
        public Int64 rate { get; set; }
        public string address { get; set; }
        public string eName { get; set; }
        public string ePhone { get; set; }
        public string eAddress { get; set; }
        public byte[] imageBytes { get; set; }

        public clsEmployee()
        {

        }

    }
}
