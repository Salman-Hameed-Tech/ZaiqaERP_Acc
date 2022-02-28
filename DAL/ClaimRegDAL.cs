using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;

using Common;

namespace DAL
{
    public class ClaimRegDAL
    {
        private string source = ReadProjectConfigFile.ConfigString();
        SqlConnection con;
        SqlCommand cmd;

        SqlDataAdapter da = new SqlDataAdapter();

        //public bool GetData(ref Common.Data_Sets.DSClaimRegister  ds, string where)
        //{
        //    try
        //    {
        //        con = new SqlConnection(source);
        //        con.Open();

        //        string select;

        //        select = "select SRI.RetID as ClaimID,SRI.RetDate as ClaimDate,IsNull(PartyName,'') as Party,I.ItemID,I.ItemName,Quantity,SRB.SalePrice,SRB.PurPrice,RetAmt as Total,AmtRecieved as Paid,Type,IsNull(Narration,'') as Narration from SaleReturnInvoice SRI inner join SaleReturnBody SRB on SRB.RetID=SRI.RetID Left Outer join Parties P on P.PartyID=SRI.SupplierID inner join Item I on I.ItemID=SRB.ItemId inner join ItemCategory IC on IC.CategoryID=I.CategoryID " + where + " Order By SRI.RetID";

        //        cmd = new SqlCommand(select, con);

        //        da.SelectCommand = cmd;

        //        da.Fill(ds, "ClaimRegister");

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

       
    }
}
