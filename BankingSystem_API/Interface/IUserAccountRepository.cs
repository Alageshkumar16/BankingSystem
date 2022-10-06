using BankingSystem_API.Model;

namespace BankingSystem_API.Interface
{
    public interface IUserAccountRepository
    {
        List<Account> CreateAccount(Account account);
        List<Account> GetAccount(int userId);
        string DeleteAccount(int accountId);
    }
}
