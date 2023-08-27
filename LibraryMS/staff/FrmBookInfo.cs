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

namespace LibraryMS.staff
{
    public partial class FrmBookInfo : Form
    {
        /// <summary>
        /// save current selectedIndex of bookdatagridview;
        /// </summary>
        private int bookSelectedIndex;

        private BookInfo lastSearchedBookInfo;

        public delegate void PassReservedBookInfoIdHandler(int boolInfoId);
        public event PassReservedBookInfoIdHandler PassReservedDataEvent;

        public delegate void PassLendBookInfoIdHandler(int boolInfoId);
        public event PassLendBookInfoIdHandler PassLendDataEvent;

        public FrmBookInfo()
        {
            InitializeComponent();
        }

        private void FrmBookInfo_Load(object sender, EventArgs e)
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
            updateBtn.Enabled = false;
            deleteBtn.Enabled = false;
            reserveBtn.Enabled = false;
            lendBtn.Enabled = false;
        }


        private void bookDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            bookDataGridView.ClearSelection();
            bookDataGridView.CurrentCell = null;
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


        private void resetBtn_Click(object sender, EventArgs e)
        {

            BookInfoBLL bookInfoBLL = new BookInfoBLL();
            List<BookInfo> allBooks = bookInfoBLL.getAll();
            bookDataGridView.DataSource = allBooks;
            bookSelectedIndex = 0;
            lastSearchedBookInfo = null;
            bookNameText.Text = string.Empty;
            ISBNText.Text = string.Empty;
            authorText.Text = string.Empty;
            publisherText.Text = string.Empty;
            updateBtn.Enabled = false;
            deleteBtn.Enabled = false;
            reserveBtn.Enabled = false;
            lendBtn.Enabled = false;
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
            updateBtn.Enabled = false;
            deleteBtn.Enabled = false;
            reserveBtn.Enabled = false;
            lendBtn.Enabled = false;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            AddAndUpdateClasses(1);
        }

        private void AddAndUpdateClasses(int p)
        {
            FrmBookInfoEdit frmBookInfoEdit = new FrmBookInfoEdit();
            //update
            if (p == 2)
            {
                bookSelectedIndex = bookDataGridView.SelectedRows[0].Index;
                frmBookInfoEdit.bookInfo = DataGridToBookInfo();
                frmBookInfoEdit.ButtonClicked += FrmBookInfoEdit_UpdateButtonClicked;

            }
            else
            {
                frmBookInfoEdit.ButtonClicked += FrmBookInfoEdit_AddButtonClicked;
            }

            frmBookInfoEdit.ShowDialog();

        }

        private void FrmBookInfoEdit_AddButtonClicked(object sender, EventArgs e)
        {
            BookInfoBLL bookInfoBLL = new BookInfoBLL();
            List<BookInfo> books = null;
            if (lastSearchedBookInfo != null)
            {
                books = bookInfoBLL.searchConditions(lastSearchedBookInfo);

            }
            else
            {
                books = bookInfoBLL.getAll();
            }
            bookDataGridView.DataSource = books;
            if (bookDataGridView.RowCount > 1)
            {
                bookDataGridView.Rows[bookDataGridView.Rows.Count - 1].Selected = true;
                int firstVisibleRowIndex = bookDataGridView.FirstDisplayedScrollingRowIndex;
                int displayedRowCount = bookDataGridView.DisplayedRowCount(true);
                if (bookDataGridView.RowCount> firstVisibleRowIndex+ displayedRowCount-1)
                {
                    bookDataGridView.FirstDisplayedScrollingRowIndex = bookDataGridView.RowCount - 1;
                }           
            }

        }

