using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class Barcode
    {
        private string itembarcode;

        public Barcode()
        { }
        public Barcode(string itembarcode)
        {
            this.itembarcode = itembarcode;
        }
        public string MakeBarcode(string  ItemID )
        { 
            string VBarcodestring=string.Concat(System.Collections.ArrayList.Repeat('0',6-(ItemID.Length)  ).ToArray());
            
                return VBarcodestring + ItemID;
        }
        public override string ToString()
        {
            return itembarcode.ToString();
        }
        public string Itembarcode
        {
            get { return itembarcode; }
            set { itembarcode = value; }
        }

        public override bool Equals(object obj)
        {
            Barcode bc = obj as Barcode;
            if (bc == null)
            {
                return false;
            }
            return (bc.itembarcode == this.itembarcode);
        }
    }
}
