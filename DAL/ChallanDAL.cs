using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Common;

namespace DAL
{
    public class ChallanDAL
    {
        List<Challan> challan = new List<Challan>();
        private string source = ReadProjectConfigFile.ConfigString();


        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlTransaction VTran;
        SqlDataReader drPurchase;
        SqlDataReader drPurchaseLine;
        SqlDataAdapter da;


       

        public int SaveOrder(Challan c, bool Isnew)
        {
            try
            {
                int VID = 0;
                con = new SqlConnection(source);
                con.Open();
                VTran = con.BeginTransaction();

                if (Isnew)
                {
                    cmd = new SqlCommand("Select IsNull(Max(ID),0) +1 as ID From Challan", con);
                    cmd.Transaction = VTran;
                    VID = Convert.ToInt32(cmd.ExecuteScalar());


                    string insert = "if exists(select * from Challan where ID=" + VID + ")Begin Update Challan set ID=" + VID + ",Date = '" + c.FromDate.Date.ToString("yyyy-MM-dd 00:00:00") + "',CreatedBy=" + User.UserNo + ",CreatedDate= GetDATE(),Received="+ Convert.ToInt16(c.IsReceived)+ ",InTransition=" + Convert.ToInt16(c.IsTarnsition)+",EntryBranchID="+c.EntryBranchID+",BranchID="+c.BranchID+",UserNo="+User.UserNo+",Remarks='"+c.Remarks+"'  WHERE ID=" + VID + " End Else Begin Insert into Challan(ID,Date,CreatedBy,CreatedDate,Received,InTransition,EntryBranchID,BranchID,UserNo,Remarks) Values(" + VID + ",'" + c.FromDate.Date.ToString("yyyy-MM-dd 00:00:00") + "'," + User.UserNo + ",GetDate(),"+Convert.ToInt16(c.IsReceived)+","+Convert.ToInt16(c.IsTarnsition)+","+c.EntryBranchID+","+c.BranchID+","+User.UserNo+",'"+c.Remarks+"')End";
                    cmd = new SqlCommand(insert, con);
                    cmd.Transaction = VTran;
                    cmd.ExecuteNonQuery();

                    foreach (Common.Challan p in c.ChallanLines)
                    {
                        {

                            cmd.CommandText = SetPurInsertLine(p, VID);                         
                            cmd.ExecuteNonQuery();

                           

                        }
                    }
                }
                else
                {
                    VID = c.ID;
                  

                    cmd = new SqlCommand("Select * from Challan Where ID=" + VID, con);
                    cmd.Transaction = VTran;
                    int i = (int)cmd.ExecuteScalar();

                    foreach (Challan line in c.ChallanLines)
                    {
                        if (!line.IsDeleted && line.serialno != 0)
                        {
                            
                            cmd.CommandText = "Update ChallanBody Set ItemID = " + line.ItemID + ",Quantity = " + line.Quantity + " ,ItemName = '" + line.ItemName + "',Purrate="+line.Purate+",cost="+line.Cost+"  where SrNo = " + line.serialno;
                            cmd.ExecuteNonQuery();

                            


                        }
                        else if (!line.IsDeleted && line.serialno == 0)
                        {
                            cmd.CommandText = (SetPurInsertLine(line, c.ID));
                            cmd.ExecuteNonQuery();

                            cmd.CommandText = "exec SPInsertDC " + line.ItemID + ", " + line.EntryBranchID + ", " + line.Quantity + ", " + line.Purate + " ";
                            cmd.ExecuteNonQuery();

                        }
                        else
                        {
                         

                            cmd.CommandText = "Delete from challanbody where SrNo = " + line.serialno;
                            cmd.ExecuteNonQuery();

                          
                        }
                       

                    }


                    string insert = "if exists(select * from Challan where ID=" + VID + ")Begin Update Challan set ID=" + VID + ",Date = '" + c.FromDate.Date.ToString("yyyy-MM-dd 00:00:00") + "',updatedBy=" + User.UserNo + ",UpdatedOn= GetDATE(),Received=" + Convert.ToInt16(c.IsReceived) + ",InTransition=" + Convert.ToInt16(c.IsTarnsition) + ",EntryBranchID=" + c.EntryBranchID + ",BranchID=" + c.BranchID + ",UserNo=" + User.UserNo + ",Remarks='" + c.Remarks + "'  WHERE ID=" + VID + " End Else Begin Insert into Challan(ID,Date,CreatedBy,CreatedDate,Received,InTransition,UserNo,Remarks) Values(" + VID + ",'" + c.FromDate.Date.ToString("yyyy-MM-dd 00:00:00") + "'," + User.UserNo + ",GetDate()," + Convert.ToInt16(c.IsReceived) + "," + Convert.ToInt16(c.IsTarnsition) + ","+User.UserNo+",'"+c.Remarks+ "')End";

                    cmd = new SqlCommand(insert, con);
                    cmd.Transaction = VTran;
                    cmd.ExecuteNonQuery();


                    
                }
                cmd = new SqlCommand ("exec SpDCAccEntries " + VID , con);
                cmd.Transaction = VTran;
                cmd.ExecuteNonQuery();
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

     

    

        public bool UpdateRecord(int id)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();

                cmd = new SqlCommand("Update Challan set Received= 1 where id=" + id + " ", con);
                cmd.Transaction = VTran;
                cmd.ExecuteNonQuery();

                return true;
            }
            catch
            {
                VTran.Rollback();
                throw;
            }
            finally
            {
                //  conn.Close();
            }
        }


