using Common;
using CategoryControlle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Accounts.Forms
{
    public partial class FrmFixedAccounts : Form
    {
        public FrmFixedAccounts()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowSearch(ref TxtPDiscNo, ref TxtPDiscName);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ShowSearch(ref TxtSaleNo , ref TxtSaleName);
        }
        private void VerifyAcc(ref System.Windows.Forms.TextBox txtno, ref System.Windows.Forms.TextBox txtname)
        {
            ChartOfAccounts Ca;
            Ca = new ChartofAccountsController().GetAccountDetail(txtno.Text, " and isdetailed=1");
            if (Ca == null)
            {
                txtno.Clear();
                ShowSearch(ref txtno, ref txtname);
            }

            else
            {
                txtno.Text = Ca.AccountNo;
                txtname.Text = Ca.AccountName;
            }
        }


        private void BtnCash_Click(object sender, EventArgs e)
        {
            ShowSearch(ref TxtCashNo, ref TxtCashName);
        }
        private void ShowSearch(ref System.Windows.Forms.TextBox txtno, ref System.Windows.Forms.TextBox txtname)
        {
            try
            {
                SchForms.SchAccounts Sch = new SchForms.SchAccounts();
                Sch.ShowDialog();
                if (Sch.SelectedAccount != null)
                {
                    txtno.Text = Sch.SelectedAccount.AccountNo;
                    txtname.Text = Sch.SelectedAccount.AccountName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnPurR_Click(object sender, EventArgs e)
        {
            ShowSearch(ref TxtPurNo, ref TxtPurName);
        }

        private void TxtCashNo_Validated(object sender, EventArgs e)
        {
            if (TxtSaleNo.Text.ToString().Trim().Length == 0) return;
            VerifyAcc(ref TxtCashNo, ref TxtCashName);
        }

        private void TxtPurNo_Validated(object sender, EventArgs e)
        {
            if (TxtPurNo.Text.ToString().Trim().Length == 0) return;
            VerifyAcc(ref TxtPurNo, ref TxtPurName);
        }

        private void TxtPDiscNo_Validated(object sender, EventArgs e)
        {
            if (TxtPDiscNo.Text.ToString().Trim().Length == 0) return;
            VerifyAcc(ref TxtPDiscNo, ref TxtPDiscName); ;
        }

    
        private void saverec()
        {
            try
            {

            
            FixedAccounts objfx = new FixedAccounts();
            objfx.CashAcc1 = Convert.ToString( TxtCashNo.Text  );
            objfx.PurRet1 = Convert.ToString( TxtPurNo.Text   );
            objfx.PurDisc1 = Convert.ToString( TxtPDiscNo.Text  );
            objfx.SaleDisc1 = Convert.ToString( TxtSaleNo.Text  );
            objfx.SaleReturn1 = Convert.ToString( TxtSaleRNo.Text  );
            objfx.Transit = txtTransitNo.Text.Trim();
            FixedAccountController ObjFx = new FixedAccountController();
            if (ObjFx.SaveFixAcc(objfx) == true)
                MessageBox.Show("Successfully Saved", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,"Error" , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowSearch(ref TxtSaleRNo, ref TxtSaleRName);
        }

        private void TxtSaleRNo_Validated(object sender, EventArgs e)
        {
            if (TxtSaleRNo.Text.ToString().Trim().Length == 0) return;
            VerifyAcc(ref TxtSaleRNo, ref TxtSaleRName);
        }

        private void FrmFixedAccounts_Fill_Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmFixedAccounts_Load(object sender, EventArgs e)
        {
            GetFixAccounts();
          //  this.FrmFixedAccounts_Fill_Panel .BackColor  = AccountsGlobals.FormColor;
        }
        private void GetFixAccounts()
        { 
            FixedAccountController ObjFx = new FixedAccountController();
            FixedAccounts FxObj = new FixedAccounts ();
            FxObj = ObjFx.getFixAcc();
            if ( FxObj != null)
            {
                
                TxtCashNo.Text = FxObj.CashAcc1;
                VerifyAcc(ref TxtCashNo, ref TxtCashName);
                TxtPurNo.Text = FxObj.PurRet1;
                VerifyAcc(ref TxtPurNo, ref TxtPurName);
                TxtPDiscNo.Text = FxObj.PurDisc1;
                VerifyAcc(ref TxtPDiscNo, ref TxtPDiscName);
                TxtSaleNo.Text = FxObj.SaleDisc1;
                VerifyAcc(ref TxtSaleNo  , ref TxtSaleName);
                TxtSaleRNo.Text = FxObj.SaleReturn1;
                VerifyAcc(ref TxtSaleRNo, ref TxtSaleRName);
              //  txtTransitNo.Text = FxObj.Transit;
              //  VerifyAcc(ref txtTransitNo , ref txtTransitName );
            }
        }

        private void tsbtnSave_Click(object sender, EventArgs e)
        {
            saverec();
        }

        private void tsbtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void schAccount_Click(object sender, EventArgs e)
        {
            ShowSearch(ref txtTransitNo , ref txtTransitName);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saverec();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            GetFixAccounts();
        }
    }
}
