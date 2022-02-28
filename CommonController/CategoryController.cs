using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Common;
using DAL;

namespace CategoryControlle
{
    public class CategoryController
    {
        private List<Category> categories;
        private CategoryDAL cDal = new CategoryDAL();

        public List<Category> GetCategories(int n)
        {
            if (categories == null) categories = new List<Category>();

            //todo from database 
            categories=cDal.GetCategories();                         
            return categories;
        }
        public Category GetSingleCategories(int ID)
        {
            return new DAL.CategoryDAL().GetSingleCategories(ID);
        }
        public List<Category> GetCategories()
        {
            if (categories == null) categories = new List<Category>();

            //todo from database 
            categories = cDal.GetCategories();
            return categories;
        }
        public Int32 GetMaxID()
        {
            return new CategoryDAL().GetMaxID();
        }

        public Boolean  SaveCategory(Category c,bool IsNew)
        {
        
            if (cDal.SaveCategory(c,IsNew))
                return true ;
            else
                return false ;
        }

        public Boolean DeleteCategory(Category c)
        {

            if (cDal.DeleteCategory (c))
                return true;
            else
                return false;
        }

        public DataSet GetSelectedCategories(int id)
        {
            return new DAL.CategoryDAL().GetSelectedCategories(id);
        }

        public List<Category> GetCategorylist(int Deprtid)
        {
            return new DAL.CategoryDAL().GetCategorylist(Deprtid);
        }
    }
}
