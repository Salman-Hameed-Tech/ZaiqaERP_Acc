using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Common;
using System.Data;

namespace CategoryControlle
{
    public class PurchaseReturnController
    {
        PurchaseReturnDAL pDal = new PurchaseReturnDAL();
        List<PurchaseReturn> purchaseReturns = new List<PurchaseReturn>();

        public int GetMaximumID()
        {
            try
            {
                return pDal.GetMaximumID();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int CheckExisting(int p)
        {
            int pid=0;
            pid=pDal.CheckExisting(p);
            if (pid>0)
                return pid;
            else
                return 0;
        }

        public int SavePurchaseReturn(PurchaseReturn p, bool nu)
        {
            try
            {
               return pDal.SavePurchaseReturn(p, nu);
              
              
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeletePurchaseReturn(PurchaseReturn p)
        {
            try
            {
                pDal.DeletePurchaseReturn(p);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<PurchaseReturn> GetPurhcaseReturns()
        {
            try
            {
                if (purchaseReturns == null) purchaseReturns = new List<PurchaseReturn>();

                purchaseReturns = pDal.GetPurchaseReturns ();
                return purchaseReturns;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<PurchaseReturn> GetPReurnsForReport(string wPurchaseBody, string wPurchaseReturn)
        {
            try
            {
                return new PurchaseReturnDAL().GetPReurnsForReport(wPurchaseBody, wPurchaseReturn);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public bool GetPurchaseReturn(ref Common.Data_Sets.DSPurchaseReturn dSPurchaseReturn, int ClaimID)
        {
            return new PurchaseReturnDAL().GetPurchaseReturn(dSPurchaseReturn,ClaimID);
        }
    }
}