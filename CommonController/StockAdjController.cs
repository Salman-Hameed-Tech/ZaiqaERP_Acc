using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Common;

namespace CategoryControlle
{
    public class StockAdjController
    {
        public List<StockAdj> GetItems(int Cat)
        {
            try
            {
                return new StockAdjDAL().GetItems(Cat);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public bool SaveAdjustment(StockAdj adj)
        {
            try
            {
                return new StockAdjDAL().SaveAdjustment(adj);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

    }
}
