using LibraryMS.DAS;
using LibraryMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMS.BLL
{
    public class BorrowHistoryBLL
    {
        public BorrowHistory getCurrentBorrow(int bookId, int userId)
        {
            BorrowHistoryDAS borrowHistoryDAS = new BorrowHistoryDAS();
            return borrowHistoryDAS.getCurrentBorrow(bookId, userId);
        }

        public List<BorrowHistory> getCurrentBorrowByUserId(int userId)
        {
            BorrowHistoryDAS borrowHistoryDAS = new BorrowHistoryDAS();
            return borrowHistoryDAS.getCurrentBorrowByUserId(userId);
        }

        public List<BorrowHistory> getHistoryBorrowByUserId(int userId)
        {
            BorrowHistoryDAS borrowHistoryDAS = new BorrowHistoryDAS();
            return borrowHistoryDAS.getHistoryBorrowByUserId(userId);
        }

        public bool deleteById(int id)
        {
            BorrowHistoryDAS borrowHistoryDAS = new BorrowHistoryDAS();
            return borrowHistoryDAS.deleteById(id);
        }

        public List<BorrowHistory> getAllConditions(Book book)
        {
            BorrowHistoryDAS borrowHistoryDAS = new BorrowHistoryDAS();
            return borrowHistoryDAS.getAllConditions(book);
        }
    }
}
