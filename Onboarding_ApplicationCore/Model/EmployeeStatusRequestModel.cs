using System;
using Onboarding_ApplicationCore.Entity;
using System.ComponentModel.DataAnnotations;

namespace Onboarding_ApplicationCore.Model
{
    public class EmployeeStatusRequestModel
    {
        public int Id { get; set; }
        public string LookupCode { get; set; }
        [StringLength(512, ErrorMessage = "Max 512 characters")]
        public string? Description { get; set; }
        [StringLength(16, ErrorMessage = "Max 16 characters")]
        public string? ABBR { get; set; }

        //naviagational property
        public ICollection<Employee>? Employees { get; set; }
    }
}

