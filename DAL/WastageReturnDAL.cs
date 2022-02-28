using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Common;

namespace DAL
{
    public class WastageReturnDAL
    {
        string wid = "";

        //Fields.
        List<PurchaseReturn> purchaseReturns;
        List<PurchaseReturn> subPurchaseReturns;

        List<WastageReturn> wastageReturns;
        List<WastageReturn> subWastageReturns;

        private string source = ReadProjectConfigFile.ConfigString();

        SqlConnection con;
        SqlCommand cmd;

        SqlDataReader drWastageReturn;
        SqlDataReader drWastageReturnLine;

        SqlTransaction VTran;
        SqlDataReader dr;

        public int GetMaximumID()
        {

            int VID = 0;

            con = new SqlConnection(source);
            con.Open();

            cmd = new SqlCommand("Select IsNull(Max(WasID),0) +1 From WastageInvoice", con);
            VID = Convert.ToInt32(cmd.ExecuteScalar());

            return VID;
        }

        public int CheckExisting(int p)
        {
            con = new SqlConnection(source);
            con.Open();
            int pid = 0;
            cmd = new SqlCommand("Select RetID From PurchaseReturnInvoice where PurchaseID=" + p, con);

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

        public bool SavePurchaseReturn(PurchaseReturn purchaseReturn, bool newOrUpdate)
        {
            try
            {
                int VID = 0;
                con = new SqlConnection(source);
                con.Open();
                VTran = con.BeginTransaction();

                if (newOrUpdate)
                {
                    cmd = new SqlCommand("Select IsNull(Max(RetID),0) +1 From PurchaseReturnInvoice", con);
                    cmd.Transaction = VTran;
                    VID = Convert.ToInt32(cmd.ExecuteScalar());
                }
                else
                {
                    VID = purchaseReturn.RetInvoiceNo;
                    SqlCommand c1, c2, c3;

                    cmd = new SqlCommand("Select * from PurchaseReturnInvoice Where RetID=" + VID, con);
                    cmd.Transaction = VTran;
                    int i = (int)cmd.ExecuteScalar();

                    if (i > 0)
                    {

                        foreach (PurchaseReturnLine pl in purchaseReturn.PurchaseReturnLines)
                        {
                            c1 = new SqlCommand("Delete from PurchaseReturnBody where SrNo=" + pl.SerialNumber, con);
                            c1.Transaction = VTran;
                            c1.ExecuteNonQuery();
                        }
                        c3 = new SqlCommand("Delete from PurchaseReturnInvoice where RetID=" + VID, con);
                        c3.Transaction = VTran;
                        c3.ExecuteNonQuery(); ;
                    }
                }



                string insertPurchaseRet = "Insert into PurchaseReturnInvoice(RetID,RetDate,RetAmt,AmtPaid,SupplierID,Discount,Narration) Values(" + VID + ",'" + purchaseReturn.PurchaseReturnDate.Date + "'," + purchaseReturn.TotalAmount + "," + purchaseReturn.AmountPaid + ",'" + purchaseReturn.Vendor.Id.AccountNo + "'," + purchaseReturn.Discount + ", '" + purchaseReturn.Narration + "'   )";
                cmd = new SqlCommand(insertPurchaseRet, con);
                cmd.Transaction = VTran;
                cmd.ExecuteNonQuery();

                foreach (PurchaseReturnLine pl in purchaseReturn.PurchaseReturnLines)
                {
                    if (pl.IsDeleted == false && pl.Quantity > 0)
                    {
                        string insertPurchaseRetItems = "Insert Into PurchaseReturnBody(RetID,ItemID,Quantity,PurPrice) Values(" + VID + "," + pl.Item.ItemID + "," + pl.Quantity + "," + pl.PurchasePrice + ")";
                        cmd = new SqlCommand(insertPurchaseRetItems, con);
                        cmd.Transaction = VTran;
                        cmd.ExecuteNonQuery();
                    }
                }

                cmd = new SqlCommand("exec SpPurchaseRAccEntries " + VID + ",'" + purchaseReturn.PurchaseReturnDate.Date + "'", con);
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

                string select = "select * from PurchaseReturnInvoice PRI left Outer join PurchaseInvoice PIN On PIN.PurchaseID=PRI.PurchaseID Left Outer join ChartofAccounts C on C.AccountNo=PRI.SupplierID";

                con.Open();
                cmd = new SqlCommand(select, con);

                drWastageReturn = cmd.ExecuteReader();
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

                Vendor v;
                Purchase p = new Purchase();
                Wastage w;

                List<PurchaseReturnLine> purchaseReturnLines;
                List<WastageReturnLine> wastageReturnLines;

                while (drWastageReturn.Read())
                {
                    v = new Vendor(new ChartOfAccounts((string)drWastageReturn["AccountNo"], (string)drWastageReturn["AccountName"]), new Address(), "");
                    w = new Wastage();

                    wastageReturnLines = new List<WastageReturnLine>();

                    //PurchaseReturn pr = new PurchaseReturn((int)drPurchaseReturn["RetID"], p, (DateTime)drPurchaseReturn["RetDate"], purchaseReturnLines, (decimal)drPurchaseReturn["RetAmt"], (decimal)drPurchaseReturn["AmtPaid"], v,drPurchaseReturn ["Narration"].ToString ());                   
                    WastageReturn wr = new WastageReturn();//new WastageReturn( Convert.ToInt32(  drPurchaseReturn["WasID"]) , p,  Convert.ToDateTime(  drPurchaseReturn["WasDate"]) , PurchaseReturnLine , Convert.ToDecimal(  drPurchaseReturn["RetAmt"]) ,  Convert.ToDecimal(  drPurchaseReturn["AmtPaid"]) , v,  Convert.ToString(  drPurchaseReturn["Narration"]));                   
                    wr.Discount = Convert.ToDecimal(drWastageReturn["Discount"] == System.DBNull.Value ? "0" : drWastageReturn["Discount"]);

                    //purchaseReturns.Add(wr);
                    wastageReturns.Add(wr);
                }
                drWastageReturn.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                drWastageReturn.Close();
            }
        }

        public void AddWastageReturns()
        {
            try
            {

                Vendor v;
                Purchase p = new Purchase();
                Wastage w;

                //List<PurchaseReturnLine> purchaseReturnLines;
                List<WastageReturnLine> wastageReturnLines;

                while (drWastageReturn.Read())
                {
                    //v = new Vendor(new ChartOfAccounts((string)drWastageReturn["AccountNo"], (string)drWastageReturn["AccountName"]), new Address(), "");
                    v = new Vendor();
                    w = new Wastage();

                    wastageReturnLines = new List<WastageReturnLine>();

                    //PurchaseReturn pr = new PurchaseReturn((int)drPurchaseReturn["RetID"], p, (DateTime)drPurchaseReturn["RetDate"], purchaseReturnLines, (decimal)drPurchaseReturn["RetAmt"], (decimal)drPurchaseReturn["AmtPaid"], v,drPurchaseReturn ["Narration"].ToString ());                   
                    WastageReturn wr = new WastageReturn(Convert.ToInt32(drWastageReturn["WasID"]), w, Convert.ToDateTime(drWastageReturn["WastageDate"]), wastageReturnLines, Convert.ToDecimal(drWastageReturn["AmtWaste"]), Convert.ToDecimal(drWastageReturn["AmtPaid"]), v, Convert.ToString(drWastageReturn["Narration"]));
                    wr.Discount = Convert.ToDecimal(drWastageReturn["Discount"] == System.DBNull.Value ? "0" : drWastageReturn["Discount"]);

                    //purchaseReturns.Add(wr);
                    wastageReturns.Add(wr);
                }
                drWastageReturn.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                drWastageReturn.Close();
            }
        }

        public void AddWastageReturnLines(string id)
        {
            try
            {
                Item i;
                Category c;

                WastageReturnLine wastageReturnLine;
                List<WastageReturnLine> wastageReturnLines;

                SqlCommand cmd2;
                string selectWastageLine;

                //wastageReturnLines = new List<WastageReturnLine>();

                foreach (WastageReturn p in wastageReturns)
                {
                    if (wid != "")
                    {
                        string where = " where WIB.WasID= "+wid;
                        selectWastageLine = "select IC.CategoryID,IC.CategoryName,Item.ItemID,ItemName,CompanyName,ProductName,Size,Design,cs.Quantity as InHand,IsNull(WIB.Quantity,0) as RetQty,WIB.PurPrice,IsNull(WIB.SrNo,0) as SrNo  from WastageInvoiceBody WIB inner join Item on Item.ItemID=WIB.ItemID inner join ItemCategory IC on IC.CategoryID=Item.CategoryID inner join CurrentStock cs on cs.itemid=WIB.ItemID "+where;
                    }
                    else
                    {
                        selectWastageLine = "select IC.CategoryID,IC.CategoryName,Item.ItemID,ItemName,CompanyName,ProductName,Size,isnull(Color,'')as Color,Design,cs.Quantity as InHand,IsNull(WIB.Quantity,0) as RetQty,WIB.PurPrice,IsNull(WIB.SrNo,0) as SrNo  from WastageInvoiceBody WIB inner join Item on Item.ItemID=WIB.ItemID inner join ItemCategory IC on IC.CategoryID=Item.CategoryID inner join CurrentStock cs on cs.itemid=WIB.ItemID ";
                    }
                    
                    cmd2 = new SqlCommand(selectWastageLine, con);

                    drWastageReturnLine = cmd2.ExecuteReader();
                    while (drWastageReturnLine.Read())
                    {
                        i = new Item(Convert.ToInt32(drWastageReturnLine["ItemID"]), new ItemName((string)drWastageReturnLine["CompanyName"], (string)drWastageReturnLine["ProductName"], (string)drWastageReturnLine["Design"], (string)drWastageReturnLine["Size"]), (decimal)drWastageReturnLine["InHand"]);
                        c = new Category((int)drWastageReturnLine["CategoryID"], (string)drWastageReturnLine["CategoryName"]);

                        wastageReturnLine = new WastageReturnLine(c, i, (decimal)drWastageReturnLine["RetQty"], 0, (decimal)drWastageReturnLine["PurPrice"], Convert.ToDecimal((decimal)drWastageReturnLine["RetQty"] * (decimal)drWastageReturnLine["PurPrice"]), (int)drWastageReturnLine["SrNo"]);
                        p.WastageReturnLines.Add(wastageReturnLine);
                    }
                    drWastageReturnLine.Close();
                }

            }
            catch (Exception ex)
            {
                throw;
            }
            finally { drWastageReturnLine.Close(); }
        }

        public void AddPurchaseReturnLines()
        {
            try
            {
                Item i;
                Category c;
                PurchaseReturnLine purchaseReturnLine;
                List<PurchaseReturnLine> purchaseReturnLines;

                WastageReturnLine wastageReturnLine;
                List<WastageReturnLine> wastageReturnLines;

                SqlCommand cmd2;
                string selectPurchaseLine;

                wastageReturnLines = new List<WastageReturnLine>();

                foreach (WastageReturn p in wastageReturns)
                {
                    //selectPurchaseLine = "select IC.CategoryID,IC.CategoryName,Item.ItemID,ItemName,CompanyName,ProductName,Size,Design,cs.Quantity as InHand,IsNull(PRB.Quantity,0) as RetQty,PRB.PurPrice,IsNull(PRB.SrNo,0) as SrNo  from PurchaseReturnBody PRB inner join Item on Item.ItemID=PRB.ItemID inner join ItemCategory IC on IC.CategoryID=Item.CategoryID inner join CurrentStock cs on cs.itemid=PRB.ItemID where PRB.RetID=" + p.RetInvoiceNo;
                    selectPurchaseLine = "select IC.CategoryID,IC.CategoryName,Item.ItemID,isnull(Item.Color,'')as Color,ItemName,CompanyName,ProductName,Size,Design,cs.Quantity as InHand,IsNull(WIB.Quantity,0) as RetQty,WIB.PurPrice,IsNull(WIB.SrNo,0) as SrNo  from WastageInvoiceBody WIB inner join Item on Item.ItemID=WIB.ItemID inner join ItemCategory IC on IC.CategoryID=Item.CategoryID inner join CurrentStock cs on cs.itemid=WIB.ItemID";
                    cmd2 = new SqlCommand(selectPurchaseLine, con);

                    drWastageReturnLine = cmd2.ExecuteReader();
                    while (drWastageReturnLine.Read())
                    {
                        i = new Item(Convert.ToInt32(drWastageReturnLine["ItemID"]), new ItemName((string)drWastageReturnLine["CompanyName"], (string)drWastageReturnLine["ProductName"], (string)drWastageReturnLine["Design"], (string)drWastageReturnLine["Size"]), (decimal)drWastageReturnLine["InHand"]);
                        c = new Category((int)drWastageReturnLine["CategoryID"], (string)drWastageReturnLine["CategoryName"]);

                        wastageReturnLine = new WastageReturnLine(c, i, (decimal)drWastageReturnLine["RetQty"], 0, (decimal)drWastageReturnLine["PurPrice"], Convert.ToDecimal((decimal)drWastageReturnLine["RetQty"] * (decimal)drWastageReturnLine["PurPrice"]), (int)drWastageReturnLine["SrNo"]);


                        p.WastageReturnLines.Add(wastageReturnLine);
                    }
                    drWastageReturnLine.Close();
                }

            }
            catch (Exception ex)
            {
                throw;
            }
            finally { drWastageReturnLine.Close(); }
        }

        public bool DeletePurchaseReturn(PurchaseReturn purchaseReturn)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                VTran = con.BeginTransaction();

                cmd = new SqlCommand("Select * from PurchaseReturnInvoice Where RetID=" + purchaseReturn.RetInvoiceNo, con);
                cmd.Transaction = VTran;
                int i = (int)cmd.ExecuteScalar();

                if (i > 0)
                {
                    foreach (PurchaseReturnLine pl in purchaseReturn.PurchaseReturnLines)
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
                drWastageReturn = cmd.ExecuteReader();

                Vendor v;
                Purchase p;

                List<PurchaseReturnLine> purchaseReturnLines;

                while (drWastageReturn.Read())
                {
                    v = new Vendor(new ChartOfAccounts((string)drWastageReturn["VendorID"], (string)drWastageReturn["PartyName"]), new Address(), "");
                    p = new Purchase((int)drWastageReturn["PurchaseID"]);
                    purchaseReturnLines = new List<PurchaseReturnLine>();
                    purchaseReturns.Add(new PurchaseReturn((int)drWastageReturn["RetID"], p, (DateTime)drWastageReturn["RetDate"], purchaseReturnLines, (decimal)drWastageReturn["RetAmt"], (decimal)drWastageReturn["AmtPaid"], v));
                }
                drWastageReturn.Close();

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
                        selectPurchaseLine = "select IC.CategoryID,IC.CategoryName,Item.ItemID,ItemName,CompanyName,ProductName,Size,Design,cs.Quantity as InHand,PIB.Quantity  as PurQty, IsNull(Ret.Quantity,0) as RetQty,PIB.PurPrice,IsNull(Ret.SrNo,0) as SrNo  from PurchaseInvoiceBody PIB inner join Item on Item.ItemID=PIB.ItemID inner join ItemCategory IC on IC.CategoryID=Item.CategoryID inner join CurrentStock cs on cs.itemid=PIB.ItemID Left Outer Join ( Select PurchaseID,Prb.SrNo,ItemID,Sum(Quantity) as Quantity from PurchaseReturnBody PRB inner Join PurchaseReturnInvoice PR on PR.RetID=PRB.RetID where PurchaseID=" + pr.Purchase.InvoiceNo + " Group By PurchaseID,ItemID,PRb.SrNo ) Ret on Ret.PurchaseID=PIB.PurchaseID and PIB.ItemID=Ret.ItemID where PIB.PurchaseID=" + pr.Purchase.InvoiceNo + wPurchaseBody;
                        cmd2 = new SqlCommand(selectPurchaseLine, con);

                        drWastageReturnLine = cmd2.ExecuteReader();

                        bool contains = false;
                        while (drWastageReturnLine.Read())
                        {
                            i = new Item((int)drWastageReturnLine["ItemID"], new ItemName((string)drWastageReturnLine["CompanyName"], (string)drWastageReturnLine["ProductName"], (string)drWastageReturnLine["Design"], (string)drWastageReturnLine["Size"]), (decimal)drWastageReturnLine["InHand"]);
                            c = new Category((int)drWastageReturnLine["CategoryID"], (string)drWastageReturnLine["CategoryName"]);

                            purchaseReturnLine = new PurchaseReturnLine(c, i, (decimal)drWastageReturnLine["RetQty"], (decimal)drWastageReturnLine["PurQty"], (decimal)drWastageReturnLine["PurPrice"], Convert.ToDecimal((decimal)drWastageReturnLine["RetQty"] * (decimal)drWastageReturnLine["PurPrice"]), (int)drWastageReturnLine["SrNo"]);
                            pr.PurchaseReturnLines.Add(purchaseReturnLine);

                            contains = true;
                        }

                        if (contains == true)
                        {
                            subPurchaseReturns.Add(pr);
                        }
                        drWastageReturnLine.Close();
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

        public List<WastageReturn> GetWastageReturns(string where)
        {
            string select = "";
            
            try
            {
                if (wastageReturns == null) wastageReturns = new List<WastageReturn>();

                if (where != "WastageDamage")
                {
                    wid = where ;
                    where = " where WI.WasID = "+where+" ";
                    select = "select * from wastageinvoice WI inner join WastageInvoiceBody WIB On WI.WasID=WIB.WasID " + where;
                }
                else 
                {
                    select = "select * from wastageinvoice WI inner join WastageInvoiceBody WIB On WI.WasID=WIB.WasID";
                }

                con = new SqlConnection(source);
                //select * from PurchaseReturnInvoice PRI left Outer join PurchaseInvoice PIN On PIN.PurchaseID=PRI.PurchaseID Left Outer join ChartofAccounts C on C.AccountNo=PRI.SupplierID
                 

                con.Open();
                cmd = new SqlCommand(select, con);

                drWastageReturn = cmd.ExecuteReader();

                AddWastageReturns();

                if (wastageReturns.Count > 0)
                {
                    string id=wid;
                    AddWastageReturnLines(id);
                }

                return wastageReturns;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void DeleteWastageReturn(WastageReturn wastageReturn)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                VTran = con.BeginTransaction();

                cmd = new SqlCommand("Select * from WastageInvoice Where WasID=" + wastageReturn.RetInvoiceNo, con);
                cmd.Transaction = VTran;
                int i = (int)cmd.ExecuteScalar();

                if (i > 0)
                {
                    foreach (WastageReturnLine pl in wastageReturn.WastageReturnLines)
                    {
                        cmd = new SqlCommand("Delete from WastageInvoiceBody where SrNo=" + pl.SerialNumber, con);
                        cmd.Transaction = VTran;
                        cmd.ExecuteNonQuery();
                    }
                    cmd = new SqlCommand("Delete from WastageInvoice where WasID=" + wastageReturn.RetInvoiceNo, con);
                    cmd.Transaction = VTran;
                    cmd.ExecuteNonQuery();
                }

                VTran.Commit();
                con.Close();
                //return true;
            }
            catch (Exception)
            {
                VTran.Rollback();
                throw;
            }
            finally { con.Close(); }
        }
    }
}