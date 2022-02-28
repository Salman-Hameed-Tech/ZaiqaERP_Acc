using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Common;

namespace DAL
{
    public class OpeningStockDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlTransaction sqlTrans;

        OpeningStock openingstock;
        OpeningStockLine openingstockline;

        private string source = ReadProjectConfigFile.ConfigString();

        public bool SaveOpeningStock(List<OpeningStockLine> stockLine, bool isnew)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                sqlTrans = con.BeginTransaction();
                int VID = 0;
                for (int i = 0; i < stockLine.Count; i++)
                {
                    if (isnew == true)
                    {
                        cmd = new SqlCommand("  select isnull(max(id),0)+1 from  OpeningStock ",con);
                        cmd.Transaction = sqlTrans;
                        VID = Convert.ToInt32(cmd.ExecuteScalar());
                     

                        string query = "Insert into OpeningStock(ID,ItemID, ItemName, PartyID, PartyName, Quantity, Dated)Values(" + VID + "," + stockLine[i].ItemID + ", '" + stockLine[i].ItemName + "', " + stockLine[i].PartyID + ", '" + stockLine[i].PartyName + "', " + stockLine[i].Quantity + ", '" + stockLine[i].Dated.ToString("yyyy-MM-dd 00:00:00") + "')";
                        cmd = new SqlCommand(query, con);
                        cmd.Transaction = sqlTrans;
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        VID = stockLine[0].ID;

                        if(stockLine[i].SrNo > 0)
                        {
                            string query = "Update OpeningStock set ItemID=" + stockLine[i].ItemID + ", ItemName='" + stockLine[i].ItemName + "', PartyID='" + stockLine[i].PartyID + "', PartyName='" + stockLine[i].PartyName + "', Quantity=" + stockLine[i].Quantity + ", Dated='" + stockLine[i].Dated.ToString("yyyy-MM-dd 00:00:00") + "'  where id="+VID+" and itemid="+ stockLine[i].ItemID+ " ";
                            cmd = new SqlCommand(query, con);
                            cmd.Transaction = sqlTrans;
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            string query = "Insert into OpeningStock(ID ,ItemID, ItemName, PartyID, PartyName, Quantity, Dated)Values(" + VID + "," + stockLine[i].ItemID + ", '" + stockLine[i].ItemName + "', " + stockLine[i].PartyID + ", '" + stockLine[i].PartyName + "', " + stockLine[i].Quantity + ", '" + stockLine[i].Dated.ToString("yyyy-MM-dd 00:00:00") + "')";
                            cmd = new SqlCommand(query, con);
                            cmd.Transaction = sqlTrans;
                            cmd.ExecuteNonQuery();

                        }

                       
                       
                    }
                }
                sqlTrans.Commit();
                con.Close();
                return true;
            }
            catch (Exception)
            {
                sqlTrans.Rollback();
                con.Close();
                throw;
            }
        }

        public string GetMaxID()
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand("  select isnull(max(id),0)+1 from  OpeningStock ",con);
                string id = cmd.ExecuteScalar().ToString();

                return id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<OpeningStockLine> LoadGrid()
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand("select distinct(ID),PartyID, PartyName, Dated from openingstock", con);
                dr = cmd.ExecuteReader();

                List<OpeningStockLine> lstitem = new List<OpeningStockLine>();

                while (dr.Read())
                {
                    OpeningStockLine osl = new OpeningStockLine();
                    osl.ID = Convert.ToInt32(dr["ID"]);
                    osl.PartyID = Convert.ToInt32(dr["PartyID"]);
                    osl.PartyName = (dr["PartyName"]).ToString();
                    osl.Dated = Convert.ToDateTime(dr["Dated"]);
                    lstitem.Add(osl);
                }
                return lstitem;
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

        public List<OpeningStockLine> GetSingleOpeningStock( DateTime dateTime)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                string select = "select ID,ItemID, ItemName, PartyID, PartyName, Quantity, Dated,SrNo from openingstock where Dated = '" + dateTime.ToString("yyyy-MM-dd 00:00:00") + "' ";
                cmd = new SqlCommand(select, con);
                dr = cmd.ExecuteReader();
                List<OpeningStockLine> lstSelectedOS = new List<OpeningStockLine>();

                while (dr.Read())
                {
                    openingstockline = new OpeningStockLine();
                    openingstockline.ID = Convert.ToInt32(dr["ID"]);
                    openingstockline.ItemID = Convert.ToInt32(dr["ItemID"]);
                    openingstockline.ItemName = dr["ItemName"].ToString();
                    openingstockline.PartyID = Convert.ToInt32(dr["PartyID"]);
                    openingstockline.PartyName = (dr["PartyName"]).ToString();
                    openingstockline.Quantity = Convert.ToInt32(dr["Quantity"]);
                    openingstockline.Dated = Convert.ToDateTime(dr["Dated"]);
                    openingstockline.SrNo = Convert.ToInt32(dr["SrNo"]);
                    lstSelectedOS.Add(openingstockline);
                }
                return lstSelectedOS;
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

        public bool DeleteOpeningStock(int itemid, DateTime date)
        {
            con = new SqlConnection(source);
            con.Open();
            string delete = "DELETE from openingstock where ItemID = " + itemid + " AND Dated = '" + date + "' ";
            cmd = new SqlCommand(delete, con);
            cmd.ExecuteNonQuery();
            return true;
        }
    }
}