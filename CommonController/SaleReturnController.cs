using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DAL;
using Common;

namespace CategoryControlle
{
    public class SaleReturnController
    {
        SaleReturnDAL sDal = new SaleReturnDAL();
        List<SaleReturn> saleReturns = new List<SaleReturn>();

        public int GetMaximumID()
        {
            try
            {
                return sDal.GetMaximumID();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        
        public int CheckExisting(int p)
        {
            int pid=0;
            pid=sDal.CheckExisting(p);
            if (pid>0)
                return pid;
            else
                return 0;
        }
        
        public bool SavePurchaseReturn(SaleReturn p,bool isNew)
        {
            try
            {
                if (sDal.SaveSaleReturn(p))
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeletePurchaseReturn(SaleReturn p)
        {
            try
            {
                sDal.DeleteSaleReturn(p);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
       
        public List<SaleReturn> GetPurhcaseReturns(string where)
        {
            try
            {
                if (saleReturns == null) saleReturns = new List<SaleReturn>();

                saleReturns = sDal.GetSaleReturns(where);
                return saleReturns;
            }
            catch (Exception ex)
            {
                throw;
            }
        }       
    }
}
