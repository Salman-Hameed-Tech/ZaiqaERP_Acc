using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Common;

namespace DAL
{
    public class FixedAccDAL
    {
        private string source = ReadProjectConfigFile.ConfigString();
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader Dr;
        public FixedAccounts getEnteries()
        {
            try
            {


                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand("select * from fixedaccounts", con);
                Dr = cmd.ExecuteReader();
                FixedAccounts objfx = new FixedAccounts();
                while (Dr.Read())
                {
                    objfx.PurRet1 = Convert.ToString ( Dr["purchasereturn"]);
                    objfx.SaleReturn1 = Convert.ToString ( Dr["salereturn"]);
                    objfx.CashAcc1 = Convert.ToString ( Dr["cashacc"]);
                    objfx.PurDisc1 =  Convert.ToString ( Dr["purdisc"]);
                    objfx.SaleDisc1 =  Convert.ToString ( Dr["saledisc"]);
                   // objfx.Transit  = Convert.ToString(Dr["TransitAcc"]);
                }
                Dr.Close();
                return objfx;
            }
            catch (Exception)
            {

                throw;
            }
            finally { con.Close(); }
        }
        public  Boolean SaveRecord(FixedAccounts FxObj)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();

                cmd = new SqlCommand("Select * From FixedAccounts", con);
                Dr = cmd.ExecuteReader();
                if (Dr.HasRows == true)
                    cmd = new SqlCommand("Update FixedAccounts Set PurchaseReturn=" + FxObj.PurRet1 + ",CashAcc=" + FxObj.CashAcc1 + " ,PurDisc=" + FxObj.PurDisc1 + ",SaleDisc=" + FxObj.SaleDisc1 + ",SaleReturn=" + FxObj.SaleReturn1 + ",TransitAcc= " + FxObj .Transit , con);
                else
                    cmd = new SqlCommand("insert into fixedaccounts (cashacc,purchasereturn,purdisc,saledisc,salereturn,TransitAcc) values (" + FxObj.CashAcc1 + "," + FxObj.PurRet1 + "," + FxObj.PurDisc1 + "," + FxObj.SaleDisc1 + "," + FxObj.SaleReturn1 + "," + FxObj.Transit + ")", con);
                Dr.Close();
                cmd.ExecuteNonQuery();
                return true;


            }
            catch (Exception)
            {

                throw;
            }
            finally {
                con.Close();
            }
        }
    }
}
