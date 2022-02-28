using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class SaleReturn
    {
        //Fields.
        private int retInvoiceNo;
        private DateTime saleReturnDate;
        
        private decimal totalAmount;
        private decimal amountPaid;
        public Int32 BranchID { get; set; }

        private SaleInvoice sale;
        private Vendor vendor;
        private List<SaleReturnLine> saleReturnLines;

        private ClaimType type;
        private string narration;                

        public static string Condition;
         //Constructors.
        public SaleReturn()
        {
            saleReturnLines = new List<SaleReturnLine>();            
        }

        public SaleReturn(int retInvoiceNo, SaleInvoice sale, DateTime saleReturnDate, List<SaleReturnLine> saleReturnLines, decimal totalAmount, decimal amountPaid, Vendor vendor)
            : this()
        {
            this.retInvoiceNo = retInvoiceNo;
            this.sale = sale;
            this.saleReturnDate = saleReturnDate;                        
            this.saleReturnLines = saleReturnLines;
            this.totalAmount = totalAmount;
            this.amountPaid = amountPaid;
            this.vendor = vendor;
        }
        public SaleReturn(int retInvoiceNo, SaleInvoice sale, DateTime saleReturnDate, List<SaleReturnLine> saleReturnLines, decimal totalAmount, decimal amountPaid, Vendor vendor,ClaimType type)
            : this()
        {
            this.retInvoiceNo = retInvoiceNo;
            this.sale = sale;
            this.saleReturnDate = saleReturnDate;
            this.saleReturnLines = saleReturnLines;
            this.totalAmount = totalAmount;
            this.amountPaid = amountPaid;
            this.vendor = vendor;
            this.type = type;
        }
        public SaleReturn(int retInvoiceNo, SaleInvoice sale, DateTime saleReturnDate, List<SaleReturnLine> saleReturnLines, decimal totalAmount, decimal amountPaid, Vendor vendor, ClaimType type,string narration)
            : this()
        {
            this.retInvoiceNo = retInvoiceNo;
            this.sale = sale;
            this.saleReturnDate = saleReturnDate;
            this.saleReturnLines = saleReturnLines;
            this.totalAmount = totalAmount;
            this.amountPaid = amountPaid;
            this.vendor = vendor;
            this.type = type;
            this.narration = narration;
        }
        //Properties.
        public int RetInvoiceNo
        {
            get { return retInvoiceNo; }
            set { retInvoiceNo = value; }
        }

        public DateTime SaleReturnDate
        {
            get { return saleReturnDate; }
            set { saleReturnDate = value; }
        }
       
        
        public List<SaleReturnLine> SaleReturnLines
        {
            get { return saleReturnLines; }
            set { saleReturnLines = value; }
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

        public SaleInvoice Sale
        {
            get{ return sale; }
            set{ sale = value; }
        }
        public Vendor Vendor
        {
            get { return vendor; }
            set { vendor = value; }
        }
        public ClaimType Type
        {
            get { return type; }
            set { type = value; }
        }
        public string Narration
        {
            get { return narration; }
            set { narration = value; }
        }
        //Methods.
        public override string ToString()
        {
            return retInvoiceNo + ", Sale=" + sale.SaleID+ ", Date=" + saleReturnDate.Date + ", Vendor=" + vendor.ToString();
        }
        public override bool Equals(object obj)
        {
            return (((SaleReturn)obj).retInvoiceNo == this.retInvoiceNo);
        }
    }
}
