using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class ProductionRecipieLines
    {
        public int ItemID { get; set; }

        public string ItemName { get; set; }
        public decimal Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal Total { get; set; }
        public int SrNo { get; set; }
        public bool IsDeleted { get; set; }
        public decimal CsQty { get; set; }


    }
}
