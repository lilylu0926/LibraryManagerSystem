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

namespace LibraryMS
{
    public partial class FrmStaff : Form
    {
        public Account signAccount { get; set; }
        public FrmStaff()
        {
            InitializeComponent();
        }

        private void FrmStaff_Load(object sender, EventArgs e)
        {
            updateNameInfo();
        }

        private void updateNameInfo()
        {
            //if (signAccount != null)
            //{
            //   // nameLabel.Text = signAccount.AccountName;
            //}
            BookInfoBLL bookInfoBLL = new BookInfoBLL();
            List<BookInfo> books= bookInfoBLL.getAll();
            bookDataGridView.AutoGenerateColumns= false;
            bookDataGridView.DataSource= books;
            bookDataGridView.SelectedRows[0].Selected= false;
        }
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            this.Close();
                
        }

        private void textBoxB_Name_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonSearchBook_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxBook_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            BookInfoBLL bookInfoBLL=new BookInfoBLL();
            int id = Convert.ToInt32(textBoxB_Name.Text);
            MessageBox.Show(bookInfoBLL.getById(id).ToString());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
