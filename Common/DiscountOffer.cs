using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Data_Sets;

namespace Common
{
    public class DiscountOffer
    {
        //Fields.
        int offerID;
        Category category;
        Common.Item item;
        decimal discount;
        bool isActive;
        private DateTime fromDate;
        private DateTime toDate;
        public string Barcode { get; set; }
        public string ItemName { get; set; }
        public int Branchid { get; set; }
        public int CatID { get; set; }

        public List<Branch> branchList = new List<Branch>();
        public List<DiscountOffer> barcodeList = new List<DiscountOffer>();
        public DiscountOffer()
        { }

        public DiscountOffer(int offerID,Category category,Item item,decimal discount,bool isActive,DateTime fromdate,DateTime todate,List<Branch> brnachlist,List<DiscountOffer> barcodelist):this()
        {
            this.offerID = offerID;
            this.category = category;
            this.item = item;
            this.discount = discount;
            this.isActive = isActive;
            this.FromDate = fromdate;
            this.ToDate = todate;
            branchList = brnachlist;
            this.barcodeList = barcodelist;

        }
        public DiscountOffer(Item item)
        {
            this.Item = item;
        }

        //Properties.
        public int OfferID
        {
            get { return offerID; }
            set { offerID = value; }
        }
        public Category Category
        {
            get { return category; }
            set { category = value; }
        }
        public decimal Discount
        {
            get { return discount; }
            set { discount = value; }
        }
        public Common.Item Item
        {
            get { return item; }
            set { item = value; }
        }
       

        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }
        public DateTime FromDate
        {
            get { return fromDate; }
            set { fromDate = value; }
        }
        public DateTime ToDate
        {
            get { return toDate; }
            set { toDate = value; }
        }

        public bool GetChallanData(ref DsChallan dsChallan, int v1, string v2)
        {
            throw new NotImplementedException();
        }
    }
}
