using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Common;
using Common.Data_Sets;

namespace DAL
{
    public class DiscountOfferDAL
    {
        List<DiscountOffer> offers;
        DiscountOffer offer;
        List<Branch> branches = new List<Branch>();
        List<DiscountOffer> barcode = new List<DiscountOffer>();
        private string source = ReadProjectConfigFile.ConfigString();
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlTransaction vtran;

      

        SqlDataAdapter da;

      
        public bool CheckOffer(DiscountOffer DO,bool isNew)
        {
            try
            {                
                con = new SqlConnection(source);
                con.Open();

                if (isNew == false)
                    return false;
                
                vtran = con.BeginTransaction();                      
                for (int b = 0; b < DO.branchList.Count; b++)
                {                               
                    
                    cmd = new SqlCommand("select IsNull(OfferID,0) as OfferID from DiscountOffers where CategoryID=" + DO.Category.Id + " and isnull(CompanyName,'')='" + DO.Item.ItemName.CompanyName + "' and isnull(ProductName,'')='" + DO.Item.ItemName.ProductName + "' and isnull(Design,'')='" + DO.Item.ItemName.Design + "' and isnull(Size,'')='" + DO.Item.ItemName.Size + "' and FromDate >='" + DO.FromDate.AddDays(-1).ToString("yyyy/MM/dd 00:00:00") + "' and ToDate <='" + DO.ToDate.AddDays(1).ToString("yyyy/MM/dd 00:00:00") + "' and Branchid=" + DO.branchList[b].ID + "  ", con);
                    cmd.Transaction = vtran;
                    int o = Convert.ToInt32(cmd.ExecuteScalar());
                    if (o > 0)
                    {
                        return true;
                    }

                }                          

                vtran.Commit();
                return false;
               
            }
            catch (Exception ex)
            {
                vtran.Rollback();
                throw;
            }
            finally
            {                 
                con.Close(); 
            }

        }
        public bool CheckBarcodeOffer(DiscountOffer DO, bool isNew)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();

               
                vtran = con.BeginTransaction();
                if (DO.barcodeList.Count > 0)
                {
                    for (int b = 0; b < DO.branchList.Count; b++)
                    {
                        cmd = new SqlCommand("select IsNull(OfferID,0) as OfferID from DiscountOffers where  isnull(Itemname,'')='" + DO.barcodeList[b].ItemName + "' and FromDate >='" + DO.FromDate.AddDays(-1).ToString("yyyy/MM/dd 00:00:00") + "' and ToDate <='" + DO.ToDate.AddDays(1).ToString("yyyy/MM/dd 00:00:00") + "' and Branchid=" + DO.branchList[b].ID + " ", con);
                        cmd.Transaction = vtran;
                        int o = Convert.ToInt32(cmd.ExecuteScalar());
                        if (o > 0)
                        {
                            return true;
                        }

                    }
                }
                vtran.Commit();
                return false;

            }
            catch (Exception ex)
            {
                vtran.Rollback();
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public string GetMaxFileNo()
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand("Select isnull(max(FileNo),0) +1 from DiscountOffers  ", con);
                cmd.Transaction = vtran;
                int FileNo = Convert.ToInt32(cmd.ExecuteScalar());
                return FileNo.ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { con.Close(); }
        }

       

        public string GetMaxID()
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();

                cmd = new SqlCommand("Select isnull(max(OfferID),0) +1 from DiscountOffers  ", con);
                cmd.Transaction = vtran;
                int VID = Convert.ToInt32(cmd.ExecuteScalar());
                

