using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class StockAdjDAL
    {
        private string source = ReadProjectConfigFile.ConfigString();
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlTransaction VTran;

        private List<StockAdj> adjustments;

        public List<StockAdj> GetItems(int Cat)
        {
            if (adjustments == null) adjustments = new List<StockAdj>();
            try
            {
                string select;

                select = "select I.ItemID,I.ItemName,isnull(Color,'')as Color,I.CompanyName,I.ProductName,I.Design,I.Size,CS.Quantity,CS.Price from Item I inner join ItemCategory IC on IC.CategoryID=I.CategoryID inner join CurrentStock CS on CS.ItemID=I.ItemID where I.IsActive=1 and I.CategoryID=" + Cat;
                

                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand(select, con);

                dr = cmd.ExecuteReader();
                
                Item i;

                while (dr.Read())
                {
                    i = new Item(Convert.ToInt32(dr["ItemID"]), new ItemName(Convert.ToString(dr["CompanyName"]), Convert.ToString(dr["ProductName"]), Convert.ToString(dr["Design"]), Convert.ToString(dr["Size"])));

                    adjustments.Add(new StockAdj(0, DateTime.Now.Date, i, Convert.ToDecimal(dr["Quantity"]), Convert.ToDecimal(dr["Price"]), 0, 0, User.UserNo));
                }

                dr.Close();
                con.Close();
                return adjustments;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
        }

        public bool SaveAdjustment(StockAdj adj)
        {
            try
            {
                int VID = 0;
                
                con = new SqlConnection(source);
                con.Open();
                
                VTran = con.BeginTransaction();

                
                cmd = new SqlCommand("Select IsNull(Max(AdjID),0) +1 From StockAdjustment", con);
                cmd.Transaction = VTran;
                VID = Convert.ToInt32(cmd.ExecuteScalar());                

                string insertAdj = "Insert into StockAdjustment(AdjID,ItemID,PreQuan,PrePrice,CurQuan,CurPrice,UserID,AdjDate) Values(" + VID + "," + adj.Item.ItemID + "," + adj.PreviousQuantity + "," + adj.PreviousPrice+ "," + adj.CurrentQuantity + "," + adj.CurrentPrice+ "," + User.UserNo + ",'" + adj.AdjDate + "')";
                cmd = new SqlCommand(insertAdj, con);
                cmd.Transaction = VTran;
                cmd.ExecuteNonQuery();

                string updateStock = "Update CurrentStock Set Quantity="+ adj.CurrentQuantity + ", Price=" + adj.CurrentPrice + " where ItemID="+adj.Item.ItemID;
                cmd = new SqlCommand(updateStock, con);
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
            finally{ con.Close(); }
        }

    }
}
