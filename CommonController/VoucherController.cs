using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Common;
using System.Data;

namespace CategoryControlle
{
   public  class VoucherController
    {
       public int GetMaximumID(Voucher v)
       {
           return new VoucherDAL ().GetMaximumID(v);
       }
        public DataSet GetVoucherData(int ID,Voucher v)
        {
            return new DAL.VoucherDAL().GetVoucherData(ID,v);
        }
        public int GetMaximumIDD(PDCVoucher v) 
       {
           return new VoucherDAL().GetMaximumIDD(v); 
       }

       public int SaveVoucher(Voucher  voucher, bool isNew)
       {
           return new VoucherDAL ().SaveVoucher(voucher, isNew);
       }
       public int SavepdcVoucher(PDCVoucher voucher, bool isNew)
       {
           return new VoucherDAL().SavepdcVoucher(voucher, isNew);
       }
       public bool SaveClearance(Voucher v, bool isNew)
       {
           return new VoucherDAL().SaveClearance(v, isNew);
       }

       public bool CloseMonth(bool close, DateTime date)
       {
           return new VoucherDAL().CloseMonth(close, date);
       }
       public bool CheckCloseMonth(DateTime  date)
       {
           return new VoucherDAL().CheckCloseMonth(date);
       }

       public bool SetPrinted(int voucherNo, VoucherType type,bool setPrinted,bool isNew)
       {
           return new VoucherDAL().SetPrinted(voucherNo, type,setPrinted,isNew );
       }

       public bool  CheckVoucherEntry(int voucherNo, VoucherType voucherType)
       {
           return new VoucherDAL().CheckVoucherEntry(voucherNo, voucherType); 
       }

       public List<Voucher> GetVouchers(Voucher v,bool isPrinted,bool isPosted)
       {
           return new VoucherDAL().GetVouchers( v,isPrinted ,isPosted  );
       }
       public List<PDCVoucher> GetpdcVouchers(PDCVoucher v, bool isPrinted, bool isPosted)
       {
           return new VoucherDAL().GetpdcVouchers(v, isPrinted, isPosted);
       }
       public Voucher GetPDCCheck(Voucher v)
       {
           return new VoucherDAL().GetPDCCheck(v);
       }

       public bool DeleteVoucher(Voucher v)
       {
           return new VoucherDAL ().DeleteVoucher(v);
       }

        public List<VoucherInvoice> GetInvoices(string accountNo,TransactionFlow flow)
        {
            return new VoucherDAL().GetInvoices(accountNo ,flow );
        }

        public int PostVoucher(VoucherType type,DateTime voucherDate, string bankAccountNo, int refNo, bool post)
        {
            return new VoucherDAL().PostVoucher(type,voucherDate,bankAccountNo , refNo,post );
        }

        public bool GetData(ref Common.Data_Sets.DSVoucher ds, Voucher v)
        {
            return new VoucherDAL().GetData(ref ds, v);
        }

        public bool SearchVoucher(ref Common.Data_Sets.DSAccLedger ds, string where)
        {
            return new VoucherDAL().SearchVoucher(ref ds, where);
        }

        public bool  SetPostDatedVoucher(List <Voucher> vouchers)
        {
            return new VoucherDAL().SetPostDatedVoucher(vouchers);
        }
    
    }
}
