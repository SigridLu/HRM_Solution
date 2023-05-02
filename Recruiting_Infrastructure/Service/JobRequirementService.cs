using System;
using Recruiting_ApplicationCore.Contract.Repository;
using Recruiting_ApplicationCore.Contract.Service;
using Recruiting_ApplicationCore.Data;
using Recruiting_ApplicationCore.Model;
using Recruiting_Infrastructure.Helpers;

namespace Recruiting_Infrastructure.Service
{
    public class JobRequirementService : IJobRequirementService
    {
        IJobRequirementRepository jobRequirementRepository;
        public JobRequirementService(IJobRequirementRepository _jr)
        {
            jobRequirementRepository = _jr;
        }

        public async Task<int> AddJobRequirementAsync(JobRequirementRequestModel model)
        {
            JobRequirement jobRequirement = new JobRequirement();
            if (model != null)
            {
                jobRequirement.NumberOfPositions = model.NumberOfPositions;
                jobRequirement.Title = model.Title;
                jobRequirement.Description = model.Description;
                jobRequirement.HiringManagerId = model.HiringManagerId;
                jobRequirement.StartDate = model.StartDate;
                jobRequirement.IsActive = model.IsActive;
                jobRequirement.ClosedOn = model.ClosedOn;
                jobRequirement.ClosedReason = model.ClosedReason;
                jobRequirement.CreatedOn = model.CreatedOn;
                jobRequirement.JobCategory = model.JobCategory;
                jobRequirement.EmployeeType = model.EmployeeType;
                jobRequirement.Submissions = new List<Submission>();
            }
            //returns number of rows affected, typically 1
            return await jobRequirementRepository.InsertAsync(jobRequirement);
        }

        public async Task<int> DeleteJobRequirementAsync(int id)
        {
            //returns number of rows affected, typically 1
            return await jobRequirementRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<JobRequirementResponseModel>> GetAllJobRequirements()
        {
            var jRTypes = await jobRequirementRepository.GetAllAsync();
            var response = jRTypes.Select(x => x.ToJobRequirementResponseModel());
            return response;
        }

        public async Task<JobRequirementResponseModel> GetJobRequirementByIdAsync(int id)
        {
            var jR = await jobRequirementRepository.GetByIdAsync(id);
            var response = jR.ToJobRequirementResponseModel();
            return response;
        }

        public async Task<int> UpdateJobRequirementAsync(JobRequirementRequestModel model)
        {
            /*var existingJobRequirement = await jobRequirementRepository
                .GetJobRequirementsIncludingCategory(x => model.Id == x.Id);
            if (existingJobRequirement == null)
            {
                throw new Exception("JobRequirement does not exist");
            }*/
            JobRequirement jobRequirement = new JobRequirement();
            if (model != null)
            {
                jobRequirement.NumberOfPositions = model.NumberOfPositions;
                jobRequirement.Title = model.Title;
                jobRequirement.Description = model.Description;
                jobRequirement.HiringManagerId = model.HiringManagerId;
                jobRequirement.StartDate = model.StartDate;
                jobRequirement.IsActive = model.IsActive;
                jobRequirement.ClosedOn = model.ClosedOn;
                jobRequirement.ClosedReason = model.ClosedReason;
                jobRequirement.CreatedOn = model.CreatedOn;
                jobRequirement.JobCategory = model.JobCategory;
                return await jobRequirementRepository.UpdateAsync(jobRequirement);
            }
            else
            {
                //unsuccessful update
                return -1;
            }

        }
    }
}

