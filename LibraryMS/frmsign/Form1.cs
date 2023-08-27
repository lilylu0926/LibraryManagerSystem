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
    public partial class FrmSignIn : Form
    {
        public Account signAccount;
        public FrmSignIn()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void roleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
           // MessageBox.Show(roleComboBox.SelectedValue.ToString());
        }

        private void signInButton_Click(object sender, EventArgs e)
        {
            signAccount = null;
            string userName = nameTextBox.Text.Trim();
            string userPassword = passwordTextBox.Text.Trim();
            //Validation
            if (string.IsNullOrEmpty(userName)){
                nameTextBox.Focus();
                MessageBox.Show("Account name can not be empty!","Sign in",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (!Validation.accountNameValidation(userName))
            {
                nameTextBox.Focus();
                MessageBox.Show("Account name must be more than 3 charactors or numbers!", "Sign in", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(userPassword)){
                passwordTextBox.Focus();
                MessageBox.Show("Password can not be empty!", "Sign in", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Validation.passwordValidation(userPassword))
            {
                passwordTextBox.Focus();
                MessageBox.Show("Password must be more than 3 charactors or numbers!", "Sign in", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Account account= new Account();
            account.AccountName= userName;
            account.Password= userPassword;
            AccountBLL accountBLL = new AccountBLL();
            string msg = "";
            signAccount = accountBLL.SignIn(account, out msg);
            if (signAccount == null) //Failed to sign in
            {
                MessageBox.Show(msg);
            }
            else //Sucess
            {
   
                Frmmain frmmain = (Frmmain)this.Owner; 
                frmmain.signAccount= signAccount;
                this.Close();
            }


            
        }

        private void signUpbutton_Click(object sender, EventArgs e)
        {
            Frmmain frmmain = (Frmmain)this.Owner;
            frmmain.signAccount = null;
            this.Close();
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
