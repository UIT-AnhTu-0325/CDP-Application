using AuthenticationService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationService.Core.Interfaces.Services
{
    public interface IAuthenticationService
    {
        public Task<IEnumerable<Employee>> GetAllEmployees();
        public Task<Employee> GetEmployeeById(int id);
        public Task<Employee> CreateEmployee(Employee employee);
        public Task<bool> DeleteEmployee(int id);
        public Task<Object> UpdateEmployee(int id, Employee employee);
    }
}
