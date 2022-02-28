using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using DAL;


namespace CommonController
{
    public class CategoryPartyController
    {
        public Boolean SaveCPRelation(List<CategoryPartyRelation> listCPR)
        {
            return new DAL.CategoryPartyDAL().SaveCPRelation(listCPR);
        }
        public List<CategoryPartyRelation> GetCategoryPartyRelations()
        {
            return new DAL.CategoryPartyDAL().GetCategoryPartyRelations();
        }
        public List<Category> GetCategories(int id)
        {
            return new DAL.CategoryPartyDAL().GetCategories(id);
        }
    }
}
