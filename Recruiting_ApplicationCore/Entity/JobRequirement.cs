using System;
using System.ComponentModel.DataAnnotations;

namespace Recruiting_ApplicationCore.Data
{
    public class JobRequirement
    {
        public int Id { get; set; }
        public int? NumberOfPositions { get; set; }
        [StringLength(512, ErrorMessage = "Max 512 characters")]
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int HiringManagerId { get; set; }
        [StringLength(256, ErrorMessage = "Max 256 characters")]
        public string? HiringManagerName { get; set; }
        public DateTime? StartDate { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? ClosedOn { get; set; }
        public string? ClosedReason { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? JobCategory { get; set; } // Manager, employee, Lead, Senior
        public string? EmployeeType { get; set; }
        public ICollection<Submission>? Submissions { get; set; }
    }
}

