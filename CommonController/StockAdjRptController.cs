using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace CategoryControlle
{
    public class StockAdjRptController
    {
        public bool GetData(ref Common.Data_Sets.DSStockAdj ds, int itemID, string fromDate, string toDate)
        {
            try
            {
                return new StockAdjRptDAL().GetData(ref ds, itemID, fromDate, toDate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
