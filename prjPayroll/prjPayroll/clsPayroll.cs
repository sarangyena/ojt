using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjPayroll
{
    public class clsPayroll
    {
        public string userId { get; set; }
        public string week { get; set; }
        public string name { get; set; }
        public string position { get; set; }
        public float rate { get; set; }
        public float days { get; set; }
        public float late { get; set; }
        public float salary { get; set; }
        public float ratePerHour { get; set; }
        public float hours { get; set; }
        public float otPay { get; set; }
        public float holiday { get; set; }
        public float philhealth { get; set; }
        public float sss { get; set; }
        public float advance { get; set; }
        public float total { get; set; }
    }
}
