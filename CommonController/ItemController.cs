
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Common;
using Common.Data_Sets;
using DAL;


namespace CategoryControlle
{
   public  class ItemController
    {
           private List<Item> items=new List<Item> ();
           private List<string> companyNames = new List<string>();
           private List<string> productNames = new List<string>();
           private List<string> designs = new List<string>();
           private List<string> sizes = new List<string>();

           private ItemDAL iDAL = new ItemDAL();
        public string ItemPrice(int Itemid,int BranchID)
        {
            return new ItemDAL().ItemPrice(Itemid, BranchID);  
        }
        public Boolean DeleteItem(Int32 vid)
           {
               try
               {

               
               ItemDAL iDal = new ItemDAL();
               return (iDal.DeleteItem(vid));
               }
               catch (Exception)
               {

                   throw;
               }
           }

        public List<Barcodes> GetbarcodeTitle()
        {
            return new DAL.ItemDAL().GetbarcodeTitle();
        }

        public string GetMaxTitleID()
        {
            return new DAL.ItemDAL().GetMaxTitleID();
        }

        public List<SchItems> GetMarinatedIems(string condition)
        {
            return new DAL.ItemDAL().GetMarinatedItems(condition);
        }

        public bool SaveBarocdeTitle(Barcodes common, bool isNew)
        {
            return new DAL.ItemDAL().SaveBarocdeTitle( common,  isNew);
        }

        public List<string> GetNames(string select)
        {
            return new ItemDAL().GetNames(select);
        }
        public Item  PrintSticker(int itemid)
           { 
               return (iDAL.PrintSticker (itemid ));
           
           }

        public bool DetelteBracodeTitle(int id)
        {
            return new DAL.ItemDAL().DetelteBracodeTitle(id);
        }

        public List<Item> GetItems(string Cat)
            {
                if (items  == null) items  = new List<Item >();

                //todo from database 
                items = iDAL.GetItems(Cat);         
                return items ;
            }

            public List<string> GetCompanyNames(int cat,bool i)
            {
                if (companyNames  == null) companyNames  = new List<string >();

                //todo from database 
                companyNames = iDAL.GetCompanyNames(cat,i);
                
                return companyNames ;
            }
            public List<string> GetProductNames(string company,bool i)
            {
                if (productNames == null) productNames = new List<string>();

                //todo from database 
                productNames = iDAL.GetProductNames(company,i);
                return productNames ;
            }

            public List<string> GetDesigns(string product,string company,bool i)
            {
                if (designs  == null) designs  = new List<string>();

                //todo from database 
                designs = iDAL.GetDesigns(product,company,i);
                return designs ;
            }
            
            public List<string> GetSizes(string design,string product,string company,bool i)
            {
                if (sizes  == null) sizes  = new List<string>();

                //todo from database 
                sizes = iDAL.GetSizes(design,product,company,i);
                return sizes ;
            }
            public int MaxID()
            {
                return iDAL.MaxID();
            }
            public List<Barcode> LoadBarcode(int id)
            {
                try
                {
                    return (iDAL.LoadBarcodes(id));
                }
                catch (Exception)
                {
                    
                    throw;
                }
            }
        public DataSet GetReportData(int ID)
        {
            return new ItemDAL().GetReportData(ID);
        }
        public Item GetSingleItem(int id, StockType stockType, string PartyID, string Category)
        {
            return new ItemDAL().GetSingleItem(id, stockType, PartyID, Category);
        }
        public List<Item> EditModule(int id,int BranchId)
            {
                try
                {

                
                return iDAL.EditModule(id, BranchId);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            public Boolean ChkShortkey(string shortkey)
            {
                if (iDAL.ChkShortkey(shortkey))
                    return true;
                else
                    return false;
            }

            public Item GetItemDetail(int ItemID)
            {
                return new ItemDAL().GetItemDetail(ItemID);
            }
        
        public Item GetSingleItem(int id, StockType stockType, int storeID)
        {
            return new ItemDAL().GetSingleItem(id, stockType, storeID);
        }

        public DataSet GetTitle()
        {
            return new DAL.ItemDAL().GetTitle();
        }

        public Boolean SaveItem(Item i,List <Barcode> barcodes)
            {
                try
                {

                   
                if (iDAL.SaveItem(i,barcodes ))
                    return true;
                else
                    return false;
                }
                catch (Exception)
                {

                    throw;
                }
            }
       
        public Boolean VerifyBarcodes(string barcode)
            {
                try
                {
                    if (iDAL.verifyBarcode(barcode))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception)
                {

                    throw;
                }

            }

            public List<Item> GetStockReportItems(string where)
            {
                try
                {
                    return new ItemDAL().GetStockReportItems(where);
                }
                catch (Exception ex)
                {                    
                    throw ex;
                }
            }

        public DataSet GetProductName()
        {
            return new DAL.ItemDAL().GetProductName();
        }

        public List<Item> GetReOrderReportItems(string where)
            {
                try
                {
                    return new ItemDAL().GetReOrderReportItems(where);
                }
                catch (Exception ex)
                {                    
                    throw ex;
                }
            }

            public List<Item> GetReprintItems()
            {
                try
                {
                    return new ItemDAL().GetReprintItems();
                }
                catch (Exception ex)
                {                    
                    throw ex;
                }
            }

        public Barcodes GetSinglebarcodeTitle(int id)
        {
            return new DAL.ItemDAL().GetSinglebarcodeTitle( id);
        }

        public bool UpdatePrintStatus(int it)
            {
                try
                {
                    return new ItemDAL().UpdatePrintStatus(it);
                }
                catch (Exception ex)
                {                    
                    throw ex;
                }
            }

        public List<StockDifferenceSP> GetStockItems(int branchid)
        {
            return new DAL.ItemDAL().GetStockItems(branchid);
        }

        public decimal GetDiscountOffer(int ItemID)
            {
                try
                {
                    return new ItemDAL().GetDiscountOffer(ItemID);
                }
                catch (Exception ex)
                {                    
                    throw ex;
                }
            }

        public string GetDapartment(int CategoryID)
        {
            return new DAL.ItemDAL().GetDepartment(CategoryID);
        }
        public Int32 GetDapartmentid(string Department)
        {
            return new DAL.ItemDAL().GetDapartmentid(Department);
        }
        public bool GetProfitLose(ref Common.Data_Sets.DSProfitLose ds, string where)
        {
            return new ItemDAL().GetProfitLose(ref ds, where);
        }

        public void SaveBarcodeTitle(string x)
        {
            new DAL.ItemDAL().SaveBarcodeTitle(x);
        }

        //public Item GetChallanItem(string v1, string v2)
        //{

        //}
        public Item GetChallanItem(string id, string type,int BranchID)
        {
            return new ItemDAL().GetChallanItem(id, type , BranchID );
        }

        public DataSet GetBarcodes(string where)
        {
            return new DAL.ItemDAL().GetBarcodes(where);
        }

        public List<DiscountOffer> GetSeletedBarcodes(List<Category> cat)
        {
            return new DAL.ItemDAL().GetSeletedBarcodes(cat);
        }

        public string GetItemName(string barcode)
        {
            return new DAL.ItemDAL().GetItemName( barcode);
        }

        public bool GetItemsList(ref DSItems dSItems, string categoryid)
        {
            return new DAL.ItemDAL().GetItemsList(ref dSItems, categoryid);
        }

        public Item GetRecipieItem(int itemid)
        {
            return new DAL.ItemDAL().GetRecipieItem( itemid);
        }
    }
}
