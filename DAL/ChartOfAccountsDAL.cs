
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Common;
using System.Configuration;

namespace DAL
{
    public class ChartofAccountsDAL
    {
        private ChartOfAccounts account;
        private PartyType prty;
        private List<ChartOfAccounts> accounts=new List<ChartOfAccounts> ();
        private string source = ReadProjectConfigFile.ConfigString();
        private string Msource = ReadProjectConfigFile.MConfigString();
        SqlConnection conLocal;
        // string source = ConfigurationManager.ConnectionStrings["MyKey"].ConnectionString;
        List<Branch> branches = new List<Branch>();
        SqlConnection con;
        SqlCommand cmd;

        List<string> names = new List<string>();

        SqlTransaction VTran;
        SqlTransaction VTranLocal;
        SqlDataReader dr;


        public List<ChartOfAccounts> GetAccounts(string accountType, string POS,int BranchID)
        {
            try
            {
                string select = "";

                if (POS == "P")
                {
                    if (User._IsAdmin)
                    {
                        select = "select * from chartofaccounts c inner join parties p on p.partyid=c.accountNo   where c.isdetailed=1  and p.inPurchase=1" + accountType;

                    }
                    else
                    {
                        select = "select isnull(openingdr,0) as openingdebit,isnull(openingcr,0) as openingcredit, * from chartofaccounts c inner join Openingbalances op on op.Accountno =c.accountNo   where c.isdetailed=1 and op.BranchID=" + BranchID  + "  " + accountType;

                    }
                }
                else if (POS == "S")
                {
                    if (User._IsAdmin)
                    {
                        select = "select *  from chartofaccounts c inner join parties p on p.partyid=c.accountNo where c.isdetailed=1 " + accountType; //and p.inSale=1
                    }
                    else
                    {
                        select = "select *  from chartofaccounts c inner join parties p on p.partyid=c.accountNo   inner join COABranch b on c.AccountNo=b.PartyID  where c.isdetailed=1   " + accountType + " and  b.BranchID=" + Globals.BranchID + " "; //and p.inSale=1

                    }
                }
                else if (POS == "VA")
                {
                    //select = "Execute SPVoucherAccounts '" + accountType + "'";
                    if (User._IsAdmin)
                    {
                        select = "select *  from chartofaccounts where isdetailed=1 ";
                    }
                    else
                    {
                        select = "select *  from chartofaccounts c inner join COABranch b on c.AccountNo=b.PartyID where isdetailed=1 and  b.BranchID=" + Globals.BranchID + " ";
                    }
                }
                else
                {
                    select = "select  isnull(openingdr,0) as openingdr,isnull(openingcr,0) as openingcr,*  from chartofaccounts c   left outer join (select accountno,openingdr,openingcr from openingbalances where branchid=" + BranchID + ")b  on c.accountno=b.accountno  where isdetailed=1" + accountType;
                }

                con = new SqlConnection(source);
                con.Open();

                cmd = new SqlCommand(select, con);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string ano = (string)dr["AccountNo"];
                    string ana = (string)dr["AccountName"];
                    AccountType at = (AccountType)Enum.Parse(typeof(AccountType), Convert.ToString(dr["AccountType"]), true);
                    int ad = Convert.ToInt16(dr["AccountDepth"]);
                    string nar = (string)((dr["Narration"] == System.DBNull.Value) ? "" : dr["Narration"]);
                    string pano = (string)((dr["ParentAccountNo"] == System.DBNull.Value) ? "0" : dr["ParentAccountNo"]);
                    decimal od = Convert.ToDecimal(dr["openingdr"] == System.DBNull.Value ? 0 : dr["openingdr"]);
                    decimal oc = Convert.ToDecimal(dr["openingcr"] == System.DBNull.Value ? 0 : dr["openingcr"]);
                    decimal adb = Convert.ToDecimal(dr["AdjustedDebit"] == System.DBNull.Value ? 0 : dr["AdjustedDebit"]);
                    decimal ac = Convert.ToDecimal(dr["AdjustedCredit"] == System.DBNull.Value ? 0 : dr["AdjustedCredit"]);
                    bool id = Convert.ToBoolean(dr["IsDetailed"]);
                    bool il = Convert.ToBoolean(dr["IsLocked"]);
                    bool ip = Convert.ToBoolean(dr["IsPosted"]);
                    bool ie = Convert.ToBoolean(dr["IsEditable"]);
                    bool bf = Convert.ToBoolean(dr["BalFlag"]);
                    string pf = (string)((dr["plFlag"] == System.DBNull.Value) ? "" : dr["plFlag"]);
                    bool ef = Convert.ToBoolean(dr["ExpFlag"]);

                    accounts.Add(new ChartOfAccounts(ano, ana, at, ad, nar, new ChartOfAccounts(pano, ""), od, oc, adb, ac, id, il, ip, ie, bf, pf, ef));
                }
                return accounts;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
        }
        public List<ChartOfAccounts> GetPAcc(int ID)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                //cmd = new SqlCommand("select accountno,accountname from chartofaccounts where isdetailed=0", con);
                if (ID == 0)
                {
                    cmd = new SqlCommand(" select 0 as accountno,'All' as accountname  union all  select accountno,accountname from chartofaccounts where isdetailed=0", con);
                }
                else
                {
                    cmd = new SqlCommand(" select 0 as accountno,'All' as accountname  union all  select accountno,accountname from chartofaccounts where isdetailed=1 and accountno like '6008%'", con);
                }
                dr = cmd.ExecuteReader();
                List<ChartOfAccounts> lstacc = new List<ChartOfAccounts>();
                while (dr.Read())
                {
                    ChartOfAccounts coa = new ChartOfAccounts();
                    coa.AccountNo = Convert.ToString(dr["Accountno"]);
                    coa.AccountName = Convert.ToString(dr["Accountname"]);

                    lstacc.Add(coa);

                }
                return lstacc;

            }
            catch (Exception ex)
            {

                throw ex;
                return null;
            }
            finally
            {
                con.Close();
                dr.Close();
            }
        }

        public bool UpdateOpBal(ChartOfAccounts accounts, int BranchID)
        {
            
                try
                {
                    con = new SqlConnection(source);
                    con.Open();
                    VTran = con.BeginTransaction();

               foreach(ChartOfAccounts acc in accounts.coaList)
               {
                    string updateOpBal = " if exists(select *  from openingbalances where accountno=" + acc.AccountNo + " and branchid=" + BranchID + ")  Begin  Update openingbalances Set OpeningDr=" + acc.OpeningDebit + ",OpeningCr=" + acc.OpeningCredit + " ,AdjustedDr=" + acc.AdjustedDebit + " ,AdjustedCr=" + acc.AdjustedCredit + " where AccountNo='" + acc.AccountNo + "' and branchid=" + BranchID + "  end Else Begin Insert into openingbalances (Accountno,Branchid,OpeningDr,OpeningCr,AdjustedDr,AdjustedCr) values (" + acc.AccountNo + "," + BranchID + "," + acc.OpeningDebit + "," + acc.OpeningCredit + ",0,0) end ";
                    cmd = new SqlCommand(updateOpBal, con);
                    cmd.Transaction = VTran;
                    cmd.ExecuteNonQuery();
                }


                VTran.Commit();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    VTran.Rollback();
                    throw ex;
                }
                finally { con.Close(); }
        }

        public int GetAccountDepth(string AccountNo)
        {
            try
            {
                int VID = 0;

                con = new SqlConnection(source);
                con.Open();

                cmd = new SqlCommand("select AccountDepth + 1  from ChartOfAccounts where AccountNo = '" + AccountNo  +"'", con);
                VID = Convert.ToInt32(cmd.ExecuteScalar());

                return VID;
            }
            catch
            {
                throw;
            }
        }

        public List<ChartOfAccounts> GetParentAccounts(int flag)
        {
            try
            {
                string select;
                if (flag == 0)
                {
                    select = "Select * from ChartofAccounts where isdetailed=0 and lower(accounttype)<>'Party' order by AccountNo";
                }
                else if (flag == 1)
                {
                    select = "Select * from ChartofAccounts where isdetailed=0 and lower(accounttype)='Party' order by AccountNo";
                }
                else
                    select = "Select * from ChartofAccounts where isdetailed=0 order by AccountNo";

                con = new SqlConnection(source);
                con.Open();

                cmd = new SqlCommand(select, con);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string ano=(string)dr["AccountNo"];
                    string ana= (string)dr["AccountName"];
                    AccountType at = (AccountType)Enum.Parse (typeof(AccountType),Convert.ToString (dr["AccountType"]),true );
                    int ad=Convert.ToInt16 (dr["AccountDepth"]);
                    string nar=(string)((dr["Narration"] == System.DBNull.Value) ? "" : dr["Narration"]);
                    string pano=(string)((dr["ParentAccountNo"] == System.DBNull.Value) ? "0" : dr["ParentAccountNo"]);
                    decimal od=Convert.ToDecimal(dr["OpeningDebit"] == System.DBNull.Value ? 0 : dr["OpeningDebit"]);
                    decimal oc=Convert.ToDecimal(dr["OpeningCredit"] == System.DBNull.Value ? 0 : dr["OpeningCredit"]);
                    decimal adb=Convert.ToDecimal(dr["AdjustedDebit"] == System.DBNull.Value ? 0 : dr["AdjustedDebit"]);
                    decimal ac=Convert.ToDecimal(dr["AdjustedCredit"] == System.DBNull.Value ? 0 : dr["AdjustedCredit"]);
                    bool id=Convert.ToBoolean(dr["IsDetailed"]);
                    bool il=Convert.ToBoolean(dr["IsLocked"]);
                    bool ip=Convert.ToBoolean(dr["IsPosted"]);
                    bool ie=Convert.ToBoolean(dr["IsEditable"]);
                    bool bf= Convert.ToBoolean(dr["BalFlag"]);
                    string pf=(string)((dr["plFlag"] == System.DBNull.Value) ? "" : dr["plFlag"]);
                    bool ef=Convert.ToBoolean(dr["ExpFlag"]);

                    accounts.Add(new ChartOfAccounts(ano,ana,at,ad,nar,new ChartOfAccounts(pano,""),od ,oc ,adb,ac ,id ,il ,ip ,ie ,bf,pf,ef));
                }
                return accounts;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
        }

        public List<ChartOfAccounts> GetVendors()
        {
            try
            {
                con = new SqlConnection(source);
                List<ChartOfAccounts> accounts = new List<ChartOfAccounts>();
                con.Open();

                cmd = new SqlCommand("select AccountNo,AccountName from ChartofAccounts where IsDetailed=1 and AccountNo like '6%'", con);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ChartOfAccounts ca = new ChartOfAccounts();
                    ca.AccountNo = (string)dr["AccountNo"];
                    ca.AccountName = (string)dr["AccountName"];
                
                    accounts.Add(ca);

                }
                return accounts;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ChartOfAccounts> GetCourierAccounts()
        {

            con = new SqlConnection(source);
            List<ChartOfAccounts> accounts = new List<ChartOfAccounts>();
            con.Open();

            cmd = new SqlCommand("select AccountNo,AccountName,AccountType from ChartofAccounts where IsDetailed=1 and AccountNo like '6006%'", con);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ChartOfAccounts ca = new ChartOfAccounts();
                ca.AccountNo = (string)dr["AccountNo"];
                ca.AccountName = (string)dr["AccountName"];
                ca.AccountType = (AccountType)Enum.Parse(typeof(AccountType), (string)(dr["AccountType"]), true);
                accounts.Add(ca);

            }
            return accounts;
        }

        public List<ChartOfAccounts> GetChildAccounts(string accountNo, string s)
        {
            try
            {
                if (s.Trim().Length == 0)
                {
                    s = "";
                }
                else
                {
                    s = " and AccountName like '%" + s + "%'";
                }

                string select;
                select = "select *  from chartofaccounts where isdetailed=1 and parentaccountno="+ accountNo + s;

                con = new SqlConnection(source);
                con.Open();

                cmd = new SqlCommand(select, con);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string ano = (string)dr["AccountNo"];
                    string ana = (string)dr["AccountName"];
                    AccountType at = (AccountType)Enum.Parse(typeof(AccountType), Convert.ToString(dr["AccountType"]), true);
                    int ad = Convert.ToInt16 (dr["AccountDepth"]);
                    string nar = (string)((dr["Narration"] == System.DBNull.Value) ? "" : dr["Narration"]);
                    string pano = (string)((dr["ParentAccountNo"] == System.DBNull.Value) ? "0" : dr["AccountNo"]);
                    decimal od = Convert.ToDecimal (dr["OpeningDebit"]);
                    decimal oc = Convert.ToDecimal (dr["OpeningCredit"]);
                    decimal adb = Convert.ToDecimal (dr["AdjustedDebit"]);
                    decimal ac = Convert.ToDecimal (dr["AdjustedCredit"]);
                    bool id = Convert.ToBoolean(dr["IsDetailed"]);
                    bool il = Convert.ToBoolean(dr["IsLocked"]);
                    bool ip = Convert.ToBoolean(dr["IsPosted"]);
                    bool ie = Convert.ToBoolean(dr["IsEditable"]);
                    bool bf = Convert.ToBoolean(dr["BalFlag"]);
                    string pf = (string)((dr["plFlag"] == System.DBNull.Value) ? "" : dr["plFlag"]);
                    bool ef = Convert.ToBoolean(dr["ExpFlag"]);

                    accounts.Add(new ChartOfAccounts(ano, ana, at, ad, nar, new ChartOfAccounts(pano, ""), od, oc, adb, ac, id, il, ip, ie, bf, pf, ef));
                }
                return accounts;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
        }

        public List<ChartOfAccounts> GetAccounts(string accountType, string POS, string companyID)
        {
            try
            {
                string select;
                string cnic = "";
                if (POS == "P")
                {
                    //select = "select c.*  from chartofaccounts c inner join parties p on p.partyid=c.accountNo where p.CompanyID='"+companyID+"' and c.isdetailed=1 and p.inPurchase=1" + accountType;
                    select = "select c.*, p.CNIC  from chartofaccounts c inner join parties p on p.partyid=c.accountNo where c.isdetailed=1 and p.inPurchase=1" + accountType;
                    //   select = "select p.partyid,p.partyname,p.CNIC,p.partytype from parties inner join ChartOfAccounts c on p.partyid=c.AccountNo where c.isdetailed=1 and p.inPurchase=1 and partyid='"+companyID+"'";
                }
                else if (POS == "S")
                {
                    //select = "select c.*  from chartofaccounts c inner join parties p on p.partyid=c.accountNo where c.isdetailed=1 and  p.CompanyID='" + companyID + "'and p.inSale=1" + accountType;
                    select = "select c.*  from chartofaccounts c inner join parties p on p.partyid=c.accountNo where c.isdetailed=1 and  p.inSale=1" + accountType;
                }
                else if (POS == "SP")
                {
                    select = "select *  from chartofaccounts c inner join parties p on p.partyid=c.accountNo where c.isdetailed=1 and p.inSale=1 or p.isPurchase=1" + accountType;
                }
                else if (POS == "VA")
                {
                    select = "Execute SPVoucherAccounts '" + accountType + "'";
                }
                else if (POS == "SACC")
                {
                    select = "select p.CNIC, c.*  from chartofaccounts c inner join parties p on p.partyid=c.accountNo where c.isdetailed=1 and  p.inSale=1" + accountType;
                   
                    // cmd = new SqlCommand("select PartyID,PartyName,PartyType,CNIC from parties where PartyID like '6%' and InSale='1'", con);
                    //select = "select  AccountNo,AccountName,AccountType from parties where PartyID like '6%' and InSale='1'";
                }


                else
                {
                    select = "select *  from chartofaccounts where isdetailed=1" + accountType;

                }


                con = new SqlConnection(source);
                con.Open();



                cmd = new SqlCommand(select, con);
                dr = cmd.ExecuteReader();
                //if (POS == "P")
                //{
                //    while (dr.Read())
                //    {
                //        Party common = new Party();
                //        string pid = (string)dr["Partyid"];
                //        string pname = (string)dr["partyname"];
                //        string ptype = (string)dr["PartyType"];
                //        string pcnic = (string)dr["CNIC"];
                //        prty.Add(new Party(pid, pname, ptype, pcnic));
                //    }
                //}
                //else
                //{
                while (dr.Read())
                {
                    string ano = (string)dr["AccountNo"];
                    string ana = (string)dr["AccountName"];
                    AccountType at = (AccountType)Enum.Parse(typeof(AccountType), Convert.ToString(dr["AccountType"]), true);
                    int ad = Convert.ToInt16(dr["AccountDepth"]);
                    string nar = (string)((dr["Narration"] == System.DBNull.Value) ? "" : dr["Narration"]);
                    string pano = (string)((dr["ParentAccountNo"] == System.DBNull.Value) ? "0" : dr["AccountNo"]);
                    decimal od = Convert.ToDecimal(dr["OpeningDebit"]);
                    decimal oc = Convert.ToDecimal(dr["OpeningCredit"]);
                    decimal adb = Convert.ToDecimal(dr["AdjustedDebit"]);
                    decimal ac = Convert.ToDecimal(dr["AdjustedCredit"]);
                    bool id = Convert.ToBoolean(dr["IsDetailed"]);
                    bool il = Convert.ToBoolean(dr["IsLocked"]);
                    bool ip = Convert.ToBoolean(dr["IsPosted"]);
                    bool ie = Convert.ToBoolean(dr["IsEditable"]);
                    bool bf = Convert.ToBoolean(dr["BalFlag"]);
                    string pf = (string)((dr["plFlag"] == System.DBNull.Value) ? "" : dr["plFlag"]);
                    bool ef = Convert.ToBoolean(dr["ExpFlag"]);

                    accounts.Add(new ChartOfAccounts(ano, ana, at, ad, nar, new ChartOfAccounts(pano, ""), od, oc, adb, ac, id, il, ip, ie, bf, pf, ef));

                }
                return accounts;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
        }

        public List<ChartOfAccounts> GetCreditCardAccounts()
        {
            try
            {               
                string select;
                select = "Select '0' as AccountNo, 'None' as AccountName Union All select AccountNo,AccountName  from chartofaccounts where parentaccountno=11003";

                con = new SqlConnection(source);
                con.Open();

                cmd = new SqlCommand(select, con);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string ano = (string)dr["AccountNo"];
                    string ana = (string)dr["AccountName"];                   

                    accounts.Add(new ChartOfAccounts(ano,ana));
                }
                return accounts;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
        }

        public string GetAccountExtension(string parentAcc,string type)
        {
            try
            {
                string select;

                string extension;
                
                select = "Select Case When Len(cast(Max(cast(substring(AccountNo," + parentAcc.Length + " + 1,10) as bigint)) +1  as varchar(15)) )=1 then '00' + (cast(Max(cast(substring(AccountNo," + parentAcc.Length + " + 1,10) as bigint)) +1  as varchar(15)) ) Else Case When Len(cast(Max(cast(substring(AccountNo," + parentAcc.Length + " + 1,10) as bigint)) +1  as varchar(15)) )=2 Then '0'+ (cast(Max(cast(substring(AccountNo," + parentAcc.Length + " + 1,10) as bigint)) +1  as varchar(15)) ) else case when Len(cast(Max(cast(substring(AccountNo," + parentAcc.Length + " + 1,10) as bigint)) +1  as varchar(15)) )=3 then  (cast(Max(cast(substring(AccountNo," + parentAcc.Length + " + 1,10) as bigint)) +1  as varchar(15)) )  end End End    from chartofaccounts where parentaccountno='" + parentAcc + "'";                               

                con = new SqlConnection(source);
                con.Open();

                cmd = new SqlCommand(select, con);

                extension = cmd.ExecuteScalar().ToString ();

                return extension;
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
                string select;

                string extension;
                
                select = "select  '" + parentAcc + "'+ isnull(cast(max(cast(substring(accountno," + parentAcc.Length + " + 1,10) as bigint)) +1  as varchar(15)),'1')as id  from chartofaccounts where parentaccountno='" + parentAcc + "'";
                


                con = new SqlConnection(source);
                con.Open();

                cmd = new SqlCommand(select, con);

                extension = cmd.ExecuteScalar().ToString();

                return extension;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ChartOfAccounts GetAccountDetail(string accountNo,string where)
        {
            try
            {
                string select;

                string vWhere = "";
                AddBranches(accountNo);
                if (accountNo.Length > 0)
                {
                 //   vWhere = " WHERE accountno='" + accountNo + "'" + where;
                    vWhere = " WHERE c1.accountno='" + accountNo + "'";
                }
                else
                {
                    vWhere = where;
                }
               
                select = "SELECT c1.AccountNo,c1.AccountName,c1.AccountType,c1.AccountDepth,c1.Narration,c1.ParentAccountNo,c1.OpeningDebit,c1.OpeningCredit,c1.AdjustedDebit,c1.AdjustedCredit,c1.IsDetailed,c1.IsLocked,c1.IsPosted,c1.IsEditable,c1.BalFlag,c1.plFlag,c1.ExpFlag,c1.GRVAccountNo,c2.AccountName as grvaccountname FROM chartofaccounts c1 left join chartofaccounts c2 on c1.grvaccountno=c2.AccountNo " + vWhere;

                con = new SqlConnection(source);
                con.Open();

               

                cmd = new SqlCommand(select, con);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string ano = (string)dr["AccountNo"];
                    string ana = (string)dr["AccountName"];
                    AccountType at = (AccountType)Enum.Parse(typeof(AccountType), Convert.ToString(dr["AccountType"]), true);
                    int ad = Convert.ToInt16 (dr["AccountDepth"]);
                    string nar = (string)((dr["Narration"] == System.DBNull.Value) ? "" : dr["Narration"]);
                    string pano = (string)((dr["ParentAccountNo"] == System.DBNull.Value) ? "0" : dr["ParentAccountNo"]);
                    decimal od = Convert.ToDecimal (dr["OpeningDebit"]);
                    decimal oc = Convert.ToDecimal (dr["OpeningCredit"]);
                    decimal adb = Convert.ToDecimal (dr["AdjustedDebit"]);
                    decimal ac = Convert.ToDecimal (dr["AdjustedCredit"]);
                    bool id = Convert.ToBoolean(dr["IsDetailed"]);
                    bool il = Convert.ToBoolean(dr["IsLocked"]);
                    bool ip = Convert.ToBoolean(dr["IsPosted"]);
                  
                    bool ie = Convert.ToBoolean(dr["IsEditable"]);
                    bool bf = Convert.ToBoolean(dr["BalFlag"]);
                    string pf = (string)((dr["plFlag"] == System.DBNull.Value) ? "" : dr["plFlag"]);
                    bool ef = Convert.ToBoolean(dr["ExpFlag"]);

                    account = new ChartOfAccounts(ano, ana, at, ad, nar, new ChartOfAccounts(pano, ""), od, oc, adb, ac, id, il, ie,ip, bf, pf, ef);
                    account.Branches = branches;
                    account.GRVAccount= (string)((dr["GRVAccountNo"] == System.DBNull.Value) ? "" : dr["GRVAccountNo"]);
                    account.GRVAccountName = (string)((dr["grvaccountname"] == System.DBNull.Value) ? "" : dr["grvaccountname"]);

                }
                
                return account;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
        }

        private void AddBranches(string accountNo)
        {
            con = new SqlConnection(source);
            con.Open();

            cmd = new SqlCommand("select cob.BranchID,cob.PartyID,b.BranchName from COABranch cob left join branch b on cob.Branchid=b.id where partyid='"+ accountNo + "'",con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Branch b = new Branch();
                b.ID = Convert.ToInt32(dr["BranchID"]);
                b.BranchName = dr["BranchName"].ToString();
                b.Select =true;
                branches.Add(b);

            }
        }

        public bool SaveAccount(ChartOfAccounts acc)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                VTran = con.BeginTransaction();

                string insertAccount = "Insert Into ChartofAccounts(AccountNo,UserNo,AccountName,AccountType,AccountDepth,Narration,ParentAccountNo,OpeningDebit,OpeningCredit,AdjustedDebit,AdjustedCredit,IsDetailed,IsLocked,IsPosted,IsEditable,BalFlag,PLFlag,ExpFlag,GRVAccountNo) Values('" + acc.AccountNo + "','"+User.UserNo+"','" + acc.AccountName + "','" + acc.AccountType.ToString() + "'," + acc.AccountDepth + ",'" + acc.Narration + "','" + acc.ParentAccount.AccountNo + "'," + acc.OpeningDebit + "," + acc.OpeningCredit + "," + acc.AdjustedDebit + "," + acc.AdjustedCredit + "," + Convert.ToInt16 (acc.IsDetailed) + "," + Convert.ToInt16 (acc.IsLocked) + "," + Convert.ToInt16 (acc.IsPosted) + "," + Convert.ToInt16 (acc.IsEditable) + "," + Convert.ToInt16 (acc.BalFlag) + ",'" + acc.PlFlag + "'," + Convert.ToInt16 (acc.ExpFlag) + ",'"+acc.GRVAccount+"')";
                cmd = new SqlCommand(insertAccount, con);
                cmd.Transaction = VTran;
                cmd.ExecuteNonQuery();

                foreach (Branch b in acc.Branches)
                {
                    cmd.CommandText = SetPurInsertBranch(b, acc.AccountNo);
                    cmd.ExecuteNonQuery();

                }

                VTran.Commit();
                con.Close();

                return true;
            }
            catch (Exception ex)
            {
                VTran.Rollback();
                throw ex;
            }
            finally { con.Close(); }
        }
        private string SetPurInsertBranch(Branch b, string accountNo)
        {
            try
            {
                string insertItems = "Insert Into COABranch(PartyID,BranchID) Values(" + accountNo + "," + b.ID + ")";
                return insertItems;
            }
            catch
            {
                VTran.Rollback();
                throw;
            }
        }
        public bool SaveLocalAccount(ChartOfAccounts acc)
        {
            try
            {
                if (Msource.ToString().Trim().Length == 0) return true;
                conLocal = new SqlConnection(Msource);
                conLocal.Open();
                VTranLocal = conLocal.BeginTransaction();

                string insertAccount = "Insert Into ChartofAccounts(AccountNo,AccountName,AccountType,AccountDepth,Narration,ParentAccountNo,OpeningDebit,OpeningCredit,AdjustedDebit,AdjustedCredit,IsDetailed,IsLocked,IsPosted,IsEditable,BalFlag,PLFlag,ExpFlag) Values('" + acc.AccountNo + "','" + acc.AccountName + "','" + acc.AccountType.ToString() + "'," + acc.AccountDepth + ",'" + acc.Narration + "','" + acc.ParentAccount.AccountNo + "'," + acc.OpeningDebit + "," + acc.OpeningCredit + "," + acc.AdjustedDebit + "," + acc.AdjustedCredit + "," + Convert.ToInt16(acc.IsDetailed) + "," + Convert.ToInt16(acc.IsLocked) + "," + Convert.ToInt16(acc.IsPosted) + "," + Convert.ToInt16(acc.IsEditable) + "," + Convert.ToInt16(acc.BalFlag) + ",'" + acc.PlFlag + "'," + Convert.ToInt16(acc.ExpFlag) + ")";
                cmd = new SqlCommand(insertAccount, conLocal);
                cmd.Transaction = VTranLocal;
                cmd.ExecuteNonQuery();

                foreach (Branch b in acc.Branches)
                {
                    cmd.CommandText = SetPurInsertBranch(b, acc.AccountNo);
                    cmd.ExecuteNonQuery();

                }

                VTranLocal.Commit();
                conLocal.Close();

                return true;
            }
            catch (Exception ex)
            {
                VTranLocal.Rollback();
                throw ex;
            }
            finally { conLocal.Close(); }
        }

        public bool UpdateLocalAccount(ChartOfAccounts acc)
        {
            try
            {
                if (Msource.ToString().Trim().Length == 0) return true;
                conLocal = new SqlConnection(Msource);
                conLocal.Open();
                VTranLocal = conLocal.BeginTransaction();

                string updateAccount = "Update ChartofAccounts Set AccountName='" + acc.AccountName + "',Narration='" + acc.Narration + "' where AccountNo='" + acc.AccountNo + "'";
                cmd = new SqlCommand(updateAccount, conLocal);
                cmd.Transaction = VTranLocal;
                cmd.ExecuteNonQuery();
                string DeleteAccount = " Delete from COABranch where PartyID='" + acc.AccountNo + "'  ";
                cmd = new SqlCommand(DeleteAccount, conLocal );
                cmd.Transaction = VTranLocal  ;
                cmd.ExecuteNonQuery();


                foreach (Branch b in acc.Branches)
                {
                    cmd.CommandText = SetPurInsertBranch(b, acc.AccountNo);
                    cmd.ExecuteNonQuery();

                }



                VTranLocal.Commit();
                conLocal.Close();

                return true;
            }
            catch (Exception ex)
            {
                VTranLocal.Rollback();
                throw ex;
            }
            finally { conLocal.Close(); }
        }

        public bool UpdateAccount(ChartOfAccounts acc)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                VTran = con.BeginTransaction();

                string updateAccount = "Update ChartofAccounts Set AccountName='" + acc.AccountName  + "',Narration='" + acc.Narration  + "',GRVAccountNo='"+acc.GRVAccount+"' where AccountNo='" + acc.AccountNo +"'";
                cmd = new SqlCommand(updateAccount, con);
                cmd.Transaction = VTran;
                cmd.ExecuteNonQuery();

                string DeleteAccount = " Delete from COABranch where PartyID='" + acc.AccountNo + "'  ";
                cmd = new SqlCommand(DeleteAccount, con);
                cmd.Transaction = VTran;
                cmd.ExecuteNonQuery();


                foreach (Branch b in acc.Branches)
                {
                    cmd.CommandText = SetPurInsertBranch(b, acc.AccountNo);
                    cmd.ExecuteNonQuery();

                }

                VTran.Commit();
                con.Close();

                return true;
            }
            catch (Exception ex)
            {
                VTran.Rollback();
                throw ex;
            }
            finally { con.Close(); }
        }

        public bool CheckBalances(string accountNo)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();

                int r;
                string checkBal = "Select Count(*)  from openingbalances where  (openingdr>0 or openingcr >0) and accountno ='" + accountNo + "'";
                SqlCommand c = new SqlCommand(checkBal, con);
                r = Convert.ToInt16(c.ExecuteScalar());

                if (r > 0)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            { con.Close(); }
        }
        public bool SaveOpBal(ChartOfAccounts acc)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                VTran = con.BeginTransaction();

                string insertOpBal = "Insert Into OpeningBalances(AccountNo,OpeningDr,OpeningCr,AdjustedDr,AdjustedCr) Values('" + acc.AccountNo  + "'," + acc.OpeningDebit + "," + acc.OpeningCredit + "," + acc.AdjustedDebit + "," + acc.AdjustedCredit + ")";
                cmd = new SqlCommand(insertOpBal, con);
                cmd.Transaction = VTran;
                cmd.ExecuteNonQuery();

                VTran.Commit();
                con.Close();

                return true;
            }
            catch (Exception ex)
            {
                VTran.Rollback();
                throw ex;
            }
            finally { con.Close(); }
        }
      
    

        public List<string> GetNames(string select)
        {
            try
            {

                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand(select, con);

                dr = cmd.ExecuteReader();

                //Add Categories to Collection
                AddNames();

                con.Close();
                return names;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public void AddNames()
        {
            try
            {

                while (dr.Read())
                {
                    names.Add(dr["Name"].ToString());
                }
                dr.Close();
            }
            catch
            {
                throw;
            }

            finally { dr.Close(); }

        }

        public bool DeleteAccount(string accountNo)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                VTran = con.BeginTransaction();                
                
                string deleteAccount = "Delete From ChartofAccounts where AccountNo='" + accountNo + "'";
                cmd = new SqlCommand(deleteAccount, con);
                cmd.Transaction = VTran;
                cmd.ExecuteNonQuery();
              
                VTran.Commit();
                con.Close();

                return true;
            }
            catch (Exception ex)
            {
                VTran.Rollback();
                throw ex;
            }
            finally { con.Close(); }
        }


        public bool DeleteLocalAccount(string accountNo)
        {
            try
            {
                if (Msource.ToString().Trim().Length == 0) return true;
                conLocal = new SqlConnection(Msource);
                conLocal.Open();
                VTranLocal = conLocal.BeginTransaction();

                string deleteAccount = "Delete From ChartofAccounts where AccountNo='" + accountNo + "'";
                cmd = new SqlCommand(deleteAccount, conLocal);
                cmd.Transaction = VTranLocal;
                cmd.ExecuteNonQuery();

                VTranLocal.Commit();
                conLocal.Close();

                return true;
            }
            catch (Exception ex)
            {
                VTranLocal.Rollback();
                throw ex;
            }
            finally { conLocal.Close(); }
        }
        public DataSet GetReportData(string AccType)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                DataSet ds = new DataSet();
                string Select = "";
                string subAccName = "";
               // subAccName = "select AccountName from ChartOfAccounts where AccountDepth = 1";
                if (AccType == "All")
                {
                    Select = "select AccountNo,AccountName,AccountType from ChartOfAccounts where IsDetailed=1";
                }
                else
                {
                    Select = "select AccountNo,AccountName,AccountType from ChartOfAccounts where AccountType='" + AccType + "' and IsDetailed=1";
                }
                cmd = new SqlCommand(Select, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;

            }
            catch
            {
                throw;
            }
           
        }

        public List<ChartOfAccounts> GetAccounts()
        {
            con = new SqlConnection(source);
            List<ChartOfAccounts> accounts = new List<ChartOfAccounts>();
            con.Open();

            cmd = new SqlCommand("select AccountNo,AccountName,AccountType from ChartofAccounts where IsDetailed=1", con);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ChartOfAccounts ca = new ChartOfAccounts();
                ca.AccountNo = (string)dr["AccountNo"];
                ca.AccountName = (string)dr["AccountName"];
                ca.AccountType = (AccountType)Enum.Parse(typeof(AccountType),(string)(dr["AccountType"]),true);
                accounts.Add(ca);        

            }
            return accounts;
        }

        public DataSet GetCompanies()
        {
            con = new SqlConnection(source);
            DataSet ds = new DataSet();
            con.Open();
            cmd = new SqlCommand("select * from CompanyFile", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;
            
        }

        public DataSet GetSector()
        {
            con = new SqlConnection(source);
            DataSet ds = new DataSet();
            con.Open();
            cmd = new SqlCommand("select * from SectorFile", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;
        }

        public DataSet GetRegion(string Salesmanid)
        {
            con = new SqlConnection(source);
            DataSet ds = new DataSet();
            con.Open();
           
           cmd = new SqlCommand("select * from RegionFile", con);
           
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;
        }

        public DataSet GetSalesman()
        {
            con = new SqlConnection(source);
            DataSet ds = new DataSet();
            con.Open();
            cmd = new SqlCommand("select PartyID,PartyName,PartyType,CNIC from parties where PartyID like '6100%'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;
        }

        public DataSet GetParty()
        {
            con = new SqlConnection(source);
            DataSet ds = new DataSet();
            con.Open();
            cmd = new SqlCommand("select PartyID,PartyName from parties where PartyID like '6%'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;
        }

        public DataSet GetRegiondata()
        {
            con = new SqlConnection(source);
            DataSet ds = new DataSet();
            con.Open();

            cmd = new SqlCommand("select * from RegionFile", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;
        }
        public List<ChartOfAccounts> GetAccounts(string accountType, string POS)
        {
            try
            {
                string select="";

                if (POS == "P")
                {
                    if (User._IsAdmin)
                    {
                        select = "select * from chartofaccounts c inner join parties p on p.partyid=c.accountNo   where c.isdetailed=1  and p.inPurchase=1" + accountType;

                    }
                    else
                    {
                        select = "select * from chartofaccounts c inner join parties p on p.partyid=c.accountNo  inner join COABranch b on c.AccountNo=b.PartyID where c.isdetailed=1 and b.BranchID="+Globals.BranchID+"  and p.inPurchase=1" + accountType;

                    }
                }
                else if (POS == "S")
                {
                    if (User._IsAdmin)
                    {
                        select = "select *  from chartofaccounts c inner join parties p on p.partyid=c.accountNo where c.isdetailed=1 " + accountType; //and p.inSale=1
                    }
                    else
                    {
                        select = "select *  from chartofaccounts c inner join parties p on p.partyid=c.accountNo   inner join COABranch b on c.AccountNo=b.PartyID  where c.isdetailed=1   " + accountType + " and  b.BranchID=" + Globals.BranchID + " "; //and p.inSale=1

                    }
                }
                else if (POS == "VA")
                {
                    //select = "Execute SPVoucherAccounts '" + accountType + "'";
                    if (User._IsAdmin)
                    {
                        select = "select *  from chartofaccounts where isdetailed=1 ";
                    }
                    else
                    {
                        select = "select *  from chartofaccounts c inner join COABranch b on c.AccountNo=b.PartyID where isdetailed=1 and  b.BranchID=" + Globals.BranchID +" ";
                    }
                }
                else
                {
                    select = "select *  from chartofaccounts where isdetailed=1" + accountType;
                }

                con = new SqlConnection(source);
                con.Open();

                cmd = new SqlCommand(select, con);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string ano = (string)dr["AccountNo"];
                    string ana = (string)dr["AccountName"];
                    AccountType at = (AccountType)Enum.Parse(typeof(AccountType), Convert.ToString(dr["AccountType"]), true);
                    int ad = Convert.ToInt16(dr["AccountDepth"]);
                    string nar = (string)((dr["Narration"] == System.DBNull.Value) ? "" : dr["Narration"]);
                    string pano = (string)((dr["ParentAccountNo"] == System.DBNull.Value) ? "0" : dr["ParentAccountNo"]);
                    decimal od = Convert.ToDecimal(dr["OpeningDebit"] == System.DBNull.Value ? 0 : dr["OpeningDebit"]);
                    decimal oc = Convert.ToDecimal(dr["OpeningCredit"] == System.DBNull.Value ? 0 : dr["OpeningCredit"]);
                    decimal adb = Convert.ToDecimal(dr["AdjustedDebit"] == System.DBNull.Value ? 0 : dr["AdjustedDebit"]);
                    decimal ac = Convert.ToDecimal(dr["AdjustedCredit"] == System.DBNull.Value ? 0 : dr["AdjustedCredit"]);
                    bool id = Convert.ToBoolean(dr["IsDetailed"]);
                    bool il = Convert.ToBoolean(dr["IsLocked"]);
                    bool ip = Convert.ToBoolean(dr["IsPosted"]);
                    bool ie = Convert.ToBoolean(dr["IsEditable"]);
                    bool bf = Convert.ToBoolean(dr["BalFlag"]);
                    string pf = (string)((dr["plFlag"] == System.DBNull.Value) ? "" : dr["plFlag"]);
                    bool ef = Convert.ToBoolean(dr["ExpFlag"]);

                    accounts.Add(new ChartOfAccounts(ano, ana, at, ad, nar, new ChartOfAccounts(pano, ""), od, oc, adb, ac, id, il, ip, ie, bf, pf, ef));
                }
                return accounts;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
        }
    }
}
