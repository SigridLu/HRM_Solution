using System;
namespace Recruiting_ApplicationCore.Data
{
    public class Submission
    {
        public int Id { get; set; }
        public int JobRequirementId { get; set; }
        public int CandidateId { get; set; }
        public DateTime? SubmittedOn { get; set; }
        public DateTime? ConfirmedOn { get; set; }
        public DateTime? RejectedOn { get; set; }
        public string SubmissionStatusCode { get; set; }
        public List<SubmissionStatus> SubmissionStatuses { get; set; }
        public JobRequirement JobRequirement { get; set; }
        public Candidate Candidate { get; set; }
    }
}

