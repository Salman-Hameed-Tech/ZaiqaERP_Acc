using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using DAL;

namespace CategoryControlle
{
    public class VendorController
    {
        private List<Vendor> vendors = new List<Vendor>();
        private Vendor v = new Vendor();

        public bool SaveParty(Vendor v, ChartOfAccounts acc, bool isNew,string type)
        {
            return new VendorDAL().SaveParty(v,acc,isNew,type);
        }
        public Vendor GetPartyDetail(string accountNo)
        { 
            return new VendorDAL ().GetPartyDetail(accountNo);
        }
        public bool DeleteParty(string accountNo)
        {
            return new VendorDAL().DeleteParty(accountNo);
        }
       
    }
}
