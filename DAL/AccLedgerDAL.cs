using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using Common;

namespace DAL
{
    public class AccLedgerDAL
    {
        private string source = ReadProjectConfigFile.ConfigString();
        SqlConnection con;
        SqlCommand cmd;

        SqlDataAdapter da = new SqlDataAdapter();

        public bool GetData(ref Common.Data_Sets.DSAccLedger ds, string fromDate, string toDate, string accNo,int branchid)
        {
            try
            {
                Object objFrom = fromDate;
                Object objTo = toDate;
                Object objAccNo= accNo;
                Object objbranchid = branchid;

                con = new SqlConnection(source);
                con.Open();

                cmd = new SqlCommand("SPAccountsLedger", con);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                
                cmd.Parameters.AddWithValue("@FromDate", objFrom);
                cmd.Parameters.AddWithValue("@ToDate", objTo);
                cmd.Parameters.AddWithValue("@AccountNo", objAccNo);
                if (branchid > 0)
                {
                    cmd.Parameters.AddWithValue("@BranchID", objbranchid);
                }

                da.SelectCommand = cmd;

                da.Fill(ds, "SPAccountsLedger");

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GetGeneralData(ref Common.Data_Sets.DSAccLedger ds, string fromDate, string toDate, string voucherType,int branchid,string AccNo)
        {
            try
            {
                Object objFrom = fromDate;
                Object objTo = toDate;
                Object objVoucherType = voucherType;
                Object objbranchid = branchid;

                con = new SqlConnection(source);
                con.Open();

                cmd = new SqlCommand("SPGeneralJournal", con);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FromDate", objFrom);
                cmd.Parameters.AddWithValue("@ToDate", objTo);
                cmd.Parameters.AddWithValue("@VoucherType", objVoucherType);
                if (branchid > 0)
                {
                    cmd.Parameters.AddWithValue("@BranchID", objbranchid);
                }


                if (AccNo.ToString().Trim().Length     > 0)
                {
                    cmd.Parameters.AddWithValue("@AccNo", AccNo );
                }
                da.SelectCommand = cmd;

                da.Fill(ds, "SPAccountsLedger");

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GetFundsFlow(ref Common.Data_Sets.DSFundsFlow ds, string fromDate, string toDate)
        {
            try
            {
                Object objFrom = fromDate;
                Object objTo = toDate;


                con = new SqlConnection(source);
                con.Open();

                cmd = new SqlCommand("SPFundsFlow", con);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FromDate", objFrom);
                cmd.Parameters.AddWithValue("@ToDate", objTo);
                cmd.Parameters.AddWithValue("@IsPosted", 0);
                da.SelectCommand = cmd;

                da.Fill(ds, "SPFundsFlow");

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "SELECT AccountNo,AccountName,'Closing Balance' AS PartyName, SUM(Amount) AS Amount FROM FundsFlow  GROUP BY AccountNo,AccountName ";

                da.Fill(ds, "SPTotal");



                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
