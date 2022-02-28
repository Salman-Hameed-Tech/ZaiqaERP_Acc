
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;

using Common;

namespace DAL
{
    public class VendorDAL
    {
        private Vendor v;
        private List<Vendor> vendors = new List<Vendor>();
        private List<Branch> branches = new List<Branch>();

        private string source = ReadProjectConfigFile.ConfigString();
        private string Msource = ReadProjectConfigFile.MConfigString();
        SqlConnection con;
        SqlConnection conLocal;
        SqlCommand cmd;

        SqlTransaction VTran;
        SqlTransaction VTranLocal;
        SqlDataReader dr;


        public bool DeleteLocalParty(string accountNo)
        {
            try
            {
                if (Msource.ToString().Trim().Length == 0) return true;
                conLocal = new SqlConnection(Msource);
                conLocal.Open();
                VTranLocal = conLocal.BeginTransaction();

                string deleteAccount = "Delete From Parties where PartyID='" + accountNo + "'";
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
        public Vendor GetPartyDetail(string accountNo)
        {
            Vendor ven = new Vendor();
            try
            {
                string select = "Select * from Parties where PartyID='"+accountNo+"'";
                AddBranches(accountNo);
                con = new SqlConnection(source);
                con.Open();
               
                cmd = new SqlCommand(select, con);

                dr = cmd.ExecuteReader();              
                              
                while (dr.Read())
                {
                    ven = new Vendor(new ChartOfAccounts((string)dr["PartyID"], (string)dr["PartyName"]), new Address((string)dr["address"], (string)dr["city"], "", Convert.ToInt32(dr["SectorID"])), (string)dr["phone1"], (string)dr["phone2"], (string)dr["mobile"], (string)dr["fax"], (string)dr["email"], (string)dr["ContactPerson"], (bool)(dr["InPurchase"] == System.DBNull.Value ? 0 : dr["InPurchase"]), (bool)(dr["InSale"] == System.DBNull.Value ? 0 : dr["InSale"]));
                    
                    ven.BranchList = branches;
                }
                dr.Close();

                con.Close();
                return ven;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        private void AddBranches(string accountNo)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();

                cmd = new SqlCommand("  select cob.BranchID,cob.PartyID,b.BranchName from COABranch cob left join branch b on cob.BranchID=b.id where cob.partyid='" + accountNo + "'", con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Branch b = new Branch();
                    b.ID = Convert.ToInt32(dr["BranchID"]);
                    b.BranchName = dr["BranchName"].ToString();
                    b.Select = true;
                    branches.Add(b);

                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
        }
        public void AddVendors()
        {
            try
            {
                Vendor newVendor;               

                while (dr.Read())
                {
                    newVendor = new Vendor(new ChartOfAccounts((string)dr["PartyID"], (string)dr["PartyName"]), new Address((string)dr["address"], (string)dr["city"], ""), (string)dr["phone1"], (string)dr["phone2"], (string)dr["mobile"], (string)dr["fax"], (string)dr["email"], (string)dr["ContactPerson"], (bool)(dr["InPurchase"] == System.DBNull.Value ? "false" : dr["InPurchase"]), (bool)(dr["InSale"] == System.DBNull.Value ? "false" : dr["InSale"]));
                    vendors.Add(newVendor);
                }
                dr.Close();
                con.Close();
            }
            catch (Exception ex) { throw ex; }

            finally { dr.Close(); }

        }

        public bool SaveParty(Vendor v, ChartOfAccounts acc, bool isNew,string type)
        {
            try
            {
                int VID = 0;
                con = new SqlConnection(source);
                con.Open();
                VTran = con.BeginTransaction();

                if (isNew)//Insert
                {

                    string insertAccount = "Insert Into ChartofAccounts(AccountNo,UserNo,AccountName,AccountType,AccountDepth,Narration,ParentAccountNo,OpeningDebit,OpeningCredit,AdjustedDebit,AdjustedCredit,IsDetailed,IsLocked,IsPosted,IsEditable,BalFlag,PLFlag,ExpFlag,GRVAccountNo) Values('" + acc.AccountNo + "','" + User.UserNo + "','" + acc.AccountName + "','" + acc.AccountType.ToString() + "'," + acc.AccountDepth + ",'" + acc.Narration + "','" + acc.ParentAccount.AccountNo + "'," + acc.OpeningDebit + "," + acc.OpeningCredit + "," + acc.AdjustedDebit + "," + acc.AdjustedCredit + "," + Convert.ToInt16(acc.IsDetailed) + "," + Convert.ToInt16(acc.IsLocked) + "," + Convert.ToInt16(acc.IsPosted) + "," + Convert.ToInt16(acc.IsEditable) + "," + Convert.ToInt16(acc.BalFlag) + ",'" + acc.PlFlag + "'," + Convert.ToInt16(acc.ExpFlag) + "," + (acc.GRVAccount == "NULL" ? "NULL" : "'" + acc.GRVAccount + "'") + ")";
                    cmd = new SqlCommand(insertAccount, con);
                    cmd.Transaction = VTran;
                    cmd.ExecuteNonQuery();

                    string insertParty = "Insert into Parties(PartyID,PartyName,SectorID,Address,City,Phone1,Phone2,Mobile,Fax,Email,ContactPerson,PartyType,InPurchase,InSale,ispos) Values(" + v.Id.AccountNo + ",'" + v.Name + "'," + v.Address.Sector + ",'" + v.Address.AdressLine + "','" + v.Address.City + "','" + v.PhoneHome.ToString() + "','" + v.PhoneOffice.ToString() + "','" + v.Mobile.ToString() + "','" + v.Fax.ToString() + "','" + v.Email + "','" + v.ContactPerson + "','" + type + "'," + Convert.ToInt16(v.InPurchase) + "," + Convert.ToInt16(v.InSale) + "," + Convert.ToInt16(v.IsPos) + ")";
                    cmd.CommandText = insertParty;
                    cmd.Transaction = VTran;
                    cmd.ExecuteNonQuery();

                    foreach (Branch b in v.BranchList)
                    {
                        cmd.CommandText = SetPurInsertBranch(b, v.Id.AccountNo);
                        cmd.ExecuteNonQuery();

                    }

                }
                else//update
                {

                    string updateAccount = "Update ChartofAccounts Set AccountName='" + acc.AccountName + "',Narration='" + acc.Narration + "',GRVAccountNo=" + (acc.GRVAccount == "NULL" ? "NULL" : "'" + acc.GRVAccount + "'") + " where AccountNo='" + acc.AccountNo + "'";
                    cmd = new SqlCommand(updateAccount, con);
                    cmd.Transaction = VTran;
                    cmd.ExecuteNonQuery();


                    string insertParty = "Update Parties set PartyName='" + v.Name + "',Address='" + v.Address.AdressLine + "',SectorID=" + v.Address.Sector + ",City='" + v.Address.City + "',Phone1='" + v.PhoneHome.ToString() + "',Phone2='" + v.PhoneOffice.ToString() + "',Mobile='" + v.Mobile.ToString() + "',Fax='" + v.Fax + "',Email='" + v.Email + "',ContactPerson='" + v.ContactPerson + "',InPurchase=" + Convert.ToInt16(v.InPurchase) + ",InSale=" + Convert.ToInt16(v.InSale) + ",ispos=" + Convert.ToInt16(v.IsPos) + " where PartyID='" + v.Id.AccountNo + "'";
                    cmd.CommandText = insertParty;
                    cmd.Transaction = VTran;
                    cmd.ExecuteNonQuery();

                    insertParty = " Delete from COABranch where partyid='" + v.Id.AccountNo + "' ";
                    cmd = new SqlCommand(insertParty, con);
                    cmd.Transaction = VTran;
                    cmd.ExecuteNonQuery();

                    foreach (Branch b in v.BranchList)
                    {
                        cmd.CommandText = SetPurInsertBranch(b, v.Id.AccountNo);
                        cmd.ExecuteNonQuery();

                    }

                }

               

                VTran.Commit();

                return true;
            }
            catch (Exception ex)
            {
                VTran.Rollback();
                throw ex;
            }
            finally
            { con.Close(); }
        }

        public bool SaveLocalParty(Vendor v, bool isNew, string type)
        {
            try
            {
                if (Msource.ToString().Trim().Length == 0) return true;
                int VID = 0;
                conLocal = new SqlConnection(Msource);
                conLocal.Open();
                VTranLocal = conLocal.BeginTransaction();
                string insert = "";

                if (isNew)
                {
                    insert = "Insert into Parties(PartyID,PartyName,SectorID,Address,City,Phone1,Phone2,Mobile,Fax,Email,ContactPerson,PartyType,InPurchase,InSale,ispos) Values(" + v.Id.AccountNo + ",'" + v.Name + "'," + v.Address.Sector + ",'" + v.Address.AdressLine + "','" + v.Address.City + "','" + v.PhoneHome.ToString() + "','" + v.PhoneOffice.ToString() + "','" + v.Mobile.ToString() + "','" + v.Fax.ToString() + "','" + v.Email + "','" + v.ContactPerson + "','" + type + "'," + Convert.ToInt16(v.InPurchase) + "," + Convert.ToInt16(v.InSale) + "," + Convert.ToInt16(v.IsPos )  + ")";
                }
                else
                {
                    insert = "Update Parties set PartyName='" + v.Name + "',Address='" + v.Address.AdressLine + "',SectorID=" + v.Address.Sector + ",City='" + v.Address.City + "',Phone1='" + v.PhoneHome.ToString() + "',Phone2='" + v.PhoneOffice.ToString() + "',Mobile='" + v.Mobile.ToString() + "',Fax='" + v.Fax + "',Email='" + v.Email + "',ContactPerson='" + v.ContactPerson + "',InPurchase=" + Convert.ToInt16(v.InPurchase) + ",InSale=" + Convert.ToInt16(v.InSale) + ",ispos=" + Convert.ToInt16(v.IsPos )  + " where PartyID='" + v.Id.AccountNo + "'";
                }

                cmd = new SqlCommand(insert, conLocal);
                cmd.Transaction = VTranLocal;
                cmd.ExecuteNonQuery();
                VTranLocal.Commit();

                return true;
            }
            catch (Exception ex)
            {
                VTranLocal.Rollback();
                throw ex;
            }
            finally
            { conLocal.Close(); }
        }

        private string SetUpadteBranch(Branch b, string accountNo)
        {
            try
            {
                string update = "Update COABranch set PartyID=" + accountNo + ",BranchID = " + b.ID + ")";
                return update;
            }
            catch
            {
                VTran.Rollback();
                throw;
            }
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

        public bool DeleteParty(string accountNo)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                VTran = con.BeginTransaction();

                string deleteAccount = "Delete From Parties where PartyID='" + accountNo + "'";
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

        //Get Sale and Purchase Invoice Information       
        //////////////////////////////////////////////////////////////////////////////////////////////////////////
       

    }
}