        private void FrmBookInfoEdit_UpdateButtonClicked(object sender, EventArgs e)
        {
            BookInfoBLL bookInfoBLL = new BookInfoBLL();
            List<BookInfo> books = null;
            if (lastSearchedBookInfo != null)
            {
                books = bookInfoBLL.searchConditions(lastSearchedBookInfo);

            }
            else
            {
                books = bookInfoBLL.getAll();
            }
            bookDataGridView.DataSource = books;
            if (bookDataGridView.RowCount > 1)
            {
                bookDataGridView.Rows[bookSelectedIndex].Selected = true;
                int firstVisibleRowIndex = bookDataGridView.FirstDisplayedScrollingRowIndex;
                int displayedRowCount = bookDataGridView.DisplayedRowCount(true);
                if ((bookSelectedIndex< firstVisibleRowIndex) || (bookSelectedIndex> displayedRowCount - 1))
                {
                    bookDataGridView.FirstDisplayedScrollingRowIndex = bookSelectedIndex;
                }
                
            }

        }

        private BookInfo DataGridToBookInfo()
        {
            BookInfo bookInfo = new BookInfo();
            bookInfo.BookInfoId = Convert.ToInt32(bookDataGridView.SelectedRows[0].Cells[1].Value);
            bookInfo.BookName = bookDataGridView.SelectedRows[0].Cells[2].Value.ToString();
            bookInfo.ISBN13 = bookDataGridView.SelectedRows[0].Cells[3].Value.ToString();
            bookInfo.Author = bookDataGridView.SelectedRows[0].Cells[4].Value.ToString();
            bookInfo.Publisher = bookDataGridView.SelectedRows[0].Cells[5].Value.ToString();
            bookInfo.Price = Convert.ToDouble(bookDataGridView.SelectedRows[0].Cells[6].Value);
            return bookInfo;
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (bookDataGridView.SelectedRows.Count > 0)
            {

                AddAndUpdateClasses(2);
            }
            else
            {
                MessageBox.Show("Please select one Book!");
            }
        }


        private void bookDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bookDataGridView.SelectedRows.Count > 0)
            {
                updateBtn.Enabled = true;
                int totalQty = Convert.ToInt32(bookDataGridView.SelectedRows[0].Cells[7].Value);
                int reservedQty = Convert.ToInt32(bookDataGridView.SelectedRows[0].Cells[8].Value);
                int availableQty = Convert.ToInt32(bookDataGridView.SelectedRows[0].Cells[9].Value);
                if (availableQty == (totalQty - reservedQty))
                {
                    deleteBtn.Enabled = true;
                }
                else
                {
                    deleteBtn.Enabled = false;
                }

                if (availableQty > 0 || reservedQty > 0)
                {
                    reserveBtn.Enabled = true;
                }
                else
                {
                    reserveBtn.Enabled = false;
                }

                if (availableQty > 0)
                {

                    lendBtn.Enabled = true;
                }
                else
                {
                    lendBtn.Enabled = false;

                }

            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you confirm to delete this book information？", "Delete confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                bookSelectedIndex = bookDataGridView.SelectedRows[0].Index;
                int bookInfoId = Convert.ToInt32(bookDataGridView.SelectedRows[0].Cells[1].Value);
                BookInfoBLL bookInfoBLL = new BookInfoBLL();
                String msg = "";
                if (bookInfoBLL.deleteByBookInfoId(bookInfoId, out msg))
                {
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

                    MessageBox.Show(msg, "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(msg, "Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void reserveBtn_Click(object sender, EventArgs e)
        {

            if (bookDataGridView.SelectedRows.Count > 0)
            {
                int bookInfoId = Convert.ToInt32(bookDataGridView.SelectedRows[0].Cells[1].Value);
                PassReservedDataEvent?.Invoke(bookInfoId);
            }
        }

        private void lendBtn_Click(object sender, EventArgs e)
        {
            if (bookDataGridView.SelectedRows.Count > 0)
            {
                int bookInfoId = Convert.ToInt32(bookDataGridView.SelectedRows[0].Cells[1].Value);
                PassLendDataEvent?.Invoke(bookInfoId);
            }
        }
    }
}
