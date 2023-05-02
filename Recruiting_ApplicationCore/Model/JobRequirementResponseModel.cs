using System;
using System.ComponentModel.DataAnnotations;

namespace Recruiting_ApplicationCore.Model
{
    public class JobRequirementResponseModel
    {
        public int Id { get; set; }
        public int? NumberOfPositions { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int HiringManagerId { get; set; }
        public string? HiringManagerName { get; set; }
        public DateTime? StartDate { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? ClosedOn { get; set; }
        public string? ClosedReason { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}

