using System;
using Interview_ApplicationCore.Entity;
using Interview_ApplicationCore.Model;

namespace Interview_ApplicationCore.Contract.Service
{
    public interface IInterviewFeedbackService
    {
        Task<int> AddInterviewFeedbackAsync(InterviewFeedbackRequestModel model);
        Task<int> UpdateInterviewFeedbackAsync(InterviewFeedbackRequestModel model);
        Task<int> DeleteInterviewFeedbackAsync(int id);
        Task<IEnumerable<InterviewFeedbackResponseModel>> GetAllInterviewFeedbacks();
        Task<InterviewFeedbackResponseModel> GetInterviewFeedbackByIdAsync(int id);
    }
}

