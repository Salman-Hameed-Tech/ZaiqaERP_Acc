using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace CommonController
{
    public class RecipieController
    {
        public bool SaveRecipie(Item item)
        {
            return new DAL.RecipieDAL().SaveRecipie(item);
        }

        public string GetMaxInvID()
        {
            return new DAL.RecipieDAL().GetMaxInvID();
        }

        public List<Item> GetRecipieList(int itemID)
        {
            return new DAL.RecipieDAL().GetRecipieList(itemID);
        }

        public int Save(ProductionRecipie production, bool isNew)
        {
            return new DAL.RecipieDAL().Save(production,  isNew);
        }

        public List<ProductionRecipie> GetInvoices(int id,int branchID)
        {
            return new DAL.RecipieDAL().GetInvoices( id,branchID);
        }
    }
}
