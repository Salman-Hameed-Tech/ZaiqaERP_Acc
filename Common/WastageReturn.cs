using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class WastageReturn
    {
        //Fields.
        private int retInvoiceNo;
        private DateTime purchaseReturnDate;
        
        private decimal totalAmount;
        private decimal amountPaid;

                
        private Purchase purchase;
        private Wastage wastage;
        private Vendor vendor;

        private List<PurchaseReturnLine> purchaseReturnLines;

        private List<WastageReturnLine> wastageReturnLines;

        public string Narration { get; set; }
        public decimal Discount { get; set; }

        public static string Condition;
         //Constructors.
        public WastageReturn(int retInvoiceNo, Wastage wastage, DateTime purchaseReturnDate, List<WastageReturnLine > wastageReturnLines, decimal totalAmount, decimal amountPaid, Vendor vendor, string narration)  
        {
            this.retInvoiceNo = retInvoiceNo;
            this.wastage = wastage;
            this.purchaseReturnDate = purchaseReturnDate;
            this.wastageReturnLines = wastageReturnLines;
            this.totalAmount = totalAmount;
            this.amountPaid = amountPaid;
            this.vendor = vendor;
            this.Narration = narration;
        }

        
        public WastageReturn()
        {
            purchaseReturnLines = new List<PurchaseReturnLine>();
            wastageReturnLines = new List<WastageReturnLine>();
        }

        public WastageReturn(int retInvoiceNo, Purchase purchase, DateTime purchaseReturnDate, List<PurchaseReturnLine> purchaseReturnLines, decimal totalAmount, decimal amountPaid, Vendor vendor)
            
        {
            this.retInvoiceNo = retInvoiceNo;
            this.purchase = purchase;
            this.purchaseReturnDate = purchaseReturnDate;                        
            this.purchaseReturnLines = purchaseReturnLines;
            this.totalAmount = totalAmount;
            this.amountPaid = amountPaid;
            this.vendor = vendor;
        }

        //Properties.
        public int RetInvoiceNo
        {
            get { return retInvoiceNo; }
            set { retInvoiceNo = value; }
        }

        public DateTime PurchaseReturnDate
        {
            get { return purchaseReturnDate; }
            set { purchaseReturnDate = value; }
        }


        public List<WastageReturnLine> WastageReturnLines
        {
            get { return wastageReturnLines; }
            set { wastageReturnLines = value; }
        }
        
        public List<PurchaseReturnLine> PurchaseReturnLines
        {
            get { return purchaseReturnLines; }
            set { purchaseReturnLines = value; }
        }
       
        public decimal TotalAmount
        {
            get { return totalAmount; }
            set { totalAmount = value; }
        }
        public decimal AmountPaid
        {
            get { return amountPaid; }
            set { amountPaid = value; }
        }

        public Purchase Purchase
        {
            get{ return purchase; }
            set{ purchase = value; }
        }
        public Vendor Vendor
        {
            get { return vendor; }
            set { vendor = value; }
        }

        //Methods.
        public override string ToString()
        {
            return retInvoiceNo + ", Purchase=" + purchase.InvoiceNo + ", Date=" + purchaseReturnDate.Date + ", Vendor=" + vendor.ToString();
        }
        public override bool Equals(object obj)
        {
            return (((WastageReturn)obj).retInvoiceNo == this.retInvoiceNo);
        }
    }
}
