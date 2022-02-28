using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace CategoryControlle
{
    public class ItemLedgerController
    {
        public bool GetData(ref Common.Data_Sets.DSItemLedger ds, int itemID, string fromDate,string toDate,int branchid,string type)
        {
            try
            {
                return new ItemLedgerDAL().GetData(ref ds,itemID,fromDate,toDate, branchid,type);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
    }
}
