using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using DAL;

namespace CategoryControlle
{
    public class GodownController
    {
        private List<Godown> godowns;
        private GodownDAL  gDal = new GodownDAL();

        public int GetMaximimID()
        {
            return gDal.GetMaximumID();
        }
        public List<Godown> GetGodown()
        {
            if (godowns == null) godowns = new List<Godown>();

            //todo from database 
            godowns = gDal.GetGodowns ();
            return godowns;
        }

        public void SaveGodown(Godown g)
        {
            try
            {
                gDal.SaveGodown(g);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }            
        }

        public void DeleteGodown(Godown g)
        {
            try
            {
                gDal.DeleteGodown(g);
            }
            catch (Exception ex)
            {

                throw ex;
            }             
        }        
    }
}
