using Common;
using Common.Data_Sets;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class WholesaleDAL
    {
        List<WholeSale> sale;
        List<WholeSaleLines> subsale;
        SqlConnection con;

        string source = ReadProjectConfigFile.ConfigString();
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;
        SqlDataReader drSaleLines;
        SqlTransaction VTran;

        public List<WholeSaleLines> VerifyItem(string id, string type)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                string vwhere = "";
                List<WholeSaleLines> lst = new List<WholeSaleLines>();

                if (type == "b")
                {
                    vwhere = "   where ib.Barcode='" + id + "'    and item.isactive=1";
                }
                else if (type == "s")
                {
                    vwhere = " where shortkey='" + id + "'  and item.isactive=1";
                }
                else if (type == "i")
                {
                    vwhere = " where item.itemid=" + id + " and item.isactive=1";
                }
                cmd = new SqlCommand("Select item.itemid,IsNull(item.itemprint,'') as itemprint,item.itemname,item.companyName,isnull(Item.shortkey,'')as shortkey,isnull(ib.Barcode,'')as Barcode,item.productname,item.design,item.size,isnull(item.Color,'')as Color,IsNull(cs.quantity,0) as qty,case IsNull(CS.Price,0) when 0 then IsNull(item.PurchasePrice,0) else cs.Price end as purprice  ,item.saleprice,IsNull(item.discountlimit,0) as discountlimit  from item Left Outer Join CurrentStock Cs on Cs.Itemid=item.itemid and Cs.BranchID=" + Globals.BranchID + " inner join ItemBarcodes ib on item.ItemID=ib.itemid  " + vwhere, con); //IsNull(cs.price,isnull(item.purchaseprice,0))
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                  
                    WholeSaleLines obj = new WholeSaleLines();
                    obj.ItemID = Convert.ToInt32(dr["itemid"]);
                    obj.ItemName = dr["itemname"].ToString();
                    obj.Barcode = Convert.ToString(dr["Barcode"]);
                    obj.CsQty = Convert.ToDecimal(dr["qty"]);
                    obj.Rate = (decimal)dr["SalePrice"];
                  

                    lst.Add(obj);
                }
                return lst;
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

        public bool GetWSData(ref DSWholeSale dSWhole, string where)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand("", con);
                cmd.CommandText = "select b.BranchName,p.PartyName,wi.PmtType,wi.ID,wi.Dated,wi.TotalAmt,   wi.InvDiscountPer,wi.InvDiscount,wib.Barcode,wib.ItemID,wib.ItemName,  wib.Quantity,wib.Rate,wib.DiscPer,wib.DiscAmt,wi.Remarks,(select sum(InvDiscount) from WholesaleInvoice ) as TotalInvDisc from WholesaleInvoice wi inner join WholesaleInvoiceBody wib on wi.ID = wib.SID  and wi.Dated = wib.Dated  and wi.BranchID = wib.BranchID left join Item i on wib.ItemID = i.ItemID left join Parties p on wi.BuyerID = p.PartyID left join Branch b on wi.BranchID = b.ID  "+where+" ";

                da = new SqlDataAdapter(cmd);

                da.Fill(dSWhole, "SPWholeSale");
                return true;
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

        public WholeSale GetSingleWSale(int id, DateTime date)
        {
            try
            {
                WholeSale sale = new WholeSale();

                AddLines(id,  date);

                con = new SqlConnection(source);           
                string select = " select i.ID,i.BranchID,i.Dated,i.BuyerID,p.PartyName,b.BranchName,isnull(i.InvDiscountPer,0)as InvDiscountPer,isnull(i.InvDiscount,0)as InvDiscount ,i.TotalAmt,u.UserName as CreatedBy,isnull(i.Remarks,'') as Remarks,isnull(i.PmtType,'')as PaymentMode from WholesaleInvoice i left join Branch b on i.BranchID=b.ID left join Parties p on i.BuyerID=p.PartyID left join Users u on i.UserNo=u.UserNo where i.ID=" + id+" and Dated='"+date.Date.ToString("yyyy-MM-dd 00:00:00")+"' and  i.BranchID=" + Globals.BranchID + " ";
                con.Open();
                cmd = new SqlCommand(select, con);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                      
                        sale.ID = Convert.ToInt32(dr["ID"]);
                        sale.BranchID = Convert.ToInt32(dr["BranchID"]);
                        sale.Dated = Convert.ToDateTime(dr["Dated"]);
                        sale.BuyerID = dr["BuyerID"].ToString();
                        sale.BuyerName = dr["PartyName"].ToString();
                        sale.BranchName = dr["BranchName"].ToString();
                        sale.InvoiceDiscountPer = Convert.ToDecimal(dr["InvDiscountPer"]);
                        sale.InvoiceDiscount = Convert.ToDecimal(dr["InvDiscount"]);
                        sale.NetTotal = Convert.ToDecimal(dr["TotalAmt"]);
                        sale.UserName = dr["CreatedBy"].ToString();
                        sale.Remarks = dr["Remarks"].ToString();
                        sale.PaymentMode = Convert.ToString(dr["PaymentMode"]);
                        sale.wholeSaleLines = subsale;

                    }
                }


                return sale;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void AddLines(int id, DateTime date)
        {
            try
            {
                con = new SqlConnection(source);
                subsale = new List<WholeSaleLines>();
                string select = " select SID,ItemID,Barcode,ItemName,Quantity,Rate,isnull(DiscPer,0)as DiscPer,isnull(DiscAmt,0)as DiscAmt,SrNo from WholesaleInvoiceBody where sid="+id+ " and Dated='" + date.Date.ToString("yyyy-MM-dd 00:00:00")+"' and BranchID="+Globals.BranchID+" ";
                con.Open();
                cmd = new SqlCommand(select, con);
                SqlDataReader drs;
                drs = cmd.ExecuteReader();
                if (drs.HasRows)
                {
                    while (drs.Read())
                    {
                        WholeSaleLines line = new WholeSaleLines();
                        line.ItemID = Convert.ToInt32(drs["ItemID"]);
                        line.Barcode = drs["Barcode"].ToString();
                        line.ItemName = drs["ItemName"].ToString();
                        line.DiscPer = Convert.ToDecimal(drs["DiscPer"]);
                        line.DiscAmt = Convert.ToDecimal(drs["DiscAmt"]);
                        line.Quantity = Convert.ToDecimal(drs["Quantity"]);
                        line.Rate = Convert.ToDecimal(drs["Rate"]);
                        line.SrNo = Convert.ToInt32(drs["SrNo"]);
                        subsale.Add(line);


                    }
                    drs.Close();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            finally { con.Close();}
        }

        public List<WholeSale> GetWSale()
        {
            try
            {
                if (sale == null) sale = new List<WholeSale>();
                con = new SqlConnection(source);
                string select = " select i.ID,i.Dated,p.PartyName,b.BranchName,isnull(i.InvDiscountPer,0)as InvDiscountPer,isnull(i.InvDiscount,0)as InvDiscount ,i.TotalAmt,u.UserName as CreatedBy,isnull(i.Remarks,'') as Remarks from WholesaleInvoice i left join Branch b on i.BranchID=b.ID left join Parties p on i.BuyerID=p.PartyID left join Users u on i.UserNo=u.UserNo where i.BranchID="+Globals.BranchID+" ";         
                con.Open();
                cmd = new SqlCommand(select, con);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        WholeSale obj = new WholeSale();
                        obj.ID = Convert.ToInt32(dr["ID"]);
                        obj.Dated = Convert.ToDateTime(dr["Dated"]);
                        obj.BuyerName = dr["PartyName"].ToString();
                        obj.BranchName = dr["BranchName"].ToString();
                        obj.InvoiceDiscountPer = Convert.ToDecimal(dr["InvDiscountPer"]);
                        obj.InvoiceDiscount = Convert.ToDecimal(dr["InvDiscount"]);
                        obj.NetTotal = Convert.ToDecimal(dr["TotalAmt"]);
                        obj.UserName = dr["CreatedBy"].ToString();
                        obj.Remarks = dr["Remarks"].ToString();
                        sale.Add(obj);
                    }
                }
               

                return sale;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        

        public bool GetReportData(ref DSWholeSale dSSale, DateTime dated, int vID)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand("", con);
                 cmd.CommandText  = "select b.BranchName,p.PartyName,wi.PmtType,wi.ID,wi.Dated,wi.TotalAmt,   wi.InvDiscountPer,wi.InvDiscount,wib.Barcode,wib.ItemID,wib.ItemName,  wib.Quantity,wib.Rate,wib.DiscPer,wib.DiscAmt,wi.Remarks,(select sum(InvDiscount) from WholesaleInvoice ) as TotalInvDisc from WholesaleInvoice wi inner join WholesaleInvoiceBody wib on wi.ID = wib.SID  and wi.Dated = wib.Dated  and wi.BranchID = wib.BranchID left join Item i on wib.ItemID = i.ItemID left join Parties p on wi.BuyerID = p.PartyID left join Branch b on wi.BranchID = b.ID where wi.BranchID = " + Globals.BranchID+"  " +" and wi.dated = '"+dated.Date.ToString("yyyy-MM-dd 00:00:00")+"' and" +" wi.ID = "+vID+"";
                  

                da = new SqlDataAdapter(cmd);

                da.Fill(dSSale, "SPWholeSale");
                return true;
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

        public int Save(WholeSale sale,bool IsNew)
        {
            try
            {
                int VID = 0;
                DateTime d = new DayLogDAL().GetDay(Globals.BranchID);
                con = new SqlConnection(source);
                con.Open();
                VTran = con.BeginTransaction();
                if (IsNew)
                {
                    cmd = new SqlCommand("Select IsNull(Max(ID),0) +1 From WholesaleInvoice where BranchID=" + Globals.BranchID + " and Dated='" + sale.Dated.Date.ToString("yyyy/MM/dd 00:00:00") + "'  ", con);
                    cmd.Transaction = VTran;
                    VID = Convert.ToInt32(cmd.ExecuteScalar());
                    string insertInvoice = "";


                    insertInvoice = " Insert into WholesaleInvoice(ID,Dated,SDateTime,BuyerID,InvDiscountPer,InvDiscount,TotalAmt,SummaryNo,UserNo,BranchID,Remarks,PmtType) Values(" + VID + ",'" + sale.Dated.Date.ToString("yyyy-MM-dd 00:00:00") + "','" + sale.Dated.ToString("yyyy-MM-dd hh:mm:ss") + "','" + sale.BuyerID + "'," + sale.InvoiceDiscountPer + "," + sale.InvoiceDiscount + "," + sale.NetTotal + "," + Summary.SummaryNo + "," + User.UserNo + "," + Globals.BranchID + ",'" + sale.Remarks + "','" + sale.PaymentMode + "' )";


                    cmd.CommandText = insertInvoice;
                    cmd.ExecuteNonQuery();

                    foreach (WholeSaleLines pl in sale.wholeSaleLines)
                    {
                        if (pl.IsDeleted == false)
                        {
                            cmd.CommandText = SetInsertLine(pl, VID, sale);
                            cmd.ExecuteNonQuery();

                            cmd.CommandText = "exec SPInsertWholeSale " + pl.ItemID + ", " + Globals.BranchID + ", " + pl.Quantity + " ";
                            cmd.ExecuteNonQuery();

                        }
                    }

                }
              else
                {
                    VID = sale.ID;
                    cmd = new SqlCommand("", con);
                    cmd.Transaction = VTran;

                    if (con == null)
                    {
                        con = new SqlConnection(source);
                        con.Open();
                    }

                    foreach (WholeSaleLines line in sale.wholeSaleLines)
                    {
                        if (!line.IsDeleted && line.SrNo != 0)
                        {
                            //Getting previous Qty on this item
                            cmd.CommandText = "Select Quantity from wholesaleinvoicebody where Itemid=" + line.ItemID + " and  SrNo = " + line.SrNo + " and BranchID=" + sale.BranchID + " ";
                            decimal PrevQuantity = Convert.ToDecimal(cmd.ExecuteScalar());

                            cmd.CommandText = "Update wholesaleinvoicebody Set ItemID = " + line.ItemID + ",Barcode='"+line.Barcode+"',UserNo="+User.UserNo+",Quantity = " + line.Quantity + " ,Rate = " + line.Rate + ",DiscPer = " + line.DiscPer + ",DiscAmt = " + line.DiscAmt + " where SrNo = " + line.SrNo;
                            cmd.ExecuteNonQuery();

                            cmd.CommandText = "exec SPUpdateWholesale " + line.ItemID + ", " + sale.BranchID + "," + line.Quantity + ", " + PrevQuantity + "";
                            cmd.ExecuteNonQuery();

                        }
                        else if (!line.IsDeleted && line.SrNo == 0)
                        {
                            cmd.CommandText = SetInsertLine(line, VID, sale);
                            cmd.ExecuteNonQuery();


                            cmd.CommandText = "exec SPInsertWholeSale " + line.ItemID + ", " + sale.BranchID + ", " + line.Quantity + " ";
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            cmd.CommandText = "Select Quantity from wholesaleinvoicebody where Itemid=" + line.ItemID + " and  SrNo = " + line.SrNo + " and BranchID=" + sale.BranchID + " ";
                            decimal PrevQuantity = Convert.ToDecimal(cmd.ExecuteScalar());

                            cmd.CommandText = "Delete from wholesaleinvoicebody where SrNo = " + line.SrNo;
                            cmd.ExecuteNonQuery();

                            cmd.CommandText = "exec SPDeleteWholesale " + line.ItemID + ", " + sale.BranchID + ", " + PrevQuantity + " ";
                            cmd.ExecuteNonQuery();

                        }


                    }
                    cmd.CommandText = "Update Wholesaleinvoice Set  BuyerID = '" + sale.BuyerID + "',  InvDiscountPer = " + sale.InvoiceDiscountPer + ", InvDiscount=" + sale.InvoiceDiscount + ", TotalAmt = " +sale.NetTotal + " ,UserNo=" + User.UserNo + ", Remarks='" + sale.Remarks + "',PmtType='"+sale.PaymentMode+"' Where ID = " + sale.ID+" and Dated='"+sale.Dated.Date.ToString("yyyy-MM-dd 00:00:00")+"' and Branchid="+sale.BranchID+" ";
                    cmd.ExecuteNonQuery();

                }



                //cmd.CommandText = "DELETE FROM AccVouchersBody WHERE VoucherType = 'WSJ' AND VoucherNo = " + VID;
                //cmd.ExecuteNonQuery();

                //cmd = new SqlCommand("exec SpWSaleAccEntries " + VID + ",'" + sale.Dated.Date.ToString("yyyy-MM-dd 00:00:00") + "'", con);
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

        private string SetInsertLine(WholeSaleLines sl, int VID, WholeSale sale)
        {
            try
            {
                string insertItems = "Insert Into WholesaleInvoicebody(SID,Dated,SDateTime,ItemID,ItemName,Barcode,Quantity,Rate,BranchID,DiscPer,DiscAmt,UserNo) Values(" + VID + ",'" + sale.Dated.Date.ToString("yyyy-MM-dd 00:00:00") + "','" + sale.Dated.ToString("yyyy-MM-dd hh:mm:ss") + "'," + sl.ItemID + ",'"+sl.ItemName+"','" + sl.Barcode + "'," + sl.Quantity + "," + sl.Rate + "," + Globals.BranchID + "," + sl.DiscPer + "," + sl.DiscAmt + "," + User.UserNo + ")";
                return insertItems;
            }
            catch
            {
                VTran.Rollback();
                throw;
            }
        }

        public List<WholeSaleLines> VerifyAllItem(string id, string type)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                string vwhere = "";
                List<WholeSaleLines> lst = new List<WholeSaleLines>();

                if (type == "b")
                {
                    vwhere = " where item.itemid=(select itemid from itembarcodes where barcode='" + id + "') and item.isactive=1";
                }
                else if (type == "s")
                {
                    vwhere = " where shortkey='" + id + "' and item.isactive=1";
                }
                else if (type == "i")
                {
                    vwhere = " where item.itemid=" + id + "    and item.isactive=1";
                }
                cmd = new SqlCommand("Select item.itemid,IsNull(item.itemprint,'') as itemprint,item.companyName,item.productname,isnull(item.Color,'')as Color,item.itemname,item.design,item.size,IsNull(cs.quantity,0) as qty,case IsNull(CS.Price,0) when 0 then IsNull(item.PurchasePrice,0) else cs.Price end as purprice  ,item.saleprice,IsNull(item.discountlimit,0) as discountlimit,ic.Barcode,isnull(shortkey,'')as ShortKey  from item Left Outer Join CurrentStock Cs on Cs.Itemid=item.itemid and Cs.BranchID=" + Globals.BranchID + "  left join ItemBarcodes ic on Item.ItemID=ic.itemid  " + vwhere, con); //IsNull(cs.price,isnull(item.purchaseprice,0))
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    WholeSaleLines obj = new WholeSaleLines();
                    obj.ItemID = Convert.ToInt32(dr["itemid"]);
                    obj.ItemName = dr["itemname"].ToString();
                    obj.Barcode = Convert.ToString(dr["Barcode"]);
                    obj.CsQty = Convert.ToDecimal(dr["qty"]);
                    obj.Rate = (decimal)dr["SalePrice"];
                    lst.Add(obj);
                }
                return lst;
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

        public string GetMaximumID()
        {
            try
            {
                int VID = 0;
                DateTime d = new DayLogDAL().GetDay(Globals.BranchID);

                con = new SqlConnection(source);
                con.Open();

                cmd = new SqlCommand("Select IsNull(Max(ID),0) +1 From WholesaleInvoice Where branchid=" + Globals.BranchID + " and  Dated='" + d.ToString("yyyy-MM-dd 00:00:00") + "'", con);
                VID = Convert.ToInt32(cmd.ExecuteScalar());

                return VID.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
