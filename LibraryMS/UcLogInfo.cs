using LibraryMS.BLL;
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

namespace LibraryMS
{
    public partial class UcLogInfo : UserControl
    {
        public event EventHandler logoutButtonClicked;
        public event EventHandler profileButtonClicked;
        public Account account;

        public UcLogInfo()
        {
            InitializeComponent();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            logoutButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        private void UcLogInfo_Load(object sender, EventArgs e)
        {

            updateAccount(account);
            logoutButton.Width= 40;
            logoutButton.Height= 40;
            profileButton.Width= 40;
            profileButton.Height= 40;
            logoutButton.Location = new Point(this.Location.X + this.Width - logoutButton.Width-20, 4);
            profileButton.Location = new Point(this.Location.X + this.Width - logoutButton.Width- profileButton.Width - 40, 4);
            AccountLabel1.Location = new Point(this.Location.X + this.Width - logoutButton.Width - profileButton.Width-AccountLabel1.Width - 60, 9);
            label1.Location = new Point(this.Location.X + this.Width - logoutButton.Width - profileButton.Width - AccountLabel1.Width-label1.Width - 65, 6);
        }

        private void profileButton_Click(object sender, EventArgs e)
        {
            profileButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        public void updateAccount(Account account)
        {
            
            if (this.account.RoleId==2)
            {
                UserBLL userBLL = new UserBLL();
                User user = userBLL.getByUserName(this.account.AccountName);
                if (user != null)
                {
                    AccountLabel1.Text = this.account.AccountName + " (User - " + user.status.StatusName + ")";
                }
            }
            else if (this.account.RoleId==3)
            {
                AccountLabel1.Text = this.account.AccountName + " (Supplier)";
            }
            else
            {
                AccountLabel1.Text = this.account.AccountName + " (Staff)";
            }
        }

        private void AccountLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
