using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjBilling
{
    public class clsBilling
    {
        public Int64 BillingId { get; set; }
        public Int64 CustomerId { get; set; }
        public Int64 BranchId { get; set; }
        public Int64 BillingNumber { get; set; }
        public string BillingNumChar { get; set; }
        public string BillingRefNum { get; set; }
        public string BilledTo { get; set; }
        public string TIN { get; set; }
        public DateTime BillingDate { get; set; }
        public string Terms { get; set; }
        public string BusinessStyle { get; set; }
        public string EncodedBy { get; set; }
        public DateTime DateEncoded { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime DateModified { get; set; }
        public string Remarks { get; set; }







        public clsBilling()
        {

        }
    }
}
