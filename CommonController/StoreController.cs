using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using DAL;

namespace CategoryControlle
{
   public  class StoreController
    {
        public Int32 GetMaxID()
        {
            return new StoreDAL ().GetMaxID(); 
        }
        
        public Boolean SaveStore(Store  c, bool isNew)
        {
            return new StoreDAL ().SaveStore(c, isNew); 
        }

        public List<Store> GetItemStock(int id, StockType stockType)
        {
            return new StoreDAL().GetItemStock(id, stockType);
        }

        public List<Store > GetStores(int id)
        {
            return new StoreDAL ().GetStores(id,LoadStoresFor.All ,0);
        }

        public List<Store> GetStores(int id,LoadStoresFor loadFor,int DOID)
        {
            return new StoreDAL().GetStores(id,loadFor ,DOID );
        }

        public Boolean DeleteStore(Store  c)
        {
            return new StoreDAL ().DeleteStore(c);
        }

        public bool GetData(ref Common.Data_Sets.DSItemLedger ds, int itemID, string fromDate, string toDate, int storeID, bool isLoose)
        {
            return new StoreDAL().GetData(ref ds, itemID,fromDate ,toDate , storeID, isLoose); 
        }

        public bool GetData(ref Common.Data_Sets.DSStoreStockCT ds, string where)
        {
            return new StoreDAL().GetData(ref ds, where);
        }

        public bool GetData(ref Common.Data_Sets.DSGodownStock ds, string where)
        {
            try
            {
                return new StoreDAL().GetData(ref ds, where);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GetDataRaw(ref Common.Data_Sets.DSItemLedger ds, int itemID, string fromDate, string toDate, int storeID, bool isLoose)
        {
            return new StoreDAL().GetDataRaw(ref ds, itemID, fromDate, toDate, storeID, isLoose);
        }

        public bool GetdataFinish(ref Common.Data_Sets.DSGodownStock dsStoreStock, string where)
        {
            return new StoreDAL().GetDataFinish(dsStoreStock,where);
        }
    }

   

}
