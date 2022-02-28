using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class PurchaseLine
    {
        //Fields.
        private string shortkey;
        private decimal quantity;
        private decimal purchasePrice;
        private decimal totalAmount;
        private bool isDeleted;
        private int serialNumber;
        private Category category;
        private Item item;
        private double disc;
        private double DiscPer;
        private decimal salePrice;
        private string ItemName;
        private string barcode;
        private decimal gstper;
        private decimal gstamt;

        public int BranchID { get; set; }
        //Constructors.
        public PurchaseLine()
        {
            category = new Category();
            item = new Item();
        }
        public PurchaseLine(int serialNumber)
        {
            this.serialNumber = serialNumber;
        }
        public PurchaseLine(Category category,Item item,decimal quantity,decimal purchasePrice,decimal totalAmount,int serialNumber,double disc,decimal salePrice,string itemname)
        {
            this.category = category;
            this.item = item;
            this.quantity = quantity;
            this.purchasePrice = purchasePrice;
            this.serialNumber = serialNumber;
            this.totalAmount = totalAmount;
            this.isDeleted = false;
            this.disc = disc;
            this.salePrice = salePrice;
          
            this.Itemname=itemname;
          
        }
        
        //Properties.
        public decimal Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public string ShortKey
        {
            get { return shortkey; }
            set { shortkey = value; }
        }
        public string Barcode
        {
            get { return barcode; }
            set { barcode = value; }
        }
        public decimal PurchasePrice
        {
            get { return purchasePrice; }
            set { purchasePrice = value; }
        }

        public decimal TotalAmount
        {
            get { return totalAmount; }
            set { totalAmount = value; }
        }

        public int SerialNumber
        {
            get { return serialNumber; }
            set { serialNumber = value; }
        }

        public Category Category
        {
            get { return category; }
            set { category = value; }
        }

        public Item Item
        {
            get {return item;}
            set {item = value;}
        }

        public bool IsDeleted
        {
            get { return isDeleted; }
            set { isDeleted = value; }
        }

        public double Disc
        {
            get { return disc; }
            set { disc = value; }
        }

        public double Discper
        {
            get { return DiscPer; }
            set { DiscPer = value; }
        }

        public decimal GstPer
        {
            get { return gstper; }
            set { gstper = value; }
        }
        public decimal GstAmt
        {
            get { return gstamt; }
            set { gstamt = value; }
        }

        public decimal SalePrice
        {
            get { return salePrice; }
            set { salePrice = value; }
        }

        public string Itemname
        {
            get { return ItemName; }
            set { ItemName = value; }
        }

        //Methods.
        public override string ToString()
        {
            return item.ItemName.ToString ()+", Quantity="+quantity+", Rate="+purchasePrice ;
        }
        public override bool Equals(object obj)
        {
            return (((PurchaseLine)obj).serialNumber==this .serialNumber );
        }        
    }
}
