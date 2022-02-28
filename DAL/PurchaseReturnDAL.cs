using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Common;
using System.Data;

namespace DAL
{
    public class PurchaseReturnDAL
    {
        //Fields.
        List<PurchaseReturn> purchaseReturns;
        List<PurchaseReturn> subPurchaseReturns;
        private string source = ReadProjectConfigFile.ConfigString();

        SqlConnection con;
        SqlCommand cmd;

        SqlDataReader drPurchaseReturn;
        SqlDataReader drPurchaseReturnLine;
        SqlDataAdapter da;
        SqlTransaction VTran;
        SqlDataReader dr;

        public int GetMaximumID()
        {

            int VID = 0;

            con = new SqlConnection(source);
            con.Open();

            cmd = new SqlCommand("Select IsNull(Max(ID),0) +1 From PurchaseReturn", con);
            VID = Convert.ToInt32(cmd.ExecuteScalar());

            return VID;
        }

        public int CheckExisting(int p)
        {
            con = new SqlConnection(source);
            con.Open();
            int pid=0;
            cmd = new SqlCommand("Select ID From PurchaseReturn where PurchaseID="+p , con);

            if (cmd.ExecuteScalar() != null)
            {
                pid = (int)cmd.ExecuteScalar();
                if (pid > 0)
                {
                    return pid;
                }
                else
                    return 0;
            }
            else
                return 0;
            
        }

        public int SavePurchaseReturn(PurchaseReturn purchaseReturn, bool isNew)
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
                    cmd = new SqlCommand("Select IsNull(Max(ID),0) +1 From ClaimInvoice where BranchID="+ purchaseReturn .BranchID+ "", con);
                    cmd.Transaction = VTran;
                    VID = Convert.ToInt32(cmd.ExecuteScalar());
  
                    string insertPurchase = "Insert into ClaimInvoice(ID,Type,Dated,PartyID,Remarks,Type,TotalAmount,Remarks,CreatedBy,BranchID,SrNo) Values(" + VID + ",, '" + purchaseReturn.PurchaseReturnDate.Date.ToString("yyyy-MM-dd 00:00:00") + "', " + purchaseReturn.TotalAmount + ", '" + purchaseReturn.Vendor.Id.AccountNo +"', '" + purchaseReturn .Remarks  + "','"+ purchaseReturn.Narration + "', " + purchaseReturn.BranchID + ","+User.UserNo+","+ Convert.ToInt16(purchaseReturn.IsAdjust)+ ",'"+purchaseReturn.CourierAccount+"','"+purchaseReturn.TrackingID+"',"+purchaseReturn.CourierAmount+")";
                    cmd.CommandText = insertPurchase;
                    cmd.ExecuteNonQuery();

