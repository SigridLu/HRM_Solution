using System;
namespace Interview_ApplicationCore.Entity
{
    public class Interview
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

        // Navigation Property
        public List<InterviewType> InterviewTypes { get; set; }
        public List<Interviewer> Interviewers { get; set; }
        public List<InterviewFeedback> InterviewFeedbacks { get; set; }
        public List<Recruiter> Recruiters { get; set; }

        // Navigation Property for Candidate in Recruiting assembly
        public int CandidateId { get; set; }
    }
}

