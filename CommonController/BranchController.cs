using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using DAL;
namespace CategoryControlle
{
   public class BranchController
    {
        public Int32 GetMaxID()
        {
            return new BranchDAL().GetMaxID();
        }
        public bool Save(Branch B, bool isNew)
        {
            return new DAL.BranchDAL().Save(B, isNew);
        }
        public bool Delete(string ID)
        {
            return new DAL.BranchDAL().Delete(ID);
        }
        public List<Branch> GetBranch(string s)
        {
            return new DAL.BranchDAL().GetBranch(s);
        }

        public Branch GetSingleCounter(int ID)
        {
            return new DAL.BranchDAL().GetSingleCounter(ID);
        }

        public string GetCurrentBranch(int branchID)
        {
            return new DAL.BranchDAL().GetCurrentBranch(branchID);


        }
    }
}
