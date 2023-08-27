using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMS.Model
{
    public class UserStatus
    {
        private int _statusId;
        private string _statusName;

        public UserStatus(int statusId, string statusName)
        {
            StatusId = statusId;
            StatusName = statusName;
        }

        public UserStatus()
        {
        }

        public int StatusId { get => _statusId; set => _statusId = value; }
        public string StatusName { get => _statusName; set => _statusName = value; }
    }
}
