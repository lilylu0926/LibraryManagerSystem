using LibraryMS.BLL;
using LibraryMS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryMS.staff
{
    public partial class FrmBookInfoEdit : Form
    {
        public BookInfo bookInfo= null;
        public event EventHandler ButtonClicked;

        public FrmBookInfoEdit()
        {
            InitializeComponent();
        }

        private void FrmBookInfoEdit_Load(object sender, EventArgs e)
        {
            if (bookInfo != null)
            {
                titleLabel.Text = "Update Book Information";
            }
            else
            {
                titleLabel.Text = "Add Book Information";
            }

            update();
        }

        private void update()
        {
            if (bookInfo != null)
            {
                bookNameText.Text = bookInfo.BookName;
                ISBNText.Text = bookInfo.ISBN13;
                authorText.Text = bookInfo.Author;
                publisherText.Text = bookInfo.Publisher;
                priceText.Text = bookInfo.Price.ToString();

            }
            else
            {
                bookNameText.Text = string.Empty;
                ISBNText.Text = string.Empty;
                authorText.Text = string.Empty;
                publisherText.Text = string.Empty;
                priceText.Text = string.Empty;
            }
        }

        private void setBtn_Click(object sender, EventArgs e)
        {
            bool flag = false;
            String msg = "";

            if (bookInfo != null)
            {
                flag = UpdateBookInfo(out msg);
            }
            else
            {
                flag = AddBookInfo(out msg);
            }
            if (flag)
            {
                ButtonClicked?.Invoke(this, EventArgs.Empty);
                
            }
            MessageBox.Show(msg);

        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            update();
        }

        private bool AddBookInfo(out String msg)
        {
            if (!validationText(out msg))
                return false;
            BookInfo bookInfo = new BookInfo();
            bookInfo.BookName = bookNameText.Text.Trim();
            bookInfo.Author = authorText.Text.Trim() ;
            bookInfo.Publisher = publisherText.Text.Trim() ;
            bookInfo.ISBN13=ISBNText.Text.Trim() ;
            bookInfo.Price=Convert.ToDouble(priceText.Text.Trim()) ;
            

            BookInfoBLL bookInfoBLL = new BookInfoBLL();
            if (bookInfoBLL.add(bookInfo, out msg))
            {
                ButtonClicked?.Invoke(this, EventArgs.Empty);
                return true;
            }
            return false;


        }

        private bool UpdateBookInfo(out String msg)
        {
            if (!validationText(out msg))
                return false;

            bookInfo.BookName = bookNameText.Text.Trim();
            bookInfo.Author = authorText.Text.Trim();
            bookInfo.Publisher = publisherText.Text.Trim();
            bookInfo.ISBN13 = ISBNText.Text.Trim();
            bookInfo.Price = Convert.ToDouble(priceText.Text.Trim());
            BookInfoBLL bookInfoBLL = new BookInfoBLL();
            if (bookInfoBLL.update(bookInfo))
            {
                ButtonClicked?.Invoke(this, EventArgs.Empty);
                msg = "Update the book information successfully!";
                return true;
            }
            msg = "Failed to update the book information!";
            return false;
        }

        private bool validationText(out String msg)
        {
            if (string.IsNullOrEmpty(bookNameText.Text))
            {
                bookNameText.Focus();
                msg = "Book name is empty!";
                return false;
            }
            if (string.IsNullOrEmpty(authorText.Text))
            {
                authorText.Focus();
                msg = "Author name is empty!";
                return false;
            }
            if (string.IsNullOrEmpty(ISBNText.Text))
            {
                ISBNText.Focus();
                msg = "ISBN is empty!";
                return false;
            }
            if (string.IsNullOrEmpty(publisherText.Text))
            {
                publisherText.Focus();
                msg = "Publish name is empty!";
                return false;
            }
            if (string.IsNullOrEmpty(priceText.Text))
            {
                priceText.Focus();
                msg = "Price is empty!";
                return false;
            }
            if (!Validation.bookNameValidation(bookNameText.Text))
            {
                bookNameText.Focus();
                msg = "Book name must be characters and numbers!";
                return false;
            }
            if (!Validation.nameValidation(authorText.Text))
            {
                authorText.Focus();
                msg = "Author name must be characters!";
                return false;
            }

            if (!Validation.ISBNValidation(ISBNText.Text))
            {
                ISBNText.Focus();
                msg = "ISBN must be 13 numbers!";
                return false;
            }

            if (!Validation.publisherValidation(publisherText.Text))
            {
                publisherText.Focus();
                msg = "Publisher name must be characters!";
                return false;
            }

            if (!Validation.priceValidation(priceText.Text))
            {
                priceText.Focus();
                msg = "Price  must be double!";
                return false;
            }



            msg = "ok";
            return true;
        }
    }
}
