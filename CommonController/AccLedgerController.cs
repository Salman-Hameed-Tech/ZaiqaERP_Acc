
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace CategoryControlle
{
    public class AccLedgerController
    {
        public bool GetData(ref Common.Data_Sets.DSAccLedger ds, string fromDate, string toDate, string accNo, int isPosted, int isPostDated,int branchid)
        {
            try
            {
                return new AccLedgerDAL().GetData(ref ds,fromDate,toDate,accNo, branchid);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public bool GetFundsFlow(ref Common.Data_Sets.DSFundsFlow ds, string fromDate, string toDate)
        {
            return new AccLedgerDAL().GetFundsFlow (ref ds, fromDate, toDate);
        }

        public bool GetGeneralData(ref Common.Data_Sets.DSAccLedger ds, string fromDate, string toDate, string voucherType,int branchid,string AccNo)
        {
            try
            {
                return new AccLedgerDAL().GetGeneralData(ref ds, fromDate, toDate, voucherType, branchid, AccNo);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
    }
}
