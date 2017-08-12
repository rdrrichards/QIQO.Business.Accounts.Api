using QIQO.Business.Accounts.Data.Interfaces;
using QIQO.Business.Accounts.Proxies.Models;
using QIQO.Business.Accounts.Proxies.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QIQO.Business.Accounts.Proxies.Clients
{
    public class AccountClient : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountEntityService _accountEntityService;

        public AccountClient(IAccountRepository accountRepository, IAccountEntityService accountEntityService)
        {
            _accountRepository = accountRepository;
            _accountEntityService = accountEntityService;
        }
        public int CreateAccount(Account account)
        {
            throw new NotImplementedException();
        }

        public Task<int> CreateAccountAsync(Account account)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAccount(Account account)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAccountAsync(Account account)
        {
            throw new NotImplementedException();
        }

        public List<Account> FindAccountByCompany(Company company, string pattern)
        {
            throw new NotImplementedException();
        }

        public Task<List<Account>> FindAccountByCompanyAsync(Company company, string pattern)
        {
            throw new NotImplementedException();
        }

        public Account GetAccountByCode(string account_code, string company_code)
        {
            throw new NotImplementedException();
        }

        public Task<Account> GetAccountByCodeAsync(string account_code, string company_code)
        {
            throw new NotImplementedException();
        }

        public Account GetAccountByID(int account_key, bool full_load)
        {
            throw new NotImplementedException();
        }

        public Task<Account> GetAccountByIDAsync(int account_key, bool full_load)
        {
            throw new NotImplementedException();
        }

        public string GetAccountNextNumber(Account account, QIQOEntityNumberType number_type)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetAccountNextNumberAsync(Account account, QIQOEntityNumberType number_type)
        {
            throw new NotImplementedException();
        }

        public List<Account> GetAccountsByCompany(Company company)
        {
            throw new NotImplementedException();
        }

        public Task<List<Account>> GetAccountsByCompanyAsync(Company company)
        {
            throw new NotImplementedException();
        }

        public List<Account> GetAccountsByEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task<List<Account>> GetAccountsByEmployeeAsync(Employee employee)
        {
            throw new NotImplementedException();
        }

        public List<Account> GetAccounts()
        {
            return _accountEntityService.Map(_accountRepository.GetAll());
        }

        public Task<List<Account>> GetAccountsAsync()
        {
            return Task.Run(() => GetAccounts());
        }
    }

}
