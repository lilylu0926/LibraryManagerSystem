using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMS.Model
{
    public class Role
    {
        private int _roleId;
        private string roleName;

        public int RoleId { get => _roleId; set => _roleId = value; }
        public string RoleName { get => roleName; set => roleName = value; }
    }
}
