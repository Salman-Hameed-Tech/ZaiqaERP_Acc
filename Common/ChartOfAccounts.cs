using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class ChartOfAccounts
    {
        //Fields.
        private string accountNo;
        private string accountName;
        private AccountType accountType;
        private int accountDepth;
        private string narration;
        private ChartOfAccounts parentAccount;
        private ChartOfAccounts partyAccount;
        private decimal openingDebit;
        private decimal openingCredit;
        private decimal adjustedDebit;
        private decimal adjustedCredit;
        private bool isDetailed;
        private bool isLocked;
        private bool isEditable;
        private bool isPosted;
        private bool balFlag;
        private string plFlag;
        private bool expFlag;

        private decimal dr;
        private decimal cr;
        private bool isDeleted;
        private string grvAccountno;
        private string grvaccname;


        public List<Branch> Branches = new List<Branch>();

        public List<ChartOfAccounts> coaList = new List<ChartOfAccounts>();
        public int  InvoiceNo { get; set; }

        //Constructors.
        public ChartOfAccounts()
        { 
        
        }
        public ChartOfAccounts(string  accountNo,string accountName):this()
        {
            this.AccountNo = accountNo;
            this.AccountName = accountName;                                                
        }

        public ChartOfAccounts(string accountNo, string accountName,string narration, decimal dr, decimal cr, bool isDeleted): this()
        {
            this.accountNo = accountNo;
            this.accountName = accountName;
            this.narration = narration;
            this.dr = dr;
            this.cr = cr;
            this.isDeleted = isDeleted;
        }

        public ChartOfAccounts(string accountNo, string accountName, AccountType accountType, int accountDepth, string narration, 
            ChartOfAccounts parentAccount, decimal openingDebit, decimal openingCredit, decimal adjustedDebit, decimal adjustedCredit,
            bool isDetailed, bool isLocked, bool isEditable, bool isPosted, bool balFlag, string plFlag, bool expFlagst):this()
        {
            this.AccountNo = accountNo;
            this.AccountName = accountName;
            this.AccountType = accountType;
            this.accountDepth  = accountDepth;
            this.narration = narration;
            this.parentAccount = parentAccount;
            this.openingDebit = openingDebit;
            this.openingCredit = openingCredit;
            this.adjustedDebit = adjustedDebit;
            this.adjustedCredit = adjustedCredit;
            this.isDetailed = isDetailed;
            this.isLocked = isLocked;
            this.isEditable = isEditable;
            this.isPosted = isPosted;
            this.balFlag = balFlag;
            this.plFlag = plFlag;
            this.expFlag = expFlag;
          
        }
        
        

        //Properties.
        
       
        public string  AccountNo
        {
            get { return accountNo; }
            set { accountNo = value; }
        }    
        public string AccountName
        {
            get { return accountName; }
            set { accountName = value; }
        }
        public AccountType AccountType
        {
            get { return accountType; }
            set { this.accountType = value; }
        }
        public int AccountDepth
        {
            get { return accountDepth; }
            set { accountDepth = value; }
        }
        public string Narration
        {
            get { return narration; }
            set { narration = value; }
        }
        public ChartOfAccounts ParentAccount
        {
            get { return parentAccount; }
            set { parentAccount = value; }
        }
        public ChartOfAccounts PartyAccount 
        {
            get { return partyAccount; }
            set { partyAccount = value; }
        }
        public decimal OpeningDebit
        {
            get { return openingDebit; }
            set { openingDebit = value; }
        }
        public decimal OpeningCredit
        {
            get { return openingCredit; }
            set { openingCredit = value; }
        }
        public decimal AdjustedDebit
        {
            get { return adjustedDebit; }
            set { adjustedDebit = value; }
        }
        public decimal AdjustedCredit
        {
            get { return adjustedCredit; }
            set { adjustedCredit = value; }
        }
        public bool IsDetailed
        {
            get { return isDetailed; }
            set { isDetailed = value; }
        }
        public bool IsLocked
        {
            get { return isLocked; }
            set { isLocked = value; }
        }
        public bool IsEditable
        {
            get { return isEditable; }
            set { isEditable = value; }
        }
        public bool IsPosted
        {
            get { return isPosted; }
            set { isPosted = value; }
        }
        public bool BalFlag
        {
            get { return balFlag; }
            set { balFlag = value; }
        }
        public string PlFlag
        {
            get { return plFlag; }
            set { plFlag = value; }
        }
        public bool ExpFlag
        {
            get { return expFlag; }
            set { expFlag = value; }
        }

        public bool IsDeleted
        {
            get { return isDeleted; }
            set { isDeleted = value; }
        }

        

        public decimal Dr
        {
            get { return dr; }
            set { dr = value; }
        }
        public decimal Cr
        {
            get { return cr; }
            set { cr = value; }
        }
        public string GRVAccount
        {
            get { return grvAccountno; }
            set { grvAccountno = value; }
        }
        public string GRVAccountName
        {
            get { return grvaccname; }
            set { grvaccname = value; }
        }

        public Prefix Prefix { get; set; }
        public decimal PreviousBalance { get; set; }
        public string Chqno { get; set; }
        public DateTime VoucherDate { get; set; }
        //Methods.
        public override string ToString()
        {
            return this.AccountName ;
        }
        //public override bool Equals(object obj)
        //{           
        //    return ((ChartOfAccounts)obj).accountNo == this.accountNo;
        //}
    }
}
