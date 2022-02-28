using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class Item
    {
        //Fields.
        private string sticker;
        public string PrintName { get; set; }
        public string CompanyName { get; set; }
        public string PartyID { get; set; }
        public string PartyName { get; set; }
        public bool IsMarinated { get; set; }
        public int BranchID { get; set; }
        public string BarCode
        {
            get { return barCode; }
            set { barCode = value; }
        }
        public string Sticker
        {
            get { return sticker; }
            set { sticker = value; }
        }
      
        public bool IsBakeryItem { get; set; }
        private double OpQty;

        public double OpQty1
        {
            get { return OpQty; }
            set { OpQty = value; }
        }
        private double Purprice;

        public double Purprice1
        {
            get { return Purprice; }
            set { Purprice = value; }
        }
        private int itemID;


        public List<Item> ReceipeList = new List<Item>();

        public  List<String > barcode =new List<string>() ;

        private decimal purchasePrice;
        private decimal salePrice;
        private decimal discountLimit;
        private double   reorderLimit;
        private ChartOfAccounts saleAccount;
        private ChartOfAccounts purchaseAccount;
        private Category category;
        private ItemName itemName;

        private string barCode;        
        private Boolean isActive;
        private bool addToPrint;
        private string unit;

        public int CategoryID { get; set; }
        public string ItemNameb;
        

        public static string condition;

        public Int32 CounterID { get; set; }
        public Int32 DepartmentID { get; set; }
        public string Seasons { get; set; }
        public string Color { get; set; }
        public decimal MarginAmt { get; set; }
        public decimal Quantity { get; set; }
        public string Itemname { get; set; }
        public string CategoryName { get; set; }
        public string Unit
        {
            get { return unit; }
            set { unit = value; }
        }

        public bool AddToPrint
        {
            get { return addToPrint; }
            set { addToPrint = value; }
        }

        private decimal currentStock;

        public decimal CurrentStock
        {
            get { return currentStock; }
            set { currentStock = value; }
        }

        
        //Constructors.
        public Item()
        { 
          
        }
        public Item(int itemID)
        {
            this.ItemID = itemID;            
        }       
        public Item(int itemID, ItemName itemName)
        {
            this.ItemID = itemID;           
            this.ItemName = itemName;           
        }

        public Item(int itemId, ItemName itemName, decimal currentStock)
            : this()
        {
            this.itemID = itemId;
            this.ItemName = itemName;
            this.currentStock = currentStock;
        }
        public Item(int itemId, ItemName itemName, decimal currentStock,double reorderLimit)
            : this()
        {
            this.itemID = itemId;
            this.ItemName = itemName;
            this.currentStock = currentStock;
            this.reorderLimit = reorderLimit;
        }
        public Item(int itemId, ItemName itemName, decimal currentStock, decimal discountLimit)
            : this()
        {
            this.itemID = itemId;
            this.ItemName = itemName;
            this.currentStock = currentStock;
            this.discountLimit = discountLimit;
        }
        public Item(int itemId, ItemName itemName, string barCode, string shortKey)
            : this()
        {
            this.itemID = itemId;
            this.ItemName = itemName;
            this.barCode = barCode;
            this.shortKey = shortKey;
        }

        public Item(int itemID,Category category,ItemName itemName,decimal purhcasePrice,decimal salePrice,decimal discountLimit, decimal  reorderLimit,ChartOfAccounts saleAccount,ChartOfAccounts purchaseAccount,Boolean isActive,string shortkey,bool addToPrint)
        {
            this.ItemID = itemID;
            this.Category = category;
            this.ItemName = itemName;
            this.PurchasePrice = purhcasePrice ;
            this.SalePrice = salePrice;            
            this.DiscountLimit = discountLimit;
            this.ReorderLimit = (double ) reorderLimit;
            this.PurchaseAccount = purchaseAccount;
            this.SaleAccount = saleAccount;
            this.isActive = isActive;
            this.shortKey = shortkey;
            this.addToPrint = addToPrint;
        }
        public Item(int itemID, string Sticker, decimal salePrice, Barcode barcode, double OpQty)
        {
            this.itemID = itemID;
            this.Sticker = sticker;
            this.salePrice = salePrice;
                        this.OpQty = OpQty;
        }

        public Item(int itemID, int categoryid, ItemName itemName, decimal purhcasePrice, decimal salePrice, decimal discountLimit, decimal reorderLimit, ChartOfAccounts saleAccount, ChartOfAccounts purchaseAccount, Boolean isActive, string shortkey, double OpQty, Double PurPrice, string Sticker, bool addToPrint)
        {
            this.ItemID = itemID;
            this.CategoryID = categoryid;
            this.ItemName = itemName;
            this.PurchasePrice = purhcasePrice;
            this.SalePrice = salePrice;
            this.DiscountLimit = discountLimit;
            this.ReorderLimit = (double)reorderLimit;
            this.PurchaseAccount = purchaseAccount;
            this.SaleAccount = saleAccount;
            this.IsActive = isActive;
            this.shortKey = shortkey;
            this.OpQty = OpQty;
            this.Purprice = PurPrice;
            this.sticker = Sticker;
            this.addToPrint = addToPrint;
          
        }
        public Item(int itemID, Category category, ItemName itemName, decimal purhcasePrice, decimal salePrice, decimal discountLimit, decimal reorderLimit, ChartOfAccounts saleAccount, ChartOfAccounts purchaseAccount, Boolean isActive, string shortkey, double OpQty, Double PurPrice, Boolean isLocked, string sticker, double currentstock, bool addToPrint)
        {
            this.ItemID = itemID;
            this.Category = category;
            this.ItemName = itemName;
            this.PurchasePrice = purhcasePrice;
            this.SalePrice = salePrice;
            this.DiscountLimit = discountLimit;
            this.ReorderLimit = (double)reorderLimit;
            this.PurchaseAccount = purchaseAccount;
            this.SaleAccount = saleAccount;
            this.IsActive = isActive;
            this.shortKey = shortkey;
            this.OpQty = OpQty;
            this.Purprice = PurPrice;
            this.isloacked = isLocked;
            this.sticker = sticker;
            this.CurrentStock = Convert.ToDecimal ( currentstock);
            this.addToPrint = addToPrint;
        }       
               
        

        //Properties.
        private Boolean isloacked;

        public Boolean Isloacked
        {
            get { return isloacked; }
            set { isloacked = value; }
        }
        public int ItemID
        {
            get { return itemID; }
            set { itemID = value; }
        }       

        public decimal PurchasePrice
        {
            get { return purchasePrice; }
            set { purchasePrice = value; }
        }       

        public decimal SalePrice
        {
            get { return salePrice; }
            set { salePrice = value; }
        }        
        
            
private Boolean isactive;
public Boolean Isactive
{
  get { return isactive; }
  set { isactive = value; }
}
        private string shortKey;
        

public string ShortKey
{
  get { return shortKey; }
  set { shortKey = value; }
}public decimal DiscountLimit
        {
            get { return discountLimit; }
            set { discountLimit = value; }
        }        

        public double ReorderLimit
        {
            get { return reorderLimit; }
            set { reorderLimit = value; }
        }       

        public ChartOfAccounts PurchaseAccount
        {
            get { return purchaseAccount; }
            set { purchaseAccount = value; }
        }        

        public ChartOfAccounts SaleAccount
        {
            get { return saleAccount; }
            set { saleAccount = value; }
        }

        public Boolean IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }


        public ItemName ItemName
        {
            get
            {
                return this.itemName;
            }
            set
            {
                this.itemName = value;
            }
        }

        public Category Category
        {
            get
            {
                return this.category;
            }
            set
            {
                this.category = value;
            }
        }
        
        //Methods.
        public override string ToString()
        {
            return ItemName.ToString ();
        }
        public string DepartName { get; set; }
        public override bool Equals(object obj)
        {            
            Item it = obj as Item;
            if (it==null)
            {
                return false;
            }
            return (this.itemID == it.itemID);
        }
        public Item(int itemID, Category category, ItemName itemName, decimal purhcasePrice, decimal salePrice, decimal discountLimit, decimal reorderLimit, ChartOfAccounts saleAccount, ChartOfAccounts purchaseAccount, Boolean isActive, string shortkey, double OpQty, Double PurPrice, bool addToPrint, string unit)
        {
            this.ItemID = itemID;
            this.Category = category;
            this.ItemName = itemName;
            this.PurchasePrice = purhcasePrice;
            this.SalePrice = salePrice;
            this.DiscountLimit = discountLimit;
            this.ReorderLimit = (double)reorderLimit;
            this.PurchaseAccount = purchaseAccount;
            this.SaleAccount = saleAccount;
         //   this.SaleTaxAccount = saleTaxAccount;
            this.IsActive = isActive;
            this.shortKey = shortkey;
            this.OpQty = OpQty;
            this.Purprice = PurPrice;
            this.sticker = Sticker;
            this.addToPrint = addToPrint;
            this.Unit = unit;
          //  this.Packing = packing;
         //   this.Multiplier = Multiplier;
          //  this.Origin = origin;

           // this.DisplayName = itemName.ToString();
        }
        public Item(int itemID, Category category, ItemName itemName, decimal purhcasePrice, decimal salePrice, decimal discountLimit, decimal reorderLimit, ChartOfAccounts saleAccount, ChartOfAccounts purchaseAccount, Boolean isActive, string shortkey, double OpQty, Double PurPrice, Boolean isLocked, string sticker, double currentstock, bool addToPrint,string departname)
        {
            this.ItemID = itemID;
            this.Category = category;
            this.ItemName = itemName;
            this.PurchasePrice = purhcasePrice;
            this.SalePrice = salePrice;
            this.DiscountLimit = discountLimit;
            this.ReorderLimit = (double)reorderLimit;
            this.PurchaseAccount = purchaseAccount;
            this.SaleAccount = saleAccount;
            this.IsActive = isActive;
            this.shortKey = shortkey;
            this.OpQty = OpQty;
            this.Purprice = PurPrice;
            this.isloacked = isLocked;
            this.sticker = sticker;
            this.CurrentStock = Convert.ToDecimal(currentstock);
            this.addToPrint = addToPrint;
            this.DepartName = departname;
        }

    }
}
