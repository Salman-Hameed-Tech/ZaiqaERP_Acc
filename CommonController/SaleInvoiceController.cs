using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using DAL;
using System.Data;
using Common.Data_Sets;

namespace CategoryControlle
{
    public class SaleInvoiceController
    {
        private SaleInvoiceDAL sDAL;

        public int GetMaximumID()
        {
            return new SaleInvoiceDAL().GetMaximumID();
        }
        public DateTime GetDays(int branchid) 
        {
            DayLogDAL daylog = new DayLogDAL();
            return daylog.GetDay(branchid);
        }
        public int GetPendingCount(int branchid)
        {
            return new SaleInvoiceDAL().GetPendingCount(branchid);
        }

        public string GetPassword(int branchID)
        {
            return new DAL.SaleInvoiceDAL().GetPassword(branchID);
        }

        public List<SaleInvoiceLine> VerifyItem(string id, string type)
        {
            return new SaleInvoiceDAL().VerifyItem(id,type);
        }
        public List<SaleInvoiceLine> VerifyAllItem(string id, string type,int branchid)
        {
            return new SaleInvoiceDAL().VerifyAllItem(id, type, branchid);
        }

        public List<SaleInvoice> GetSalesInv(int Branchid)
        {
            return new SaleInvoiceDAL().GetSalesInv(Branchid);
        }



        public List<SaleInvoice> GetPendingSales(string where,int chk)
        {
            return new SaleInvoiceDAL().GetPendingSales(where,chk);
        }

        public int SaveSale(SaleInvoice s,bool isNew)
        {
            return new SaleInvoiceDAL().SaveSale(s,isNew);
        }
        public bool CancelSale(SaleInvoice sale,DateTime date,int branchid)
        {
            return new SaleInvoiceDAL().CancelSale(sale, date,branchid);
        }

        public string GetInvocieNote()
        {

            return new SaleInvoiceDAL().GetSaleInvoiceNote();
        }
        public bool SaveInvoiceNote(string note)
        {

            return new SaleInvoiceDAL().SaveSaleInvoiceNote(note);
        }

        public List<SaleInvoice> GetSales(string wSaleBody,string wSale,string wCancell, bool pending)
        {
            try
            {
                return new SaleInvoiceDAL().GetSales(wSaleBody, wSale, wCancell, pending);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public bool SaveGST(List<SaleInvoice> lstsi) 
        {
            return new DAL.SaleInvoiceDAL().SaveGST(lstsi);
        }

       
        public bool FillDailyGST(ref Common.Data_Sets.DSSaleRegister ds,string p)
        {
            return new DAL.SaleInvoiceDAL().FillDailyGST(ref ds, "");
        }

        public bool FillSupplyRegister(ref Common.Data_Sets.DSSaleRegister ds, string p)
        {
            return new DAL.SaleInvoiceDAL().FillSupplyRegister(ref ds, "");
        }

        public bool GetReportData(ref Common.Data_Sets.DSSaleInvoice dSSale, DateTime date,int ID)
        {
            return new DAL.SaleInvoiceDAL().GetReportData(ref dSSale,date,ID);
        }
        public List<SaleInvoice> GetAllSale(int id)
        {
            return new SaleInvoiceDAL().GetAllSale(id);
        }

        public bool GetValuationSale(ref DSValuationSale dSValuationSale, string fromDate,string toDate,int branchid, List<Branch> counters, List<ChartOfAccounts> vendor)
        {
            return new DAL.SaleInvoiceDAL().GetValuationSale(ref dSValuationSale, fromDate, toDate, branchid, counters, vendor);
        }

        public bool GetInventoryValuation(ref DSInventoryValuation dSInventory, string fromDate, string toDate, int branchID)
        {
            return new DAL.SaleInvoiceDAL().GetInventoryValuation(ref  dSInventory,  fromDate,  toDate,  branchID);
        }

        public bool SavePrinter(string v, int branchid)
        {
            return new DAL.SaleInvoiceDAL().SavePrinter( v, branchid);
        }

        public string GetPrinterName(int branchid)
        {
            return new DAL.SaleInvoiceDAL().GetPrinterName(branchid);
        }

        public bool GetInventoryMIS(ref DSMIS dSMIS,string categoryid,List<ChartOfAccounts> LstVendors )
        {
            return new DAL.SaleInvoiceDAL().GetInventoryMIS(ref  dSMIS, categoryid,LstVendors );
        }

        public List<SaleInvoice> GetSingleSale(int ID, DateTime date)
        {
            return new DAL.SaleInvoiceDAL().GetSingleSale(ID, date);
        }

        public int UpdateSaleforSummary(SaleInvoice sale, bool isNew)
        {
            return new DAL.SaleInvoiceDAL().UpdateSaleforSummary(sale, isNew);
        }

        public bool GetCCSaleSummary(ref DSCCSaleSummary dSCC, string fromDate, string toDate, int branchid, string bank)
        {
            return new DAL.SaleInvoiceDAL().GetCCSaleSummary(ref  dSCC,  fromDate,  toDate,  branchid,  bank);
        }

        public bool GetPhoneBook(ref DSPhoneBook dSPhoneBook)
        {
            return new DAL.SaleInvoiceDAL().GetPhoneBook(ref  dSPhoneBook);
        }

        public SaleInvoice GetSelectedSale(int id,int branchid)
        {
            return new DAL.SaleInvoiceDAL().GetSelectedSale( id, branchid);
        }
    }
}
