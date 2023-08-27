using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMS.Model
{
    public class Account
    {

        private int _accountId;
        private string _accountName;
        private string _firstName;
        private string _lastName;
        private string _password;
        private int _roleId;
        private string _telephone;

     

        private static Account _instance;   
        public Role role { get; set; }
        public int AccountId { get => _accountId; set => _accountId = value; }
        public string AccountName { get => _accountName; set => _accountName = value; }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public string Password { get => _password; set => _password = value; }
        public int RoleId { get => _roleId; set => _roleId = value; }
        public string Telephone { get => _telephone; set => _telephone = value; }
    }
}
