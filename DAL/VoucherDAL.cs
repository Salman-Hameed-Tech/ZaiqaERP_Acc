
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Common;

namespace DAL
{
   public class VoucherDAL
    {

       private string source = ReadProjectConfigFile.ConfigString();
       
       private List<Voucher  > vouchers;
       private List<PDCVoucher> pdcvouchers; 
       List<ChartOfAccounts  > accounts = new List<ChartOfAccounts>();
       List<PDCVoucherBody> pdclines = new List<PDCVoucherBody>();

       SqlDataAdapter da = new SqlDataAdapter();

       List<VoucherInvoice> invoices;

        SqlConnection con;
        SqlCommand cmd;
       
        SqlTransaction VTran;
        SqlDataReader dr;


       #region Get maximum ID for Voucher
        /// <summary>
       /// Get Maximum ID.
       /// </summary>
       /// <returns></returns>
       public int GetMaximumID(Voucher v)
       {
           try
           {

               int VID = 0;

               con = new SqlConnection(source);
               con.Open();
               
               string VoucherWhere = "where BranchID="+Globals.BranchID+"  and  VoucherType = '" + v.VoucherType.ToString() + "' and MONTH (VoucherDate) = " + v.VoucherDate.Month + " and YEAR (VoucherDate ) = " + v.VoucherDate.Year;

               if (v.VoucherType == VoucherType.BPV || v.VoucherType == VoucherType.BRV || v.VoucherType == VoucherType .BCV || v.VoucherType == VoucherType .BDV )
               {
                   VoucherWhere += " and BankAccNo = '" + v.BankAccNo.AccountNo + "'";
               }
               
               cmd = new SqlCommand("Select IsNull(Max(VoucherNo),0) +1 From AccVouchersBody " + VoucherWhere  , con);
               VID = Convert.ToInt32(cmd.ExecuteScalar());

               return VID;
           }
           catch
           {
               throw;
           }
       }
       public int GetMaximumIDD(PDCVoucher v)
       {
           try
           {

               int VID = 0;

               con = new SqlConnection(source);
               con.Open();

               string VoucherWhere = "where VoucherType = '" + v.VoucherType.ToString() + "' and MONTH (VoucherDate) = " + v.VoucherDate.Month + " and YEAR (VoucherDate ) = " + v.VoucherDate.Year;

                   VoucherWhere += " and BankAccNo = '" + v.BankAccounts.AccountNo + "'";

               cmd = new SqlCommand("Select IsNull(Max(VoucherNo),0) +1 From AccVouchersBody " + VoucherWhere, con);
               VID = Convert.ToInt32(cmd.ExecuteScalar());

               return VID;
           }
           catch
           {
               throw;
           }
       }


        #endregion 

       /////////////////////////////////////////////////////////////////////////////////////////////////////////

       #region Delete Voucher

       /// <summary>
       /// Delete record upon given ID
       /// </summary>
       /// <param name="VID"></param>
       /// <returns></returns>
       public bool DeleteVoucher(Voucher v)
       {
           try
           {
                con = new SqlConnection(source);
               con.Open();

               VTran = con.BeginTransaction();

               string BodyWhere = " where  Branchid=" + v.PrevBranchID + "   and  VoucherNo = " + v.VoucherNo + " and  VoucherType = '" + v.VoucherType.ToString() + "' and MONTH (VoucherDate) = " + v.PreVoucherDate.Month + " and YEAR (VoucherDate ) = " + v.PreVoucherDate.Year;


               if (v.VoucherType == VoucherType.BPV || v.VoucherType == VoucherType.BRV || v.VoucherType == VoucherType.BCV || v.VoucherType == VoucherType.BDV)
               {
                  // BodyWhere += " and BankAccNo = '" + v.BankAccNo.AccountNo + "'";                   
               }

               cmd = new SqlCommand(" insert into accvouchersbodytrail select *,'Deleted'," + User.UserNo  + ",getdate() from accvouchersbody "  +BodyWhere  + "  Delete From AccVouchersBody " + BodyWhere, con);
               cmd.Transaction = VTran;
               cmd.ExecuteNonQuery();
                             
               VTran.Commit();
               return true;
           }
           catch
           {
               VTran.Rollback();
               throw;
           }
           finally 
           {
               con .Close ();
           }
       }

       #endregion

       /////////////////////////////////////////////////////////////////////////////////////////////////////////

       #region Save Voucher

       /// <summary>
       /// Depending upon isNew state insertion or update in done.
       /// </summary>
       /// <param name="sale"></param>
       /// <param name="isNew"></param>
       /// <returns></returns>    


       public int SaveVoucher(Voucher v, bool isNew)
       {
           try
           {
               int VID = 0;
               con = new SqlConnection(source);
               con.Open();
               VTran = con.BeginTransaction();

               //Deletion made on previous date.
               ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
               string voucherCondition =  " and VoucherNo = " + v.VoucherNo;
               string BodyWhere = " Where  BranchID=" + v.PrevBranchID + " and  VoucherType = '" + v.VoucherType.ToString() + "' and MONTH (VoucherDate) = " + v.PreVoucherDate.Month + " and YEAR (VoucherDate ) = " + v.PreVoucherDate.Year;

               if (v.VoucherType == VoucherType.BPV || v.VoucherType == VoucherType.BRV ||  v.VoucherType == VoucherType.BCV || v.VoucherType == VoucherType.BDV)
               {
                   BodyWhere += " and BankAccNo = '" + v.BankAccNo.AccountNo + "'";                   
               }
               cmd = new SqlCommand(" insert into accvouchersbodytrail  select *,'Edited'," + User.UserNo  + ",getdate()from accvouchersbody  " + BodyWhere + voucherCondition +  " Delete From AccVouchersBody " + BodyWhere + voucherCondition, con);
               cmd.Transaction = VTran;
               
               if (isNew == false)
               {
                   cmd.ExecuteNonQuery();
               }
               
               ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

               BodyWhere = " Where  BranchID=" + Globals.BranchID + " and VoucherType = '" + v.VoucherType.ToString() + "' and MONTH (VoucherDate) = " + v.VoucherDate.Month + " and YEAR (VoucherDate ) = " + v.VoucherDate.Year;

               if (v.VoucherType == VoucherType.BPV  || v.VoucherType == VoucherType.BRV ||  v.VoucherType == VoucherType.BCV || v.VoucherType == VoucherType.BDV)
               {
                   BodyWhere += " and BankAccNo = '" + v.BankAccNo.AccountNo + "'";
               }
               ///////////////////////////////////////////////////////////////////////
               ///


               if (isNew) // If new then get maximum ID for present date.
               {
                   cmd.CommandText = "Select IsNull(Max(VoucherNo),0) +1 From AccVouchersBody " + BodyWhere;
                   VID = Convert.ToInt32(cmd.ExecuteScalar());
               }
               else // If Update.
               {
                   //Check if voucher ID already exists for the month.
                   cmd.CommandText = "Select count(VoucherNo) From AccVouchersBody " + BodyWhere + voucherCondition ;
                   int count = Convert.ToInt32(cmd.ExecuteScalar());

                   if (count > 0) //If Exists get maximum id for the month
                   {
                       cmd.CommandText = "Select IsNull(Max(VoucherNo),0) +1 From AccVouchersBody " + BodyWhere;
                       VID = Convert.ToInt32(cmd.ExecuteScalar());
                   }
                   else // Else Same id passed from the form is used for insertion.
                   {
                       VID = v.VoucherNo;
                   }
               }                

                foreach (ChartOfAccounts   pl in v.Accounts  )
                {
                    cmd.CommandText = "Insert Into AccVouchersBody(VoucherType,VoucherNo,VoucherDate,AccountNo,Narration,Debit,Credit,RefNo,SummaryNo,BankAccNo,CheckNo,CheckDate,InvoiceNo,IsPrinted,IsEdited,UserNo,BranchID) Values('" + v.VoucherType.ToString() + "'," + VID + ",'" + v.VoucherDate.ToString("yyyy/MM/dd 00:00:00") + "','" + pl.AccountNo + "','" + pl.Narration + "'," + pl.Dr + "," + pl.Cr + "," + v.User.UserID + ","+Summary.SummaryNo+ "," + (v.BankAccNo.AccountNo.Length == 0 ? "NULL" : "'" + v.BankAccNo.AccountNo + "'") + ",'" + v.CheckNo + "','" + v.CheckDate.ToString("yyyy-MM-dd 00:00:00") + "'," + (pl.InvoiceNo == 0 ? "NULL" : pl.InvoiceNo.ToString()) + "," + Convert.ToInt32(v.IsPrinted) + ",0,"+User.UserNo+","+Globals.BranchID+")";
                    cmd.ExecuteNonQuery();
                }

                cmd.CommandText = "Execute SPAddBankVouchers " + VID + ",'" + v.VoucherType.ToString() + "','" + v.VoucherDate.Date.ToString("yyyy-MM-dd 00:00:00") + "','" + v.BankAccNo.AccountNo + "'";
                cmd.ExecuteNonQuery();

                VTran.Commit();
               con.Close();
               return VID ;
           }

           catch
           {
               VTran.Rollback();
               throw;
           }
           finally { con.Close(); }
       }

