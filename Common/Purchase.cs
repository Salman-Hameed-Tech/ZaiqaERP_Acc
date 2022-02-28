using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class Purchase
    {
        //Fields.
        private int invoiceNo;
        private string VendorName;
        private DateTime purchaseDate;
        private decimal discount;
        private decimal totalAmount;
        private decimal amountPaid;
        private string ItemName;  
        public int BranchID { get; set; }
        private int userNo;
        private string userName;
        private Vendor vendor;
        private List<PurchaseLine> purchaseLines;
        private string billNumber;
        private bool addToPrint;
        private string remarks;
        private bool isadjust;
        private decimal gstper;
        private decimal gstamt;
        private string trackingid;
        private decimal courieramount;
        private string courieraccount;
        public int PaymentMode { get; set; }



        public static string Condition;


        //Constructors.
        public Purchase()
        {
            purchaseLines = new List<PurchaseLine>();
            vendor = new Vendor();
        }
        public Purchase(int invoiceNo)
            : this()
        {
            this.invoiceNo = invoiceNo;
        }
        public Purchase(int invoiceNo, string VendorName)
            : this()
        {
            this.invoiceNo = invoiceNo;
            this.VendorName = VendorName;
        }

        public Purchase(int invoiceNo, DateTime purchaseDate, decimal discount, Vendor vendor, List<PurchaseLine> purchaseLines, string billNumber, decimal totalAmount, decimal amountPaid,int branchID,string username,string remarks,bool isadjust,int pmtmode) : this()    
        {
            this.invoiceNo = invoiceNo;
            this.purchaseDate = purchaseDate;
            this.discount = discount;
            this.vendor = vendor;
            this.billNumber = billNumber;
            this.purchaseLines = purchaseLines;
            this.totalAmount = totalAmount;
            this.amountPaid = amountPaid;
           
            this.BranchID = branchID;
            this.UserName = username;
            this.Remarks = remarks;
            this.IsAdjust = isadjust;
            this.PaymentMode = pmtmode;
         
        }

        //Properties.
        public int InvoiceNo
        {
            get { return invoiceNo; }
            set { invoiceNo = value; }
        }

        public DateTime PurchaseDate
        {
            get { return purchaseDate; }
            set { purchaseDate = value; }
        }
       
       
        public Vendor Vendor
        {
            get{ return vendor ; }
            set{ vendor = value; }
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
       
       
       
        public string TrackingID
        {
            get { return trackingid; }
            set { trackingid = value; }
        }
        public decimal CourierAmount
        {
            get { return courieramount; }
            set { courieramount = value; }
        }
        public string CourierAccount
        {
            get { return courieraccount; }
            set { courieraccount = value; }
        }
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        public string Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }
        public bool IsAdjust
        {
            get { return isadjust; }
            set { isadjust = value; }
        }
        public string Vendorname
        {
            get { return VendorName; }
            set { VendorName = value; }
        }

        public decimal Discount
        {
            get { return discount; }
            set { discount = value; }
        }
        public decimal GSTAmt
        {
            get { return gstamt; }
            set { gstamt = value; }
        }
        public List<PurchaseLine> PurchaseLines
        {
            get { return purchaseLines; }
            set { purchaseLines = value; }
        }
        public decimal GSTPer
        {
            get { return gstper; }
            set { gstper = value; }
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
        public int UserNo
        {
            get { return userNo; }
            set { userNo = value; }
        }


        //Methods.isadjust
        public override string ToString()
        {
            return invoiceNo+", BillNo="+billNumber+", Date="+purchaseDate.Date+", Vendor="+vendor.ToString ();
        }

        //public override bool Equals(object obj)
        //{
        //    return (((Purchase)obj).invoiceNo == this .invoiceNo );
        //}

       
    }
}
