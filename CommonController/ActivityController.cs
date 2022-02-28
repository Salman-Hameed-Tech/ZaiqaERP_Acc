using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DAL;

namespace CategoryControlle
{
    public class ActivityController
    {
        public bool GetData(ref Common.Data_Sets.DSActivity ds, DateTime fromDate, DateTime toDate,int branchid)
        {
            try
            {
                return new ActivityDAL().GetData(ref ds,fromDate,toDate,branchid);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
    }
}
