using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
   public  class StockConvertLine
    {
       public Item Item { get; set; }
       public decimal Quantity { get; set; }
       public bool IsLoose {get;set;}
       public Store Store { get; set; }       
       public decimal Rate { get; set; }
       public Int32 SrNo { get; set; }
       public bool IsDeleted { get; set; }
      
       public StockConvertLine()
       {
 
       }

       public StockConvertLine(Item item, decimal quantity, Boolean isLoose, Store store, decimal rate, Int32 srNo, bool isDeleted)
       {
           this.Item = item;
           this.Quantity = quantity;
           this.IsLoose = isLoose;
           this.Store = store;           
           this.Rate = rate;
           this.SrNo = srNo;
           this.IsDeleted = isDeleted;
           
       }      

    }
}
