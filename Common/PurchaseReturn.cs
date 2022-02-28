using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class PurchaseReturn
    {
        //Fields.
        private int retInvoiceNo;
        private DateTime purchaseReturnDate;
        
        private decimal totalAmount;
        private decimal amountPaid;
        public int BranchID { get; set; }
                
        private Purchase purchase;
        private Vendor vendor;
        private List<PurchaseReturnLine> purchaseReturnLines;
        public string Narration { get; set; }
        public decimal Discount { get; set; }
        private string username;
        private bool isadjust;
        public string Remarks { get; set; }
        private string courierAccount;
        private string trackingID;
        private decimal courierAmount;

        private ClaimInvoiceType claimInvoiceType;
        public static string Condition;
         //Constructors.
        public PurchaseReturn(int retInvoiceNo, Purchase purchase, DateTime purchaseReturnDate, List<PurchaseReturnLine> purchaseReturnLines, decimal totalAmount, Vendor vendor, string narration)
            : this()
        {
            this.retInvoiceNo = retInvoiceNo;
            this.purchase = purchase;
            this.purchaseReturnDate = purchaseReturnDate;
            this.purchaseReturnLines = purchaseReturnLines;
            this.totalAmount = totalAmount;

            this.vendor = vendor;
            this.Narration = narration;

        }

        
        public PurchaseReturn()
        {
            purchaseReturnLines = new List<PurchaseReturnLine>();            
        }

        public PurchaseReturn(int retInvoiceNo,Purchase purchase, DateTime purchaseReturnDate, List<PurchaseReturnLine> purchaseReturnLines, decimal totalAmount, decimal amountPaid,Vendor vendor)
            : this()
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
        public string CourierAccount
        {
            get { return courierAccount; }
            set { courierAccount = value; }
        }
        public ClaimInvoiceType ClaimType
        {
            get { return claimInvoiceType; }
            set { claimInvoiceType = value; }
        }
        public string TrackingID
        {
            get { return trackingID; }
            set { trackingID = value; }
        }
        public decimal CourierAmount
        {
            get { return courierAmount; }
            set { courierAmount = value; }
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
        public string UserName
        {
            get { return username; }
            set { username = value; }
        }
        public bool IsAdjust
        {
            get { return isadjust; }
            set { isadjust = value; }
        }
        //Methods.
        public override string ToString()
        {
            return retInvoiceNo + ", Purchase=" + purchase.InvoiceNo + ", Date=" + purchaseReturnDate.Date + ", Vendor=" + vendor.ToString();
        }
        public override bool Equals(object obj)
        {
            return (((PurchaseReturn)obj).retInvoiceNo == this.retInvoiceNo);
        }
    }
}
