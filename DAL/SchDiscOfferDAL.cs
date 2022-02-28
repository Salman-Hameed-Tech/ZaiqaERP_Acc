using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Common;

namespace DAL
{
    public class SchDiscOfferDAL
    {
        List<SchDiscOffers> offers;

        string source = ReadProjectConfigFile.ConfigString();
        
        SqlConnection con;
        SqlDataReader dr;
        SqlCommand cmd;

        public List<SchDiscOffers> GetOffers(bool IsCategoryDisc)
        {
            try
            {
                if (offers == null) offers = new List<SchDiscOffers>();
                string select = "";
                con = new SqlConnection(source);
                con.Open();
               
                select = "  Select distinct(OfferID),FromDate,ToDate,isnull(CategoryName,'')as CategoryName,isnull(CompanyName,'')as CompanyName,isnull(Productname,'')as Productname,isnull(Design,'') as Design,isnull(Size,'')as Size,isnull(do.FileNo,0)as  FileNo,IsActive,do.Discount  from discountoffers do  left join ItemCategory IC on IC.CategoryID=do.CategoryID where do.CategoryID is not  null  ";
                
                cmd = new SqlCommand(select, con);

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    offers.Add(new SchDiscOffers(Convert.ToInt32(dr["OfferID"]), Convert.ToDateTime(dr["FromDate"]), Convert.ToDateTime(dr["ToDate"]),Convert.ToDecimal(dr["Discount"]), Convert.ToString(dr["CategoryName"]), Convert.ToString(dr["CompanyName"]), Convert.ToString(dr["ProductName"]), Convert.ToString(dr["Design"]), Convert.ToString(dr["Size"]), Convert.ToBoolean(dr["IsActive"]), Convert.ToInt32(dr["FileNo"])));
                }

                return offers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { con.Close(); }
        }
        public List<SchDiscOffers> GetBarcodeOffers()
        {
            try
            {
                if (offers == null) offers = new List<SchDiscOffers>();
                string select = "";
                con = new SqlConnection(source);
                con.Open();
                select = "   Select distinct(FileNo),FromDate,ToDate,IsActive from discountoffers do  left join ItemCategory IC on IC.CategoryID=do.CategoryID  where do.CategoryID is  null ";
                cmd = new SqlCommand(select, con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    SchDiscOffers d = new SchDiscOffers();
                    d.FileNo = Convert.ToInt32(dr["FileNo"]);
                    d.FromDate = Convert.ToDateTime(dr["FromDate"]);
                    d.ToDate = Convert.ToDateTime(dr["ToDate"]);
                    
                    d.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    offers.Add(d);

                }
                return offers;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { con.Close(); }
        }

        public List<SchDiscOffers> GetDiscDetail(int fileNo)
        {
            try
            {
                if (offers == null) offers = new List<SchDiscOffers>();
                string select = "";
                con = new SqlConnection(source);
                con.Open();
                select = "           Select OfferID,do.ItemName,ToDate,do.Discount,FromDate,ToDate,(select max(Barcode) from ItemBarcodes where itemid=i.ItemID)as Barcode from discountoffers do left join Item i on do.itemname=i.ItemName left join ItemCategory IC on IC.CategoryID=do.CategoryID  where FileNo="+fileNo+" and  do.CategoryID is  null   ";
                cmd = new SqlCommand(select, con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    SchDiscOffers d = new SchDiscOffers();
                    d.OfferID = Convert.ToInt32(dr["OfferID"]);
                    d.ProductName = Convert.ToString(dr["ItemName"]);
                    d.Barcode = Convert.ToString(dr["Barcode"]);
                    d.FromDate = Convert.ToDateTime(dr["FromDate"]);
                    d.ToDate = Convert.ToDateTime(dr["ToDate"]);
                    d.Discount = Convert.ToDecimal(dr["Discount"]);
                 
                    offers.Add(d);

                }
                return offers;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { con.Close(); }
        }
    }
}
