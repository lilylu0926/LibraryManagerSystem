using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryMS.Model;
using System.Security.Principal;
using System.Net;

namespace LibraryMS.DAS
{
    public class AccountDAS
    {
        /// <summary>
        /// Get account object by given accountName
        /// </summary>
        /// <param name="accountName">input accountName</param>
        /// <returns>Account get from database</returns>
        public Account GetByAccountName(string accountName)
        {
            DapperUtil dapper = new DapperUtil("conStr");
            string sql = @"select a.*,r.* from AccountInfo a
                           inner join Roles r  on a.RoleId=r.RoleId
                           where AccountName = @AccountName";
            List<Account> accounts = dapper.GetMultModelList<Account>(sql,
                new[] { typeof(Account), typeof(Role) },
                (obs) =>
                {
                    Account account = obs[0] as Account;
                    Role role = obs[1] as Role;
                    account.role = role;
                    return account;
                }, new { AccountName = accountName }, splitOn: "RoleId").Distinct().ToList(); 
            if (accounts != null && accounts.Count>0)
            {
                return accounts[0];
            }
            return null;
        }

        public Account GetById(int id)
        {
            DapperUtil dapper = new DapperUtil("conStr");
            string sql = @"select * from AccountInfo
                           where AccountId = @AccountId";
            return dapper.GetModel<Account>(sql, new { AccountId= id });
        }

        public Account Add(Account account)
        {
            DapperUtil dapper = new DapperUtil("conStr");
            try
            {
                dapper.UseDbTransaction();

                string sql = @"insert into AccountInfo (AccountName,FirstName,LastName,Password,RoleId,Telephone)
                            values (@AccountName,@FirstName,@LastName,@Password,@RoleId,@Telephone); SELECT last_insert_rowid()";
                int i = dapper.GetValue<int>(sql, account);
                



                if (account.RoleId == 2)
                {

                    string sql2 = @"insert into Users (UserId,StatusId)
                            values (@UserId,1) ";
                    dapper.ExecuteCommand(sql2, new { UserId= i});
                }
                dapper.Commit();
                account.AccountId= i;
                return account;
            }
            catch(Exception ex)
            {
                dapper.Rollback();
                return null;
            }
           
        }

        public bool update(Account account)
        {
            DapperUtil dapper = new DapperUtil("conStr");
            string sql = @"update AccountInfo set AccountName=@AccountName,FirstName=@FirstName,LastName=@LastName,Password=@Password,Telephone=@Telephone
                            where AccountId=@AccountId";
            return dapper.ExecuteCommand(sql, account);
        }

        public bool delete(Account account)
        {
            DapperUtil dapper = new DapperUtil("conStr");
            try
            {
                dapper.UseDbTransaction();
                //supplier
                if (account.RoleId == 3) 
                {
                    string sql = "delete from BookSales where SupplierId=@SupplierId";
                    dapper.ExecuteCommand(sql, new { SupplierId = account.AccountId });
                }else if (account.RoleId == 2)
                {
                    string sql2 = "delete from Book_User where UserId=@UserId";
                    dapper.ExecuteCommand(sql2, new { UserId = account.AccountId });

                    string sql3 = "delete from Users where UserId=@UserId";
                    dapper.ExecuteCommand(sql3, new { UserId = account.AccountId });
                }

                string sql4 = "delete from AccountInfo where AccountId=@AccountId";
                dapper.ExecuteCommand(sql4, new { AccountId = account.AccountId });


                dapper.Commit();
                return true;
            }catch(Exception ex) 
            { 
                dapper.Rollback();
                return false;
            }
        }
    }
}
