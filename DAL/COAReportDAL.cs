using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using Common;
using System.Configuration;

namespace DAL
{
    public class COAReportDAL
    {
        //private string source = ConfigurationManager.ConnectionStrings["MyKey"].ConnectionString;
        private string source = ReadProjectConfigFile.ConfigString();
        SqlConnection con;
        SqlCommand cmd;

        SqlDataAdapter da = new SqlDataAdapter();

        public bool GetTrialData(ref Common.Data_Sets.DSCOA ds, string fromDate, string toDate)
        {
            try
            {
                Object objFrom = fromDate;
                Object objTo = toDate;

                con = new SqlConnection(source);
                con.Open();

                cmd = new SqlCommand("SPTrialBalance", con);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FromDate", objFrom);
                cmd.Parameters.AddWithValue("@ToDate", objTo);                

                da.SelectCommand = cmd;

                da.Fill(ds, "ChartOfAccounts");

                return true;
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
                Object objFrom = fromDate;
                Object objTo = toDate;
                Object objAcc = AccNo;

                con = new SqlConnection(source);
                con.Open();

                cmd = new SqlCommand("SPGTrialBalance", con);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FromDate", objFrom);
                cmd.Parameters.AddWithValue("@ToDate", objTo);
                if (objAcc.ToString() != "0%")
                {
                    cmd.Parameters.AddWithValue("@AccNo", objAcc);
                }

                da.SelectCommand = cmd;

                da.Fill(ds, "ChartOfAccounts");

                return true;
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
                Object objFrom = fromDate;
                Object objTo = toDate;

                con = new SqlConnection(source);
                con.Open();
                if (IsIncomeStmntFirst != true)
                {
                    cmd = new SqlCommand("SPIncomeStatement", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FromDate", objFrom);
                    cmd.Parameters.AddWithValue("@ToDate", objTo);
                    da.SelectCommand = cmd;
                    da.Fill(ds, "SPIncomeStatement");
                }
                else 
                {
                    cmd = new SqlCommand("SPIncomeStatementFirst", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FromDate", objFrom);
                    cmd.Parameters.AddWithValue("@ToDate", objTo);
                    da.SelectCommand = cmd;
                    da.Fill(ds, "SPIncomeStatementFirst");
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Getting New Inc Stmt
        public bool GetIncStmtData(ref System.Data.DataSet    ds, string fromDate, string toDate)
        {
            try
            {
                Object objFrom = fromDate;
                Object objTo = toDate;

                con = new SqlConnection(source);
                con.Open();

                cmd = new SqlCommand("SpIncStmt", con);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FromDate", objFrom);
                cmd.Parameters.AddWithValue("@ToDate", objTo);

                da.SelectCommand = cmd;

                da.Fill(ds);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// </summary>
        /// <param name="ds"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        public bool GetBalanceSheetData(ref Common.Data_Sets.DSBalanceSheet ds, string fromDate, string toDate)
        {
            try
            {
                Object objFrom = fromDate;
                Object objTo = toDate;

                con = new SqlConnection(source);
                con.Open();

                cmd = new SqlCommand("SpBalanceSheet", con);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FromDate", objFrom);
                cmd.Parameters.AddWithValue("@ToDate", objTo);

                da.SelectCommand = cmd;

                da.Fill(ds, "SPBalanceSheet");

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GetGroupBalances(ref Common.Data_Sets.DSGroupBalances  ds, string fromDate, string toDate,string groupNo)
        {
            try
            {
                Object objFrom = fromDate;
                Object objTo = toDate;
                Object objGroupNo = groupNo ;

                con = new SqlConnection(source);
                con.Open();

                string procedureName = "SPGroupBalances";
               

                cmd = new SqlCommand(procedureName, con);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FromDate", objFrom);
                cmd.Parameters.AddWithValue("@ToDate", objTo);
                cmd.Parameters.AddWithValue("@GroupNo", objGroupNo);

                da.SelectCommand = cmd;

                da.Fill(ds, "SPGroupBalances");

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GetPayRecData(ref Common.Data_Sets.DSCOA ds, string fromDate, string toDate,string type,bool level,int  BranchID)
        {
            try
            {
                Object objFrom = fromDate;
                Object objTo = toDate;
                Object objType = type;
                Object objBranch = BranchID ;
                con = new SqlConnection(source);
                con.Open();

                string procedureName = "SPAccBalances";
                if (level)
                {
                    procedureName = "SPAccBalancesPO/DO";
                }

                cmd = new SqlCommand(procedureName, con);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FromDate", objFrom);
                cmd.Parameters.AddWithValue("@ToDate", objTo);
                cmd.Parameters.AddWithValue("@ReportType", objType);
                cmd.Parameters.AddWithValue("@BranchID", objBranch );

                da.SelectCommand = cmd;

                da.Fill(ds, "ChartOfAccounts");

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public bool GetSvcIncomeData(ref Common.Data_Sets.DSIncomeStatementService DsSvcIncStmnt, string fromDate, string toDate)
        //{
        //    Object objFrom = fromDate;
        //    Object objTo = toDate;

        //    con = new SqlConnection(source);
        //    con.Open();

        //    cmd = new SqlCommand("SPIncomeStatementService", con);

        //    cmd.CommandType = System.Data.CommandType.StoredProcedure;

        //    cmd.Parameters.AddWithValue("@FromDate", objFrom);
        //    cmd.Parameters.AddWithValue("@ToDate", objTo);

        //    da.SelectCommand = cmd;
        //    da.Fill(DsSvcIncStmnt, "SPIncomeStatementService");

        //    return true;
        //}
    }
}
