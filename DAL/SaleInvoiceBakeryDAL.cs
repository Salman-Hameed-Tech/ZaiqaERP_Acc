using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.Data_Sets;

namespace DAL
{
    public class SaleInvoiceBakeryDAL
    {
        private string source = ReadProjectConfigFile.ConfigString();
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataReader drLine;
        SqlTransaction VTran;
        SqlDataAdapter da;

        public string GetMaxID()
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand("Select IsNull(Max(ID),0) +1 From SaleInvoiceBakery", con);
                cmd.Transaction = VTran;
                int VID = Convert.ToInt32(cmd.ExecuteScalar());
                return VID.ToString();
                
            }
            catch (Exception)
            {

                throw;
            }
            finally { con.Close(); }
           
        }

        public bool GetReportData(ref DSaleInvoiceBakery dSaleInvoiceBakery, int vID)
        {
            try
            {
                string where = "";
                if (vID > 0)
                {
                    where = " where si.ID=" + vID + "";
                }
                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand("select si.ID,si.PartyID,coa.AccountName as PartyName,si.Dated,si.InvDiscount,si.AmountPaid,si.PaymentMode,si.TotalAmount,si.ReturnAmount,sib.ItemID,i.ItemName,sib.DiscPer,sib.DiscAmt,sib.Quantity,sib.Rate,sib.Total from SaleInvoiceBakery si inner join SaleInvoiceBakeryBody sib on si.ID=sib.SID left join ChartofAccounts coa on si.PartyID=coa.AccountName left join Item i on sib.ItemID=i.ItemID  "+where+"  ", con);
                da = new SqlDataAdapter(cmd);
                da.Fill(dSaleInvoiceBakery, "SPSaleInvoiceBakery");
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

        public int Save(SaleInvoiceBakery invoice, bool isNew)
        {
            try
            {
                int VID = 0;
                int TID = 0;
                con = new SqlConnection(source);
                con.Open();
                VTran = con.BeginTransaction();

                if (isNew)
                {
                    cmd = new SqlCommand("Select IsNull(Max(ID),0) +1 From SaleInvoiceBakery", con);
                    cmd.Transaction = VTran;
                    VID = Convert.ToInt32(cmd.ExecuteScalar());


                    string insertPurchase = "Insert into SaleInvoiceBakery(ID,Dated,PartyID,InvDiscount,TotalAmount,PaymentMode,Bank,CardNo,AmountPaid,ReturnAmount,BranchID,UserNo) Values(" + VID + ",'" + invoice.Dated.ToString("yyyy-MM-dd 00:00:00") + "','" +  invoice.PartyID + "'," + invoice.DiscAmt + "," + invoice.TotalAmt + ",'" + invoice.PaymentMode + "','"+invoice.Bank + "','" + invoice.CardNo + "',"+invoice.AmtPaid+","+invoice.ReturnAmt+", " +invoice.BranchID+ "," + invoice.UserNo + ")";
                    cmd.CommandText = insertPurchase;
                    cmd.ExecuteNonQuery();


                    foreach (SaleInvoiceBakeryLine pl in invoice.bakeryLines)
                    {
                        if (pl.IsDeleted == false)
                        {
                            cmd.CommandText = SetInsertLine(pl, VID);
                            cmd.ExecuteNonQuery();


                        }
                    }


                }
                #region Comments
                //else
                //{
                //    VID = purchase.InvoiceNo;
                //    cmd = new SqlCommand("", con);
                //    cmd.Transaction = VTran;

                //    if (con == null)
                //    {
                //        con = new SqlConnection(source);
                //        con.Open();
                //    }

                //    foreach (PurchaseLine line in purchase.PurchaseLines)
                //    {
                //        if (!line.IsDeleted && line.SerialNumber != 0)
                //        {
                //            cmd.CommandText = "Update purchaseInvoiceBody Set ItemID = " + line.Item.ItemID + ", Quantity = " + line.Quantity + " ,PurPrice = " + line.PurchasePrice + ",Discount = " + line.Disc + ",SalePrice = " + line.SalePrice + " where SrNo = " + line.SerialNumber;
                //            cmd.ExecuteNonQuery();
                //        }
                //        else if (!line.IsDeleted && line.SerialNumber == 0)
                //        {
                //            cmd.CommandText = SetInsertLine(line, purchase.InvoiceNo);
                //            cmd.ExecuteNonQuery();
                //        }
                //        else
                //        {
                //            cmd.CommandText = "Delete from purchaseinvoicebody where SrNo = " + line.SerialNumber;
                //            cmd.ExecuteNonQuery();
                //        }


                //    }
                //    cmd.CommandText = "Update purchaseInvoice Set PaymentMode=" + purchase.PaymentMode + ",PurchaseDate='" + purchase.PurchaseDate.Date.ToString("yyyy-MM-dd 00:00:00") + "', VendorID = '" + purchase.Vendor.Id.AccountNo + "',  TotalAmount = " + purchase.TotalAmount + ", AmountPaid=" + purchase.AmountPaid + ", BillNo = '" + purchase.BillNumber + "' , BranchID = " + purchase.BranchID + ",UserNo=" + User.UserNo + ", Remarks='" + purchase.Remarks + "',IsAdjEnt=" + Convert.ToInt16(purchase.IsAdjust) + " Where PurchaseId = " + purchase.InvoiceNo;
                //    cmd.ExecuteNonQuery();

                //}
                #endregion

                //cmd.CommandText = "DELETE FROM AccVouchersBody WHERE  VoucherType = 'SJV' AND VoucherNo = " + VID;
                //cmd.ExecuteNonQuery();

                //cmd = new SqlCommand("exec SpSaleBakeryAccEntries " + VID, con);
                //cmd.Transaction = VTran;
                //cmd.ExecuteNonQuery();

                VTran.Commit();
                con.Close();
                return VID;
            }
            catch (Exception ex)
            {
                VTran.Rollback();
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        private string SetInsertLine(SaleInvoiceBakeryLine pl, int VID)
        {
            try
            {
                string insertPurchaseItems = "Insert Into SaleInvoiceBakeryBody(SID,ItemID,Quantity,Rate,DiscPer,DiscAmt,Total,Barcode) Values(" + VID + "," + pl.ItemID + "," + pl.Quantity + "," + pl.Rate + "," + pl.DiscPer + ","+pl.DiscAmt+"," + pl.Total + ",'"+pl.Barcode+"')";

                return insertPurchaseItems;
            }
            catch
            {
                VTran.Rollback();
                throw;
            }
        }
    }
}
