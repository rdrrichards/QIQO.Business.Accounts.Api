using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using QIQO.Business.Accounts.Api.ViewModels;
using QIQO.Business.Accounts.Proxies;
using System.Threading.Tasks;
using QIQO.Business.Accounts.Proxies.Models;

namespace QIQO.Business.Accounts.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/companies")]
    public class CompanyController : QIQOControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IAccountService _accountService;

        public CompanyController(ICompanyService companyService, IAccountService accountService)
        {
            _companyService = companyService;
            _accountService = accountService;
        }
        // GET: api/companies
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var ret = new List<Company>();
            foreach (var acct in await _companyService.GetCompaniesAsync())
                ret.Add(acct);

            return Ok(ret);
        }

        // GET: api/companies/5
        [HttpGet("{id}/accounts")]
        public async Task<IActionResult> Get(int id)
        {
            var company = await _companyService.GetCompanyAsync(id);

            var ret = new List<AccountViewModel>();
            foreach (var acct in await _accountService.GetAccountsByCompanyAsync(company))
                ret.Add(new AccountViewModel { Account = acct });

            return Ok(ret);
        }
    }
}
