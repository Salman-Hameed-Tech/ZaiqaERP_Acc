using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class Voucher
    {
        //Fields.
        private int voucherNo;
        private int preVoucherNo;
        private DateTime voucherDate;
        private DateTime preVoucherDate;        
        private VoucherType voucherType;
        private VoucherPDC voucherTypee;
        private List<ChartOfAccounts> accounts;
        private List<ChequeClearance> acc;
        private ChartOfAccounts bankAccNo;
        private ChartOfAccounts accountdtl;
        private DateTime checkDate;
        private string checkNo;
        private Int32 debit;
        private Int32 credit;
        private string narration;
        private TransactionFlow flow;
        private bool ispostdated;
        private User user;
        private bool isclosed;
        private Int64 summaryNo;
        private int branchID;
        private string branchname;
        private string bankname;
        private int prevbranchid;





        public static string Condition;

        //Constructors.
        public Voucher()
        {         
                     
        }

        public Voucher(int voucherNo,DateTime voucherDate,VoucherType voucherType,List<ChartOfAccounts> accounts,User user,ChartOfAccounts bankAccNo )
        {
            this.voucherNo = voucherNo;
            this.voucherDate = voucherDate;
            this.voucherType = voucherType;
            this.accounts = accounts;
            this.BankAccNo = bankAccNo;
            this.user = user;
            
        }

        //Properties.branchname
        public int VoucherNo
        {
            get { return voucherNo; }
            set { voucherNo = value; }
        }
        public Int64 SummaryNo
        {
            get { return summaryNo; }
            set { summaryNo = value; }
        }
        public int PreVoucherNo
        {
            get { return preVoucherNo; }
            set { preVoucherNo = value; }
        }
        public int PrevBranchID
        {
            get { return prevbranchid; }
            set { prevbranchid = value; }
        }
        public DateTime VoucherDate
        {
            get { return voucherDate; }
            set { voucherDate = value; }
        }
        public string BranchName
        {
            get { return branchname; }
            set { branchname = value; }
        }
        public int BranchID
        {
            get { return branchID; }
            set { branchID = value; }
        }

        public DateTime PreVoucherDate
        {
            get { return preVoucherDate; }
            set { preVoucherDate = value; }
        }
        public User User
        {
            get { return user; }
            set { user = value; }
        }       
     
        public VoucherType VoucherType
        {
            get { return voucherType; }
            set { voucherType = value;}
        }
        public VoucherPDC VoucherTypee 
        {
            get { return voucherTypee; }
            set { voucherTypee = value; }
        }
        public string vtype { get; set; }
        public List<ChartOfAccounts> Accounts
        {
            get { return accounts; }
            set { accounts = value; }
        }
        public List<ChequeClearance> Accountss
        {
            get { return acc; } 
            set { acc = value; }
        }
        public ChartOfAccounts BankAccNo
        {
            get { return bankAccNo; }
            set { bankAccNo = value; }
        }

        public ChartOfAccounts accountsdetail
        {
            get { return accountdtl; }
            set { accountdtl = value; }
        }
        public DateTime CheckDate
        {
            get { return checkDate; }
            set { checkDate = value; }
        }
        public string CheckNo
        {
            get { return checkNo; }
            set { checkNo = value; }
        }
        public Int32 Debit
        {
            get { return debit; }
            set { debit = value; }
        }
        public Int32 Credit
        {
            get { return credit; }
            set { credit = value; }
        }
        public string Narration
        {
            get { return narration; }
            set { narration = value; }
        }
        public TransactionFlow Flow
        {
            get { return flow; }
            set { flow = value; }
        }
        public bool isPostDated
        {
            get { return ispostdated; }
            set { ispostdated = value; }
        }
        public bool Isclosed
        {
            get { return isclosed; }
            set { isclosed = value; }
        }
       

        public string BankName
        {
            get { return bankname; }
            set { bankname = value; }
        }

        public string VoucherString { get; set; }
        public bool IsPrinted { get; set; }
        public bool IsSubmitted { get; set; } 

        public string  Reason { get; set; }


        public override string ToString()
        {            
            string bankCode = "";
            string sVoucherNo = "";

            if (BankAccNo.AccountNo .Length   != 0)
            {
                bankCode = BankAccNo .AccountNo.ToString().Substring(4, 2);
            }
            else
            {
                bankCode = "00";
            }

            sVoucherNo = voucherType.ToString() + "-" + bankCode + "-" + voucherDate.Date.ToString("MMM").ToUpper() + "-" + voucherNo .ToString ();
            
            return sVoucherNo;
        }
    }
}
