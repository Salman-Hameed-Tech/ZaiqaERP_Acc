using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class WastageLine
    {
        //Fields.
        private string shortkey;
        private decimal quantity;
        private decimal purchasePrice;
        public Int32 itemid { get; set; }
        public Int32 BranchID { get; set; }
        public string itemname { get; set; }
        private decimal totalAmount;
        private bool isDeleted;
        private int serialNumber;
        private Category category;
        private Item item;
      
        private double disc;
        private decimal salePrice;
        private string ItemName;

        //Constructors.
        public WastageLine()
        {
            category = new Category();
            item = new Item();
        }

        public WastageLine(Category category,Item item, string shortkey,decimal quantity,decimal purchasePrice,decimal totalAmount,int serialNumber,double disc,decimal salePrice,string itemname)
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
            this.ShortKey = shortkey;
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
            get { return item; }
            set { item = value; }
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
            return item.ItemName.ToString() + ", Quantity=" + quantity + ", Rate=" + purchasePrice;
        }
        public override bool Equals(object obj)
        {
            return (((WastageLine)obj).serialNumber == this.serialNumber);
        }   
    }
}