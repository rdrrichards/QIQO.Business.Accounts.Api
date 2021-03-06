﻿using QIQO.Business.Accounts.Proxies.Models;
using QIQO.Business.Core.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QIQO.Business.Accounts.Proxies
{
    public interface IAccountService : IServiceContract //, IDisposable
    {
        Account GetAccountByID(int account_key, bool full_load);
        List<Account> GetAccountsByEmployee(Employee employee);
        List<Account> GetAccountsByCompany(Company company);
        List<Account> GetAccounts();
        void SaveAccount(Account account);
        void DeleteAccount(Account account);
        string GetAccountNextNumber(Account account, QIQOEntityNumberType number_type);
        Account GetAccountByCode(string account_code, string company_code);
        List<Account> FindAccountByCompany(Company company, string pattern);

        Task<Account> GetAccountByIDAsync(int account_key, bool full_load);
        Task<List<Account>> GetAccountsByEmployeeAsync(Employee employee);
        Task<List<Account>> GetAccountsByCompanyAsync(Company company);
        Task<List<Account>> GetAccountsAsync();
        Task SaveAccountAsync(Account account);
        Task DeleteAccountAsync(Account account);
        Task<string> GetAccountNextNumberAsync(Account account, QIQOEntityNumberType number_type);
        Task<Account> GetAccountByCodeAsync(string account_code, string company_code);
        Task<List<Account>> FindAccountByCompanyAsync(Company company, string pattern);
    }
}