                    foreach (PurchaseReturnLine pl in purchaseReturn.PurchaseReturnLines)
                    {
                        if (pl.IsDeleted == false)
                        {
                            cmd.CommandText = SetInsertLine(pl, VID);
                            cmd.ExecuteNonQuery();

                            cmd.CommandText = "exec SPInsertPurcahseReturn " + pl.Item.ItemID + ", " + pl.BranchID + ", " + pl.Quantity + ", " + pl.PurchasePrice + " ";
                            cmd.ExecuteNonQuery();
                        }
                    }


                }
                else
                {
                    VID = purchaseReturn.RetInvoiceNo;
                    cmd = new SqlCommand("", con);
                    cmd.Transaction = VTran;

                    if (con == null)
                    {
                        con = new SqlConnection(source);
                        con.Open();
                    }

                    foreach (PurchaseReturnLine line in purchaseReturn.PurchaseReturnLines)
                    {
                        if (!line.IsDeleted && line.SerialNumber != 0)
                        {
                            //Getting previous Qty on this item
                            cmd.CommandText = "Select Quantity from purchaseReturnBody where Itemid=" + line.Item.ItemID + " and  SrNo = " + line.SerialNumber + " and BranchID=" + line.BranchID + " ";
                            decimal PrevQuantity = Convert.ToDecimal(cmd.ExecuteScalar());

                            cmd.CommandText = "Update PurchaseReturnBody Set ItemID = " + line.Item.ItemID + ", Quantity = " + line.Quantity + " ,PurPrice = " + line.PurchasePrice + ", BranchID=" + line.BranchID + "  where SrNo = " + line.SerialNumber;
                            cmd.ExecuteNonQuery();


                            cmd.CommandText = "exec SPUpdatePurcahseReturn " + line.Item.ItemID + ", " + line.BranchID + "," + line.Quantity + ", " + PrevQuantity + ", " + line.PurchasePrice + " ";
                            cmd.ExecuteNonQuery();

                        }
                        else if (!line.IsDeleted && line.SerialNumber == 0)
                        {
                            cmd.CommandText = SetInsertLine(line, purchaseReturn.RetInvoiceNo);
                            cmd.ExecuteNonQuery();

                            cmd.CommandText = "exec SPInsertPurcahseReturn " + line.Item.ItemID + ", " + line.BranchID + ", " + line.Quantity + ", " + line.PurchasePrice + " ";
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            cmd.CommandText = "Select Quantity from purchaseReturnBody where Itemid=" + line.Item.ItemID + " and  SrNo = " + line.SerialNumber + "  ";
                            decimal PrevQuantity = Convert.ToDecimal(cmd.ExecuteScalar());

                            cmd.CommandText = "Delete from purchaseReturnBody where SrNo = " + line.SerialNumber;
                            cmd.ExecuteNonQuery();

                            cmd.CommandText = "exec SPDeletePurchaseReturn " + line.Item.ItemID + ", " + line.BranchID + ", " + PrevQuantity + "," + line.PurchasePrice + " ";
                            cmd.ExecuteNonQuery();

                        }


                    }
                    cmd.CommandText = "Update PurchaseReturn Set Date='" + purchaseReturn.PurchaseReturnDate.Date.ToString("yyyy-MM-dd 00:00:00") + "', SupplierID = '" + purchaseReturn.Vendor.Id.AccountNo + "',  RetAmt = " + purchaseReturn.TotalAmount + ", Type='" + purchaseReturn.Narration + "' , BranchID = " + purchaseReturn.BranchID + ",Remarks='"+purchaseReturn.Remarks+"', UserNo=" + User.UserNo + ",IsAdjEnt="+ Convert.ToInt16(purchaseReturn.IsAdjust) + ",CourierAccount='"+purchaseReturn.CourierAccount+"',TrackingID='"+purchaseReturn.TrackingID+"',CourierAmount="+purchaseReturn.CourierAmount+"  Where ID = " + purchaseReturn.RetInvoiceNo;
                    cmd.ExecuteNonQuery();

                }

                cmd.CommandText = "DELETE FROM AccVouchersBody WHERE VoucherType = 'PR' AND refno= " + VID;
                cmd.ExecuteNonQuery();


                cmd = new SqlCommand("exec SPpurchaseRAccEntries " + VID + ",'" + purchaseReturn.PurchaseReturnDate.Date.ToString("yyyy-MM-dd 00:00:00") + "'", con);
                cmd.Transaction = VTran;
                cmd.ExecuteNonQuery();
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

        private string SetInsertLine(PurchaseReturnLine pl, int VID)
        {
           
            try
            {
                string insertPurchaseItems = "Insert Into PurchaseReturnBody(RID,ItemID,Quantity,PurPrice,BranchID) Values(" + VID + "," + pl.Item.ItemID + "," + pl.Quantity + "," + pl.PurchasePrice + "," + pl.BranchID + ")";

                return insertPurchaseItems;
            }
            catch
            {
                VTran.Rollback();
                throw;
            }
           
        }

        public bool GetPurchaseReturn(Common.Data_Sets.DSPurchaseReturn ds, int claimID)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
              
