using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common;
using CategoryControlle;

namespace Accounts.Forms
{
    public partial class FrmChartofAccounts : Form
    {
        ChartOfAccounts account;
        ChartOfAccounts selectedAccount;
        List<ChartOfAccounts> accounts;
        List<ChartOfAccounts> cAccounts;
        List<ChartOfAccounts> filterAccounts;
        ChartofAccountsController cc;

        TreeNode tNode;
        string vNode;               

        public FrmChartofAccounts()
        {
            InitializeComponent();
        }

        private void FrmChartofAccounts_Load(object sender, EventArgs e)
        {
            try
            {
                //FrmChartofAccounts_Fill_Panel.BackColor = AccountsGlobals.FormColor;
                //lblHeading.Font = AccountsGlobals.HeadingStyle;

                PopulateTree();
            }
            catch (Exception ex)
            {                
                MessageBox.Show(ex.Message,"FrmChartofAccounts_Load",MessageBoxButtons.OK ,MessageBoxIcon.Error );
            }            
        }

        public void PopulateTree()
        {
            try
            {
                int flag;
                if (rbAccounts.Checked)
                {
                    flag = 0;
                }
                else if (rbParties.Checked)
                {
                    flag = 1;
                }
                else
                {
                    flag = 2;
                }
                accounts = new ChartofAccountsController().GetParentAccounts(flag);
                TreeNode x;

                this.tvChartofAccounts.Nodes.Clear();

                for (int i = 0; i < accounts.Count; i++)
                {
                    if (accounts[i].ParentAccount.AccountNo == "0")
                    {
                        x = new TreeNode();

                        x.Text = accounts[i].AccountName;
                        x.Tag = accounts[i].IsDetailed.ToString();
                        x.Tag += accounts[i].IsEditable.ToString();
                        x.Tag += accounts[i].IsLocked.ToString();
                        x.Tag += accounts[i].AccountType.ToString() + ", " + accounts[i].AccountNo.ToString();

                        this.tvChartofAccounts.Nodes.Add(x);
                        this.tvChartofAccounts.SelectedNode = x;
                    }
                    else
                    {
                        x = new TreeNode();

                        x.Text = accounts[i].AccountName;
                        x.Tag = accounts[i].IsDetailed.ToString();
                        x.Tag += accounts[i].IsEditable.ToString();
                        x.Tag += accounts[i].IsLocked.ToString();
                        x.Tag += accounts[i].AccountType.ToString() + ", " + accounts[i].AccountNo.ToString();

                        this.tvChartofAccounts.SelectedNode.Nodes.Add(x);

                        if (i < accounts.Count - 1)
                        {
                            if (accounts[i].AccountDepth < accounts[i + 1].AccountDepth)
                            {
                                this.tvChartofAccounts.SelectedNode = x;
                            }
                            else if (accounts[i].AccountDepth > accounts[i + 1].AccountDepth)
                            {
                                for (int j = 0; j < accounts[i].AccountDepth - accounts[i + 1].AccountDepth; j++)
                                {
                                    if (this.tvChartofAccounts.SelectedNode.Parent!=null)
                                    {
                                        x = this.tvChartofAccounts.SelectedNode.Parent;
                                        this.tvChartofAccounts.SelectedNode = x;   
                                    }                                    
                                }
                            }
                            else
                            {
                                x = x.Parent;
                                this.tvChartofAccounts.SelectedNode = x;
                            }
                        }
                        else
                        {
                            x = x.Parent;
                            this.tvChartofAccounts.SelectedNode = x;
                        }
                    }
                }
                this.tvChartofAccounts.CollapseAll();
                this.tvChartofAccounts.SelectedNode = this.tvChartofAccounts.Nodes[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmChartofAccounts PopulateTree", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void tvChartofAccounts_AfterSelect(object sender, TreeViewEventArgs e)
        {            
            vNode = this.tvChartofAccounts.SelectedNode.Tag.ToString();
            PopulateListView(vNode);
            ShowDetail();
        }

        public void PopulateListView(string s)
        {
            try
            {
                int index;
                int cIndex = 0;
                string accNo;                              

                this.lvChartofAccounts.Items.Clear();
                accNo = GetAccountNo(s);
                cAccounts = new ChartofAccountsController().GetChildAccounts(accNo,this.txtAccountName.Text);
                foreach (ChartOfAccounts acc in cAccounts)
                {
                    if (acc.IsDetailed)
                    {
                        this.lvChartofAccounts.Items.Add(acc.AccountNo);
                        this.lvChartofAccounts.Items[cIndex].SubItems.Add(acc.AccountName);
                        cIndex++;
                    }
                }
                if (this.lvChartofAccounts.Items.Count > 0)
                {
                    this.lvChartofAccounts.Items[0].Selected = true;   
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmChartofAccounts ListView", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }
        public void ShowDetail() 
        {
            string accNo;
            accNo = GetAccountNo(this.tvChartofAccounts.SelectedNode.Tag.ToString());

            account = new ChartofAccountsController().GetAccountDetail(accNo,"");

            this.cmnuModGroup.Enabled = account.IsEditable;
            this.cmnuDelGroup.Enabled = account.IsEditable;

            this.txtAccountNo.Text = account.AccountNo;
            this.txtAccountType.Text = account.AccountType.ToString();            
        }
        public string GetAccountNo(string s)
        {
            try
            {
                char[] ch = { ' ' };
                string accNo;

                string[] sub = s.Split(ch);
                accNo = sub[1];
                return accNo;   
            }
            catch (Exception ex)
            {                
                MessageBox.Show(ex.Message,"FrmChartofAccounts PopulateTree",MessageBoxButtons.OK ,MessageBoxIcon.Error );
                return "";
            }
        }
        private bool FilterAccounts(ChartOfAccounts a)
        {
            return a.AccountName.ToUpper().Contains(this.txtAccountName.Text.ToUpper());
        }

        private void rbAccounts_CheckedChanged(object sender, EventArgs e)
        {
            PopulateTree();
        }

       

        private void cMnuListView_Opening(object sender, CancelEventArgs e)
        {
            if (this .lvChartofAccounts .Items .Count <=0)
            {
                this.cmnuDeleteAccount.Enabled = false;
                this.cmnuModAccount.Enabled = false;
            }
            else
            {
                this.cmnuDeleteAccount.Enabled = true;
                this.cmnuModAccount.Enabled = true;
            }
        }

        private void txtAccountName_TextChanged(object sender, EventArgs e)
        {
            //PopulateListView(vNode);
            int cIndex = 0;

            if (this.txtAccountName.Text.Trim ().Length ==0)
            {
                this.lvChartofAccounts.Items.Clear();
                foreach (ChartOfAccounts acc in cAccounts)
                {
                    if (acc.IsDetailed)
                    {
                        this.lvChartofAccounts.Items.Add(acc.AccountNo);
                        this.lvChartofAccounts.Items[cIndex].SubItems.Add(acc.AccountName);
                        cIndex++;
                    }
                }               
            }
            else
            {
                this.lvChartofAccounts.Items.Clear();
                filterAccounts = cAccounts.FindAll(FilterAccounts);
                if (filterAccounts.Count > 0)
                {
                    foreach (ChartOfAccounts acc in filterAccounts)
                    {
                        if (acc.IsDetailed)
                        {
                            this.lvChartofAccounts.Items.Add(acc.AccountNo);
                            this.lvChartofAccounts.Items[cIndex].SubItems.Add(acc.AccountName);
                            cIndex++;
                        }
                    }   
                }
                else
                {
                    this.lvChartofAccounts.Items.Clear();
                }
            }
        }

        private void cmnuNewGroup_Click(object sender, EventArgs e)
        {
            try
            {
                FrmNewAccount frm = new FrmNewAccount();

                frm.Opt = 1;
                frm.Operation = 1;
                frm.IsDetailed = 1;

                string node=this.tvChartofAccounts.SelectedNode.Tag.ToString ();               
                TreeNode sNode=this.tvChartofAccounts.SelectedNode ;

                frm.txtAccountType.Text = this.txtAccountType.Text;                
                frm.txtParentAccount.Text = GetAccountNo(node);
                frm.ShowDialog ();

                PopulateTree();                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message ,"FrmChartofAccount New_Group_Clicked",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }            
        }
        private void cmnuModGroup_Click(object sender, EventArgs e)
        {
            try
            {
                FrmNewAccount frm = new FrmNewAccount();

                frm.Opt = 1;
                frm.Operation = 3;
                frm.IsDetailed = 1;

                string node = this.tvChartofAccounts.SelectedNode.Tag.ToString();

                ChartOfAccounts acc=new ChartOfAccounts ();
              
                acc = new ChartofAccountsController ().GetAccountDetail(GetAccountNo(node),"");

                frm.txtAccountName.Text = acc.AccountName;
                frm.txtAccountNo.Text = acc.AccountNo;
                frm.txtAccountType.Text = acc.AccountType.ToString();
                frm.txtNarration.Text = acc.Narration;
                frm.txtParentAccount.Text = acc.ParentAccount.AccountNo;

                frm.txtAccountExtention.Enabled = false;
                
                frm.ShowDialog();                
            }
            catch (Exception ex)
            {                
                MessageBox.Show(ex.Message ,"FrmChartofAccount Modify_Group_Clicked",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void cmnuDelGroup_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult r = MessageBox.Show("Are you sure you want to delete this group?","Confirm Deletion...",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (r== DialogResult .Yes )
                {
                    cAccounts.Clear();
                    cAccounts = new ChartofAccountsController().GetChildAccounts(GetAccountNo(this.tvChartofAccounts.SelectedNode.Tag.ToString ().Trim ()), this.txtAccountName.Text);
                    if (cAccounts.Count > 0)
                    {
                        MessageBox.Show("Can not delete group.\nBecause there are accounts in this group.", "Delete Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        cc = new ChartofAccountsController();
                        if (cc.DeleteAccount(GetAccountNo(this.tvChartofAccounts.SelectedNode.Tag.ToString().Trim())))
                        {
                            MessageBox.Show("Account Group is deleted successfully.", "Deleted Successfully...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        PopulateTree(); 
                    }
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmChartofAccount Delete_Group_Clicked", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        private void cmnuCreateAccount_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtAccountType.Text != "Party")
                {
                    FrmNewAccount frm = new FrmNewAccount();

                    frm.Opt = 2;
                    frm.Operation = 1;
                    frm.IsDetailed = 1;

                    string node = this.tvChartofAccounts.SelectedNode.Tag.ToString();
                    TreeNode sNode = this.tvChartofAccounts.SelectedNode;

                    frm.txtAccountType.Text = this.txtAccountType.Text;
                    frm.txtParentAccount.Text = GetAccountNo(node);
                    frm.ShowDialog();

                    vNode = this.tvChartofAccounts.SelectedNode.Tag.ToString();
                    PopulateListView(vNode);
                    ShowDetail();
                }
                else
                {
                    FrmParty frm = new FrmParty();

                    frm.Opt = 2;
                    frm.Operation = 1;
                    frm.IsDetailed = 1;

                    string node = this.tvChartofAccounts.SelectedNode.Tag.ToString();
                    TreeNode sNode = this.tvChartofAccounts.SelectedNode;

                    frm.txtAccountType.Text = this.txtAccountType.Text;
                    frm.txtParentAccount.Text = GetAccountNo(node);
                    frm.ShowDialog();

                    vNode = this.tvChartofAccounts.SelectedNode.Tag.ToString();
                    PopulateListView(vNode);
                    ShowDetail();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmChartofAccount CreateAccount_for Group_Clicked", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmnuModAccount_Click(object sender, EventArgs e)
        {
            try
            {
                //Chart of accounts
                if (this.txtAccountType.Text != "Party")
                {
                    FrmNewAccount frm = new FrmNewAccount();

                    frm.Opt = 2;
                    frm.Operation = 3;
                    frm.IsDetailed = 1;



                    ChartOfAccounts acc = new ChartOfAccounts();

                    acc = new ChartofAccountsController().GetAccountDetail(this.lvChartofAccounts.SelectedItems[0].Text.ToString(),"");

                    frm.txtAccountName.Text = acc.AccountName;
                    frm.txtAccountNo.Text = acc.AccountNo;
                    frm.txtAccountType.Text = acc.AccountType.ToString();
                    frm.txtNarration.Text = acc.Narration;
                    frm.txtParentAccount.Text = acc.ParentAccount.AccountNo;
                    frm.txtGRVAccount.Text = acc.GRVAccount;
                    frm.txtGRVAccountName.Text = acc.GRVAccountName;
                    frm.txtAccountExtention.Enabled = false;
                    frm.branches = acc.Branches;
                    frm.ShowDialog();

                    vNode = this.tvChartofAccounts.SelectedNode.Tag.ToString();
                    PopulateListView(vNode);
                    ShowDetail();
                }
                else  // parties
                {
                    FrmParty frm = new FrmParty();

                    frm.Opt = 2;
                    frm.Operation = 3;
                    frm.IsDetailed = 1;
                    
                    ChartOfAccounts acc = new ChartOfAccounts();

                    acc = new ChartofAccountsController().GetAccountDetail(this.lvChartofAccounts.SelectedItems[0].Text.ToString(),"");

                    frm.partyName  = acc.AccountName;
                    frm.txtAccountNo.Text = acc.AccountNo;
                    frm.txtAccountType.Text = acc.AccountType.ToString();                    
                    frm.txtParentAccount.Text = acc.ParentAccount.AccountNo;
                    frm.txtGRVAccount.Text = acc.GRVAccount;
                    frm.txtGRVAccountName.Text = acc.GRVAccountName;
                    frm.txtAccountExtention.Enabled = false;
                 
                    Vendor v = new Vendor();

                    v = new VendorController().GetPartyDetail(this.lvChartofAccounts.SelectedItems[0].Text.ToString());
                    
                    frm.txtAddress.Text = v.Address.AdressLine;
                    frm.cityID = v.Address.Sector;
                    frm.txtFax.Text = v.Fax;
                    frm.txtMobile.Text = v.Mobile;
                    frm.txtPhoneHome.Text = v.PhoneHome;
                    frm.txtPhoneOffice.Text = v.PhoneOffice;
                    frm.txtEmail.Text = v.Email;
                    frm.txtContactPerson.Text = v.ContactPerson;
                    frm.chkPurchase.Checked = v.InPurchase;
                    frm.branches = v.BranchList;  
                    frm.chkSale.Checked = v.InSale;               
                    frm.isNew = false;
                    frm.ShowDialog();

                    vNode = this.tvChartofAccounts.SelectedNode.Tag.ToString();
                    PopulateListView(vNode);
                    ShowDetail();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmChartofAccount Modify_Account_Clicked", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmnuDeleteAccount_Click(object sender, EventArgs e)
        {
            try
            {
                ChartOfAccounts acc = new ChartOfAccounts();

                acc = new ChartofAccountsController().GetAccountDetail(this.lvChartofAccounts.SelectedItems[0].Text.ToString(),"");
                
                if (acc.IsEditable == false)
                {
                    MessageBox.Show("Fixed Accounts can not be deleted.", "Delete Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DialogResult r = MessageBox.Show("Are you sure you want to delete this group?", "Confirm Deletion...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        cc = new ChartofAccountsController();
                        bool deleted=false;
                        //if (cc.CheckBalances(acc.AccountNo.ToString()))
                        //{
                        //    MessageBox.Show("Account can not be deleted.\n Opening balances for account exists.", "Delete Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //}
                        //else
                        //{
                        if (this.txtAccountType.Text == "Party")
                        {
                            bool b = new VendorController().DeleteParty(acc.AccountNo.ToString());
                            if (b)
                            {
                                deleted = cc.DeleteAccount(acc.AccountNo.ToString());
                            }                            
                        }
                        else
                        {
                            deleted=cc.DeleteAccount(acc.AccountNo.ToString());                            
                        }

                        if (deleted)
                        {
                              MessageBox.Show("Account is deleted successfully.", "Deleted Successfully...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                              MessageBox.Show("Account can not be deleted.", "Delete Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        //}
                    }

                    vNode = this.tvChartofAccounts.SelectedNode.Tag.ToString();
                    PopulateListView(vNode);
                    ShowDetail();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmChartofAccount Delete_Group_Clicked", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }       
                
        private void txtAccountName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    System.Windows.Forms.SendKeys.Send("\t");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FrmChartofAccounts txtAccountName_KeyDown.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    

        private void tsBtnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }        
    }
}
