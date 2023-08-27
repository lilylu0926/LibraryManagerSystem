using LibraryMS.DAS;
using LibraryMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMS.BLL
{
    public class RoleBLL
    {
        public List<Role> GetAllRoles()
        {
            RoleDAS roleDAS= new RoleDAS();
            return roleDAS.GetAllRoles();
        }
    }
}
