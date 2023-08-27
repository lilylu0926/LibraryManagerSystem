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
    public partial class FrmSaleHistory : Form
    {
        public Account account;
        private SaleHistory lastSearchCondition;
        public FrmSaleHistory()
        {
            InitializeComponent();
        }

        private void FrmSaleHistory_Load(object sender, EventArgs e)
        {
            updateNameInfo();

        }

        /*private Point getTotalLabelPosition()
        {
            int subtotalColumMiddlePoint = bookDataGridView.Location.X + bookDataGridView.Width - bookDataGridView.Columns["subTotal"].Width / 2;
            return new Point(subtotalColumMiddlePoint - totalNumberLabel.Width / 2, 10); 
        }

        private Point getTotalTitleLabelPosition()
        {
            int subtotalColumMiddlePoint = bookDataGridView.Location.X + bookDataGridView.Width - bookDataGridView.Columns["subTotal"].Width - totalTitleLabel.Width / 2;
            return new Point(subtotalColumMiddlePoint - totalTitleLabel.Width / 2,  10);
        }*/

        private void updateNameInfo()
        {
            SaleHistoryBLL saleHistoryBLL = new SaleHistoryBLL();
            SaleHistory saleHistory = new SaleHistory();
            saleHistory.SupplierId = account.AccountId;
            List<SaleHistory> saleHistories = saleHistoryBLL.getAllConditionsBySupplierId(saleHistory);
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
            bookDataGridView.DataSource = saleHistories;
            bookDataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            bookDataGridView.DefaultCellStyle.Padding = new Padding(5);
            deleteButton.Enabled = false;
            double sum = 0;
            foreach (SaleHistory saleHistory1 in saleHistories)
            {
                sum += saleHistory1.subTotal;
            }
            totalNumberLabel.Text = "CA "+ sum.ToString("F2");
            dateCheckBox.Checked = false;
            fromLabel.Enabled = false;
            toLabel.Enabled = false;
            startDateTimePicker.Enabled = false;
            endDateTimePicker.Enabled = false;
            bookNameText.Text = string.Empty;
            ISBNText.Text = string.Empty;
            authorText.Text = string.Empty;
            publisherText.Text = string.Empty;


        }

        private void bookDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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
                    e.Value = "CA " + (e.Value as BookInfo).Price.ToString("F2");
                }
            }
            //subtotal
            if (e.ColumnIndex == 9 && e.Value != null)
            {
                if (e.Value is double db1)
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

        private void deleteButton_Click(object sender, EventArgs e)
        {
            
        }

        private void FrmSaleHistory_Shown(object sender, EventArgs e)
        {
            //totalNumberLabel.Location = getTotalLabelPosition();
           // totalTitleLabel.Location = getTotalTitleLabelPosition();
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            SaleHistory saleHistory= new SaleHistory();
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
            if (dateCheckBox.Checked)
            {
                saleHistory.SaleDate =new DateTime(startDateTimePicker.Value.Year, startDateTimePicker.Value.Month, startDateTimePicker.Value.Day,0,0,0);
                saleHistory.EndSaleDate = new DateTime(endDateTimePicker.Value.Year, endDateTimePicker.Value.Month, endDateTimePicker.Value.Day, 23, 59, 59);
            }
            

            saleHistory.bookInfo = bookInfo;
            saleHistory.SupplierId = account.AccountId;
            SaleHistoryBLL saleHistoryBLL = new SaleHistoryBLL();
            List<SaleHistory> saleHistories = saleHistoryBLL.getAllConditionsBySupplierId(saleHistory);
            bookDataGridView.DataSource = saleHistories;
            deleteButton.Enabled = false;
            lastSearchCondition = saleHistory;
            double sum = 0;
            foreach (SaleHistory saleHistory1 in saleHistories)
            {
                sum += saleHistory1.subTotal;
            }
            totalNumberLabel.Text = "CA " + sum.ToString("F2");
        }

        private void dateCheckBox_Click(object sender, EventArgs e)
        {
            
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            updateNameInfo();
        }

        private void dateCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            fromLabel.Enabled = dateCheckBox.Checked;
            toLabel.Enabled = dateCheckBox.Checked;
            startDateTimePicker.Enabled = dateCheckBox.Checked;
            endDateTimePicker.Enabled = dateCheckBox.Checked;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime t = startDateTimePicker.Value;
            MessageBox.Show(t.ToString());
        }

        private void bookDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bookDataGridView.SelectedRows.Count > 0)
            {
                deleteButton.Enabled = true;
            }
        }

        private void deleteButton_Click_1(object sender, EventArgs e)
        {
            if (bookDataGridView.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Do you confirm to delete the sale record from list？", "Deletion is confi confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(bookDataGridView.SelectedRows[0].Cells["BookSaleId"].Value);
                    SaleHistoryBLL saleHistoryBLL = new SaleHistoryBLL();
                    if (saleHistoryBLL.deleteById(id))
                    {
                        int bookSelectedIndex = bookDataGridView.SelectedRows[0].Index;
                        updateNameInfo();
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
                        MessageBox.Show("Delete the sale record from list successfully!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete the sale record from list!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select one record first!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
