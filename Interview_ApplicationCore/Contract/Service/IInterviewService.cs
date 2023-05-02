using System;
using Interview_ApplicationCore.Entity;
using Interview_ApplicationCore.Model;

namespace Interview_ApplicationCore.Contract.Service
{
    public interface IInterviewService
    {
        Task<int> AddInterviewAsync(InterviewRequestModel model);
        Task<int> UpdateInterviewAsync(InterviewRequestModel model);
        Task<int> DeleteInterviewAsync(int id);
        Task<IEnumerable<InterviewResponseModel>> GetAllInterviews();
        Task<InterviewResponseModel> GetInterviewByIdAsync(int id);
    }
}