        public DataSet GetVoucherData(int iD, Voucher v)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                VTran = con.BeginTransaction();
                string select = "";

                string bodyWhere = " where  VoucherType = '" + v.VoucherType.ToString() + "' AND AVB.AccountNo <> (select Top 1 TransitAcc from FixedAccounts) and AVB.AccountNo Not Like '" + Globals.PurchaseTranporter + "%' ";
                string voucherCondtion = " and MONTH (VoucherDate) = " + v.VoucherDate.Month + " AND YEAR (VoucherDate ) = " + v.VoucherDate.Year + " and VoucherNo = " + v.VoucherNo;

                string CurrentDateWhere = "  WHERE  AB.VoucherDate = AVB.VoucherDate  AND AB.Accountno = AVB.Accountno  AND  AB.VoucherNo < AVB.VoucherNo AND AB.IsPrinted = 1 ";

                if (v.VoucherType == VoucherType.BPV || v.VoucherType == VoucherType.BRV || v.VoucherType == VoucherType.BCV || v.VoucherType == VoucherType.BDV)
                {
                    if (v.BankAccNo.AccountNo.Length != 0)
                    {
                        //bodyWhere += " and BankAccNo = '" + v.BankAccNo.AccountNo + "' and BankAccNo <> AccountNo";
                        bodyWhere += " and BankAccNo = '" + v.BankAccNo.AccountNo + "'";
                        CurrentDateWhere += " AND BankAccNo = '" + v.BankAccNo.AccountNo + "' ";
                    }
                }
                cmd = new SqlCommand("select VoucherType,P.Name AS PrefixName,RTRIM(VoucherType) + '-' + SUBSTRING(ISNULL(BankAccNo,'00'),LEN(ISNULL(BankAccNo,'00')) - 1,LEN(ISNULL(BankAccNo,'00'))) + '-' + SUBSTRING(CONVERT(VARCHAR,VoucherDate,107),0,4) + '-' + CAST(VoucherNo AS VARCHAR(10)) AS VoucherNo,(SELECT SUM(Balance) FROM(SELECT SUM(ISNULL(OpeningDebit,0) - ISNULL(OpeningCredit ,0)) as Balance from ChartOfAccounts AB  where  AB.Accountno =  AVB.Accountno UNION ALL SELECT SUM(ISNULL(Debit,0)- ISNULL(Credit,0)) as Balance from AccVouchersBody  AB   where  AB.VoucherDate < AVB.VoucherDate  AND AB.Accountno = AVB.Accountno AND AB.IsPrinted = 1 ) AS TB) + IsNull((SELECT  SUM(IsNull(Debit,0) -  IsNull(Credit,0))  from AccVouchersBody AB   " + CurrentDateWhere + " ),0) AS PreviousBalance,VoucherDate,AVB.Accountno,COA.AccountName, dbo.ProperCase(AVB.Narration) as Narration ,AVB.Debit,AVB.Credit,AVB.BankAccNo,AVB.CheckNo,AVB.CheckDate,AVB.IsPosted,AVB.IsPrinted,(Select Top 1 Signature FROM Users WHERE IsAdministrator = 1) AS AdminSignatures,U.Signature AS UserSignatures,(Select UserName From Users WHERE UserNo = " + User.UserNo + ") AS PrintedBy from AccVouchersBody AVB INNER JOIN ChartOfAccounts COA ON COA.AccountNo = AVB.AccountNo LEFT OUTER JOIN Users U ON U.UserNo = AVB.UserNo LEFT OUTER JOIN Prefix P ON P.ID = PrefixID  " + bodyWhere + voucherCondtion + " ORDER BY Credit",con);
               
                cmd.Transaction = VTran;
                da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
            catch (Exception)
            {
                VTran.Rollback();
                throw;
            }
            finally
            {
                VTran.Commit();
                con.Close();
            }
        }

        //////////////////////////pdc vocuvher