                cmd = new SqlCommand("  select ClaimID,ClaimDate,PartyId,Party,ItemID,ItemName,Quantity,PurPrice,Quantity*PurPrice as Total,IsAdjEnt,BranchName,Remarks,CourierAccount,TrackingID,CourierAmount from ( select p.ID as ClaimID ,b.BranchName ,p.Date as ClaimDate,p.SupplierID as PartyId, c.AccountName as Party,pb.ItemID,i.ItemName,sum(pb.Quantity) as Quantity,pb.PurPrice as PurPrice,isnull(p.IsAdjEnt,0)as IsAdjEnt,isnull(p.Remarks,'')as Remarks,isnull((Select Accountname from chartofaccounts where accountno=p.CourierAccount),'')as CourierAccount,isnull(p.TrackingID,'')as TrackingID,isnull(p.CourierAmount,0)as CourierAmount  from PurchaseReturn p inner join PurchaseReturnBody pb on p.ID=pb.RID inner join item i on i.ItemID=pb.ItemID inner join ChartofAccounts c on c.AccountNo=p.SupplierID left join branch b on p.branchid=b.id where p.ID=" + claimID+ " Group by p.ID,p.Date,p.SupplierID,c.AccountName,pb.ItemID,i.ItemName,pb.PurPrice,IsAdjEnt,Remarks,Branchname,CourierAccount,TrackingID,CourierAmount)tb  ", con);
               
                da = new SqlDataAdapter(cmd);
           
                da.Fill(ds, "SPPurchaseReturn");
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

