using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class SchDiscOffers
    {
        //Fields.
        public static string Condition;

        private int offerID;
        private int branchid;
        private DateTime fromdate;
        private DateTime todate;
        private string branchname;
        private string category;
        private string companyName;
        private string productName;
        private string design;
        private string size;
        private bool isActive;
        private decimal discount;
        private int fileno;
        private string barcode;

        List<Branch> branhList = new List<Branch>();
        public SchDiscOffers()
        { }

        public SchDiscOffers(int offerID, DateTime fromdate,DateTime todate,decimal discount, string category,string companyName,string productName,string design,string size,bool isActive,int fileno):this()
        {
            this.offerID = offerID;
         
            this.FromDate = fromdate;
            this.ToDate = todate;
            this.Discount = discount;
            this.category = category;
            this.companyName = companyName;
            this.productName = productName;
            this.design = design;
            this.size = size;
            this.isActive = isActive;
            this.FileNo = fileno;
        }

        //Properties.
        public int OfferID
        {
            get { return offerID; }
            set { offerID = value; }
        }
        public string BranchName
        {
            get { return branchname; }
            set { branchname = value; }
        }
        public int FileNo
        {
            get { return fileno; }
            set { fileno = value; }
        }
        public string Barcode
        {
            get { return barcode; }
            set { barcode = value; }
        }
        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }
        public DateTime FromDate
        {
            get { return fromdate; }
            set { fromdate = value; }
        }
        public DateTime ToDate
        {
            get { return todate; }
            set { todate = value; }
        }
        public decimal Discount
        {
            get { return discount; }
            set { discount = value; }
        }
        
       
        public string Category
        {
            get { return category; }
            set { category = value; }
        }
        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }
        public string CompanyName
        {
            get { return companyName; }
            set { companyName = value; }
        }
        
        public string Design
        {
            get { return design; }
            set { design = value; }
        }
        public string Size
        {
            get { return size; }
            set { size = value; }
        }
        


    }
}
