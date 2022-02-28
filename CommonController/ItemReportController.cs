using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using DAL;

namespace CategoryControlle
{
    public class ItemReportController
    {
        public bool GetHotItems(ref Common.Data_Sets.DSCurrentStock ds, string fromDate, string toDate, int level, string where, string itemFilter)
        {
            try
            {
                return new ItemReportDAL().GetHotItems(ref ds, fromDate, toDate, level, where, itemFilter);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public bool GetColdItems(ref Common.Data_Sets.DSCurrentStock ds, string fromDate, string toDate, int level)
        {
            try
            {
                return new ItemReportDAL().GetColdItems(ref ds, fromDate, toDate, level);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
