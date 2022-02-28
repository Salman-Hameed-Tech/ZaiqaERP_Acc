using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using System.Data.SqlClient ;

namespace DAL
{
    public class SchItemsDAL
    {
        string source = ReadProjectConfigFile.ConfigString();
        List <SchItems > lstItems=new List<SchItems> ();
        SqlConnection  cn;
        SqlDataReader dr;
        SqlCommand cmd;
        public void UpdateItem(Int32 itemid, Boolean act)
        {
            cn = new SqlConnection(source);
            cn.Open();
            SqlTransaction vtran;
            vtran = cn.BeginTransaction();
            cmd = new SqlCommand("Alter Table Item Disable Trigger GenerateBarcodeUpdate", cn);
            cmd.Transaction = vtran;
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("Update item set isactive=" + (act==true?(int)1:(int) 0) + " where itemid=" + itemid, cn);
            cmd.Transaction = vtran;
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("Alter Table Item enable Trigger GenerateBarcodeUpdate", cn);
            cmd.Transaction = vtran;
            cmd.ExecuteNonQuery();
            vtran.Commit();
        }
        public List<SchItems > LoadGrid(string isFinished, string condition)
        {
            try 
            {	        
                cn=new SqlConnection (source);
                cn.Open();
               
                
               cmd = new SqlCommand("select i.itemid,ic.Barcode,categoryname,companyname,productname,design,size,isactive,isnull(ismarinated,0) as ismarinated,isnull(isbakery,0) as isbakery  from item i inner join itemcategory on i.categoryid=itemcategory.categoryid" + isFinished + "   left join ItemBarcodes ic on i.ItemID=ic.itemid where  ic.SrNo=(select MAX(SrNo) from ItemBarcodes where itemid=i.ItemID) "+condition+"    ", cn);

               
               
                dr = cmd.ExecuteReader ();
                List<SchItems> lstitem = new List<SchItems>();
                while (dr.Read() )
                {
                    
                    SchItems Objitem=new SchItems (Convert.ToInt32  (dr["itemid"]),(string) dr["categoryname"],(string) dr["companyname"],(string)dr["productname"],(string) dr["design"],(string) dr["size"],(Boolean ) dr["isactive"], (string)dr["Barcode"], (bool)dr["ismarinated"], (bool)dr["isbakery"]);
                    
                    lstitem.Add (Objitem );
                }
                return lstitem ;

                
            }
	        catch (Exception)
	        {	
                throw;
            }
            finally 
            {  cn.Close (); }        
         }

        public List<SchItems> LoadGrid()
        {
            try
            {
                cn = new SqlConnection(source);
                cn.Open();
                cmd = new SqlCommand("select itemid,categoryname,companyname,productname,design,size,isactive,isnull(ismarinated,0)as ismarinated,isnull(isbakery,0) as isbakery from item inner join itemcategory on item.categoryid=itemcategory.categoryid", cn);
                dr = cmd.ExecuteReader();
                List<SchItems> lstitem = new List<SchItems>();
                while (dr.Read())
                {
                    SchItems Objitem = new SchItems(Convert.ToInt32(dr["itemid"]), (string)dr["categoryname"], (string)dr["companyname"], (string)dr["productname"], (string)dr["design"], (string)dr["size"], (Boolean)dr["isactive"],"",(bool)dr["ismarinated"],(bool)dr["isbakery"]);
                    lstitem.Add(Objitem);
                }
                return lstitem;


            }
            catch (Exception)
            {
                throw;
            }
            finally
            { cn.Close(); }
        }
    }
}
