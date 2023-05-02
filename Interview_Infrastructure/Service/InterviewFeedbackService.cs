using System;
using Interview_ApplicationCore.Contract.Repository;
using Interview_ApplicationCore.Contract.Service;
using Interview_ApplicationCore.Entity;
using Interview_ApplicationCore.Model;
using Interview_Infrastructure.Helpers;

namespace Interview_Infrastructure.Service
{
    public class InterviewFeedbackService : IInterviewFeedbackService
    {
        IInterviewFeedbackRepository interviewFeedbackRepo;
        public InterviewFeedbackService(IInterviewFeedbackRepository _interviewFeedbackRepo)
        {
            interviewFeedbackRepo = _interviewFeedbackRepo;
        }

        public async Task<int> AddInterviewFeedbackAsync(InterviewFeedbackRequestModel model)
        {
            var interviewFeedback = new InterviewFeedback();
            if (model != null)
            {
                interviewFeedback.InterviewFeedbackId = model.InterviewFeedbackId;
                interviewFeedback.Rating = model.Rating;
                interviewFeedback.comment = model.comment;
            }
            return await interviewFeedbackRepo.InsertAsync(interviewFeedback);
        }

        public async Task<int> DeleteInterviewFeedbackAsync(int id)
        {
            return await interviewFeedbackRepo.DeleteAsync(id);
        }

        public async Task<IEnumerable<InterviewFeedbackResponseModel>> GetAllInterviewFeedbacks()
        {
            var interviewFeedbacks = await interviewFeedbackRepo.GetAllAsync();
            var response = interviewFeedbacks.Select(x => x.ToInterviewFeedbackResponseModel());
            return response;
        }

        public async Task<InterviewFeedbackResponseModel> GetInterviewFeedbackByIdAsync(int id)
        {
            var interviewFeedback = await interviewFeedbackRepo.GetByIdAsync(id);
            var response = interviewFeedback.ToInterviewFeedbackResponseModel();
            return response;
        }

        public async Task<int> UpdateInterviewFeedbackAsync(InterviewFeedbackRequestModel model)
        {
            var existingFeedback = await interviewFeedbackRepo.GetByIdAsync(model.InterviewFeedbackId);
            if (existingFeedback == null)
            {
                throw new Exception("Feedback does not exist");
            }
            else
            {
                var feedback = new InterviewFeedback();
                if (model != null)
                {
                    feedback.InterviewFeedbackId = model.InterviewFeedbackId;
                    feedback.Rating = model.Rating;
                    feedback.comment = model.comment;
                    return await interviewFeedbackRepo.UpdateAsync(feedback);
                }
                else
                    return -1;
            }
        }
    }
}

