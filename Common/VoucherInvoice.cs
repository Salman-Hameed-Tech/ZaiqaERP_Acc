using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
   public  class VoucherInvoice
    {
        public int ID { get; set; }
       public DateTime Dated {get;set;}     
       public string Purpose { get; set; }
       public ChartOfAccounts  Party { get; set; }
       public decimal TotalAmt { get; set; }
       public decimal RemainingAmt {get;set;}
       public bool Select { get; set; }
      
       public VoucherInvoice()
       {
       }

       public VoucherInvoice(int id,decimal remainingAmt)
       {
           this.ID = id;           
           this.RemainingAmt = remainingAmt;
       }
       

       public VoucherInvoice(int id, DateTime dated, string purpose, ChartOfAccounts party, decimal totalAmt, decimal remainingAmt)
       {
           this.ID = id;
           this.Dated = dated;          
           this.Purpose = purpose ;
           this.Party = party ;
           this.TotalAmt = totalAmt;
           this.RemainingAmt = remainingAmt; 
       }
    }
}
