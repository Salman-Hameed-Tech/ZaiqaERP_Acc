using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Printing;

namespace BarcodeStickerPrinter
{
    public class StickerPage
    {
        public List<Item> items {get;set;}
        public int RowsPerPage { get; set; }
        public int ColsPerPage { get; set; }
        public Location pagelocation { get; set; }
        public CellSize CellSize { get; set; }     
        public  List<Row> Rows{get;set;}
        public Cell  StartingCell { get; set; }
        public  PrintDocument pdoc{get;set;}
        public PaperSize PaperSize { get; set; }
        public int Pages { get; set; }
        public int MaxRows { get; set; }
        int currentItemIndex = 0;
        int NextPageItemBarcodeCounter;
        int NextPageCurrentItemIndex;
        public StickerPage() 
        {
            this.StartingCell = new Cell(1,1);
            this.pagelocation = new Location();
            pdoc = new PrintDocument();
            this.pdoc.PrintPage += new PrintPageEventHandler(pdoc_PrintPage);
            NextPageCurrentItemIndex = 0;
            NextPageItemBarcodeCounter = 0;
            PaperSize = new PaperSize();
          
        }

        void pdoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            
            Graphics g = e.Graphics;
            Location cellLocation = new Location();
            SolidBrush stringBrush= new SolidBrush(Color.Black  );
            Font stringFont = new Font("arial western", 6);//7 for automatic cutting page (future)
            Font priceFont = new Font("arial western", 8);
            Font barcodeFont = new Font("Free 3 of 9 Extended", 19);//25 for automatic Cutting Page (future)
            currentItemIndex = NextPageCurrentItemIndex ;
            int itemBarcodeCounter = NextPageItemBarcodeCounter ;
            Item currentItem = items[currentItemIndex ];

            cellLocation.X = pagelocation.X;
            cellLocation.Y = pagelocation.Y;
           
            for (int currentrow = 0  ; currentrow < this.RowsPerPage ; currentrow++)
            {
                if (currentItemIndex == items.Count - 1)
                {
                    if (currentItem.ItemQuantity == itemBarcodeCounter) break;
                }
                for (int currentCol = 0 ; currentCol < this.ColsPerPage ; currentCol++)
                {
                    itemBarcodeCounter++;
                   
                    if (currentItem.ItemQuantity < itemBarcodeCounter)
                    {
                        currentItemIndex++;
                       if (currentItemIndex < items.Count) currentItem = items[currentItemIndex];

                        itemBarcodeCounter = 1;

                        
                    }

                    Rectangle rx = new Rectangle(cellLocation.X, cellLocation.Y, CellSize.Weidth, CellSize.Height);
                    g.DrawRectangle(new Pen(new SolidBrush(Color.White)), rx);
                    cellLocation.Y += 10;
                    g.DrawString( Convert.ToString (currentItem.Itemname.Split ('~').GetValue (0)), stringFont, stringBrush, cellLocation.X, cellLocation.Y);
                    cellLocation.Y += 10;
                    string strRs;
                    if (currentItem.Itemname.ToString ().Trim ().Length !=0)
                     strRs = "Rs." + currentItem.ItemPrice.ToString() + "  " + currentItem.Itemname.Split ('~').GetValue (1) ;
                    else
                         strRs = "Rs." + currentItem.ItemPrice.ToString()   ;
                    strRs = strRs.PadLeft(16, ' ');
                    g.DrawString(((currentItem.ItemPrice == null) ? "" : currentItem.ItemBarcode.Remove(currentItem.ItemBarcode.Length - 1, 1).Remove(0, 1)  + strRs), stringFont, stringBrush, cellLocation.X, cellLocation.Y);
                    //g.DrawString(((currentItem.ItemPrice == null) ? "" : "000000000000000023"), stringFont, stringBrush, cellLocation.X, cellLocation.Y);
                    //cellLocation.Y += 10;
                    //g.DrawString(currentItem.ItemBarcode, stringFont, stringBrush, cellLocation.X, cellLocation.Y);
                    cellLocation.Y += 10;//15 for cutting page(future)
                    g.DrawString(currentItem.ItemBarcode, barcodeFont, stringBrush, cellLocation.X, cellLocation.Y);
                    cellLocation.Y -= 32;// 32 for cutting page(future)

                    
                    cellLocation.X += CellSize.Weidth +10;
                    if (currentItemIndex == items.Count - 1)
                    {
                        if (currentItem.ItemQuantity == itemBarcodeCounter) break;
                    }
                }
                cellLocation.Y += CellSize.Height + 25;
                cellLocation.X = pagelocation.X;
            }
            
            if (this.Pages > 1)
            {
                e.HasMorePages = true;
                NextPageItemBarcodeCounter = itemBarcodeCounter;
                NextPageCurrentItemIndex = currentItemIndex;
                if (MaxRows < 20) RowsPerPage = MaxRows - 10;
                else RowsPerPage = 10;
                MaxRows -= 10;
                Pages--;
            }
            
        }
        public StickerPage(List<Item> items,CellSize cellsize,Location pagelocation):this()
        {
            this.items = items;
            this.CellSize = cellsize;
            this.pagelocation = pagelocation;
            
        }
        public StickerPage(List<Item> items, CellSize cellsize)
            : this()
        {
            this.items = items;
            this.CellSize = cellsize;
        }
          
        public void PrintBarcodes()
        {
            try
            {
                if (items == null) throw new Exception("No List of Items for Printing");
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            pdoc.DefaultPageSettings.PaperSize = this.PaperSize ;  //= new PaperSize("", 8.5, 11.5);
            pdoc.Print();

        }
    }
}