        public int SavepdcVoucher(PDCVoucher v, bool isNew)
       {
           try
           {
               int VID = 0;
               int VIDD= 0;
               con = new SqlConnection(source);
               con.Open();
               VTran = con.BeginTransaction();
               cmd = new SqlCommand("",con);

               //Deletion made on previous date.
               ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
               string voucherCondition = " and VoucherNo = " + v.VoucherNo;
               string BodyWhere = " Where VoucherType = '" + v.VoucherType.ToString() + "' and PartyAccNo = '" + v.PartyAccounts.AccountNo + "' and MONTH (VDate) = " + v.PreVoucherDate.Month + " and YEAR (VDate ) = " + v.PreVoucherDate.Year;// and PartyAccNo = '" + v.PartyAccounts.AccountNo + "'
               BodyWhere += " and BankAccNo = '" + v.BankAccounts.AccountNo + "'";

               cmd = new SqlCommand("Delete From AccVouchersBody " + BodyWhere + voucherCondition, con);
               cmd.Transaction = VTran;

               if (isNew == false)
               {
                   cmd.ExecuteNonQuery();
               }

               ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


               BodyWhere = " Where VoucherType = '" + v.VoucherType.ToString() + "' and  MONTH (VDate) = " + v.PreVoucherDate.Month + " and YEAR (VDate ) = " + v.PreVoucherDate.Year;
               BodyWhere += " and BankAccNo = '" + v.BankAccounts.AccountNo + "'";
               if (isNew) // If new then get maximum ID for present date.
               {
                   cmd.CommandText = "Select IsNull(Max(VoucherNo),0) +1 From AccVouchersBody " + BodyWhere;
                   cmd.Transaction = VTran;
                   VID = Convert.ToInt32(cmd.ExecuteScalar());
               }

               else // If Update.
               {
                   //Check if voucher ID already exists for the month.
                   cmd.CommandText = "Select count(VoucherNo) From AccVouchersBody " + BodyWhere + voucherCondition;
                   int count = Convert.ToInt32(cmd.ExecuteScalar());

                   if (count > 0) //If Exists get maximum id for the month
                   {
                       cmd.CommandText = "Select IsNull(Max(VoucherNo),0) +1 From AccVouchersBody " + BodyWhere;
                       VID = Convert.ToInt32(cmd.ExecuteScalar());
                   }
                   else // Else Same id passed from the form is used for insertion.
                   {
                       VID = v.VoucherNo;
                   }
               }
               


               foreach (PDCVoucherBody pl in v.PDCVoucherLines)
               {

                   BodyWhere = " Where VoucherType = '" + v.VoucherType.ToString() + "' and  MONTH (VDate) = " +v.VoucherDate.Month + " and YEAR (VDate ) = " + v.VoucherDate.Year;
                   BodyWhere += " and BankAccNo = '" + v.BankAccounts.AccountNo + "'";


                   //cmd.CommandText = "Select IsNull(Max(VoucherNo),0) +1 From AccVouchersBody " + BodyWhere;
                   //VID = Convert.ToInt32(cmd.ExecuteScalar());
                   
                   cmd.CommandText = "Insert Into AccVouchersBody(VoucherType,VoucherNo,VoucherDate,Narration,Debit,Credit,UserNo,BankAccNo,CheckNo,CheckDate,IsPosted,IsEdited,PartyAccNo,accountno,vdate ) Values('" + v.VoucherType.ToString() + "'," + VID + ",'" + pl.ChequeDate.ToString("yyyy-MM-dd 00:00:00")  + "','" + pl.Narration + "'," + pl.Dr + "," + pl.Cr + "," + User.UserNo + "," + (v.BankAccounts.AccountNo.Length == 0 ? "NULL" : "'" + v.BankAccounts.AccountNo + "'") + ",'" + pl.ChequeNo + "','" + pl.ChequeDate + "',0," + (isNew ? "NULL" : "1") + "," + (v.PartyAccounts.AccountNo.Length == 0 ? "NULL" : "'" + v.PartyAccounts.AccountNo + "'") + "," + (v.PartyAccounts.AccountNo.Length == 0 ? "NULL" : "'" + v.PartyAccounts.AccountNo + "'") + ",'" + v.VoucherDate.ToString("yyyy-MM-dd 00:00:000")   +  "')";
                   cmd.ExecuteNonQuery();





                   if (v.VoucherType.ToString() == "PDCI")
                   {
                       cmd.CommandText = "Insert into AccVouchersBody(VoucherType,VoucherNo,VoucherDate,AccountNo,Narration,Debit,Credit,RefNo,BankAccNo,CheckNo,CheckDate,IsPrinted,UserNo,IsEdited  ,vdate,partyaccno  ) Values ('PDCI'," + VID + ",'" + pl.ChequeDate.ToString("yyyy-MM-dd 00:00:00") + "' ,'211' ,'" + pl.Narration + "' ," + pl.Cr + "," + pl.Dr  + " ,Null,'" + v.BankAccounts.AccountNo + "','" + pl.ChequeNo + "','" + pl.ChequeDate.ToString("yyyy-MM-dd 00:00:00") + "',1," + User.UserNo + ",0,'" + v.VoucherDate.ToString("yyyy-MM-dd 00:00:00")   +  "'," + v.PartyAccounts.AccountNo   +  ")";
                       cmd.ExecuteNonQuery();

                       cmd = new SqlCommand("Select IsNull(Max(ID),0) +1 From ChequeClearance", con);
                       cmd.Transaction = VTran;
                       VIDD = Convert.ToInt32(cmd.ExecuteScalar());

                       cmd.CommandText = " delete from chequeclearance where vouchertype='" + v.VoucherType.ToString() + "' and voucherno=" + v.VoucherNo + " and vdate='" + v.PreVoucherDate.ToString("yyyy-MM-dd 00:00:00") + "'";
                       cmd.ExecuteNonQuery(); 
                       cmd.CommandText = "Insert Into ChequeClearance(ID,ChqNo,VoucherNo,VoucherDate,Amount,Clear,Disown,Resubmitted,IsChecked,voucherType,AccountNo,Bank,ChequeDate,vdate ) Values(" + VIDD + ",'" + pl.ChequeNo + "','" + VID + "','" + pl.ChequeDate.ToString("yyyy-MM-dd 00:00:00") + "'," + pl.Dr + "," + 0 + "," + 0 + "," + 0 + "," + 1 + ",'" + v.VoucherType.ToString() + "'," + (v.PartyAccounts.AccountNo.Length == 0 ? "NULL" : "'" + v.PartyAccounts.AccountNo + "'") + "," + 1 + ",'" + pl.ChequeDate.ToString("yyyy-MM-dd 00:00:00") + "','" + v.VoucherDate.ToString("yyyy-MM-dd 00:00:00")    +  "')";
                       cmd.ExecuteNonQuery();
                   }
                   else
                   {
                       cmd.CommandText = "Insert into AccVouchersBody(VoucherType,VoucherNo,VoucherDate,AccountNo,Narration,Debit,Credit,RefNo,BankAccNo,CheckNo,CheckDate,IsPrinted,UserNo,IsEdited,vdate,partyaccno   ) Values ('PDCR'," + VID + ",'" + pl.ChequeDate.ToString("yyyy-MM-dd 00:00:00") + "' ,'11010' ,'" + pl.Narration + "' ," + pl.Cr + "," + pl.Dr   + " ,Null,'" + v.BankAccounts.AccountNo + "','" + pl.ChequeNo + "','" + pl.ChequeDate.ToString("yyyy-MM-dd 00:00:00") + "',1," + User.UserNo + ",0,'" + v.VoucherDate.ToString("yyyy-MM-dd 00:00:00")    +  "'," + v.PartyAccounts.AccountNo   +  "  )";
                       cmd.ExecuteNonQuery(); 
                   }
               }

               

               VTran.Commit();
               con.Close();
               return VID;
           }

           catch
           {
               VTran.Rollback();
               throw;
           }
           finally { con.Close(); }
       }

       //////////////////////////////////////end pdc voucher

       #endregion

