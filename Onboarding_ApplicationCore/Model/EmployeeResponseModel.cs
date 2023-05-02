using System;
using System.ComponentModel.DataAnnotations;
using Onboarding_ApplicationCore.Entity;

namespace Onboarding_ApplicationCore.Model
{
    public class EmployeeResponseModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required")]
        [StringLength(128, ErrorMessage = "Max 128 characters")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Required")]
        [StringLength(128, ErrorMessage = "Max 128 characters")]
        public string LastName { get; set; }
        [StringLength(128, ErrorMessage = "Max 128 characters")]
        public string? MiddleName { get; set; }
        [Required(ErrorMessage = "Required")]
        [StringLength(9, ErrorMessage = "Max 9 characters")]
        public string SSN { get; set; }
        public DateTime? HireDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Address { get; set; }
        [Required(ErrorMessage = "Required")]
        [RegularExpression(@"\b[A-Z0-9._%-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b")]
        public string Email { get; set; }

        // Foreign Key
        public string EmployeeCategoryCode { get; set; }
        public string EmployeeStatusCode { get; set; }
        public string EmployeeRoleId { get; set; }
    }
}

