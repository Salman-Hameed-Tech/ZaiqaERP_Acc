using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Common
{
   public  class Globals
    {
       public static bool SaleDiscountColumnVisible = true ;
       public static bool PurchaseDiscountColumnVisible = true ;
       public static bool SaleTaxColumnVisisble = false  ;
       public static bool StoreColumnVisible = true    ;
       public static bool PackingColumnVisible = false  ;
       public static bool DescriptionColumnVisible = false  ;
       public static bool BarcodeColumnVisisble = false;
       public static bool AccountForEachItem = false;
       public static bool FormClosing_CheckOnEdit = true;

        public static int BranchID;
        public static int DepartmentID;
        public static bool IsCashCounter;
      

       public static string FormClosingMessage = "Close this form without saving?";
        public static string ReportPath = ReadProjectConfigFile.GetReportPath();



       public static string condition;

       public static string ClearingAgent = "6009";
       public static string BankAccountNo = "112";
       public static string Indenter = "6010";
       public static string ForeignSupplier = "61003";
       public static string LocalSupllier = "61004";
       public static string BuyerAccount = "6002";
       public static string PurchaseTranporter = "6008002";
       public static  string SaleTransporter = "60081";
       public static string SaleGroup = "4002";
       public static string PurchaseGroup = "11006";
       public static string LCAccountGroup = "11005";
       public static string LCExpenseGroup = "5008";
       public static string SalesManGroup = "6014";

       public static Boolean IDEditModeReadOnly = true ;
       public static Boolean IDNewModeReadOnly = false ;



       public static string NumberToText(Int64 n)
       {
           if (n < 0)
               return "Minus " + NumberToText(-n);
           else if (n == 0)
               return "";
           else if (n <= 19)
               return new string[] {"One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", 
         "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", 
         "Seventeen", "Eighteen", "Nineteen"}[n - 1] + " ";
           else if (n <= 99)
               return new string[] {"Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", 
         "Eighty", "Ninety"}[n / 10 - 2] + " " + NumberToText(n % 10);
           else if (n <= 199)
               return "One Hundred " + NumberToText(n % 100);
           else if (n <= 999)
               return NumberToText(n / 100) + "Hundred " + NumberToText(n % 100);
           else if (n <= 1999)
               return "One Thousand " + NumberToText(n % 1000);
           else if (n <= 999999)
               return NumberToText(n / 1000) + "Thousand " + NumberToText(n % 1000);
           else if (n <= 1999999)
               return "One Million " + NumberToText(n % 1000000);
           else if (n <= 999999999)
               return NumberToText(n / 1000000) + "Million " + NumberToText(n % 1000000);
           else if (n <= 1999999999)
               return "One Billion " + NumberToText(n % 1000000000);
           else
               return NumberToText(n / 1000000000) + "Billion " + NumberToText(n % 1000000000);
       }

    }
}
