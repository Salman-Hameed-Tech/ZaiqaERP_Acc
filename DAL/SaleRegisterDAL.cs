using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using Common;

namespace DAL
{
    public class SaleRegisterDAL
    {
        private string source = ReadProjectConfigFile.ConfigString();
        SqlConnection con;
        SqlCommand cmd;

        SqlDataAdapter da = new SqlDataAdapter();

        public bool GetData(ref Common.Data_Sets.DSSaleRegister ds, string where)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                
                cmd = new SqlCommand(" select si.SaleID,si.SaleDate,si.SupplierID as partyID,p.partyname as PartyName,si.TotalAmt,si.BranchID,b.BranchName,sib.ItemID,i.ItemName,sib.Quantity,sib.SalePrice from saleinvoice si  inner join saleinvoicebody sib on si.saleid=sib.saleid left join parties p on si.supplierid=p.partyid left join Branch b on si.Branchid=b.id   left join item i on sib.Itemid=i.itemid left join ItemCategory ic  on i.CategoryID=ic.CategoryID  " + where+"  ", con);
                
                da.SelectCommand = cmd;

                da.Fill(ds, "SPSaleInvoice");

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GetDailyProfit(ref Common.Data_Sets.DSDailyProfit ds, string where)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();

                string select;
                //previously made
                //select = "select itemname as Article ,sum(quantity) as qty, sum(purchaseprice) as pprice,sum(sib.SalePrice) as sprice, sum(purchaseprice*quantity) as Pvalue,sum(sib.SalePrice*quantity)as Svalue from item inner join saleinvoicebody sib on sib.itemid=item.itemid inner join saleinvoice si on si.saleid=sib.saleid  " + where + " group by itemname ";

                select = "select itemname as Article ,(quantity) as qty, (purchaseprice) as pprice,(sib.SalePrice) as sprice, (purchaseprice*quantity) as Pvalue,(sib.SalePrice*quantity)as Svalue from item inner join saleinvoicebody sib on sib.itemid=item.itemid inner join saleinvoice si on si.saleid=sib.saleid and si.saledate=sib.saledate " + where;

                cmd = new SqlCommand(select, con);

                da.SelectCommand = cmd;

                da.Fill(ds, "DataTable1");
                con.Close();
                //int i= ds.Tables["DataTable1"].Rows.Count;
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int GetDiscount(string where)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                string select = "select sum(totaldiscount) from saleinvoice sib "+where;
                cmd = new SqlCommand(select, con);
                int disc =Convert.ToInt32( cmd.ExecuteScalar());
                con.Close();
                return disc;

                
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
