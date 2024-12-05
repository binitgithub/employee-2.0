using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using employee_2._0.Data;
using employee_2._0.Models;
using Microsoft.EntityFrameworkCore;

namespace employee_2._0.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext dbContext;

        public EmployeeRepository(EmployeeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Employee> CreateEmployeeAsync(Employee employee)
        {
            await dbContext.Employees.AddAsync(employee);
            await dbContext.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> DeleteEmployeeAsync(int id)
        {
            var deleteEmp = await dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (deleteEmp == null)
            {
                return null;
            }
            dbContext.Employees.Remove(deleteEmp);
            await dbContext.SaveChangesAsync();
            return deleteEmp;
        }

        public async Task<List<Employee>> GetAllEmployeeAsync()
        {
            return  await dbContext.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Employee> UpdateEmployeeAsync(int id, Employee employee)
        {
            var updateEmp = await dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (updateEmp == null)
            {
                return null;
            }

            updateEmp.FirstName = employee.FirstName;
            updateEmp.LastName = employee.LastName;
            updateEmp.PhoneNumber = employee.PhoneNumber;
            updateEmp.DateOfBirth = employee.DateOfBirth;
            updateEmp.DateOfJoining = employee.DateOfJoining;
            updateEmp.Department = employee.Department;
            updateEmp.Position = employee.Position;
            updateEmp.Salary = employee.Salary;
            updateEmp.IsActive = employee.IsActive;

            await dbContext.SaveChangesAsync();
            return employee;
        }
    }
}