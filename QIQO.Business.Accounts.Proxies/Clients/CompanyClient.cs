using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QIQO.Business.Accounts.Proxies.Models;

namespace QIQO.Business.Accounts.Proxies.Clients
{
    public class CompanyClient : ICompanyService
    {
        public int CompanyAddEmployee(Company company, Employee emp, string role, string comment)
        {
            throw new NotImplementedException();
        }

        public Task<int> CompanyAddEmployeeAsync(Company company, Employee emp, string role, string comment)
        {
            throw new NotImplementedException();
        }

        public bool CompanyDeleteEmployee(Company company, Employee emp)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CompanyDeleteEmployeeAsync(Company company, Employee emp)
        {
            throw new NotImplementedException();
        }

        public int CreateCompany(Company company)
        {
            throw new NotImplementedException();
        }

        public Task<int> CreateCompanyAsync(Company company)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCompany(Company company)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCompanyAsync(Company company)
        {
            throw new NotImplementedException();
        }

        public List<Company> GetCompanies(Employee emp)
        {
            throw new NotImplementedException();
        }

        public Task<List<Company>> GetCompaniesAsync(Employee emp)
        {
            throw new NotImplementedException();
        }

        public Company GetCompany(int company_key)
        {
            throw new NotImplementedException();
        }

        public Task<Company> GetCompanyAsync(int company_key)
        {
            throw new NotImplementedException();
        }

        public string GetCompanyNextNumber(Company company, QIQOEntityNumberType number_type)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetCompanyNextNumberAsync(Company company, QIQOEntityNumberType number_type)
        {
            throw new NotImplementedException();
        }

        public string GetEmployeeRoleInCompany(Employee emp)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetEmployeeRoleInCompanyAsync(Employee emp)
        {
            throw new NotImplementedException();
        }
    }
}
