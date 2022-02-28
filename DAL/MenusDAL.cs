using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Common;
using Common.Data_Sets;

namespace DAL
{
    public class MenusDAL
    {
        List<Menus> menus = new List<Menus>();
        private string source = ReadProjectConfigFile.ConfigString();
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlTransaction vtran;
        SqlDataAdapter da = new SqlDataAdapter();
        List<string> names = new List<string>();


        public List<Menus> LoadGrid(int menuid)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                if (menuid > 0)
                {
                    cmd = new SqlCommand("select MenuID,MenuName,M.MCategoryID,mc.MCategoryName,m.Rate,isnull(UrduName,'')as UrduName  from menu m inner join mcategory mc on m.mcategoryid= mc.mcategoryid where m.menuid="+ menuid + "", con);
                    dr = cmd.ExecuteReader();
                }
                else
                {
                    cmd = new SqlCommand("select MenuID,MenuName,M.MCategoryID,mc.MCategoryName,m.Rate,isnull(UrduName,'')as UrduName  from menu m inner join mcategory mc on m.mcategoryid= mc.mcategoryid", con);
                    dr = cmd.ExecuteReader();
                }
                List<Menus> lstitem = new List<Menus>();
                while (dr.Read())
                {
                    Menus obj = new Menus();
                    obj.MenuID = Convert.ToInt32(dr["MenuID"]);
                    obj.MCategoryID = Convert.ToInt32(dr["MCategoryID"]);
                    obj.MCategoryName = Convert.ToString(dr["MCategoryName"]);
                    obj.MenuName = Convert.ToString(dr["MenuName"]);
                    obj.UrduName = Convert.ToString(dr["UrduName"]);
                    obj.Rate = Convert.ToDecimal(dr["Rate"]);

                    lstitem.Add(obj);
                }
                return lstitem;


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            { con.Close(); dr.Close(); }


        }

        public List<Item> LoadItems()
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
              
                cmd = new SqlCommand(" select ItemID,ItemName,ic.CategoryName from Item i left join ItemCategory ic on i.CategoryID=ic.CategoryID where i.ismarinated=0 and i.IsBakery=0 and isactive=1 ", con);
                dr = cmd.ExecuteReader();
                
