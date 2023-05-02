using System;
using Interview_ApplicationCore.Contract.Repository;
using Interview_ApplicationCore.Contract.Service;
using Interview_ApplicationCore.Entity;
using Interview_ApplicationCore.Model;
using Interview_Infrastructure.Helpers;

namespace Interview_Infrastructure.Service
{
    public class InterviewTypeService : IInterviewTypeService
    {
        IInterviewTypeRepository interviewTypeRepo;
        public InterviewTypeService(IInterviewTypeRepository _interviewTypeRepo)
        {
            interviewTypeRepo = _interviewTypeRepo;
        }

        public async Task<int> AddInterviewTypeAsync(InterviewTypeRequestModel model)
        {
            var interviewType = new InterviewType();
            if (model != null)
            {
                interviewType.LookupCode = model.LookupCode;
                interviewType.Description = model.Description;
            }
            return await interviewTypeRepo.InsertAsync(interviewType);
        }

        public async Task<int> DeleteInterviewTypeAsync(int id)
        {
            return await interviewTypeRepo.DeleteAsync(id);
        }

        public async Task<IEnumerable<InterviewTypeResponseModel>> GetAllInterviewTypes()
        {
            var interviewTypes = await interviewTypeRepo.GetAllAsync();
            var response = interviewTypes.Select(x => x.ToInterviewTypeResponseModel());
            return response;
        }

        public async Task<InterviewTypeResponseModel> GetInterviewTypeByIdAsync(int id)
        {
            var interviewType = await interviewTypeRepo.GetByIdAsync(id);
            var response = interviewType.ToInterviewTypeResponseModel();
            return response;
        }

        public async Task<int> UpdateInterviewTypeAsync(InterviewTypeRequestModel model)
        {
            var existingType = await interviewTypeRepo.GetByIdAsync(model.LookupCode);
            if (existingType == null)
            {
                throw new Exception("Type does not exist");
            }
            else
            {
                var interviewType = new InterviewType();
                if (model != null)
                {
                    interviewType.LookupCode = model.LookupCode;
                    interviewType.Description = model.Description;
                    return await interviewTypeRepo.UpdateAsync(interviewType);
                }
                else
                    return -1;
            }
        }
    }
}

