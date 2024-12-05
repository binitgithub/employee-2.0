using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace employee_2._0.Models
{
    public class Employee
    {
        public int Id { get; set; } // Primary Key

        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Email { get; set; }
        
        public string PhoneNumber { get; set; }
        
        public DateTime DateOfBirth { get; set; }
        
        public DateTime DateOfJoining { get; set; }

        public string Department { get; set; }

        public string Position { get; set; }

        public decimal Salary { get; set; }

        public bool IsActive { get; set; } // Active/Inactive status
    }
}