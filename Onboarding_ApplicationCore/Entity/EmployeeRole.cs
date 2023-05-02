using System;
using System.ComponentModel.DataAnnotations;

namespace Onboarding_ApplicationCore.Entity
{
    public class EmployeeRole
    {
        public int Id { get; set; }
        public string LookupCode { get; set; }

        // Foreign Key
        public string Name { get; set; }
        public string ABBR { get; set; }

        // Navigation property
        public ICollection<Employee>? Employees { get; set; }
        public List<EmployeeRole>? RoleName { get; set; }
    }
}

