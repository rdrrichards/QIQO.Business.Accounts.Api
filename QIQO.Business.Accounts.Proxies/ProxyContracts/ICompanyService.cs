﻿using QIQO.Business.Accounts.Proxies.Models;
using QIQO.Business.Core.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QIQO.Business.Accounts.Proxies
{
    public interface ICompanyService : IServiceContract
    {
        List<Company> GetCompanies();
        List<Company> GetCompanies(Employee emp);
        void SaveCompany(Company company);
        void DeleteCompany(Company company);
        Company GetCompany(int company_key);
        string GetEmployeeRoleInCompany(Employee emp); // , Company company
        void CompanyAddEmployee(Company company, Employee emp, string role, string comment);
        string GetCompanyNextNumber(Company company, QIQOEntityNumberType number_type);
        void CompanyDeleteEmployee(Company company, Employee emp);

        Task<List<Company>> GetCompaniesAsync();
        Task<List<Company>> GetCompaniesAsync(Employee emp);
        Task SaveCompanyAsync(Company company);
        Task DeleteCompanyAsync(Company company);        
        Task<Company> GetCompanyAsync(int company_key);
        Task<string> GetEmployeeRoleInCompanyAsync(Employee emp); // , Company company
        Task CompanyAddEmployeeAsync(Company company, Employee emp, string role, string comment);
        Task<string> GetCompanyNextNumberAsync(Company company, QIQOEntityNumberType number_type);
        Task CompanyDeleteEmployeeAsync(Company company, Employee emp);
    }

}
