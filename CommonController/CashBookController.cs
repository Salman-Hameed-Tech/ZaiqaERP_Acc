using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace CategoryControlle
{
    public class CashBookController
    {
        public System.Data.DataSet GetRRegister(string FromDate, string ToDate)
        {
            return new CashBookDAL().GetRRegister(FromDate, ToDate);
        }
        public System.Data.DataSet GetStkBalance(string FromDate, string ToDate,string AccNo)
        {
            return new CashBookDAL().GetStkBalances(FromDate, ToDate, AccNo  );
        }
        public bool GetData(ref Common.Data_Sets.DSCashBook ds, string fromDate, string toDate, string procedureName, string VoucherType,int  Branchid)
        {
            try
            {
                return new CashBookDAL().GetData(ref ds, fromDate, toDate, procedureName, VoucherType,Branchid );
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
    }
}
