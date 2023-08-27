using LibraryMS.BLL;
using LibraryMS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryMS
{
    public partial class FrmSignUp : Form
    {
        public FrmSignUp()
        {
            InitializeComponent();
        }

        private void signInButton_Click(object sender, EventArgs e)
        {
            Frmmain frmmain = (Frmmain)this.Owner;
            frmmain.signAccount = null;
            this.Close();
        }

        private void signUpButton_Click(object sender, EventArgs e)
        {
            //input validate
            string msg = "";
            if (ValidateText(out msg))
            {
                Account account = TextToAccount();
                AccountBLL accountBLL = new AccountBLL();
                string msg1 = "";
                Account newAccount = accountBLL.SignUp(account, out msg1);
                if (newAccount==null)
                {
                    MessageBox.Show(msg1);
                }
                else
                {
                    Frmmain frmmain = (Frmmain)this.Owner;
                    frmmain.signAccount = newAccount;
                    this.Close();
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
            account.AccountName= nameTextBox.Text.Trim();
            account.Password= passwordTextBox.Text.Trim();
            account.FirstName= firstNameTextBox.Text.Trim();
            account.LastName= lastNameTextBox.Text.Trim();
            account.Telephone = telephoneTextBox.Text.Trim();
            account.RoleId = Convert.ToInt32(roleComboBox.SelectedValue);
            return account;

        }

        private void FrmSignUp_Load(object sender, EventArgs e)
        {
            RoleBLL roleBLL = new RoleBLL();
            List<Role> list = roleBLL.GetAllRoles();
            roleComboBox.DataSource = list;
            roleComboBox.DisplayMember = "RoleName";
            roleComboBox.ValueMember = "RoleId";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
