using System;
using Interview_ApplicationCore.Contract.Repository;
using Interview_ApplicationCore.Contract.Service;
using Interview_ApplicationCore.Entity;
using Interview_ApplicationCore.Model;
using Interview_Infrastructure.Helpers;
using Interview_Infrastructure.Repository;

namespace Interview_Infrastructure.Service
{
    public class InterviewerService : IInterviewerService
    {
        IInterviewerRepository interviewerRepo;
        public InterviewerService(IInterviewerRepository _interviewerRepo)
        {
            interviewerRepo = _interviewerRepo;
        }

        public async Task<int> AddInterviewerAsync(InterviewerRequestModel model)
        {
            var interviewer = new Interviewer();
            if (model != null)
            {
                interviewer.InterviewerId = model.InterviewerId;
                interviewer.FirstName = model.FirstName;
                interviewer.LastName = model.LastName;
                interviewer.EmployeeId = model.EmployeeId;
            }
            return await interviewerRepo.InsertAsync(interviewer);
        }

        public async Task<int> DeleteInterviewerAsync(int id)
        {
            return await interviewerRepo.DeleteAsync(id);
        }

        public async Task<IEnumerable<InterviewerResponseModel>> GetAllInterviewers()
        {
            var interviewers = await interviewerRepo.GetAllAsync();
            var response = interviewers.Select(x => x.ToInterviewerResponseModel());
            return response;
        }

        public async Task<InterviewerResponseModel> GetInterviewerByIdAsync(int id)
        {
            var interviewer = await interviewerRepo.GetByIdAsync(id);
            var response = interviewer.ToInterviewerResponseModel();
            return response;
        }

        public async Task<int> UpdateInterviewerAsync(InterviewerRequestModel model)
        {
            var existingInterviewer = await interviewerRepo.GetByIdAsync(model.InterviewerId);
            if (existingInterviewer == null)
            {
                throw new Exception("Interviewer does not exist");
            }
            else
            {
                var interviewer = new Interviewer();
                if (model != null)
                {
                    interviewer.InterviewerId = model.InterviewerId;
                    interviewer.FirstName = model.FirstName;
                    interviewer.LastName = model.LastName;
                    interviewer.EmployeeId = model.EmployeeId;
                    return await interviewerRepo.UpdateAsync(interviewer);
                }
                else
                    return -1;
            }
        }
    }
}

