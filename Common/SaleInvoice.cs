using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class SaleInvoice
    {
        //Fields.        
        private int saleid;
        private DateTime saledate;
        private DateTime sDateTime;
        private Boolean pending;
        private Customer party;
        private double invdisc;
        private Int64 crcid;
        private double crcamt;
        private double cashamt;
        private double total;
        private double totaldisc;
        private double cardDeduction;
        private double totalRetAmt;
        private double balance;
        private bool isFinalInvoice;
        private string customerName;
        private string customerCell;
        private string partyid;
        private string partyname;
        private string username;
        private string bankacc;
        private string cardno;
        public Int32 BranchID { get; set; }
        public string PmtType { get; set; }
       

        public string Reference
        {
            get { return reference; }
            set { reference = value; }
        }

        private List<SaleInvoiceLine> saleLines;

        private Int64 summaryNo;
        private string name;

        public static string Condition;
        //Constructors.
        public SaleInvoice()
        { }
        public SaleInvoice(int saleid, DateTime saledate, Boolean pending, Customer party, double invdisc, Int64 crcid, double crcamt, double cashamt, double total, double totaldisc, List<SaleInvoiceLine> saleLines, Int64 summaryNo, double cardDeduction, double totalRetAmt, double balance)
        {
            this.saledate = saledate;
            this.saleid = saleid;
            this.pending = pending;
            this.party = party;
            this.crcid = crcid;
            this.crcamt = crcamt;
            this.cashamt = cashamt;
            this.total = total;
            this.invdisc = invdisc;
            this.totaldisc = totaldisc;
            this.saleLines = saleLines;
            this.summaryNo = summaryNo;
            this.cardDeduction = cardDeduction;
            this.totalRetAmt = totalRetAmt;
            this.balance = balance;
        }

        public SaleInvoice(int saleid, DateTime saledate, Boolean pending, Customer party, double invdisc, Int64 crcid, double crcamt, double cashamt, double total, double totaldisc, List<SaleInvoiceLine> saleLines, Int64 summaryNo, string name, double cardDeduction, double totalRetAmt, double balance)
        {
            this.saledate = saledate;
            this.saleid = saleid;
            this.pending = pending;
            this.party = party;
            this.crcid = crcid;
            this.crcamt = crcamt;
            this.cashamt = cashamt;
            this.total = total;
            this.invdisc = invdisc;
            this.totaldisc = totaldisc;
            this.saleLines = saleLines;
            this.summaryNo = summaryNo;
            this.name = name;
            this.cardDeduction = cardDeduction;
            this.totalRetAmt = totalRetAmt;
            this.balance = balance;
        }
        string reference = "";
        public SaleInvoice(int saleid, DateTime saledate, Boolean pending, Customer party, double invdisc, Int64 crcid, double crcamt, double cashamt, double total, double totaldisc, List<SaleInvoiceLine> saleLines, Int64 summaryNo, string name, double cardDeduction, double totalRetAmt, double balance,/*bool isgst ,*/string reference)
        {
            this.saledate = saledate;
            this.saleid = saleid;
            this.reference = reference;
            this.pending = pending;
            this.party = party;
            this.crcid = crcid;
            this.crcamt = crcamt;
            this.cashamt = cashamt;
            this.total = total;
            this.invdisc = invdisc;
            this.totaldisc = totaldisc;
            this.saleLines = saleLines;
            this.summaryNo = summaryNo;
            this.name = name;
            this.cardDeduction = cardDeduction;
            this.totalRetAmt = totalRetAmt;
            this.balance = balance;
          //  this.IsGST = isgst;
        }
        //Properties.
        public int SaleID
        {
            get { return saleid; }
            set { saleid = value; }
        }
        public DateTime Saledate
        {
            get { return saledate; }
            set { saledate = value; }
        }
        //private string partyid;
        //private string partyname;
        //private string username;
        //private string bankacc;
        //private string cardno;
        public string PartyID
        {
            get { return partyid; }
            set { partyid = value; }
        }
        public string PartyName
        {
            get { return partyname; }
            set { partyname = value; }
        }

        public double Total
        {
            get { return total; }
            set { total = value; }
        }
        public string CardNo
        {
            get { return cardno; }
            set { cardno = value; }
        }
        public string UserName
        {
            get { return username; }
            set { username = value; }
        }
        public string BankAcc
        {
            get { return bankacc; }
            set { bankacc = value; }
        }

        public DateTime SDateTime
        {
            get { return sDateTime; }
            set { sDateTime = value; }
        }
        public Boolean Pending
        {
            get { return pending; }
            set { pending = value; }
        }

        public Customer Party
        {
            get { return party; }
            set { party = value; }
        }
        public double Invdisc
        {
            get { return invdisc; }
            set { invdisc = value; }
        }

        public bool IsGST { get; set; }
        public Int64 Crcid
        {
            get { return crcid; }
            set { crcid = value; }
        }

        public double Crcamt
        {
            get { return crcamt; }
            set { crcamt = value; }
        }
        public double CardDeduction
        {
            get { return cardDeduction; }
            set { cardDeduction = value; }
        }
        public double Cashamt
        {
            get { return cashamt; }
            set { cashamt = value; }
        }

       

        public double Totaldisc
        {
            get { return totaldisc; }
            set { totaldisc = value; }
        }
        public List<SaleInvoiceLine> SaleLines
        {
            get { return saleLines; }
            set { saleLines = value; }
        }
        public Int64 SummaryNo
        {
            get { return summaryNo; }
            set { summaryNo = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }
        public string CustomerCell
        {
            get { return customerCell; }
            set { customerCell = value; }
        }
        public double TotalRetAmt
        {
            get { return totalRetAmt; }
            set { totalRetAmt = value; }
        }
        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }
        public bool IsFinalInvoice
        {
            get { return isFinalInvoice; }
            set { isFinalInvoice = value; }
        }
    }
}
