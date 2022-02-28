using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Common;

namespace CategoryControlle
{
    public class WastageReturnController
    {
        PurchaseReturnDAL pDal = new PurchaseReturnDAL();
        List<PurchaseReturn> purchaseReturns = new List<PurchaseReturn>();

        WastageReturnDAL wDal = new WastageReturnDAL();
        List<WastageReturn> wastageReturns = new List<WastageReturn>();

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
            int pid = 0;
            pid = pDal.CheckExisting(p);
            if (pid > 0)
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

                purchaseReturns = pDal.GetPurchaseReturns();
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

        public List<WastageReturn> GetWastageReturns(string Type)
        {
            try
            {
                if (wastageReturns == null) wastageReturns = new List<WastageReturn>();

                wastageReturns = wDal.GetWastageReturns(Type);
                return wastageReturns;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<WastageReturn> GetWastageReturns(int p)
        {
            throw new NotImplementedException();
        }

        public bool DeleteWastageReturn(WastageReturn wastageReturn)
        {
            try
            {
                wDal.DeleteWastageReturn(wastageReturn);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}