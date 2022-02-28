using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

using Common;

namespace DAL
{
    public class SaleReturnDAL
    {
        //Fields.
        List<SaleReturn> saleReturns;
        List<SaleReturn> subSaleReturns;
        private string source = ReadProjectConfigFile.ConfigString();

        SqlConnection con;
        SqlCommand cmd;

        SqlDataReader drSaleReturn;
        SqlDataReader drSaleReturnLine;

        SqlTransaction VTran;
        SqlDataReader dr;

        public int GetMaximumID()
        {

            int VID = 0;

            con = new SqlConnection(source);
            con.Open();

            cmd = new SqlCommand("Select IsNull(Max(RetID),0) +1 From SaleReturnInvoice", con);
            VID = Convert.ToInt32(cmd.ExecuteScalar());

            return VID;
        }

        public int CheckExisting(int s)
        {
            con = new SqlConnection(source);
            con.Open();
            int sid=0;
            cmd = new SqlCommand("Select RetID From SaleReturnInvoice where saleID="+s , con);

            if (cmd.ExecuteScalar() != null)
            {
                sid = (int)cmd.ExecuteScalar();
                if (sid > 0)
                {
                    return sid;
                }
                else
                    return 0;
            }
            else
                return 0;
            
        }

        public bool SaveSaleReturn(SaleReturn saleReturn)
        {
            try
            {
                int VID = 0;
                con = new SqlConnection(source);
                con.Open();
                VTran = con.BeginTransaction();

                if (saleReturn.RetInvoiceNo == 0)
                {
                    cmd = new SqlCommand("Select IsNull(Max(RetID),0) +1 From SaleReturnInvoice", con);
                    cmd.Transaction = VTran;
                    VID = Convert.ToInt32(cmd.ExecuteScalar());
                }
                else
                {
                    VID = saleReturn.RetInvoiceNo;
                    SqlCommand c1, c2, c3;

                    cmd = new SqlCommand("Select * from SaleReturnInvoice Where RetID=" + VID, con);
                    cmd.Transaction = VTran;
                    int i = (int)cmd.ExecuteScalar();

                    if (i > 0)
                    {

                        foreach (SaleReturnLine sl in saleReturn.SaleReturnLines)
                        {
                            c1 = new SqlCommand("Delete from SaleReturnBody where SrNo=" + sl.SerialNumber, con);
                            c1.Transaction = VTran;
                            c1.ExecuteNonQuery();
                        }
                        c3 = new SqlCommand("Delete from SaleReturnInvoice where RetID=" + VID, con);
                        c3.Transaction = VTran;
                        c3.ExecuteNonQuery(); ;
                    }
                }


                string n = "NULL";

                string insertPurchaseRet = "Insert into SaleReturnInvoice(RetID,RetDate,SaleID,RetAmt,AmtRecieved,SupplierID,Type,Narration,BranchID) Values(" + VID + ",'" + saleReturn.SaleReturnDate.Date + "'," + (saleReturn.Sale ==null ? 0 : saleReturn.Sale.SaleID) + "," + saleReturn.TotalAmount + "," + saleReturn.AmountPaid + "," + (saleReturn.Vendor.Id.AccountNo.Trim().Length == 0 ? n : "'" + saleReturn.Vendor.Id.AccountNo.Trim() + "'") +",'"+ saleReturn.Type.ToString() +"',"+ (Convert.ToString(saleReturn.Narration == null ? "":saleReturn.Narration).Trim().Length == 0 ? n:"'"+ saleReturn.Narration.Trim() +"'") + "," + saleReturn.BranchID + ")";
                cmd = new SqlCommand(insertPurchaseRet, con);
                cmd.Transaction = VTran;
                cmd.ExecuteNonQuery();

                foreach (SaleReturnLine sl in saleReturn.SaleReturnLines )
                {
                    if (sl.IsDeleted == false && sl.Quantity > 0)
                    {
                        string insertPurchaseRetItems = "Insert Into SaleReturnBody(RetID,ItemID,Quantity,PurPrice,SalePrice,BranchID) Values(" + VID + "," + sl.Item.ItemID + "," + sl.Quantity + "," + sl.PurchasePrice + "," + sl.SalePrice + "," + sl.BranchID + ")";
                        cmd = new SqlCommand(insertPurchaseRetItems, con);
                        cmd.Transaction = VTran;
                        cmd.ExecuteNonQuery();
                    }
                }

                cmd = new SqlCommand("exec SPClaimAccEntries " + VID + ",'" + saleReturn.SaleReturnDate.Date + "'", con);
                cmd.Transaction = VTran;
                cmd.ExecuteNonQuery();

                VTran.Commit();
                con.Close();
                return true;
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

        public List<SaleReturn> GetSaleReturns(string type)
        {
            try
            {
                if (saleReturns == null) saleReturns = new List<SaleReturn>();

                con = new SqlConnection(source);

                string where = "";

                //if (type == "Claim")
                //{
                //    where = " where PRI.saleId=0";
                //}
                //else
                //    where = " where PRI.saleId <> 0";

                string select = "select * from SaleReturnInvoice PRI Left Outer join SaleInvoice PIN On PIN.SaleID=PRI.SaleID Left Outer join ChartofAccounts C on C.AccountNo=PRI.SupplierID " + where;

                con.Open();
                cmd = new SqlCommand(select, con);

                drSaleReturn = cmd.ExecuteReader();
                AddSaleReturns();
                if (saleReturns.Count > 0)
                {
                    Item i;
                    Category c;
                    SaleReturnLine saleReturnLine;
                    List<SaleReturnLine> saleReturnLines;

                    SqlCommand cmd2;
                    string selectPurchaseLine;

                    saleReturnLines = new List<SaleReturnLine>();

                    foreach (SaleReturn s in saleReturns)
                    {
                        //if (type == "Claim")
                        //{
                            selectPurchaseLine = "select IC.CategoryID,IC.CategoryName,Item.ItemID,Item.ItemName,Item.CompanyName,Item.ProductName,Item.Design,Item.Size,isnull(Item.Color,'')as Color,cs.Quantity as InHand,Ret.Quantity  as PurQty, IsNull(Ret.Quantity,0) as RetQty,Ret.SalePrice,Item.PurchasePrice as PurPrice,IsNull(Ret.SrNo,0) as SrNo  from Item  inner join ItemCategory IC on IC.CategoryID=Item.CategoryID inner join CurrentStock cs on cs.itemid=Item.ItemID Left Outer Join ( Select PR.RetID,SaleID,Prb.SrNo,ItemID,Sum(Quantity) as Quantity,PRB.SalePrice from SaleReturnBody PRB inner Join SaleReturnInvoice PR on PR.RetID=PRB.RetID where PR.RetID=" + s.RetInvoiceNo + " Group By PR.RetID,SaleID,ItemID,PRb.SrNo,PRB.SalePrice ) Ret on Ret.ItemID=Item.ItemID where Ret.RetID=" + s.RetInvoiceNo;    
                        //}
                        //else
                        //    selectPurchaseLine = "select IC.CategoryID,IC.CategoryName,Item.ItemID,Item.ItemName,cs.Quantity as InHand,PIB.Quantity  * Multiplier as PurQty, IsNull(Ret.Quantity,0) as RetQty,PIB.SalePrice,PIB.PurPrice,IsNull(Ret.SrNo,0) as SrNo  from SaleInvoiceBody PIB inner join Item on Item.ItemID=PIB.ItemID inner join Packing P on P.packID=PIB.packID inner join ItemCategory IC on IC.CategoryID=Item.CategoryID inner join CurrentStock cs on cs.itemid=PIB.ItemID Left Outer Join ( Select SaleID,Prb.SrNo,ItemID,Sum(Quantity) as Quantity from SaleReturnBody PRB inner Join SaleReturnInvoice PR on PR.RetID=PRB.RetID where SaleID=" + s.Sale.Saleid + " Group By SaleID,ItemID,PRb.SrNo ) Ret on Ret.SaleID=PIB.SaleID and PIB.ItemID=Ret.ItemID where PIB.SaleID=" + s.Sale.Saleid;
                        
                        cmd2 = new SqlCommand(selectPurchaseLine, con);

                        drSaleReturnLine = cmd2.ExecuteReader();
                        while (drSaleReturnLine.Read())
                        {
                            i = new Item(Convert.ToInt32(drSaleReturnLine["ItemID"]), new ItemName(Convert.ToString(drSaleReturnLine["CompanyName"]), Convert.ToString(drSaleReturnLine["ProductName"]), Convert.ToString(drSaleReturnLine["Design"]), Convert.ToString(drSaleReturnLine["Size"])));
                            i.CurrentStock = Convert.ToDecimal(drSaleReturnLine["InHand"]);

                            c = new Category((int)drSaleReturnLine["CategoryID"], (string)drSaleReturnLine["CategoryName"]);

                            saleReturnLine = new SaleReturnLine(c, i, (decimal)drSaleReturnLine["RetQty"], (decimal)drSaleReturnLine["PurQty"], (decimal)drSaleReturnLine["PurPrice"], (decimal)drSaleReturnLine["SalePrice"], Convert.ToDecimal((decimal)drSaleReturnLine["RetQty"] * (decimal)drSaleReturnLine["SalePrice"]), (int)drSaleReturnLine["SrNo"]);
                            s.SaleReturnLines.Add(saleReturnLine);
                        }
                        drSaleReturnLine.Close();
                    }
                }

                return saleReturns;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void AddSaleReturns()
        {
            try
            {

               Vendor  v;
               SaleInvoice s;

                List<SaleReturnLine> saleReturnLines;

                while (drSaleReturn.Read())
                {
                   v = new Vendor(new ChartOfAccounts(Convert.ToString(drSaleReturn["SupplierID"] == System.DBNull.Value ? "" : drSaleReturn["SupplierID"]), Convert.ToString(drSaleReturn["AccountName"] == System.DBNull.Value ? "" : drSaleReturn["AccountName"])), new Address(), "");
                   s = new SaleInvoice();
                   s.SaleID=(int)drSaleReturn["SaleID"];
                   saleReturnLines = new List<SaleReturnLine>();
                   saleReturns.Add(new SaleReturn((int)drSaleReturn["RetID"], s, (DateTime)drSaleReturn["RetDate"], saleReturnLines, (decimal)drSaleReturn["RetAmt"], (decimal)drSaleReturn["AmtRecieved"], v, (ClaimType)Enum.Parse(typeof(ClaimType), Convert.ToString(drSaleReturn["Type"]), true), Convert.ToString(drSaleReturn["Narration"] == System.DBNull.Value ? "" : drSaleReturn["Narration"])));
                }
                drSaleReturn.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                drSaleReturn.Close();
            }
        }

        public void AddSaleReturnLines()
        {
            try
            {
                Item i;
                Category c;
                SaleReturnLine saleReturnLine;
                List<SaleReturnLine> saleReturnLines;

                SqlCommand cmd2;
                string selectPurchaseLine;

                saleReturnLines = new List<SaleReturnLine>();

                foreach (SaleReturn s in saleReturns)
                {
                    selectPurchaseLine = "select IC.CategoryID,IC.CategoryName,Item.ItemID,Item.ItemName,isnull(Item.Color,'')as Color,Item.CompanyName,Item.ProductName,Item.Design,Item.Size,cs.Quantity as InHand,PIB.Quantity  * Multiplier as PurQty, IsNull(Ret.Quantity,0) as RetQty,PIB.SalePrice,PIB.PurPrice,IsNull(Ret.SrNo,0) as SrNo  from SaleInvoiceBody PIB inner join Item on Item.ItemID=PIB.ItemID inner join Packing P on P.packID=PIB.packID inner join ItemCategory IC on IC.CategoryID=Item.CategoryID inner join CurrentStock cs on cs.itemid=PIB.ItemID Left Outer Join ( Select SaleID,Prb.SrNo,ItemID,Sum(Quantity) as Quantity from SaleReturnBody PRB inner Join SaleReturnInvoice PR on PR.RetID=PRB.RetID where SaleID=" + s.Sale.SaleID + " Group By SaleID,ItemID,PRb.SrNo ) Ret on Ret.SaleID=PIB.SaleID and PIB.ItemID=Ret.ItemID where PIB.SaleID=" + s.Sale.SaleID;
                    cmd2 = new SqlCommand(selectPurchaseLine, con);

                    drSaleReturnLine = cmd2.ExecuteReader();
                    while (drSaleReturnLine.Read())
                    {
                        i = new Item(Convert.ToInt32(drSaleReturnLine["ItemID"]), new ItemName(Convert.ToString(drSaleReturnLine["CompanyName"]), Convert.ToString(drSaleReturnLine["ProductName"]), Convert.ToString(drSaleReturnLine["Design"]), Convert.ToString(drSaleReturnLine["Size"])));
                        i.CurrentStock = Convert.ToDecimal(drSaleReturnLine["InHand"]);

                        c = new Category((int)drSaleReturnLine["CategoryID"], (string)drSaleReturnLine["CategoryName"]);

                        saleReturnLine = new SaleReturnLine(c, i, (decimal)drSaleReturnLine["RetQty"], (decimal)drSaleReturnLine["PurQty"], (decimal)drSaleReturnLine["PurPrice"], (decimal)drSaleReturnLine["SalePrice"], Convert.ToDecimal((decimal)drSaleReturnLine["RetQty"] * (decimal)drSaleReturnLine["SalePrice"]), (int)drSaleReturnLine["SrNo"]);
                        s.SaleReturnLines.Add(saleReturnLine);
                    }
                    drSaleReturnLine.Close();
                }

            }
            catch (Exception ex)
            {
                throw;
            }
            finally { drSaleReturnLine.Close(); }
        }

        public bool DeleteSaleReturn(SaleReturn saleReturn)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                VTran = con.BeginTransaction();

                cmd = new SqlCommand("Select * from SaleReturnInvoice Where RetID=" + saleReturn.RetInvoiceNo , con);
                cmd.Transaction = VTran;
                int i = (int)cmd.ExecuteScalar();

                if (i > 0)
                {
                    foreach (SaleReturnLine pl in saleReturn.SaleReturnLines )
                    {
                        cmd = new SqlCommand("Delete from SaleReturnBody where SrNo=" + pl.SerialNumber, con);
                        cmd.Transaction = VTran;
                        cmd.ExecuteNonQuery();
                    }
                    cmd = new SqlCommand("Delete from SaleReturnInvoice where RetID=" + saleReturn.RetInvoiceNo, con);
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
    }
}
