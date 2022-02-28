using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
   public  class PDCVoucher
    {
       public VoucherPDC VoucherType { get; set; }
       public ChartOfAccounts PartyAccounts { get; set; }
       public ChartOfAccounts BankAccounts { get; set; }
       public DateTime VoucherDate { get; set; }
       public List<PDCVoucherBody> PDCVoucherLines { get; set; } 
       public Int32 VoucherNo { get; set; }
       public string VoucherString { get; set; }
       public DateTime PreVoucherDate { get; set; }



       public override string ToString()
       {
           string bankCode = "";
           string sVoucherNo = "";

           if (BankAccounts.AccountNo.Length != 0)
           {
               bankCode = BankAccounts.AccountNo.ToString().Substring(4, 2);
           }
           else
           {
               bankCode = "00";
           }

           sVoucherNo = VoucherType.ToString() + "-" + bankCode + "-" + VoucherDate.Date.ToString("MMM").ToUpper() + "-" + VoucherNo.ToString();

           return sVoucherNo;
       }

    }

}
