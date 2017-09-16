using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using QIQO.Business.Accounts.Api.ViewModels;
using QIQO.Business.Accounts.Proxies;
using System.Threading.Tasks;

namespace QIQO.Business.Accounts.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/accounts")]
    public class AccountController : QIQOControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        // GET: api/Account
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return await ExecuteHandledOperationAsync(() =>
            {
                var ret = new List<AccountViewModel>();
                foreach (var acct in _accountService.GetAccountsAsync().Result)
                    ret.Add(new AccountViewModel { Account = acct });

                return ret;
            });
        }

        // GET: api/Account/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            return await ExecuteHandledOperationAsync(() =>
            {
                var account = _accountService.GetAccountByIDAsync(id, true);
                return new AccountViewModel { Account = account.Result };
            });            
        }

        // POST: api/Account
        [HttpPost]
        public async Task Post([FromBody]AccountViewModel value)
        {
            await ExecuteHandledOperationAsync(() =>
            {
                _accountService.SaveAccountAsync(value.Account);
            });
        }

        // PUT: api/Account/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody]AccountViewModel value)
        {
            await ExecuteHandledOperationAsync(() =>
            {
                _accountService.SaveAccountAsync(value.Account);
            });
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await ExecuteHandledOperationAsync(() =>
            {
                var account = _accountService.GetAccountByIDAsync(id, false);
                _accountService.DeleteAccountAsync(account.Result);
            });
        }
    }
}
