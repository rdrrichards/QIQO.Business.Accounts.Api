using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QIQO.Business.Accounts.Proxies.Models;

namespace QIQO.Business.Accounts.Proxies.Clients
{
    public class EmployeeClient : IEmployeeService
    {
        public int CreateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task<int> CreateEmployeeAsync(Employee employee)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteEmployeeAsync(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployee(int entity_person_key)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetEmployeeAsync(int entity_person_key)
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployeeByCredentials(string user_name)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetEmployeeByCredentialsAsync(string user_name)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetEmployees(Company company)
        {
            throw new NotImplementedException();
        }

        public Task<List<Employee>> GetEmployeesAsync(Company company)
        {
            throw new NotImplementedException();
        }
    }
}
