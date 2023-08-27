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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ScrollBar;

namespace LibraryMS.frmuser
{
    public partial class FrmReturn : Form
    {
        public int userId;
        //key:bookID
        private Dictionary<int, User> users = new Dictionary<int, User>();
        public FrmReturn()
        {
            InitializeComponent();
        }

        private void FrmReturn_Load(object sender, EventArgs e)
        {
            updateNameInfo();
        }

        private void updateNameInfo()
        {
            BorrowHistoryBLL borrowHistoryBLL = new BorrowHistoryBLL();
            List<BorrowHistory> borrowHistories = borrowHistoryBLL.getCurrentBorrowByUserId(userId);
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
            returnButton.Enabled = false;
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

        private void booksDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == booksDataGridView.Columns["ReturnCol"].Index)
            {
                booksDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);


            }
        }

        private void booksDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (booksDataGridView.Columns.Contains("ReturnCol") && e.ColumnIndex == booksDataGridView.Columns["ReturnCol"].Index)
            {
                bool flag = Convert.ToBoolean(booksDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                int bookId = Convert.ToInt32(booksDataGridView.Rows[e.RowIndex].Cells[1].Value);
                User user = new User();
                user.UserId = userId;

                if (flag)
                {
                    users[bookId] = user;
                }
                else
                {
                    users.Remove(bookId);
                }

                if (users.Count > 0)
                {
                    returnButton.Enabled = true;
                    cancelBtn.Enabled = true;
                }
                else
                {
                    returnButton.Enabled = false;
                    cancelBtn.Enabled = false;
                }
            }
        }

        private void returnButton_Click(object sender, EventArgs e)
        {
            if (users.Count > 0)
            {
                BooksBLL booksBLL = new BooksBLL();
                if (booksBLL.returnFromUsers(users))
                {
                    users.Clear();
                    returnButton.Enabled = false;
                    updateNameInfo();
                    MessageBox.Show("Thank you! You have returned a book", "Return books", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Failed to return a book!", "Return books", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("The booklist is empty", "Return books", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            updateNameInfo();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
