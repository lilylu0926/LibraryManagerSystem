using ClassLibrary1;
using LibraryMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMS.DAS
{
    public class BorrowHistoryDAS
    {
        public BorrowHistory getCurrentBorrow(int bookId, int userId)
        {
            DapperUtil dapper = new DapperUtil("conStr");
            string sql = @"select * from Book_User
                           where BookId = @BookId and UserId=@UserId and ReturnDate is NULL";
            List<BorrowHistory> histories= dapper.GetModelList<BorrowHistory>(sql, new { BookId = bookId, UserId = userId });
            if (histories.Count > 0)
            {
                return histories[0];
            }else { return null; }
        }

        public List<BorrowHistory> getCurrentBorrowByUserId(int userId)
        {
            DapperUtil dapper = new DapperUtil("conStr");
            string sql = @"select bu.*,b.*,bi.* from Book_User bu
                           left join Books b on bu.BookId=b.BookId
                           left join BookInfo bi on b.BookInfoId=bi.BookInfoId
                           where bu.UserId=@UserId and ReturnDate is NULL";
            List<BorrowHistory> histories = dapper.GetMultModelList<BorrowHistory>(
                sql, 
                new[] {typeof(BorrowHistory),typeof(Book),typeof(BookInfo) },
                (objs) =>
                {
                    BorrowHistory borrowHistory = objs[0] as BorrowHistory;
                    Book book = objs[1] as Book;
                    BookInfo bookInfo= objs[2] as BookInfo;
                    book.bookInfo = bookInfo;
                    borrowHistory.book = book;
                    return borrowHistory;
                },
                new {UserId = userId },splitOn:"BookId,BookInfoId");
            
            return histories;
            
        }

        public List<BorrowHistory> getHistoryBorrowByUserId(int userId)
        {
            DapperUtil dapper = new DapperUtil("conStr");
            string sql = @"select bu.*,b.*,bi.* from Book_User bu
                           left join Books b on bu.BookId=b.BookId
                           left join BookInfo bi on b.BookInfoId=bi.BookInfoId
                           where bu.UserId=@UserId and ReturnDate NOT NULL";
            List<BorrowHistory> histories = dapper.GetMultModelList<BorrowHistory>(
                sql,
                new[] { typeof(BorrowHistory), typeof(Book), typeof(BookInfo) },
                (objs) =>
                {
                    BorrowHistory borrowHistory = objs[0] as BorrowHistory;
                    Book book = objs[1] as Book;
                    BookInfo bookInfo = objs[2] as BookInfo;
                    book.bookInfo = bookInfo;
                    borrowHistory.book = book;
                    return borrowHistory;
                },
                new { UserId = userId }, splitOn: "BookId,BookInfoId");

            return histories;

        }

        public List<BorrowHistory> getAllConditions(Book book)
        {
            DapperUtil dapper = new DapperUtil("conStr");
            string sql = @"select bu.*,b.*,bi.* from Book_User bu
                           left join Books b on bu.BookId=b.BookId
                           left join BookInfo bi on b.BookInfoId=bi.BookInfoId
                           where bu.UserId=@UserId and ReturnDate NOT NULL";

            var parameters = new Dictionary<String, Object>();
            StringBuilder sb = new StringBuilder();
            if (book != null && book.UserId > 0)
            {
                parameters["UserId"] = book.UserId;
            }
                
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
            sql += sb.ToString();

            List<BorrowHistory> histories = dapper.GetMultModelList<BorrowHistory>(
                sql,
                new[] { typeof(BorrowHistory), typeof(Book), typeof(BookInfo) },
                (objs) =>
                {
                    BorrowHistory borrowHistory = objs[0] as BorrowHistory;
                    Book book1 = objs[1] as Book;
                    BookInfo bookInfo = objs[2] as BookInfo;
                    book1.bookInfo = bookInfo;
                    borrowHistory.book = book1;
                    return borrowHistory;
                },
                parameters, splitOn: "BookId,BookInfoId");

            return histories;

        }

        public bool deleteById(int id)
        {
            DapperUtil dapper = new DapperUtil("conStr");
            string sql = "delete from Book_User where Id=@Id";
            return dapper.ExecuteCommand(sql, new { Id = id });
        }
    }
}
