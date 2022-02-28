using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Common;
using Common.Data_Sets;

namespace DAL
{
    public class SummaryDAL
    {
        Summary sum;
        List<Summary> sums;
        SaleInvoice sale = new SaleInvoice();
        List<SaleInvoiceLine> invoiceLines = new List<SaleInvoiceLine>();

        private string source = ReadProjectConfigFile.ConfigString();

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;
        SqlTransaction VTran;

        int VID;

        public int MakeSummary(int userID)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();

                VTran = con.BeginTransaction();
                
                cmd = new SqlCommand("Declare @VSummaryNo as int if exists(Select (SummaryNo) From Summary where Printed=0 and userid=" + userID + ") BEGIN (Select Max(SummaryNo) as no From Summary where Printed=0 and userid=" + userID + ") END Else Begin  Select @vsummaryNo=Isnull(Max(summaryNo),0) + 1 from summary  Insert into summary (summaryno,userid,summarydate,printed) values  (@VSummaryNo," + userID + ",(getdate()),0) select @Vsummaryno as no  END", con);
                cmd.Transaction = VTran;
                VID = Convert.ToInt32 (cmd.ExecuteScalar());

                VTran.Commit();

                con.Close();
                return VID;
            }
            catch (Exception ex)
            {
                VTran.Rollback();
                throw ex;
            }
            finally { con.Close(); }
        }

        public DataSet GetUserList(string where)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand(" select distinct(s.UserID),u.UserName from Summary s left join Users u on s.UserID=u.UserNo where  "+where+"  order by s.UserID", con);

                da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

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

        public string GetOpeningCash(string shift, int baranchid,DateTime date)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                if (shift == "Day")
                {
                    cmd = new SqlCommand(" select closingcash from Summary s where  SummaryNo=( select Max(SummaryNo) from Summary where   convert(varchar(10), SummaryDate, 120) < convert(varchar(10), '"+ date.ToString("yyyy-MM-dd") + "', 120) and branchid=" + baranchid + " and shift='Evening' )  ", con);
                }
                else if(shift=="Evening")
                {
                    cmd = new SqlCommand(" select closingcash from Summary s where  SummaryNo=( select Max(SummaryNo) from Summary where   convert(varchar(10), SummaryDate, 120) = convert(varchar(10), '" + date.ToString("yyyy-MM-dd") + "', 120) and branchid=" + baranchid + " and shift='Day' )  ", con);

                }
                decimal openingcash = Convert.ToDecimal(cmd.ExecuteScalar());
                return openingcash.ToString();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

                con.Close();
            }
        }

        public bool GetSCCSummary(ref DSPettyCash dSPetty, DateTime fromDate, DateTime toDate, int branchid)
        {
            try
            {
                Object objFrom = fromDate;
                Object objTo = toDate;
                Object objid = branchid;
                con = new SqlConnection(source);
                con.Open();

                cmd = new SqlCommand("SPShopCashCounterSummary", con);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FromDate", objFrom);
                cmd.Parameters.AddWithValue("@ToDate", objTo);
                if (branchid > 0)
                {
                    cmd.Parameters.AddWithValue("@BranchID", objid);
                }
                SqlDataAdapter da1 = new SqlDataAdapter();
                da1.SelectCommand = cmd;

                da1.Fill(dSPetty, "SPPettyCash");

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SaleInvoice GetSaleInvoie(int saleid, string saledate, int branchid)
        {
            try
            {
               
                con = new SqlConnection(source);
                con.Open();
                string select = "";
                AddInvoiceLines(saleid, saledate, branchid);
                select = " select SaleId,SaleDate,s.BranchID,s.SupplierId,p.PartyName,u.UserName,TotalAmt,TotalDiscount,TotalRetAmt,AmtPaid,PmtType,isnull(s.Bank,'')as Bank,isnull(s.CardNo,'') as CardNo    from SaleInvoice s left join Users u on s.UserNo=u.UserNo left join Parties p on s.SupplierId=p.PartyID  where saleid=" + saleid+" and saledate='"+saledate+"' and s.branchid="+branchid+" ";

                cmd = new SqlCommand(select, con);

                dr = cmd.ExecuteReader();
                AddInvoices();

                return sale;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void AddInvoices()
        {

            try
            {
                while (dr.Read())
                {
                   
                    sale.SaleID = Convert.ToInt32(dr["SaleId"]);
                    sale.Saledate= Convert.ToDateTime(dr["SaleDate"]);
                    sale.PartyID = dr["SupplierId"].ToString();
                    sale.PartyName = dr["PartyName"].ToString();
                    sale.UserName= dr["UserName"].ToString();
                    sale.Total= Convert.ToInt64(dr["TotalAmt"]);
                    sale.Totaldisc = Convert.ToInt64(dr["TotalDiscount"]);
                    sale.TotalRetAmt = Convert.ToInt64(dr["TotalRetAmt"]);
                    sale.Cashamt = Convert.ToInt64(dr["AmtPaid"]);
                    sale.Totaldisc = Convert.ToInt64(dr["TotalDiscount"]);
                    sale.PmtType = dr["PmtType"].ToString();
                    sale.BranchID = Convert.ToInt32(dr["BranchID"]);
                    sale.BankAcc = dr["Bank"].ToString();
                    sale.CardNo = dr["CardNo"].ToString();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void AddInvoiceLines(int saleid, string saledate, int branchid)
        {
             try
            {
                string selectLine = "  select ib.ItemId,ib.ItemBarCode,i.ItemName,ib.Quantity,ib.DiscPer,ib.Discount,ib.SalePrice,srno from SaleInvoiceBody ib left join Item i on ib.ItemId=i.ItemID where SaleId="+saleid+" and saledate='"+saledate+"' and branchid="+branchid+" ";
                SqlCommand cmd = new SqlCommand(selectLine, con);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    SaleInvoiceLine line = new SaleInvoiceLine();
                    line.Vitem.ItemID = Convert.ToInt32(dr["ItemId"]);
                    line.Vitem.BarCode = dr["ItemBarCode"].ToString();
                    line.ItemName = dr["ItemName"].ToString();
                    line.Quantity = Convert.ToInt32(dr["Quantity"]);
                    line.Discper = Convert.ToDecimal(dr["DiscPer"]);
                    line.Disc = Convert.ToDecimal(dr["Discount"]);
                    line.SalePrice = Convert.ToDecimal(dr["SalePrice"]);
                    line.SerialNumber = Convert.ToInt32(dr["srno"]);
                    invoiceLines.Add(line);
                    sale.SaleLines = invoiceLines;
                }
               

              
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally { dr.Close(); }
        }

        public Summary GetSummary(int summaryno,int branchid)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();

                cmd = new SqlCommand(" execute SPSummary "+summaryno+",  "+ branchid + "  ", con);
                dr = cmd.ExecuteReader();
                Summary sum = new Summary();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        sum.TotalSale = Convert.ToDecimal(dr["SaleAmt"]);
                        sum.TotalPayment = Convert.ToDecimal(dr["Payment"]);
                        sum.CreditCard=Convert.ToDecimal(dr["CreditCard"]);


                    }
                }
                return sum;
                
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

                con.Close();
            }
        }

        public Summary GetUser(int userNo)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();

                cmd = new SqlCommand("   select s.SummaryNo from Summary s left join Users u on s.UserID=u.UserNo where printed=0 and  u.UserNo=" + userNo + " order by s.UserID  ", con);
                dr = cmd.ExecuteReader();
                Summary sum = new Summary();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                       
                        sum.SummaryID = Convert.ToInt32(dr["SummaryNo"]);
                    }
                }
                return sum;

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

        public bool GetPettyCashData(ref DSPettyCash dSPetty, int summaryID)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
              
                cmd = new SqlCommand(" select s.SummaryNo, SummaryDate, u.UserName, s.Printed, s.Cash, s.OpeningCash, s.BankDeposite, s.ClosingCash , CashSale , CreditCard ,s.PaymentVoucher, s.shift, b.BranchName, s.Coin1, s.Coin2, s.Coin5, s.Note10, s.Note20, s.Note50, s.Note100, s.Note500, s.Note1000, s.Note5000 from Summary s left join Users u on s.UserID = u.UserNo left join Branch b on s.branchid = b.ID where SummaryNo = " + summaryID + " ", con);
                cmd.Transaction = VTran;
                da = new SqlDataAdapter(cmd);

                da.Fill(dSPetty, "DSPettyCash");
                return true;
            }
            catch (Exception)
            {
              
                throw;
            }
            finally
            {
              
                con.Close();
            }
        }

        public int GetSummaryNo(int userid)
        {
            try
            {                                        
                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand(" select SummaryNo from Summary  where  Printed=0 and UserID=" + userid+" ",con);
                int sumno = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
                return sumno;

             
            }
            catch (Exception ex)
            {
                VTran.Rollback();
                throw ex;
            }
            finally
            {
                con.Close();
            }

        }

        public bool SaveCash(Summary sum)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();

                VTran = con.BeginTransaction();
                cmd = new SqlCommand("Update Summary Set Printed= 1 ,  PrintedDate='"+sum.PrintedDate+"', coin1=" + sum.Coin1+",coin2="+sum.Coin2+",coin5="+sum.Coin5+",note10="+sum.Note10+",note20="+sum.Note20+",note50="+sum.Note50+",note100="+sum.Note100+",note500="+sum.Note500+",note1000="+sum.Note1000+",note5000="+sum.Note5000+" ,   Cash=" + sum.PettyCash + ", OpeningCash="+sum.OpeningCash+", BankDeposite="+sum.BankDeposite+", ClosingCash="+sum.ClosingCash+",CashSale="+sum.TotalSale+",CreditCard="+sum.CreditCard+",PaymentVoucher="+sum.TotalPayment+", BranchID="+sum.BarnchID+", Shift='"+sum.Shift+"'  where SummaryNo=" + sum.SummaryID, con);
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

        public DataSet GetSummaries(int userID,string date)
        {
            try
            {
                DataSet ds = new DataSet();
                if (sums == null) sums = new List<Summary>();
                string select;

                if (userID == 0)
                {
                    //select = "Select * from Summary inner join Users on Users.userNo=Summary.UserID";  
                    select = "Select SummaryNo,(cast(SummaryNo as varchar(10))+' - ' + Convert(varchar(10), SummaryDate,120)+' - ' + + UserName) as Summary from Summary inner join Users on Users.userNo=Summary.UserID where Printed=0";
                }
                else
                    select = "Select SummaryNo from Summary inner join Users on Users.userNo=Summary.UserID  where  userID=" + userID;
                //select = "Select SummaryNo from Summary inner join Users on Users.userNo=Summary.UserID  where convert(varchar(10), SummaryDate, 120)='" + date+"' and  userID=" + userID;

                con = new SqlConnection(source);
                con.Open();

                VTran = con.BeginTransaction();
                cmd = new SqlCommand(select, con);
                cmd.Transaction = VTran;
                // dr = cmd.ExecuteReader();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                
                //Add Users to Collection
                //AddSummary();

                VTran.Commit();
                con.Close();
                return ds;
            }
            catch (Exception ex)
            {
                VTran.Rollback();
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        
        public void AddSummary()
        {
            try
            {
                sum = new Summary();
                User newUser;
               
                while (dr.Read())
                {
                    newUser = new User(Convert.ToInt32(dr["UserID"]),(string)dr["UserName"],"");

                    sum = new Summary(Convert.ToInt32(dr["SummaryNo"]), Convert.ToDateTime(dr["SummaryDate"]), Convert.ToBoolean(dr["Printed"]), newUser);
                    sum.PettyCash = Convert.ToDecimal(dr["Cash"] == System.DBNull.Value ? 0 : dr["Cash"]);
                    sums.Add(sum);
                }
                dr.Close();                
            }
            catch (Exception ex) { throw ex; }

            finally { dr.Close(); }

        }

        public Summary GetSummaryDetail(int UserID)
        {
            try
            {
                sum = new Summary();

                string select = "Select * from Summary inner join Users on Users.userNo=Summary.UserID where Printed=0 and userID=" + UserID;

                con = new SqlConnection(source);
                con.Open();

                VTran = con.BeginTransaction();
                cmd = new SqlCommand(select, con);
                cmd.Transaction = VTran;
                dr = cmd.ExecuteReader();

                User newUser;

                while (dr.Read())
                {
                    newUser = new User(Convert.ToInt32(dr["UserID"]), (string)dr["UserName"], "");

                    sum = new Summary(Convert.ToInt32(dr["SummaryNo"]), Convert.ToDateTime(dr["SummaryDate"]), Convert.ToBoolean(dr["Printed"]), newUser);

                    sum.PettyCash = Convert.ToDecimal(dr["Cash"] == System.DBNull.Value ? 0 : dr["Cash"]);
                }
                dr.Close();

                return sum;
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public bool UpdateSummary(Int64 SummaryNo)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();

                VTran = con.BeginTransaction();
                cmd = new SqlCommand("Update Summary Set Printed=1, PrintedDate=getdate() where SummaryNo=" + SummaryNo, con);
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

        public bool UpdateSummary(Summary sum)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();

                VTran = con.BeginTransaction();
                cmd = new SqlCommand("Update Summary Set Cash="+ sum.PettyCash +" where SummaryNo=" + sum.SummaryID, con);
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
    }
}
