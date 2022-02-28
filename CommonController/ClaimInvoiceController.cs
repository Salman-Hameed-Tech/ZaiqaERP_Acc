using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Common;
using Common.Data_Sets;

namespace CommonController
{
    public  class ClaimInvoiceController
    {
        //public bool SearchPrices(ref Common.Data_Sets.DsSearchPrices ds, ClaimInvoiceType priceFor, string partyID, int itemID)
        //{
        //    return new ClaimInvoiceDAL().SearchPrices(ref ds,priceFor,partyID ,itemID );
        //}

        public decimal GetQuantity(int ItemID, int InvoiceNo)
        {
            return new ClaimInvoiceDAL().GetQuantity(ItemID, InvoiceNo);
        }
        public int GetMaximumID(ClaimInvoiceType type)
        {
            return new ClaimInvoiceDAL().GetMaximumID(type);
        }

        public bool DeleteClaim(int VID, ClaimInvoiceType type)
        {
            return new ClaimInvoiceDAL().DeleteClaim(VID, type);
        }

        public int SaveClaim(ClaimInvoice claim, bool isNew)
        {
            return new ClaimInvoiceDAL().SaveClaim(claim, isNew);
        }

        public List<ClaimInvoice> GetClaims(int id, ClaimInvoiceType type)
        {
            return new ClaimInvoiceDAL().GetClaims(id, type);
        }

        public bool GetReportData(ref DSClaim ds,string where, ClaimInvoiceType invoiceType)
        {
            return new DAL.ClaimInvoiceDAL().GetReportData(ref  ds, where, invoiceType);
        }

        //public bool GetData(ref Common.Data_Sets.DSClaim ds, string where)
        //{
        //    return new ClaimInvoiceDAL().GetData (ref ds, where);
        //}


    }
}
