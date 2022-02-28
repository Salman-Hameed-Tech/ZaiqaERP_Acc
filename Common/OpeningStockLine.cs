using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class OpeningStockLine
    {
        public int ID { get; set; }
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public int PartyID { get; set; }
        public string PartyName { get; set; }
        public decimal Quantity { get; set; }
        public DateTime Dated { get; set; }
        public int SrNo { get; set; }

        public List<OpeningStockLine> openingstocklines { get; set; }
    }
}