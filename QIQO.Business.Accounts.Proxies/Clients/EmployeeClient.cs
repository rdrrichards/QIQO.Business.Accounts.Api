using System.Collections.Generic;
using System.Threading.Tasks;
using QIQO.Business.Accounts.Proxies.Models;
using QIQO.Business.Accounts.Data.Interfaces;
using QIQO.Business.Accounts.Proxies.Services;

namespace QIQO.Business.Accounts.Proxies.Clients
{
    public class EmployeeClient : ClientBase, IEmployeeService
    {
        private readonly IPersonRepository _employeeRepository;
        private readonly IEmployeeEntityService _employeeEntityService;
        private readonly ICompanyEntityService _companyEntityService;

        public EmployeeClient(IPersonRepository employeeRepository, IEmployeeEntityService employeeEntityService,
            ICompanyEntityService companyEntityService)
        {
            _employeeRepository = employeeRepository;
            _employeeEntityService = employeeEntityService;
            _companyEntityService = companyEntityService;
        }
        public int SaveEmployee(Employee employee)
        {
            return ExecuteHandledOperation(() => { return _employeeRepository.Save(_employeeEntityService.Map(employee)); });
        }

        public Task<int> SaveEmployeeAsync(Employee employee)
        {
            return Task.Run(() => SaveEmployee(employee));
        }

        public bool DeleteEmployee(Employee employee)
        {
            return ExecuteHandledOperation(() =>
            {
                _employeeRepository.Delete(_employeeEntityService.Map(employee));
                return true;
            });
        }

        public Task<bool> DeleteEmployeeAsync(Employee employee)
        {
            return Task.Run(() => DeleteEmployee(employee));
        }

        public Employee GetEmployee(int entity_person_key)
        {
            return ExecuteHandledOperation(() => { return _employeeEntityService.Map(_employeeRepository.GetByID(entity_person_key)); });
        }

        public Task<Employee> GetEmployeeAsync(int entity_person_key)
        {
            return Task.Run(() => GetEmployee(entity_person_key));
        }

        public Employee GetEmployeeByCredentials(string user_name)
        {
            return ExecuteHandledOperation(() => { return _employeeEntityService.Map(_employeeRepository.GetByUserName(user_name)); });
        }

        public Task<Employee> GetEmployeeByCredentialsAsync(string user_name)
        {
            return Task.Run(() => GetEmployeeByCredentials(user_name));
        }

        public List<Employee> GetEmployees(Company company)
        {
            return ExecuteHandledOperation(() => { return _employeeEntityService.Map(_employeeRepository.GetAll(_companyEntityService.Map(company))); });
        }

        public Task<List<Employee>> GetEmployeesAsync(Company company)
        {
            return Task.Run(() => GetEmployees(company));
        }
    }
}
