using ClassLibrary1;
using LibraryMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMS.DAS
{
    public class SaleHistoryDAS
    {
        /// <summary>
        /// seach sale history of given supply with multi condition
        /// </summary>
        /// <param name="saleHistory"></param>
        /// <param name="supplierId"></param>
        /// <returns></returns>
        public List<SaleHistory> getAllConditionsBySupplierId(SaleHistory saleHistory)
        {
            DapperUtil dapper = new DapperUtil("conStr");
            string sql = @"select  bs.*,b.* from BookSales bs
                            left join BookInfo b on b.BookInfoId=bs.BookInfoId
                            where 1=1";

            var parameters = new Dictionary<String, Object>();
            StringBuilder sb = new StringBuilder();
            

            if (saleHistory != null && saleHistory.SupplierId > 0)
            {
                sb.Append(" and SupplierId=@SupplierId");
                parameters["SupplierId"] = saleHistory.SupplierId;
            }

            if (saleHistory != null && saleHistory.SaleDate !=null)
            {
                sb.Append(" and SaleDate>=@StartSaleDate");
                parameters["StartSaleDate"] = saleHistory.SaleDate;
            }

            if (saleHistory != null && saleHistory.EndSaleDate != null)
            {
                sb.Append(" and SaleDate<=@EndSaleDate");
                parameters["EndSaleDate"] = saleHistory.EndSaleDate;
            }

            if (saleHistory != null && saleHistory.bookInfo != null)
            {
                if (!string.IsNullOrEmpty(saleHistory.bookInfo.BookName))
                {
                    sb.Append(" and BookName like @BookName");
                    parameters["BookName"] = "%" + saleHistory.bookInfo.BookName + "%";
                }
                if (!string.IsNullOrEmpty(saleHistory.bookInfo.ISBN13))
                {
                    sb.Append(" and ISBN13 like @ISBN13");
                    parameters["ISBN13"] = "%" + saleHistory.bookInfo.ISBN13 + "%";
                }
                if (!string.IsNullOrEmpty(saleHistory.bookInfo.Author))
                {
                    sb.Append(" and Author like @Author");
                    parameters["Author"] = "%" + saleHistory.bookInfo.Author + "%";
                }
                if (!string.IsNullOrEmpty(saleHistory.bookInfo.Publisher))
                {
                    sb.Append(" and Publisher like @Publisher");
                    parameters["Publisher"] = "%" + saleHistory.bookInfo.Publisher + "%";
                }

            }
            sql += sb.ToString();
            sql += " order by SaleDate desc";

            List<SaleHistory> histories = dapper.GetMultModelList<SaleHistory>(
                sql,
                new[] { typeof(SaleHistory), typeof(BookInfo) },
                (objs) =>
                {
                    SaleHistory saleHistory1 = objs[0] as SaleHistory;
                    BookInfo bookInfo = objs[1] as BookInfo;
                    saleHistory1.bookInfo = bookInfo;
                    return saleHistory1;
                },
                parameters, splitOn: "BookInfoId");

            return histories;

        }

        public bool deleteById(int bookSaleId)
        {
            DapperUtil dapper = new DapperUtil("conStr");
            string sql = "delete from BookSales where BookSaleId=@BookSaleId";
            return dapper.ExecuteCommand(sql, new { BookSaleId = bookSaleId });
        }
    }
}
