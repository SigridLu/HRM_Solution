using System;
using Recruiting_ApplicationCore.Contract.Repository;
using System.Net.NetworkInformation;
using Recruiting_ApplicationCore.Contract.Service;
using Recruiting_ApplicationCore.Model;
using Recruiting_ApplicationCore.Data;
using Recruiting_Infrastructure.Helpers;

namespace Recruiting_Infrastructure.Service
{
    public class SubmissionStatusService : ISubmissionStatusService
    {
        ISubmissionStatusRepository statusRepository;
        ISubmissionRepository submissionRepository;

        public SubmissionStatusService(ISubmissionStatusRepository _status, ISubmissionRepository submissionRepository)
        {
            statusRepository = _status;
            this.submissionRepository = submissionRepository;
        }

        public async Task<int> AddStatusAsync(SubmissionStatusRequestModel model)
        {
            //Looks for the associated submission to compare status states.If it isnt changed, reject status addition.
            var relevantSubmission = await submissionRepository.FirstOrDefaultWithIncludesAsync(s => s.CandidateId == model.CandidateId &&
                s.JobRequirementId == model.JobRequirementId, s => s.SubmissionStatuses);
            //Last changed status
            var statusList = relevantSubmission.SubmissionStatuses.Count - 1;
            var existingStatus = relevantSubmission.SubmissionStatuses.FirstOrDefault(s => s.Id == relevantSubmission.SubmissionStatuses[statusList].Id);
            if (existingStatus != null && existingStatus.LookupCode == model.LookupCode)
            {
                throw new Exception("Status is not changing");
            }
            SubmissionStatus status = new SubmissionStatus();
            if (model != null)
            {
                status.SubmissionId = relevantSubmission.Id;
                status.LookupCode = model.LookupCode;
                status.Description = model.Description;
                status.Submission = relevantSubmission;
            }
            //returns number of rows affected, typically 1
            return await statusRepository.InsertAsync(status);
        }

        public async Task<int> DeleteStatusAsync(int id)
        {
            //returns number of rows affected, typically 1
            return await statusRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<SubmissionStatusResponseModel>> GetAllStatus()
        {
            var statuses = await statusRepository.GetAllAsync();
            var response = statuses.Select(x => x.ToSubmissionStatusResponseModel());
            return response;
        }

        public async Task<SubmissionStatusResponseModel> GetStatusByIdAsync(int id)
        {
            var stat = await statusRepository.GetByIdAsync(id);
            var response = stat.ToSubmissionStatusResponseModel();
            return response;
        }

        public async Task<int> UpdateStatusAsync(SubmissionStatusRequestModel model)
        {
            // Could be improved because now we have status Id but its fine 
            var relevantSubmission = await submissionRepository.FirstOrDefaultWithIncludesAsync(s => s.Id == model.SubmissionId, s => s.SubmissionStatuses);
            //Last changed status
            var statusList = relevantSubmission.SubmissionStatuses.Count - 1;
            var existingStatus = relevantSubmission.SubmissionStatuses.FirstOrDefault(s => s.Id == relevantSubmission.SubmissionStatuses[statusList].Id);
            if (existingStatus != null && existingStatus.LookupCode == model.LookupCode)
            {
                throw new Exception("Status is not changing");
            }
            SubmissionStatus status = new SubmissionStatus();
            if (model != null)
            {
                status.Id = model.Id;
                status.SubmissionId = model.SubmissionId;
                status.LookupCode = model.LookupCode;
                status.Description = model.Description;
                return await statusRepository.UpdateAsync(status);
            }

            else
            {
                //unsuccessful update
                return -1;
            }

        }
    }
}

