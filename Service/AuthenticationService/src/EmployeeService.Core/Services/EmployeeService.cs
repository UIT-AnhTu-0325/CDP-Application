using AuthenticationService.Core.Interfaces.Repositories;
using AuthenticationService.Core.Interfaces.Services;
using AuthenticationService.Core.Models;
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationService.Core.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<AuthenticationService> _logger;
        public AuthenticationService(IEmployeeRepository employeeRepository, ILogger<AuthenticationService> logger)
        {
            _employeeRepository = employeeRepository??throw new ArgumentNullException(nameof(employeeRepository));
            _logger = logger??throw new ArgumentNullException(nameof(logger));
        }   
        public async Task<Employee> CreateEmployee(Employee employee)
        {
            try
            {
                return await _employeeRepository.CreateEmployee(employee);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to call CreateEmployees in service class, Error Message = {ex}.");
                throw;
            }
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            try
            {
                return await _employeeRepository.DeleteEmployee(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to call DeleteEmployee in service class, Error Message = {ex}.");
                throw;
            }
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            try
            {
                return await _employeeRepository.GetAllEmployees();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to call GetAllEmployees in service class, Error Message = {ex}.");
                throw;
            }
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            try
            {
                return await _employeeRepository.GetEmployeeById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to call GetEmployeeById in service class, Error Message = {ex}.");
                throw;
            }
        }

        public async Task<Object> UpdateEmployee(int id, Employee employee)
        {
            try
            {
                return await _employeeRepository.UpdateEmployee(id, employee);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to call UpdateEmployee in service class, Error Message = {ex}.");
                throw;
            }
        }
    }
}
