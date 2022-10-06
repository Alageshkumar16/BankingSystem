using BankingSystem_API.Model;

namespace BankingSystem_API.Interface
{
    public interface ITransactionRepository
    {
        string Withdraw(Transaction transaction);
        string Deposit(Transaction transaction);
    }
}
