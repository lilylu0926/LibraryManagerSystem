using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMS.Model
{
    public class BookInfo
    {
       
        private int _bookInfoId;
        private string _bookName;
        private string _iSBN13;
        private string _author;
        private string _publisher;
        private double _price;
        
        private int getBookTotal()
        {
            if (books != null)
            {
                if (books.Count==1 & (books[0]==null))
                {
                    return 0;
                }
                else
                {
                    return books.Count;
                }
            }
            else
            {
                return 0;
            }
        }

        private int getReserved()
        {
            int sum = 0;
            if (books != null)
            {
                books.ForEach(book =>
                {
                    if (book!=null && book.IsReserved.GetValueOrDefault())
                    {
                        sum++;
                    }
                });
            }
            return sum;
        }



        private int getAvailableCount()
        {
            int sum = 0;
            if (books != null)
            {
                foreach (Book book in books)
                {
                    if (book != null && book.UserId != 0)
                    {
                        sum++;
                    }
                }
            }
            return Total-sum- Reserved;
        }
      

        public int BookInfoId { get => _bookInfoId; set => _bookInfoId = value; }
        public string BookName { get => _bookName; set => _bookName = value; }
        public string ISBN13 { get => _iSBN13; set => _iSBN13 = value; }
        public string Author { get => _author; set => _author = value; }
        public string Publisher { get => _publisher; set => _publisher = value; }
        public double Price { get => _price; set => _price = value; }
        public List<Book> books { get; set; }
        public int Total { get=> getBookTotal(); }
        public int Reserved { get => getReserved(); }
        public int AvailableCount { get => getAvailableCount(); }
       
    }
}
