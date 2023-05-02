using System;
using Onboarding_ApplicationCore.Entity;
using System.ComponentModel.DataAnnotations;

namespace Onboarding_ApplicationCore.Model
{
    public class EmployeeCategoryResponseModel
    {
        public int Id { get; set; }
        public string LookupCode { get; set; }
        [StringLength(512, ErrorMessage = "Max 512 characters")]
        public string? Description { get; set; }
    }
}

