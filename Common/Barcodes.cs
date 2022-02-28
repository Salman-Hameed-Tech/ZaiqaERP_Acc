using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class Barcodes
    {
        private string barcode;
        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public string Barcode
        {
            get { return barcode; }
            set { barcode = value; }
        }
       
    }
}
