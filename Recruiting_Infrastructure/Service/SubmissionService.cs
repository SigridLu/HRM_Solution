using System;
using Recruiting_ApplicationCore.Contract.Repository;
using Recruiting_ApplicationCore.Contract.Service;
using Recruiting_ApplicationCore.Data;
using Recruiting_ApplicationCore.Model;
using Recruiting_Infrastructure.Helpers;

namespace Recruiting_Infrastructure.Service
{
    public class SubmissionService : ISubmissionService
    {
        ISubmissionRepository _submissionRepository;
        ICandidateRepository _candidateRepository;
        ISubmissionStatusService _statusService;

        public SubmissionService(ISubmissionRepository submissions, ICandidateRepository candidateRepository, ISubmissionStatusService statusService)
        {
            _submissionRepository = submissions;
            _candidateRepository = candidateRepository;
            _statusService = statusService;
        }

        //Check if the candidate's submission is linked with jR to see if candidate has already submitted a submission to that same jR
        public async Task<int> AddSubmissionAsync(SubmissionRequestModel model)
        {
            var candidateJRSubs = await _candidateRepository.FirstOrDefaultWithIncludesAsync(x => x.Id == model.CandidateId, x => x.Submissions);
            var exists = candidateJRSubs.Submissions.FirstOrDefault(s => s.JobRequirementId == model.JobRequirementId);

            if (exists != null)
            {
                throw new Exception("Submission already made");
            }
            Submission submission = new Submission();

            if (model != null)
            {
                submission.JobRequirementId = model.JobRequirementId;
                submission.CandidateId = model.CandidateId;
                submission.SubmittedOn = model.SubmittedOn;
                submission.ConfirmedOn = model.ConfirmedOn;
                submission.RejectedOn = model.RejectedOn;
                submission.SubmissionStatusCode = "Submitted";
            }
            //returns number of rows affected, typically 1
            await _submissionRepository.InsertAsync(submission);
            await _statusService.AddStatusAsync(new SubmissionStatusRequestModel()
            {
                CandidateId = submission.CandidateId,
                JobRequirementId = submission.JobRequirementId,
                LookupCode = submission.SubmissionStatusCode,
                Description = "Submission created"
            });
            return 1; //Add in statusService for some reason with candidateid and job id
        }

        public async Task<int> DeleteSubmissionAsync(int id)
        {
            //returns number of rows affected, typically 1
            return await _submissionRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<SubmissionResponseModel>> GetAllSubmissions()
        {
            var submissions = await _submissionRepository.GetAllAsync();
            var response = submissions.Select(x => x.ToSubmissionResponseModel());
            return response;
        }

        public async Task<SubmissionResponseModel> GetSubmissionByIdAsync(int id)
        {
            var sub = await _submissionRepository.GetByIdAsync(id);
            var response = sub.ToSubmissionResponseModel();
            return response;
        }

        public async Task<int> UpdateSubmissionAsync(SubmissionRequestModel model)
        {
            var existingSubmission = await _submissionRepository.GetByIdAsync(model.Id);
            if (existingSubmission == null)
            {
                throw new Exception("Submission does not exist");
            }
            Submission submission = new Submission();
            if (model != null)
            {
                submission.Id = model.Id;
                submission.JobRequirementId = model.JobRequirementId;
                submission.CandidateId = model.CandidateId;
                submission.SubmittedOn = model.SubmittedOn;
                submission.ConfirmedOn = model.ConfirmedOn;
                submission.RejectedOn = model.RejectedOn;
                // Consider the impact of status history on this statement below
                submission.SubmissionStatusCode = model.SubmissionStatusCode;
                return await _submissionRepository.UpdateAsync(submission);
            }
            else
            {
                //unsuccessful update
                return -1;
            }

        }
    }
}

