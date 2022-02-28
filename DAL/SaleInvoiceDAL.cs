
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Common;
using Common.Data_Sets;

namespace DAL
{
    public class SaleInvoiceDAL
    {
        SqlConnection con;

        string source = ReadProjectConfigFile.ConfigString();
        SqlCommand cmd;
        SqlDataReader drSales;
        SqlDataAdapter da;
        SqlDataReader drSaleLines;
        SqlTransaction VTran;

        List<SaleInvoice> sales;
        List<SaleInvoice> subSales;

        List<SaleInvoiceLine> sale;
        SaleInvoice objsale = new SaleInvoice();
        public int GetMaximumID()
        {
            try
            {
                int VID = 0;
               // DateTime d = new DayLogDAL().GetDay();

                con = new SqlConnection(source);
                con.Open();

                cmd = new SqlCommand("Select IsNull(Max(SaleID),0) +1 From SaleInvoice ", con);
                VID = Convert.ToInt32(cmd.ExecuteScalar());

                return VID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetPassword(int branchID)
        {
            try
            {
                string note;
                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand(" Select Password from DiscountPassword where BranchID="+branchID+" ", con);
                string pwd = cmd.ExecuteScalar().ToString();
                return pwd;
                con.Close();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public string GetSaleInvoiceNote()
        {
            try
            {
                string note;
                con = new SqlConnection(source);
                con.Open();

                cmd = new SqlCommand("Select IsNull(Note,'') From InvoiceNote", con);
                note = Convert.ToString(cmd.ExecuteScalar());

                return note;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            { con.Close(); }
        }
        public bool SaveSaleInvoiceNote(string note)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();

                cmd = new SqlCommand("if exists(Select * from InvoiceNote)Begin Update InvoiceNote Set Note='" + note + "' End Else Begin Insert Into InvoiceNote Values('" + note + "') End", con);
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int GetPendingCount(int branchid)
        {

            int count = 0;
            DateTime d = new DayLogDAL().GetDay(branchid);

            con = new SqlConnection(source);
            con.Open();

            cmd = new SqlCommand("Select Count(*) From SaleInvoice Where SaleDate='" + d.ToString("yyyy-MM-dd 00:00:00") + "'  ", con);
            count = Convert.ToInt32(cmd.ExecuteScalar());

            return count;
        }

        public bool GetReportData(ref Common.Data_Sets.DSSaleInvoice dSSale, DateTime date,int iD)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();

                cmd = new SqlCommand(" select si.SaleID,si.SaleDate,si.SupplierID as partyID,p.partyname as PartyName,si.TotalAmt,si.BranchID,b.BranchName,sib.ItemID,i.ItemName,sib.Quantity,sib.SalePrice from saleinvoice si  inner join saleinvoicebody sib on si.saleid=sib.saleid left join parties p on si.supplierid=p.partyid left join Branch b on si.Branchid=b.id left join item i on sib.Itemid=i.itemid where si.saleid="+iD+"", con);
                da = new SqlDataAdapter(cmd);
         
                da.Fill(dSSale, "SPSaleInvoice");
                return true;
            }
            catch (Exception)
            {
               
                
                throw;
            }
            finally
            {
              
                con.Close();
            }
        }

        public SaleInvoice GetSelectedSale(int id,int branchid)
        {
            try
            {
                con = new SqlConnection(source);          
                con.Open();
              

                AddSaleLines(id, branchid);
                cmd = new SqlCommand(" select SaleID,SaleDate,SupplierID,p.PartyName,TotalAmt,saleinvoice.BranchID,username  from saleinvoice left join users u on saleinvoice.userno=u.userno left join parties p on saleinvoice.SupplierID=p.partyid where saleid=" + id+" ", con);
                drSales = cmd.ExecuteReader();

                while (drSales.Read())
                {

                    objsale.SaleID = Convert.ToInt32(drSales["SaleID"]);
                    objsale.BranchID = Convert.ToInt32(drSales["BranchID"]);
                    objsale.Saledate = Convert.ToDateTime(drSales["SaleDate"]);
                    objsale.PartyID = drSales["SupplierID"].ToString();
                    objsale.PartyName = drSales["PartyName"].ToString();
                    objsale.Total = Convert.ToInt64(drSales["TotalAmt"]);
                    objsale.UserName = Convert.ToString(drSales["username"]);
                }
                return objsale;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        private void AddSaleLines(int id,int branchid)
        {
            try
            {
                
                SqlDataReader dr;
                cmd = new SqlCommand(" select sb.ItemID,i.ItemName,sb.Quantity,sb.PurPrice,sb.SalePrice,cs.quantity as csqty,sb.srno from saleinvoicebody sb left outer join (select itemid,sum(quantity) as quantity,case when sum(quantity)<>0  then  sum(quantity*price)/sum(quantity) else 0  end  as price from tblfifo where branchid=" + branchid + " group by itemid) Cs on Cs.Itemid=sb.itemid   left join item i on sb.itemid=i.itemid  where saleid=" + id+"", con);
                dr = cmd.ExecuteReader();
                List<SaleInvoiceLine> lines = new List<SaleInvoiceLine>();
                while (dr.Read())
                {
                    SaleInvoiceLine sl = new SaleInvoiceLine();
                    sl.Vitem.ItemID = Convert.ToInt32(dr["ItemID"]);
                
                    sl.ItemName= dr["ItemName"].ToString();
                    sl.SalePrice= Convert.ToDecimal(dr["PurPrice"]);
                    sl.SalePrice = Convert.ToDecimal(dr["SalePrice"]);
                    sl.Quantity = Convert.ToDecimal(dr["Quantity"]);
                    sl.CStk = Convert.ToDecimal(dr["csqty"]);
                    sl.SerialNumber = Convert.ToInt32(dr["srno"]);
                    lines.Add(sl);
                }
                dr.Close();
                objsale.SaleLines = lines;
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
        public bool GetPhoneBook(ref DSPhoneBook dSPhoneBook)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand(" select distinct(CustomerCell),CustomerName from SaleInvoice where CustomerCell <> '' and CustomerCell is not null ", con);
                da = new SqlDataAdapter(cmd);
               
                da.Fill(dSPhoneBook, "SPPhoneBook");

                return true;
            }
            catch (Exception)
            {

                throw;
            }  
        }

        public bool GetCCSaleSummary(ref DSCCSaleSummary dSCC, string fromDate, string toDate, int branchid, string bank)
        {
            try
            {
                Object objFrom = fromDate;
                Object objTo = toDate;
                Object objbranchid = branchid;
                Object objBank = bank;
                con = new SqlConnection(source);
                con.Open();

                cmd = new SqlCommand("SPCreditCardSaleSummary", con);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;            
                if (branchid > 0)
                {
                    cmd.Parameters.AddWithValue("@Branchid", branchid);
                }
                if (bank !="")
                {
                    cmd.Parameters.AddWithValue("@Bank", objBank  );
                }
                cmd.Parameters.AddWithValue("@FromDate", objFrom);
                cmd.Parameters.AddWithValue("@ToDate", objTo);
                SqlDataAdapter da1 = new SqlDataAdapter();
                da1.SelectCommand = cmd;

                da1.Fill(dSCC, "CCSaleSummary");

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ChartOfAccounts> GetBankAcc()
        {
            con = new SqlConnection(source);
            List<ChartOfAccounts> accounts = new List<ChartOfAccounts>();
            con.Open();

            cmd = new SqlCommand("select AccountNo,AccountName,AccountType from ChartofAccounts where IsDetailed=1 and AccountNo like '11200%'", con);
            drSales = cmd.ExecuteReader();

            while (drSales.Read())
            {
                ChartOfAccounts ca = new ChartOfAccounts();
                ca.AccountNo = (string)drSales["AccountNo"];
                ca.AccountName = (string)drSales["AccountName"];
                ca.AccountType = (AccountType)Enum.Parse(typeof(AccountType), (string)(drSales["AccountType"]), true);
                accounts.Add(ca);

            }
            return accounts;
        }

        public List<SaleInvoice> GetSingleSale(int iD, DateTime date)
        {
            try
            {
                if (sales == null) sales = new List<SaleInvoice>();

                con = new SqlConnection(source);

                string select = "select SI.SaleID,SI.SaleDate,SI.TotalAmt,SI.AmtPaid,SI.CreditCardAmount,SI.CardDeduction,SI.TotalRetAmt,SI.Balance,SI.TotalDiscount,IsNull(PartyName,'') as PartyName,SI.SupplierID,SI.IsPending,SI.InvDiscount,SI.CreditCardID,SI.SummaryNo from SaleInvoice SI Left Outer Join Parties P on P.PartyID=SI.SupplierID  where Saleid=" + iD +" and SaleDate='"+date.ToString("yyyy-MM-dd 00:00:00")+"' and Branchid="+Globals.BranchID+"";

                con.Open();
                cmd = new SqlCommand(select, con);
                drSales = cmd.ExecuteReader();

                Customer c;
                List<SaleInvoiceLine> salesLines;

                while (drSales.Read())
                {
                    salesLines = new List<SaleInvoiceLine>();
                    c = new Customer(new ChartOfAccounts((string)(drSales["SupplierID"] == System.DBNull.Value ? "" : drSales["SupplierID"]), Convert.ToString(drSales["PartyName"])), new Name(), new Address(), "");

                    sales.Add(new SaleInvoice((int)drSales["SaleID"], (DateTime)drSales["SaleDate"], Convert.ToBoolean(drSales["IsPending"]), c, Convert.ToDouble(drSales["InvDiscount"]), (long)Convert.ToDouble(drSales["CreditCardID"]), (long)Convert.ToDouble(drSales["CreditCardAmount"]), Convert.ToDouble(drSales["AmtPaid"]), Convert.ToDouble(drSales["TotalAmt"]), Convert.ToDouble(drSales["TotalDiscount"]), salesLines, (long)Convert.ToDouble(drSales["SummaryNo"]), Convert.ToDouble(drSales["CardDeduction"]), Convert.ToDouble(drSales["TotalRetAmt"]), Convert.ToDouble(drSales["Balance"])));
                }
                drSales.Close();

                if (sales.Count > 0)
                {
                    Item i;

                    SqlCommand cmd2;
                    string selectSaleLine;
                    subSales = new List<SaleInvoice>();

                    foreach (SaleInvoice si in sales)
                    {
                        selectSaleLine = "select SaleID,SaleDate,SIB.ItemID,SIB.ItemBarcode,SIB.ShortKey,I.companyName,I.productname,I.design,I.size,isnull(I.Color,'')as Color,SIB.Quantity,SIB.PurPrice,SIB.SalePrice,Discount,IsNull(CS.Quantity,0) as CSQty,SIB.SrNo from SaleInvoiceBody SIB inner join Item I on I.ItemID=SIB.ItemID inner join ItemCategory IC on IC.CategoryID=I.CategoryID Left Outer join CurrentStock CS on CS.ItemID=SIB.ItemID  and CS.BranchID=sib.BranchID where SIB.SaleID=" + si.SaleID + " and SIB.SaleDate='" + si.Saledate.ToString("yyyy-MM-dd 00:00:00") + "'  and SIB.Branchid="+Globals.BranchID+" ";

                        cmd2 = new SqlCommand(selectSaleLine, con);
                        drSaleLines = cmd2.ExecuteReader();

                        bool contains = false;
                        while (drSaleLines.Read())
                        {
                            i = new Item(Convert.ToInt32(drSaleLines["itemid"]), new ItemName((string)drSaleLines["companyname"], (string)drSaleLines["productname"], (string)drSaleLines["design"], (string)drSaleLines["size"]), (string)drSaleLines["ItemBarCode"], (string)drSaleLines["ShortKey"]);

                            si.SaleLines.Add(new SaleInvoiceLine(Convert.ToDecimal(drSaleLines["CSQty"]), Convert.ToDecimal(drSaleLines["Quantity"]), Convert.ToDecimal(drSaleLines["SalePrice"]), Convert.ToDecimal(drSaleLines["PurPrice"]), Convert.ToDecimal(drSaleLines["Discount"]), i, Convert.ToInt32(drSaleLines["SrNo"]), Convert.ToBoolean(false), Convert.ToInt32(drSaleLines["Saleid"])));

                            contains = true;
                        }

                        if (contains == true)
                        {
                            subSales.Add(si);
                        }
                        drSaleLines.Close();
                    }
                }
                return sales;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { con.Close(); }
        }

        public bool GetInventoryMIS(ref DSMIS dSMIS,string categoryid,List<ChartOfAccounts> LstVendors )
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                SqlDataAdapter da;

                if (LstVendors.Count == 0)
                {
                    da = new SqlDataAdapter("exec SPInventoryMIS  " + categoryid + "", con);

                    System.Data.DataSet ds = new System.Data.DataSet();
                    da.Fill(dSMIS, "SPInventoryMIS");
                }
                
            else
            {
                for (int i = 0; i < LstVendors.Count  ; i++)
                {
                    da = new SqlDataAdapter("exec SPInventoryMIS  " + categoryid + "", con);

                    System.Data.DataSet ds = new System.Data.DataSet();
                    da.Fill(dSMIS, "SPInventoryMIS");
                }
            }
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                //return false;
                throw ex;
            }
        }

        public string GetPrinterName(int branchid)
        {
            try
            {
                con = new SqlConnection(source);
            con.Open();
            cmd = new SqlCommand(" Select PrinterName from Printer where branchid="+ branchid + " ", con);

            string Printer=cmd.ExecuteScalar().ToString();
            return Printer;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool SavePrinter(string printer, int branchid)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                VTran = con.BeginTransaction();

                cmd = new SqlCommand(" Delete from Printer where branchid="+ branchid + "", con);
                cmd.Transaction = VTran;
                cmd.ExecuteNonQuery();

                cmd.CommandText= " Insert into Printer (PrinterName,branchid) values('" + printer + "',"+branchid+")";            
                cmd.ExecuteNonQuery();

                VTran.Commit();
                con.Close();
                return true;
               

            }
            catch (Exception ex)
            {
                VTran.Rollback();
                throw;
            }
        }

        public bool GetInventoryValuation(ref DSInventoryValuation dSInventory, string FromDate, string Todate, int BranchID)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();

                cmd = new SqlCommand("exec SpStkValuation  '" + FromDate + "','" + Todate + "'," + BranchID + "", con);
                cmd.CommandTimeout = 6000;//seconds
                cmd.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter("exec SPInventoryValuation " + BranchID + ",'" + FromDate + "','" + Todate + "'", con);

                System.Data.DataSet ds = new System.Data.DataSet();
                da.Fill(dSInventory, "SPInventoryValuation");
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                //return false;
                throw ex;
            }
        }

        public bool GetValuationSale(ref DSValuationSale dSValuationSale, string FromDate,string Todate,int BranchID, List<Branch> counters,List<ChartOfAccounts> vendor)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();

                if (BranchID > 0) // for single Branch
                {
                    Object objFrom = FromDate;
                    Object objTo = Todate;
                    Object objbranchid = BranchID;
                
                    con = new SqlConnection(source);
                    con.Open();

                    cmd = new SqlCommand("exec SpStkValuation '" + objFrom + "','" + objTo + "'," + BranchID + "", con);
                    cmd.CommandTimeout = 6000;//seconds
                    cmd.ExecuteNonQuery();

                    if (vendor.Count > 0)
                    {
                        for (int v = 0; v < vendor.Count; v++)
                        {

                            cmd = new SqlCommand("SPValuationSale", con);
                            cmd.Parameters.AddWithValue("@FromDate", objFrom);
                            cmd.Parameters.AddWithValue("@ToDate", objTo);
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@BranchID", objbranchid);
                            cmd.Parameters.AddWithValue("@Vendor", vendor[v].AccountNo);

                            SqlDataAdapter da1 = new SqlDataAdapter();
                            da1.SelectCommand = cmd;
                            da1.Fill(dSValuationSale, "SPValuationSale");
                        }
                    }
                    else
                    {
                        cmd = new SqlCommand("SPValuationSale", con);
                        cmd.Parameters.AddWithValue("@FromDate", objFrom);
                        cmd.Parameters.AddWithValue("@ToDate", objTo);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@BranchID", objbranchid);

                        SqlDataAdapter da1 = new SqlDataAdapter();
                        da1.SelectCommand = cmd;
                        da1.Fill(dSValuationSale, "SPValuationSale");
                    }
                    

                  
                   
                }
                else //For All Branches
                {

                    for (int i = 0; i < counters.Count; i++)
                    {
                        Object objFrom = FromDate;
                        Object objTo = Todate;
                        Object objbranchid = counters[i].ID;
                    
                        con = new SqlConnection(source);
                        con.Open();

                        cmd = new SqlCommand("exec SpStkValuation '" + objFrom + "','" + Todate + "'," + objbranchid + "", con);
                        cmd.CommandTimeout = 6000;//seconds
                        cmd.ExecuteNonQuery();

                        if (vendor.Count > 0)
                        {
                            for (int v = 0; v < vendor.Count; v++)
                            {
                                cmd = new SqlCommand("SPValuationSale", con);
                                cmd.Parameters.AddWithValue("@FromDate", objFrom);
                                cmd.Parameters.AddWithValue("@ToDate", objTo);
                                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@BranchID", objbranchid);
                                cmd.Parameters.AddWithValue("@Vendor", vendor[v].AccountNo);

                                SqlDataAdapter da1 = new SqlDataAdapter();
                                da1.SelectCommand = cmd;
                                da1.Fill(dSValuationSale, "SPValuationSale");
                            }
                        }
                        else 
                        {
                            cmd = new SqlCommand("SPValuationSale", con);
                            cmd.Parameters.AddWithValue("@FromDate", objFrom);
                            cmd.Parameters.AddWithValue("@ToDate", objTo);
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@BranchID", objbranchid);

                            SqlDataAdapter da1 = new SqlDataAdapter();
                            da1.SelectCommand = cmd;
                            da1.Fill(dSValuationSale, "SPValuationSale");
                        }

                    
                      
                    }
                }
                con.Close();
                return true;
            }
            catch(Exception ex)
            {
                //return false;
                throw ex;
            }
        }

        public List<SaleInvoice> GetAllSale(int id)
        {
            try
            {
                if (sales == null) sales = new List<SaleInvoice>();

                con = new SqlConnection(source);

                string select = "select SI.SaleID,SI.SaleDate,SI.TotalAmt,SI.AmtPaid,SI.CreditCardAmount,SI.CardDeduction,SI.TotalRetAmt,SI.Balance,SI.TotalDiscount,IsNull(PartyName,'') as PartyName,SI.SupplierID,SI.IsPending,SI.InvDiscount,SI.CreditCardID,SI.SummaryNo from SaleInvoice SI Left Outer Join Parties P on P.PartyID=SI.SupplierID  where Saleid=" + id;

                con.Open();
                cmd = new SqlCommand(select, con);
                drSales = cmd.ExecuteReader();

                Customer c;
                List<SaleInvoiceLine> salesLines;

                while (drSales.Read())
                {
                    salesLines = new List<SaleInvoiceLine>();
                    c = new Customer(new ChartOfAccounts((string)(drSales["SupplierID"] == System.DBNull.Value ? "" : drSales["SupplierID"]), Convert.ToString(drSales["PartyName"])), new Name(), new Address(), "");

                    sales.Add(new SaleInvoice((int)drSales["SaleID"], (DateTime)drSales["SaleDate"], Convert.ToBoolean(drSales["IsPending"]), c, Convert.ToDouble(drSales["InvDiscount"]), (long)Convert.ToDouble(drSales["CreditCardID"]), (long)Convert.ToDouble(drSales["CreditCardAmount"]), Convert.ToDouble(drSales["AmtPaid"]), Convert.ToDouble(drSales["TotalAmt"]), Convert.ToDouble(drSales["TotalDiscount"]), salesLines, (long)Convert.ToDouble(drSales["SummaryNo"]), Convert.ToDouble(drSales["CardDeduction"]), Convert.ToDouble(drSales["TotalRetAmt"]), Convert.ToDouble(drSales["Balance"])));
                }
                drSales.Close();

                if (sales.Count > 0)
                {
                    Item i;

                    SqlCommand cmd2;
                    string selectSaleLine;
                    subSales = new List<SaleInvoice>();

                    foreach (SaleInvoice si in sales)
                    {
                        selectSaleLine = "select SaleID,SaleDate,SIB.ItemID,SIB.ItemBarcode,SIB.ShortKey,I.companyName,I.productname,I.design,I.size,isnull(I.Color,'')as Color,SIB.Quantity,SIB.PurPrice,SIB.SalePrice,Discount,IsNull(CS.Quantity,0) as CSQty,SIB.SrNo from SaleInvoiceBody SIB inner join Item I on I.ItemID=SIB.ItemID inner join ItemCategory IC on IC.CategoryID=I.CategoryID Left Outer join CurrentStock CS on CS.ItemID=SIB.ItemID where SIB.SaleID=" + si.SaleID + " and SIB.SaleDate='" + si.Saledate + "'";

                        cmd2 = new SqlCommand(selectSaleLine, con);
                        drSaleLines = cmd2.ExecuteReader();

                        bool contains = false;
                        while (drSaleLines.Read())
                        {
                            i = new Item(Convert.ToInt32(drSaleLines["itemid"]), new ItemName((string)drSaleLines["companyname"], (string)drSaleLines["productname"], (string)drSaleLines["design"], (string)drSaleLines["size"]), (string)drSaleLines["ItemBarCode"], (string)drSaleLines["ShortKey"]);

                            si.SaleLines.Add(new SaleInvoiceLine(Convert.ToDecimal(drSaleLines["CSQty"]), Convert.ToDecimal(drSaleLines["Quantity"]), Convert.ToDecimal(drSaleLines["SalePrice"]), Convert.ToDecimal(drSaleLines["PurPrice"]), Convert.ToDecimal(drSaleLines["Discount"]), i, Convert.ToInt32(drSaleLines["SrNo"]), Convert.ToBoolean(false), Convert.ToInt32(drSaleLines["Saleid"])));
                          
                            contains = true;
                        }

                        if (contains == true)
                        {
                            subSales.Add(si);
                        }
                        drSaleLines.Close();
                    }
                }
                return sales;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { con.Close(); }
        }

        public List<SaleInvoiceLine> VerifyItem(string id, string type)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                string vwhere = "";
                List<SaleInvoiceLine> lst = new List<SaleInvoiceLine>();

                if (type == "b")
                {
                    vwhere = "   where ib.Barcode='"+id+"'    and item.isactive=1";
                }
                else if (type == "s")
                {
                    vwhere = " where shortkey='" + id + "'  and item.isactive=1";
                }
                else if (type == "i")
                {
                    vwhere = " where item.itemid=" + id + " and item.isactive=1";
                }
                cmd = new SqlCommand("Select item.itemid,item.companyName,isnull(ib.Barcode,'')as Barcode,item.productname,item.design,item.size,IsNull(cs.quantity,0) as qty,isnull(cs.price,0) as purprice ,item.saleprice  from item Left Outer Join (select itemid,branchid,sum(quantity) as quantity,case when sum(quantity)<>0  then  sum(quantity*price)/sum(quantity) else 0  end  as price from tblfifo where branchid=1 group by itemid,branchid) Cs on Cs.Itemid=item.itemid and Cs.BranchID=" + Globals.BranchID+ " inner join ItemBarcodes ib on item.ItemID=ib.itemid  " + vwhere, con); //IsNull(cs.price,isnull(item.purchaseprice,0))
                drSales = cmd.ExecuteReader();

                while (drSales.Read())
                {
                    Item i = new Item(Convert.ToInt32(drSales["itemid"]), new ItemName((string)drSales["companyname"], (string)drSales["productname"], (string)drSales["design"], (string)drSales["size"]), Convert.ToDecimal(drSales["qty"]), Convert.ToDecimal(0));
                   
                    i.BarCode = Convert.ToString(drSales["Barcode"]);

                    SaleInvoiceLine obj = new SaleInvoiceLine();
                    obj.Vitem = i;
                    obj.SalePrice= (decimal)drSales["purprice"];
                    obj.CStk= (decimal)drSales["qty"];

                    lst.Add(obj);
                }
                return lst;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close();
            }
        }
        public List<SaleInvoiceLine> VerifyAllItem(string id, string type,int branchid)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                string vwhere = "";
                List<SaleInvoiceLine> lst = new List<SaleInvoiceLine>();

                if (type == "b")
                {
                    vwhere = " where item.itemid=(select itemid from itembarcodes where barcode='" + id + "') and item.isactive=1";
                }
                else if (type == "s")
                {
                    vwhere = " where shortkey='" + id + "' and item.isactive=1";
                }
                else if (type == "i")
                {
                    vwhere = " where item.itemid=" + id + "   and item.isactive=1";
                }
                else if (type == "BI")
                {
                    vwhere = " where item.itemid=" + id + " and item.isBakery=1  and item.isactive=1";
                }
                else if (type == "BIbarcode")
                {
                    vwhere = " where item.itemid=(select itemid from itembarcodes where barcode='" + id + "') and item.isactive=1  and item.isBakery=1 ";
                }
                cmd = new SqlCommand("Select item.itemid,item.companyName,item.productname,item.design,item.size,IsNull(cs.quantity,0) as qty  ,isnull(cs.Price,0) as SalePrice,isnull(item.SalePrice,0) as  purprice ,0 as discountlimit, ic.Barcode  from item Left Outer Join (select itemid,sum(quantity) as quantity,case when sum(quantity)<>0  then  sum(quantity*price)/sum(quantity) else 0  end  as price from tblfifo where branchid=" + branchid+" group by itemid) Cs on Cs.Itemid=item.itemid   left join ItemBarcodes ic on Item.ItemID=ic.itemid  " + vwhere, con); //IsNull(cs.price,isnull(item.purchaseprice,0))
                drSales = cmd.ExecuteReader();

                while (drSales.Read())
                {
                    Item i = new Item(Convert.ToInt32(drSales["itemid"]), new ItemName((string)drSales["companyname"], (string)drSales["productname"], (string)drSales["design"], (string)drSales["size"]), Convert.ToDecimal(drSales["qty"]), Convert.ToDecimal(drSales["discountlimit"]));
                  
                    i.BarCode = Convert.ToString(drSales["Barcode"]);

                    SaleInvoiceLine obj = new SaleInvoiceLine();// Convert.ToDecimal(drSales["qty"]), 0, (decimal)drSales["SalePrice"], (decimal)drSales["purprice"], Convert.ToDecimal(drSales["discountlimit"]), i, 0, Convert.ToBoolean(false), 0);
                    obj.Vitem = i;
                    obj.CStk = Convert.ToDecimal(drSales["qty"]);
                    obj.SalePrice= Convert.ToDecimal(drSales["SalePrice"]);
                    obj.PurchasePrice = Convert.ToDecimal(drSales["purprice"]);
                    lst.Add(obj);
                }
                return lst;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close();
            }
        }
        public int UpdateSaleforSummary(SaleInvoice sale, bool isNew)
        {
            try
            {

                int VID = sale.SaleID;
                con = new SqlConnection(source);
                con.Open();
                VTran = con.BeginTransaction();

                cmd = new SqlCommand("", con);           
                cmd.Transaction = VTran;

                foreach (SaleInvoiceLine line in sale.SaleLines)
                {
                    if (!line.IsDeleted && line.SerialNumber != 0)
                    {

                        cmd.CommandText = "Select Quantity from saleinvoicebody where Itemid=" + line.Vitem.ItemID + " and  SrNo = " + line.SerialNumber + " and BranchID=" + sale.BranchID + " ";
                        decimal PrevQuantity = Convert.ToDecimal(cmd.ExecuteScalar());

                        cmd.CommandText = "update  SaleInvoiceBody set ItemID=" + line.Vitem.ItemID + ",ItemBarCode='" + line.Vitem.BarCode + "',Quantity=" + line.Quantity + ",PurPrice=" + line.PurchasePrice + ",SalePrice=" + line.SalePrice + ",Discount=" + line.Disc + ",DiscPer= "+ line.Discper + ",DiscAmt=" + line.Disc + "  where  srno="+line.SerialNumber+"   ";
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = "exec SPUpdateSale " + line.Vitem.ItemID + ", " + sale.BranchID + "," + line.Quantity + ", " + PrevQuantity + " ";
                        cmd.ExecuteNonQuery();



                    }
                    else if (!line.IsDeleted && line.SerialNumber == 0)
                    {
                        cmd.CommandText = UpdateLines(line, VID,sale);
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = "exec SPInsertSale " + line.Vitem.ItemID + ", " + sale.BranchID + ", " + line.Quantity + " ";
                        cmd.ExecuteNonQuery();

                    }
                    else
                    {
                        cmd.CommandText = "Select Quantity from saleinvoicebody where Itemid=" + line.Vitem.ItemID + " and  SrNo = " + line.SerialNumber + " and BranchID=" + sale.BranchID + " ";
                        decimal PrevQuantity = Convert.ToDecimal(cmd.ExecuteScalar());

                        cmd.CommandText = "Delete from SaleInvoiceBody where SrNo = " + line.SerialNumber;
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = "exec SPDeleteSale " + line.Vitem.ItemID + ", " + sale.BranchID + ", " + PrevQuantity + " ";
                        cmd.ExecuteNonQuery();

                    }
                 
                }
                cmd.CommandText = "Update SaleInvoice Set SDateTime='" + sale.SDateTime + "',InvDiscount=" + sale.Invdisc + ",TotalAmt=" + sale.Total + ",AmtPaid=" + sale.Cashamt + ",TotalDiscount=" + sale.Totaldisc + ",TotalRetAmt=" + sale.TotalRetAmt + ",Balance=" + sale.Balance + ", Reference='" + sale.Reference + "',CustomerName='" + sale.CustomerName +"',CustomerCell='"+sale.CustomerCell+"',PmtType='"+sale.PmtType+"',Bank='"+sale.BankAcc+"',CardNo='"+sale.CardNo+"'      where  saleid="+VID+" and  saledate='"+sale.Saledate.ToString("yyyy-MM-dd 00:00:00")+"'  and branchid="+sale.BranchID+" ";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "DELETE FROM AccVouchersBody WHERE VoucherType = 'SJV' AND VoucherNo = " + VID;
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("exec SpSaleAccEntries " + VID + ",'" + sale.Saledate.Date.ToString("yyyy-MM-dd 00:00:00") + "'", con);
                cmd.Transaction = VTran;
                cmd.ExecuteNonQuery();


                VTran.Commit();
                con.Close();
                return VID;
            }

            catch(Exception ex)
            {
                VTran.Rollback();
                throw ex;
            }
            finally { con.Close(); }
        }

