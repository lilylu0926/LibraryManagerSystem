using LibraryMS.DAS;
using LibraryMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMS.BLL
{
    public class UserBLL
    {
        public List<User> GetAll()
        {
            UserDAS userDAS = new UserDAS();
            return userDAS.getAll();
        }

        public User getById(int userId)
        {
            UserDAS userDAS = new UserDAS();
            return userDAS.getById(userId);
        }
        public User getByUserName(String userName)
        {
            UserDAS userDAS = new UserDAS();
            return userDAS.getByUserName(userName);
        }

        public List<User> getConditions(User user)
        {
            UserDAS userDAS = new UserDAS();
            return userDAS.getConditions(user);
        }

        public bool accepteMember(int userId)
        {
            UserDAS userDAS = new UserDAS();
            return userDAS.accepteMember(userId);
        }

        public bool update(User user, out String msg)
        {
            AccountDAS accountDAL = new AccountDAS();
            Account account1 = accountDAL.GetByAccountName(user.account.AccountName);

            if (account1 != null)
            {
                if (account1.AccountId != user.account.AccountId)
                {
                    msg = "Account name is existed!";
                    return false;
                }
            }
            UserDAS userDAS = new UserDAS();
            bool inserted = userDAS.update(user);
            if (!inserted)
            {
                msg = "Failed to update the profile!";
                return false;
            }

            msg = "Update the profile successfully";
            return true;

        }
    }

    
}
