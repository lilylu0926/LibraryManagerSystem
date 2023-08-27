using LibraryMS.BLL;
using LibraryMS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace LibraryMS.frmuser
{
    
    public partial class FrmBorrowBook : Form
    {
        public Book lastBookCondition;
        public int userId;
        //key:bookID
        private Dictionary<int, User> users = new Dictionary<int, User>();
        public FrmBorrowBook()
        {
            InitializeComponent();
        }

        private void FrmBorrowBook_Load(object sender, EventArgs e)
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
            borrowButton.Enabled = false;
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
                    e.Value = "CA " + (e.Value as BookInfo).Price.ToString("F2");

                }
            }
        }

        private void returnbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void booksDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            booksDataGridView.ClearSelection();
            booksDataGridView.CurrentCell = null;
        }



        private void booksDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (booksDataGridView.Columns.Contains("BorrowCol") && e.ColumnIndex == booksDataGridView.Columns["BorrowCol"].Index)
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
                    borrowButton.Enabled = true;
                    cancelBtn.Enabled = true;
                }
                else
                {
                    borrowButton.Enabled = false;
                    cancelBtn.Enabled = false;
                }
            }
        }

    

        private void booksDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ( e.ColumnIndex == booksDataGridView.Columns["BorrowCol"].Index)
            {
            booksDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);

               
            }
        }

        private void borrowButton_Click(object sender, EventArgs e)
        {
            if (users.Count > 0)
            {
                BooksBLL booksBLL = new BooksBLL();
                if (booksBLL.lendToUsers(users))
                {
                    users.Clear();
                    borrowButton.Enabled = false;
                    updateNameInfo();
                    MessageBox.Show("Congratulations! You have borrowed a book!", "Borrow books", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Failed to borrow a book. Try again!", "Borrow books", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("The booklist is empty", "Borrow books", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            updateNameInfo();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
