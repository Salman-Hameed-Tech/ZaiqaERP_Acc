using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BarcodeStickerPrinter
{
   public  class Cell
    {
       public int Row { get; set; }
       public int Col { get; set; }
       
       public Cell(){}
       public Cell(int row,int col)
       {
           this.Row = row;
           this.Col = col;
       }
    }
}
