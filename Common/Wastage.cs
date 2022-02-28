using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class Wastage
    {
        //Fields.
        private int invoiceNo;
        private string VendorName;
        private DateTime wastageDate;
        private decimal discount;
        private decimal totalAmount;
        private decimal amountPaid;
        private string ItemName;
        private string narration;
        private decimal payable;
        private decimal paid;
        public Int32 BranchID { get; set; }
        private Vendor vendor;
        private List<WastageLine> wastageLines;
        private string billNumber;
        private bool addToPrint;

        public static string Condition;

        //constructor.
        public Wastage()
        {
            WastageLines = new List<WastageLine>();            
        }

        public Wastage(int invno, DateTime InvDate, List<WastageLine> wastageLine, decimal totalAmount, decimal amountPaid,Vendor vendor)
        {
            this.InvoiceNo = invno;
            this.WastageDate = InvDate;                        
            this.WastageLines = wastageLines;
            this.totalAmount = totalAmount;
            this.amountPaid = amountPaid;
            this.vendor = vendor;
        }

        //Properties.
        public int InvoiceNo
        {
            get { return invoiceNo; }
            set { invoiceNo = value; }
        }

        public decimal Payable 
        {
            get { return payable; }
            set { payable=value;}
        }

        public DateTime WastageDate
        {
            get { return wastageDate; }
            set { wastageDate = value; }
        }

        public decimal Discount
        {
            get { return discount; }
            set { discount = value; }
        }

        public decimal Paid
        {
            get { return paid; }
            set { paid = value; }
        }

        public Vendor Vendor
        {
            get { return vendor; }
            set { vendor = value; }
        }

        public string Vendorname
        {
            get { return VendorName; }
            set { VendorName = value; }
        }

        public string Narration
        {
            get { return narration; }
            set { narration = value; }
        }

        public List<WastageLine> WastageLines
        {
            get { return wastageLines; }
            set { wastageLines = value; }
        }

        public string BillNumber
        {
            get { return billNumber; }
            set { billNumber = value; }
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
        public bool AddToPrint
        {
            get { return addToPrint; }
            set { addToPrint = value; }
        }


        //Methods.
        public override string ToString()
        {
            return invoiceNo + ", BillNo=" + billNumber + ", Date=" + wastageDate.Date + ", Vendor=" + vendor.ToString();
        }
        public override bool Equals(object obj)
        {
            return (((Wastage)obj).invoiceNo == this.invoiceNo);
        }
    }
}