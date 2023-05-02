using System;
using System.ComponentModel.DataAnnotations;

namespace Onboarding_ApplicationCore.Entity
{
    public class EmployeeCategory
    {
        public int Id { get; set; }
        public string LookupCode { get; set; }
        [StringLength(512, ErrorMessage = "Max 512 characters")]
        public string? Description { get; set; }
        public ICollection<Employee>? Employees { get; set; }
    }
}

