using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Common;

namespace CommonController
{
    public class OpeningStockController
    {
        public bool SaveOpeningStock(List<OpeningStockLine> stockLine, bool isnew)
        {
            return new OpeningStockDAL().SaveOpeningStock(stockLine, isnew);
        }

        public List<OpeningStockLine> LoadGrid()
        {
            return new OpeningStockDAL().LoadGrid();
        }

        public List<OpeningStockLine> GetSingleOpeningStock( DateTime dateTime)
        {
            return new OpeningStockDAL().GetSingleOpeningStock( dateTime);
        }

        public bool DeleteOpeningStock(int itemid, DateTime date)
        {
            return new OpeningStockDAL().DeleteOpeningStock(itemid, date);
        }

        public string GetMaxID()
        {
            return new DAL.OpeningStockDAL().GetMaxID();
        }
    }
}
