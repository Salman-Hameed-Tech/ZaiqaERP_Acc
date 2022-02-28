using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace DAL
{
    public class ReceivedChllanDAL
    {
        private string source = ReadProjectConfigFile.ConfigString();


        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlTransaction VTran;
        SqlDataReader drPurchase;
        SqlDataReader drPurchaseLine;

       

        SqlDataAdapter da;
        public int CheckExist(int ID)
        {
            try
            {
                int VID = 0;
                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand("select count(*) from ReceivedChallan where ID="+ID+"", con);
                VID = Convert.ToInt32(cmd.ExecuteScalar());
                return VID;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        
        public bool Save(Challan delchalan, bool isNew)
        {
            try
            {

                int VID = delchalan.ID;
                con = new SqlConnection(source);
                con.Open();
               
                cmd =new SqlCommand( "Update Challan set Received= 1, InTransition=0,updatedon=getdate()   where id=" + VID + " ",con);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("exec spRCAccEntries " + VID + " ", con);
                cmd.ExecuteNonQuery();

                con.Close();
                return true;


            }
            catch (Exception ex)
            {
               
                throw;
            }
        }
        //public bool Save(Challan delchalan,bool isNew)
        //{
        //    try
        //    {
        //        int VID = delchalan.ID;
        //        con = new SqlConnection(source);
        //        con.Open();
        //        VTran = con.BeginTransaction();

        //        if (isNew)
        //        {
        //            cmd = new SqlCommand("", con);
        //            cmd.Transaction = VTran;


        //            string insertPurchase = "Insert into ReceivedChallan(ID,Date,UserNo) Values(" + VID+ ",'" + delchalan.FromDate.ToString("yyyy-MM-dd 00:00:00") + "',"+User.UserNo+")";
        //            cmd.CommandText = insertPurchase;
        //            cmd.ExecuteNonQuery();

        //            foreach (Challan pl in delchalan.ChallanLines)
        //            {
        //                cmd.CommandText = SetInsertLine(pl, VID);
        //                cmd.ExecuteNonQuery();

        //                cmd.CommandText = "exec SPInsertRC " + pl.ItemID + ", " + pl.BranchID + ", " + pl.Quantity + " ";
        //                cmd.ExecuteNonQuery();

        //            }
        //        }
        //        else
        //        {
        //            VID = delchalan.ID;
        //            cmd = new SqlCommand("", con);
        //            cmd.Transaction = VTran;
        //            if (con == null)
        //            {
        //                con = new SqlConnection(source);
        //                con.Open();
        //            }
        //            foreach (Challan pl in delchalan.ChallanLines)
        //            {
        //                cmd.CommandText = "Update ReceivedChallanBody set ItemID="+pl.ItemID+ ", Qunatity="+pl.Quantity+ ",BranchID="+pl.BranchID+" where SrNo="+pl.serialno+"";
        //                cmd.ExecuteNonQuery();
        //            }

        //            cmd.CommandText = "Update ReceivedChallan set Date='" + delchalan.FromDate.ToString("yyyy-MM-dd 00:00:00") + "' where ID="+ VID + " ";
        //            cmd.ExecuteNonQuery();


        //        }
        //        cmd.CommandText = "Update Challan set Received= 1, InTransition=0  where id=" + VID + " ";
        //        cmd.ExecuteNonQuery();

        //        VTran.Commit();
        //        con.Close();
        //        return true;

        //    }
        //    catch(Exception ex)
        //    {
        //        VTran.Rollback();
        //        throw;
        //    }
        //}

        private string SetInsertLine(Challan pl, int vID)
        {
            try
            {
                string insertItems = " Insert Into ReceivedChallanBody (RID,ItemID,Quantity,BranchID) values(" + vID + "," + pl.ItemID + ","+pl.Quantity+","+pl.BranchID+")";
                return insertItems;
            }
            catch (Exception ex)
            {
                VTran.Rollback();
                throw;
            }
        }
    }
}
