using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Common;

namespace DAL
{
    public class PrefixDAL
    {
        List<Prefix> stores = new List<Prefix>();

        SqlDataAdapter da = new SqlDataAdapter();

        private string source = ReadProjectConfigFile.ConfigString();
      
                    
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlTransaction VTran;



        public Int32 GetMaxID()
        {
            try
            {
                string Select = "Select isNull(Max(ID),0) + 1 as ID from Prefix";
                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand(Select, con);

                Int32 VID = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
                return VID;
            }
            catch
            {
                con.Close();
                throw;
            }
        }

        public List<Prefix> GetPrefixs(int id)
        {
            if (stores == null) stores = new List<Prefix>();
            try
            {
                string where = "";

                if (id > 0)
                {
                    where = " Where ID = " + id;
                }
                else
                {
                    Prefix newCategory;
                    newCategory = new Prefix(0, "Non");
                    stores.Add(newCategory);
                }
                string select = "Select * from Prefix" + where;
                
                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand(select, con );
                
                dr = cmd.ExecuteReader();

                //Add Categories to Collection
                AddCategories();

                con.Close();
                return stores ;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        
        public void AddCategories()
        {
            try
            {
                Prefix newCategory;
               
                while (dr.Read())
                {                
     
                    newCategory = new Prefix((int)dr["ID"], (string)dr["Name"]);
                    stores.Add(newCategory);
                }
                dr.Close();
            }
            catch (Exception ex) 
            {
                throw;
            }

            finally { dr.Close(); }
            
        }

        public Boolean SavePrefix(Prefix c, bool isNew)
        {
            try
            {

                int VID=0;
                                 con = new SqlConnection(ReadProjectConfigFile.ConfigString () );
                con.Open();
                VTran = con.BeginTransaction();
                                if (isNew )
                {
                    cmd = new SqlCommand("Select IsNull(Max(id),0) +1 From Prefix", con);
                    cmd.Transaction = VTran;
                    VID =Convert.ToInt32 ( cmd.ExecuteScalar());
                                        }
                else
                {
                    VID=c.Id;
                }
                                string insert = "if exists(select * from Prefix where ID=" + VID + ")Begin Update Prefix set ID=" + VID + ",Name='" + c.Name + "'  where ID=" + VID + " End Else Begin Insert into Prefix(ID,Name) Values(" + VID + ",\'" + c.Name + "\'" + ")End";
                cmd = new SqlCommand(insert, con);
                cmd.Transaction = VTran;
                cmd.ExecuteNonQuery();
                VTran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                VTran.Rollback();
                throw;
            }
            finally
            { con.Close(); }
        }

        public Boolean DeletePrefix(Prefix c)
        {
            try
            {
                string delete = "Delete From Prefix where ID=" + c.Id;
                con = new SqlConnection(source);
                con.Open();

                cmd = new SqlCommand(delete, con);

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            { con.Close(); }
        }


        //public bool GetData(ref Common.Data_Sets.DSPrefixRegister  ds, string where)
        //{
        //    try
        //    {
        //        con = new SqlConnection(source);
        //        con.Open();

        //        string select = "";

        //        select = "SELECT RTRIM(VoucherType) + '-' + SUBSTRING(BankAccNo,LEN(BankAccNo) - 1,LEN(BankAccNo)) + '-' + SUBSTRING(CONVERT(VARCHAR,VoucherDate,107),0,4) + '-' + VoucherNo AS VoucherString,* FROM(SELECT VoucherType,CAST(VoucherNo AS VARCHAR(10)) AS VoucherNo,VoucherDate,VB.Narration,Debit,Credit,IsNull(BankAccNo,'00') AS BankAccNo ,(Select AccountName FROM ChartofAccounts WHERE AccountNo = BankAccNo) AS BankName,PrefixID,Name AS PrefixName,AccountName,AccountType FROM AccVouchersBody VB LEFT OUTER JOIN Prefix P ON P.ID = VB.PrefixID INNER JOIN ChartOfAccounts COA ON COA.AccountNo = VB.Accountno WHERE P.ID IS NOT NULL " + where  + ") AS TB ORDER BY AccountName ";

        //        cmd = new SqlCommand(select, con);

        //        da.SelectCommand = cmd;

        //        da.Fill(ds, "SPPrefixRegister");

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    
    }
}
