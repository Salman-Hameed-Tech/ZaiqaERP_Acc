using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
   public  class StockShiftLine
    {
       public Item Item { get; set; }
       public decimal Quantity { get; set; }
       public bool IsLoose {get;set;}
       public Store FromStore { get; set; }
       public Store ToStore { get; set; }
       public decimal Rate { get; set; }
       public Int32 SrNo { get; set; }
       public bool IsDeleted { get; set; }
      
       public StockShiftLine()
       {
 
       }

       public StockShiftLine(Item item, decimal quantity,Boolean isLoose,Store fromStore,Store toStore,decimal rate, Int32 srNo, bool isDeleted)
       {
           this.Item = item;
           this.Quantity = quantity;
           this.IsLoose = isLoose;
           this.FromStore = fromStore;
           this.ToStore = toStore;
           this.Rate = rate;
           this.SrNo = srNo;
           this.IsDeleted = isDeleted;
           
       }      

    }
}
