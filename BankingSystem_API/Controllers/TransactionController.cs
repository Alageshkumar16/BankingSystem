using BankingSystem_API.Interface;
using BankingSystem_API.Model;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BankingSystem_API.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ITransactionRepository _transactionRepository;
        public TransactionController(ITransactionRepository transactionRepository) { _transactionRepository = transactionRepository; }

        [HttpPost]
        [Route("Withdraw")]
        public ActionResult Withdraw([FromHeader][Required] int userId, [FromHeader][Required] string userName, [FromHeader][Required] int accountId, [FromHeader][Required] string accountType, [FromHeader][Required] string transactionType, decimal Amount)
        {
            try
            {
                Transaction transaction = new Transaction
                {
                    TransactionType = transactionType,
                    Amount = Amount,
                    AccountId = accountId,
                    UserId = userId,
                    UserName = userName
                };
                return Ok(_transactionRepository.Withdraw(transaction));
            }
            catch
            {
                return Ok("Exception");
            }
        }

        [HttpPost]
        [Route("Deposit")]
        public ActionResult Deposit([FromHeader][Required] int userId, [FromHeader][Required] string userName, [FromHeader][Required] int accountId, [FromHeader][Required] string accountType, [FromHeader][Required] string transactionType, decimal Amount)
        {
            try
            {
                Transaction transaction = new Transaction
                {
                    TransactionType = transactionType,
                    Amount = Amount,
                    AccountId = accountId,
                    UserId = userId,
                    UserName = userName
                };
                return Ok(_transactionRepository.Deposit(transaction));
            }
            catch
            {
                return Ok("Exception");
            }
        }
    }
}
