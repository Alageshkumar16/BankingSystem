using BankingSystem_API.DbContexts;
using BankingSystem_API.Interface;
using BankingSystem_API.Model;


namespace BankingSystem_API.Repository
{
    public class UserAccountRepository : IUserAccountRepository
    {
        public List<Account> CreateAccount(Account account)
        {
            using (var context = new ApiContext())
            {
                var accList = context.Account.ToList();
                if (accList.Count != 0)
                {
                    var maxId = accList.Max(x => x.AccountId);
                    account.AccountId = maxId != 0 ? maxId + 1 : 1;
                }
                else { account.AccountId = 1; }
                context.Account.AddRange(account);
                context.SaveChanges();
                var list = context.Account
                    .ToList();
                return list;
            }
        }

        public List<Account> GetAccount(int userId)
        {
            using (var context = new ApiContext())
            {
                List<Account> accountsList = context.Account.ToList();
                if (accountsList.Count != 0)
                {
                    var userAccountList = accountsList.Where(a => a.UserId == userId);
                    return userAccountList.ToList();
                }
                else
                    return accountsList;

            }
        }

        public string DeleteAccount(int accountId)
        {
            using (var context = new ApiContext())
            {
                var validValue = context.Account.FirstOrDefault(a => a.AccountId == accountId);
                if (validValue == null)
                    return "Not Found";
                context.Remove(context.Account.Single(a => a.AccountId == accountId));
                context.SaveChanges();
                return "Success";
            }
        }
    }
}
