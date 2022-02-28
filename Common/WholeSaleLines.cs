using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class WholeSaleLines
    {
        public int ItemID { get; set; }
        public string Barcode { get; set; }
        public string ItemName { get; set; }
        public decimal CsQty { get; set; }
        public decimal Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal DiscPer { get; set; }
        public decimal DiscAmt { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsDeleted { get; set; }
        public Int64 SrNo { get; set; }

    }
}
