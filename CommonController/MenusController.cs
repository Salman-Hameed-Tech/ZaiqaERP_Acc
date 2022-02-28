using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using Common.Data_Sets;
using DAL;

namespace CommonController
{
    public class MenusController
    {

        public List<Menus> LoadGrid(int menuid)
        {
            return new MenusDAL().LoadGrid(menuid);
        }

        public Boolean SaveMenu(Menus menu)
        {
            return new MenusDAL().SaveMenu(menu);
        }
        public List<MenuReceipe> GetMenuReceipe(int menuID)
        {
            return new MenusDAL().GetMenuReceipe(menuID);
        }
        public MenuReceipe VerifyItem(int itemID)
        {
            return new MenusDAL().VerifyItem(itemID);
        }




        public System.Data.DataSet PrintMenuRecipe(Menus m)
        {
            return new DAL.MenusDAL().PrintMenuRecipe(m);
        }

        public List<Item> LoadItems()
        {
            return new DAL.MenusDAL().LoadItems();
        }

        public List<Menus> GetAllMenus()
        {
            return new DAL.MenusDAL().GetAllMenus();
        }

        public string GetMaxID()
        {
            return new DAL.MenusDAL().GetMaxID();
        }

        //public object LoadGrdCategories()
        //{
        //    
        //}



        public List<Categories> getcatg()
        {
            return new DAL.MenusDAL().getcatg();
        }

        public bool Save(Menus menu, bool isNew, int PrevMenuId)
        {
            return new DAL.MenusDAL().Save(menu, isNew, PrevMenuId);
        }

        public bool CheckExistMenuID(int menuid)
        {
            return new DAL.MenusDAL().CheckExistMenuID( menuid);
        }

       

    

       
    }
}
