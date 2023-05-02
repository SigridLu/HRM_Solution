using System;
using System.ComponentModel.DataAnnotations;

namespace Onboarding_ApplicationCore.Entity
{
    public class EmployeeStatus
    {
        public int Id { get; set; }
        public string LookupCode { get; set; }
        [StringLength(512, ErrorMessage = "Max 512 characters")]
        public string? Description { get; set; }
        [StringLength(16, ErrorMessage = "Max 16 characters")]
        public string? ABBR { get; set; }
        public ICollection<Employee>? Employees { get; set; }
    }
}

