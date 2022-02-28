using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class StockAdj
    {
        //Fields.
        private int adjID;
        private DateTime adjDate;              
        private Item item;
        private decimal previousQuantity;
        private decimal previousPrice;        
        private decimal currentQuantity;        
        private decimal currentPrice;
        public Packing Packing;
        private int user;                       

        //Constructors.

        public StockAdj()
        { }

        public StockAdj(int adjID, DateTime adjDate, Item item, decimal previousQuantity, decimal previousPrice, decimal currentQuantity, decimal currentPrice, int user,Packing packing)
            : this()
        {

            this.adjID = adjID;
            this.adjDate = adjDate;
            this.item = item;
            this.previousQuantity = previousQuantity;
            this.previousPrice = previousPrice;
            this.currentQuantity = currentQuantity;
            this.currentPrice = currentPrice; 
            this.user = user;
            this.Packing = packing;
        }

        private int storeID;

        public int StoreID
        {
            get { return storeID; }
            set { storeID  = value; }
        }
        //Properties.
        public int AdjID
        {
            get { return adjID; }
            set { adjID = value; }
        }
        public DateTime AdjDate
        {
            get { return adjDate; }
            set { adjDate = value; }
        }
        public Item Item
        {
            get { return item; }
            set { item = value; }
        }

        public decimal PreviousQuantity
        {
            get { return previousQuantity; }
            set { previousQuantity = value; }
        }
        public decimal PreviousPrice
        {
            get { return previousPrice; }
            set { previousPrice = value; }
        }
        public decimal CurrentQuantity
        {
            get { return currentQuantity; }
            set { currentQuantity = value; }
        }
        public decimal CurrentPrice
        {
            get { return currentPrice; }
            set { currentPrice = value; }
        }
        
        public int User
        {
            get { return user; }
            set { user = value; }
        }
        public StockAdj(int adjID, DateTime adjDate, Item item, decimal previousQuantity, decimal previousPrice, decimal currentQuantity, decimal currentPrice, int user)
           : this()
        {

            this.adjID = adjID;
            this.adjDate = adjDate;
            this.item = item;
            this.previousQuantity = previousQuantity;
            this.previousPrice = previousPrice;
            this.currentQuantity = currentQuantity;
            this.currentPrice = currentPrice;
            this.user = user;
        }
    }
}
