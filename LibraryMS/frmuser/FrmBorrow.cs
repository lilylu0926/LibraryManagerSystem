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
    public partial class FrmBorrow : Form
    {
      
        public BookInfo lastSearchedBookInfo;
        public delegate void passHandleBookInfoEvent(int bookInfoId, int rowindex, BookInfo lastSearchedBookInfo);
        public event passHandleBookInfoEvent PassBookInfoEvent;
        public int? lastSelectIndex;
        public FrmBorrow()
        {
            InitializeComponent();
        }

        private void FrmBorrow_Load(object sender, EventArgs e)
        {
            updateNameInfo();
        }

        private void updateNameInfo()
        {
            /*if (signAccount != null)
            {
               // nameLabel.Text = signAccount.AccountName;
            }*/

            BookInfoBLL bookInfoBLL = new BookInfoBLL();
            List<BookInfo> books = bookInfoBLL.searchConditions(lastSearchedBookInfo);
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
            borrowBtn.Enabled = false;
            if (lastSearchedBookInfo != null)
            {
                bookNameText.Text = lastSearchedBookInfo.BookName;
                authorText.Text = lastSearchedBookInfo.Author;
                ISBNText.Text= lastSearchedBookInfo.ISBN13;
                publisherText.Text = lastSearchedBookInfo.Publisher;
            }



        }

        private void bookDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (lastSelectIndex == null)
            {
                bookDataGridView.ClearSelection();
                bookDataGridView.CurrentCell = null;
            }
            else
            {
                int lastSelectIndex1 = (int)lastSelectIndex;
                bookDataGridView.Rows[lastSelectIndex1].Selected = true;
                int firstVisibleRowIndex = bookDataGridView.FirstDisplayedScrollingRowIndex;
                int displayedRowCount = bookDataGridView.DisplayedRowCount(true);
                if ((lastSelectIndex1 < firstVisibleRowIndex) || (lastSelectIndex1 > displayedRowCount - 1))
                {
                    bookDataGridView.FirstDisplayedScrollingRowIndex = lastSelectIndex1;
                }
            }

        }

        private void bookDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                e.Value = e.RowIndex + 1;
            }
            //Price
            if (e.ColumnIndex == 6 && e.Value != null)
            {
                if (e.Value is double db1)
                {
                    e.Value = "CA " + db1.ToString("F2");
                }

            }
        }

        private void bookDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bookDataGridView.SelectedRows.Count > 0)
            {
                int totalQty = Convert.ToInt32(bookDataGridView.SelectedRows[0].Cells[7].Value);
                int reservedQty = Convert.ToInt32(bookDataGridView.SelectedRows[0].Cells[8].Value);
                int availableQty = Convert.ToInt32(bookDataGridView.SelectedRows[0].Cells[9].Value);

               if (availableQty > 0)
                {

                    borrowBtn.Enabled = true;
                }
                else
                {
                    borrowBtn.Enabled = false;

                }

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
            borrowBtn.Enabled = false;
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
            borrowBtn.Enabled = false;
            lastSelectIndex = null;

        }

        private void borrowBtn_Click(object sender, EventArgs e)
        {
            if (bookDataGridView.SelectedRows.Count > 0)
            {
                int bookInfoId = Convert.ToInt32(bookDataGridView.SelectedRows[0].Cells[1].Value);
                PassBookInfoEvent?.Invoke(bookInfoId, bookDataGridView.SelectedRows[0].Index, lastSearchedBookInfo);



            }
        }

    }
}
