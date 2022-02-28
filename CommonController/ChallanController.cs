using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Common;
using System.Data;
using Common.Data_Sets;

namespace CategoryControlle
{
   public class ChallanController
    {
        ChallanDAL pDal = new ChallanDAL();
        public int SaveOrder(Challan c, bool Isnew)
        {
            return new DAL.ChallanDAL().SaveOrder(c, Isnew);
        }
        public bool UpdateRecord(int id)
        {
            return new ChallanDAL().UpdateRecord(id);
        }
        public int GetMaximumID()
        {
            try
            {
                return pDal.GetMaximumID();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public bool GetChallanData(ref Common.Data_Sets.DsChallan dsChallan, int InvID,string where, int branchID)
        {
            return new DAL.ChallanDAL().GetChallanData(ref dsChallan, InvID,where, branchID);
        }
        public List<Challan> GetData(int id, string where)
        {
            return new DAL.ChallanDAL().GetData(id, where);
        }
        public List<Challan> GetChalan(int id)
        {
            return new ChallanDAL().GetChalan(id);
        }
        public List<Challan> GetRecivedData(int Brnachid)
        {
            return new DAL.ChallanDAL().GetRecivedData( Brnachid);
        }

        public bool DeletePurchase(int VID)
        {
            return new ChallanDAL().DeletePurchase(VID);
        }

        
    }
}
