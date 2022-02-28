using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class StockDifferenceSP
    {
        public int ItemID { get; set; }
        public string Barcode { get; set; }
        public string ItemName { get; set; }
        public int CsQty { get; set; }
        public int PhysicalQty { get; set; }
        public int BranchID { get; set; }

    }
}
