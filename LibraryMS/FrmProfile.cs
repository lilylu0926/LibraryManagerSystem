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
    public partial class FrmProfile : Form
    {
        private User user;
        public Account account { get; set; }

        public delegate void PassAccountHandler(Account account);
        public event PassAccountHandler PassAccountEvent;

        public delegate void PassDeleteAccountHandler();
        public event PassDeleteAccountHandler PassDeleteAccountEvent;

        public FrmProfile()
        {
            InitializeComponent();
        }

        private void FrmProfile_Load(object sender, EventArgs e)
        {
            update();
        }

        private void update()
        {
            nameTextBox.Text = account.AccountName;
            passwordTextBox.Text = account.Password;
            rePasswordTextBox.Text = account.Password;
            firstNameTextBox.Text = account.FirstName;
            lastNameTextBox.Text = account.LastName;
            telephoneTextBox.Text = account.Telephone;
            if (this.account.RoleId==2)
            {
                UserBLL userBLL = new UserBLL();
                user = userBLL.getByUserName(this.account.AccountName);
                if (user != null)
                {
                    //Non-Member
                    if (user.StatusId == 1)
                    {
                        memberCheckBox.Text = " Apply to be a member";
                    }
                    else
                    {
                        memberCheckBox.Text = " Cancel membership";
                    }
                    memberCheckBox.Checked = false;
                    memberCheckBox.Visible = true;
                }

            }
            else
            {
                memberCheckBox.Visible = false;
            }

        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            update();
        }

        private void setBtn_Click(object sender, EventArgs e)
        {
            //input validate
            string msg = "";
            if (ValidateText(out msg))
            {
                Account account = TextToAccount();
                string msg1 = "";

                if (this.account.RoleId==2)
                {
                    User newUser= new User();
                    account.AccountId = this.account.AccountId;
                    newUser.UserId = this.account.AccountId;
                    newUser.account = account;
                    if (memberCheckBox.Checked)
                    {
                        if (user.StatusId == 1)
                        {
                            newUser.StatusId = 2;
                        }
                        else
                        {
                            newUser.StatusId = 1;
                        }
                    }
                    else
                    {
                        newUser.StatusId = user.StatusId;
                    }
                    UserBLL userBLL=new UserBLL();
                    if (userBLL.update(newUser, out msg1)){
                        
                        account.role = this.account.role;
                        account.RoleId = this.account.RoleId;
                        PassAccountEvent?.Invoke(account);
                        this.account = account;
                        update();
                        MessageBox.Show(msg1, "Update profile", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(msg1, "Update profile", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                   account.AccountId = this.account.AccountId;
                    AccountBLL accountBLL = new AccountBLL();
                    if (accountBLL.update(account, out msg1))
                    {
                        account.role= this.account.role;
                        account.RoleId= this.account.RoleId;
                        PassAccountEvent?.Invoke(account);
                        this.account = account;
                        MessageBox.Show(msg1, "Update profile", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(msg1, "Update profile", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }


            }
            else
            {
                MessageBox.Show(msg);
            }
        }

        /// <summary>
        /// Validate input text
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        private bool ValidateText(out string msg)
        {
            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                msg = "Account name is empty!";
                nameTextBox.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(passwordTextBox.Text))
            {
                passwordTextBox.Focus();
                msg = "Password is empty!";
                return false;
            }
            if (!passwordTextBox.Text.Equals(rePasswordTextBox.Text))
            {
                rePasswordTextBox.Focus();
                msg = "Password is not the same!";
                return false;
            }
            if (string.IsNullOrWhiteSpace(firstNameTextBox.Text))
            {
                firstNameTextBox.Focus();
                msg = "First name is empty!";
                return false;
            }
            if (string.IsNullOrWhiteSpace(lastNameTextBox.Text))
            {
                lastNameTextBox.Focus();
                msg = "Last name is empty!";
                return false;
            }

            if (!Validation.accountNameValidation(nameTextBox.Text.Trim()))
            {
                nameTextBox.Focus();
                msg = "Account name must be more than 3 characters or numbers";
                return false;
            }

            if (!Validation.passwordValidation(passwordTextBox.Text.Trim()))
            {
                passwordTextBox.Focus();
                msg = "Password must be more than 3 characters or numbers";
                return false;
            }

            if (!Validation.nameValidation(firstNameTextBox.Text.Trim()))
            {
                firstNameTextBox.Focus();
                msg = "First name must be characters";
                return false;
            }

            if (!Validation.nameValidation(lastNameTextBox.Text.Trim()))
            {
                lastNameTextBox.Focus();
                msg = "Last name must be characters";
                return false;
            }

            if (!String.IsNullOrEmpty(telephoneTextBox.Text) && !Validation.telephoneValidation(telephoneTextBox.Text.Trim()))
            {
                telephoneTextBox.Focus();
                msg = "Telephone number must be like 223-456-1234";
                return false;
            }

            msg = "Ok";
            return true;
        }

        private Account TextToAccount()
        {
            Account account = new Account();
            account.AccountName = nameTextBox.Text.Trim();
            account.Password = passwordTextBox.Text.Trim();
            account.FirstName = firstNameTextBox.Text.Trim();
            account.LastName = lastNameTextBox.Text.Trim();
            account.Telephone = telephoneTextBox.Text.Trim();
            return account;

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you confirm to delete your account？", "Delete account", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {

                AccountBLL accountBLL = new AccountBLL();
                if (accountBLL.delete(account))
                {
                    PassDeleteAccountEvent?.Invoke();

                }
                else
                {
                    MessageBox.Show("Failed to delete the sale record from list!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void memberCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
