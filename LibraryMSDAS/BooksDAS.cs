using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryMS.Model;
using System.Net;
using System.Runtime.CompilerServices;

namespace LibraryMS.DAS
{
    public class BooksDAS
    {
        /// <summary>
        /// Get the books that have been borrowed by bookInfoId
        /// </summary>
        /// <param name="bookInfoId"></param>
        /// <returns></returns>
      public List<Book> getBorrowedByBookInfoId(int bookInfoId)
        {
            String sql = "select * from Books where BookInfoId=@BookInfoId and  UserId>0";
            DapperUtil dapper = new DapperUtil("conStr");
            return dapper.GetModelList<Book>(sql, new { BookInfoId = bookInfoId });
        }

        /// <summary>
        /// Get the books that have been reserved or not borrowed
        /// </summary>
        /// <returns></returns>
        public List<Book> getAllAvailableOrReserved()
        {
            String sql = @"select b.*,i.* from Books b
                           left join BookInfo i on b.BookInfoId=i.BookInfoId
                           where (IsReserved==1 or UserId is NULL)
                           order by b.BookInfoId;";
            DapperUtil dapper = new DapperUtil("conStr");
            return dapper.GetMultModelList<Book>(
                sql,
                new[] {typeof(Book), typeof(BookInfo)},
                (objs) =>
                {
                    Book book = objs[0] as Book;
                    BookInfo bookInfo= objs[1] as BookInfo;
                    book.bookInfo = bookInfo;
                    return book;
                },splitOn:"BookInfoId");
        }

        /// <summary>
        /// Get books Available or reserved by multi coditions
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public List<Book> getAvailableOrReservedConditions(Book book)
        {
            string sql = @"select b.*,i.* from Books b
                           left join BookInfo i on b.BookInfoId=i.BookInfoId
                           where (IsReserved==1 or UserId is NULL)";
            var parameters = new Dictionary<String, Object>();
            StringBuilder sb = new StringBuilder();
            if (book!=null && book.bookInfo != null)
            {
                if (!string.IsNullOrEmpty(book.bookInfo.BookName))
                {
                    sb.Append(" and BookName like @BookName");
                    parameters["BookName"] = "%" + book.bookInfo.BookName + "%";
                }
                if (!string.IsNullOrEmpty(book.bookInfo.ISBN13))
                {
                    sb.Append(" and ISBN13 like @ISBN13");
                    parameters["ISBN13"] = "%" + book.bookInfo.ISBN13 + "%";
                }
                if (!string.IsNullOrEmpty(book.bookInfo.Author))
                {
                    sb.Append(" and Author like @Author");
                    parameters["Author"] = "%" + book.bookInfo.Author + "%";
                }
                if (!string.IsNullOrEmpty(book.bookInfo.Publisher))
                {
                    sb.Append(" and Publisher like @Publisher");
                    parameters["Publisher"] = "%" + book.bookInfo.Publisher + "%";
                }
                

            }
            if (book != null && book.BookInfoId > 0)
            {
                sb.Append(" and b.BookInfoId=@BookInfoId");
                parameters["BookInfoId"] = book.BookInfoId;
            }

            if (book!=null && book.IsReserved != null)
            {
                if (book.IsReserved.GetValueOrDefault())
                {
                    sb.Append(" and IsReserved==1");
                }
                else
                {
                    sb.Append(" and IsReserved==0");
                }
            }

            sql += sb.ToString();
            sql += " order by b.BookInfoId";
            DapperUtil dapper = new DapperUtil("conStr");
            return dapper.GetMultModelList<Book>(
                sql,
                new[] { typeof(Book), typeof(BookInfo) },
                (objs) =>
                {
                    Book book1 = objs[0] as Book;
                    BookInfo bookInfo = objs[1] as BookInfo;
                    book1.bookInfo = bookInfo;
                    return book1;
                }, parameters, splitOn: "BookInfoId");

        }

