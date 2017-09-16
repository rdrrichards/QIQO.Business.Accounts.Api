using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QIQO.Business.Accounts.Proxies.Models;
using QIQO.Business.Accounts.Data.Interfaces;
using QIQO.Business.Accounts.Proxies.Services;

namespace QIQO.Business.Accounts.Proxies.Clients
{
    public class CompanyClient : ClientBase, ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly ICompanyEntityService _companyEntityService;
        private readonly IEmployeeEntityService _employeeEntityService;

        public CompanyClient(ICompanyRepository companyRepository, ICompanyEntityService companyEntityService,
            IEmployeeEntityService employeeEntityService)
        {
            _companyRepository = companyRepository;
            _companyEntityService = companyEntityService;
            _employeeEntityService = employeeEntityService;
        }
        public void CompanyAddEmployee(Company company, Employee emp, string role, string comment)
        {
            throw new NotImplementedException();
        }

        public Task CompanyAddEmployeeAsync(Company company, Employee emp, string role, string comment)
        {
            return Task.Run(() => CompanyAddEmployee(company, emp, role, comment));
        }

        public void CompanyDeleteEmployee(Company company, Employee emp)
        {
            throw new NotImplementedException();
        }

        public Task CompanyDeleteEmployeeAsync(Company company, Employee emp)
        {
            return Task.Run(() => CompanyDeleteEmployee(company, emp));
        }

        public void SaveCompany(Company company)
        {
            ExecuteHandledOperation(() => { return _companyRepository.Save(_companyEntityService.Map(company)); });
        }

        public Task SaveCompanyAsync(Company company)
        {
            return Task.Run(() => SaveCompany(company));
        }

        public void DeleteCompany(Company company)
        {
            ExecuteHandledOperation(() => { _companyRepository.Delete(_companyEntityService.Map(company)); });
        }

        public Task DeleteCompanyAsync(Company company)
        {
            return Task.Run(() => DeleteCompany(company));
        }

        public List<Company> GetCompanies()
        {
            return ExecuteHandledOperation(() => { return _companyEntityService.Map(_companyRepository.GetAll()); });
        }

        public Task<List<Company>> GetCompaniesAsync()
        {
            return Task.Run(() => GetCompanies());
        }

        public List<Company> GetCompanies(Employee emp)
        {
            return ExecuteHandledOperation(() => { return _companyEntityService.Map(_companyRepository.GetAll(_employeeEntityService.Map(emp))); });
        }

        public Task<List<Company>> GetCompaniesAsync(Employee emp)
        {
            return Task.Run(() => GetCompanies(emp));
        }

        public Company GetCompany(int company_key)
        {
            return ExecuteHandledOperation(() => { return _companyEntityService.Map(_companyRepository.GetByID(company_key)); });
        }

        public Task<Company> GetCompanyAsync(int company_key)
        {
            return Task.Run(() => GetCompany(company_key));
        }

        public string GetCompanyNextNumber(Company company, QIQOEntityNumberType number_type)
        {
            return ExecuteHandledOperation(() => { return _companyRepository.GetNextNumber(_companyEntityService.Map(company), (int)number_type); });
        }

        public Task<string> GetCompanyNextNumberAsync(Company company, QIQOEntityNumberType number_type)
        {
            return Task.Run(() => GetCompanyNextNumber(company, number_type));
        }

        public string GetEmployeeRoleInCompany(Employee emp)
        {
            return string.Empty; // _companyRepository.
        }

        public Task<string> GetEmployeeRoleInCompanyAsync(Employee emp)
        {
            return Task.Run(() => GetEmployeeRoleInCompany(emp));
        }
    }
}
