using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class SaleInvoiceLine
    {
        //Fields.

        private decimal cStk;
        private decimal quantity;
        private decimal salePrice;
        private decimal purchasePrice;              
        private decimal disc;
        private decimal DiscPer;
        private Item vitem;
        private int serialNumber;
        private bool isDeleted;
        public Int32 BranchID { get; set; }
        public Int32 SaleID { get; set; }
        public string ItemName { get; set; }
        //private String ShortKey;

        //Constructors.
        public SaleInvoiceLine()
        { vitem = new Item(); }
        public SaleInvoiceLine(decimal CStk, double Disc, Item Vitem)
        {
            this.cStk = CStk;
            this.disc = disc;
            this.vitem = vitem;
        }
        public SaleInvoiceLine(decimal CStk, decimal quantity, decimal salePrice, decimal purchasePrice, decimal disc, Item vitem, int serialNumber, bool isDeleted,Int32 saleid)
        {
            this.cStk = CStk;
            this.quantity = quantity;
            this.salePrice = salePrice;
            this.purchasePrice = purchasePrice;
            this.disc =disc;
            this.vitem = vitem;
            this.serialNumber = serialNumber;
            this.isDeleted = isDeleted;
            this.SaleID = saleid;
            //this.ShortKey = ShortKey;
        }       
        
        //Properties.
        public decimal CStk
        {
            get { return cStk; }
            set { cStk = value; }
        }
        public decimal Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

       
        public decimal SalePrice
        {
            get { return salePrice; }
            set { salePrice = value; }
        }
        public decimal PurchasePrice
        {
            get { return purchasePrice; }
            set { purchasePrice = value; }
        }        
        public decimal Disc
        {
            get { return disc; }
            set { disc = value; }
        }
        public decimal Discper
        {
            get { return DiscPer; }
            set { DiscPer = value; }
        }
        public Item Vitem
        {
            get { return vitem; }
            set { vitem = value; }
        }
        public int SerialNumber
        {
            get { return serialNumber; }
            set { serialNumber = value; }
        }
        public bool IsDeleted
        {
            get { return isDeleted; }
            set { isDeleted = value; }
        }
    }
}
