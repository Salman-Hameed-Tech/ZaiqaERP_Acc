using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using DAL;

namespace CategoryControlle
{
    public class GodownStockController
    {
        public bool GetData(ref Common.Data_Sets.DSGodownStock ds,  string where)
        {
            try
            {
                return new GodownStockDAL().GetData(ref ds, where);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