       /////////////////////////////////////////////////////////////////////////////////////////////////////////
       public bool SaveClearance(Voucher v, bool isNew) 
       {
           try
           {
               
               con = new SqlConnection(source);
               con.Open();
               VTran = con.BeginTransaction();
               int VID = 0;
               cmd = new SqlCommand("Select IsNull(Max(ID),0) +1 From ChequeClearance", con);
               cmd.Transaction = VTran;
               VID = Convert.ToInt32(cmd.ExecuteScalar());

               foreach (ChequeClearance pl in v.Accountss)
               {
                   if(pl.IsChecked==true)
                   {
                       //cmd.CommandText = "IF EXISTS (select *  from ChequeClearance where IsChecked=1 and Bank=1 and chqno=" + pl.ChqNo + " and vouchertype='" + v.VoucherTypee + "' and `voucherno=" + v.VoucherNo + " and voucherdate='" + v.VoucherDate.ToString("yyyy-MM-dd 00:00:00") + "') BEGIN  update ChequeClearance set clear=" + ChequeClearance.Clear + ",Disown=" + ChequeClearance.Disown + ",ReSubmitted=" + ChequeClearance.Resubmitted + ",bank=" + ChequeClearance.Bank + " where IsChecked=1 and Bank=1 and chqno=" + pl.ChqNo + " and vouchertype='" + v.VoucherTypee + "' and voucherno=" + v.VoucherNo + " and voucherdate='" + v.VoucherDate.ToString("yyyy-MM-dd 00:00:00") + "' END ELSE begin Insert Into ChequeClearance(ID,ChqNo,VoucherNo,VoucherDate,Amount,Reason,Clear,Disown,Resubmitted,IsChecked,voucherType,AccountNo,Bank,ChequeDate) Values(" + VID + ",'" + pl.ChqNo + "','" + v.VoucherNo + "','" + pl.VoucherDate.ToString("yyyy-MM-dd 00:00:00") + "'," + pl.Amount + ",'" + v.Reason + "'," + ChequeClearance.Clear + "," + ChequeClearance.Disown + "," + ChequeClearance.Resubmitted + "," + Convert.ToInt32(pl.IsChecked) + ",'" + v.VoucherTypee + "'," + pl.accountno + "," + ChequeClearance.Bank + ",'" + v.VoucherDate.ToString("yyy-MM-dd 00:00:00") + "') end";
                       cmd.CommandText = "IF EXISTS (select *  from ChequeClearance where IsChecked=1 and Bank=1 and chqno=" + pl.ChqNo + " and vouchertype='" + v.VoucherTypee + "' and voucherno=" + v.VoucherNo + " and voucherdate='" + pl.VoucherDate.ToString("yyyy-MM-dd 00:00:00") + "') BEGIN  update ChequeClearance set clear=" + ChequeClearance.Clear + ",Disown=" + ChequeClearance.Disown + ",ReSubmitted=" + ChequeClearance.Resubmitted + ",bank=" + ChequeClearance.Bank + " where IsChecked=1 and Bank=1 and chqno=" + pl.ChqNo + " and vouchertype='" + v.VoucherTypee + "' and voucherno=" + v.VoucherNo + " and voucherdate='" + pl.VoucherDate.ToString("yyyy-MM-dd 00:00:00") + "' END ELSE begin Insert Into ChequeClearance(ID,ChqNo,VoucherNo,VoucherDate,Amount,Reason,Clear,Disown,Resubmitted,IsChecked,voucherType,AccountNo,Bank,ChequeDate) Values(" + VID + ",'" + pl.ChqNo + "','" + v.VoucherNo + "','" + pl.VoucherDate.ToString("yyyy-MM-dd 00:00:00") + "'," + pl.Amount + ",'" + v.Reason + "'," + ChequeClearance.Clear + "," + ChequeClearance.Disown + "," + ChequeClearance.Resubmitted + "," + Convert.ToInt32(pl.IsChecked) + ",'" + v.VoucherTypee + "'," + pl.accountno + "," + ChequeClearance.Bank + ",'" + v.CheckDate.ToString("yyy-MM-dd 00:00:00") + "') end";
                       cmd.ExecuteNonQuery();
                       cmd.CommandText ="exec SpClearBankEntries " + v.VoucherNo + ",'" + pl.VoucherDate.ToString("yyyy-MM-dd 00:00:00") +"','" + v.VoucherTypee + "','" + pl.ChqNo + "'";     
                       cmd.ExecuteNonQuery ();
                   }
               }

            

               VTran.Commit();
               con.Close();
               return true;
           }

           catch
           {
               VTran.Rollback();
               
               throw;
           }
           finally { con.Close(); }
       }
       public bool CloseMonth(bool close,DateTime date)
       {
           try
           {               
               con = new SqlConnection(source);
               con.Open();
               VTran = con.BeginTransaction();
               string qry="";
               
               if (close == true)
               {
                   qry = "insert into MonthClose (isclosed,ClosingMonth) values(1,'"+ date.ToString ("yyyy-MM-01 00:00:00") + "') "  ;
               }
               else
               {
                   qry = " delete from monthclose where month(closingmonth)=" + date.ToString("MM") + " and year(closingmonth)=" + date.ToString("yyyy");
               }
               cmd = new SqlCommand(qry, con);               
               cmd.Transaction = VTran;
               cmd.ExecuteNonQuery();
               
               VTran.Commit();
               con.Close();
               return true;
           }

           catch
           {
               VTran.Rollback();
               throw;
           }
           finally { con.Close(); }
       }

       public bool CheckCloseMonth(DateTime date)
       {
           try
           {
               con = new SqlConnection(source);
               con.Open();
               VTran = con.BeginTransaction();
               bool allowed;
               string qry = "";

               qry = " select case when count(*) =0 then 1 else 0 end from monthclose where month(closingmonth)=month('" + date.ToString("yyyy-MM-dd 00:00:00") + "') and year(closingmonth)=year('" + date.ToString("yyyy-MM-dd 00:00:00") + "')" ;
               
               
               cmd = new SqlCommand(qry, con);
               cmd.Transaction = VTran;
               allowed = Convert.ToBoolean( cmd.ExecuteScalar());

               VTran.Commit();
               con.Close();
               return allowed;
           }

           catch
           {
               VTran.Rollback();
               throw;
           }
           finally { con.Close(); }
       }

       /////////////////////////////////////////////////////////////////////////////////////////////////////////

       #region Set posted, Printed or PostDated

       public bool SetPrinted(int voucherNo, VoucherType type, bool setPrinted, bool isNew)
       {
           try
           {
               con = new SqlConnection(source);
               con.Open();

               string Update = "Update AccVouchersBody set IsPrinted = " + (setPrinted ? 1 : 0) + ",IsEdited = " + (isNew ? "NULL" : "1") + ",UserNo = " + User.UserNo + " where voucherNo = " + voucherNo + " and VoucherType = '" + type.ToString() + "' and AccountNo Not Like '" + Globals.PurchaseTranporter + "%' and AccountNo <> (Select Top 1 TransitAcc From FixedAccounts)";

               cmd = new SqlCommand(Update, con);
               cmd.ExecuteNonQuery();
               return true;
           }
           catch
           {
               throw;
           }
       }

       public bool  SetPostDatedVoucher(List <Voucher> vouchers)
       {
           try
           {
               int count = 0;
               con = new SqlConnection(source);
               con.Open();
              
               VTran = con.BeginTransaction();
               
               foreach (Voucher v in vouchers)
               {
                   string BodyWhere = " Where VoucherType = '" + v.VoucherType.ToString() + "' and VoucherNo = " + v.VoucherNo + " and VoucherDate = '" + v.VoucherDate + "'";

                   if (v.VoucherType == VoucherType.BPV || v.VoucherType == VoucherType.BRV || v.VoucherType == VoucherType.BCV || v.VoucherType == VoucherType.BDV)
                   {
                       BodyWhere += " and BankAccNo = '" + v.BankAccNo.AccountNo + "'";
                   }

                   cmd = new SqlCommand("Update AccVouchersBody set IsPostDated = " + (v.isPostDated ? 1 : 0) + BodyWhere, con);
                   cmd.Transaction = VTran;
                   cmd.ExecuteNonQuery();
                   count++;
               }
               VTran.Commit();
               return true  ;
           }
           catch
           {
               VTran.Rollback();
               throw;
           }
           finally
           {

           }
       }

