using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using Common;

namespace DAL
{
    public class GodownStockDAL
    {
        private string source = ReadProjectConfigFile.ConfigString();
        SqlConnection con;
        SqlCommand cmd;

        SqlDataAdapter da = new SqlDataAdapter();

        public bool GetData(ref Common.Data_Sets.DSGodownStock ds,string where)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                string select;

                select = " Select IC.CategoryID,IC.CategoryName,I.ItemID,I.ItemName,isnull(CS.Quantity,0) as Quantity,CS.Price as Price, b.BranchName,b.ID as BranchID  from item I inner Join  (select BranchID,itemid,sum(quantity) as quantity , case when sum(quantity)<>0  then sum(quantity*price)/sum(quantity) else 0  end as price from tblfifo group by itemid,BranchID)Cs  on I.ItemID=Cs.Itemid  Inner Join ItemCategory IC on I.CategoryID=Ic.CategoryID  inner Join Branch b on Cs.BranchID = b.ID    " + where+"     Order By IC.CategoryID,I.ItemName   ";
                cmd = new SqlCommand(select, con);
                da.SelectCommand = cmd;
                da.Fill(ds, "GodownStock");
                return true;

                

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
