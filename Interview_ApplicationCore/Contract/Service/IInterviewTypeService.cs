using System;
using Interview_ApplicationCore.Entity;
using Interview_ApplicationCore.Model;

namespace Interview_ApplicationCore.Contract.Service
{
    public interface IInterviewTypeService
    {
        Task<int> AddInterviewTypeAsync(InterviewTypeRequestModel model);
        Task<int> UpdateInterviewTypeAsync(InterviewTypeRequestModel model);
        Task<int> DeleteInterviewTypeAsync(int id);
        Task<IEnumerable<InterviewTypeResponseModel>> GetAllInterviewTypes();
        Task<InterviewTypeResponseModel> GetInterviewTypeByIdAsync(int id);
    }
}