       public int PostVoucher(VoucherType type,DateTime voucherDate,string bankAccountNo, int refNo,bool post)
       {
           try
           {
               int count = 0;
               con = new SqlConnection(source);
               con.Open();

               string BodyWhere = " Where VoucherType = '" + type .ToString () + "' and VoucherNo = " + refNo + " and VoucherDate = '" + voucherDate + "'";

               if (type == VoucherType.BPV || type == VoucherType.BRV || type == VoucherType.BCV || type == VoucherType.BDV)
               {
                   BodyWhere += " and BankAccNo = '" + bankAccountNo  + "'";
               }

               cmd = new SqlCommand("Update AccVouchersBody set isPosted = " + (post ? 1 : 0) + BodyWhere , con);
               count = cmd.ExecuteNonQuery();
               
               return count;
           }
           catch
           {
               throw;
           }
           finally
           {

           }
       }


       #endregion
       #region Check if voucher is entered for the given invoice

       public bool CheckVoucherEntry(int voucherNo, VoucherType type)
       {
           try
           {
               int VID = 0;

               con = new SqlConnection(source);
               con.Open();

               cmd = new SqlCommand("Select count(VoucherNo) as Count From AccVouchersBody where VoucherNo = " + voucherNo + " and VoucherType = '" + type.ToString() + "' and IsPrinted = 1 and AccountNo Not Like '" + Globals.PurchaseTranporter + "%' and AccountNo <> (Select Top 1 TransitAcc From FixedAccounts)", con);
               VID = Convert.ToInt32(cmd.ExecuteScalar());

               if (VID > 0)
               {
                   return true;
               }
               else
               {
                   return false;
               }
           }
           catch
           {
               throw;
           }
           finally
           {
               con.Close();
           }

       }

       #endregion

       /////////////////////////////////////////////////////////////////////////////////////////////////////////         

       #region Fetch Records for editing

       /// (Returns list of items) if id is greater then 0 single item at 0 index will be returned with its lines
       /// Else whole list of items will be populated without lines.
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>              

       public List<Voucher > GetVouchers(Voucher v,bool isPrinted,bool isPosted)
       {
           try
           {
               vouchers = new List<Voucher>();
               con = new SqlConnection(source);
               con.Open();

               string accVoucherCondition = "";
                string bodyWhere = " where BranchID="+Globals.BranchID+" and VoucherType = '" + v.VoucherType.ToString() + "'   " + (User._IsAdmin== false?"  and userno="  + User.UserNo:""   );

                string voucherCondtion = " and MONTH (VoucherDate) = " + v.VoucherDate.Month +" and YEAR (VoucherDate ) = " + v.VoucherDate.Year + " and VoucherNo = " + v.VoucherNo;

               string CurrentDateWhere = "  WHERE  AVB.VoucherDate = AccVouchersBody.VoucherDate AND AVB.VoucherNo < AccVouchersBody.VoucherNo  AND AVB.Accountno = AccVouchersBody.Accountno AND AVB.VoucherType = AccVouchersBody.VoucherType AND AVB.IsPrinted = 1 ";

             

               if (v.VoucherType == VoucherType.BPV || v.VoucherType == VoucherType.BRV || v.VoucherType == VoucherType.BCV || v.VoucherType == VoucherType.BDV)
               {
                   if (v.BankAccNo.AccountNo.Length != 0)
                   {
                     
                        bodyWhere += " and BankAccNo = '" + v.BankAccNo.AccountNo + "' and BankAccNo <> AccountNo";
                      
                   }
               }

               if (v.VoucherType == VoucherType.CRV || v.VoucherType == VoucherType.CPV)
               {
                   bodyWhere += " and AccountNo <> (SELECT TOP 1 CashAcc FROM FixedAccounts) ";
               }

               

               if (v.VoucherType == VoucherType.LPJ || v.VoucherType == VoucherType.SJV || v.VoucherType == VoucherType.PRV || v.VoucherType == VoucherType.SRV || v.VoucherType == VoucherType.FPJ )
               {
                    if (isPrinted == false)
                    {
                        bodyWhere += " and (IsPrinted is Null or IsPrinted = 0) ";
                    }
                    else
                    {
                        bodyWhere += " and IsPrinted = 1 ";
                    }
                }
                


                if (v.VoucherNo > 0)
               {
                   //
                  // string selectLine = "select AccountNo,0 AS PreviousBalance,(Select CA.AccountName from ChartofAccounts CA where CA.AccountNo = AccVouchersBody.AccountNo) as AccountName,Narration,Debit,Credit,isNull(InvoiceNo,0) as InvoiceNo,isNull(PrefixID,0) as PrefixID,VoucherDate  from AccVouchersBody    " + bodyWhere + voucherCondtion + " ORDER BY Credit";
                    string selectLine = "select AccountNo,0 AS PreviousBalance,(Select CA.AccountName from ChartofAccounts CA where CA.AccountNo = AccVouchersBody.AccountNo) as AccountName,Narration,Debit,Credit,VoucherDate  from AccVouchersBody    " + bodyWhere + voucherCondtion + " ORDER BY Credit";
                    cmd = new SqlCommand(selectLine, con);
                   dr = cmd.ExecuteReader();

                   while (dr.Read())
                   {
                       ChartOfAccounts account = new ChartOfAccounts();
                       account.AccountNo = dr["AccountNo"].ToString();
                       account.AccountName = dr["AccountName"].ToString();
                       account.Narration = dr["Narration"].ToString();
                       account.Dr = Convert.ToDecimal(dr["Debit"]);
                       account.Cr = Convert.ToDecimal(dr["Credit"]);                 
                       account.PreviousBalance = Convert .ToDecimal (dr["PreviousBalance"]);
                       
                       accounts.Add(account);
                   }
                   dr.Close();

                   accVoucherCondition = bodyWhere + voucherCondtion;
               }
               else
               {
                   accVoucherCondition = bodyWhere + ""; 
               }


                // string select = "Select VoucherType,VoucherNo,VoucherDate,isNull(BankAccNo,'') as BankAccNo,isNull(CheckNo,'') as CheckNo,isNull(CheckDate,GetDate()) as CheckDate From AccVouchersBody " + accVoucherCondition + " Group by VoucherType,VoucherNo,VoucherDate,BankAccNo,CheckNo,CheckDate ORDER BY  VoucherDate desc ,VoucherNo";
                //string select = "Select VoucherType, VoucherNo,Accountno, Narration,Debit,Credit,VoucherDate,isnull(BranchID,0)as BranchID,b.BranchName,isnull(BankAccNo,'')as BankAccNo  From AccVouchersBody left join branch b on AccVouchersBody.BranchID=b.ID " + accVoucherCondition + "";
                string select = "  Select VoucherType, isnull(SummaryNo,0)as SummaryNo,VoucherNo,VoucherDate,isnull(CheckDate,getdate())as CheckDate,isnull(CheckNo,'')as CheckNo,isnull(BranchID,0)as BranchID,b.BranchName ,     isnull(BankAccNo,'') as BankAccNo,isnull((Select CA.AccountName from ChartofAccounts CA where CA.AccountNo = AccVouchersBody.BankAccNo),'') as BankName  From AccVouchersBody left join branch b on AccVouchersBody.BranchID=b.ID " + accVoucherCondition + "   Group by VoucherType,VoucherNo,VoucherDate,BranchID,b.BranchName,BankAccNo,CheckNo,CheckDate,SummaryNo   ORDER BY  VoucherDate desc ,VoucherNo ";
                cmd = new SqlCommand(select, con);

               dr = cmd.ExecuteReader();

               while (dr.Read())
               {

                   Voucher voucher = new Voucher();
                   voucher.VoucherType = (VoucherType)Enum.Parse(typeof(VoucherType), Convert.ToString(dr["VoucherType"]), true);
                   voucher.VoucherNo = Convert.ToInt32(dr["VoucherNo"]);
                    //voucher.Debit = Convert.ToInt32(dr["Debit"]);
                    voucher.SummaryNo = Convert.ToInt32(dr["SummaryNo"]);
                  //  voucher.Narration = Convert.ToString(dr["Narration"]);
                    voucher.VoucherDate = Convert.ToDateTime(dr["VoucherDate"]);
                    voucher.BankAccNo = new ChartOfAccounts(dr["BankAccNo"].ToString(), "");
                    voucher.BankName = dr["BankName"].ToString();
                    // voucher.VoucherTypee = dr["VoucherType"].ToString();
                   voucher.CheckDate = Convert.ToDateTime(dr["CheckDate"]);
                    voucher.CheckNo = Convert.ToString(dr["CheckNo"]);
                    // voucher.VoucherString = voucher.ToString();
                    voucher.BranchID = Convert.ToInt16(dr["BranchID"]);
                    voucher.BranchName = dr["BranchName"].ToString();
                   voucher.Accounts = accounts;
                   vouchers.Add(voucher);
               }
               dr.Close();

               return vouchers;
           }

           catch { throw; }
           finally { con.Close(); }
       }

