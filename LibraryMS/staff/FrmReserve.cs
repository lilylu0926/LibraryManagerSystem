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
    public partial class FrmReserve : Form
    {
        public Book lastBookCondition;
        private int lastSelectIndex;

        public FrmReserve()
        {
            InitializeComponent();
        }

        private void FrmReserve_Load(object sender, EventArgs e)
        {
            updateNameInfo();
        }

        private void updateNameInfo()
        {
            BooksBLL booksBLL = new BooksBLL();
            //List<Book> books = booksBLL.getAllAvailableOrReserved();
            List<Book> books = booksBLL.getAvailableOrReservedConditions(lastBookCondition);
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
            reservedBtn.Enabled = false;
            reservedBtn.Text= "";
        }

        private void booksDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            booksDataGridView.ClearSelection();
            booksDataGridView.CurrentCell = null;
        }

        private void booksDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                e.Value = e.RowIndex + 1;
            }
            //Book Name
            if (e.ColumnIndex == 2 && e.Value!=null)
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
                    e.Value ="CA "+ (e.Value as BookInfo).Price.ToString("F2");
                }
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
            booksDataGridView.DataSource = booksBLL.getAvailableOrReservedConditions(book);
            reservedBtn.Enabled = false;
            lastBookCondition = book;
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            BooksBLL booksBLL = new BooksBLL();
            List<Book> books = booksBLL.getAllAvailableOrReserved();
            booksDataGridView.DataSource = books;
            bookNameText.Text = string.Empty;
            ISBNText.Text = string.Empty;
            authorText.Text = string.Empty;
            publisherText.Text = string.Empty;
            reservedBtn.Enabled = false;
            reservedCheckBox.Checked = false;
            unReservdcheckBox.Checked = false;
            lastBookCondition = null;

        }

        private void booksDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (booksDataGridView.SelectedRows.Count > 0)
            {
                bool isReserved = booksDataGridView.SelectedRows[0].Cells[7].Value.ToString().Equals("True");
                if (isReserved)
                {
                   reservedBtn.Text = "";
                    Image backImage = Properties.Resources.cancelRESERVE;
                    reservedBtn.BackgroundImage = backImage;
                }
                else
                {
                    reservedBtn.Text = "";
                    Image backImage = Properties.Resources.reserve;
                    reservedBtn.BackgroundImage = backImage;
                }
                reservedBtn.Enabled = true;
            }
        }

        private void reservedBtn_Click(object sender, EventArgs e)
        {
            if (booksDataGridView.SelectedRows.Count>0)
            {
                int bookId = Convert.ToInt32(booksDataGridView.SelectedRows[0].Cells[1].Value);
                bool isReserved = Convert.ToBoolean(booksDataGridView.SelectedRows[0].Cells[7].Value);
                lastSelectIndex = booksDataGridView.SelectedRows[0].Index;
                BooksBLL booksBLL = new BooksBLL();
                String msg = "";
                bool flag = false;
                if (!isReserved)
                {
                    flag = booksBLL.updateReservedStatusByBookId(bookId, true);
                    msg = flag ? "The book is successfully reserved!" : "Failed to reserve the book!";
                    if (flag)
                    {
                        Image backImage = Properties.Resources.cancelRESERVE;
                        reservedBtn.BackgroundImage = backImage;
                    }
                    else
                    {
                        Image backImage = Properties.Resources.reserve;
                        reservedBtn.BackgroundImage = backImage;

                    }
                   // reservedBtn.Text = flag ? "UnReserve":"Reserve";
                }
                else
                {
                    flag = booksBLL.updateReservedStatusByBookId(bookId, false);
                    msg = flag ? "Thank you. The book is not reserved" : "Failed to unreserve the book!";
                    //reservedBtn.Text = flag ? "Reserve":"Unreserve";
                    if (flag)
                    {
                        Image backImage = Properties.Resources.cancelRESERVE;
                        reservedBtn.BackgroundImage = backImage;
                    }
                    else
                    {
                        Image backImage = Properties.Resources.reserve;
                        reservedBtn.BackgroundImage = backImage;

                    }
                }
                if (flag)
                {
                    booksDataGridView.DataSource = booksBLL.getAvailableOrReservedConditions(lastBookCondition);
                    if (booksDataGridView.RowCount > 1)
                    {
                        if (lastBookCondition!=null && lastBookCondition.IsReserved!=null)
                        {
                            bool flag2 = lastBookCondition.IsReserved.GetValueOrDefault() & reservedBtn.Text.Equals("Unreserve");
                            flag2 = flag2 || !lastBookCondition.IsReserved.GetValueOrDefault() & reservedBtn.Text.Equals("Reserve");
                            if (flag2)
                            {
                    
                                booksDataGridView.Rows[lastSelectIndex].Selected = true;
                                int firstVisibleRowIndex = booksDataGridView.FirstDisplayedScrollingRowIndex;
                                int displayedRowCount = booksDataGridView.DisplayedRowCount(true);
                                if ((lastSelectIndex < firstVisibleRowIndex) || (lastSelectIndex > displayedRowCount - 1))
                                {
                                    booksDataGridView.FirstDisplayedScrollingRowIndex = lastSelectIndex;
                                }
                            }

                        }
                        else
                        {
                            booksDataGridView.Rows[lastSelectIndex].Selected = true;
                            int firstVisibleRowIndex = booksDataGridView.FirstDisplayedScrollingRowIndex;
                            int displayedRowCount = booksDataGridView.DisplayedRowCount(true);
                            if ((lastSelectIndex < firstVisibleRowIndex) || (lastSelectIndex > displayedRowCount - 1))
                            {
                                booksDataGridView.FirstDisplayedScrollingRowIndex = lastSelectIndex;
                            }
                        }
                        
                    }
                    MessageBox.Show(msg, "Reserve", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(msg, "Reserve", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Please, select one book first!", "Reserve", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }
    }
}
