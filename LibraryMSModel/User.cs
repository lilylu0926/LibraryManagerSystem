using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMS.Model
{
    public class User
    {
        private int _userId;
        private int _statusId;

        public int UserId { get => _userId; set => _userId = value; }

        public UserStatus status { get; set; }
        public Account account { get; set; }
        public int StatusId { get => _statusId; set => _statusId = value; }
    }
}