       /// <summary>
       /// /////////////////////pdc
       public List<PDCVoucher> GetpdcVouchers(PDCVoucher v, bool isPrinted, bool isPosted) 
       {
           try
           {
               pdcvouchers = new List<PDCVoucher>();
               con = new SqlConnection(source);
               con.Open();

               string accVoucherCondition = "";
              // string bodyWhere = " where  VoucherType = '" + v.VoucherType.ToString() + "'  and AccountNo <> (select Top 1 TransitAcc from FixedAccounts) and AccountNo Not Like '" + Globals.PurchaseTranporter + "%' ";
               string bodyWhere = " where  VoucherType = '" + v.VoucherType.ToString() + "' ";

               if (v.VoucherType == VoucherPDC.PDCI || v.VoucherType == VoucherPDC.PDCR)
               {
                   bodyWhere = bodyWhere + " and accountno not in ('11010','211') and vtype is null ";
               }
               string voucherCondtion = " and MONTH (VDate) = " + v.VoucherDate.Month + " and YEAR (VDate ) = " + v.VoucherDate.Year + " and VoucherNo = " + v.VoucherNo;

              // string CurrentDateWhere = "  WHERE  AVB.VoucherDate = AccVouchersBody.VoucherDate AND AVB.VoucherNo < AccVouchersBody.VoucherNo  AND AVB.Accountno = AccVouchersBody.Accountno AND AVB.VoucherType = AccVouchersBody.VoucherType AND AVB.IsPrinted = 1 ";

                   if (v.BankAccounts.AccountNo.Length != 0)
                   {
                       bodyWhere += " and BankAccNo = '" + v.BankAccounts.AccountNo + "' ";
                       //CurrentDateWhere += " AND BankAccNo = '" + v.BankAccNo.AccountNo + "' and BankAccNo <> AccountNo";
                   }

               if (v.VoucherNo > 0)
               {
                   //
                   string selectLine = "select CheckNo,Checkdate,Narration,Debit,Credit from AccVouchersBody    " + bodyWhere + voucherCondtion + " ORDER BY Credit";
                   cmd = new SqlCommand(selectLine, con);
                   dr = cmd.ExecuteReader();

                   while (dr.Read())
                   {
                       PDCVoucherBody account = new PDCVoucherBody();
                       account.ChequeNo = Convert.ToInt64( dr["CheckNo"]);
                       account.ChequeDate =Convert.ToDateTime( dr["CheckDate"]);
                       account.Narration = dr["Narration"].ToString();
                       account.Dr = Convert.ToDecimal(dr["Debit"]);
                       account.Cr = Convert.ToDecimal(dr["Credit"]);


                       pdclines.Add(account);
                   }
                   dr.Close();

                   accVoucherCondition = bodyWhere + voucherCondtion;
               }
               else
               {
                   accVoucherCondition = bodyWhere;
               }


               string select = "Select PartyAccNo,(Select CA.AccountName from ChartofAccounts CA where CA.AccountNo = PartyAccno) as PartyAccountName,VoucherType,VoucherNo, vdate as VoucherDate,isNull(BankAccNo,'') as BankAccNo From AccVouchersBody " + accVoucherCondition + " Group by VoucherType,VoucherNo,VDate,BankAccNo,partyaccno ORDER BY  VoucherDate desc ,VoucherNo";

               cmd = new SqlCommand(select, con);

               dr = cmd.ExecuteReader();

               while (dr.Read())
               {

                   PDCVoucher voucher = new PDCVoucher();
                   voucher.VoucherType = (VoucherPDC)Enum.Parse(typeof(VoucherPDC), Convert.ToString(dr["VoucherType"]), true);
                   voucher.VoucherNo = Convert.ToInt32(dr["VoucherNo"]);
                   voucher.VoucherDate = Convert.ToDateTime(dr["VoucherDate"]);
                   voucher.BankAccounts = new ChartOfAccounts(dr["BankAccNo"].ToString(), "");
                   voucher.PartyAccounts = new ChartOfAccounts(dr["PartyAccNo"].ToString(), dr["PartyAccountName"].ToString());
                   voucher.VoucherString = voucher.ToString();
                   voucher.PDCVoucherLines = pdclines;
                   pdcvouchers.Add(voucher);
               }
               dr.Close();

               return pdcvouchers;
           }

           catch { throw; }
           finally { con.Close(); }
       }

       /// ////////////////////end pdc
       /// </summary>
       /// <param name="v"></param>
       /// <returns></returns>

       #endregion
       public Voucher GetPDCCheck(Voucher v)
       {
           try
           {
              
               string select = "";
               con = new SqlConnection(source);
               con.Open();
               if(v.IsSubmitted)
               {
                   select = "Select VoucherNo,VoucherDate,isNull(CheckNo,'') as CheckNo,partyaccno as accountno,(Select CA.AccountName from ChartofAccounts CA where CA.AccountNo = AccVouchersBody.partyaccno) as AccountName,Narration,Debit,Credit,VoucherDate  From AccVouchersBody where accountno not in ('211','11010') and  VoucherType='" + v.vtype + "' and checkdate <='" + v.CheckDate.ToShortDateString() + "'and bankaccno=" + v.BankAccNo.AccountNo + " and checkno  in(select chqno as checkno from ChequeClearance where bank=1 and vouchertype='" + v.vtype + "' )";//IsChecked=1 and Bank=1 and checkno=AccVouchersBody.checkno and vouchertype='" + v.vtype + "'
               }
               else
               {
                   select = "Select VoucherNo,VoucherDate,isNull(CheckNo,'') as CheckNo,partyaccno as accountno,(Select CA.AccountName from ChartofAccounts CA where CA.AccountNo = AccVouchersBody.partyaccno) as AccountName,Narration,Debit,Credit,VoucherDate  From AccVouchersBody where accountno not in ('211','11010') and   VoucherType='" + v.vtype + "' and checkdate <='" + v.CheckDate.ToShortDateString() + "'and bankaccno=" + v.BankAccNo.AccountNo + " and checkno not in(select chqno as checkno  from ChequeClearance where  clear=1 or disown=1 or resubmitted=1   and vouchertype='" + v.vtype + "' )";
               }
                   cmd = new SqlCommand(select, con);

               dr = cmd.ExecuteReader();
               Voucher voucher = new Voucher();
            
               ChartOfAccounts account;
               while (dr.Read())
               {

                 
                    account = new ChartOfAccounts();
                   account.AccountNo = dr["AccountNo"].ToString();
                   account.AccountName = dr["AccountName"].ToString();
                   account.Chqno = dr["CheckNo"].ToString();
                   account.VoucherDate = Convert.ToDateTime(dr["VoucherDate"]);
                   account.Narration = dr["Narration"].ToString();
                   account.Dr = Convert.ToDecimal(dr["Debit"]);
                   account.Cr = Convert.ToDecimal(dr["Credit"]);
                  // voucher.accountsdetail = account;
                   accounts.Add(account);
                  
                 
                   voucher.VoucherNo = Convert.ToInt32(dr["VoucherNo"]);
                  
                   voucher.Accounts=accounts;
                   //vouchers.Add(voucher);
               }
               dr.Close();

               return voucher;
           }

           catch { throw; }
           finally { con.Close(); }
       }
       #region Payment and Receiving Invoices Data

