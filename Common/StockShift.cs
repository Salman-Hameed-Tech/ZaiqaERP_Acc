using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
   public  class StockShift
    {
       public int ID { get; set; }
       public DateTime Dated {get;set;}          
       public string Remarks { get; set; }
       public int  CreatedBy { get; set; }
     
       public List<StockShiftLine > StockShiftLines { get; set; }

       //public static string condition;
      
       public StockShift()
       {
       }

       public StockShift(int id, DateTime dated, string remarks, int createdBy)
       {
           this.ID = id;
           this.Dated = dated;          
           this.Remarks = remarks;
           this.CreatedBy  = createdBy;          
       }
    }
}
