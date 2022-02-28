using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.Data_Sets;

namespace CommonController
{
    public class WholesaleController
    {
        public string GetMaximumID()
        {
           return new DAL.WholesaleDAL().GetMaximumID();
        }

        public List<WholeSaleLines> VerifyItem(string id, string type)
        {
            return new DAL.WholesaleDAL().VerifyItem(id, type);
        }

        public List<WholeSaleLines> VerifyAllItem(string id, string type)
        {
            return new DAL.WholesaleDAL().VerifyAllItem( id,  type);
        }

        public int Save(WholeSale sale,bool isnew)
        {
            return new DAL.WholesaleDAL().Save(sale,isnew);
        }

        public List<WholeSale> GetWSale()
        {
            return new DAL.WholesaleDAL().GetWSale();
        }

        public bool GetReportData(ref DSWholeSale dSSale, DateTime dated, int vID)
        {
            return new DAL.WholesaleDAL().GetReportData(ref  dSSale,  dated,  vID);
        }

        public WholeSale GetSingleWSale(int id,DateTime date)
        {
            return new DAL.WholesaleDAL().GetSingleWSale(id, date);
        }

        public bool GetWSData(ref DSWholeSale dSWhole, string where)
        {
            return new DAL.WholesaleDAL().GetWSData(ref  dSWhole,  where);
        }
    }
}
