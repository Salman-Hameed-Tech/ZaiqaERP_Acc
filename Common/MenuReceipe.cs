using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class MenuReceipe
    {        
        public Int32 ItemID { get; set; }
        public string ItemName { get; set; }
        public decimal Qty { get; set; }
        public decimal Divisor { get; set; }

     
        public MenuReceipe()
        { }

        public MenuReceipe(Int32 itemid, string itemname, decimal qty, decimal divisor)
        {            
            this.ItemID = itemid;
            this.ItemName = itemname;
            this.Qty = qty;
            this.Divisor = divisor;
        }

    }
}
