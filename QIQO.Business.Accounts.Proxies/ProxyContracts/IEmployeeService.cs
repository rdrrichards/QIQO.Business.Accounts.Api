using QIQO.Business.Accounts.Proxies.Models;
using QIQO.Business.Core.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QIQO.Business.Accounts.Proxies
{
    public interface IEmployeeService : IServiceContract
    {
        List<Employee> GetEmployees(Company company);
        int CreateEmployee(Employee employee);
        bool DeleteEmployee(Employee employee);
        Employee GetEmployee(int entity_person_key);
        Employee GetEmployeeByCredentials(string user_name);
        //List<Representative> GetAccountRepsByCompany(int company_key);
        //List<Representative> GetSalesRepsByCompany(int company_key);
        
        Task<List<Employee>> GetEmployeesAsync(Company company);
        Task<int> CreateEmployeeAsync(Employee employee);
        Task<bool> DeleteEmployeeAsync(Employee employee);
        Task<Employee> GetEmployeeAsync(int entity_person_key);
        Task<Employee> GetEmployeeByCredentialsAsync(string user_name);
        //Task<List<Representative>> GetAccountRepsByCompanyAsync(int company_key);
        //Task<List<Representative>> GetSalesRepsByCompanyAsync(int company_key);
    }

}
