using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BarcodeStickerPrinter
{
    public class CellSize
    {
        public int Height
        {
            get ;
            set ;
        }
      
        public int Weidth
        {
            get ;
            set ;
        }

        public CellSize() { }
        public CellSize(int width, int height)
        {
            this.Height = height;
            this.Weidth = width;
        }

    }
}