                return VID.ToString();
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { con.Close(); }
        }

        public bool GetItemsWithoutDiscount(ref DSItems dSItems, int brnachid)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();             
                cmd = new SqlCommand("select ic.Barcode,i.ItemID,i.ItemName from Item i left join itembarcodes ic on i.ItemID=ic.itemid where ItemName not in (select ItemName from DiscountOffers where CategoryID is null)   and   i.CategoryID not in (select CategoryID from DiscountOffers where ItemName is null) ", con);               
                da = new SqlDataAdapter(cmd);

                da.Fill(dSItems, "SPItems");
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

        public bool SaveBracodeOffer(DiscountOffer DO, bool isNew)
        {
            try
            {
                int VID = 0;
                int FileNo = 0;
                string n = "NULL";
                string insert = "";

                con = new SqlConnection(source);
                con.Open();
                vtran = con.BeginTransaction();

                cmd = new SqlCommand("Select isnull(max(FileNo),0) +1 from DiscountOffers  ", con);
                cmd.Transaction = vtran;
                FileNo = Convert.ToInt32(cmd.ExecuteScalar());

                
               
                cmd = new SqlCommand();
                if (isNew)
                {                                                                       
                    if (DO.barcodeList.Count > 0)
                    {
                        for (int j = 0; j < DO.barcodeList.Count; j++)
                        {
                            cmd = new SqlCommand("Select isnull(max(OfferID),0) +1 from DiscountOffers  ", con);
                            cmd.Transaction = vtran;
                            VID = Convert.ToInt32(cmd.ExecuteScalar());

                            for (int i = 0; i < DO.branchList.Count; i++)
                            {
                                insert = "Insert into DiscountOffers(OfferID,CategoryID,CompanyName,ProductName,ItemName,Design,Size,Discount,IsActive,BranchID,FromDate,ToDate,FileNo) Values(" + VID + "," + n + "," + (DO.Item.ItemName.CompanyName.Trim().Length == 0 ? n : "'" + DO.Item.ItemName.CompanyName + "'") + "," + (DO.Item.ItemName.ProductName.Trim().Length == 0 ? n : "'" + DO.Item.ItemName.ProductName + "'") + ",    " + (DO.barcodeList[j].ItemName.Trim().Length == 0 ? n : "'" + DO.barcodeList[j].ItemName + "'") + "  ," + (DO.Item.ItemName.Design.Trim().Length == 0 ? n : "'" + DO.Item.ItemName.Design + "'") + "," + (DO.Item.ItemName.Size.Trim().Length == 0 ? n : "'" + DO.Item.ItemName.Size + "'") + "," + DO.barcodeList[j].Discount + "," + Convert.ToInt16(DO.IsActive) + "," + DO.branchList[i].ID + ",'" + DO.FromDate.ToString("yyyy/MM/dd 00:00:00") + "','" + DO.ToDate.ToString("yyyy/MM/dd 00:00:00") + "',"+FileNo+")";
                                cmd = new SqlCommand(insert, con);
                                cmd.Transaction = vtran;
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                }
                ////////////////////////////EDIT MODE///////////////////////////////
                else
                {
                   int FID = DO.OfferID;
                    cmd = new SqlCommand("delete from DiscountOffers where   fileno=" + FID, con);
                    cmd.Transaction = vtran;
                    cmd.ExecuteNonQuery();
  
                    if (DO.barcodeList.Count > 0)
                    {
                        for (int j = 0; j < DO.barcodeList.Count; j++)
                        {
                            cmd = new SqlCommand("Select isnull(max(OfferID),0) +1 from DiscountOffers  ", con);
                            cmd.Transaction = vtran;
                            VID = Convert.ToInt32(cmd.ExecuteScalar());
                            for (int i = 0; i < DO.branchList.Count; i++)
                            {
                                insert = "Insert into DiscountOffers(OfferID,CategoryID,CompanyName,ProductName,ItemName,Design,Size,Discount,IsActive,BranchID,FromDate,ToDate,FileNo) Values(" + VID + "," + n + "," + (DO.Item.ItemName.CompanyName.Trim().Length == 0 ? n : "'" + DO.Item.ItemName.CompanyName + "'") + "," + (DO.Item.ItemName.ProductName.Trim().Length == 0 ? n : "'" + DO.Item.ItemName.ProductName + "'") + ",    " + (DO.barcodeList[j].ItemName.Trim().Length == 0 ? n : "'" + DO.barcodeList[j].ItemName + "'") + "  ," + (DO.Item.ItemName.Design.Trim().Length == 0 ? n : "'" + DO.Item.ItemName.Design + "'") + "," + (DO.Item.ItemName.Size.Trim().Length == 0 ? n : "'" + DO.Item.ItemName.Size + "'") + "," + DO.barcodeList[j].Discount + "," + Convert.ToInt16(DO.IsActive) + "," + DO.branchList[i].ID + ",'" + DO.FromDate.ToString("yyyy/MM/dd 00:00:00") + "','" + DO.ToDate.ToString("yyyy/MM/dd 00:00:00") + "',"+FID+")";
                                cmd = new SqlCommand(insert, con);
                                cmd.Transaction = vtran;
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
               
                }

                vtran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                vtran.Rollback();
                throw ex;
            }
            finally { con.Close(); }
        }

        public bool DeleteBarcode(int fileNo)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();

                vtran = con.BeginTransaction();
                cmd = new SqlCommand("Delete from DiscountOffers where FileNo=" + fileNo, con);
                cmd.Transaction = vtran;
                cmd.ExecuteNonQuery();

                vtran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                vtran.Rollback();
                throw ex;
            }
        }

        public int CheckExistedPwd(int Branchid)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand(" select count(*) from DiscountPassword where BranchID="+ Branchid + "", con);
                int count=Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
        public bool GetOffers(ref DSOffers dSOffers,int BranchID,string  FromDate,string ToDate)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                string where = "  where 1=1 and  fromdate>='" + FromDate + "' and todate<='" + ToDate + "' "     ;
               if (BranchID == 0)
               {
                    where = "  where d.IsActive = 1  ";
                    
                    //  cmd = new SqlCommand("  select OfferID,d.BranchID,d.CategoryID,isnull(ic.CategoryName,'-') as CategoryName,isnull(d.CompanyName,'-')as CompanyName, isnull(d.ProductName,'-')as ProductName,isnull(d.ItemName,'-')as ItemName,isnull(d.Design,'-')as Design,Discount, FromDate,ToDate,isnull(d.Size,'-')as Size,b.BranchName, cs.Quantity  from DiscountOffers d  left join ItemCategory ic on d.CategoryID=ic.CategoryID  left join Branch b on d.BranchID=b.ID   left join item i on d.ItemName=i.ItemName left join CurrentStock cs on i.ItemID=cs.ItemID and d.BranchID=cs.BranchID  ", con);
                    //cmd = new SqlCommand(" select OfferID,d.BranchID,d.CategoryID,isnull(ic.CategoryName,'-') as CategoryName,isnull(CompanyName,'-')as CompanyName,isnull(ProductName,'-')as ProductName,isnull(ItemName,'-')as ItemName,isnull(Design,'-')as Design,Discount,FromDate,ToDate,isnull(Size,'-')as Size,b.BranchName, cs.Quantity from DiscountOffers d left join ItemCategory ic on d.CategoryID=ic.CategoryID left join Branch b on d.BranchID=b.ID  left join CurrentStock cs on (select itemid from Item where ItemName=d.ItemName)=cs.ItemID and d.BranchID=cs.BranchID", con);
                }
                else
                {
                    where = "  where d.BranchID=" + BranchID + " and d.IsActive=1  ";
                    //cmd = new SqlCommand(" select OfferID,BranchID,d.CategoryID,isnull(ic.CategoryName,'-') as CategoryName,isnull(CompanyName,'-')as CompanyName,isnull(ProductName,'-')as ProductName,isnull(ItemName,'-')as ItemName,isnull(Design,'-')as Design,Discount,FromDate,ToDate,isnull(Size,'-')as Size,b.BranchName from DiscountOffers d left join ItemCategory ic on d.CategoryID=ic.CategoryID left join Branch b on d.BranchID=b.ID where BranchID=" + BranchID+"  ", con);
                    // cmd = new SqlCommand("   select OfferID,d.BranchID,d.CategoryID, isnull(ic.CategoryName,'-') as CategoryName,isnull(d.CompanyName,'-')as CompanyName, isnull(d.ProductName,'-')as ProductName,isnull(d.ItemName,'-')as ItemName,isnull(d.Design,'-')as Design, Discount,FromDate,ToDate,isnull(d.Size,'-')as Size, b.BranchName, isnull((select itemid from item where ItemName=d.ItemName),0)as ItemID, isnull((select barcode from ItemBarcodes where Itemid=(select itemid from item where ItemName=d.ItemName)),'-')as Barcode,  isnull((select SalePrice from item where ItemName=d.ItemName),0)as SalePrice,  isnull((select PurchasePrice from item where ItemName=d.ItemName),0)as PurchasePrice,cs.Quantity  from DiscountOffers d left join ItemCategory ic on d.CategoryID=ic.CategoryID left join Branch b on d.BranchID=b.ID  left join CurrentStock cs on (select itemid from Item where ItemName=d.ItemName)=cs.ItemID and d.BranchID=cs.BranchID   where d.BranchID=" + BranchID + " order by OfferID  ", con);
                }
                cmd = new SqlCommand("    select OfferID,d.BranchID,d.CategoryID, isnull(ic.CategoryName,'-') as CategoryName,isnull(d.CompanyName,'-')as CompanyName,   isnull(d.ProductName,'-')as ProductName,isnull(d.ItemName,'-')as ItemName,isnull(d.Design,'-')as Design,   Discount,FromDate,ToDate,isnull(d.Size,'-')as Size, b.BranchName,i.ItemID,  isnull((select max(barcode) from ItemBarcodes where Itemid=i.ItemID),'-')as Barcode,   isnull(SalePrice,0)as SalePrice,  isnull(PurchasePrice,0)as PurchasePrice,isnull(cs.Quantity,0)as  Quantity  ,(select accountname from  chartofaccounts where accountno=i.partyid) as vendor  from DiscountOffers d left join Branch b on d.BranchID=b.ID left join item i on d.ItemName=i.ItemName left join ItemCategory ic on i.CategoryID=ic.CategoryID   left join CurrentStock cs on i.ItemID=cs.ItemID and d.BranchID=cs.BranchID    " + where + "    order by OfferID     ", con);

                da = new SqlDataAdapter(cmd);

                da.Fill(dSOffers, "SPOffers");
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

        public bool SavePassword(DiscountPassword common,bool IsNew)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                if (IsNew)
                {
                    cmd = new SqlCommand(" Insert DiscountPassword  (BranchID,Password) values("+common.BranchID+",'"+common.Password+"')", con);

                }
                else
                {
                    cmd = new SqlCommand(" Update DiscountPassword Set Password ='" + common.Password + "' where Branchid=" + common.BranchID + " ", con);

                }
                cmd.ExecuteNonQuery();
               
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

         public List<Branch> GetOfferBranches(int OfferID,bool isBarcodeDisc)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                string selectLine = "";
                if (isBarcodeDisc)
                {
                    selectLine = "   select ID,BranchName,sum(selected)as Selected  from  ( select ID,BranchName,0 as selected from Branch union all select d.BranchID,b.BranchName,1  from DiscountOffers d inner join Branch b on d.BranchID=b.ID where FileNo=" + OfferID + "  )tb group by ID,BranchName ";
                }
                else
                {
                    selectLine = "   select ID,BranchName,sum(selected)as Selected  from  ( select ID,BranchName,0 as selected from Branch union all select d.BranchID,b.BranchName,1  from DiscountOffers d inner join Branch b on d.BranchID=b.ID where OfferID=" + OfferID + "  )tb group by ID,BranchName ";

                }
                SqlCommand cmd = new SqlCommand(selectLine, con);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Branch b = new Branch();
                    b.ID = Convert.ToInt32(dr["ID"]);
                    b.BranchName = dr["BranchName"].ToString();
                    b.Select = Convert.ToBoolean(dr["Selected"]);
                    branches.Add(b);
                }
                dr.Close();

                return branches;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool SaveOffer(DiscountOffer DO,bool isNew)
        {
            try
            {
                int VID = 0;
                string n = "NULL";
                string insert = "";

                con = new SqlConnection(source);
                con.Open();

                vtran = con.BeginTransaction();
                cmd = new SqlCommand();
                if (isNew)
                {
                    cmd = new SqlCommand("Select isnull(max(OfferID),0) +1 from DiscountOffers  ", con);
                    cmd.Transaction = vtran;
                    VID = Convert.ToInt32(cmd.ExecuteScalar());

                    for (int i = 0; i < DO.branchList.Count; i++)
                    {                                                       
                        insert = "Insert into DiscountOffers(OfferID,CategoryID,CompanyName,ProductName,ItemName,Design,Size,Discount,IsActive,BranchID,FromDate,ToDate) Values(" + VID + "," + DO.Category.Id + "," + (DO.Item.ItemName.CompanyName.Trim().Length == 0 ? n : "'" + DO.Item.ItemName.CompanyName + "'") + "," + (DO.Item.ItemName.ProductName.Trim().Length == 0 ? n : "'" + DO.Item.ItemName.ProductName + "'") + "," + n + "," + (DO.Item.ItemName.Design.Trim().Length == 0 ? n : "'" + DO.Item.ItemName.Design + "'") + "," + (DO.Item.ItemName.Size.Trim().Length == 0 ? n : "'" + DO.Item.ItemName.Size + "'") + "," + DO.Discount + "," + Convert.ToInt16(DO.IsActive) + "," + DO.branchList[i].ID + ",'" + DO.FromDate.ToString("yyyy/MM/dd 00:00:00") + "','" + DO.ToDate.ToString("yyyy/MM/dd 00:00:00") + "')";
                        cmd = new SqlCommand(insert, con);
                        cmd.Transaction = vtran;
                        cmd.ExecuteNonQuery();
                   }
                } 
                ////////////////////////////EDIT MODE///////////////////////////////
                else
                {
                    VID = DO.OfferID;
                    cmd = new SqlCommand("delete from DiscountOffers where   OfferID=" + VID, con);
                    cmd.Transaction = vtran;
                    cmd.ExecuteNonQuery();

                    for (int i = 0; i < DO.branchList.Count; i++)
                    {
      
                        insert = "Insert into DiscountOffers(OfferID,CategoryID,CompanyName,ProductName,ItemName,Design,Size,Discount,IsActive,BranchID,FromDate,ToDate) Values(" + VID + "," + DO.Category.Id + "," + (DO.Item.ItemName.CompanyName.Trim().Length == 0 ? n : "'" + DO.Item.ItemName.CompanyName + "'") + "," + (DO.Item.ItemName.ProductName.Trim().Length == 0 ? n : "'" + DO.Item.ItemName.ProductName + "'") + "," + n + "," + (DO.Item.ItemName.Design.Trim().Length == 0 ? n : "'" + DO.Item.ItemName.Design + "'") + "," + (DO.Item.ItemName.Size.Trim().Length == 0 ? n : "'" + DO.Item.ItemName.Size + "'") + "," + DO.Discount + "," + Convert.ToInt16(DO.IsActive) + "," + DO.branchList[i].ID + ",'" + DO.FromDate.ToString("yyyy/MM/dd 00:00:00") + "','" + DO.ToDate.ToString("yyyy/MM/dd 00:00:00") + "')";
                        cmd = new SqlCommand(insert, con);
                        cmd.Transaction = vtran;
                        cmd.ExecuteNonQuery();
   
                    }
                }

            
                vtran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                vtran.Rollback();
                throw ex;
            }
            finally { con.Close(); }
        }

        public DiscountOffer GetOfferDetail(int OfferID)
        {
            try
            {               
                con = new SqlConnection(source);
                con.Open();
                AddBranhes(OfferID,false);
                AddBarcodes(OfferID);
              
                string select = "select OfferID,isnull(CategoryID,0)as CategoryID,CompanyName,ProductName,Design,Size,Discount,IsActive,'' as Color, isnull(fromdate,'')as FromDate,isnull(todate,'')as ToDate from DiscountOffers where OfferID=" + OfferID;
                cmd = new SqlCommand(select, con);
                

                dr = cmd.ExecuteReader();

                Common.Item it;
                Category c;
                List<DiscountOffer> itemlst = new List<DiscountOffer>();

                while (dr.Read())
                {
                    it= new Item(0, new ItemName(Convert.ToString(dr["CompanyName"]), Convert.ToString(dr["ProductName"]), Convert.ToString(dr["Design"]), Convert.ToString(dr["Size"])));

                    c = new Category(Convert.ToInt32(dr["CategoryID"]), "");
                    
                    offer = new DiscountOffer(Convert.ToInt32(dr["OfferID"]),c,it,Convert.ToDecimal(dr["Discount"]),Convert.ToBoolean(dr["IsActive"]),Convert.ToDateTime(dr["FromDate"]), Convert.ToDateTime(dr["ToDate"]),branches, barcode);
                  
                }

                return offer;
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }


        public List<DiscountOffer> GetBarcodeItems(int OfferID, bool isCategoryDisc)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                AddBranhes(OfferID, isCategoryDisc);
                AddBarcodes(OfferID);
                if (isCategoryDisc)
                {
                    string select = "select OfferID,isnull(CategoryID,0)as CategoryID,CompanyName,ProductName,Design,Size,Discount,IsActive,'' as Color, isnull(fromdate,'')as FromDate,isnull(todate,'')as ToDate from DiscountOffers where OfferID=" + OfferID;
                    cmd = new SqlCommand(select, con);
                }
                else
                {
                    string select = "select OfferID,isnull(CategoryID,0)as CategoryID,CompanyName,ProductName,Design,Size,Discount,IsActive,'' as Color, isnull(fromdate,'')as FromDate,isnull(todate,'')as ToDate,FileNo from DiscountOffers where CategoryID is null and FileNo=" + OfferID;
                    cmd = new SqlCommand(select, con);
                }

                dr = cmd.ExecuteReader();

                Common.Item it;
                Category c;
                List<DiscountOffer> itemlst = new List<DiscountOffer>();

                while (dr.Read())
                {
                    it = new Item(0, new ItemName(Convert.ToString(dr["CompanyName"]), Convert.ToString(dr["ProductName"]), Convert.ToString(dr["Design"]), Convert.ToString(dr["Size"])));

                    c = new Category(Convert.ToInt32(dr["CategoryID"]), "");

                    offer = new DiscountOffer(Convert.ToInt32(dr["OfferID"]), c, it, Convert.ToDecimal(dr["Discount"]), Convert.ToBoolean(dr["IsActive"]), Convert.ToDateTime(dr["FromDate"]), Convert.ToDateTime(dr["ToDate"]), branches, barcode);
                    itemlst.Add(offer);
                }

                return itemlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<DiscountOffer> AddBarcodes(int offerID)
        {
            try
            {
                string selectLine="select distinct(d.ItemName),d.Discount,ibc.Barcode from DiscountOffers d inner join Branch b on d.BranchID=b.ID left join Item i on d.ItemName=i.ItemName left join ItemBarcodes ibc on i.ItemID=ibc.itemid where d.fileno =" + offerID + "  ";
              //  string selectLine = "  select d.ItemName from DiscountOffers d inner join Branch b on d.BranchID=b.ID where d.OfferID=" + offerID + "  ";
                SqlCommand cmd = new SqlCommand(selectLine, con);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    DiscountOffer b = new DiscountOffer();
                    b.ItemName = Convert.ToString(dr["ItemName"]);
                    b.Barcode = Convert.ToString(dr["Barcode"]);
                    b.Discount = Convert.ToDecimal(dr["Discount"]);

                    barcode.Add(b);
                }
                dr.Close();

                return barcode;
            }
            catch
            {
                throw;
            }
        }

        private List<Branch> AddBranhes(int offerID, bool isCategoryDisc)
        {
            try
            {
                string selectLine = "";
                if (isCategoryDisc)
                {
                    // selectLine = "  select d.BranchID,b.BranchName from DiscountOffers d inner join Branch b on d.BranchID=b.ID where d.OfferID=" + offerID + "  ";
                    selectLine = "   select ID,BranchName,sum(selected)as Selected  from  ( select ID,BranchName,0 as selected from Branch union all select d.BranchID,b.BranchName,1  from DiscountOffers d inner join Branch b on d.BranchID=b.ID where OfferID=" + offerID + "  )tb group by ID,BranchName ";

                }
                else
                {
                     selectLine = "   select ID,BranchName,sum(selected)as Selected  from  ( select ID,BranchName,0 as selected from Branch union all select d.BranchID,b.BranchName,1  from DiscountOffers d inner join Branch b on d.BranchID=b.ID where FileNo=" + offerID + "  )tb group by ID,BranchName ";

                }
                SqlCommand cmd = new SqlCommand(selectLine, con);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Branch b = new Branch();
                    b.ID = Convert.ToInt32(dr["ID"]);
                    b.BranchName = dr["BranchName"].ToString();
                    b.Select = Convert.ToBoolean(dr["Selected"]);
                    branches.Add(b);
                }
                dr.Close();

                return branches;
            }
            catch
            {
                throw;
            }
        }

        public bool DeleteOffer(int OfferID)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();

                vtran = con.BeginTransaction();
                cmd = new SqlCommand("Delete from DiscountOffers where OfferID="+OfferID,con);
                cmd.Transaction = vtran;
                cmd.ExecuteNonQuery();

                vtran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                vtran.Rollback();
                throw ex;
            }
        }
    }
}
