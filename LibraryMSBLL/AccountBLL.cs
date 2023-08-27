using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryMS.Model;
using LibraryMS.DAS;

namespace LibraryMS.BLL
{
    public class AccountBLL
    {
        /// <summary>
        /// Sign in with accountName and password
        /// </summary>
        /// <param name="account"> input accountName and password</param>
        /// <param name="msg">operate status</param>
        /// <returns> Account object from database</returns>
        public Account SignIn(Account account, out string msg)
        {
            AccountDAS accountDAL = new AccountDAS();
            Account account1 = accountDAL.GetByAccountName(account.AccountName);
            if (account1 == null)
            {
                msg = "Account name is not existed!";
                return null;
            }
            else
            {
                if (!account.Password.Equals(account1.Password))
                {
                    msg = "Password is not right!";
                    return null;
                }
                else
                {
                    msg = "Sign In successfully!";
                    return account1;
                }
            }


        }

        /// <summary>
        /// SignUp
        /// </summary>
        /// <param name="account"></param>
        /// <param name="msg">operate status</param>
        /// <returns></returns>
        public Account SignUp(Account account, out string msg)
        {
            AccountDAS accountDAL = new AccountDAS();
            Account account1 = accountDAL.GetByAccountName(account.AccountName);
            
            if (account1 != null)
            {
                msg = "Account name is existed!";
                return null;
            }
            Account newAccount = accountDAL.Add(account);
            if (newAccount==null)
            {
                msg = "Failed to insert into the database!";
                return null;
            }

            msg = "OK";
            return newAccount;

        }

        /// <summary>
        /// update account
        /// </summary>
        /// <param name="account"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool update(Account account, out String msg) 
        {
            AccountDAS accountDAL = new AccountDAS();
            Account account1 = accountDAL.GetByAccountName(account.AccountName);

            if (account1 != null)
            {
                if (account1.AccountId != account.AccountId)
                {
                    msg = "Account name is existed!";
                    return false;
                }              
            }
            bool inserted = accountDAL.update(account);
            if (!inserted)
            {
                msg = "Failed to update the profile!";
                return false;
            }

            msg = "Update the profile successfully";
            return true;

        }

        public Account GetById(int id)
        {
            AccountDAS accountDAL = new AccountDAS();
            return accountDAL.GetById(id);
        }

        public bool delete(Account account)
        {
            AccountDAS accountDAL = new AccountDAS();
            return accountDAL.delete(account);
        }


    }
}