                List<Item> lstitem = new List<Item>();
                while (dr.Read())
                {
                    Item obj = new Item();
                    obj.ItemID = Convert.ToInt32(dr["ItemID"]);
                    obj.Itemname = Convert.ToString(dr["ItemName"]);
                    obj.CategoryName = Convert.ToString(dr["CategoryName"]);
                 
                    lstitem.Add(obj);
                }
                return lstitem;


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            { con.Close(); dr.Close(); }

        }

        public Boolean SaveMenu(Menus menu)
        {
            try
            {
                int VID = 0;
                con = new SqlConnection(source);
                con.Open();

                vtran = con.BeginTransaction();
                cmd = new SqlCommand("Delete from MenuReceipe where MenuID = " + menu.MenuID, con);
                cmd.Transaction = vtran;
                cmd.ExecuteNonQuery();

                foreach (MenuReceipe m in menu.menuReceipe)
                {
                    cmd.CommandText = "INSERT INTO MenuReceipe(MenuID,ItemID,Qty,Divisor) VALUES (" + menu.MenuID + "," + m.ItemID + "," + m.Qty + ",'" + m.Divisor + "')";
                    cmd.Transaction = vtran;
                    cmd.ExecuteNonQuery();
                }

                vtran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                vtran.Rollback();
                throw ex;
            }
            finally
            { con.Close(); }
        }

     

      

        public bool CheckExistMenuID(int menuid)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();            

                cmd = new SqlCommand("  select * from Menu where menuid="+ menuid + " ", con);
                bool result = Convert.ToBoolean(cmd.ExecuteScalar());
                return result;
            }
            catch (Exception)
            {
                return false;
                throw;

            }
            finally { con.Close(); }
        }

        public bool CheckMenuID(int v, int menuid)
        {
            throw new NotImplementedException();
        }

        public bool Save(Menus menu, bool isNew, int prevMenuId)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
           
                if (isNew)
                {
                    
                    cmd = new SqlCommand("insert into Menu (MenuID,MCategoryID,MenuName,Unit,Rate,UserNo,urduname) values(" + menu.MenuID + "," + menu.MCategoryID + ",'" + menu.MenuName + "', 1 , "+ menu .Rate+ ","+User.UserNo+",N'"+ menu .UrduName+ "' )", con);
                    cmd.ExecuteNonQuery();

                    return true;
                }
                else
                {               
                    cmd = new SqlCommand("Update Menu set MenuID="+ menu.MenuID + ",MCategoryID=" + menu.MCategoryID + ",MenuName='" + menu.MenuName + "',Rate=" + menu.Rate + ", UserNo=" + User.UserNo + ",urduname=N'" + menu.UrduName + "'   where MenuID=" + prevMenuId + " ", con);
                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
            catch (Exception)
            {

                throw;
                return false;
            }
            finally { con.Close(); }
        }

        public string GetMaxID()
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                int VID = 0;

                cmd = new SqlCommand("select IsNull(Max(MenuID),0) +1 from Menu ", con);
                VID = Convert.ToInt32(cmd.ExecuteScalar());

                return VID.ToString();
            }
            catch (Exception)
            {

                throw;
            }
            finally { con.Close(); }
        }

       

        public List<MenuReceipe> GetMenuReceipe(int menuID)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                List<MenuReceipe> lstReceipe = new List<MenuReceipe>();

                cmd = new SqlCommand("select mr.ItemID,i.ItemName,mr.qty,isnull(divisor,0) as divisor   from MenuReceipe mr inner join item i on mr.itemid = i.ItemID  where mr.MenuID = " + menuID, con);
                dr = cmd.ExecuteReader();
                List<Menus> lstitem = new List<Menus>();
                while (dr.Read())
                {
                    MenuReceipe Objmr = new MenuReceipe(Convert.ToInt16(dr["ItemID"]),Convert.ToString(dr["ItemName"])
                        , Convert.ToDecimal(dr["Qty"]), Convert.ToDecimal(dr["Divisor"]));

                    lstReceipe.Add(Objmr);
                }
                return lstReceipe;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            { con.Close(); dr.Close(); }


        }


        public MenuReceipe VerifyItem(int itemID)
        {
            try
            {
                MenuReceipe mr = new MenuReceipe();
                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand("select ItemID, ItemName from Item  where ItemID = " + itemID + " and ismarinated=0 and IsBakery=0 and isactive=1 ", con);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    mr.ItemID = Convert.ToInt16(dr["ItemID"]);
                    mr.ItemName = Convert.ToString(dr["ItemName"]);

                }
                return mr;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            { con.Close(); dr.Close(); }


        }

        public DataSet PrintMenuRecipe(Menus m)
        {
            con = new SqlConnection(source);
            con.Open();

            //cmd = new SqlCommand("select mr.ItemID, i.ItemName, isnull((select   max(rate)  from purchaseinvoicebody where itemid= i.itemid and pid in (select max(pid) from purchaseinvoicebody where itemid=i.itemid)) ,mr.qty from MenuReceipe mr inner join item i on mr.itemid = i.ItemID  where mr.MenuID =" + m.MenuID + " ", con);
            cmd = new SqlCommand("select  mr.ItemID, i.ItemName, ( case when  isnull((select   max(rate)  from purchaseinvoicebody where itemid= i.ItemID and pid in (select max(pid) from purchaseinvoicebody where itemid=i.ItemID)), 0)>0 then  isnull((select   max(rate)  from purchaseinvoicebody where itemid= i.ItemID and pid in (select max(pid) from purchaseinvoicebody where itemid=i.ItemID)), 0)/isnull(divisor,0) else case when i.purprice>0 then i.purprice/divisor else 0 end  end    ) as purchaseprice, mr.qty from MenuReceipe mr  inner join item i on mr.itemid = i.ItemID  where mr.MenuID =" + m.MenuID + "", con);
            //cmd = new SqlCommand("select mr.ItemID,i.ItemName,mr.qty from MenuReceipe mr inner join item i on mr.itemid = i.ItemID  where mr.MenuID ="+m.MenuID+" ", con);
            
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds);
            con.Close();
            return ds;
        }

        public List<Menus> GetAllMenus()
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                List<Menus> lstReceipe = new List<Menus>();

                cmd = new SqlCommand("select * from menu", con);
                dr = cmd.ExecuteReader();
                List<Menus> lstitem = new List<Menus>();
                while (dr.Read())
                {
                    Menus m = new Menus();
                    m.MenuID = Convert.ToInt32(dr["MenuID"]);
                    m.MenuName = dr["MenuName"].ToString();
                    //m.Rate = dr["Rate"].ToString();
                    lstReceipe.Add(m);
                }
                return lstReceipe;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            { con.Close(); dr.Close(); }
        }





        public List<Categories> getcatg()
        {
            con = new SqlConnection(source);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from MCategory",con);
            dr = cmd.ExecuteReader();
            List<Categories> categlist = new List<Categories>();
            while (dr.Read())
            {
                Categories cat = new Categories();
                cat.ID = Convert.ToInt32(dr["MCategoryID"]);
                cat.CategoryName = dr["MCategoryName"].ToString();
                categlist.Add(cat);
            }
            return categlist;
         
        }
    }
}
