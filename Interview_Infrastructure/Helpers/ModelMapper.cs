using System;
using Interview_ApplicationCore.Entity;
using Interview_ApplicationCore.Model;

namespace Interview_Infrastructure.Helpers
{
    public static class ModelMapper
    {
        public static InterviewResponseModel ToInterviewResponseModel(this Interview interview)
        {
            return new InterviewResponseModel
            {
                InterviewId = interview.InterviewId,
                RecruiterId = interview.RecruiterId,
                SubmissionId = interview.SubmissionId,
                InterviewTypeCode = interview.InterviewTypeCode,
                InterviewRound = interview.InterviewRound,
                ScheduledOn = interview.ScheduledOn,
                InterviewerId = interview.InterviewerId,
                FeedbackId = interview.FeedbackId,
                CandidateId = interview.CandidateId
            };
        }

        public static InterviewerResponseModel ToInterviewerResponseModel(this Interviewer interviewer)
        {
            return new InterviewerResponseModel
            {
                InterviewerId = interviewer.InterviewerId,
                FirstName = interviewer.FirstName,
                LastName = interviewer.LastName,
                EmployeeId = interviewer.EmployeeId
            };
        }

        public static InterviewTypeResponseModel ToInterviewTypeResponseModel(this InterviewType interviewType)
        {
            return new InterviewTypeResponseModel
            {
                LookupCode = interviewType.LookupCode,
                Description = interviewType.Description
            };
        }

        public static InterviewFeedbackResponseModel ToInterviewFeedbackResponseModel(this InterviewFeedback interviewFeedback)
        {
            return new InterviewFeedbackResponseModel
            {
                InterviewFeedbackId = interviewFeedback.InterviewFeedbackId,
                Rating = interviewFeedback.Rating,
                comment = interviewFeedback.comment
            };
        }

        public static RecruiterResponseModel ToRecruiterResponseModel(this Recruiter recruiter)
        {
            return new RecruiterResponseModel
            {
                RecruiterId = recruiter.RecruiterId,
                FirstName = recruiter.FirstName,
                LastName = recruiter.LastName,
                EmployeeId = recruiter.EmployeeId
            };
        }
    }
}

