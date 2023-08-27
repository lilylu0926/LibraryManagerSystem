using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMS.Model
{
    public class Book
    {

        private int _bookId;
        private int _bookInfoId;
        private bool? _isReserved;
        private int _userId;

        public int BookId { get => _bookId; set => _bookId = value; }
        public int BookInfoId { get => _bookInfoId; set => _bookInfoId = value; }
        
        public BookInfo bookInfo { get;set; }
        public int UserId { get => _userId; set => _userId = value; }
        public bool? IsReserved { get => _isReserved; set => _isReserved = value; }

    }
}
