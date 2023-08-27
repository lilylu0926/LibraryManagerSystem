using LibraryMS.BLL;
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
    public partial class FrmStaff : Form, ISubScriber
    {
        public Frmmain mainForm;

        private string isbn;

        public Account signAccount { get; set; }
        public FrmStaff()
        {
            InitializeComponent();
        }



        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            mainForm.Unsubscribe(this);
        }

        private void FrmStaff_Load(object sender, EventArgs e)
        {
            //FrmBookInfo frmBookInfo = new FrmBookInfo();
            //frmBookInfo.PassDataEvent += new FrmBookInfo.PassBookInfoIdHandler(passHandleBookInfoEvent);
            //LoadRoleForm(frmBookInfo);
            //BookInfobutton.Enabled = false;
            displayBookInfo();
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


        private void BookInfobutton_Click(object sender, EventArgs e)
        {
            displayBookInfo();
        }

        private void displayBookInfo()
        {
            FrmBookInfo frmBookInfo = new FrmBookInfo();
            frmBookInfo.PassReservedDataEvent += new FrmBookInfo.PassReservedBookInfoIdHandler(passHandleBookInfoEvent);
            frmBookInfo.PassLendDataEvent += new FrmBookInfo.PassLendBookInfoIdHandler(passLendHandleBookInfoEvent);
            LoadRoleForm(frmBookInfo);
            BookInfobutton.Enabled = false;
            Reservebutton.Enabled = true;
            Lendbutton.Enabled = true;
            BookListbutton.Enabled = true;
            Membersbutton.Enabled = true;
        }

        private void passHandleBookInfoEvent(int bookInfoId)
        {
            diplayBookReserved(bookInfoId);
        }

        private void passLendHandleBookInfoEvent(int bookInfoId)
        {
            diplayBookLend(bookInfoId);
        }

        private void Reservebutton_Click(object sender, EventArgs e)
        {
            diplayBookReserved(0);
        }

        private void diplayBookReserved(int bookInfoId)
        {
            FrmReserve frmReserve = new FrmReserve();
            if (bookInfoId > 0)
            {
                Book book= new Book();
                book.BookInfoId = bookInfoId;
                frmReserve.lastBookCondition = book;
            }
            LoadRoleForm(frmReserve);
            BookInfobutton.Enabled = true;
            Reservebutton.Enabled = false;
            Lendbutton.Enabled = true;
            BookListbutton.Enabled = true;
            Membersbutton.Enabled = true;
        }


        private void Lendbutton_Click(object sender, EventArgs e)
        {
            diplayBookLend(0);
        }

        private void diplayBookLend(int bookInfoId)
        {
            FrmLend frmLend = new FrmLend();
            if (bookInfoId > 0)
            {
                Book book = new Book();
                book.BookInfoId = bookInfoId;
                frmLend.lastBookCondition = book;
            }
            LoadRoleForm(frmLend);
            BookInfobutton.Enabled = true;
            Reservebutton.Enabled = true;
            Lendbutton.Enabled = false;
            BookListbutton.Enabled = true;
            Membersbutton.Enabled = true;
        }

        private void BookListbutton_Click(object sender, EventArgs e)
        {
            diplayBookList();
        }

        private void diplayBookList()
        {
            FrmBookList frmBookList = new FrmBookList();
            LoadRoleForm(frmBookList);
            BookInfobutton.Enabled = true;
            Reservebutton.Enabled = true;
            Lendbutton.Enabled = true;
            BookListbutton.Enabled = false;
            Membersbutton.Enabled = true;
        }

        private void Membersbutton_Click(object sender, EventArgs e)
        {
            diplayMember();
        }

        private void diplayMember()
        {
            FrmMember frmMember = new FrmMember();
            LoadRoleForm(frmMember);
            BookInfobutton.Enabled = true;
            Reservebutton.Enabled = true;
            Lendbutton.Enabled = true;
            BookListbutton.Enabled = true;
            Membersbutton.Enabled = false;
        }

        public void Notify(string message)
        {
            BookInfobutton.Enabled = true;
            Reservebutton.Enabled = true;
            Lendbutton.Enabled = true;
            BookListbutton.Enabled = true;
            Membersbutton.Enabled = true;
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
            this.signAccount= account;
            mainForm.signAccount = account;
            mainForm.UpdateUcLogInfo();
        }

        private void passDeleteAccountEvent()
        {
            mainForm.LogoutFormDeleteAccount();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
    }
}
