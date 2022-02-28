using Common;

namespace DAL
{
    internal class PurchaseInvoiceLine
    {
        private Item i;
        private bool v1;
        private Store s;
        private decimal v2;
        private decimal v3;
        private int v4;
        private bool v5;
        private decimal v6;
        private decimal v7;
        private decimal v8;
        private decimal v9;

        public PurchaseInvoiceLine(Item i, bool v1, Store s, decimal v2, decimal v3, int v4, bool v5, decimal v6, decimal v7, decimal v8, decimal v9)
        {
            this.i = i;
            this.v1 = v1;
            this.s = s;
            this.v2 = v2;
            this.v3 = v3;
            this.v4 = v4;
            this.v5 = v5;
            this.v6 = v6;
            this.v7 = v7;
            this.v8 = v8;
            this.v9 = v9;
        }
    }
}