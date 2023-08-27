using LibraryMS.BLL;
using LibraryMS.frmuser;
using LibraryMS.Model;
using LibraryMS.staff;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace LibraryMS
{
    public partial class FrmUser : Form, ISubScriber
    {
        public Frmmain mainForm;
        private int? lastSelectIndex;
        private BookInfo lastSearchedBookInfo;
        public Account signAccount { get; set; }
        public FrmUser()
        {
            InitializeComponent();
        }


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            mainForm.Unsubscribe(this);
        }

        private void FrmUser_Load(object sender, EventArgs e)
        {
            displayBorrowForm();
        }

        private void displayBorrowForm()
        {
            FrmBorrow frmBorrow = new FrmBorrow();
            frmBorrow.PassBookInfoEvent += new FrmBorrow.passHandleBookInfoEvent(passHandleBookInfoEvent);
            frmBorrow.lastSelectIndex= lastSelectIndex;
            frmBorrow.lastSearchedBookInfo= lastSearchedBookInfo;
            LoadRoleForm(frmBorrow);
            borrowButton.Enabled = false;
            returnButton.Enabled = true;
            historybutton.Enabled = true;
        }

        private void passHandleBookInfoEvent(int bookInfoId,int rowindex, BookInfo lastSearchedBookInfo)
        {
            lastSelectIndex = rowindex;
            this.lastSearchedBookInfo= lastSearchedBookInfo;
            FrmBorrowBook frmBorrowBook = new FrmBorrowBook();
            frmBorrowBook.FormClosed += new FormClosedEventHandler(frmBorrowBookClosed);
            frmBorrowBook.userId= signAccount.AccountId;
            Book book = new Book();
            book.BookInfoId = bookInfoId;
            frmBorrowBook.lastBookCondition = book;
            LoadRoleForm(frmBorrowBook);
            borrowButton.Enabled = true;
        }

        private void frmBorrowBookClosed(object sender, FormClosedEventArgs e)
        {
            displayBorrowForm();
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

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex==1 && e.Value != null)
            {
                if (e.Value is UserStatus)
                {
                    e.Value = (e.Value as UserStatus).StatusName;
                }
            }
        }

        private void borrowButton_Click(object sender, EventArgs e)
        {
            displayBorrowForm();
        }

        private void returnButton_Click(object sender, EventArgs e)
        {
            displayRetrunForm();
        }

        private void historybutton_Click(object sender, EventArgs e)
        {
            displayHistoryForm();
        }

        private void displayRetrunForm()
        {
            FrmReturn frmReturn = new FrmReturn();
            frmReturn.userId = signAccount.AccountId;
            LoadRoleForm(frmReturn);
            borrowButton.Enabled = true;
            returnButton.Enabled = false;
            historybutton.Enabled = true;
            lastSelectIndex = 0;
        }

        private void displayHistoryForm()
        {
            FrmUserHistory frmUserHistory = new FrmUserHistory();
            frmUserHistory.userId = signAccount.AccountId;
            LoadRoleForm(frmUserHistory);
            borrowButton.Enabled = true;
            returnButton.Enabled = true;
            historybutton.Enabled = false;
            lastSelectIndex = 0;
        }

        public void Notify(string message)
        {
            borrowButton.Enabled = true;
            historybutton.Enabled = true;
            returnButton.Enabled = true;
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
