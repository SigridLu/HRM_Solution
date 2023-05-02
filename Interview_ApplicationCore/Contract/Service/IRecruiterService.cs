using System;
using Interview_ApplicationCore.Entity;
using Interview_ApplicationCore.Model;

namespace Interview_ApplicationCore.Contract.Service
{
    public interface IRecruiterService
    {
        Task<int> AddRecruiterAsync(RecruiterRequestModel model);
        Task<int> UpdateRecruiterAsync(RecruiterRequestModel model);
        Task<int> DeleteRecruiterAsync(int id);
        Task<IEnumerable<RecruiterResponseModel>> GetAllRecruiters();
        Task<RecruiterResponseModel> GetRecruiterByIdAsync(int id);
    }
}

