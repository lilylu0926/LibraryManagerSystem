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
    public partial class FrmBookList : Form
    {
        List<Book> books = null;
        private Book lastSearchCondition;
        public FrmBookList()
        {
            InitializeComponent();
        }

        private void FrmBookList_Load(object sender, EventArgs e)
        {
            updateNameInfo();
        }

        private void updateNameInfo()
        {
            BooksBLL booksBLL = new BooksBLL();
            //List<Book> books = booksBLL.getAllAvailableOrReserved();
            books = booksBLL.getAll();
            FontFamily fontFamily = new FontFamily("Arial");
            Font newFont = new Font(fontFamily, 12);
            booksDataGridView.DefaultCellStyle.Font = newFont;
            booksDataGridView.ColumnHeadersDefaultCellStyle.Font = new Font(booksDataGridView.Font.FontFamily, 14);
            booksDataGridView.EnableHeadersVisualStyles = false;
            booksDataGridView.Columns["BookName"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            booksDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            booksDataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            booksDataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            booksDataGridView.AutoGenerateColumns = false;
            booksDataGridView.DataSource = books;
            booksDataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            booksDataGridView.DefaultCellStyle.Padding = new Padding(5);
            deleteButton.Enabled = false;
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
                    e.Value = "CA "+(e.Value as BookInfo).Price.ToString("F2");
                }
            }
            //UserName
            if (e.ColumnIndex == 8 && e.Value != null)
            {
                if (e.Value is int)
                {

                    AccountBLL accountBLL = new AccountBLL();
                    Account account = accountBLL.GetById((int)e.Value);
                    if (account != null) { e.Value = account.AccountName; }
                    else { e.Value = String.Empty; }

                }
            }

        }

        private void booksDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (booksDataGridView.RowCount > 0)
            {
                BorrowHistoryBLL borrowHistoryBLL = new BorrowHistoryBLL();
                for (int i = 0; i < booksDataGridView.RowCount; i++)
                {
                    int bookId = Convert.ToInt32(booksDataGridView.Rows[i].Cells[1].Value);
                    int userId = Convert.ToInt32(booksDataGridView.Rows[i].Cells[10].Value);
                    BorrowHistory borrowHistory = borrowHistoryBLL.getCurrentBorrow(bookId, userId);
                    if (borrowHistory != null)
                    {
                        booksDataGridView.Rows[i].Cells[9].Value = borrowHistory.BorrowDate;
                    }
                }

            }
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
            if ((reservedCheckBox.Checked & !unReservdcheckBox.Checked) || (!reservedCheckBox.Checked & unReservdcheckBox.Checked))
            {
                book.IsReserved = reservedCheckBox.Checked;
            }
            else
            {
                book.IsReserved = null;
            }

            book.bookInfo = bookInfo;
            BooksBLL booksBLL = new BooksBLL();
            booksDataGridView.DataSource = booksBLL.getAllConditions(book);
            deleteButton.Enabled = false;
            lastSearchCondition = book;
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            updateNameInfo();
            bookNameText.Text = string.Empty;
            ISBNText.Text = string.Empty;
            authorText.Text = string.Empty;
            publisherText.Text = string.Empty;
            reservedCheckBox.Checked = false;
            unReservdcheckBox.Checked = false;

        }

        private void booksDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (Convert.ToInt32(booksDataGridView.SelectedRows[0].Cells[8].Value) == 0)
            {
                deleteButton.Enabled = true;
            }
            else
            {
                deleteButton.Enabled = false;
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {

            if (Convert.ToInt32(booksDataGridView.SelectedRows[0].Cells[8].Value) == 0)
            {
                if (MessageBox.Show("Do you confirm to delete this book from the list？", "Delete confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    int bookSelectedIndex = booksDataGridView.SelectedRows[0].Index;
                    int bookId = Convert.ToInt32(booksDataGridView.SelectedRows[0].Cells[1].Value);
                    BooksBLL booksBLL = new BooksBLL();
                    if (booksBLL.deleteByBookId(bookId))
                    {
                        if (this.lastSearchCondition != null)
                        {
                            booksDataGridView.DataSource = booksBLL.getAllConditions(this.lastSearchCondition);
                        }
                        else
                        {
                            booksDataGridView.DataSource = booksBLL.getAll();
                        }

                        if (bookSelectedIndex >= booksDataGridView.RowCount)
                        {
                            bookSelectedIndex = booksDataGridView.RowCount - 1;
                        }
                        if (booksDataGridView.RowCount > 1)
                        {
                            booksDataGridView.Rows[bookSelectedIndex].Selected = true;
                            int firstVisibleRowIndex = booksDataGridView.FirstDisplayedScrollingRowIndex;
                            int displayedRowCount = booksDataGridView.DisplayedRowCount(true);
                            if ((bookSelectedIndex < firstVisibleRowIndex) || (bookSelectedIndex > displayedRowCount - 1))
                            {
                                booksDataGridView.FirstDisplayedScrollingRowIndex = bookSelectedIndex;
                            }                    

                        }
                        MessageBox.Show("Delete the book from library successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete the book", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

            }
            else
            {
                MessageBox.Show("The book can not be deleted!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


    }
}
