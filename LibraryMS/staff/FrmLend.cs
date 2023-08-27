using LibraryMS.BLL;
using LibraryMS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryMS.staff
{
    public partial class FrmLend : Form
    {
        //key:bookID
        private Dictionary<int, User> users = new Dictionary<int, User>();
        public Book lastBookCondition;
        public FrmLend()
        {
            InitializeComponent();
        }

        private void FrmLend_Load(object sender, EventArgs e)
        {
            updateNameInfo();
        }

        private void updateNameInfo()
        {
            BooksBLL booksBLL = new BooksBLL();
            //List<Book> books = booksBLL.getAllAvailableOrReserved();
            List<Book> books = booksBLL.getAvailableConditions(lastBookCondition);
            FontFamily fontFamily = new FontFamily("Arial");
            Font newFont = new Font(fontFamily, 12);
            booksDataGridView.DefaultCellStyle.Font = newFont;
            booksDataGridView.Columns["BookName"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            booksDataGridView.ColumnHeadersDefaultCellStyle.Font = new Font(booksDataGridView.Font.FontFamily, 14);
            booksDataGridView.EnableHeadersVisualStyles = false;
            booksDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            booksDataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            booksDataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            booksDataGridView.AutoGenerateColumns = false;
            booksDataGridView.DataSource = books;
            booksDataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            booksDataGridView.DefaultCellStyle.Padding = new Padding(5);
            lendBtn.Enabled = false;
            userButton.Enabled = false;
            cancelBtn.Enabled = false;
        }

        private void booksDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                e.Value = e.RowIndex + 1;
            }
            //Book Name
            if (e.ColumnIndex == 2 && e.Value != null)
            {
                if (e.Value is BookInfo)
                {
                    e.Value = (e.Value as BookInfo).BookName;
                }
            }
            //ISBN
            if (e.ColumnIndex == 3 && e.Value != null)
            {
                if (e.Value is BookInfo)
                {
                    e.Value = (e.Value as BookInfo).ISBN13;
                }
            }
            //Author
            if (e.ColumnIndex == 4 && e.Value != null)
            {
                if (e.Value is BookInfo)
                {
                    e.Value = (e.Value as BookInfo).Author;
                }
            }
            //Publisher
            if (e.ColumnIndex == 5 && e.Value != null)
            {
                if (e.Value is BookInfo)
                {
                    e.Value = (e.Value as BookInfo).Publisher;
                }
            }
            //Price
            if (e.ColumnIndex == 6 && e.Value != null)
            {
                if (e.Value is BookInfo)
                {
                    e.Value ="CA "+  (e.Value as BookInfo).Price.ToString("F2");
                }
            }
        }

        private void booksDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            booksDataGridView.ClearSelection();
            booksDataGridView.CurrentCell = null;
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            BookInfo bookInfo = new BookInfo();
            Book book = new Book();
            if (!string.IsNullOrEmpty(bookNameText.Text))
            {
                bookInfo.BookName = bookNameText.Text.Trim();
            }
            if (!string.IsNullOrEmpty(ISBNText.Text))
            {
                bookInfo.ISBN13 = ISBNText.Text.Trim();
            }
            if (!string.IsNullOrEmpty(publisherText.Text))
            {
                bookInfo.Publisher = publisherText.Text.Trim();
            }
            if (!string.IsNullOrEmpty(authorText.Text))
            {
                bookInfo.Author = authorText.Text.Trim();
            }

            book.bookInfo = bookInfo;
            BooksBLL booksBLL = new BooksBLL();
            booksDataGridView.DataSource = booksBLL.getAvailableConditions(book);
            lendBtn.Enabled = false;
            cancelBtn.Enabled = false;
            userButton.Enabled = false;
            lastBookCondition = book;
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            users.Clear();
            BooksBLL booksBLL = new BooksBLL();
            List<Book> books = booksBLL.getAvailableConditions(null);
            booksDataGridView.DataSource = books;
            bookNameText.Text = string.Empty;
            ISBNText.Text = string.Empty;
            authorText.Text = string.Empty;
            publisherText.Text = string.Empty;
            lendBtn.Enabled = false;
            cancelBtn.Enabled = false;
            userButton.Enabled = false;
            lastBookCondition = null;
           
        }

        private void userButton_Click(object sender, EventArgs e)
        {
            FrmLendUser frmLendUser = new FrmLendUser();
            frmLendUser.PassUserIdDataEvent += new FrmLendUser.PassUserIdHandler(passHandleUserIdEvent);
            frmLendUser.ShowDialog();
        }

        private void passHandleUserIdEvent(int userId)
        {
            UserBLL userBLL = new UserBLL();
            User user = userBLL.getById(userId);
            if (user != null && booksDataGridView.SelectedRows.Count>0)
            {
                booksDataGridView.SelectedRows[0].Cells[7].Value = user.account.AccountName;
                booksDataGridView.SelectedRows[0].Cells[8].Value = user.UserId;
                int bookId = Convert.ToInt32(booksDataGridView.SelectedRows[0].Cells[1].Value);
                users[bookId] =user;
                lendBtn.Enabled = users.Count > 0;
                MessageBox.Show("Assign the book to the user!", "Select user", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void booksDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (booksDataGridView.SelectedRows.Count > 0)
            {
                userButton.Enabled = true;
                cancelBtn.Enabled = true;
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            users.Clear();
            lendBtn.Enabled = false;
            updateNameInfo();
        }

        private void lendBtn_Click(object sender, EventArgs e)
        {
            if (users.Count > 0)
            {
                BooksBLL booksBLL = new BooksBLL();
                if (booksBLL.lendToUsers(users))
                {
                    users.Clear();
                    lendBtn.Enabled = false;
                    updateNameInfo();
                    MessageBox.Show("Congratulations! You have lended the book to the user!", "Lend books", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
                else
                {
                    MessageBox.Show("Failed to lend a book!", "Lend books", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("The user list is empty", "Lend books", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
