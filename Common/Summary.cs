using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class Summary
    {
        //Fields.
        private int summaryID;
        private DateTime summaryDate;
        private bool printed;
        private DateTime printedDate;
        private User user;
        private decimal pettyCash;
        public int Coin1 { get; set; }
        public int Coin2 { get; set; }
        public int Coin5 { get; set; }
        public int Note10 { get; set; }
        public int Note20 { get; set; }
        public int Note50 { get; set; }
        public int Note100 { get; set; }
        public int Note500 { get; set; }
        public int Note1000 { get; set; }
        public int Note5000 { get; set; }
        public decimal TotalSale { get; set; }
        public Decimal TotalPayment { get; set; }
        public decimal OpeningCash { get; set; }
        public decimal ClosingCash { get; set; }
        public decimal BankDeposite { get; set; }
        public decimal BarnchID { get; set; }
        public string Shift { get; set; }
        public decimal CreditCard { get; set; }



        public static Int64 SummaryNo;

        public Summary()
        { }

        public Summary(int summaryID,DateTime summaryDate,bool printed, DateTime printedDate,User user)
            : this()
        {
            this.summaryID = summaryID;
            this.summaryDate = summaryDate;
            this.printed = printed;
            this.printedDate = printedDate;
            this.user = user;
        }
        public Summary(int summaryID, DateTime summaryDate, bool printed, User user)
            : this()
        {
            this.summaryID = summaryID;
            this.summaryDate = summaryDate;
            this.printed = printed;         
            this.user = user;
        }
        public Summary(int summaryID, DateTime summaryDate, bool printed, DateTime printedDate, User user,decimal pettyCash)
            : this()
        {
            this.summaryID = summaryID;
            this.summaryDate = summaryDate;
            this.printed = printed;
            this.printedDate = printedDate;
            this.user = user;
            this.pettyCash = pettyCash;
        }
        //Properties.
        public int SummaryID
        {
            get { return summaryID; }
            set { summaryID = value; }
        }        
        public DateTime SummaryDate
        {
            get { return summaryDate; }
            set { summaryDate = value; }
        }        
        public bool Printed
        {
            get { return printed; }
            set { printed = value; }
        }        
        public DateTime PrintedDate
        {
            get { return printedDate; }
            set { printedDate = value; }
        }       

        public User User
        {
            get { return user; }
            set { user = value; }
        }

        public decimal PettyCash
        {
            get { return pettyCash; }
            set { pettyCash = value; }
        }
    }
}
