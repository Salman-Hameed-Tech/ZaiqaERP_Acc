using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
   public  class StockConvert
    {
       public int ID { get; set; }
       public DateTime Dated {get;set;}          
       public string Remarks { get; set; }
       public int  CreatedBy { get; set; }

       public List<StockConvertLine> StockConvertLines { get; set; }

       public StockConvert()
       {
       }

       public StockConvert(int id, DateTime dated, string remarks, int createdBy)
       {
           this.ID = id;
           this.Dated = dated;          
           this.Remarks = remarks;
           this.CreatedBy  = createdBy;          
       }
    }
}
