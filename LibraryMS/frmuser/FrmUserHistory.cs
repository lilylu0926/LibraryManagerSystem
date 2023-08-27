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

namespace LibraryMS.frmuser
{
    public partial class FrmUserHistory : Form
    {
        public int userId;
        public FrmUserHistory()
        {
            InitializeComponent();
        }

        private void FrmUserHistory_Load(object sender, EventArgs e)
        {
            updateNameInfo();
        }

        private void updateNameInfo()
        {
            BorrowHistoryBLL borrowHistoryBLL = new BorrowHistoryBLL();
            List<BorrowHistory> borrowHistories = borrowHistoryBLL.getHistoryBorrowByUserId(userId);
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
            booksDataGridView.DataSource = borrowHistories;
            booksDataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            booksDataGridView.DefaultCellStyle.Padding = new Padding(5);
            deleteBtn.Enabled = false;
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
                if (e.Value is Book)
                {
                    e.Value = (e.Value as Book).bookInfo.BookName;
                }
            }
            //ISBN
            if (e.ColumnIndex == 3 && e.Value != null)
            {
                if (e.Value is Book)
                {
                    e.Value = (e.Value as Book).bookInfo.ISBN13;
                }
            }
            //Author
            if (e.ColumnIndex == 4 && e.Value != null)
            {
                if (e.Value is Book)
                {
                    e.Value = (e.Value as Book).bookInfo.Author;
                }
            }
            //Publisher
            if (e.ColumnIndex == 5 && e.Value != null)
            {
                if (e.Value is Book)
                {
                    e.Value = (e.Value as Book).bookInfo.Publisher;
                }
            }
            //Price
            if (e.ColumnIndex == 6 && e.Value != null)
            {
                if (e.Value is Book)
                {
                    e.Value ="CA "+ (e.Value as Book).bookInfo.Price.ToString("F2");
                }
            }
        }

        private void booksDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            booksDataGridView.ClearSelection();
            booksDataGridView.CurrentCell = null;
        }

        private void booksDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (booksDataGridView.SelectedRows.Count> 0)
            {
                deleteBtn.Enabled = true;
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (booksDataGridView.SelectedRows.Count> 0)
            {
                if (MessageBox.Show("Do you confirm to delete the borrow record from list？", "Delete confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(booksDataGridView.SelectedRows[0].Cells["id"].Value);
                    BorrowHistoryBLL borrowHistoryBLL = new BorrowHistoryBLL();
                    if (borrowHistoryBLL.deleteById(id))
                    {
                        int bookSelectedIndex = booksDataGridView.SelectedRows[0].Index;
                        updateNameInfo();
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
                        MessageBox.Show("Delete the borrow record from list successfully!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete the borrow record from list!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select one record first!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
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
            book.UserId= userId;
            BorrowHistoryBLL borrowHistoryBLL = new BorrowHistoryBLL();
            booksDataGridView.DataSource = borrowHistoryBLL.getAllConditions(book);
            deleteBtn.Enabled = false;
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            updateNameInfo();

            bookNameText.Text = string.Empty;
            ISBNText.Text = string.Empty;
            authorText.Text = string.Empty;
            publisherText.Text = string.Empty;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
