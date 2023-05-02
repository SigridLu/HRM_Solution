using System;
using Interview_ApplicationCore.Contract.Repository;
using Interview_ApplicationCore.Contract.Service;
using Interview_ApplicationCore.Entity;
using Interview_ApplicationCore.Model;
using Interview_Infrastructure.Data;
using Interview_Infrastructure.Helpers;

namespace Interview_Infrastructure.Service
{
    public class RecruiterService : IRecruiterService
    {
        IRecruiterRepository recruiterRepo;

        public RecruiterService(IRecruiterRepository _recruiterRepo)
        {
            recruiterRepo = _recruiterRepo;
        }

        public async Task<int> AddRecruiterAsync(RecruiterRequestModel model)
        {
            var recruiter = new Recruiter();
            if (model != null)
            {
                recruiter.RecruiterId = model.RecruiterId;
                recruiter.FirstName = model.FirstName;
                recruiter.LastName = model.LastName;
                recruiter.EmployeeId = model.EmployeeId;
            }
            return await recruiterRepo.InsertAsync(recruiter);
        }

        public async Task<int> DeleteRecruiterAsync(int id)
        {
            return await recruiterRepo.DeleteAsync(id);
        }

        public async Task<IEnumerable<RecruiterResponseModel>> GetAllRecruiters()
        {
            var recruiters = await recruiterRepo.GetAllAsync();
            var response = recruiters.Select(x => x.ToRecruiterResponseModel());
            return response;
        }

        public async Task<RecruiterResponseModel> GetRecruiterByIdAsync(int id)
        {
            var recruiter = await recruiterRepo.GetByIdAsync(id);
            var response = recruiter.ToRecruiterResponseModel();
            return response;
        }

        public async Task<int> UpdateRecruiterAsync(RecruiterRequestModel model)
        {
            var existingRecruiter = await recruiterRepo.GetByIdAsync(model.RecruiterId);
            if (existingRecruiter == null)
                throw new Exception("Recruiter does not exist");
            else
            {
                if (model != null)
                {
                    var recruiter = new Recruiter();
                    recruiter.RecruiterId = model.RecruiterId;
                    recruiter.FirstName = model.FirstName;
                    recruiter.LastName = model.LastName;
                    recruiter.EmployeeId = model.EmployeeId;
                    return await recruiterRepo.UpdateAsync(recruiter);
                }
                else
                    return -1;
            }
        }
    }
}