       public List<VoucherInvoice> GetInvoices(string accountNo,TransactionFlow flow)
       {
           try
           {
               invoices = new List<VoucherInvoice>();
               con = new SqlConnection(source);
               con.Open();

               string select = "";

               if (flow == TransactionFlow.Payment)
               {
                   select = "Select * from (Select GRN.ID ,GRN.Dated,GRN.PurchasePurpose as Purpose ,PO.SupplierID as PartyID,(Select COA.AccountName   from ChartofAccounts COA where COA.AccountNo = PO.SupplierID ) as AccountName,Grn.TotalAmt,Grn.TotalAmt - isnull( (select SUM(Debit ) from AccVouchersBody AccB where GRN.ID = AccB.InvoiceNo  and AccB.InvoiceType = 'P' ),0)   as RemainingAmt  from GRN inner join PurchaseOrder PO on PO.ID = GRN.PurchaseOrderID  Where PO.SupplierID = " + accountNo + ") as tb where RemainingAmt <> 0";
               }

               if (flow == TransactionFlow.Receiving)
               {
                   //select = "Select * from (Select OGP.ID ,OGP.Dated,DO.SalePurpose as Purpose,Acc.RefNo ,DO.BuyerID  as PartyID,(Select COA.AccountName   from ChartofAccounts COA where COA.AccountNo = DO.BuyerID  ) as AccountName,OGP.TotalAmt,OGP.TotalAmt - isnull( (select SUM(Credit ) from AccVouchersBody AccB where Acc.RefNo = AccB.InvoiceNo  and AccB.InvoiceType = 'R' and ( SUBSTRING( Acc.VoucherType,0,2) = 'S') ),0)   as RemainingAmt  from OGP  inner join DO   on DO.ID = OGP .DOID  inner join AccVouchersBody Acc on Acc.RefNo = OGP.ID and Acc.Accountno = DO.BuyerID Where DO.BuyerID = " + accountNo + ") as tb where RemainingAmt <> 0";
               //    select = "Select * from (Select ID ,Dated,'' AS Purpose ,PartyID,(Select COA.AccountName   from ChartofAccounts COA where COA.AccountNo = PartyID ) as AccountName,TotalAmt,TotalAmt - Advance - Discount - ItemDiscount - isnull( (select SUM(Credit ) from AccVouchersBody AccB where ID = AccB.InvoiceNo  and AccB.InvoiceType = 'R'  ),0)   as RemainingAmt  from SaleOrder Where PartyID = " + accountNo + ") as tb where RemainingAmt <> 0";
                   select = "select * from ( select fid as id,Fdate as dated, Accno as partyid,accountname,'' as purpose, ((totper + EPer) * perhead) + exch - disc + ((((totper + EPer) * perhead) + exch) *(isnull(gst,0)/100)) as TotalAmt,((totper + EPer) * perhead) + exch - disc + ((((totper + EPer) * perhead) + exch) *(isnull(gst,0)/100)) - isnull(cr,0) as RemainingAmt from tbfunctions tbf inner join ChartofAccounts coa on coa.AccountNo=tbf.accno left outer join (select InvoiceNo,SUM(credit) as cr from AccVouchersBody where InvoiceNo is not null group by InvoiceNo)tbacc on tbacc.invoiceno=tbf.fid where Accno=" + accountNo + ")tb where remainingamt<>0 " ;
               }

               cmd = new SqlCommand(select, con);

               dr = cmd.ExecuteReader();
               AddInvoices();

               return invoices;
           }

           catch { throw; }
           finally { con.Close(); }
       }

       public void AddInvoices()
       {
           try
           {
               while (dr.Read())
               {
                   ChartOfAccounts party = new ChartOfAccounts(dr["PartyID"].ToString(), dr["AccountName"].ToString());
                   VoucherInvoice invoice = new VoucherInvoice(Convert.ToInt32(dr["ID"]), Convert.ToDateTime(dr["Dated"]), dr["Purpose"].ToString(), party, Convert.ToDecimal(dr["TotalAmt"]), Convert.ToDecimal(dr["RemainingAmt"]));

                   invoices.Add(invoice);
               }
               dr.Close();
           }
           catch 
           {
               throw;
           }
           finally
           {
               dr.Close();
           }
       }

       #endregion
       #region Report Data.

