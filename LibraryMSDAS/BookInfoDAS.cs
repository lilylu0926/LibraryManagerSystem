using ClassLibrary1;
using LibraryMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LibraryMS.DAS
{
    public class BookInfoDAS
    {
        public List<BookInfo> getAll()
        {
            //String sql = "select * from BookInfo";
            //DapperUtil dapper = new DapperUtil("conStr");
            //return dapper.GetModelList<BookInfo>(sql);
            string sql = @"select bi.*,bs.* from BookInfo bi
                            left join Books bs on  bi.BookInfoId=bs.BookInfoId";

            DapperUtil dapper = new DapperUtil("conStr");
            List<BookInfo> bookInfowithBook = new List<BookInfo>();
            return dapper.GetMultModelList<BookInfo>(
                sql,
                new[] { typeof(BookInfo), typeof(Book) },
                (obs) =>
                {
                    BookInfo bookInfo1 = obs[0] as BookInfo;
                    Book book = obs[1] as Book;
                    BookInfo bookinfoItem = bookInfowithBook.FirstOrDefault(b => b.BookInfoId == bookInfo1.BookInfoId);
                    if (bookinfoItem == null)
                    {
                        bookInfo1.books = new List<Book>();
                        bookinfoItem = bookInfo1;
                        bookInfowithBook.Add(bookinfoItem);
                    }
                    bookinfoItem.books.Add(book);
                    return bookinfoItem;

                }, splitOn: "BookId").Distinct<BookInfo>().ToList();
        }
  


        public BookInfo getByISBN(String iSBN13)
        {
            String sql = "select * from BookInfo where ISBN13=@ISBN13";
            DapperUtil dapper = new DapperUtil("conStr");
            return dapper.GetModel<BookInfo>(sql, new { ISBN13 = iSBN13 });
        }


        
        public List<BookInfo> searchConditions(BookInfo bookInfo)
        {
            string sql = @"select bi.*,bs.* from BookInfo bi
                            left join Books bs on  bi.BookInfoId=bs.BookInfoId
                            where 1=1";
            StringBuilder sb = new StringBuilder();
            var parameters = new Dictionary<String, Object>();
            if (bookInfo != null)
            {
                if (!string.IsNullOrEmpty(bookInfo.BookName))
                {
                    sb.Append(" and BookName like @BookName");
                    parameters["BookName"] = "%" + bookInfo.BookName + "%";
                }
                if (!string.IsNullOrEmpty(bookInfo.ISBN13))
                {
                    sb.Append(" and ISBN13 like @ISBN13");
                    parameters["ISBN13"] = "%" + bookInfo.ISBN13 + "%";
                }
                if (!string.IsNullOrEmpty(bookInfo.Author))
                {
                    sb.Append(" and Author like @Author");
                    parameters["Author"] = "%" + bookInfo.Author + "%";
                }
                if (!string.IsNullOrEmpty(bookInfo.Publisher))
                {
                    sb.Append(" and Publisher like @Publisher");
                    parameters["Publisher"] = "%" + bookInfo.Publisher + "%";
                }

                sql += sb.ToString();
            }
            

            DapperUtil dapper = new DapperUtil("conStr");
            List<BookInfo> bookInfowithBook = new List<BookInfo>();
            return dapper.GetMultModelList<BookInfo>(
                sql,
                new[] { typeof(BookInfo), typeof(Book), },
                (obs) =>
                {
                    BookInfo bookInfo1 = obs[0] as BookInfo;
                    Book book = obs[1] as Book;
                    BookInfo bookinfoItem = bookInfowithBook.FirstOrDefault(b => b.BookInfoId == bookInfo1.BookInfoId);
                    if (bookinfoItem == null)
                    {
                        bookInfo1.books = new List<Book>();
                        bookinfoItem = bookInfo1;
                        bookInfowithBook.Add(bookinfoItem);
                    }
                    bookinfoItem.books.Add(book);
                    return bookinfoItem;

                }, parameters, splitOn: "BookId").Distinct<BookInfo>().ToList();

        }

        public bool add(BookInfo bookInfo)
        {
            string sql = @"insert into BookInfo (BookName,ISBN13,Author,Publisher,Price) 
                            values(@BookName,@ISBN13,@Author,@Publisher,@Price)";
            DapperUtil dapper = new DapperUtil("conStr");
            return dapper.ExecuteCommand(sql, bookInfo);
        }

        public bool update(BookInfo bookInfo)
        {
            string sql = @"update BookInfo set BookName=@BookName, ISBN13=@ISBN13, Author=@Author,Publisher=@Publisher,Price=@Price where BookInfoId=@BookInfoId";
            DapperUtil dapper = new DapperUtil("conStr");
            return dapper.ExecuteCommand(sql, bookInfo);
        }

        public bool deleteByBookInfoId(int bookInfoId)
        {
            DapperUtil dapper = new DapperUtil("conStr");
            try
            {
                dapper.UseDbTransaction();
                //delete from books
                string sql = "delete from Books where BookInfoId=@BookInfoId";
                dapper.ExecuteCommand(sql, new {BookInfoId =bookInfoId});
               // throw new Exception();
                sql = "delete from BookInfo where BookInfoId=@BookInfoId";
                dapper.ExecuteCommand(sql, new { BookInfoId = bookInfoId });
                dapper.Commit();
                return true;

            }catch(Exception ex)
            {
                dapper.Rollback();
                return false;
            }
        }




    }
}
