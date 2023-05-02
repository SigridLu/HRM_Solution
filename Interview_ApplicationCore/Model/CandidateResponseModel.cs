using System;
using System.ComponentModel.DataAnnotations;

namespace Interview_ApplicationCore.Model
{
    public class CandidateResponseModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required")]
        [StringLength(128, ErrorMessage = "Max 128 characters")]
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        [Required(ErrorMessage = "Required")]
        [StringLength(128, ErrorMessage = "Max 128 characters")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Required")]
        [RegularExpression(@"\b[A-Z0-9._%-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b")]
        [StringLength(256, ErrorMessage = "Max 256 characters")]
        public string Email { get; set; }
        public string? ResumeURL { get; set; }
    }
}

