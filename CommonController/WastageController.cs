using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Common;
using System.Data;

namespace CategoryControlle
{
    public class WastageController
    {
        WastageDAL wDal = new WastageDAL();
        List<Wastage> wastages = new List<Wastage>();

        PurchaseDAL pDal = new PurchaseDAL();
        List<Purchase> purchases = new List<Purchase>();
            
        public int GetMaximumID()
        {
            try
            {
                return wDal.GetMaximumID();
            }
            catch (Exception ex)
            {                
                throw;
            }            
        }

        public int CheckReturn(int p)
        {
            int pid = 0;
            pid = wDal.CheckReturn(p);
            if (pid > 0)
                return pid;
            else
                return 0;
        }
        public List<WastageLine> GetWastagesline(int id)
        {
            return new WastageDAL().GetWastagesline(id);
        }
        //public bool DeletePurchase(Purchase p)
        //{
        //    try
        //    {
        //        pDal.DeletePurchase(p);
        //        return true;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        public bool DeleteWastage(int id)
        {
            try
            {
                wDal.DeleteWastage(id);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Purchase> GetPurhcases()
        {
            try
            {
                if (purchases == null) purchases = new List<Purchase>();

                purchases = pDal.GetPurchases();
                return purchases;
            }
            catch (Exception ex)
            {                
                throw;
            }            
        }
        public List<Wastage> GetWastageData(int id, string where)
        {
            return new DAL.WastageDAL().GetWastageData(id, where);
        }
        public Purchase GetSinglePurchase(int purchaseID)
        {

            try
            {
                return pDal.GetSinglePurchase(purchaseID);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
        public List<PurchaseLine> VerifyItem(string id, string type)
        {
            return new PurchaseDAL().VerifyItem(id, type,0,"");
        }
        public List<Purchase> GetPurchasesForReport(string wPurchaseBody, string wPurchase)
        {
            try
            {
                return new PurchaseDAL().GetPurchasesForReport(wPurchaseBody,wPurchase);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
        public List<Purchase> GetReprintItems()
        {
            try
            {
                return new PurchaseDAL().GetReprintItems();
            }
            catch (Exception ex)
            {                
                throw ex; 
            }
        }
        public bool UpdatePrintStatus(int p)
        {
            try
            {
                return new PurchaseDAL().UpdatePrintStatus(p);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
        public void SaveWastage(SaleReturn saleReturn, Wastage wastage, bool isNew)
        {
            try
            {
                wDal.SaveWastage(saleReturn, wastage, isNew);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool LoadWasRegister(DataSet ds)
        {
            return new DAL.WastageDAL().LoadWasRegister(ds);
        }
    }
}
