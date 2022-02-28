using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class WholeSale
    {
        public int ID { get; set; }
        public DateTime Dated { get; set; }
        public string BuyerID { get; set; }
        public int BranchID { get; set; }
        public string BuyerName { get; set; }
        public string BranchName { get; set; }
        public decimal InvoiceDiscountPer { get; set; }
        public decimal InvoiceDiscount { get; set; }
    
        public decimal NetTotal { get; set; }
      
        public int UserNo { get; set; }
    
        public string UserName { get; set; }
        public string Remarks { get; set; }
        public string PaymentMode { get; set; }


        public List<WholeSaleLines> wholeSaleLines = new List<WholeSaleLines>();
    }
}
