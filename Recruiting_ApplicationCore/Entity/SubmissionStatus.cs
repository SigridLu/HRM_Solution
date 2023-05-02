using System;
using System.ComponentModel.DataAnnotations;

namespace Recruiting_ApplicationCore.Data
{
    public class SubmissionStatus
    {
        public int Id { get; set; }
        public string LookupCode { get; set; }
        [StringLength(512, ErrorMessage = "Max 512 characters")]
        public string? Description { get; set; }
        public int SubmissionId { get; set; }

        //naviagational property
        public Submission Submission { get; set; }
    }
}

