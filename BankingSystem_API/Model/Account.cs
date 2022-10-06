namespace BankingSystem_API.Model
{
    public class Account
    {
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public string AccountType { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public decimal InitalBalance { get; set; }
    }
}
