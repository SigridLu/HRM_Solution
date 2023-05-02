using System;
using Interview_ApplicationCore.Contract.Repository;
using Interview_ApplicationCore.Contract.Service;
using Interview_ApplicationCore.Entity;
using Interview_ApplicationCore.Model;
using Interview_Infrastructure.Helpers;

namespace Interview_Infrastructure.Service
{
    public class InterviewService : IInterviewService
    {
        IInterviewRepository interviewRepo;

        public InterviewService(IInterviewRepository _interviewRepo)
        {
            interviewRepo = _interviewRepo;
        }

        public async Task<int> AddInterviewAsync(InterviewRequestModel model)
        {
            var interview = new Interview();
            if (model != null)
            {
                interview.InterviewId = model.InterviewId;
                interview.RecruiterId = model.RecruiterId;
                interview.SubmissionId = model.SubmissionId;
                interview.InterviewTypeCode = model.InterviewTypeCode;
                interview.InterviewRound = model.InterviewRound;
                interview.ScheduledOn = model.ScheduledOn;
                interview.InterviewerId = model.InterviewerId;
                interview.FeedbackId = model.FeedbackId;
                interview.CandidateId = model.CandidateId;
            }
            return await interviewRepo.InsertAsync(interview);
        }

        public async Task<int> DeleteInterviewAsync(int id)
        {
            return await interviewRepo.DeleteAsync(id);
        }

        public async Task<IEnumerable<InterviewResponseModel>> GetAllInterviews()
        {
            var interviews = await interviewRepo.GetAllAsync();
            var response = interviews.Select(x => x.ToInterviewResponseModel());
            return response;
        }

        public async Task<InterviewResponseModel> GetInterviewByIdAsync(int id)
        {
            var interview = await interviewRepo.GetByIdAsync(id);
            var response = interview.ToInterviewResponseModel();
            return response;

        }

        public async Task<int> UpdateInterviewAsync(InterviewRequestModel model)
        {
            var existingInterview = interviewRepo.GetByIdAsync(model.InterviewId);
            if (existingInterview == null)
                throw new Exception("Interview does not exist");
            else
            {
                var interview = new Interview();
                if (model != null)
                {
                    interview.InterviewId = model.InterviewId;
                    interview.RecruiterId = model.RecruiterId;
                    interview.SubmissionId = model.SubmissionId;
                    interview.InterviewTypeCode = model.InterviewTypeCode;
                    interview.InterviewRound = model.InterviewRound;
                    interview.ScheduledOn = model.ScheduledOn;
                    interview.InterviewerId = model.InterviewerId;
                    interview.FeedbackId = model.FeedbackId;
                    interview.CandidateId = model.CandidateId;
                }
                return await interviewRepo.UpdateAsync(interview);
            }
        }
    }
}

