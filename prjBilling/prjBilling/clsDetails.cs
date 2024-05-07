using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjBilling
{
    public class clsDetails
    {
        public Int64 detailsId { get; set; }
        public Int64 billingId { get; set; }
        public string particulars { get; set; }
        public float quantity { get; set; }
        public float amount { get; set; }
        public float lineTotalAmount { get; set; }
        public string encodedBy { get; set; }
        public DateTime dateEncoded { get; set; }
        public string modifiedBy { get; set; }
        public DateTime dateModified { get; set; }

        public clsDetails()
        {

        }
    }
}
