using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BarcodeStickerPrinter
{
    public class Item
    {
        public Nullable<int> Itemno{get;set;}
        public string Itemname {get; set; }
       
        public string Printname { get; set; }
        public Nullable<double> ItemPrice { get; set; }
        public string ItemBarcode { get; set; }
        public int ItemQuantity { get; set; }
        public string Code { get; set; }
        public Item() { }

        public Item(Nullable<int> no, string name, Nullable<double> price, string barcode, int qty)
        {
            this.Itemname = name;
         
            this.Itemno = no;
            this.ItemPrice = price;
            this.ItemBarcode = barcode;
            this.ItemQuantity = qty;
            //this.Company = comp;

        }
    }
}