        public bool GetChallanData(ref Common.Data_Sets.DsChallan dsChallan,int invID,string where, int branchID)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
               
                if (invID != 0)
                {
                    cmd = new SqlCommand(" Select case when c.Received=1 then 'Received' else 'Not Received' end as ChallanStatus, cB.cid as ChallanNo,C.Date,b.BranchName,CB.ItemID,ic.CategoryName,bc.Barcode, CB.ItemName as ProductDetail,cb.Quantity,isnull(cb.purrate,0) as Rate,isnull(cb.cost,0)as Cost,isnull(c.Remarks,'')as Remarks,(select BranchName from Branch where ID=c.BranchID)as ReceiverBranch    from Challan c  INNER JOIN CHALLANBODY CB ON CB.CID= C.ID    left join branch b on c.EntryBranchid=b.id left join item i on i.itemid=cb.itemid left join ItemBarcodes bc on i.ItemID=bc.itemid left join ItemCategory ic on i.CategoryID=ic.CategoryID    where cb.cid=" + invID + "  ", con);
                }
                else if (invID == 0)
                {
                    cmd = new SqlCommand(" Select case when c.Received=1 then 'Received' else 'Not Received' end as ChallanStatus, cB.cid as ChallanNo,C.Date,b.BranchName,CB.ItemID,ic.CategoryName,bc.Barcode, CB.ItemName as ProductDetail,cb.Quantity,isnull(cb.purrate,0) as Rate,isnull(cb.cost,0)as Cost,isnull(c.Remarks,'')as Remarks,(select BranchName from Branch where ID=c.BranchID)as ReceiverBranch   from Challan c  INNER JOIN CHALLANBODY CB ON CB.CID= C.ID    left join branch b on c.EntryBranchid=b.id  left join item i on i.itemid=cb.itemid left join ItemBarcodes bc on i.ItemID=bc.itemid left join ItemCategory ic on i.CategoryID=ic.CategoryID " + where + "  and bc.SrNo=(select MAX(SrNo) from ItemBarcodes where itemid=i.ItemID)   order by ChallanNo ", con);

                }
               
                da = new SqlDataAdapter(cmd);
               
