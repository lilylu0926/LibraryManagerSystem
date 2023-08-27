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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace LibraryMS.staff
{
    public partial class FrmLendUser : Form
    {
        
        public delegate void PassUserIdHandler(int userId);
        public event PassUserIdHandler PassUserIdDataEvent;
        public FrmLendUser()
        {
            InitializeComponent();
        }

        private void FrmLendUser_Load(object sender, EventArgs e)
        {
            updateNameInfo();
        }

        private void updateNameInfo()
        {
            UserBLL userBLL = new UserBLL();
            List<User> users = userBLL.GetAll();
            FontFamily fontFamily = new FontFamily("Arial");
            Font newFont = new Font(fontFamily, 12);
            booksDataGridView.DefaultCellStyle.Font = newFont;
            booksDataGridView.ColumnHeadersDefaultCellStyle.Font = new Font(booksDataGridView.Font.FontFamily, 14);
            booksDataGridView.EnableHeadersVisualStyles = false;
            booksDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            booksDataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            booksDataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            booksDataGridView.AutoGenerateColumns = false;
            booksDataGridView.DataSource = users;
            booksDataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            booksDataGridView.DefaultCellStyle.Padding = new Padding(5);
            if (booksDataGridView.SelectedRows.Count > 0 ) 
            { 
                setButton.Enabled = true;
            }
            else
            {
                setButton.Enabled = false;
            }
            
   
        }

        private void booksDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                e.Value = e.RowIndex + 1;
            }
            //account Name
            if (e.ColumnIndex == 2 && e.Value != null)
            {
                if (e.Value is Account)
                {
                    e.Value = (e.Value as Account).AccountName;
                }
            }
            //user name
            if (e.ColumnIndex == 3 && e.Value != null)
            {
                if (e.Value is Account)
                {
                    e.Value = (e.Value as Account).FirstName + " " + (e.Value as Account).LastName;
                }
            }
            //telephone
            if (e.ColumnIndex == 4 && e.Value != null)
            {
                if (e.Value is Account)
                {
                    e.Value = (e.Value as Account).Telephone;
                }
            }
        }

        private void booksDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            booksDataGridView.ClearSelection();
            booksDataGridView.CurrentCell = null;
        }

        private void setButton_Click(object sender, EventArgs e)
        {
            if (booksDataGridView.SelectedRows.Count > 0)
            {
                int userId = Convert.ToInt32(booksDataGridView.SelectedRows[0].Cells[1].Value);
                PassUserIdDataEvent?.Invoke(userId);
            }
                
        }



        private void booksDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (booksDataGridView.SelectedRows.Count > 0)
            {
                setButton.Enabled = true;
            }
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            User user = new User();
            Account account = null;
            if (!string.IsNullOrEmpty(accountText.Text))
            {
                if (account == null)
                {
                    account = new Account();
                }
                account.AccountName= accountText.Text.Trim();
            }
            if (!string.IsNullOrEmpty(userNameText.Text))
            {
                if (account == null)
                {
                    account = new Account();
                }
               account.FirstName = userNameText.Text.Trim();
            }

            user.account = account;
            UserBLL userBLL = new UserBLL();
            booksDataGridView.DataSource = userBLL.getConditions(user);
            setButton.Enabled = false;

        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            UserBLL userBLL = new UserBLL();
            List<User> users = userBLL.GetAll();
            booksDataGridView.DataSource = users;
            accountText.Text = string.Empty;
            userNameText.Text = string.Empty;

           setButton.Enabled = false;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
