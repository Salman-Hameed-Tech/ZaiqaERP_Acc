using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CategoryControlle;
using Common;
using CommonController;
using Microsoft.Win32;

namespace FFMS.Forms
{
    public partial class FrmDaySettings : Form
    {

        bool dayEnded;

        RegistryKey regKeyAppRoot;
        String invPrinter;

        public FrmDaySettings()
        {
            InitializeComponent();
        }

        private void FrmDaySettings_Load(object sender, EventArgs e)
        {
            try
            {
                LoadBranches();
                if (User._IsAdmin)
                {
                    cmbBranch.Enabled = true;
                  
                }
                else
                {
                    cmbBranch.Enabled = false;
                    cmbBranch.SelectedValue = Globals.BranchID;
                }
                LoadPrinters();
                dayEnded = new CommonController.DaySettingController().CheckDayEnd(Convert.ToInt32(cmbBranch.SelectedValue)); //true when day is ended
                this.btnDayEnd.Enabled = !dayEnded;
                this.btnDayStart.Enabled = dayEnded;
                GetRunningDate(Convert.ToInt32(cmbBranch.SelectedValue));////get running date which is continued
              

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmSettings_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBranches()
        {
            List<Branch> counters = new BranchController().GetBranch("  ");
            cmbBranch.DataSource = counters;
            cmbBranch.ValueMember = "ID";
            cmbBranch.DisplayMember = "BranchName";
         
        }

        private void btnDayStart_Click(object sender, EventArgs e)
        {
            StartDay();
            GetRunningDate(Convert.ToInt32(cmbBranch.SelectedValue));
        }
        private void LoadPrinters()
        {
            try
            {
                foreach (String printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                {
                    this.cbxInvPrinter.Items.Add(printer);
                }

                regKeyAppRoot = Registry.LocalMachine.CreateSubKey("SOFTWARE\\POSPrinter");
                

                invPrinter = ""; 
                 invPrinter = Convert.ToString(regKeyAppRoot.GetValue("InvPrinter"));

                //if Key InvPrinter exist then show it in Combo.
                if (invPrinter == null || invPrinter.Trim().Length == 0)
                {
                    regKeyAppRoot.SetValue("InvPrinter", "NO");
                }
                else
                    this.cbxInvPrinter.SelectedItem = invPrinter;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmConfiguration LoadPrinters", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDayEnd_Click(object sender, EventArgs e)
        {
            int branchid = Convert.ToInt32(cmbBranch.SelectedValue);
            string count = new SaleInvoiceController().GetPendingCount(branchid).ToString();
            if (Convert.ToInt32(count) > 0)
            {
                MessageBox.Show("Please Final Pending Sale Bills First", "Sale Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                EndDay(branchid);
                GetRunningDate(branchid);
            }
        }
        

       
        
        private void EndDay(int branchid)
        {
            try
            {                
                DialogResult r = MessageBox.Show("Do You Really Want To End The Day " + this.dtpDate.Text + "", "Alert..", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                  
                        if (new CommonController.DaySettingController().EndDay(branchid))
                        {
                            this.btnDayEnd.Enabled = false;
                            this.btnDayStart.Enabled = true;
                            MessageBox.Show("Day end Successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
               
                 
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmDaySettings EndDay", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void StartDay()
        {
            try
            {                
                DialogResult r = MessageBox.Show("Do You Really Want To Start The Day " + System.DateTime.Now.Date + "", "Alert..", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    if (new CommonController.DaySettingController().StartDay(Convert.ToInt32(cmbBranch.SelectedValue)))
                    {
                        this.btnDayStart.Enabled = false;
                        this.btnDayEnd.Enabled = true;
                        MessageBox.Show("Day Start Successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Some Error Occoured", "StartDay", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmSettings StartDay", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GetRunningDate(int branchid)
        {
            this.dtpDate.Text = "";
            this.dtpDate.Value = new CommonController.DaySettingController().GetRunningDate(branchid);
        }

        private void tsbtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbxInvPrinter_Leave(object sender, EventArgs e)
        {
            //regKeyAppRoot.SetValue("InvPrinter", this.cbxInvPrinter.Text);
        }

        private void btnSeclect_Click(object sender, EventArgs e)
        {
            if (cbxInvPrinter.Text.Trim().Length != 0)
            {
                regKeyAppRoot.SetValue("InvPrinter", this.cbxInvPrinter.Text);
                MessageBox.Show("Printer Saved successfullly", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
              
            }
            else
                MessageBox.Show("Please select Priter","Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void cmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbBranch_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                dayEnded = new CommonController.DaySettingController().CheckDayEnd(Convert.ToInt32(cmbBranch.SelectedValue)); //true when day is ended
                this.btnDayEnd.Enabled = !dayEnded;
                this.btnDayStart.Enabled = dayEnded;
                GetRunningDate(Convert.ToInt32(cmbBranch.SelectedValue));////get running date which is continued
                LoadPrinters();
            }
            catch (Exception)
            {

              
            }
           
        }
    }
}
