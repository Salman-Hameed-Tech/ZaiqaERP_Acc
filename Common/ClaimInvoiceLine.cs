using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class ClaimInvoiceLine
    {
        public Item Item { get; set; }
        public decimal Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal PurPrice { get; set; }
        public Int32 SrNo { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsLoose { get; set; }
        public int InvID { get; set; }
        public decimal PurQty { get; set; }
        public Store Store { get; set; }
        public decimal Csqty { get; set; }
        public decimal SaleQty { get; set; }

        public ClaimInvoiceLine()
        {

        }

        public ClaimInvoiceLine(Item item, decimal quantity, decimal rate, Int32 srno, bool isDeleted,int invID,decimal purPrice)
        {
            this.Item = item;
            this.Quantity = quantity;
            this.Rate = rate;
         
            this.SrNo = srno;
            this.IsDeleted = isDeleted;
      
            this.InvID = invID;
            this.PurPrice = purPrice;
        }

    }
}
