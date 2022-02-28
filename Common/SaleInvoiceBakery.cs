using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class SaleInvoiceBakery
    {
        public int ID { get; set; }
        public DateTime Dated { get; set; }
        public int BranchID { get; set; }
        public string PartyID { get; set; }
        public decimal DiscPer { get; set; }
        public decimal DiscAmt { get; set; }
        public decimal TotalAmt { get; set; }
        public decimal AmtPaid { get; set; }
        public string Bank { get; set; }
        public string PaymentMode { get; set; }
        public string CardNo { get; set; }
        public decimal ReturnAmt { get; set; }
        public string Remarks { get; set; }
        public int UserNo { get; set; }

        public List<SaleInvoiceBakeryLine> bakeryLines = new List<SaleInvoiceBakeryLine>();
    }
}
