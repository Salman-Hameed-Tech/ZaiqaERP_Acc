using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class FixedAccounts
    {
        private String CashAcc;

        public String CashAcc1
        {
            get { return CashAcc; }
            set { CashAcc = value; }
        }
        private String PurRet;

        public String PurRet1
        {
            get { return PurRet; }
            set { PurRet = value; }
        }
        private String PurDisc;

        public String PurDisc1
        {
            get { return PurDisc; }
            set { PurDisc = value; }
        }
        private string SaleReturn;

        public string SaleReturn1
        {
            get { return SaleReturn; }
            set { SaleReturn = value; }
        }
        private String SaleDisc;

        public String SaleDisc1
        {
            get { return SaleDisc; }
            set { SaleDisc = value; }
        }

        private String transit;

        public String Transit
        {
            get { return transit; }
            set { transit = value; }
        }

    }
}
