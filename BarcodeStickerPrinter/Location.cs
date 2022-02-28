using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BarcodeStickerPrinter
{
   public  class Location
    {
       public int X { get; set; }
       public int Y { get; set; }
       public Location()
       {
           this.X = 0;
           this.Y = 0;
       }
    }
}
