using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Common;

namespace DAL
{
    public class SummaryRptDAL
    {
        private string source = ReadProjectConfigFile.ConfigString();
        SqlConnection con;
        SqlCommand cmd;

        SqlDataAdapter da = new SqlDataAdapter();

        public bool GetData(ref Common.Data_Sets.DSSummary ds, Int64 sumNo,string where)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();

                string select;

                select = "Select Title,VoucherNo,VoucherDate,Sum(IsNull(totalAmt,0))as TotalAmt,Sum(IsNull(TotalDiscount,0))as TotalDiscount,Sum(Paid) as Paid,VoucherType,SummaryNo,UserName  from (Select 'Petty Cash' as title,0 as VoucherNo,SummaryDate as VoucherDate,sum(Cash) as totalAmt,0 as TotalDiscount,0 as paid,'' as VoucherType,SummaryNo,UserName from  Summary inner join Users U on U.UserNO=Summary.UserID where SummaryNo=" + sumNo + " Group By SummaryDate,SummaryNo,username Union All select 'Sale Invoice' as Title,SaleID as VoucherNo,SaleDate as VoucherDate,TotalAmt,TotalDiscount,AmtPaid+CreditCardAmount as Paid,'SI' as VoucherType,S.SummaryNo,UserName  from SaleInvoice SI inner join Summary S on S.SummaryNo=SI.SummaryNo inner join Users U on U.UserNO=S.UserID where S.summaryno=" + sumNo + " Union All Select 'Cash Payment',AV.voucherno,AV.voucherdate,-sum(amount),0,-sum(amount),   'CPV' as VoucherType  ,S.SummaryNo,UserName from AccVouchersbody AV Inner Join (Select VoucherNo,VoucherDate,Sum(Debit) as Amount from AccVouchersBody where VoucherType='CPV' Group By VoucherNo,VoucherDate)AVB on AVB.Voucherno=AV.Voucherno and AVB.VoucherDate=AV.VoucherDate inner join Summary S on S.SummaryNo=AV.SummaryNo inner join Users U on U.UserNO=S.UserID Where S.SummaryNo=" + sumNo + " and AV.VoucherType='CPV' Group by AV.voucherno,AV.voucherdate,S.SummaryNo,UserName  Union All Select 'Cash Recieved',AV.voucherno,AV.voucherdate,sum(amount),0,sum(amount),'CRV' as VoucherType,S.SummaryNo,UserName  from AccVouchersbody AV Inner Join (Select VoucherNo,VoucherDate,Sum(Credit) as Amount from AccVouchersBody where VoucherType='CRV' Group By VoucherNo,VoucherDate)AVB on AVB.Voucherno=AV.Voucherno  and AVB.VoucherDate=AV.VoucherDate inner join Summary S on S.SummaryNo=AV.SummaryNo inner join Users U on U.UserNO=S.UserID Where S.SummaryNo=" + sumNo + " and AV.VoucherType='CRV' Group by AV.voucherno,AV.voucherdate,S.SummaryNo,UserName)Main where 1=1 " + where + " Group By title,VoucherNo,VoucherDate,voucherType,summaryNo,UserName Order By VoucherDate ";//VoucherNo

                cmd = new SqlCommand(select, con);

                da.SelectCommand = cmd;

                da.Fill(ds, "Summary");

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
