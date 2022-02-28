using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Common;
using DAL;

namespace CategoryControlle
{
    public class ChartofAccountsController
    {
        List<ChartOfAccounts> accounts;
        ChartOfAccounts account;

        public List<ChartOfAccounts> GetPAcc(int ID)
        {
            return new ChartofAccountsDAL().GetPAcc(ID );
        }
        public List<ChartOfAccounts> GetParentAccounts(int flag)
        {
            accounts = new ChartofAccountsDAL().GetParentAccounts(flag);
            return accounts;
        }
        public List<ChartOfAccounts> GetAccounts(string accountType, string POS, string companyID)
        {
            accounts = new ChartofAccountsDAL().GetAccounts(accountType, POS, companyID);
            return accounts;
        }
        public List<ChartOfAccounts> GetChildAccounts(string accNo, string s)
        {
            accounts = new ChartofAccountsDAL().GetChildAccounts(accNo, s);
            return accounts;
        }
        public List<ChartOfAccounts> GetCreditCardAccounts()
        {
            accounts = new ChartofAccountsDAL().GetCreditCardAccounts();
            return accounts;
        }
        public ChartOfAccounts GetAccountDetail(string accNo,string where)
        {
            account = new ChartofAccountsDAL().GetAccountDetail(accNo,where);
            return account;
        }

        public int GetAccountDepth(string AccountNo)
        {
            return new ChartofAccountsDAL().GetAccountDepth (AccountNo);
        }

        public string GetAccountExtension(string parentAcc,string type)
        {
            try
            {
                return new ChartofAccountsDAL().GetAccountExtension(parentAcc,type);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       

        public string GetPartyExtension(string parentAcc, string type)
        {
            try
            {
                return new ChartofAccountsDAL().GetPartyExtension(parentAcc, type);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<string> GetNames(string select)
        {
            return new ChartofAccountsDAL().GetNames(select);
        }

        public bool SaveAccount(ChartOfAccounts acc)
        {
            return new ChartofAccountsDAL().SaveAccount(acc);
        }
        
        public bool UpdateAccount(ChartOfAccounts acc)
        {
            return new ChartofAccountsDAL().UpdateAccount (acc);
        }

        public bool DeleteAccount(string accountNo)
        {
            return new ChartofAccountsDAL().DeleteAccount(accountNo);
        }

        public bool CheckBalances(string accountNo)
        {
            return new ChartofAccountsDAL().CheckBalances(accountNo);
        }
        public bool SaveOpBal(ChartOfAccounts acc)
        {
            try
            {
                return new ChartofAccountsDAL().SaveOpBal(acc);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

       

        public System.Data.DataSet GetReportData(string AccType)
        {
            return new DAL.ChartofAccountsDAL().GetReportData(AccType);
        }

        public List<ChartOfAccounts> GetAccounts()
        {
            return new DAL.ChartofAccountsDAL().GetAccounts();
        }





        public System.Data.DataSet GetCompanies()
        {
            return new DAL.ChartofAccountsDAL().GetCompanies();
        }

        public System.Data.DataSet GetSector()
        {
            return new DAL.ChartofAccountsDAL().GetSector();
        }

        public System.Data.DataSet GetRegion(string Salesmanid)
        {
            return new DAL.ChartofAccountsDAL().GetRegion(Salesmanid);
        }

        public System.Data.DataSet GetSalesman()
        {
            return new DAL.ChartofAccountsDAL().GetSalesman();
        }

        public System.Data.DataSet GetParty()
        {
            return new DAL.ChartofAccountsDAL().GetParty();
        }

        public System.Data.DataSet GetRegiondata()
        {
            return new DAL.ChartofAccountsDAL().GetRegiondata();
        }
        public List<ChartOfAccounts> GetAccounts(string accountType, string POS)
        {
            accounts = new ChartofAccountsDAL().GetAccounts(accountType, POS);
            return accounts;
        }
        public List<ChartOfAccounts> GetAccounts(string accountType, string POS,int BranchID)
        {
            accounts = new ChartofAccountsDAL().GetAccounts(accountType, POS,BranchID );
            return accounts;
        }
        public List<ChartOfAccounts> GetCourierAccounts()
        {
            return new DAL.ChartofAccountsDAL().GetCourierAccounts();
        }

        public List<ChartOfAccounts> GetBankAccounts()
        {
            return new DAL.SaleInvoiceDAL().GetBankAcc();
        }

        public List<ChartOfAccounts> GetVendors()
        {
            return new DAL.ChartofAccountsDAL().GetVendors();
        }

        public bool UpdateOpBal(ChartOfAccounts accounts, int branchid)
        {
            return new DAL.ChartofAccountsDAL().UpdateOpBal(accounts, branchid);
        }
    }
}
