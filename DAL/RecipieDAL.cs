using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace DAL
{
    public class RecipieDAL
    {
        string source = ReadProjectConfigFile.ConfigString();
        List<SchItems> lstItems = new List<SchItems>();
        SqlConnection con;
        SqlDataReader dr;
        SqlCommand cmd;
        SqlTransaction VTran;

        private List<ProductionRecipie> invoices;
        List<ProductionRecipieLines> invoiceLines = new List<ProductionRecipieLines>();


        public string GetMaxInvID()
        {
            try
            {
                int VID = 0;
                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand("Select IsNull(Max(ID),0) +1 From RecipieProduction", con);
                VID = (int)cmd.ExecuteScalar();

                return VID.ToString();
            }
            catch (Exception)
            {
               
                throw;
            }
            finally { con.Close(); }
        }

        public List<ProductionRecipie> GetInvoices(int id, int branchID)
        {
            try
            {

                invoices = new List<ProductionRecipie>();
                con = new SqlConnection(source);
                con.Open();

                string where = "";
             
                string select = "";
                if (id > 0)
                {
                    AddInvoiceLines(id);
                    where = "where ID =" + id;
                    select = " select ID, p.Dated, BranchID, MItemID, MQuantity,i.ItemName, isnull(TotalAmt,0) as TotalAmt  from recipieproduction  p left join Item i on p.MItemID=i.ItemID " + where+" order by ID DESC ";
                }

                else
                {
                    if (User._IsAdmin)
                    {
                        select = " select ID, p.Dated, BranchID, MItemID, i.ItemName,MQuantity, isnull(TotalAmt,0) as TotalAmt from recipieproduction p left join Item i on p.MItemID=i.ItemID " + where + " order by ID DESC ";
                    }
                    else
                    {
                        select = " select ID, p.Dated, BranchID, MItemID,i.ItemName, MQuantity, isnull(TotalAmt,0) as TotalAmt  from recipieproduction p left join Item i on p.MItemID=i.ItemID  order by ID DESC ";
                    }
                }



                cmd = new SqlCommand(select, con);

                dr = cmd.ExecuteReader();
                AddInvoices(id);

                return invoices;
            }

            catch { throw; }
            finally { con.Close(); }
        }

        private List<ProductionRecipieLines> AddInvoiceLines(int id)
        {
            try
            {
                string selectLine = " select pb.ItemID,i.ItemName,pb.Quantity,Pb.Rate,pb.Total,Cs.quantity as CsQty,pb.srno from recipieproductionbody pb left join Item i on pb.itemid = i.ItemID  Left Outer Join(select itemid, sum(quantity) as quantity,case when sum(quantity) <> 0  then  sum(quantity * price) / sum(quantity) else 0  end as price from tblfifo where branchid = "+Globals.BranchID+" group by itemid) Cs on Cs.Itemid = pb.itemid where pb.rid = "+id+" ";
                SqlCommand cmd = new SqlCommand(selectLine, con);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ProductionRecipieLines lines = new ProductionRecipieLines();
                    lines.ItemID = Convert.ToInt32(dr["ItemID"]);
                    lines.ItemName = dr["ItemName"].ToString();
                    lines.Quantity= Convert.ToDecimal(dr["Quantity"]);
                    lines.Rate = Convert.ToDecimal(dr["Rate"]);
                    lines.CsQty = Convert.ToDecimal(dr["CsQty"]);
                    lines.SrNo = Convert.ToInt32(dr["srno"]);
                    invoiceLines.Add(lines);
                }
                dr.Close();

                return invoiceLines;
            }
            catch
            {
                throw;
            }
        }

        private void AddInvoices(int id)
        {
            try
            {
                while (dr.Read())
                {
                    ProductionRecipie p = new ProductionRecipie();
                    p.ID = Convert.ToInt32(dr["ID"]);
                    p.Dated = Convert.ToDateTime(dr["Dated"]);
                    p.MItemID = Convert.ToInt32(dr["MItemID"]);
                    p.MItemName = dr["ItemName"].ToString();
                    p.MQuantity=Convert.ToDecimal(dr["MQuantity"]);
                    p.TotalAmt = Convert.ToDecimal(dr["TotalAmt"]);

                    p.productionRecipieLines = invoiceLines;
                    invoices.Add(p);
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

        public int Save(ProductionRecipie invoice, bool isNew)
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
                    cmd = new SqlCommand("Select IsNull(Max(ID),0) +1 From RecipieProduction", con);
                    cmd.Transaction = VTran;
                    VID = Convert.ToInt32(cmd.ExecuteScalar());

                    string insertInvoice = "Insert into RecipieProduction(ID,Dated,BranchID,MItemID,MQuantity,TotalAmt) Values(" + VID + ",'" + invoice.Dated.Date + "'," + invoice.BranchID + "," + invoice.MItemID + "," + invoice.MQuantity + "," + invoice.TotalAmt + ")";
                    cmd.CommandText = insertInvoice;
                    cmd.ExecuteNonQuery();

                    foreach (ProductionRecipieLines pl in invoice.productionRecipieLines)
                    {
                        if (pl.IsDeleted == false)
                        {
                            cmd.CommandText = SetInsertLine(pl, VID);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                else
                {
                    VID = invoice.ID;
                    cmd = new SqlCommand("", con);
                    cmd.Transaction = VTran;
                    if (con == null)
                    {
                        con = new SqlConnection(source);
                        con.Open();
                    }

                    foreach (ProductionRecipieLines line in invoice.productionRecipieLines)
                    {
                        if (line.SrNo != 0)
                        {
                            cmd.CommandText = "Update RecipieProductionBody Set Quantity = " + line.Quantity + ",Total="+line.Total+" where SrNo = " + line.SrNo;
                        }
                        
                       
                        cmd.ExecuteNonQuery();
                    }

                    cmd.CommandText = "Update RecipieProduction Set MQuantity="+invoice.MQuantity+",TotalAmt="+invoice.TotalAmt+"   Where ID = " + invoice.ID;
                    cmd.ExecuteNonQuery();

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

        private string SetInsertLine(ProductionRecipieLines pl, int VID)
        {
            try
            {
                string insertItems = "Insert Into RecipieProductionBody(RID,ItemID,Quantity,Rate,Total) Values(" + VID + "," + pl.ItemID + "," + pl.Quantity + "," + pl.Rate + ","+pl.Total+")";
                return insertItems;
            }
            catch
            {
                VTran.Rollback();
                throw;
            }
        }

        public List<Item> GetRecipieList(int itemID)
        {
            try
            {
                List<Item> lstrecipie = new List<Item>();
                con = new SqlConnection(source);
                con.Open();

                cmd = new SqlCommand("select r.ItemID,r.Quantity,i.itemname,isnull(cs.price,0) as price,isnull(cs.quantity,0) as csqty from Recipie r left join item i  on r.itemid=i.itemid Left Outer Join (select itemid,sum(quantity) as quantity,case when sum(quantity)<>0  then  sum(quantity*price)/sum(quantity) else 0  end  as price from tblfifo where branchid=" + Globals.BranchID + " group by itemid) Cs on Cs.Itemid=r.itemid where r.MItemID=" + itemID+"",con);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Item i = new Item();
                    ItemName name = new ItemName();
                    i.ItemID = Convert.ToInt32(dr["ItemID"]);
                    name.ProductName=dr["itemname"].ToString();
                    i.Quantity = Convert.ToDecimal(dr["Quantity"]);
                    i.CurrentStock = Convert.ToDecimal(dr["csqty"]);
                    i.PurchasePrice = Convert.ToDecimal(dr["price"]);//as cs price
                    i.ItemName = name;
                    lstrecipie.Add(i);
                }

                return lstrecipie;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool SaveRecipie(Item item)// for  save recipie
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();

                VTran = con.BeginTransaction();

               
                cmd = new SqlCommand("Delete from Recipie where MItemID = " + item.ItemID, con);
                cmd.Transaction = VTran;
                cmd.ExecuteNonQuery();

                foreach (var obj in item.ReceipeList)
                {
                    cmd.CommandText="insert into Recipie (MItemID,ItemID,Quantity) values(" + item.ItemID + ","+obj.ItemID+","+obj.Quantity+") ";
                    cmd.Transaction = VTran;
                    cmd.ExecuteNonQuery();
                }
                VTran.Commit();
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
