using Common;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restorant_Management_System.Forms
{
    public partial class FrmExcelDiscount : Form
    {
        DataTable tables = new DataTable();
        DiscountOffer offer=new DiscountOffer();
        List<DiscountOffer> offerList = new List<DiscountOffer>();
        public FrmExcelDiscount()
        {
            InitializeComponent();
        }

        private void btnBrowes_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Excel 97-2003 Workbook|*.xls|Excel Workbook|*.xlsx" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtFileNmae.Text = ofd.FileName;
                    using (var stream = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            DataSet data = reader.AsDataSet(new ExcelDataSetConfiguration() { ConfigureDataTable = __ => new ExcelDataTableConfiguration() { UseHeaderRow = true } });
                           
                            tables = data.Tables[0];
                            PopulateData(tables);
                            Grd.DataSource = offerList;


                        }
                    }
                }
            }
        }

        private void PopulateData(DataTable dt)
        {
            Common.Item it;
            Category c;
          

            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                it = new Item(0, new ItemName(Convert.ToString(dt.Rows[i]["COMPANYNAME"]), Convert.ToString(dt.Rows[i]["PRODUCTNAME"]), Convert.ToString(dt.Rows[i]["DESIGN"]), Convert.ToString(dt.Rows[i]["SIZE"])));

                c = new Category(Convert.ToInt32(dt.Rows[i]["CATEGORYID"]), "");

                offer = new DiscountOffer(0, c, it, Convert.ToDecimal(dt.Rows[i]["DISCOUNT"]), Convert.ToBoolean(1), Convert.ToDateTime(dt.Rows[i]["FROMDATE"]), Convert.ToDateTime(dt.Rows[i]["TODATE"]), null, null);

                //DiscountOffer offer = new DiscountOffer();
                //offer.Item.ItemName = new ItemName(dt.Rows[i]["COMPANYNAME"].ToString(), dt.Rows[i]["PRODUCTNAME"].ToString(), dt.Rows[i]["DESIGN"].ToString(), dt.Rows[i]["SIZE"].ToString(), "");

                //offer.Branchid = Convert.ToInt32(dt.Rows[i]["BRANCHID"]);
                //offer.CatID = Convert.ToInt32(dt.Rows[i]["CATEGORYID"]);


                //offer.ItemName = dt.Rows[i]["ITEMNAME"].ToString();

                //offer.Discount = Convert.ToDecimal(dt.Rows[i]["DISCOUNT"]);

                //offer.FromDate = Convert.ToDateTime(dt.Rows[i]["FROMDATE"]);
                //offer.ToDate = Convert.ToDateTime(dt.Rows[i]["TODATE"]);
                offerList.Add(offer);
            }
          
        }

        private void txtFileNmae_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
