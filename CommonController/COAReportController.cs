
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace CategoryControlle
{
    public class COAReportController
    {
        public bool GetTrialData(ref Common.Data_Sets.DSCOA ds, string fromDate, string toDate)
        {
            try
            {
                return new COAReportDAL().GetTrialData(ref ds, fromDate, toDate);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public bool GetTrialData(ref Common.Data_Sets.DSCOA ds, string fromDate, string toDate,string AccNo)
        {
            try
            {
                return new COAReportDAL().GetTrialData(ref ds, fromDate, toDate,AccNo );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool GetIncomeData(ref Common.Data_Sets.DSIncomeStatement ds, string fromDate, string toDate, bool IsIncomeStmntFirst)
        {
            try
            {
                return new COAReportDAL().GetIncomeData(ref ds, fromDate, toDate, IsIncomeStmntFirst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Set Inc Stmt
        public bool GetIncStmtData(ref System.Data.DataSet ds, string fromDate, string toDate)
        {
            try
            {
                return new COAReportDAL().GetIncStmtData (ref ds, fromDate, toDate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GetBalanceSheetData(ref Common.Data_Sets.DSBalanceSheet ds, string fromDate, string toDate)
        {
            try
            {
                return new COAReportDAL().GetBalanceSheetData(ref ds, fromDate, toDate);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public bool GetGroupBalances(ref Common.Data_Sets.DSGroupBalances ds, string fromDate, string toDate, string groupNo)
        {
            return new COAReportDAL().GetGroupBalances(ref ds, fromDate, toDate, groupNo);
        }


        public bool GetPayRecData(ref Common.Data_Sets.DSCOA ds, string fromDate, string toDate,string Type,bool level,int BranchID)
        {
            try
            {
                return new COAReportDAL().GetPayRecData(ref ds, fromDate, toDate,Type,level, BranchID  );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public bool GetSvcIncomeData(ref Common.Data_Sets.DSIncomeStatementService DsSvcIncStmnt, string fromDate, string toDate)
        //{
        //    try
        //    {
        //        return new COAReportDAL().GetSvcIncomeData(ref DsSvcIncStmnt, fromDate, toDate);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
