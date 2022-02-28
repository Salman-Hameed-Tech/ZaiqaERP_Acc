using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using Common.Data_Sets;
using DAL;

namespace CategoryControlle
{
    public class DiscountOfferController
    {
        public bool CheckOffer(DiscountOffer DO, bool isNew)
        {
            try
            {
                return new DiscountOfferDAL().CheckOffer(DO,isNew);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public bool SaveOffer(DiscountOffer DO,bool isNew)
        {
            try
            {
                return new DiscountOfferDAL().SaveOffer(DO,isNew);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public DiscountOffer GetOfferDetail(int OfferID,bool isCategoryDisc)
        {
            try
            {
                return new DiscountOfferDAL().GetOfferDetail(OfferID);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public List<Branch> GetOfferBranches(int OfferID,bool isBarcodeDisc)
        {
            return new DAL.DiscountOfferDAL().GetOfferBranches(OfferID, isBarcodeDisc);
        }

        public bool DeleteOffer(int OfferID)
        {
            try
            {
                return new DiscountOfferDAL().DeleteOffer(OfferID);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public bool SavePassword(DiscountPassword common,bool isNew)
        {
            return new DAL.DiscountOfferDAL().SavePassword(common,isNew);


        }

        public int CheckExistedPwd(int v)
        {
            return new DAL.DiscountOfferDAL().CheckExistedPwd( v);
        }

        public bool GetOffers(ref DSOffers dSOffers,int brnachid,string FromDate,string ToDate)
        {
            return new DAL.DiscountOfferDAL().GetOffers(ref  dSOffers, brnachid,FromDate , ToDate   );
        }

        public bool SaveBracodeOffer(DiscountOffer dO, bool isNew)
        {
            return new DAL.DiscountOfferDAL().SaveBracodeOffer( dO,  isNew);
        }

        public List<DiscountOffer> GetBarcodeItems(int paraOutID, bool isCategoryDisc)
        {
            return new DAL.DiscountOfferDAL().GetBarcodeItems(paraOutID, isCategoryDisc);
        }

        public bool DeleteBarcode(int fileNo)
        {
            return new DAL.DiscountOfferDAL().DeleteBarcode( fileNo);
        }

        public bool GetItemsWithoutDiscount(ref DSItems dSItems, int brnachid)
        {
            return new DAL.DiscountOfferDAL().GetItemsWithoutDiscount(ref dSItems, brnachid);
        }

        public string GetMaxID()
        {
            return new DAL.DiscountOfferDAL().GetMaxID();
        }

        public string GetMaxFileNo()
        {
            return new DAL.DiscountOfferDAL().GetMaxFileNo();
        }

        public List<SchDiscOffers> GetDiscDetail(int fileNo)
        {
            return new DAL.SchDiscOfferDAL().GetDiscDetail(fileNo);
        }

        public bool CheckBarcodeOffer(DiscountOffer dO, bool isNew)
        {
            return new DAL.DiscountOfferDAL().CheckBarcodeOffer( dO,  isNew);
        }
    }
}