        /// <summary>
        /// Get books Available by multi coditions
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public List<Book> getAvailableConditions(Book book)
        {
            string sql = @"select b.*,i.* from Books b
                           left join BookInfo i on b.BookInfoId=i.BookInfoId
                           where (UserId is NULL) and (IsReserved==0)";
            var parameters = new Dictionary<String, Object>();
            StringBuilder sb = new StringBuilder();
            if (book != null && book.bookInfo != null)
            {
                if (!string.IsNullOrEmpty(book.bookInfo.BookName))
                {
                    sb.Append(" and BookName like @BookName");
                    parameters["BookName"] = "%" + book.bookInfo.BookName + "%";
                }
                if (!string.IsNullOrEmpty(book.bookInfo.ISBN13))
                {
                    sb.Append(" and ISBN13 like @ISBN13");
                    parameters["ISBN13"] = "%" + book.bookInfo.ISBN13 + "%";
                }
                if (!string.IsNullOrEmpty(book.bookInfo.Author))
                {
                    sb.Append(" and Author like @Author");
                    parameters["Author"] = "%" + book.bookInfo.Author + "%";
                }
                if (!string.IsNullOrEmpty(book.bookInfo.Publisher))
                {
                    sb.Append(" and Publisher like @Publisher");
                    parameters["Publisher"] = "%" + book.bookInfo.Publisher + "%";
                }


            }
            if (book != null && book.BookInfoId > 0)
            {
                sb.Append(" and b.BookInfoId=@BookInfoId");
                parameters["BookInfoId"] = book.BookInfoId;
            }

            sql += sb.ToString();
            sql += " order by b.BookInfoId";
            DapperUtil dapper = new DapperUtil("conStr");
            return dapper.GetMultModelList<Book>(
                sql,
                new[] { typeof(Book), typeof(BookInfo) },
                (objs) =>
                {
                    Book book1 = objs[0] as Book;
                    BookInfo bookInfo = objs[1] as BookInfo;
                    book1.bookInfo = bookInfo;
                    return book1;
                }, parameters, splitOn: "BookInfoId");

        }

        /// <summary>
        /// set IsReserved status by book id
        /// </summary>
        /// <param name="bookId"></param>
        /// <param name="isReserved"></param>
        /// <returns></returns>
        public bool updateReservedStatusByBookId(int bookId, bool isReserved)
        {
            string sql = @"update Books set IsReserved=@IsReserved where BookId=@BookId";
            DapperUtil dapper = new DapperUtil("conStr");
            int reservedNum = isReserved ? 1 : 0;
            return dapper.ExecuteCommand(sql, new { IsReserved = reservedNum, BookId = bookId });
        }

        /// <summary>
        /// Lend books to many users once
        /// </summary>
        /// <param name="users">key:BookId</param>
        /// <returns></returns>
        public bool lendToUsers(Dictionary<int,User> users)
        {
            DapperUtil dapper = new DapperUtil("conStr");
            try
            {
                dapper.UseDbTransaction();
                string sql = "update Books set UserId=@UserId where BookId=@BookId";
                foreach (KeyValuePair<int,User> kvp in users)
                {
                    dapper.ExecuteCommand(sql, new { BookId = kvp.Key, UserId = kvp.Value.UserId });
                }
                string currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                sql = "insert into Book_User (BookId, UserId, BorrowDate) values (@BookId, @UserId,@BorrowDate)";
                foreach (KeyValuePair<int, User> kvp in users)
                {
                    dapper.ExecuteCommand(sql, new { BookId = kvp.Key, UserId = kvp.Value.UserId, BorrowDate= currentTime});
                }
                dapper.Commit();
                return true;

            }catch(Exception ex)
            {
                dapper.Rollback();
                return false;
            }

        }

        public bool returnFromUsers(Dictionary<int, User> users)
        {
            DapperUtil dapper = new DapperUtil("conStr");
            try
            {
                dapper.UseDbTransaction();
                string sql = "update Books set UserId=NULL where BookId=@BookId";
                foreach (KeyValuePair<int, User> kvp in users)
                {
                    dapper.ExecuteCommand(sql, new { BookId = kvp.Key});
                }
                string currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                sql = @"update Book_User set ReturnDate=@ReturnDate
                        where BookId=@BookId and UserId=@UserId and (ReturnDate is NULL)";
                foreach (KeyValuePair<int, User> kvp in users)
                {
                    dapper.ExecuteCommand(sql, new { BookId = kvp.Key, UserId = kvp.Value.UserId, ReturnDate = currentTime });
                }
                dapper.Commit();
                return true;

            }
            catch (Exception ex)
            {
                dapper.Rollback();
                return false;
            }

        }

