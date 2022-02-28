using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Data_Sets;
using DAL;

namespace CategoryControlle
{
    public class PurchaseRegController
    {

        public bool GetReturnData(ref Common.Data_Sets.DSPurchaseReturn ds, string where)
        {
            try
            {
                //return new PurchaseRegDAL().GetData(ref ds, where);
                return new PurchaseRegDAL().GetReturnData(ref ds, where);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    
        public bool GetData(ref Common.Data_Sets.DSPurchaseInvoice ds, string where)
        {
            try
            {
                return new PurchaseRegDAL().GetData(ref ds, where);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GetVWInventory(ref DSVendorWInventory dSVendorWInventory, string partyid)
        {
            return new DAL.PurchaseDAL().GetVWInventory(ref dSVendorWInventory, partyid);
        }
    }
}
