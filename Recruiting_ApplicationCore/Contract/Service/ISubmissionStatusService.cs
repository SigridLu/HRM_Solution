using System;
using Recruiting_ApplicationCore.Model;

namespace Recruiting_ApplicationCore.Contract.Service
{
    public interface ISubmissionStatusService
    {
        Task<int> AddStatusAsync(SubmissionStatusRequestModel model);
        Task<int> UpdateStatusAsync(SubmissionStatusRequestModel model);
        Task<int> DeleteStatusAsync(int id);
        Task<IEnumerable<SubmissionStatusResponseModel>> GetAllStatus();
        Task<SubmissionStatusResponseModel> GetStatusByIdAsync(int id);
    }
}

