using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using QIQO.Business.Accounts.Api.ViewModels;

namespace QIQO.Business.Accounts.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountController : Controller
    {
        // GET: api/Account
        [HttpGet]
        public IEnumerable<AccountViewModel> Get()
        {
            return new AccountViewModel[] {
                new AccountViewModel { Account = new Models.Account { AccountName = "Account 1" } },
                new AccountViewModel { Account = new Models.Account { AccountName = "Account 2" } }
            };
        }

        // GET: api/Account/5
        [HttpGet("{id}", Name = "Get")]
        public AccountViewModel Get(int id)
        {
            return new AccountViewModel();
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
