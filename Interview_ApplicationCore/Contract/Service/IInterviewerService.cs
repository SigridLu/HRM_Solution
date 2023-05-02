using System;
using Interview_ApplicationCore.Entity;
using Interview_ApplicationCore.Model;

namespace Interview_ApplicationCore.Contract.Service
{
    public interface IInterviewerService
    {
        Task<int> AddInterviewerAsync(InterviewerRequestModel model);
        Task<int> UpdateInterviewerAsync(InterviewerRequestModel model);
        Task<int> DeleteInterviewerAsync(int id);
        Task<IEnumerable<InterviewerResponseModel>> GetAllInterviewers();
        Task<InterviewerResponseModel> GetInterviewerByIdAsync(int id);
    }
}

