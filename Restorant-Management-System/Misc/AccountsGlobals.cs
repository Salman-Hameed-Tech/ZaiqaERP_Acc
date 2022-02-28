using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows .Forms ;
using Common;
using System.Drawing;
using CategoryControlle;
using System.IO;
using Microsoft.Reporting.WinForms;

namespace Accounts
{
   public  class AccountsGlobals
    {
       public static System.Drawing.Color FormColor = System.Drawing.Color.Gainsboro;
       public static Font HeadingStyle = new Font("Monotype Corsiva", 35, FontStyle.Italic);       
       public static List<UserRight> UserRights = new List<UserRight>();
        public static int DateRights = 42;
        public static DateTime ServerDate; 
       static int FormID;

        public static Font Font { get; internal set; }

        private static   bool FindFormID(UserRight right)
       {
           return (right.RightID == FormID);
       }

       public static byte[] imageToByteArray(System.Drawing.Image imageIn)
       {
           MemoryStream ms = new MemoryStream();
           imageIn.Save(ms, imageIn.RawFormat);
           return ms.ToArray();
       }

       public static Image byteArrayToImage(byte[] byteArrayIn)
       {
           MemoryStream ms = new MemoryStream(byteArrayIn);
           Image returnImage = Image.FromStream(ms);
           return returnImage;
       }

       public static UserRight FormRights(int formID)
       {
           FormID = formID;
           if (User._IsAdmin)
           {
              return  new UserRight(0, "", true, true, true);             
           }
            bool S = true;
            S=Convert.ToBoolean(AccountsGlobals.UserRights.Find(FindFormID));
            return AccountsGlobals.UserRights.Find(FindFormID); 
       }

       public static void ShowCmsOnLeftClick(object sender, MouseEventArgs e)
       {
           if (e.Button == MouseButtons.Left)
           {
               if (((Control)sender).ContextMenuStrip != null)
               {
                   ((Control)sender).ContextMenuStrip.Show(Cursor.Position, ToolStripDropDownDirection.BelowRight);
               }
           }
       }

       //public static   string CreateAccount(string accountName,string parentAccount, AccountType accountType, string nameExtension)
       //{
       //    try
       //    {

       //        ChartOfAccounts acc = new ChartOfAccounts();
       //        string accountExtension = new ChartofAccountsController().GetAccountExtension(parentAccount, accountType.ToString());

       //        if (accountExtension.Trim().Length == 0)
       //        {
       //            accountExtension = "001";
       //        }

       //        acc = new ChartofAccountsController().GetAccountDetail(parentAccount, "");

       //        acc = new ChartOfAccounts();

       //        acc.IsDetailed = true;

       //        acc.AccountDepth = new ChartofAccountsController ().GetAccountDepth (parentAccount) ;
       //        acc.AccountName = accountName.Trim() + " " + nameExtension;
       //        acc.AccountNo = parentAccount + accountExtension;
       //        //acc.AccountType = (AccountType)Enum.Parse(typeof(AccountType), this.txtAccountType.Text, true);
       //        acc.AccountType = accountType;
       //        acc.AdjustedCredit = 0;
       //        acc.AdjustedDebit = 0;
       //        acc.Narration = "";
       //        acc.BalFlag = false;
       //        acc.ExpFlag = false;
       //        acc.IsEditable = true;
       //        acc.IsLocked = false;
       //        acc.IsPosted = false;
       //        acc.OpeningCredit = 0;
       //        acc.OpeningDebit = 0;
       //        acc.ParentAccount = new ChartOfAccounts(parentAccount, "");
       //        acc.PlFlag = "-";

       //        new ChartofAccountsController().SaveAccount(acc);

       //        return acc.AccountNo;
       //    }
       //    catch (Exception ex)
       //    {
       //        MessageBox.Show(ex.Message, "FrmNewAccount SaveAccount", MessageBoxButtons.OK, MessageBoxIcon.Error);
       //        return null;
       //    }
       //}


