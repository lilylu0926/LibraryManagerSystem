using LibraryMS.frmsuppler;
using LibraryMS.frmuser;
using LibraryMS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LibraryMS.frmuser.FrmBorrow;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ScrollBar;

namespace LibraryMS
{
    public partial class FrmSupplier : Form, ISubScriber
    {
        public Frmmain mainForm;
        public Account signAccount { get; set; }
        public FrmSupplier()
        {
            InitializeComponent();
        }


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            mainForm.Unsubscribe(this);
        }

        private void FrmSupplier_Load(object sender, EventArgs e)
        {
            if (signAccount != null)
            {

                displaySellForm();
            }
        }


        private void displaySellForm()
        {
            FrmSellBook frmSellBook = new FrmSellBook();
            frmSellBook.account= signAccount;
            LoadRoleForm(frmSellBook);
            sellbutton.Enabled = false;
            historyButton.Enabled = true;

        }

        private void LoadRoleForm(Form form)
        {
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            this.splitContainer1.Panel2.Controls.Clear();
            this.splitContainer1.Panel2.Controls.Add(form);
            form.Show();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void historyButton_Click(object sender, EventArgs e)
        {
            displayHistoryForm();
        }

        private void sellbutton_Click(object sender, EventArgs e)
        {
            displaySellForm();
        }

        private void displayHistoryForm()
        {
            FrmSaleHistory frmSaleHistory = new FrmSaleHistory();
            frmSaleHistory.account = signAccount;
            LoadRoleForm(frmSaleHistory);
            sellbutton.Enabled = true;
            historyButton.Enabled = false;

        }

        public void Notify(string message)
        {
            sellbutton.Enabled=true;
            historyButton.Enabled=true;
            FrmProfile frmProfile = new FrmProfile();
            frmProfile.PassAccountEvent += new FrmProfile.PassAccountHandler(passAccountEvent);
            frmProfile.PassDeleteAccountEvent += new FrmProfile.PassDeleteAccountHandler(passDeleteAccountEvent);
            frmProfile.account = signAccount;

            frmProfile.TopLevel = false;
            frmProfile.FormBorderStyle = FormBorderStyle.None;

            this.splitContainer1.Panel2.Controls.Clear();
            this.splitContainer1.Panel2.Controls.Add(frmProfile);


            frmProfile.Location = new Point((this.splitContainer1.Panel2.Width - frmProfile.Width) / 2, (this.splitContainer1.Panel2.Height - frmProfile.Height) / 2);
            frmProfile.Show();
        }

        private void passAccountEvent(Account account)
        {
            this.signAccount = account;
            mainForm.signAccount = account;
            mainForm.UpdateUcLogInfo();
        }

        private void passDeleteAccountEvent()
        {
            mainForm.LogoutFormDeleteAccount();
        }
    }
}
