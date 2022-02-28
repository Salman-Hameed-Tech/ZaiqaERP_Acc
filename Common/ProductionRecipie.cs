using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class ProductionRecipie
    {
        public int ID { get; set; }
        public DateTime Dated { get; set; }
        public int MItemID { get; set; }
        public string MItemName { get; set; }
        public Decimal MQuantity { get; set; }
        
        public int BranchID { get; set; }
        public decimal TotalAmt { get; set; }


        public List<ProductionRecipieLines> productionRecipieLines = new List<ProductionRecipieLines>();
    }
}