        public List<PurchaseReturn> GetPurchaseReturns()
        {
            try
            {
                if (purchaseReturns == null) purchaseReturns = new List<PurchaseReturn>();

                con = new SqlConnection(source);

                string select = "select *,u.UserName from PurchaseReturn PRI  left join users u on PRI.UserNo=u.UserNo  Left Outer join ChartofAccounts C on C.AccountNo=PRI.SupplierID";

                con.Open();
                cmd = new SqlCommand(select, con);

                drPurchaseReturn = cmd.ExecuteReader();
                AddPurchaseReturns();
                if (purchaseReturns.Count > 0)
                {
                    AddPurchaseReturnLines();
                }

                return purchaseReturns;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void AddPurchaseReturns()
        {
            try
            {

               Vendor  v;
                Purchase p;

                List<PurchaseReturnLine> purchaseReturnLines;

                while (drPurchaseReturn.Read())
                {
                    v = new Vendor(new ChartOfAccounts((string)drPurchaseReturn["SupplierID"], (string)drPurchaseReturn["AccountName"]), new Address(), "");
                    p =new Purchase ();
                    purchaseReturnLines = new List<PurchaseReturnLine>();
                   
                    PurchaseReturn pr = new PurchaseReturn((int)drPurchaseReturn["ID"], p, (DateTime)drPurchaseReturn["Date"], purchaseReturnLines, (decimal)drPurchaseReturn["RetAmt"],  v,drPurchaseReturn ["Narration"].ToString ());
                    pr.BranchID =(int)(drPurchaseReturn["BranchID"]);
                    pr.UserName = drPurchaseReturn["UserName"].ToString();
                    pr.IsAdjust = Convert.ToBoolean(drPurchaseReturn["IsAdjEnt"] == System.DBNull.Value ? false : drPurchaseReturn["IsAdjEnt"]);
                    pr.Remarks= drPurchaseReturn["Remarks"].ToString();
                    pr.CourierAccount= Convert.ToString(drPurchaseReturn["CourierAccount"]==System.DBNull.Value ? "" : drPurchaseReturn["CourierAccount"]);
                    pr.TrackingID = Convert.ToString(drPurchaseReturn["TrackingID"]==System.DBNull.Value ? "" : drPurchaseReturn["TrackingID"]);
                    pr.CourierAmount = Convert.ToDecimal(drPurchaseReturn["CourierAmount"]==System.DBNull.Value ? 0 : drPurchaseReturn["CourierAmount"]);
                    //pr.Discount = Convert.ToDecimal(drPurchaseReturn["Discount"] == System.DBNull.Value ? "0" : drPurchaseReturn["Discount"]);

                    purchaseReturns.Add(pr);
                }
                drPurchaseReturn.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                drPurchaseReturn.Close();
            }
        }

        public void AddPurchaseReturnLines()
        {
            try
            {
                Item i;
                Category c;
                PurchaseReturnLine purchaseReturnLine;
                List<PurchaseReturnLine> purchaseReturnLines;

                SqlCommand cmd2;
                string selectPurchaseLine;

                purchaseReturnLines = new List<PurchaseReturnLine>();

                foreach (PurchaseReturn p in purchaseReturns)
                {
                    selectPurchaseLine = " select IC.CategoryID,IC.CategoryName,Item.ItemID,ItemName,CompanyName,ProductName,Size,isnull(Color,'')as Color,Design,cs.Quantity as InHand,IsNull(PRB.Quantity,0) as RetQty,PRB.PurPrice,IsNull(PRB.SrNo,0) as SrNo,bc.Barcode  from PurchaseReturnBody PRB inner join Item on PRB.ItemID=Item.ItemID inner join ItemCategory IC on Item.CategoryID=IC.CategoryID inner join CurrentStock cs on PRB.ItemID=cs.itemid and PRB.BranchID=cs.BranchID left join ItemBarcodes bc on PRB.ItemID=bc.ItemID  where PRB.RID=" + p.RetInvoiceNo;
                    cmd2 = new SqlCommand(selectPurchaseLine, con);

                    drPurchaseReturnLine = cmd2.ExecuteReader();
                    while (drPurchaseReturnLine.Read())
                    {
                        i = new Item(Convert.ToInt32(drPurchaseReturnLine["ItemID"]), new ItemName((string)drPurchaseReturnLine["CompanyName"], (string)drPurchaseReturnLine["ProductName"], (string)drPurchaseReturnLine["Design"], (string)drPurchaseReturnLine["Size"]), (decimal)drPurchaseReturnLine["InHand"]);
                        c = new Category((int)drPurchaseReturnLine["CategoryID"], (string)drPurchaseReturnLine["CategoryName"]);

                        purchaseReturnLine = new PurchaseReturnLine(c, i,(decimal)drPurchaseReturnLine["RetQty"], 0, (decimal)drPurchaseReturnLine["PurPrice"], Convert.ToDecimal((decimal)drPurchaseReturnLine["RetQty"] * (decimal)drPurchaseReturnLine["PurPrice"]), (int)drPurchaseReturnLine["SrNo"]);
                        p.PurchaseReturnLines.Add(purchaseReturnLine);
                    }
                    drPurchaseReturnLine.Close();
                }

            }
            catch (Exception ex)
            {
                throw;
            }
            finally { drPurchaseReturnLine.Close(); }
        }

        public bool DeletePurchaseReturn(PurchaseReturn purchaseReturn)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                VTran = con.BeginTransaction();

                cmd = new SqlCommand("Select * from PurchaseReturnInvoice Where RetID=" + purchaseReturn.RetInvoiceNo , con);
                cmd.Transaction = VTran;
                int i = (int)cmd.ExecuteScalar();

                if (i > 0)
                {
                    foreach (PurchaseReturnLine pl in purchaseReturn.PurchaseReturnLines )
                    {
                        cmd = new SqlCommand("Delete from PurchaseReturnBody where SrNo=" + pl.SerialNumber, con);
                        cmd.Transaction = VTran;
                        cmd.ExecuteNonQuery();
                    }
                    cmd = new SqlCommand("Delete from PurchaseReturnInvoice where RetID=" + purchaseReturn.RetInvoiceNo, con);
                    cmd.Transaction = VTran;
                    cmd.ExecuteNonQuery(); ;
                }

                VTran.Commit();
                con.Close();
                return true;
            }
            catch (Exception)
            {
                VTran.Rollback();
                throw;
            }
            finally { con.Close(); }
        }

