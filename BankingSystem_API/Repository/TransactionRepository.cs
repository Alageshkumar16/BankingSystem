using BankingSystem_API.DbContexts;
using BankingSystem_API.Interface;
using BankingSystem_API.Model;

namespace BankingSystem_API.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        public string Withdraw(Transaction transaction)
        {
            using (var context = new ApiContext())
            {
                var accList = context.Account.ToList();
                Account account = accList.SingleOrDefault(a => a.AccountId == transaction.AccountId);
                if (transaction.TransactionType == "Withdraw" && account.InitalBalance > 100)
                {
                    decimal percentage = transaction.Amount / account.InitalBalance * 100;
                    if (percentage < 90)
                    {
                        account.InitalBalance -= transaction.Amount;
                        context.Transaction.AddRange(transaction);
                        context.SaveChanges();
                        return "Sucess";
                    }
                    else
                    {
                        return "Cannot withdraw an amount more than 90% of your initialbalance";
                    }
                }
                else
                {
                    return "Low balance";
                }
            }
        }
        public string Deposit(Transaction transaction)
        {
            using (var context = new ApiContext())
            {
                if (transaction.TransactionType == "Deposit" && transaction.Amount < 10000)
                {
                    var accList = context.Account.ToList();
                    if (accList.Count != 0)
                    {
                        Account account = accList.SingleOrDefault(a => a.AccountId == transaction.AccountId);
                        if (account != null)
                        {
                            var transactionList = context.Transaction.ToList();                            
                            if (transactionList.Count != 0)
                            {
                                var maxId = transactionList.Max(x => x.TransactionId);
                                account.AccountId = maxId != 0 ? maxId + 1 : 1;
                            }
                            else { transaction.TransactionId= 1; }                            
                            account.InitalBalance += transaction.Amount;
                            context.Transaction.AddRange(transaction);
                            context.SaveChanges();
                            return "Sucess";
                        }
                        else
                        {
                            return "Please enter the valid account number";
                        }
                    }
                    else
                    {
                        return "Please create your account";
                    }                    
                }
                else
                {
                    return "Cannot deposit more than $10000";
                }
            }
        }
    }
}
