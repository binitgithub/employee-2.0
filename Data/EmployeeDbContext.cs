using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using employee_2._0.Models;
using Microsoft.EntityFrameworkCore;

namespace employee_2._0.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base (options){}
        public DbSet<Employee> Employees { get; set; }
    }
}