        /// <summary>
        /// Get All the books Information
        /// </summary>
        /// <returns></returns>
        public List<Book> getAll()
        {
            String sql = @"select b.*,i.* from Books b
                           left join BookInfo i on b.BookInfoId=i.BookInfoId";
            DapperUtil dapper = new DapperUtil("conStr");
            return dapper.GetMultModelList<Book>(
                sql,
                new[] { typeof(Book), typeof(BookInfo) },
                (objs) =>
                {
                    Book book = objs[0] as Book;
                    BookInfo bookInfo = objs[1] as BookInfo;
                    book.bookInfo = bookInfo;
                    return book;
                }, splitOn: "BookInfoId");
        }

        public List<Book> getAllConditions(Book book)
        {
            string sql = @"select b.*,i.* from Books b
                           left join BookInfo i on b.BookInfoId=i.BookInfoId
                           where 1=1";
            var parameters = new Dictionary<String, Object>();
            StringBuilder sb = new StringBuilder();
            if (book != null && book.bookInfo != null)
            {
                if (!string.IsNullOrEmpty(book.bookInfo.BookName))
                {
                    sb.Append(" and BookName like @BookName");
                    parameters["BookName"] = "%" + book.bookInfo.BookName + "%";
                }
                if (!string.IsNullOrEmpty(book.bookInfo.ISBN13))
                {
                    sb.Append(" and ISBN13 like @ISBN13");
                    parameters["ISBN13"] = "%" + book.bookInfo.ISBN13 + "%";
                }
                if (!string.IsNullOrEmpty(book.bookInfo.Author))
                {
                    sb.Append(" and Author like @Author");
                    parameters["Author"] = "%" + book.bookInfo.Author + "%";
                }
                if (!string.IsNullOrEmpty(book.bookInfo.Publisher))
                {
                    sb.Append(" and Publisher like @Publisher");
                    parameters["Publisher"] = "%" + book.bookInfo.Publisher + "%";
                }


            }
            if (book != null && book.BookInfoId > 0)
            {
                sb.Append(" and b.BookInfoId=@BookInfoId");
                parameters["BookInfoId"] = book.BookInfoId;
            }

            if (book != null && book.IsReserved != null)
            {
                if (book.IsReserved.GetValueOrDefault())
                {
                    sb.Append(" and IsReserved==1");
                }
                else
                {
                    sb.Append(" and IsReserved==0");
                }
            }

            sql += sb.ToString();
            sql += " order by b.BookInfoId";
            DapperUtil dapper = new DapperUtil("conStr");
            return dapper.GetMultModelList<Book>(
                sql,
                new[] { typeof(Book), typeof(BookInfo) },
                (objs) =>
                {
                    Book book1 = objs[0] as Book;
                    BookInfo bookInfo = objs[1] as BookInfo;
                    book1.bookInfo = bookInfo;
                    return book1;
                }, parameters, splitOn: "BookInfoId");

        }


        public bool deleteByBookId(int bookId)
        {
            DapperUtil dapper = new DapperUtil("conStr");
            string sql = "delete from Books where BookId=@BookId";
            return dapper.ExecuteCommand(sql, new { BookId = bookId });
        }

        /// <summary>
        /// Supplier sell books
        /// </summary>
        /// <param name="supplierId"></param>
        /// <param name="bookInfoId"></param>
        /// <param name="qty"></param>
        /// <returns></returns>
        public bool addWithBookInfoId(int supplierId,int bookInfoId,int qty)
        {
           
            try
            {
                string sql = @"insert into Books (BookInfoId) 
                            values(@BookInfoId)";
                DapperUtil dapper = new DapperUtil("conStr");
                dapper.UseDbTransaction();
                for (int i=0;i<qty; i++)
                {
                    dapper.ExecuteCommand(sql, new { BookInfoId=bookInfoId });
                }

                String currentTime= DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string sql2 = @"insert into BookSales (SupplierId,BookInfoId,Quantity,SaleDate) 
                            values(@SupplierId,@BookInfoId,@Quantity,@SaleDate)";
                dapper.ExecuteCommand(sql2, new { SupplierId =supplierId, BookInfoId = bookInfoId, Quantity =qty, SaleDate = currentTime });
                dapper.Commit();
                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }
    }
}
