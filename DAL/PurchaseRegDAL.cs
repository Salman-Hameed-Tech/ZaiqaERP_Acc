using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using Common;

namespace DAL
{
    public class PurchaseRegDAL
    {
        private string source = ReadProjectConfigFile.ConfigString();
        SqlConnection con;
        SqlCommand cmd;

        SqlDataAdapter da = new SqlDataAdapter();

        //Getting Return Data
        public bool GetReturnData(ref Common.Data_Sets.DSPurchaseReturn ds, string where)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();

                string select;

                select = "  select * from (  select PIn.id as ClaimID,PIn.BranchID,b.BranchName,isnull(pca.PartyName,'')as CourierAccount,isnull(PIn.TrackingID,'')as TrackingID,isnull(pin.IsAdjEnt,0)as IsAdjEnt,PIn.Date as ClaimDate,PIn.supplierid as PartyID, RetAmt as Total,P.PartyName as Party,I.ItemID,ItemName,Pib.Quantity,Pib.PurPrice,0 as SalePrice,PIn.Remarks,0 as CourierAmount from purchasereturnbody PIb    inner join Purchasereturn PIn on PIn.ID=PIb.RID    inner join Parties P on P.PartyID=PIn.SupplierID    inner join Item I on I.ItemID=PIb.ItemId    inner join ItemCategory IC on IC.CategoryID=I.CategoryID     left join Branch b on pin.BranchID=b.ID   left join Parties pca on PIn.CourierAccount=pca.PartyID   )pin   "+where+" 	Order By  ClaimID   ";

                cmd = new SqlCommand(select, con);

                da.SelectCommand = cmd;

                da.Fill(ds, "SPPurchaseReturn");

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool GetData(ref Common.Data_Sets.DSPurchaseInvoice ds, string where)
         {
            try
            {
                con = new SqlConnection(source);
                con.Open();

                cmd = new SqlCommand("  select pin.PurchaseId,c.PartyName,b.BranchName,i.ItemName,pin.PurchaseDate,pin.Discount,pin.TotalAmount,pin.IsAdjEnt,pin.Remarks,u.UserName as CreatedBy ,pb.Itemid,(select max(barcode) from itemBarcodes where itemid=i.itemid)as Barcode,pb.Quantity,pb.PurPrice,pb.SalePrice,pb.DiscAmt,isnull(pin.BillNo,'-')as BillNo  from PurchaseInvoice pin inner join PurchaseInvoiceBody PB on pin.PurchaseId=pb.PurchaseId left join Parties c on pin.VendorID =c.PartyID left join item i on pb.itemid=i.itemid  left join Users u on pin.UserNo=u.UserNo left join branch b on pin.branchid=b.id left join parties p on pin.vendorid=p.partyid left join itemcategory ic on i.categoryid=ic.categoryid "+ where + " ", con);


                da = new SqlDataAdapter(cmd);

                da.Fill(ds, "SPPurchaseInvoice");
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                con.Close();
            }
        }
    }
}
