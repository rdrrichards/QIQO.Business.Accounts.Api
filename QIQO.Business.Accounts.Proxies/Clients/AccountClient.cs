using QIQO.Business.Accounts.Data.Interfaces;
using QIQO.Business.Accounts.Proxies.Models;
using QIQO.Business.Accounts.Proxies.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QIQO.Business.Accounts.Proxies.Clients
{
    public class AccountClient : ClientBase, IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountEntityService _accountEntityService;
        private readonly ICompanyEntityService _companyEntityService;
        private readonly IEmployeeEntityService _employeeEntityService;
        private readonly IAddressService _addressService;
        private readonly IFeeScheduleService _feeScheduleService;

        public AccountClient(IAccountRepository accountRepository, IAccountEntityService accountEntityService,
            ICompanyEntityService companyEntityService, IEmployeeEntityService employeeEntityService,
            IAddressService addressService, IFeeScheduleService feeScheduleService)
        {
            _accountRepository = accountRepository;
            _accountEntityService = accountEntityService;
            _companyEntityService = companyEntityService;
            _employeeEntityService = employeeEntityService;
            _addressService = addressService;
            _feeScheduleService = feeScheduleService;
        }
        public int SaveAccount(Account account)
        {
            return ExecuteHandledOperation(() => { return _accountRepository.Save(_accountEntityService.Map(account)); });
        }

        public Task<int> SaveAccountAsync(Account account)
        {
            return Task.Run(() => SaveAccount(account));
        }

        public bool DeleteAccount(Account account)
        {
            return ExecuteHandledOperation(() =>
            {
                _accountRepository.Delete(_accountEntityService.Map(account));
                return true;
            });
        }

        public Task<bool> DeleteAccountAsync(Account account)
        {
            return Task.Run(() => DeleteAccount(account));
        }

        public List<Account> FindAccountByCompany(Company company, string pattern)
        {
            return ExecuteHandledOperation(() => { return _accountEntityService.Map(_accountRepository.FindAll(company.CompanyKey, pattern)); });
        }

        public Task<List<Account>> FindAccountByCompanyAsync(Company company, string pattern)
        {
            return Task.Run(() => FindAccountByCompanyAsync(company, pattern));
        }

        public Account GetAccountByCode(string account_code, string company_code)
        {
            return ExecuteHandledOperation(() => { return _accountEntityService.Map(_accountRepository.GetByCode(account_code, company_code)); });
        }

        public Task<Account> GetAccountByCodeAsync(string account_code, string company_code)
        {
            return Task.Run(() => GetAccountByCode(account_code, company_code));
        }

        public Account GetAccountByID(int account_key, bool full_load)
        {
            // TODO: Need to handle full load here
            return ExecuteHandledOperation(() =>
            {
                var account = _accountEntityService.Map(_accountRepository.GetByID(account_key));
                if (full_load)
                {
                    account.Addresses = _addressService.GetAddressesByEntity(account.AccountKey, QIQOEntityType.Account);
                    account.FeeSchedules = _feeScheduleService.GetFeeSchedulesByAccount(account);
                }
                return account;
            });
        }

        public Task<Account> GetAccountByIDAsync(int account_key, bool full_load)
        {
            return Task.Run(() => GetAccountByID(account_key, full_load));
        }

        public string GetAccountNextNumber(Account account, QIQOEntityNumberType number_type)
        {
            return ExecuteHandledOperation(() => { return _accountRepository.GetNextNumber(_accountEntityService.Map(account), (int)number_type); });
        }

        public Task<string> GetAccountNextNumberAsync(Account account, QIQOEntityNumberType number_type)
        {
            return Task.Run(() => GetAccountNextNumber(account, number_type));
        }

        public List<Account> GetAccountsByCompany(Company company)
        {
            return ExecuteHandledOperation(() => { return _accountEntityService.Map(_accountRepository.GetAll(_companyEntityService.Map(company))); });
        }

        public Task<List<Account>> GetAccountsByCompanyAsync(Company company)
        {
            return Task.Run(() => GetAccountsByCompany(company));
        }

        public List<Account> GetAccountsByEmployee(Employee employee)
        {
            return ExecuteHandledOperation(() => { return _accountEntityService.Map(_accountRepository.GetAll(_employeeEntityService.Map(employee))); });
        }

        public Task<List<Account>> GetAccountsByEmployeeAsync(Employee employee)
        {
            return Task.Run(() => GetAccountsByEmployee(employee));
        }

        public List<Account> GetAccounts()
        {
            return ExecuteHandledOperation(() =>
            {
                var accounts = _accountEntityService.Map(_accountRepository.GetAll());

                foreach (var account in accounts)
                    account.Addresses = _addressService.GetAddressesByEntity(account.AccountKey, QIQOEntityType.Account);

                return accounts;
            });
        }

        public Task<List<Account>> GetAccountsAsync()
        {
            return Task.Run(() => GetAccounts());
        }
    }
}
