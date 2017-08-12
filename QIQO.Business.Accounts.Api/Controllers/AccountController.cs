using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using QIQO.Business.Accounts.Api.ViewModels;
using QIQO.Business.Accounts.Proxies;

namespace QIQO.Business.Accounts.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/account")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        // GET: api/Account
        [HttpGet]
        public IEnumerable<AccountViewModel> Get()
        {
            var ret = new List<AccountViewModel>();
            foreach (var acct in _accountService.GetAccounts())
                ret.Add(new AccountViewModel { Account = acct });

            return ret;
        }

        // GET: api/Account/5
        [HttpGet("{id}", Name = "Get")]
        public AccountViewModel Get(int id)
        {
            return new AccountViewModel { Account = new Proxies.Models.Account { AccountName = "Account #11" } };
        }

        // POST: api/Account
        [HttpPost]
        public void Post([FromBody]AccountViewModel value)
        {
        }

        // PUT: api/Account/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]AccountViewModel value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
