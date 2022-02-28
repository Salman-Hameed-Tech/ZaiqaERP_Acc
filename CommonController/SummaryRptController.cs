using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
namespace CategoryControlle
{
    public class SummaryRptController
    {
        public bool GetData(ref Common.Data_Sets.DSSummary ds, Int64 sumNo,string where)
        {
            try
            {
                return new SummaryRptDAL().GetData(ref ds,sumNo,where);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
    }
}
