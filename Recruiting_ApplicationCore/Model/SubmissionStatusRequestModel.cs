using System;
using Recruiting_ApplicationCore.Data;

namespace Recruiting_ApplicationCore.Model
{
    public class SubmissionStatusRequestModel
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public int JobRequirementId { get; set; }
        public string LookupCode { get; set; }
        public string? Description { get; set; }
        public int SubmissionId { get; set; }
    }
}

