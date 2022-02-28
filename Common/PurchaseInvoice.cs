using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
   public  class PurchaseInvoice
    {
       public int ID { get; set; }
       public int InvoiceNo { get; set; }
       public DateTime Dated {get;set;}
       public string PartyName { get; set; }
       public string Invtype { get; set; }
       public ChartOfAccounts Party { get; set; }
       public int LeadDays { get; set; }
       public string Purpose { get; set; }

     
       
       public decimal TotalAmt { get; set; }
       public decimal GstPer { get; set; }
       public decimal GstAmt { get; set; }
       public string Remarks { get; set; }
       public int ItemID { get; set; }
       public string ItemName { get; set; }
       public int  UserID { get; set; }       
       public int PaymentMode { get; set; }
       public int PaymentDays { get; set; }
       public decimal Disc { get; set; }
       public decimal DiscPer { get; set; }
       public decimal Quantity { get; set; }
       public decimal AdjQuantity { get; set; }
       public decimal Rate { get; set; }
       public decimal ReturnQuantity { get; set; }
       public List<PurchaseLine> InvoiceLines { get; set; }
       public List<PurchaseInvoice> InvoiceLine { get; set; }

       public static string condition;
       public PurchaseInvoice()
       {
       }


       public PurchaseInvoice(int id, string accountName, DateTime dated, int itemid, string ItemName, decimal quantity)
       {
           this.ID = id;
           this.ItemName = ItemName;
           this.Quantity = quantity;
           this.ItemID = itemid;
           this.Dated = dated;
           this.PartyName = accountName;


       }
       public PurchaseInvoice(int id,DateTime dated,int  leadDays,string purpose,ChartOfAccounts  party,decimal totalAmt,string remarks,int  userID,int paymentMode,int paymentDays)
       {
           this.ID = id;
           this.Dated = dated;
           this.LeadDays = leadDays;
           this.Purpose = purpose;
           this.Party = party;
           this.TotalAmt = totalAmt;
           this.Remarks = remarks;
           this.UserID = userID;
         
           this.PaymentMode = paymentMode ;
           this.PaymentDays = paymentDays;
       }
    }
}
