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
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }

        private void Test_Load(object sender, EventArgs e)
        {
            this.BackColor = AccountsGlobals.FormColor;
            //webBrow.Navigate(@"F:\login 1.png");                 
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //webBrow.Navigate(System.Windows.Forms.Application.StartupPath + @"\" + "CalmBay1.swf");
          
            //timer1.Start();
           
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
