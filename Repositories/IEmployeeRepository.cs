using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using employee_2._0.Models;

namespace employee_2._0.Repositories
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllEmployeeAsync();
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<Employee> CreateEmployeeAsync(Employee employee);
        Task<Employee> UpdateEmployeeAsync(int id, Employee employee);
        Task<Employee> DeleteEmployeeAsync(int id);
    }
}