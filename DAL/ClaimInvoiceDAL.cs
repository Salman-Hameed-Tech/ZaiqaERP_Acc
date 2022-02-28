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
   public  class ClaimInvoiceDAL
    {

      
        List<string> names = new List<string>();

        private List<ClaimInvoice > claims;
        List<ClaimInvoiceLine > claimLines = new List<ClaimInvoiceLine >();


        SqlTransaction VTran;
        SqlDataReader dr;      

        private string source = ReadProjectConfigFile.ConfigString();
        SqlConnection con;
        SqlCommand cmd;

        SqlDataAdapter da = new SqlDataAdapter();


        public decimal GetQuantity(int ItemID, int InvoiceNo)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand("select sum(quantity) from tblfifo where itemid=" + ItemID + "  and invno=" + InvoiceNo, con);
                return Convert.ToDecimal(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { con.Close(); }
        }

        public bool GetReportData(ref DSClaim ds,string where, ClaimInvoiceType invoiceType)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                
                cmd = new SqlCommand("select ci.ID,ci.Type,ci.Dated,b.BranchName,ci.PartyID,p.PartyName,ci.TotalAmt,ci.Remarks,ci.IsAdjEntry, cb.ItemID,i.ItemName,cb.RecQty,cb.Rate,InvID ,case when cb.ClaimType='"+ invoiceType + "' then pib.Quantity else sib.Quantity end as InvQty from ClaimInvoice ci  inner join ClaimInvoiceBody cb on ci.ID=cb.ClaimID and ci.type=cb.claimtype left join Item i on cb.ItemID=i.ItemID left join PurchaseInvoiceBody pib on cb.InvID=pib.PurchaseId and cb.ItemID=pib.Itemid left join SaleInvoiceBody sib on cb.ClaimID=sib.SaleId and cb.ItemID=sib.ItemId left join Branch b on ci.BranchID=b.ID left join Parties p on ci.PartyID=p.PartyID left join itemcategory ic on i.categoryid=ic.categoryid "+ where + "  ", con);
                
                da.SelectCommand = cmd;

                da.Fill(ds, "SPClaim");

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

   
        public int GetMaximumID(ClaimInvoiceType type)
        {
            try
            {

                int VID = 0;

                con = new SqlConnection(source);
                con.Open();

                cmd = new SqlCommand("Select IsNull(Max(ID),0) +1 From ClaimInvoice where Type = '" + type.ToString () + "'" , con);
                VID = Convert.ToInt32(cmd.ExecuteScalar());

                return VID;
            }
            catch
            {
                throw;
            }
        }


        public bool DeleteClaim(int VID,ClaimInvoiceType type)
        {
            try
            {
                if (con == null)
                {
                    con = new SqlConnection(source);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                }
                VTran = con.BeginTransaction();

                cmd = new SqlCommand("Select * from ClaimInvoice Where ID=" + VID + " and Type = '" + type .ToString () + "'", con);
                cmd.Transaction = VTran;
                int i = (int)cmd.ExecuteScalar();

                if (i > 0)
                {
                    SqlDataAdapter Da = new SqlDataAdapter("select itemid,srno from ClaimInvoiceBody where ClaimID=" + VID + " and ClaimType = '" + type .ToString () + "'", con);
                    DataSet ds = new DataSet();
                    Da.SelectCommand.Transaction = VTran;
                    Da.Fill(ds);
                    //foreach (PurchaseLine pl in sale.PurchaseLines)
                    ///for ( i = 0; i < ds.Tables [0].Rows.Count -1; i++)
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        cmd.CommandText = "Delete from ClaimInvoiceBody where SrNo=" + Convert.ToInt32(item["srno"]);
                        cmd.ExecuteNonQuery();
                    }
                    cmd.CommandText = "Delete from ClaimInvoice Where ID=" + VID + " and Type = '" + type.ToString() + "'";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "Delete from AccVouchersBody where RefNo = " + VID + " and VoucherType = '" + (type == ClaimInvoiceType.PR ? "PRV" : "SRV") + "'";
                    cmd.ExecuteNonQuery();

                }
                VTran.Commit();
                return true;
            }
            catch
            {
                VTran.Rollback();
                throw;
            }
        }


        public int SaveClaim(ClaimInvoice  claim, bool isNew)
        {
            try
            {
                int VID = 0;
                con = new SqlConnection(source);
                con.Open();
                VTran = con.BeginTransaction();

                if (isNew)
                {
                    cmd = new SqlCommand("Select IsNull(Max(ID),0) +1 From ClaimInvoice where Type = '" + claim.Type.ToString() + "'", con);
                    cmd.Transaction = VTran;
                    VID = Convert.ToInt32(cmd.ExecuteScalar());

                    string insertPurchase = "Insert into ClaimInvoice(ID,Type,Dated,PartyID,TotalAmt,Remarks,CreatedBy,IsAdjEntry,BranchID) Values(" + VID + ",'" + claim.Type .ToString () + "','" + claim.Dated.Date.ToString("yyyy-MM-dd 00:00:00") + "'," + (claim.Party .AccountNo.Length == 0 ? "NULL" : "'" +  claim.Party.AccountNo + "'") + "," + claim.TotalAmt + ",'" + claim.Remarks + "'," + claim.CreatedBy +  ","+Convert.ToInt16(claim.IsAdjEntry)+","+claim.BranchID+")";
                    cmd.CommandText = insertPurchase;
                    cmd.ExecuteNonQuery();

                    foreach (ClaimInvoiceLine  pl in claim.ClaimLines )
                    {
                        if (pl.IsDeleted == false)
                        {
                            cmd.CommandText = SetInsertLine(pl, VID,claim.Type );
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                else
                {
                    VID = claim .ID ;

                    if (con == null)
                    {
                        con = new SqlConnection(source);
                        con.Open();
                    }

                    cmd = new SqlCommand("", con);
                    cmd.Transaction = VTran;
                    foreach (ClaimInvoiceLine line in claim.ClaimLines)
                    {
                        if (!line.IsDeleted && line.SrNo != 0)
                        {
                            cmd.CommandText = "Update ClaimInvoiceBody Set ItemID = " + line.Item.ItemID + ",ClaimType = '" + claim.Type .ToString () + "',Rate = " + line.Rate + ",RecQty = " + line.Quantity  + ",InvID = " + line.InvID + ",PurPrice = " + line .PurPrice + " where SrNo = " + line.SrNo;
                        }
                        else if (!line.IsDeleted && line.SrNo == 0)
                        {
                            cmd.CommandText = SetInsertLine(line, claim.ID,claim.Type );
                        }
                        else
                        {
                            cmd.CommandText = "Delete from ClaimInvoiceBody where SrNo = " + line.SrNo;
                        }
                        cmd.ExecuteNonQuery();
                    }

                    cmd.CommandText = "Update ClaimInvoice set Dated = '" + claim.Dated.Date.ToString("yyyy-MM-dd 00:00:00") + "',BranchID="+claim.BranchID+",PartyID = " + (claim.Party.AccountNo.Length == 0 ? "NULL" : "'" + claim.Party.AccountNo + "'") + ",TotalAmt = " + claim.TotalAmt + ",Remarks = '" + claim.Remarks + "',CreatedBy = " + claim.CreatedBy + ",IsAdjEntry="+Convert.ToInt16(claim.IsAdjEntry)+"  Where ID = " + claim.ID + " and Type = '" + claim.Type.ToString() + "'";
                    cmd.ExecuteNonQuery();
                }

               // cmd.CommandText = "Delete from AccVouchersBody where RefNo = " + VID + " and VoucherType = '" + (claim.Type == ClaimInvoiceType .PR ? "PRV" : "SRV") + "'";
               //cmd.ExecuteNonQuery();

               // cmd.CommandText = "execute  SPClaimAccEntries " + VID + ",'" + claim.Type .ToString () + "'";
               // cmd.ExecuteNonQuery();
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

        public string SetInsertLine(ClaimInvoiceLine  pl, Int32 VID,ClaimInvoiceType type)
        {
            try
            {
                string insertPurchaseItems = "Insert Into ClaimInvoiceBody(ClaimID,ClaimType,ItemID,Rate,RecQty,InvID,PurPrice) Values(" + VID + ",'" + type .ToString () + "'," + pl.Item.ItemID + "," + pl.Rate + "," + pl.Quantity + "," + pl.InvID + "," + pl.PurPrice + ")";
                return insertPurchaseItems;
            }
            catch
            {
                VTran.Rollback();
                throw;
            }

        }

        public List<ClaimInvoice > GetClaims(int id, ClaimInvoiceType type)
        {
            try
            {
                claims  = new List<ClaimInvoice >();
                con = new SqlConnection(source);
                con.Open();

                string where = "where type = '" + type.ToString () + "'";

                if (id > 0)
                {
                    where += " and ID = " + id;
                    AddClaimLines(id, type );                   
                }

                string select = "select id,Type,Dated,PartyID,BranchID,(Select AccountName from ChartofAccounts where AccountNo = PartyID) as PartyName,TotalAmt,Remarks,CreatedBy from claimInvoice  " + where + " Order By ID ";
                    
                
               
                cmd = new SqlCommand(select, con);

                dr = cmd.ExecuteReader();
                AddClaims(id,type );

                return claims ;
            }

            catch { throw; }
            finally { con.Close(); }
        }

        public void AddClaims(int id,ClaimInvoiceType type)
        {
            try
            {
                while (dr.Read())
                {
                    ChartOfAccounts Party = new ChartOfAccounts(dr["PartyID"].ToString(), dr["PartyName"].ToString());
               
                    ClaimInvoice  p = new ClaimInvoice (Convert.ToInt32(dr["ID"]),Party , type ,dr["Remarks"].ToString(), Convert.ToInt32(dr["CreatedBy"]), Convert.ToDecimal(dr["TotalAmt"]), Convert.ToDateTime(dr["Dated"]));
                    p.BranchID = Convert.ToInt32(dr["BranchID"]);
                    p.ClaimLines  = claimLines ;
                    
                    claims.Add(p);
                }

                dr.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                dr.Close();

            }
        }

        public List<ClaimInvoiceLine > AddClaimLines(int id, ClaimInvoiceType type)
        {
            try
            {
                string selectLine = "";
                //string selectLine = "select ClaimID,SRB.ItemID,IsLoose,InvID,SRB.StoreID,RecQty,SRB.Rate,SRB.PurPrice,CompanyName ,ProductName,Multiplier ,Design,Packing ,Origin,SrNo , 0 as IsDeleted  from ClaimInvoiceBody SRB inner join Item I on I.ItemID = SRB.ItemID inner join CurrentStock cs on cs.ItemID = SRB.ItemID and cs.StoreID = SRB.StoreID where ClaimID = " + id + " and ClaimType = '" + type.ToString() + "' Order By SRB.ClaimID";
                if (type == ClaimInvoiceType.PR)
                {
                     selectLine = " select ClaimID,SRB.ItemID,i.itemname,isnull(pi.quantity,0) as quantity,InvID,RecQty,cs.quantity as csqty,SRB.Rate,SRB.PurPrice,CompanyName ,ProductName ,Design,srb.SrNo , 0 as IsDeleted  from ClaimInvoiceBody SRB  left outer join  (select itemid,branchid,sum(quantity) as quantity,case when sum(quantity)<>0  then  sum(quantity*price)/sum(quantity) else 0  end  as price from tblfifo  group by itemid,branchid ) Cs on Cs.Itemid=srb.itemid  and cs.branchid=(select Branchid from claiminvoice  where id=srb.claimid and type='PR')  left join purchaseinvoicebody pi on srb.invid=pi.purchaseid and srb.itemid=pi.itemid inner join Item I on I.ItemID = SRB.ItemID   where ClaimID = " + id + " and ClaimType = '" + type + "' Order By SRB.ClaimID ";

                }
                else if (type == ClaimInvoiceType.SR)
                {
                    selectLine = " select ClaimID,SRB.ItemID,i.itemname,isnull(si.quantity,0) as quantity,InvID,RecQty,cs.quantity as csqty,SRB.Rate,SRB.PurPrice,CompanyName ,ProductName ,Design,srb.SrNo , 0 as IsDeleted  from ClaimInvoiceBody SRB  left outer join  (select itemid,branchid,sum(quantity) as quantity,case when sum(quantity)<>0  then  sum(quantity*price)/sum(quantity) else 0  end  as price from tblfifo  group by itemid,branchid ) Cs on Cs.Itemid=srb.itemid  and cs.branchid=(select Branchid from claiminvoice  where id=srb.claimid and type='SR')  left join saleinvoicebody si on srb.invid=si.saleid and srb.itemid=si.itemid inner join Item I on I.ItemID = SRB.ItemID   where ClaimID = " + id + " and ClaimType = '" + type + "' Order By SRB.ClaimID ";
                }

                SqlCommand cmd = new SqlCommand(selectLine, con);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Item i = new Item(); 
                    i.ItemID= Convert.ToInt32(dr["ItemID"]);
                    ItemName name = new ItemName();
                    name.CompanyName = dr["CompanyName"].ToString();
                    name.Design = dr["Design"].ToString();
                    name.ProductName = dr["itemname"].ToString();
                    i.ItemName = name;
                    ClaimInvoiceLine claim = new ClaimInvoiceLine();
                    claim.Item = i;
                   
                    claim.Quantity = Convert.ToDecimal(dr["RecQty"]);
                    claim.Rate = Convert.ToDecimal(dr["Rate"]);
                    claim.SaleQty = Convert.ToDecimal(dr["quantity"]);
                    claim.Csqty = Convert.ToDecimal(dr["csqty"]);
                    claim.InvID = Convert.ToInt32(dr["InvID"]);

                    claimLines.Add(claim);
                }
                dr.Close();

                return claimLines ;
            }
            catch
            {
                throw;
            }
        }

        //public bool GetData(ref Common.Data_Sets.DSClaim  ds, string where)
        //{
        //    try
        //    {
        //        con = new SqlConnection(source);
        //        con.Open();

        //        string select = "";

        //        select = "SELECT * FROM(select id,Type,Dated,PartyID,(Select AccountName from ChartofAccounts where AccountNo = PartyID) as PartyName,TotalAmt,Remarks,CreatedBy from claimInvoice ) AS CI INNER JOIN (select ClaimType,ClaimID,SRB.ItemID,I.ItemName,IsLoose,InvID,SRB.StoreID,S.Name AS StoreName,RecQty,SRB.Rate,SRB.PurPrice,CompanyName ,ProductName,Multiplier ,Design,Packing ,Origin,SrNo,(case Isloose when 0 then cs.Quantity else cs.QtyLoose end) as QTYcs , 0 as IsDeleted,CategoryID  from ClaimInvoiceBody SRB inner join Item I on I.ItemID = SRB.ItemID inner join CurrentStock cs on cs.ItemID = SRB.ItemID and cs.StoreID = SRB.StoreID INNER JOIN Store S ON S.ID = SRB.StoreID ) AS CIB  ON CIB.ClaimID = CI.ID AND CIB.ClaimType = CI.Type  " + where + " Order By ID";

        //        cmd = new SqlCommand(select, con);

        //        da.SelectCommand = cmd;

        //        da.Fill(ds, "SPClaim");

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
