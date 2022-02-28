using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
 public   class SchItems
    {
     public static string condition;
     public SchItems()
     { 
     }
        public SchItems(int itemid, string categoryname, string companyname, string productname, string design, string size)
        {
            this.ItemID = itemid;
            this.categoryname = categoryname;
            this.companyname = companyname;
            this.productname = productname;
            this.design = design;
            this.size = size;
         
        }
        public SchItems(int itemid, string categoryname, string companyname, string productname, string design, string size, Boolean vselect1,string barcodes,bool ismarinateditem,bool isbakeryitem)
        {
            this.ItemID = itemid;
            this.categoryname = categoryname;
            this.companyname = companyname;
            this.productname = productname;
            this.design = design;
            this.size = size;
            this.VSelect = vselect1;
            this.Barcode = barcodes;
            this.IsMarinated = ismarinateditem;
            this.IsBakery = isbakeryitem;
        }
        
        private int itemID;
     
       

        public int ItemID
        {
            get { return itemID; }
            set { itemID = value; }
        }
        private string brcaode;
        public string Barcode
        {
            get { return brcaode; }
            set { brcaode = value; }
        }
        private string categoryname;
        public string Categoryname
        {
            get { return categoryname; }
            set { categoryname = value; }
        }
        private string companyname;

        public string Companyname
        {
            get { return companyname; }
            set { companyname = value; }
        }
        private string productname;

        public string Productname
        {
            get { return productname; }
            set { productname = value; }
        }
        private string design;

        public string Design
        {
            get { return design; }
            set { design = value; }
        }
        private bool ismarinated;
        public bool IsMarinated
        {
            get { return ismarinated; }
            set { ismarinated = value; }
        }
        private bool isbakery;
        public bool IsBakery
        {
            get { return isbakery; }
            set { isbakery = value; }
        }
        private string size;

        public string Size
        {
            get { return size; }
            set { size = value; }
        }
        private Boolean VSelect;

        public Boolean VSelect1
        {
            get { return VSelect; }
            set { VSelect = value; }
        }
        public override bool Equals(object obj)
        {
           SchItems objitem=(SchItems )obj;
               //return (objitem.categoryname ==null;false:  && (objitem.itemID == this.itemID);
               return (objitem.companyname  == null ? true : (this.companyname.Trim().ToUpper().StartsWith(objitem.companyname.Trim().ToUpper()))) && (objitem.itemID == 0 ? true : (objitem.itemID == this.itemID));


           
        }
 }

}
