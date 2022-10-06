using BankingSystem_API.Interface;
using BankingSystem_API.Model;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BankingSystem_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserAccountController : Controller
    {
        private readonly IUserAccountRepository _userAccountRepository;
        public UserAccountController(IUserAccountRepository userAccountRepository)
        {
            _userAccountRepository = userAccountRepository;
        }

        [HttpGet]
        [Route("GetAccount")]
        public ActionResult GetAccount([FromHeader][Required] int userId)
        {
            try
            {
                return Ok(_userAccountRepository.GetAccount(userId));
            }
            catch
            {
                return Ok("Exception");
            }
        }

        [HttpPost]
        [Route("CreateAccount")]
        public ActionResult CreateAccount([FromHeader][Required] string accountName,
            [FromHeader][Required] string accountType, [FromHeader][Required] int userId, [FromHeader][Required] string userName)
        {
            try
            {
                Account account = new Account
                {
                    AccountName = accountName,
                    AccountType = accountType,
                    UserId = userId,
                    UserName = userName
                };
                return Ok(_userAccountRepository.CreateAccount(account));
            }
            catch
            {
                return Ok("Exception");
            }
        }

        [HttpDelete]
        public ActionResult Delete([FromHeader][Required] int accountId)
        {
            try
            {
                return Ok(_userAccountRepository.DeleteAccount(accountId));
            }
            catch
            {
                return Ok("Exception");
            }
        }
    }
}
