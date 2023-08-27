using ClassLibrary1;
using LibraryMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMS.DAS
{
    public class RoleDAS
    {
        public List<Role> GetAllRoles()
        {
            DapperUtil dapper = new DapperUtil("conStr");
            string sql = "select * from Roles";
            return dapper.GetModelList<Role>(sql);
        }
    }
}