        private string UpdateLines(SaleInvoiceLine sl, int VID, SaleInvoice sale)
        {
            try
            {
                string insertItems = "Insert Into SaleInvoiceBody(SaleID,SaleDate,SDateTime,ItemID,ItemBarCode,ShortKey,Quantity,PurPrice,SalePrice,Discount,IsCancelled,BranchID,DiscPer,DiscAmt,UserNo) Values(" + VID + ",'" + sale.Saledate.Date.ToString("yyyy-MM-dd 00:00:00") + "','" + sale.SDateTime.ToString("yyyy-MM-dd 00:00:00") + "'," + sl.Vitem.ItemID + ",'" + sl.Vitem.BarCode + "','" + sl.Vitem.ShortKey + "'," + sl.Quantity + "," + sl.PurchasePrice + "," + sl.SalePrice + "," + sl.Disc + ",0," + sale.BranchID + "," + sl.Discper + "," + sl.Disc + "," + User.UserNo + ")";
                return insertItems;
            }
            catch
            {
                VTran.Rollback();
                throw;
            }
        }

        public int SaveSale(SaleInvoice sale, bool isNew)
        {
            try
            {
                int VID = 0;
                con = new SqlConnection(source);
                con.Open();
                VTran = con.BeginTransaction();        
                if (isNew)
                {
                    cmd = new SqlCommand("Select IsNull(Max(SaleID),0) +1 From SaleInvoice ", con);
                    cmd.Transaction = VTran;
                    VID = Convert.ToInt32(cmd.ExecuteScalar());
                    string insertInvoice = "";
                    insertInvoice = " Insert into SaleInvoice(SaleID,SaleDate,SupplierID,TotalAmt,SummaryNo, Reference,BranchID,UserNo) Values(" + VID + ",'" + sale.Saledate.Date.ToString("yyyy-MM-dd 00:00:00") + "','" + sale.PartyID + "'," + sale.Total + "," + Summary.SummaryNo + ",'" + sale.Reference + "'," + sale.BranchID + "," + User.UserNo + ")  ";
                    cmd.CommandText = insertInvoice;
                    cmd.ExecuteNonQuery();

                    foreach (SaleInvoiceLine pl in sale.SaleLines)
                    {
                        if (pl.IsDeleted == false)
                        {
                            cmd.CommandText = SetInsertLine(pl, VID, sale);
                            cmd.ExecuteNonQuery();
                   
                           
                        }
                    }

                }
                else
                {
                    VID = sale.SaleID;
                    cmd = new SqlCommand("", con);
                    cmd.Transaction = VTran;

                    foreach (SaleInvoiceLine line in sale.SaleLines)
                    {
                        if (!line.IsDeleted && line.SerialNumber != 0)
                        {
                            cmd.CommandText = "Update SaleInvoiceBody Set SaleDate='"+sale.Saledate.Date.ToString("yyyy-MM-dd 00:00:00")+"',ItemID = " + line.Vitem.ItemID + ",ItemBarCode='" + line.Vitem.BarCode+"', Quantity = " + line.Quantity + " ,PurPrice = " + line.PurchasePrice + ",SalePrice = " + line.SalePrice + ",ItemDescription='"+line.Vitem.ItemName+"',UserNo="+User.UserNo+"  where SrNo = " + line.SerialNumber;
                            cmd.ExecuteNonQuery();
                        }
                        else if (!line.IsDeleted && line.SerialNumber == 0)
                        {
                            cmd.CommandText = SetInsertLine(line, VID, sale);
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            cmd.CommandText = "Delete from SaleInvoiceBody where SrNo = " + line.SerialNumber;
                            cmd.ExecuteNonQuery();
                        }

                    }

                    cmd.CommandText = "Update  SaleInvoice set  SaleDate='" + sale.Saledate.Date.ToString("yyyy-MM-dd 00:00:00")+"',SupplierID='"+sale.PartyID+"',TotalAmt="+sale.Total+",SummaryNo="+Summary.SummaryNo+", Reference='"+sale.Reference+"',BranchID="+sale.BranchID+",UserNo="+User.UserNo+"   where saleid="+VID+"    ";
                    cmd.ExecuteNonQuery();
                    
                }

                cmd.CommandText = "DELETE FROM AccVouchersBody WHERE  VoucherType = 'SJV' AND VoucherNo = " + VID;
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("exec SpSaleAccEntries " + VID , con);
                cmd.Transaction = VTran;
                cmd.ExecuteNonQuery();

                VTran.Commit();
                con.Close();
                return VID;
            }
            catch (Exception ex)
            {
                VTran.Rollback();
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        private string SetInsertLine(SaleInvoiceLine sl, int VID,SaleInvoice sale)
        {
            try
            {
                string insertItems = "Insert Into SaleInvoiceBody(SaleID,SaleDate,ItemID,ItemDescription,Quantity,PurPrice,SalePrice,UserNo,ItemBarCode) Values(" + VID + ",'" + sale.Saledate.Date.ToString("yyyy-MM-dd 00:00:00") + "'," + sl.Vitem.ItemID + ",'"+sl.Vitem.ItemName+"'," + sl.Quantity + "," + sl.PurchasePrice + "," + sl.SalePrice + ","+User.UserNo+",'"+sl.Vitem.BarCode+"')";
                return insertItems;
            }
            catch
            {
                VTran.Rollback();
                throw;
            }
        }

        public bool CancelSale(SaleInvoice sale, DateTime date, int branchid)
        {
            try
            {
                DateTime d = new DayLogDAL().GetDay(branchid);
            
                con = new SqlConnection(source);
                con.Open();
                VTran = con.BeginTransaction();
                

                foreach (SaleInvoiceLine sl in sale.SaleLines)
                {
                    
 
                    cmd= new SqlCommand("Select Quantity from saleinvoicebody where Itemid= " + sl.Vitem.ItemID + " and  SrNo = " + sl.SerialNumber + " and BranchID=" + branchid + " ",con);
                    cmd.Transaction = VTran;
                    decimal PrevQuantity = Convert.ToDecimal(cmd.ExecuteScalar());

                    cmd.CommandText="Update SaleInvoiceBody Set IsCancelled=1 Where SrNo=" + sl.SerialNumber ;          
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "exec SPDeleteSale " + sl.Vitem.ItemID + ", " + branchid + ", " + PrevQuantity + " ";
                    cmd.ExecuteNonQuery();


                }

                cmd.CommandText="Update SaleInvoice Set IsCancelled=1,IsPending=0 where SaleID=" + sale.SaleID + " and branchid="+branchid+" and saledate='"+ d.Date.ToString("yyyy-MM-dd 00:00:00") + "' " ;            
                cmd.ExecuteNonQuery();

                VTran.Commit();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                VTran.Rollback();
                throw ex;
            }
            finally
            { con.Close(); }
        }

        public List<SaleInvoice> GetSalesInv( int Branchid)
        {
            try
            {
             
                if (sales == null) sales = new List<SaleInvoice>();

                con = new SqlConnection(source);

                string select = " select SaleID,SaleDate,SupplierID,p.PartyName,TotalAmt  from saleinvoice left join parties p on saleinvoice.SupplierID=p.partyid where branchid=" + Branchid + " ";

                con.Open();
                cmd = new SqlCommand(select, con);
                drSales = cmd.ExecuteReader();
                while (drSales.Read())
                {

                    SaleInvoice si = new SaleInvoice();
                    si.SaleID = Convert.ToInt32(drSales["SaleID"]);
                    si.Saledate = Convert.ToDateTime(drSales["SaleDate"]);
                    si.PartyID = drSales["SupplierID"].ToString();
                    si.Total = Convert.ToInt64(drSales["TotalAmt"]);
                    si.PartyName = drSales["PartyName"].ToString();
                    sales.Add(si);
                }
                
                return sales;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        public List<SaleInvoice> GetPendingSales(string where, int chk)
        {
            try
            {
                DateTime d = new DayLogDAL().GetDay(Globals.BranchID);
                if (sales == null) sales = new List<SaleInvoice>();
                ///////////////////////////////
                con = new SqlConnection(source);
                //  string select = " Select tb2.*,Tb2.IsPending,Tb2.Supplierid,Tb2.SaleID,tb2.SaleDate,name= (select itemprint  from item  Inner Join SaleInvoiceBody Sib on Sib.itemid=Item.itemid  Inner Join SaleInvoice on SaleInvoice.SaleID=Sib.SaleID And SaleInvoice.SaleDate=Sib.SaleDate where SaleInvoice.SaleID=tb2.SaleID And SaleInvoice.SaleDate=Tb2.SaleDate " + where + " And SaleInvoice.IsCancelled <> 1 and  item.itemid= (Select top 1 itemid from saleinvoicebody Where SaleID=Tb2.SaleID And SaleDate=Tb2.SaleDate ) Group by itemprint) +    IsNull( ',' + (select itemprint  from item  Inner Join SaleInvoiceBody Sib on Sib.itemid=Item.itemid  Inner Join SaleInvoice On SaleInvoice.SaleID=Sib.SaleId and SaleInvoice.SaleDate=Sib.SaleDate where  SaleInvoice.SaleID= Tb2.Saleid And SaleInvoice.SaleDate=Tb2.SaleDate " + where + " and SaleInvoice.IsCancelled <>1 And SRNO= ( Select max(srno) from (Select top 2 * from saleinvoicebody  Order by srno desc)tb ) and srno not in (select srno  from item  Inner Join SaleInvoiceBody Sib on Sib.itemid=Item.itemid where item.itemid= (Select top 1 itemid from saleinvoicebody where saleid=tb2.saleid and saledate=tb2.saledate ) ) Group by itemprint),''), CAST(0 as bit)IsGST  From  (select * from SaleInvoice where Year(SaleDate)=Year('" + d.Date.ToString() + "') and Month(SaleDate)=Month('" + d.Date.ToString() + "') and Day(SaleDate)=Day('" + d.Date.ToString() + "') and IsCancelled=0 " + where + ")Tb2 ";
                ///////////////////////////////
                string select = " Select tb2.*,Tb2.IsPending,Tb2.Supplierid,Tb2.SaleID,tb2.SaleDate,name= (select itemprint  from item  Inner Join SaleInvoiceBody Sib on Sib.itemid=Item.itemid  Inner Join SaleInvoice on SaleInvoice.SaleID=Sib.SaleID And SaleInvoice.SaleDate=Sib.SaleDate where SaleInvoice.SaleID=tb2.SaleID And SaleInvoice.SaleDate=Tb2.SaleDate " + where + " And SaleInvoice.IsCancelled <> 1 and  item.itemid= (Select top 1 itemid from saleinvoicebody Where SaleID=Tb2.SaleID And SaleDate=Tb2.SaleDate ) Group by itemprint) +    IsNull( ',' + (select itemprint  from item  Inner Join SaleInvoiceBody Sib on Sib.itemid=Item.itemid  Inner Join SaleInvoice On SaleInvoice.SaleID=Sib.SaleId and SaleInvoice.SaleDate=Sib.SaleDate where  SaleInvoice.SaleID= Tb2.Saleid And SaleInvoice.SaleDate=Tb2.SaleDate " + where + " and SaleInvoice.IsCancelled <>1 And SRNO= ( Select max(srno) from (Select top 2 * from saleinvoicebody  Order by srno desc)tb ) and srno not in (select srno  from item  Inner Join SaleInvoiceBody Sib on Sib.itemid=Item.itemid where item.itemid= (Select top 1 itemid from saleinvoicebody where saleid=tb2.saleid and saledate=tb2.saledate ) ) Group by itemprint),''), IsGST  From  (select * from SaleInvoice where Year(SaleDate)=Year('" + d.Date.ToString() + "') and Month(SaleDate)=Month('" + d.Date.ToString() + "') and Day(SaleDate)=Day('" + d.Date.ToString() + "') and IsCancelled=0 " + where + ")Tb2 ";//and (transid = 0 or transid is null) 
                ///////////
                con.Open();
                cmd = new SqlCommand(select, con);
                drSales = cmd.ExecuteReader();

                AddSales();
                //if (sales.Count > 0)
                //{
                //    AddSaleLines();
                //}
                return sales;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<SaleInvoice> GetSales(string wSaleBody, string wSale, string wCancel, bool pending)
        {
            try
            {
                if (sales == null) sales = new List<SaleInvoice>();

                con = new SqlConnection(source);

                string select = "select SI.SaleID,SI.SaleDate,SI.TotalAmt,SI.AmtPaid,SI.CreditCardAmount,SI.CardDeduction,SI.TotalRetAmt,SI.Balance,SI.TotalDiscount,IsNull(PartyName,'') as PartyName,SI.SupplierID,SI.IsPending,SI.InvDiscount,SI.CreditCardID,SI.SummaryNo from SaleInvoice SI Left Outer Join Parties P on P.PartyID=SI.SupplierID  where IsPending=" + (pending == true ? 1 : 0) + wCancel + wSale;

                con.Open();
                cmd = new SqlCommand(select, con);
                drSales = cmd.ExecuteReader();

                Customer c;
                List<SaleInvoiceLine> salesLines;

                while (drSales.Read())
                {
                    salesLines = new List<SaleInvoiceLine>();
                    c = new Customer(new ChartOfAccounts((string)(drSales["SupplierID"] == System.DBNull.Value ? "" : drSales["SupplierID"]), Convert.ToString(drSales["PartyName"])), new Name(), new Address(), "");

                    sales.Add(new SaleInvoice((int)drSales["SaleID"], (DateTime)drSales["SaleDate"], Convert.ToBoolean(drSales["IsPending"]), c, Convert.ToDouble(drSales["InvDiscount"]), (long)Convert.ToDouble(drSales["CreditCardID"]), (long)Convert.ToDouble(drSales["CreditCardAmount"]), Convert.ToDouble(drSales["AmtPaid"]), Convert.ToDouble(drSales["TotalAmt"]), Convert.ToDouble(drSales["TotalDiscount"]), salesLines, (long)Convert.ToDouble(drSales["SummaryNo"]), Convert.ToDouble(drSales["CardDeduction"]), Convert.ToDouble(drSales["TotalRetAmt"]), Convert.ToDouble(drSales["Balance"])));
                }
                drSales.Close();

                if (sales.Count > 0)
                {
                    Item i;

                    SqlCommand cmd2;
                    string selectSaleLine;
                    subSales = new List<SaleInvoice>();

                    foreach (SaleInvoice si in sales)
                    {
                        selectSaleLine = "select SaleID,SaleDate,SIB.ItemID,SIB.ItemBarcode,SIB.ShortKey,I.companyName,I.productname,I.design,I.size,isnull(I.Color,'')as Color,SIB.Quantity,SIB.PurPrice,SIB.SalePrice,Discount,IsNull(CS.Quantity,0) as CSQty,SIB.SrNo from SaleInvoiceBody SIB inner join Item I on I.ItemID=SIB.ItemID inner join ItemCategory IC on IC.CategoryID=I.CategoryID Left Outer join CurrentStock CS on CS.ItemID=SIB.ItemID where SIB.SaleID=" + si.SaleID + " and SIB.SaleDate='" + si.Saledate + "'" + wSaleBody;

                        cmd2 = new SqlCommand(selectSaleLine, con);
                        drSaleLines = cmd2.ExecuteReader();

                        bool contains = false;
                        while (drSaleLines.Read())
                        {
                            i = new Item(Convert.ToInt32(drSaleLines["itemid"]), new ItemName((string)drSaleLines["companyname"], (string)drSaleLines["productname"], (string)drSaleLines["design"], (string)drSaleLines["size"]), (string)drSaleLines["ItemBarCode"], (string)drSaleLines["ShortKey"]);

                            si.SaleLines.Add(new SaleInvoiceLine(Convert.ToDecimal(drSaleLines["CSQty"]), Convert.ToDecimal(drSaleLines["Quantity"]), Convert.ToDecimal(drSaleLines["SalePrice"]), Convert.ToDecimal(drSaleLines["PurPrice"]), Convert.ToDecimal(drSaleLines["Discount"]), i, Convert.ToInt32(drSaleLines["SrNo"]), Convert.ToBoolean(false), 0));
                            contains = true;
                        }

                        if (contains == true)
                        {
                            subSales.Add(si);
                        }
                        drSaleLines.Close();
                    }
                }
                return subSales;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { con.Close(); }
        }

        private void AddSales()
        {
            try
            {
                Customer c;
                List<SaleInvoiceLine> salesLines;

                while (drSales.Read())
                {
                    salesLines = new List<SaleInvoiceLine>();

                    c = new Customer(new ChartOfAccounts((string)(drSales["SupplierID"] == System.DBNull.Value ? "" : drSales["SupplierID"]), ""), new Name(), new Address(), "");
                    sales.Add(new SaleInvoice((int)drSales["SaleID"], (DateTime)drSales["SaleDate"], Convert.ToBoolean(drSales["IsPending"]), c, Convert.ToDouble(drSales["InvDiscount"]), (long)Convert.ToDouble(drSales["CreditCardID"]), Convert.ToDouble(drSales["CreditCardAmount"]), Convert.ToDouble(drSales["AmtPaid"]), Convert.ToDouble(drSales["TotalAmt"]), Convert.ToDouble(drSales["TotalDiscount"]), salesLines, (long)Convert.ToDouble(drSales["SummaryNo"]), Convert.ToString(drSales["name"]), Convert.ToDouble(drSales["CardDeduction"] == System.DBNull.Value ? 0 : drSales["CardDeduction"]), Convert.ToDouble(drSales["TotalRetAmt"] == System.DBNull.Value ? 0 : drSales["TotalRetAmt"]), Convert.ToDouble(drSales["Balance"] == System.DBNull.Value ? 0 : drSales["Balance"]),/* Convert.ToBoolean(drSales["IsGST"] == System.DBNull.Value ? false : drSales["IsGST"]), */drSales["reference"].ToString()));
                }
                drSales.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            { drSales.Close(); }
        }
       

        public bool SaveGST(List<SaleInvoice> lstsi)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand();
                SqlCommand cmd1;
                for (int i = 0; i < lstsi.Count; i++)
                {
                    ////////////////TransID//////////
                    int TransID = 0;
                    cmd1 = new SqlCommand("select ISNULL(IsGst,0) from SaleInvoice where saleid = " + lstsi[i].SaleID, con);
                    //////////////////////
                    if (!Convert.ToBoolean(cmd1.ExecuteScalar()))
                    {
                        cmd1 = new SqlCommand("select max(isnull(TransID,0))+1 from saleinvoice", con);
                        TransID = Convert.ToInt32(cmd1.ExecuteScalar());
                        ////////////////////////////////////////////////
                        string UpdateGST = "update SaleInvoice set IsGst = " + 1 + ", GstID = " + lstsi[i].SaleID + ", TransId = " + TransID + " where SaleId = " + lstsi[i].SaleID + " ";
                        cmd = new SqlCommand(UpdateGST, con);
                        cmd.ExecuteNonQuery();
                    }
                    else { return false; }
                }
                con.Close();
                return true;

            }
            catch (SqlException e1)
            {
                throw e1;
            }
        }

        public bool FillDailyGST(ref DSSaleRegister ds, string p)
        {
            try
            {
                string select = "select  gstid as orderid,saledate as orderdate, (select sum(TotalAmt/1.16)  from saleinvoice where gstid=si.gstid )  as linetotal ,( select (sum(TotalAmt/1.16)*0.16) from saleinvoice where gstid=si.gstid )    as gst from saleinvoice si where 1=1 and isgst=1   order by gstid";
                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand(select, con);
                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds.Tables["SaleRegister"]);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public bool FillSupplyRegister(ref DSSaleRegister ds, string p)
        {
            try
            {
                string select = "select saledate as dated, ' From Inv# ' + cast(min(gstid) as varchar(10)) + ' To Inv# ' + cast(max(gstid) as varchar(10)) as Description, saledate as invdate , sum(cast(total/1.16 as numeric(18,2))) as amt, sum( total  -  (total / 1.16))  as gst , sum( total ) as netsale from ( select gstid, saledate , (select top 1 TotalAmt from saleinvoice where gstid=si.gstid ) as total   from saleinvoice si  where isgst=1 )O  where 1=1   group by saledate order by  saledate";
                con = new SqlConnection(source);
                con.Open();
                cmd = new SqlCommand(select, con);
                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds.Tables["SaleRegister"]);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
