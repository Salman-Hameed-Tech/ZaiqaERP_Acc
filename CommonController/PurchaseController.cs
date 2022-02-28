using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Common;
using System.Data;

namespace CategoryControlle
{
    public class PurchaseController
    {
        PurchaseDAL pDal = new PurchaseDAL();
        List<Purchase> purchases = new List<Purchase>();

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
        public int VerifyItem(string id)
        {
            return new PurchaseDAL().VerifyItem(id);
        }
        public decimal VerifyQTY(string id)
        {
            return new PurchaseDAL().VerifyQty(id);
        }
        public int CheckReturn(int p)
        {
            int pid = 0;
            pid = pDal.CheckReturn(p);
            if (pid > 0)
                return pid;
            else
                return 0;
        }

        public List<PurchaseInvoice> GetPurchaseInvoice(int itemId, int invoiceNo)
        {
            return new DAL.PurchaseDAL().GetPurchaseInvoice( itemId,  invoiceNo);
        }

        public int SavePurchase(Purchase p,bool nu)
        {
            try
            {
                return new DAL.PurchaseDAL().SavePurchase(p,nu);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public bool DeletePurchase(Purchase p)
        {
            try
            {
                pDal.DeletePurchase(p);
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

        public List<PurchaseLine> VerifyItem(string id, string type,int Branchid,string partyid)
        {
            return new PurchaseDAL().VerifyItem(id, type, Branchid, partyid);
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

        public object GetPurchaseEdit(int v)
        {
            throw new NotImplementedException();
        }

        public bool GetReportData(ref Common.Data_Sets.DSPurchaseInvoice dS, int InvID)
        {
            return new DAL.PurchaseDAL().GetReportData(ref dS,InvID);
        }

        public List<Item> GetPrintedItems()
        {
            return new DAL.PurchaseDAL().GetPrintedItems();
        }

        public bool ClearPrintedInv()
        {
            return new DAL.PurchaseDAL().ClearPrintedInv();


        }

       
    }
}
