using System;
using Recruiting_ApplicationCore.Model;

namespace Recruiting_ApplicationCore.Contract.Service
{
    public interface ISubmissionService
    {
        Task<int> AddSubmissionAsync(SubmissionRequestModel model);
        Task<int> UpdateSubmissionAsync(SubmissionRequestModel model);
        Task<int> DeleteSubmissionAsync(int id);
        Task<IEnumerable<SubmissionResponseModel>> GetAllSubmissions();
        Task<SubmissionResponseModel> GetSubmissionByIdAsync(int id);
    }
}