       public static void SetGridStyle(ref DGV.DGV Grd)
       {         
           try
           {
              
              Grd.Columns.Clear();
               //Grd.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
               //Grd.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
               //Grd.ColumnHeadersDefaultCellStyle.Font = new Font(Grd.Font, FontStyle.Bold);
               //Grd.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
               //Grd.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
               //Grd.CellBorderStyle = DataGridViewCellBorderStyle.Single;
               //Grd.GridColor = Color.Black;


               Grd.RowsDefaultCellStyle.BackColor = System.Drawing.Color.Lavender;
               Grd.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Honeydew;
               Grd.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
               Grd.ColumnHeadersDefaultCellStyle.Font = new Font(Grd.Font, FontStyle.Bold);
               Grd.DefaultCellStyle.Font = new Font(Grd.Font, FontStyle.Regular );
               Grd.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SteelBlue;
               Grd.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
               Grd.CellBorderStyle = DataGridViewCellBorderStyle.Single;
             
             
               Grd.AllowUserToResizeColumns = false;               
               Grd.MultiSelect = false;
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message, "SetGridStyle", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
       }


       public static void ExtendCol(ref DGV.DGV grd, string colName)
       {
           try
           {
               //Extand given column to cover whole grid.It should have been done in a better way :(
               ////////////////////////////////////////////////////////////////////////////////////////
               grd.Columns[colName].Visible = false;
               //grd.Columns[colName ].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
               //grd.Columns[colName ].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

               int columnsSize = 0;
               for (int i = 0; i < grd.Columns.Count; i++)
               {
                   if (grd.Columns[i].Visible)
                   {
                       columnsSize += grd.Columns[i].Width;
                   }
               }
               grd.Columns[colName].Visible = true;

               if (grd.Width - grd.RowHeadersWidth - columnsSize - 2 > 0)
               {
                   grd.Columns[colName].Width = grd.Bounds .Width  - grd.RowHeadersWidth - columnsSize - 2;
               }
               ////////////////////////////////////////////////////////////////////////////////////////
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message, "SetLastRow", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
       }

        public static void PrintVoucher(string p, Voucher voucher, VoucherType voucherType)
        {
            try
            {
                System.Data.DataRow VRow;
                Common.Data_Sets.DSVoucher dsVoucher = new Common.Data_Sets.DSVoucher();


                Restorant_Management_System.Report_Forms.frmViewer Viewer = new Restorant_Management_System.Report_Forms.frmViewer();
                Viewer.reportViewer1.Reset();
                if(new VoucherController().GetData(ref dsVoucher, voucher))
                {
                    if (dsVoucher.Tables["Voucher"].Rows.Count > 0)
                    {
                        ReportDataSource rds = new ReportDataSource("DataSet1", dsVoucher.Tables["Voucher"]);
                        Viewer.reportViewer1.LocalReport.DataSources.Add(rds);                  
                        Viewer.reportViewer1.LocalReport.ReportEmbeddedResource = "Restorant_Management_System.Report.RptJournalVoucher.rdlc";

                        #region Condistion
                        if (voucherType == VoucherType.CRV)
                        {
                            ReportParameter[] rptParams = new ReportParameter[]
                                  {
                                        new ReportParameter("VoucherType","Cash Receiving Voucher"),
                                          new ReportParameter("UserName",User._UserName),
                                  };
                            Viewer.reportViewer1.LocalReport.SetParameters(rptParams);
                        }
                        if (voucherType == VoucherType.BCV)
                        {
                            ReportParameter[] rptParams = new ReportParameter[]
                                  {
                                        new ReportParameter("VoucherType","Bank Credit Voucher"),
                                          new ReportParameter("UserName",User._UserName),
                                  };
                            Viewer.reportViewer1.LocalReport.SetParameters(rptParams);
                        }
                        if (voucherType == VoucherType.BRV)
                        {
                            ReportParameter[] rptParams = new ReportParameter[]
                                 {
                                        new ReportParameter("VoucherType","Bank Receiving Voucher"),
                                        new ReportParameter("UserName",User._UserName),
                                 };
                            Viewer.reportViewer1.LocalReport.SetParameters(rptParams);
                        }
                        if (voucherType == VoucherType.BDV)
                        {
                            ReportParameter[] rptParams = new ReportParameter[]
                                {
                                        new ReportParameter("VoucherType","Bank Debit Voucher"),
                                        new ReportParameter("UserName",User._UserName),
                                };
                            Viewer.reportViewer1.LocalReport.SetParameters(rptParams);
                        }
                        else if (voucherType == VoucherType.CPV)
                        {
                            ReportParameter[] rptParams = new ReportParameter[]
                               {
                                        new ReportParameter("VoucherType","Cash Payment Voucher"),
                                        new ReportParameter("UserName",User._UserName),
                               };
                            Viewer.reportViewer1.LocalReport.SetParameters(rptParams);
                        }
                        else if (voucherType == VoucherType.BPV)
                        {
                            ReportParameter[] rptParams = new ReportParameter[]
                              {
                                        new ReportParameter("VoucherType","Bank Payment Voucher"),
                                        new ReportParameter("UserName",User._UserName),
                              };
                            Viewer.reportViewer1.LocalReport.SetParameters(rptParams);
                        }
                        else if (voucherType == VoucherType.JV)
                        {
                            ReportParameter[] rptParams = new ReportParameter[]
                             {
                                        new ReportParameter("VoucherType","Journal Voucher"),
                                        new ReportParameter("UserName",User._UserName),
                             };
                            Viewer.reportViewer1.LocalReport.SetParameters(rptParams);

                        }
                        else if (voucherType == VoucherType.LPJ)
                        {
                            ReportParameter[] rptParams = new ReportParameter[]
                            {
                                        new ReportParameter("VoucherType","Purchase Voucher"),
                                        new ReportParameter("UserName",User._UserName),
                            };
                            Viewer.reportViewer1.LocalReport.SetParameters(rptParams);
                        }
                        else if (voucherType == VoucherType.FPJ)
                        {
                            ReportParameter[] rptParams = new ReportParameter[]
                           {
                                        new ReportParameter("VoucherType","Purchase Voucher"),
                                        new ReportParameter("UserName",User._UserName),
                           };
                            Viewer.reportViewer1.LocalReport.SetParameters(rptParams);
                        }
                        else if (voucherType == VoucherType.SJV)
                        {
                            ReportParameter[] rptParams = new ReportParameter[]
                          {
                                        new ReportParameter("VoucherType","Sale Voucher"),
                                        new ReportParameter("UserName",User._UserName),
                          };
                            Viewer.reportViewer1.LocalReport.SetParameters(rptParams);

                        }
                        else if (voucherType == VoucherType.SRV)
                        {
                            ReportParameter[] rptParams = new ReportParameter[]
                         {
                                        new ReportParameter("VoucherType","Sale Return Voucher"),
                                        new ReportParameter("UserName",User._UserName),
                         };
                            Viewer.reportViewer1.LocalReport.SetParameters(rptParams);

                        }
                        else if (voucherType == VoucherType.PRV)
                        {
                            ReportParameter[] rptParams = new ReportParameter[]
                           {
                                        new ReportParameter("VoucherType","Purchase Return Voucher"),
                                        new ReportParameter("UserName",User._UserName),
                           };
                            Viewer.reportViewer1.LocalReport.SetParameters(rptParams);

                        }

                        #endregion

                        Viewer.reportViewer1.LocalReport.Refresh();
                        Viewer.ShowDialog();      
                    }

                }


               

              

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmVoucher PrintVoucher", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public static void CreateAccountForm(AccountType accountType, string accountExtension)
        {
            try
            {
                if ((AccountsGlobals.FormRights(45).CanAccess))
                {
                    if (accountType == AccountType.Party)
                    {
                        FrmParty frm = new FrmParty();

                        frm.Opt = 2;
                        frm.Operation = 1;
                        frm.IsDetailed = 1;
                        frm.chkPurchase.Checked = true;
                        frm.chkSale.Checked = true;

                        frm.txtAccountType.Text = accountType.ToString();
                        frm.txtParentAccount.Text = accountExtension;
                        frm.ShowDialog();
                    }
                    else
                    {
                        FrmNewAccount frm = new FrmNewAccount();

                        frm.Opt = 2;
                        frm.Operation = 1;
                        frm.IsDetailed = 1;

                        frm.txtAccountType.Text = accountType.ToString();
                        frm.txtParentAccount.Text = accountExtension;
                        frm.ShowDialog();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "CreateAccountForm", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void  ShowItemCreation()
        {
            try
            {
                if ((AccountsGlobals.FormRights(4).CanAccess))
                {
                   // Forms.FrmItem frm = new Forms.FrmItem();
                    //frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ShowItemCreation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
