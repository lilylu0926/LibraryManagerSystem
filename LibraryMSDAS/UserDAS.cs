using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
using LibraryMS.Model;

namespace LibraryMS.DAS
{
    public class UserDAS
    {
        public List<User> getAll()
        {
            DapperUtil dapper = new DapperUtil("conStr");
            string sql = @"select u.*,s.*,a.* from Users u
                           inner join UserStatus s on u.StatusId=s.StatusId
                           inner join AccountInfo a on a.AccountId=u.UserId";
            return dapper.GetMultModelList<User>(
                sql,
                new[] {typeof(User),typeof(UserStatus),typeof(Account)},
                (obs) =>
                {
                    User u = obs[0] as User;
                    UserStatus s = obs[1] as UserStatus;
                    Account a = obs[2] as Account;
                    u.status = s;
                    u.account = a;
                    return u;
                },splitOn:"StatusId,AccountId");
        }

        public User getById(int userId)
        {
            DapperUtil dapper = new DapperUtil("conStr");
            string sql = @"select u.*,s.*,a.* from Users u
                           inner join UserStatus s on u.StatusId=s.StatusId
                           inner join AccountInfo a on a.AccountId=u.UserId
                            where UserId=@UserId";
            List<User> users = dapper.GetMultModelList<User>(
                sql,
                new[] { typeof(User), typeof(UserStatus), typeof(Account) },
                (obs) =>
                {
                    User u = obs[0] as User;
                    UserStatus s = obs[1] as UserStatus;
                    Account a = obs[2] as Account;
                    u.status = s;
                    u.account = a;
                    return u;
                },new { UserId = userId } ,splitOn: "StatusId,AccountId");
            if (users != null && users.Count>0) 
                { return users[0]; }
        else return null;
        }

        public User getByUserName(String userName)
        {
            DapperUtil dapper = new DapperUtil("conStr");
            string sql = @"select u.*,s.*,a.* from Users u
                           inner join UserStatus s on u.StatusId=s.StatusId
                           inner join AccountInfo a on a.AccountId=u.UserId
                            where AccountName=@UserName";
            List<User> users = dapper.GetMultModelList<User>(
                sql,
                new[] { typeof(User), typeof(UserStatus), typeof(Account) },
                (obs) =>
                {
                    User u = obs[0] as User;
                    UserStatus s = obs[1] as UserStatus;
                    Account a = obs[2] as Account;
                    u.status = s;
                    u.account = a;
                    return u;
                }, new { UserName = userName }, splitOn: "StatusId,AccountId");
            if (users != null && users.Count > 0)
            { return users[0]; }
            else return null;
        }

        public List<User> getConditions(User user)
        {
            string sql = @"select u.*,s.*,a.* from Users u
                           inner join UserStatus s on u.StatusId=s.StatusId
                           inner join AccountInfo a on a.AccountId=u.UserId
                            where 1=1";
            var parameters = new Dictionary<String, Object>();
            StringBuilder sb = new StringBuilder();
            if (user != null && user.account!= null)
            {
                if (!string.IsNullOrEmpty(user.account.AccountName))
                {
                    sb.Append(" and a.AccountName like @AccountName");
                    parameters["AccountName"] = "%" + user.account.AccountName + "%";
                }
                if (!string.IsNullOrEmpty(user.account.FirstName))
                {
                    sb.Append(" and (a.FirstName like @FirstName) or  a.LastName like @FirstName");
                    parameters["FirstName"] = "%" + user.account.FirstName + "%";
                }
            }
            if (user!=null && user.StatusId>0 & user.StatusId < 7)
            {
                switch (user.StatusId)
                {
                    case 1: 
                        sb.Append(" and (u.StatusId=1)");
                        break;
                    case 2:
                        sb.Append(" and (u.StatusId=2)");
                        break;
                    case 3:
                        sb.Append(" and (u.StatusId=1 or u.StatusId=2)");
                        break;
                    case 4:
                        sb.Append(" and (u.StatusId=3)");
                        break;
                    case 5:
                        sb.Append(" and (u.StatusId=1 or u.StatusId=3)");
                        break;
                    case 6:
                        sb.Append(" and (u.StatusId=2 or u.StatusId=3)");
                        break;
                }
            }

            sql += sb.ToString();

            DapperUtil dapper = new DapperUtil("conStr");
            return dapper.GetMultModelList<User>(
                sql,
               new[] { typeof(User), typeof(UserStatus), typeof(Account) },
                (obs) =>
                {
                    User u = obs[0] as User;
                    UserStatus s = obs[1] as UserStatus;
                    Account a = obs[2] as Account;
                    u.status = s;
                    u.account = a;
                    return u;
                }, parameters, splitOn: "StatusId,AccountId");

        }

        public bool accepteMember(int userId)
        {
            string sql = @"update Users set StatusId=3 where UserId=@UserId";
            DapperUtil dapper = new DapperUtil("conStr");
            return dapper.ExecuteCommand(sql, new { UserId = userId});
        }

        public bool update(User user)
        {
            DapperUtil dapper = new DapperUtil("conStr");
            try
            {
                dapper.UseDbTransaction();


                string sql = @"update AccountInfo set AccountName=@AccountName,FirstName=@FirstName,LastName=@LastName,Password=@Password,Telephone=@Telephone
                            where AccountId=@AccountId";
                dapper.ExecuteCommand(sql, user.account);
                string sql1 = @"update Users set StatusId=@StatusId
                            where UserId=@UserId";
                dapper.ExecuteCommand(sql1, user);
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
