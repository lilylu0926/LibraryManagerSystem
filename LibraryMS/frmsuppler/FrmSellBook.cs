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

namespace LibraryMS.frmsuppler
{
    public partial class FrmSellBook : Form
    {
        private BookInfo lastSearchedBookInfo;
        public Account account;
        private int bookSelectedIndex;
        public FrmSellBook()
        {
            InitializeComponent();
        }

        private void FrmSellBook_Load(object sender, EventArgs e)
        {

            updateNameInfo();

        }

        private void updateNameInfo()
        {
            BookInfoBLL bookInfoBLL = new BookInfoBLL();
            List<BookInfo> books = bookInfoBLL.getAll();
            FontFamily fontFamily = new FontFamily("Arial");
            Font newFont = new Font(fontFamily, 12);
            bookDataGridView.DefaultCellStyle.Font = newFont;
            bookDataGridView.Columns["BookName"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            bookDataGridView.ColumnHeadersDefaultCellStyle.Font = new Font(bookDataGridView.Font.FontFamily, 14);
            bookDataGridView.EnableHeadersVisualStyles = false;
            bookDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            bookDataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bookDataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bookDataGridView.AutoGenerateColumns = false;
            bookDataGridView.DataSource = books;
            bookDataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            bookDataGridView.DefaultCellStyle.Padding = new Padding(5);
            //sellGroupBox.Enabled = false;
            qtyTextBox.Enabled = false;
            sellButton.Enabled = false;
        }

        private void bookDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                e.Value = e.RowIndex + 1;
            }
            //Price
            if (e.ColumnIndex == 6 && e.Value != null)
            {   if (e.Value is double db1)
                {
                    e.Value = "CA " + db1.ToString("F2");
                }
               
            }
        }

        private void bookDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            bookDataGridView.ClearSelection();
            bookDataGridView.CurrentCell = null;
        }

        private void bookDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bookDataGridView.SelectedRows.Count > 0)
            {
                //sellGroupBox.Enabled = true;
                qtyTextBox.Enabled = true;
                sellButton.Enabled = true;


            }
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            BookInfo bookInfo = new BookInfo();

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
            BookInfoBLL bookInfoBLL = new BookInfoBLL();
            bookDataGridView.DataSource = bookInfoBLL.searchConditions(bookInfo);
            this.lastSearchedBookInfo = bookInfo;
            // sellGroupBox.Enabled = false;
            qtyTextBox.Enabled = false;
            sellButton.Enabled = false;
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            BookInfoBLL bookInfoBLL = new BookInfoBLL();
            List<BookInfo> allBooks = bookInfoBLL.getAll();
            bookDataGridView.DataSource = allBooks;
            lastSearchedBookInfo = null;
            bookNameText.Text = string.Empty;
            ISBNText.Text = string.Empty;
            authorText.Text = string.Empty;
            publisherText.Text = string.Empty;
            // sellGroupBox.Enabled = false;
            qtyTextBox.Enabled = false;
            sellButton.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (bookDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select one book information first !", "Sell book", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!Validation.QuantityValidation(qtyTextBox.Text.Trim()))
            {
                qtyTextBox.Focus();
                MessageBox.Show("Quantity must be integer!", "Sell book", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int qty = Convert.ToInt32(qtyTextBox.Text);
            String bookMsg = "";
            if (qty > 0)
            {
                String msg = "Do you confirm to sell " + qty.ToString();
                if (qty > 1)
                {
                    bookMsg = " books";
                }
                else
                {
                    bookMsg += " book";
                }
                if (MessageBox.Show(msg + bookMsg+" ?", "Delete confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    bookSelectedIndex = bookDataGridView.SelectedRows[0].Index;
                    int bookInfoId = Convert.ToInt32(bookDataGridView.SelectedRows[0].Cells[1].Value);
                    BooksBLL booksBLL = new BooksBLL();
                    if (booksBLL.addWithBookInfoId(account.AccountId, bookInfoId, qty))
                    {
                        BookInfoBLL bookInfoBLL = new BookInfoBLL();
                        if (this.lastSearchedBookInfo != null)
                        {
                            
                            bookDataGridView.DataSource = bookInfoBLL.searchConditions(this.lastSearchedBookInfo);
                        }
                        else
                        {
                            bookDataGridView.DataSource = bookInfoBLL.getAll();
                        }

                        if (bookSelectedIndex >= bookDataGridView.RowCount)
                        {
                            bookSelectedIndex = bookDataGridView.RowCount - 1;
                        }
                        if (bookDataGridView.RowCount > 1)
                        {
                            bookDataGridView.Rows[bookSelectedIndex].Selected = true;
                            int firstVisibleRowIndex = bookDataGridView.FirstDisplayedScrollingRowIndex;
                            int displayedRowCount = bookDataGridView.DisplayedRowCount(true);
                            if ((bookSelectedIndex < firstVisibleRowIndex) || (bookSelectedIndex > displayedRowCount - 1))
                            {
                                bookDataGridView.FirstDisplayedScrollingRowIndex = bookSelectedIndex;
                            }
                        }

                        MessageBox.Show("Sell " + qty.ToString()+bookMsg+" successfully!", "Sell book", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to sell " + qty.ToString() + bookMsg + " !", "Sell book", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("The book quantity must be great than 0!", "Sell book", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void sellGroupBox_Enter(object sender, EventArgs e)
        {

        }

        private void labelAuthor_Click(object sender, EventArgs e)
        {

        }
    }
}
