namespace BankingSystem_API.Model
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public string TransactionType { get; set; }
        public decimal Amount { get; set; }
        public int AccountId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}
