using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjPayroll
{
    public class clsScanner
    {
        public string userId { get; set; }
        public string userType { get; set; }
        public string name { get; set; }
        public DateTime dateIn { get; set; }
        public string timeIn { get; set; }
        public DateTime dateOut { get; set; }
        public DateTime timeOut { get; set; }

        public clsScanner()
        {

        }
    }
}
