using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class ItemName
    {
        //Fields.
        private string companyName;
        private string productName;
        private string design;
        private string size;
        private string color;

        //Constructors.
        public ItemName()
        { }

       
        public ItemName(string companyName,string productName,string design,string size)
        {

            this.CompanyName = companyName;
            this.ProductName = productName;
            this.Design = design;
            this.Size = size;
            
          
        }

        //Properties.
        public string CompanyName
        {
            get { return companyName; }
            set { companyName = value; }
        }        

        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
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

        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        //Methods.
        public override string ToString()
        {
            return companyName + "-" + productName + (design.Trim().Length == null ? "" : "-" + design) + (size.Trim().Length == 0 ? "" : "-" + size);
        }
    }
}
