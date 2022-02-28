using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restorant_Management_System.Report_Forms
{
    public partial class frmViewer : Form
    {
        public frmViewer()
        {
            InitializeComponent();
        }

        private void frmViewer_Load(object sender, EventArgs e)
        {
           // this.reportViewer1.LocalReport.ReportEmbeddedResource = "Restorant-Management-System.Report.RptPurchaseInvoice.rdlc";
            this.reportViewer1.RefreshReport();
          
        }

        private void reportViewer1_Resize(object sender, EventArgs e)
        {
            //ReportPageSettings rps = reportViewer1.LocalReport.GetDefaultPageSettings();
            //if (reportViewer1.ParentForm.Width > rps.PaperSize.Width)
            //{
            //    int hPad = (reportViewer1.ParentForm.Width - rps.PaperSize.Width)/4;
            //    reportViewer1.Padding = new Padding(hPad, 1, hPad, 1);
            //}
        }
    }
}