                da.Fill(dsChallan, "DsChallan");
                return true;
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
        public int GetMaximumID()
        {

            int VID = 0;

            con = new SqlConnection(source);
            con.Open();

            cmd = new SqlCommand("Select IsNull(Max(ID),0) +1 From Challan", con);
            VID = Convert.ToInt32(cmd.ExecuteScalar());

            return VID;
        }
        public List<Challan> GetData(int id, string where)
        {
            con = new SqlConnection(source);
            con.Open();
            challan = new List<Challan>();
            try
            {

                where = " Where Received=0  ";
                if (id > 0)
                {
                    where = "  and  ID = " + id;
                }
                string select = "   Select c.ID,c.Date,b1.BranchName as Sender,b2.BranchName as Receiver, u.UserName  from Challan c left join Branch b1 on c.EntryBranchID=b1.ID left join Branch b2 on c.BranchID=b2.ID left join Users u on c.UserNo=u.UserNo   " + where + " ORDER BY c.ID";
                cmd = new SqlCommand(select, con);
                SqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    Challan o = new Challan();

                    o.ID = (int)read["ID"];
                    o.FromDate = Convert.ToDateTime(read["Date"]);
                    o.ReceiverBranch= Convert.ToString(read["Receiver"]);
                    o.BranchName = Convert.ToString(read["Sender"]);
                    o.Username= Convert.ToString(read["UserName"]);
                  


                    challan.Add(o);
                }
                read.Close();

                con.Close();
                return challan;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Challan> GetRecivedData(int Brnachid)
        {
            con = new SqlConnection(source);
            con.Open();
            challan = new List<Challan>();
            try
            {
                string where = "";
             

                if ( Brnachid > 0 )
                {
                  //  where = " Where c.BranchID = " + Brnachid + " and c.CounterID = " + Counterid + " and Received=0";
                    where = " Where  Received=0 and c.BranchID="+ Brnachid + "";
                }
                //string select = "Select * from Challan c   " + where + " ORDER BY c.ID";
                string select = " Select distinct(C.ID),c.Date,b.BranchName,u.UserName   from Challan c  inner join challanbody cb on c.ID = cb.CID   left join Branch b on c.EntryBranchID=b.ID  left join Users u on c.UserNo=u.UserNo  " + where + "   ORDER BY c.ID";
                     cmd = new SqlCommand(select, con);
                SqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    Challan o = new Challan();

                    o.ID = (int)read["ID"];
                    o.FromDate = Convert.ToDateTime(read["Date"]);
                    o.BranchName = read["BranchName"].ToString();
                    o.Username = read["UserName"].ToString();
                  


                    challan.Add(o);
                }
                read.Close();

                con.Close();
                return challan;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Challan> GetChalan(int id)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                cmd= new SqlCommand("select c.ID,c.Date,c.BranchID,c.EntryBranchID,c.Remarks,cb.ItemID,ibc.barcode,cb.ItemName,cb.Quantity,isnull(cb.Cost,0) as Cost,isnull(cb.purRate,0)as PurRate,(select sum(quantity) from tblfifo where itemid=cb.itemid and branchid=1)as Stock, cb.Srno from challan c inner join challanbody cb on c.ID=cb.CID left join itembarcodes ibc on cb.itemid=ibc.itemid where c.ID=" + id+" ", con);
                dr = cmd.ExecuteReader();
                List<Challan> lstmn = new List<Challan>();
                while (dr.Read())
                {
                    Common.Challan objorder = new Challan();
                    objorder.ID = Convert.ToInt32(dr["ID"]);
                    objorder.FromDate = Convert.ToDateTime(dr["Date"]);
                    objorder.ItemID = Convert.ToInt32(dr["ItemID"]);
                    objorder.Barcode = dr["barcode"].ToString();
                    objorder.BranchID = Convert.ToInt32(dr["BranchID"]);
                    objorder.EntryBranchID = Convert.ToInt32(dr["EntryBranchID"]);
                    objorder.ItemName = dr["ItemName"] == DBNull.Value ? "" : dr["ItemName"].ToString();               
                    objorder.Quantity = dr["Quantity"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["Quantity"]);
                    objorder.stock = dr["Stock"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["Stock"]);
                    objorder.Cost = dr["Cost"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["Cost"]);
                    objorder.Purate = dr["PurRate"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["PurRate"]);
                    objorder.serialno = Convert.ToInt32(dr["Srno"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Srno"]));                
                    objorder.Remarks = dr["Remarks"].ToString();
                           
                    lstmn.Add(objorder);

                }
                return lstmn;
            }
            catch (Exception ex)
            {

                throw;
            }
            finally { con.Close(); dr.Close(); }
        }

        public bool DeletePurchase(int VID)
        {
            try
            {
                if (con == null)
                {
                    con = new SqlConnection(source);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                }
                VTran = con.BeginTransaction();

                cmd = new SqlCommand("Select * from Challan Where ID=" + VID, con);
                cmd.Transaction = VTran;
                int i = (int)cmd.ExecuteScalar();

                if (i > 0)
                {
                    SqlDataAdapter Da = new SqlDataAdapter("select itemid,srno from ChallanBody where CID=" + VID, con);
                    DataSet ds = new DataSet();
                    Da.SelectCommand.Transaction = VTran;
                    Da.Fill(ds);
                    //foreach (PurchaseLine pl in purchase.PurchaseLines)
                    ///for ( i = 0; i < ds.Tables [0].Rows.Count -1; i++)
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        cmd.CommandText = "Delete from ChallanBody where SrNo=" + Convert.ToInt32(item["srno"]);
                        cmd.ExecuteNonQuery();
                    }
                    cmd.CommandText = "Delete from Challan where ID=" + VID;
                    cmd.ExecuteNonQuery();
                }

             

                VTran.Commit();
                return true;
            }
            catch
            {
                VTran.Rollback();
                throw;
            }
        }

        private string SetPurInsertLine(Challan p, int OID)
        {
            try
            {
                string insertItems = "Insert Into ChallanBody(CID,ItemID,ItemName,Quantity,Purrate,cost ) Values(" + OID + "," + p.ItemID + ",'" + p.ItemName + "'," + p.Quantity + "," + p.Purate + "," + p.Cost  + ")";
                return insertItems;
            }
            catch
            {
                VTran.Rollback();
                throw;
            }
        }
    }
}
