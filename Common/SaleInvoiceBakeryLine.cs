using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class SaleInvoiceBakeryLine
    {
        public int ItemID { get; set; }
        public int ItemName { get; set; }
        public decimal Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal DiscPer { get; set; }
        public decimal DiscAmt { get; set; }
        public decimal Total { get; set; }
        public Int32 SrNo { get; set; }
        public bool IsDeleted { get; set; }
        public string Barcode { get; set; }
    }
}
