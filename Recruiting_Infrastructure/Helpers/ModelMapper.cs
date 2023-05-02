using System;
using System.Net.NetworkInformation;
using Recruiting_ApplicationCore.Data;
using Recruiting_ApplicationCore.Model;

namespace Recruiting_Infrastructure.Helpers
{
    public static class ModelMapper
    {
        public static CandidateResponseModel ToCandidateResponseModel(this Candidate candidate)
        {
            return new CandidateResponseModel
            {
                Id = candidate.Id,
                Email = candidate.Email,
                FirstName = candidate.FirstName,
                LastName = candidate.LastName,
                MiddleName = candidate.MiddleName,
                ResumeURL = candidate.ResumeURL
            };
        }

        public static JobRequirementResponseModel ToJobRequirementResponseModel(this JobRequirement jR)
        {
            return new JobRequirementResponseModel
            {
                Id = jR.Id,
                NumberOfPositions = jR.NumberOfPositions,
                Title = jR.Title,
                Description = jR.Description,
                HiringManagerId = jR.HiringManagerId,
                HiringManagerName = jR.HiringManagerName,
                StartDate = jR.StartDate,
                IsActive = jR.IsActive,
                ClosedOn = jR.ClosedOn,
                ClosedReason = jR.ClosedReason,
                CreatedOn = jR.CreatedOn
            };
        }

        public static SubmissionStatusResponseModel ToSubmissionStatusResponseModel(this SubmissionStatus status)
        {
            return new SubmissionStatusResponseModel
            {
                Id = status.Id,
                LookupCode = status.LookupCode,
                SubmissionId = status.SubmissionId,
                Description = status.Description
            };
        }

        public static SubmissionResponseModel ToSubmissionResponseModel(this Submission submission)
        {
            return new SubmissionResponseModel
            {
                Id = submission.Id,
                JobRequirementId = submission.JobRequirementId,
                CandidateId = submission.CandidateId,
                SubmittedOn = submission.SubmittedOn,
                ConfirmedOn = submission.ConfirmedOn,
                RejectedOn = submission.RejectedOn,
                SubmissionStatusCode = submission.SubmissionStatusCode
            };
        }
    }
}