       public bool GetData(ref Common.Data_Sets.DSVoucher  ds, Voucher v)
       {
           try
           {
               con = new SqlConnection(source);
               con.Open();
                             
               //string bodyWhere = " where  VoucherType = '" + v.VoucherType.ToString() + "' and AccountNo <> (select Top 1 CashAcc from FixedAccounts) and AccountNo <> (select Top 1 TransitAcc from FixedAccounts) and AccountNo Not Like '" + Globals.PurchaseTranporter + "%' ";
               string bodyWhere = " where AVB.BranchID="+Globals.BranchID+" and  VoucherType = '" + v.VoucherType.ToString() + "' AND AVB.AccountNo <> (select Top 1 isnull(TransitAcc,'') from FixedAccounts) and AVB.AccountNo Not Like '" + Globals.PurchaseTranporter + "%' ";
               string voucherCondtion = " and MONTH (VoucherDate) = " + v.VoucherDate.Month + " AND YEAR (VoucherDate ) = " + v.VoucherDate.Year + " and VoucherNo = " + v.VoucherNo;

               string CurrentDateWhere = "  WHERE  AB.VoucherDate = AVB.VoucherDate  AND AB.Accountno = AVB.Accountno  AND  AB.VoucherNo < AVB.VoucherNo AND AB.IsPrinted = 1 ";

               if (v.VoucherType == VoucherType.BPV || v.VoucherType == VoucherType.BRV || v.VoucherType == VoucherType.BCV || v.VoucherType == VoucherType.BDV)
               {
                   if (v.BankAccNo.AccountNo.Length != 0)
                   {
                       //bodyWhere += " and BankAccNo = '" + v.BankAccNo.AccountNo + "' and BankAccNo <> AccountNo";
                       bodyWhere += " and BankAccNo = '" + v.BankAccNo.AccountNo + "'";
                       CurrentDateWhere += " AND BankAccNo = '" + v.BankAccNo.AccountNo + "' ";
                   }
               }
               
               string select = "";
                select = "select VoucherType,RTRIM(VoucherType) + '-' + SUBSTRING(ISNULL(BankAccNo,'00'),LEN(ISNULL(BankAccNo,'00')) - 1,LEN(ISNULL(BankAccNo,'00'))) + '-' + SUBSTRING(CONVERT(VARCHAR,VoucherDate,107),0,4) + '-' + CAST(VoucherNo AS VARCHAR(10)) AS VoucherNo,(SELECT SUM(Balance) FROM(SELECT SUM(ISNULL(OpeningDebit,0) - ISNULL(OpeningCredit ,0)) as Balance from ChartOfAccounts AB  where  AB.Accountno =  AVB.Accountno UNION ALL SELECT SUM(ISNULL(Debit,0)- ISNULL(Credit,0)) as Balance from AccVouchersBody  AB   where  AB.VoucherDate < AVB.VoucherDate  AND AB.Accountno = AVB.Accountno AND AB.IsPrinted = 1 ) AS TB) + IsNull((SELECT  SUM(IsNull(Debit,0) -  IsNull(Credit,0))  from AccVouchersBody AB   " + CurrentDateWhere + " ),0) AS PreviousBalance,VoucherDate,AVB.Accountno,COA.AccountName,isnull(AVB.Narration,'')as Narration, AVB.Debit,AVB.Credit,AVB.BankAccNo,AVB.CheckNo,AVB.CheckDate,AVB.IsPrinted,(Select Top 1 Signature FROM Users WHERE IsAdministrator = 1) AS AdminSignatures,U.Signature AS UserSignatures,(Select UserName From Users WHERE UserNo = " + User.UserNo + ") AS PrintedBy,b.BranchName from AccVouchersBody AVB INNER JOIN ChartOfAccounts COA ON COA.AccountNo = AVB.AccountNo LEFT OUTER JOIN Users U ON U.UserNo = AVB.UserNo   left join Branch b on avb.BranchID=b.ID  " + bodyWhere + voucherCondtion + " ORDER BY Credit";

                //select = "select VoucherType,P.Name AS PrefixName,RTRIM(VoucherType) + '-' + SUBSTRING(ISNULL(BankAccNo,'00'),LEN(ISNULL(BankAccNo,'00')) - 1,LEN(ISNULL(BankAccNo,'00'))) + '-' + SUBSTRING(CONVERT(VARCHAR,VoucherDate,107),0,4) + '-' + CAST(VoucherNo AS VARCHAR(10)) AS VoucherNo,(SELECT SUM(Balance) FROM(SELECT SUM(ISNULL(OpeningDebit,0) - ISNULL(OpeningCredit ,0)) as Balance from ChartOfAccounts AB  where  AB.Accountno =  AVB.Accountno UNION ALL SELECT SUM(ISNULL(Debit,0)- ISNULL(Credit,0)) as Balance from AccVouchersBody  AB   where  AB.VoucherDate < AVB.VoucherDate  AND AB.Accountno = AVB.Accountno AND AB.IsPrinted = 1 ) AS TB) + IsNull((SELECT  SUM(IsNull(Debit,0) -  IsNull(Credit,0))  from AccVouchersBody AB   " + CurrentDateWhere + " ),0) AS PreviousBalance,VoucherDate,AVB.Accountno,COA.AccountName, dbo.ProperCase(AVB.Narration) as Narration ,AVB.Debit,AVB.Credit,AVB.BankAccNo,AVB.CheckNo,AVB.CheckDate,AVB.IsPosted,AVB.IsPrinted,(Select Top 1 Signature FROM Users WHERE IsAdministrator = 1) AS AdminSignatures,U.Signature AS UserSignatures,(Select UserName From Users WHERE UserNo = " + User.UserNo + ") AS PrintedBy from AccVouchersBody AVB INNER JOIN ChartOfAccounts COA ON COA.AccountNo = AVB.AccountNo LEFT OUTER JOIN Users U ON U.UserNo = AVB.UserNo LEFT OUTER JOIN Prefix P ON P.ID = PrefixID  " + bodyWhere + voucherCondtion + " ORDER BY Credit";
                // select = "select VoucherType,P.Name AS PrefixName,RTRIM(VoucherType) + '-' + SUBSTRING(ISNULL(BankAccNo,'00'),LEN(ISNULL(BankAccNo,'00')) - 1,LEN(ISNULL(BankAccNo,'00'))) + '-' + SUBSTRING(CONVERT(VARCHAR,VoucherDate,107),0,4) + '-' + CAST(VoucherNo AS VARCHAR(10)) AS VoucherNo,(SELECT SUM(Balance) FROM(SELECT SUM(ISNULL(OpeningDebit,0) - ISNULL(OpeningCredit ,0)) as Balance from ChartOfAccounts AB  where  AB.Accountno =  AVB.Accountno UNION ALL SELECT SUM(ISNULL(Debit,0)- ISNULL(Credit,0)) as Balance from AccVouchersBody  AB   where  AB.VoucherDate < AVB.VoucherDate  AND AB.Accountno = AVB.Accountno AND AB.IsPrinted = 1 ) AS TB) + IsNull((SELECT  SUM(IsNull(Debit,0) -  IsNull(Credit,0))  from AccVouchersBody AB   " + CurrentDateWhere + " ),0) AS PreviousBalance,VoucherDate,AVB.Accountno,COA.AccountName, (AVB.Narration) as Narration ,AVB.Debit,AVB.Credit,AVB.BankAccNo,AVB.CheckNo,AVB.CheckDate,AVB.IsPosted,AVB.IsPrinted,(Select Top 1 Signature FROM Users WHERE IsAdministrator = 1) AS AdminSignatures,U.Signature AS UserSignatures,(Select UserName From Users WHERE UserNo = " + User.UserNo + ") AS PrintedBy from AccVouchersBody AVB INNER JOIN ChartOfAccounts COA ON COA.AccountNo = AVB.AccountNo LEFT OUTER JOIN Users U ON U.UserNo = AVB.UserNo LEFT OUTER JOIN Prefix P ON P.ID = PrefixID  " + bodyWhere + voucherCondtion + " ORDER BY Credit";
                cmd = new SqlCommand(select, con);

               da.SelectCommand = cmd;

               da.Fill(ds, "Voucher");

               return true;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }



       public bool SearchVoucher(ref Common.Data_Sets.DSAccLedger ds,string where)
       {
           try
           {             
               con = new SqlConnection(source);
               con.Open();

               cmd = new SqlCommand("", con);

               cmd.CommandText = "SELECT * FROM (Select VoucherType +'-' + IsNull(Cast(RefNo as Varchar(15)),VoucherNo)as VoucherNo,VoucherDate,AccVouchersbody.Narration,sum(debit) as debit ,sum(credit) as credit,Accountname,ca.Accountno,VoucherType,CheckDate,CheckNo From AccVouchersbody 	Inner Join ChartOfAccounts CA on CA.AccountNo=AccVouchersBody.Accountno	where  IsPrinted = 1 group by vouchertype,refno,voucherno,voucherdate,AccVouchersbody.narration,AccountName,Ca.AccountNo,CheckDate,CheckNo ) AS TB " + where ;

               da.SelectCommand = cmd;

               da.Fill(ds, "SPAccountsLedger");

               return true;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       #endregion

        
       /////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
