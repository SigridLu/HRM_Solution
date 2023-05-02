using System;
using Interview_ApplicationCore.Entity;

namespace Interview_ApplicationCore.Model
{
    public class InterviewRequestModel
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
        /*public List<InterviewType> InterviewTypes { get; set; }
        public List<Interviewer> Interviewers { get; set; }
        public List<InterviewFeedback> InterviewFeedbacks { get; set; }
        public List<Recruiter> Recruiters { get; set; }*/

        public int CandidateId { get; set; }
    }
}

