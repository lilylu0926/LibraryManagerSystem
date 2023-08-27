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
    public partial class FrmMember : Form
    {
        private User lastUserCondition;
        public FrmMember()
        {
            InitializeComponent();
        }

        private void FrmMember_Load(object sender, EventArgs e)
        {
            updateNameInfo();
        }

        private void updateNameInfo()
        {
            UserBLL userBLL = new UserBLL();
            List<User> users = userBLL.GetAll();
            FontFamily fontFamily = new FontFamily("Arial");
            Font newFont = new Font(fontFamily, 12);
            booksDataGridView.DefaultCellStyle.Font = newFont;
            booksDataGridView.ColumnHeadersDefaultCellStyle.Font = new Font(booksDataGridView.Font.FontFamily, 14);
            booksDataGridView.EnableHeadersVisualStyles = false;
            booksDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            booksDataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            booksDataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            booksDataGridView.AutoGenerateColumns = false;
            booksDataGridView.DataSource = users;
            booksDataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            booksDataGridView.DefaultCellStyle.Padding = new Padding(5);
            if (booksDataGridView.SelectedRows.Count > 0)
            {
                setButton.Enabled = true;
            }
            else
            {
                setButton.Enabled = false;
            }


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
            //account Name
            if (e.ColumnIndex == 2 && e.Value != null)
            {
                if (e.Value is Account)
                {
                    e.Value = (e.Value as Account).AccountName;
                }
            }
            //user name
            if (e.ColumnIndex == 3 && e.Value != null)
            {
                if (e.Value is Account)
                {
                    e.Value = (e.Value as Account).FirstName + " " + (e.Value as Account).LastName;
                }
            }
            //telephone
            if (e.ColumnIndex == 4 && e.Value != null)
            {
                if (e.Value is Account)
                {
                    e.Value = (e.Value as Account).Telephone;
                }
            }
            //userstatus
            if (e.ColumnIndex == 5 && e.Value != null)
            {
                if (e.Value is UserStatus)
                {
                    e.Value = (e.Value as UserStatus).StatusName;
                }
            }
        }

        private void booksDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (booksDataGridView.SelectedRows.Count > 0)
            {
                int statusId = Convert.ToInt32(booksDataGridView.SelectedRows[0].Cells[6].Value);
                if (statusId == 2)
                {
                    setButton.Enabled = true;
                }
                else
                {
                    setButton.Enabled = false;
                }
               
            }
        }

        private void setButton_Click(object sender, EventArgs e)
        {
            if (booksDataGridView.SelectedRows.Count > 0)
            {
                int userId = Convert.ToInt32(booksDataGridView.SelectedRows[0].Cells[1].Value);
                int statusId = Convert.ToInt32(booksDataGridView.SelectedRows[0].Cells[6].Value);
                if (statusId==2)
                {
                    int lastSelectIndex = booksDataGridView.SelectedRows[0].Index;
                    UserBLL userBLL = new UserBLL();
                    if (userBLL.accepteMember(userId))
                    {
                        booksDataGridView.DataSource = userBLL.getConditions(lastUserCondition);
                        if (booksDataGridView.RowCount > 1)
                        {
                            booksDataGridView.Rows[lastSelectIndex].Selected = true;
                            int firstVisibleRowIndex = booksDataGridView.FirstDisplayedScrollingRowIndex;
                            int displayedRowCount = booksDataGridView.DisplayedRowCount(true);
                            if ((lastSelectIndex < firstVisibleRowIndex) || (lastSelectIndex > displayedRowCount - 1))
                            {
                                booksDataGridView.FirstDisplayedScrollingRowIndex = lastSelectIndex;
                            }
                        }
                        setButton.Enabled= false;
                        MessageBox.Show("The user is accepted to be a member successfully!", "Accept member", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("The user is accepted to be a member successfully!", "Accept member", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            else
            {
                MessageBox.Show("Please select one book first!", "Reserve", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            User user = new User();
            Account account = null;
            if (!string.IsNullOrEmpty(accountText.Text))
            {
                if (account == null)
                {
                    account = new Account();
                }
                account.AccountName = accountText.Text.Trim();
            }
            if (!string.IsNullOrEmpty(userNameText.Text))
            {
                if (account == null)
                {
                    account = new Account();
                }
                account.FirstName = userNameText.Text.Trim();
            }
            int status = 0;
            if (memberCheckBox.Checked)
            {
                status += 4;
            }
            if (appliedCheckBox.Checked)
            {
                status += 2;
            }
            if (nonMembercheckBox.Checked)
            {
                status += 1;
            }
            user.StatusId = status;

            user.account = account;
            UserBLL userBLL = new UserBLL();
            booksDataGridView.DataSource = userBLL.getConditions(user);
            setButton.Enabled = false;
            lastUserCondition = user;
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            UserBLL userBLL = new UserBLL();
            List<User> users = userBLL.GetAll();
            booksDataGridView.DataSource = users;
            accountText.Text = string.Empty;
            userNameText.Text = string.Empty;
            setButton.Enabled = false;
            nonMembercheckBox.Checked = false;
            appliedCheckBox.Checked = false;
            memberCheckBox.Checked = false;
            lastUserCondition = null;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
