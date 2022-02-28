using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace CategoryControlle
{
    public class CurrentStockController
    {
        public bool GetData(ref Common.Data_Sets.DSCurrentStock ds, string where)
        {
            try
            {
                return new CurrentStockDAL().GetData(ref ds,where);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
