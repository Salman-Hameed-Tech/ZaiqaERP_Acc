using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.Data_Sets;

namespace CommonController
{
    public class SaleInvoiceBakeryController
    {
        public int Save(SaleInvoiceBakery invoice, bool isNew)
        {
            return new DAL.SaleInvoiceBakeryDAL().Save(invoice,isNew);
        }

        public string GetMaxID()
        {
            return new DAL.SaleInvoiceBakeryDAL().GetMaxID();
        }

        public bool GetReportData(ref DSaleInvoiceBakery dSaleInvoiceBakery, int vID)
        {

            return new DAL.SaleInvoiceBakeryDAL().GetReportData(ref dSaleInvoiceBakery, vID);
        }
    }
}
