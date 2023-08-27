using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMS.Model
{
    public class BorrowHistory
    {
        private int _id;
        private int _bookId;
        private int _UserId;
        private String _borrowDate;
        private String _returnDate;

        public int BookId { get => _bookId; set => _bookId = value; }
        public int UserId { get => _UserId; set => _UserId = value; }
        public String BorrowDate { get => _borrowDate; set => _borrowDate = value; }
        public String ReturnDate { get => _returnDate; set => _returnDate = value; }
        public Book book { get; set; }
        public int Id { get => _id; set => _id = value; }
    }
}
