using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryMS.DAS;
using LibraryMS.Model;
using ClassLibrary1;
using System.Net;

namespace LibraryMS.BLL
{
    public class BooksBLL
    {
        public List<Book> getReserveORBorrowByBookInfoId(int bookInfoId)
        {
            BooksDAS booksDAS = new BooksDAS();
            return booksDAS.getBorrowedByBookInfoId(bookInfoId);
        }

        /// <summary>
        /// Get the books that have been reserved or not borrowed
        /// </summary>
        /// <returns></returns>
        public List<Book> getAllAvailableOrReserved()
        {
            BooksDAS booksDAS = new BooksDAS();
            return booksDAS.getAllAvailableOrReserved();
        }

        /// <summary>
        /// Get books by multi coditions
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public List<Book> getAvailableOrReservedConditions(Book book)
        {
            BooksDAS booksDAS = new BooksDAS();
            return booksDAS.getAvailableOrReservedConditions(book);
        }

        /// <summary>
        /// Get books Available by multi coditions
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public List<Book> getAvailableConditions(Book book)
        {
            BooksDAS booksDAS = new BooksDAS();
            return booksDAS.getAvailableConditions(book);
        }

        /// <summary>
        /// set IsReserved status by book id
        /// </summary>
        /// <param name="bookId"></param>
        /// <param name="isReserved"></param>
        /// <returns></returns>
        public bool updateReservedStatusByBookId(int bookId, bool isReserved)
        {
            BooksDAS booksDAS = new BooksDAS();
            return booksDAS.updateReservedStatusByBookId(bookId, isReserved);
        }

        /// <summary>
        /// Lend books to many users once
        /// </summary>
        /// <param name="users">key:BookId</param>
        /// <returns></returns>
        public bool lendToUsers(Dictionary<int, User> users)
        {
            BooksDAS booksDAS = new BooksDAS();
            return booksDAS.lendToUsers(users);
        }

        public bool returnFromUsers(Dictionary<int, User> users)
        {
            BooksDAS booksDAS = new BooksDAS();
            return booksDAS.returnFromUsers(users);
        }

        /// <summary>
        /// Get All the books Information
        /// </summary>
        /// <returns></returns>
        public List<Book> getAll()
        {
            BooksDAS booksDAS = new BooksDAS();
            return booksDAS.getAll();
        }

        public List<Book> getAllConditions(Book book)
        {
            BooksDAS booksDAS = new BooksDAS();
            return booksDAS.getAllConditions(book);
        }

        public bool deleteByBookId(int bookId)
        {
            BooksDAS booksDAS = new BooksDAS();
            return booksDAS.deleteByBookId(bookId);
        }

        /// <summary>
        /// Supplier sell books
        /// </summary>
        /// <param name="supplierId"></param>
        /// <param name="bookInfoId"></param>
        /// <param name="qty"></param>
        /// <returns></returns>
        public bool addWithBookInfoId(int supplierId, int bookInfoId, int qty)
        {
            BooksDAS booksDAS = new BooksDAS();
            return booksDAS.addWithBookInfoId(supplierId,bookInfoId,qty);
        }
    }
}
