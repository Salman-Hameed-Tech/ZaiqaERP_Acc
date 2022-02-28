using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Common;
using Common.Data_Sets;
using DAL;

namespace CategoryControlle
{
    public class SummaryController
    {
        public int MakeSummary(int userID)
        {
            try
            {
                return new SummaryDAL().MakeSummary(userID);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public DataSet GetSummaries(int userID,string date)
        {
            try
            {
                return new SummaryDAL().GetSummaries(userID,date);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public int GetSummaryNo(int userid)
        {
            return new DAL.SummaryDAL().GetSummaryNo(userid);
        }

        public bool UpdateSummary(Int64 SummaryNo)
        {
            try
            {
                return new SummaryDAL().UpdateSummary(SummaryNo);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public Summary GetSummaryDetail(int UserID)
        {
            try
            {
                return new SummaryDAL().GetSummaryDetail(UserID);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public string GetOpeningCash(string shift, int baranchid,DateTime date)
        {
            return new DAL.SummaryDAL().GetOpeningCash(shift,  baranchid,date);
        }

        public Summary GetSummary(int summaryno,int branchid)
        {
            return new DAL.SummaryDAL().GetSummary(summaryno, branchid);
        }

        public bool UpdateSummary(Summary sum)
        {
            try
            {
                return new SummaryDAL().UpdateSummary(sum);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public bool SaveCash(Summary sum)
        {
            return new DAL.SummaryDAL().SaveCash( sum);
        }

        public bool GetPettyCashData(ref DSPettyCash dSPetty, int summaryID)
        {
            return new DAL.SummaryDAL().GetPettyCashData(ref  dSPetty,  summaryID);
        }

        public Summary GetUser(int userNo)
        {
            return new DAL.SummaryDAL().GetUser( userNo);
        }

        public SaleInvoice GetSaleInvoie(int saleid, string saledate, int branchid)
        {
            return new DAL.SummaryDAL().GetSaleInvoie( saleid,  saledate,  branchid);
        }

        public bool GetSCCSummary(ref DSPettyCash dSPetty, DateTime fromDate, DateTime toDate, int branchid)
        {
            return new DAL.SummaryDAL().GetSCCSummary(ref  dSPetty,  fromDate,  toDate,  branchid);
        }
    }
}