        public List<PurchaseReturn> GetPReurnsForReport(string wPurchaseBody, string wPurchaseReturn)
        {
            try
            {
                if (purchaseReturns == null) purchaseReturns = new List<PurchaseReturn>();

                if (subPurchaseReturns == null) subPurchaseReturns = new List<PurchaseReturn>();
                con = new SqlConnection(source);                

                string select = "select PRI.RetID,PRI.RetDate,PRI.RetAmt,PRI.AmtPaid,PRI.PurchaseID,PIn.VendorID,P.PartyName from PurchaseReturnInvoice PRI inner join PurchaseInvoice PIN On PIN.PurchaseID=PRI.PurchaseID inner join Parties P on P.PartyID=PIn.VendorID" + wPurchaseReturn;

                con.Open();
                cmd = new SqlCommand(select, con);
                drPurchaseReturn = cmd.ExecuteReader();

                Vendor v;
                Purchase p;

                List<PurchaseReturnLine> purchaseReturnLines;

                while (drPurchaseReturn.Read())
                {
                    v = new Vendor(new ChartOfAccounts((string)drPurchaseReturn["VendorID"], (string)drPurchaseReturn["PartyName"]), new Address(), "");
                    p = new Purchase((int)drPurchaseReturn["PurchaseID"]);
                    purchaseReturnLines = new List<PurchaseReturnLine>();
                    purchaseReturns.Add(new PurchaseReturn((int)drPurchaseReturn["RetID"], p, (DateTime)drPurchaseReturn["RetDate"], purchaseReturnLines, (decimal)drPurchaseReturn["RetAmt"], (decimal)drPurchaseReturn["AmtPaid"], v));
                }
                drPurchaseReturn.Close();

                if (purchaseReturns.Count > 0)
                {
                    Item i;
                    Category c;
                    PurchaseReturnLine purchaseReturnLine;                    

                    SqlCommand cmd2;
                    string selectPurchaseLine;

                    purchaseReturnLines = new List<PurchaseReturnLine>();

                    foreach (PurchaseReturn pr in purchaseReturns)
                    {
                        selectPurchaseLine = "select IC.CategoryID,IC.CategoryName,Item.ItemID,ItemName,CompanyName,ProductName,Size,isnull(Color,'')as Color,Design,cs.Quantity as InHand,PIB.Quantity  as PurQty, IsNull(Ret.Quantity,0) as RetQty,PIB.PurPrice,IsNull(Ret.SrNo,0) as SrNo  from PurchaseInvoiceBody PIB inner join Item on Item.ItemID=PIB.ItemID inner join ItemCategory IC on IC.CategoryID=Item.CategoryID inner join CurrentStock cs on cs.itemid=PIB.ItemID Left Outer Join ( Select PurchaseID,Prb.SrNo,ItemID,Sum(Quantity) as Quantity from PurchaseReturnBody PRB inner Join PurchaseReturnInvoice PR on PR.RetID=PRB.RetID where PurchaseID=" + pr.Purchase.InvoiceNo + " Group By PurchaseID,ItemID,PRb.SrNo ) Ret on Ret.PurchaseID=PIB.PurchaseID and PIB.ItemID=Ret.ItemID where PIB.PurchaseID=" + pr.Purchase.InvoiceNo + wPurchaseBody;
                        cmd2 = new SqlCommand(selectPurchaseLine, con);

                        drPurchaseReturnLine = cmd2.ExecuteReader();

                        bool contains = false;
                        while (drPurchaseReturnLine.Read())
                        {
                            i = new Item((int)drPurchaseReturnLine["ItemID"], new ItemName((string)drPurchaseReturnLine["CompanyName"], (string)drPurchaseReturnLine["ProductName"], (string)drPurchaseReturnLine["Design"], (string)drPurchaseReturnLine["Size"]), (decimal)drPurchaseReturnLine["InHand"]);
                            c = new Category((int)drPurchaseReturnLine["CategoryID"], (string)drPurchaseReturnLine["CategoryName"]);

                            purchaseReturnLine = new PurchaseReturnLine(c, i, (decimal)drPurchaseReturnLine["RetQty"], (decimal)drPurchaseReturnLine["PurQty"], (decimal)drPurchaseReturnLine["PurPrice"], Convert.ToDecimal((decimal)drPurchaseReturnLine["RetQty"] * (decimal)drPurchaseReturnLine["PurPrice"]), (int)drPurchaseReturnLine["SrNo"]);
                            pr.PurchaseReturnLines.Add(purchaseReturnLine);

                            contains = true;
                        }

                        if (contains == true)
                        {
                            subPurchaseReturns.Add(pr);
                        }
                        drPurchaseReturnLine.Close();
                    }
                }
                return subPurchaseReturns;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { con.Close(); }
        }
    }
}
