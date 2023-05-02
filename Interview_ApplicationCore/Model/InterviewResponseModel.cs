using System;
namespace Interview_ApplicationCore.Model
{
    public class InterviewResponseModel
    {
        public int InterviewId { get; set; }
        public int SubmissionId { get; set; }
        public int InterviewRound { get; set; }
        public DateTime ScheduledOn { get; set; }

        // Foreign Key
        public int RecruiterId { get; set; }
        public int InterviewTypeCode { get; set; }
        public int InterviewerId { get; set; }
        public int FeedbackId { get; set; }

        public int CandidateId { get; set; }
    }
}

