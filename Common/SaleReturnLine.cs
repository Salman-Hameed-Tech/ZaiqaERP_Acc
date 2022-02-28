using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class SaleReturnLine
    {
        //Fields.
        private decimal quantity;
        private decimal purchasePrice;
        private decimal salePrice;        
        private decimal purQuantity;        
        private decimal totalAmount;
        private bool isDeleted;
        private int serialNumber;
        public Int32 BranchID { get; set; }
        private Category category;
        private Item item;

         //Constructors.
        public SaleReturnLine()
        {
            category = new Category();
            item = new Item();
        }
        public SaleReturnLine(int serialNumber)
        {
            this.serialNumber = serialNumber;
        }
        public SaleReturnLine(Category category, Item item, decimal quantity, decimal purQuantity, decimal purchasePrice, decimal totalAmount, int serialNumber)
        {
            this.category = category;
            this.item = item;
            this.quantity = quantity;
            this.purQuantity = purQuantity;
            this.purchasePrice = purchasePrice;
            this.serialNumber = serialNumber;
            this.totalAmount = totalAmount;
            this.isDeleted = false;
        }
        public SaleReturnLine(Category category, Item item, decimal quantity, decimal purQuantity, decimal purchasePrice,decimal salePrice, decimal totalAmount, int serialNumber)
        {
            this.category = category;
            this.item = item;
            this.quantity = quantity;
            this.purQuantity = purQuantity;
            this.purchasePrice = purchasePrice;
            this.salePrice = salePrice;
            this.serialNumber = serialNumber;
            this.totalAmount = totalAmount;
            this.isDeleted = false;
        }
        public Item Item
        {
            get
            { return item; }
            set
            { item = value; }
        }
        public Category Category
        {
            get { return category; }
            set { category = value; }
        }

        public decimal Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        public decimal PurQuantity
        {
            get { return purQuantity; }
            set { purQuantity = value; }
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
        public decimal SalePrice
        {
            get { return salePrice; }
            set { salePrice = value; }
        }
        public bool IsDeleted
        {
            get { return isDeleted; }
            set { isDeleted = value; }
        }        

        //Methods.
        public override string ToString()
        {
            return item.ItemName.ToString() + ", Quantity=" + quantity + ", Rate=" + purchasePrice;
        }
        public override bool Equals(object obj)
        {
            return (((SaleReturnLine)obj).serialNumber == this.serialNumber);
        }        
    }
}
