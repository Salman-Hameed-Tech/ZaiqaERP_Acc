using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using DAL;

namespace CategoryControlle
{
    public class SchDiscOfferController
    {
        public List<SchDiscOffers> GetOffers(bool type)
        {
            try
            {
                return new SchDiscOfferDAL().GetOffers(type);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public List<SchDiscOffers> GetBarcodeOffers()
        {
            return new DAL.SchDiscOfferDAL().GetBarcodeOffers();
        }
    }
}
