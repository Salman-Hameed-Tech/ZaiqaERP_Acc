using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using DAL;

namespace CategoryControlle
{
    public class SchItemController
    {
        public void UpdateItem(Int32 itemid, Boolean act)
        {
            new SchItemsDAL().UpdateItem(itemid, act);
        }

        public List<SchItems> LoadGrid(string isFinished, string condition)
        {
            return (new SchItemsDAL().LoadGrid(isFinished, condition));    
        }
        public List<SchItems> LoadGrid()
        {
            return (new SchItemsDAL().LoadGrid());
        }
    }
}
