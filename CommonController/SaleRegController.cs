using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace CategoryControlle
{
    public class  SaleRegController
    {
        public bool GetData(ref Common.Data_Sets.DSSaleRegister ds, string where)
        {
            try
            {
                return new SaleRegisterDAL().GetData(ref ds, where);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool GetDailyProfit(ref Common.Data_Sets.DSDailyProfit ds, string where)
        {
            try
            {
                return new SaleRegisterDAL().GetDailyProfit(ref ds, where);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int GetDiscount(string where)
        {
            return new SaleRegisterDAL().GetDiscount(where);
        }
    }
}
