using ClassLibrary1;
using LibraryMS.DAS;
using LibraryMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMS.BLL
{
    public class BookInfoBLL
    {
        /// <summary>
        /// search all bookinfo
        /// </summary>
        /// <returns></returns>
        public List<BookInfo> getAll()
        {
            BookInfoDAS bookInfoDAS = new BookInfoDAS();
            return bookInfoDAS.getAll();
        }

        /// <summary>
        /// Search by multi-conditions
        /// </summary>
        /// <param name="bookInfo"></param>
        /// <returns></returns>
        public List<BookInfo> searchConditions(BookInfo bookInfo)
        {
            BookInfoDAS bookInfoDAS = new BookInfoDAS();
            return bookInfoDAS.searchConditions(bookInfo);
        }

        /// <summary>
        /// Add book information 
        /// </summary>
        /// <param name="bookInfo"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool add(BookInfo bookInfo, out String msg)
        {
            BookInfoDAS bookInfoDAS = new BookInfoDAS();
            //search if the ISBN has been existed
            BookInfo resultBookInfo = bookInfoDAS.getByISBN(bookInfo.ISBN13);
            if (resultBookInfo == null)
            {
                if (bookInfoDAS.add(bookInfo))
                {
                    msg = "Add book information successfully!";
                    return true;
                }
                else
                {
                    msg = "Failed to add book information!";
                    return true;

                }
            }
            else
            {
                msg = "The ISBN is existed already, Failed to add book information!";
                return false;
            }

        }

        /// <summary>
        /// update book information
        /// </summary>
        /// <param name="bookInfo"></param>
        /// <returns></returns>
        public bool update(BookInfo bookInfo)
        {
            BookInfoDAS bookInfoDAS = new BookInfoDAS();
            return bookInfoDAS.update(bookInfo);
        }

        public bool deleteById(int bookInfoId)
        {

            return false;
        }

        public bool deleteByBookInfoId(int bookInfoId,out String msg)
        {
            BooksDAS booksDAS = new BooksDAS();
            List<Book> books = booksDAS.getBorrowedByBookInfoId(bookInfoId);
            if (books.Count>0)
            {
                msg = "There are " + books.Count + " books not returned yet. The book information can not be deleted!";
                return false;
            }
            else
            {
                BookInfoDAS bookInfoDAS = new BookInfoDAS();
                if (bookInfoDAS.deleteByBookInfoId(bookInfoId))
                {
                    msg = "Delete the book information successfully!";
                    return true;
                }
                else
                {
                    msg = "Failed to delete the book information!";
                    return false;
                }
            }


        }


    }


}
