using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class ClaimInvoice
    {

        public int ID { get; set; }
        public ClaimInvoiceType Type { get; set; }
        public DateTime Dated { get; set; }
        public int BranchID { get; set; }
        public ChartOfAccounts Party { get; set; }
        public ChartOfAccounts SalesMan { get; set; }
        public string Remarks { get; set; }
        public int CreatedBy { get; set; }
        public decimal TotalAmt { get; set; }
        public string InvoiceNo { get; set; }
        public bool IsAdjEntry { get; set; }
        public List<ClaimInvoiceLine > ClaimLines;

        public ClaimInvoice()
        {

        }

        public ClaimInvoice(int id, ChartOfAccounts party,ClaimInvoiceType type, string remarks, int createdBy, decimal totalAmt, DateTime dated)
        {
            this.ID = id;            
            this.Dated = dated;
            this.Party = party;
            this.Remarks = remarks;
            this.CreatedBy = createdBy;
            this.TotalAmt = totalAmt;
            this.Type = type;

        }


    }
}
